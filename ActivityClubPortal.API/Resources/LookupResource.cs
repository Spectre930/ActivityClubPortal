namespace ActivityClubPortal.API.Resources
{
    public class LookupResource
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; } = null!;

        public string Orders { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
