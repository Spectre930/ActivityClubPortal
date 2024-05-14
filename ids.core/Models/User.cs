using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ids.core.Models;

public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
}
