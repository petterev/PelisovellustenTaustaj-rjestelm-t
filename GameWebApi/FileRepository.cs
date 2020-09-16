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
        PlayerList List = new PlayerList();
        string plrs = await File.ReadAllTextAsync("game-dev.txt");

        List = JsonConvert.DeserializeObject<PlayerList>(plrs);

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
        PlayerList List = new PlayerList();
        string plrs = await File.ReadAllTextAsync("game-dev.txt");
        List = JsonConvert.DeserializeObject<PlayerList>(plrs);
        List.list.Add(player);


        await File.WriteAllTextAsync("game-dev.txt", JsonConvert.SerializeObject(List));


        return player;
    }
    public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        PlayerList List = new PlayerList();
        string plrs = await File.ReadAllTextAsync("game-dev.txt");
        List = JsonConvert.DeserializeObject<PlayerList>(plrs);

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
        PlayerList List = new PlayerList();
        string plrs = await File.ReadAllTextAsync("game-dev.txt");
        List = JsonConvert.DeserializeObject<PlayerList>(plrs);

        for (int i = 0; i < List.list.Count; i++)
        {
            if (id == List.list[i].Id)
            {
                Player d = List.list[i];
                List.list.RemoveAt(i);
                return d;
            }
        }

        File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(List));

        return null;
    }
}