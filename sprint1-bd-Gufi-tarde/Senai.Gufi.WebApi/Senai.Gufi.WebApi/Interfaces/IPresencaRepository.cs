using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> Listar();

        void Cadastrar(Presenca novoTipoEvento);

        void Atualizar(int id, Presenca presencaAtualizada);

        void Deletar(int id);

        Presenca BuscarPorId(int id);

        void Convidar(int id);

        List<Presenca> ListarMinhas(int id);

        void Inscricao(Presenca novaInscricao);

        void Aprovar(int id);
    }
}
