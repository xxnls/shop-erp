using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopERP.Models;

public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [Column("ProductCategoryID")]
    public int ProductCategoryId { get; set; }

    [Column("ProductUnitID")]
    public int ProductUnitId { get; set; }

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }

    public int ProductQuantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateEdited { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("ProductCategoryId")]
    [InverseProperty("Products")]
    public virtual ProductCategory ProductCategory { get; set; } = null!;

    [ForeignKey("ProductUnitId")]
    [InverseProperty("Products")]
    public virtual ProductUnit ProductUnit { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("Product")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
