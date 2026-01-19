using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string ImageUrl { get; set; }
        public required string Gender { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
