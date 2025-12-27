using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Newsletter
    {
        [Key]
        public int NewsletterID { get; set; }
        public string? Mail { get; set; }
    }
}
