using System;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
public class FileRepository : IRepository
{



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
        List<Player> pl = new List<Player>();
        pl.Add(player);

        string json = JsonConvert.SerializeObject(pl.ToArray());

        //write string to file
        await File.WriteAllTextAsync("game-dev.txt", json);

        return null;
    }
    public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        string plrs = await File.ReadAllTextAsync("game-dev.txt");

        List<Player> list = JsonConvert.DeserializeObject<List<Player>>(plrs);

        foreach (Player p in list)
        {

            if (p.Id == id)
            {

                p.Level = player.Level;
                p.Score = player.Score;
                p.IsBanned = player.IsBanned;
                return p;
            }
        }

        return null;
    }
    [HttpDelete]
    public async Task<Player> Delete(Guid id)
    {
        string plrs = await File.ReadAllTextAsync("game-dev.txt");

        List<Player> list = JsonConvert.DeserializeObject<List<Player>>(plrs);

        foreach (Player p in list)
        {
            if (id == p.Id)
            {
                list.Remove(p);
            }
        }
        string json = JsonConvert.SerializeObject(list.ToArray());

        //write string to file
        File.WriteAllText("game-dev.txt", json);

        return null;
    }
}