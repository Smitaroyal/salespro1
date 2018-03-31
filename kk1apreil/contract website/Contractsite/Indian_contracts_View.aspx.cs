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






public partial class _Default : System.Web.UI.Page
{
    static string office;
    static string pointsamt, pointstax, poinstcgst, pointssgst, mrgcode;
    string IGSTrate, Interestrate, mcwaiver;
    string Finance_No, documentationfee, IGST_Amount, No_Emi, emiamt;

   

    static string pemail, semail, sp1email, sp2email;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        if (!Page.IsPostBack)
        {





            string contractno = Convert.ToString(Request.QueryString["ContractNo"]);


            string ProfileID = Queries.GetProfileIDOnContractNo(contractno);
            DataSet ds = Queries.LoadContractNoDetails(contractno);
            string ContractDetails_ID = ds.Tables[0].Rows[0]["ContractDetails_ID"].ToString();
            string mc = ds.Tables[0].Rows[0]["MCWaiver"].ToString();
            DataSet ds1 = Queries.LoadProfielDetailsFull(ProfileID);
            string office = ds1.Tables[0].Rows[0]["Office"].ToString();
            DataSet dsfinance = Queries.LoadFinanceContractDetails(ContractDetails_ID);
            if (ds.Tables[0].Rows.Count == 0)
            {



            }
            else
            {
                string ContractType = ds.Tables[0].Rows[0]["ContractType"].ToString();
                string Finance_Details = ds.Tables[0].Rows[0]["Finance_Details"].ToString();
             
                if (Finance_Details == "Finance")
                {
                    if (ContractType == "Fractionals")
                    {
                        DataSet dsf = Queries.LoadContract_Fractional_IndianDetails(ContractDetails_ID);
                        if (mc == "No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, dsf.Tables[0].Rows[0]["resort"].ToString(), dsf.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if (mc == "Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, dsf.Tables[0].Rows[0]["resort"].ToString(), dsf.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }

                       
                    }
                    else if (ContractType == "Points")
                    {
                        DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);// contractno);

                        string club = dsp.Tables[0].Rows[0]["club"].ToString();
                        string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                        string aff = dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString();
                        
                       
                        if(mc=="No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, club, curr, Finance_Details, aff, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if(mc=="Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, club, curr, Finance_Details, aff, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        
                    }
                    else if (ContractType == "Trade-In-Points")
                    {
                        DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);// contractno);


                        if (mc == "No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, dsp.Tables[0].Rows[0]["New_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if (mc == "Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, dsp.Tables[0].Rows[0]["New_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                     
                    }
                    else if (ContractType == "Trade-In-Weeks")
                    {
                        DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);// contractno);
                        if (mc == "No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if (mc == "Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        
                    }
                    else if(ContractType== "Trade-In-Fractionals")
                    {
                        DataSet dsf = Queries.LoadContract_Fractional_IndianDetails(ContractDetails_ID);
                        if (mc == "No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, dsf.Tables[0].Rows[0]["resort"].ToString(), dsf.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if (mc == "Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, dsf.Tables[0].Rows[0]["resort"].ToString(), dsf.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        

                    }

                }
                else if (Finance_Details == "Non Finance")
                {
                    if (ContractType == "Fractionals")
                    {
                        DataSet dsf = Queries.LoadContract_Fractional_IndianDetails(ContractDetails_ID);
                        if (mc == "No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, dsf.Tables[0].Rows[0]["resort"].ToString(), dsf.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if (mc == "Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, dsf.Tables[0].Rows[0]["resort"].ToString(), dsf.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }


                    }
                    else if (ContractType == "Points")
                    {
                        DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);// contractno);

                        string club = dsp.Tables[0].Rows[0]["club"].ToString();
                        string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                        string aff = dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString();


                        if (mc == "No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, club, curr, Finance_Details, aff, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if (mc == "Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, club, curr, Finance_Details, aff, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }

                    }
                    else if (ContractType == "Trade-In-Points")
                    {
                        DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);// contractno);


                        if (mc == "No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, dsp.Tables[0].Rows[0]["New_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if (mc == "Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, dsp.Tables[0].Rows[0]["New_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }

                    }
                    else if (ContractType == "Trade-In-Weeks")
                    {
                        DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);// contractno);
                        if (mc == "No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if (mc == "Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString(), dsp.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }

                    }
                    else if (ContractType == "Trade-In-Fractionals")
                    {
                        DataSet dsf = Queries.LoadContract_Fractional_IndianDetails(ContractDetails_ID);
                        if (mc == "No")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(ContractType, office, dsf.Tables[0].Rows[0]["resort"].ToString(), dsf.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if (mc == "Yes")
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(ContractType, office, dsf.Tables[0].Rows[0]["resort"].ToString(), dsf.Tables[0].Rows[0]["Currency"].ToString(), Finance_Details, dsfinance.Tables[0].Rows[0]["Affiliate_Type"].ToString(), ds.Tables[0].Rows[0]["MCWaiver"].ToString());
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }


                    }

                }



            }







        }
    }


    protected void Button5_Click(object sender, EventArgs e)
    {

        string contractno = Convert.ToString(Request.QueryString["ContractNo"]);


        string ProfileID = Queries.GetProfileIDOnContractNo(contractno);
        DataSet ds = Queries.LoadContractNoDetails(contractno);
        DataSet ds1 = Queries.LoadProfielDetailsFull(ProfileID);
        string office = ds1.Tables[0].Rows[0]["Office"].ToString();
        if (ds.Tables[0].Rows.Count == 0)
        {



        }
        else
        {
            string ContractType = ds.Tables[0].Rows[0]["ContractType"].ToString();
            string Finance_Details = ds.Tables[0].Rows[0]["Finance_Details"].ToString();
            string contractdetailsID= ds.Tables[0].Rows[0]["ContractDetails_ID"].ToString();
            if (Finance_Details == "Finance")
            {
                if (ContractType == "Fractionals")
                {

                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.Fractional_PA(contractno);
                        ReportDocument crystalReport = new ReportDocument();
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt"));
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
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

                    }

                }
                else if (ContractType == "Points")
                {


                    string printr = PrintPdfDropDownList.SelectedItem.Text;

                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.NewPoints_PA(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                else if (ContractType == "Trade-In-Points")
                {


                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.TradeInPoints_PA(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                else if (ContractType == "Trade-In-Weeks")
                {
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.TradeInWeeks_PA(contractno);

                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                else if (ContractType == "Trade-In-Fractionals")
                {
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.FractionalTradeIn_PA(contractno);

                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
            }
            else if (Finance_Details  == "Non Finance")
            {
                if (ContractType == "Fractionals")
                {
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.Fractional_PA(contractno);

                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                else if (ContractType == "Points")
                {
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.NewPoints_PA(contractno);

                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                else if (ContractType == "Trade-In-Points")
                {
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.TradeInPoints_PA(contractno);

                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                else if (ContractType == "Trade-In-Weeks")
                {
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.TradeInWeeks_PA(contractno);

                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                else if (ContractType == "Trade-In-Fractionals")
                {
                    string printr = PrintPdfDropDownList.SelectedItem.Text;
                    if (printr == "RECEIPT")
                    {
                        DataTable datatable = Queries.ReceiptPage(contractno);
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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
                        DataTable datatable = Queries.FractionalTradeIn_PA(contractno);

                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
                        crystalReport.SetDataSource(datatable);
                        System.IO.FileStream fs = null;
                        long FileSize = 0;
                        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
                        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
                        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        oDest.DiskFileName = ExportFileName;
                        crystalReport.ExportOptions.DestinationOptions = oDest;
                        crystalReport.Export();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("Content-Type", "application/pdf");
                        //   string fn = "test" + ".pdf";
                        string fn = printr + ".pdf";
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

            }

        }
    }
}



