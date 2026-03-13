using ApiEventos.Domains;

namespace ApiEventos.Interface
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario ObterPorId(int id);
        List<Usuario> ObterPalestrantes();
        List<Usuario> ObterParticipantes();
        void CadastrarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario, int id);
        void Deletar(int id);

    }
}
