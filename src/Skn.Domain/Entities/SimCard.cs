using Skn.Domain.Commons;

namespace Skn.Domain.Entities;

public class SimCard : Auditable
{
    public string Name { get; set; }
    public int Count { get; set; }
    public string StartSimCard { get; set; }
    public string EndSimCard { get; set;}

    public long UserId { get; set; }
}
