using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios Login(UsuarioViewModel user)
        {
            using (OptusContext otx = new OptusContext())
            {
                Usuarios usuario = otx.Usuarios.FirstOrDefault(x => x.Email == user.Email && x.Senha == user.Senha);

                if (usuario == null)
                {
                    return null;
                }
                return usuario;
            }
        }
    }
}
