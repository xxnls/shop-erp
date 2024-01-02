using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopERP.Models;

public partial class Sale
{
    [Key]
    [Column("SaleID")]
    public int SaleId { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SaleStartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SaleEndDate { get; set; }

    public double SaleDiscount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateEdited { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Sales")]
    public virtual Product Product { get; set; } = null!;
}
