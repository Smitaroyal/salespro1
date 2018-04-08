using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
public partial class WebSite5_production_Exchange_Rate : System.Web.UI.Page
{

    static string pname;
    static string exchangeRate;
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
            sqlcon1.Close();
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

        //string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        Label2.Text = user;
        string val = getdata();

        TextBox9.Text= DateTime.Today.ToString("dd/MM/yyyy");
    }

    [WebMethod]
    public static void insertExchangeRate(string eRatesIDR, string eRatesINR, string eRatesAUD, string eRatesEUR, string eRatesGBP)
    {
       
       
        int id = 0;
        int check;
        string value = "ER";
        string exchangeRateID;
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        DateTime time = DateTime.Now;              
        string format = "yyyy-MM-dd HH:mm:ss:sss";
        String sql = "select count(*) from Exchange_Rate";
        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        id = (int)cmd.ExecuteScalar();
        if (id == 0)
        {
            check = 1;
            exchangeRateID = value + check;

        }
        else
        {
            check = id + 1;
            exchangeRateID = value + check;
        }

        string query1 = "select ERates_ID from Exchange_Rate where ERates_Status='Active'";
        SqlCommand cmd4 = new SqlCommand(query1, sqlcon);
        SqlDataReader reader = cmd4.ExecuteReader();
        while (reader.Read())
        {
            exchangeRate = reader.GetString(0);



        }
        reader.Close();

        string query = "insert into Exchange_Rate ([ERates_ID],[ERates_USD],[ERates_IDR],[ERates_INR],[ERates_AUD],[ERates_EUR],[ERates_Create_Date],[ERates_Expiry_Date],[ERates_Status],[ERates_GBP]) values('" + exchangeRateID+ "','1','"+ eRatesIDR + "','"+ eRatesINR + "','"+ eRatesAUD + "','"+ eRatesEUR + "','" + time.ToString(format)+"','','Active','"+ eRatesGBP + "');";
        SqlCommand cmd1 = new SqlCommand(query, sqlcon);
        cmd1.ExecuteNonQuery();

        if (exchangeRate == "")
        {

        }else
        {
            string query2 = "update Exchange_Rate set ERates_Expiry_Date='" + time.ToString(format) + "', ERates_Status='Inactive' where ERates_ID='" + exchangeRate + "'";
            SqlCommand cmd5 = new SqlCommand(query2, sqlcon);
            cmd5.ExecuteNonQuery();
            
        }

        sqlcon.Close();

    }

    [WebMethod]
    public static string getAllExchangeRate()
    {

        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select ERates_ID,ERates_IDR,ERates_INR,ERates_AUD,ERates_EUR,ERates_GBP from Exchange_Rate where ERates_Status='Active';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string ERates_ID = reader.GetString(0);
            double ERates_IDR = reader.GetDouble(1);
            double ERates_INR = reader.GetDouble(2);
            double ERates_AUD = reader.GetDouble(3);
            double ERates_EUR = reader.GetDouble(4);
            double ERates_GBP = reader.GetDouble(5);
            JSON += "[\"" + ERates_ID + "\" , \"" + ERates_IDR + "\",\"" + ERates_INR + "\",\"" + ERates_AUD + "\",\"" + ERates_EUR + "\",\"" + ERates_GBP + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        reader.Close();
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static void deleteExchangeRate(string exchangeRateID)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "delete from Exchange_Rate where ERates_ID='"+ exchangeRateID + "'";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }
    [WebMethod]
    public static void updateExchangeRate(string exchangeRateID, string eRatesIDR, string eRatesINR,string eRatesAUD, string eRatesEUR,string eRatesGBP)

    {
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "update Exchange_Rate set ERates_IDR='"+ eRatesIDR + "',ERates_INR='"+ eRatesINR + "',ERates_AUD='"+ eRatesAUD + "',ERates_EUR='"+ eRatesEUR + "',ERates_GBP='"+ eRatesGBP + "' where ERates_ID='"+ exchangeRateID + "'";
        sqlcon.Open();
        SqlCommand cmd2 = new SqlCommand(query, sqlcon);
        cmd2.ExecuteNonQuery();
        sqlcon.Close();

    }
}