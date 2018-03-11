using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_VenueCountry : System.Web.UI.Page
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
    public static void insertVenueCountry(string venuecountryname, string status)
    {
      
        try
        {
            string data = "name already exixts";         
            int id = 0;
            int check;
            string value = "VC00";
            string venueCountryID;
            String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            String sql = "select count(*) from VenueCountry";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            id = (int)cmd.ExecuteScalar();
            if (id == 0)
            {
                check = 1;
                venueCountryID = value + check;

            }
            else
            {
                check = id + 1;
                venueCountryID = value + check;
            }  

            string query = "insert into VenueCountry ([Venue_Country_ID],[Venue_Country_Name],[Venue_Country_Status],[Venue_Country_Created_Date]) values('" + venueCountryID + "','" + venuecountryname + "','" + status + "','" + time.ToString(format) + "');";
            SqlCommand cmd1 = new SqlCommand(query, sqlcon);
            cmd1.ExecuteNonQuery();


            sqlcon.Close();

        }
        catch (SqlException e)
        {
            
         
     
        }
       
    }
    [WebMethod]
    public static string getAllVenueCountry()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select * from VenueCountry;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string venueCountryID = reader.GetString(0);
            string venueCountryName = reader.GetString(1);

            string status = reader.GetString(2);

            JSON += "[\"" + venueCountryID + "\" , \"" + venueCountryName + "\",\"" + status + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;



    }
    [WebMethod]
    public static void deleteVenueCountry(string venueCountryID)

    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from VenueCountry where [Venue_Country_ID]='" + venueCountryID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }

    [WebMethod]
    public static void updateVenueCountry(string venuecountryID, string venuecountryName, string status)

    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update VenueCountry set [Venue_Country_Name]='" + venuecountryName + "',[Venue_Country_Status]='" + status + "' where [Venue_Country_ID]='" + venuecountryID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update VenueCountry set [Venue_Country_Name]='" + venuecountryName + "',[Venue_Country_Status]='" + status + "',[Venue_Country_Expiry_Date]='" + time.ToString(format) + "' where [Venue_Country_ID]='" + venuecountryID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

    }

}