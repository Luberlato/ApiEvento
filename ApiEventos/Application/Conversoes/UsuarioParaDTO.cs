using ApiEventos.Domains;
using ApiEventos.DTO.UsuarioDTO;

namespace ApiEventos.Application.Conversoes
{
    public class UsuarioParaDTO
    {
        public static LerUsuarioDTO LerDto(Usuario usuario)
        {
            LerUsuarioDTO usuarioDto = new LerUsuarioDTO
            {
                Email = usuario.Email,
                Nome = usuario.Nome,
                TipoUsuario = usuario.TipoUsuario,
                EventoId = usuario.Evento.Select(evento => evento.EventoId).ToList()
            };

            return usuarioDto;
        }
    }
}
