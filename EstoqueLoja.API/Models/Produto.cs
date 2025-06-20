﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EstoqueLoja.API.Models;

[Table("Produto")]
public partial class Produto
{
    [Key]
    public int IdPro { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string NomePro { get; set; }

    public double? PrecoPro { get; set; }

    [InverseProperty("IdProNavigation")]
    public virtual ICollection<ItensEstoque> ItensEstoques { get; set; } = new List<ItensEstoque>();
}