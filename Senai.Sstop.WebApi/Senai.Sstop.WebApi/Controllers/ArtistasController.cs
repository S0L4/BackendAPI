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
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository ArtistaRepository = new ArtistaRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(ArtistaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastar(ArtistaDomain artistaDomain)
        {
            try
            {
                // tenta fazer alguma coisa;
                ArtistaRepository.Cadastrar(artistaDomain);
                return Ok();

                // Ok = 200
                // Not Found = 404
                // Bad Request = 400
            }
            catch (Exception ex)
            { 
                // plano B
                return BadRequest(new { mensagem = "Oba, desculpa meu consagrado, ocorreu um probleminha aqui hihi" + ex.Message });
                throw;
            }          
        }
    }
}