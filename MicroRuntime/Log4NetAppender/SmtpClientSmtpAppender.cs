using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using log4net.Appender;
using log4net.Core;

namespace voidsoft.MicroRuntime.Log4NetAppender
{
    /// <summary>
    /// SmtpClient appender
    /// </summary>
    public class SmtpClientSmtpAppender : SmtpAppender
    {
        protected override void SendBuffer(LoggingEvent[] events)
        {
            try
            {
                StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
                string t = Layout.Header;
                if (t != null)
                {
                    writer.Write(t);
                }
                for (int i = 0; i < events.Length; i++)
                {
                    // Render the event and append the text to the buffer
                    RenderLoggingEvent(writer, events[i]);
                }
                t = Layout.Footer;
                if (t != null)
                {
                    writer.Write(t);
                }
                // Use SmtpClient so we can use SSL.
                SmtpClient client = new SmtpClient(SmtpHost, Port);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(Username, Password);
                string messageText = writer.ToString();
                MailMessage mail = new MailMessage(From, To, Subject, messageText);
                client.Send(mail);
            }
            catch (Exception e)
            {
                ErrorHandler.Error("Error occurred while sending e-mail notification from SmtpClientSmtpAppender.", e);
            }
        }
    }
}