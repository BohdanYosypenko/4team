using Microsoft.AspNetCore.Identity;
using System;

namespace _4Teammate.API.Database.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public byte Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }
    }
}
