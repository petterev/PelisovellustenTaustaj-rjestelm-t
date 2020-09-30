using System;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
public class FileRepository : IRepository
{

    public class PlayerList
    {
        public List<Player> list = new List<Player>();
    }


    public Task<Item> GiveItem(Guid id, Item item)
    {

        return null;
    }

    public Task<Player[]> GetWithNumOfItems(int i)
    {


        return null;
    }
    public Task<Player[]> FindPlayersWithItemOfType(ItemType itemType)
    {


        return null;
    }

    public Task<Player[]> GetWithScoreMin(int m)
    {


        return null;
    }
    public Task<Player> IncrementScore(Guid id, int i)
    {


        return null;
    }
    public Task<Player[]> GetTenHighest()
    {



        return null;
    }
    public Task<Player[]> GetAllWithTag(string tag)
    {

        return null;
    }


    public async Task<Player> Get(Guid id)
    {
        PlayerList List = await GetList();

        foreach (Player p in List.list)
        {
            if (p.Id == id)
            {
                return p;
            }
        }

        return null;
    }
    public async Task<Player[]> GetAll()
    {
        PlayerList List = new PlayerList();
        string plrs = await File.ReadAllTextAsync("game-dev.txt");

        List = JsonConvert.DeserializeObject<PlayerList>(plrs);

        return List.list.ToArray();




    }
    public async Task<Player> Create(Player player)
    {
        PlayerList List = await GetList();
        List.list.Add(player);

        await File.WriteAllTextAsync("game-dev.txt", JsonConvert.SerializeObject(List));


        return player;
    }
    public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        PlayerList List = await GetList();

        foreach (Player p in List.list)
        {

            if (p.Id == id)
            {
                p.Score = player.Score;

                await File.WriteAllTextAsync("game-dev.txt", JsonConvert.SerializeObject(List));

                return p;
            }
        }

        return null;
    }

    public async Task<Player> Delete(Guid id)
    {
        PlayerList List = await GetList();

        for (int i = 0; i < List.list.Count; i++)
        {
            if (id == List.list[i].Id)
            {
                Player d = List.list[i];
                List.list.RemoveAt(i);
                File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(List));
                return d;
            }
        }



        return null;
    }

    public async Task<Item> CreateItem(Guid playerId, Item item)
    {
        PlayerList List = await GetList();
        Player player = await Get(playerId);

        player.Items.Add(item);
        File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(List));
        return item;
    }
    public async Task<Item> GetItem(Guid playerId, Guid itemId)
    {
        PlayerList List = new PlayerList();
        string plrs = await File.ReadAllTextAsync("game-dev.txt");
        List = JsonConvert.DeserializeObject<PlayerList>(plrs);
        for (int i = 0; i < List.list.Count; i++)
        {
            if (List.list[i].Id == playerId)
            {
                foreach (Item item in List.list[i].Items)
                {
                    if (item.Id == itemId)
                    {

                        return item;
                    }


                }

            }
        }
        return null;
    }
    public async Task<Item[]> GetAllItems(Guid playerId)
    {
        PlayerList List = await GetList();
        for (int i = 0; i < List.list.Count; i++)
        {
            if (List.list[i].Id == playerId)
            {
                return List.list[i].Items.ToArray();
            }
        }
        return null;

    }
    public async Task<Item> UpdateItem(Guid playerId, Guid itemId, Item item)
    {
        PlayerList List = await GetList();
        Player player = await Get(playerId);

        for (int j = 0; j < player.Items.Count; j++)
        {
            if (player.Items[j].Id == itemId)
            {
                player.Items[j].Level = item.Level;
                File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(List));
                return player.Items[j];
            }
        }

        return null;
    }
    public async Task<Item> DeleteItem(Guid playerId, Guid itemId)
    {
        PlayerList List = await GetList();
        Player player = await Get(playerId);
        Item deletedItem;
        for (int i = 0; i < player.Items.Count; i++)
        {
            if (player.Items[i].Id == itemId)
            {
                deletedItem = player.Items[i];
                player.Items[i] = null;
                File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(List));
                return deletedItem;

            }

        }
        return null;
    }
    public async Task<PlayerList> GetList()
    {
        PlayerList List = new PlayerList();
        string plrs = await File.ReadAllTextAsync("game-dev.txt");
        List = JsonConvert.DeserializeObject<PlayerList>(plrs);
        return List;

    }
}