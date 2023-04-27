using System.Net.Mail;
using Aspose.Email.Clients.Imap;

namespace EmailClient;

public class EmailServer
{
    private readonly ImapClient _imapClient;
    private readonly SmtpClient _smtpClient;

    public EmailServer(string smtp, string imap, string email, string password)
    {
        try
        {
            _imapClient = new ImapClient(imap, 993, email, password);
            _smtpClient = new SmtpClient(smtp, 587);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Email> RetrieveEmails(int numberOfMails)
    {
        if(NumberOfMailInInbox() < numberOfMails)
            numberOfMails = NumberOfMailInInbox();
        try
        {
            
            var emails = new List<Email>();
            for (var i = 1; i <= numberOfMails; i++)
            {
                _imapClient.SelectFolder("Inbox");
                var msg = _imapClient.FetchMessage(i);
                emails.Add(new Email()
                {
                    From = msg.From.ToString(),
                    To = msg.To.ToString(),
                    Subject = msg.Subject,
                    HtmlBody = msg.HtmlBody,
                    TextBody = msg.Body,
                    Priority = msg.Priority.ToString()
                });
            }

            return emails;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return new List<Email>();
    }

    public int NumberOfMailInInbox()
    {
        return _imapClient.ListMessages("Inbox").Count;
    }

  

    public bool SendEmail(Email email)
    {
        try
        {
            var msg = new MailMessage();
            msg.From = new MailAddress(email.From);
            msg.To.Add(new MailAddress(email.To));
            msg.Subject = email.Subject;
            msg.Body = email.HtmlBody;
            msg.Priority = email.Priority == "High" ? MailPriority.High : MailPriority.Normal;
            _smtpClient.Send(msg);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}