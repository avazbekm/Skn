using System.ComponentModel.DataAnnotations;

namespace Skn.Service.DTOs.Users;

public class UserCreationDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Phone]
    public string Phone { get; set; }
}
