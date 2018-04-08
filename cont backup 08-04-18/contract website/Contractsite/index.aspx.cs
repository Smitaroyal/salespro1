using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        Label1.Text = "HI!! " + user;
        /* String conn = "Data Source=DESKTOP-TG6R49R;Initial Catalog=test;Integrated Security=True";
         string htmlstr = "";
         string query = "select * from rights where name='gaurav';";
         SqlConnection sqlcon = new SqlConnection(conn);
         sqlcon.Open();
         SqlCommand cmd = new SqlCommand(query, sqlcon);
         SqlDataReader reader1 = cmd.ExecuteReader();

         reader1.Read();
         Label1.Text = "HI!! "+reader1["name"].ToString();
         sqlcon.Close();*/


    }

    public string getdata()
    {
        string user = (string)Session["username"];
         String conn = "Data Source=192.168.20.7;Initial Catalog=Contractapp;user id=sa;pwd=c10h12n2o";
        string htmlstr = "";
        string query = " select * from user_group_access ug join users u on u.[Group Id] = ug.[Group Id]where u.username ='"+user+"'; ";
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
    }
}