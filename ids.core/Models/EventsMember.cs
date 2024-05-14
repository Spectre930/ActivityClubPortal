using System;
using System.Collections.Generic;

namespace ids.core.Models;

public partial class EventsMember
{
    public int EventsId { get; set; }

    public int MembersId { get; set; }

    public virtual Event Events { get; set; } = null!;

    public virtual Member Members { get; set; } = null!;
}
