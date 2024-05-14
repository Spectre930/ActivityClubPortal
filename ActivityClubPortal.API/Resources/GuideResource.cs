namespace ActivityClubPortal.API.Resources
{
    public class GuideResource
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Profession { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string? ImageUrl { get; set; }


    }
}
