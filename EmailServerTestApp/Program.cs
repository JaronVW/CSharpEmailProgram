using EmailClient;

namespace EmailServerTestApp;

class Program
{
    public static void Main(string[] args)
    {
        var emailServer = new EmailServer("smtp.office365.com", "outlook.office365.com", "",
            "");
        var emails = emailServer.RetrieveEmails(12);

        foreach (var email in emails)
        {
            Console.WriteLine($"From: {email.From}");
            Console.WriteLine($"To: {email.To}");
            Console.WriteLine($"Subject: {email.Subject}");
            Console.WriteLine($"Priority: {email.Priority}");
            Console.WriteLine($"TextBody: {email.TextBody}");
            Console.WriteLine();
       
        }
    }
}