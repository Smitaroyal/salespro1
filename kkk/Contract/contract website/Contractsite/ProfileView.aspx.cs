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


public partial class ProfileView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     string profile = Convert.ToString(Request.QueryString["value"]);
        
        DataSet ds2 =  Queries.LoadProfileOnCreation(profile);
        lblptitle.Text  = ds2.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
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
        lbldob.Text = ds2.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString();
        lblhotel.Text = ds2.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
        lblcheckindate.Text = ds2.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString();
        lblcheckoutdate.Text = ds2.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString();

    }
}