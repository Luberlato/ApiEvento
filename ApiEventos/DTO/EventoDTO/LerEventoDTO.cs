namespace ApiEventos.DTO.EventoDTO
{
    public class LerEventoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataRealizacao { get; set; }
        public string LocalRealizacao { get; set; }
        public List<int> usuarios { get; set; }

    }
}
