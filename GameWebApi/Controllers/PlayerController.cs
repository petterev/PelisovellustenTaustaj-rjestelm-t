using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {

        private readonly FileRepository _repository;


        public PlayerController(FileRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("Get{id:Guid}")]
        public Task<Player> Get(Guid id)
        {
            return _repository.Get(id);
        }
        [HttpGet("GetAll")]
        public Task<Player[]> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Player> Create(NewPlayer player)
        {
            Player p = new Player();
            p.Name = player.Name;
            p.Id = player.Id;
            p.CreationTime = player.CreationTime;

            return _repository.Create(p);

        }
        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return _repository.Modify(id, player);
        }
        [HttpDelete("Del{id:Guid}")]
        public Task<Player> Delete(Guid id)
        {
            return _repository.Delete(id);
        }



    }
}