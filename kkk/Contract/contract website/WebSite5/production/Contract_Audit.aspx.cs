using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

public partial class WebSite5_production_Contract_Audit : System.Web.UI.Page
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
    }



    public string getAllAudits()
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        string audit = "";
        string query = "select * from Contract_audit1 where (Contract_Process_Date is null or Contract_Process_Date = '')";
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string profile_ID = reader.GetString(0);
            string contractNo = reader.GetString(1);
            string fName = reader.GetString(2);
            string lName = reader.GetString(3);
            string conCreatedDate = reader.GetString(4);
            string conProcessDate = reader.GetString(5);

            audit += "<tr><td>"+profile_ID+ "</td><td>" + contractNo + "</td><td>" + fName + "</td><td>" + lName + "</td><td>" + conCreatedDate + "</td><td>" + conProcessDate + "</td><td> <input type='checkbox' id='audit' name='audit' value='"+ contractNo + "'>  </td></tr>";
        }

        sqlcon.Close();
        return audit;
    }

    [WebMethod]
    public static void ContractProcess(string contract_NO)
    {
        string value = contract_NO;
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();

        if(contract_NO != "")
        {
            string[] array= contract_NO.Split(',');
            for (int i = 0; i <= array.Length-1; i++)
            {
                string processDate = DateTime.Now.ToString("yyyy-MM-dd");
                string query = "update Contract_audit1 set Contract_Process_Date='" + processDate + "' where Contract_No='" + array[i] + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.ExecuteNonQuery();

            }
           

        }
        sqlcon.Close();
    }
}