using System;
using System.Collections.Generic;

namespace ApiEventos.Domains;

public partial class Evento
{
    public int EventoId { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataRealizacao { get; set; }

    public string LocalRealizacao { get; set; } = null!;

    public int? UsuarioId { get; set; }

    public virtual ICollection<Inscricao> Inscricao { get; set; } = new List<Inscricao>();

    public virtual Usuario? Usuario { get; set; }
}
