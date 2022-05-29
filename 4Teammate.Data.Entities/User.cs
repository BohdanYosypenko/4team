using Microsoft.AspNetCore.Identity;

namespace _4Teammate.Data.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public byte Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string City { get; set; }
}
