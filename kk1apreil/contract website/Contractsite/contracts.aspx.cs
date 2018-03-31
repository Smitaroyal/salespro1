﻿using System;
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
    static string officeo,user;
    static string ProfileIDo;
    static string contFinance;
    static string purchaseservice;
    private string Values;
    static string venuecountryG, venueG, markG;


    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager,oreception,osubvenue, oSecond_Employment_status;
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
    static string oVPID, oPrimaryAge, oSecondAge, oSP1Age, oSP2Age, oSP3Age, oSP4Age, oQStatusDropDownList1, ocheck;
    static string GenContNumbglob,ofname,olname, regTerms, regTerms2, DealRegDate;
      string sp4fname, sp4lname, sp4dob, tsp4dob,sp4nationality, sp4country;
    string sp3fname, sp3lname, sp3dob, tsp3dob, sp3nationality, sp3country;
    string ft1, ft2;


    protected void Page_Load(object sender, EventArgs e)
    {

        string user1 = (string)Session["username"];
        if (user1 == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }



        //TextBox1.Text = DateTime.Today.ToString("yyyy/MM/dd");

        //string user1 = (string)Session["username"];
        //string user1 = "Administrator";
        // TextBox tb = new TextBox();
        user = user1;
        string office = Queries.GetOffice(user);
        // string ProfileID = "IVO20178";
        string ProfileID = Convert.ToString(Request.QueryString["Profile_ID"]);
        //ProfileIDo = ProfileID;

        string ContType = DropDownList40.SelectedItem.Text;
        //string Venue_country =Convert.ToString(Request.Q)
        if (!Page.IsPostBack)
        {


            DataSet ds4 = Queries2.LoadProfileOnCreation(ProfileID);
            ProfileIDTextBox.Text = ds4.Tables[0].Rows[0]["Profile_ID"].ToString();
            ProfileIDo = ProfileIDTextBox.Text;
            TextBox1.Text = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Date_Of_Insertion"]);// Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Date_Of_Insertion"]).ToString("yyyy-MM-dd");

            CreatedByTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Created_By"].ToString();

            DataSet recep = Queries2.LoadRecept();

            ReceptionistDropDownList.DataSource = recep;
            ReceptionistDropDownList.DataTextField = "name";
            ReceptionistDropDownList.DataValueField = "Recep_ID";
            ReceptionistDropDownList.AppendDataBoundItems = true;
            ReceptionistDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Reception"].ToString(), ""));
            ReceptionistDropDownList.DataBind();

            //primarytitleDropDownList.DataSource = ds4;
            //primarytitleDropDownList.DataTextField = "Profile_Primary_Title";
            //primarytitleDropDownList.DataValueField = "Profile_Primary_Title";
            //primarytitleDropDownList.DataBind();
           ofname= pfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            olname= plnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();

            //primarynationalityDropDownList.DataSource = ds4;
            //primarynationalityDropDownList.DataTextField = "Profile_Primary_Nationality";
            //primarynationalityDropDownList.DataValueField = "Profile_Primary_Nationality";
            //primarynationalityDropDownList.DataBind();

            DataSet primanat = Queries2.LoadNationalityWithoutPrevValPrimary(ProfileID);
            primarynationalityDropDownList.DataSource = primanat;
            primarynationalityDropDownList.DataTextField = "nationality_name";
            primarynationalityDropDownList.DataValueField = "nationality_name";
            primarynationalityDropDownList.AppendDataBoundItems = true;
            primarynationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
            primarynationalityDropDownList.DataBind();


            //PrimaryCountryDropDownList.Items.Clear();
            //DataSet ds28 = Queries2.LoadCountryName();
           
            //PrimaryCountryDropDownList.DataSource = ds28;
            //PrimaryCountryDropDownList.DataTextField = "country_name";
            //PrimaryCountryDropDownList.DataValueField = "country_name";
            //PrimaryCountryDropDownList.AppendDataBoundItems = true;
            //PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            //PrimaryCountryDropDownList.DataBind();

            PrimaryCountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString());

            string tpr = ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
            string vencountry = Queries2.GetVenueCountryCode(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString());
            VenueCountryDropDownList.Items.Clear();
            DataSet ds8 = Queries2.LoadVenueCountry1(ProfileID,office);

            VenueCountryDropDownList.DataSource = ds8;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            //VenueDropDownList.Items.Clear();
            DataSet ds24 = Queries2.LoadVenue(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ds4.Tables[0].Rows[0]["Profile_Venue"].ToString());
            VenueDropDownList.DataSource = ds24;
            VenueDropDownList.DataTextField = "Venue_Name";
            VenueDropDownList.DataValueField = "Venue_Name";
            VenueDropDownList.AppendDataBoundItems = true;
            VenueDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            VenueDropDownList.DataBind();

            //string venuecode = Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, vencountry);
           // VenueDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Venue"].ToString());



            GroupVenueDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Group_Venue"].ToString());
            MarketingPrgmDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString());
            AgentsDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString());
            AgentCodeDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString());


            string VenueDropDownListval = ds4.Tables[0].Rows[0]["Profile_Venue"].ToString();

            string subvenue1 = ds4.Tables[0].Rows[0]["SubVenue"].ToString();

            DataSet loadven = Queries2.LoadSubVenue(VenueDropDownListval, subvenue1);
            //VenueDropDownList.DataSource = ds24; 
            VenueDropDownList2.DataSource = loadven;
            VenueDropDownList2.DataTextField = "SVenue_Name";
            VenueDropDownList2.DataValueField = "SVenue_Name";
            VenueDropDownList2.AppendDataBoundItems = true;
            //VenueCountryDropDownList.Items.Insert(0,"", ""));
            VenueDropDownList2.Items.Insert(0, new ListItem(subvenue1, ""));
            VenueDropDownList2.DataBind();

            //GroupVenueDropDownList.Items.Clear();
            //DataSet ds25 = Queries.LoadVenueGroup(venuecode);
            //GroupVenueDropDownList.DataSource = ds25;
            //GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            //GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            //GroupVenueDropDownList.AppendDataBoundItems = true;
            //GroupVenueDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            //GroupVenueDropDownList.DataBind();

            //string Groupvenuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);

            //MarketingPrgmDropDownList.Items.Clear();
            //DataSet ds26 = Queries.LoadMarketingProgram(Groupvenuecode);
            //MarketingPrgmDropDownList.DataSource = ds26;
            //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.AppendDataBoundItems = true;
            //MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingPrgmDropDownList.DataBind();

            //string MarketingPCode = Queries2.getMarketingProgram(MarketingPrgmDropDownList.SelectedItem.Text, Groupvenuecode);
            //MarketingPrgmDropDownList.Items.Clear();
            //MarketingPrgmDropDownList.DataSource = ds26;
            //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.AppendDataBoundItems = true;
            //MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingPrgmDropDownList.DataBind();

            //AgentsDropDownList.Items.Clear();
            //DataSet ds27 = Queries2.LoadAgentsIVO(MarketingPrgmDropDownList.SelectedItem.Text);
            //AgentsDropDownList.DataSource = ds27;
            //AgentsDropDownList.DataTextField = "Agent_Name";
            //AgentsDropDownList.DataValueField = "Agent_Name";
            //AgentsDropDownList.AppendDataBoundItems = true;
            //AgentsDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
            //AgentsDropDownList.DataBind();

            /*DataSet ds27 = Queries.LoadAgentsIVO(MarketingProgramDropDownList.SelectedItem.Text);
            AgentNameDropDownList.DataSource = ds27;
            AgentNameDropDownList.DataTextField = "Agent_Name";
            AgentNameDropDownList.DataValueField = "Agent_Name";
            AgentNameDropDownList.AppendDataBoundItems = true;
            AgentNameDropDownList.Items.Insert(0, new ListItem("", ""));
            AgentNameDropDownList.DataBind();*/

            Memno1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();

            Memno2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();

           



            contsalesrepDropDownList.Items.Clear();
            DataSet ds7 = Queries2.LoadSalesReps(vencountry, VenueDropDownListval);
            contsalesrepDropDownList.DataSource = ds7;
            contsalesrepDropDownList.DataTextField = "Sales_Rep_Name";
            contsalesrepDropDownList.DataValueField = "Sales_Rep_Name";
            contsalesrepDropDownList.AppendDataBoundItems = true;
            contsalesrepDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
            contsalesrepDropDownList.DataBind();

           /* secondarytitleDropDownList.DataSource = ds4;
            secondarytitleDropDownList.DataTextField = "Profile_Secondary_Title";
            secondarytitleDropDownList.DataValueField = "Profile_Secondary_Title";
            secondarytitleDropDownList.DataBind();

            Memno1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
            Memno2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();

            pfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();



            sfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            slnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();

            secondarynationalityDropDownList.DataSource = ds4;
            secondarynationalityDropDownList.DataTextField = "Profile_Secondary_Nationality";
            secondarynationalityDropDownList.DataValueField = "Profile_Secondary_Nationality";
            secondarynationalityDropDownList.DataBind();

           // SecCountryDropDownList.DataSource = ds4;
           // SecCountryDropDownList.DataTextField = "Profile_Primary_Country";
           // SecCountryDropDownList.DataValueField = "Profile_Primary_Country";
          //  SecCountryDropDownList.DataBind();

            pmobileTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            pemailTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Email"].ToString();
            employmentstatusDropDownList.DataSource = ds4;
            employmentstatusDropDownList.DataTextField = "Profile_Employment_status";
            employmentstatusDropDownList.DataValueField = "Profile_Employment_status";
            employmentstatusDropDownList.DataBind();

            MaritalStatusDropDownList.DataSource = ds4;
            MaritalStatusDropDownList.DataTextField = "Profile_Marital_status";
            MaritalStatusDropDownList.DataValueField = "Profile_Marital_status";
            MaritalStatusDropDownList.DataBind();

            datepicker1.Text = ds4.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString();

            hotelTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();*/

            //string datear = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd"); ; 
            // datepicker5.Text = DateTime.datear.ToString();
            // datepicker5.Text
            //Response.Write(datear);
            //DateTime dae = DateTime.ParseExact(datear, "yyyy/MM/dd", null);
            //datepicker5.Text = datear;

            //AgentCodeDropDownList.Items.Clear();
            //DataSet ds29 = Queries.LoadProfileAgentCode(ProfileID);
            //AgentCodeDropDownList.DataSource = ds29;
            //AgentCodeDropDownList.DataTextField = "Agent_Code_Name";
            //AgentCodeDropDownList.DataValueField = "Agent_Code_Name";
            //AgentCodeDropDownList.AppendDataBoundItems = true;
            //AgentCodeDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            //AgentCodeDropDownList.DataBind();

            MemType1DropDownList.Items.Clear();
            DataSet ds30 = Queries.LoadMemberType();
            MemType1DropDownList.DataSource = ds30;
            MemType1DropDownList.DataTextField = "Member_Type_name";
            MemType1DropDownList.DataValueField = "Member_Type_name";
            MemType1DropDownList.AppendDataBoundItems = true;
            MemType1DropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
            MemType1DropDownList.DataBind();

            MemType2DropDownList.Items.Clear();
            DataSet ds31 = Queries.LoadMemberType();
            MemType2DropDownList.DataSource = ds31;
            MemType2DropDownList.DataTextField = "Member_Type_name";
            MemType2DropDownList.DataValueField = "Member_Type_name";
            MemType2DropDownList.AppendDataBoundItems = true;
            MemType2DropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Member_Type2"].ToString(), ""));
            MemType2DropDownList.DataBind();

            Memno1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
            //   MemType2DropDownList.SelectedItem.Text = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
            Memno2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();

            //employmentstatusDropDownList.Items.Clear();
            //employmentstatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Employment_status"].ToString());
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
            employmentstatusDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            employmentstatusDropDownList.DataBind();

            DataSet Secondemploy = Queries.LoadEmploymentStatus();
            SecondemploymentstatusDropDownList.DataSource = Secondemploy;
            SecondemploymentstatusDropDownList.DataTextField = "Name";
            SecondemploymentstatusDropDownList.DataValueField = "Name";
            SecondemploymentstatusDropDownList.AppendDataBoundItems = true;
            SecondemploymentstatusDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_Employment_Status"].ToString(), ""));
            SecondemploymentstatusDropDownList.DataBind();


            //MaritalStatusDropDownList.Items.Clear();
            //MaritalStatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Marital_status"].ToString());
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
            MaritalStatusDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
            MaritalStatusDropDownList.DataBind();

            livingyrsTextBox.Text = ds4.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();

            //primarytitleDropDownList.Items.Clear();
            //primarytitleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            //primarytitleDropDownList.Items.Add("Mr");
            //primarytitleDropDownList.Items.Add("Ms");
            //primarytitleDropDownList.Items.Add("Mrs");
            //primarytitleDropDownList.Items.Add("Adv");
            //primarytitleDropDownList.Items.Add("Dr");


            DataSet dsptitle = Queries2.LoadSalutations(office);
            primarytitleDropDownList.DataSource = dsptitle;
            primarytitleDropDownList.DataTextField = "Salutation";
            primarytitleDropDownList.DataValueField = "Salutation";
            primarytitleDropDownList.AppendDataBoundItems = true;
            primarytitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
            primarytitleDropDownList.DataBind();

            //DataSet ds32 = Queries.LoadCountryPrimary(ProfileID);
            //PrimaryCountryDropDownList.DataSource = ds32;
            //PrimaryCountryDropDownList.DataTextField = "country_name";
            //PrimaryCountryDropDownList.DataValueField = "country_name";
            //PrimaryCountryDropDownList.AppendDataBoundItems = true;
            //PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            //PrimaryCountryDropDownList.DataBind();



            DataSet ds33 = Queries2.LoadCountryWithCodePrimaryMobile(ProfileID);
            primarymobileDropDownList.DataSource = ds33;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            primarymobileDropDownList.DataBind();

            DataSet ds34 = Queries2.LoadCountryWithCodePrimaryAlt(ProfileID);
            primaryalternateDropDownList.DataSource = ds34;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            primaryalternateDropDownList.DataBind();

            pmobileTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Mobile"].ToString();
           palternateTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            pemailTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Email"].ToString();
            pemailTextBox2.Text = ds4.Tables[0].Rows[0]["Primary_Email2"].ToString();


            //secondary profile

            //secondarytitleDropDownList.Items.Clear();
            //secondarytitleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString());
            //secondarytitleDropDownList.Items.Add("Mr");
            //secondarytitleDropDownList.Items.Add("Ms");
            //secondarytitleDropDownList.Items.Add("Mrs");
            //secondarytitleDropDownList.Items.Add("Adv");
            //secondarytitleDropDownList.Items.Add("Dr");

            DataSet dsstitle = Queries2.LoadSalutations(office);
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString(), ""));
            secondarytitleDropDownList.DataBind();



            sfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            slnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            //
            string datep1 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Primary_DOB"]);
            
            if (datep1 == "" || datep1 == "01-01-1900")
                //string datep1 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Primary_DOB"]).ToString("yyyy-MM-dd");
           // if (datep1 == " " || datep1 == "1900-01-01")
            {
                datepicker1.Text = "";
            }
            else
            {
                datepicker1.Text = datep1;
            }

            string datep2 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Secondary_DOB"]);

            if (datep2 == "" || datep2 == "01-01-1900")


               // string datep2 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Secondary_DOB"]).ToString("yyyy-MM-dd");

           // if (datep2 == " " || datep2== "1900-01-01")
            {
                datepicker2.Text = "";
            }
            else
            {
                datepicker2.Text = datep2;
            }

            DataSet seconnat = Queries2.LoadNationalityWithoutPrevValSecondary(ProfileID);
            secondarynationalityDropDownList.DataSource = seconnat;
            secondarynationalityDropDownList.DataTextField = "nationality_name";
            secondarynationalityDropDownList.DataValueField = "nationality_name";
            secondarynationalityDropDownList.AppendDataBoundItems = true;
            secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString(), ""));
            secondarynationalityDropDownList.DataBind();
            //secondarynationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString());


            //DataSet ds35 = Queries.LoadCountrySecondary(ProfileID);
            //SecondaryCountryDropDownList.DataSource = ds35;
            //SecondaryCountryDropDownList.DataTextField = "country_name";
            //SecondaryCountryDropDownList.DataValueField = "country_name";
            //SecondaryCountryDropDownList.AppendDataBoundItems = true;
            //SecondaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString(), ""));
            //SecondaryCountryDropDownList.DataBind();

            SecondaryCountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString());

            DataSet ds36 = Queries2.LoadCountryWithCodeSecondaryMobile(ProfileID);
            secondarymobileDropDownList.DataSource = ds36;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_CC"].ToString(), ""));
            secondarymobileDropDownList.DataBind();

            DataSet ds37 = Queries2.LoadCountryWithCodeSecondaryAlt(ProfileID);
            secondaryalternateDropDownList.DataSource = ds37;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString(), ""));
            secondaryalternateDropDownList.DataBind();

            smobileTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            salternateTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            semailTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Email"].ToString();
            semailTextBox2.Text = ds4.Tables[0].Rows[0]["Secondary_Email2"].ToString();
            //subprofile 1
            //subprofile1titleDropDownList.Items.Clear();
            //subprofile1titleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            //subprofile1titleDropDownList.Items.Add("Mr");
            //subprofile1titleDropDownList.Items.Add("Ms");
            //subprofile1titleDropDownList.Items.Add("Mrs");
            //subprofile1titleDropDownList.Items.Add("Adv");
            //subprofile1titleDropDownList.Items.Add("Dr");

            DataSet dssp1title = Queries2.LoadSalutations(office);
            subprofile1titleDropDownList.DataSource = dssp1title;
            subprofile1titleDropDownList.DataTextField = "Salutation";
            subprofile1titleDropDownList.DataValueField = "Salutation";
            subprofile1titleDropDownList.AppendDataBoundItems = true;
            subprofile1titleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
            subprofile1titleDropDownList.DataBind();



            //  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            sp1fnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            //datepicker3.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString();

            string datep3 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Sub_Profile1_DOB"]);
            if (datep3 == " " || datep3 == "01-01-1900")


               // string datep3 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile1_DOB"]).ToString("yyyy-MM-dd");

           // if (datep3 == " " || datep3 == "1900-01-01")
            {
                datepicker3.Text = "";
            }
            else
            {
                datepicker3.Text = datep3;
            }

            DataSet sp1nat = Queries2.LoadNationalityWithoutPrevValSP1(ProfileID);
            subprofile1nationalityDropDownList.DataSource = sp1nat;
            subprofile1nationalityDropDownList.DataTextField = "nationality_name";
            subprofile1nationalityDropDownList.DataValueField = "nationality_name";
            subprofile1nationalityDropDownList.AppendDataBoundItems = true;
            subprofile1nationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
            subprofile1nationalityDropDownList.DataBind();
            //subprofile1nationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString());

            //DataSet ds38 = Queries.LoadCountrySP1(ProfileID);
            //SubProfile1CountryDropDownList.DataSource = ds38;
            //SubProfile1CountryDropDownList.DataTextField = "country_name";
            //SubProfile1CountryDropDownList.DataValueField = "country_name";
            //SubProfile1CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            //SubProfile1CountryDropDownList.DataBind();


            //DataSet ds38 = Queries2.LoadCountryPrevVal(ProfileID, "SP1");
            //SubProfile1CountryDropDownList.DataSource = ds38;
            //SubProfile1CountryDropDownList.DataTextField = "country_name";
            //SubProfile1CountryDropDownList.DataValueField = "country_name";
            //SubProfile1CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            //SubProfile1CountryDropDownList.DataBind();



            SubProfile1CountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString());


            DataSet ds39 = Queries2.LoadCountryWithCodeSP1Mobile(ProfileID);
            subprofile1mobileDropDownList.DataSource = ds39;
            subprofile1mobileDropDownList.DataTextField = "name";
            subprofile1mobileDropDownList.DataValueField = "name";
            subprofile1mobileDropDownList.AppendDataBoundItems = true;
            subprofile1mobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            subprofile1mobileDropDownList.DataBind();
            DataSet ds40 = Queries2.LoadCountryWithCodeSP1Alt(ProfileID);
            subprofile1alternateDropDownList.DataSource = ds40;
            subprofile1alternateDropDownList.DataTextField = "name";
            subprofile1alternateDropDownList.DataValueField = "name";
            subprofile1alternateDropDownList.AppendDataBoundItems = true;
            subprofile1alternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            subprofile1alternateDropDownList.DataBind();


            sp1mobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            sp1alternateTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            sp1emailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
            sp1emailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile1_Email2"].ToString();

            //subprofile2
            //subprofile2titleDropDownList.Items.Clear();
            //subprofile2titleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //subprofile2titleDropDownList.Items.Add("Mr");
            //subprofile2titleDropDownList.Items.Add("Ms");
            //subprofile2titleDropDownList.Items.Add("Mrs");
            //subprofile2titleDropDownList.Items.Add("Adv");
            //subprofile2titleDropDownList.Items.Add("Dr");

            DataSet dssp2title = Queries2.LoadSalutations(office);
            subprofile2titleDropDownList.DataSource = dssp2title;
            subprofile2titleDropDownList.DataTextField = "Salutation";
            subprofile2titleDropDownList.DataValueField = "Salutation";
            subprofile2titleDropDownList.AppendDataBoundItems = true;
            subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            subprofile2titleDropDownList.DataBind();

            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            sp2fnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            // datepicker4.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString();

            string datep4 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"]);
            if (datep4 == " " || datep4 == "01-01-1900")


               // string datep4 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

           // if (datep4 == " " || datep4 == "1900-01-01")
            {
                datepicker4.Text = "";
            }
            else
            {
                datepicker4.Text = datep4;
            }

            DataSet sp2nat = Queries2.LoadNationalityWithoutPrevValSP2(ProfileID);
            subprofile2nationalityDropDownList.DataSource = sp2nat;
            subprofile2nationalityDropDownList.DataTextField = "nationality_name";
            subprofile2nationalityDropDownList.DataValueField = "nationality_name";
            subprofile2nationalityDropDownList.AppendDataBoundItems = true;
            subprofile2nationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
            subprofile2nationalityDropDownList.DataBind();
            //subprofile2nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());

            //subprofile2nationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());

            //DataSet ds41 = Queries.LoadCountrySP2(ProfileID);
            //SubProfile2CountryDropDownList.DataSource = ds41;
            //SubProfile2CountryDropDownList.DataTextField = "country_name";
            //SubProfile2CountryDropDownList.DataValueField = "country_name";
            //SubProfile2CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            //SubProfile2CountryDropDownList.DataBind();

            //DataSet ds41 = Queries2.LoadCountryPrevVal(ProfileID, "SP2");
            //SubProfile2CountryDropDownList.DataSource = ds41;
            //SubProfile2CountryDropDownList.DataTextField = "country_name";
            //SubProfile2CountryDropDownList.DataValueField = "country_name";
            //SubProfile2CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            //SubProfile2CountryDropDownList.DataBind();



            SubProfile2CountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString());

            DataSet ds42 = Queries2.LoadCountryWithCodeSP2Mobile(ProfileID);
            subprofile2mobileDropDownList.DataSource = ds42;
            subprofile2mobileDropDownList.DataTextField = "name";
            subprofile2mobileDropDownList.DataValueField = "name";
            subprofile2mobileDropDownList.AppendDataBoundItems = true;
            subprofile2mobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            subprofile2mobileDropDownList.DataBind();

            DataSet ds43 = Queries2.LoadCountryWithCodeSP2Alt(ProfileID);
            subprofile2alternateDropDownList.DataSource = ds43;
            subprofile2alternateDropDownList.DataTextField = "name";
            subprofile2alternateDropDownList.DataValueField = "name";
            subprofile2alternateDropDownList.AppendDataBoundItems = true;
            subprofile2alternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            subprofile2alternateDropDownList.DataBind();


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


            sp2mobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            sp2alternateTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
            sp2emailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
            sp2emailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile2_Email2"].ToString();

            address1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            address2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            stateTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            cityTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            pincodeTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();


            DataSet ds64 = Queries2.LoadCountryName();
            AddCountryDropDownList.DataSource = ds64;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
            AddCountryDropDownList.DataBind();




            //sub profile 3

            DataSet dssp3title = Queries2.LoadSalutations(office);
            SubP3TitleDropDownList.DataSource = dssp3title;
            SubP3TitleDropDownList.DataTextField = "Salutation";
            SubP3TitleDropDownList.DataValueField = "Salutation";
            SubP3TitleDropDownList.AppendDataBoundItems = true;
            SubP3TitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString(), ""));
            SubP3TitleDropDownList.DataBind();

            
            SubP3FnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
            if (SubP3FnameTextBox.Text != "")
            {
                SubP3LnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
                //sp2dobdatepicker.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");


                string datesp3 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Sub_Profile3_DOB"]);
                if (datesp3 == " " || datesp3 == "01-01-1900")

                 //   string datesp3 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile3_DOB"]).ToString("yyyy-MM-dd");

               // if (datesp3 == " " || datesp3 == "1900-01-01")
                {
                    SubP3DOB.Text = "";
                }
                else
                {
                    SubP3DOB.Text = datesp3;
                }

               


                SubP3MobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
                SubP3AMobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
                SubP3EmailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
                SubP3EmailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile3_Email2"].ToString();
            }

            DataSet sp3nat = Queries2.LoadNationalityWithoutPrevValSP3(ProfileID);
            SubP3NationalityDropDownList.DataSource = sp3nat;
            SubP3NationalityDropDownList.DataTextField = "nationality_name";
            SubP3NationalityDropDownList.DataValueField = "nationality_name";
            SubP3NationalityDropDownList.AppendDataBoundItems = true;
            SubP3NationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
            SubP3NationalityDropDownList.DataBind();

            //DataSet dsp311 = Queries.LoadCountrySP2(ProfileID);
            //SubP3CountryDropDownList.DataSource = dsp311;
            //SubP3CountryDropDownList.DataTextField = "country_name";
            //SubP3CountryDropDownList.DataValueField = "country_name";
            //SubP3CountryDropDownList.AppendDataBoundItems = true;
            //SubP3CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
            //SubP3CountryDropDownList.DataBind();


            //DataSet dsp311 = Queries2.LoadCountryPrevVal(ProfileID, "SP3");
            //SubP3CountryDropDownList.DataSource = dsp311;
            //SubP3CountryDropDownList.DataTextField = "country_name";
            //SubP3CountryDropDownList.DataValueField = "country_name";
            //SubP3CountryDropDownList.AppendDataBoundItems = true;
            //SubP3CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
            //SubP3CountryDropDownList.DataBind();


            SubP3CountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString());


            DataSet dssp3 = Queries2.LoadCountryWithCodeSP3Mobile(ProfileID);
            SubP3CCDropDownList.DataSource = dssp3;
            SubP3CCDropDownList.DataTextField = "name";
            SubP3CCDropDownList.DataValueField = "name";
            SubP3CCDropDownList.AppendDataBoundItems = true;
            SubP3CCDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile3_CC"].ToString(), ""));
            SubP3CCDropDownList.DataBind();

            DataSet dsspalt3 = Queries2.LoadCountryWithCodeSP3Alt(ProfileID);
            SubP3CCDropDownList2.DataSource = dsspalt3;
            SubP3CCDropDownList2.DataTextField = "name";
            SubP3CCDropDownList2.DataValueField = "name";
            SubP3CCDropDownList2.AppendDataBoundItems = true;
            SubP3CCDropDownList2.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString(), ""));
            SubP3CCDropDownList2.DataBind();

            //sub profile 4

            DataSet dssp4title = Queries2.LoadSalutations(office);
            SubP4TitleDropDownList.DataSource = dssp4title;
            SubP4TitleDropDownList.DataTextField = "Salutation";
            SubP4TitleDropDownList.DataValueField = "Salutation";
            SubP4TitleDropDownList.AppendDataBoundItems = true;
            SubP4TitleDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString(), ""));
            SubP4TitleDropDownList.DataBind();

            string tvenue = ds4.Tables[0].Rows[0]["Profile_Venue"].ToString();

            if (tvenue == "Flybuys")
            {
                DataSet OfficeSou = Queries2.LoadOfficeSource();

                OfficeSourceDropDownList.DataSource = OfficeSou;
                OfficeSourceDropDownList.DataTextField = "Office_Source_Name";
                OfficeSourceDropDownList.DataValueField = "Office_Source_Name";
                OfficeSourceDropDownList.AppendDataBoundItems = true;
                OfficeSourceDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                OfficeSourceDropDownList.DataBind();



                DataSet Flyage = Queries2.LoadFlybuyAgent();

                FAgentDropDownList.DataSource = Flyage;
                FAgentDropDownList.DataTextField = "FAgent_Name";
                FAgentDropDownList.DataValueField = "FAgent_Name";
                FAgentDropDownList.AppendDataBoundItems = true;
                FAgentDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
                FAgentDropDownList.DataBind();



                DataSet LeaSou = Queries2.LoadLeadSource();

                DropDownListFly.DataSource = LeaSou;
                DropDownListFly.DataTextField = "Lead_Source_Name";
                DropDownListFly.DataValueField = "Lead_Source_Name";
                DropDownListFly.AppendDataBoundItems = true;
                DropDownListFly.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Lead_Source"].ToString(), ""));
                DropDownListFly.DataBind();

                DataSet PreArr = Queries2.LoadPreArrival();

                PreArrivalDropDownList.DataSource = PreArr;
                PreArrivalDropDownList.DataTextField = "Pre_Arrival_Name";
                PreArrivalDropDownList.DataValueField = "Pre_Arrival_Name";
                PreArrivalDropDownList.AppendDataBoundItems = true;
                PreArrivalDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Pre_Arrival"].ToString(), ""));
                PreArrivalDropDownList.DataBind();

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
            SubP4FnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
            if (SubP4FnameTextBox.Text != "")
            {
                SubP4LnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
                //sp2dobdatepicker.Text = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");


                string datesp4 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Sub_Profile4_DOB"]);
                if (datesp4 == " " || datesp4 == "01-01-1900")

                {
                    SubP4DOB.Text = "";
                }
                else
                {
                    SubP4DOB.Text = datesp4;
                }

               


                SubP4MobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
                SubP4AMobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
                SubP4EmailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile4_Email"].ToString();
                SubP4EmailTextBox2.Text = ds4.Tables[0].Rows[0]["Subprofile4_Email2"].ToString();

            }

            DataSet sp4nat = Queries2.LoadNationalityWithoutPrevValSP4(ProfileID);
            SubP4NationalityDropDownList.DataSource = sp4nat;
            SubP4NationalityDropDownList.DataTextField = "nationality_name";
            SubP4NationalityDropDownList.DataValueField = "nationality_name";
            SubP4NationalityDropDownList.AppendDataBoundItems = true;
            SubP4NationalityDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
            SubP4NationalityDropDownList.DataBind();


            //DataSet dsp411 = Queries.LoadCountrySP2(ProfileID);
            //SubP4CountryDropDownList.DataSource = dsp411;
            //SubP4CountryDropDownList.DataTextField = "country_name";
            //SubP4CountryDropDownList.DataValueField = "country_name";
            //SubP4CountryDropDownList.AppendDataBoundItems = true;
            //SubP4CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
            //SubP4CountryDropDownList.DataBind();

            //DataSet dsp411 = Queries2.LoadCountryPrevVal(ProfileID, "SP4");
            //SubP4CountryDropDownList.DataSource = dsp411;
            //SubP4CountryDropDownList.DataTextField = "country_name";
            //SubP4CountryDropDownList.DataValueField = "country_name";
            //SubP4CountryDropDownList.AppendDataBoundItems = true;
            //SubP4CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
            //SubP4CountryDropDownList.DataBind();

            SubP4CountryDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString());



            DataSet dssp4 = Queries2.LoadCountryWithCodeSP4Mobile(ProfileID);
            SubP4CCDropDownList.DataSource = dssp4;
            SubP4CCDropDownList.DataTextField = "name";
            SubP4CCDropDownList.DataValueField = "name";
            SubP4CCDropDownList.AppendDataBoundItems = true;
            SubP4CCDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile4_CC"].ToString(), ""));
            SubP4CCDropDownList.DataBind();

            DataSet dsspalt4 = Queries2.LoadCountryWithCodeSP4Alt(ProfileID);
            SubP4CCDropDownList2.DataSource = dsspalt4;
            SubP4CCDropDownList2.DataTextField = "name";
            SubP4CCDropDownList2.DataValueField = "name";
            SubP4CCDropDownList2.AppendDataBoundItems = true;
            SubP4CCDropDownList2.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString(), ""));
            SubP4CCDropDownList2.DataBind();






            //stay details
            hotelTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            roomnoTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            datepicker5.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString();
            datepicker6.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString();

            string datep5 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]);
            if (datep5 == " " || datep5 == "01-01-1900")


            //    string datep5 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd");

            //if (datep5 == " " || datep5 == "1900-01-01")
            {
                datepicker5.Text = "";
            }
            else
            {
                datepicker5.Text = datep5;
            }


            string datep6 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]);
            if (datep6 == " " || datep6 == "01-01-1900")

            //    string datep6 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToString("yyyy-MM-dd");
            
            //if (datep6 == " " || datep6 == "1900-01-01")
            {
                datepicker6.Text = "";
            }
            else
            {
                datepicker6.Text = datep6;
            }


            //guest status

            DataSet dsgs = Queries.LoadGuestStatus();
            gueststatusDropDownList.DataSource = dsgs;
            gueststatusDropDownList.DataTextField = "Guest_Status_name";
            gueststatusDropDownList.DataValueField = "Guest_Status_name";
            gueststatusDropDownList.AppendDataBoundItems = true;
            gueststatusDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            gueststatusDropDownList.DataBind();


            

           // gueststatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString());
           // salesrepDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());
            //contsalesrepDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());
            deckcheckintimeTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            deckcheckouttimeTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            //tourdatedatepicker.Text = ds4.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString();

            string datep7 = String.Format("{0:dd-MM-yyyy}", ds4.Tables[0].Rows[0]["Tour_Details_Tour_Date"]);
            if (datep7 == " " || datep7 == "01-01-1900")

               // string datep7 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToString("yyyy-MM-dd");

            //if (datep7 == " " || datep7 == "1900-01-01")
            {
                tourdatedatepicker.Text = "";
            }
            else
            {
                tourdatedatepicker.Text = datep7;
            }



            taxipriceInTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            TaxiRefInTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            TaxiPriceOutTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            TaxiRefOutTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();

            officeo = Queries2.getoffice(ProfileID);

            DataSet dssr = Queries2.LoadSalesReps(vencountry, VenueDropDownListval);
            salesrepDropDownList.DataSource = dssr;
            salesrepDropDownList.DataTextField = "sales_rep_name";
            salesrepDropDownList.DataValueField = "sales_rep_name";
            salesrepDropDownList.AppendDataBoundItems = true;
            salesrepDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
            salesrepDropDownList.DataBind();


            string[] ar = new string[10];
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

            if (string.IsNullOrEmpty(ar[0]) == false)
            //if (ar[0] != "" || ar[0] != null)
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
                TextBoxGPrice1.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToDouble(dr[0]));//string.Format("{0:n0}", dr[0]);//dr[0];

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
            //if (ar[4] != "" || ar[4] != null)
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


            TextVPID.Text = ds4.Tables[0].Rows[0]["VP_ID"].ToString();
            TextPrimaryAge.Text = ds4.Tables[0].Rows[0]["Primary_Age"].ToString();
            TextSecondAge.Text = ds4.Tables[0].Rows[0]["Secondary_Age"].ToString();
            TextSP1Age.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();
            TextSP2Age.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();
            TextSP3Age.Text = ds4.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();
            TextSP4Age.Text = ds4.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

            DataSet dsepr = Queries2.LoadQStatus();
            QStatusDropDownList1.DataSource = dsepr;
            QStatusDropDownList1.DataTextField = "Qstatus_Name";
            QStatusDropDownList1.DataValueField = "Qstatus_Name";
            QStatusDropDownList1.AppendDataBoundItems = true;
            QStatusDropDownList1.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Tour_Details_Qualified_Status"].ToString(), ""));
            QStatusDropDownList1.DataBind();

            string check = ds4.Tables[0].Rows[0]["RegTerms"].ToString();

            if (check == "Y")
            {
                Regterms1.Checked = true;
            }
            else
            {
                Regterms1.Checked = false;
            }

            string check2 = ds4.Tables[0].Rows[0]["RegTerms2"].ToString();

            if (check2 == "Y")
            {
                Regterms2.Checked = true;
            }
            else
            {
                Regterms2.Checked = false;
            }



            DataSet ds1 = Queries2.LoadEntitlement();
            EntitlementFracDropDownList.DataSource = ds1;
            EntitlementFracDropDownList.DataTextField = "Entitlement_Name";
            EntitlementFracDropDownList.DataValueField = "Entitlement_Name";
            EntitlementFracDropDownList.AppendDataBoundItems = true;
            EntitlementFracDropDownList.Items.Insert(0, new ListItem("", ""));
            EntitlementFracDropDownList.DataBind();

            //Response.Redirect("WebSite5\production\Dashboard.aspx");

            DataSet ds2 = Queries2.LoadEntitlement();
            EntitlementPoinDropDownList.DataSource = ds2;
            EntitlementPoinDropDownList.DataTextField = "Entitlement_Name";
            EntitlementPoinDropDownList.DataValueField = "Entitlement_Name";
            EntitlementPoinDropDownList.AppendDataBoundItems = true;
            EntitlementPoinDropDownList.Items.Insert(0, new ListItem("", ""));
            EntitlementPoinDropDownList.DataBind();

            DataSet ds3 = Queries2.LoadEntitlement();
            EntitlementTPoinDropDownList.DataSource = ds3;
            EntitlementTPoinDropDownList.DataTextField = "Entitlement_Name";
            EntitlementTPoinDropDownList.DataValueField = "Entitlement_Name";
            EntitlementTPoinDropDownList.AppendDataBoundItems = true;
            EntitlementTPoinDropDownList.Items.Insert(0, new ListItem("", ""));
            EntitlementTPoinDropDownList.DataBind();



            DataSet ds5 = Queries2.LoadEntitlement();
            EntitlementTFracDropDownList.DataSource = ds5;
            EntitlementTFracDropDownList.DataTextField = "Entitlement_Name";
            EntitlementTFracDropDownList.DataValueField = "Entitlement_Name";
            EntitlementTFracDropDownList.AppendDataBoundItems = true;
            EntitlementTFracDropDownList.Items.Insert(0, new ListItem("", ""));
            EntitlementTFracDropDownList.DataBind();

            DataSet ds6 = Queries2.LoadPayMethod();
            PayMethodDropDownList.DataSource = ds6;
            PayMethodDropDownList.DataTextField = "pay_method_name";
            PayMethodDropDownList.DataValueField = "pay_method_name";
            PayMethodDropDownList.AppendDataBoundItems = true;
            PayMethodDropDownList.Items.Insert(0, new ListItem("", ""));
            PayMethodDropDownList.DataBind();

            DataSet ds9 = Queries2.LoadFinanceCurrency();
            FinanceCurrencyDropDownList.DataSource = ds9;
            FinanceCurrencyDropDownList.DataTextField = "Finance_Currency_Name";
            FinanceCurrencyDropDownList.DataValueField = "Finance_Currency_Name";
            FinanceCurrencyDropDownList.AppendDataBoundItems = true;
            FinanceCurrencyDropDownList.Items.Insert(0, new ListItem("USD", ""));
            FinanceCurrencyDropDownList.DataBind();

            DataSet ds10 = Queries2.LoadDepositPayMethod(officeo);
            DPMFractDropDownList.DataSource = ds10;
            DPMFractDropDownList.DataTextField = "Deposit_pay_method_name";
            DPMFractDropDownList.DataValueField = "Deposit_pay_method_name";
            DPMFractDropDownList.AppendDataBoundItems = true;
            DPMFractDropDownList.Items.Insert(0, new ListItem("", ""));
            DPMFractDropDownList.DataBind();

            //DataSet ds11 = Queries2.LoadDepositPayMethod(officeo);
            //DPMPointsDropDownList.DataSource = ds11;
            //DPMPointsDropDownList.DataTextField = "Deposit_pay_method_name";
            //DPMPointsDropDownList.DataValueField = "Deposit_pay_method_name";
            //DPMPointsDropDownList.AppendDataBoundItems = true;
            //DPMPointsDropDownList.Items.Insert(0, new ListItem("", ""));
            //DPMPointsDropDownList.DataBind();

            //DataSet ds12 = Queries2.LoadDepositPayMethod(officeo);
            //DPMTFractDropDownList.DataSource = ds12;
            //DPMTFractDropDownList.DataTextField = "Deposit_pay_method_name";
            //DPMTFractDropDownList.DataValueField = "Deposit_pay_method_name";
            //DPMTFractDropDownList.AppendDataBoundItems = true;
            //DPMTFractDropDownList.Items.Insert(0, new ListItem("", ""));
            //DPMTFractDropDownList.DataBind();

            //DataSet ds13 = Queries2.LoadDepositPayMethod(officeo);
            //DPMTPointsDropDownList.DataSource = ds13;
            //DPMTPointsDropDownList.DataTextField = "Deposit_pay_method_name";
            //DPMTPointsDropDownList.DataValueField = "Deposit_pay_method_name";
            //DPMTPointsDropDownList.AppendDataBoundItems = true;
            //DPMTPointsDropDownList.Items.Insert(0, new ListItem("", ""));
            //DPMTPointsDropDownList.DataBind();

            //DataSet ds14 = Queries2.LoadDepositPayMethod(officeo);
            //BPMDropDownList.DataSource = ds14;
            //BPMDropDownList.DataTextField = "Deposit_pay_method_name";
            //BPMDropDownList.DataValueField = "Deposit_pay_method_name";
            //BPMDropDownList.AppendDataBoundItems = true;
            //BPMDropDownList.Items.Insert(0, new ListItem("", ""));
            //BPMDropDownList.DataBind();

            DataSet ds15 = Queries2.LoadDealDrawer();
            DealDrawerDropDownList.DataSource = ds15;
            DealDrawerDropDownList.DataTextField = "Deal_Drawer_Name";
            DealDrawerDropDownList.DataValueField = "Deal_Drawer_Name";
            DealDrawerDropDownList.AppendDataBoundItems = true;
            DealDrawerDropDownList.Items.Insert(0, new ListItem("", ""));
            DealDrawerDropDownList.DataBind();

           

            DataSet ds16 = Queries2.LoadContractClub(officeo);
            ContractClubPDropDownList.DataSource = ds16;
            ContractClubPDropDownList.DataTextField = "Contract_Club_Name";
            ContractClubPDropDownList.DataValueField = "Contract_Club_Name";
            ContractClubPDropDownList.AppendDataBoundItems = true;
            ContractClubPDropDownList.Items.Insert(0, new ListItem("", ""));
            ContractClubPDropDownList.DataBind();

            DataSet ds17 = Queries2.LoadContractClub(officeo);
            ContractClubTPDropDownList1.DataSource = ds17;
            ContractClubTPDropDownList1.DataTextField = "Contract_Club_Name";
            ContractClubTPDropDownList1.DataValueField = "Contract_Club_Name";
            ContractClubTPDropDownList1.AppendDataBoundItems = true;
            ContractClubTPDropDownList1.Items.Insert(0, new ListItem("", ""));
            ContractClubTPDropDownList1.DataBind();

            DataSet ds18 = Queries2.LoadContractClub(officeo);
            ContractClubTPDropDownList2.DataSource = ds18;
            ContractClubTPDropDownList2.DataTextField = "Contract_Club_Name";
            ContractClubTPDropDownList2.DataValueField = "Contract_Club_Name";
            ContractClubTPDropDownList2.AppendDataBoundItems = true;
            ContractClubTPDropDownList2.Items.Insert(0, new ListItem("", ""));
            ContractClubTPDropDownList2.DataBind();

           
            //= office;

            DataSet ds19 = Queries2.LoadTOManager(officeo, VenueDropDownListval,vencountry);
            TOManagerDropDownList.DataSource = ds19;
            TOManagerDropDownList.DataTextField = "TO_Manager_name";
            TOManagerDropDownList.DataValueField = "TO_Manager_name";
            TOManagerDropDownList.AppendDataBoundItems = true;
            TOManagerDropDownList.Items.Insert(0, new ListItem("", ""));
            TOManagerDropDownList.DataBind();

            DataSet ds20 = Queries2.LoadButtonUp(officeo, VenueDropDownListval,vencountry);
            ButtonUpDropDownList.DataSource = ds20;
            ButtonUpDropDownList.DataTextField = "ButtonUp_Name";
            ButtonUpDropDownList.DataValueField = "ButtonUp_Name";
            ButtonUpDropDownList.AppendDataBoundItems = true;
            ButtonUpDropDownList.Items.Insert(0, new ListItem("", ""));
            ButtonUpDropDownList.DataBind();

            DataSet ds21 = Queries2.LoadFractionalI();
            FractionalIDropDownListF.DataSource = ds21;
            FractionalIDropDownListF.DataTextField = "Contract_Fractional_Int_Name";
            FractionalIDropDownListF.DataValueField = "Contract_Fractional_Int_Name";
            FractionalIDropDownListF.AppendDataBoundItems = true;
            FractionalIDropDownListF.Items.Insert(0, new ListItem("", ""));
            FractionalIDropDownListF.DataBind();

            DataSet ds22 = Queries2.LoadCCardType();
            CardPrimaryDropDownList.DataSource = ds22;
            CardPrimaryDropDownList.DataTextField = "Card_Type_Name";
            CardPrimaryDropDownList.DataValueField = "Card_Type_Name";
            CardPrimaryDropDownList.AppendDataBoundItems = true;
            CardPrimaryDropDownList.Items.Insert(0, new ListItem("", ""));
            CardPrimaryDropDownList.DataBind();

            DataSet ds23 = Queries2.LoadCCardType();
            CardSecondaryDropDownList.DataSource = ds23;
            CardSecondaryDropDownList.DataTextField = "Card_Type_Name";
            CardSecondaryDropDownList.DataValueField = "Card_Type_Name";
            CardSecondaryDropDownList.AppendDataBoundItems = true;
            CardSecondaryDropDownList.Items.Insert(0, new ListItem("", ""));
            CardSecondaryDropDownList.DataBind();


            DataSet ds44 = Queries2.LoadSeasType();
            SeasonTPDropDownList.DataSource = ds44;
            SeasonTPDropDownList.DataTextField = "Season_Name";
            SeasonTPDropDownList.DataValueField = "Season_Name";
            SeasonTPDropDownList.AppendDataBoundItems = true;
            SeasonTPDropDownList.Items.Insert(0, new ListItem("", ""));
            SeasonTPDropDownList.DataBind();


            DataSet ds45 = Queries2.LoadEntitlement();
            EntitleTPDropDownList.DataSource = ds45;
            EntitleTPDropDownList.DataTextField = "Entitlement_Name";
            EntitleTPDropDownList.DataValueField = "Entitlement_Name";
            EntitleTPDropDownList.AppendDataBoundItems = true;
            EntitleTPDropDownList.Items.Insert(0, new ListItem("", ""));
            EntitleTPDropDownList.DataBind();

            DataSet ds46 = Queries2.LoadEntitlement();
            EntitlementDropDownList1.DataSource = ds46;
            EntitlementDropDownList1.DataTextField = "Entitlement_Name";
            EntitlementDropDownList1.DataValueField = "Entitlement_Name";
            EntitlementDropDownList1.AppendDataBoundItems = true;
            EntitlementDropDownList1.Items.Insert(0, new ListItem("", ""));
            EntitlementDropDownList1.DataBind();


            DataSet ds47 = Queries2.LoadFracResort();
            ResortTPDropDownList.DataSource = ds47;
            ResortTPDropDownList.DataTextField = "Fract_Resort_Name";
            ResortTPDropDownList.DataValueField = "Fract_Resort_Name";
            ResortTPDropDownList.AppendDataBoundItems = true;
            ResortTPDropDownList.Items.Insert(0, new ListItem("", ""));
            ResortTPDropDownList.DataBind();


      

            DataSet ds48 = Queries2.LoadContPeriod();
            PeriodTPDropDownList.DataSource = ds48;
            PeriodTPDropDownList.DataTextField = "Period_Name";
            PeriodTPDropDownList.DataValueField = "Period_Name";
            PeriodTPDropDownList.AppendDataBoundItems = true;
            PeriodTPDropDownList.Items.Insert(0, new ListItem("", ""));
            PeriodTPDropDownList.DataBind();


            DataSet ds49 = Queries2.LoadContNumbOccu();
            NumbOccuTPDropDownList.DataSource = ds49;
            NumbOccuTPDropDownList.DataTextField = "Numb_Occu_Numb";
            NumbOccuTPDropDownList.DataValueField = "Numb_Occu_Numb";
            NumbOccuTPDropDownList.AppendDataBoundItems = true;
            NumbOccuTPDropDownList.Items.Insert(0, new ListItem("", ""));
            NumbOccuTPDropDownList.DataBind();

            DataSet ds50 = Queries2.LoadApartType();
            AppartmentTypeTPDropDownList.DataSource = ds50;
            AppartmentTypeTPDropDownList.DataTextField = "Apart_Type_Name";
            AppartmentTypeTPDropDownList.DataValueField = "Apart_Type_Name";
            AppartmentTypeTPDropDownList.AppendDataBoundItems = true;
            AppartmentTypeTPDropDownList.Items.Insert(0, new ListItem("", ""));
            AppartmentTypeTPDropDownList.DataBind();

            DataSet ds51 = Queries2.LoadContractClub(officeo);
            OldClubDropDownListTF.DataSource = ds51;
            OldClubDropDownListTF.DataTextField = "Contract_Club_Name";
            OldClubDropDownListTF.DataValueField = "Contract_Club_Name";
            OldClubDropDownListTF.AppendDataBoundItems = true;
            OldClubDropDownListTF.Items.Insert(0, new ListItem("", ""));
            OldClubDropDownListTF.DataBind();

            DataSet ds52 = Queries2.LoadEntitlement();
            EntitleDropDownListTF1.DataSource = ds52;
            EntitleDropDownListTF1.DataTextField = "Entitlement_Name";
            EntitleDropDownListTF1.DataValueField = "Entitlement_Name";
            EntitleDropDownListTF1.AppendDataBoundItems = true;
            EntitleDropDownListTF1.Items.Insert(0, new ListItem("", ""));
            EntitleDropDownListTF1.DataBind();

            DataSet ds53 = Queries2.LoadEntitlement();
            EntitleDropDownListTF2.DataSource = ds53;
            EntitleDropDownListTF2.DataTextField = "Entitlement_Name";
            EntitleDropDownListTF2.DataValueField = "Entitlement_Name";
            EntitleDropDownListTF2.AppendDataBoundItems = true;
            EntitleDropDownListTF2.Items.Insert(0, new ListItem("", ""));
            EntitleDropDownListTF2.DataBind();

            DataSet ds54 = Queries2.LoadEntitlement();
            EntitleDropDownListTF3.DataSource = ds54;
            EntitleDropDownListTF3.DataTextField = "Entitlement_Name";
            EntitleDropDownListTF3.DataValueField = "Entitlement_Name";
            EntitleDropDownListTF3.AppendDataBoundItems = true;
            EntitleDropDownListTF3.Items.Insert(0, new ListItem("", ""));
            EntitleDropDownListTF3.DataBind();


            DataSet ds55 = Queries2.LoadFracResort();
            ResortDropDownListTF1.DataSource = ds55;
            ResortDropDownListTF1.DataTextField = "Fract_Resort_Name";
            ResortDropDownListTF1.DataValueField = "Fract_Resort_Name";
            ResortDropDownListTF1.AppendDataBoundItems = true;
            ResortDropDownListTF1.Items.Insert(0, new ListItem("", ""));
            ResortDropDownListTF1.DataBind();

            DataSet ds56 = Queries2.LoadContPeriod();
            PeriodDropDownListTF.DataSource = ds56;
            PeriodDropDownListTF.DataTextField = "Period_Name";
            PeriodDropDownListTF.DataValueField = "Period_Name";
            PeriodDropDownListTF.AppendDataBoundItems = true;
            PeriodDropDownListTF.Items.Insert(0, new ListItem("", ""));
            PeriodDropDownListTF.DataBind();


            DataSet ds57 = Queries2.LoadContNumbOccu();
            NoOccuDropDownListTF.DataSource = ds57;
            NoOccuDropDownListTF.DataTextField = "Numb_Occu_Numb";
            NoOccuDropDownListTF.DataValueField = "Numb_Occu_Numb";
            NoOccuDropDownListTF.AppendDataBoundItems = true;
            NoOccuDropDownListTF.Items.Insert(0, new ListItem("", ""));
            NoOccuDropDownListTF.DataBind();

            DataSet ds58 = Queries2.LoadApartType();
            AppartTypeDropDownListTF.DataSource = ds58;
            AppartTypeDropDownListTF.DataTextField = "Apart_Type_Name";
            AppartTypeDropDownListTF.DataValueField = "Apart_Type_Name";
            AppartTypeDropDownListTF.AppendDataBoundItems = true;
            AppartTypeDropDownListTF.Items.Insert(0, new ListItem("", ""));
            AppartTypeDropDownListTF.DataBind();

            DataSet ds59 = Queries2.LoadSeasType();
            SeasonDropDownListTF.DataSource = ds59;
            SeasonDropDownListTF.DataTextField = "Season_Name";
            SeasonDropDownListTF.DataValueField = "Season_Name";
            SeasonDropDownListTF.AppendDataBoundItems = true;
            SeasonDropDownListTF.Items.Insert(0, new ListItem("", ""));
            SeasonDropDownListTF.DataBind();

            DataSet ds60 = Queries2.LoadContResort();
            ResortDropDownListTF.DataSource = ds60;
            ResortDropDownListTF.DataTextField = "Contract_Resort_Name";
            ResortDropDownListTF.DataValueField = "Contract_Resort_Name";
            ResortDropDownListTF.AppendDataBoundItems = true;
            ResortDropDownListTF.Items.Insert(0, new ListItem("", ""));
            ResortDropDownListTF.DataBind();

            DataSet ds61 = Queries2.LoadFractionalI();
            FracIntDropDownListTF.DataSource = ds61;
            FracIntDropDownListTF.DataTextField = "Contract_Fractional_Int_Name";
            FracIntDropDownListTF.DataValueField = "Contract_Fractional_Int_Name";
            FracIntDropDownListTF.AppendDataBoundItems = true;
            FracIntDropDownListTF.Items.Insert(0, new ListItem("", ""));
            FracIntDropDownListTF.DataBind();

            DataSet ds62 = Queries2.LoadContResort();
            ResortDropDownListTF3.DataSource = ds62;
            ResortDropDownListTF3.DataTextField = "Contract_Resort_Name";
            ResortDropDownListTF3.DataValueField = "Contract_Resort_Name";
            ResortDropDownListTF3.AppendDataBoundItems = true;
            ResortDropDownListTF3.Items.Insert(0, new ListItem("", ""));
            ResortDropDownListTF3.DataBind();

            DataSet ds63 = Queries2.LoadFractionalI();
            FracIntDropDownListTF1.DataSource = ds63;
            FracIntDropDownListTF1.DataTextField = "Contract_Fractional_Int_Name";
            FracIntDropDownListTF1.DataValueField = "Contract_Fractional_Int_Name";
            FracIntDropDownListTF1.AppendDataBoundItems = true;
            FracIntDropDownListTF1.Items.Insert(0, new ListItem("", ""));
            FracIntDropDownListTF1.DataBind();


            //DataTable dt = Queries2.LoadFractionalI();
            //dt.Columns.Add("FullName", typeof(string), "FirstName + ' ' + LastName");

            DataSet ds65 = Queries2.LoadYearOfInt();
            
            YearOfIntDropDownList.DataSource = ds65;
            YearOfIntDropDownList.DataTextField = "name";
            YearOfIntDropDownList.DataValueField = "Year_Int_ID";
            YearOfIntDropDownList.AppendDataBoundItems = true;
            YearOfIntDropDownList.Items.Insert(0, new ListItem("", ""));
            YearOfIntDropDownList.DataBind();


            //string tcurr = "USD";

            DataSet ds66 = Queries2.CrownFinaCurr();

            CrownFinanceCurrDropDownList.DataSource = ds66;
            CrownFinanceCurrDropDownList.DataTextField = "Finance_Curr_Name";
            CrownFinanceCurrDropDownList.DataValueField = "Finance_Curr_Name";
            CrownFinanceCurrDropDownList.AppendDataBoundItems = true;
            CrownFinanceCurrDropDownList.Items.Insert(0, new ListItem("USD", ""));
            CrownFinanceCurrDropDownList.DataBind();

          
            TextBox96.Text = officeo;





        }
        //   string venuecountry = DropDownList1.SelectedItem.Text;

    }



    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    contsalesrepDropDownList.Items.Clear();
    //    string venuecountry = Queries2.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text);

    //    DataSet ds7 = Queries2.LoadSalesReps(venuecountry);
    //    contsalesrepDropDownList.DataSource = ds7;
    //    contsalesrepDropDownList.DataTextField = "Sales_Rep_Name";
    //    contsalesrepDropDownList.DataValueField = "Sales_Rep_Name";
    //    contsalesrepDropDownList.AppendDataBoundItems = true;
    //    contsalesrepDropDownList.Items.Insert(0, new ListItem("", ""));
    //    contsalesrepDropDownList.DataBind();
    //}

    //DealDrawerDropDownList
    




    public void Button5_Click(object sender, EventArgs e)
    {
        //string ResortF = ResortDropDownListF.SelectedItem.Text;
        // string ResortF = Request.Form[ResortDropDownListF.UniqueID];
        //if (!Page.IsPostBack)

        //string ResortF = Request.Form[ResortDropDownListF.UniqueID];
        // string ResidenceNoF = ResidenceNoDropDownListF.SelectedItem.Text;
        // string ResidenceTypeF = ResidenceTypeDropDownListF.SelectedItem.Text;
        // string ResidenceNoF = Request.Form[ResidenceNoDropDownListF.UniqueID];
        //string ResidenceTypeF = Request.Form[ResidenceTypeDropDownListF.UniqueID];
        //string FractionalInt = FractionalIDropDownListF.SelectedItem.Text;

        try
        {


            string contnumid2 = null;
            string ContFracid2 = null;
            // {
            string conttype = DropDownList40.SelectedItem.Text;

            if (conttype == "Points")
            {

                string contnumid = Queries2.getContractID(officeo);
                contnumid2 = contnumid;

                string t1 = EntitlementPoinDropDownList.SelectedItem.Text;
                int fyear = Convert.ToInt32(TextPFOccu.Text);


                if (fyear % 2 == 0)
                {
                    ft1 = "Even";
                }
                else
                {
                    ft1 = "Odd";
                }

                if (PCheckBox1.Checked)
                {
                    ft2 = "Yes";
                }
                else
                {
                    ft2 = "No";
                }

            }
            else if (conttype == "Fractional")
            {
                string ContFracid = Queries2.getContFracID(officeo);
                ContFracid2 = ContFracid;

                string t1 = EntitlementFracDropDownList.SelectedItem.Text;
                int fyear = Convert.ToInt32(TextFOccuF.Text);
                

                if (fyear % 2 == 0)
                {
                    ft1 = "Even";
                }
                else
                {
                    ft1 = "Odd";
                }

                if (FCheckBox1.Checked)
                {
                    ft2 = "Yes";
                }
                else
                {
                    ft2 = "No";
                }


            }
            else if (conttype == "Trade Into Points")
            {
                string ContFracid = Queries2.getContTPID(officeo);
                ContFracid2 = ContFracid;

                string t1 = EntitlementTPoinDropDownList.SelectedItem.Text;
                int fyear = Convert.ToInt32(TextFYOccTP.Text);


                if (fyear % 2 == 0)
                {
                    ft1 = "Even";
                }
                else
                {
                    ft1 = "Odd";
                }

                if (FCheckBox1.Checked)
                {
                    ft2 = "Yes";
                }
                else
                {
                    ft2 = "No";
                }


            }
            else if (conttype == "Trade Into Fractional")
            {
                string ContFracid = Queries2.getContTFID(officeo);
                ContFracid2 = ContFracid;

                string t1 = EntitlementTFracDropDownList.SelectedItem.Text;
                int fyear = Convert.ToInt32(TextFYOccuTF.Text);


                if (fyear % 2 == 0)
                {
                    ft1 = "Even";
                }
                else
                {
                    ft1 = "Odd";
                }

                if (FCheckBox1.Checked)
                {
                    ft2 = "Yes";
                }
                else
                {
                    ft2 = "No";
                }


            }
            //TextBox96.Text = officeo;

            string Deposit_PM = DPMFractDropDownList.SelectedItem.Text;

            string contfinaid = Queries2.getContractFinanceID(officeo);
            string contPASAid = Queries2.getContractPASAID(officeo);
            contFinance = contfinaid;
            //string conttype = DropDownList40.SelectedItem.Text;


            string GenContNumb = TextContractNumb.Text;
            GenContNumbglob = GenContNumb;
            string ContType = DropDownList40.SelectedItem.Text;
            string affilice = TextICE.Text;
            string affilhp = TextHP.Text;
            string salesrep = contsalesrepDropDownList.SelectedItem.Text;
            string tomanager = TOManagerDropDownList.SelectedItem.Text;
            string buttonup = ButtonUpDropDownList.SelectedItem.Text;
            string FinaCurrency = FinanceCurrencyDropDownList.SelectedItem.Text;
            string PurchasePrice = TextPurchasePrice.Text;
            string AdminFees = TextAdminFees.Text;
            string MCFees = TextMCFees.Text;
            string DealDrawer = DealDrawerDropDownList.SelectedItem.Text;
            string PaymentMethod = PayMethodDropDownList.SelectedItem.Text;
            string FinanceNumb = TextPnumb.Text;
            string BPaymethod = "";//BPMDropDownList.SelectedItem.Text;
            string Pan = TextPan.Text;
            string Adhar = TextAdhar.Text;
            string ID_Card = TextOtherID.Text;
            string CrownCurr = CrownFinanceCurrDropDownList.SelectedItem.Text;




            /*string ResortF = ResortDropDownListF.SelectedItem.Text;
            string ResidenceNoF = ResidenceNoDropDownListF.SelectedItem.Text;
            string ResidenceTypeF = ResidenceTypeDropDownListF.SelectedItem.Text;
            string FractionalInt = FractionalIDropDownListF.SelectedItem.Text;
            string FractEntitle = EntitlementFracDropDownList.SelectedItem.Text;
            string FractFOccu = TextFOccuF.Text;
            string FractDura = TextFDuration.Text;
            string FractLOccu = TextFOccuL.Text;
            string FractLease = "";*/



            // string DepositP_PM = "";//DPMPointsDropDownList.SelectedItem.Text;
            //string DepositP = TextDepositP.Text;
            //string DepoPPA = TextDepoPPA.Text;
            //string AdmissFeesP = TextAdmissFeesP.Text;
            //string AdminFeesP = TextAdminFeesP.Text;
            //string PurchasePriceP = TextPpurchasePrice.Text;
            //string CoutryTaxP = TextCountryTaxP.Text;
            //string GrandTotalP = TextGrandTotalP.Text;
            //string BalanceDuePAP = TextPBalaceDPA.Text;
            //string PANoOfInstallP = TextPPANoInstall.Text;
            //string PAFirstPayDateP1 = Convert.ToDateTime(datepicker8.Text).ToString("yyyy-MM-dd");

            //string PAFirstPayDateP = PAFirstPayDateP1;
            //string PAAmountInstallP = TextPPAAmountInstall.Text;
            //string PAFirstInstallP = TextPPAFInstall.Text;
            //string BalanceDueDatesPAP = TextPBalanceDDates.Text;
            //string DepositSAP = TextPDepositSA.Text;
            //string ApplicationFeesP = TextAppliFeesP.Text;
            //string AdminServiceP = TextAdminServiceP.Text;
            //string TotalServicePriceP = TextTotalServicePriceP.Text;
            //string BalanceDueSAP = TextBalanceDueSAP.Text;
            //string SANoOfInstallP = "";//TextSANoInstallP.Text;
            //string SAFirstPayDateP = "";//datepicker9.Text;
            //string SAAmountInstallP = "";//TextSAAmountInstallP.Text;
            //string SAFirstInstallP = "";//TextSAFInstallP.Text;
            //string BalanceDueDatesSAP = TextBalanceDDatesSAP.Text;
            //string RemarksP = TextRemarkP.Text;
            //string EuroRatesP = TextEuroRateP.Text;
            //string AusRatesP = TextAusRateP.Text;
            //string GbpRates = TextGbpRateP.Text;
            //string IdaRates = TextIdaRateP.Text;
            //string UsePayProtectP = "";

            //string TYearOfInterestP = YearOfIntDropDownList.SelectedItem.Text;
            //string YearOfInterestP;
            //if (TYearOfInterestP == "")
            //{
            //    YearOfInterestP = "";
            //}
            //else
            //{

            //    YearOfInterestP = Queries2.LoadYearOfIntValue(TYearOfInterestP);
            //}
            // string TotalBalance = TextTotalBalance.Text;
            // YearOfIntDropDownList.SelectedItem.Text;



            string EuroRatesP = TextEuroRateP.Text;
            string AusRatesP = TextAusRateP.Text;
            string GbpRates = TextGbpRateP.Text;
            string IdaRates = TextIdaRateP.Text;
            string UsePayProtectP = "";

            string TYearOfInterestP = YearOfIntDropDownList.SelectedItem.Text;
            string YearOfInterestP;
            if (TYearOfInterestP == "")
            {
                YearOfInterestP = "";
            }
            else
            {

                YearOfInterestP = Queries2.LoadYearOfIntValue(TYearOfInterestP);
            }


            if (PaymentMethod != "Crown Finance")
            {
                CrownCurr = "";
                FinanceNumb = "";

            }

            
            if(DealDrawer=="Deal")
            {
                DealRegDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                DealRegDate = "";
            }



            int ContractFinance = Queries2.InsertContractFinance(contfinaid, GenContNumb, ContType, affilice, affilhp, salesrep, tomanager,
                buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, BPaymethod, Pan, Adhar, ID_Card, ProfileIDo, officeo, CrownCurr, DealRegDate,ft1,ft2,DateTime.Now, DateTime.Now);
            string log1 = "Contract Finance: " + "Finance_ID:" + contfinaid + "," + "Finance_Cont_Numb:" + GenContNumb + "," + "Finance_Cont_Type:" + ContType + "," + "Finance_Affil_ICE:" + affilice + "," + "Finance_Affil_HP:" + affilhp + "," + "Finance_Sales_Rep:" + salesrep + "," + "Finance_TO_Manager:" + tomanager + "," + "Finance_Button_UP:" + buttonup + "," + "Finance_Currency:" + FinaCurrency + "," + "Finance_Purchase_Price:" + PurchasePrice + "," + "Finance_Admin_Fees:" + AdminFees + "," + "Finance_MC_Fees:" + MCFees + "," + "Finance_Deal_Drawer:" + DealDrawer + "," + "Finance_Payment_Method:" + PaymentMethod + "," + "Finance_Finance_Num:" + FinanceNumb + "," + "Finance_BPayment_Method:" + BPaymethod + "," + "Finance_Pan_Card:" + Pan + "," + "Finance_Adhar_Card:" + Adhar + "," + "Finance_ID_Card:" + ID_Card + "," + "Profile ID:" + ProfileIDo + "," + "Crown Finance Curr:" + CrownCurr + "," + "Deal Reg Date:" + DealRegDate + "," + "Contract_finance_OddEven:" + ft1 + "," + "Contract_finance_OddEven50:" + ft2 + "," + "Contract_finance_Insert_Date:" + DateTime.Now + "," + "Contract_finance_Update_Date:" + DateTime.Now;
            int insertlog1 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log1, "Contract Finance", user, DateTime.Now.ToString());

            if (PaymentMethod == "Crown Finance")
            {
                int UpdatePnumber = Queries2.UpdatePnumber(CrownCurr);

            }

            if (conttype == "Points")
            {
                // string desc, text12, text13, text14, text15, message;
                string desc, amot1, amot2, date,date1, curr, text11, text12, text13, text14, text15;
                string PA = "PA";
                string SA = "SA";
                //GenContNumb = TextBox49.Text;


                string ContClub = ContractClubPDropDownList.SelectedItem.Text;
                string NoofPoints = TextNoPoints.Text;
                string PointsEntitle = EntitlementPoinDropDownList.SelectedItem.Text;
                string PointsMemFees = TextPMemFees.Text;
                string PointsPropFees = TextPPropFees.Text;
                string PointsFOccu = TextPFOccu.Text;
                string PointsDura = TextPDura.Text;
                string PointsLOccu = TextPLOccu.Text;


                string DepositP = TextDepositP.Text;
                string DepoPPA = TextDepoPPA.Text;
                string AdmissFeesP = TextAdmissFeesP.Text;
                string AdminFeesP = TextAdminFeesP.Text;
                string PurchasePriceP = TextPpurchasePrice.Text;
                string CoutryTaxP = TextCountryTaxP.Text;
                string GrandTotalP = TextGrandTotalP.Text;
                string BalanceDuePAP = TextPBalaceDPA.Text;
                string PANoOfInstallP = TextPPANoInstall.Text;
                string PAFirstPayDateP1 = datepicker8.Text;// Convert.ToDateTime(datepicker8.Text).ToString("yyyy-MM-dd");

                string PAFirstPayDateP = PAFirstPayDateP1;
                string PAAmountInstallP = TextPPAAmountInstall.Text;
                string PAFirstInstallP = TextPPAFInstall.Text;
                string BalanceDueDatesPAP = TextPBalanceDDates.Text;
                string DepositSAP = TextPDepositSA.Text;
                string ApplicationFeesP = TextAppliFeesP.Text;
                string AdminServiceP = TextAdminServiceP.Text;
                string TotalServicePriceP = TextTotalServicePriceP.Text;
                string BalanceDueSAP = TextBalanceDueSAP.Text;
                string SANoOfInstallP = "";//TextSANoInstallP.Text;
                string SAFirstPayDateP = "";//datepicker9.Text;
                string SAAmountInstallP = "";//TextSAAmountInstallP.Text;
                string SAFirstInstallP = "";//TextSAFInstallP.Text;
                string BalanceDueDatesSAP = TextBalanceDDatesSAP.Text;
                string RemarksP = TextRemarkP.Text;
                
                string TotalBalance = TextTotalBalance.Text;

                string InitDepop = TextInitDepo.Text;

                string BalDepop = TextBalDepo.Text;

                string DepoDatep = TextBoxNBDP.Text;

                string BalanceDueDatesPAP2 = TextPBalanceDDates2.Text;
                string BalanceDueDatesSAP2 = TextBalanceDDatesSAP2.Text;
                string RemarksP2 = TextRemarkP2.Text;


                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallP); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12];
                    text15 = "textBoxN_" + i + "3";
                    amot2 = Request[text15];
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                    //date = Convert.ToDateTime(date1).ToString("yyyy-MM-dd");
                    if (int.Parse(amot1) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(officeo);
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo,contFinance,DateTime.Now);
                    }

                    if (int.Parse(amot2) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(officeo);
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot2, curr, GenContNumb, ProfileIDo, SA, officeo, contFinance, DateTime.Now);
                    }

                }






                string office = officeo;
                string club_name = ContClub;
                string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
                string venue = VenueDropDownList.SelectedItem.Text;
                string mark = MarketingPrgmDropDownList.SelectedItem.Text;

                string contnumbf = GenContNumb;
                if (contnumbf != "")
                {
                    int contup = Queries2.UpdatePointCont(office, club_name, venuecountry, venue, mark);
                }
                int ContractPoints = Queries2.InsertContractPoints(contnumid2, ContClub, NoofPoints, PointsEntitle, PointsMemFees, PointsPropFees, PointsFOccu, PointsDura, PointsLOccu, ProfileIDo, contfinaid, officeo);

                string log2 = "Points Contract  " + "Points_ID:" + contnumid2 + "," + "Points_Club:" + ContClub + "," + "Points_Entle:" + PointsEntitle + "," + "Points_Member_fees:" + PointsMemFees + "," + "Points_Points_Property_fees:" + PointsPropFees + "," + "Points_FYear_Occ:" + PointsFOccu + "," + "Points_Duration:" + PointsDura + "," + "Points_LYear_Occ:" + PointsLOccu + "," + "Points_Noof_Points:" + NoofPoints + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;
                int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log2, "Points", user, DateTime.Now.ToString());




                // YearOfIntDropDownList.SelectedItem.Text;





                int PurchaseService2 = Queries2.InserPurchaseService(contPASAid, Deposit_PM, DepositP, DepoPPA, DepositSAP, AdmissFeesP, ApplicationFeesP, AdminFeesP, AdminServiceP, PurchasePriceP, TotalServicePriceP, CoutryTaxP, GrandTotalP, BalanceDuePAP, BalanceDueSAP, PANoOfInstallP, SANoOfInstallP, PAFirstPayDateP, SAFirstPayDateP, PAAmountInstallP, SAAmountInstallP, PAFirstInstallP, SAFirstInstallP, BalanceDueDatesPAP,
                  BalanceDueDatesSAP, RemarksP, EuroRatesP, AusRatesP, GbpRates, IdaRates, UsePayProtectP, YearOfInterestP, ProfileIDo, contfinaid, TotalBalance, DateTime.Now, officeo,BalanceDueDatesPAP2,BalanceDueDatesSAP2,RemarksP2,InitDepop,BalDepop,DepoDatep);





                string log3 = "Points Finance  " + "ID:" + contPASAid + "," + "Deposit_Pay_Method:" + Deposit_PM + "," + "Deposit:" + DepositP + "," + "Deposit_PA:" + DepoPPA + "," + "Deposit_SA:" + DepositSAP + "," + "PA_Admission:" + AdmissFeesP + "," + "SA_Application:" + ApplicationFeesP + "," + "PA_Administration:" + AdminFeesP + "," + "SA_Administration:" + AdminServiceP + "," + "Total_Purchase:" + PurchasePriceP + "," + "Total_Service:" + TotalServicePriceP + "," + "Country_Tax:" + CoutryTaxP + "," + "Grand_Total:" + GrandTotalP + "," + "PA_Balance_Due:" + BalanceDuePAP + "," + "SA_Balance_Due:" + BalanceDueSAP + ","
                    + "PA_No_Install:" + PANoOfInstallP + "," + "SA_No_Install:" + SANoOfInstallP + "," + "PA_FInstall_Date:" + PAFirstPayDateP + "," + "SA_FInstall_Date:" + SAFirstPayDateP + "," + "PA_Install_Amt:" + PAAmountInstallP + "," + "SA_Install_Amt:" + SAAmountInstallP + "," + "PA_FInstall_Amt:" + PAFirstInstallP + "," + "SA_FInstall_Amt:" + SAFirstInstallP + "," + "PA_Balance_Due_Dates:" + BalanceDueDatesPAP + ","
                    + "SA_Balance_Due_Dates:" + BalanceDueDatesSAP + "," + "Remarks:" + RemarksP + "," + "EURO_Rate:" + EuroRatesP + "," + "AUS_Rate:" + AusRatesP + "," + "GBP_Rate:" + GbpRates + "," + "IDA_Rate:" + IdaRates + "," + "Pay_Protect:" + UsePayProtectP + "," + "YOInterest:" + YearOfInterestP + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid + "," + "Total_Balance:" + TotalBalance + "," + "Initial Deposit:" + InitDepop + "," + "Balance Deposit:" + BalDepop + "," + "Deposit Date:" + DepoDatep; ;

                int insertlog3 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log3, "Points Finance", user, DateTime.Now.ToString());

                int contractaudit = Queries2.InsertIntoContractAudit(ProfileIDTextBox.Text, GenContNumb,ofname,olname, DateTime.Now.ToString("yyyy-MM-dd"),"");

                


                if (PayMethodDropDownList.SelectedItem.Text == "Crown Finance")
                {

                    string FDID = Queries2.getFinanceDetailID();

                    string tPurchase1 = tPurchase.Text;
                    string QDepo1 = QDepo.Text;
                    string AmtCre1 = AmtCre.Text;
                    string CreCurr1 = CreCurr.Text;
                    string NoOfMonth1 = NoOfMonth.Text;
                    string RateOfInt1 = RateOfInt.Text;
                    string MonthlyRepay1 = MonthlyRepay.Text;



                    string MonthlyRepay110, MonthlyRepay1Payprotectcharge,PayProtect;
                    MonthlyRepay110= (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                    if (UsePayProtectCheckBox.Checked)
                    {
                        string s1 = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                        MonthlyRepay1Payprotectcharge = (float.Parse(s1) + float.Parse(MonthlyRepay1)).ToString("0.00");
                        PayProtect = "Yes";
                    }
                    else
                    {
                        MonthlyRepay1Payprotectcharge = "0.00";
                        PayProtect = "No";
                    }





                    int FD = Queries2.InsertFDetails(FDID, tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, ProfileIDo, contFinance, DateTime.Now.ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect);

                    string log4 = "Finance_Details_ID:" + FDID + "," + "Finance_Details_Total_Pur:" + tPurchase1 + "," + "Finance_Details_Qual_Depo:" + QDepo1 + "," + "Finance_Details_Credit_Amount:" + AmtCre1 + "," + "Finance_Details_Amount_Curr:" + CreCurr1 + ","
                         + "Finance_Details_No_Of_Month:" + NoOfMonth1 + "," + "Finance_Details_Int_Rate:" + RateOfInt1 + "," + "Finance_Details_Monthly_Repay:" + MonthlyRepay1 + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contFinance + "," + "Finance_Details_Entry_Date:" + DateTime.Now.ToString();

                    int insertlog4 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log4, "Points Finance", user, DateTime.Now.ToString());

                }


            }
            else if (conttype == "Fractional")
            {

               




                string desc, amot1, date, date1, curr, text11, text12, text13, text14;
                string PA = "PA";
                string PANoOfInstallF = TextNoOfInstallF.Text;
                //string SA = "SA";
                //GenContNumb = TextBox49.Text;

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                //string var1, car1;
                for (i = 1; i <= int.Parse(PANoOfInstallF); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12];
                    //text15 = "textBoxN_" + i + "3";
                    //amot2 = Request[text15];
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];

                    //date = Convert.ToDateTime(date1).ToString("yyyy-MM-dd");
                    // if (int.Parse(amot1) != 0)
                    //{
                    string finaInstI = Queries2.getFinanceInstallID(officeo);
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo, contFinance, DateTime.Now);
                    // }

                    //if (int.Parse(amot2) != 0)
                    //{
                    //   string finaInstI = Queries2.getFinanceInstallID(officeo);
                    //   int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot2, curr, GenContNumb, ProfileIDo, SA, officeo);
                    //}
                    // message = text11;


                    //var1 = "textBox_" + i + "1";
                    //tb.ID = "textBox_" + i + "1";
                    //car1 = tb.ID;
                    //var1 = car1.Text;
                    // tb.Text;

                    //tb = (System.Web.UI.WebControls.TextBox)Panel1.FindControl(tb.ID.ToString());
                    //string value = tb.Text;
                    //string val2;
                    //You have the data now
                    //car1= var1.te
                    // string finaInstI = Queries2.getFinanceInstallID(officeo);
                    // text11 = "textBox_" + i + "1";
                    //string var = text11.t
                    // int FinanceInvoice = Queries2.InsertFinanceInv(tex);
                }


                string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
                string venue = VenueDropDownList.SelectedItem.Text;
                string mark = GroupVenueDropDownList.SelectedItem.Text;//,  venue,  mark;

                string contnumbf = GenContNumb;
                if (contnumbf != "")
                {
                    int contup = Queries2.UpdateFracCont(venuecountry, venue, mark);
                }



                string ResortF = Request.Form[ResortDropDownListF.UniqueID];
                string ResidenceNoF = Request.Form[ResidenceNoDropDownListF.UniqueID];
                string ResidenceTypeF = Request.Form[ResidenceTypeDropDownListF.UniqueID];

                //string ResortF = Request.Form[ResortDropDownListF.UniqueID];
                // string ResidenceNoF = ResidenceNoDropDownListF.SelectedItem.Text;
                // string ResidenceTypeF = ResidenceTypeDropDownListF.SelectedItem.Text;
                // string ResidenceNoF = Request.Form[ResidenceNoDropDownListF.UniqueID];
                // string ResidenceTypeF = Request.Form[ResidenceTypeDropDownListF.UniqueID];
                string FractionalInt = FractionalIDropDownListF.SelectedItem.Text;
                string FractEntitle = EntitlementFracDropDownList.SelectedItem.Text;
                string FractFOccu = TextFOccuF.Text;
                string FractDura = TextFDuration.Text;
                string FractLOccu = TextFOccuL.Text;
                string FractLease = "";

                
                string DepositF = TextDepositF.Text;
                // string DepoPPA = TextDepoPPA.Text;
                string AdmissFeesF = TextAdmissFeesF.Text;
                string AdminFeesF = TextAdminFeesF.Text;
                string PurchasePriceF = TextTotalPurchasePriceF.Text;
                string CoutryTaxF = TextCountryTaxF.Text;
                //string GrandTotalP = TextGrandTotalP.Text;
                string BalanceDuePAF = TextBalanceDueF.Text;

                string PAFirstPayDateF1 = datepicker10.Text;// Convert.ToDateTime(datepicker10.Text).ToString("yyyy-MM-dd");
                string PAFirstPayDateF = PAFirstPayDateF1;
                string PAAmountInstallF = TextInstallAmtF.Text;
                string PAFirstInstallF = TextFirstInstallAmtF.Text;
                string BalanceDueDatesPAF = TextDueDatesPAF.Text;
                // string DepositSAP = TextPDepositSA.Text;
                // string ApplicationFeesP = TextAppliFeesP.Text;
                //string AdminServiceP = TextAdminServiceP.Text;
                // string TotalServicePriceP = TextTotalServicePriceP.Text;
                // string BalanceDueSAP = TextBalanceDueSAP.Text;
                //string SANoOfInstallP = TextSANoInstallP.Text;
                // string SAFirstPayDateP = datepicker9.Text;
                //string SAAmountInstallP = TextSAAmountInstallP.Text;
                //string SAFirstInstallP = TextSAFInstallP.Text;
                // string BalanceDueDatesSAP = TextBalanceDDatesSAP.Text;
                string RemarksF = TextRemarksF.Text;
                string EuroRatesF = TextEuroRateP.Text;
                string AusRatesF = TextAusRateP.Text;
                string GbpRatesF = TextGbpRateP.Text;
                string IdaRatesF = TextIdaRateP.Text;
                string UsePayProtectF = "";

                string InitDepof = TextInitDepoF.Text;

                string BalDepof = TextBalDepoF.Text;

                string DepoDatef = TextBoxNBDF.Text;

                string BalanceDueDatesPAF2 = TextDueDatesPAF2.Text;

                string RemarksF2 = TextRemarksF2.Text;
                // string YearOfInterestF = "";

                /* string TYearOfInterestF = YearOfIntDropDownList.SelectedItem.Text;
                  string YearOfInterestF;
                  if (TYearOfInterestF == "")
                  {
                       YearOfInterestF = Queries2.LoadYearOfIntValue(TYearOfInterestF);
                  }
                  else
                  {
                      YearOfInterestF = "";
                  }*/

                string TotalBalanceF = TextTotalBalanceF.Text;

                int ContFracid = Queries2.InsertContractFractional(ContFracid2, ResortF, ResidenceNoF, ResidenceTypeF, FractionalInt, FractEntitle, FractFOccu, FractDura, FractLOccu, FractLease, contfinaid, ProfileIDo, officeo);


                //string log2 = "Points Contract  " + "Points_ID:" + contnumid2 + "," + "Points_Club:" + ContClub + "," + "Points_Entle:" + PointsEntitle + "," + "Points_Member_fees:" + PointsMemFees + "," + "Points_Points_Property_fees:" + PointsPropFees + "," + "Points_FYear_Occ:" + PointsFOccu + "," + "Points_Duration:" + PointsDura + "," + "Points_LYear_Occ:" + PointsLOccu + "," + "Points_Noof_Points:" + NoofPoints + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;

                string log4 = "Fractional Contract  " + "Fractional_ID:" + ContFracid2 + "," + "Fractional_Resort:" + ResortF + "," + "Fractional_Residence_No:" + ResidenceNoF + "," + "Fractional_Residence_Type:" + ResidenceTypeF + "," + "Fractional_Fractional_Int:" + FractionalInt + "," + "Fractional_Entitle:" + FractEntitle + "," + "Fractional_First_Occu:" + FractFOccu + "," + "Fractional_Duration:" + FractDura + "," + "Fractional_Last_Occu:" + FractLOccu + "," + "Fractional_Lease_Back:" + FractLease + "," + "Contract_Finance_ID:" + contfinaid + "," + "Profile_ID:" + ProfileIDo;
                int insertlog4 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log4, "Points Finance", user, DateTime.Now.ToString());

                int PurchaseService = Queries2.InserPurchaseService(contPASAid, Deposit_PM, DepositF, "", "", AdmissFeesF, "", AdminFeesF, "", PurchasePriceF, "", CoutryTaxF, "", BalanceDuePAF, "", PANoOfInstallF, "", PAFirstPayDateF, "", PAAmountInstallF, "", PAFirstInstallF, "", BalanceDueDatesPAF,
                    "", RemarksF, EuroRatesF, AusRatesF, GbpRatesF, IdaRatesF, UsePayProtectF, YearOfInterestP, ProfileIDo, contfinaid, TotalBalanceF, DateTime.Now, officeo, BalanceDueDatesPAF2, "", RemarksF2, InitDepof, BalDepof,DepoDatef);

                string log5 = "Fractional Finance  " + "ID:" + contPASAid + "," + "Deposit_Pay_Method:" + Deposit_PM + "," + "Deposit:" + DepositF + "," + "PA_Admission:" + AdmissFeesF + "," + "PA_Administration:" + AdminFeesF + "," + "Total_Purchase:" + PurchasePriceF + "," + "Country_Tax:" + CoutryTaxF + "," + "PA_Balance_Due:" + BalanceDuePAF + ","
                   + "PA_No_Install:" + PANoOfInstallF + "," + "PA_FInstall_Date:" + PAFirstPayDateF + "," + "PA_Install_Amt:" + PAAmountInstallF + "," + "PA_FInstall_Amt:" + PAFirstInstallF + "," + "PA_Balance_Due_Dates:" + BalanceDueDatesPAF + ","
                   + "Remarks:" + RemarksF + "," + "EURO_Rate:" + EuroRatesF + "," + "AUS_Rate:" + AusRatesF + "," + "GBP_Rate:" + GbpRatesF + "," + "IDA_Rate:" + IdaRatesF + "," + "Pay_Protect:" + UsePayProtectF + "," + "YOInterest:" + YearOfInterestP + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid + "," + "Total_Balance:" + TotalBalanceF + "," + "Initial Deposit:" + InitDepof + "," + "Balance Deposit:" + BalDepof + "," + "Deposit Date:" + DepoDatef; ;

                int insertlog3 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log5, "Fractional Finance", user, DateTime.Now.ToString());



                int contractaudit = Queries2.InsertIntoContractAudit(ProfileIDTextBox.Text, GenContNumb, ofname, olname, DateTime.Now.ToString("yyyy-MM-dd"), "");

                if (PayMethodDropDownList.SelectedItem.Text == "Crown Finance")
                {

                    string FDID = Queries2.getFinanceDetailID();

                    string tPurchase1 = tPurchase.Text;
                    string QDepo1 = QDepo.Text;
                    string AmtCre1 = AmtCre.Text;
                    string CreCurr1 = CreCurr.Text;
                    string NoOfMonth1 = NoOfMonth.Text;
                    string RateOfInt1 = RateOfInt.Text;
                    string MonthlyRepay1 = MonthlyRepay.Text;


                    string MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect;
                    MonthlyRepay110 = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                    if (UsePayProtectCheckBox.Checked)
                    {
                        string s1 = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                        MonthlyRepay1Payprotectcharge = (float.Parse(s1) + float.Parse(MonthlyRepay1)).ToString("0.00");
                        PayProtect = "Yes";
                    }
                    else
                    {
                        MonthlyRepay1Payprotectcharge = "0.00";
                        PayProtect = "No";
                    }




                    int FD = Queries2.InsertFDetails(FDID, tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, ProfileIDo, contFinance, DateTime.Now.ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect);

                    string log6 = "Finance_Details_ID:" + FDID + "," + "Finance_Details_Total_Pur:" + tPurchase1 + "," + "Finance_Details_Qual_Depo:" + QDepo1 + "," + "Finance_Details_Credit_Amount:" + AmtCre1 + "," + "Finance_Details_Amount_Curr:" + CreCurr1 + ","
                        + "Finance_Details_No_Of_Month:" + NoOfMonth1 + "," + "Finance_Details_Int_Rate:" + RateOfInt1 + "," + "Finance_Details_Monthly_Repay:" + MonthlyRepay1 + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contFinance + "," + "Finance_Details_Entry_Date:" + DateTime.Now.ToString();

                    int insertlog6 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log6, "Points Finance", user, DateTime.Now.ToString());

                }

            }

            else if (conttype == "Trade Into Fractional")
            {


                string desc, amot1, date,date1, curr, text11, text12, text13, text14;
                string PA = "PA";
                string PANoOfInstallTF = TextNoOfInstallTF.Text;
                //string SA = "SA";
                //GenContNumb = TextBox49.Text;
                string OldAgreeNoTF = "", OldClubTF = "", OldNoOfPointsTF = "", OldEntitleTF = "", OldResortTF = "", OldAppartTypeTF = "", OldNoOccuTF = "", OldPeriodTF = "", OldSeasonTF = "", OldResidenceNoTF = "", OldResiTypeTF = "", OldFracIntTF = "";





                string conttypeTF = Request.Form[ContTypeDropDownListTF.UniqueID];

                if (conttypeTF == "From Points To Fractional")
                {
                    OldAgreeNoTF = TextOldAgreeNoTF1.Text;
                    OldClubTF = OldClubDropDownListTF.Text;
                    OldNoOfPointsTF = TextOldNoOfPointsTF.Text;
                    OldEntitleTF = EntitleDropDownListTF1.SelectedItem.Text;
                    OldResortTF = "";
                    OldAppartTypeTF = "";
                    OldNoOccuTF = "";
                    OldPeriodTF = "";
                    OldSeasonTF = "";
                    OldResidenceNoTF = "";
                    OldResiTypeTF = "";
                    OldFracIntTF = "";
                }
                else if (conttypeTF == "From Weeks To Fractional")
                {
                    OldAgreeNoTF = TextOldAgreeNoTF2.Text;
                    OldClubTF = "";
                    OldNoOfPointsTF = "";
                    OldEntitleTF = EntitleDropDownListTF2.SelectedItem.Text;
                    OldResortTF = ResortDropDownListTF1.SelectedItem.Text;
                    OldAppartTypeTF = AppartTypeDropDownListTF.SelectedItem.Text;
                    OldNoOccuTF = NoOccuDropDownListTF.SelectedItem.Text;
                    OldPeriodTF = PeriodDropDownListTF.SelectedItem.Text;
                    OldSeasonTF = SeasonDropDownListTF.SelectedItem.Text;
                    OldResidenceNoTF = "";
                    OldResiTypeTF = "";
                    OldFracIntTF = "";
                }
                else if (conttypeTF == "From Fractional To Fractional")
                {
                    OldAgreeNoTF = TextOldAgreeNoTF3.Text;
                    OldClubTF = "";
                    OldNoOfPointsTF = "";
                    OldEntitleTF = EntitleDropDownListTF3.SelectedItem.Text;
                    OldResortTF = ResortDropDownListTF3.SelectedItem.Text;
                    OldAppartTypeTF = "";
                    OldNoOccuTF = "";
                    OldPeriodTF = "";
                    OldSeasonTF = "";
                    OldResidenceNoTF = Request.Form[ResidenceNoDropDownListTF.UniqueID];
                    OldResiTypeTF = Request.Form[ResiTypeDropDownListTF.UniqueID];
                    OldFracIntTF = Request.Form[FracIntDropDownListTF.UniqueID];
                }


                string ResortTF = Request.Form[ResortDropDownListTF.UniqueID];
                string ResidenceNoTF = Request.Form[ResidenceNoDropDownListTF1.UniqueID];
                string ResidenceTypeTF = Request.Form[ResiTypeDropDownListTF1.UniqueID];

                //string ResortF = Request.Form[ResortDropDownListF.UniqueID];
                // string ResidenceNoF = ResidenceNoDropDownListF.SelectedItem.Text;
                // string ResidenceTypeF = ResidenceTypeDropDownListF.SelectedItem.Text;
                // string ResidenceNoF = Request.Form[ResidenceNoDropDownListF.UniqueID];
                // string ResidenceTypeF = Request.Form[ResidenceTypeDropDownListF.UniqueID];
                string TFractionalInt = FracIntDropDownListTF1.SelectedItem.Text;
                string TFractEntitle = EntitlementTFracDropDownList.SelectedItem.Text;
                string TFractFOccu = TextFYOccuTF.Text;
                string TFractDura = TextDurationTF.Text;
                string TFractLOccu = TextLYOccuTF.Text;
                string TFractLease = "";

                //string DepositTF_PM = "";//DPMTFractDropDownList.SelectedItem.Text;
                string DepositTF = TextDepositTF.Text;
                // string DepoPPA = TextDepoPPA.Text;
                string AdmissFeesTF = TextAdmissFeeTF.Text;
                string AdminFeesTF = TextAdminFeeTF.Text;
                string PurchasePriceTF = TextPurchasePriceTF.Text;
                string CoutryTaxTF = TextCountryTaxTF.Text;
                //string GrandTotalP = TextGrandTotalP.Text;
                string BalanceDuePATF = TextBalanceDuePATF.Text;

                string PAFirstPayDateTF1 = datepicker13.Text;// Convert.ToDateTime(datepicker13.Text).ToString("yyyy-MM-dd");
                string PAFirstPayDateTF = PAFirstPayDateTF1;
                string PAAmountInstallTF = TextInstallAmtTF.Text;
                string PAFirstInstallTF = TextFInstallAmtTF.Text;
                string BalanceDueDatesPATF = TextBalanceDueDatesPATF.Text;

                string RemarksTF = TextRemarksTF.Text;
                string TotalBalanceTF = TextTotalBalanceTF.Text;

                string InitDepotf = TextInitDepoTF.Text;

                string BalDepotf = TextBalDepoTF.Text;

                string DepoDatetf = TextBoxNBDTF.Text;

                string BalanceDueDatesPATF2 = TextBalanceDueDatesPATF2.Text;

                string RemarksTF2 = TextRemarksTF2.Text;

                int ContFracid = Queries2.InsertContractTF(ContFracid2, OldAgreeNoTF, OldClubTF, OldNoOfPointsTF, OldEntitleTF, OldResortTF, OldAppartTypeTF, OldNoOccuTF, OldPeriodTF, OldSeasonTF, OldResidenceNoTF, OldResiTypeTF, OldFracIntTF, ResortTF, ResidenceNoTF, ResidenceTypeTF, TFractionalInt, TFractEntitle, TFractFOccu, TFractDura, TFractLOccu, TFractLease, ProfileIDo, contfinaid, officeo, conttypeTF);

                // string log4 = "Fractional Contract  " + "Fractional_ID:" + ContFracid2 + "," + "Fractional_Resort:" + ResortF + "," + "Fractional_Residence_No:" + ResidenceNoF + "," + "Fractional_Residence_Type:" + ResidenceTypeF + "," + "Fractional_Fractional_Int:" + FractionalInt + "," + "Fractional_Entitle:" + FractEntitle + "," + "Fractional_First_Occu:" + FractFOccu + "," + "Fractional_Duration:" + FractDura + "," + "Fractional_Last_Occu:" + FractLOccu + "," + "Fractional_Lease_Back:" + FractLease + "," + "Contract_Finance_ID:" + contfinaid + "," + "Profile_ID:" + ProfileIDo;

                string log6 = "Trade Into Fractional  " + "ID:" + ContFracid2 + "," + "Old_Cont_Numb:" + OldAgreeNoTF + "," + "Old_Club:" + OldClubTF + "," + "Old_NoOf_Points:" + OldNoOfPointsTF + "," + "Old_Entitle:" + OldEntitleTF + ","
                    + "Old_Resort:" + OldResortTF + "," + "Old_Apmnt_Type:" + OldAppartTypeTF + "," + "Old_No_Occu:" + OldNoOccuTF + "," + "Old_Period:" + OldPeriodTF + "," + "Old_Season:" + OldSeasonTF + "," + "Old_Resi_No:" + OldResidenceNoTF + "," + "Old_Resi_Type:" + OldResiTypeTF + "," + "Old_Frac_Int:" + OldFracIntTF + "," + "Resort:" + ResortTF + "," + "Resi_No:" + ResidenceNoTF + ","
                    + "Resi_Type:" + ResidenceTypeTF + "," + "Frac_Int:" + TFractionalInt + "," + "Entitle:" + TFractEntitle + "," + "First_Occ:" + TFractFOccu + "," + "Duration:" + TFractDura + "," + "Last_Occ:" + TFractLOccu + "," + "Leas:" + TFractLease + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;
                int insertlog6 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log6, "Trade Into Fractional ", user, DateTime.Now.ToString());

                int PurchaseService = Queries2.InserPurchaseService(contPASAid, Deposit_PM, DepositTF, "", "", AdmissFeesTF, "", AdminFeesTF, "", PurchasePriceTF, "", CoutryTaxTF, "", BalanceDuePATF, "", PANoOfInstallTF, "", PAFirstPayDateTF, "", PAAmountInstallTF, "", PAFirstInstallTF, "", BalanceDueDatesPATF,
                    "", RemarksTF, EuroRatesP, AusRatesP, GbpRates, IdaRates, UsePayProtectP, YearOfInterestP, ProfileIDo, contfinaid, TotalBalanceTF, DateTime.Now, officeo, BalanceDueDatesPATF2, "", RemarksTF2, InitDepotf,BalDepotf,DepoDatetf);

                string log7 = "Fractional Finance  " + "ID:" + contPASAid + "," + "Deposit_Pay_Method:" + Deposit_PM + "," + "Deposit:" + DepositTF + "," + "PA_Admission:" + AdmissFeesTF + "," + "PA_Administration:" + AdminFeesTF + "," + "Total_Purchase:" + PurchasePriceTF + "," + "Country_Tax:" + CoutryTaxTF + "," + "PA_Balance_Due:" + BalanceDuePATF + ","
                  + "PA_No_Install:" + PANoOfInstallTF + "," + "PA_FInstall_Date:" + PAFirstPayDateTF + "," + "PA_Install_Amt:" + PAAmountInstallTF + "," + "PA_FInstall_Amt:" + PAFirstInstallTF + "," + "PA_Balance_Due_Dates:" + BalanceDueDatesPATF + ","
                  + "Remarks:" + RemarksTF + "," + "EURO_Rate:" + EuroRatesP + "," + "AUS_Rate:" + AusRatesP + "," + "GBP_Rate:" + GbpRates + "," + "IDA_Rate:" + IdaRates + "," + "Pay_Protect:" + UsePayProtectP + "," + "YOInterest:" + YearOfInterestP + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid + "," + "Total_Balance:" + TotalBalanceTF + "," + "Initial Deposit:" + InitDepotf + "," + "Balance Deposit:" + BalDepotf + "," + "Deposit Date:" + DepoDatetf; ;

                int insertlog7 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log7, "Trade Into Fractional Finance", user, DateTime.Now.ToString());

                int contractaudit = Queries2.InsertIntoContractAudit(ProfileIDTextBox.Text, GenContNumb, ofname, olname, DateTime.Now.ToString("yyyy-MM-dd"), "");

                if (PayMethodDropDownList.SelectedItem.Text == "Crown Finance")
                {

                    string FDID = Queries2.getFinanceDetailID();

                    string tPurchase1 = tPurchase.Text;
                    string QDepo1 = QDepo.Text;
                    string AmtCre1 = AmtCre.Text;
                    string CreCurr1 = CreCurr.Text;
                    string NoOfMonth1 = NoOfMonth.Text;
                    string RateOfInt1 = RateOfInt.Text;
                    string MonthlyRepay1 = MonthlyRepay.Text;


                    string MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect;
                    MonthlyRepay110 = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                    if (UsePayProtectCheckBox.Checked)
                    {
                        string s1 = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                        MonthlyRepay1Payprotectcharge = (float.Parse(s1) + float.Parse(MonthlyRepay1)).ToString("0.00");
                        PayProtect = "Yes";
                    }
                    else
                    {
                        MonthlyRepay1Payprotectcharge = "0.00";
                        PayProtect = "No";
                    }


                    int FD = Queries2.InsertFDetails(FDID, tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, ProfileIDo, contFinance, DateTime.Now.ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect);

                    string log18 = "Finance_Details_ID:" + FDID + "," + "Finance_Details_Total_Pur:" + tPurchase1 + "," + "Finance_Details_Qual_Depo:" + QDepo1 + "," + "Finance_Details_Credit_Amount:" + AmtCre1 + "," + "Finance_Details_Amount_Curr:" + CreCurr1 + ","
                         + "Finance_Details_No_Of_Month:" + NoOfMonth1 + "," + "Finance_Details_Int_Rate:" + RateOfInt1 + "," + "Finance_Details_Monthly_Repay:" + MonthlyRepay1 + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contFinance + "," + "Finance_Details_Entry_Date:" + DateTime.Now.ToString();

                    int insertlog18 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log18, "Points Finance", user, DateTime.Now.ToString());

                }



                string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
                string venue = VenueDropDownList.SelectedItem.Text;
                string mark = GroupVenueDropDownList.SelectedItem.Text;//,  venue,  mark;


                string contnumbf = GenContNumb;
                if (contnumbf != "")
                {
                    int contup = Queries2.UpdateFracCont(venuecountry, venue, mark);
                }

                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                //string var1, car1;
                if (PANoOfInstallTF != "" || PANoOfInstallTF != "0")
                {
                    for (i = 1; i <= int.Parse(PANoOfInstallTF); i++)
                    {
                        text11 = "textBoxN_" + i + "1";
                        desc = Request[text11];
                        text12 = "textBoxN_" + i + "2";
                        amot1 = Request[text12];
                        //text15 = "textBoxN_" + i + "3";
                        //amot2 = Request[text15];
                        text13 = "textBox_" + i + "3";
                        date = Request[text13];
                        text14 = "textBox_" + i + "4";
                        curr = Request[text14];

                        //date = Convert.ToDateTime(date1).ToString("yyyy-MM-dd");
                        // if (int.Parse(amot1) != 0)
                        //{
                        string finaInstI = Queries2.getFinanceInstallID(officeo);
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo, contFinance, DateTime.Now);
                        // }


                    }
                }




            }

            else if (conttype == "Trade Into Points")
            {
                string desc, amot1, amot2, date,date1, curr, text11, text12, text13, text14, text15;
                string PA = "PA";
                string SA = "SA";
                //GenContNumb = TextBox49.Text;
                string OldAgreeNo = "";
                string OldClub = "", OldNoPoints = "", OldEntitle = "", ContResort = "", AppartmentType = "", NumbOccuTP = "", ContPeriod = "", ContSeason = "";


                string ContTPType = hiddentconttype.Text;

                if (ContTPType == "From Points To Points")
                {
                    OldAgreeNo = TextOldAgreeNoTP1.Text;
                    //OldAgreeNo = OldAgreeNo1;
                    if (ContractClubTPDropDownList1.SelectedItem.Text == "")
                    { OldClub = ""; }
                    else
                    { OldClub = ContractClubTPDropDownList1.SelectedItem.Text; }


                    OldNoPoints = TextOldNoPointsTP.Text;

                    if (EntitlementDropDownList1.SelectedItem.Text == "")
                    { OldEntitle = ""; }
                    else
                    { OldEntitle = EntitlementDropDownList1.SelectedItem.Text; }


                    ContResort = "";
                    AppartmentType = "";
                    NumbOccuTP = "";
                    ContPeriod = "";
                    ContSeason = "";
                }
                else if (ContTPType == "From Weeks To Points")
                {
                    OldClub = "";
                    //OldNoPoints = "";
                    OldAgreeNo = TextOldAgreeNoTP2.Text;
                    ContResort = ResortTPDropDownList.SelectedItem.Text;
                    if (AppartmentTypeTPDropDownList.SelectedItem.Text == "")
                    { AppartmentType = ""; }
                    else
                    { AppartmentType = AppartmentTypeTPDropDownList.SelectedItem.Text; }

                    if (NumbOccuTPDropDownList.SelectedItem.Text == "")
                    { NumbOccuTP = ""; }
                    else
                    { NumbOccuTP = NumbOccuTPDropDownList.SelectedItem.Text; }

                    if (PeriodTPDropDownList.SelectedItem.Text == "")
                    { ContPeriod = ""; }
                    else
                    { ContPeriod = PeriodTPDropDownList.SelectedItem.Text; }

                    if (SeasonTPDropDownList.SelectedItem.Text == "")
                    { ContSeason = ""; }
                    else
                    { ContSeason = SeasonTPDropDownList.SelectedItem.Text; }

                    if (EntitleTPDropDownList.SelectedItem.Text == "")
                    { OldEntitle = ""; }
                    else
                    { OldEntitle = EntitleTPDropDownList.SelectedItem.Text; }

                    OldNoPoints = TextTPPoints.Text;

                }

                string NewPoints = TextNewPointsTP.Text;
                string TotalPoints = TextTotalPointsTP.Text;
                string ContNewClub = ContractClubTPDropDownList2.Text;
                string ContNewEntitle = EntitlementTPoinDropDownList.SelectedItem.Text;
                string Memberfees = TextMembershipFeesTP.Text;
                string PropertyFees = TextPropertyFeesTP.Text;
                string FYOcc = TextFYOccTP.Text;
                string DurationTP = TextDurationTP.Text;
                string LYOcc = TextLYOccTP.Text;


              //  string DepositPayMethodTP = "";//DPMTPointsDropDownList.SelectedItem.Text;
                string DepositTP = TextDepositTP.Text;
                string DepositPATP = TextDepositPATP.Text;
                string TotalBalanceTP = TextTotalBalanceTP.Text;
                string AdmissFTP = TextAdmissFTP.Text;
                string AdminFeesTP = TextAdminFeesTP.Text;
                string PurchasePriceTP = TextPurchasePriceTP.Text;
                string CountryTaxTP = TextCountryTaxTP.Text;
                string GrandTotalTP = TextGrandTotalTP.Text;
                string BalanceDuePATP = TextBalanceDuePATP.Text;
                string NoOfInstallPATP = TextNoOfInstallPATP.Text;
                string InstallAmtPATP = TextInstallAmtPATP.Text;
                string FInstallAmtPATP = TextFInstallAmtPATP.Text;
                string DepositSATP = TextDepositSATP.Text;
                string AppliFeesTP = TextAppliFeesTP.Text;
                string AdminServiceTP = TextAdminServiceTP.Text;
                string TotalServiceTP = TextTotalServiceTP.Text;
                string BalanceDueSATP = TextBalanceDueSATP.Text;
                string NoOfInstallSATP = "";//TextNoOfInstallSATP.Text;
                string InstallAmtSATP = "";//TextInstallAmtSATP.Text;
                string FInstallAmtSATP = "";// TextFInstallAmtSATP.Text;
                string remarkTP = TextRemarksTP.Text;
                string BalanceDueDatesPATP = TextBalanceDueDatesPATP.Text;
                string BalanceDueDatesSATP = TextBalanceDueDatesSATP.Text;

                string PaymentDatePA1 = datepicker11.Text;// Convert.ToDateTime(datepicker11.Text).ToString("yyyy-MM-dd");

                string PaymentDatePA = PaymentDatePA1;
                string PaymentDateSA = "";// datepicker12.Text;


                string InitDepotp = TextInitDepoTP.Text;

                string BalDepotp = TextBalDepoTP.Text;

                string DepoDatetp = TextBoxNBDTP.Text;

                string remarkTP2 = TextRemarksTP2.Text;
                string BalanceDueDatesPATP2 = TextBalanceDueDatesPATP2.Text;
                string BalanceDueDatesSATP2 = TextBalanceDueDatesSATP2.Text;




                int ContractPoints = Queries2.InsertContractTP(ContFracid2, ContTPType, OldAgreeNo, ContResort, AppartmentType, NumbOccuTP, ContPeriod, ContSeason, OldEntitle, OldClub, OldNoPoints, NewPoints, TotalPoints, ContNewClub, ContNewEntitle, Memberfees, PropertyFees, FYOcc, DurationTP, LYOcc, ProfileIDo, contfinaid, officeo);

                //string log2 = "Points Contract  " + "Points_ID:" + contnumid2 + "," + "Points_Club:" + ContClub + "," + "Points_Entle:" + PointsEntitle + "," + "Points_Member_fees:" + PointsMemFees + "," + "Points_Points_Property_fees:" + PointsPropFees + "," + "Points_FYear_Occ:" + PointsFOccu + "," + "Points_Duration:" + PointsDura + "," + "Points_LYear_Occ:" + PointsLOccu + "," + "Points_Noof_Points:" + NoofPoints + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;

                string log8 = "Trade Into Points  " + "ID:" + ContFracid2 + "," + "Cont_Type:" + ContTPType + "," + "Old_Agree_Numb:" + OldAgreeNo + "," + "Resort:" + ContResort + "," + "Appartment_Type:" + AppartmentType + "," + "Num_Occ:" + NumbOccuTP + ","
                    + "Period:" + ContPeriod + "," + "Season:" + ContSeason + "," + "Old_Entitlement:" + OldEntitle + "," + "Old_Club:" + OldClub + "," + "Old_No_Points:" + OldNoPoints + "," + "New_No_Points:" + NewPoints + "," + "Total_Points:" + TotalPoints + "," + "New_CLub:" + ContNewClub + "," + "New_Entitlement:" + ContNewEntitle + "," + "Member_Fees:" + Memberfees + "," + "Property_Fees:" + PropertyFees + "," + "FY_Occu:" + FYOcc + "," + "Duration:" + DurationTP + "," + "LY_Occu:" + LYOcc + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;

                int insertlog8 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log8, "Trade Into Points ", user, DateTime.Now.ToString());

                int PurchaseService2 = Queries2.InserPurchaseService(contPASAid, Deposit_PM, DepositTP, DepositPATP, DepositSATP, AdmissFTP, AppliFeesTP, AdminFeesTP, AdminServiceTP, PurchasePriceTP, TotalServiceTP, CountryTaxTP, GrandTotalTP, BalanceDuePATP, BalanceDueSATP, NoOfInstallPATP, NoOfInstallSATP, PaymentDatePA, PaymentDateSA, InstallAmtPATP, InstallAmtSATP, FInstallAmtPATP, FInstallAmtSATP, BalanceDueDatesPATP,
                BalanceDueDatesSATP, remarkTP, EuroRatesP, AusRatesP, GbpRates, IdaRates, UsePayProtectP, YearOfInterestP, ProfileIDo, contfinaid, TotalBalanceTP, DateTime.Now, officeo,BalanceDueDatesPATP2,BalanceDueDatesSATP2,remarkTP2,InitDepotp,BalDepotp,DepoDatetp);



                string log9 = "Trade Into Points Finance  " + "ID:" + contPASAid + "," + "Deposit_Pay_Method:" + Deposit_PM + "," + "Deposit:" + DepositTP + "," + "Deposit_PA:" + DepositPATP + "," + "Deposit_SA:" + DepositSATP + "," + "PA_Admission:" + AdmissFTP + "," + "SA_Application:" + AppliFeesTP + "," + "PA_Administration:" + AdminFeesTP + "," + "SA_Administration:" + AdminServiceTP + "," + "Total_Purchase:" + PurchasePriceTP + "," + "Total_Service:" + TotalServiceTP + "," + "Country_Tax:" + CountryTaxTP + "," + "Grand_Total:" + GrandTotalTP + "," + "PA_Balance_Due:" + BalanceDuePATP + "," + "SA_Balance_Due:" + BalanceDueSATP + ","
                    + "PA_No_Install:" + NoOfInstallPATP + "," + "SA_No_Install:" + NoOfInstallSATP + "," + "PA_FInstall_Date:" + PaymentDatePA + "," + "SA_FInstall_Date:" + PaymentDateSA + "," + "PA_Install_Amt:" + InstallAmtPATP + "," + "SA_Install_Amt:" + InstallAmtSATP + "," + "PA_FInstall_Amt:" + FInstallAmtPATP + "," + "SA_FInstall_Amt:" + FInstallAmtSATP + "," + "PA_Balance_Due_Dates:" + BalanceDueDatesPATP + ","
                    + "SA_Balance_Due_Dates:" + BalanceDueDatesSATP + "," + "Remarks:" + remarkTP + "," + "EURO_Rate:" + EuroRatesP + "," + "AUS_Rate:" + AusRatesP + "," + "GBP_Rate:" + GbpRates + "," + "IDA_Rate:" + IdaRates + "," + "Pay_Protect:" + UsePayProtectP + "," + "YOInterest:" + YearOfInterestP + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid + "," + "Total_Balance:" + TotalBalanceTP + "," + "Initial Deposit:" + InitDepotp + "," + "Balance Deposit:" + BalDepotp + "," + "Deposit Date:" + DepoDatetp;


                int insertlog9 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log9, "Trade Into Points Finance", user, DateTime.Now.ToString());


                int contractaudit = Queries2.InsertIntoContractAudit(ProfileIDTextBox.Text, GenContNumb, ofname, olname, DateTime.Now.ToString("yyyy-MM-dd"), "");

                if (PayMethodDropDownList.SelectedItem.Text == "Crown Finance")
                {
                    

                    string FDID = Queries2.getFinanceDetailID();


                    string tPurchase1 = tPurchase.Text;
                    string QDepo1 = QDepo.Text;
                    string AmtCre1 = AmtCre.Text;
                    string CreCurr1 = CreCurr.Text;
                    string NoOfMonth1 = NoOfMonth.Text;
                    string RateOfInt1 = RateOfInt.Text;
                    string MonthlyRepay1 = MonthlyRepay.Text;

                    //string MonthlyRepay110;
                    //if (UsePayProtectCheckBox.Checked)
                    //{
                    //  string s1   = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                    //    MonthlyRepay110 = (float.Parse(s1) + float.Parse(MonthlyRepay1)).ToString("0.00");
                    //}
                    //else
                    //{
                    //    MonthlyRepay110 = "0.00";
                    //}



                    string MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect;
                    MonthlyRepay110 = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                    if (UsePayProtectCheckBox.Checked)
                    {
                        string s1 = (float.Parse(MonthlyRepay1) * 0.10).ToString("0.00");
                        MonthlyRepay1Payprotectcharge = (float.Parse(s1) + float.Parse(MonthlyRepay1)).ToString("0.00");
                        PayProtect = "Yes";
                    }
                    else
                    {
                        MonthlyRepay1Payprotectcharge = "0.00";
                        PayProtect = "No";
                    }


                    int FD = Queries2.InsertFDetails(FDID, tPurchase1, QDepo1, AmtCre1, CreCurr1, NoOfMonth1, RateOfInt1, MonthlyRepay1, ProfileIDo, contFinance, DateTime.Now.ToString(), MonthlyRepay110, MonthlyRepay1Payprotectcharge, PayProtect);

                    string log19 = "Finance_Details_ID:" + FDID + "," + "Finance_Details_Total_Pur:" + tPurchase1 + "," + "Finance_Details_Qual_Depo:" + QDepo1 + "," + "Finance_Details_Credit_Amount:" + AmtCre1 + "," + "Finance_Details_Amount_Curr:" + CreCurr1 + ","
                        + "Finance_Details_No_Of_Month:" + NoOfMonth1 + "," + "Finance_Details_Int_Rate:" + RateOfInt1 + "," + "Finance_Details_Monthly_Repay:" + MonthlyRepay1 + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contFinance + "," + "Finance_Details_Entry_Date:" + DateTime.Now.ToString();

                    int insertlog19 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log19, "Points Finance", user, DateTime.Now.ToString());

                }


                int i;
                //System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
                string var1, car1;
                for (i = 1; i <= int.Parse(NoOfInstallPATP); i++)
                {
                    text11 = "textBoxN_" + i + "1";
                    desc = Request[text11];
                    text12 = "textBoxN_" + i + "2";
                    amot1 = Request[text12];
                    text15 = "textBoxN_" + i + "3";
                    amot2 = Request[text15];
                    text13 = "textBox_" + i + "3";
                    date = Request[text13];
                    text14 = "textBox_" + i + "4";
                    curr = Request[text14];


                   // date = Convert.ToDateTime(date1).ToString("yyyy-MM-dd");
                    if (int.Parse(amot1) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(officeo);
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo, contFinance, DateTime.Now);
                    }

                    if (int.Parse(amot2) != 0)
                    {
                        string finaInstI = Queries2.getFinanceInstallID(officeo);
                        int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot2, curr, GenContNumb, ProfileIDo, SA, officeo, contFinance, DateTime.Now);
                    }

                }

                string office = officeo;
                string club_name = ContNewClub;
                string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
                string venue = VenueDropDownList.SelectedItem.Text;
                string mark = MarketingPrgmDropDownList.SelectedItem.Text;

                string contnumbf = GenContNumb;
                if (contnumbf != "")
                {
                    int contup = Queries2.UpdatePointCont(office, club_name, venuecountry, venue, mark);
                }
            }


            //





            //int PurchaseService2 = Queries2.InserPurchaseService(contPASAid, DepositP_PM, DepositP, DepoPPA, DepositSAP, AdmissFeesP, ApplicationFeesP, AdminFeesP, AdminServiceP, PurchasePriceP, TotalServicePriceP, CoutryTaxP, GrandTotalP, BalanceDuePAP, BalanceDueSAP, PANoOfInstallP, SANoOfInstallP, PAFirstPayDateP, SAFirstPayDateP, PAAmountInstallP, SAAmountInstallP, PAFirstInstallP, SAFirstInstallP, BalanceDueDatesPAP,
            //  BalanceDueDatesSAP, RemarksP, EuroRatesP, AusRatesP, GbpRates, IdaRates, UsePayProtectP, YearOfInterestP, ProfileIDo, contfinaid, officeo);

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "test", "test();", true);\
            // ScriptManager.RegisterStartupScript(Page, typeof(Page), Guid.NewGuid().ToString(), "$('#tabs').tabs('option', 'active', 3);", true);

            //string script = "<script> $(function() { $( '#tabs' ).tabs({ active: 3 }); });</script> ";
            //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
            // ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
            PrintPdfDropDownList.Items.Clear();
            string ContType1 = DropDownList40.SelectedItem.Text;
            DataSet ds21 = Queries2.LoadPrintFiles(ContType1, officeo);
            PrintPdfDropDownList.DataSource = ds21;
            PrintPdfDropDownList.DataTextField = "Printpdf_name";
            PrintPdfDropDownList.DataValueField = "Printpdf_name";
            PrintPdfDropDownList.AppendDataBoundItems = true;
            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
            PrintPdfDropDownList.DataBind();



            string PCard_Type = CardPrimaryDropDownList.SelectedItem.Text;
            if (PCard_Type != "")
            {

                string PmentDetailsId = Queries2.getPaymentDetailsID(officeo);

                string PIssuing_Bank = TextIssuingP.Text;
                string PCredit_Card_No = TextCardNumbP.Text;
                string PCard_Holders_Name = TextCardHNameP.Text;
                string PExpiry = TextExpMonthP.Text;
                string PSecurity_No = TextSecurityP.Text;
                string PFor_Depo = TextFDepo1.Text;
                string PFor_Bala = TextFBala1.Text;
                string SCard_Type = CardSecondaryDropDownList.SelectedItem.Text;
                string SIssuing_Bank = TextIssuingS.Text;
                string SCredit_Card = TextCardNumbS.Text;
                string SCard_Holders_Name = TextCardHNameS.Text;
                string SExpiry = TextExpiryS.Text;
                string SSecurity_No = TextSecurityS.Text;
                string SFor_Depo = TextFDepo2.Text;
                string SFor_Bala = TextFBala2.Text;
                DateTime entrydate = DateTime.Now;
                string Pcomments = TextPrimaryCCard.Text;
                string Scomments = TextSecondaryCCard.Text;



                int PmentDetails = Queries2.InserPaymentDetails(PmentDetailsId, PCard_Type, PIssuing_Bank, PCredit_Card_No, PCard_Holders_Name, PExpiry, PSecurity_No,
                    PFor_Depo, PFor_Bala, SCard_Type, SIssuing_Bank, SCredit_Card, SCard_Holders_Name, SExpiry, SSecurity_No, SFor_Depo, SFor_Bala, ProfileIDo, contFinance, entrydate, officeo, Pcomments, Scomments);
            }
            string script = "<script> $(function() { $('#tabs').tabs({ disabled: [] }); $( '#tabs' ).tabs({ active: 4 }); }); document.getElementById('myBtnNext').style.display = 'none';document.getElementById('Button4').style.display = 'none'; callallfunc();</script> ";
            //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);


            // string script = "<script> $(function() { $('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
            //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
        }
        catch (Exception ex)
        {


            //MessageBox.Show("Error while creating Contract " + ex.Message);


            string msg = "Error while creating Contract " + ex.Message;
            //MessageBox.Show("Error while creating profile " + ex.Message);
            //string msg = "Details updated for Profile :" + " " + profile;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);

            int delete = Queries2.Deletecotractonerror(contFinance);

            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

        }


    }

    //}

    public void Button2_Click(object sender, EventArgs e)
    {
       /* PrintPdfDropDownList.Items.Clear();
        string ContType = DropDownList40.SelectedItem.Text;
        DataSet ds21 = Queries2.LoadPrintFiles(ContType, officeo);
        PrintPdfDropDownList.DataSource = ds21;
        PrintPdfDropDownList.DataTextField = "Printpdf_name";
        PrintPdfDropDownList.DataValueField = "Printpdf_name";
        PrintPdfDropDownList.AppendDataBoundItems = true;
        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
        PrintPdfDropDownList.DataBind();
        */
       // string script = "<script> $(function() { $('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
        //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
       // ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
    }


    

   /* protected void Button5_Click(object sender, EventArgs e)
    {

        string PmentDetailsId = Queries2.getPaymentDetailsID(officeo);
        string PCard_Type = CardPrimaryDropDownList.SelectedItem.Text;
        string PIssuing_Bank = TextIssuingP.Text;
        string PCredit_Card_No = TextCardNumbP.Text;
        string PCard_Holders_Name = TextCardHNameP.Text;
        string PExpiry = TextExpMonthP.Text;
        string PSecurity_No = TextSecurityP.Text;
        string PFor_Depo = TextFDepo1.Text;
        string PFor_Bala = TextFBala1.Text;
        string SCard_Type = CardSecondaryDropDownList.SelectedItem.Text;
        string SIssuing_Bank = TextIssuingS.Text;
        string SCredit_Card = TextCardNumbS.Text;
        string SCard_Holders_Name = TextCardHNameS.Text;
        string SExpiry = TextExpiryS.Text;
        string SSecurity_No = TextSecurityS.Text;
        string SFor_Depo = TextFDepo2.Text;
        string SFor_Bala = TextFBala2.Text;
        DateTime entrydate = DateTime.Now;




        int PmentDetails = Queries2.InserPaymentDetails(PmentDetailsId, PCard_Type, PIssuing_Bank, PCredit_Card_No, PCard_Holders_Name, PExpiry, PSecurity_No,
            PFor_Depo, PFor_Bala, SCard_Type, SIssuing_Bank, SCredit_Card, SCard_Holders_Name, SExpiry, SSecurity_No, SFor_Depo, SFor_Bala, ProfileIDo, contFinance, entrydate, officeo);

        string script = "<script> $(function() { $('#tabs').tabs({ disabled: [] }); $( '#tabs' ).tabs({ active: 4 }); });</script> ";
        //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
    }*/



    protected void Button4_Click(object sender, EventArgs e)
    {

        var printr = PrintPdfDropDownList.SelectedItem.Text;
        DataTable datatable = Queries2.loadreport(GenContNumbglob, printr,officeo);
        
        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
        crystalReport.Load(Server.MapPath("~/reports/"+printr+".rpt")); // path of report       
        crystalReport.SetDataSource(datatable);

        System.IO.FileStream fs = null;
        long FileSize = 0;
        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
        //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
        string ExportFileName = Server.MapPath("~/reports/"+printr+".rpt") + "Export";
        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        oDest.DiskFileName = ExportFileName;
        crystalReport.ExportOptions.DestinationOptions = oDest;
        crystalReport.Export();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("Content-Type", "application/pdf");
        string fn = printr + ".pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

        fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
        FileSize = fs.Length;
        byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
        fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
        fs.Close();
        Response.BinaryWrite(bBuffer);
        Response.Flush();
       // Response.Close();







      //  string ContType = PrintPdfDropDownList.SelectedItem.Text;
       // string text2 = "reports"+ ContType + ".rpt";
       // ReportDocument cryRpt = new ReportDocument();
       // cryRpt.Load(Server.MapPath("~/reports/NEW POINTS CPA.rpt"));
      //  cryRpt.FileName = Server.MapPath("~/reports/NEW POINTS CPA.rpt");
       // CrystalReportViewer1.ReportSource = cryRpt;
    }


   

    public class resort
    {
        public string ResortID { get; set; }
        public string ResortName { get; set; }
    }

    [WebMethod]
    public static string PopulateDropDownList()
    {
        DataTable dt = new DataTable();
        List<resort> listRes = new List<resort>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Contract_Resort_ID,Contract_Resort_Name from Contract_Resort where Contract_Resort_Status='Active' order by 1", con))
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

                        resort objst = new resort();

                        objst.ResortID = Convert.ToString(dt.Rows[i]["Contract_Resort_ID"]);

                        objst.ResortName = Convert.ToString(dt.Rows[i]["Contract_Resort_Name"]);

                        listRes.Insert(i, objst);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class resortno
    {
        public string ResortNoID { get; set; }
        public string ResortNoName { get; set; }
    }


    [WebMethod]
    public static string PopulateResortNoDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<resortno> listRes = new List<resortno>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Contract_Residence_ID,Contract_Residence_Name from Contract_Residence_No where Contract_Resort_ID in (select Contract_Resort_ID from Contract_Resort where Contract_Resort_Name ='" + id + "') ", con))
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

                        resortno objst2 = new resortno();

                        objst2.ResortNoID = Convert.ToString(dt.Rows[i]["Contract_Residence_ID"]);

                        objst2.ResortNoName = Convert.ToString(dt.Rows[i]["Contract_Residence_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    public class ResidenceType
    {
        public string ResidenceTypeID { get; set; }
        public string ResidenceTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateResidenceTypeDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<ResidenceType> listRes = new List<ResidenceType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Contract_Resi_Type_ID,Contract_Resi_Type_Name from Contract_Residence_Type where Contract_Residence_ID in (select Contract_Residence_ID from Contract_Residence_No where Contract_Residence_Name='" + id + "')", con))
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

                        ResidenceType objst2 = new ResidenceType();

                        objst2.ResidenceTypeID = Convert.ToString(dt.Rows[i]["Contract_Resi_Type_ID"]);

                        objst2.ResidenceTypeName = Convert.ToString(dt.Rows[i]["Contract_Resi_Type_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //for contract type


    public class Contracttype
    {
        public string ContracttypeID { get; set; }
        public string ContracttypeName { get; set; }
    }


    [WebMethod]
    public static string ContracttypeDropDownList(string id)
    {
        DataTable dt = new DataTable();
        List<Contracttype> listRes = new List<Contracttype>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Contract_Type_Name from contract_type where contract_type_contract_type = '"+ id +"'and Contract_Type_Status = 'Active' order by 1 ", con))
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

                        Contracttype objst2 = new Contracttype();

                       // objst2.ResortNoID = Convert.ToString(dt.Rows[i]["Contract_Residence_ID"]);

                        objst2.ContracttypeName = Convert.ToString(dt.Rows[i]["Contract_Type_Name"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //for venue dropdownlist
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
            //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
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


    //load sub venue

    public class SubVenueGroupType
    {
        public string SubVenueGroupTypeID { get; set; }
        public string SubVenueGroupTypeName { get; set; }
    }


    [WebMethod]
    public static string PopulateSubVenueGroupDropDownList(string venueid, string countid)
    {
        DataTable dt = new DataTable();
        List<SubVenueGroupType> listRes = new List<SubVenueGroupType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
            using (SqlCommand cmd = new SqlCommand("select SVenue_Name from Sub_Venue where Venue_ID in (select Venue_ID from venue where Venue_Name='" + venueid + "') and SVenue_Status='Active'", con))
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

                        SubVenueGroupType objst2 = new SubVenueGroupType();

                        //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

                        objst2.SubVenueGroupTypeName = Convert.ToString(dt.Rows[i]["SVenue_Name"]);

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
            // using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
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
            //using (SqlCommand cmd = new SqlCommand("select Agent_Code from Agent_Code where Agent_id in (select Agent_ID from Agent_marketing where Agent_Name = '" + agentid + "' and marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "'))", con))
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




    /* public class contnumbgen
     {
         public string contnumbgenno { get; set; }
         //public string ResidenceTypeName { get; set; }
     }*/

    [WebMethod]
    
    public static string loadpointcont1(string venuecountry)
    {
        //contnumbgen c1 = new contnumbgen();

       // DataSet dt = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            /*SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name  and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)and Venue_ID in (select Venue_ID from venue where Venue_Name = @venue)", cs1);
            SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = officeo;
            SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
            // da = new SqlDataAdapter(SqlCmd);
            //dt = new DataSet();
            //da.Fill(dt);*/

            SqlCommand SqlCmd = new SqlCommand("select Venue_Country_ID from VenueCountry where Venue_Country_Name = @venuecountry", con);
            SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
            //cs1.Open();
            //SqlDataReader rd = SqlCmd.ExecuteReader();
            DataTable data = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            //dt = new DataSet();
            da.Fill(data);

            if(data.Rows.Count > 0)
            {
                return data.Rows[0].ItemArray[0].ToString();//rd["Venue_Country_ID"].ToString();
                
            }
            //cs1.Close();
        }
        return "hi";

    }



    [System.Web.Services.WebMethod]
    public static string helo1(string name,string venue,string club,string mark, string conttype)
    {
        //return "Hello "+name;
        string finaInstI = "";

        if (conttype == "Points" || conttype == "Trade Into Points")
        {
             finaInstI = Queries2.LoadPointCont(officeo, club, name, venue, mark);
        }
        else if (conttype == "Fractional" || conttype == "Trade Into Fractional")
        {
             finaInstI = Queries2.LoadFracCont(officeo, club, name, venue, mark);
        }
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        //{
        //    /*SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name  and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)and Venue_ID in (select Venue_ID from venue where Venue_Name = @venue)", cs1);
        //    SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = officeo;
        //    SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club_name;
        //    SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = venuecountry;
        //    SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;
        //    // da = new SqlDataAdapter(SqlCmd);
        //    //dt = new DataSet();
        //    //da.Fill(dt);*/

        //    // SqlCommand SqlCmd = new SqlCommand("select Venue_Country_ID from VenueCountry where Venue_Country_Name = @venuecountry", con);
        //    SqlCommand SqlCmd = new SqlCommand("select Contract_Code from Contract_Club where Contract_Club_Name=@club_name  and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name=@venuecountry)and Venue_ID in (select Venue_ID from venue where Venue_Name = @venue)", con);
        //    SqlCmd.Parameters.Add("@office", SqlDbType.VarChar).Value = officeo;
        //    SqlCmd.Parameters.Add("@club_name", SqlDbType.VarChar).Value = club;
        //    SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = name;
        //    SqlCmd.Parameters.Add("@venue", SqlDbType.VarChar).Value = venue;


        //    //SqlCmd.Parameters.Add("@venuecountry", SqlDbType.VarChar).Value = name;
        //    //cs1.Open();
        //    //SqlDataReader rd = SqlCmd.ExecuteReader();
        //    DataTable data = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
        //    //dt = new DataSet();
        //    da.Fill(data);

        //    if (data.Rows.Count > 0)
        //    {
        //        return data.Rows[0].ItemArray[0].ToString();//rd["Venue_Country_ID"].ToString();

        //    }
        //    //cs1.Close();
        //}
        return finaInstI;


    }

    [System.Web.Services.WebMethod]
    public static string [] LoadPropfess()
    {
        // string[] finaInstI = new string[3];
        //return "Hello "+name;
        string[] s = new string[2];
        string finaInstI = Queries2.LoadPropfess();
        //return finaInstI;

       //var k = finaInstI.Split('-');
       


        //string str = null;
        string[] strArr = new string[10];
        //int count = 0;
        //str = "CSharp split test";
        char[] splitchar = { '-' };
        strArr = finaInstI.Split(splitchar);

        return strArr;
        // return NoPoints;
    }


    //gift option
    [System.Web.Services.WebMethod]
    public static int totalgift()
    {
        //return "Hello "+name;
        int finaInstI;

        finaInstI = Queries2.countgift(ProfileIDo);
        return finaInstI;

        //  return "hi";


    }

    [System.Web.Services.WebMethod]
    public static string pnumberCount(string id)
    {
        //return "Hello "+name;
        string Pnumb;

        Pnumb = Queries2.PnumbCount(id);
        return Pnumb;

       // return "hi";


    }


    [System.Web.Services.WebMethod]
    public static string Erates(string id)
    {
        //return "Hello "+name;
        string ER;

        ER = Queries2.getExchangeRate(id);
        return ER;

        // return "hi";


    }

    [System.Web.Services.WebMethod]
    public static string gmcharge(string id,string id2)
    {
        //return "Hello "+name;
        string mcval;

        mcval = Queries2.loadmcharge(id,id2);
        return mcval;

        // return "hi";


    }



    protected void Button6_Click(object sender, EventArgs e)
    {

        try
        {
            string pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3mobile, sp3alternate, sp4mobile, sp4alternate,sp3cc, sp3altcc, sp4cc, sp4altcc;
            string pemail, semail, sp1email, sp2email, pemail2, semail2, sp1email2, sp2email2, sp3email, sp3email2, sp4email, sp4email2; 
            string venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, membertype2, employmentstatus, Secondemploymentstatus, maritalstatus, primarytitle, primarynationality, leadsource,prearrival;
            string primarycountry, secondarytitle, secondarynationality, secondarycountry, sp1title, sp1nationality, sp1country, sp2title, sp2nationality, sp2country, sp3title, sp4title;
            string gueststatus, salesrep, gift_option;
            string reception, subvenue;

            string profile = ProfileIDTextBox.Text;
            string createdby = CreatedByTextBox.Text;

            string VPID = TextVPID.Text;



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






            if (VenueCountryDropDownList.SelectedItem.Text == "")
            {
                venuecountry = "";
            }
            else
            {
                venuecountry = VenueCountryDropDownList.SelectedItem.Text;
            }

            if (ReceptionistDropDownList.SelectedItem.Text == "")
            {
                reception = "";
            }
            else
            {
                reception = ReceptionistDropDownList.SelectedItem.Text;
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


            if (venue == "Flybuys")
            {

                agents = OfficeSourceDropDownList.SelectedItem.Text; //Request.Form[AgentsDropDownList.UniqueID];
                agentcode = FAgentDropDownList.SelectedItem.Text;//Request.Form[AgentCodeDropDownList.UniqueID];
                leadsource = DropDownListFly.SelectedItem.Text;
                prearrival = PreArrivalDropDownList.SelectedItem.Text;
            }
            else
            {
                agents = Request.Form[AgentsDropDownList.UniqueID];
                agentcode = Request.Form[AgentCodeDropDownList.UniqueID];
                leadsource = "";
                prearrival = "";
            }


            //agents = Request.Form[AgentsDropDownList.UniqueID];
            //agentcode = Request.Form[AgentCodeDropDownList.UniqueID];
           // subvenue = Request.Form[VenueDropDownList2.UniqueID];

            if (VenueDropDownList2.SelectedItem.Text == "")
            {
                subvenue = "";
            }
            else
            {
                subvenue = VenueDropDownList2.SelectedItem.Text;
            }





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

            //other details

            if (employmentstatusDropDownList.SelectedItem.Text == "")
            {
                employmentstatus = "";
            }
            else
            {
                employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
            }


            if (SecondemploymentstatusDropDownList.SelectedItem.Text == "")
            {
                Secondemploymentstatus = "";
            }
            else
            {
                Secondemploymentstatus = SecondemploymentstatusDropDownList.SelectedItem.Text;
            }


            if (MaritalStatusDropDownList.SelectedItem.Text == "")
            {
                maritalstatus = "";
            }
            else
            {
                maritalstatus = MaritalStatusDropDownList.SelectedItem.Text;
            }

            string livingyrs = livingyrsTextBox.Text;


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



            int updateprofile = Queries2.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, "","","","",reception,subvenue, regTerms, VPID,regTerms2,Secondemploymentstatus, leadsource,prearrival,"");


            //primary profile

            if (primarytitleDropDownList.SelectedItem.Text == "")
            {
                primarytitle = "";
            }
            else
            {
                primarytitle = primarytitleDropDownList.SelectedItem.Text;
            }


            string primaryfname = pfnameTextBox.Text;
            string primaylname = plnameTextBox.Text;
            string primarydob = datepicker1.Text;
            string primaryage = TextPrimaryAge.Text;
            string tprimarydob;
            if (primarydob == "")
            {
                tprimarydob = "1900-01-01";
            }
            else
            {
                tprimarydob = primarydob;// Convert.ToDateTime(primarydob).ToString("yyyy-MM-dd");
            }


            if (primarynationalityDropDownList.SelectedItem.Text == "")
            {
                primarynationality = "";
            }
            else
            {
                primarynationality = primarynationalityDropDownList.SelectedItem.Text;
            }

            //if (PrimaryCountryDropDownList.SelectedItem.Text == "")
            //{
            //    primarycountry = "";
            //}
            //else
            //{
            //    primarycountry = PrimaryCountryDropDownList.SelectedItem.Text;
            //}
             primarycountry = Request.Form[PrimaryCountryDropDownList.UniqueID];
            int primary = Queries2.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, tprimarydob, primarynationality, primarycountry, primaryage, "","");

            //Secondary Profile

            if (secondarytitleDropDownList.SelectedItem.Text == "")
            {
                secondarytitle = "";
            }
            else
            {
                secondarytitle = secondarytitleDropDownList.SelectedItem.Text;
            }



            string secondaryfname = sfnameTextBox.Text;
            string secondarylname = slnameTextBox.Text;
            string secondarydob = datepicker2.Text;
            string secondaryage = TextSecondAge.Text;
            string tsecondarydob;
            if (secondarydob == "")
            {
                tsecondarydob = "1900-01-01";
            }
            else
            {
                tsecondarydob = secondarydob;// Convert.ToDateTime(secondarydob).ToString("yyyy-MM-dd");
            }

            if (secondarynationalityDropDownList.SelectedItem.Text == "")
            {
                secondarynationality = "";
            }
            else
            {
                secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
            }

            //if (SecondaryCountryDropDownList.SelectedItem.Text == "")
            //{
            //    secondarycountry = "";
            //}
            //else
            //{
            //    secondarycountry = SecondaryCountryDropDownList.SelectedItem.Text;
            //}

             secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID];

            int secondary1 = Queries2.checksubprofile("secondary", profile);

            if (secondaryfname != "")
            {
                if (secondary1 == 0)
                {
                    int year = DateTime.Now.Year;
                    string secondaryprofileid = Queries.GetSecondaryProfileID(officeo);
                    int secondary = Queries2.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, ProfileIDTextBox.Text, secondaryage, "", "");
                    string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Profile Secondary Age:" + secondaryage;
                    int insertlog3 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log3, "ProfileSecondary", user, DateTime.Now.ToString());
                    int updates = Queries.UpdateSecondaryValue(officeo, year);
                }

                else
                {
                    int secondary = Queries2.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, secondaryage, "", "");
                }

            }

            // int secondary = Queries2.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, secondaryage, "","");


            // subprofile1
            if (subprofile1titleDropDownList.SelectedItem.Text == "")
            {
                sp1title = "";
            }
            else
            {
                sp1title = subprofile1titleDropDownList.SelectedItem.Text;
            }

            string sp1fname = sp1fnameTextBox.Text;
            string sp1lname = sp1lnameTextBox.Text;
            string sp1dob = datepicker3.Text;
            string SubProfile1age = TextSP1Age.Text;
            string tsp1dob;
            if (sp1dob == "")
            {
                tsp1dob = "1900-01-01";
            }
            else
            {
                tsp1dob = sp1dob;//  Convert.ToDateTime(sp1dob).ToString("yyyy-MM-dd");
            }

            if (subprofile1nationalityDropDownList.SelectedItem.Text == "")
            {
                sp1nationality = "";
            }
            else
            {
                sp1nationality = subprofile1nationalityDropDownList.SelectedItem.Text;
            }

            //if (SubProfile1CountryDropDownList.SelectedItem.Text == "")
            //{
            //    sp1country = "";
            //}
            //else
            //{
            //    sp1country = SubProfile1CountryDropDownList.SelectedItem.Text;
            //}
             sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID];


            int subprofilecheck1 = Queries2.checksubprofile("SP1", profile);

            if (sp1fname != "")
            {
                if (subprofilecheck1 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile1id = Queries.GetSubProfile1ID(officeo);
                    int subprofielid = Queries2.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, ProfileIDTextBox.Text, SubProfile1age);
                    string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Sub Profile 1 Age:" + SubProfile1age;
                    int insertlog5 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log5, "ProfileSubProfie1", user, DateTime.Now.ToString());
                    int updatesp2 = Queries.UpdateSubprofile2Value(officeo, year);
                }
                else
                {
                    int sp1 = Queries2.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, SubProfile1age);
                }
            }


            //int sp1 = Queries2.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, SubProfile1age);

            // subprofile2
            if (subprofile2titleDropDownList.SelectedItem.Text == "")
            {
                sp2title = "";
            }
            else
            {
                sp2title = subprofile2titleDropDownList.SelectedItem.Text;
            }

            string sp2fname = sp2fnameTextBox.Text;
            string sp2lname = sp2lnameTextBox.Text;
            string sp2dob = datepicker4.Text;
            string Subprofile2 = TextSP2Age.Text;
            string tsp2dob;
            if (sp2dob == "")
            {
                tsp2dob = "1900-01-01";
            }
            else
            {
                tsp2dob = sp2dob;// Convert.ToDateTime(sp2dob).ToString("yyyy-MM-dd");
            }

            if (subprofile2nationalityDropDownList.SelectedItem.Text == "")
            {
                sp2nationality = "";
            }
            else
            {
                sp2nationality = subprofile2nationalityDropDownList.SelectedItem.Text;
            }


            //if (SubProfile2CountryDropDownList.SelectedItem.Text == "")
            //{
            //    sp2country = "";
            //}
            //else
            //{
            //    sp2country = SubProfile2CountryDropDownList.SelectedItem.Text;
            //}

             sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID];

            int subprofilecheck2 = Queries2.checksubprofile("SP2", profile);


            if (sp2fname != "")
            {
                if (subprofilecheck2 == 0)
                {
                    int year = DateTime.Now.Year;
                    string subprofile2id = Queries.GetSubProfile2ID(officeo);
                    int subprofielid2 = Queries2.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, ProfileIDTextBox.Text, Subprofile2);
                    string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Sub Profile 2 Age:" + Subprofile2;
                    int insertlog6 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log6, "ProfileSubProfie2", user, DateTime.Now.ToString());
                    int updatesp2 = Queries.UpdateSubprofile2Value(officeo, year);
                }
                else
                {
                    int sp2 = Queries2.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, Subprofile2);
                }
            }


            //int sp2 = Queries2.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, Subprofile2);


            //subprofile3
            

            if (SubP3TitleDropDownList.SelectedItem.Text == "")
            {
                sp3title = "";
            }
            else
            {
                sp3title = SubP3TitleDropDownList.SelectedItem.Text;
            }

            
             sp3fname = SubP3FnameTextBox.Text;
            if (sp3fname != "")
            {

                sp3lname = SubP3LnameTextBox.Text;
                sp3dob = SubP3DOB.Text;
                string Subprofile3 = TextSP3Age.Text;
                //string tsp3dob;
                if (sp3dob == "")
                {
                    tsp3dob = "1900-01-01";
                }
                else
                {
                    tsp3dob = sp3dob;// Convert.ToDateTime(sp3dob).ToString("yyyy-MM-dd");
                }



                if (SubP3NationalityDropDownList.SelectedItem.Text == "")
                {
                    sp3nationality = "";
                }
                else
                {
                    sp3nationality = SubP3NationalityDropDownList.SelectedItem.Text;
                }

                //if (SubP3CountryDropDownList.SelectedItem.Text == "")
                //{
                //    sp3country = "";
                //}
                //else
                //{
                //    sp3country = SubP3CountryDropDownList.SelectedItem.Text;
                //}
                sp3country = Request.Form[SubP3CountryDropDownList.UniqueID];

                int subprofilecheck3 = Queries2.checksubprofile("SP3", profile);
                if (sp3fname != "")
                {
                    if (subprofilecheck3 == 0)
                    {
                        int year = DateTime.Now.Year;
                        string subprofile3id = Queries.GetSubProfile3ID(officeo);
                        int subprofielid3 = Queries2.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, ProfileIDTextBox.Text, Subprofile3);
                        string log11 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Age:" + Subprofile3;
                        int insertlog11 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log11, "ProfileSubProfie2", user, DateTime.Now.ToString());
                        int updatesp3 = Queries2.UpdateSubprofile3Value(officeo, year);
                    }
                    else
                    {
                        int sp3 = Queries2.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, Subprofile3);
                    }

                }



                //int sp3 = Queries.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, Subprofile3);
            }

            //subprofile4

          
            if (SubP4TitleDropDownList.SelectedItem.Text == "")
            {
                sp4title = "";
            }
            else
            {
                sp4title = SubP4TitleDropDownList.SelectedItem.Text;
            }

             sp4fname = SubP4FnameTextBox.Text;
            if (sp4fname != "")
            {
                sp4lname = SubP4LnameTextBox.Text;
                sp4dob = SubP4DOB.Text;
                string Subprofile4 = TextSP4Age.Text;

                if (sp4dob == "")
                {
                    tsp4dob = "1900-01-01";
                }
                else
                {
                    tsp4dob = sp4dob;// Convert.ToDateTime(sp4dob).ToString("yyyy-MM-dd"); //SubP4DOB.Text;
                }

                //string sp4nationality = Request.Form[SubP4NationalityDropDownList.UniqueID];
                //string sp4country = Request.Form[SubP4CountryDropDownList.UniqueID];

                if (SubP4NationalityDropDownList.SelectedItem.Text == "")
                {
                    sp4nationality = "";
                }
                else
                {
                    sp4nationality = SubP4NationalityDropDownList.SelectedItem.Text;
                }

                //if (SubP4CountryDropDownList.SelectedItem.Text == "")
                //{
                //    sp4country = "";
                //}
                //else
                //{
                //    sp4country = SubP4CountryDropDownList.SelectedItem.Text;
                //}
                sp4country = Request.Form[SubP4CountryDropDownList.UniqueID];
                int subprofilecheck4 = Queries2.checksubprofile("SP4", profile);
                if (sp4fname != "")
                {
                    if (subprofilecheck4 == 0)
                    {
                        int year = DateTime.Now.Year;
                        string subprofile4id = Queries.GetSubProfile4ID(officeo);
                        int subprofielid4 = Queries2.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, tsp4dob, sp4nationality, sp4country, ProfileIDTextBox.Text, Subprofile4);
                        string log12 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + ProfileIDTextBox.Text + "," + "Age:" + Subprofile4;
                        int insertlog12 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log12, "ProfileSubProfie2", user, DateTime.Now.ToString());
                        int updatesp4 = Queries2.UpdateSubprofile4Value(officeo, year);

                    }
                    else
                    {
                        int sp4 = Queries2.UpdateSubProfile4(profile, sp4title, sp4fname, sp4lname, tsp4dob, sp4nationality, sp4country, Subprofile4);
                    }
                }


               

            }


            //address

            string address1 = address1TextBox.Text;
            string address2 = address2TextBox.Text;
            string state = stateTextBox.Text;
            string city = cityTextBox.Text;
            string pincode = pincodeTextBox.Text;

            string acountry = AddCountryDropDownList.SelectedItem.Text;

            int address = Queries2.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);

            //pcc = primarymobileDropDownList.SelectedItem.Text;


            // paltrcc = primaryalternateDropDownList.SelectedItem.Text;

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
                //pcc = pcc1;

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



            pmobile = pmobileTextBox.Text;

            palternate = palternateTextBox.Text;

            pemail = pemailTextBox.Text;

            pemail2 = pemailTextBox2.Text;




            //scc = secondarymobileDropDownList.SelectedItem.Text;


            // saltcc = secondaryalternateDropDownList.SelectedItem.Text;

            if (secondarymobileDropDownList.SelectedItem.Text == "")
            {
                scc = "";
            }
            else
            {
                //Request.Form[secondarymobileDropDownList.UniqueID];
                //scc = Request.Form[secondarymobileDropDownList.UniqueID];
                string scc1;
                scc = secondarymobileDropDownList.SelectedItem.Text;//Request.Form[primarymobileDropDownList.UniqueID];

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


            smobile = smobileTextBox.Text;

            salternate = salternateTextBox.Text;


            semail = semailTextBox.Text;
            semail2 = semailTextBox2.Text;



            // sp1cc = subprofile1mobileDropDownList.SelectedItem.Text;


            // sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;


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



            sp1mobile = sp1mobileTextBox.Text;

            sp1alternate = sp1alternateTextBox.Text;


            sp1email = sp1emailTextBox.Text;
            sp1email2 = sp1emailTextBox2.Text;



            // sp2cc = subprofile2mobileDropDownList.SelectedItem.Text;


            // sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text;

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


            sp2mobile = sp2mobileTextBox.Text;


            sp2alternate = sp2alternateTextBox.Text;



            sp2email = sp2emailTextBox.Text;
            sp2email2 = sp2emailTextBox2.Text;


            //sub profile 3


            if (sp3country == "" || sp3country==null)
            {
                sp3cc = "";
                sp3altcc = "";
                sp3mobile = "";
                sp3alternate = "";
            }
            else
            {




                //sp3cc = SubP3CCDropDownList.SelectedItem.Text;//  Request.Form[SubP3CCDropDownList.UniqueID];


                //sp3altcc = SubP3CCDropDownList2.SelectedItem.Text;


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

            //sub profile 4

            if (sp4country == "" || sp4country==null)
            {
                sp4cc = "";
                sp4altcc = "";
                sp4mobile = "";
                sp4alternate = "";
            }
            else
            {

                //sp4cc = SubP4CCDropDownList.SelectedItem.Text;

                //sp4altcc = SubP4CCDropDownList2.SelectedItem.Text;


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





            int phone = Queries2.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3cc, sp3mobile, sp4cc, sp4mobile, sp3altcc, sp3alternate, sp4altcc, sp4alternate);
            int email = Queries2.UpdateEmail(profile, pemail, semail, sp1email, sp2email,pemail2,semail2,sp1email2,sp1email2, sp3email, sp3email2, sp4email, sp4email2);


            //stay details
            string resort = hotelTextBox.Text;
            string roomno = roomnoTextBox.Text;
            string arrivaldate = datepicker5.Text;
            string tarrivaldate;
            if (arrivaldate == "")
            {
                tarrivaldate = "1900-01-01";
            }
            else
            {
                tarrivaldate = arrivaldate;// Convert.ToDateTime(arrivaldate).ToString("yyyy-MM-dd"); //datepicker5.Text;
            }
            string departuredate = datepicker6.Text;
            string tdeparturedate;
            if (departuredate == "")
            {
                tdeparturedate = "1900-01-01";
            }
            else
            {
                tdeparturedate = departuredate;// Convert.ToDateTime(departuredate).ToString("yyyy-MM-dd"); //datepicker6.Text;
            }

            //guest status

            if (gueststatusDropDownList.SelectedItem.Text == "")
            {
                gueststatus = "";
            }
            else
            {

                gueststatus = gueststatusDropDownList.SelectedItem.Text;
            }

            if (salesrepDropDownList.SelectedItem.Text == "")
            {
                salesrep = "";
            }
            else
            {

                salesrep = salesrepDropDownList.SelectedItem.Text;
            }


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
            //    ttourdate = tourdate;// Convert.ToDateTime(tourdate).ToString("yyyy-MM-dd"); //tourdatedatepicker.Text;
            //}
            string taxin = taxipriceInTextBox.Text;
            string taxirefin = TaxiRefInTextBox.Text;
            string taxiout = TaxiPriceOutTextBox.Text;
            string taxirefout = TaxiRefOutTextBox.Text;


            string QualiStatus = QStatusDropDownList1.SelectedItem.Text;

           


            /*if (GiftOptDropDownList.SelectedItem.Text == "")
            {
                gift_option = "";
            }
            else
            {

                gift_option = GiftOptDropDownList.SelectedItem.Text;
            }*/
            //string VoucherNo = TextVoucherNo.Text;
            //string giftcomm = TextComment.Text;




            int stay = Queries2.UpdateProfileStay(profile, resort, roomno, tarrivaldate, tdeparturedate);
            int tour = Queries2.UpdateTourDetails(profile, gueststatus, salesrep, ttourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout,QualiStatus, weekno);

            //int giftoption = Queries2.Updategiftoption(profile, gift_option, VoucherNo, giftcomm);


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




            //if (giftoptionDropDownList.SelectedItem.Text != "")
            //{
            //    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList, gifto1, voucher1, ProfileIDo,"");
            //}
            //if (giftoptionDropDownList2.SelectedItem.Text != "")
            //{
            //    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList2, gifto2, voucher2, ProfileIDo,"");
            //}
            //if (giftoptionDropDownList3.SelectedItem.Text != "")
            //{
            //    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList3, gifto3, voucher3, ProfileIDo,"");
            //}

            string chargeback = TextBoxChargeBack.Text;


            if (giftoptionDropDownList.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList == "" || ogiftoptionDropDownList == null)
                {
                    string giftid = Queries.GetProfileGift(officeo);

                    int insert = Queries2.InsertGiftOption(giftid, gifto1, voucher1, chargeback, ProfileIDo, "", giftprice1);
                    int update1 = Queries.UpdateGiftValue(officeo, DateTime.Now.Year);
                }
                else
                {
                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList, gifto1, voucher1, ProfileIDo, chargeback, giftprice1);
                }
            }
            if (giftoptionDropDownList2.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList2 == "" || ogiftoptionDropDownList2 == null)
                {
                    string giftid = Queries.GetProfileGift(officeo);

                    int insert = Queries2.InsertGiftOption(giftid, gifto2, voucher2, "", ProfileIDo, "", giftprice2);
                    int update1 = Queries.UpdateGiftValue(officeo, DateTime.Now.Year);
                }
                else
                {
                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList2, gifto2, voucher2, ProfileIDo, "", giftprice2);
                }
            }
            if (giftoptionDropDownList3.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList3 == "" || ogiftoptionDropDownList3 == null)
                {
                    string giftid = Queries.GetProfileGift(officeo);

                    int insert = Queries2.InsertGiftOption(giftid, gifto3, voucher3, "", ProfileIDo, "", giftprice3);
                    int update1 = Queries.UpdateGiftValue(officeo, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList3, gifto3, voucher3, ProfileIDo, "", giftprice3);
                }
            }

            if (giftoptionDropDownList4.SelectedItem.Text != "")
            {
                if (ogiftoptionDropDownList4 == "" || ogiftoptionDropDownList4 == null)
                {
                    string giftid = Queries.GetProfileGift(officeo);

                    int insert = Queries2.InsertGiftOption(giftid, gifto4, voucher4, "", ProfileIDo, "", giftprice4);
                    int update1 = Queries.UpdateGiftValue(officeo, DateTime.Now.Year);
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
                    string giftid = Queries.GetProfileGift(officeo);

                    int insert = Queries2.InsertGiftOption(giftid, gifto5, voucher5, "", ProfileIDo, "", giftprice5);
                    int update1 = Queries.UpdateGiftValue(officeo, DateTime.Now.Year);
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
                    string giftid = Queries.GetProfileGift(officeo);

                    int insert = Queries2.InsertGiftOption(giftid, gifto6, voucher6, "", ProfileIDo, "", giftprice6);
                    int update1 = Queries.UpdateGiftValue(officeo, DateTime.Now.Year);
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
                    string giftid = Queries.GetProfileGift(officeo);

                    int insert = Queries2.InsertGiftOption(giftid, gifto7, voucher7, "", ProfileIDo, "", giftprice7);
                    int update1 = Queries.UpdateGiftValue(officeo, DateTime.Now.Year);
                }
                else
                {

                    int gift = Queries2.UpdateGiftValue(ogiftoptionDropDownList7, gifto7, voucher7, ProfileIDo, "", giftprice7);
                }
            }




            string msg = "Details updated for Profile :" + " " + profile;
            // Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
           // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele()", true);
            //Response.Write("<script>pele();</script>");
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('hi')", true);

            string str = "<script>pele('"+ msg + "');</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);

        }
        catch (Exception ex)
        {


            //MessageBox.Show("Error while Updating profile " + ex.Message);


            string msg = "Error while Updating profile " + ex.Message;
            //MessageBox.Show("Error while creating profile " + ex.Message);
            //string msg = "Details updated for Profile :" + " " + profile;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);

            //int delete = Queries2.Deleteprofileonerror(ProfileIDo);

            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

        }

    }
}






