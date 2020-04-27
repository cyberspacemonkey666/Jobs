using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace JobPortal.Engine
{

    public class EmailSender
    {
        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 465;//587;
        static bool enableSSL = true;
        static string emailFromAddress = "amakereproject@gmail.com"; //Sender Email Address  
        static string password = "password123.pro"; //Sender Password  
        static string emailToAddress = "kayceehans@gmail.com"; //Receiver Email Address  
        //  static string subject = "Hello";  
        //  static string body = "Hello, This is Email sending test using gmail.";  

        static string Message, Subject, Email;
        public EmailSender(string message, string subject, string email)
        {
            Message = message;
            Subject = subject;
            Email = email;
        }
        public void Shooter()
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = Subject;
                mail.Body = Message;
                mail.IsBodyHtml = false;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                   // smtp.UseDefaultCredentials = true;
                    
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    //var client = new SmtpClient("smtp.gmail.com", 587)
                    //{
                    //    Credentials = new NetworkCredential("amakereproject@gmail.com", "password123.pro"),
                    //    EnableSsl = true
                    //    //EnableSSLOnMail=true
                    //};
                    ////client.Send("myusername@gmail.com", "myusername@gmail.com", "test", "testbody");
                    //client.Send(Email, "kayceehans@gmail.com", Subject, Message);
                }


            }
        }
    }
}