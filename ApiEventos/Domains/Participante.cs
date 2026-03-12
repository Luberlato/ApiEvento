using System;
using System.Collections.Generic;

namespace ApiEventos.Domains;

public partial class Participante
{
    public int ParticipanteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Eventos> Eventos { get; set; } = new List<Eventos>();
}
