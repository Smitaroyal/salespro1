using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

/// <summary>
/// Summary description for Queries2
/// </summary>
public class Queries2
{

    public static SqlConnection GetDBConnection()
    {
        // Get the connection string from the configuration file
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        // Create a new connection object
        SqlConnection connection = new SqlConnection(connectionString);

        // Open the connection, and return it
        connection.Open();
        return connection;
    }
    public static DataSet LoadVenueCountry(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Country_Name  from VenueCountry where Venue_Country_Status = 'Active' and venue_country_office = '"+office+"' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadVenue(string VenueCountry,string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Name from venue where Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='"+VenueCountry+ "') and Venue_Status = 'Active' and Venue_Name <> '"+ venue +"' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadVenuebasedOnCountryID(string venuecountry)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Name  from venue where Venue_Country_ID =@venuecountry", cs1);
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static String GetVenueCountryCode(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("  select Venue_Country_ID  from VenueCountry where Venue_Country_Name =@name", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    /*  public static DataSet LoadVenueGroup()
      {
          SqlDataAdapter da;
          DataSet ds = new DataSet();
          using (SqlConnection cs1 = Queries.GetDBConnection())
          {
              SqlCommand SqlCmd = new SqlCommand("select Venue_Group_Name  from Venue_Group where Venue_Group_Status='Active' order by 1", cs1);
              da = new SqlDataAdapter(SqlCmd);
              ds = new DataSet();
              da.Fill(ds);
          }
          return (ds);

      }*/
    public static String GetVenueCode(string name, string country)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_ID from venue where Venue_Name=@name and Venue_Country_ID =@country", cs1);

            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            scd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static DataSet LoadVenueGroup(string vcode)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand SqlCmd = new SqlCommand("select Venue_Group_Name  from Venue_Group where Venue_Group_Status='Active' order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select  Venue_Group_Name  from Venue_Group where Venue_ID =@vcode", cs1);
            SqlCmd.Parameters.Add("@vcode", SqlDbType.VarChar).Value = vcode;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static String GetVenueGroupCode(string name)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand("select Venue_Group_ID from Venue_Group where Venue_Group_Name=@name", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static DataSet LoadMarketingProgram(string vgcode)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            // SqlCommand SqlCmd = new SqlCommand("select Marketing_Program_Name  from Marketing_Program where  Marketing_Program_Status='Active' order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand(" select Marketing_Program_Name  from Marketing_Program where  Venue_Group_ID=@vgcode", cs1);
            SqlCmd.Parameters.Add("@vgcode", SqlDbType.VarChar).Value = vgcode;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadAgents()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Agent_Name  from Agent where Agent_Status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }
    public static DataSet LoadAgentCode()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Agent_Code_Name  from Agent_Code where Agent_Code_Status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadMemberType()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Member_Type_name   from Member_Type where Member_Type_status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCode()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name  from country order by COrder desc,Country_Name", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryName()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Country_Name from Country order by COrder desc,Country_Name", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadNationality()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Nationality_Name from Nationality order by orders desc,Nationality_Name asc", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadGuestStatus()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Guest_Status_name  from Guest_Status where Guest_Status_Status ='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadSalesRep()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select sales_rep_name from Sales_Rep  where sales_rep_status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    //public static String  GetProfileID(string off)
    //{ 
    //    string ProfileID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    int chek = 0;
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            /* SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_ID ,7,len(Profile_ID)))from profile where Profile_Venue_Country=@off", cs1);
    //             //  SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_ID ,7,len(Profile_ID)))from profile", cs1);
    //             scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //             SqlDataReader dr = scd.ExecuteReader();
    //             if (dr.Read() == true)
    //             {
    //                 string len = string.Format("{0}", dr[0]);
    //                 if (len.Length != 0)
    //                 {
    //                     id = Convert.ToInt32(len);
    //                     id = id + 1;
    //                     ProfileID = startvalue + "000" + id;
    //                 }
    //                 else
    //                 {
    //                     id = 1;
    //                     ProfileID = startvalue + "000" + id;
    //                 }
    //             }*/

    //            //check if record exists with hmc
    //            //SqlCommand scd1 = new SqlCommand("select distinct profile_id from profile where profile_id like 'hmc%'", cs1);
    //            //SqlDataReader dr = scd1.ExecuteReader();
    //            //if(dr.Read()==true)
    //            //{
    //            //    chek = 1;
    //                //get last code of profile n increment by 1
    //                SqlCommand scd = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue", cs1);
    //                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //                string val = (string)scd.ExecuteScalar();
    //                id = Convert.ToInt32(val) + 1;
    //                ProfileID = startvalue + id;
    //                 id = id + 1;
    //                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue", cs1);
    //                     sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //                   int rows = sqlcmd.ExecuteNonQuery();
    //            //}
    //            //else
    //            //{
    //            //    chek = 0;
    //            //    //else insert int
    //            //    SqlCommand scd = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue", cs1);
    //            //    scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //            //    string val = (string)scd.ExecuteScalar();
    //            //    id = Convert.ToInt32(val) + 1;
    //            //    ProfileID = startvalue + id;
    //            //}
    //        }
    //        else 
    //        {
    //            /* string sel = off;
    //             startvalue = "IVO";
    //             SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_ID ,7,len(Profile_ID)))from profile where Profile_Venue_Country=@sel", cs1);
    //             //  SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_ID ,7,len(Profile_ID)))from profile", cs1);
    //             scd.Parameters.Add("@sel", SqlDbType.VarChar).Value = sel;
    //             SqlDataReader dr = scd.ExecuteReader();
    //             if (dr.Read() == true)
    //             {
    //                 string len = string.Format("{0}", dr[0]);
    //                 if (len.Length != 0)
    //                 {
    //                     id = Convert.ToInt32(len);
    //                     id = id + 1;
    //                     ProfileID = startvalue + "000" + id;
    //                 }
    //                 else
    //                 {
    //                     id = 1;
    //                     ProfileID = startvalue + "000" + id;
    //                 }
    //             }*/

    //            SqlCommand scd1 = new SqlCommand("select distinct profile_id from profile where profile_id like 'IVO%'", cs1);
    //            SqlDataReader dr = scd1.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                chek = 1;
    //                //get last code of profile n increment by 1
    //                SqlCommand scd = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue", cs1);
    //                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //                string val = (string)scd.ExecuteScalar();
    //                id = Convert.ToInt32(val) + 1;
    //                ProfileID = startvalue + id;
    //            }
    //            else
    //            {
    //                chek = 0;
    //                //else insert int
    //                SqlCommand scd = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue", cs1);
    //                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
    //                string val = (string)scd.ExecuteScalar();
    //                id = Convert.ToInt32(val) + 1;
    //                ProfileID = startvalue + id;
    //            }
    //        }

    //    }

    //    return  ProfileID;
    //}
    public static int InsertIDGeneration(string venue, int year)
    {
        int rowsAffected = 0;

        int Profile_Start_Val = 0;
        int Primary_Start_Val = 0;
        int Secondary_Start_Val = 0;
        int SubProfile1_Start_Val = 0;
        int SubProfile2_Start_Val = 0;
        int Address_Start_Val = 0;
        int Phone_Start_Val = 0;
        int Email_Start_Val = 0;
        int Profile_Stay_Start_Val = 0;
        int Tour_Details_Start_Val = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into ID_Generation values(@VenueCode,	@Year,	@Profile_Start_Val,	@Primary_Start_Val,	@Secondary_Start_Val,	@SubProfile1_Start_Val,	@SubProfile2_Start_Val,	@Address_Start_Val,	@Phone_Start_Val,	@Email_Start_Val,	@Profile_Stay_Start_Val,	@Tour_Details_Start_Val)", cs1);
                da.InsertCommand.Parameters.Add("@VenueCode", SqlDbType.VarChar).Value = venue;
                da.InsertCommand.Parameters.Add("@Year", SqlDbType.Int).Value = year;
                da.InsertCommand.Parameters.Add("@Profile_Start_Val", SqlDbType.VarChar).Value = Profile_Start_Val;
                da.InsertCommand.Parameters.Add("@Primary_Start_Val", SqlDbType.VarChar).Value = Primary_Start_Val;
                da.InsertCommand.Parameters.Add("@Secondary_Start_Val", SqlDbType.VarChar).Value = Secondary_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile1_Start_Val", SqlDbType.VarChar).Value = SubProfile1_Start_Val;
                da.InsertCommand.Parameters.Add("@SubProfile2_Start_Val", SqlDbType.VarChar).Value = SubProfile2_Start_Val;
                da.InsertCommand.Parameters.Add("@Address_Start_Val", SqlDbType.VarChar).Value = Address_Start_Val;
                da.InsertCommand.Parameters.Add("@Phone_Start_Val", SqlDbType.VarChar).Value = Phone_Start_Val;
                da.InsertCommand.Parameters.Add("@Email_Start_Val", SqlDbType.VarChar).Value = Email_Start_Val;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Start_Val", SqlDbType.VarChar).Value = Profile_Stay_Start_Val;
                da.InsertCommand.Parameters.Add("@Tour_Details_Start_Val", SqlDbType.VarChar).Value = Tour_Details_Start_Val;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert ID_Generation Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }
    public static String GetProfileID(string off)
    {
        string ProfileID = null;
        string startvalue = "";
        int id = 0;
        int chek = 0;
        int year = DateTime.Now.Year;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    ProfileID = startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    ProfileID = startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }

            }
            else
            {
                startvalue = "IVO";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    ProfileID = startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    ProfileID = startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }



            }

        }

        return ProfileID;
    }

    public static int InsertProfile(string Profile_ID, DateTime Profile_Date_Of_Insertion, string Profile_Created_By, string Profile_Venue_Country, string Profile_Venue, string Profile_Group_Venue, string Profile_Marketing_Program, string Profile_Agent, string Profile_Agent_Code, string Profile_Member_Type1, string Profile_Member_Number1, string Profile_Member_Type2, string Profile_Member_Number2, string Profile_Employment_status, string Profile_Marital_status, string Profile_NOY_Living_as_couple, string Office, string Comments, string Manager, string Photo_identity, string Card_Holder, string Reception, string SubVenue, string regTerms, string VP_ID, string Company_Name,string RegTerms2,string Secondemploymentstatus, string Lead_Source,string Pre_Arrival, string Verification)
    {

        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile values(@Profile_ID,	@Profile_Date_Of_Insertion,	@Profile_Created_By,	@Profile_Venue_Country,	@Profile_Venue,	@Profile_Group_Venue,	@Profile_Marketing_Program,	@Profile_Agent,	@Profile_Agent_Code,	@Profile_Member_Type1,	@Profile_Member_Number1,	@Profile_Member_Type2,	@Profile_Member_Number2,	@Profile_Employment_status,	@Profile_Marital_status,	@Profile_NOY_Living_as_couple,@Office,@Comments,@Manager,@Photo_identity,@Card_Holder,@Reception,@SubVenue,@regTerms,@VP_ID,@Company_Name,@RegTerms2,@Secondemploymentstatus,@Lead_Source,@Pre_Arrival,@Verification)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Profile_Date_Of_Insertion", SqlDbType.DateTime).Value = Profile_Date_Of_Insertion;
                da.InsertCommand.Parameters.Add("@Profile_Created_By", SqlDbType.VarChar).Value = Profile_Created_By;
                da.InsertCommand.Parameters.Add("@Profile_Venue_Country", SqlDbType.VarChar).Value = Profile_Venue_Country;
                da.InsertCommand.Parameters.Add("@Profile_Venue", SqlDbType.VarChar).Value = Profile_Venue;
                da.InsertCommand.Parameters.Add("@Profile_Group_Venue", SqlDbType.VarChar).Value = Profile_Group_Venue;
                da.InsertCommand.Parameters.Add("@Profile_Marketing_Program", SqlDbType.VarChar).Value = Profile_Marketing_Program;
                da.InsertCommand.Parameters.Add("@Profile_Agent", SqlDbType.VarChar).Value = Profile_Agent;
                da.InsertCommand.Parameters.Add("@Profile_Agent_Code", SqlDbType.VarChar).Value = Profile_Agent_Code;
                da.InsertCommand.Parameters.Add("@Profile_Member_Type1", SqlDbType.VarChar).Value = Profile_Member_Type1;
                da.InsertCommand.Parameters.Add("@Profile_Member_Number1", SqlDbType.VarChar).Value = Profile_Member_Number1;
                da.InsertCommand.Parameters.Add("@Profile_Member_Type2", SqlDbType.VarChar).Value = Profile_Member_Type2;
                da.InsertCommand.Parameters.Add("@Profile_Member_Number2", SqlDbType.VarChar).Value = Profile_Member_Number2;
                da.InsertCommand.Parameters.Add("@Profile_Employment_status", SqlDbType.VarChar).Value = Profile_Employment_status;
                da.InsertCommand.Parameters.Add("@Profile_Marital_status", SqlDbType.VarChar).Value = Profile_Marital_status;
                da.InsertCommand.Parameters.Add("@Profile_NOY_Living_as_couple", SqlDbType.VarChar).Value = Profile_NOY_Living_as_couple;
                da.InsertCommand.Parameters.Add("@Office", SqlDbType.VarChar).Value = Office;
                da.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;
                da.InsertCommand.Parameters.Add("@Manager", SqlDbType.VarChar).Value = Manager;
                da.InsertCommand.Parameters.Add("@Photo_identity", SqlDbType.VarChar).Value = Photo_identity;
                da.InsertCommand.Parameters.Add("@Card_Holder", SqlDbType.VarChar).Value = Card_Holder;
                da.InsertCommand.Parameters.Add("@Reception", SqlDbType.VarChar).Value = Reception;
                da.InsertCommand.Parameters.Add("@SubVenue", SqlDbType.VarChar).Value = SubVenue;
                da.InsertCommand.Parameters.Add("@regTerms", SqlDbType.VarChar).Value = regTerms;
                da.InsertCommand.Parameters.Add("@VP_ID", SqlDbType.VarChar).Value = VP_ID;
                da.InsertCommand.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = Company_Name;
                da.InsertCommand.Parameters.Add("@RegTerms2", SqlDbType.VarChar).Value = RegTerms2;
                da.InsertCommand.Parameters.Add("@Secondemploymentstatus", SqlDbType.VarChar).Value = Secondemploymentstatus;
                da.InsertCommand.Parameters.Add("@Lead_Source", SqlDbType.VarChar).Value = Lead_Source;
                da.InsertCommand.Parameters.Add("@Pre_Arrival", SqlDbType.VarChar).Value = Pre_Arrival;
                da.InsertCommand.Parameters.Add("@Verification", SqlDbType.VarChar).Value = Verification;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Profile Query " + ex.Message);

                string msg = "Error in Insert Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);

    }

   
    //public static String GetPrimaryProfileID(string off)
    //{
    //    string PProfileID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    /*if (off == "INDIA")
    //    {
    //        startvalue = "HMC";
    //    }
    //    else //if (off == "BALI")
    //    {
    //        startvalue = "IVO";
    //    }*/
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        //  SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Primary_ID ,6,len(Profile_Primary_ID)))from Profile_Primary", cs1);
    //        //    SqlCommand scd = new SqlCommand("select max(SUBSTRING(pp.Profile_Primary_ID, 6, len(pp.Profile_Primary_ID)))from Profile_Primary pp join profile p on p.Profile_ID = pp.Profile_ID where p.Profile_Venue_Country= @off and  pp.Profile_Primary_ID like 'P_HMC%'", cs1);
    //        if (off == "INDIA"||off=="India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(pp.Profile_Primary_ID, 6, len(pp.Profile_Primary_ID)))from Profile_Primary pp where  pp.Profile_Primary_ID like 'P_HMC%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else 
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(pp.Profile_Primary_ID, 6, len(pp.Profile_Primary_ID)))from Profile_Primary pp where  pp.Profile_Primary_ID like 'P_IVO%'", cs1);
    //           // scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PProfileID = "P_" + startvalue + id;
    //                }
    //            }
    //        }


    //    }

    //    return PProfileID;
    //}
    public static String GetPrimaryProfileID(string off)
    {
        string PProfileID = null;
        string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "P";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Primary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Primary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }
            else
            {
                startvalue = "IVO";

                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Primary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Primary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }


        }

        return PProfileID;
    }
    public static int InsertPrimaryProfile(string Profile_Primary_ID, string Profile_Primary_Title, string Profile_Primary_Fname, string Profile_Primary_Lname, string Profile_Primary_DOB, string Profile_Primary_Nationality, string Profile_Primary_Country, string Profile_ID, string Primary_Age, string Primary_Designation, string Primary_Language)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile_Primary values(@Profile_Primary_ID,	@Profile_Primary_Title,	@Profile_Primary_Fname,	@Profile_Primary_Lname,	convert(datetime,@Profile_Primary_DOB,105),@Profile_Primary_Nationality,@Profile_Primary_Country,@Profile_ID,@Primary_Age,@Primary_Designation,@Primary_Language)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_Primary_ID", SqlDbType.VarChar).Value = Profile_Primary_ID;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Title", SqlDbType.VarChar).Value = Profile_Primary_Title;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Fname", SqlDbType.VarChar).Value = Profile_Primary_Fname;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Lname", SqlDbType.VarChar).Value = Profile_Primary_Lname;
                da.InsertCommand.Parameters.Add("@Profile_Primary_DOB", SqlDbType.VarChar).Value = Profile_Primary_DOB;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Nationality", SqlDbType.VarChar).Value = Profile_Primary_Nationality;
                da.InsertCommand.Parameters.Add("@Profile_Primary_Country", SqlDbType.VarChar).Value = Profile_Primary_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Primary_Age", SqlDbType.VarChar).Value = Primary_Age;
                da.InsertCommand.Parameters.Add("@Primary_Designation", SqlDbType.VarChar).Value = Primary_Designation;
                da.InsertCommand.Parameters.Add("@Primary_Language", SqlDbType.VarChar).Value = Primary_Language;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Primary Profile Query " + ex.Message);

                string msg = "Error in Insert Primary Profile Query" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    //public static String GetSecondaryProfileID(string off)
    //{
    //    string SProfileID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Secondary_ID ,6,len(Profile_Secondary_ID)))from Profile_Secondary  where  Profile_Secondary_ID like 'S_HMC%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SProfileID = "S_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SProfileID = "S_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else

    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Secondary_ID ,6,len(Profile_Secondary_ID)))from Profile_Secondary  where  Profile_Secondary_ID like 'S_IVO%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SProfileID = "S_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SProfileID = "S_" + startvalue + id;
    //                }
    //            }

    //        }
    //    }

    //    return SProfileID;
    //}

    public static String GetSecondaryProfileID(string off)
    {
        string SProfileID = null;
        string startvalue = "";
        int id = 0;

        int year = DateTime.Now.Year;
        string initial = "S";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }
            else
            {
                startvalue = "IVO";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Secondary_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Secondary_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }

        }

        return SProfileID;
    }
    public static int InsertSecondaryProfile(string Profile_Secondary_ID, string Profile_Secondary_Title, string Profile_Secondary_Fname, string Profile_Secondary_Lname, string Profile_Secondary_DOB, string Profile_Secondary_Nationality, string Profile_Secondary_Country, string Profile_ID, string Secondary_Age, string Secondary_Designation, string Secondary_Language)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Profile_Secondary values(@Profile_Secondary_ID, 	@Profile_Secondary_Title,@Profile_Secondary_Fname,@Profile_Secondary_Lname,convert(datetime,@Profile_Secondary_DOB,105),@Profile_Secondary_Nationality,@Profile_Secondary_Country,@Profile_ID,@Secondary_Age,@Secondary_Designation,@Secondary_Language)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_Secondary_ID ", SqlDbType.VarChar).Value = Profile_Secondary_ID;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Title ", SqlDbType.VarChar).Value = Profile_Secondary_Title;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Fname ", SqlDbType.VarChar).Value = Profile_Secondary_Fname;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Lname ", SqlDbType.VarChar).Value = Profile_Secondary_Lname;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_DOB ", SqlDbType.VarChar).Value = Profile_Secondary_DOB;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Nationality ", SqlDbType.VarChar).Value = Profile_Secondary_Nationality;
                da.InsertCommand.Parameters.Add("@Profile_Secondary_Country ", SqlDbType.VarChar).Value = Profile_Secondary_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Secondary_Age", SqlDbType.VarChar).Value = Secondary_Age;
                da.InsertCommand.Parameters.Add("@Secondary_Designation", SqlDbType.VarChar).Value = Secondary_Designation;
                da.InsertCommand.Parameters.Add("@Secondary_Language", SqlDbType.VarChar).Value = Secondary_Language;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Secondary Profile Query " + ex.Message);

                string msg = "Error in Insert Secondary Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    //public static String GetAddressProfileID(string off)
    //{
    //    string AProfileID = null;
    //    string startvalue = "";
    //    int id = 0;

    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Address_ID ,6,len(Profile_Address_ID)))from Profile_Address where Profile_Address_ID like 'A_HMC%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    AProfileID = "A_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    AProfileID = "A_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Address_ID ,6,len(Profile_Address_ID)))from Profile_Address where Profile_Address_ID like 'A_IVO%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    AProfileID = "A_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    AProfileID = "A_" + startvalue + id;
    //                }
    //            }
    //        }
    //    }

    //    return AProfileID;
    //}
    public static String GetAddressProfileID(string off)
    {
        string AProfileID = null;
        string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "A";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    AProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    AProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }
            else
            {
                startvalue = "IVO";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    AProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Address_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    AProfileID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Address_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }

        }

        return AProfileID;
    }
    public static int InsertProfileAddress(string Profile_Address_ID, string Profile_Address_Line1, string Profile_Address_Line2, string Profile_Address_State, string Profile_Address_city, string Profile_Address_Postcode, DateTime Profile_Address_Created_Date, string Profile_Address_Expiry_Date, string Profile_ID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile_Address values(@Profile_Address_ID ,	@Profile_Address_Line1,	@Profile_Address_Line2 ,@Profile_Address_State,	@Profile_Address_city, 	@Profile_Address_Postcode ,	@Profile_Address_Created_Date, 	@Profile_Address_Expiry_Date ,@Profile_ID)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_Address_ID ", SqlDbType.VarChar).Value = Profile_Address_ID;
                da.InsertCommand.Parameters.Add("@Profile_Address_Line1 ", SqlDbType.VarChar).Value = Profile_Address_Line1;
                da.InsertCommand.Parameters.Add("@Profile_Address_Line2 ", SqlDbType.VarChar).Value = Profile_Address_Line2;
                da.InsertCommand.Parameters.Add("@Profile_Address_State ", SqlDbType.VarChar).Value = Profile_Address_State;
                da.InsertCommand.Parameters.Add("@Profile_Address_city ", SqlDbType.VarChar).Value = Profile_Address_city;
                da.InsertCommand.Parameters.Add("@Profile_Address_Postcode ", SqlDbType.VarChar).Value = Profile_Address_Postcode;
                da.InsertCommand.Parameters.Add("@Profile_Address_Created_Date ", SqlDbType.DateTime).Value = Profile_Address_Created_Date;
                da.InsertCommand.Parameters.Add("@Profile_Address_Expiry_Date ", SqlDbType.VarChar).Value = Profile_Address_Expiry_Date;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;


                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Profile_Address Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }



    //public static String GetSubProfile1ID(string off)
    //{
    //    string SubProfile1ID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile1_ID  ,8,len(Sub_Profile1_ID)))from Sub_Profile1 where Sub_Profile1_ID like 'SP1_HMC%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile1ID = "SP1_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile1ID = "SP1_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile1_ID ,8,len(Sub_Profile1_ID)))from Sub_Profile1 where Sub_Profile1_ID like 'SP1_IVO%'", cs1);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile1ID = "SP1_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile1ID = "SP1_" + startvalue + id;
    //                }
    //            }

    //        }
    //    }

    //    return SubProfile1ID;
    //}
    public static String GetSubProfile1ID(string off)
    {
        string SubProfile1ID = null;
        string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP1";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile1ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile1ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }
            else
            {
                startvalue = "IVO";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile1ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile1_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile1ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }

        }

        return SubProfile1ID;
    }
    public static int InsertSub_Profile1(string Sub_Profile1_ID, string Sub_Profile1_Title, string Sub_Profile1_Fname, string Sub_Profile1_Lname, string Sub_Profile1_DOB, string Sub_Profile1_Nationality, string Sub_Profile1_Country, string Profile_ID, string Sub_Profile1_Age)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Sub_Profile1 values(@Sub_Profile1_ID,@Sub_Profile1_Title ,	@Sub_Profile1_Fname ,	@Sub_Profile1_Lname ,	convert(datetime,@Sub_Profile1_DOB,105) ,	@Sub_Profile1_Nationality ,	@Sub_Profile1_Country,	@Profile_ID,@Sub_Profile1_Age)", cs1);
                da.InsertCommand.Parameters.Add("@Sub_Profile1_ID", SqlDbType.VarChar).Value = Sub_Profile1_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Title", SqlDbType.VarChar).Value = Sub_Profile1_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Fname", SqlDbType.VarChar).Value = Sub_Profile1_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Lname", SqlDbType.VarChar).Value = Sub_Profile1_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_DOB", SqlDbType.VarChar).Value = Sub_Profile1_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Nationality", SqlDbType.VarChar).Value = Sub_Profile1_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Country", SqlDbType.VarChar).Value = Sub_Profile1_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile1_Age", SqlDbType.VarChar).Value = Sub_Profile1_Age;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile1 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile1 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    //public static String GetSubProfile2ID(string off)
    //{
    //    string SubProfile2ID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile2_ID  ,8,len(Sub_Profile2_ID)))from Sub_Profile2  where Sub_Profile2_ID like 'SP2_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Sub_Profile2_ID  ,8,len(Sub_Profile2_ID)))from Sub_Profile2  where Sub_Profile2_ID like 'SP2_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    SubProfile2ID = "SP2_" + startvalue + id;
    //                }
    //            }

    //        }
    //    }

    //    return SubProfile2ID;
    //}

    public static String GetSubProfile2ID(string off)
    {
        string SubProfile2ID = null;
        string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP2";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile2ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile2ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }
            else
            {
                startvalue = "IVO";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile2ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select SubProfile2_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    SubProfile2ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile2_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }

        }

        return SubProfile2ID;
    }
    public static int InsertSub_Profile2(string Sub_Profile2_ID, string Sub_Profile2_Title, string Sub_Profile2_Fname, string Sub_Profile2_Lname, string Sub_Profile2_DOB, string Sub_Profile2_Nationality, string Sub_Profile2_Country, string Profile_ID, string Sub_Profile2_Age)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Sub_Profile2 values(@Sub_Profile2_ID,@Sub_Profile2_Title ,	@Sub_Profile2_Fname ,	@Sub_Profile2_Lname ,	convert(datetime,@Sub_Profile2_DOB,105) ,	@Sub_Profile2_Nationality ,	@Sub_Profile2_Country,	@Profile_ID,@Sub_Profile2_Age)", cs2);
                da.InsertCommand.Parameters.Add("@Sub_Profile2_ID", SqlDbType.VarChar).Value = Sub_Profile2_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Title", SqlDbType.VarChar).Value = Sub_Profile2_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Fname", SqlDbType.VarChar).Value = Sub_Profile2_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Lname", SqlDbType.VarChar).Value = Sub_Profile2_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_DOB", SqlDbType.VarChar).Value = Sub_Profile2_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Nationality", SqlDbType.VarChar).Value = Sub_Profile2_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Country", SqlDbType.VarChar).Value = Sub_Profile2_Country;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile2_Age", SqlDbType.VarChar).Value = Sub_Profile2_Age;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile2 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile2 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }
    //public static String GetPhoneID(string off)
    //{
    //    string PhoneID = null;
    //    string startvalue = "";
    //    int id = 0;

    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Phone_ID,7,len(Phone_ID)))from Phone where Phone_ID like 'PH_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Phone_ID,7,len(Phone_ID)))from Phone where Phone_ID like 'PH_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    PhoneID = "PH_" + startvalue + id;
    //                }
    //            }

    //        }

    //    }

    //    return PhoneID;
    //}


    public static int InsertSub_Profile3(string Sub_Profile3_ID, string Sub_Profile3_Title, string Sub_Profile3_Fname, string Sub_Profile3_Lname, string Sub_Profile3_DOB, string Sub_Profile3_Nationality, string Sub_Profile3_Country, string Profile_ID, string Sub_Profile3_Age)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Sub_Profile3 values(@Sub_Profile3_ID,@Sub_Profile3_Title ,	@Sub_Profile3_Fname ,	@Sub_Profile3_Lname ,	convert(datetime,@Sub_Profile3_DOB,105) ,	@Sub_Profile3_Nationality ,	@Sub_Profile3_Country,@Sub_Profile3_Age,@Profile_ID)", cs2);
                da.InsertCommand.Parameters.Add("@Sub_Profile3_ID", SqlDbType.VarChar).Value = Sub_Profile3_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Title", SqlDbType.VarChar).Value = Sub_Profile3_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Fname", SqlDbType.VarChar).Value = Sub_Profile3_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Lname", SqlDbType.VarChar).Value = Sub_Profile3_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_DOB", SqlDbType.VarChar).Value = Sub_Profile3_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Nationality", SqlDbType.VarChar).Value = Sub_Profile3_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Country", SqlDbType.VarChar).Value = Sub_Profile3_Country;
                da.InsertCommand.Parameters.Add("@Sub_Profile3_Age", SqlDbType.VarChar).Value = Sub_Profile3_Age;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile2 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile3 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static int InsertSub_Profile4(string Sub_Profile4_ID, string Sub_Profile4_Title, string Sub_Profile4_Fname, string Sub_Profile4_Lname, string Sub_Profile4_DOB, string Sub_Profile4_Nationality, string Sub_Profile4_Country, string Profile_ID, string Sub_Profile4_Age)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Sub_Profile4 values(@Sub_Profile4_ID,@Sub_Profile4_Title ,	@Sub_Profile4_Fname ,	@Sub_Profile4_Lname ,	convert(datetime,@Sub_Profile4_DOB,105) ,	@Sub_Profile4_Nationality ,	@Sub_Profile4_Country,@Sub_Profile4_Age,@Profile_ID)", cs2);
                da.InsertCommand.Parameters.Add("@Sub_Profile4_ID", SqlDbType.VarChar).Value = Sub_Profile4_ID;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Title", SqlDbType.VarChar).Value = Sub_Profile4_Title;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Fname", SqlDbType.VarChar).Value = Sub_Profile4_Fname;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Lname", SqlDbType.VarChar).Value = Sub_Profile4_Lname;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_DOB", SqlDbType.VarChar).Value = Sub_Profile4_DOB;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Nationality", SqlDbType.VarChar).Value = Sub_Profile4_Nationality;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Country", SqlDbType.VarChar).Value = Sub_Profile4_Country;
                da.InsertCommand.Parameters.Add("@Sub_Profile4_Age", SqlDbType.VarChar).Value = Sub_Profile4_Age;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Sub Profile2 Query " + ex.Message);

                string msg = "Error in Insert Sub Profile4 Query   " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static String GetPhoneID(string off)
    {
        string PhoneID = null;
        string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "PH";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PhoneID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PhoneID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }
            else
            {
                startvalue = "IVO";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PhoneID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Phone_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    PhoneID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Phone_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }

        }

        return PhoneID;
    }




    public static int InsertPhone(string Phone_ID, string Profile_ID, string Primary_CC, string Primary_Mobile, string Primary_Alt_CC, string Primary_Alternate, string Secondary_CC, string Secondary_Mobile, string Secondary_Alt_CC, string Secondary_Alternate, string Subprofile1_CC, string Subprofile1_Mobile, string Subprofile1_Alt_CC, string Subprofile1_Alternate, string Subprofile2_CC, string Subprofile2_Mobile, string Subprofile2_Alt_CC, string Subprofile2_Alternate, string Subprofile3_CC, string Subprofile3_Mobile, string Subprofile4_CC, string Subprofile4_Mobile, string Subprofile3_Alt_CC, string Subprofile3_Alternate, string Subprofile4_Alt_CC, string Subprofile4_Alternate,string Primary_office_cc, string Primary_office_num, string Secondary_office_cc, string Secondary_office_num)
    {
        int rowsAffected = 0;
        SqlDataAdapter da1 = new SqlDataAdapter();


        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da1.InsertCommand = new SqlCommand("insert into Phone values(@Phone_ID,@Profile_ID,@Primary_CC,@Primary_Mobile,@Primary_Alt_CC,@Primary_Alternate,@Secondary_CC, @Secondary_Mobile,@Secondary_Alt_CC,@Secondary_Alternate,@Subprofile1_CC,@Subprofile1_Mobile,@Subprofile1_Alt_CC,@Subprofile1_Alternate,@Subprofile2_CC,@Subprofile2_Mobile,@Subprofile2_Alt_CC,@Subprofile2_Alternate,@Subprofile3_CC,@Subprofile3_Mobile,@Subprofile4_CC,@Subprofile4_Mobile,@Subprofile3_Alt_CC,@Subprofile3_Alternate,@Subprofile4_Alt_CC,@Subprofile4_Alternate,@Primary_office_cc,@Primary_office_num,@Secondary_office_cc,@Secondary_office_num)", cs1);
                da1.InsertCommand.Parameters.Add("@Phone_ID", SqlDbType.VarChar).Value = Phone_ID;
                da1.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da1.InsertCommand.Parameters.Add("@Primary_CC", SqlDbType.VarChar).Value = Primary_CC;
                da1.InsertCommand.Parameters.Add("@Primary_Mobile", SqlDbType.VarChar).Value = Primary_Mobile;
                da1.InsertCommand.Parameters.Add("@Primary_Alt_CC", SqlDbType.VarChar).Value = Primary_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Primary_Alternate", SqlDbType.VarChar).Value = Primary_Alternate;
                da1.InsertCommand.Parameters.Add("@Secondary_CC", SqlDbType.VarChar).Value = Secondary_CC;
                da1.InsertCommand.Parameters.Add("@Secondary_Mobile", SqlDbType.VarChar).Value = Secondary_Mobile;
                da1.InsertCommand.Parameters.Add("@Secondary_Alt_CC", SqlDbType.VarChar).Value = Secondary_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Secondary_Alternate", SqlDbType.VarChar).Value = Secondary_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile1_CC", SqlDbType.VarChar).Value = Subprofile1_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile1_Mobile", SqlDbType.VarChar).Value = Subprofile1_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile1_Alt_CC", SqlDbType.VarChar).Value = Subprofile1_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile1_Alternate", SqlDbType.VarChar).Value = Subprofile1_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile2_CC", SqlDbType.VarChar).Value = Subprofile2_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile2_Mobile", SqlDbType.VarChar).Value = Subprofile2_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile2_Alt_CC", SqlDbType.VarChar).Value = Subprofile2_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile2_Alternate", SqlDbType.VarChar).Value = Subprofile2_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile3_CC", SqlDbType.VarChar).Value = Subprofile3_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile3_Mobile", SqlDbType.VarChar).Value = Subprofile3_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile4_CC", SqlDbType.VarChar).Value = Subprofile4_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile4_Mobile", SqlDbType.VarChar).Value = Subprofile4_Mobile;
                da1.InsertCommand.Parameters.Add("@Subprofile3_Alt_CC", SqlDbType.VarChar).Value = Subprofile3_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile3_Alternate", SqlDbType.VarChar).Value = Subprofile3_Alternate;
                da1.InsertCommand.Parameters.Add("@Subprofile4_Alt_CC", SqlDbType.VarChar).Value = Subprofile4_Alt_CC;
                da1.InsertCommand.Parameters.Add("@Subprofile4_Alternate", SqlDbType.VarChar).Value = Subprofile4_Alternate;
                da1.InsertCommand.Parameters.Add("@Primary_office_cc", SqlDbType.VarChar).Value = Primary_office_cc;
                da1.InsertCommand.Parameters.Add("@Primary_office_num", SqlDbType.VarChar).Value = Primary_office_num;
                da1.InsertCommand.Parameters.Add("@Secondary_office_cc", SqlDbType.VarChar).Value = Secondary_office_cc;
                da1.InsertCommand.Parameters.Add("@Secondary_office_num", SqlDbType.VarChar).Value = Secondary_office_num;
                rowsAffected = da1.InsertCommand.ExecuteNonQuery();

                //, string , string , string 
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in Insert Phone Query " + ex.Message);
                string msg = "Error in Insert Phone Query   " + " " + ex.Message;

                throw new Exception(msg, ex);
                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }


        return (rowsAffected);
    }
    //public static String GetEmailID(string off)
    //{
    //    string EmailID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Email_ID ,7,len(Email_ID )))from Email where Email_ID like 'EM_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Email_ID ,7,len(Email_ID )))from Email where Email_ID like 'EM_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    EmailID = "EM_" + startvalue + id;
    //                }
    //            }
    //        }

    //    }

    //    return EmailID;
    //}
    public static String GetEmailID(string off)
    {
        string EmailID = null;
        string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "EM";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    EmailID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    EmailID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }
            else
            {
                startvalue = "IVO";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    EmailID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Email_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    EmailID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Email_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }

        }


        return EmailID;
    }
    public static int InsertEmail(string Email_ID, string Profile_ID, string Primary_Email, string Secondary_Email, string Subprofile1_Email, string Subprofile2_Email)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Email values(@Email_ID,@Profile_ID,@Primary_Email,@Secondary_Email,@Subprofile1_Email,@Subprofile2_Email)", cs2);
                da.InsertCommand.Parameters.Add("@Email_ID ", SqlDbType.VarChar).Value = Email_ID;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Primary_Email ", SqlDbType.VarChar).Value = Primary_Email;
                da.InsertCommand.Parameters.Add("@Secondary_Email ", SqlDbType.VarChar).Value = Secondary_Email;
                da.InsertCommand.Parameters.Add("@Subprofile1_Email ", SqlDbType.VarChar).Value = Subprofile1_Email;
                da.InsertCommand.Parameters.Add("@Subprofile2_Email ", SqlDbType.VarChar).Value = Subprofile2_Email;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Email Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }

    //public static String GetStayDetailsID(string off)
    //{
    //    string Profile_Stay_ID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Stay_ID ,7,len(Profile_Stay_ID)))from Profile_Stay where Profile_Stay_ID like 'SD_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else

    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Profile_Stay_ID  ,7,len(Profile_Stay_ID)))from Profile_Stay where Profile_Stay_ID like 'SD_IVO%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    Profile_Stay_ID = "SD_" + startvalue + id;
    //                }
    //            }
    //        }
    //    }

    //    return Profile_Stay_ID;
    //}
    public static String GetStayDetailsID(string off)
    {
        string Profile_Stay_ID = null;
        string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SD";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    Profile_Stay_ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    Profile_Stay_ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }
            else
            {
                startvalue = "IVO";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    Profile_Stay_ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Profile_Stay_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    Profile_Stay_ID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Profile_Stay_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }

        }

        return Profile_Stay_ID;
    }
    public static int InsertProfileStay(string Profile_Stay_ID, string Profile_Stay_Resort_Name, string Profile_Stay_Resort_Room_Number, string Profile_Stay_Arrival_Date, string Profile_Stay_Departure_Date, string Profile_ID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Profile_Stay values(@Profile_Stay_ID ,	@Profile_Stay_Resort_Name ,	@Profile_Stay_Resort_Room_Number ,	convert(datetime,@Profile_Stay_Arrival_Date,105) ,	convert(datetime,@Profile_Stay_Departure_Date,105) ,	@Profile_ID)", cs2);
                da.InsertCommand.Parameters.Add("@Profile_Stay_ID ", SqlDbType.VarChar).Value = Profile_Stay_ID;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Resort_Name ", SqlDbType.VarChar).Value = Profile_Stay_Resort_Name;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Resort_Room_Number ", SqlDbType.VarChar).Value = Profile_Stay_Resort_Room_Number;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Arrival_Date ", SqlDbType.VarChar).Value = Profile_Stay_Arrival_Date;
                da.InsertCommand.Parameters.Add("@Profile_Stay_Departure_Date ", SqlDbType.VarChar).Value = Profile_Stay_Departure_Date;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Profile Stay Query " + ex.Message);

                string msg = "Error in Insert Profile Stay Query  " + " " + ex.Message;

                throw new Exception(msg, ex);

                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }

    //public static String GetTourDetailsID(string off)
    //{
    //    string TourID = null;
    //    string startvalue = "";
    //    int id = 0;
    //    //if (off == "INDIA")
    //    //{
    //    //    startvalue = "HMC";
    //    //}
    //    //else //if (off == "BALI")
    //    //{
    //    //    startvalue = "IVO";
    //    //}
    //    using (SqlConnection cs2 = Queries.GetDBConnection())
    //    {
    //        if (off == "INDIA" || off == "India")
    //        {
    //            startvalue = "HMC";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Tour_Details_ID,7,len(Tour_Details_ID )))from Tour_Details where Tour_Details_ID like 'TD_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            startvalue = "IVO";
    //            SqlCommand scd = new SqlCommand("select max(SUBSTRING(Tour_Details_ID,7,len(Tour_Details_ID )))from Tour_Details where Tour_Details_ID like 'TD_HMC%'", cs2);
    //            scd.Parameters.Add("@off", SqlDbType.VarChar).Value = off;
    //            SqlDataReader dr = scd.ExecuteReader();
    //            if (dr.Read() == true)
    //            {
    //                string len = string.Format("{0}", dr[0]);


    //                if (len.Length != 0)
    //                {
    //                    id = Convert.ToInt32(len);
    //                    id = id + 2;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //                else
    //                {
    //                    id = 1;
    //                    TourID = "TD_" + startvalue + id;
    //                }
    //            }
    //        }
    //    }

    //    return TourID;
    //}
    public static String GetTourDetailsID(string off)
    {
        string TourID = null;
        string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "TD";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if (off == "INDIA" || off == "India")
            {
                startvalue = "HMC";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    TourID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    TourID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }
            else
            {
                startvalue = "IVO";

                //check if entry exists
                SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
                scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int cnt = (int)scd.ExecuteScalar();
                if (cnt == 1)
                {
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    TourID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();
                }
                else if (cnt == 0)
                {
                    //insert into idgeneration
                    int insert = Queries.InsertIDGeneration(startvalue, year);
                    //get last code of profile n increment by 1
                    //get last code of profile n increment by 1
                    SqlCommand scd1 = new SqlCommand("select Tour_Details_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                    scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    string val = (string)scd1.ExecuteScalar();
                    id = Convert.ToInt32(val) + 1;
                    TourID = initial + startvalue + year + id;
                    //chek = id + 1;
                    SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET Tour_Details_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                    sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                    sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    int rows = sqlcmd.ExecuteNonQuery();

                }
            }

        }


        return TourID;
    }

    public static int InsertTourDetails(string Tour_Details_ID, string Tour_Details_Guest_Status, string Tour_Details_Guest_Sales_Rep, string Tour_Details_Tour_Date, string Tour_Details_Sales_Deck_Check_In, string Tour_Details_Sales_Deck_Check_Out, string Tour_Details_Taxi_In_Price, string Tour_Details_Taxi_In_Ref, string Tour_Details_Taxi_Out_Price, string Tour_Details_Taxi_Out_Ref, string Profile_ID, string Tour_Details_Qualified_Status,int Week_number)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Tour_Details values(@Tour_Details_ID,@Tour_Details_Guest_Status,@Tour_Details_Guest_Sales_Rep,convert(datetime,@Tour_Details_Tour_Date,105),@Tour_Details_Sales_Deck_Check_In,	@Tour_Details_Sales_Deck_Check_Out,@Tour_Details_Taxi_In_Price,@Tour_Details_Taxi_In_Ref ,@Tour_Details_Taxi_Out_Price ,@Tour_Details_Taxi_Out_Ref,@Profile_ID,@Tour_Details_Qualified_Status,@Week_number)", cs2);
                da.InsertCommand.Parameters.Add("@Tour_Details_ID ", SqlDbType.VarChar).Value = Tour_Details_ID;
                da.InsertCommand.Parameters.Add("@Tour_Details_Guest_Status ", SqlDbType.VarChar).Value = Tour_Details_Guest_Status;
                da.InsertCommand.Parameters.Add("@Tour_Details_Guest_Sales_Rep ", SqlDbType.VarChar).Value = Tour_Details_Guest_Sales_Rep;
                da.InsertCommand.Parameters.Add("@Tour_Details_Tour_Date ", SqlDbType.VarChar).Value = Tour_Details_Tour_Date;
                da.InsertCommand.Parameters.Add("@Tour_Details_Sales_Deck_Check_In ", SqlDbType.VarChar).Value = Tour_Details_Sales_Deck_Check_In;
                da.InsertCommand.Parameters.Add("@Tour_Details_Sales_Deck_Check_Out ", SqlDbType.VarChar).Value = Tour_Details_Sales_Deck_Check_Out;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_In_Price ", SqlDbType.VarChar).Value = Tour_Details_Taxi_In_Price;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_In_Ref ", SqlDbType.VarChar).Value = Tour_Details_Taxi_In_Ref;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_Out_Price ", SqlDbType.VarChar).Value = Tour_Details_Taxi_Out_Price;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_Out_Ref ", SqlDbType.VarChar).Value = Tour_Details_Taxi_Out_Ref;
                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Tour_Details_Qualified_Status ", SqlDbType.VarChar).Value = Tour_Details_Qualified_Status;
                da.InsertCommand.Parameters.Add("@Week_number ", SqlDbType.Int).Value = Week_number;
                
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Tour Details Query " + ex.Message);

                string msg = "Error in Insert Tour Details Query" + " "+ Tour_Details_ID + " " + Tour_Details_Guest_Status + " " + Tour_Details_Guest_Sales_Rep + " " + Tour_Details_Tour_Date + " " + Tour_Details_Sales_Deck_Check_In + " " + Tour_Details_Sales_Deck_Check_Out + " " + Tour_Details_Taxi_In_Price + " " + Tour_Details_Taxi_In_Ref + " " + Tour_Details_Taxi_Out_Price + " " + Tour_Details_Taxi_Out_Ref + " " + Profile_ID + " " + Tour_Details_Qualified_Status + " " + Week_number + " " + ex.Message;

                throw new Exception("transction: " + msg, ex);


            }
        }
        return (rowsAffected);
    }

    public static String GetCountryCodeValue(string name, string code)
    {
        string val = "";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            
            //  SqlCommand scd = new SqlCommand(" select country_id from country where country_name =@name and country_code =@code", cs1);
            SqlCommand scd = new SqlCommand(" select country_code from country where country_name =@name and country_code =@code", cs1);
            scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            scd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
            val = (string)scd.ExecuteScalar();
        }
        return val;
    }
    public static void ProfileView(string ID)
    {
        System.Web.HttpContext.Current.Response.Write("<script>window.open('Profile_View.aspx?value=" + ID + " ', 'newwindow','location=no,menubar=no,width=800,height=1000,resizable=yes,scrollbars=yes,top=250,left=200')</script>");

    }

   /* public static DataSet LoadProfileOnCreation(string profileid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select p.Profile_ID,CONVERT(CHAR(10), p.Profile_Date_Of_Insertion, 120) as Profile_Date_Of_Insertion,p.Profile_Created_By,p.Profile_Venue_Country,p.Profile_Venue,p.Profile_Group_Venue,p.Profile_Marketing_Program,p.Profile_Agent,p.Profile_Agent_Code,p.Profile_Member_Type1,p.Profile_Member_Number1,p.Profile_Member_Type2,p.Profile_Member_Number2,p.Profile_Employment_status,p.Profile_Marital_status,p.Profile_NOY_Living_as_couple,p.Office,p.Comments,pp.Profile_Primary_Title, pp.Profile_Primary_Fname, pp.Profile_Primary_Lname, pp.Profile_Primary_DOB, pp.Profile_Primary_Nationality, pp.Profile_Primary_Country, pa.Profile_Address_city, pa.Profile_Address_State, ph.Primary_Mobile, em.Primary_Email, s.Profile_Stay_Resort_Name, CONVERT(date, s.Profile_Stay_Arrival_Date)arrivaldate, CONVERT(date, s.Profile_Stay_Departure_Date) DepartureDate, ps.Profile_Secondary_Title, ps.Profile_Secondary_Fname, ps.Profile_Secondary_Lname, ps.Profile_Secondary_Nationality from Profile p left outer join Profile_Primary pp on pp.Profile_ID = p.Profile_ID left outer join Profile_Secondary ps on ps.Profile_ID = pp.Profile_ID  left outer join Phone ph on ph.Profile_ID = p.Profile_ID left outer join Email em on em.Profile_ID = p.Profile_ID left outer join Profile_Address pa on pa.Profile_ID = p.Profile_ID left outer join Profile_Stay s on s.Profile_ID = p.Profile_ID  where p.Profile_ID =@profileid", cs1);
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }*/


    public static DataSet LoadProfileOnCreation(string profileid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from Profile p left join Profile_Primary pp on pp.Profile_ID = p.Profile_ID left join Profile_Secondary ps on ps.Profile_ID = p.Profile_ID   left join Sub_Profile1 sp1 on sp1.Profile_ID = p.Profile_ID   left join Sub_Profile2 sp2 on sp2.Profile_ID = p.Profile_ID   left join Sub_Profile3 sp3 on sp3.Profile_ID = p.Profile_ID   left join Sub_Profile4 sp4 on sp4.Profile_ID = p.Profile_ID    left join Phone ph on ph.Profile_ID = p.Profile_ID     left join Email e on e.Profile_ID = p.Profile_ID     left join Profile_Address pa on pa.Profile_ID = p.Profile_ID     left join Profile_Stay s on s.Profile_ID = p.Profile_ID     left join Gift g on g.Profile_ID = p.Profile_ID     left join Tour_Details td on td.Profile_ID =p.Profile_ID where p.Profile_ID =@profileid", cs1);
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static int ProfileExists(string profile)
    {
        int c = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand scd = new SqlCommand(" select Profile_ID  from Profile  where Profile_ID =@profile", cs1);
            scd.Parameters.Add("@profile", SqlDbType.VarChar).Value = profile;
            SqlDataReader dr = scd.ExecuteReader();
            if (dr.Read() == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
        }
        return c;

    }

    //public static int InsertProfileOtherDetails()
    //{
    //    int rowsaffected = 0;
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    da.InsertCommand 
    //}
    public static DataSet LoadEntitlement()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Entitlement_Name  from Entitlement where Entitlement_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadSearchProfile(string profileid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Profile_ID,Profile_Primary_ID,Profile_Primary_Title,Profile_Primary_Fname,Profile_Primary_Lname from Profile_Primary where Profile_ID=@profileid", cs1);
            SqlCmd.Parameters.Add("@profileid", SqlDbType.VarChar).Value = profileid;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);

        }
        return (ds);
    }

    //public static DataSet LoadPayMethod(string office)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        SqlCommand SqlCmd = new SqlCommand("select pay_method_name from pay_method where office = @office", cs1);
    //        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;

    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}


    public static DataSet LoadPayMethod()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct pay_method_name from pay_method", cs1);
            //SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadSalesReps(string venuecountry,string venue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            if (venue != "Flybuys")
            {
                SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID=@venuecountry and venue= @venue", cs1);//("select * from Sales_Rep where Venue_country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuec)", cs1);
                SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            else
            {
                SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID=@venuecountry", cs1);//("select * from Sales_Rep where Venue_country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuec)", cs1);
                SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);

            }
        }
        return (ds);
    }


    //public static DataSet LoadSalesReps(string office,string venue)
    //{
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        //SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID=@venuecountry", cs1);//("select * from Sales_Rep where Venue_country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuec)", cs1);
    //        SqlCommand SqlCmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where office=@office and Venue=@venue and Sales_Rep_Status='Active'", cs1);
    //        SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
    //        SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
    //        da = new SqlDataAdapter(SqlCmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //    }
    //    return (ds);
    //}


    public static DataSet LoadVenueCountry1(string ProfileID,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand SqlCmd = new SqlCommand("select distinct Venue_Country_Name from VenueCountry where Venue_Country_Name not in(select Profile_Venue_Country  from Profile where Profile_ID=@ProfileID) and venue_country_office = '"+office+"'", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadVenue1(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Venue_Name  from Venue where Venue_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadFinanceCurrency()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Finance_Currency_Name from Finance_Currency where Finance_Currency_Status='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadDepositPayMethod(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Deposit_pay_method_name from Deposit_Pay_Method where Deposit_pay_method_status = 'Active' and office= @office order by 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static DataSet LoadDealDrawer()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Deal_Drawer_Name from Deal_Drawer where Deal_Drawer_Status ='Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadContractClub(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Contract_Club_Name from Contract_Club where Contract_Club_Status ='Active' and office=@office order by 1", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadTOManager(string office,string venue,string venuecountry)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            if (venue != "Flybuys")
            {
                SqlCommand SqlCmd = new SqlCommand("select TO_Manager_name from TO_manager where office=@office and venue=@venue and TO_Manager_Status ='Active' and VenueCountry_ID=@venuecountry order by 1", cs1);
                SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            else
            {
                SqlCommand SqlCmd = new SqlCommand("select TO_Manager_name from TO_manager where office=@office  and TO_Manager_Status ='Active' and VenueCountry_ID=@venuecountry order by 1", cs1);
                SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                //SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);

            }
        }
        return (ds);

    }

    public static DataSet LoadButtonUp(string office, string venue, string venuecountry)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            if (venue == "Coldline")
            {

                SqlCommand SqlCmd = new SqlCommand("select ButtonUp_Name from Buttonup where office=@office and venue = @venue and ButtonUp_status ='Active' and VenueCountry_ID=@venuecountry order by 1", cs1);
                SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            else
            {
                SqlCommand SqlCmd = new SqlCommand("select ButtonUp_Name from Buttonup where office=@office  and ButtonUp_status ='Active' and VenueCountry_ID=@venuecountry order by 1", cs1);
                SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                //SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);

            }
        }
        return (ds);

    }

    public static DataSet LoadPrintFiles(string conttype,string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select LTRIM(RTRIM(p.Printpdf_name)) as Printpdf_name  from ContractType a,printpdf p where a.contracttype_id = p.contracttype_id and a.ContractType_name = @ContractType_name and p.Printpdf_office=@Printpdf_office and Printpdf_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@ContractType_name", SqlDbType.VarChar).Value = conttype;
            SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadFractionalI()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Contract_Fractional_Int_Name from Contract_Fractional_Int where Contract_Fractional_Int_Status = 'Active' order by 1", cs1);
            //SqlCmd.Parameters.Add("@ContractType_name", SqlDbType.VarChar).Value = conttype;
            //SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static DataSet LoadContPeriod()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Period_Name from Cont_Period where Period_Status='Active' order by Period_ID", cs1);
            //SqlCmd.Parameters.Add("@ContractType_name", SqlDbType.VarChar).Value = conttype;
            //SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static DataSet LoadContNumbOccu()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Numb_Occu_Numb from Cont_Numb_Occu where Numb_Occu_Status='Active' order by Numb_Occu_ID", cs1);
            //SqlCmd.Parameters.Add("@ContractType_name", SqlDbType.VarChar).Value = conttype;
            //SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static DataSet LoadApartType()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Apart_Type_Name from Cont_Apart_Type where Apart_Type_Status='Active' order by Apart_Type_ID", cs1);
            //SqlCmd.Parameters.Add("@ContractType_name", SqlDbType.VarChar).Value = conttype;
            //SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static DataSet LoadCCardType()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Card_Type_Name from Card_Type where Card_Type_Status='Active' order by 1", cs1);
            //SqlCmd.Parameters.Add("@ContractType_name", SqlDbType.VarChar).Value = conttype;
            //SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static DataSet LoadContType(string conttype)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Contract_Type_Name from contract_type where contract_type_contract_type = @conttype and Contract_Type_Status ='Active' order by 1", cs1);
            SqlCmd.Parameters.Add("@conttype", SqlDbType.VarChar).Value = conttype;
            //SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static DataSet LoadContResort()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Contract_Resort_Name from Contract_Resort where Contract_Resort_Status='Active' order by 1", cs1);
            //SqlCmd.Parameters.Add("@conttype", SqlDbType.VarChar).Value = conttype;
            //SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static DataSet LoadFracResort()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Fract_Resort_Name from Fract_Resorts where Fract_Resort_Status='Active' order by 1", cs1);
            //SqlCmd.Parameters.Add("@conttype", SqlDbType.VarChar).Value = conttype;
            //SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }

    public static DataSet LoadSeasType()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Season_Name from Seasons where Season_Status = 'Active' order by 1", cs1);
            //SqlCmd.Parameters.Add("@conttype", SqlDbType.VarChar).Value = conttype;
            //SqlCmd.Parameters.Add("@Printpdf_office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }



    public static string getMarketingProgram(string MarketingP, string venueg)
    {
        string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name=@Marketing_Program_Name and Venue_Group_ID =@Venue_Group_ID", cs1);
            SqlCmd.Parameters.Add("@Marketing_Program_Name", SqlDbType.VarChar).Value = MarketingP;
            SqlCmd.Parameters.Add("@Venue_Group_ID", SqlDbType.VarChar).Value = venueg;
                    
            string val = (string)SqlCmd.ExecuteScalar();
            office = val;
        }
        return office;


    }



    public static string getoffice(string ProfileID)
    {
        string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Office from Profile where Profile_ID=@ProfileID", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            //da = new SqlDataAdapter(SqlCmd);
            //ds = new DataSet();
            //da.Fill(ds);
            //office = ds;
            string val = (string)SqlCmd.ExecuteScalar();
            office = val;
        }
        return office;

        
    }

    public static string getContractID(string midval)
    {

        string startval;
      
        int id = 0;
        
        string contnumbid = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        { 

                SqlCommand scmd = new SqlCommand("select contcat from Cont_ID_Gen where contoffice=@midval", cs1);                
                scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
                startval = (string)scmd.ExecuteScalar();
                
                 SqlCommand scmd1 = new SqlCommand("select contval  from Cont_ID_Gen where contoffice=@midval", cs1);
                  scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
                 int  val = (int)scmd1.ExecuteScalar();
            
                id = Convert.ToInt32(val) + 1;

                contnumbid = startval + midval + id;
                 
                ////PProfileID = initial + startvalue + year + id;
                ////chek = id + 1;
                //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
                //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
                // int rows = sqlcmd.ExecuteNonQuery();
        }

        return contnumbid;


    }


    public static string getContFracID(string midval)
    {

        string startval;

        int id = 0;

        string contnumbid = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select Cont_fract_cat from Cont_Fract_ID where cont_fract_office =@midval", cs1);
            scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            startval = (string)scmd.ExecuteScalar();

            SqlCommand scmd1 = new SqlCommand("select Cont_fract_val from Cont_Fract_ID where cont_fract_office =@midval", cs1);
            scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            contnumbid = startval + midval + id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return contnumbid;


    }

    public static string getContTPID(string midval)
    {

        string startval;

        int id = 0;

        string contnumbid = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select Cont_TP_cat from Cont_TP_ID where Cont_TP_Office =@midval", cs1);
            scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            startval = (string)scmd.ExecuteScalar();

            SqlCommand scmd1 = new SqlCommand("select Cont_TP_val from Cont_TP_ID where Cont_TP_Office =@midval", cs1);
            scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            contnumbid = startval + midval + id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return contnumbid;


    }


    public static string getContTFID(string midval)
    {

        string startval;

        int id = 0;

        string contnumbid = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select Cont_TF_Cat from Cont_TF_ID where Cont_TF_Office =@midval", cs1);
            scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            startval = (string)scmd.ExecuteScalar();

            SqlCommand scmd1 = new SqlCommand("select Cont_TF_Val from Cont_TF_ID where Cont_TF_Office =@midval", cs1);
            scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            contnumbid = startval + midval + id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return contnumbid;


    }


    public static string getContractFinanceID(string midval)
    {

        string startval;

        int id = 0;

        string contfinaid = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select Cont_Fina_cat from Cont_Fina_ID_Gen where Cont_Fina_office=@midval", cs1);
            scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            startval = (string)scmd.ExecuteScalar();

            SqlCommand scmd1 = new SqlCommand("select Cont_Fina_val  from Cont_Fina_ID_Gen where Cont_Fina_office=@midval", cs1);
            scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            contfinaid = startval + midval + id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return contfinaid;


    }

    public static string getContractPASAID(string midval)
    {

        string startval;

        int id = 0;

        string contPASAid = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select Cont_PASA_cat from Cont_PASA_ID_Gen where Cont_PASA_office=@midval", cs1);
            scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            startval = (string)scmd.ExecuteScalar();

            SqlCommand scmd1 = new SqlCommand("select Cont_PASA_val  from Cont_PASA_ID_Gen where Cont_PASA_office=@midval", cs1);
            scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            contPASAid = startval + midval + id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return contPASAid;


    }


    public static string getPaymentDetailsID(string midval)
    {

        string startval;

        int id = 0;

        string PayDetailsid = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select Pment_Details_Cat from Payment_Details_ID where Pment_Details_Office=@midval", cs1);
            scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            startval = (string)scmd.ExecuteScalar();

            SqlCommand scmd1 = new SqlCommand("select Pment_Details_Val from Payment_Details_ID where Pment_Details_Office=@midval", cs1);
            scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            PayDetailsid = startval + midval + id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return PayDetailsid;


    }

    public static int InsertContractFinance(string Contract_Finnace_ID, string Contract_Finance_Cont_Numb, string Contract_Finance_Cont_Type, string Contract_Finance_Affil_ICE, string Contract_Finance_Affil_HP, string Contract_Finance_Sales_Rep, string Contract_Finance_TO_Manager, string Contract_Finance_Button_UP, string Contract_Finance_Currency, string Contract_Finance_Purchase_Price, string Contract_Finance_Admin_Fees, string Contract_Finance_MC_Fees, string Contract_Finance_Deal_Drawer, string Contract_Finance_Payment_Method, string Contract_Finance_Finance_Num, string Contract_Finance_BPayment_Method, string Contract_Finance_Pan_Card, string Contract_Finance_Adhar_Card, string Contract_Finance_ID_Card, string Profile_ID, string office, string CrownCurr, string DealRegDate, string Contract_finance_OddEven,string Contract_finance_OddEven50, DateTime Contract_finance_Insert_Date, DateTime Contract_finance_Update_Date,int weekno)
    {
        int rowsAffected = 0;
        int id = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into contract_finance values(@Contract_Finnace_ID,@Contract_Finance_Cont_Numb,@Contract_Finance_Cont_Type,@Contract_Finance_Affil_ICE,@Contract_Finance_Affil_HP,@Contract_Finance_Sales_Rep,@Contract_Finance_TO_Manager,@Contract_Finance_Button_UP,@Contract_Finance_Currency,@Contract_Finance_Purchase_Price,@Contract_Finance_Admin_Fees,@Contract_Finance_MC_Fees,@Contract_Finance_Deal_Drawer,@Contract_Finance_Payment_Method,@Contract_Finance_Finance_Num,@Contract_Finance_BPayment_Method,@Contract_Finance_Pan_Card,@Contract_Finance_Adhar_Card,@Contract_Finance_ID_Card,@Profile_ID,@CrownCurr,@DealRegDate,@Contract_finance_OddEven,@Contract_finance_OddEven50, @Contract_finance_Insert_Date,@Contract_finance_Update_Date,@weekno)", cs1);
                da.InsertCommand.Parameters.Add("@Contract_Finnace_ID", SqlDbType.VarChar).Value = Contract_Finnace_ID;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Cont_Numb", SqlDbType.VarChar).Value = Contract_Finance_Cont_Numb;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Cont_Type", SqlDbType.VarChar).Value = Contract_Finance_Cont_Type;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Affil_ICE", SqlDbType.VarChar).Value = Contract_Finance_Affil_ICE;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Affil_HP", SqlDbType.VarChar).Value = Contract_Finance_Affil_HP;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Sales_Rep", SqlDbType.VarChar).Value = Contract_Finance_Sales_Rep;
                da.InsertCommand.Parameters.Add("@Contract_Finance_TO_Manager", SqlDbType.VarChar).Value = Contract_Finance_TO_Manager;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Button_UP", SqlDbType.VarChar).Value = Contract_Finance_Button_UP;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Currency", SqlDbType.VarChar).Value = Contract_Finance_Currency;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Purchase_Price", SqlDbType.VarChar).Value = Contract_Finance_Purchase_Price;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Admin_Fees", SqlDbType.VarChar).Value = Contract_Finance_Admin_Fees;
                da.InsertCommand.Parameters.Add("@Contract_Finance_MC_Fees", SqlDbType.VarChar).Value = Contract_Finance_MC_Fees;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Deal_Drawer", SqlDbType.VarChar).Value = Contract_Finance_Deal_Drawer;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Payment_Method", SqlDbType.VarChar).Value = Contract_Finance_Payment_Method;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Finance_Num", SqlDbType.VarChar).Value = Contract_Finance_Finance_Num;
                da.InsertCommand.Parameters.Add("@Contract_Finance_BPayment_Method", SqlDbType.VarChar).Value = Contract_Finance_BPayment_Method;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Pan_Card", SqlDbType.VarChar).Value = Contract_Finance_Pan_Card;
                da.InsertCommand.Parameters.Add("@Contract_Finance_Adhar_Card", SqlDbType.VarChar).Value = Contract_Finance_Adhar_Card;
                da.InsertCommand.Parameters.Add("@Contract_Finance_ID_Card", SqlDbType.VarChar).Value = Contract_Finance_ID_Card;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@CrownCurr", SqlDbType.VarChar).Value = CrownCurr;
                da.InsertCommand.Parameters.Add("@DealRegDate", SqlDbType.VarChar).Value = DealRegDate;
                da.InsertCommand.Parameters.Add("@Contract_finance_OddEven", SqlDbType.VarChar).Value = Contract_finance_OddEven;
                da.InsertCommand.Parameters.Add("@Contract_finance_OddEven50", SqlDbType.VarChar).Value = Contract_finance_OddEven50;
                da.InsertCommand.Parameters.Add("@Contract_finance_Insert_Date", SqlDbType.DateTime).Value = Contract_finance_Insert_Date;
                da.InsertCommand.Parameters.Add("@Contract_finance_Update_Date", SqlDbType.DateTime).Value = Contract_finance_Update_Date;
                da.InsertCommand.Parameters.Add("@weekno", SqlDbType.Int).Value = weekno;


                rowsAffected = da.InsertCommand.ExecuteNonQuery();

                SqlCommand scmd1 = new SqlCommand("select Cont_Fina_val  from Cont_Fina_ID_Gen where Cont_Fina_office=@midval", cs1);
                scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;

                SqlCommand scmd2 = new SqlCommand("update Cont_Fina_ID_Gen set Cont_Fina_val ='" + id + "' where Cont_Fina_office=@midval", cs1);
                //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int rows = scmd2.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert contract_finance Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }



    public static int InsertContractPoints(string CT_Points_ID, string CT_Points_Club, string CT_Points_Noof_Points, string CT_Points_Entle, string CT_Points_Member_fees, string CT_Points_Points_Property_fees, string CT_Points_FYear_Occ, string CT_Points_Duration, string CT_Points_LYear_Occ, string Profile_ID, string Contract_Finnace_ID, string office)
    {
        int rowsAffected = 0;
        int id = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into CT_Points values(@CT_Points_ID,	@CT_Points_Club,@CT_Points_Entle,	@CT_Points_Member_fees,	@CT_Points_Points_Property_fees,	@CT_Points_FYear_Occ,	@CT_Points_Duration,	@CT_Points_LYear_Occ,	@Profile_ID,	@Contract_Finnace_ID,@CT_Points_Noof_Points)", cs1);
                da.InsertCommand.Parameters.Add("@CT_Points_ID", SqlDbType.VarChar).Value = CT_Points_ID;
                da.InsertCommand.Parameters.Add("@CT_Points_Club", SqlDbType.VarChar).Value = CT_Points_Club;
                da.InsertCommand.Parameters.Add("@CT_Points_Noof_Points", SqlDbType.VarChar).Value = CT_Points_Noof_Points;
                da.InsertCommand.Parameters.Add("@CT_Points_Entle", SqlDbType.VarChar).Value = CT_Points_Entle;
                da.InsertCommand.Parameters.Add("@CT_Points_Member_fees", SqlDbType.VarChar).Value = CT_Points_Member_fees;
                da.InsertCommand.Parameters.Add("@CT_Points_Points_Property_fees", SqlDbType.VarChar).Value = CT_Points_Points_Property_fees;
                da.InsertCommand.Parameters.Add("@CT_Points_FYear_Occ", SqlDbType.VarChar).Value = CT_Points_FYear_Occ;
                da.InsertCommand.Parameters.Add("@CT_Points_Duration", SqlDbType.VarChar).Value = CT_Points_Duration;
                da.InsertCommand.Parameters.Add("@CT_Points_LYear_Occ", SqlDbType.VarChar).Value = CT_Points_LYear_Occ;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Contract_Finnace_ID", SqlDbType.VarChar).Value = Contract_Finnace_ID;


                rowsAffected = da.InsertCommand.ExecuteNonQuery();

                SqlCommand scmd1 = new SqlCommand("select contval  from Cont_ID_Gen where contoffice=@midval", cs1);
                scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;

                SqlCommand scmd2 = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contoffice=@midval", cs1);
                //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int rows = scmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert CT_Points Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }



    public static int InsertContractTP(string TP_ID, string TP_Cont_Type, string TP_Old_Agree_Numb, string TP_Resort, string TP_Appartment_Type, string TP_Num_Occ, string TP_Period, string TP_Season, string TP_Old_Entitlement, string TP_Old_Club, string TP_Old_No_Points, string TP_New_No_Points, string TP_Total_Points, string TP_New_CLub, string TP_New_Entitlement, string TP_Member_Fees, string TP_Property_Fees, string TP_FY_Occu, string TP_Duration, string TP_LY_Occu, string Profile_ID, string Contract_Finance_ID, string office)
    {
        int rowsAffected = 0;
        int id = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_TP values(@TP_ID,	@TP_Cont_Type,	@TP_Old_Agree_Numb,	@TP_Resort,	@TP_Appartment_Type,	@TP_Num_Occ,	@TP_Period,	@TP_Season,	@TP_Old_Entitlement,	@TP_Old_Club,	@TP_Old_No_Points,	@TP_New_No_Points,	@TP_Total_Points,	@TP_New_CLub,	@TP_New_Entitlement,	@TP_Member_Fees,	@TP_Property_Fees,	@TP_FY_Occu,	@TP_Duration,	@TP_LY_Occu,	@Profile_ID,	@Contract_Finance_ID)", cs1);
                da.InsertCommand.Parameters.Add("@TP_ID", SqlDbType.VarChar).Value = TP_ID;
                da.InsertCommand.Parameters.Add("@TP_Cont_Type", SqlDbType.VarChar).Value = TP_Cont_Type;
                da.InsertCommand.Parameters.Add("@TP_Old_Agree_Numb", SqlDbType.VarChar).Value = TP_Old_Agree_Numb;
                da.InsertCommand.Parameters.Add("@TP_Resort", SqlDbType.VarChar).Value = TP_Resort;
                da.InsertCommand.Parameters.Add("@TP_Appartment_Type", SqlDbType.VarChar).Value = TP_Appartment_Type;
                da.InsertCommand.Parameters.Add("@TP_Num_Occ", SqlDbType.VarChar).Value = TP_Num_Occ;
                da.InsertCommand.Parameters.Add("@TP_Period", SqlDbType.VarChar).Value = TP_Period;
                da.InsertCommand.Parameters.Add("@TP_Season", SqlDbType.VarChar).Value = TP_Season;
                da.InsertCommand.Parameters.Add("@TP_Old_Entitlement", SqlDbType.VarChar).Value = TP_Old_Entitlement;
                da.InsertCommand.Parameters.Add("@TP_Old_Club", SqlDbType.VarChar).Value = TP_Old_Club;
                da.InsertCommand.Parameters.Add("@TP_Old_No_Points", SqlDbType.VarChar).Value = TP_Old_No_Points;
                da.InsertCommand.Parameters.Add("@TP_New_No_Points", SqlDbType.VarChar).Value = TP_New_No_Points;
                da.InsertCommand.Parameters.Add("@TP_Total_Points", SqlDbType.VarChar).Value = TP_Total_Points;
                da.InsertCommand.Parameters.Add("@TP_New_CLub", SqlDbType.VarChar).Value = TP_New_CLub;
                da.InsertCommand.Parameters.Add("@TP_New_Entitlement", SqlDbType.VarChar).Value = TP_New_Entitlement;
                da.InsertCommand.Parameters.Add("@TP_Member_Fees", SqlDbType.VarChar).Value = TP_Member_Fees;
                da.InsertCommand.Parameters.Add("@TP_Property_Fees", SqlDbType.VarChar).Value = TP_Property_Fees;
                da.InsertCommand.Parameters.Add("@TP_FY_Occu", SqlDbType.VarChar).Value = TP_FY_Occu;
                da.InsertCommand.Parameters.Add("@TP_Duration", SqlDbType.VarChar).Value = TP_Duration;
                da.InsertCommand.Parameters.Add("@TP_LY_Occu", SqlDbType.VarChar).Value = TP_LY_Occu;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Contract_Finance_ID", SqlDbType.VarChar).Value = Contract_Finance_ID;



                rowsAffected = da.InsertCommand.ExecuteNonQuery();

                SqlCommand scmd1 = new SqlCommand("select Cont_TP_Val  from Cont_TP_ID where Cont_TP_Office=@midval", cs1);
                scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;

                SqlCommand scmd2 = new SqlCommand("update Cont_TP_ID set Cont_TP_Val ='" + id + "' where Cont_TP_Office=@midval", cs1);
                //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int rows = scmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Contract_TP Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }



    public static int InsertContractTF(string TF_ID, string TF_Old_Cont_Numb, string TF_Old_Club, string TF_Old_NoOf_Points, string TF_Old_Entitle, string TF_Old_Resort, string TF_Old_Apmnt_Type, string TF_Old_No_Occu, string TF_Old_Period, string TF_Old_Season, string TF_Old_Resi_No, string TF_Old_Resi_Type, string TF_Old_Frac_Int, string TF_Resort, string TF_Resi_No, string TF_Resi_Type, string TF_Frac_Int, string TF_Entitle, string TF_First_Occ, string TF_Duration, string TF_Last_Occ, string TF_Leas, string Profile_ID, string Contract_Finance_ID, string office,string conttypeTF)
    {
        int rowsAffected = 0;
        int id = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_TF values(@TF_ID,	@TF_Old_Cont_Numb,	@TF_Old_Club,	@TF_Old_NoOf_Points,	@TF_Old_Entitle,	@TF_Old_Resort,	@TF_Old_Apmnt_Type,	@TF_Old_No_Occu,	@TF_Old_Period,	@TF_Old_Season,	@TF_Old_Resi_No,	@TF_Old_Resi_Type,	@TF_Old_Frac_Int,	@TF_Resort,	@TF_Resi_No,	@TF_Resi_Type,	@TF_Frac_Int,	@TF_Entitle,	@TF_First_Occ,	@TF_Duration,	@TF_Last_Occ,	@TF_Leas,	@Profile_ID,	@Contract_Finance_ID,@conttypeTF)", cs1);
                da.InsertCommand.Parameters.Add("@TF_ID", SqlDbType.VarChar).Value = TF_ID;
                da.InsertCommand.Parameters.Add("@TF_Old_Cont_Numb", SqlDbType.VarChar).Value = TF_Old_Cont_Numb;
                da.InsertCommand.Parameters.Add("@TF_Old_Club", SqlDbType.VarChar).Value = TF_Old_Club;
                da.InsertCommand.Parameters.Add("@TF_Old_NoOf_Points", SqlDbType.VarChar).Value = TF_Old_NoOf_Points;
                da.InsertCommand.Parameters.Add("@TF_Old_Entitle", SqlDbType.VarChar).Value = TF_Old_Entitle;
                da.InsertCommand.Parameters.Add("@TF_Old_Resort", SqlDbType.VarChar).Value = TF_Old_Resort;
                da.InsertCommand.Parameters.Add("@TF_Old_Apmnt_Type", SqlDbType.VarChar).Value = TF_Old_Apmnt_Type;
                da.InsertCommand.Parameters.Add("@TF_Old_No_Occu", SqlDbType.VarChar).Value = TF_Old_No_Occu;
                da.InsertCommand.Parameters.Add("@TF_Old_Period", SqlDbType.VarChar).Value = TF_Old_Period;
                da.InsertCommand.Parameters.Add("@TF_Old_Season", SqlDbType.VarChar).Value = TF_Old_Season;
                da.InsertCommand.Parameters.Add("@TF_Old_Resi_No", SqlDbType.VarChar).Value = TF_Old_Resi_No;
                da.InsertCommand.Parameters.Add("@TF_Old_Resi_Type", SqlDbType.VarChar).Value = TF_Old_Resi_Type;
                da.InsertCommand.Parameters.Add("@TF_Old_Frac_Int", SqlDbType.VarChar).Value = TF_Old_Frac_Int;
                da.InsertCommand.Parameters.Add("@TF_Resort", SqlDbType.VarChar).Value = TF_Resort;
                da.InsertCommand.Parameters.Add("@TF_Resi_No", SqlDbType.VarChar).Value = TF_Resi_No;
                da.InsertCommand.Parameters.Add("@TF_Resi_Type", SqlDbType.VarChar).Value = TF_Resi_Type;
                da.InsertCommand.Parameters.Add("@TF_Frac_Int", SqlDbType.VarChar).Value = TF_Frac_Int;
                da.InsertCommand.Parameters.Add("@TF_Entitle", SqlDbType.VarChar).Value = TF_Entitle;
                da.InsertCommand.Parameters.Add("@TF_First_Occ", SqlDbType.VarChar).Value = TF_First_Occ;
                da.InsertCommand.Parameters.Add("@TF_Duration", SqlDbType.VarChar).Value = TF_Duration;
                da.InsertCommand.Parameters.Add("@TF_Last_Occ", SqlDbType.VarChar).Value = TF_Last_Occ;
                da.InsertCommand.Parameters.Add("@TF_Leas", SqlDbType.VarChar).Value = TF_Leas;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Contract_Finance_ID", SqlDbType.VarChar).Value = Contract_Finance_ID;
                da.InsertCommand.Parameters.Add("@conttypeTF", SqlDbType.VarChar).Value = conttypeTF;



                rowsAffected = da.InsertCommand.ExecuteNonQuery();

                SqlCommand scmd1 = new SqlCommand("select Cont_TF_Val  from Cont_TF_ID where Cont_TF_Office=@midval", cs1);
                scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;

                SqlCommand scmd2 = new SqlCommand("update Cont_TF_ID set Cont_TF_Val ='" + id + "' where Cont_TF_Office=@midval", cs1);
                //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int rows = scmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Contract_TF Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }



    public static int InsertContractFractional(string Contract_Fractional_ID, string Contract_Fractional_Resort, string Contract_Fractional_Residence_No, string Contract_Fractional_Residence_Type, string Contract_Fractional_Fractional_Int, string Contract_Fractional_Entitle, string Contract_Fractional_First_Occu,string contract_Fractional_Duration, string Contract_Fractional_Last_Occu, string Contract_Fractional_Lease_Back, string Contract_Finance_ID, string Profile_ID, string office)
    {
        int rowsAffected = 0;
        int id = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Fractional values(@Contract_Fractional_ID,@Contract_Fractional_Resort,@Contract_Fractional_Residence_No,@Contract_Fractional_Residence_Type,@Contract_Fractional_Fractional_Int,@Contract_Fractional_Entitle,@Contract_Fractional_First_Occu,@contract_Fractional_Duration, @Contract_Fractional_Last_Occu,@Contract_Fractional_Lease_Back,@Contract_Finance_ID,@Profile_ID)", cs1);
                da.InsertCommand.Parameters.Add("@Contract_Fractional_ID", SqlDbType.VarChar).Value = Contract_Fractional_ID;
                da.InsertCommand.Parameters.Add("@Contract_Fractional_Resort", SqlDbType.VarChar).Value = Contract_Fractional_Resort;
                da.InsertCommand.Parameters.Add("@Contract_Fractional_Residence_No", SqlDbType.VarChar).Value = Contract_Fractional_Residence_No;
                da.InsertCommand.Parameters.Add("@Contract_Fractional_Residence_Type", SqlDbType.VarChar).Value = Contract_Fractional_Residence_Type;
                da.InsertCommand.Parameters.Add("@Contract_Fractional_Fractional_Int", SqlDbType.VarChar).Value = Contract_Fractional_Fractional_Int;
                da.InsertCommand.Parameters.Add("@Contract_Fractional_Entitle", SqlDbType.VarChar).Value = Contract_Fractional_Entitle;
                da.InsertCommand.Parameters.Add("@Contract_Fractional_First_Occu", SqlDbType.VarChar).Value = Contract_Fractional_First_Occu;
                da.InsertCommand.Parameters.Add("@contract_Fractional_Duration", SqlDbType.VarChar).Value = contract_Fractional_Duration;
                da.InsertCommand.Parameters.Add("@Contract_Fractional_Last_Occu", SqlDbType.VarChar).Value = Contract_Fractional_Last_Occu;
                da.InsertCommand.Parameters.Add("@Contract_Fractional_Lease_Back", SqlDbType.VarChar).Value = Contract_Fractional_Lease_Back;
                da.InsertCommand.Parameters.Add("@Contract_Finance_ID", SqlDbType.VarChar).Value = Contract_Finance_ID;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;



                rowsAffected = da.InsertCommand.ExecuteNonQuery();

                SqlCommand scmd1 = new SqlCommand("select Cont_Fract_Val  from Cont_Fract_ID where Cont_Fract_Office=@midval", cs1);
                scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;

                SqlCommand scmd2 = new SqlCommand("update Cont_Fract_ID set Cont_Fract_Val ='" + id + "' where Cont_Fract_Office=@midval", cs1);
                //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int rows = scmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Contract_Fractional Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }


    public static int InserPurchaseService(string PS_ID, string PS_Deposit_Pay_Method, string PS_Deposit, string PS_Deposit_PA, string PS_Deposit_SA, string PS_PA_Admission, string PS_SA_Application, string PS_PA_Administration, string PS_SA_Administration, string PS_Total_Purchase, string PS_Total_Service, string PS_Country_Tax, string PS_Grand_Total, string PS_PA_Balance_Due, string PS_SA_Balance_Due, string PS_PA_No_Install, string PS_SA_No_Install, string PS_PA_FInstall_Date, string PS_SA_FInstall_Date, string PS_PA_Install_Amt, string PS_SA_Install_Amt, string PS_PA_FInstall_Amt, string PS_SA_FInstall_Amt, string PS_PA_Balance_Due_Dates, string PS_SA_Balance_Due_Dates, string PS_Remarks, string PS_EURO_Rate, string PS_AUS_Rate, string PS_GBP_Rate, string PS_IDA_Rate, string PS_Pay_Protect, string PS_YOInterest, string Profile_ID, string Contract_Finance_ID, string Total_Balance, DateTime PS_Date_Of_Insert, string office, string PS_PA_Balance_Due_Dates2, string PS_SA_Balance_Due_Dates2, string PS_Remarks2, string PS_Initial_Deposit, string PS_Bal_Deposit,string PS_Deposit_Date,string PS_CPA_Commnet)
    {
        int rowsAffected = 0;
        int id = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                da.InsertCommand = new SqlCommand("insert into Purchase_Service values(@PS_ID,	@PS_Deposit_Pay_Method,	@PS_Deposit,	@PS_Deposit_PA,	@PS_Deposit_SA,	@PS_PA_Admission,	@PS_SA_Application,	@PS_PA_Administration,	@PS_SA_Administration,	@PS_Total_Purchase,	@PS_Total_Service,	@PS_Country_Tax,	@PS_Grand_Total,	@PS_PA_Balance_Due,	@PS_SA_Balance_Due,	@PS_PA_No_Install,	@PS_SA_No_Install,	convert(datetime,@PS_PA_FInstall_Date,105),	@PS_SA_FInstall_Date,	@PS_PA_Install_Amt,	@PS_SA_Install_Amt,	@PS_PA_FInstall_Amt,	@PS_SA_FInstall_Amt,	@PS_PA_Balance_Due_Dates,	@PS_SA_Balance_Due_Dates,	@PS_Remarks,	@PS_EURO_Rate,	@PS_AUS_Rate,	@PS_GBP_Rate,	@PS_IDA_Rate,	@PS_Pay_Protect,	@PS_YOInterest,	@Profile_ID,	@Contract_Finance_ID, @Total_Balance,@PS_Date_Of_Insert,@PS_PA_Balance_Due_Dates2, @PS_SA_Balance_Due_Dates2, @PS_Remarks2, @PS_Initial_Deposit, @PS_Bal_Deposit,	convert(datetime,@PS_Deposit_Date,105),@PS_CPA_Commnet)", cs1);
                da.InsertCommand.Parameters.Add("@PS_ID", SqlDbType.VarChar).Value = PS_ID;
                da.InsertCommand.Parameters.Add("@PS_Deposit_Pay_Method", SqlDbType.VarChar).Value = PS_Deposit_Pay_Method;
                da.InsertCommand.Parameters.Add("@PS_Deposit", SqlDbType.VarChar).Value = PS_Deposit;
                da.InsertCommand.Parameters.Add("@PS_Deposit_PA", SqlDbType.VarChar).Value = PS_Deposit_PA;
                da.InsertCommand.Parameters.Add("@PS_Deposit_SA", SqlDbType.VarChar).Value = PS_Deposit_SA;
                da.InsertCommand.Parameters.Add("@PS_PA_Admission", SqlDbType.VarChar).Value = PS_PA_Admission;
                da.InsertCommand.Parameters.Add("@PS_SA_Application", SqlDbType.VarChar).Value = PS_SA_Application;
                da.InsertCommand.Parameters.Add("@PS_PA_Administration", SqlDbType.VarChar).Value = PS_PA_Administration;
                da.InsertCommand.Parameters.Add("@PS_SA_Administration", SqlDbType.VarChar).Value = PS_SA_Administration;
                da.InsertCommand.Parameters.Add("@PS_Total_Purchase", SqlDbType.VarChar).Value = PS_Total_Purchase;
                da.InsertCommand.Parameters.Add("@PS_Total_Service", SqlDbType.VarChar).Value = PS_Total_Service;
                da.InsertCommand.Parameters.Add("@PS_Country_Tax", SqlDbType.VarChar).Value = PS_Country_Tax;
                da.InsertCommand.Parameters.Add("@PS_Grand_Total", SqlDbType.VarChar).Value = PS_Grand_Total;
                da.InsertCommand.Parameters.Add("@PS_PA_Balance_Due", SqlDbType.VarChar).Value = PS_PA_Balance_Due;
                da.InsertCommand.Parameters.Add("@PS_SA_Balance_Due", SqlDbType.VarChar).Value = PS_SA_Balance_Due;
                da.InsertCommand.Parameters.Add("@PS_PA_No_Install", SqlDbType.VarChar).Value = PS_PA_No_Install;
                da.InsertCommand.Parameters.Add("@PS_SA_No_Install", SqlDbType.VarChar).Value = PS_SA_No_Install;
                da.InsertCommand.Parameters.Add("@PS_PA_FInstall_Date", SqlDbType.VarChar).Value = PS_PA_FInstall_Date;
                da.InsertCommand.Parameters.Add("@PS_SA_FInstall_Date", SqlDbType.VarChar).Value = PS_SA_FInstall_Date;
                da.InsertCommand.Parameters.Add("@PS_PA_Install_Amt", SqlDbType.VarChar).Value = PS_PA_Install_Amt;
                da.InsertCommand.Parameters.Add("@PS_SA_Install_Amt", SqlDbType.VarChar).Value = PS_SA_Install_Amt;
                da.InsertCommand.Parameters.Add("@PS_PA_FInstall_Amt", SqlDbType.VarChar).Value = PS_PA_FInstall_Amt;
                da.InsertCommand.Parameters.Add("@PS_SA_FInstall_Amt", SqlDbType.VarChar).Value = PS_SA_FInstall_Amt;
                da.InsertCommand.Parameters.Add("@PS_PA_Balance_Due_Dates", SqlDbType.VarChar).Value = PS_PA_Balance_Due_Dates;
                da.InsertCommand.Parameters.Add("@PS_SA_Balance_Due_Dates", SqlDbType.VarChar).Value = PS_SA_Balance_Due_Dates;
                da.InsertCommand.Parameters.Add("@PS_Remarks", SqlDbType.VarChar).Value = PS_Remarks;
                da.InsertCommand.Parameters.Add("@PS_EURO_Rate", SqlDbType.VarChar).Value = PS_EURO_Rate;
                da.InsertCommand.Parameters.Add("@PS_AUS_Rate", SqlDbType.VarChar).Value = PS_AUS_Rate;
                da.InsertCommand.Parameters.Add("@PS_GBP_Rate", SqlDbType.VarChar).Value = PS_GBP_Rate;
                da.InsertCommand.Parameters.Add("@PS_IDA_Rate", SqlDbType.VarChar).Value = PS_IDA_Rate;
                da.InsertCommand.Parameters.Add("@PS_Pay_Protect", SqlDbType.VarChar).Value = PS_Pay_Protect;
                da.InsertCommand.Parameters.Add("@PS_YOInterest", SqlDbType.VarChar).Value = PS_YOInterest;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Contract_Finance_ID", SqlDbType.VarChar).Value = Contract_Finance_ID;
                da.InsertCommand.Parameters.Add("@Total_Balance", SqlDbType.VarChar).Value = Total_Balance;
                da.InsertCommand.Parameters.Add("@PS_Date_Of_Insert", SqlDbType.DateTime).Value = PS_Date_Of_Insert;
                da.InsertCommand.Parameters.Add("@PS_PA_Balance_Due_Dates2", SqlDbType.VarChar).Value = PS_PA_Balance_Due_Dates2;
                da.InsertCommand.Parameters.Add("@PS_SA_Balance_Due_Dates2", SqlDbType.VarChar).Value = PS_SA_Balance_Due_Dates2;
                da.InsertCommand.Parameters.Add("@PS_Remarks2", SqlDbType.VarChar).Value = PS_Remarks2;
                da.InsertCommand.Parameters.Add("@PS_Initial_Deposit", SqlDbType.VarChar).Value = PS_Initial_Deposit;
                da.InsertCommand.Parameters.Add("@PS_Bal_Deposit", SqlDbType.VarChar).Value = PS_Bal_Deposit;
                da.InsertCommand.Parameters.Add("@PS_Deposit_Date", SqlDbType.VarChar).Value = PS_Deposit_Date;
                da.InsertCommand.Parameters.Add("@PS_CPA_Commnet", SqlDbType.VarChar).Value = PS_CPA_Commnet;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();

                SqlCommand scmd1 = new SqlCommand("select Cont_PASA_val from Cont_PASA_ID_Gen where Cont_PASA_office= @midval", cs1);
                scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;

                SqlCommand scmd2 = new SqlCommand("update Cont_PASA_ID_Gen set Cont_PASA_val ='" + id + "' where Cont_PASA_office=@midval", cs1);
                //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int rows = scmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Purchase_Service Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }



    public static int InserPaymentDetails(string Payment_Details_ID, string Payment_Details_PCard_Type, string Payment_Details_PIssuing_Bank, string Payment_Details_PCredit_Card_No, string Payment_Details_PCard_Holders_Name, string Payment_Details_PExpiry, string Payment_Details_PSecurity_No, string Payment_Details_PFor_Depo, string Payment_Details_PFor_Bala, string Payment_Details_SCard_Type, string Payment_Details_SIssuing_Bank, string Payment_Details_SCredit_Card_No, string Payment_Details_SCard_Holders_Name, string Payment_Details_SExpiry, string Payment_Details_SSecurity_No, string Payment_Details_SFor_Depo, string Payment_Details_SFor_Bala, string Profile_ID, string Contract_Finance_ID,DateTime Payment_Details_Insert_Date, string office,string pcomments,string scomments)
    {
        int rowsAffected = 0;
        int id = 0;
        
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Payment_Details values(@Payment_Details_ID,	@Payment_Details_PCard_Type,	@Payment_Details_PIssuing_Bank,	@Payment_Details_PCredit_Card_No,	@Payment_Details_PCard_Holders_Name,	@Payment_Details_PExpiry,	@Payment_Details_PSecurity_No,	@Payment_Details_PFor_Depo,	@Payment_Details_PFor_Bala,	@Payment_Details_SCard_Type,	@Payment_Details_SIssuing_Bank,	@Payment_Details_SCredit_Card_No,	@Payment_Details_SCard_Holders_Name,	@Payment_Details_SExpiry,	@Payment_Details_SSecurity_No,	@Payment_Details_SFor_Depo,	@Payment_Details_SFor_Bala,	@Profile_ID,	@Contract_Finance_ID,	@Payment_Details_Insert_Date,@pcomments,@scomments)", cs1);
                da.InsertCommand.Parameters.Add("@Payment_Details_ID", SqlDbType.VarChar).Value = Payment_Details_ID;
                da.InsertCommand.Parameters.Add("@Payment_Details_PCard_Type", SqlDbType.VarChar).Value = Payment_Details_PCard_Type;
                da.InsertCommand.Parameters.Add("@Payment_Details_PIssuing_Bank", SqlDbType.VarChar).Value = Payment_Details_PIssuing_Bank;
                da.InsertCommand.Parameters.Add("@Payment_Details_PCredit_Card_No", SqlDbType.VarChar).Value = Payment_Details_PCredit_Card_No;
                da.InsertCommand.Parameters.Add("@Payment_Details_PCard_Holders_Name", SqlDbType.VarChar).Value = Payment_Details_PCard_Holders_Name;
                da.InsertCommand.Parameters.Add("@Payment_Details_PExpiry", SqlDbType.VarChar).Value = Payment_Details_PExpiry;
                da.InsertCommand.Parameters.Add("@Payment_Details_PSecurity_No", SqlDbType.VarChar).Value = Payment_Details_PSecurity_No;
                da.InsertCommand.Parameters.Add("@Payment_Details_PFor_Depo", SqlDbType.VarChar).Value = Payment_Details_PFor_Depo;
                da.InsertCommand.Parameters.Add("@Payment_Details_PFor_Bala", SqlDbType.VarChar).Value = Payment_Details_PFor_Bala;
                da.InsertCommand.Parameters.Add("@Payment_Details_SCard_Type", SqlDbType.VarChar).Value = Payment_Details_SCard_Type;
                da.InsertCommand.Parameters.Add("@Payment_Details_SIssuing_Bank", SqlDbType.VarChar).Value = Payment_Details_SIssuing_Bank;
                da.InsertCommand.Parameters.Add("@Payment_Details_SCredit_Card_No", SqlDbType.VarChar).Value = Payment_Details_SCredit_Card_No;
                da.InsertCommand.Parameters.Add("@Payment_Details_SCard_Holders_Name", SqlDbType.VarChar).Value = Payment_Details_SCard_Holders_Name;
                da.InsertCommand.Parameters.Add("@Payment_Details_SExpiry", SqlDbType.VarChar).Value = Payment_Details_SExpiry;
                da.InsertCommand.Parameters.Add("@Payment_Details_SSecurity_No", SqlDbType.VarChar).Value = Payment_Details_SSecurity_No;
                da.InsertCommand.Parameters.Add("@Payment_Details_SFor_Depo", SqlDbType.VarChar).Value = Payment_Details_SFor_Depo;
                da.InsertCommand.Parameters.Add("@Payment_Details_SFor_Bala", SqlDbType.VarChar).Value = Payment_Details_SFor_Bala;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Contract_Finance_ID", SqlDbType.VarChar).Value = Contract_Finance_ID;
                //da.InsertCommand.Parameters.Add("@Payment_Details_Insert_Date", SqlDbType.VarChar).Value = DateTime.Now;
                da.InsertCommand.Parameters.Add("@Payment_Details_Insert_Date", SqlDbType.DateTime).Value = Payment_Details_Insert_Date;
                da.InsertCommand.Parameters.Add("@pcomments", SqlDbType.VarChar).Value = pcomments;
                da.InsertCommand.Parameters.Add("@scomments", SqlDbType.VarChar).Value = scomments;


                rowsAffected = da.InsertCommand.ExecuteNonQuery();

                SqlCommand scmd1 = new SqlCommand("select Pment_Details_Val from Payment_Details_ID where Pment_Details_Office= @midval", cs1);
                scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;

                SqlCommand scmd2 = new SqlCommand("update Payment_Details_ID set Pment_Details_Val ='" + id + "' where Pment_Details_Office=@midval", cs1);
                //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int rows = scmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Payment_Details Query " + ex.Message);
                throw;

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static int Updategiftoption(string ProfileID, string gift_option, string VoucherNo, string giftcomm)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {
            try
            {

                SqlCommand scd = new SqlCommand("update Gift set Gift_ID_Option= '" + gift_option + "',Gift_Voucher_numb='" + VoucherNo + "',Gift_Comment='" + giftcomm + "',GiftItem='' where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update Gift Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsaffected);
    }


    //public static int GetAccessValue(string id, string title, string name)
    //{
    //    int val;
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        SqlCommand scd = new SqlCommand("select *  from user_group_access where  Name =@name  and([read] = 1 or[modify] = 1 or[delete] = 1 or[write] = 1 or[report] = 1)", cs1);
    //        scd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
    //        scd.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
    //        scd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
    //        val = (int)scd.ExecuteScalar();

    //    }
    //    return val;
    //}


    public static string getFinanceInstallID(string midval)
    {

        string startval,mmidval,sendval;
        


        int id = 0;

        string finaiInstId = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select StartVal from Finance_install_ID where office = @midval", cs1);
            scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            startval = (string)scmd.ExecuteScalar();

            SqlCommand scmd2 = new SqlCommand("select midval from Finance_install_ID where office = @midval", cs1);
            scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            mmidval = (string)scmd2.ExecuteScalar();

            SqlCommand scmd3 = new SqlCommand("select Smidval from Finance_install_ID where office = @midval", cs1);
            scmd3.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            sendval = (string)scmd3.ExecuteScalar();

            SqlCommand scmd1 = new SqlCommand("select endval from Finance_install_ID where office = @midval", cs1);
            scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            finaiInstId = startval + mmidval + sendval + id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return finaiInstId;


    }

    public static string getFinanceDetailID()
    {

        string startval;



        int id = 0;

        string finaiInstId = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select  FD_Start_Val from Finance_Details_ID", cs1);
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            startval = (string)scmd.ExecuteScalar();

           
            SqlCommand scmd1 = new SqlCommand("select  FD_End_Val from Finance_Details_ID", cs1);
           // scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            finaiInstId = startval + id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return finaiInstId;


    }


    public static int InsertFinanceInv(string Finance_Invoice_Numb, string Finance_Invoice_Desc, string Finance_Invoice_Due_Date, string Finance_Invoice_Amt, string Finance_Invoice_currency, string Finance_Invoice_Contratct_Numb, string Profile_ID, string Finance_Invoice_Type, string office,string contFinance, DateTime Finance_Invoice_Insert_Date)
    {
        int rowsAffected = 0;
        int id = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Finance_Invoice values(@Finance_Invoice_Numb,	@Finance_Invoice_Desc,	convert(datetime,@Finance_Invoice_Due_Date,105),	@Finance_Invoice_Amt,	@Finance_Invoice_currency,	@Finance_Invoice_Contratct_Numb,	@Profile_ID, @Finance_Invoice_Type,@contFinance,@Finance_Invoice_Insert_Date)", cs1);
                da.InsertCommand.Parameters.Add("@Finance_Invoice_Numb", SqlDbType.VarChar).Value = Finance_Invoice_Numb;
                da.InsertCommand.Parameters.Add("@Finance_Invoice_Desc", SqlDbType.VarChar).Value = Finance_Invoice_Desc;
                da.InsertCommand.Parameters.Add("@Finance_Invoice_Due_Date", SqlDbType.VarChar).Value = Finance_Invoice_Due_Date;
                da.InsertCommand.Parameters.Add("@Finance_Invoice_Amt", SqlDbType.VarChar).Value = Finance_Invoice_Amt;
                da.InsertCommand.Parameters.Add("@Finance_Invoice_currency", SqlDbType.VarChar).Value = Finance_Invoice_currency;
                da.InsertCommand.Parameters.Add("@Finance_Invoice_Contratct_Numb", SqlDbType.VarChar).Value = Finance_Invoice_Contratct_Numb;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Finance_Invoice_Type", SqlDbType.VarChar).Value = Finance_Invoice_Type;
                da.InsertCommand.Parameters.Add("@contFinance", SqlDbType.VarChar).Value = contFinance;
                da.InsertCommand.Parameters.Add("@Finance_Invoice_Insert_Date", SqlDbType.DateTime).Value = Finance_Invoice_Insert_Date;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();

           
            SqlCommand scmd1 = new SqlCommand("select endval from Finance_install_ID where office = @midval", cs1);
            scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            SqlCommand scmd2 = new SqlCommand("update Finance_install_ID set endval ='" + id + "' where office=@midval", cs1);
            //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
            int rows = scmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Finance_Invoice Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }


    public static int InsertFDetails(string Finance_Details_ID, string Finance_Details_Total_Pur, string Finance_Details_Qual_Depo, string Finance_Details_Credit_Amount, string Finance_Details_Amount_Curr, string Finance_Details_No_Of_Month, string Finance_Details_Int_Rate, string Finance_Details_Monthly_Repay, string Profile_ID, string Contract_Finance_ID, string Finance_Details_Entry_Date,string Finance_Details_Monthly_Repay2,string Finance_Details_Monthly_RepayProtect, string Finance_Details_PayProtect, string Finance_Details_Finance_Date)
    {
        int rowsAffected = 0;
        int id = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Finance_Details values(@Finance_Details_ID,	@Finance_Details_Total_Pur ,	@Finance_Details_Qual_Depo ,	@Finance_Details_Credit_Amount,	@Finance_Details_Amount_Curr ,	@Finance_Details_No_Of_Month ,	@Finance_Details_Int_Rate ,	@Finance_Details_Monthly_Repay ,	@Profile_ID ,	@Contract_Finance_ID ,	@Finance_Details_Entry_Date,@Finance_Details_Monthly_Repay2,@Finance_Details_Monthly_RepayProtect, @Finance_Details_PayProtect,convert(datetime,@Finance_Details_Finance_Date,105))", cs1);
                da.InsertCommand.Parameters.Add("@Finance_Details_ID", SqlDbType.VarChar).Value = Finance_Details_ID;
                da.InsertCommand.Parameters.Add("@Finance_Details_Total_Pur", SqlDbType.VarChar).Value = Finance_Details_Total_Pur;
                da.InsertCommand.Parameters.Add("@Finance_Details_Qual_Depo", SqlDbType.VarChar).Value = Finance_Details_Qual_Depo;
                da.InsertCommand.Parameters.Add("@Finance_Details_Credit_Amount", SqlDbType.VarChar).Value = Finance_Details_Credit_Amount;
                da.InsertCommand.Parameters.Add("@Finance_Details_Amount_Curr", SqlDbType.VarChar).Value = Finance_Details_Amount_Curr;
                da.InsertCommand.Parameters.Add("@Finance_Details_No_Of_Month", SqlDbType.VarChar).Value = Finance_Details_No_Of_Month;
                da.InsertCommand.Parameters.Add("@Finance_Details_Int_Rate", SqlDbType.VarChar).Value = Finance_Details_Int_Rate;
                da.InsertCommand.Parameters.Add("@Finance_Details_Monthly_Repay", SqlDbType.VarChar).Value = Finance_Details_Monthly_Repay;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Contract_Finance_ID", SqlDbType.VarChar).Value = Contract_Finance_ID;
                da.InsertCommand.Parameters.Add("@Finance_Details_Entry_Date", SqlDbType.VarChar).Value = Finance_Details_Entry_Date;
                da.InsertCommand.Parameters.Add("@Finance_Details_Monthly_Repay2", SqlDbType.VarChar).Value = Finance_Details_Monthly_Repay2;
                da.InsertCommand.Parameters.Add("@Finance_Details_Monthly_RepayProtect", SqlDbType.VarChar).Value = Finance_Details_Monthly_RepayProtect;
                da.InsertCommand.Parameters.Add("@Finance_Details_PayProtect", SqlDbType.VarChar).Value = Finance_Details_PayProtect;
                da.InsertCommand.Parameters.Add("@Finance_Details_Finance_Date", SqlDbType.VarChar).Value = Finance_Details_Finance_Date;



                rowsAffected = da.InsertCommand.ExecuteNonQuery();


                SqlCommand scmd1 = new SqlCommand("select FD_End_Val from Finance_Details_ID", cs1);
                //scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;
               // update Finance_Details_ID set FD_End_Val = '"+id+"'
                SqlCommand scmd2 = new SqlCommand("update Finance_Details_ID set FD_End_Val = '" + id + "'", cs1);
                //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                //scmd2.Parameters.Add("@midval", SqlDbType.VarChar).Value = office;
                int rows = scmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Finance details Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }





    public static DataSet LoadGiftOption(string office)
    {
        SqlDataAdapter da;
        DataSet dt = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select item from Gift_Option where Gift_Option_Status = 'Active' and office=@office", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            dt = new DataSet();
            da.Fill(dt);
        }
        return (dt);

    }


    public static DataSet LoadYearOfInt()
    {
        SqlDataAdapter da;
        DataSet dt = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Year_Int_Year +'  '+ Year_Int_Perc  as name, Year_Int_ID from Year_Of_Int", cs1);
            //SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            dt = new DataSet();
            da.Fill(dt);
        }
        return (dt);

    }

    public static DataSet LoadRecept()
    {
        SqlDataAdapter da;
        DataSet dt = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Recep_First_Name as name,Recep_ID from reception", cs1);
            //SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            dt = new DataSet();
            da.Fill(dt);
        }
        return (dt);

    }


    public static DataSet CrownFinaCurr()
    {
        SqlDataAdapter da;
        DataSet dt = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Finance_Curr_Name from Crown_Finance_Curr where Finance_Curr_Status='Active' order by Finance_Curr_Name ", cs1);
           // SqlCmd.Parameters.Add("@tcurr", SqlDbType.VarChar).Value = tcurr;
            da = new SqlDataAdapter(SqlCmd);
            dt = new DataSet();
            da.Fill(dt);
        }
        return (dt);

    }


    public static string PnumbCount(string midval)
    {

        string startval;



        int id = 0;

        string Pnumbnumb = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select PnumberCount_start_val from PnumberCount where PnumberCount_curr=@midval", cs1);
            scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            startval = (string)scmd.ExecuteScalar();

          

            SqlCommand scmd1 = new SqlCommand("select PnumberCount_End_val from PnumberCount where PnumberCount_curr=@midval", cs1);
            scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            int val = (int)scmd1.ExecuteScalar();

            id = Convert.ToInt32(val) + 1;

            Pnumbnumb = startval + id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return Pnumbnumb;


    }



    public static string getExchangeRate(string midval)
    {

        //string startval;



        // int id = 0;
        //float val = 0;
        double val = 0;

        string Pnumbnumb = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            if (midval == "EUR")
            {
                SqlCommand scmd = new SqlCommand("select ERates_EUR from Exchange_Rate where ERates_Status ='Active'", cs1);
                //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
               // val = (float)scmd.ExecuteScalar();
                val = (double)scmd.ExecuteScalar();
            }
            else if (midval == "AUD")
            {
                SqlCommand scmd = new SqlCommand("select ERates_AUD from Exchange_Rate where ERates_Status ='Active'", cs1);
                //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
                //val = (float)scmd.ExecuteScalar();
                val = (double)scmd.ExecuteScalar();
                // = scmd.ExecuteScalar().tostring();
               // val = (float)System.Convert.ToSingle(str);
            }
            else if (midval == "USD")
            {
                val = 1;

            }
            else if (midval == "GBP")
            {
                SqlCommand scmd = new SqlCommand("select ERates_GBP from Exchange_Rate where ERates_Status ='Active'", cs1);
                //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
                //val = (float)scmd.ExecuteScalar();
                val = (double)scmd.ExecuteScalar();
                // = scmd.ExecuteScalar().tostring();
                // val = (float)System.Convert.ToSingle(str);
            }


            //SqlCommand scmd1 = new SqlCommand("select PnumberCount_End_val from PnumberCount where PnumberCount_curr=@midval", cs1);
            //scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            //int val = (int)scmd1.ExecuteScalar();

            //id = Convert.ToInt32(val) + 1;

            Pnumbnumb =  val + "";

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return Pnumbnumb;


    }




    public static string loadmcharge(string resitype,string fracint)
    {

        string startval;


        int year = DateTime.Now.Year;
        int id = 0;

        string Pnumbnumb = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select MCharge_Per_Week from frac_mcharge where MCharge_Resi_Type =@resitype and MCharge_Year='"+year+"'", cs1);
            scmd.Parameters.Add("@resitype", SqlDbType.VarChar).Value = resitype;
            int val = (int)scmd.ExecuteScalar();


            if(fracint== "Four Weeks")
            {
                id = Convert.ToInt32(val) * 4;
            }
            else if(fracint == "One Weeks")
            {
                id = Convert.ToInt32(val) * 1;
            }
            else if (fracint == "Two Weeks")
            {
                id = Convert.ToInt32(val) * 2;
            }
            else if (fracint == "Three Weeks")
            {
                id = Convert.ToInt32(val) * 3;
            }





            //SqlCommand scmd1 = new SqlCommand("select PnumberCount_End_val from PnumberCount where PnumberCount_curr=@midval", cs1);
            //scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            //int val = (int)scmd1.ExecuteScalar();

            //id = Convert.ToInt32(val) + 1;

            Pnumbnumb =  id + "" ;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return Pnumbnumb;


    }

    public static int UpdatePnumber(string CrownCurr)
    {
        int rows = 0;
         int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scmd1 = new SqlCommand("select PnumberCount_End_val from PnumberCount where PnumberCount_curr=@midval", cs1);
                scmd1.Parameters.Add("@midval", SqlDbType.VarChar).Value = CrownCurr;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("update PnumberCount set PnumberCount_End_val = '"+ id +"' where PnumberCount_curr=@midval", cs1);
                sqlcmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = CrownCurr;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in UPDATE UpdatePnumber Query  " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }




    public static string LoadYearOfIntValue(string val)
    {
        string startval;
        string finaiInstId = null;

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select Year_Int_Perc from Year_Of_Int where Year_Int_Perc = RIGHT(@val, 3)", cs1);
            scmd.Parameters.Add("@val", SqlDbType.VarChar).Value = val;
            startval = (string)scmd.ExecuteScalar();
            finaiInstId = startval;
        //    SqlDataAdapter da;
        //DataSet dt = new DataSet();
        //using (SqlConnection cs1 = Queries.GetDBConnection())
        //{
        //    SqlCommand SqlCmd = new SqlCommand("select Year_Int_Perc from Year_Of_Int where Year_Int_Perc = RIGHT(@val, 3)", cs1);
        //    SqlCmd.Parameters.Add("@val", SqlDbType.VarChar).Value = val;
        //    da = new SqlDataAdapter(SqlCmd);
        //    dt = new DataSet();
        //    da.Fill(dt);
        }
        return finaiInstId;

    }



    public static DataSet LoadAgentsIVO(string mktg)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select distinct a.Agent_Name  from Agent a join Agent_marketing sm on a.Agent_ID = sm.Agent_ID join Marketing_Program mp on mp.Marketing_Program_ID = sm.marketing_program_id where a.Agent_Status = 'Active' and mp.Marketing_Program_Name =@mktg order by 1", cs1);
            SqlCmd.Parameters.Add("@mktg", SqlDbType.VarChar).Value = mktg;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static SqlDataReader getgiftoption(string ProfileID)
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select Gift_ID_Option,Gift_Voucher_numb,Gift_Comment,GiftPrice from Gift where Profile_ID=@ProfileID", cs1);
        SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;

        SqlDataReader dr = SqlCmd.ExecuteReader();
        return dr;
    }


    //insert logs
    public static int InsertContractLogs(string ProfileID, String ContractNo, String UpdatedField, string area, string Username, String Log_Entry)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Log values(@ProfileID,@ContractNo,@UpdatedField,@area,@Username,@Log_Entry)", cs1);
                da.InsertCommand.Parameters.Add("@ProfileID  ", SqlDbType.VarChar).Value = ProfileID;
                da.InsertCommand.Parameters.Add("@ContractNo ", SqlDbType.VarChar).Value = ContractNo;
                da.InsertCommand.Parameters.Add("@UpdatedField", SqlDbType.VarChar).Value = UpdatedField;
                da.InsertCommand.Parameters.Add("@area", SqlDbType.VarChar).Value = area;
                da.InsertCommand.Parameters.Add("@Username ", SqlDbType.VarChar).Value = Username;
                da.InsertCommand.Parameters.Add("@Log_Entry", SqlDbType.VarChar).Value = Log_Entry;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert Contract_Log Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }


    public static string LoadPointCont(string office,string club_name,string venuecountry, string venue, string mark)
    {
        //SqlDataAdapter da;
        //DataSet dt = new DataSet();
        string sendval, date, startv, endv,incr1;
        int  incr2, incr3;
        string final = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name and Office=@office and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
           // SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            sendval = (string)SqlCmd.ExecuteScalar();
            //da = new SqlDataAdapter(SqlCmd);
            //dt = new DataSet();
            //da.Fill(dt);

            SqlCommand SqlCmd2 = new SqlCommand("SELECT FORMAT(GETDATE(), 'ddMMyy') as date", cs1);
            date = (string)SqlCmd2.ExecuteScalar();

            //SqlCommand SqlCmd3 = new SqlCommand("select isnull(Cont_Gen_Scode,'') from Marketing_Program where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = @venue and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)) )  and Marketing_Program_Name=@mark", cs1);
            //SqlCmd3.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            //SqlCmd3.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            //SqlCmd3.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
            //startv = (string)SqlCmd3.ExecuteScalar();

            //SqlCommand SqlCmd4 = new SqlCommand("select isnull(Cont_Gen_Lcode,'') from Marketing_Program where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = @venue and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)) )  and Marketing_Program_Name=@mark", cs1);
            //SqlCmd4.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            //SqlCmd4.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            //SqlCmd4.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
            //endv = (string)SqlCmd4.ExecuteScalar();

            

            SqlCommand SqlCmd5 = new SqlCommand("select Increment_Value from Contract_Club where Contract_Club_Name=@club_name and Office=@office and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)", cs1);
            SqlCmd5.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            SqlCmd5.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
            SqlCmd5.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            //SqlCmd5.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            incr1 = (string)SqlCmd5.ExecuteScalar();

            incr2 = Convert.ToInt32(incr1);

            incr3 = incr2 + 1;
            //incr2 = int.TryParse(incr1);
            //select Cont_Gen_Scode from Marketing_Program where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID = 'V0001') and Marketing_Program_Name = 'Karma Royal Jimbaran'

            //final = sendval + '/' + date + '/' + startv + incr3 + endv;
            final = sendval + '/' + date + '/' + incr3 ;
        }
        return final;
        
       
    }



    public static string LoadFracCont(string office, string club_name, string venuecountry, string venue, string mark)
    {
        //SqlDataAdapter da;
        //DataSet dt = new DataSet();
        string sendval = "", date, startv, endv;
        int incr1,incr2, incr3;
        string final = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
           

            SqlCommand SqlCmd2 = new SqlCommand("SELECT FORMAT(GETDATE(), 'ddMMyy') as date", cs1);
            date = (string)SqlCmd2.ExecuteScalar();

            //SqlCommand SqlCmd3 = new SqlCommand("select isnull(ContF_Gen_Scode,'') from Marketing_Program where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = @venue and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)) )  and Marketing_Program_Name=@mark", cs1);
            //SqlCmd3.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            //SqlCmd3.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;

            
             SqlCommand SqlCmd3 = new SqlCommand("select isnull(ContF_Gen_Scode,'') from venue2 where Venue2_Name =@mark", cs1);
            SqlCmd3.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;

            startv = (string)SqlCmd3.ExecuteScalar();

            
           // SqlCommand SqlCmd4 = new SqlCommand("select isnull(ContF_Gen_Lcode,'') from Marketing_Program where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = @venue and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)) )  and Marketing_Program_Name=@mark", cs1);
            SqlCommand SqlCmd4 = new SqlCommand("select isnull(ContF_Gen_Lcode,'') from venue2 where Venue2_Name = @mark", cs1);
           //// SqlCmd4.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
           // SqlCmd4.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd4.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
            endv = (string)SqlCmd4.ExecuteScalar();

           // select ContF_Inc_Val from venue2 where Venue2_Name = @mark

            SqlCommand SqlCmd5 = new SqlCommand("select ContF_Inc_Val from venue2 where Venue2_Name = @mark", cs1);
          
            //SqlCmd5.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            //SqlCmd5.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            SqlCmd5.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
            incr1 = (int)SqlCmd5.ExecuteScalar();

            //incr2 = Convert.ToInt32(incr1);

            incr3 = Convert.ToInt32(incr1) + 1;
            //incr2 = int.TryParse(incr1);
            //select Cont_Gen_Scode from Marketing_Program where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID = 'V0001') and Marketing_Program_Name = 'Karma Royal Jimbaran'
            if (office == "IVO")
            {
                sendval = "KRR1";
            }
            else if (office == "HML")
            {
                sendval = "PRR1";
            }
            else if (office == "ATH")
            {
                sendval = "KRR1";
            }
            final = sendval + '/' + date + '/' + startv + incr3 + endv;
        }
        return final;


    }


    //load count for gift option

    public static int countgift(string ProfileID)
    {
        //SqlDataAdapter da;
        //DataSet dt = new DataSet();
        // string sendval = "", date, startv, endv;
        //int incr1, incr2, incr3;
        int inc1,inc2;
        int final;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            
            SqlCommand SqlCmd3 = new SqlCommand("select count(*) from Gift where Profile_ID=@ProfileID", cs1);
            SqlCmd3.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;







            inc1 = (int)SqlCmd3.ExecuteScalar();
            inc2 = Convert.ToInt32(inc1);
            final = inc2;


        }
        return final;


    }


    public static int UpdateGiftValue(string OGiftOption, string GiftOption, string Voucher, string ProfileID, string comment, string GiftPrice)
    {
        int rows = 0;
       // int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                int price = int.Parse(GiftPrice, NumberStyles.Number);

                SqlCommand scd1 = new SqlCommand("select Gift_ID from Gift where Profile_ID = @ProfileID and Gift_ID_Option = @OGiftOption", cs1);
                scd1.Parameters.Add("@OGiftOption", SqlDbType.VarChar).Value = OGiftOption;
                scd1.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                string val = (string)scd1.ExecuteScalar();


                SqlCommand sqlcmd = new SqlCommand("update gift set Gift_ID_Option = @GiftOption,Gift_Voucher_numb = @Voucher,Gift_Comment=@comment,GiftPrice=@GiftPrice where Profile_ID = @ProfileID and Gift_ID = @giftid", cs1);
                sqlcmd.Parameters.Add("@GiftOption", SqlDbType.VarChar).Value = GiftOption;
                sqlcmd.Parameters.Add("@Voucher", SqlDbType.VarChar).Value = Voucher;
                sqlcmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                sqlcmd.Parameters.Add("@giftid", SqlDbType.VarChar).Value = val;
                sqlcmd.Parameters.Add("@comment", SqlDbType.VarChar).Value = comment;
                sqlcmd.Parameters.Add("@GiftPrice", SqlDbType.Int).Value = price;
                
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in UPDATE GiftValue Query  " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }

        }
        return rows;
    }



    public static int UpdatePointCont(string office, string club_name, string venuecountry, string venue, string mark)
    {
        int rowsAffected = 0;
        int id, incr2, incr3;
        string incr1;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand SqlCmd5 = new SqlCommand("select Increment_Value from Contract_Club where Contract_Club_Name=@club_name and Office=@office and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)", cs1);
                SqlCmd5.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                SqlCmd5.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
                SqlCmd5.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd5.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                incr1 = (string)SqlCmd5.ExecuteScalar();

                incr2 = Convert.ToInt32(incr1);

                incr3 = incr2 + 1;

                SqlCommand SqlCmd6 = new SqlCommand("update Contract_Club set Increment_Value = '" + incr3 + "' where Contract_Club_Name=@club_name and Office=@office and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)", cs1);

                SqlCmd6.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
                SqlCmd6.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
                SqlCmd6.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd6.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update Contract_Club Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }

    public static int UpdateFracCont( string venuecountry, string venue, string mark)
    {
        int rowsAffected = 0;
        int incr1,id,incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                //SqlCommand SqlCmd5 = new SqlCommand("select ContF_Inc_Val from Marketing_Program where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = @venue and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name = @venuecountry)) )  and Marketing_Program_Name=@mark", cs1);

                //SqlCmd5.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd5.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                //SqlCmd5.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
                //incr1 = (int)SqlCmd5.ExecuteScalar();

                //id = Convert.ToInt32(incr1) + 1;


                SqlCommand SqlCmd5 = new SqlCommand("select ContF_Inc_Val from venue2 where Venue2_Name = @mark", cs1);

                //SqlCmd5.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd5.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd5.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
                incr1 = (int)SqlCmd5.ExecuteScalar();

                //incr2 = Convert.ToInt32(incr1);

                incr3 = Convert.ToInt32(incr1) + 1;



                SqlCommand SqlCmd6 = new SqlCommand("update venue2 set ContF_Inc_Val = '" + incr3 + "' where Venue2_Name = @mark", cs1);

                //SqlCmd6.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd6.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd6.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update Marketing_Program Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }


    public static string LoadPropfess()
    {
        double sendval1,sendval2;
        string f2;
        float f1;

        //int year = DateTime.Now.Year;
       // string [] sendvalArray = new string[3];
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select charge_Property_fee_per_year from Property_fee_charge where charge_year = year(GETDATE())", cs1);
           // SqlCmd.Parameters.Add("@Nopoints", SqlDbType.VarChar).Value = NoPoints;

            sendval1 = (double)SqlCmd.ExecuteScalar();

            SqlCommand SqlCmd2 = new SqlCommand("select charge_member_fee from Property_fee_charge where charge_year = year(GETDATE()) ", cs1);
            //SqlCmd2.Parameters.Add("@Nopoints", SqlDbType.VarChar).Value = NoPoints;

            sendval2 = (double)SqlCmd2.ExecuteScalar();

            
            f2 = sendval1+"-"+ sendval2;
         
        }
       return f2;
    }


  


    public static DataTable loadreport(string Profile_Id,string fname,string office)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            string endv;
            SqlCommand SqlCmd4 = new SqlCommand("select procedureName from printpdf where Printpdf_Name=@fname and Printpdf_Office=@office and Printpdf_Status='Active' ", cs1);
            SqlCmd4.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            SqlCmd4.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            //SqlCmd4.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
            endv = (string)SqlCmd4.ExecuteScalar();


            string test1 = endv;

            SqlCommand cmd_sp = new SqlCommand(test1, cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@contnumb", Profile_Id);
            // using (SqlCommand cmd = new SqlCommand())
            // {
            // cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandText = "holiday_confirm";
            // cmd.Parameters.AddWithValue("@booking_id", booking_id);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }


    public static DataTable loadDGRBALI1(string date,string office, string venue)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("dgrbali22", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
              cmd_sp.Parameters.AddWithValue("@date", date);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }



    public static DataTable loadregcard(string Profile_Id)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("GetGuestReg", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Profile_Id", Profile_Id);
            // using (SqlCommand cmd = new SqlCommand())
            // {
            // cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandText = "holiday_confirm";
            // cmd.Parameters.AddWithValue("@booking_id", booking_id);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }

    public static DataTable loadregcard1(string Profile_Id)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand cmd_sp = new SqlCommand("GuestRegistration", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@Profile_Id", Profile_Id);
            // using (SqlCommand cmd = new SqlCommand())
            // {
            // cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandText = "holiday_confirm";
            // cmd.Parameters.AddWithValue("@booking_id", booking_id);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }



    public static int Deleteprofileonerror(string ProfileID)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {
            try
            {

                SqlCommand scd = new SqlCommand("delete from Profile_Primary where Profile_ID=@ProfileID", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();

                SqlCommand scd2 = new SqlCommand("delete from Profile_Secondary where Profile_ID=@ProfileID", cs2);
                scd2.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd2.ExecuteNonQuery();

                SqlCommand scd3 = new SqlCommand("delete from Sub_Profile1 where Profile_ID=@ProfileID", cs2);
                scd3.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd3.ExecuteNonQuery();

                SqlCommand scd4 = new SqlCommand("delete from Sub_Profile2 where Profile_ID=@ProfileID", cs2);
                scd4.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd4.ExecuteNonQuery();

                SqlCommand scd5 = new SqlCommand("delete from Profile_Address where Profile_ID=@ProfileID", cs2);
                scd5.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd5.ExecuteNonQuery();

                SqlCommand scd6 = new SqlCommand("delete from Tour_Details where Profile_ID=@ProfileID", cs2);
                scd6.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd6.ExecuteNonQuery();

                SqlCommand scd7 = new SqlCommand("delete from Profile_Stay where Profile_ID=@ProfileID", cs2);
                scd7.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd7.ExecuteNonQuery();

                SqlCommand scd8 = new SqlCommand("delete from Phone where Profile_ID=@ProfileID", cs2);
                scd8.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd8.ExecuteNonQuery();

                SqlCommand scd9 = new SqlCommand("delete from Email where Profile_ID=@ProfileID", cs2);
                scd9.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd9.ExecuteNonQuery();

                

                SqlCommand scd11 = new SqlCommand("delete from Sub_Profile3 where Profile_ID=@ProfileID", cs2);
                scd11.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd11.ExecuteNonQuery();

                SqlCommand scd12 = new SqlCommand("delete from Sub_Profile4 where Profile_ID=@ProfileID", cs2);
                scd12.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd12.ExecuteNonQuery();

                SqlCommand scd10 = new SqlCommand("delete from Profile where Profile_ID=@ProfileID", cs2);
                scd10.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd10.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Update Gift Query " + ex.Message);

                string msg = "Error in Delete Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }



    public static String GetSubProfile3ID(string startvalue)//(string off)
    {
        string SubProfile3ID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP3";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile3_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile3ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile3_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile3ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return SubProfile3ID;
    }


    public static String GetSubProfile4ID(string startvalue)//(string off)
    {
        string SubProfile4ID = null;
        // string startvalue = "";
        int id = 0;
        int year = DateTime.Now.Year;
        string initial = "SP4";
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            /* if (off == "INDIA" || off == "India")
             {
                 startvalue = "HMC";*/

            //check if entry exists
            SqlCommand scd = new SqlCommand("select count(*) from ID_Generation where VenueCode =@startvalue and year =@year", cs1);
            scd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
            scd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int cnt = (int)scd.ExecuteScalar();
            if (cnt == 1)
            {
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile4_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile4ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();
            }
            else if (cnt == 0)
            {
                //insert into idgeneration
                int insert = Queries.InsertIDGeneration(startvalue, year);
                //get last code of profile n increment by 1
                //get last code of profile n increment by 1
                SqlCommand scd1 = new SqlCommand("select SubProfile4_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;
                SubProfile4ID = initial + startvalue + year + id;

                //SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile1_Start_Val='" + id + "' where VenueCode=@startvalue and year=@year", cs1);
                //sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                //sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //int rows = sqlcmd.ExecuteNonQuery();

            }


        }

        return SubProfile4ID;
    }

    public static int UpdateSubprofile3Value(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd1 = new SqlCommand("select SubProfile3_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile3_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val SubProfile1_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val SubProfile3_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }



    public static int UpdateSubprofile4Value(string startvalue, int year)
    {
        int rows = 0;
        int id = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd1 = new SqlCommand("select SubProfile4_Start_Val  from ID_Generation where VenueCode=@startvalue and year=@year", cs1);
                scd1.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                scd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                string val = (string)scd1.ExecuteScalar();
                id = Convert.ToInt32(val) + 1;


                SqlCommand sqlcmd = new SqlCommand("UPDATE ID_Generation SET SubProfile4_Start_Val=@id where VenueCode=@startvalue and year=@year", cs1);
                sqlcmd.Parameters.Add("@startvalue", SqlDbType.VarChar).Value = startvalue;
                sqlcmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                sqlcmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rows = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE ID_Generation Query Email_Start_Val SubProfile1_Start_Val" + ex.Message);

                string msg = "Error in UPDATE ID_Generation Query Email_Start_Val SubProfile4_Start_Val" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return rows;
    }



    public static DataSet LoadContractFinanceDetails(string Cfinanceno)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from Contract_Finance where Contract_Finance_ID=@Cfinanceno", cs1);
            SqlCmd.Parameters.Add("@Cfinanceno", SqlDbType.VarChar).Value = Cfinanceno;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadAllContractFractionalDetails(string Cfinanceno)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from Contract_Finance cf left join Contract_Fractional cfr on cfr.Contract_Finance_ID =cf.Contract_Finance_ID left join CT_Points cp on cp.Contract_Finance_ID = cf.Contract_Finance_ID left join Contract_TP ctp on ctp.Contract_Finance_ID = cf.Contract_Finance_ID left join Contract_TF ctf on ctf.Contract_Finance_ID = cf.Contract_Finance_ID left join Purchase_service ps on ps.Contract_Finance_ID = cf.Contract_Finance_ID left join Payment_Details pd on pd.Contract_Finance_ID = cf.Contract_Finance_ID left join Finance_Details fd on fd.Contract_Finance_ID = cf.Contract_Finance_ID left join status_change  sc on sc.Contract_Finance_ID = cf.Contract_Finance_ID  where cf.Contract_Finance_ID=@Cfinanceno", cs1);
            SqlCmd.Parameters.Add("@Cfinanceno", SqlDbType.VarChar).Value = Cfinanceno;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet loadFinanceinvoicedetails(string Cfinanceno)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Finance_Invoice_Desc,	Finance_Invoice_Due_Date,	Finance_Invoice_Amt,	Finance_Invoice_currency,	Finance_Invoice_Contratct_Numb,	Profile_ID,	Finance_Invoice_Type from Finance_Invoice where Finance_Invoice_Contratct_Numb in (select Contract_Finance_Cont_Numb from Contract_Finance where Contract_Finance_ID=@Cfinanceno)", cs1);
            SqlCmd.Parameters.Add("@Cfinanceno", SqlDbType.VarChar).Value = Cfinanceno;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }



    public static int DeleteInvoiceOnEdit(string ProfileID,string Fracid)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {
            try
            {

                SqlCommand scd = new SqlCommand("insert into Finance_Invoice_Deleted select * from Finance_Invoice where Finance_Invoice_Contratct_Numb in (select Contract_Finance_Cont_Numb from Contract_Finance where Contract_Finance_ID=@Fracid)", cs2);
                scd.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                rowsaffected = scd.ExecuteNonQuery();


                SqlCommand scd2 = new SqlCommand("delete from Finance_Invoice where Finance_Invoice_Contratct_Numb in (select Contract_Finance_Cont_Numb from Contract_Finance where Contract_Finance_ID=@Fracid)", cs2);
                scd2.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                rowsaffected = scd2.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in DeleteInvoiceOnEdit Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


    public static int UpdateContract_Fractional(string ResortF, string ResidenceNoF, string ResidenceTypeF, string FractionalInt, string FractEntitle, string FractFOccu, string FractDura, string FractLOccustring, string Fracid)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
             
                SqlCommand SqlCmd6 = new SqlCommand("update Contract_Fractional set Contract_Fractional_Resort='"+ ResortF + "',Contract_Fractional_Residence_No='"+ ResidenceNoF + "',Contract_Fractional_Residence_Type ='" + ResidenceTypeF + "',Contract_Fractional_Fractional_Int ='" + FractionalInt + "',Contract_Fractional_Entitle ='" + FractEntitle + "',Contract_Fractional_First_Occu ='" + FractFOccu + "',Contract_Fractional_Duration ='" + FractDura + "',Contract_Fractional_Last_Occu ='" + FractLOccustring + "' where Contract_Finance_ID=@Fracid", cs1);

                //SqlCmd6.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd6.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update UpdateContract_Fractional Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }


    public static int UpdateFracPS(string Deposit_PM, string DepositF, string AdmissFeesF, string AdminFeesF, string PurchasePriceF, string BalanceDuePAF, string PS_PA_No_Install, string PAFirstPayDateF, string PAAmountInstallF, string PAFirstInstallF, string BalanceDueDatesPAF, string RemarksF, string EuroRatesF, string AusRatesF, string GbpRatesF, string IdaRatesF, string PS_YOInterest, string Total_Balance, string PS_Date_Of_Insert, string Fracid, string InitDepof, string BalDepof,string DepoDatef,string BalanceDueDatesPAF2,string RemarksF2,string PS_CPA_Comment)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand SqlCmd6 = new SqlCommand("update Purchase_service set PS_Deposit_Pay_Method='"+ Deposit_PM + "',PS_Deposit='" + DepositF + "',PS_PA_Admission='" + AdmissFeesF + "',PS_PA_Administration='"+ AdminFeesF + "',PS_Total_Purchase='" + PurchasePriceF + "',PS_PA_Balance_Due='" + BalanceDuePAF + "',PS_PA_No_Install='" + PS_PA_No_Install + "',PS_PA_FInstall_Date=convert(datetime,'" + PAFirstPayDateF + "',105),PS_PA_Install_Amt='" + PAAmountInstallF + "',PS_PA_FInstall_Amt='" + PAFirstInstallF + "',PS_PA_Balance_Due_Dates='" + BalanceDueDatesPAF + "',PS_Remarks='" + RemarksF + "',PS_EURO_Rate='" + EuroRatesF + "',	PS_AUS_Rate='" + AusRatesF + "',	PS_GBP_Rate='" + GbpRatesF + "',	PS_IDA_Rate='" + IdaRatesF + "',PS_YOInterest='" + PS_YOInterest + "',Total_Balance='" + Total_Balance + "',PS_Date_Of_Insert='" + PS_Date_Of_Insert + "',PS_Initial_Deposit='" + InitDepof + "',PS_Bal_Deposit='" + BalDepof + "',PS_Deposit_Date=convert(datetime,'" + DepoDatef + "',105),PS_PA_Balance_Due_Dates2='" + BalanceDueDatesPAF2 + "',PS_Remarks2='" + RemarksF2 + "',PS_CPA_Comment='" + PS_CPA_Comment + "' where Contract_Finance_ID=@Fracid", cs1);

                //SqlCmd6.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd6.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update UpdateContract_Fractional Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }


    public static int UpdatePointPS(string Deposit_PM, string DepositP, string DepoPPA, string DepositSAP, string AdmissFeesP, string ApplicationFeesP, string AdminFeesP, string AdminServiceP, string PurchasePriceP, string TotalServicePriceP, string CoutryTaxP, string GrandTotalP, string BalanceDuePAP, string BalanceDueSAP, string PANoOfInstallP, string PAFirstPayDateP, string PAAmountInstallP, string PAFirstInstallP, string BalanceDueDatesPAP, string BalanceDueDatesSAP, string RemarksP, string TotalBalance, string EuroRatesF, string AusRatesF, string GbpRatesF, string IdaRatesF, string PS_YOInterest, string PS_Date_Of_Insert, string Fracid, string InitDepop, string BalDepop, string DepoDatep, string BalanceDueDatesPAP2, string BalanceDueDatesSAP2, string RemarksP2,string PS_CPA_Comment)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand SqlCmd6 = new SqlCommand("update Purchase_Service set PS_Deposit_Pay_Method='" + Deposit_PM + "',PS_Deposit='" + DepositP + "',PS_Deposit_PA='" + DepoPPA + "',PS_Deposit_SA='" + DepositSAP + "',PS_PA_Admission='" + AdmissFeesP + "',PS_SA_Application='" +  ApplicationFeesP + "',PS_PA_Administration='" + AdminFeesP  + "',PS_SA_Administration='" + AdminServiceP + "',PS_Total_Purchase='" + PurchasePriceP + "',PS_Total_Service='" + TotalServicePriceP + "',PS_Country_Tax='" + CoutryTaxP + "',PS_Grand_Total='" + GrandTotalP + "',PS_PA_Balance_Due='" + BalanceDuePAP + "',PS_SA_Balance_Due='" + BalanceDueSAP + "',PS_PA_No_Install='" + PANoOfInstallP + "',PS_PA_FInstall_Date=convert(datetime,'" + PAFirstPayDateP + "',105),PS_PA_Install_Amt='" + PAAmountInstallP + "',PS_PA_FInstall_Amt='" + PAFirstInstallP + "',PS_PA_Balance_Due_Dates='" + BalanceDueDatesPAP + "',PS_SA_Balance_Due_Dates='" + BalanceDueDatesSAP + "',PS_Remarks='" + RemarksP + "',PS_EURO_Rate='" + EuroRatesF + "',PS_AUS_Rate='" + AusRatesF + "',PS_GBP_Rate='" + GbpRatesF + "',PS_IDA_Rate='" + IdaRatesF + "',PS_YOInterest='" + PS_YOInterest + "',Total_Balance='" + TotalBalance + "',PS_Date_Of_Insert='" + PS_Date_Of_Insert + "',PS_Initial_Deposit='" + InitDepop + "',PS_Bal_Deposit='" + BalDepop + "',PS_Deposit_Date=convert(datetime,'" + DepoDatep + "',105),PS_PA_Balance_Due_Dates2='" + BalanceDueDatesPAP2 + "',PS_SA_Balance_Due_Dates2='" + BalanceDueDatesSAP2 + "',PS_Remarks2='" + RemarksP2 + "',PS_CPA_Comment='" + PS_CPA_Comment + "' where Contract_Finance_ID=@Fracid", cs1);

                //SqlCmd6.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd6.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update UpdateContract_Fractional Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }




    public static int UpdateContFrac(string affilice, string affilhp, string salesrep, string tomanager, string buttonup, string FinaCurrency, string PurchasePrice, string AdminFees, string MCFees, string DealDrawer, string PaymentMethod, string FinanceNumb, string ID_Card, string CrownCurr, string Fracid,string DealRegDate, string Contract_finance_OddEven, string Contract_finance_OddEven50, DateTime Contract_finance_Update_Date,int cweekno)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand SqlCmd6 = new SqlCommand("update Contract_Finance set Contract_Finance_Affil_ICE='"+ affilice + "',Contract_Finance_Affil_HP='" + affilhp + "',Contract_Finance_Sales_Rep='" + salesrep + "',Contract_Finance_TO_Manager='" + tomanager + "',Contract_Finance_Button_UP='" + buttonup + "',Contract_Finance_Currency='" + FinaCurrency + "',Contract_Finance_Purchase_Price='" + PurchasePrice + "',Contract_Finance_Admin_Fees='" + AdminFees + "',Contract_Finance_MC_Fees='" + MCFees + "',Contract_Finance_Deal_Drawer='" + DealDrawer + "',Contract_Finance_Payment_Method='" + PaymentMethod + "',Contract_Finance_Finance_Num='" + FinanceNumb + "',Contract_Finance_ID_Card='" + ID_Card + "',Contract_Finance_Crown_Curr='" + CrownCurr + "',Contract_Finance_Deal_Reg_Date='" + DealRegDate + "',Contract_finance_OddEven='" + Contract_finance_OddEven + "',Contract_finance_OddEven50='" + Contract_finance_OddEven50 + "',Contract_finance_Update_Date='" + Contract_finance_Update_Date + "',Contract_Finance_Week_No='" + cweekno + "' where Contract_Finance_ID=@Fracid", cs1);

                //SqlCmd6.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd6.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Update UpdateContFrac Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }


    public static int UpdateFinanceDetails(string tPurchase1, string QDepo1 , string AmtCre1 , string CreCurr1 , string NoOfMonth1 , string RateOfInt1, string MonthlyRepay1, string Fracid, string Finance_Details_Monthly_Repay2, string Finance_Details_Monthly_RepayProtect, string Finance_Details_PayProtect, string Finance_Details_Finance_Date)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand SqlCmd6 = new SqlCommand("update Finance_Details set Finance_Details_Total_Pur='"+ tPurchase1 + "',	Finance_Details_Qual_Depo='" + QDepo1 + "',	Finance_Details_Credit_Amount='" + AmtCre1 + "',	Finance_Details_Amount_Curr='" + CreCurr1 + "',	Finance_Details_No_Of_Month='" + NoOfMonth1 + "',	Finance_Details_Int_Rate='" + RateOfInt1 + "',	Finance_Details_Monthly_Repay='" + MonthlyRepay1 + "',Finance_Details_Monthly_Repay2='" + Finance_Details_Monthly_Repay2 + "',Finance_Details_Monthly_RepayProtect='" + Finance_Details_Monthly_RepayProtect + "',Finance_Details_PayProtect='" + Finance_Details_PayProtect + "',Finance_Details_Finance_Date=convert(datetime, '" + Finance_Details_Finance_Date + "', 105) where Contract_Finance_ID=@Fracid", cs1);

                //SqlCmd6.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd6.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update UpdateContFrac Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }

    public static int UpdateCT_Points(string NoofPoints, string PointsEntitle, string PointsMemFees, string PointsPropFees, string PointsFOccu, string PointsDura, string PointsLOccu,string Fracid)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand SqlCmd6 = new SqlCommand("update CT_Points set CT_Points_Entle='"+ PointsEntitle + "',	CT_Points_Member_fees='" + PointsMemFees + "',	CT_Points_Points_Property_fees='" + PointsPropFees + "',	CT_Points_FYear_Occ='" + PointsFOccu + "',	CT_Points_Duration='" + PointsDura + "',	CT_Points_LYear_Occ='" + PointsLOccu + "',CT_Points_Noof_Points='" + NoofPoints + "' where Contract_Finance_ID=@Fracid", cs1);

                //SqlCmd6.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
                //SqlCmd6.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update UpdateContFrac Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }



    public static int Update_Contract_TP(string ContResort, string AppartmentType, string NumbOccuTP, string ContPeriod, string ContSeason, string OldEntitle, string OldNoPoints,string NewPoints, string TotalPoints, string ContNewEntitle, string Memberfees, string PropertyFees, string FYOcc, string DurationTP, string LYOcc, string Fracid,string OldAgreeNo)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand SqlCmd6 = new SqlCommand("update Contract_TP set TP_Resort='" + ContResort + "',	TP_Appartment_Type='" + AppartmentType + "',	TP_Num_Occ='" + NumbOccuTP + "',	TP_Period='" + ContPeriod + "',	TP_Season='" + ContSeason + "',	TP_Old_Entitlement='" + OldEntitle + "',	TP_Old_Club='" + OldAgreeNo + "',	TP_Old_No_Points='" + OldNoPoints + "',	TP_New_No_Points='" + NewPoints + "',	TP_Total_Points='" + TotalPoints + "',	TP_New_Entitlement='" + ContNewEntitle + "',	TP_Member_Fees='" + Memberfees + "',	TP_Property_Fees='" + PropertyFees + "',	TP_FY_Occu='" + FYOcc + "',	TP_Duration='" + DurationTP + "',	TP_LY_Occu='" + LYOcc + "' where Contract_Finance_ID=@Fracid", cs1);
                
                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update Update_Contract_TP Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }


    public static int Update_Contract_TF(string OldAgreeNoTF, string OldClubTF, string OldNoOfPointsTF, string OldEntitleTF, string OldResortTF, string OldAppartTypeTF, string OldNoOccuTF, string OldPeriodTF, string OldSeasonTF, string OldResidenceNoTF, string OldResiTypeTF, string OldFracIntTF, string ResortTF, string ResidenceNoTF, string ResidenceTypeTF, string TFractionalInt, string TFractEntitle, string TFractFOccu, string TFractDura, string TFractLOccu, string Fracid)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand SqlCmd6 = new SqlCommand("update Contract_TF set TF_Old_Cont_Numb='" + OldAgreeNoTF + "',	TF_Old_Club='" + OldClubTF + "',	TF_Old_NoOf_Points='" + OldNoOfPointsTF + "',	TF_Old_Entitle='" + OldEntitleTF + "',	TF_Old_Resort='" + OldResortTF + "',	TF_Old_Apmnt_Type='" + OldAppartTypeTF + "',	TF_Old_No_Occu='" + OldNoOccuTF + "',	TF_Old_Period='" + OldPeriodTF + "',	TF_Old_Season='" + OldSeasonTF + "',	TF_Old_Resi_No='" + OldResidenceNoTF + "',	TF_Old_Resi_Type='" + OldResiTypeTF + "',	TF_Old_Frac_Int='" + OldFracIntTF + "',	TF_Resort='" + ResortTF + "',	TF_Resi_No='" + ResidenceNoTF + "',	TF_Resi_Type='" + ResidenceTypeTF + "',	TF_Frac_Int='" + TFractionalInt + "',	TF_Entitle='" + TFractEntitle + "',	TF_First_Occ='" + TFractFOccu + "',	TF_Duration='" + TFractDura + "',	TF_Last_Occ='" + TFractLOccu + "' where Contract_Finance_ID=@Fracid", cs1);

                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update UpdateContFrac Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }

    public static int Update_Finance_Details(string tPurchase1, string QDepo1, string AmtCre1, string CreCurr1, string NoOfMonth1, string RateOfInt1, string MonthlyRepay1, string Fracid, string Finance_Details_Monthly_Repay2, string Finance_Details_Monthly_RepayProtect, string Finance_Details_PayProtect, string Finance_Details_Finance_Date)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                
                SqlCommand SqlCmd6 = new SqlCommand("update Finance_Details set Finance_Details_Total_Pur='" + tPurchase1 + "' ,	Finance_Details_Qual_Depo='" + QDepo1 + "',	Finance_Details_Credit_Amount='" + AmtCre1 + "' ,	Finance_Details_Amount_Curr='" + CreCurr1 + "',	Finance_Details_No_Of_Month='" + NoOfMonth1 + "',	Finance_Details_Int_Rate='" + RateOfInt1 + "',	Finance_Details_Monthly_Repay='" + MonthlyRepay1 + "',Finance_Details_Monthly_Repay2='" + Finance_Details_Monthly_Repay2 + "',Finance_Details_Monthly_RepayProtect='" + Finance_Details_Monthly_RepayProtect + "',Finance_Details_PayProtect='" + Finance_Details_PayProtect + "',Finance_Details_Finance_Date=convert(datetime, '" + Finance_Details_Finance_Date + "', 105) where Contract_Finance_ID=@Fracid", cs1);

                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update UpdateContFrac Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }


    public static int checkforexistinginvoice(string midval)
    {

        //string startval;



        // int id = 0;
        //float val = 0;
       // double val = 0;

        int Pnumbnumb = 0;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            
               

            SqlCommand scd = new SqlCommand("select count(*) from Finance_Invoice where Finance_Invoice_Contratct_Numb in (select Contract_Finance_Cont_Numb from Contract_Finance where Contract_Finance_ID=@midval)", cs1);
            scd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            
            int cnt = (int)scd.ExecuteScalar();
            Pnumbnumb = cnt;

        }

        return Pnumbnumb;


    }


    public static int checkforexistingfinancedetails(string midval)
    {

        //string startval;



        // int id = 0;
        //float val = 0;
        // double val = 0;

        int Pnumbnumb = 0;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {


            
            SqlCommand scd = new SqlCommand("select count(*) from finance_details where Contract_Finance_ID =@midval", cs1);
            scd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;

            int cnt = (int)scd.ExecuteScalar();
            Pnumbnumb = cnt;

        }

        return Pnumbnumb;


    }




    public static string getcontnumbfromid(string midval)
    {

        //string startval;



        // int id = 0;
        //float val = 0;
        // double val = 0;

        string Pnumbnumb = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            SqlCommand scd = new SqlCommand("select Contract_Finance_Cont_Numb from Contract_Finance where Contract_Finance_ID=@midval", cs1);
            scd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;

            string cnt = (string)scd.ExecuteScalar();
            Pnumbnumb = cnt;

        }

        return Pnumbnumb;


    }


    public static DataSet LoadCancelReason()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select CR_Reasons from Cancel_reason where CR_Status = 'Active'", cs1);
            //SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static string GetStatusChangeID()
    {

        string startval;

        int year = DateTime.Now.Year;

        int id = 0;

        string finaiInstId = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scmd = new SqlCommand("select Status_Change_Start_Val from ID_Generation2 where ID_Year=@year", cs1);
            scmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            startval = (string)scmd.ExecuteScalar();

            SqlCommand scmd2 = new SqlCommand("select Status_Change_End_Val  from ID_Generation2 where ID_Year=@year", cs1);
            scmd2.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            int val  = (int)scmd2.ExecuteScalar();

            id = Convert.ToInt32(val);


            finaiInstId = startval+id;

            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return finaiInstId;


    }

    public static int InsertStatusChange(string SC_ID, string SC_Previous_Status, string SC_Updated_Status, string SC_Cancel_Group_Venue, string SC_Cancel_Reason, string SC_Cancel_Date, string SC_User, string Profile_ID, string Contract_Finance_ID, string SC_Update_Date)
    {
        int rowsAffected = 0;
        int year = DateTime.Now.Year;
        int id = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into status_change values(@SC_ID,@SC_Previous_Status,@SC_Updated_Status,@SC_Cancel_Group_Venue,@SC_Cancel_Reason,@SC_Cancel_Date,@SC_User,@Profile_ID,@Contract_Finance_ID,@SC_Update_Date)", cs1);
                da.InsertCommand.Parameters.Add("@SC_ID", SqlDbType.VarChar).Value = SC_ID;
                da.InsertCommand.Parameters.Add("@SC_Previous_Status", SqlDbType.VarChar).Value = SC_Previous_Status;
                da.InsertCommand.Parameters.Add("@SC_Updated_Status", SqlDbType.VarChar).Value = SC_Updated_Status;
                da.InsertCommand.Parameters.Add("@SC_Cancel_Group_Venue", SqlDbType.VarChar).Value = SC_Cancel_Group_Venue;
                da.InsertCommand.Parameters.Add("@SC_Cancel_Reason", SqlDbType.VarChar).Value = SC_Cancel_Reason;
                da.InsertCommand.Parameters.Add("@SC_Cancel_Date", SqlDbType.VarChar).Value = SC_Cancel_Date;
                da.InsertCommand.Parameters.Add("@SC_User", SqlDbType.VarChar).Value = SC_User;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Contract_Finance_ID", SqlDbType.VarChar).Value = Contract_Finance_ID;
                da.InsertCommand.Parameters.Add("@SC_Update_Date", SqlDbType.VarChar).Value = SC_Update_Date;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();

                SqlCommand scmd1 = new SqlCommand("select Status_Change_End_Val from ID_Generation2 where ID_Year=@year", cs1);
                scmd1.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int val = (int)scmd1.ExecuteScalar();

                id = Convert.ToInt32(val) + 1;

                SqlCommand scmd2 = new SqlCommand("update ID_Generation2 set Status_Change_End_Val ='" + id + "' where ID_Year=@year", cs1);
                //scmd2.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
                scmd2.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                int rows = scmd2.ExecuteNonQuery();



            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert ID_Generation2 Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }


    public static int Update_Status_change(string SC_Cancel_Group_Venue, string SC_Cancel_Reason, string SC_Cancel_Date,string curdate,string dealstat, string Fracid)
    {
        int rowsAffected = 0;
        //int incr1, id, incr3;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand SqlCmd6 = new SqlCommand("update status_change set SC_Cancel_Group_Venue='"+ SC_Cancel_Group_Venue + "',SC_Cancel_Reason='" + SC_Cancel_Reason + "',SC_Update_Date='" + curdate + "',SC_Cancel_Date='" + SC_Cancel_Date + "' where SC_ID in(select SC_ID from status_change where  SC_Update_Date in (select max(SC_Update_Date)as date from status_change where Contract_Finance_ID=@Fracid and SC_Updated_Status=@dealstat))", cs1);

                SqlCmd6.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
                SqlCmd6.Parameters.Add("@dealstat", SqlDbType.VarChar).Value = dealstat;
                int rows = SqlCmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in Update Update_Status_change Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }


        }
        return (rowsAffected);
    }

    public static DataSet LoadStatusChange(string Fracid, string dealstat)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from status_change where SC_ID in(select SC_ID from status_change where SC_Update_Date in (select max(SC_Update_Date) as date from status_change where Contract_Finance_ID = @Fracid and SC_Updated_Status = @dealstat))", cs1);
            SqlCmd.Parameters.Add("@Fracid", SqlDbType.VarChar).Value = Fracid;
            SqlCmd.Parameters.Add("@dealstat", SqlDbType.VarChar).Value = dealstat;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadSearchContract(string ContNumb)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Contract_Finance_Cont_Numb as ContractNo,cf.Profile_ID,pp.Profile_Primary_Fname+' '+pp.Profile_Primary_Lname as Name,Contract_Finance_Purchase_Price as [Total Purchase Price] ,Contract_Finance_Deal_Drawer as [Deal Status] from Contract_Finance cf join Profile_Primary pp on cf.Profile_ID = pp.Profile_ID join Email e on e.Profile_ID =pp.Profile_ID join Phone q on q.Profile_ID =pp.Profile_ID where (cf.Contract_Finance_Cont_Numb=@ContNumb or pp.Profile_ID = @ContNumb or pp.Profile_Primary_Fname like '%'+@ContNumb+'%' or pp.Profile_Primary_Lname like '%'+@ContNumb+'%' or e.Primary_Email like '%'+@ContNumb+'%' or q.Primary_Mobile like '%'+@ContNumb+'%')", cs1);
            SqlCmd.Parameters.Add("@ContNumb", SqlDbType.VarChar).Value = ContNumb;
            //SqlCmd.Parameters.Add("@dealstat", SqlDbType.VarChar).Value = dealstat;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }




    public static int checksubprofile(string sp, string Profile_ID)
    {



        //int year = DateTime.Now.Year;

        // int id = 0;
        int startval;

        int finaiInstId = 0;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            
            if (sp == "SP3")
            {

                SqlCommand scmd = new SqlCommand("select count(*) from Sub_Profile3 where Profile_ID = @Profile_ID", cs1);
                scmd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                startval = (int)scmd.ExecuteScalar();
                finaiInstId = startval;
            }
            else if (sp == "SP4")
            {
                SqlCommand scmd = new SqlCommand("select count(*) from Sub_Profile4 where Profile_ID = @Profile_ID", cs1);
                scmd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                startval = (int)scmd.ExecuteScalar();
                finaiInstId = startval;
            }
            else if (sp == "SP2")
            {
                SqlCommand scmd = new SqlCommand("select count(*) from Sub_Profile2 where Profile_ID = @Profile_ID", cs1);
                scmd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                startval = (int)scmd.ExecuteScalar();
                finaiInstId = startval;
            }
            else if (sp == "SP1")
            {
                SqlCommand scmd = new SqlCommand("select count(*) from Sub_Profile1 where Profile_ID = @Profile_ID", cs1);
                scmd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                startval = (int)scmd.ExecuteScalar();
                finaiInstId = startval;
            }
            else if (sp == "secondary")
            {
                SqlCommand scmd = new SqlCommand("select count(*) from Profile_Secondary where Profile_ID = @Profile_ID", cs1);
                scmd.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                startval = (int)scmd.ExecuteScalar();
                finaiInstId = startval;
            }

            //secondary select * from Profile_Secondary


            ////PProfileID = initial + startvalue + year + id;
            ////chek = id + 1;
            //SqlCommand sqlcmd = new SqlCommand("update Cont_ID_Gen set contval ='" + id + "' where contcat=@startval and contoffice=@midval", cs1);
            //scmd.Parameters.Add("@startval", SqlDbType.VarChar).Value = startval;
            //scmd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;
            // int rows = sqlcmd.ExecuteNonQuery();
        }

        return finaiInstId;


    }

    public static string getcontIDfromNo(string midval)
    {

        //string startval;



        // int id = 0;
        //float val = 0;
        // double val = 0;

        string Pnumbnumb = null;
        // string office;
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            SqlCommand scd = new SqlCommand("select Contract_Finance_ID from Contract_Finance where  Contract_Finance_Cont_Numb=@midval", cs1);
            scd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;

            string cnt = (string)scd.ExecuteScalar();
            Pnumbnumb = cnt;

        }

        return Pnumbnumb;


    }


    public static string getProfileIDfromNo(string midval)
    {

        

        string Pnumbnumb = null;
       
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            SqlCommand scd = new SqlCommand("select Profile_ID from Contract_Finance where  Contract_Finance_Cont_Numb=@midval", cs1);
            scd.Parameters.Add("@midval", SqlDbType.VarChar).Value = midval;

            string cnt = (string)scd.ExecuteScalar();
            Pnumbnumb = cnt;

        }

        return Pnumbnumb;


    }





    public static SqlDataReader getvpval()
    {
        SqlConnection cs1 = Queries.GetDBConnection();
        SqlCommand SqlCmd = new SqlCommand("select VP_ID from VPtestdetails", cs1);
        //SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;

        SqlDataReader dr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }


    public static int checkifVPexist(string vpid)
    {

        int Pnumbnumb = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd = new SqlCommand("select count(*) from Profile where VP_Id=@vpid", cs1);
            scd.Parameters.Add("@vpid", SqlDbType.VarChar).Value = vpid;

            int cnt = (int)scd.ExecuteScalar();
            Pnumbnumb = cnt;

        }

        return Pnumbnumb;


    }

    public static string getprofileidVP(string vpid)
    {

        string Pnumbnumb = null;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd = new SqlCommand("select Profile_ID from Profile where VP_Id=@vpid", cs1);
            scd.Parameters.Add("@vpid", SqlDbType.VarChar).Value = vpid;

            string cnt = (string)scd.ExecuteScalar();
            Pnumbnumb = cnt;

        }

        return Pnumbnumb;


    }



    public static int InsertTourDetailsVP(string Tour_Details_ID, string Tour_Details_Guest_Status, string Tour_Details_Guest_Sales_Rep, string Tour_Details_Tour_Date, string Tour_Details_Sales_Deck_Check_In, string Tour_Details_Sales_Deck_Check_Out, string Tour_Details_Taxi_In_Price, string Tour_Details_Taxi_In_Ref, string Tour_Details_Taxi_Out_Price, string Tour_Details_Taxi_Out_Ref,string Profile_Venue_Country,string Profile_Venue,string Profile_Group_Venue,string Profile_Marketing_Program,string Profile_Agent,string  Profile_Agent_Code,string SubVenue, string VP_Id, string Profile_ID)
    {
        int rowsAffected = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Tour_Details_VP values(@Tour_Details_ID,@Tour_Details_Guest_Status,@Tour_Details_Guest_Sales_Rep,@Tour_Details_Tour_Date,@Tour_Details_Sales_Deck_Check_In,	@Tour_Details_Sales_Deck_Check_Out,@Tour_Details_Taxi_In_Price,@Tour_Details_Taxi_In_Ref ,@Tour_Details_Taxi_Out_Price ,@Tour_Details_Taxi_Out_Ref,@Profile_Venue_Country,	@Profile_Venue,	@Profile_Group_Venue,	@Profile_Marketing_Program,	@Profile_Agent,	@Profile_Agent_Code,	@SubVenue,	@VP_Id, @Profile_ID)", cs2);
                da.InsertCommand.Parameters.Add("@Tour_Details_ID ", SqlDbType.VarChar).Value = Tour_Details_ID;
                da.InsertCommand.Parameters.Add("@Tour_Details_Guest_Status ", SqlDbType.VarChar).Value = Tour_Details_Guest_Status;
                da.InsertCommand.Parameters.Add("@Tour_Details_Guest_Sales_Rep ", SqlDbType.VarChar).Value = Tour_Details_Guest_Sales_Rep;
                da.InsertCommand.Parameters.Add("@Tour_Details_Tour_Date ", SqlDbType.VarChar).Value = Tour_Details_Tour_Date;
                da.InsertCommand.Parameters.Add("@Tour_Details_Sales_Deck_Check_In ", SqlDbType.VarChar).Value = Tour_Details_Sales_Deck_Check_In;
                da.InsertCommand.Parameters.Add("@Tour_Details_Sales_Deck_Check_Out ", SqlDbType.VarChar).Value = Tour_Details_Sales_Deck_Check_Out;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_In_Price ", SqlDbType.VarChar).Value = Tour_Details_Taxi_In_Price;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_In_Ref ", SqlDbType.VarChar).Value = Tour_Details_Taxi_In_Ref;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_Out_Price ", SqlDbType.VarChar).Value = Tour_Details_Taxi_Out_Price;
                da.InsertCommand.Parameters.Add("@Tour_Details_Taxi_Out_Ref ", SqlDbType.VarChar).Value = Tour_Details_Taxi_Out_Ref;

                
                da.InsertCommand.Parameters.Add("@Profile_Venue_Country ", SqlDbType.VarChar).Value = Profile_Venue_Country;
                da.InsertCommand.Parameters.Add("@Profile_Venue ", SqlDbType.VarChar).Value = Profile_Venue;
                da.InsertCommand.Parameters.Add("@Profile_Group_Venue ", SqlDbType.VarChar).Value = Profile_Group_Venue;
                da.InsertCommand.Parameters.Add("@Profile_Marketing_Program ", SqlDbType.VarChar).Value = Profile_Marketing_Program;
                da.InsertCommand.Parameters.Add("@Profile_Agent ", SqlDbType.VarChar).Value = Profile_Agent;
                da.InsertCommand.Parameters.Add("@Profile_Agent_Code ", SqlDbType.VarChar).Value = Profile_Agent_Code;
                da.InsertCommand.Parameters.Add("@SubVenue ", SqlDbType.VarChar).Value = SubVenue;
                da.InsertCommand.Parameters.Add("@VP_Id ", SqlDbType.VarChar).Value = VP_Id;

                da.InsertCommand.Parameters.Add("@Profile_ID ", SqlDbType.VarChar).Value = Profile_ID;
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Tour Details Query " + ex.Message);

                string msg = "Error in Insert Tour Details VP Query" + " " + ex.Message;

                throw new Exception("transction: " + msg, ex);


            }
        }
        return (rowsAffected);
    }


    public static DataSet LoadVPDetails(string vpid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select * from VPtestdetails where vp_id=@vpid", cs1);
            SqlCmd.Parameters.Add("@vpid", SqlDbType.VarChar).Value = vpid;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }



    public static DataSet LoadQStatus()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Qstatus_Name from Qstatus where Qstatus_Status = 'Active' order by 1", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }



    public static int InsertIntoContractAudit(string Profile_ID, string Contract_No, string Fname, string Lname, string ContCreateDate, string ProcessDate)
    {
        int rowsAffected = 0;

       
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into Contract_Audit1 values(@Profile_ID,@Contract_No,@Fname,@Lname,@ContCreateDate,@ProcessDate)", cs1);
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@Contract_No", SqlDbType.VarChar).Value = Contract_No;
                da.InsertCommand.Parameters.Add("@Fname", SqlDbType.VarChar).Value = Fname;
                da.InsertCommand.Parameters.Add("@Lname", SqlDbType.VarChar).Value = Lname;
                da.InsertCommand.Parameters.Add("@ContCreateDate", SqlDbType.VarChar).Value = ContCreateDate;
                da.InsertCommand.Parameters.Add("@ProcessDate", SqlDbType.VarChar).Value = ProcessDate;
            
                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in insert InsertIntoContractAudit Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                throw;
            }
        }
        return (rowsAffected);
    }


    public static int UpdateProfile(string ProfileID, string Profile_Venue_Country, string Profile_Venue, string Profile_Group_Venue, string Profile_Marketing_Program, string Profile_Agent, string Profile_Agent_Code, string Profile_Member_Type1, string Profile_Member_Number1, string Profile_Member_Type2, string Profile_Member_Number2, string Profile_Employment_status, string Profile_Marital_status, string Profile_NOY_Living_as_couple, string manager, string Photo_identity, string Card_Holder, string Comments, string reception, string SubVenue, string regTerms,string VP_ID, string regTerms2,string Secondemploymentstatus, string Leadsource, string Pre_Arrival,string verifi)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Profile  SET Profile_Venue_Country= '" + Profile_Venue_Country + "',	Profile_Venue= '" + Profile_Venue + "',	Profile_Group_Venue= '" + Profile_Group_Venue + "',	Profile_Marketing_Program= '" + Profile_Marketing_Program + "',	Profile_Agent= '" + Profile_Agent + "',	Profile_Agent_Code= '" + Profile_Agent_Code + "',	Profile_Member_Type1= '" + Profile_Member_Type1 + "',	Profile_Member_Number1= '" + Profile_Member_Number1 + "',	Profile_Member_Type2= '" + Profile_Member_Type2 + "',	Profile_Member_Number2= '" + Profile_Member_Number2 + "',	Profile_Employment_status= '" + Profile_Employment_status + "',	Profile_Marital_status= '" + Profile_Marital_status + "',	Profile_NOY_Living_as_couple= '" + Profile_NOY_Living_as_couple + "',	manager= '" + manager + "',	Photo_identity= '" + Photo_identity + "',	Card_Holder= '" + Card_Holder + "',Comments='" + Comments + "',Reception='" + reception + "', SubVenue='" + SubVenue + "',RegTerms='" + regTerms + "',RegTerms2='" + regTerms2 + "',VP_ID='" + VP_ID + "',Secondary_Employment_Status='" + Secondemploymentstatus + "',Lead_Source='" + Leadsource + "',Pre_Arrival='" + Pre_Arrival + "',Verification='" + verifi + "' where Profile_ID ='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile Query " + ex.Message);

                string msg = "Error in UPDATE Profile Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateProfilePrimary(string ProfileID, string Profile_Primary_Title, string Profile_Primary_Fname, string Profile_Primary_Lname, string Profile_Primary_DOB, string Profile_Primary_Nationality, string Profile_Primary_Country, string Primary_Age, string Primary_Designation, string Primary_Language)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Primary SET  Profile_Primary_Title='" + Profile_Primary_Title + "',Profile_Primary_Fname='" + Profile_Primary_Fname + "',Profile_Primary_Lname='" + Profile_Primary_Lname + "',Profile_Primary_DOB= convert(datetime,'" + Profile_Primary_DOB + "',105),Profile_Primary_Nationality='" + Profile_Primary_Nationality + "',Profile_Primary_Country='" + Profile_Primary_Country + "',Primary_Age='" + Primary_Age + "',Primary_Designation='" + Primary_Designation + "',Primary_Language='" + Primary_Language + "'where Profile_ID='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Profile_Primary Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Primary Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


    public static int UpdateProfileSecondary(string ProfileID, string Profile_Secondary_Title, string Profile_Secondary_Fname, string Profile_Secondary_Lname, string Profile_Secondary_DOB, string Profile_Secondary_Nationality, string Profile_Secondary_Country, string Secondary_Age, string Secondary_Designation, string Secondary_Language)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Secondary SET  Profile_Secondary_Title='" + Profile_Secondary_Title + "',Profile_Secondary_Fname='" + Profile_Secondary_Fname + "',Profile_Secondary_Lname='" + Profile_Secondary_Lname + "',Profile_Secondary_DOB= convert(datetime,'" + Profile_Secondary_DOB + "',105),Profile_Secondary_Nationality='" + Profile_Secondary_Nationality + "',Profile_Secondary_Country='" + Profile_Secondary_Country + "',Secondary_Age='" + Secondary_Age + "',Secondary_Designation='" + Secondary_Designation + "',Secondary_Language='" + Secondary_Language + "'where Profile_ID='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Profile_Secondary Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Secondary Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


    public static int UpdateSubProfile1(string ProfileID, string Sub_Profile1_Title, string Sub_Profile1_Fname, string Sub_Profile1_Lname, string Sub_Profile1_DOB, string Sub_Profile1_Nationality, string Sub_Profile1_Country, string Sub_Profile1_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {

                SqlCommand scd = new SqlCommand("update Sub_Profile1 SET  Sub_Profile1_Title='" + Sub_Profile1_Title + "',Sub_Profile1_Fname='" + Sub_Profile1_Fname + "',Sub_Profile1_Lname='" + Sub_Profile1_Lname + "',Sub_Profile1_DOB=convert(datetime,'" + Sub_Profile1_DOB + "',105),Sub_Profile1_Nationality='" + Sub_Profile1_Nationality + "',Sub_Profile1_Country='" + Sub_Profile1_Country + "',Sub_Profile1_Age='" + Sub_Profile1_Age + "'where Profile_ID='" + ProfileID + "'", cs1);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile1 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile1 Query  " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


    public static int UpdateSubProfile2(string ProfileID, string Sub_Profile2_Title, string Sub_Profile2_Fname, string Sub_Profile2_Lname, string Sub_Profile2_DOB, string Sub_Profile2_Nationality, string Sub_Profile2_Country, string Sub_Profile2_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Sub_Profile2 SET  Sub_Profile2_Title='" + Sub_Profile2_Title + "',Sub_Profile2_Fname='" + Sub_Profile2_Fname + "',Sub_Profile2_Lname='" + Sub_Profile2_Lname + "',Sub_Profile2_DOB=convert(datetime,'" + Sub_Profile2_DOB + "',105),Sub_Profile2_Nationality='" + Sub_Profile2_Nationality + "',Sub_Profile2_Country='" + Sub_Profile2_Country + "',Sub_Profile2_Age='" + Sub_Profile2_Age + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile2 Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateSubProfile3(string ProfileID, string Sub_Profile3_Title, string Sub_Profile3_Fname, string Sub_Profile3_Lname, string Sub_Profile3_DOB, string Sub_Profile3_Nationality, string Sub_Profile3_Country, string Sub_Profile3_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Sub_Profile3 SET  Sub_Profile3_Title='" + Sub_Profile3_Title + "',Sub_Profile3_Fname='" + Sub_Profile3_Fname + "',Sub_Profile3_Lname='" + Sub_Profile3_Lname + "',Sub_Profile3_DOB=convert(datetime,'" + Sub_Profile3_DOB + "',105),Sub_Profile3_Nationality='" + Sub_Profile3_Nationality + "',Sub_Profile3_Country='" + Sub_Profile3_Country + "',Sub_Profile3_Age='" + Sub_Profile3_Age + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile3 Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateSubProfile4(string ProfileID, string Sub_Profile4_Title, string Sub_Profile4_Fname, string Sub_Profile4_Lname, string Sub_Profile4_DOB, string Sub_Profile4_Nationality, string Sub_Profile4_Country, string Sub_Profile4_Age)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Sub_Profile4 SET  Sub_Profile4_Title='" + Sub_Profile4_Title + "',Sub_Profile4_Fname='" + Sub_Profile4_Fname + "',Sub_Profile4_Lname='" + Sub_Profile4_Lname + "',Sub_Profile4_DOB=convert(datetime,'" + Sub_Profile4_DOB + "',105),Sub_Profile4_Nationality='" + Sub_Profile4_Nationality + "',Sub_Profile4_Country='" + Sub_Profile4_Country + "',Sub_Profile4_Age='" + Sub_Profile4_Age + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Sub_Profile2 Query " + ex.Message);

                string msg = "Error in UPDATE Sub_Profile4 Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }



    public static int UpdateProfileAddress(string ProfileID, string Profile_Address_Line1, string Profile_Address_Line2, string Profile_Address_State, string Profile_Address_city, string Profile_Address_Postcode, string acountry)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())
        {
            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Address SET  Profile_Address_Line1='" + Profile_Address_Line1 + "',Profile_Address_Line2='" + Profile_Address_Line2 + "',Profile_Address_State='" + Profile_Address_State + "',Profile_Address_city='" + Profile_Address_city + "',Profile_Address_Postcode='" + Profile_Address_Postcode + "',Profile_Address_Country='" + acountry + "'where Profile_ID='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile_Address Query " + ex.Message);

                string msg = "Error in UPDATE Profile_Address Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }



    public static int UpdatePhone(string ProfileID, string Primary_CC, string Primary_Mobile, string Primary_Alt_CC, string Primary_Alternate, string Secondary_CC, string Secondary_Mobile, string Secondary_Alt_CC, string Secondary_Alternate, string Subprofile1_CC, string Subprofile1_Mobile, string Subprofile1_Alt_CC, string Subprofile1_Alternate, string Subprofile2_CC, string Subprofile2_Mobile, string Subprofile2_Alt_CC, string Subprofile2_Alternate, string Subprofile3_CC, string Subprofile3_Mobile, string Subprofile4_CC, string Subprofile4_Mobile, string Subprofile3_Alt_CC, string Subprofile3_Alternate, string Subprofile4_Alt_CC, string Subprofile4_Alternate)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {
            try
            {

                SqlCommand scd = new SqlCommand("update Phone SET Primary_CC= '" + Primary_CC + "',Primary_Mobile='" + Primary_Mobile + "',	Primary_Alt_CC='" + Primary_Alt_CC + "',	Primary_Alternate='" + Primary_Alternate + "',	Secondary_CC='" + Secondary_CC + "',	Secondary_Mobile='" + Secondary_Mobile + "',	Secondary_Alt_CC='" + Secondary_Alt_CC + "',	Secondary_Alternate='" + Secondary_Alternate + "',	Subprofile1_CC='" + Subprofile1_CC + "',	Subprofile1_Mobile='" + Subprofile1_Mobile + "',	Subprofile1_Alt_CC='" + Subprofile1_Alt_CC + "',	Subprofile1_Alternate='" + Subprofile1_Alternate + "',	Subprofile2_CC='" + Subprofile2_CC + "',	Subprofile2_Mobile='" + Subprofile2_Mobile + "',	Subprofile2_Alt_CC='" + Subprofile2_Alt_CC + "',	Subprofile2_Alternate='" + Subprofile2_Alternate + "',	Subprofile3_CC='" + Subprofile3_CC + "',	Subprofile3_Mobile='" + Subprofile3_Mobile + "',	Subprofile3_Alt_CC='" + Subprofile3_Alt_CC + "',	Subprofile3_Alternate='" + Subprofile3_Alternate + "',	Subprofile4_CC='" + Subprofile4_CC + "',	Subprofile4_Mobile='" + Subprofile4_Mobile + "',	Subprofile4_Alt_CC='" + Subprofile4_Alt_CC + "',	Subprofile4_Alternate='" + Subprofile4_Alternate + "'  where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Phone Query " + ex.Message);
                string msg = "Error in UPDATE Phone Query" + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }





    public static int UpdateEmail(string ProfileID, string Primary_Email, string Secondary_Email, string Subprofile1_Email, string Subprofile2_Email, string Primary_Email2, string Secondary_Email2, string Subprofile1_Email2, string Subprofile2_Email2, string Subprofile3_Email, string Subprofile3_Email2, string Subprofile4_Email, string Subprofile4_Email2)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {
                SqlCommand scd = new SqlCommand("update Email SET Primary_Email= '" + Primary_Email + "',	Secondary_Email= '" + Secondary_Email + "',	Subprofile1_Email= '" + Subprofile1_Email + "',	Subprofile2_Email= '" + Subprofile2_Email + "', Primary_Email2= '" + Primary_Email2 + "',	Secondary_Email2= '" + Secondary_Email2 + "',	Subprofile1_Email2= '" + Subprofile1_Email2 + "',	Subprofile2_Email2= '" + Subprofile2_Email2 + "',	Subprofile3_Email= '" + Subprofile3_Email + "',	Subprofile3_Email2= '" + Subprofile3_Email2 + "',	Subprofile4_Email= '" + Subprofile4_Email + "',	Subprofile4_Email2= '" + Subprofile4_Email2 + "' where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in UPDATE Email Query " + ex.Message);

                string msg = "Error in UPDATE Email Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }

    public static int UpdateProfileStay(string ProfileID, string Profile_Stay_Resort_Name, string Profile_Stay_Resort_Room_Number, string Profile_Stay_Arrival_Date, string Profile_Stay_Departure_Date)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {
                SqlCommand scd = new SqlCommand("update Profile_Stay SET  Profile_Stay_Resort_Name= '" + Profile_Stay_Resort_Name + "',Profile_Stay_Resort_Room_Number = '" + Profile_Stay_Resort_Room_Number + "',Profile_Stay_Arrival_Date = convert(datetime,'" + Profile_Stay_Arrival_Date + "',105),Profile_Stay_Departure_Date = convert(datetime,'" + Profile_Stay_Departure_Date + "',105) where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // MessageBox.Show("Error in UPDATE Profile_Stay Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
                string msg = "Error in UPDATE Profile_Stay Query " + " " + ex.Message;

                throw new Exception(msg, ex);
            }
        }
        return (rowsaffected);
    }

    //public static int UpdateTourDetails(string ProfileID, string Tour_Details_Guest_Status, string Tour_Details_Guest_Sales_Rep, string Tour_Details_Tour_Date, string Tour_Details_Sales_Deck_Check_In, string Tour_Details_Sales_Deck_Check_Out, string Tour_Details_Taxi_In_Price, string Tour_Details_Taxi_In_Ref, string Tour_Details_Taxi_Out_Price, string Tour_Details_Taxi_Out_Ref, string QualiStatus)
    //{
    //    int rowsaffected = 0;
    //    using (SqlConnection cs2 = Queries.GetDBConnection())

    //    {

    //        try
    //        {

    //            SqlCommand scd = new SqlCommand("update Tour_Details SET  Tour_Details_Guest_Status= '" + Tour_Details_Guest_Status + "',	Tour_Details_Guest_Sales_Rep= '" + Tour_Details_Guest_Sales_Rep + "',	Tour_Details_Tour_Date= convert(datetime,'" + Tour_Details_Tour_Date + "',105),	Tour_Details_Sales_Deck_Check_In= '" + Tour_Details_Sales_Deck_Check_In + "',	Tour_Details_Sales_Deck_Check_Out= '" + Tour_Details_Sales_Deck_Check_Out + "',	Tour_Details_Taxi_In_Price= '" + Tour_Details_Taxi_In_Price + "',	Tour_Details_Taxi_In_Ref= '" + Tour_Details_Taxi_In_Ref + "',	Tour_Details_Taxi_Out_Price= '" + Tour_Details_Taxi_Out_Price + "',	Tour_Details_Taxi_Out_Ref= '" + Tour_Details_Taxi_Out_Ref + "',	Tour_Details_Qualified_Status= '" + QualiStatus + "'where Profile_ID ='" + ProfileID + "'", cs2);
    //            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
    //            rowsaffected = scd.ExecuteNonQuery();

    //        }
    //        catch (Exception ex)
    //        {

    //            MessageBox.Show("Error in UPDATE Tour_Details Query " + ex.Message);

    //            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
    //        }
    //    }
    //    return (rowsaffected);
    //}


    public static int UpdateTourDetails(string ProfileID, string Tour_Details_Guest_Status, string Tour_Details_Guest_Sales_Rep, string Tour_Details_Tour_Date, string Tour_Details_Sales_Deck_Check_In, string Tour_Details_Sales_Deck_Check_Out, string Tour_Details_Taxi_In_Price, string Tour_Details_Taxi_In_Ref, string Tour_Details_Taxi_Out_Price, string Tour_Details_Taxi_Out_Ref, string QualiStatus, int Week_number)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {

            try
            {

                SqlCommand scd = new SqlCommand("update Tour_Details SET  Tour_Details_Guest_Status= '" + Tour_Details_Guest_Status + "',	Tour_Details_Guest_Sales_Rep= '" + Tour_Details_Guest_Sales_Rep + "',	Tour_Details_Tour_Date=convert(datetime, '" + Tour_Details_Tour_Date + "',105),	Tour_Details_Sales_Deck_Check_In= '" + Tour_Details_Sales_Deck_Check_In + "',	Tour_Details_Sales_Deck_Check_Out= '" + Tour_Details_Sales_Deck_Check_Out + "',	Tour_Details_Taxi_In_Price= '" + Tour_Details_Taxi_In_Price + "',	Tour_Details_Taxi_In_Ref= '" + Tour_Details_Taxi_In_Ref + "',	Tour_Details_Taxi_Out_Price= '" + Tour_Details_Taxi_Out_Price + "',	Tour_Details_Taxi_Out_Ref= '" + Tour_Details_Taxi_Out_Ref + "',	Tour_Details_Qualified_Status= '" + QualiStatus + "',	Week_number= '" + Week_number + "'where Profile_ID ='" + ProfileID + "'", cs2);
                scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                rowsaffected = scd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in UPDATE Tour_Details Query " + ex.Message);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }



    public static DataTable loadDGR(string Proce, string date, string office, string venue)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // string endv;
            //SqlCommand SqlCmd4 = new SqlCommand("select procedureName from printpdf where Printpdf_Name=@fname and Printpdf_Office=@office", cs1);
            //SqlCmd4.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            //SqlCmd4.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            ////SqlCmd4.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
            //endv = (string)SqlCmd4.ExecuteScalar();


            //string test1 = endv;

            SqlCommand cmd_sp = new SqlCommand(Proce, cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", date);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            // using (SqlCommand cmd = new SqlCommand())
            // {
            // cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandText = "holiday_confirm";
            // cmd.Parameters.AddWithValue("@booking_id", booking_id);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }




    public static DataTable loadDGRBali(string date, string office, string venue)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // string endv;
            //SqlCommand SqlCmd4 = new SqlCommand("select procedureName from printpdf where Printpdf_Name=@fname and Printpdf_Office=@office", cs1);
            //SqlCmd4.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            //SqlCmd4.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            ////SqlCmd4.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
            //endv = (string)SqlCmd4.ExecuteScalar();


            //string test1 = endv;

            SqlCommand cmd_sp = new SqlCommand("DGR1", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", date);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            // using (SqlCommand cmd = new SqlCommand())
            // {
            // cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandText = "holiday_confirm";
            // cmd.Parameters.AddWithValue("@booking_id", booking_id);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }





    //public static DataTable loadDGRBali(string date, string office, string venue)
    //{

    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {

    //        // string endv;
    //        //SqlCommand SqlCmd4 = new SqlCommand("select procedureName from printpdf where Printpdf_Name=@fname and Printpdf_Office=@office", cs1);
    //        //SqlCmd4.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
    //        //SqlCmd4.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
    //        ////SqlCmd4.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
    //        //endv = (string)SqlCmd4.ExecuteScalar();


    //        //string test1 = endv;

    //        SqlCommand cmd_sp = new SqlCommand("DGR1", cs1);
    //        // cmd.CommandText = "holiday_confirm";
    //        cmd_sp.CommandType = CommandType.StoredProcedure;
    //        cmd_sp.Parameters.AddWithValue("@DATE", date);
    //        cmd_sp.Parameters.AddWithValue("@office", office);
    //        cmd_sp.Parameters.AddWithValue("@venue", venue);
    //        // using (SqlCommand cmd = new SqlCommand())
    //        // {
    //        // cmd.CommandType = CommandType.StoredProcedure;
    //        // cmd.CommandText = "holiday_confirm";
    //        // cmd.Parameters.AddWithValue("@booking_id", booking_id);

    //        SqlDataAdapter da = new SqlDataAdapter();
    //        da.SelectCommand = cmd_sp;
    //        DataTable datatable = new DataTable();
    //        da.Fill(datatable);
    //        return datatable;

    //    }

    //}


    public static int CheckProfileID(string ProfileID)
    {

        int Pnumbnumb = 0;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            SqlCommand scd = new SqlCommand("select Count(*) from Profile where Profile_ID=@ProfileID", cs1);
            scd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;

            int cnt = (int)scd.ExecuteScalar();
            Pnumbnumb = cnt;

        }

        return Pnumbnumb;


    }



    public static int GetWkNumber(string dtDate)
    {
        int returnNumber = 0;
        try
        {

            DateTime d;
            if (DateTime.TryParseExact(dtDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out d))
            {
                // use d
            }



            CultureInfo ciGetNumber = CultureInfo.CurrentCulture;
            // returnNumber = ciGetNumber.Calendar.GetWeekOfYear(dtDate, CalendarWeekRule.FirstDay, DayOfWeek.Friday);
            returnNumber = ciGetNumber.Calendar.GetWeekOfYear(d, CalendarWeekRule.FirstFullWeek, DayOfWeek.Saturday);
        }
        catch (System.FormatException fe)
        {
            // MessageBox.Show("Exception occurred in " + fe);

        }
        return returnNumber;

    }


    public static int UserExists(string email)
    {
        int user, ch;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand sqcmd = new SqlCommand("select count(*) from users where Email=@email and userstatus='Active'", cs1);
            sqcmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            ch = (int)sqcmd.ExecuteScalar();
            if (ch == 1)
            {
                user = 1;
            }
            else
            {
                user = 0;
            }
        }
        return user;
    }


    public static string getusername(string email)
    {
        string user, ch;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand sqcmd = new SqlCommand("select username from users where Email=@email and userstatus='Active'", cs1);
            sqcmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            ch = (string)sqcmd.ExecuteScalar();
            //if (ch == 1)
            //{
            //    user = 1;
            //}
            //else
            //{
            //    user = 0;
            //}
            user = ch;
        }
        return user;
    }



    public static DataSet LoadSMSReciever()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            //SqlCommand SqlCmd = new SqlCommand(" select distinct Venue_Name from Venue where Venue_Status='active' and Venue_Name  not in(select Profile_Venue   from Profile where Profile_ID=@ProfileID) ", cs1);
            SqlCommand SqlCmd = new SqlCommand("select SMS_Reciever,SMS_Mobile from SMSReciever where SMS_Status='Active'", cs1);
            //SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            //SqlCmd.Parameters.Add("@country", SqlDbType.VarChar).Value = country;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static int InsertGiftOption(string Gift_ID, string Gift_ID_Option, string Gift_Voucher_numb, string Gift_Comment, string Profile_ID, string GiftItem, string GiftPrice)
    {
        int rowsAffected = 0;

        
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            try
            {
                int price = int.Parse(GiftPrice, NumberStyles.Number);

                da.InsertCommand = new SqlCommand("insert into Gift values(@Gift_ID,	@Gift_ID_Option,@Gift_Voucher_numb,	@Gift_Comment,@Profile_ID,@GiftItem,@GiftPrice)", cs1);
                da.InsertCommand.Parameters.Add("@Gift_ID", SqlDbType.VarChar).Value = Gift_ID;
                da.InsertCommand.Parameters.Add("@Gift_ID_Option", SqlDbType.VarChar).Value = Gift_ID_Option;
                da.InsertCommand.Parameters.Add("@Gift_Voucher_numb", SqlDbType.VarChar).Value = Gift_Voucher_numb;
                da.InsertCommand.Parameters.Add("@Gift_Comment", SqlDbType.VarChar).Value = Gift_Comment;
                da.InsertCommand.Parameters.Add("@Profile_ID", SqlDbType.VarChar).Value = Profile_ID;
                da.InsertCommand.Parameters.Add("@GiftItem", SqlDbType.VarChar).Value = GiftItem;
                da.InsertCommand.Parameters.Add("@GiftPrice", SqlDbType.Int).Value = price;

                rowsAffected = da.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Insert Gift Query " + ex.Message);

                string msg = "Error in Insert Gift Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsAffected);
    }


    public static DataSet LoadSalutations(string office)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Salutation from Salutations where status='active' and office='"+office+"' order by 1", cs1);

            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodePrimaryMobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            //SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Primary_CC from phone where profile_id=@ProfileID) order by COrder desc ", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Primary_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodePrimaryAlt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            //SqlCommand SqlCmd = new SqlCommand("select country_code as name from country where country_code not in(select Primary_Alt_CC from phone where profile_id=@ProfileID) order by COrder desc ", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Primary_Alt_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodeSecondaryMobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Secondary_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodeSecondaryAlt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Secondary_Alt_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }
    public static DataSet LoadCountryWithCodeSP1Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Subprofile1_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodeSP1Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Subprofile1_Alt_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodeSP2Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Subprofile2_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodeSP2Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Subprofile2_Alt_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountryWithCodeSP3Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Subprofile3_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodeSP3Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Subprofile3_Alt_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadCountryWithCodeSP4Mobile(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Subprofile4_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc ", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadCountryWithCodeSP4Alt(string ProfileID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            //  SqlCommand SqlCmd = new SqlCommand("select country_code+' '+country_name as name from country order by 1", cs1);
            SqlCommand SqlCmd = new SqlCommand("select country_code+'  '+Country_Name as name from country where country_code not in(select Subprofile4_Alt_CC from phone where profile_id=@ProfileID) order by COrder desc,Country_Name asc", cs1);
            SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadSubVenue(string venue1, string subvenue)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select SVenue_Name from Sub_Venue where Venue_ID in (select Venue_ID from venue where Venue_Name=@venue) and SVenue_Name <> '"+ subvenue + "' and SVenue_Status='Active'", cs1);
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue1;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);

    }


    public static DataSet LoadNationalityWithoutPrevValPrimary(string Profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Nationality_Name from Nationality where Nationality_name not in(select Profile_Primary_Nationality from Profile_Primary where profile_id='"+Profile_ID+ "') order by orders desc,Nationality_Name asc", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadNationalityWithoutPrevValSecondary(string Profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Nationality_Name from Nationality where Nationality_name not in(select Profile_Secondary_Nationality from Profile_Secondary where profile_id='" + Profile_ID + "') order by orders desc,Nationality_Name asc", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadNationalityWithoutPrevValSP1(string Profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Nationality_Name from Nationality where Nationality_name not in(select Sub_Profile1_Nationality from Sub_Profile1 where profile_id='" + Profile_ID + "') order by orders desc,Nationality_Name asc", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadNationalityWithoutPrevValSP2(string Profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Nationality_Name from Nationality where Nationality_name not in(select Sub_Profile2_Nationality from Sub_Profile2 where profile_id='" + Profile_ID + "') order by orders desc,Nationality_Name asc", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadNationalityWithoutPrevValSP3(string Profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Nationality_Name from Nationality where Nationality_name not in(select Sub_Profile3_Nationality from Sub_Profile3 where profile_id='" + Profile_ID + "') order by orders desc,Nationality_Name asc", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadNationalityWithoutPrevValSP4(string Profile_ID)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select  Nationality_Name from Nationality where Nationality_name not in(select Sub_Profile4_Nationality from Sub_Profile4 where profile_id='" + Profile_ID + "') order by orders desc,Nationality_Name asc", cs1);
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }



    public static DataSet LoadCountryPrevVal(string ProfileID,string subprofile)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            if(subprofile == "SP1")
            {
                SqlCommand SqlCmd = new SqlCommand("select country_name from country where country_name not in(select Sub_Profile1_Country  from Sub_Profile1 where Profile_ID = @ProfileID) order by COrder desc, Country_Name", cs1);
                SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            else if(subprofile == "SP2")
            {
                SqlCommand SqlCmd = new SqlCommand("select country_name from country where country_name not in(select Sub_Profile2_Country  from Sub_Profile2 where Profile_ID = @ProfileID) order by COrder desc, Country_Name", cs1);
                SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            else if (subprofile == "SP3")
            {
                SqlCommand SqlCmd = new SqlCommand("select country_name from country where country_name not in(select Sub_Profile3_Country  from Sub_Profile3 where Profile_ID = @ProfileID) order by COrder desc, Country_Name", cs1);
                SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            else if (subprofile == "SP4")
            {
                SqlCommand SqlCmd = new SqlCommand("select country_name from country where country_name not in(select Sub_Profile4_Country  from Sub_Profile4 where Profile_ID = @ProfileID) order by COrder desc, Country_Name", cs1);
                SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                da = new SqlDataAdapter(SqlCmd);
                ds = new DataSet();
                da.Fill(ds);
            }




        }
        return (ds);
    }



    public static string getcountrycodefromstring(string data)
    {
        string  ch;
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand sqcmd = new SqlCommand("select Country_Code  from country where country_code+'  '+Country_Name='"+ data + "'", cs1);
            //sqcmd.Parameters.Add("@email", SqlDbType.VarChar).Value = data;
            ch = (string)sqcmd.ExecuteScalar();
           
        }
        return ch;
    }



    //public static string getcountrycodestring(string data)
    //{
    //    string ch;
    //    using (SqlConnection cs1 = Queries.GetDBConnection())
    //    {
    //        SqlCommand sqcmd = new SqlCommand("select Country_Code  from country where country_code+'  '+Country_Name='" + data + "'", cs1);
    //        //sqcmd.Parameters.Add("@email", SqlDbType.VarChar).Value = data;
    //        ch = (string)sqcmd.ExecuteScalar();

    //    }
    //    return ch;
    //}


    public static DataSet LoadOfficeSource()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Office_Source_Name from Flybuy_Office_Source", cs1);
            //SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadFlybuyAgent()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select FAgent_Name from Flybuy_Agent", cs1);
            //SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }

    public static DataSet LoadLeadSource()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Lead_Source_Name from Flybuy_Lead_Source", cs1);
            //SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadPreArrival()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Pre_Arrival_Name from Flybuy_Pre_Arrival where Pre_Arrival_Status='Active' and Pre_Arrival_Expiry_Date=''", cs1);
            //SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataSet LoadVerification()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        using (SqlConnection cs1 = Queries.GetDBConnection())
        {
            SqlCommand SqlCmd = new SqlCommand("select Verification_Name from flybuy_verification where Verification_Status='Active' and Verification_Expiry_Date=''", cs1);
            //SqlCmd.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
            da = new SqlDataAdapter(SqlCmd);
            ds = new DataSet();
            da.Fill(ds);
        }
        return (ds);
    }


    public static DataTable loadDSR_CONSOLIDATED(string date)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {



            SqlCommand cmd_sp = new SqlCommand("DSRC", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", date);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }


    public static DataTable loadDGRBaliVenue(string date, string office, string venue, string MarketingProgram)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // string endv;
            //SqlCommand SqlCmd4 = new SqlCommand("select procedureName from printpdf where Printpdf_Name=@fname and Printpdf_Office=@office", cs1);
            //SqlCmd4.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            //SqlCmd4.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            ////SqlCmd4.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
            //endv = (string)SqlCmd4.ExecuteScalar();


            //string test1 = endv;

            SqlCommand cmd_sp = new SqlCommand("DGR_venuwise", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@DATE", date);
            cmd_sp.Parameters.AddWithValue("@office", office);
            cmd_sp.Parameters.AddWithValue("@venue", venue);
            cmd_sp.Parameters.AddWithValue("@source", MarketingProgram);
            // using (SqlCommand cmd = new SqlCommand())
            // {
            // cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandText = "holiday_confirm";
            // cmd.Parameters.AddWithValue("@booking_id", booking_id);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }




    public static DataTable loadDSR(string year)
    {

        using (SqlConnection cs1 = Queries.GetDBConnection())
        {

            // string endv;
            //SqlCommand SqlCmd4 = new SqlCommand("select procedureName from printpdf where Printpdf_Name=@fname and Printpdf_Office=@office", cs1);
            //SqlCmd4.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            //SqlCmd4.Parameters.Add("@office", SqlDbType.VarChar).Value = office;
            ////SqlCmd4.Parameters.Add("@mark", SqlDbType.VarChar).Value = mark;
            //endv = (string)SqlCmd4.ExecuteScalar();


            //string test1 = endv;

            SqlCommand cmd_sp = new SqlCommand("usp_data5", cs1);
            // cmd.CommandText = "holiday_confirm";
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.Parameters.AddWithValue("@year", year);
          
            // using (SqlCommand cmd = new SqlCommand())
            // {
            // cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandText = "holiday_confirm";
            // cmd.Parameters.AddWithValue("@booking_id", booking_id);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd_sp;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;

        }

    }









    public static int Deletecotractonerror(string contractid)
    {
        int rowsaffected = 0;
        using (SqlConnection cs2 = Queries.GetDBConnection())

        {
            try
            {

                SqlCommand scd = new SqlCommand("delete from Purchase_Service where Contract_Finance_ID=@contractid", cs2);
                scd.Parameters.Add("@contractid", SqlDbType.VarChar).Value = contractid;
                rowsaffected = scd.ExecuteNonQuery();

                SqlCommand scd2 = new SqlCommand("delete from Finance_Details where Contract_Finance_ID=@contractid", cs2);
                scd2.Parameters.Add("@contractid", SqlDbType.VarChar).Value = contractid;
                rowsaffected = scd2.ExecuteNonQuery();

                SqlCommand scd3 = new SqlCommand("delete from Finance_Invoice where Contract_Finance_ID=@contractid", cs2);
                scd3.Parameters.Add("@contractid", SqlDbType.VarChar).Value = contractid;
                rowsaffected = scd3.ExecuteNonQuery();

                SqlCommand scd4 = new SqlCommand("delete from CT_Points where Contract_Finance_ID=@contractid", cs2);
                scd4.Parameters.Add("@contractid", SqlDbType.VarChar).Value = contractid;
                rowsaffected = scd4.ExecuteNonQuery();

                SqlCommand scd5 = new SqlCommand("delete from Contract_Fractional where Contract_Finance_ID=@contractid", cs2);
                scd5.Parameters.Add("@contractid", SqlDbType.VarChar).Value = contractid;
                rowsaffected = scd5.ExecuteNonQuery();

                SqlCommand scd6 = new SqlCommand("delete from Contract_TP where Contract_Finance_ID=@contractid", cs2);
                scd6.Parameters.Add("@contractid", SqlDbType.VarChar).Value = contractid;
                rowsaffected = scd6.ExecuteNonQuery();

                SqlCommand scd7 = new SqlCommand("delete from Contract_TF where Contract_Finance_ID=@contractid", cs2);
                scd7.Parameters.Add("@contractid", SqlDbType.VarChar).Value = contractid;
                rowsaffected = scd7.ExecuteNonQuery();

                SqlCommand scd8 = new SqlCommand("delete from Finance_Details where Contract_Finance_ID=@contractid", cs2);
                scd8.Parameters.Add("@contractid", SqlDbType.VarChar).Value = contractid;
                rowsaffected = scd8.ExecuteNonQuery();

                SqlCommand scd9 = new SqlCommand("delete from Contract_Finance where Profile_ID=@contractid", cs2);
                scd9.Parameters.Add("@contractid", SqlDbType.VarChar).Value = contractid;
                rowsaffected = scd9.ExecuteNonQuery();



                //SqlCommand scd11 = new SqlCommand("delete from Sub_Profile3 where Profile_ID=@ProfileID", cs2);
                //scd11.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                //rowsaffected = scd11.ExecuteNonQuery();

                //SqlCommand scd12 = new SqlCommand("delete from Sub_Profile4 where Profile_ID=@ProfileID", cs2);
                //scd12.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                //rowsaffected = scd12.ExecuteNonQuery();

                //SqlCommand scd10 = new SqlCommand("delete from Profile where Profile_ID=@ProfileID", cs2);
                //scd10.Parameters.Add("@ProfileID", SqlDbType.VarChar).Value = ProfileID;
                //rowsaffected = scd10.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error in Update Gift Query " + ex.Message);

                string msg = "Error in  contract Delete Query " + " " + ex.Message;

                throw new Exception(msg, ex);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
        return (rowsaffected);
    }


}