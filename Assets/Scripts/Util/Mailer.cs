using System.Net;
using System.Net.Mail;

public static class Mailer
{
    const string host = "smtp.gmail.com";
    const int hostPort = 587;
    const string password = "valera0cool1pronov";
    const string from = "valerapronov@gmail.com";

    public static void SendEmail(string body)
    {
        MailAddress fromAddress = new MailAddress(from);
        MailAddress toAddress = new MailAddress("supervareniki@mail.ru");
        using (MailMessage message = new MailMessage(fromAddress, toAddress))
        {
            message.Subject = "Game Report";
            message.Body = body;

            using (SmtpClient smtp = new SmtpClient(host, hostPort))
            {
                smtp.Credentials = new NetworkCredential(from, password); ;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}
