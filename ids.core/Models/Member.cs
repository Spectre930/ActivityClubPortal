using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ids.core.Models;

public partial class Member
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public DateOnly JoiningDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public string? MobileNumber { get; set; }

    public string? EmergencyNumber { get; set; }

    public string Profession { get; set; } = null!;

    public string Nationality { get; set; } = null!;


    public virtual ICollection<EventsMember> EventsMembers { get; set; } = new List<EventsMember>();
}
