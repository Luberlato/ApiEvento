using System;
using System.Collections.Generic;

namespace ApiEventos.Domains;

public partial class Eventos
{
    public int EventoId { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataRealizacao { get; set; }

    public string LocalRealizacao { get; set; } = null!;

    public int? ParticipanteId { get; set; }

    public int? PalestranteId { get; set; }

    public virtual Palestrante? Palestrante { get; set; }

    public virtual Participante? Participante { get; set; }
}
