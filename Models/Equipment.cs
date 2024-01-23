using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopERP.Models;

public partial class Equipment
{
    [Key]
    [Column("EquipmentID")]
    public int EquipmentId { get; set; }

    [StringLength(100)]
    public string EquipmentName { get; set; } = null!;

    public DateTime EquipmentAcquireDate { get; set; }

    public DateTime? EquipmentServiceDate { get; set; }

    [Column(TypeName = "money")]
    public decimal? EquipmentBoughtPrice { get; set; }

    public bool EquipmentIsLeased { get; set; }

    [StringLength(100)]
    public string? EquipmentLeasedFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateEdited { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }
}
