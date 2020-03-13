using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, TipoEvento tipoEventoAtualizado)
        {
            TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

            tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;

            ctx.TipoEvento.Update(tipoEventoBuscado);

            ctx.SaveChanges();
        }

        public TipoEvento BuscarPorId(int id)
        {
            return ctx.TipoEvento.FirstOrDefault(te  => te.IdTipoEvento == id);
        }

        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            ctx.TipoEvento.Add(novoTipoEvento);

            ctx.SaveChanges();
            
        }

        public void Deletar(int id)
        {
            TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

            ctx.TipoEvento.Remove(tipoEventoBuscado);

            ctx.SaveChanges();
        }

        public List<TipoEvento> Listar()
        {
            return ctx.TipoEvento.ToList();
        }
    }
}
