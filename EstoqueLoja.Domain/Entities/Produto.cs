using EstoqueLoja.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Data;

namespace EstoqueLoja.Domain.Entities;

public partial class Produto
{
    public int IdPro { get; private set; }

    public string? NomePro { get; private set; }

    public double? PrecoPro { get; private set; }

    public virtual ICollection<ItensEstoque> ItensEstoques { get; private set; } = new List<ItensEstoque>();

    public Produto(int idPro, string? nomePro, double? precoPro, ICollection<ItensEstoque> itensEstoques) {
        DomainExceptionValidation.When(idPro < 0, "O Id do Produto deve ser Positivo");
        IdPro = idPro;
        ValidateDomain(nomePro, precoPro, itensEstoques);
    }

    public Produto(string? nomePro, double? precoPro, ICollection<ItensEstoque> itensEstoques) {
        ValidateDomain(nomePro, precoPro, itensEstoques);
    }

    public void Update(string? nomePro, double? precoPro, ICollection<ItensEstoque> itensEstoques) {
        ValidateDomain(nomePro, precoPro, itensEstoques);
    }

    public void ValidateDomain(string? nomePro, double? precoPro, ICollection<ItensEstoque> itensEstoques) {
        DomainExceptionValidation.When(nomePro.Length > 50, "O Nome do Produto deve ter menos de 50 letras");
        DomainExceptionValidation.When(precoPro < 0, "O Preco do Produto deve ser positivo");

        NomePro = nomePro;
        PrecoPro = precoPro;
        ItensEstoques = itensEstoques;
    }
}
