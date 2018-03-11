using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Venue1 : System.Web.UI.Page
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
    public static void insertVenue(string venuename, string status,string venuecountry)
    {
        int id = 0;
        int check;
        string value = "V00";
        string venueID;
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        String sql = "select count(*) from Venue";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        id = (int)cmd.ExecuteScalar();
        if (id == 0)
        {
            check = 1;
             venueID = value + check;

        }
        else
        {
            check = id + 1;
            venueID = value + check;
        }
        string query = "insert into venue ([Venue_ID],[Venue_Name],[Venue_Status],[Venue_Created_Date],[Venue_Country_ID]) values('" + venueID + "','" + venuename + "','" + status + "','" + time.ToString(format) + "','" + venuecountry + "');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();


        sqlcon.Close();


    }

    [WebMethod]
    public static string getAllVenue()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct v.Venue_ID,v.Venue_Name,v.Venue_Status,vc.Venue_Country_ID,vc.Venue_Country_Name from venue v join VenueCountry vc on v.Venue_Country_ID=vc.Venue_Country_ID;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string venueID = reader.GetString(0);
            string venueName = reader.GetString(1);
            string venueCountryID = reader.GetString(3);
            string status = reader.GetString(2);
            string venueCountryName = reader.GetString(4);


            JSON += "[\"" + venueID + "\" , \"" + venueName + "\",\"" + status + "\",\"" + venueCountryName + "\",\"" + venueCountryID + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;



    }

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
    public static void updateVenue(string venueID, string venueName, string status,string venueCountryID)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update venue set [Venue_Name]='"+venueName+"',[Venue_Status]='"+status+"',[Venue_Country_ID]='"+venueCountryID+"' where [Venue_ID]='"+venueID+"';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update venue set [Venue_Name]='" + venueName + "',[Venue_Status]='" + status + "',[Venue_Expiry_Date]='"+time.ToString(format)+"',[Venue_Country_ID]='" + venueCountryID + "' where [Venue_ID]='" + venueID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

    }



    [WebMethod]
    public static void deleteVenue(string venueID)

    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from venue where [Venue_ID]='" + venueID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }
}