using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }
        [Required(ErrorMessage = "Esqueceu do nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Esqueceu do sobrenome")]
        public string Sobrenome { get; set; }
    }
}
