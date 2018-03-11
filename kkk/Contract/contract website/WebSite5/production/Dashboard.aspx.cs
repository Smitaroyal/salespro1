using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class WebSite5_production_Dashboard : System.Web.UI.Page
{
    static string pname;
    public string getdata()
    {
        string user = (string)Session["username"];
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string query = "select distinct parentnode from user_group_access ug join users u on u.[Group Id] = ug.[Group Id]where u.username ='"+ user + "' ";
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
            string query1 = "select * from user_group_access ug join users u on u.[Group Id] =ug.[Group Id]where ug.ParentNode='" + name + "' and  u.username ='"+ user + "'";
            SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);

            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string pagename = reader1.GetString(1);
                string pageurl = reader1.GetString(3);
                string AccessName = reader1.GetString(11);


              

                 htmlstr += "<li><a href="+ pageurl +"?name="+ AccessName + ">"+ pagename + " </a></li>";
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
        if (user == null)
        {
            Response.Redirect("login.aspx");
        }
       // string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();

   }
    /* public string getdata()
     {
         string user = (string)Session["username"];
         String conn = "Data Source=192.168.20.7;Initial Catalog=Contractapp;user id=sa;pwd=c10h12n2o";
         string htmlstr = "";
         string query = " select * from user_group_access ug join users u on u.[Group Id] = ug.[Group Id]where u.username ='" + user + "'; ";
         SqlConnection sqlcon = new SqlConnection(conn);
         sqlcon.Open();
         SqlCommand cmd = new SqlCommand(query, sqlcon);
         SqlDataReader reader = cmd.ExecuteReader();
         while (reader.Read())
         {

             string pagename = reader.GetString(1);
             string pageurl = reader.GetString(3);

             htmlstr += "<a href = " + pageurl + " >" + pagename + " </a>";
             Session["pagename"] = pagename;
             string office = Queries.GetOffice(user);
             Session["office"] = office;
         }
         sqlcon.Close();
         return htmlstr;
     }*/

    public string getSignUps()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        string query = "select count(*) from Profile where Office='"+Session["office"] +"'";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int count = reader.GetInt32(0);
            htmlstr += count;
        }
        sqlcon.Close();
        return htmlstr;
    }

    public string getDeals()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        string query = "select count(*) from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID where cf.Contract_Finance_Deal_Drawer='Deal' and p.Office='" + Session["office"] + "'";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int count = reader.GetInt32(0);
            htmlstr += count;
        }
        sqlcon.Close();
        return htmlstr;
    }
    public string getCancelledDeals()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        string query = "select count(*) from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID where cf.Contract_Finance_Deal_Drawer='Cancel' and p.Office='" + Session["office"] + "'";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int count = reader.GetInt32(0);
            htmlstr += count;
        }
        sqlcon.Close();
        return htmlstr;
    }
    public string getTopProfiles()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        string query = "select top(3)p.Profile_Created_By ,ps.PS_Total_Purchase from Profile p join Purchase_Service ps on p.Profile_ID=ps.Profile_ID where office='" + Session["office"] + "' order by ps.PS_Total_Purchase Desc;";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            int amount = reader.GetInt32(1);
            htmlstr += "<li class='media event'> <a class='pull-left border-aero profile_thumb'><i class='fa fa-user aero'></i></a><div class='media-body'><a class='title' href='#'>" + name + "</a> <p><strong>" + amount + " </strong></p><p> Total Purchase</p> </div></li>";
        }




        sqlcon.Close();
        return htmlstr;
    }
    public string getTopSalesRep()
    {
        string htmlstr = "";
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        string query = "select top(1) count(cf.Contract_Finance_Deal_Drawer),cf.Contract_Finance_Sales_Rep from Contract_Finance cf join Profile p on cf.Profile_ID=p.Profile_ID where Office='IVO' and Contract_Finance_Sales_Rep !='' and Contract_Finance_Deal_Drawer='Deal'  GROUP BY Contract_Finance_Sales_Rep order by count(Contract_Finance_Deal_Drawer) desc;";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int count = reader.GetInt32(0);
            string name = reader.GetString(1);
            htmlstr += "  <div class='count'>" + count + "<h6 style='margin-top:auto'>" + name + "</h6></div>";
        }



        sqlcon.Close();

        return htmlstr;
    }
}