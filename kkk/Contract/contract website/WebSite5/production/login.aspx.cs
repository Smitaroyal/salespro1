using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite5_production_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String uname = TextBox1.Text;

        String pwd = TextBox2.Text;
        string groupid = "";
        string title = "";


        //Checking whether username or pwd is blank or not and redirecting to error page 
        if (uname == "" || pwd == "")
        {
         //   Response.Redirect("error.aspx");
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
                    string office = Queries.GetOffice(uname);
                    Session["office"] = office;

                    //Response.Redirect("index.aspx");
                    Response.Redirect("~/WebSite5/production/Dashboard.aspx");
                    //WebSite5\production\Dashboard.aspx
                    //Response.Redirect("~/Contractsite/index.aspx");
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