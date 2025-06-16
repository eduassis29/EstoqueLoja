using EstoqueLoja.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstoqueLoja.Domain.Entities;

public partial class Loja
{
    public int IdLoj { get; private set; }

    public string? NomeLoj { get; private set; }

    public string? EnderecoLoj { get; private set; }

    public virtual ItensEstoque? ItensEstoque { get; set; }

    public Loja(int idLoj, string? nomeLoj, string? enderecoLoj, ItensEstoque itensEstoque) {
        DomainExceptionValidation.When(idLoj < 0, "O Id da Loja deve ser positivo");
        IdLoj = idLoj;
        ValidateDomain(nomeLoj, enderecoLoj, itensEstoque);
    }

    public Loja(string? nomeLoj, string? enderecoLoj, ItensEstoque itensEstoque) {
        ValidateDomain(nomeLoj, enderecoLoj, itensEstoque);
    }

    public void Update(string? nomeLoj, string? enderecoLoj, ItensEstoque itensEstoque) {
        ValidateDomain(nomeLoj, enderecoLoj, itensEstoque);
    }

    public void ValidateDomain(string? nomeLoj, string? enderecoLoj, ItensEstoque itensEstoque) {
        DomainExceptionValidation.When(nomeLoj.Length > 50, "O Nome da Loja deve ter Menos de 50 Caracteres");
        DomainExceptionValidation.When(enderecoLoj.Length > 70, "O Endereço da Loja deve ter Menos de 70 Caracteres");

        NomeLoj = nomeLoj;
        EnderecoLoj = enderecoLoj;
        ItensEstoque = itensEstoque;
    }
}
