using System;
using System.Collections.Generic;
using System.Text;

namespace DTOLayer.DTOs.MailDTOs
{
    public class MailRequestDTO
    {
        public string SenderMail { get; set; }
        public string Name { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
