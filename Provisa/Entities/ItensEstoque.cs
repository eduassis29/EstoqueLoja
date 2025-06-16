using System;
using System.Collections.Generic;

namespace EstoqueLoja.Domain.Entities;

public partial class ItensEstoque
{
    public int? IdPro { get; set; }

    public int IdLoj { get; set; }

    public int? QuantidadeIte { get; set; }

    public virtual Loja IdLojNavigation { get; set; } = null!;

    public virtual Produto? IdProNavigation { get; set; }
}
