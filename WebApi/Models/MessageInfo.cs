using System;

namespace WebApi.Models
{
    public class MessageInfo
    {
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get;set; }
    }
}
