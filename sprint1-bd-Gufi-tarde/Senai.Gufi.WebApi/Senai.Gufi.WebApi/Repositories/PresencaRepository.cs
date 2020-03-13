using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private InLockContext ctx = new InLockContext();

        PresencaRepository _presencaRepository;

        public void Aprovar(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Presenca presencaAtualizada)
        {
            Presenca presencaBuscada = ctx.Presenca.Find(id);

            presencaBuscada.IdPresenca = presencaAtualizada.IdPresenca;

            ctx.Presenca.Update(presencaBuscada);

            ctx.SaveChanges();
        }

        public Presenca BuscarPorId(int id)
        {
            return ctx.Presenca.FirstOrDefault(p => p.IdPresenca == id);
        }

        public void Cadastrar(Presenca novoPresenca)
        {
            ctx.Presenca.Add(novoPresenca);

            ctx.SaveChanges();
        }

        public void Convidar(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            ctx.Presenca.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public void Inscricao(Presenca novaInscricao)
        {
            throw new NotImplementedException();
        }

        public List<Presenca> Listar()
        {
            return ctx.Presenca.ToList();
        }

        public List<Presenca> ListarMinhas(int id)
        {
            return ctx.Presenca
                .Include(e => e.IdEventoNavigation)
                .Include(u => u.IdUsuarioNavigation)
                .ToList();
            //return ctx.Presenca.ToList().FindAll(p => p.IdUsuario == id); // Include
        }
    }
}
