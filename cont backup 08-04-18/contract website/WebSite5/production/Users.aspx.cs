using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        if(user == null)
        {
            Response.Redirect("login.aspx");
        }


       // string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();
    }


    static string pname;
    public string getdata()
    {
        string user = (string)Session["username"];
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
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

   
    


    [WebMethod]
    public static void insertUsers(string username, string password, string name, string email, string office, string department, string group,string title)
    {
        
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd HH:mm:ss:sss";
       
       
        string query = "insert into users ([username],[password],[name],[userstatus],[office],[created_date],[dept],[Group Id],[Email],[Title]) values('" + username + "','" + password + "','" + name + "','Active','"+ office + "','" + time.ToString(format) + "','" + department + "','"+ group + "','"+email+"','"+title+"');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();


        sqlcon.Close();


    }

    [WebMethod]
    public static string getAllUsers()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select u.username,u.password,u.name,u.userstatus,u.office,d.[Dept Code],d.[Dept Name],g.[Group Id],g.[Group Name],u.Email,u.Title from users u join Department d on u.Dept=d.[Dept Code] join user_Group g on u.[Group Id]=g.[Group Id]  ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string username = reader.GetString(0);
            string password = reader.GetString(1);
            string name = reader.GetString(2);
            string userstatus = reader.GetString(3);
            string office = reader.GetString(4);
            string deptCode = reader.GetString(5);
            string deptName = reader.GetString(6);
            int groupID = reader.GetInt32(7);
            string groupName = reader.GetString(8);
            string email = reader.GetString(9);
            string title = reader.GetString(10);

            JSON += "[\"" + username + "\" , \"" + password + "\",\"" + name + "\",\"" + userstatus + "\",\"" + office + "\",\"" + deptCode + "\",\"" + deptName + "\",\"" + groupID + "\",\"" + groupName + "\",\"" + email + "\",\"" + title + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }




    public string getAllGroups()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
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


        sqlcon.Close();
        return htmlstr;
    }

    public string getAllDepartments()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select [Dept Code],[Dept Name] from Department";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            string deptCode = reader.GetString(0);
            string deptName = reader.GetString(1);
            htmlstr += "<option value='" + deptCode + "'>" + deptName + "</option>";
        }


        sqlcon.Close();
        return htmlstr;
    }



    [WebMethod]
    public static void deleteUsers(string username)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from users where [username]='" + username + "';";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }


    [WebMethod]
    public static void updateUsers(string username, string password, string name, string email,string status, string office, string department,string group,string title)
    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);

        sqlcon.Open();


        if (status == "Active")
        {

            string query = "update users set [username]='"+username+ "',[password]='" + password + "',[name]='" + name + "',[userstatus]='" + status + "',[office]='" + office + "',[dept]='" + department + "',[Group Id]='" + group + "',[Email]='" + email + "',[Title]='"+title+"' where [username]='"+username+"';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }
        else
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss:sss";
            string query = "update users set [username]='" + username + "',[password]='" + password + "',[name]='" + name + "',[userstatus]='" + status + "',[office]='" + office + "',[dept]='" + department + "',[Expiry_Date]='"+time.ToString(format)+"',[Group Id]='" + group + "',[Email]='" + email + "',[Title]='" + title + "'  where [username]='" + username + "';";
            SqlCommand cmd2 = new SqlCommand(query, sqlcon);
            cmd2.ExecuteNonQuery();
        }

        sqlcon.Close();

    }




}