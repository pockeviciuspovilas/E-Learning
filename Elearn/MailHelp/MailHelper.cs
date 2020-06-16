using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using Elearn.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;

namespace Elearn.MailHelp
{
    public class MailHelper
    {
        const string fromAdress = "elearnltt@gmail.com";
        string tempPath = @"C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\wwwroot\mails\mailtemplate.html";
        SmtpClient client;
        public MailHelper()
        {
            client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("elearnltt@gmail.com", "Qwerqwer1234"),
                EnableSsl = true
            };
        }



        public void InformAboutAssign(string userEmail, string testName, DateTime expiration)
        {
            string title = "Pranešimas apie priskirtą testą";
            string body = string.Format("Jums buvo priskirtas naujas testas „{0}“, šį testą turite atlikti iki {1}. Ši, bei kitus testus galite peržiūrėti elearn.lt",testName,expiration.ToString());
            string temp = File.ReadAllText(tempPath).Replace("####TITLE####", title).Replace("####BODY####",body);
            var msg = new MailMessage(fromAdress, userEmail, title, temp);
            msg.IsBodyHtml = true;
            client.Send(msg);
        }
        public void InformNewMark(string userEmail, string testName, double mark)
        {
            string title = "Pranešimas apie naują pažymį";
            string body = string.Format("Sveikiname, iš testo „{0}“ gavote {1}. Ši, bei kitus testus galite peržiūrėti elearn.lt",testName,mark);
            string temp = File.ReadAllText(tempPath).Replace("####TITLE####", title).Replace("####BODY####",body);
            var msg = new MailMessage(fromAdress, userEmail, title, temp);
            msg.IsBodyHtml = true;
            client.Send(msg);
        }
        public void InformIncomingAssign(string userEmail, string testName, DateTime expiration)
        {
            string title = "Pranešimas apie priskirtą testą";
            string body = string.Format("Primename, jums buvo priskirtas naujas testas „{0}“, šį testą turite atlikti iki {1}. Ši, bei kitus testus galite peržiūrėti elearn.lt",testName,expiration.ToString());
            string temp = File.ReadAllText(tempPath).Replace("####TITLE####", title).Replace("####BODY####",body);
            var msg = new MailMessage(fromAdress, userEmail, title, temp);
            msg.IsBodyHtml = true;
            client.Send(msg);
        }
        public void InformAboutPasswordChange(string userEmail)
        {
            string title = "Pranešimas apie sėkmingą slaptažodžio pakeitimą";
            string body = "Slaptažodis sėkmingai pakeistas";
            string temp = File.ReadAllText(tempPath).Replace("####TITLE####", title).Replace("####BODY####",body);
            var msg = new MailMessage(fromAdress, userEmail, title, temp);
            msg.IsBodyHtml = true;
            client.Send(msg);
        }


    }
}
