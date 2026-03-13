using ApiEventos.Domains;
using ApiEventos.Interface;

namespace ApiEventos.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiEventos.Contexts.Db_EventosContext _context;

        public UsuarioRepository(ApiEventos.Contexts.Db_EventosContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuario.ToList();
        }

        public Usuario ObterPorId(int id)
        {
            return _context.Usuario.Find(id);
        }

        public List<Usuario> ObterParticipantes()
        {
            return _context.Usuario.Where(usuario => usuario.TipoUsuario.Equals("Participante")).ToList();
        }

        public List<Usuario> ObterPalestrantes()
        {
            return _context.Usuario.Where(usuario => usuario.TipoUsuario.Equals("Palestrante")).ToList();
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public void AtualizarUsuario(Usuario usuario, int id)
        {
            Usuario? usuarioBanco = _context.Usuario.Find(id);

            if (usuarioBanco == null)
            {
                return;
            }

            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Email = usuario.Email;
            usuarioBanco.Senha = usuario.Senha;
            usuarioBanco.TipoUsuario = usuario.TipoUsuario;


            _context.SaveChanges();
        }


        public void Deletar(int id)
        {
            Usuario? usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return;
            }

            _context.Remove(usuario);
            _context.SaveChanges();
        }


    }
}
