using System.ComponentModel.DataAnnotations;

namespace Skn.Service.DTOs.SimCards;

public class SimCardCreationDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int Count { get; set; }
    [Required]
    public string StartSimCard { get; set; }
    [Required]
    public string EndSimCard { get; set; }
    [Required]
    public long UserId { get; set; }
}
