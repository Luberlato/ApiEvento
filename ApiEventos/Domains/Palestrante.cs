using System;
using System.Collections.Generic;

namespace ApiEventos.Domains;

public partial class Palestrante
{
    public int PalestranteId { get; set; }

    public string Nome { get; set; } = null!;

    public string AreaDeAtuacao { get; set; } = null!;

    public virtual ICollection<Eventos> Eventos { get; set; } = new List<Eventos>();
}
