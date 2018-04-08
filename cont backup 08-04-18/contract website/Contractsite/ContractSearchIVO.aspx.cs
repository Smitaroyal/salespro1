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
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

public partial class Contractsite_ContractSearchIVO : System.Web.UI.Page
{
    static string pname, office, user, name;
    protected void Page_Load(object sender, EventArgs e)
    {

        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        //pname = "Create Contract";
        pname = Request.QueryString["name"];
        //  pname = (string)Session["pagename"];
        office = (string)Session["office"];
        user = (string)Session["username"];

        /* if (!Page.IsPostBack)
         {
             searchbyTextBox.Visible = false;
             Button1.Visible = false;
             RadioButtonList1.Visible = true;
             RadioButtonList1.SelectedIndex = -1;
         }*/

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string contractno = Convert.ToString(searchbyTextBox.Text);
        DataSet ds1 = Queries2.LoadSearchContract(contractno);
        GridView1.DataSource = ds1;
        GridView1.DataBind();

    }

    protected void LinkbtnClick(object sender, EventArgs e)
    {
        if (office == "HML")
        {
            if (pname == "EditProfile")
            {
                Response.Redirect("IndiaEdit Profile.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            }
            else if (pname == "CreateContract")
            {

                Response.Redirect("Indian_contracts.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            }
            else if (pname == "EditContract")
            {

                Response.Redirect("Indian_contracts_Edit.aspx?ContractNo=" + ((LinkButton)sender).Text);
            }
            else if (pname == "ViewContract")
            {
                Response.Redirect("Indian_contracts_View.aspx?ContractNo=" + ((LinkButton)sender).Text);
            }

        }
        else if (office == "IVO")
        {
            //if (pname == "EditProfile")
            //{
            //    Response.Redirect("Edit Profile.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            //}
            //else if (pname == "CreateContract")
            //{

            //    Response.Redirect("contracts.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            //}
            // else
            if (pname == "EditContract")
            {
                Response.Redirect("Edit_Contract.aspx?ContractNo=" + ((LinkButton)sender).Text);
            }
            else if(pname == "ViewContract")
            {
                Response.Redirect("ContractView.aspx?ContractNo=" + ((LinkButton)sender).Text);
            }

        }
        else if (office == "ATH")
        {
            if (pname == "EditProfile")
            {
                Response.Redirect("Edit Profile.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            }
            else if (pname == "contractsathens")
            {

                Response.Redirect("contracts athens.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            }

        }
    }

}