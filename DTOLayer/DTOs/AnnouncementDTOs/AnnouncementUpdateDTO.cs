using System;
using System.Collections.Generic;
using System.Text;

namespace DTOLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementUpdateDTO
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
