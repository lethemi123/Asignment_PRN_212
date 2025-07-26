using System;
using System.Collections.Generic;

namespace Test1.Model;

public partial class Person
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateOnly? DateOfBirth { get; set; }
    public string FullName => $"{Fname} {Lname}".Trim();

    public string? PathImagePerson { get; set; }

    public bool? RoleAccount { get; set; }

    public double? Balance { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
