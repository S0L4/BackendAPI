using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext otx = new OptusContext())
            {
                // listar
                return otx.Estilos.ToList();
            }
        }

        public Estilos BuscarPorId(int id)
        {
            using (OptusContext otx = new OptusContext())
            {
                // buscar
                return otx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        public void Cadastrar(Estilos estilo)
        {
            using (OptusContext otx = new OptusContext())
            {
                // cadastrar
                otx.Estilos.Add(estilo);
                otx.SaveChanges();
            }
        }

        public void Atualizar(Estilos estilo)
        {
            using (OptusContext otx = new OptusContext())
            {
                // atualizar
                Estilos EstiloDesejado = otx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);
                EstiloDesejado.Nome = estilo.Nome;
                otx.Estilos.Update(EstiloDesejado);
                otx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OptusContext otx = new OptusContext())
            {
                // deletar
                Estilos estilo = otx.Estilos.Find(id);
                otx.Estilos.Remove(estilo);
                otx.SaveChanges();
            }
        }
    }
}
