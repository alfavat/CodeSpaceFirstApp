namespace MyApp.Domain.Dtos
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime? Birthdate {get; set;} = null!;
    }
}
