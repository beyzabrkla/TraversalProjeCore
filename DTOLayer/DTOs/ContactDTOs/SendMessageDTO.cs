using System;
using System.Collections.Generic;
using System.Text;

namespace DTOLayer.DTOs.ContactDTOs
{
    public class SendMessageDTO
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
