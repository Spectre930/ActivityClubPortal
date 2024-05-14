using System;
using System.Collections.Generic;

namespace ids.core.Models;

public partial class UsersRole
{
    public int UsersId { get; set; }

    public int RolesId { get; set; }

    public virtual Role Roles { get; set; } = null!;

    public virtual User Users { get; set; } = null!;
}
