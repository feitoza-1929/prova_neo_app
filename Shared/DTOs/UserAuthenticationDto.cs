using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public record UserAuthenticationDto
{
    [Required(ErrorMessage = "User name field is required")]
    public string UserName { get; init; }
    [Required(ErrorMessage = "User password field is required")]
    public string Password { get; init; }
}