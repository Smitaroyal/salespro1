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

public partial class Contractsite_test2 : System.Web.UI.Page
{
    static string pname, office,user,name;
    protected void Page_Load(object sender, EventArgs e)
    {

        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        //pname = "Create Contract";
        pname  = Request.QueryString["name"];
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

        /*if (RadioButtonList1.SelectedItem.Text == "Name")
        {

        }
        else if (RadioButtonList1.SelectedItem.Text == "Phone No")
        {

        }
        else if (RadioButtonList1.SelectedItem.Text == "Profile ID")
        {*/
        string profileid = Convert.ToString(searchbyTextBox.Text);
        DataSet ds1 = Queries.LoadSearchProfile(profileid, office);
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        //}
    }


    protected void LinkbtnClick(object sender, EventArgs e)
    {

        //GridViewRow row = GridView1.SelectedRow;

        // In this example, the first column (index 0) contains
        //string kk = row.Cells[0].Text;


        //var ponumber = GridView1.Rows[2].Cells[0].Text;

        //var lb = (LinkButton)sender;
        //var row = (GridViewRow)lb.NamingContainer;

        ////LinkButton btn = (LinkButton)sender;
        //// GridDataItem item = (GridDataItem)btn.NamingContainer;
        //// string name = item["ColumnUniqueName1"].Text;

        //var lblRequestor = row.FindControl("Tour_Id") as System.Web.UI.WebControls.Label;

        //string requestor = lblRequestor.Text;

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
        }
        else if (office == "IVO")
        {
            if (pname == "EditProfile")
            {
                Response.Redirect("Edit Profile.aspx?Profile_ID=" + ((LinkButton)sender).Text);
            }
            else if (pname == "CreateContract")
            {

                Response.Redirect("contracts.aspx?Profile_ID=" + ((LinkButton)sender).Text);
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


    protected void LinkbtnClick2(object sender, EventArgs e)
    {

        GridViewRow gdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string profileID = gdrow.Cells[0].Text;
        string name1 = gdrow.Cells[1].Text;
        string r = gdrow.Cells[2].Text;
        string h = gdrow.Cells[3].Text;
    }


   protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        LinkButton lnkView = (LinkButton)e.CommandSource;
        string dealId = lnkView.CommandArgument;

        if (office =="IVO")
        {

            DataTable datatable = Queries2.loadregcard(dealId);
            var printr = "Guest Reg Form";
            ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
            crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
            crystalReport.SetDataSource(datatable);

            System.IO.FileStream fs = null;
            long FileSize = 0;
            DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
            //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
            string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
            crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            oDest.DiskFileName = ExportFileName;
            crystalReport.ExportOptions.DestinationOptions = oDest;
            crystalReport.Export();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Type", "application/pdf");
            string fn = "Guest Reg Form" + ".pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

            fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
            FileSize = fs.Length;
            byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
            fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
            fs.Close();
            Response.BinaryWrite(bBuffer);
            Response.Flush();
        }
        else if(office=="HML")
        {

            DataTable datatable = Queries2.loadregcard1(dealId);
            var printr = "Guest Reg form india";
            ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
            crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
            crystalReport.SetDataSource(datatable);

            System.IO.FileStream fs = null;
            long FileSize = 0;
            DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
            //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
            string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
            crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            oDest.DiskFileName = ExportFileName;
            crystalReport.ExportOptions.DestinationOptions = oDest;
            crystalReport.Export();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Type", "application/pdf");
            string fn = "Guest Reg Form" + ".pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

            fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
            FileSize = fs.Length;
            byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
            fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
            fs.Close();
            Response.BinaryWrite(bBuffer);
            Response.Flush();

        }
        //Response.Close();
    }
    /* protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
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


     }*/


   
}