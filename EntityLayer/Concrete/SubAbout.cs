using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class SubAbout
    {
        [Key]
        public int SubAboutId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
