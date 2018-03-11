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

public partial class Contractsite_getvp : System.Web.UI.Page
{
    static string Profile_IDo;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Profile_ID, tourid, stayid, phid, emid,primaryprofileid;

        string fname, lname, add1, phone1, email1, resort, checkin, checkout, VP_Id;
        string office = "IVO";
        string[] ar = new string[10];
        int i = 0,j;
        string kk;
        int year = DateTime.Now.Year;
        SqlDataReader reader = Queries2.getvpval();
        while (reader.Read())
        {
            ar[i] = reader.GetString(0);
            i++;
        }

        for(j=0;j<i;j++)
        {
            int cnt = Queries2.checkifVPexist(ar[j]);

            if(cnt == 0)
            {
                Profile_ID = Queries.GetProfileID(office);

               // int profile = Queries.InsertProfile(Profile_ID, DateTime.Now, "", "", "", "", "", "", "", "", "", "", "", "", "", "", office, "", "", "", "", "", "", "",ar[j]);

                 primaryprofileid = Queries.GetPrimaryProfileID(office);
                tourid = Queries.GetTourDetailsID(office);
                stayid = Queries.GetStayDetailsID(office);
                phid = Queries.GetPhoneID(office);
                emid = Queries.GetEmailID(office);

               //int adddetail = Queries2.InsertDetailsVP(tourid, stayid, phid, emid,ar[j]);
                DataSet ds1 = Queries2.LoadVPDetails(ar[j]);
                VP_Id= ds1.Tables[0].Rows[0]["VP_Id"].ToString();
                fname = ds1.Tables[0].Rows[0]["VP_First_Name"].ToString(); 
                lname = ds1.Tables[0].Rows[0]["VP_Last_Name"].ToString();
                add1 = ds1.Tables[0].Rows[0]["VP_Address1"].ToString();
                phone1 = ds1.Tables[0].Rows[0]["VP_Phone"].ToString();
                email1 = ds1.Tables[0].Rows[0]["VP_Email"].ToString();
                resort = ds1.Tables[0].Rows[0]["VP_Resort"].ToString();
                checkin = ds1.Tables[0].Rows[0]["VP_Arival_Date"].ToString();
                checkout = ds1.Tables[0].Rows[0]["VP_Departure_Date"].ToString();

                int primary = Queries.InsertPrimaryProfile(primaryprofileid, "", fname, lname, "", "", "", Profile_ID, "", "", "");
                int tourdetails = Queries2.InsertTourDetailsVP(tourid, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", VP_Id, Profile_ID);
                //int staydetails = Queries.InsertProfileStay(stayid, resort, "", checkin, checkout, Profile_ID, tourid);
                int staydetails = Queries.InsertProfileStay(stayid, resort, "", checkin, checkout, Profile_ID);
                //int phone = Queries.InsertPhone(phid, Profile_ID, "", phone1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                int email = Queries.InsertEmail(emid, Profile_ID, email1, "", "", "", "", "", "", "", "", "", "", "");

                int update = Queries.UpdateProfileValue(office, year);
                int updatep = Queries.UpdatePrimaryValue(office, year);
                //int updateadd = Queries.UpdateAddressValue(office, year);
                int updatestay = Queries.UpdateStayValue(office, year);
                int updatetour = Queries.UpdateTourValue(office, year);
                int updatephone = Queries.UpdatePhoneValue(office, year);
                int updateemail = Queries.UpdateEmailValue(office, year);
            }
            else
            {

                DataSet ds1 = Queries2.LoadVPDetails(ar[j]);
                VP_Id = ds1.Tables[0].Rows[0]["VP_Id"].ToString();
                fname = ds1.Tables[0].Rows[0]["VP_First_Name"].ToString();
                lname = ds1.Tables[0].Rows[0]["VP_Last_Name"].ToString();
                add1 = ds1.Tables[0].Rows[0]["VP_Address1"].ToString();
                phone1 = ds1.Tables[0].Rows[0]["VP_Phone"].ToString();
                email1 = ds1.Tables[0].Rows[0]["VP_Email"].ToString();
                resort = ds1.Tables[0].Rows[0]["VP_Resort"].ToString();
                checkin = ds1.Tables[0].Rows[0]["VP_Arival_Date"].ToString();
                checkout = ds1.Tables[0].Rows[0]["VP_Departure_Date"].ToString();

                string profil_id = Queries2.getprofileidVP(VP_Id);

                tourid = Queries.GetTourDetailsID(office);
                stayid = Queries.GetStayDetailsID(office);
                int tourdetails = Queries2.InsertTourDetailsVP(tourid, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", VP_Id, profil_id);
                //int staydetails = Queries.InsertProfileStay(stayid, resort, "", checkin, checkout, profil_id, tourid);

                int updatestay = Queries.UpdateStayValue(office, year);
                int updatetour = Queries.UpdateTourValue(office, year);
            }

        }

   }

    protected  void Button2_Click(object sender, EventArgs e)
    {

       // HttpContext tb = HttpContext.Current;
        string reportName = "DGR"; string reportPro = "DGR"; string date = "2017-12-27"; string office = "HML";
        //var printr = PrintPdfDropDownList.SelectedItem.Text;
        DataTable datatable = Queries2.loadDGR(reportPro, date, office);

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
        Response.AddHeader("Content-Type", "application/pdf");
        string fn = reportName + ".pdf";
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