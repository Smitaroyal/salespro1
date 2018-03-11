using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Agent : System.Web.UI.Page
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
    public static void insertAgent(string agentName, string status,string office)
    {
        int id = 0;
        int check;
        string value = "SEM0";
        string agentID;
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        String sql = "select count(*) from Agent";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        id = (int)cmd.ExecuteScalar();
        if (id == 0)
        {
            check = 1;
            agentID = value + check;

        }
        else
        {
            check = id + 1;
            agentID = value + check;
        }
        string query = "insert into Agent ([Agent_ID],[Agent_Name],[Agent_Status],[Agent_Created_Date],[agent_office]) values('" + agentID + "','" + agentName + "','" + status + "','" + time.ToString(format) + "','"+ office + "');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();


        sqlcon.Close();


    }


    [WebMethod]
    public static string getAllAgents()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select * from Agent;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string agentID = reader.GetString(0);
            string agentName = reader.GetString(1);
            string agentStatus = reader.GetString(2);
            string office= reader.GetString(5);

            JSON += "[\"" + agentID + "\" , \"" + agentName + "\",\"" + agentStatus + "\",\"" + office + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;



    }

    [WebMethod]
    public static void deleteAgents(string agentID)

    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Agent where [Agent_ID]='" + agentID + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }

    [WebMethod]
    public static void updateAgents(string agentID, string agentName, string agentStatus, string office)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (agentStatus == "Active")
        {

            string query = "update agent set [Agent_Name]='" + agentName + "',[Agent_Status]='" + agentStatus + "',[agent_office]='" + office + "' where [Agent_ID]='" + agentID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update agent set [Agent_Name]='" + agentName + "',[Agent_Status]='" + agentStatus + "',[agent_office]='" + office + "',[Agent_Expiry_Date]='"+format+"' where [Agent_ID]='" + agentID + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

    }


}