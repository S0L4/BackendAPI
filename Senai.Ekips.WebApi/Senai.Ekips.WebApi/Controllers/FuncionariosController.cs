using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();

        [HttpGet]
        public IActionResult ListarFuncionarios()
        {
            return Ok(FuncionarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarFuncionario(Funcionarios funcionario)
        {
            try
            {
                FuncionarioRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro :/ ." + ex.Message });

            }
        }
        
        [HttpPut]
        public IActionResult AtualizarFuncionario(Funcionarios funcionario)
        {
            try
            {
                Funcionarios FuncionarioEncontrado = FuncionarioRepository.BuscarPorId(funcionario.IdFuncionario);

                if (FuncionarioEncontrado == null)
                {
                    return NotFound();
                }
                FuncionarioRepository.Atualizar(funcionario);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro :/ ." + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFuncionario(int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }
    }
}