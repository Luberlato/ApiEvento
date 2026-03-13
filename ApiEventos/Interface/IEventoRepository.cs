using ApiEventos.Domains;

namespace ApiEventos.Interface
{
    public interface IEventoRepository
    {
        List<Evento> Listar();
        Evento ObterPorId(int id);
        List<Evento> ObterPorNome(string nome);
        void CadastrarEvento(Evento evento);
        void AtualizarEvento(Evento evento, int id);
        void DeletarEvento(int id);

       
    }
}
