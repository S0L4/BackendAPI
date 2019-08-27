using Microsoft.EntityFrameworkCore;
using Senao.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senao.Gufos.WebApi.Repositories
{
    public class EventoRepository
    {
        public List<Eventos> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                // listar
                // return ctx.Eventos.ToList();
                return ctx.Eventos.Include(x => x.IdCategoriaNavigation).ToList();
            }
        }

        public void Cadastrar(Eventos evento)
        {
            using (GufosContext ctx = new GufosContext())
            {
                ctx.Eventos.Add(evento);
                ctx.SaveChanges();
            }
        }
    }
}
