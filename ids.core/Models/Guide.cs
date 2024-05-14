

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ids.core.Models;

public partial class Guide
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public DateOnly? JoiningDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public string Profession { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public virtual ICollection<EventGuide> EventGuide { get; set; } = new List<EventGuide>();
}
