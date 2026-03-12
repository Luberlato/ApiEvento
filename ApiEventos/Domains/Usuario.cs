using System;
using System.Collections.Generic;

namespace ApiEventos.Domains;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public byte[] Senha { get; set; } = null!;

    public virtual ICollection<Evento> Evento { get; set; } = new List<Evento>();

    public virtual ICollection<Inscricao> Inscricao { get; set; } = new List<Inscricao>();
}
