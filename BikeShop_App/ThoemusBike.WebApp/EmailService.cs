using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ThoemusBike.WebApp;

public class EmailService : IEmailSender
{
    private readonly SmtpClient _client;
    public EmailService(IConfiguration config)
    {
        //var port = config.GetValue<int>("ThoemusBike:EmailPort");
        //var host = config.GetValue<string>("ThoemusBike:EmailHost")!;
        //_client = new() { Port = port, Host = host };

        var smtpUri = new Uri(config.GetConnectionString("SmtpUri")!);
        _client = new() { Host = smtpUri.Host, Port = smtpUri.Port };
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {       
        var mailMessage = new MailMessage
        {
            Body = htmlMessage,
            Subject = subject,
            IsBodyHtml = true,
            From = new MailAddress("e-commerce@thoemusbike.com", "Carved Rock Shop"),
            To = { email }
        };        
        await _client.SendMailAsync(mailMessage);
    }
}
