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
    public class GenerosController : ControllerBase
    {
        [Route("api/[controller]")]
        [Produces("application/json")]
        [HttpGet]
        public IEnumerable<GeneroDomain> ListarGeneros()
        {
            return GeneroRepository.Listar();
        }
    }
}