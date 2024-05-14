namespace ActivityClubPortal.API.Resources
{
    public class EventResource
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public string Cost { get; set; } = null!;

        public string Status { get; set; } = null!;

        public int? LookupId { get; set; }

        public DateOnly DateFrom { get; set; }

        public DateOnly DateTo { get; set; }

        public string? ImageUrl { get; set; }
    }
}

