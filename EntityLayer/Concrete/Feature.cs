using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        public string? Post1Name { get; set; }
        public string? Post1Description { get; set; }
        public string? Post1Image { get; set; }
        public string? Status { get; set; }
    }
}
