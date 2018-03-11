using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Web.SessionState;

public partial class Contractsite_Login_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String uname = usernameTextBox.Text;

        String pwd = pswdTextBox.Text;
        string groupid = "";
        string title = "";


        //Checking whether username or pwd is blank or not and redirecting to error page 
        if (uname == "" || pwd == "")
        {
            Response.Redirect("error.aspx");
        }
        else
        {
            //check user names exists
            int user = Queries.UserExists(uname);
            if (user == 1)
            {
                //check paswd enetered is corect
                string pd = Queries.PswdCheck(uname);
                if (String.Compare(pd, pwd) == 0)
                {
                   groupid = Queries.GetGroupID(uname);
                    title = Queries.GetTitle(uname);
                    Session["GroupId"] = groupid;
                    Session["username"] = uname;
                    Session["title"] = title;
                 
                    Response.Redirect("index.aspx");

                }
                else
                {
                    Response.Write("Invalid");
                }
            }

            else
            {
                Response.Write("User doesnot exists");
            }
        }

      
            }
}