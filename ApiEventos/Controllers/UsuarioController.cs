using ApiEventos.Application.Services;
using ApiEventos.DTO.UsuarioDTO;
using ApiEventos.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Listar()
        {
            List<LerUsuarioDTO> usuarios = _service.Listar();

            return Ok(usuarios);
        }

        [HttpGet("/participantes")]
        public IActionResult ListarParticipantes()
        {
            List<LerUsuarioDTO> usuarios = _service.ObterParticipantes();

            return Ok(usuarios);
        }

        [HttpGet("/palestrantes")]
        public ActionResult ObterPalestrantes()
        {
            List<LerUsuarioDTO> usuarios = _service.ObterParticipantes();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public ActionResult ObterPorId(int id)
        {
            try
            {
                LerUsuarioDTO usuario = _service.ObterPorId(id);
                return Ok(usuario);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CriarUsuarioDTO usuarioDto)
        {
            try
            {
                LerUsuarioDTO usuario = _service.CadastrarUsuario(usuarioDto);
                return StatusCode(201, usuario);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(CriarUsuarioDTO usuario, int id)
        {
            try
            {
                LerUsuarioDTO usuarioDto = _service.AtualzarUsuario(usuario, id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                _service.DeletarUsuario(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
