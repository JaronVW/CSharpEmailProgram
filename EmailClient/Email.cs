namespace EmailClient;

public class Email
{
    public string From { get; set; } = null!;
    public string To { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string HtmlBody { get; set; } = null!;
    public string TextBody { get; set; } = null!;
    public string Priority { get; set; } = null!;
}