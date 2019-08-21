using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();
        FuncionarioDomain funcionarioDomain = new FuncionarioDomain();

        [HttpGet]
        public IEnumerable<FuncionarioDomain> ListaFuncionarios()
        {
            return FuncionarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFuncionarioPorId(int id)
        {
            funcionarioDomain = FuncionarioRepository.BuscarPorId(id);


            if (funcionarioDomain == null)
            {
                return NotFound(funcionarioDomain);
            }
            return Ok(funcionarioDomain);
        }

        [HttpPost]
        public IActionResult CadastrarFuncionario(FuncionarioDomain funcionarioDomain)
        {
            FuncionarioRepository.Inserir(funcionarioDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFuncionario(int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult AtualizarFuncionario(FuncionarioDomain funcionarioDomain)
        {
            FuncionarioRepository.Atualizar(funcionarioDomain);
            return Ok();
        }
    }
}