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
public partial class WebSite5_production_Reports : System.Web.UI.Page
{

    static string pname;
    public string getdata()
    {
        string user = (string)Session["username"];
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct parentnode from user_group_access ug join users u on u.[Group Id] = ug.[Group Id]where u.username ='" + user + "' ";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            htmlstr += "<li><a><i class='fa fa-home'></i>" + name + " <span class='fa fa-chevron - down'></span> </a><ul class='nav child_menu'>";
            SqlConnection sqlcon1 = new SqlConnection(conn);
            sqlcon1.Open();
            string query1 = "select * from user_group_access ug join users u on u.[Group Id] =ug.[Group Id]where ug.ParentNode='" + name + "' and  u.username ='" + user + "'";
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);

            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string pagename = reader1.GetString(1);
                string pageurl = reader1.GetString(3);
                string AccessName = reader1.GetString(11);




                htmlstr += "<li><a href=" + pageurl + "?name=" + AccessName + ">" + pagename + " </a></li>";
                Session["pagename"] = pagename;
                string office = Queries.GetOffice(user);
                Session["office"] = office;
                Session["username"] = user;
            }

            htmlstr += "</ul></li>";



            reader1.Close();
            sqlcon1.Close();
        }
        reader.Close();
        sqlcon.Close();

        return htmlstr;

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }

        //string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }





    protected void Button1_Click(object sender, EventArgs e)
    {


        string reportName = Request.Form["reports"];
        if (reportName == "DGR")
        {
            reportName = Request.Form["reports"];
            string reportPro = Request.Form["reports"];
            string date = Request.Form["example1"];
            string office = Request.Form["office"];
            string venue = Request.Form["venue"];
            string type = Request.Form["type"];


            if (type == ".pdf")
            {
                DataTable datatable = Queries2.loadDGR(reportPro, date, office, venue);

                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + reportName + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);

                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
                string ExportFileName = Server.MapPath("~/reports/" + reportName + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/" + type + "");
                string fn = reportName + "" + type;
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else
            {
                DataTable datatable = Queries2.loadDGR(reportPro, date, office, venue);

                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                crystalReport.Load(Server.MapPath("~/reports/" + reportName + ".rpt")); // path of report       
                crystalReport.SetDataSource(datatable);

                System.IO.FileStream fs = null;
                long FileSize = 0;
                DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
                string ExportFileName = Server.MapPath("~/reports/" + reportName + ".rpt") + "Export";
                crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crystalReport.ExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                oDest.DiskFileName = ExportFileName;
                crystalReport.ExportOptions.DestinationOptions = oDest;
                crystalReport.Export();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Type", "application/" + type + "");
                string fn = reportName + "" + type;
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }

        }else
        {
           // DataTable datatable = Queries2.loadDGR(reportPro, date, office, venue);

            ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
            crystalReport.Load(Server.MapPath("~/reports/sales reports.rpt")); // path of report       
          //  crystalReport.SetDataSource(datatable);

            System.IO.FileStream fs = null;
            long FileSize = 0;
            DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
            //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
            string ExportFileName = Server.MapPath("~/reports/sales reports.rpt") + "Export";
            crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crystalReport.ExportOptions.ExportFormatType = ExportFormatType.Excel;
            oDest.DiskFileName = ExportFileName;
            crystalReport.ExportOptions.DestinationOptions = oDest;
            crystalReport.Export();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Type", "application/.xls");
            string fn = "sales reports.xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

            fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
            FileSize = fs.Length;
            byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
            fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
            fs.Close();
            Response.BinaryWrite(bBuffer);
            Response.Flush();

        }



    }

    public string getvenue()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct Venue_Name from venue";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string venue = reader.GetString(0);
            htmlstr += "<option value='"+ venue +"'>"+venue+"</option>";
        }
        sqlcon.Close();
        return htmlstr;
    }


    public string getCountries()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct Country_Name from country ";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string country = reader.GetString(0);
            htmlstr += "<option value='" + country + "'>" + country + "</option>";
        }
        sqlcon.Close();
        return htmlstr;
    }
}