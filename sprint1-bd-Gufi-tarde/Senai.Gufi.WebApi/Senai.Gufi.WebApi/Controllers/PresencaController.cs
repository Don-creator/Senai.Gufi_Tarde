using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        InLockContext ctx = new InLockContext();

       private PresencaRepository _presencaRepository;

        public PresencaController()
        {
            _presencaRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_presencaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Presenca novaPresenca)
        {
            _presencaRepository.Cadastrar(novaPresenca);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _presencaRepository.Deletar(id);

            return Ok();
        }      


    }
}