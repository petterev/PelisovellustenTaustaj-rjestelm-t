using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

public class MongoDBRepository : IRepository
{
    private readonly IMongoCollection<Player> _playerCollection;
    private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;

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




    public async Task<Player> Get(Guid id)
    {
        //var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
        var players = await _playerCollection.Find(null).ToListAsync();
        foreach (Player p in players)
        {
            if (p.Id == id)
                return p;
        }
        return null;
    }
    public async Task<Player[]> GetAll()
    {
        var players = await _playerCollection.Find(null).ToListAsync();
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
        //FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
        Player player = await Get(playerId);
        player.Items.Add(item);
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
    public async Task<Item> UpdateItem(Guid playerId, Item item)
    {
        Player player = await Get(playerId);

        return null;
    }
    public async Task<Item> DeleteItem(Guid playerId, Item item)
    {
        Player player = await Get(playerId);
        for (int i = 0; i < player.Items.Count; i++)
        {
            if (player.Items[i] == item)
                player.Items.RemoveAt(i);
        }
        return null;
    }



}