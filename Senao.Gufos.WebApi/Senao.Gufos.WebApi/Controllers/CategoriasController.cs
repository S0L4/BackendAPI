using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senao.Gufos.WebApi.Domains;
using Senao.Gufos.WebApi.Repositories;

namespace Senao.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository CategoriaRepository = new CategoriaRepository();

        [HttpGet]
        public IActionResult ListarCategorias()
        {
            return Ok(CategoriaRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarCategoria(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro :/ " + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarCategoriaPorId(int id)
        {
            Categorias Categoria = CategoriaRepository.BuscarPorId(id);

            if (Categoria == null)
            {
                return NotFound();
            }
            return Ok(Categoria);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCategoria(int id)
        {
            CategoriaRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult AtualizarCategoria(Categorias categoria)
        {
            try
            {
                Categorias CategoriaBuscada = CategoriaRepository.BuscarPorId
                    (categoria.IdCategoria);

                if (CategoriaBuscada == null)
                {
                    return NotFound();
                }
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ah, não. By - João" });
            }
        }
    }
}