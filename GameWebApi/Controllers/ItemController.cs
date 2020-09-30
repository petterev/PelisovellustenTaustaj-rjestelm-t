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



        [HttpPost]
        [Route("Give")]
        public async Task<Item> GiveItem(Guid id, [FromBody] NewItem item)
        {
            Item i = new Item();
            i.Level = item.Level;
            i.Id = Guid.NewGuid();
            i.CreationDate = DateTime.UtcNow;
            i.Type = item.Type;

            return await _repository.GiveItem(id, i);
        }




        [HttpPost]
        [Route("Create")]
        public async Task<Item> CreateItem(Guid playerId, [FromBody] NewItem item)
        {

            Item i = new Item();
            i.Id = Guid.NewGuid();
            i.CreationDate = DateTime.UtcNow;
            i.Level = item.Level;
            i.Type = item.Type;
            return await _repository.CreateItem(playerId, i);
        }
        [HttpGet]
        [Route("{itemId:Guid}")]
        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {


            return await _repository.GetItem(playerId, itemId);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<Item[]> GetAllItems(Guid playerId)
        {


            return await _repository.GetAllItems(playerId);
        }
        [HttpPost]
        [Route("Update/{itemId:Guid}")]
        public async Task<Item> UpdateItem(Guid playerId, Guid itemId, [FromBody] ModifiedItem item)
        {
            Item i = new Item();
            i.Level = item.Level;


            return await _repository.UpdateItem(playerId, itemId, i);
        }
        [HttpDelete]
        [Route("Del/{itemId:Guid}")]
        public async Task<Item> DeleteItem(Guid playerId, Guid itemId)
        {


            return await _repository.DeleteItem(playerId, itemId);
        }



    }
}