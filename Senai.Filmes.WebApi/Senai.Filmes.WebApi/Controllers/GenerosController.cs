using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        public IActionResult ListarGeneros()
        {
            return Ok(GeneroRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarGenero(GeneroDomain generoDomain)
        {
            GeneroRepository.Cadastrar(generoDomain);
            return Ok();
        }

        [HttpPut]
        public IActionResult AtualizarGenero(GeneroDomain generoDomain)
        {
            GeneroRepository.Atualizar(generoDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGenero(int id)
        {
            GeneroRepository.Deletar(id);
            return Ok();
        }
    }
}