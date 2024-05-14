namespace ActivityClubPortal.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;
    }
}
