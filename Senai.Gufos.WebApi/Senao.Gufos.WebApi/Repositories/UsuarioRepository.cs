using Senao.Gufos.WebApi.Domains;
using Senao.Gufos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senao.Gufos.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailSenha(LoginViewModel login)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);

                if (usuario == null)
                    return null;
                return usuario;
            }
        }
    }
}
