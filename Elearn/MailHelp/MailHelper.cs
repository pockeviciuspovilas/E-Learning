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
        SmtpClient client;
        public MailHelper()
        {
            client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("elearnltt@gmail.com", "Qwerqwer1234"),
                EnableSsl = true
            };
        }



        public void InformAboutAssign(string userEmail, Asign newAssign)
        {
            string title = "Pranešimas apie priskirtą testą";
            string body = string.Format("Jums buvo priskirtas naujas testas „{0}“, šį testą turite atlikti iki {1}. Ši, bei kitus testus galite peržiūrėti elearn.lt",newAssign.Test.Name,newAssign.ExpireDate);
            string temp = File.ReadAllText(@"C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\wwwroot\mails\mailtemplate.html").Replace("####TITLE####", title).Replace("####BODY####",body);
            var msg = new MailMessage(fromAdress, userEmail, title, temp);
            msg.IsBodyHtml = true;
            client.Send(msg);
        }


    }
}
