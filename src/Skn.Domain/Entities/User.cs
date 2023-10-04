using Skn.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace Skn.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
}
