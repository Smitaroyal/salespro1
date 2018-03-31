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

public partial class _Default : System.Web.UI.Page
{
    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate, sp3mobile, sp3alternate, sp4mobile, sp4alternate;
    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec;
    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc, sp3cc, sp3altcc, sp4cc, sp4altcc;
    static string sp3lname, sp3dob, tsp3dob, sp3nationality, sp3country ,sp3title,sp3fname;
    static string sp4title, sp4fname, sp4lname, sp4dob, tsp4dob, sp4nationality, sp4country;
    static string pemail, semail,sp1email, sp2email, pemail2, semail2, sp1email2, sp2email2, sp3email, sp3email2, sp4email, sp4email2;
    static string Subprofile3, Subprofile4;

    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oSecond_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager,oreception;
    static string oProfile_Primary_ID, oProfile_Primary_Title, oProfile_Primary_Fname, oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID;
    static string oProfile_Secondary_ID, oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB, oProfile_Secondary_Nationality, oProfile_Secondary_Country;
    static string oSub_Profile1_ID, oSub_Profile1_Title, oSub_Profile1_Fname, oSub_Profile1_Lname, oSub_Profile1_DOB, oSub_Profile1_Nationality, oSub_Profile1_Country;
    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country;
    static string oSub_Profile3_ID, oSub_Profile3_Title, oSub_Profile3_Fname, oSub_Profile3_Lname, oSub_Profile3_DOB, oSub_Profile3_Nationality, oSub_Profile3_Country;
    static string oSub_Profile4_ID, oSub_Profile4_Title, oSub_Profile4_Fname, oSub_Profile4_Lname, oSub_Profile4_DOB, oSub_Profile4_Nationality, oSub_Profile4_Country;
    static string oProfile_Address_ID, oProfile_Address_Line1, oProfile_Address_Line2, oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city, oProfile_Address_Postcode, oProfile_Address_Created_Date, oProfile_Address_Expiry_Date;
    static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate, oSubprofile3_CC, oSubprofile3_Mobile, oSubprofile3_Alt_CC, oSubprofile3_Alternate, oSubprofile4_CC, oSubprofile4_Mobile, oSubprofile4_Alt_CC, oSubprofile4_Alternate;
    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email, oPrimary_Email2, oSecondary_Email2, oSubprofile1_Email2, oSubprofile2_Email2, oSubprofile3_Email, oSubprofile3_Email2, oSubprofile4_Email, oSubprofile4_Email2;
    static string oProfile_Stay_ID, oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    static string oTour_Details_ID, oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep, oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In, oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price, oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;

    static string ogiftoptionDropDownList, ogiftoptionDropDownList2, ogiftoptionDropDownList3, ogiftoptionDropDownList4, ogiftoptionDropDownList5, ogiftoptionDropDownList6, ogiftoptionDropDownList7;
    static string ovouchernoTextBox, ovouchernoTextBox2, ovouchernoTextBox3, ovouchernoTextBox4, ovouchernoTextBox5, ovouchernoTextBox6, ovouchernoTextBox7;
    static string ogiftprice1, ogiftprice2, ogiftprice3, ogiftprice4, ogiftprice5, ogiftprice6, ogiftprice7;
    static string oVPID, oPrimaryAge, oSecondAge, oSP1Age, oSP2Age, oSP3Age, oSP4Age, oQStatusDropDownList1, ocheck, ocheck2;

    static string ProfileIDo, regTerms, regTerms2;

    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }

        string ProfileID = Convert.ToString(Request.QueryString["Profile_ID"]);
        string TourID = Convert.ToString(Request.QueryString["Tour_Detail_Id"]);


        if (!Page.IsPostBack)
        {
            //string user = (string)Session["username"];// "Caroline";
            CreatedByTextBox.Text = user;
            //get office of user
            string office = Queries.GetOffice(user);
            //



           DataSet ds = Queries.LoadProfielDetailsFull(ProfileID);
           // DataSet ds = Queries2.LoadProfileOnCreation(ProfileID);
            ProfileIDTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();  
            
            ProfileIDo= ds.Tables[0].Rows[0]["Profile_ID"].ToString();
            string tcreateddateTextBox = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"]);
            createddateTextBox.Text = tcreateddateTextBox; //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"]).ToString("yyyy-MM-dd");

            CreatedByTextBox.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString();



            DataSet recep = Queries2.LoadRecept();

            ReceptionistDropDownList.DataSource = recep;
            ReceptionistDropDownList.DataTextField = "name";
            ReceptionistDropDownList.DataValueField = "Recep_ID";
            ReceptionistDropDownList.AppendDataBoundItems = true;
            ReceptionistDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Reception"].ToString(), ""));
            ReceptionistDropDownList.DataBind();



            DataSet ds1 = Queries2.LoadVenueCountry1(ProfileID,office);
            VenueCountryDropDownList.DataSource = ds1;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            //VenueDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Venue"].ToString());
            DataSet ds2 = Queries2.LoadVenue(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ds.Tables[0].Rows[0]["Profile_Venue"].ToString());
            VenueDropDownList.DataSource = ds2;
            VenueDropDownList.DataTextField = "Venue_Name";
            VenueDropDownList.DataValueField = "Venue_Name";
            VenueDropDownList.AppendDataBoundItems = true;
            VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            VenueDropDownList.DataBind();

            GroupVenueDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString());
            //DataSet ds3 = Queries.LoadProfileVenueGroup(ProfileID);
            //GroupVenueDropDownList.DataSource = ds3;
            //GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            //GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            //GroupVenueDropDownList.AppendDataBoundItems = true;
            //GroupVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            //GroupVenueDropDownList.DataBind();

            MarketingPrgmDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString());
            //DataSet ds4 = Queries.LoadProfileMktg(ProfileID);
            //MarketingPrgmDropDownList.DataSource = ds4;
            //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.AppendDataBoundItems = true;
            //MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingPrgmDropDownList.DataBind();

            AgentsDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Agent"].ToString());
            //DataSet ds5 = Queries.LoadProfileAgent(ProfileID);
            //AgentsDropDownList.DataSource = ds5;
            //AgentsDropDownList.DataTextField = "Agent_Name";
            //AgentsDropDownList.DataValueField = "Agent_Name";
            //AgentsDropDownList.AppendDataBoundItems = true;
            //AgentsDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
            //AgentsDropDownList.DataBind();

            AgentCodeDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString());
            //DataSet ds6 = Queries.LoadProfileAgentCode(ProfileID);
            //AgentCodeDropDownList.DataSource = ds6;
            //AgentCodeDropDownList.DataTextField = "Agent_Code_Name";
            //AgentCodeDropDownList.DataValueField = "Agent_Code_Name";
            //AgentCodeDropDownList.AppendDataBoundItems = true;
            //AgentCodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            //AgentCodeDropDownList.DataBind();
            DataSet dsm = Queries.LoadMemberType();
            MemType1DropDownList.DataSource = dsm;
            MemType1DropDownList.DataTextField = "Member_Type_name";
            MemType1DropDownList.DataValueField = "Member_Type_name";
            MemType1DropDownList.AppendDataBoundItems = true;
            MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
            MemType1DropDownList.DataBind();

            DataSet ds7 = Queries.LoadMemberType();
            MemType2DropDownList.DataSource = ds7;
            MemType2DropDownList.DataTextField = "Member_Type_name";
            MemType2DropDownList.DataValueField = "Member_Type_name";
            MemType2DropDownList.AppendDataBoundItems = true;
            MemType2DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString(), ""));
            MemType2DropDownList.DataBind();
            //if (ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString()!="")
            //{
            //    MemType1DropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
                Memno1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
             //   MemType2DropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
                Memno2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
            // }

            //employmentstatusDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString());
            //employmentstatusDropDownList.Items.Add("Employee");
            //employmentstatusDropDownList.Items.Add("Worker");
            //employmentstatusDropDownList.Items.Add("Self Employed");
            //employmentstatusDropDownList.Items.Add("Director");
            //employmentstatusDropDownList.Items.Add("Office Holder");
            //employmentstatusDropDownList.Items.Add("Unemployed");

            DataSet dsemploy = Queries.LoadEmploymentStatus();
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            employmentstatusDropDownList.DataBind();

            DataSet Secondemploy = Queries.LoadEmploymentStatus();
            SecondemploymentstatusDropDownList.DataSource = Secondemploy;
            SecondemploymentstatusDropDownList.DataTextField = "Name";
            SecondemploymentstatusDropDownList.DataValueField = "Name";
            SecondemploymentstatusDropDownList.AppendDataBoundItems = true;
            SecondemploymentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_Employment_Status"].ToString(), ""));
            SecondemploymentstatusDropDownList.DataBind();


            //load marital status
            //MaritalStatusDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString());
            //MaritalStatusDropDownList.Items.Add("Single");
            //MaritalStatusDropDownList.Items.Add("Married");
            //MaritalStatusDropDownList.Items.Add("Divorced");
            //MaritalStatusDropDownList.Items.Add("Just Friend");
            //MaritalStatusDropDownList.Items.Add("Female Couple");
            //MaritalStatusDropDownList.Items.Add("Male Couple");
            //MaritalStatusDropDownList.Items.Add("Living Together as couple");

            DataSet dsmart = Queries.LoadMaritalStatus();
            MaritalStatusDropDownList.DataSource = dsmart;
            MaritalStatusDropDownList.DataTextField = "MaritalStatus";
            MaritalStatusDropDownList.DataValueField = "MaritalStatus";
            MaritalStatusDropDownList.AppendDataBoundItems = true;
            MaritalStatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
            MaritalStatusDropDownList.DataBind();

            //if (ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString() != "")
            //{
            //    employmentstatusDropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            //}
            //if (ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString() != "")
            //{
            //    MaritalStatusDropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
            //}
            livingyrsTextBox.Text    = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
           string  Profile_Office  = ds.Tables[0].Rows[0]["Office"].ToString();

            DataSet dsptitle = Queries2.LoadSalutations(office);
            primarytitleDropDownList.DataSource = dsptitle;
            primarytitleDropDownList.DataTextField = "Salutation";
            primarytitleDropDownList.DataValueField = "Salutation";
            primarytitleDropDownList.AppendDataBoundItems = true;
            primarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
            primarytitleDropDownList.DataBind();

            //primarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            //primarytitleDropDownList.Items.Add("Mr");
            //primarytitleDropDownList.Items.Add("Ms");
            //primarytitleDropDownList.Items.Add("Mrs");
            //primarytitleDropDownList.Items.Add("Adv");
            //primarytitleDropDownList.Items.Add("Dr");


          //  primarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            
            pfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            //pdobdatepicker.Text =  Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Primary_DOB"]).ToString("yyyy-MM-dd");

           // string deptt = ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString();
           // string datep1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"]).ToString("yyyy-MM-dd");

            string datep1 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]);
            //pdobdatepicker.Text = k;
            // string k = ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString();
            //string datep1= DateTime.ParseExact(k, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            if (datep1 == "" || datep1 == "01-01-1900")
            {
                pdobdatepicker.Text = "";
            }
            else
            {
                pdobdatepicker.Text = datep1;
            }
            
            DataSet primanat = Queries2.LoadNationalityWithoutPrevValPrimary(ProfileID);
            primarynationalityDropDownList.DataSource = primanat;
            primarynationalityDropDownList.DataTextField = "nationality_name";
            primarynationalityDropDownList.DataValueField = "nationality_name";
            primarynationalityDropDownList.AppendDataBoundItems = true;
            primarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
            primarynationalityDropDownList.DataBind();

            //primarynationalityDropDownList.Items.Add (ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString());

            //DataSet ds8 = Queries.LoadCountryPrimary(ProfileID);
            //PrimaryCountryDropDownList.DataSource = ds8;
            //PrimaryCountryDropDownList.DataTextField = "country_name";
            //PrimaryCountryDropDownList.DataValueField = "country_name";
            //PrimaryCountryDropDownList.AppendDataBoundItems = true;
            //PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            //PrimaryCountryDropDownList.DataBind();
            //PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            PrimaryCountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString());
           // primarynationalityDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString());

            //string 

            DataSet ds14p = Queries2.LoadCountryWithCodePrimaryMobile(ProfileID);
            primarymobileDropDownList.DataSource = ds14p;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            primarymobileDropDownList.DataBind();

            DataSet ds14al = Queries2.LoadCountryWithCodePrimaryAlt(ProfileID);
            primaryalternateDropDownList.DataSource = ds14al;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            primaryalternateDropDownList.DataBind();           
              
            pmobile = pmobileTextBox.Text = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            palternate = palternateTextBox.Text = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            pemail = pemailTextBox.Text = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            pemail2 = pemailTextBox2.Text = ds.Tables[0].Rows[0]["Primary_Email2"].ToString();

            //secondary profile
            // secondarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString());

            DataSet dsstitle = Queries2.LoadSalutations(office);
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString(), ""));
            secondarytitleDropDownList.DataBind();

            //secondarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString());
            //secondarytitleDropDownList.Items.Add("Mr");
            //secondarytitleDropDownList.Items.Add("Ms");
            //secondarytitleDropDownList.Items.Add("Mrs");
            //secondarytitleDropDownList.Items.Add("Adv");
            //secondarytitleDropDownList.Items.Add("Dr");


          
            sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            //sdobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");

           // string datep2 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]).ToString("yyyy-MM-dd");
            string datep2 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]);

            if (datep2 == "" || datep2 == "01-01-1900")
            {
                sdobdatepicker.Text = "";
            }
            else
            {
                sdobdatepicker.Text = datep2;
            }


            DataSet seconnat = Queries2.LoadNationalityWithoutPrevValSecondary(ProfileID);
            secondarynationalityDropDownList.DataSource = seconnat;
            secondarynationalityDropDownList.DataTextField = "nationality_name";
            secondarynationalityDropDownList.DataValueField = "nationality_name";
            secondarynationalityDropDownList.AppendDataBoundItems = true;
            secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString(), ""));
            secondarynationalityDropDownList.DataBind();
            //secondarynationalityDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString());

            //DataSet ds9 = Queries.LoadCountrySecondary(ProfileID);
            //SecondaryCountryDropDownList.DataSource = ds9;
            //SecondaryCountryDropDownList.DataTextField = "country_name";
            //SecondaryCountryDropDownList.DataValueField = "country_name";
            //SecondaryCountryDropDownList.AppendDataBoundItems = true;
            //SecondaryCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString(), ""));
            //SecondaryCountryDropDownList.DataBind();

            SecondaryCountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString());

            DataSet ds14  = Queries2.LoadCountryWithCodeSecondaryMobile(ProfileID);
            secondarymobileDropDownList.DataSource = ds14 ;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_CC"].ToString(), ""));
            secondarymobileDropDownList.DataBind();

            DataSet ds14a = Queries2.LoadCountryWithCodeSecondaryAlt(ProfileID);
            secondaryalternateDropDownList.DataSource = ds14a;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString(), ""));
            secondaryalternateDropDownList.DataBind();
    
            smobileTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            salternateTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            semailTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            semailTextBox2.Text = ds.Tables[0].Rows[0]["Secondary_Email2"].ToString();


            DataSet dssp1title = Queries2.LoadSalutations(office);
            subprofile1titleDropDownList.DataSource = dssp1title;
            subprofile1titleDropDownList.DataTextField = "Salutation";
            subprofile1titleDropDownList.DataValueField = "Salutation";
            subprofile1titleDropDownList.AppendDataBoundItems = true;
            subprofile1titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
            subprofile1titleDropDownList.DataBind();

            //subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            //subprofile1titleDropDownList.Items.Add("Mr");
            //subprofile1titleDropDownList.Items.Add("Ms");
            //subprofile1titleDropDownList.Items.Add("Mrs");
            //subprofile1titleDropDownList.Items.Add("Adv");
            //subprofile1titleDropDownList.Items.Add("Dr");

        

          //  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            sp1fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            //sp1dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]).ToString("yyyy-MM-dd");

           

                //string datep3 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]).ToString("yyyy-MM-dd");
                string datep3 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);
                if (datep3 == " " || datep3 == "01-01-1900")
            {
                sp1dobdatepicker.Text = "";
            }
            else
            {
                sp1dobdatepicker.Text = datep3;
            }


            DataSet sp1nat = Queries2.LoadNationalityWithoutPrevValSP1(ProfileID);
            subprofile1nationalityDropDownList.DataSource = sp1nat;
            subprofile1nationalityDropDownList.DataTextField = "nationality_name";
            subprofile1nationalityDropDownList.DataValueField = "nationality_name";
            subprofile1nationalityDropDownList.AppendDataBoundItems = true;
            subprofile1nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
            subprofile1nationalityDropDownList.DataBind();

            // subprofile1nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString());


            //DataSet ds10 = Queries2.LoadCountryPrevVal(ProfileID,"SP1");
            //SubProfile1CountryDropDownList.DataSource = ds10;
            //SubProfile1CountryDropDownList.DataTextField = "country_name";
            //SubProfile1CountryDropDownList.DataValueField = "country_name";
            //SubProfile1CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            //SubProfile1CountryDropDownList.DataBind();

            SubProfile1CountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString());

            DataSet dssp1 = Queries2.LoadCountryWithCodeSP1Mobile(ProfileID);
            subprofile1mobileDropDownList.DataSource = dssp1;
            subprofile1mobileDropDownList.DataTextField = "name";
            subprofile1mobileDropDownList.DataValueField = "name";
            subprofile1mobileDropDownList.AppendDataBoundItems = true;
            subprofile1mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            subprofile1mobileDropDownList.DataBind();
            DataSet dsspalt = Queries2.LoadCountryWithCodeSP1Alt(ProfileID);
            subprofile1alternateDropDownList.DataSource = dsspalt;
            subprofile1alternateDropDownList.DataTextField = "name";
            subprofile1alternateDropDownList.DataValueField = "name";
            subprofile1alternateDropDownList.AppendDataBoundItems = true;
            subprofile1alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            subprofile1alternateDropDownList.DataBind();

           
            sp1mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            sp1alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            sp1emailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            sp1emailTextBox2.Text = ds.Tables[0].Rows[0]["Subprofile1_Email2"].ToString();

            DataSet dssp2title = Queries2.LoadSalutations(office);
            subprofile2titleDropDownList.DataSource = dssp2title;
            subprofile2titleDropDownList.DataTextField = "Salutation";
            subprofile2titleDropDownList.DataValueField = "Salutation";
            subprofile2titleDropDownList.AppendDataBoundItems = true;
            subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            subprofile2titleDropDownList.DataBind();

            //subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //subprofile2titleDropDownList.Items.Add("Mr");
            //subprofile2titleDropDownList.Items.Add("Ms");
            //subprofile2titleDropDownList.Items.Add("Mrs");
            //subprofile2titleDropDownList.Items.Add("Adv");
            //subprofile2titleDropDownList.Items.Add("Dr");
          //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            sp2fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            //sp2dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

            
                // string datep4 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");
                string datep4 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);
                if (datep4 == " " || datep4 == "01-01-1900")
            {
                sp2dobdatepicker.Text = "";
            }
            else
            {
                sp2dobdatepicker.Text = datep4;
            }


            DataSet sp2nat = Queries2.LoadNationalityWithoutPrevValSP2(ProfileID);
            subprofile2nationalityDropDownList.DataSource = sp2nat;
            subprofile2nationalityDropDownList.DataTextField = "nationality_name";
            subprofile2nationalityDropDownList.DataValueField = "nationality_name";
            subprofile2nationalityDropDownList.AppendDataBoundItems = true;
            subprofile2nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
            subprofile2nationalityDropDownList.DataBind();
            //subprofile2nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());

            //DataSet ds11 = Queries2.LoadCountryPrevVal(ProfileID, "SP2");
            //SubProfile2CountryDropDownList.DataSource = ds11;
            //SubProfile2CountryDropDownList.DataTextField = "country_name";
            //SubProfile2CountryDropDownList.DataValueField = "country_name";
            //SubProfile2CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            //SubProfile2CountryDropDownList.DataBind();

            SubProfile2CountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString());


            DataSet dssp2 = Queries2.LoadCountryWithCodeSP2Mobile(ProfileID);
            subprofile2mobileDropDownList.DataSource = dssp2;
            subprofile2mobileDropDownList.DataTextField = "name";
            subprofile2mobileDropDownList.DataValueField = "name";
            subprofile2mobileDropDownList.AppendDataBoundItems = true;
            subprofile2mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            subprofile2mobileDropDownList.DataBind();
            DataSet dsspalt2 = Queries2.LoadCountryWithCodeSP2Alt(ProfileID);
            subprofile2alternateDropDownList.DataSource = dsspalt2;
            subprofile2alternateDropDownList.DataTextField = "name";
            subprofile2alternateDropDownList.DataValueField = "name";
            subprofile2alternateDropDownList.AppendDataBoundItems = true;
            subprofile2alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            subprofile2alternateDropDownList.DataBind();


            sp2mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            sp2alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
            sp2emailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            sp2emailTextBox2.Text = ds.Tables[0].Rows[0]["Subprofile2_Email2"].ToString();

            address1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
           address2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
             stateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
         cityTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
             pincodeTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();

            DataSet ds12 = Queries2.LoadCountryName();
            AddCountryDropDownList.DataSource = ds12;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
            AddCountryDropDownList.DataBind();


            //sub profile 3

            DataSet dssp3title = Queries2.LoadSalutations(office);
            SubP3TitleDropDownList.DataSource = dssp3title;
            SubP3TitleDropDownList.DataTextField = "Salutation";
            SubP3TitleDropDownList.DataValueField = "Salutation";
            SubP3TitleDropDownList.AppendDataBoundItems = true;
            SubP3TitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString(), ""));
            SubP3TitleDropDownList.DataBind();

            //DataSet dssp2title = Queries.LoadSalutations();
            //subprofile2titleDropDownList.DataSource = dssp2title;
            //subprofile2titleDropDownList.DataTextField = "Salutation";
            //subprofile2titleDropDownList.DataValueField = "Salutation";
            //subprofile2titleDropDownList.AppendDataBoundItems = true;
            //subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            //subprofile2titleDropDownList.DataBind();

            //subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //subprofile2titleDropDownList.Items.Add("Mr");
            //subprofile2titleDropDownList.Items.Add("Ms");
            //subprofile2titleDropDownList.Items.Add("Mrs");
            //subprofile2titleDropDownList.Items.Add("Adv");
            //subprofile2titleDropDownList.Items.Add("Dr");
            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            SubP3FnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
            if (SubP3FnameTextBox.Text != "")
            {
                SubP3LnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
                //sp2dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

                

                   // string datesp3 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]).ToString("yyyy-MM-dd");
                string datesp3 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]);
                if (datesp3 == " " || datesp3 == "01-01-1900")
                {
                    SubP3DOB.Text = "";
                }
                else
                {
                    SubP3DOB.Text = datesp3;
                }




                SubP3MobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
                SubP3AMobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
                SubP3EmailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
                SubP3EmailTextBox2.Text = ds.Tables[0].Rows[0]["Subprofile3_Email2"].ToString();
            }

            DataSet sp3nat = Queries2.LoadNationalityWithoutPrevValSP3(ProfileID);
            SubP3NationalityDropDownList.DataSource = sp3nat;
            SubP3NationalityDropDownList.DataTextField = "nationality_name";
            SubP3NationalityDropDownList.DataValueField = "nationality_name";
            SubP3NationalityDropDownList.AppendDataBoundItems = true;
            SubP3NationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
            SubP3NationalityDropDownList.DataBind();


            //DataSet dsp311 = Queries2.LoadCountryPrevVal(ProfileID, "SP3");
            //SubP3CountryDropDownList.DataSource = dsp311;
            //SubP3CountryDropDownList.DataTextField = "country_name";
            //SubP3CountryDropDownList.DataValueField = "country_name";
            //SubP3CountryDropDownList.AppendDataBoundItems = true;
            //SubP3CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
            //SubP3CountryDropDownList.DataBind();

            SubP3CountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString());



            DataSet dssp3 = Queries2.LoadCountryWithCodeSP3Mobile(ProfileID);
            SubP3CCDropDownList.DataSource = dssp3;
            SubP3CCDropDownList.DataTextField = "name";
            SubP3CCDropDownList.DataValueField = "name";
            SubP3CCDropDownList.AppendDataBoundItems = true;
            SubP3CCDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString(), ""));
            SubP3CCDropDownList.DataBind();

            DataSet dsspalt3 = Queries2.LoadCountryWithCodeSP3Alt(ProfileID);
            SubP3CCDropDownList2.DataSource = dsspalt3;
            SubP3CCDropDownList2.DataTextField = "name";
            SubP3CCDropDownList2.DataValueField = "name";
            SubP3CCDropDownList2.AppendDataBoundItems = true;
            SubP3CCDropDownList2.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString(), ""));
            SubP3CCDropDownList2.DataBind();

            //sub profile 4

            DataSet dssp4title = Queries2.LoadSalutations(office);
            SubP4TitleDropDownList.DataSource = dssp4title;
            SubP4TitleDropDownList.DataTextField = "Salutation";
            SubP4TitleDropDownList.DataValueField = "Salutation";
            SubP4TitleDropDownList.AppendDataBoundItems = true;
            SubP4TitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString(), ""));
            SubP4TitleDropDownList.DataBind();

            string tvenue = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();

            if (tvenue == "Flybuys")
            {
                DataSet OfficeSou = Queries2.LoadOfficeSource();

                OfficeSourceDropDownList.DataSource = OfficeSou;
                OfficeSourceDropDownList.DataTextField = "Office_Source_Name";
                OfficeSourceDropDownList.DataValueField = "Office_Source_Name";
                OfficeSourceDropDownList.AppendDataBoundItems = true;
                OfficeSourceDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                OfficeSourceDropDownList.DataBind();



                DataSet Flyage = Queries2.LoadFlybuyAgent();

                FAgentDropDownList.DataSource = Flyage;
                FAgentDropDownList.DataTextField = "FAgent_Name";
                FAgentDropDownList.DataValueField = "FAgent_Name";
                FAgentDropDownList.AppendDataBoundItems = true;
                FAgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
                FAgentDropDownList.DataBind();



                DataSet LeaSou = Queries2.LoadLeadSource();

                DropDownListFly.DataSource = LeaSou;
                DropDownListFly.DataTextField = "Lead_Source_Name";
                DropDownListFly.DataValueField = "Lead_Source_Name";
                DropDownListFly.AppendDataBoundItems = true;
                DropDownListFly.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Lead_Source"].ToString(), ""));
                DropDownListFly.DataBind();

                DataSet PreArr = Queries2.LoadPreArrival();

                PreArrivalDropDownList.DataSource = PreArr;
                PreArrivalDropDownList.DataTextField = "Pre_Arrival_Name";
                PreArrivalDropDownList.DataValueField = "Pre_Arrival_Name";
                PreArrivalDropDownList.AppendDataBoundItems = true;
                PreArrivalDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Pre_Arrival"].ToString(), ""));
                PreArrivalDropDownList.DataBind();

                DataSet Veri = Queries2.LoadVerification();

                VerificationDropDownList.DataSource = Veri;
                VerificationDropDownList.DataTextField = "Verification_Name";
                VerificationDropDownList.DataValueField = "Verification_Name";
                VerificationDropDownList.AppendDataBoundItems = true;
                VerificationDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Verification"].ToString(), ""));
                VerificationDropDownList.DataBind();

            }

            else
            {


                DataSet OfficeSou = Queries2.LoadOfficeSource();

                OfficeSourceDropDownList.DataSource = OfficeSou;
                OfficeSourceDropDownList.DataTextField = "Office_Source_Name";
                OfficeSourceDropDownList.DataValueField = "Office_Source_Name";
                OfficeSourceDropDownList.AppendDataBoundItems = true;
                OfficeSourceDropDownList.Items.Insert(0, new ListItem("", ""));
                OfficeSourceDropDownList.DataBind();



                DataSet Flyage = Queries2.LoadFlybuyAgent();

                FAgentDropDownList.DataSource = Flyage;
                FAgentDropDownList.DataTextField = "FAgent_Name";
                FAgentDropDownList.DataValueField = "FAgent_Name";
                FAgentDropDownList.AppendDataBoundItems = true;
                FAgentDropDownList.Items.Insert(0, new ListItem("", ""));
                FAgentDropDownList.DataBind();



                DataSet LeaSou = Queries2.LoadLeadSource();

                DropDownListFly.DataSource = LeaSou;
                DropDownListFly.DataTextField = "Lead_Source_Name";
                DropDownListFly.DataValueField = "Lead_Source_Name";
                DropDownListFly.AppendDataBoundItems = true;
                DropDownListFly.Items.Insert(0, new ListItem("", ""));
                DropDownListFly.DataBind();

                DataSet PreArr = Queries2.LoadPreArrival();

                PreArrivalDropDownList.DataSource = PreArr;
                PreArrivalDropDownList.DataTextField = "Pre_Arrival_Name";
                PreArrivalDropDownList.DataValueField = "Pre_Arrival_Name";
                PreArrivalDropDownList.AppendDataBoundItems = true;
                PreArrivalDropDownList.Items.Insert(0, new ListItem("", ""));
                PreArrivalDropDownList.DataBind();


                DataSet Veri = Queries2.LoadVerification();

                VerificationDropDownList.DataSource = Veri;
                VerificationDropDownList.DataTextField = "Verification_Name";
                VerificationDropDownList.DataValueField = "Verification_Name";
                VerificationDropDownList.AppendDataBoundItems = true;
                VerificationDropDownList.Items.Insert(0, new ListItem("", ""));
                VerificationDropDownList.DataBind();

            }

            //DataSet dssp2title = Queries.LoadSalutations();
            //subprofile2titleDropDownList.DataSource = dssp2title;
            //subprofile2titleDropDownList.DataTextField = "Salutation";
            //subprofile2titleDropDownList.DataValueField = "Salutation";
            //subprofile2titleDropDownList.AppendDataBoundItems = true;
            //subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            //subprofile2titleDropDownList.DataBind();

            //subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //subprofile2titleDropDownList.Items.Add("Mr");
            //subprofile2titleDropDownList.Items.Add("Ms");
            //subprofile2titleDropDownList.Items.Add("Mrs");
            //subprofile2titleDropDownList.Items.Add("Adv");
            //subprofile2titleDropDownList.Items.Add("Dr");
            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            SubP4FnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
            if (SubP4FnameTextBox.Text != "")
            {
                SubP4LnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
                //sp2dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");
               
                    //string datesp4 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]).ToString("yyyy-MM-dd");
                string datesp4 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]);
                if (datesp4 == " " || datesp4 == "01-01-1900")
                {
                    SubP4DOB.Text = "";
                }
                else
                {
                    SubP4DOB.Text = datesp4;
                }



                SubP4MobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
                SubP4AMobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
                SubP4EmailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();
                SubP4EmailTextBox2.Text = ds.Tables[0].Rows[0]["Subprofile4_Email2"].ToString();
            }


            DataSet sp4nat = Queries2.LoadNationalityWithoutPrevValSP4(ProfileID);
            SubP4NationalityDropDownList.DataSource = sp4nat;
            SubP4NationalityDropDownList.DataTextField = "nationality_name";
            SubP4NationalityDropDownList.DataValueField = "nationality_name";
            SubP4NationalityDropDownList.AppendDataBoundItems = true;
            SubP4NationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
            SubP4NationalityDropDownList.DataBind();

            //SubP4NationalityDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString());

            //DataSet dsp411 = Queries2.LoadCountryPrevVal(ProfileID, "SP4");
            //SubP4CountryDropDownList.DataSource = dsp411;
            //SubP4CountryDropDownList.DataTextField = "country_name";
            //SubP4CountryDropDownList.DataValueField = "country_name";
            //SubP4CountryDropDownList.AppendDataBoundItems = true;
            //SubP4CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
            //SubP4CountryDropDownList.DataBind();
            SubP4CountryDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString());


            DataSet dssp4 = Queries2.LoadCountryWithCodeSP4Mobile(ProfileID);
            SubP4CCDropDownList.DataSource = dssp4;
            SubP4CCDropDownList.DataTextField = "name";
            SubP4CCDropDownList.DataValueField = "name";
            SubP4CCDropDownList.AppendDataBoundItems = true;
            SubP4CCDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString(), ""));
            SubP4CCDropDownList.DataBind();

            DataSet dsspalt4 = Queries2.LoadCountryWithCodeSP4Alt(ProfileID);
            SubP4CCDropDownList2.DataSource = dsspalt4;
            SubP4CCDropDownList2.DataTextField = "name";
            SubP4CCDropDownList2.DataValueField = "name";
            SubP4CCDropDownList2.AppendDataBoundItems = true;
            SubP4CCDropDownList2.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString(), ""));
            SubP4CCDropDownList2.DataBind();

            //load gift

            DataSet tdsgift1 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList.DataSource = tdsgift1;
            giftoptionDropDownList.DataTextField = "item";
            giftoptionDropDownList.DataValueField = "item";
            giftoptionDropDownList.AppendDataBoundItems = true;
            giftoptionDropDownList.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList.DataBind();

            DataSet tdsgift2 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList2.DataSource = tdsgift2;
            giftoptionDropDownList2.DataTextField = "item";
            giftoptionDropDownList2.DataValueField = "item";
            giftoptionDropDownList2.AppendDataBoundItems = true;
            giftoptionDropDownList2.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList2.DataBind();


            DataSet tdsgift3 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList3.DataSource = tdsgift3;
            giftoptionDropDownList3.DataTextField = "item";
            giftoptionDropDownList3.DataValueField = "item";
            giftoptionDropDownList3.AppendDataBoundItems = true;
            giftoptionDropDownList3.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList3.DataBind();

            DataSet tdsgift4 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList4.DataSource = tdsgift4;
            giftoptionDropDownList4.DataTextField = "item";
            giftoptionDropDownList4.DataValueField = "item";
            giftoptionDropDownList4.AppendDataBoundItems = true;
            giftoptionDropDownList4.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList4.DataBind();

            DataSet tdsgift5 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList5.DataSource = tdsgift5;
            giftoptionDropDownList5.DataTextField = "item";
            giftoptionDropDownList5.DataValueField = "item";
            giftoptionDropDownList5.AppendDataBoundItems = true;
            giftoptionDropDownList5.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList5.DataBind();

            DataSet tdsgift6 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList6.DataSource = tdsgift6;
            giftoptionDropDownList6.DataTextField = "item";
            giftoptionDropDownList6.DataValueField = "item";
            giftoptionDropDownList6.AppendDataBoundItems = true;
            giftoptionDropDownList6.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList6.DataBind();

            DataSet tdsgift7 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList7.DataSource = tdsgift7;
            giftoptionDropDownList7.DataTextField = "item";
            giftoptionDropDownList7.DataValueField = "item";
            giftoptionDropDownList7.AppendDataBoundItems = true;
            giftoptionDropDownList7.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList7.DataBind();


            //stay details
            hotelTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
             roomnoTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            //checkindatedatepicker.Text = Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd");
            //checkoutdatedatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToString("yyyy-MM-dd");
           
                //string datep5 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd");
            string datep5 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]);
            if (datep5 == " " || datep5 == "01-01-1900")
            {
                checkindatedatepicker.Text = "";
            }
            else
            {
                checkindatedatepicker.Text = datep5;
            }
         
                //string datep6 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToString("yyyy-MM-dd");
            string datep6 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]);
            if (datep6 == " " || datep6 == "01-01-1900")
            {
                checkoutdatedatepicker.Text = "";
            }
            else
            {
                checkoutdatedatepicker.Text = datep6;
            }


            //guest status

            DataSet ds20 = Queries.LoadGuestStatus();
            gueststatusDropDownList.DataSource = ds20;
            gueststatusDropDownList.DataTextField = "Guest_Status_name";
            gueststatusDropDownList.DataValueField = "Guest_Status_name";
            gueststatusDropDownList.AppendDataBoundItems = true;
            gueststatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            gueststatusDropDownList.DataBind();


            //DataSet ds22 = Queries.LoadSalesReps(office);
            //salesrepDropDownList.DataSource = ds22;
            //salesrepDropDownList.DataTextField = "sales_rep_name";
            //salesrepDropDownList.DataValueField = "sales_rep_name";
            //salesrepDropDownList.AppendDataBoundItems = true;
            //salesrepDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
            //salesrepDropDownList.DataBind();


            salesrepDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());


            //gueststatusDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString()); 
            //salesrepDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());
            deckcheckintimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
             deckcheckouttimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            // tourdatedatepicker.Text= Convert.ToDateTime( ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToString("yyyy-MM-dd");
            
                //string datep7 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToString("yyyy-MM-dd");
            string datep7 = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]);
          
                if (datep7 == " " || datep7 == "01-01-1900")
            {
                tourdatedatepicker.Text = "";
            }
            else
            {
                tourdatedatepicker.Text = datep7;
            }

            taxipriceInTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            TaxiRefInTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
              TaxiPriceOutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
             TaxiRefOutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();


            string [] ar = new string[10];
            string[] br = new string[10];
            string[] cr = new string[10];
            string[] dr = new string[10];
            int i = 0;
            SqlDataReader reader = Queries2.getgiftoption(ProfileID);
            while (reader.Read())
            {

                 ar[i] = reader.GetString(0);
                br[i] = reader.GetString(1);
                cr[i] = reader.GetString(2);
                dr[i] = reader.GetString(3);

                //string id = "giftoptionDropDownList";

                i++;

            }
            //string tes = ar[0];

            if (string.IsNullOrEmpty(ar[0]) == false)

               // if (ar[0] != "" || ar[0] != "null")
            {
                giftoptionDropDownList.Items.Clear();
                DataSet dsgift1 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList.DataSource = dsgift1;
                giftoptionDropDownList.DataTextField = "item";
                giftoptionDropDownList.DataValueField = "item";
                giftoptionDropDownList.AppendDataBoundItems = true;

                giftoptionDropDownList.DataBind();
                giftoptionDropDownList.Items.Insert(0, new ListItem(ar[0]));

                vouchernoTextBox.Text = br[0];
                string gift_p = dr[0];

                //if (gift_p != "")
                //{
                    TextBoxGPrice1.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[0]));//string.Format("{0:n0}", dr[0]);//dr[0];
                //}
                ogiftoptionDropDownList = ar[0];
                ovouchernoTextBox = br[0];
                TextBoxChargeBack.Text = cr[0];
                ogiftprice1 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[0])); //string.Format("{0:n0}", dr[0]); 
                string dsf = cr[0];

            }

            if (string.IsNullOrEmpty(ar[1]) == false)
            //if (ar[1] != "" || ar[1] != null)
            {
                giftoptionDropDownList2.Items.Clear();
                DataSet dsgift2 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList2.DataSource = dsgift2;
                giftoptionDropDownList2.DataTextField = "item";
                giftoptionDropDownList2.DataValueField = "item";
                giftoptionDropDownList2.AppendDataBoundItems = true;

                giftoptionDropDownList2.DataBind();
                giftoptionDropDownList2.Items.Insert(0, new ListItem(ar[1]));

                vouchernoTextBox2.Text = br[1];
                TextBoxGPrice2.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1])); //dr[1];
                ogiftoptionDropDownList2 = ar[1];
                ovouchernoTextBox2 = br[1];
                ogiftprice2 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[1]));//dr[1];
            }

            if (string.IsNullOrEmpty(ar[2]) == false)
            //if (ar[2] != "" || ar[2] != null)
            {
                giftoptionDropDownList3.Items.Clear();
                DataSet dsgift3 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList3.DataSource = dsgift3;
                giftoptionDropDownList3.DataTextField = "item";
                giftoptionDropDownList3.DataValueField = "item";
                giftoptionDropDownList3.AppendDataBoundItems = true;

                giftoptionDropDownList3.DataBind();
                giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                vouchernoTextBox3.Text = br[2];
                TextBoxGPrice3.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[2]));//dr[2];
                ogiftoptionDropDownList3 = ar[2];
                ovouchernoTextBox3 = br[2];
                ogiftprice3 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[2]));//dr[2];
            }

            if (string.IsNullOrEmpty(ar[3]) == false)
            //if (ar[3] != "" || ar[3] != null)
            {
                giftoptionDropDownList4.Items.Clear();
                DataSet dsgift4 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList4.DataSource = dsgift4;
                giftoptionDropDownList4.DataTextField = "item";
                giftoptionDropDownList4.DataValueField = "item";
                giftoptionDropDownList4.AppendDataBoundItems = true;

                giftoptionDropDownList4.DataBind();
                giftoptionDropDownList4.Items.Insert(0, new ListItem(ar[3]));

                vouchernoTextBox4.Text = br[3];
                TextBoxGPrice4.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[3])); //dr[3];
                ogiftoptionDropDownList4 = ar[3];
                ovouchernoTextBox4 = br[3];
                ogiftprice4 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[3]));//dr[3];
            }

            if (string.IsNullOrEmpty(ar[4]) == false)
               // if (ar[4] != "" || ar[4] != null)
            {
                giftoptionDropDownList5.Items.Clear();
                DataSet dsgift5 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList5.DataSource = dsgift5;
                giftoptionDropDownList5.DataTextField = "item";
                giftoptionDropDownList5.DataValueField = "item";
                giftoptionDropDownList5.AppendDataBoundItems = true;

                giftoptionDropDownList5.DataBind();
                giftoptionDropDownList5.Items.Insert(0, new ListItem(ar[4]));

                vouchernoTextBox5.Text = br[4];
                TextBoxGPrice5.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[4]));//dr[4];
                ogiftoptionDropDownList5 = ar[4];
                ovouchernoTextBox5 = br[4];
                ogiftprice5 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[4])); //dr[4];
            }

            if (string.IsNullOrEmpty(ar[5]) == false)
                //if (ar[5] != "" || ar[5] != null)
            {
                giftoptionDropDownList6.Items.Clear();
                DataSet dsgift6 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList6.DataSource = dsgift6;
                giftoptionDropDownList6.DataTextField = "item";
                giftoptionDropDownList6.DataValueField = "item";
                giftoptionDropDownList6.AppendDataBoundItems = true;

                giftoptionDropDownList6.DataBind();
                giftoptionDropDownList6.Items.Insert(0, new ListItem(ar[5]));

                vouchernoTextBox6.Text = br[5];
                TextBoxGPrice6.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[5])); //dr[5];
                ogiftoptionDropDownList6 = ar[5];
                ovouchernoTextBox6 = br[5];
                ogiftprice6 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[5])); //dr[5];
            }

            if (string.IsNullOrEmpty(ar[6]) == false)
                //if (ar[6] != "" || ar[6] != null)
            {
                giftoptionDropDownList7.Items.Clear();
                DataSet dsgift7 = Queries2.LoadGiftOption(office);
                giftoptionDropDownList7.DataSource = dsgift7;
                giftoptionDropDownList7.DataTextField = "item";
                giftoptionDropDownList7.DataValueField = "item";
                giftoptionDropDownList7.AppendDataBoundItems = true;

                giftoptionDropDownList7.DataBind();
                giftoptionDropDownList7.Items.Insert(0, new ListItem(ar[6]));

                vouchernoTextBox7.Text = br[6];
                TextBoxGPrice7.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[6]));//dr[6];
                ogiftoptionDropDownList7 = ar[6];
                ovouchernoTextBox7 = br[6];
                ogiftprice7 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[6]));//dr[6];
            }



            TextVPID.Text = ds.Tables[0].Rows[0]["VP_ID"].ToString();
            TextPrimaryAge.Text = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            TextSecondAge.Text = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            TextSP1Age.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();
            TextSP2Age.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();
            TextSP3Age.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();
            TextSP4Age.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

            DataSet dsepr = Queries2.LoadQStatus();
            QStatusDropDownList1.DataSource = dsepr;
            QStatusDropDownList1.DataTextField = "Qstatus_Name";
            QStatusDropDownList1.DataValueField = "Qstatus_Name";
            QStatusDropDownList1.AppendDataBoundItems = true;
            QStatusDropDownList1.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Qualified_Status"].ToString(), ""));
            QStatusDropDownList1.DataBind();

            string check = ds.Tables[0].Rows[0]["RegTerms"].ToString();
            
            if(check == "Y")
            {
                Regterms1.Checked = true;
            }
            else
            {
                Regterms1.Checked = false;
            }


            string check2 = ds.Tables[0].Rows[0]["RegTerms2"].ToString();

            if (check2 == "Y")
            {
                Regterms2.Checked = true;
            }
            else
            {
                Regterms2.Checked = false;
            }


            oProfile_Venue_Country = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
            oProfile_Venue = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
            oProfile_Group_Venue = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
            oProfile_Marketing_Program = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
            oProfile_Agent = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
            oProfile_Agent_Code = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
            oProfile_Member_Type1 = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
            oProfile_Member_Number1 = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
            oProfile_Member_Type2 = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
            oProfile_Member_Number2 = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
            oProfile_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            oSecond_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            oProfile_Marital_status = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
            oProfile_NOY_Living_as_couple = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
            oreception = ds.Tables[0].Rows[0]["Reception"].ToString();
            oOffice = ds.Tables[0].Rows[0]["Office"].ToString();
            oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
            oManager = ds.Tables[0].Rows[0]["Manager"].ToString();

            oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
            oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            oProfile_Primary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
            oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();

            oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
            oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            oProfile_Secondary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
            oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();

            oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
            oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            oSub_Profile1_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);//Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
            oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();

            oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
            oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            oSub_Profile2_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
            oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();


            oSub_Profile3_Title = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
            oSub_Profile3_Fname = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
            if (oSub_Profile3_Fname != "")
            {
                oSub_Profile3_Lname = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
                oSub_Profile3_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]);  //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
                oSub_Profile3_Nationality = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
                oSub_Profile3_Country = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
                oSubprofile3_CC = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
                oSubprofile3_Mobile = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
                oSubprofile3_Alt_CC = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
                oSubprofile3_Alternate = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
                
            }

            oSub_Profile4_Title = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
            oSub_Profile4_Fname = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
            if (oSub_Profile4_Fname != "")
            {
                oSub_Profile4_Lname = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
                oSub_Profile4_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
                oSub_Profile4_Nationality = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
                oSub_Profile4_Country = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();
                oSubprofile4_CC = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
                oSubprofile4_Mobile = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
                oSubprofile4_Alt_CC = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
                oSubprofile4_Alternate = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
            }

            oProfile_Address_Line1 = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            oProfile_Address_Line2 = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            oProfile_Address_State = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            oProfile_Address_city = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            oProfile_Address_Postcode = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            oProfile_Address_Created_Date = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
            oProfile_Address_Expiry_Date = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();

            oPrimary_CC = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
            oPrimary_Mobile = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            oPrimary_Alt_CC = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
            oPrimary_Alternate = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            oSecondary_CC = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
            oSecondary_Mobile = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            oSecondary_Alt_CC = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
            oSecondary_Alternate = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            oSubprofile1_CC = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
            oSubprofile1_Mobile = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            oSubprofile1_Alt_CC = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
            oSubprofile1_Alternate = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            oSubprofile2_CC = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
            oSubprofile2_Mobile = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            oSubprofile2_Alt_CC = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
            oSubprofile2_Alternate = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();

           

            oPrimary_Email = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            oSecondary_Email = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            oSubprofile1_Email = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            oSubprofile2_Email = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            oPrimary_Email2 = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            oSecondary_Email2 = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            oSubprofile1_Email2 = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            oSubprofile2_Email2 = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();

            oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
            oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            oProfile_Stay_Arrival_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]);  //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Stay_Departure_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

            oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
            oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
            oTour_Details_Tour_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
            oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();


            oVPID = ds.Tables[0].Rows[0]["VP_ID"].ToString();
            oPrimaryAge = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            oSecondAge = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            oSP1Age = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();
            oSP2Age = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();
            oSP3Age = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();
            oSP4Age = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();


            oQStatusDropDownList1 = ds.Tables[0].Rows[0]["Tour_Details_Qualified_Status"].ToString();
            

             ocheck = ds.Tables[0].Rows[0]["RegTerms"].ToString();
            ocheck2 = ds.Tables[0].Rows[0]["RegTerms2"].ToString();





        }
    }

    
    /*
    protected void VenueCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get code
        string venuecountry =Queries.GetVenueCountryCode( VenueCountryDropDownList.SelectedItem.Text);
        //ProfileIDTextBox.ReadOnly = true;
        //ProfileIDTextBox.Text = Queries.GetProfileID(VenueCountryDropDownList.SelectedItem.Text);

        DataSet ds1 = Queries.LoadVenuebasedOnCountryID(venuecountry);
        VenueDropDownList.DataSource = ds1;
        VenueDropDownList.DataTextField = "Venue_Name";
        VenueDropDownList.DataValueField = "Venue_Name";
        VenueDropDownList.AppendDataBoundItems = true;
        VenueDropDownList.Items.Insert(0, new ListItem("", ""));
        VenueDropDownList.DataBind();
    }
    protected void VenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get code
        string venuecode= Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, (Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));

        
        DataSet ds1 = Queries.LoadVenueGroup(venuecode);
        GroupVenueDropDownList.DataSource = ds1;
        GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
        GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
        GroupVenueDropDownList.AppendDataBoundItems = true;
        GroupVenueDropDownList.Items.Insert(0, new ListItem("", ""));
        GroupVenueDropDownList.DataBind();
    }

    protected void GroupVenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get code
        string venuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);


        DataSet ds1 = Queries.LoadMarketingProgram(venuecode);
        MarketingPrgmDropDownList.DataSource = ds1;
        MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
        MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
        MarketingPrgmDropDownList.AppendDataBoundItems = true;
        MarketingPrgmDropDownList.Items.Insert(0, new ListItem("", ""));
        MarketingPrgmDropDownList.DataBind();
        
    }

    protected void PrimaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        primarymobileDropDownList.Items.Clear();
        string code = Queries.GetCountryCode(PrimaryCountryDropDownList.SelectedItem.Text);
        DataSet ds12 = Queries.LoadCountryWithCode();
        primarymobileDropDownList.DataSource = ds12;
        primarymobileDropDownList.DataTextField = "name";
        primarymobileDropDownList.DataValueField = "name";
        primarymobileDropDownList.AppendDataBoundItems = true;
        primarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        primarymobileDropDownList.DataBind();

    }

    protected void SecondaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        secondarymobileDropDownList.Items.Clear();
        string code = Queries.GetCountryCode(SecondaryCountryDropDownList.SelectedItem.Text);
        DataSet ds12 = Queries.LoadCountryWithCode();
        secondarymobileDropDownList.DataSource = ds12;
        secondarymobileDropDownList.DataTextField = "name";
        secondarymobileDropDownList.DataValueField = "name";
        secondarymobileDropDownList.AppendDataBoundItems = true;
        secondarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        secondarymobileDropDownList.DataBind();
    }

    protected void SubProfile1CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        subprofile1mobileDropDownList.Items.Clear();
        string code = Queries.GetCountryCode(SubProfile1CountryDropDownList.SelectedItem.Text);
        DataSet ds12 = Queries.LoadCountryWithCode();
        subprofile1mobileDropDownList.DataSource = ds12;
        subprofile1mobileDropDownList.DataTextField = "name";
        subprofile1mobileDropDownList.DataValueField = "name";
        subprofile1mobileDropDownList.AppendDataBoundItems = true;
        subprofile1mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        subprofile1mobileDropDownList.DataBind();
    }
    protected void SubProfile2CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        subprofile2mobileDropDownList.Items.Clear();
        string code = Queries.GetCountryCode(SubProfile2CountryDropDownList.SelectedItem.Text);
        DataSet ds12 = Queries.LoadCountryWithCode();
        subprofile2mobileDropDownList.DataSource = ds12;
        subprofile2mobileDropDownList.DataTextField = "name";
        subprofile2mobileDropDownList.DataValueField = "name";
        subprofile2mobileDropDownList.AppendDataBoundItems = true;
        subprofile2mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        subprofile2mobileDropDownList.DataBind();
    }*/

    protected void Button1_Click(object sender, EventArgs e)
    {
        //ProfileID
        try
       {

            DataSet ds = Queries.LoadProfielDetailsFull(ProfileIDTextBox.Text);
            oProfile_Venue_Country = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
            oProfile_Venue = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
            oProfile_Group_Venue = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
            oProfile_Marketing_Program = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
            oProfile_Agent = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
            oProfile_Agent_Code = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
            oProfile_Member_Type1 = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
            oProfile_Member_Number1 = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
            oProfile_Member_Type2 = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
            oProfile_Member_Number2 = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
            oProfile_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            oSecond_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
            oProfile_Marital_status = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
            oProfile_NOY_Living_as_couple = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
            oreception = ds.Tables[0].Rows[0]["Reception"].ToString();
            oOffice = ds.Tables[0].Rows[0]["Office"].ToString();
            oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
            oManager = ds.Tables[0].Rows[0]["Manager"].ToString();

            oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
            oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            oProfile_Primary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
            oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();

            oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
            oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            oProfile_Secondary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
            oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();

            oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
            oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            oSub_Profile1_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
            oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();

            oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
            oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            oSub_Profile2_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
            oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();


            oSub_Profile3_Title = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
            oSub_Profile3_Fname = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
            if (oSub_Profile3_Fname != "")
            {
                oSub_Profile3_Lname = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
                oSub_Profile3_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
                oSub_Profile3_Nationality = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
                oSub_Profile3_Country = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
                oSubprofile3_CC = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
                oSubprofile3_Mobile = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
                oSubprofile3_Alt_CC = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
                oSubprofile3_Alternate = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();

            }

            oSub_Profile4_Title = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
            oSub_Profile4_Fname = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
            if (oSub_Profile4_Fname != "")
            {
                oSub_Profile4_Lname = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
                oSub_Profile4_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
                oSub_Profile4_Nationality = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
                oSub_Profile4_Country = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();
                oSubprofile4_CC = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
                oSubprofile4_Mobile = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
                oSubprofile4_Alt_CC = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
                oSubprofile4_Alternate = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
            }

            oProfile_Address_Line1 = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            oProfile_Address_Line2 = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            oProfile_Address_State = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            oProfile_Address_city = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            oProfile_Address_Postcode = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            oProfile_Address_Created_Date = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
            oProfile_Address_Expiry_Date = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();

            oPrimary_CC = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
            oPrimary_Mobile = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            oPrimary_Alt_CC = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
            oPrimary_Alternate = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            oSecondary_CC = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
            oSecondary_Mobile = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            oSecondary_Alt_CC = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
            oSecondary_Alternate = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            oSubprofile1_CC = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
            oSubprofile1_Mobile = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            oSubprofile1_Alt_CC = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
            oSubprofile1_Alternate = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            oSubprofile2_CC = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
            oSubprofile2_Mobile = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            oSubprofile2_Alt_CC = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
            oSubprofile2_Alternate = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();



            oPrimary_Email = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            oSecondary_Email = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            oSubprofile1_Email = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            oSubprofile2_Email = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            oPrimary_Email2 = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
            oSecondary_Email2 = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
            oSubprofile1_Email2 = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            oSubprofile2_Email2 = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();

            oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
            oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            oProfile_Stay_Arrival_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Stay_Departure_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

            oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
            oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
            oTour_Details_Tour_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
            oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();



            string subvenue1 = ds.Tables[0].Rows[0]["SubVenue"].ToString();


            string[] ar = new string[10];
            string[] br = new string[10];
            string[] cr = new string[10];

            int i = 0;
            SqlDataReader reader = Queries2.getgiftoption(ProfileIDTextBox.Text);
            while (reader.Read())
            {

                ar[i] = reader.GetString(0);
                br[i] = reader.GetString(1);
                cr[i] = reader.GetString(3);


                //string id = "giftoptionDropDownList";

                i++;

            }

            if (string.IsNullOrEmpty(ar[0]) == false)
                //if (ar[0] != "" || ar[0] != null)
            {
                //DataSet dsgift1 = Queries2.LoadGiftOption(ProfileIDTextBox.Text);
                //giftoptionDropDownList.DataSource = dsgift1;
                //giftoptionDropDownList.DataTextField = "item";
                //giftoptionDropDownList.DataValueField = "item";
                //giftoptionDropDownList.AppendDataBoundItems = true;

                //giftoptionDropDownList.DataBind();
                //giftoptionDropDownList.Items.Insert(0, new ListItem(ar[0]));

                //vouchernoTextBox.Text = br[0];

                ogiftoptionDropDownList = ar[0];
                ovouchernoTextBox = br[0];
                ogiftprice1 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[0]));//cr[0];


            }

            if (string.IsNullOrEmpty(ar[1]) == false)
            //if (ar[1] != "" || ar[1] != null)
            {
                //DataSet dsgift2 = Queries2.LoadGiftOption(office);
                //giftoptionDropDownList2.DataSource = dsgift2;
                //giftoptionDropDownList2.DataTextField = "item";
                //giftoptionDropDownList2.DataValueField = "item";
                //giftoptionDropDownList2.AppendDataBoundItems = true;

                //giftoptionDropDownList2.DataBind();
                //giftoptionDropDownList2.Items.Insert(0, new ListItem(ar[1]));

                //vouchernoTextBox2.Text = br[1];
                ogiftoptionDropDownList2 = ar[1];
                ovouchernoTextBox2 = br[1];
                ogiftprice2 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[1]));//cr[1];
            }

            if (string.IsNullOrEmpty(ar[2]) == false)
            //if (ar[2] != "" || ar[2] != null)
            {
                //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                //giftoptionDropDownList3.DataSource = dsgift3;
                //giftoptionDropDownList3.DataTextField = "item";
                //giftoptionDropDownList3.DataValueField = "item";
                //giftoptionDropDownList3.AppendDataBoundItems = true;

                //giftoptionDropDownList3.DataBind();
                //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                //vouchernoTextBox3.Text = br[2];
                ogiftoptionDropDownList3 = ar[2];
                ovouchernoTextBox3 = br[2];
                ogiftprice3 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[2])); //cr[2];
            }


            if (string.IsNullOrEmpty(ar[3]) == false)
            //if (ar[3] != "" || ar[3] != null)
            {
                //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                //giftoptionDropDownList3.DataSource = dsgift3;
                //giftoptionDropDownList3.DataTextField = "item";
                //giftoptionDropDownList3.DataValueField = "item";
                //giftoptionDropDownList3.AppendDataBoundItems = true;

                //giftoptionDropDownList3.DataBind();
                //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                //vouchernoTextBox3.Text = br[2];
                ogiftoptionDropDownList4 = ar[3];
                ovouchernoTextBox4 = br[3];
                ogiftprice4 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[3]));//cr[3];
            }


            if (string.IsNullOrEmpty(ar[4]) == false)
            //if (ar[4] != "" || ar[4] != null)
            {
                //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                //giftoptionDropDownList3.DataSource = dsgift3;
                //giftoptionDropDownList3.DataTextField = "item";
                //giftoptionDropDownList3.DataValueField = "item";
                //giftoptionDropDownList3.AppendDataBoundItems = true;

                //giftoptionDropDownList3.DataBind();
                //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));
                
                //vouchernoTextBox3.Text = br[2];
                ogiftoptionDropDownList5 = ar[4];
                ovouchernoTextBox5 = br[4];
                ogiftprice5 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[4]));//cr[4];
            }

            if (string.IsNullOrEmpty(ar[5]) == false)
            //if (ar[5] != "" || ar[5] != null)
            {
                //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                //giftoptionDropDownList3.DataSource = dsgift3;
                //giftoptionDropDownList3.DataTextField = "item";
                //giftoptionDropDownList3.DataValueField = "item";
                //giftoptionDropDownList3.AppendDataBoundItems = true;

                //giftoptionDropDownList3.DataBind();
                //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                //vouchernoTextBox3.Text = br[2];
                ogiftoptionDropDownList6 = ar[5];
                ovouchernoTextBox6 = br[5];
                ogiftprice6 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[5]));//cr[5];
            }


            if (string.IsNullOrEmpty(ar[6]) == false)
            //if (ar[6] != "" || ar[6] != null)
            {
                //DataSet dsgift3 = Queries2.LoadGiftOption(office);
                //giftoptionDropDownList3.DataSource = dsgift3;
                //giftoptionDropDownList3.DataTextField = "item";
                //giftoptionDropDownList3.DataValueField = "item";
                //giftoptionDropDownList3.AppendDataBoundItems = true;

                //giftoptionDropDownList3.DataBind();
                //giftoptionDropDownList3.Items.Insert(0, new ListItem(ar[2]));

                //vouchernoTextBox3.Text = br[2];
                ogiftoptionDropDownList7 = ar[6];
                ovouchernoTextBox7 = br[6];
                ogiftprice7 = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(cr[6]));//cr[6];
            }




            //update profile

            string user = (string)Session["username"];// "Caroline";
            CreatedByTextBox.Text = user;
            //get office of user

            string VPID = TextVPID.Text;

            string office = Queries.GetOffice(user);

            string profile = ProfileIDTextBox.Text;
            string createdby = CreatedByTextBox.Text;


            string reception;

            if (ReceptionistDropDownList.SelectedItem.Text == "")
            {
                reception = "";
            }
            else
            {
                reception = ReceptionistDropDownList.SelectedItem.Text;
            }

            //string reception; 
            string venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, membertype2, leadsource, prearrival,verifi;

            if (VenueCountryDropDownList.SelectedItem.Text == "")
            {
                venuecountry = "";
            }
            else
            {
                venuecountry = VenueCountryDropDownList.SelectedItem.Text;
            }

            if (VenueDropDownList.SelectedItem.Text == "")
            {
                venue = "";
            }
            else
            {
                venue = VenueDropDownList.SelectedItem.Text;
            }

            //venue = Request.Form[VenueDropDownList.UniqueID];
             venuegroup = Request.Form[GroupVenueDropDownList.UniqueID];
             mktg = Request.Form[MarketingPrgmDropDownList.UniqueID];
             //agents = Request.Form[AgentsDropDownList.UniqueID];
            // agentcode = Request.Form[AgentCodeDropDownList.UniqueID];

            if (venue == "Flybuys")
            {

                agents = OfficeSourceDropDownList.SelectedItem.Text; //Request.Form[AgentsDropDownList.UniqueID];
                agentcode = FAgentDropDownList.SelectedItem.Text;//Request.Form[AgentCodeDropDownList.UniqueID];
                leadsource = DropDownListFly.SelectedItem.Text;
                prearrival = PreArrivalDropDownList.SelectedItem.Text;
                verifi = VerificationDropDownList.SelectedItem.Text;
            }
            else
            {
                agents = Request.Form[AgentsDropDownList.UniqueID];
                agentcode = Request.Form[AgentCodeDropDownList.UniqueID];
                leadsource = "";
                prearrival = "";
                verifi = "";
            }


            //if (VenueDropDownList.SelectedItem.Text == "")
            //{
            //    venue = "";
            //}
            //else
            //{
            //    venue = VenueDropDownList.SelectedItem.Text;
            //}

            //if (GroupVenueDropDownList.SelectedItem.Text == "")
            //{
            //    venuegroup = "";
            //}
            //else
            //{
            //    venuegroup = GroupVenueDropDownList.SelectedItem.Text;
            //}

            //if (MarketingPrgmDropDownList.SelectedItem.Text == "")
            //{
            //    mktg = "";
            //}
            //else
            //{
            //    mktg = MarketingPrgmDropDownList.SelectedItem.Text;
            //}

            //if (AgentsDropDownList.SelectedItem.Text == "")
            //{
            //    agents = "";
            //}
            //else
            //{
            //    agents = AgentsDropDownList.SelectedItem.Text;
            //}

            //// if (AgentCodeDropDownList.SelectedItem.Text == "" || AgentCodeDropDownList.SelectedIndex == 0)
            ////{
            ////  agentcode = "";
            //// }
            //// else
            //// {
            //agentcode = AgentCodeDropDownList.SelectedItem.Text;
            //  }


            //member details
            if (MemType1DropDownList.SelectedItem.Text == "")
            {
                membertype1 = "";
            }
            else
            {
                membertype1 = MemType1DropDownList.SelectedItem.Text;
            }

            if (MemType2DropDownList.SelectedItem.Text == "")
            {
                membertype2 = "";
            }
            else
            {
                membertype2 = MemType2DropDownList.SelectedItem.Text;
            }
            //string agentcode = AgentCodeDropDownList.SelectedItem.Text;


            string memno1 = Memno1TextBox.Text;

            string memno2 = Memno2TextBox.Text;


            //Request.Form[AgentCodeDropDownList.UniqueID];
            /*string venuecountry = VenueCountryDropDownList.SelectedItem.Text;//Request.Form[VenueCountryDropDownList.UniqueID];
            string venue = Request.Form[VenueDropDownList.UniqueID];
            string venuegroup = Request.Form[GroupVenueDropDownList.UniqueID];
            string mktg = Request.Form[MarketingPrgmDropDownList.UniqueID];
            string agents = Request.Form[AgentsDropDownList.UniqueID];
            string agentcode = Request.Form[AgentCodeDropDownList.UniqueID];
            //member details
            string membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno1 = Memno1TextBox.Text;
            string membertype2 = MemType2DropDownList.SelectedItem.Text;
            string memno2 = Memno2TextBox.Text;*/
            //primary profile
            string primarytitle = primarytitleDropDownList.SelectedItem.Text;
            string primaryfname = pfnameTextBox.Text;
            string primaylname = plnameTextBox.Text;
            string primarydob = pdobdatepicker.Text;//Convert.ToDateTime(pdobdatepicker.Text).ToString("yyyy-MM-dd"); 
            string tprimarydob;
            if (primarydob == "")
            {
                tprimarydob = "1900-01-01";
            }
            else
            {
                tprimarydob = primarydob;// Convert.ToDateTime(primarydob).ToString("yyyy-MM-dd");
            }

            string primarynationality = primarynationalityDropDownList.SelectedItem.Text;
            string primarycountry = Request.Form[PrimaryCountryDropDownList.UniqueID];
            //if (primarymobileDropDownList.SelectedItem.Text == "")
            //{
            //    pcc = "";

            //}
            //else
            //{
            //Request.Form[primarymobileDropDownList.UniqueID];
            // pcc = primarymobileDropDownList.SelectedItem.Text;//Request.Form[primarymobileDropDownList.UniqueID];

            //}
            //if (primaryalternateDropDownList.SelectedItem.Text == "")
            //{
            //    paltrcc = "";
            //}
            //else
            //{

            //    paltrcc = primaryalternateDropDownList.SelectedItem.Text;
            //}

            if (primarymobileDropDownList.SelectedItem.Text == "")
            {
                pcc = "";

            }
            else
            { //Request.Form[primarymobileDropDownList.UniqueID];
                string pcc1;
                pcc = primarymobileDropDownList.SelectedItem.Text;//Request.Form[primarymobileDropDownList.UniqueID];

                if (String.Compare(oPrimary_CC, pcc) != 0)
                {
                    pcc1 = Queries2.getcountrycodefromstring(pcc);
                    pcc = pcc1;
                }
                    //pcc1 = Queries2.getcountrycodefromstring(pcc);
               // pcc = pcc1;

            }
            if (primaryalternateDropDownList.SelectedItem.Text == "")
            {
                paltrcc = "";
            }
            else
            {
                string paltrcc1;
                paltrcc = primaryalternateDropDownList.SelectedItem.Text;

                if (String.Compare(oPrimary_Alt_CC, paltrcc) != 0)
                {
                    paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                    paltrcc = paltrcc1;
                }

                //paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                //paltrcc = paltrcc1;
            }



            if (pmobileTextBox.Text == "" || pmobileTextBox.Text == null)
            {
                pmobile = "";
            }
            else
            {
                pmobile = pmobileTextBox.Text;
            }

            if (palternateTextBox.Text == "" || palternateTextBox.Text == null)
            {
                palternate = "";
            }
            else
            {
                palternate = palternateTextBox.Text;
            }

            if (pemailTextBox.Text == "" || pemailTextBox.Text == null)
            {
                pemail = "";
            }
            else
            {
                pemail = pemailTextBox.Text;
            }
            if (pemailTextBox2.Text == "" || pemailTextBox2.Text == null)
            {
                pemail2 = "";
            }
            else
            {
                pemail2 = pemailTextBox2.Text;
            }

            string primaryage = TextPrimaryAge.Text;
            //secondary profile

            string secondarytitle = secondarytitleDropDownList.SelectedItem.Text;
            string secondaryfname = sfnameTextBox.Text;
            string secondarylname = slnameTextBox.Text;
            string secondarydob = sdobdatepicker.Text;
            string tsecondarydob;
            if (secondarydob == "")
            {
                tsecondarydob = "1900-01-01";
            }
            else
            {
                tsecondarydob = secondarydob;// Convert.ToDateTime(secondarydob).ToString("yyyy-MM-dd");
            }
            string secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
            string secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID]; //SecondaryCountryDropDownList.SelectedItem.Text;
                                                                                           //if (secondarymobileDropDownList.SelectedItem.Text == "")
                                                                                           //{
                                                                                           //    scc = "";
                                                                                           //}
                                                                                           //else
                                                                                           //{
                                                                                           //Request.Form[secondarymobileDropDownList.UniqueID];
                                                                                           // scc = secondarymobileDropDownList.SelectedItem.Text; //Request.Form[secondarymobileDropDownList.UniqueID];
                                                                                           //}

            //if (secondaryalternateDropDownList.SelectedItem.Text == "")
            //{
            //    saltcc = "";
            //}
            //else
            //{

            //    saltcc = secondaryalternateDropDownList.SelectedItem.Text;
            //}

            if (secondarymobileDropDownList.SelectedItem.Text == "")
            {
                scc = "";
            }
            else
            {
                //Request.Form[secondarymobileDropDownList.UniqueID];
                //scc = Request.Form[secondarymobileDropDownList.UniqueID];
                string scc1;
                scc = secondarymobileDropDownList.SelectedItem.Text;


                if (String.Compare(oSecondary_CC, scc) != 0)
                {
                    scc1 = Queries2.getcountrycodefromstring(scc);
                    scc = scc1;
                }


                //Request.Form[primarymobileDropDownList.UniqueID];
                //scc1 = Queries2.getcountrycodefromstring(scc);
                //scc = scc1;

            }
            //secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID];
            if (secondaryalternateDropDownList.SelectedItem.Text == "")
            {
                saltcc = "";
            }
            else
            {
                string saltcc1;
                saltcc = secondaryalternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                if (String.Compare(oSecondary_Alt_CC, saltcc) != 0)
                {
                    saltcc1 = Queries2.getcountrycodefromstring(saltcc);
                    saltcc = saltcc1;
                }

                //saltcc1 = Queries2.getcountrycodefromstring(saltcc);
               // saltcc = saltcc1;

            }



            if (smobileTextBox.Text == "" || smobileTextBox.Text == null)
            {
                smobile = "";
            }
            else
            {
                smobile = smobileTextBox.Text;
            }
            if (salternateTextBox.Text == "" || salternateTextBox.Text == null)
            {
                salternate = "";
            }
            else
            {
                salternate = salternateTextBox.Text;
            }
            if (semailTextBox.Text == "" || semailTextBox.Text == null)
            {
                semail = "";
            }
            else
            {
                semail = semailTextBox.Text;
            }

            if (semailTextBox2.Text == "" || semailTextBox2.Text == null)
            {
                semail2 = "";
            }
            else
            {
                semail2 = semailTextBox2.Text;
            }

            string secondaryage = TextSecondAge.Text;
            //sub profile1

            string sp1title = subprofile1titleDropDownList.SelectedItem.Text;
            string sp1fname = sp1fnameTextBox.Text;
            string sp1lname = sp1lnameTextBox.Text;
            string sp1dob = sp1dobdatepicker.Text;
            string SubProfile1age = TextSP1Age.Text;

            string tsp1dob;
            if (sp1dob == "")
            {
                tsp1dob = "1900-01-01";
            }
            else
            {
                tsp1dob = sp1dob;// Convert.ToDateTime(sp1dob).ToString("yyyy-MM-dd");
            }

            string sp1nationality = subprofile1nationalityDropDownList.SelectedItem.Text;
            string sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID]; 
            //.SelectedItem.Text;
                                                                                       //if (subprofile1mobileDropDownList.SelectedItem.Text == "")
                                                                                       //{
                                                                                       //    sp1cc = "";
                                                                                       //}
                                                                                       //else
                                                                                       //{
                                                                                       //Request.Form[subprofile1mobileDropDownList.UniqueID];
                                                                                       // Request.Form[subprofile1mobileDropDownList.UniqueID]

            //sp1cc = Request.Form[subprofile1mobileDropDownList.UniqueID];
            //}

            //if (subprofile1alternateDropDownList.SelectedItem.Text == "")
            //{
            //    sp1altcc = "";
            //}
            //else
            //{

            //    sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;
            //}

            if (subprofile1mobileDropDownList.SelectedItem.Text == "")
            {
                sp1cc = "";
            }
            else
            {
                //Request.Form[subprofile1mobileDropDownList.UniqueID];
                //sp1cc = Request.Form[subprofile1mobileDropDownList.UniqueID];

                string sp1cc1;
                sp1cc = subprofile1mobileDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                if (String.Compare(oSubprofile1_CC, sp1cc) != 0)
                {
                    sp1cc1 = Queries2.getcountrycodefromstring(sp1cc);
                    sp1cc = sp1cc1;
                }

                //sp1cc1 = Queries2.getcountrycodefromstring(sp1cc);
                //sp1cc = sp1cc1;

            }
            // sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID];

            if (subprofile1alternateDropDownList.SelectedItem.Text == "")
            {
                sp1altcc = "";
            }
            else
            {

                //sp1altcc = Request.Form[subprofile1alternateDropDownList.UniqueID];

                string sp1altcc1;
                sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                if (String.Compare(oSubprofile1_Alt_CC, sp1altcc) != 0)
                {
                    sp1altcc1 = Queries2.getcountrycodefromstring(sp1altcc);
                    sp1altcc = sp1altcc1;
                }
                //sp1altcc1 = Queries2.getcountrycodefromstring(sp1altcc);
                //sp1altcc = sp1altcc1;

            }


            if (sp1mobileTextBox.Text == "" || sp1mobileTextBox.Text == null)
            {
                sp1mobile = "";
            }
            else
            {
                sp1mobile = sp1mobileTextBox.Text;
            }
            if (sp1alternateTextBox.Text == "" || sp1alternateTextBox.Text == null)
            {
                sp1alternate = "";
            }
            else
            {
                sp1alternate = sp1alternateTextBox.Text;
            }
            if (sp1emailTextBox.Text == "" || sp1emailTextBox.Text == null)
            {
                sp1email = "";
            }
            else
            {
                sp1email = sp1emailTextBox.Text;
            }


            if (sp1emailTextBox2.Text == "" || sp1emailTextBox2.Text == null)
            {
                sp1email2 = "";
            }
            else
            {
                sp1email2 = sp1emailTextBox2.Text;
            }

            

            //sub profile 2
            string sp2title = subprofile2titleDropDownList.SelectedItem.Text;
            string sp2fname = sp2fnameTextBox.Text;
            string sp2lname = sp2lnameTextBox.Text;
            string sp2dob = sp2dobdatepicker.Text;
            string Subprofile2 = TextSP2Age.Text;
            string tsp2dob;
            if (sp2dob == "")
            {
                tsp2dob = "1900-01-01";
            }
            else
            {
                tsp2dob = sp2dob;// Convert.ToDateTime(sp1dob).ToString("yyyy-MM-dd");
            }

            string sp2nationality = subprofile2nationalityDropDownList.SelectedItem.Text;
            string sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID]; //.SelectedItem.Text;

            //if (subprofile2mobileDropDownList.SelectedItem.Text == "")
            //{
            //    sp2cc = "";
            //}
            //else
            //{
            // Request.Form[subprofile2mobileDropDownList.UniqueID];
            //sp2cc = Request.Form[subprofile2mobileDropDownList.UniqueID];
            //}

            //if (subprofile2alternateDropDownList.SelectedItem.Text == "")
            //{
            //    sp2altccc = "";
            //}
            //else
            //{

            //    sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text;
            //}

            if (subprofile2mobileDropDownList.SelectedItem.Text == "")
            {
                sp2cc = "";
            }
            else
            {
                // Request.Form[subprofile2mobileDropDownList.UniqueID];
                //sp2cc = Request.Form[subprofile2mobileDropDownList.UniqueID];

                string sp2cc1;
                sp2cc = subprofile2mobileDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                if (String.Compare(oSubprofile2_CC, sp2cc) != 0)
                {
                    sp2cc1 = Queries2.getcountrycodefromstring(sp2cc);
                    sp2cc = sp2cc1;
                }
                //sp2cc1 = Queries2.getcountrycodefromstring(sp2cc);
                //sp2cc = sp2cc1;

            }
            //sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID];
            if (subprofile2alternateDropDownList.SelectedItem.Text == "")
            {
                sp2altccc = "";
            }
            else
            {

                //sp2altccc = Request.Form[subprofile2alternateDropDownList.UniqueID];

                string sp2altccc1;
                sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                if (String.Compare(oSubprofile2_Alt_CC, sp2altccc) != 0)
                {
                    sp2altccc1 = Queries2.getcountrycodefromstring(sp2altccc);
                    sp2altccc = sp2altccc1;
                }
                //sp2altccc1 = Queries2.getcountrycodefromstring(sp2altccc);
                //sp2altccc = sp2altccc1;


            }


            if (sp2mobileTextBox.Text == "" || sp2mobileTextBox.Text == null)
            {
                sp2mobile = "";
            }
            else
            {
                sp2mobile = sp2mobileTextBox.Text;

            }
            if (sp2alternateTextBox.Text == "" || sp2alternateTextBox.Text == null)
            {
                sp2alternate = "";

            }
            else
            {
                sp2alternate = sp2alternateTextBox.Text;

            }
            if (sp2emailTextBox.Text == "" || sp2emailTextBox.Text == null)
            {
                sp2email = "";
            }
            else
            {
                sp2email = sp2emailTextBox.Text;
            }

            if (sp2emailTextBox2.Text == "" || sp2emailTextBox2.Text == null)
            {
                sp2email2 = "";
            }
            else
            {
                sp2email2 = sp2emailTextBox2.Text;
            }

           

            //sub profile3



            sp3title = SubP3TitleDropDownList.SelectedItem.Text;
            
             sp3fname = SubP3FnameTextBox.Text;
            if (sp3fname != "")
            {
                 sp3lname = SubP3LnameTextBox.Text;
                 sp3dob = SubP3DOB.Text;
                Subprofile3 = TextSP3Age.Text;

                if (sp3dob == "")
                {
                    tsp3dob = "1900-01-01";
                }
                else
                {
                    tsp3dob = sp3dob;// Convert.ToDateTime(sp3dob).ToString("yyyy-MM-dd");
                }

                 sp3nationality = SubP3NationalityDropDownList.SelectedItem.Text; //Request.Form[SubP3NationalityDropDownList.UniqueID];
                 sp3country = Request.Form[SubP3CountryDropDownList.UniqueID]; //.SelectedItem.Text;


                //sp3cc = Request.Form[SubP3NationalityDropDownList.UniqueID];

                if (sp3country == "" || sp3country==null)
                {
                    sp3cc = "";
                    sp3altcc = "";
                    sp3mobile = "";
                    sp3alternate = "";
                }
                else
                {
                    //if (subprofile1mobileDropDownList.SelectedIndex == 0)
                    //{
                    //    sp1cc = "";
                    //}
                    //else
                    //{

                    // sp3cc = SubP3CCDropDownList.SelectedItem.Text;

                    //sp3cc = Request.Form[SubP3CCDropDownList.UniqueID];
                    //}

                    //if (SubP3CCDropDownList2.SelectedItem.Text == "")
                    //{
                    //    sp3altcc = "";
                    //}
                    //else
                    //{

                    //    sp3altcc = SubP3CCDropDownList2.SelectedItem.Text;
                    //}


                    if (SubP3CCDropDownList.SelectedItem.Text == "")
                    {
                        sp3cc = "";
                    }
                    else
                    {
                        string sp3cc1;
                        sp3cc = SubP3CCDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                        if (String.Compare(oSubprofile3_CC, sp3cc) != 0)
                        {
                            sp3cc1 = Queries2.getcountrycodefromstring(sp3cc);
                            sp3cc = sp3cc1;
                        }
                        //sp3cc1 = Queries2.getcountrycodefromstring(sp3cc);
                        //sp3cc = sp3cc1;


                        // sp3cc =  Request.Form[SubP3CCDropDownList.UniqueID];
                    }

                    if (SubP3CCDropDownList2.SelectedItem.Text == "")
                    {
                        sp3altcc = "";
                    }
                    else
                    {

                        //sp3altcc = Request.Form[SubP3CCDropDownList2.UniqueID];

                        string sp3altcc1;
                        sp3altcc = SubP3CCDropDownList2.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                        if (String.Compare(oSubprofile3_Alt_CC, sp3altcc) != 0)
                        {
                            sp3altcc1 = Queries2.getcountrycodefromstring(sp3altcc);
                            sp3altcc = sp3altcc1;
                        }
                        //sp3altcc1 = Queries2.getcountrycodefromstring(sp3altcc);
                       // sp3altcc = sp3altcc1;


                    }


                    if (SubP3MobileTextBox.Text == "" || SubP3MobileTextBox.Text == null)
                    {
                        sp3mobile = "";
                    }
                    else
                    {
                        sp3mobile = SubP3MobileTextBox.Text;
                    }
                    if (SubP3AMobileTextBox.Text == "" || SubP3AMobileTextBox.Text == null)
                    {
                        sp3alternate = "";
                    }
                    else
                    {
                        sp3alternate = SubP3AMobileTextBox.Text;
                    }
                }
                if (SubP3EmailTextBox.Text == "" || SubP3EmailTextBox.Text == null)
                {
                    sp3email = "";
                }
                else
                {
                    sp3email = SubP3EmailTextBox.Text;
                }

                if (SubP3EmailTextBox2.Text == "" || SubP3EmailTextBox2.Text == null)
                {
                    sp3email2 = "";
                }
                else
                {
                    sp3email2 = SubP3EmailTextBox2.Text;
                }

                 

            }


            //sub profile4


            
             sp4title = SubP4TitleDropDownList.SelectedItem.Text;
             sp4fname = SubP4FnameTextBox.Text;
            if (sp4fname != "")
            {

                 sp4lname = SubP4LnameTextBox.Text;
                 sp4dob = SubP4DOB.Text;
                Subprofile4 = TextSP4Age.Text;
                if (sp4dob == "")
                {
                    tsp4dob = "1900-01-01";
                }
                else
                {
                    tsp4dob = sp4dob;// Convert.ToDateTime(sp4dob).ToString("yyyy-MM-dd");
                }

                 sp4nationality = SubP4NationalityDropDownList.SelectedItem.Text;
                 sp4country = Request.Form[SubP4CountryDropDownList.UniqueID];// .SelectedItem.Text;

                //sp4cc = Request.Form[SubP4CountryDropDownList.UniqueID];
                if (sp4country == "" || sp4country==null)
                {
                    sp4cc = "";
                    sp4altcc = "";
                    sp4mobile = "";
                    sp4alternate = "";
                }
                else
                {
                    //if (subprofile1mobileDropDownList.SelectedIndex == 0)
                    //{
                    //    sp1cc = "";
                    //}
                    //else
                    //{

                    //sp4cc = SubP4CCDropDownList.SelectedItem.Text;
                    //sp4cc = Request.Form[SubP4CCDropDownList.UniqueID];
                    //}

                    //if (SubP4CCDropDownList2.SelectedItem.Text == "")
                    //{
                    //    sp4altcc = "";
                    //}
                    //else
                    //{

                    //    sp4altcc = SubP4CCDropDownList2.SelectedItem.Text;
                    //}

                    if (SubP4CountryDropDownList.SelectedItem.Text == "")
                    {
                        sp4cc = "";
                    }
                    else
                    {

                        //sp4cc = SubP4CCDropDownList.SelectedItem.Text;
                        //sp4cc = Request.Form[SubP4CCDropDownList.UniqueID];

                        string sp4cc1;
                        sp4cc = SubP4CCDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                        if (String.Compare(oSubprofile4_CC, sp4cc) != 0)
                        {
                            sp4cc1 = Queries2.getcountrycodefromstring(sp4cc);
                            sp4cc = sp4cc1;
                        }
                        //sp4cc1 = Queries2.getcountrycodefromstring(sp4cc);
                       // sp4cc = sp4cc1;
                    }
                    //sp4country = Request.Form[SubP4CountryDropDownList.UniqueID];

                    if (SubP4CCDropDownList2.SelectedItem.Text == "")
                    {
                        sp4altcc = "";
                    }
                    else
                    {

                        //sp4altcc = Request.Form[SubP4CCDropDownList2.UniqueID];

                        string sp4altcc1;
                        sp4altcc = SubP4CCDropDownList2.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];

                        if (String.Compare(oSubprofile4_Alt_CC, sp4altcc) != 0)
                        {
                            sp4altcc1 = Queries2.getcountrycodefromstring(sp4altcc);
                            sp4altcc = sp4altcc1;
                        }
                        //sp4altcc1 = Queries2.getcountrycodefromstring(sp4altcc);
                        //sp4altcc = sp4altcc1;

                    }


                    if (SubP4MobileTextBox.Text == "" || SubP4MobileTextBox.Text == null)
                    {
                        sp4mobile = "";
                    }
                    else
                    {
                        sp4mobile = SubP4MobileTextBox.Text;
                    }
                    if (SubP4AMobileTextBox.Text == "" || SubP4AMobileTextBox.Text == null)
                    {
                        sp4alternate = "";
                    }
                    else
                    {
                        sp4alternate = SubP4AMobileTextBox.Text;
                    }
                }
                if (SubP4EmailTextBox.Text == "" || SubP4EmailTextBox.Text == null)
                {
                    sp4email = "";
                }
                else
                {
                    sp4email = SubP4EmailTextBox.Text;
                }

                if (SubP4EmailTextBox2.Text == "" || SubP4EmailTextBox2.Text == null)
                {
                    sp4email2 = "";
                }
                else
                {
                    sp4email2 = SubP4EmailTextBox2.Text;
                }

               
            }

            //address

            string address1 = address1TextBox.Text;
            string address2 = address2TextBox.Text;
            string state = stateTextBox.Text;
            string city = cityTextBox.Text;
            string pincode = pincodeTextBox.Text;
            string acountry = AddCountryDropDownList.SelectedItem.Text;

            //other details

            string employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
            string Secondemploymentstatus = SecondemploymentstatusDropDownList.SelectedItem.Text;
            string maritalstatus = MaritalStatusDropDownList.SelectedItem.Text;
            string livingyrs = livingyrsTextBox.Text;

            //stay details
            string resort = hotelTextBox.Text;
            string roomno = roomnoTextBox.Text;
            string arrivaldate = checkindatedatepicker.Text;
            string tarrivaldate;
            if (arrivaldate == "")
            {
                tarrivaldate = "1900-01-01";
            }
            else
            {
                tarrivaldate = arrivaldate;//Convert.ToDateTime(arrivaldate).ToString("yyyy-MM-dd");
            }

            string departuredate = checkoutdatedatepicker.Text;
            string tdeparturedate;
            if (departuredate == "")
            {
                tdeparturedate = "1900-01-01";
            }
            else
            {
                tdeparturedate = departuredate;// Convert.ToDateTime(departuredate).ToString("yyyy-MM-dd");
            }

            //guest status

            string gueststatus = gueststatusDropDownList.SelectedItem.Text;
            string salesrep = salesrepDropDownList.SelectedItem.Text;
            string timeIn = deckcheckintimeTextBox.Text;
            string timeOut = deckcheckouttimeTextBox.Text;
            string tourdate = tourdatedatepicker.Text;
            string ttourdate;
            int weekno;
            if (tourdate == "")
            {
                ttourdate = "1900-01-01";
                weekno = 0;
            }
            else
            {
                ttourdate = tourdate;// Convert.ToDateTime(tourdate).ToString("yyyy-MM-dd");
                weekno = Queries2.GetWkNumber(ttourdate);
            }
            //if (tourdate == "")
            //{
            //    ttourdate = "1900-01-01";
            //}
            //else
            //{
            //    ttourdate = tourdate;// Convert.ToDateTime(tourdate).ToString("yyyy-MM-dd");
            //}
            string taxin = taxipriceInTextBox.Text;
            string taxirefin = TaxiRefInTextBox.Text;
            string taxiout = TaxiPriceOutTextBox.Text;
            string taxirefout = TaxiRefOutTextBox.Text;



            string gifto1, gifto2, gifto3, gifto4, gifto5, gifto6, gifto7;
            if (giftoptionDropDownList.SelectedItem.Text == "")
            {
                gifto1 = "";
            }
            else
            {
                gifto1 = giftoptionDropDownList.SelectedItem.Text;
            }

            if (giftoptionDropDownList2.SelectedItem.Text == "")
            {
                gifto2 = "";
            }
            else
            {
                gifto2 = giftoptionDropDownList2.SelectedItem.Text;
            }

            if (giftoptionDropDownList3.SelectedItem.Text == "")
            {
                gifto3 = "";
            }
            else
            {
                gifto3 = giftoptionDropDownList3.SelectedItem.Text;
            }
            if (giftoptionDropDownList4.SelectedItem.Text == "")
            {
                gifto4 = "";
            }
            else
            {
                gifto4 = giftoptionDropDownList4.SelectedItem.Text;
            }
            if (giftoptionDropDownList5.SelectedItem.Text == "")
            {
                gifto5 = "";
            }
            else
            {
                gifto5 = giftoptionDropDownList5.SelectedItem.Text;
            }
            if (giftoptionDropDownList6.SelectedItem.Text == "")
            {
                gifto6 = "";
            }
            else
            {
                gifto6 = giftoptionDropDownList6.SelectedItem.Text;
            }
            if (giftoptionDropDownList7.SelectedItem.Text == "")
            {
                gifto7 = "";
            }
            else
            {
                gifto7 = giftoptionDropDownList7.SelectedItem.Text;
            }

            string voucher1 = vouchernoTextBox.Text;
            string voucher2 = vouchernoTextBox2.Text;
            string voucher3 = vouchernoTextBox3.Text;
            string voucher4 = vouchernoTextBox4.Text;
            string voucher5 = vouchernoTextBox5.Text;
            string voucher6 = vouchernoTextBox6.Text;
            string voucher7 = vouchernoTextBox7.Text;



            string giftprice1 = TextBoxGPrice1.Text;
            
            string giftprice2 = TextBoxGPrice2.Text;
            string giftprice3 = TextBoxGPrice3.Text;
            string giftprice4 = TextBoxGPrice4.Text;
            string giftprice5 = TextBoxGPrice5.Text;
            string giftprice6 = TextBoxGPrice6.Text;
            string giftprice7 = TextBoxGPrice7.Text;

            if (giftprice1 == "")
            {
                giftprice1 = "0";
            }

            if (giftprice2 == "")
            {
                giftprice2 = "0";
            }

            if (giftprice3 == "")
            {
                giftprice3 = "0";
            }

            if (giftprice4 == "")
            {
                giftprice4 = "0";
            }

            if (giftprice5 == "")
            {
                giftprice5 = "0";
            }

            if (giftprice6 == "")
            {
                giftprice6 = "0";
            }

            if (giftprice7 == "")
            {
                giftprice7 = "0";
            }



            string chargeback = TextBoxChargeBack.Text;

            string QualiStatus = QStatusDropDownList1.SelectedItem.Text;

            if (Regterms1.Checked)
            {


                regTerms = "Y";
            }
            else
            {
                regTerms = "N";

            }

            if (Regterms2.Checked)
            {


                regTerms2 = "Y";
            }
            else
            {
                regTerms2 = "N";

            }




            if (String.Compare(oProfile_Venue_Country, venuecountry) != 0)
            {
                string act = "venue country changed from:" + oProfile_Venue_Country + "To:" + venuecountry;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
                //int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Venue, venue) != 0)
            {
                string act = "venue changed from:" + oProfile_Venue + "To:" + venue;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oreception, reception) != 0)
            {
                string act = "Reception changed from:" + oreception + "To:" + reception;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oProfile_Group_Venue, venuegroup) != 0)
            {
                string act = "venue group changed from:" + oProfile_Group_Venue + "To:" + venuegroup;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Marketing_Program, mktg) != 0)
            {
                string act = "marketing prgm changed from:" + oProfile_Marketing_Program + "To:" + mktg;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Agent, agents) != 0)
            {
                string act = "agent name changed from:" + oProfile_Agent + "To:" + agents;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Agent_Code, agentcode) != 0)
            {
                string act = "To Name changed from:" + oProfile_Agent_Code + "To:" + agentcode;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            /*if (String.Compare(oManager, mgr) != 0)
            {
                string act = "manager changed from:" + oManager + "To:" + mgr;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }*/
            if (String.Compare(oProfile_Member_Type1, membertype1) != 0)
            {
                string act = "membertype1 changed from:" + oProfile_Member_Type1 + "To:" + membertype1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Member_Number1, memno1) != 0)
            {
                string act = "memno1 changed from:" + oProfile_Member_Number1 + "To:" + memno1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Member_Type2, membertype2) != 0)
            {
                string act = "membertype2 changed from:" + oProfile_Member_Type2 + "To:" + membertype2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Member_Number2, memno2) != 0)
            {
                string act = "memno2 changed from:" + oProfile_Member_Number2 + "To:" + memno2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Title, primarytitle) != 0)
            {
                string act = "primary title changed from:" + oProfile_Primary_Title + "To:" + primarytitle;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Fname, primaryfname) != 0)
            {
                string act = "primary fname changed from:" + oProfile_Primary_Fname + "To:" + primaryfname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Lname, primaylname) != 0)
            {
                string act = "primay lname changed from:" + oProfile_Primary_Lname + "To:" + primaylname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_DOB, primarydob) != 0)
            {
                string act = "primary dob changed from:" + oProfile_Primary_DOB + "To:" + primarydob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Nationality, primarynationality) != 0)
            {
                string act = "primary nationality changed from:" + oProfile_Primary_Nationality + "To:" + primarynationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Primary_Country, primarycountry) != 0)
            {
                string act = "primary country changed from:" + oProfile_Primary_Country + "To:" + primarycountry;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_CC, pcc) != 0)
            {
                string act = "primary mobile code changed from:" + oPrimary_CC + "To:" + pcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_Mobile, pmobile) != 0)
            {
                string act = "primary mobile no changed from:" + oPrimary_Mobile + "To:" + pmobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_Alt_CC, paltrcc) != 0)
            {
                string act = "primary mobile changed from:" + oPrimary_Alt_CC + "To:" + paltrcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_Alternate, palternate) != 0)
            {
                string act = "primary alternate no changed from:" + oPrimary_Alternate + "To:" + palternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_Email, pemail) != 0)
            {
                string act = "primary email changed from:" + oPrimary_Email + "To:" + pemail;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oPrimary_Email2, pemail2) != 0)
            {
                string act = "primary email2 changed from:" + oPrimary_Email2 + "To:" + pemail2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_Title, secondarytitle) != 0)
            {
                string act = "secondary title changed from:" + oProfile_Secondary_Title + "To:" + secondarytitle;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_Fname, secondaryfname) != 0)
            {
                string act = "secondary fname changed from:" + oProfile_Secondary_Fname + "To:" + secondaryfname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_Lname, secondarylname) != 0)
            {
                string act = "secondary lname changed from:" + oProfile_Secondary_Lname + "To:" + secondarylname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_DOB, secondarydob) != 0)
            {
                string act = "secondary dob changed from:" + oProfile_Secondary_DOB + "To:" + secondarydob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oProfile_Secondary_Nationality, secondarynationality) != 0)
            {
                string act = "secondary nationality changed from:" + oProfile_Secondary_Nationality + "To:" + secondarynationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Secondary_Country, secondarycountry) != 0)
            {
                string act = "secondary country changed from:" + oProfile_Secondary_Country + "To:" + secondarycountry;
            }
            else { }
            if (String.Compare(oSecondary_CC, scc) != 0)
            {
                string act = "secondary mobile code changed from:" + oSecondary_CC + "To:" + scc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSecondary_Mobile, smobile) != 0)
            {
                string act = "secondary mobile no changed from:" + oSecondary_Mobile + "To:" + smobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());

            }
            else { }
            if (String.Compare(oSecondary_Alt_CC, saltcc) != 0)
            {
                string act = "secondary alternaet num code changed from:" + oSecondary_Alt_CC + "To:" + saltcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSecondary_Alternate, salternate) != 0)
            {
                string act = "secondary alternate no changed from:" + oSecondary_Alternate + "To:" + salternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSecondary_Email, semail) != 0)
            {
                string act = "secondary email changed from:" + oSecondary_Email + "To:" + semail;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSecondary_Email2, semail2) != 0)
            {
                string act = "secondary email changed from:" + oSecondary_Email2 + "To:" + semail2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Title, sp1title) != 0)
            {
                string act = "subprofile1 title changed from:" + oSub_Profile1_Title + "To:" + sp1title;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Fname, sp1fname) != 0)
            {
                string act = "subprofile1 fname changed from:" + oSub_Profile1_Fname + "To:" + sp1fname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Lname, sp1lname) != 0)
            {
                string act = "subprofile1 lname changed from:" + oSub_Profile1_Lname + "To:" + sp1lname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_DOB, sp1dob) != 0)
            {
                string act = "subprofile1 dob changed from:" + oSub_Profile1_DOB + "To:" + sp1dob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Nationality, sp1nationality) != 0)
            {
                string act = "subprofile1 nationality changed from:" + oSub_Profile1_Nationality + "To:" + sp1nationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_Country, sp1country) != 0)
            {
                string act = "subprofile1 country changed from:" + oSub_Profile1_Country + "To:" + sp1country;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile1_CC, sp1cc) != 0)
            {
                string act = "subprofile1 mobile code changed from:" + oSubprofile1_CC + "To:" + sp1cc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile1_Mobile, sp1mobile) != 0)
            {
                string act = "subprofile1 mobile no changed from:" + oSubprofile1_Mobile + "To:" + sp1mobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile1_Alt_CC, sp1altcc) != 0)
            {
                string act = "subprofile1 alternate no code changed from:" + oSubprofile1_Alt_CC + "To:" + sp1altcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile1_Alternate, sp1alternate) != 0)
            {
                string act = "subprofile1 alternate changed from:" + oSubprofile1_Alternate + "To:" + sp1alternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(oSubprofile1_Email, sp1email) != 0)
            {
                string act = "subprofile1 email changed from:" + oSubprofile1_Email + "To:" + sp1email;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_Title, sp2title) != 0)
            {
                string act = "subprofile2 title changed from:" + oSub_Profile2_Title + "To:" + sp2title;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_Fname, sp2fname) != 0)
            {
                string act = "subprofile2 fname changed from:" + oSub_Profile2_Fname + "To:" + sp2fname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_Lname, sp2lname) != 0)
            {
                string act = "subprofile2 lname changed from:" + oSub_Profile2_Lname + "To:" + sp2lname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_DOB, sp2dob) != 0)
            {
                string act = "subprofile2 dob changed from:" + oSub_Profile2_DOB + "To:" + sp2dob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile2_Nationality, sp2nationality) != 0)
            {
                string act = "subprofile2 nationality changed from:" + oSub_Profile2_Nationality + "To:" + sp2nationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSub_Profile2_Country, sp2country) != 0)

            {
                string act = "subprofile2 country changed from:" + oSub_Profile2_Country + "To:" + sp2country;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_CC, sp2cc) != 0)
            {
                string act = "subprofile2 mobile code changed from:" + oSubprofile2_CC + "To:" + sp2cc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_Mobile, sp2mobile) != 0)
            {
                string act = "subprofile2 mobile no changed from:" + oSubprofile2_Mobile + "To:" + sp2mobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_Alt_CC, sp2altccc) != 0)
            {
                string act = "subprofile2 alternate no code changed from:" + oSubprofile2_Alt_CC + "To:" + sp2altccc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_Alternate, sp2alternate) != 0)
            {
                string act = "subprofile2 alternate no changed from:" + oSubprofile2_Alternate + "To:" + sp2alternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile2_Email, sp2email) != 0)
            {
                string act = "subprofile2 email changed from:" + oSubprofile2_Email + "To:" + sp2email;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }


            //sub profile3 

            if (String.Compare(oSub_Profile3_Title, sp3title) != 0)
            {
                string act = "subprofile3 title changed from:" + oSub_Profile3_Title + "To:" + sp3title;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile3_Fname, sp3fname) != 0)
            {
                string act = "subprofile3 fname changed from:" + oSub_Profile3_Fname + "To:" + sp3fname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile3_Lname, sp3lname) != 0)
            {
                string act = "subprofile3 lname changed from:" + oSub_Profile3_Lname + "To:" + sp3lname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile3_DOB, sp3dob) != 0)
            {
                string act = "subprofile3 dob changed from:" + oSub_Profile3_DOB + "To:" + sp3dob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile3_Nationality, sp3nationality) != 0)
            {
                string act = "subprofile3 nationality changed from:" + oSub_Profile3_Nationality + "To:" + sp3nationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSub_Profile3_Country, sp3country) != 0)

            {
                string act = "subprofile3 country changed from:" + oSub_Profile3_Country + "To:" + sp3country;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile3_CC, sp3cc) != 0)
            {
                string act = "subprofile3 mobile code changed from:" + oSubprofile3_CC + "To:" + sp3cc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile3_Mobile, sp3mobile) != 0)
            {
                string act = "subprofile3 mobile no changed from:" + oSubprofile3_Mobile + "To:" + sp3mobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile3_Alt_CC, sp3altcc) != 0)
            {
                string act = "subprofile3 alternate no code changed from:" + oSubprofile3_Alt_CC + "To:" + sp3altcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile3_Alternate, sp3alternate) != 0)
            {
                string act = "subprofile3 alternate no changed from:" + oSubprofile3_Alternate + "To:" + sp3alternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile3_Email, sp3email) != 0)
            {
                string act = "subprofile3 email changed from:" + oSubprofile3_Email + "To:" + sp3email;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile3_Email2, sp3email2) != 0)
            {
                string act = "subprofile3 email2 changed from:" + oSubprofile3_Email2 + "To:" + sp3email2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }


            //sub profile4

            if (String.Compare(oSub_Profile4_Title, sp4title) != 0)
            {
                string act = "subprofile4 title changed from:" + oSub_Profile4_Title + "To:" + sp4title;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile4_Fname, sp4fname) != 0)
            {
                string act = "subprofile4 fname changed from:" + oSub_Profile4_Fname + "To:" + sp4fname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile4_Lname, sp4lname) != 0)
            {
                string act = "subprofile4 lname changed from:" + oSub_Profile4_Lname + "To:" + sp4lname;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile4_DOB, sp4dob) != 0)
            {
                string act = "subprofile4 dob changed from:" + oSub_Profile4_DOB + "To:" + sp4dob;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile4_Nationality, sp4nationality) != 0)
            {
                string act = "subprofile4 nationality changed from:" + oSub_Profile4_Nationality + "To:" + sp4nationality;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSub_Profile4_Country, sp4country) != 0)

            {
                string act = "subprofile4 country changed from:" + oSub_Profile4_Country + "To:" + sp4country;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile4_CC, sp4cc) != 0)
            {
                string act = "subprofile4 mobile code changed from:" + oSubprofile4_CC + "To:" + sp4cc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile4_Mobile, sp4mobile) != 0)
            {
                string act = "subprofile4 mobile no changed from:" + oSubprofile4_Mobile + "To:" + sp4mobile;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile4_Alt_CC, sp4altcc) != 0)
            {
                string act = "subprofile4 alternate no code changed from:" + oSubprofile4_Alt_CC + "To:" + sp4altcc;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile4_Alternate, sp4alternate) != 0)
            {
                string act = "subprofile4 alternate no changed from:" + oSubprofile4_Alternate + "To:" + sp4alternate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile4_Email, sp4email) != 0)
            {
                string act = "subprofile4 email changed from:" + oSubprofile4_Email + "To:" + sp4email;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSubprofile4_Email2, sp4email2) != 0)
            {
                string act = "subprofile4 email2 changed from:" + oSubprofile4_Email2 + "To:" + sp4email2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }




            if (String.Compare(oProfile_Address_Line1, address1) != 0)

            {
                string act = "address1 changed from:" + oProfile_Address_Line1 + "To:" + address1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Address_Line2, address2) != 0)
            {
                string act = "address2 changed from:" + oProfile_Address_Line2 + "To:" + address2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Address_State, state) != 0)
            {
                string act = "state changed from:" + oProfile_Address_State + "To:" + state;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Address_city, city) != 0)
            {
                string act = "city changed from:" + oProfile_Address_city + "To:" + city;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Address_Postcode, pincode) != 0)
            {
                string act = "pincode changed from:" + oProfile_Address_Postcode + "To:" + pincode;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Employment_status, employmentstatus) != 0)
            {
                string act = "employment status changed from:" + oProfile_Employment_status + "To:" + employmentstatus;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSecond_Employment_status, Secondemploymentstatus) != 0)
            {
                string act = "employment status changed from:" + oSecond_Employment_status + "To:" + Secondemploymentstatus;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oProfile_Marital_status, maritalstatus) != 0)
            {
                string act = "marital status changed from:" + oProfile_Marital_status + "To:" + maritalstatus;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_NOY_Living_as_couple, livingyrs) != 0)
            {
                string act = "livingyrs changed from:" + oProfile_NOY_Living_as_couple + "To:" + livingyrs;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Stay_Resort_Name, resort) != 0)
            {
                string act = "resort changed from:" + oProfile_Stay_Resort_Name + "To:" + resort;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Stay_Resort_Room_Number, roomno) != 0)
            {
                string act = "roomno changed from:" + oProfile_Stay_Resort_Room_Number + "To:" + roomno;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Stay_Arrival_Date, arrivaldate) != 0)
            {
                string act = "arrival date changed from:" + oProfile_Stay_Arrival_Date + "To:" + arrivaldate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oProfile_Stay_Departure_Date, departuredate) != 0)
            {
                string act = "departure date changed from:" + oProfile_Stay_Departure_Date + "To:" + departuredate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Guest_Status, gueststatus) != 0)
            {
                string act = "guest status changed from:" + oTour_Details_Guest_Status + "To:" + gueststatus;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Guest_Sales_Rep, salesrep) != 0)

            {
                string act = "salesrep changed from:" + oTour_Details_Guest_Sales_Rep + "To:" + salesrep;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Sales_Deck_Check_In, timeIn) != 0)
            {
                string act = "time In changed from:" + oTour_Details_Sales_Deck_Check_In + "To:" + timeIn;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oTour_Details_Sales_Deck_Check_Out, timeOut) != 0)
            {
                string act = "time Out changed from:" + oTour_Details_Sales_Deck_Check_Out + "To:" + timeOut;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Tour_Date, tourdate) != 0)
            {
                string act = "tour date changed from:" + oTour_Details_Tour_Date + "To:" + tourdate;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Taxi_In_Price, taxin) != 0)
            {
                string act = "taxi in price changed from:" + oTour_Details_Taxi_In_Price + "To:" + taxin;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Taxi_In_Ref, taxirefin) != 0)
            {
                string act = "taxi reference in changed from:" + oTour_Details_Taxi_In_Ref + "To:" + taxirefin;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oTour_Details_Taxi_Out_Price, taxiout) != 0)
            {
                string act = "taxi outprice changed from:" + oTour_Details_Taxi_Out_Price + "To:" + taxiout;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oTour_Details_Taxi_Out_Ref, taxirefout) != 0)
            {
                string act = "taxi reference out changed from:" + oTour_Details_Taxi_Out_Ref + "To:" + taxirefout;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftoptionDropDownList, gifto1) != 0)
            {
                string act = "Gift option 1 changed from:" + ogiftoptionDropDownList + "To:" + gifto1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftoptionDropDownList2, gifto2) != 0)
            {
                string act = "Gift option 2 changed from:" + ogiftoptionDropDownList2 + "To:" + gifto2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftoptionDropDownList3, gifto3) != 0)
            {
                string act = "Gift option 3 changed from:" + ogiftoptionDropDownList3 + "To:" + gifto3;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftoptionDropDownList4, gifto4) != 0)
            {
                string act = "Gift option 4 changed from:" + ogiftoptionDropDownList4 + "To:" + gifto4;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ogiftoptionDropDownList5, gifto5) != 0)
            {
                string act = "Gift option 5 changed from:" + ogiftoptionDropDownList5 + "To:" + gifto5;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ogiftoptionDropDownList6, gifto6) != 0)
            {
                string act = "Gift option 6 changed from:" + ogiftoptionDropDownList6 + "To:" + gifto6;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(ogiftoptionDropDownList7, gifto7) != 0)
            {
                string act = "Gift option 7 changed from:" + ogiftoptionDropDownList7 + "To:" + gifto7;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox, voucher1) != 0)
            {
                string act = "voucher 1 changed from:" + ovouchernoTextBox + "To:" + voucher1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox2, voucher2) != 0)
            {
                string act = "voucher 2 changed from:" + ovouchernoTextBox2 + "To:" + voucher2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox3, voucher3) != 0)
            {
                string act = "voucher 3 changed from:" + ovouchernoTextBox3 + "To:" + voucher3;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox4, voucher4) != 0)
            {
                string act = "voucher 4 changed from:" + ovouchernoTextBox4 + "To:" + voucher4;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox5, voucher5) != 0)
            {
                string act = "voucher 5 changed from:" + ovouchernoTextBox5 + "To:" + voucher5;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox6, voucher6) != 0)
            {
                string act = "voucher 6 changed from:" + ovouchernoTextBox6 + "To:" + voucher6;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ovouchernoTextBox7, voucher7) != 0)
            {
                string act = "voucher 7 changed from:" + ovouchernoTextBox7 + "To:" + voucher7;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }



            if (String.Compare(ogiftprice1, giftprice1) != 0)
            {
                string act = "giftprice 1 changed from:" + ogiftprice1 + "To:" + giftprice1;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(ogiftprice2, giftprice2) != 0)
            {
                string act = "giftprice 2 changed from:" + ogiftprice2 + "To:" + giftprice2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }


            if (String.Compare(ogiftprice3, giftprice3) != 0)
            {
                string act = "giftprice 3 changed from:" + ogiftprice3 + "To:" + giftprice3;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftprice4, giftprice4) != 0)
            {
                string act = "giftprice 4 changed from:" + ogiftprice4 + "To:" + giftprice4;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftprice5, giftprice5) != 0)
            {
                string act = "giftprice 5 changed from:" + ogiftprice5 + "To:" + giftprice5;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftprice6, giftprice6) != 0)
            {
                string act = "giftprice 6 changed from:" + ogiftprice6 + "To:" + giftprice6;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ogiftprice7, giftprice7) != 0)
            {
                string act = "giftprice 7 changed from:" + ogiftprice7 + "To:" + giftprice7;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }




            if (String.Compare(oPrimaryAge, primaryage) != 0)
            {
                string act = "primaryage changed from:" + oPrimaryAge + "To:" + primaryage;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSecondAge, secondaryage) != 0)
            {
                string act = "secondaryage changed from:" + oSecondAge + "To:" + secondaryage;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSP1Age, SubProfile1age) != 0)
            {
                string act = "SubProfile1age changed from:" + oSP1Age + "To:" + SubProfile1age;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSP2Age, Subprofile2) != 0)
            {
                string act = "SubProfile2age changed from:" + oSP2Age + "To:" + Subprofile2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSP3Age, Subprofile3) != 0)
            {
                string act = "Subprofile3age changed from:" + oSP3Age + "To:" + Subprofile3;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oSP4Age, Subprofile4) != 0)
            {
                string act = "Subprofile4age changed from:" + oSP4Age + "To:" + Subprofile4;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oQStatusDropDownList1, QualiStatus) != 0)
            {
                string act = "Qstatus changed from:" + oQStatusDropDownList1 + "To:" + QualiStatus;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocheck, regTerms) != 0)
            {
                string act = "regterm changed from:" + ocheck + "To:" + regTerms;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(ocheck2, regTerms2) != 0)
            {
                string act = "regterm changed from:" + ocheck2 + "To:" + regTerms2;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }

            if (String.Compare(oVPID, VPID) != 0)
            {
                string act = "VPID changed from:" + oVPID + "To:" + VPID;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", act, "Profile", user, DateTime.Now.ToString());
            }
            else { }
            


            //update profile
            int updateprofile = Queries2.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, "","","","",reception,subvenue1,regTerms,VPID,regTerms2, Secondemploymentstatus,leadsource,prearrival,verifi);
            int primary = Queries2.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, tprimarydob, primarynationality, primarycountry,primaryage,"","");

            int secondary1 = Queries2.checksubprofile("secondary", profile);

            if(secondaryfname!="")
            {
                if (secondary1 == 0)
                {
                    int year = DateTime.Now.Year;
                    string secondaryprofileid = Queries.GetSecondaryProfileID(office);
                    int secondary = Queries2.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, ProfileIDTextBox.Text, secondaryage, "", "");
                    string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Profile Secondary Age:" + secondaryage;
                    int insertlog3 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log3, "ProfileSecondary", user, DateTime.Now.ToString());
                    int updates = Queries.UpdateSecondaryValue(office, year);
                }

                else
                {
                    int secondary = Queries2.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, secondaryage, "", "");
                }

            }
            

            

            int subprofilecheck1 = Queries2.checksubprofile("SP1", profile);
            int subprofilecheck2 = Queries2.checksubprofile("SP2", profile);


            if(sp1fname != "")
            {
                if(subprofilecheck1 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile1id = Queries.GetSubProfile1ID(office);
                    int subprofielid = Queries2.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, ProfileIDTextBox.Text, SubProfile1age);
                    string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Sub Profile 1 Age:" + SubProfile1age;
                    int insertlog5 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log5, "ProfileSubProfie1", user, DateTime.Now.ToString());
                    int updatesp2 = Queries.UpdateSubprofile2Value(office, year);
                }
                else
                {
                    int sp1 = Queries2.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, SubProfile1age);
                }
            }

            if (sp2fname != "")
            {
                if (subprofilecheck2 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile2id = Queries.GetSubProfile2ID(office);
                    int subprofielid2 = Queries2.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, ProfileIDTextBox.Text, Subprofile2);
                    string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Sub Profile 2 Age:" + Subprofile2;
                    int insertlog6 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log6, "ProfileSubProfie2", user, DateTime.Now.ToString());
                    int updatesp2 = Queries.UpdateSubprofile2Value(office, year);
                }
                else
                {
                    int sp2 = Queries2.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, Subprofile2);
                }
            }



            

            int subprofilecheck3 = Queries2.checksubprofile("SP3", profile);
            int subprofilecheck4 = Queries2.checksubprofile("SP4", profile);
            if (sp3fname != "")
            {
                if(subprofilecheck3 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile3id = Queries.GetSubProfile3ID(office);
                    int subprofielid3 = Queries2.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, ProfileIDTextBox.Text, Subprofile3);
                    string log11 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Age:" + Subprofile3;
                    int insertlog11 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log11, "ProfileSubProfie2", user, DateTime.Now.ToString());
                    int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);
                }
                else
                {
                    int sp3 = Queries2.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, Subprofile3);
                }
               
            }
            if (sp4fname != "")
            {
                if (subprofilecheck4 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile4id = Queries.GetSubProfile4ID(office);
                    int subprofielid4 = Queries2.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, tsp4dob, sp4nationality, sp4country, ProfileIDTextBox.Text, Subprofile4);
                    string log12 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Age:" + Subprofile4;
                    int insertlog12 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log12, "ProfileSubProfie2", user, DateTime.Now.ToString());
                    int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);

                }
                else
                {
                    int sp4 = Queries2.UpdateSubProfile4(profile, sp4title, sp4fname, sp4lname, tsp4dob, sp4nationality, sp4country, Subprofile4);
                }
            }
            int address = Queries2.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);
            int phone = Queries2.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate,sp3cc,sp3mobile,sp4cc,sp4mobile,sp3altcc,sp3alternate,sp4altcc,sp4alternate);
            int email = Queries2.UpdateEmail(profile, pemail, semail, sp1email, sp2email, pemail2, semail2, sp1email2, sp2email2,sp3email,sp3email2,sp4email,sp4email2);
            int stay = Queries2.UpdateProfileStay(profile, resort, roomno, tarrivaldate, tdeparturedate);
            int tour = Queries2.UpdateTourDetails(profile, gueststatus, salesrep, ttourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout,QualiStatus,weekno);
            


            if (giftoptionDropDownList.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList == "" || ogiftoptionDropDownList == null)
                {
                    string giftid = Queries.GetProfileGift(office);
                    
                    int insert = Queries2.InsertGiftOption(giftid, gifto1, voucher1, chargeback, ProfileIDo, "",giftprice1);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {
                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList, gifto1, voucher1, ProfileIDo,chargeback,giftprice1);
                }
            }
            if (giftoptionDropDownList2.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList2 == "" || ogiftoptionDropDownList2 == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    int insert = Queries2.InsertGiftOption(giftid, gifto2, voucher2, "", ProfileIDo, "",giftprice2);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {
                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList2, gifto2, voucher2, ProfileIDo,"",giftprice2);
                }
            }
            if (giftoptionDropDownList3.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList3 == "" || ogiftoptionDropDownList3 == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    int insert = Queries2.InsertGiftOption(giftid, gifto3, voucher3, "", ProfileIDo, "",giftprice3);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList3, gifto3, voucher3, ProfileIDo,"",giftprice3);
                }
            }

            if (giftoptionDropDownList4.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList4 == "" || ogiftoptionDropDownList4 == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    int insert = Queries2.InsertGiftOption(giftid, gifto4, voucher4, "", ProfileIDo, "", giftprice4);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList4, gifto4, voucher4, ProfileIDo, "", giftprice4);
                }
            }

            if (giftoptionDropDownList5.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList5 == "" || ogiftoptionDropDownList5 == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    int insert = Queries2.InsertGiftOption(giftid, gifto5, voucher5, "", ProfileIDo, "", giftprice5);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList5, gifto5, voucher5, ProfileIDo, "", giftprice5);
                }
            }

            if (giftoptionDropDownList6.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList6 == "" || ogiftoptionDropDownList6 == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    int insert = Queries2.InsertGiftOption(giftid, gifto6, voucher6, "", ProfileIDo, "", giftprice6);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList6, gifto6, voucher6, ProfileIDo, "", giftprice6);
                }
            }

            if (giftoptionDropDownList7.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList7 == "" || ogiftoptionDropDownList7 == null)
                {
                    string giftid = Queries.GetProfileGift(office);

                    int insert = Queries2.InsertGiftOption(giftid, gifto7, voucher7, "", ProfileIDo, "", giftprice7);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList7, gifto7, voucher7, ProfileIDo, "", giftprice7);
                }
            }




            string msg = "Details updated for Profile :" + " " + profile;
            // Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele('"+ msg + "')", true);

            //Response.Write("<script>$(function() {alert('"+ msg + "'); topFunction(); });</script>");

            //Response.Redirect("Dashboard.aspx");
        }
        catch (Exception ex)
        {


            MessageBox.Show("Error while Updating profile " + ex.Message);

            //int delete = Queries2.Deleteprofileonerror(ProfileIDo);

            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

        }
    }


    public class VenueType
    {
        public string VenueTypeID { get; set; }
        public string VenueTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateVenueDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<VenueType> listRes = new List<VenueType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select v.Venue_Name,v.Venue_ID  from venue v  join VenueCountry vc on vc.Venue_Country_ID = v.Venue_Country_ID   where vc.Venue_Country_Name = '" + id + "'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        VenueType objst2 = new VenueType();

                        objst2.VenueTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.VenueTypeName = Convert.ToString(dt.Rows[i]["Venue_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }




    public class VenueGroupType
    {
        public string VenueGroupTypeID { get; set; }
        public string VenueGroupTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateVenueGroupDropDownList(string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<VenueGroupType> listRes = new List<VenueGroupType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            // using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
            using (SqlCommand cmd = new SqlCommand("select Venue2_Name from venue2 where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "') and venue2_status='Active' ", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        VenueGroupType objst2 = new VenueGroupType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.VenueGroupTypeName = Convert.ToString(dt.Rows[i]["Venue2_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }




    public class MrktProgType
    {
        public string MrktProgTypeID { get; set; }
        public string MrktProgTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateMrktProgDropDownList(string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<MrktProgType> listRes = new List<MrktProgType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
            using (SqlCommand cmd = new SqlCommand("select MProgram2_Name from Marketing_Program2 where Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name = '" + venueid + "') and MProgram2_Status='Active'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        MrktProgType objst2 = new MrktProgType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.MrktProgTypeName = Convert.ToString(dt.Rows[i]["MProgram2_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }




    public class AgentType
    {
        public string AgentTypeID { get; set; }
        public string AgentTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateAgentDropDownList(string markid, string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<AgentType> listRes = new List<AgentType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
            using (SqlCommand cmd = new SqlCommand("select MSource_Name from Marketing_Source where MProgram2_ID in (select MProgram2_ID from Marketing_Program2 where MProgram2_Name='" + markid + "' and Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name='" + venueid + "')) and MSource_Status='Active'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        AgentType objst2 = new AgentType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.AgentTypeName = Convert.ToString(dt.Rows[i]["MSource_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }



    public class AgentCodeType
    {
        public string AgentCodeTypeID { get; set; }
        public string AgentCodeTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateAgentCodeDropDownList(string markid, string agentid,string venueid)
    {
        DataTable dt = new DataTable();
        List<AgentCodeType> listRes = new List<AgentCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            // using (SqlCommand cmd = new SqlCommand("select Agent_Code from Agent_Code where Agent_id in (select Agent_ID from Agent_marketing where Agent_Name = '" + agentid + "' and marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "'))", con))
            using (SqlCommand cmd = new SqlCommand("select SCode_Name from Source_code where MSource_ID in (select MSource_ID from Marketing_Source where MSource_Name = '" + agentid + "' and MProgram2_ID in (select MProgram2_ID from Marketing_Program2 where MProgram2_Name = '" + markid + "' and  Venue2_ID in (select Venue2_ID from venue2 where Venue2_Name = '" + venueid + "')) ) and SCode_Status='Active'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        AgentCodeType objst2 = new AgentCodeType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.AgentCodeTypeName = Convert.ToString(dt.Rows[i]["SCode_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class CountryCodeType
    {
        public string CountryCodeTypeID { get; set; }
        public string CountryCodeTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateCountryCodeDropDownList(string Countid)
    {
        DataTable dt = new DataTable();
        List<CountryCodeType> listRes = new List<CountryCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Nationality_Country_Name from Nationality where Nationality_Name='" + Countid + "'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /*objRes.Add(new resort
                        {
                            //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                            ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                        });*/

                        CountryCodeType objst2 = new CountryCodeType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.CountryCodeTypeName = Convert.ToString(dt.Rows[i]["Nationality_Country_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }



    //load sales rep with 

    public class SalesRepType
    {
        public string SalesRepTypeID { get; set; }
        public string SalesRepTypeName { get; set; }
    }


    [WebMethod]
    public static string SalesRepTypeList(string venueid, string countid)
    {

        string vencountry = Queries2.GetVenueCountryCode(countid);
        DataTable dt = new DataTable();
        List<SalesRepType> listRes = new List<SalesRepType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            if (venueid != "Flybuys")
            {
                using (SqlCommand cmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID='" + vencountry + "' and venue= '" + venueid + "'", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            /*objRes.Add(new resort
                            {
                                //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                                ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                            });*/

                            SalesRepType objst2 = new SalesRepType();

                            //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                            objst2.SalesRepTypeName = Convert.ToString(dt.Rows[i]["Sales_Rep_Name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("select Sales_Rep_Name  from Sales_Rep where Venue_country_ID='" + vencountry + "' ", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            /*objRes.Add(new resort
                            {
                                //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
                                ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
                            });*/

                            SalesRepType objst2 = new SalesRepType();

                            //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                            objst2.SalesRepTypeName = Convert.ToString(dt.Rows[i]["Sales_Rep_Name"]);

                            listRes.Insert(i, objst2);


                        }
                    }
                    JavaScriptSerializer jscript = new JavaScriptSerializer();

                    return jscript.Serialize(listRes);
                }


            }
        }
    }



    [System.Web.Services.WebMethod]
    public static int totalgift()
    {
        //return "Hello "+name;
         int finaInstI;

        finaInstI = Queries2.countgift(ProfileIDo);
        return finaInstI;

      //  return "hi";


    }

}