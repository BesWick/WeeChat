using System;

namespace WeeChat.Models
{
    public class Conversation
    {
        public Conversation()
        {
            Status = messageStatus.Sent;
        }

        public enum messageStatus
        {
            Sent,
            Delivered
        }

        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Message { get; set; }
        public messageStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
