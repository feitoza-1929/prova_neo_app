using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;
public record UserCreateDto
{
    [Required(ErrorMessage = "User name field is required")]
    public string? UserName { get; init; }
    
    [Required(ErrorMessage = "User password field is required")]
    public string? Password { get; init; }

    public ICollection<string>? Roles { get; init; }
}
