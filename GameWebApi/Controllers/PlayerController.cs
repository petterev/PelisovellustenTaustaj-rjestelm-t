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
        [HttpGet]
        public Task<Player> Get(Guid id)
        {
            return _repository.Get();
        }
        [HttpGet]
        public Task<Player[]> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Player> Create(NewPlayer player)
        {
            return _repository.Create();
        }
        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return _repository.Modify();
        }
        public Task<Player> Delete(Guid id)
        {
            return _repository.Delete();
        }



    }
}