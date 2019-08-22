using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Domains
{
    public class EstiloDomain
    {
        public int IdEstilo { get; set; }
        [Required(ErrorMessage = "Nome obrigatório meu consagrado")]
        public string Nome { get; set; }        
    }
}
