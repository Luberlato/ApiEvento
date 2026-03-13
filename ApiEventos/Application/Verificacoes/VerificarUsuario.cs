using ApiEventos.DTO.UsuarioDTO;
using ApiEventos.Exceptions;

namespace ApiEventos.Application.Verificacoes
{
    public class VerificarUsuario
    {
        public static void ValidarUsuario(CriarUsuarioDTO usuarioDTO)
        {
            if(string.IsNullOrWhiteSpace(usuarioDTO.Nome) || string.IsNullOrWhiteSpace(usuarioDTO.Email) || string.IsNullOrWhiteSpace(usuarioDTO.TipoUsuario) || string.IsNullOrWhiteSpace(usuarioDTO.Senha))
            {
                throw new DomainException("Preenchimento inválido,tente novamente");
            }
        }
    }
}
