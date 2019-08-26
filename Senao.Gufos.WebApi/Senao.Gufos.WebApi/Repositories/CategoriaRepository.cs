using Senao.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senao.Gufos.WebApi.Repositories
{
    public class CategoriaRepository
    {
        public List<Categorias> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                // facilitar a minha vida

                // select 
                return ctx.Categorias.ToList();
            }
        }
        
        public void Cadastrar(Categorias categorias)
        {
            using (GufosContext ctx = new GufosContext())
            {
                // insert
                ctx.Categorias.Add(categorias);
                ctx.SaveChanges();
            }
        }


        public Categorias BuscarPorId(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                // buscar
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        public void Deletar(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                // deletar 
                Categorias Categoria = ctx.Categorias.Find(id);
                ctx.Categorias.Remove(Categoria);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Categorias categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                // atualizar                                                  
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                CategoriaBuscada.Nome = categoria.Nome;
                ctx.Categorias.Update(CategoriaBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
