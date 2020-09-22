using System;
using System.Net.Http;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Linq;
using System.IO;

public interface IRepository
{
    public Task<Player> Get(Guid id);
    public Task<Player[]> GetAll();
    public Task<Player> Create(Player player);

    public Task<Player> Modify(Guid id, ModifiedPlayer player);
    public Task<Player> Delete(Guid id);

    Task<Item> CreateItem(Guid playerId, Item item);
    Task<Item> GetItem(Guid playerId, Guid itemId);
    Task<Item[]> GetAllItems(Guid playerId);
    Task<Item> UpdateItem(Guid playerId, Item item);
    Task<Item> DeleteItem(Guid playerId, Item item);


}