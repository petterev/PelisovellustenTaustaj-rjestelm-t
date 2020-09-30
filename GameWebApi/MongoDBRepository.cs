using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;

public class MongoDBRepository : IRepository
{
    private readonly IMongoCollection<Player> _playerCollection;
    private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;
    private ErrorHandlerMiddleware _middleware;

    public MongoDBRepository()
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var database = mongoClient.GetDatabase("game");
        _playerCollection = database.GetCollection<Player>("players");
        _bsonDocumentCollection = database.GetCollection<BsonDocument>("players");
    }


    public class PlayerList
    {
        public List<Player> list = new List<Player>();
    }

    public async Task<Player[]> GetWithNumOfItems(int i)
    {
        FilterDefinition<Player> filter = Builders<Player>.Filter.SizeGte(p => p.Items, i);

        List<Player> players = await _playerCollection.Find(filter).ToListAsync();

        return players.ToArray();
    }



    public async Task<Player[]> GetWithScoreMin(int m)
    {

        FilterDefinition<Player> filter = Builders<Player>.Filter.Gte("Score", m);

        List<Player> players = await _playerCollection.Find(filter).ToListAsync();

        return players.ToArray();

    }

    public async Task<Player[]> GetTenHighest()
    {

        SortDefinition<Player> sortDef = Builders<Player>.Sort.Ascending("Level");

        List<Player> players = await _playerCollection.Find(_ => true).Sort(sortDef).Limit(10).ToListAsync(); ;

        //List<Player> players = await cursor.ToListAsync();

        return players.ToArray();

    }

    public async Task<Item> GiveItem(Guid id, Item item)
    {

        var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
        var update = Builders<Player>.Update.Push(p => p.Items, item);

        await _playerCollection.FindOneAndUpdateAsync(filter, update);
        return item;
    }



    public async Task<Player[]> FindPlayersWithItemOfType(ItemType itemType)
    {

        var playersWithWeapons = Builders<Player>.Filter.ElemMatch<Item>(p => p.Items,
                Builders<Item>.Filter.Eq(i => i.Type, itemType));

        var players = await _playerCollection.Find(playersWithWeapons).ToListAsync();

        return players.ToArray();
    }
    public async Task<Player> IncrementScore(Guid id, int i)
    {
        FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);

        var update = Builders<Player>.Update.Inc("Score", i);
        await _playerCollection.UpdateOneAsync(filter, update);

        return await Get(id);
    }

    public async Task<Player[]> GetAllWithTag(string tag)
    {

        // var playersWithTag = Builders<Player>.Filter.ElemMatch<string>(p => p.tags,tag);
        // 

        var playersWithTag = Builders<Player>.Filter.Eq("Tags", tag);

        var players = await _playerCollection.Find(playersWithTag).ToListAsync();
        return players.ToArray();
    }

    public async Task<Player> Get(Guid id)
    {

        FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);
        Player player = await _playerCollection.Find(filter).FirstAsync();




        return player;
    }
    public async Task<Player[]> GetAll()
    {
        var players = await _playerCollection.Find(new BsonDocument()).ToListAsync();
        return players.ToArray();




    }
    public async Task<Player> Create(Player player)
    {
        await _playerCollection.InsertOneAsync(player);
        return player;

    }
    public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        Player player1 = new Player();
        player1.Score = player.Score;
        FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);
        await _playerCollection.ReplaceOneAsync(filter, player1);
        return player1;


    }

    public async Task<Player> Delete(Guid id)
    {
        FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);
        return await _playerCollection.FindOneAndDeleteAsync(filter);

    }

    public async Task<Item> CreateItem(Guid playerId, Item item)
    {

        FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
        Player player = await _playerCollection.Find(filter).FirstAsync();

        if (player == null)
            throw new NotFoundException();
        if (player.Items == null)
            player.Items = new List<Item>();

        player.Items.Add(item);
        await _playerCollection.ReplaceOneAsync(filter, player);
        return item;
    }
    public async Task<Item> GetItem(Guid playerId, Guid itemId)
    {
        Player player = await Get(playerId);
        foreach (Item i in player.Items)
        {
            if (i.Id == itemId)
            {
                return i;

            }

        }
        return null;
    }
    public async Task<Item[]> GetAllItems(Guid playerId)
    {

        Player player = await Get(playerId);
        return player.Items.ToArray();

    }
    public async Task<Item> UpdateItem(Guid playerId, Guid itemId, Item item)
    {
        Player player = await Get(playerId);
        for (int i = 0; i < player.Items.Count; i++)
        {
            if (player.Items[i].Id == itemId)
            {
                player.Items[i].Level = item.Level;
                return player.Items[i];
            }
        }

        return null;
    }
    public async Task<Item> DeleteItem(Guid playerId, Guid itemId)
    {
        FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
        Player player = await _playerCollection.Find(filter).FirstAsync();

        Item item1 = null;
        for (int i = 0; i < player.Items.Count; i++)
        {
            if (player.Items[i].Id == itemId)
            {
                item1 = player.Items[i];
                player.Items.RemoveAt(i);
                await _playerCollection.ReplaceOneAsync(filter, player);
                return item1;
            }

        }
        return null;
    }



}