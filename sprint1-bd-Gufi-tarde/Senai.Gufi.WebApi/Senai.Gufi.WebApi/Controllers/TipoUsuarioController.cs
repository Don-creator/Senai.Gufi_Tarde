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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(200, _tipoUsuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUusario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUusario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado == null)
            {
                try
                {
                    _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
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
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(Id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound();
            }

            _tipoUsuarioRepository.Deletar(Id);

            return StatusCode(202);
        }

    }
}