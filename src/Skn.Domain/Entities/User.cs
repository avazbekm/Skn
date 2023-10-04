using Skn.Domain.Commons;

namespace Skn.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public ICollection<SimCard> SimCards { get; set; }
}
