using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senao.Gufos.WebApi.ViewModels
{
    public class LoginViewModel
    {
        // data annotations
        [Required]
        public string Email { get; set; }
        // definir tamanho
        [StringLength(250, MinimumLength = 5)]
        public string Senha { get; set; }
    }
}
