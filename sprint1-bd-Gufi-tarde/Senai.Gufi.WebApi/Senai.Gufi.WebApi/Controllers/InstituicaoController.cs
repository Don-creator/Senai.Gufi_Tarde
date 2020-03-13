using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_instituicaoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Instituicao novaInstituicao)
        {
            _instituicaoRepository.Cadastrar(novaInstituicao);

            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult Put(int id, Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

            if (instituicaoBuscada == null)
            {
                try
                {
                    _instituicaoRepository.Atualizar(id, instituicaoAtualizada);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
                return StatusCode(404);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Instituicao instituicaoBuscado = _instituicaoRepository.BuscarPorId(Id);

            if (instituicaoBuscado == null)
            {
                return NotFound();
            }

            _instituicaoRepository.Deletar(Id);

            return StatusCode(202);
        }
    }
}
