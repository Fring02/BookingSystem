using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Users
{
    public class NotifyMessage
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
