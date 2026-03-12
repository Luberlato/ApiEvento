using ApiEventos.Domains;

namespace ApiEventos.Interface
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
    }
}
