using EstoqueLoja.Domain.Validation;
using System;
using System.Collections.Generic;

namespace EstoqueLoja.Domain.Entities;

public partial class ItensEstoque
{
    public int IdPro { get; set; }

    public int IdLoj { get; set; }

    public int QuantidadeIte { get; set; }

    public virtual Loja IdLojNavigation { get; set; } = null!;

    public virtual Produto? IdProNavigation { get; set; }

    public ItensEstoque(int idPro, int idLoj, int quantidadeIte) {
        ValidateDomain(idPro, idLoj, quantidadeIte);
    }

    public void Update(int idPro, int idLoj, int quantidadeIte) {
        ValidateDomain(idPro, idLoj, quantidadeIte);
    }

    public void ValidateDomain(int idPro, int idLoj, int quantidadeIte) {
        DomainExceptionValidation.When(idPro < 0, "O Id do Produto deve ser positivo");
        DomainExceptionValidation.When(idLoj < 0, "O Id da Loja deve ser positivo");

        IdPro = idPro;
        IdLoj = idLoj;
        QuantidadeIte = quantidadeIte;
    }
}
