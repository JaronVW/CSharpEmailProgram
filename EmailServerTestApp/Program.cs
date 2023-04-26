using EmailClient;

namespace EmailServerTestApp;

class Program
{
    public static void Main(string[] args)
    {
        var emailServer = new EmailServer("smtp.gmail.com", "imap.gmail.com", "", "");
        var emails = emailServer.RetrieveEmails(10);
        
        foreach (var email in emails)
        {
            Console.WriteLine($"From: {email.From}");
            Console.WriteLine($"To: {email.To}");
            Console.WriteLine($"Subject: {email.Subject}");
            Console.WriteLine($"Priority: {email.Priority}");
            Console.WriteLine($"HtmlBody: {email.HtmlBody}");
            Console.WriteLine();
        }
    }
}