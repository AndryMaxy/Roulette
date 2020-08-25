using System.Net;
using System.Net.Mail;

public class Mailer
{
    const string host = "smtp.gmail.com";
    const int hostPort = 587;
    const string password = "valera0cool1pronov";
    const string from = "valerapronov@gmail.com";

    private MailAddress fromAddress = new MailAddress(from);
    private MailAddress toAddress = new MailAddress("supervareniki@mail.ru");

    public void SendEmail(int number)
    {
        using (MailMessage message = new MailMessage(fromAddress, toAddress))
        {
            message.Subject = "Hello World! " + number;
            message.Body = "Hello";

            using (SmtpClient smtp = new SmtpClient(host, hostPort))
            {
                smtp.Credentials = new NetworkCredential(from, password); ;
                smtp.EnableSsl = true;
                smtp.SendMailAsync(message);
            }
        }
    }
}
