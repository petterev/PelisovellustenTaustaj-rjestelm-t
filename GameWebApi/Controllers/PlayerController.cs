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
        [Route("GetWithNumOfItems/{i:int}")]
        public async Task<Player[]> GetWithNumOfItems(int i)
        {
            Player[] p = await _repository.GetWithNumOfItems(i);

            return p;
        }

        [HttpGet]
        //[Route("GetWithMinScore/?minScore=x")]
        public async Task<Player[]> GetWithScoreMin(int minScore)
        {
            Player[] p = await _repository.GetWithScoreMin(minScore);

            return p;

        }
        [HttpPost]
        [Route("IncrScore/{id:Guid/i:int}")]
        public async Task<Player> IncrementScore(Guid id, int i)
        {
            Player p = await _repository.IncrementScore(id, i);

            return p;
        }

        [HttpGet]
        [Route("GetWithItem")]
        // [Route("GetWithItem/{itemType:ItemType}")
        public async Task<Player[]> FindPlayersWithItemOfType([FromBody] ItemType itemType)
        {

            Player[] p = await _repository.FindPlayersWithItemOfType(itemType);
            return p;
        }
        [HttpGet]
        [Route("GetWithTag")]
        //[Route("GetWithTag{tag:String}")]
        public async Task<Player[]> GetAllWithTag([FromBody] string tag)
        {

            Player[] players = await _repository.GetAllWithTag(tag);
            return null;
        }

        [HttpGet]
        [Route("Get/{id:Guid}")]
        public async Task<Player> Get(Guid id)
        {
            Player p = await _repository.Get(id);
            return p;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<Player[]> GetAll()
        {
            Player[] p = await _repository.GetAll();
            return p;
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
            p.tags = player.tags;
            //  p.tags.Append("noob");

            await _repository.Create(p);
            return p;

        }

        [HttpPost]
        [Route("Mod/{id:Guid}")]
        public async Task<Player> Modify(Guid id, [FromBody] ModifiedPlayer player)
        {
            Player p = await _repository.Modify(id, player);
            return p;
        }

        [HttpDelete]
        [Route("Del/{id:Guid}")]
        public async Task<Player> Delete(Guid id)
        {
            Player p = await _repository.Delete(id);
            return p;
        }



    }
}