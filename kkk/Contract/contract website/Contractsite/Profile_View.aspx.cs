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
public partial class Contractsite_Profile_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string profile = Convert.ToString(Request.QueryString["value"]);

        DataSet ds2 = Queries.LoadProfileOnCreation(profile);
        lblptitle.Text = ds2.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
        lblpfname.Text = ds2.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
        lblplname.Text = ds2.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
        lblpnationality.Text = ds2.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
        lblstitle.Text = ds2.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
        lblsfname.Text = ds2.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
        lblslname.Text = ds2.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
        lblsnationality.Text = ds2.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
        lblpcountry.Text = ds2.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
        lblphone.Text = ds2.Tables[0].Rows[0]["Primary_Mobile"].ToString();
        lblemail.Text = ds2.Tables[0].Rows[0]["Primary_Email"].ToString();
        lblemployment.Text = ds2.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
        lblmaritalstatus.Text = ds2.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
        lbldob.Text = ds2.Tables[0].Rows[0]["dob"].ToString();
        lblhotel.Text = ds2.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
        lblcheckindate.Text = ds2.Tables[0].Rows[0]["arrivaldate"].ToString();
        lblcheckoutdate.Text = ds2.Tables[0].Rows[0]["DepartureDate"].ToString();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*Response.Write("<script>");
        Response.Write("window.print()");
        Response.Write("</script>");
        Button1.Visible = false;*/

        System.IO.FileStream fs = null;
         long FileSize = 0;

        string profile = Convert.ToString(Request.QueryString["value"]);
        Response.Write("<script>");
        Response.Write("window.print()");
        Response.Write("</script>");
        Button1.Visible = false;

      /*  string export = Server.MapPath("~/Profile_View.aspx");
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("Content-Type", "application/pdf");
        string fn = profile + ".pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");
        fs = new System.IO.FileStream(export, FileMode.Open);
        FileSize = fs.Length;
        byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
        fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
        fs.Close();
        Response.BinaryWrite(bBuffer);
        Response.Flush();
        Response.Close();
       Response.End();
        Button1.Visible  = false;*/
       
    }
}