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
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.IO;

public partial class Contractsite_Searchprofile : System.Web.UI.Page
{
    static string pname,office;
    protected void Page_Load(object sender, EventArgs e)
    {

          pname = (string)Session["pagename"];
        office = (string)Session["office"];
        if (!Page.IsPostBack)
        {
            searchbyTextBox.Visible = false;
            Button1.Visible = false;
            RadioButtonList1.Visible = true;
            RadioButtonList1.SelectedIndex = -1;
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      
        /*if (RadioButtonList1.SelectedItem.Text == "Name")
        {

        }
        else if (RadioButtonList1.SelectedItem.Text == "Phone No")
        {

        }
        else if (RadioButtonList1.SelectedItem.Text == "Profile ID")
        {*/
            string profileid = Convert.ToString(searchbyTextBox.Text);
            DataSet ds1 = Queries.LoadSearchProfile(profileid,office);
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        //}
    }


    protected void LinkbtnClick(object sender, EventArgs e)
    {
        if (office == "HML")
        {
            if (pname == "Edit Profile")
            {
                Response.Redirect("Edit Profile.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            }
            else if (pname == "Create Contract")
            {

                Response.Redirect("Indian_contracts.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            }
        }
        else if(office=="IVO")
        {
            if (pname == "Edit Profile")
            {
                Response.Redirect("Edit Profile.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            }
            else if (pname == "Create Contract")
            {

                Response.Redirect("contracts.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            }

        }
    }


    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text == "Name")
        {
            searchbyTextBox.Visible = true;
            searchbyTextBox.Text = "";
            Button1.Visible = true;
        }
        else if (RadioButtonList1.SelectedItem.Text == "Phone No")
        {
            searchbyTextBox.Visible = true;
            searchbyTextBox.Text = "";
            Button1.Visible = true;

        }
        else if (RadioButtonList1.SelectedItem.Text == "Profile ID")
        {
            searchbyTextBox.Visible = true;
            searchbyTextBox.Text = "";
            Button1.Visible = true;
        }
       

    }
}

