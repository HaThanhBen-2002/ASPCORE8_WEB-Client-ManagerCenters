using MimeKit;

namespace TrainingCenters.Models.Email
{
    public class Message
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message()
        {
            To = [];
            Subject = "";
            Content = "";
        }

        public Message(List<string> to, string subject, string content)
        {
            To = to;
            Subject = subject;
            Content = content;
        }
    }
}
