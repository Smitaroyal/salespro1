using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data; 
using System.Web.Security; 
using System.Web.UI.HtmlControls; 
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Sql;


public partial class Contractsite_Home : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["username"] == null)
        {
            Response.Redirect("Timeout Page.aspx");
        }

        string groupid = (string)Session["GroupId"];
       string   username = (string)Session["username"];
        string title = (string)Session["title"];
        
        DataSet ds = Queries.LoadUserGroupAccess(groupid,title);
        //for(int i=0;i<ds.Tables[0].Rows.Count;i++)
        //{
        //    //get name
        //    string name = ds.Tables[0].Rows[i]["Name"].ToString();
        //    //get value=1
        //    int value = Queries.GetAccessValue(groupid, title, name);


        //}
         string grptitle = ds.Tables[0].Rows[0]["title"].ToString();


        int read = Convert.ToInt32(ds.Tables[0].Rows[0]["Write"]);
        int modify = Convert.ToInt32(ds.Tables[0].Rows[0]["Modify"]);
        int delete = Convert.ToInt32(ds.Tables[0].Rows[0]["Delete"]);
        int write = Convert.ToInt32(ds.Tables[0].Rows[0]["Read"]);
        int report = Convert.ToInt32(ds.Tables[0].Rows[0]["Report"]);

        if (String.Compare(grptitle, title) == 0)
        {
            //check access rights
            if (read == 0 && modify == 0 && delete == 0)
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
            }
            else if (read == 0 && modify == 0 && delete == 1)
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = true; LinkButton3.Text = "Delete Profile";
            }
            else if (read == 0 && modify == 1 && delete == 0)
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = true; LinkButton2.Text = "Edit Profile";
                LinkButton3.Visible = false;
            }
            else if (read == 0 && modify == 1 && delete == 1)
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = true; LinkButton2.Text = "Edit Profile";
                LinkButton3.Visible = true;
            }
            else if (read == 1 && modify == 0 && delete == 0)
            {
                LinkButton1.Visible = true; LinkButton1.Text = "Create Profile";
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
            }
            else if (read == 1 && modify == 0 && delete == 1)
            {
                LinkButton1.Visible = true; LinkButton1.Text = "Create Profile";
                LinkButton2.Visible = false;
                LinkButton3.Visible = true; LinkButton3.Text = "Delete Profile";
            }
            else if (read == 1 && modify == 1 && delete == 0)
            {
                LinkButton1.Visible = true; LinkButton1.Text = "Create Profile";
                LinkButton2.Visible = true; LinkButton2.Text = "Edit Profile";
                LinkButton3.Visible = false;
            }
            else if (read == 1 && modify == 1 && delete == 1)
            {
                LinkButton1.Visible = true; LinkButton1.Text = "Create Profile";
                LinkButton2.Visible = true; LinkButton2.Text = "Edit Profile";
                LinkButton3.Visible = true; LinkButton3.Text = "Delete Profile";
            }

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string username = (string)Session["username"];
        Session["username"] = username;
        Response.Redirect("CreateProfile.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string username = (string)Session["username"];
        Session["username"] = username;
        string pname = "Edit Profile";
        Session["pname"] = pname;
        Response.Redirect("Searchprofile.aspx");

    }
}