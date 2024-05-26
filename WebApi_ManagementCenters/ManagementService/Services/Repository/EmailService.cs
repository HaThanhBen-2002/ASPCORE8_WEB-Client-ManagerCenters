using ManagementService.Models;
using MailKit.Net.Smtp;
using MimeKit;
using ManagementService.Services.Interfaces;
using ManagementService.Helper.Constants;
namespace ManagementService.Services.Repository
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailService(EmailConfiguration emailConfig) => _emailConfig = emailConfig;
        public string SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
            var recipients = string.Join(", ", message.To);
            return ResponseMessages.GetEmailSuccessMessage(recipients);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Hệ thống BENBEN", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            // Set email content as HtmlBody
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = message.Content
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();

            return emailMessage;
        }



        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);

                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
