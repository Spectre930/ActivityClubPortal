using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ids.core.Models;

public partial class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string RoleName { get; set; }
    public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
}
