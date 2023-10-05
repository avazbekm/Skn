namespace Skn.Service.DTOs.SimCards;

public class SimCardResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public string StartSimCard { get; set; }
    public string EndSimCard { get; set; }
    public long UserId { get; set; }
}
