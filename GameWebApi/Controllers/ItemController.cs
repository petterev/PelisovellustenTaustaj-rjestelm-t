using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("players/{playerId}/items")]
    public class ItemController : ControllerBase
    {

        private readonly ILogger<ItemController> _logger;
        private readonly IRepository _repository;

        public ItemController(ILogger<ItemController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Item> CreateItem(Guid playerId, [FromBody] Item item)
        {

            Item i = await _repository.CreateItem(playerId, item);
            return i;
        }
        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {


            return await _repository.GetItem(playerId, itemId);
        }
        public async Task<Item[]> GetAllItems(Guid playerId)
        {


            return await _repository.GetAllItems(playerId);
        }
        public async Task<Item> UpdateItem(Guid playerId, [FromBody] ModifiedItem item)
        {
            Item i = new Item();
            i.Level = item.Level;


            return await _repository.UpdateItem(playerId, i);
        }
        public async Task<Item> DeleteItem(Guid playerId, [FromBody] Item item)
        {


            return await _repository.DeleteItem(playerId, item);
        }



    }
}