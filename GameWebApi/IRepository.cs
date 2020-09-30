using System;
using System.Net.Http;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Linq;
using System.IO;

public interface IRepository
{

    Task<Player[]> GetWithNumOfItems(int i);
    Task<Player[]> GetWithScoreMin(int m);
    Task<Player[]> GetTenHighest();
    Task<Player[]> GetAllWithTag(string tag);

    Task<Item> GiveItem(Guid id, Item item);

    Task<Player> IncrementScore(Guid id, int i);
    Task<Player> Create(Player player);


    Task<Player> Get(Guid id);
    Task<Player[]> GetAll();

    Task<Player> Modify(Guid id, ModifiedPlayer player);
    Task<Player> Delete(Guid id);


    Task<Item> CreateItem(Guid playerId, Item item);
    Task<Item> GetItem(Guid playerId, Guid itemId);
    Task<Item[]> GetAllItems(Guid playerId);
    Task<Item> UpdateItem(Guid playerId, Guid itemId, Item item);
    Task<Item> DeleteItem(Guid playerId, Guid itemId);

    Task<Player[]> FindPlayersWithItemOfType(ItemType itemType);
}