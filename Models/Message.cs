using System;

namespace MessageGenerator.Models
{
    public class Message
    {
        public Guid ID { get; set; }

        public String Text { get; set; }

        public DateTime Date { get; set; }
    }
}
