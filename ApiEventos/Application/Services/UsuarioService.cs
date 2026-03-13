using ApiEventos.Application.Conversoes;
using ApiEventos.Application.Verificacoes;
using ApiEventos.Domains;
using ApiEventos.DTO.UsuarioDTO;
using ApiEventos.Exceptions;
using ApiEventos.Interface;

namespace ApiEventos.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<LerUsuarioDTO> Listar()
        {
            List<Usuario> usuarios = _repository.Listar();

            List<LerUsuarioDTO> usuarioDTOs = usuarios.Select(usuarioBanco => UsuarioParaDTO.LerDto(usuarioBanco)).ToList();

            return usuarioDTOs;
        }

        public LerUsuarioDTO ObterPorId(int id)
        {
            LerUsuarioDTO? usuarioDto = UsuarioParaDTO.LerDto(_repository.ObterPorId(id));

            if (usuarioDto == null)
            {
                throw new DomainException("Usuário não encontrado");
            }

            return usuarioDto;
        }

        public List<LerUsuarioDTO> ObterPalestrantes()
        {
            List<Usuario> usuarios = _repository.ObterPalestrantes();

            List<LerUsuarioDTO> usuarioDTOs = usuarios.Select(usuarioBanco => UsuarioParaDTO.LerDto(usuarioBanco)).ToList();

            return usuarioDTOs;
        }

        public List<LerUsuarioDTO> ObterParticipantes()
        {
            List<Usuario> usuarios = _repository.ObterParticipantes();

            List<LerUsuarioDTO> usuarioDTOs = usuarios.Select(usuarioBanco => UsuarioParaDTO.LerDto(usuarioBanco)).ToList();

            return usuarioDTOs;
        }

        public LerUsuarioDTO CadastrarUsuario(CriarUsuarioDTO usuarioDto)
        {
            VerificarUsuario.ValidarUsuario(usuarioDto);

            Usuario usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = SenhaParaHash.HashSenha(usuarioDto.Senha),
                TipoUsuario = usuarioDto.TipoUsuario
            };

            return UsuarioParaDTO.LerDto(usuario);
        }

        public LerUsuarioDTO AtualzarUsuario(CriarUsuarioDTO usuarioDTO, int id)
        {

            Usuario? usuarioBanco = _repository.ObterPorId(id);

            if (usuarioBanco == null)
            {
                throw new DomainException("Usuário não encontrado");
            }


            VerificarUsuario.ValidarUsuario(usuarioDTO);

            Usuario usuario = new Usuario
            {
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Senha = SenhaParaHash.HashSenha(usuarioDTO.Senha),
                TipoUsuario = usuarioDTO.TipoUsuario
            };

            _repository.AtualizarUsuario(usuario, id);

            return UsuarioParaDTO.LerDto(usuario);
        }

        public void DeletarUsuario(int id)
        {
            Usuario? usuario = _repository.ObterPorId(id);

            if (usuario == null)
            {
                throw new DomainException("Usuário não encontrado");
            }

            _repository.Deletar(id);
        }



        
    }
}
