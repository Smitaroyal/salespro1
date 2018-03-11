using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Sql;
using System.Net;
using System.IO;
using System.Web.UI.WebControls.Adapters;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Globalization;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using System.Collections.Generic;

public partial class Contractsite_ContractView : System.Web.UI.Page
{
    static string officeo, GenContNumbglob;
    protected void Page_Load(object sender, EventArgs e)
    {
        string user =  (string)Session["username"];
        string office = Queries.GetOffice(user);
        officeo = office;
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        if (!Page.IsPostBack)
        {

            //string contractno = "RGC9/271117/114";//.ToString(Request.QueryString["ContractNo"]);

            string contractno = Convert.ToString(Request.QueryString["ContractNo"]);

            GenContNumbglob = contractno;

            string fracid = Queries2.getcontIDfromNo(contractno);

            DataSet ds4 = Queries2.LoadAllContractFractionalDetails(fracid);
            string conttype = ds4.Tables[0].Rows[0]["Contract_Finance_Cont_Type"].ToString(); //ds4.Tables[0].Rows[0][""].ToString();

            PrintPdfDropDownList.Items.Clear();
           // string ContType1 = DropDownList40.SelectedItem.Text;
            DataSet ds21 = Queries2.LoadPrintFiles(conttype, office);
            PrintPdfDropDownList.DataSource = ds21;
            PrintPdfDropDownList.DataTextField = "Printpdf_name";
            PrintPdfDropDownList.DataValueField = "Printpdf_name";
            PrintPdfDropDownList.AppendDataBoundItems = true;
            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
            PrintPdfDropDownList.DataBind();

        }

        }

    protected void Button5_Click(object sender, EventArgs e)
    {
        var printr = PrintPdfDropDownList.SelectedItem.Text;
        DataTable datatable = Queries2.loadreport(GenContNumbglob, printr, officeo);

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
        string fn = printr + ".pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

        fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
        FileSize = fs.Length;
        byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
        fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
        fs.Close();
        Response.BinaryWrite(bBuffer);
        Response.Flush();
        // Response.Close();
    }
}