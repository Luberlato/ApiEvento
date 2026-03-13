using ApiEventos.Contexts;
using ApiEventos.Domains;
using ApiEventos.Interface;

namespace ApiEventos.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Db_EventosContext _context;

        public EventoRepository(Db_EventosContext context)
        {
            _context = context;
        }

        public List<Evento> Listar()
        {
            return _context.Evento.ToList();
        }

        public Evento ObterPorId(int id)
        {
            return _context.Evento.Find(id);
        }

        public List<Evento> ObterPorNome(string nome)
        {
            return _context.Evento.Where(evento => evento.Nome.Contains(nome.ToLower())).ToList();
        }

        public void CadastrarEvento(Evento evento)
        {
            _context.Add(evento);
            _context.SaveChanges();
        }

        public void AtualizarEvento(Evento evento, int id)
        {
            Evento? eventoBanco = _context.Evento.Find(id);
            if (eventoBanco != null)
            {
                return;
            }

            eventoBanco.Nome = evento.Nome;
            eventoBanco.LocalRealizacao = evento.LocalRealizacao;
            eventoBanco.LocalRealizacao = evento.LocalRealizacao;
            eventoBanco.DataRealizacao = evento.DataRealizacao;

            _context.SaveChanges();
        }

        public void DeletarEvento(int id)
        {
            Evento? evento = _context.Evento.Find(id);

            if (evento == null)
                return;

            _context.Remove(evento);
        }


        
    }
}
