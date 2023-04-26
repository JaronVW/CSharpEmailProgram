namespace EmailClient;

public class Email
{
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string HtmlBody { get; set; }
    public string Priority { get; set; }
}