using System;
using System.Collections.Generic;

namespace EstoqueLoja.Domain.Entities;

public partial class Loja
{
    public int IdLoj { get; set; }

    public string? NomeLoj { get; set; }

    public string? EnderecoLoj { get; set; }

    public virtual ItensEstoque? ItensEstoque { get; set; }
}
