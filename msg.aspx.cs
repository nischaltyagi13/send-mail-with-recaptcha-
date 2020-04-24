using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class msg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string url = HttpContext.Current.Request.Url.AbsoluteUri;
        sendmail();
        //Response.Redirect("index.html");
        
    }

    public void sendmail()
    {
        string name = Request.Form["name"];
        string email = Request.Form["email"];
        string CurrComp = Request.Form["CurrComp"];
        string mobile = Request.Form["mobile"];
        string lookingfor = Request.Form["lookingfor"];
        string message = Request.Form["message"];

        string Subject = string.Empty;
        string Body = string.Empty;

        Subject = "Query From Gtf Technologies Landing Page";
        Body = System.IO.File.ReadAllText(Server.MapPath("Template/contact-us.html"));

        string Subject1 = "Thanks from Gtf Technologies";
        string Body1 = System.IO.File.ReadAllText(Server.MapPath("Template/thanks.htm"));

        Body = Body.Replace("#FIRSTNAME", name).Replace("#PHONE", mobile).Replace("#EMAILID", email).Replace("#Messege", message).Replace("#LookingFOR", lookingfor);
        
        string host = ConfigurationManager.AppSettings["SmtpHost"];
        int port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
        string senderID = ConfigurationManager.AppSettings["SenderMailID"];
        string senderPassword = ConfigurationManager.AppSettings["SenderPwd"];

        string RecieverMailID = ConfigurationManager.AppSettings["RecieverMailID"];

        MailMessage mail1 = new MailMessage();
        mail1.IsBodyHtml = true;

        MailMessage mail2 = new MailMessage();
        mail2.IsBodyHtml = true;

        var smtp = new SmtpClient();
        {
            smtp.Host = host;
            smtp.Port = port;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(senderID, senderPassword);
            smtp.Timeout = 20000;
        }
        // First Mail Sent to Admin
        mail1.Subject = Subject;
        mail1.From = new MailAddress(senderID, "Query from Gtf Technologies Landing Page");
        mail1.To.Add(RecieverMailID);
        mail1.Body = Body;
        smtp.Send(mail1);

        // Second mail sent to Client as a thanks

        mail2.Subject = Subject1;
        mail2.From = new MailAddress(senderID, "Thanks Mail from Gtf Technologies");
        mail2.To.Add(email);
        mail2.Body = Body1;
        smtp.Send(mail2);


    }
}