using System;
using System.Collections.Generic;

namespace EstoqueLoja.Domain.Entities;

public partial class Produto
{
    public int IdPro { get; set; }

    public string? NomePro { get; set; }

    public double? PrecoPro { get; set; }

    public virtual ICollection<ItensEstoque> ItensEstoques { get; set; } = new List<ItensEstoque>();
}
