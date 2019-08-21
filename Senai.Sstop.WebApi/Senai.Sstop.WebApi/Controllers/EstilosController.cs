using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>
            {
                new EstiloDomain { IdEstilo = 1, Nome = "Rock" },
                new EstiloDomain { IdEstilo = 2, Nome = "Pop" },
                new EstiloDomain { IdEstilo = 3, Nome = "Samba" }
            };

        EstiloRepository EstiloRepository = new EstiloRepository();

        [HttpGet]
        public IEnumerable<EstiloDomain> ListarTodos()
        {
            return EstiloRepository.Listar();
        }

        [HttpGet("{id}")]   
        public IActionResult BuscarPorId(int id)
        {
            EstiloDomain estiloDomain = EstiloRepository.BuscarPorId(id);
            if (estiloDomain == null)
            {
                return NotFound();
            }
            return Ok(estiloDomain);
        }

        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Cadastrar(estiloDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Atualizar(estiloDomain);
            return Ok();
        }
    }
}