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
        private readonly IRepository _repository;

        public PlayerController(ILogger<PlayerController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("Get/{id:Guid}")]
        public async Task<Player> Get(Guid id)
        {
            await _repository.Get(id);
            return null;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<Player[]> GetAll()
        {
            await _repository.GetAll();
            return null;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Player> Create([FromBody] NewPlayer player)
        {
            Player p = new Player();
            p.Name = player.Name;
            p.Id = Guid.NewGuid();
            p.CreationTime = DateTime.UtcNow;
            p.Level = 0;
            p.Score = 0;
            p.IsBanned = false;

            await _repository.Create(p);
            return p;

        }

        [HttpPost]
        [Route("Mod/{id:Guid}")]
        public async Task<Player> Modify(Guid id, [FromBody] ModifiedPlayer player)
        {
            await _repository.Modify(id, player);
            return null;
        }

        [HttpDelete]
        [Route("Del/{id:Guid}")]
        public async Task<Player> Delete(Guid id)
        {
            await _repository.Delete(id);
            return null;
        }



    }
}