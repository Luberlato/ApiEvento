namespace ApiEventos.DTO.UsuarioDTO
{
    public class LerUsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public List<int> EventoId { get; set; } = new List<int>();
    }
}
