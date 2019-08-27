using Microsoft.EntityFrameworkCore;
using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class ArtistaRepository
    {
        public List<Artistas> Listar()
        {
            using (OptusContext otx = new OptusContext())
            {
                return otx.Artistas.Include(x => x.IdEstiloNavigation).ToList();
            }
        }

        public void Cadstrar(Artistas artista)
        { 
            using (OptusContext otx = new OptusContext())
            {
                otx.Artistas.Add(artista);
                otx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OptusContext otx = new OptusContext())
            {
                Artistas artista = otx.Artistas.Find(id);
                otx.Artistas.Remove(artista);
                otx.SaveChanges();
            }
        }
    }
}
