using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTOs
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
