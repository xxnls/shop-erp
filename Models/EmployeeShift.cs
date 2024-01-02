using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopERP.Models;

[PrimaryKey("EmployeeId", "ShiftId")]
public partial class EmployeeShift
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [Key]
    [Column("ShiftID")]
    public int ShiftId { get; set; }

    public DateOnly ShiftDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateEdited { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmployeeShifts")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("ShiftId")]
    [InverseProperty("EmployeeShifts")]
    public virtual Shift Shift { get; set; } = null!;
}
