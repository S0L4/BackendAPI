using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstiloRepository EstiloRepository = new EstiloRepository();

        [HttpGet]
        public IActionResult ListarEstilos()
        {
            return Ok(EstiloRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarEstilo(Estilos estilo)
        {
            try
            {
                EstiloRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Algo de errado não esta certo :/" + ex.Message});
            }
        }

        [HttpPut]
        public IActionResult AtualizarEstilo(Estilos estilo)
        {
            try
            {
                Estilos EstiloBuscado = EstiloRepository.BuscarPorId
                    (estilo.IdEstilo);

                if (EstiloBuscado == null)
                {
                    return NotFound();
                }
                EstiloRepository.Atualizar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Algo de errado não esta certo :/" + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEstilo(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }
    }
}