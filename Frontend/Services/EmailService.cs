namespace Frontend.Services
{
    // Mail sending functionality should probably live in the backend
    public class EmailService(ILogger<EmailService> logger)
    {
        private readonly ILogger<EmailService> _logger = logger;

        /*
        private readonly string _smtpServer = "smtp.example.com"; // Replace with your SMTP server
        private readonly int _smtpPort = 587;
        private readonly string _smtpUser = "your-email@example.com"; // Replace with your email
        private readonly string _smtpPass = "your-email-password"; // Replace with your email password
        */

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress("Task Manager", _smtpUser));
            //message.To.Add(new MailboxAddress("", to));
            //message.Subject = subject;
            //message.Body = new TextPart("plain") { Text = body };

            //using (var client = new SmtpClient())
            //{
            //    await client.ConnectAsync(_smtpServer, _smtpPort, false);
            //    await client.AuthenticateAsync(_smtpUser, _smtpPass);
            //    await client.SendAsync(message);
            //    await client.DisconnectAsync(true);
            //}
            _logger.LogInformation("Sending mail {To}, {Subject}, {Body}", to, subject, body);

            await Task.Delay(2000);
        }
    }
}
