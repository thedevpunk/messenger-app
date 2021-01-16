namespace Api.Models
{
    public class Message
    {
        public string TimeStamp { get; set; }

        public User Sender { get; set; }
    
        public string Content { get; set; }
    }
}