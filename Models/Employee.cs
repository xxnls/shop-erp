using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopERP.Models;

public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [Column("EmployeeRoleID")]
    public int EmployeeRoleId { get; set; }

    [Column("AddressID")]
    public int AddressId { get; set; }

    [StringLength(100)]
    public string EmployeeFirstName { get; set; } = null!;

    [StringLength(100)]
    public string EmployeeLastName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal? EmployeeWage { get; set; }

    [Column(TypeName = "money")]
    public decimal? EmployeeSalary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateEdited { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Employees")]
    public virtual Address Address { get; set; } = null!;

    [ForeignKey("EmployeeRoleId")]
    [InverseProperty("Employees")]
    public virtual EmployeesRole EmployeeRole { get; set; } = null!;

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; } = new List<EmployeeShift>();

    [InverseProperty("Employee")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
