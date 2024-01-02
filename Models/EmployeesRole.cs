using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopERP.Models;

public partial class EmployeesRole
{
    [Key]
    [Column("EmployeeRoleID")]
    public int EmployeeRoleId { get; set; }

    [StringLength(100)]
    public string? EmployeeRoleName { get; set; }

    public bool PermissionToManageOrders { get; set; }

    public bool PermissionToDeleteData { get; set; }

    public bool PermissionToManageEmployees { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateEdited { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [InverseProperty("EmployeeRole")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
