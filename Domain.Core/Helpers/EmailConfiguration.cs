namespace Domain.Core.Helpers
{
    public class EmailConfiguration
    {
        public string FromEmail { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
    }
}
