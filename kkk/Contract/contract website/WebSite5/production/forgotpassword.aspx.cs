using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite5_production_forgotpassword : System.Web.UI.Page
{
    static string password;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string email= Request.Form["emailInput"];
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select password from users where Email='"+email+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            password = reader.GetString(0);
        }

        string pweda = "gauravdeelipphaldessai123"; //password
        string from = "gaurav.phaldessai@karmagroup.com"; //email from
        string to = email;//"gaurav.phaldessai@karmagroup.com"; //email to
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
         mail.To.Add(to);
        mail.From = new MailAddress(from);
        mail.Subject = "User Password";//"This is a test mail";
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "Your Password is "+password;//"Test Mail.";
      
        mail.Priority = MailPriority.High;
        SmtpClient smtp = new SmtpClient();


        smtp.UseDefaultCredentials = true;
        smtp.Credentials = new System.Net.NetworkCredential(from, pweda);
        smtp.Port = 587;
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;

        try
        {
            smtp.Send(mail);
       
            Response.Redirect("login.aspx");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
            Response.Redirect("forgotpassword.aspx");
        } // end try
       
    }
}