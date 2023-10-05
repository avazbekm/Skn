﻿using Skn.Domain.Entities;

namespace Skn.Service.DTOs.Users;

public class UserResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public ICollection<SimCard> SimCards { get; set; }
}
