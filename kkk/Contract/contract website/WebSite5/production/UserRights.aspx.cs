using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_UserRights : System.Web.UI.Page
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
   

    public string getAllGroups()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select [Group Id],[Group Name] from user_Group";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            int groupID = reader.GetInt32(0);
            string groupName = reader.GetString(1);
            htmlstr += "<option value='" + groupID + "'>" + groupName + "</option>";
        }



        return htmlstr;
    }
    [WebMethod]
    public static void insertUserRights(string pagename, string pageurl, string parentname, string accessname, string title, string group)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        string query = "insert into user_group_access ([Group Id],[Name],[Title],[PageName],[ParentNode],[AccessName]) values('" + group + "','" + pagename + "','" + title + "','" + pageurl + "','" + parentname + "','" + accessname + "');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();


        sqlcon.Close();


    }

    [WebMethod]
    public static string getAllUserRights()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select ugc.Name,ugc.PageName,ugc.ParentNode,ugc.AccessName,ugc.Title,ugc.[Group Id],ug.[Group Name] from user_group_access ugc join user_Group ug on ugc.[Group Id]=ug.[Group Id] ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string pagename = reader.GetString(0);
            string pageurl = reader.GetString(1);
            string parentname = reader.GetString(2);
            string accessname = reader.GetString(3);
            string title = reader.GetString(4);
            int groupID = reader.GetInt32(5);
            string groupname = reader.GetString(6);
          
        


            JSON += "[\"" + pagename + "\" , \"" + pageurl + "\",\"" + parentname + "\",\"" + accessname + "\",\"" + title + "\",\"" + groupID + "\",\"" + groupname + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;



    }

    [WebMethod]
    public static void deleteUserRights(string pagename,string title )

    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from user_group_access where [Name]='"+pagename+"' and [Title]='" + title + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }





}