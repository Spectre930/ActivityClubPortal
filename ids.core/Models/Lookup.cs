using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ids.core.Models;

public partial class Lookup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public string Orders { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
