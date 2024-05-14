using System;
using System.Collections.Generic;

namespace ids.core.Models;

public partial class EventGuide
{

    public int EventId { get; set; }

    public int GuideId { get; set; }

    public virtual Event Events { get; set; } = null!;

    public virtual Guide Guides { get; set; } = null!;
}
