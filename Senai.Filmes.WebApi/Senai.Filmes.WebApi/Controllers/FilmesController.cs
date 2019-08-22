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
    [ApiController]
    public class FilmesController : ControllerBase
    {
        FilmeRepository FilmeRepository = new FilmeRepository();

        [HttpGet]
        public IActionResult ListarFilmes()
        {
            return Ok(FilmeRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorId(int id)
        {
            FilmeDomain filmeDomain = FilmeRepository.BuscarPorId(id);
            if (filmeDomain == null)
            {
                return NotFound();
            }
            return Ok(filmeDomain);
        }

        [HttpPut]
        public IActionResult AtualizarFilme(FilmeDomain filmeDomain)
        {
            FilmeRepository.Atualizar(filmeDomain);
            return Ok();
        }
    }
}