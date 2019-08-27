using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senao.Gufos.WebApi.Domains;
using Senao.Gufos.WebApi.Repositories;

namespace Senao.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        EventoRepository EventoRepository = new EventoRepository();
        
        public IActionResult LitarEventos()
        {
            return Ok(EventoRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarEvento(Eventos evento)
        {
            try
            {
                EventoRepository.Cadastrar(evento);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Erro ao cadastrar." + ex.Message });
            }
        }
    }
}