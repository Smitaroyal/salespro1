using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Venue_Group : System.Web.UI.Page
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
    public static void insertVenueGroup(string venueGroupName, string status, string venue,string venueGroupCode)
    {
        int id = 0;
        int check;
        string value = "VG00";
        string venueGroupID;
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        String sql = "select count(*) from Venue_Group";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        id = (int)cmd.ExecuteScalar();
        if (id == 0)
        {
            check = 1;
            venueGroupID = value + check;

        }
        else
        {
            check = id + 1;
            venueGroupID = value + check;
        }
        string query = "insert into Venue_Group ([Venue_Group_ID],[Venue_Group_Name],[Venue_Group_Status],[Venue_Group_Created_Date],[Venue_ID],[Venue_Group_Code]) values('" + venueGroupID + "','" + venueGroupName + "','" + status + "','" + time.ToString(format) + "','" + venue + "','"+ venueGroupCode + "');";
       SqlCommand cmd1 = new SqlCommand(query, sqlcon);
      cmd1.ExecuteNonQuery();


        sqlcon.Close();


    }


    public string getAllVenue()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select Venue_ID ,Venue_Name from venue";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string Venue_ID = reader.GetString(0);
            string Venue_Name = reader.GetString(1);
            htmlstr += "<option value='" + Venue_ID + "'>" + Venue_Name + "</option>";
        }



        return htmlstr;
    }

    [WebMethod]
    public static string getAllVenueGroup()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct vg.Venue_Group_ID,vg.Venue_Group_Name,vg.Venue_group_Code,vg.Venue_Group_Status,v.Venue_ID,v.Venue_Name from Venue_Group vg join venue v on vg.Venue_ID=v.Venue_ID;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string venueGroupID = reader.GetString(0);
            string venueGroupName = reader.GetString(1);
            string venueGroupCode = reader.GetString(2);
            string status = reader.GetString(3);
            string venueID = reader.GetString(4);
            string venueName = reader.GetString(5);


            JSON += "[\"" + venueGroupID + "\" , \"" + venueGroupName + "\",\"" + venueGroupCode + "\",\"" + status + "\",\"" + venueID + "\",\"" + venueName + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;





    }

    [WebMethod]
    public static void deleteVenueGroup(string venueGroupID)

    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Venue_Group where [Venue_Group_ID]='" + venueGroupID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }


    [WebMethod]
    public static void updateVenueGroup(string venueGroupID, string venueGroupName,string venueGroupCode, string status, string venueID)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update Venue_Group set [Venue_Group_Name]='" + venueGroupName + "',[Venue_Group_Code]='"+ venueGroupCode + "',[Venue_Group_Status]='" + status + "',[Venue_ID]='" + venueID + "' where [Venue_Group_ID]='" + venueGroupID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update Venue_Group set [Venue_Group_Name]='" + venueGroupName + "',[Venue_Group_Code]='" + venueGroupCode + "',[Venue_Group_Status]='" + status + "',[Venue_ID]='" + venueID + "',[Venue_Group_Expiry_Date]='"+time.ToString(format)+"' where [Venue_Group_ID]='" + venueGroupID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

    }

}