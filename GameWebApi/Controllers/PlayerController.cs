using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayerController : ControllerBase
    {

        private readonly ILogger<PlayerController> _logger;
        private readonly FileRepository _repository;

        public PlayerController(ILogger<PlayerController> logger, FileRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("Get/{id:Guid}")]
        public Task<Player> Get(Guid id)
        {
            return _repository.Get(id);
        }
        [HttpGet("GetAll")]
        public Task<Player[]> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        [Route("Create")]
        public Task<Player> Create([FromBody] NewPlayer player)
        {
            Player p = new Player();
            p.Name = player.Name;
            p.Id = Guid.NewGuid();
            p.CreationTime = DateTime.UtcNow;

            return _repository.Create(p);

        }
        [HttpPost]
        [Route("Mod/{id:GUid")]
        public Task<Player> Modify(Guid id, [FromBody] ModifiedPlayer player)
        {
            return _repository.Modify(id, player);
        }
        [HttpDelete]
        [Route("Del/{id:Guid}")]
        public Task<Player> Delete(Guid id)
        {
            return _repository.Delete(id);
        }



    }
}