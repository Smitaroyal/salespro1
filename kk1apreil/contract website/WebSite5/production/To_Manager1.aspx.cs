using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_To_Manager1 : System.Web.UI.Page
{

    static string pname;
    public string getdata()
    {
        string user = (string)Session["username"];
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
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

        }
        reader.Close();
        sqlcon.Close();
        return htmlstr;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }

    [WebMethod]
    public static void insertToManager(string tomanagername, string tomanageroffice, string status, string venue,string venueCountryID)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();

        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        if (status == "Active")
        {
            string query = "insert into TO_Manager([TO_Manager_Name],[Office],[TO_Manager_Status],[TO_Manager_CreatedDate],[Venue],[VenueCountry_ID]) values('" + tomanagername + "','" + tomanageroffice + "','" + status + "','" + time.ToString(format) + "','" + venue + "','"+ venueCountryID + "');";
            SqlCommand cmd1 = new SqlCommand(query, sqlcon);
            cmd1.ExecuteNonQuery();
        }

        sqlcon.Close();


    }

    [WebMethod]
    public static string getAllToManager()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct tm.TO_Manager_ID,tm.TO_Manager_Name,tm.Office,tm.TO_Manager_Status,v.Venue_Name,tm.VenueCountry_ID,vc.Venue_Country_Name from TO_Manager tm join venue v on tm.Venue = v.Venue_Name join VenueCountry vc on tm.VenueCountry_ID=vc.Venue_Country_ID; ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            int toManagerID = reader.GetInt32(0);
            string toManagerName = reader.GetString(1);
            string office = reader.GetString(2);
            string status = reader.GetString(3);
            string venueCountryID = reader.GetString(5);
            string venueCountryName = reader.GetString(6);
            string venueName = reader.GetString(4);

            JSON += "[\"" + toManagerID + "\" , \"" + toManagerName + "\",\"" + office + "\",\"" + status + "\",\"" + venueCountryID + "\",\"" + venueCountryName + "\",\"" + venueName + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;



    }

    [WebMethod]
    public static void deleteToManager(string toManagerID)

    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from TO_Manager where [TO_Manager_ID]='" + toManagerID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }

    [WebMethod]
    public static void updateToManager(string toManagerID, string toManagername, string office, string toManagerstatus, string venue,string venuecountry)

    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (toManagerstatus == "Active")
        {

            string query = "update TO_Manager set [TO_Manager_Name]='" + toManagername + "',[Office]='" + office + "',[TO_Manager_Status]='" + toManagerstatus + "',[Venue]='" + venue + "',[VenueCountry_ID]='"+venuecountry+"' where [TO_Manager_ID]='" + toManagerID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update TO_Manager set [TO_Manager_Name]='" + toManagername + "',[Office]='" + office + "',[TO_Manager_Status]='" + toManagerstatus + "',[Venue]='" + venue + "',[TO_Manager_ExpiryDate]='" + time.ToString(format) + "',[VenueCountry_ID]='" + venuecountry + "' where [TO_Manager_ID]='" + toManagerID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

    }



    //public string getAllVenue()
    //{
    //    string htmlstr = "";
    //    String conn = "Data Source=192.168.20.7;Initial Catalog=Contractapp; User ID=sa;Password=c10h12n2o";
    //    SqlConnection sqlcon = new SqlConnection(conn);
    //    string query = "select  Venue_ID ,Venue_Name from Venue";
    //    sqlcon.Open();
    //    SqlCommand cmd = new SqlCommand(query, sqlcon);
    //    SqlDataReader reader = cmd.ExecuteReader();

    //    while (reader.Read())
    //    {

    //        //string venueID = reader.GetString(0);
    //        string venueName = reader.GetString(1);
    //        htmlstr += "<option value='" + venueName + "'>" + venueName + "</option>";
    //    }



    //    return htmlstr;
    //}



    public string getAllVenueCountry()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select Venue_Country_ID ,Venue_Country_Name from VenueCountry";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string venueCountryID = reader.GetString(0);
            string venueCountryName = reader.GetString(1);
            htmlstr += "<option value='" + venueCountryID + "'>" + venueCountryName + "</option>";
        }



        return htmlstr;
    }


    [WebMethod]
    public static string getAllVenue1(string venuecountryID)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='" + venuecountryID + "'); ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string venueName = reader.GetString(0);



            JSON += "[\"" + venueName + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;



    }



    [WebMethod]
    public static string getAllVenue(string venuecountry)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_ID='" + venuecountry + "'); ";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string venueName = reader.GetString(0);



            JSON += "[\"" + venueName + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;



    }
}