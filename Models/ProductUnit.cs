using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopERP.Models;

public partial class ProductUnit
{
    [Key]
    [Column("ProductUnitID")]
    public int ProductUnitId { get; set; }

    [StringLength(100)]
    public string ProductUnitName { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string ProductUnitNameShort { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateEdited { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [InverseProperty("ProductUnit")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
