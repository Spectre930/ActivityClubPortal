using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ids.core.Models;

public partial class Event
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public DateOnly DateFrom { get; set; }

    public DateOnly DateTo { get; set; }

    public string Cost { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public int LookupId { get; set; }

    public virtual ICollection<EventGuide> EventGuide { get; set; } = new List<EventGuide>();

    public virtual ICollection<EventsMember> EventsMembers { get; set; } = new List<EventsMember>();

    public virtual Lookup Lookup { get; set; } = null!;
}
