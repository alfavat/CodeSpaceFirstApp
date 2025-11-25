using System.ComponentModel.DataAnnotations;

namespace MyApp.WebUI.ViewModels.User;

public class RegisterViewModel
{
    [Required(ErrorMessage = "First Name is required.")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Birth Date is required.")]
    public required DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public required string Password { get; set; }
    
    [Required(ErrorMessage = "Confirm Password is required.")]  
    public required string ConfirmPassword { get; set; }
}