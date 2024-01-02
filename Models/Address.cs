using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopERP.Models;

public partial class Address
{
    [Key]
    [Column("AddressID")]
    public int AddressId { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [StringLength(100)]
    public string City { get; set; } = null!;

    [StringLength(50)]
    public string PostalCode { get; set; } = null!;

    [StringLength(100)]
    public string? StreetName { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string BuildingNumber { get; set; } = null!;

    [StringLength(50)]
    public string? ContactNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateEdited { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("Addresses")]
    public virtual Country Country { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("Address")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [InverseProperty("Address")]
    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
