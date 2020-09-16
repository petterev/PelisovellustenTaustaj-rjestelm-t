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

    public async Task<Player> Get(Guid id)
    {
        string plrs = await File.ReadAllTextAsync("game-dev.txt");

        List<Player> list = JsonConvert.DeserializeObject<List<Player>>(plrs);

        foreach (Player p in list)
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
        string plrs = await File.ReadAllTextAsync("game-dev.txt");

        List<Player> list = JsonConvert.DeserializeObject<List<Player>>(plrs);

        return list.ToArray();




    }
    public async Task<Player> Create(Player player)
    {
        PlayerList List = new PlayerList();
        string plrs = await File.ReadAllTextAsync("game-dev.txt");
        List = JsonConvert.DeserializeObject<PlayerList>(plrs);
        List.list.Add(player);


        await File.WriteAllTextAsync("game-dev.txt", JsonConvert.SerializeObject(List));


        return player;
    }
    public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        string plrs = await File.ReadAllTextAsync("game-dev.txt");

        List<Player> list = JsonConvert.DeserializeObject<List<Player>>(plrs);

        foreach (Player p in list)
        {

            if (p.Id == id)
            {
                p.Score = player.Score;

                await File.WriteAllTextAsync("game-dev.txt", JsonConvert.SerializeObject(list.ToArray()));

                return p;
            }
        }

        return null;
    }

    public async Task<Player> Delete(Guid id)
    {
        string plrs = await File.ReadAllTextAsync("game-dev.txt");

        List<Player> list = JsonConvert.DeserializeObject<List<Player>>(plrs);

        foreach (Player p in list)
        {
            if (id == p.Id)
            {
                //Player d;
                list.Remove(p);
            }
        }
        string json = JsonConvert.SerializeObject(list.ToArray());

        //write string to file
        File.WriteAllText("game-dev.txt", json);

        return null;
    }
}