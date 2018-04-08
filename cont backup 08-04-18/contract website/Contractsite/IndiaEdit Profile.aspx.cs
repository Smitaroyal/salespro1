using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Sql;
using System.Net;
using System.IO;
using System.Web.UI.WebControls.Adapters;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Globalization;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate, sp3mobile, sp3alternate, sp4mobile, sp4alternate,priOfficeno,secOfficeno;
    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec;
    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc, sp3cc, sp3altccc, sp4cc, sp4altccc,priOfficecc,secOfficecc;
    static string membertype1, memno1;
    static string pemail, semail,sp1email, sp2email, sp3email, sp4email;

    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager,ophid,ocard,oVP_ID;
    static string oProfile_Primary_ID,   oProfile_Primary_Title, oProfile_Primary_Fname,   oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID,opage,oplang,opdesignation;
    static string oProfile_Secondary_ID,  oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB,   oProfile_Secondary_Nationality, oProfile_Secondary_Country, osage, oslang, osdesignation;
    static string oSub_Profile1_ID,  oSub_Profile1_Title, oSub_Profile1_Fname,  oSub_Profile1_Lname, oSub_Profile1_DOB ,   oSub_Profile1_Nationality, oSub_Profile1_Country,osp1age;
    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country,osp2age;
    static string oSub_Profile3_ID, oSub_Profile3_Title, oSub_Profile3_Fname, oSub_Profile3_Lname, oSub_Profile3_DOB, oSub_Profile3_Nationality, oSub_Profile3_Country, osp3age;
    static string oSub_Profile4_ID, oSub_Profile4_Title, oSub_Profile4_Fname, oSub_Profile4_Lname, oSub_Profile4_DOB, oSub_Profile4_Nationality, oSub_Profile4_Country, osp4age;
    static string oProfile_Address_ID ,   oProfile_Address_Line1, oProfile_Address_Line2,   oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city,    oProfile_Address_Postcode, oProfile_Address_Created_Date,    oProfile_Address_Expiry_Date;
    static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate,oSubprofile3_CC, oSubprofile3_Mobile, oSubprofile3_Alt_CC, oSubprofile3_Alternate, oSubprofile4_CC, oSubprofile4_Mobile, oSubprofile4_Alt_CC, oSubprofile4_Alternate,opriOfficeCC,opriOfficeNo, osecOfficeCC, osecOfficeNo;
    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email, oSubprofile3_Email, oSubprofile4_Email;
    static string oProfile_Stay_ID ,  oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    static string oTour_Details_ID ,  oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep,    oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In,    oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price,  oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;
    static string profile_ID;
    static string regTerms, oregTerms,tourweekno;

    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }

        string ProfileID = Convert.ToString(Request.QueryString["Profile_ID"]);
        profile_ID = ProfileID;

        if (!Page.IsPostBack)
        {
           
            CreatedByTextBox.Text = user;
            //get office of user
            string office = Queries.GetOffice(user);
            //



            DataSet ds = Queries.LoadProfielDetailsFull(ProfileID);
            ProfileIDTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();         
            createddateTextBox.Text  = ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"].ToString();
            CreatedByTextBox.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString();
            ViewPointTextBox.Text= ds.Tables[0].Rows[0]["VP_ID"].ToString();
            ophid = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
            ocard = ds.Tables[0].Rows[0]["Card_Holder"].ToString();
            DataSet ds1 = Queries.LoadProfileVenueCountry(ProfileID);
            VenueCountryDropDownList.DataSource = ds1;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            DataSet ds2 = Queries.LoadProfileVenue(ProfileID, VenueCountryDropDownList.SelectedItem.Text);
            VenueDropDownList.DataSource = ds2;
            VenueDropDownList.DataTextField = "Venue_Name";
            VenueDropDownList.DataValueField = "Venue_Name";
            VenueDropDownList.AppendDataBoundItems = true;
            VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            VenueDropDownList.DataBind();

            DataSet ds3 = Queries.LoadProfileVenueGroup(ProfileID,VenueDropDownList.SelectedItem.Text);
            GroupVenueDropDownList.DataSource = ds3;
            GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            GroupVenueDropDownList.AppendDataBoundItems = true;
            GroupVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            GroupVenueDropDownList.DataBind();

            //DataSet ds4 = Queries.LoadProfileMktg(ProfileID, VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
            //MarketingPrgmDropDownList.DataSource = ds4;
            //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            //MarketingPrgmDropDownList.AppendDataBoundItems = true;
            //MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            //MarketingPrgmDropDownList.DataBind();

            //if (GroupVenueDropDownList.SelectedItem.Text == "Coldline")
            //{
                //     DataSet ds5 = Queries.LoadProfileAgent(ProfileID);
            //    DataSet ds5 = Queries.LoadProfileAgent1(ProfileID, VenueDropDownList.SelectedItem.Text);
            //    AgentsDropDownList.DataSource = ds5;
            //    AgentsDropDownList.DataTextField = "agent_name";
            //    AgentsDropDownList.DataValueField = "agent_name";
            //    AgentsDropDownList.AppendDataBoundItems = true;
            //    AgentsDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
            //    AgentsDropDownList.DataBind();
            //    //to names
            //    DataSet ds6 = Queries.LoadProfileTOName(ProfileID, VenueDropDownList.SelectedItem.Text);
            //    TonameDropDownList.DataSource = ds6;
            //    TonameDropDownList.DataTextField = "to_name";
            //    TonameDropDownList.DataValueField = "to_name";
            //    TonameDropDownList.AppendDataBoundItems = true;
            //    TonameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            //    TonameDropDownList.DataBind();
            //    //managers

            //    DataSet dsmg = Queries.LoadProfileManager(ProfileID, VenueDropDownList.SelectedItem.Text);
            //    mgrDropDownList.DataSource = dsmg;
            //    mgrDropDownList.DataTextField = "Manager_Name";
            //    mgrDropDownList.DataValueField = "Manager_Name";
            //    mgrDropDownList.AppendDataBoundItems = true;
            //    mgrDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["manager"].ToString(), ""));
            //    mgrDropDownList.DataBind();
            //}
            //else
            //{
            //    DataSet ds5 = Queries.LoadProfileAgentNotColdline(ProfileID, VenueDropDownList.SelectedItem.Text);
            //    AgentsDropDownList.DataSource = ds5;
            //    AgentsDropDownList.DataTextField = "Sales_Rep_Name";
            //    AgentsDropDownList.DataValueField = "Sales_Rep_Name";
            //    AgentsDropDownList.AppendDataBoundItems = true;
            //    AgentsDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
            //    AgentsDropDownList.DataBind();

            //    //to names
            //    DataSet ds6 = Queries.LoadProfileMgrs(ProfileID, VenueDropDownList.SelectedItem.Text);
            //    TonameDropDownList.DataSource = ds6;
            //    TonameDropDownList.DataTextField = "TO_Manager_Name";
            //    TonameDropDownList.DataValueField = "TO_Manager_Name";
            //    TonameDropDownList.AppendDataBoundItems = true;
            //    TonameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            //    TonameDropDownList.DataBind();
            //    //managers

            //    DataSet dsmg = Queries.LoadProfileManager(ProfileID, VenueDropDownList.SelectedItem.Text);
            //    mgrDropDownList.DataSource = dsmg;
            //    mgrDropDownList.DataTextField = "Manager_Name";
            //    mgrDropDownList.DataValueField = "Manager_Name";
            //    mgrDropDownList.AppendDataBoundItems = true;
            //    mgrDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["manager"].ToString(), ""));
            //    mgrDropDownList.DataBind();

            //}

            

           





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

            //DataSet dsem = Queries.LoadEmploymentStatusNotInProfile(ProfileID);
            //employmentstatusDropDownList.DataSource = dsem;
            //employmentstatusDropDownList.DataTextField = "Name";
            //employmentstatusDropDownList.DataValueField = "Name";
            //employmentstatusDropDownList.AppendDataBoundItems = true;
            //employmentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            //employmentstatusDropDownList.DataBind();

            //load marital status

           // DataSet dsms = Queries.LoadMaritalStatusNotInProfile(ProfileID);
           // MaritalStatusDropDownList.DataSource = dsms;
           // MaritalStatusDropDownList.DataTextField = "MaritalStatus";
           // MaritalStatusDropDownList.DataValueField = "MaritalStatus";
           // MaritalStatusDropDownList.AppendDataBoundItems = true;
           // MaritalStatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
           // MaritalStatusDropDownList.DataBind();
           
           
           // livingyrsTextBox.Text    = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
           //string  Profile_Office  = ds.Tables[0].Rows[0]["Office"].ToString();
     

            //DataSet dspt = Queries.LoadPrimarySalutation(ProfileID);
            //primarytitleDropDownList.DataSource = dspt;
            //primarytitleDropDownList.DataTextField = "Salutation";
            //primarytitleDropDownList.DataValueField = "Salutation";
            //primarytitleDropDownList.AppendDataBoundItems = true;
            //primarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
            //primarytitleDropDownList.DataBind();

           


          //  primarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            
            //pfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            //plnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            //pdobdatepicker.Text =Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            //primarynationalityDropDownList.Items.Add (ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString());
            //primaryAge.Text = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            ////pdesginationTextBox.Text = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
            //oplang= ds.Tables[0].Rows[0]["Primary_Language"].ToString();


            //DataSet ds8 = Queries.LoadCountryPrimary(ProfileID);
            //PrimaryCountryDropDownList.DataSource = ds8;
            //PrimaryCountryDropDownList.DataTextField = "country_name";
            //PrimaryCountryDropDownList.DataValueField = "country_name";
            //PrimaryCountryDropDownList.AppendDataBoundItems = true;
            //PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            //PrimaryCountryDropDownList.DataBind();
            //DataSet ds14p = Queries.LoadCountryWithCodePrimaryMobile(ProfileID);
            //primarymobileDropDownList.DataSource = ds14p;
            //primarymobileDropDownList.DataTextField = "name";
            //primarymobileDropDownList.DataValueField = "name";
            //primarymobileDropDownList.AppendDataBoundItems = true;
            //primarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            //primarymobileDropDownList.DataBind();
            //DataSet ds14al = Queries.LoadCountryWithCodePrimaryAlt(ProfileID);
            //primaryalternateDropDownList.DataSource = ds14al;
            //primaryalternateDropDownList.DataTextField = "name";
            //primaryalternateDropDownList.DataValueField = "name";
            //primaryalternateDropDownList.AppendDataBoundItems = true;
            //primaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            //primaryalternateDropDownList.DataBind();           
              
            //pmobile = pmobileTextBox.Text = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
            //palternate = palternateTextBox.Text = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            //pemail = pemailTextBox.Text = ds.Tables[0].Rows[0]["Primary_Email"].ToString();

            //secondary profile
           // secondarytitleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString());

 
            //DataSet dsst = Queries.LoadSecondarySalutation(ProfileID);
            //secondarytitleDropDownList.DataSource = dsst;
            //secondarytitleDropDownList.DataTextField = "Salutation";
            //secondarytitleDropDownList.DataValueField = "Salutation";
            //secondarytitleDropDownList.AppendDataBoundItems = true;
            //secondarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString(), ""));
            //secondarytitleDropDownList.DataBind();



          //  sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
          //  slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
          //  sdobdatepicker.Text =Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
          //  secondarynationalityDropDownList.Items.Add(ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString());
          //   secondaryAge.Text  = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
          ////  sdesignationTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
          //  oslang= ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

            //DataSet ds9 = Queries.LoadCountrySecondary(ProfileID);
            //SecondaryCountryDropDownList.DataSource = ds9;
            //SecondaryCountryDropDownList.DataTextField = "country_name";
            //SecondaryCountryDropDownList.DataValueField = "country_name";
            //SecondaryCountryDropDownList.AppendDataBoundItems = true;
            //SecondaryCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString(), ""));
            //SecondaryCountryDropDownList.DataBind();
            //DataSet ds14  = Queries.LoadCountryWithCodeSecondaryMobile(ProfileID);
            //secondarymobileDropDownList.DataSource = ds14 ;
            //secondarymobileDropDownList.DataTextField = "name";
            //secondarymobileDropDownList.DataValueField = "name";
            //secondarymobileDropDownList.AppendDataBoundItems = true;
            //secondarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_CC"].ToString(), ""));
            //secondarymobileDropDownList.DataBind();
            //DataSet ds14a = Queries.LoadCountryWithCodeSecondaryAlt(ProfileID);
            //secondaryalternateDropDownList.DataSource = ds14a;
            //secondaryalternateDropDownList.DataTextField = "name";
            //secondaryalternateDropDownList.DataValueField = "name";
            //secondaryalternateDropDownList.AppendDataBoundItems = true;
            //secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString(), ""));
            //secondaryalternateDropDownList.DataBind();
    
            //smobileTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            //salternateTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            //semailTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();

            ////  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            //DataSet dssp_1 = Queries.LoadSub_Profile1Salutation(ProfileID);
            //subprofile1titleDropDownList.DataSource = dssp_1;
            //subprofile1titleDropDownList.DataTextField = "Salutation";
            //subprofile1titleDropDownList.DataValueField = "Salutation";
            //subprofile1titleDropDownList.AppendDataBoundItems = true;
            //subprofile1titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
            //subprofile1titleDropDownList.DataBind();


            ////  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            //sp1fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            //sp1lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            //sp1dobdatepicker.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            //subprofile1nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString());
            //subProfile1Age.Text= ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();
            //DataSet ds10 = Queries.LoadCountrySP1(ProfileID);
            //SubProfile1CountryDropDownList.DataSource = ds10;
            //SubProfile1CountryDropDownList.DataTextField = "country_name";
            //SubProfile1CountryDropDownList.DataValueField = "country_name";
            //SubProfile1CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            //SubProfile1CountryDropDownList.DataBind();


            //DataSet dssp1 = Queries.LoadCountryWithCodeSP1Mobile(ProfileID);
            //subprofile1mobileDropDownList.DataSource = dssp1;
            //subprofile1mobileDropDownList.DataTextField = "name";
            //subprofile1mobileDropDownList.DataValueField = "name";
            //subprofile1mobileDropDownList.AppendDataBoundItems = true;
            //subprofile1mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            //subprofile1mobileDropDownList.DataBind();
            //DataSet dsspalt = Queries.LoadCountryWithCodeSP1Alt(ProfileID);
            //subprofile1alternateDropDownList.DataSource = dsspalt;
            //subprofile1alternateDropDownList.DataTextField = "name";
            //subprofile1alternateDropDownList.DataValueField = "name";
            //subprofile1alternateDropDownList.AppendDataBoundItems = true;
            //subprofile1alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            //subprofile1alternateDropDownList.DataBind();

           
            //sp1mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            //sp1alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            //sp1emailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();


        ////    subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());

        //    DataSet dssp_2 = Queries.LoadSub_Profile2Salutation(ProfileID);
        //    subprofile2titleDropDownList.DataSource = dssp_2;
        //    subprofile2titleDropDownList.DataTextField = "Salutation";
        //    subprofile2titleDropDownList.DataValueField = "Salutation";
        //    subprofile2titleDropDownList.AppendDataBoundItems = true;
        //    subprofile2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
        //    subprofile2titleDropDownList.DataBind();

            ////  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            //sp2fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            //sp2lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            //sp2dobdatepicker.Text =Convert.ToDateTime( ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            //subprofile2nationalityDropDownList.Items.Add( ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());
            //subProfile2Age.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();
            //DataSet ds11 = Queries.LoadCountrySP2(ProfileID);
            //SubProfile2CountryDropDownList.DataSource = ds11;
            //SubProfile2CountryDropDownList.DataTextField = "country_name";
            //SubProfile2CountryDropDownList.DataValueField = "country_name";
            //SubProfile2CountryDropDownList.AppendDataBoundItems = true;
            //SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            //SubProfile2CountryDropDownList.DataBind();
          
          

            //DataSet dssp2 = Queries.LoadCountryWithCodeSP2Mobile(ProfileID);
            //subprofile2mobileDropDownList.DataSource = dssp2;
            //subprofile2mobileDropDownList.DataTextField = "name";
            //subprofile2mobileDropDownList.DataValueField = "name";
            //subprofile2mobileDropDownList.AppendDataBoundItems = true;
            //subprofile2mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            //subprofile2mobileDropDownList.DataBind();
            //DataSet dsspalt2 = Queries.LoadCountryWithCodeSP2Alt(ProfileID);
            //subprofile2alternateDropDownList.DataSource = dsspalt2;
            //subprofile2alternateDropDownList.DataTextField = "name";
            //subprofile2alternateDropDownList.DataValueField = "name";
            //subprofile2alternateDropDownList.AppendDataBoundItems = true;
            //subprofile2alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            //subprofile2alternateDropDownList.DataBind();


            //sp2mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            //sp2alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
            //sp2emailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString(); 

         // address1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
         //  address2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
         //    stateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
         //cityTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
         //    pincodeTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();

            //DataSet ds12 = Queries.LoadCountryName();
            //AddCountryDropDownList.DataSource = ds12;
            //AddCountryDropDownList.DataTextField = "country_name";
            //AddCountryDropDownList.DataValueField = "country_name";
            //AddCountryDropDownList.AppendDataBoundItems = true;
            //AddCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
            //AddCountryDropDownList.DataBind();



            //stay details
            //hotelTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            // roomnoTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
           // checkindatedatepicker.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
           // checkoutdatedatepicker.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

          


            //guest status

            //DataSet dsg = Queries.LoadGuestStatusInProfile(ProfileID);
            //gueststatusDropDownList.DataSource = dsg;
            //gueststatusDropDownList.DataTextField = "Guest_Status_name";
            //gueststatusDropDownList.DataValueField = "Guest_Status_name";
            //gueststatusDropDownList.AppendDataBoundItems = true;
            //gueststatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            //gueststatusDropDownList.DataBind();
            //       gueststatusDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString()); 

            // salesrepDropDownList.Items.Add(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());
            // deckcheckintimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            // deckcheckouttimeTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            //tourdatedatepicker.Text= Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
            //taxipriceInTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            //TaxiRefInTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            //  TaxiPriceOutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            // TaxiRefOutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();

           // oProfile_Venue_Country = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
           // oProfile_Venue = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
           // oProfile_Group_Venue = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
           // oProfile_Marketing_Program = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
           // oProfile_Agent = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
           // oProfile_Agent_Code = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
           // oProfile_Member_Type1 = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
           // oProfile_Member_Number1 = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
           // oProfile_Member_Type2 = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
           // oProfile_Member_Number2 = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
           // oProfile_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
           // oProfile_Marital_status = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
           // oProfile_NOY_Living_as_couple = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
           // oOffice = ds.Tables[0].Rows[0]["Office"].ToString();
           // oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
           // oManager = ds.Tables[0].Rows[0]["Manager"].ToString();
           
           // oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
           // oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
           // oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
           // oProfile_Primary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
           // oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
           // oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
           //opage= ds.Tables[0].Rows[0]["Primary_Age"].ToString();
           // opdesignation = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
           // oplang = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

           // oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
           // oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
           // oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
           // oProfile_Secondary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
           // oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
           // oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
           // osage = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
           // osdesignation = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
           // oslang = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();


           // oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
           // oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
           // oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
           // oSub_Profile1_DOB =Convert.ToDateTime( ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
           // oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
           // oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
           //osp1age = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

            
           // oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
           // oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
           // oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
           // oSub_Profile2_DOB =Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
           // oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
           // oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
           // osp2age = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

           // oSub_Profile3_Title = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
           // oSub_Profile3_Fname = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
           // oSub_Profile3_Lname = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
           // oSub_Profile3_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
           // oSub_Profile3_Nationality = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
           // oSub_Profile3_Country = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
           // osp3age = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();

           // oSub_Profile4_Title = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
           // oSub_Profile4_Fname = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
           // oSub_Profile4_Lname = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
           // oSub_Profile4_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
           // oSub_Profile4_Nationality = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
           // oSub_Profile4_Country = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();
           // osp4age = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

           // oProfile_Address_Line1 = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
           // oProfile_Address_Line2 = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
           // oProfile_Address_State = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
           // oProfile_Address_city = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
           // oProfile_Address_Postcode = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
           // oProfile_Address_Created_Date = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
           // oProfile_Address_Expiry_Date = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();

           // oProfile_Address_Country = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();

           // oPrimary_CC = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
           // oPrimary_Mobile = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
           // oPrimary_Alt_CC = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
           // oPrimary_Alternate = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
           // oSecondary_CC = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
           // oSecondary_Mobile = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
           // oSecondary_Alt_CC = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
           // oSecondary_Alternate = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
           // oSubprofile1_CC = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
           // oSubprofile1_Mobile = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
           // oSubprofile1_Alt_CC = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
           // oSubprofile1_Alternate = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
           // oSubprofile2_CC = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
           // oSubprofile2_Mobile = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
           // oSubprofile2_Alt_CC = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
           // oSubprofile2_Alternate = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
           // oSubprofile3_CC = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
           // oSubprofile3_Mobile = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
           // oSubprofile3_Alt_CC = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
           // oSubprofile3_Alternate = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
           // oSubprofile4_CC = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
           // oSubprofile4_Mobile = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
           // oSubprofile4_Alt_CC = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
           // oSubprofile4_Alternate = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();

           // oPrimary_Email = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
           // oSecondary_Email = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
           // oSubprofile1_Email = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
           // oSubprofile2_Email = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
           // oSubprofile3_Email = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
           // oSubprofile4_Email = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();

           // oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
           // oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
           // oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
           // oProfile_Stay_Arrival_Date =Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
           // oProfile_Stay_Departure_Date =Convert.ToDateTime( ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

           // oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
           // oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
           // oTour_Details_Tour_Date =Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
           // oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
           // oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
           // oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
           // oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
           // oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
           // oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();



        }
    }
   


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
        ////get code
        //string venuecode= Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, (Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));

        
        //DataSet ds1 = Queries.LoadVenueGroup(venuecode);
        //GroupVenueDropDownList.DataSource = ds1;
        //GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
        //GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
        //GroupVenueDropDownList.AppendDataBoundItems = true;
        //GroupVenueDropDownList.Items.Insert(0, new ListItem("", ""));
        //GroupVenueDropDownList.DataBind();
    }

    protected void GroupVenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get code
        string venuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);


        //DataSet ds1 = Queries.LoadMarketingProgram(venuecode);
        //MarketingPrgmDropDownList.DataSource = ds1;
        //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
        //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
        //MarketingPrgmDropDownList.AppendDataBoundItems = true;
        //MarketingPrgmDropDownList.Items.Insert(0, new ListItem("", ""));
        //MarketingPrgmDropDownList.DataBind();
        
    }

    //protected void PrimaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    primarymobileDropDownList.Items.Clear();
    //    string code = Queries.GetCountryCode(PrimaryCountryDropDownList.SelectedItem.Text);
    //    DataSet ds12 = Queries.LoadCountryWithCode();
    //    primarymobileDropDownList.DataSource = ds12;
    //    primarymobileDropDownList.DataTextField = "name";
    //    primarymobileDropDownList.DataValueField = "name";
    //    primarymobileDropDownList.AppendDataBoundItems = true;
    //    primarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
    //    primarymobileDropDownList.DataBind();

    //}

    //protected void SecondaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    secondarymobileDropDownList.Items.Clear();
    //    string code = Queries.GetCountryCode(SecondaryCountryDropDownList.SelectedItem.Text);
    //    DataSet ds12 = Queries.LoadCountryWithCode();
    //    secondarymobileDropDownList.DataSource = ds12;
    //    secondarymobileDropDownList.DataTextField = "name";
    //    secondarymobileDropDownList.DataValueField = "name";
    //    secondarymobileDropDownList.AppendDataBoundItems = true;
    //    secondarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
    //    secondarymobileDropDownList.DataBind();
    //}

    //protected void SubProfile1CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    subprofile1mobileDropDownList.Items.Clear();
    //    string code = Queries.GetCountryCode(SubProfile1CountryDropDownList.SelectedItem.Text);
    //    DataSet ds12 = Queries.LoadCountryWithCode();
    //    subprofile1mobileDropDownList.DataSource = ds12;
    //    subprofile1mobileDropDownList.DataTextField = "name";
    //    subprofile1mobileDropDownList.DataValueField = "name";
    //    subprofile1mobileDropDownList.AppendDataBoundItems = true;
    //    subprofile1mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
    //    subprofile1mobileDropDownList.DataBind();
    //}
    //protected void SubProfile2CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    subprofile2mobileDropDownList.Items.Clear();
    //    string code = Queries.GetCountryCode(SubProfile2CountryDropDownList.SelectedItem.Text);
    //    DataSet ds12 = Queries.LoadCountryWithCode();
    //    subprofile2mobileDropDownList.DataSource = ds12;
    //    subprofile2mobileDropDownList.DataTextField = "name";
    //    subprofile2mobileDropDownList.DataValueField = "name";
    //    subprofile2mobileDropDownList.AppendDataBoundItems = true;
    //    subprofile2mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
    //    subprofile2mobileDropDownList.DataBind();
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {

        DataSet ds = Queries.LoadProfielDetailsFull(ProfileIDTextBox.Text);
        oProfile_Venue_Country = ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString();
        oProfile_Venue = ds.Tables[0].Rows[0]["Profile_Venue"].ToString();
        oProfile_Group_Venue = ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString();
        oVP_ID= ds.Tables[0].Rows[0]["VP_ID"].ToString();
        oProfile_Marketing_Program = ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString();
        oProfile_Agent = ds.Tables[0].Rows[0]["Profile_Agent"].ToString();
        oProfile_Agent_Code = ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString();
        oProfile_Member_Type1 = ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString();
        oProfile_Member_Number1 = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();
        oProfile_Member_Type2 = ds.Tables[0].Rows[0]["Profile_Member_Type2"].ToString();
        oProfile_Member_Number2 = ds.Tables[0].Rows[0]["Profile_Member_Number2"].ToString();
        oProfile_Employment_status = ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString();
        oProfile_Marital_status = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
        oProfile_NOY_Living_as_couple = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
        oOffice = ds.Tables[0].Rows[0]["Office"].ToString();
        oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
        oManager = ds.Tables[0].Rows[0]["Manager"].ToString();
        ophid = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
        ocard = ds.Tables[0].Rows[0]["Card_Holder"].ToString();

        oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
        oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
        oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
        oProfile_Primary_DOB =  Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
        oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
       opage = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
        opdesignation  = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
        oplang = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

        oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
        oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
        oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
        oProfile_Secondary_DOB =ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString();
        if (oProfile_Secondary_DOB=="" || oProfile_Secondary_DOB==null)
        {

        }else
        {
            oProfile_Secondary_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
        }


        oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
        oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
        osage= ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
       osdesignation = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
        oslang = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

        oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
        oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
        oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
        oSub_Profile1_DOB = ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString();
        if (oSub_Profile1_DOB=="" || oSub_Profile1_DOB==null)
        {

        }else
        {
            oSub_Profile1_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
        }
     
        oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
        oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
       osp1age= ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

        oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
        oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
        oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
        oSub_Profile2_DOB = ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString();
        if (oSub_Profile2_DOB=="" || oSub_Profile2_DOB==null)
        {

        }else
        {
            oSub_Profile2_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
        }
      
        oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
        oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
        osp2age = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

        oSub_Profile3_Title = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
        oSub_Profile3_Fname = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
        oSub_Profile3_Lname = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
        oSub_Profile3_DOB = ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString();
        if (oSub_Profile3_DOB=="" || oSub_Profile3_DOB == null)
        {

        }else
        {
            oSub_Profile3_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
        }
      
        oSub_Profile3_Nationality = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
        oSub_Profile3_Country = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
        osp3age = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();


        oSub_Profile4_Title = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
        oSub_Profile4_Fname = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
        oSub_Profile4_Lname = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
        oSub_Profile4_DOB = ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString();
        if (oSub_Profile4_DOB=="" || oSub_Profile4_DOB==null)
        {

        }else
        {
            oSub_Profile4_DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
        }
      
        oSub_Profile4_Nationality = ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString();
        oSub_Profile4_Country = ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString();
        osp4age = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();


        oProfile_Address_Line1 = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
        oProfile_Address_Line2 = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
        oProfile_Address_State = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
        oProfile_Address_city = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
        oProfile_Address_Postcode = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
        oProfile_Address_Created_Date = ds.Tables[0].Rows[0]["Profile_Address_Created_Date"].ToString();
        oProfile_Address_Expiry_Date = ds.Tables[0].Rows[0]["Profile_Address_Expiry_Date"].ToString();
        oProfile_Address_Country = ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString();

        oPrimary_CC = ds.Tables[0].Rows[0]["Primary_CC"].ToString();
        oPrimary_Mobile = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();
        oPrimary_Alt_CC = ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString();
        oPrimary_Alternate = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();
        opriOfficeCC= ds.Tables[0].Rows[0]["Primary_office_cc"].ToString();
        opriOfficeNo= ds.Tables[0].Rows[0]["Primary_office_num"].ToString();
        oSecondary_CC = ds.Tables[0].Rows[0]["Secondary_CC"].ToString();
        oSecondary_Mobile = ds.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
        oSecondary_Alt_CC = ds.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString();
        oSecondary_Alternate = ds.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
        osecOfficeCC = ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString();
        osecOfficeNo= ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();
        oSubprofile1_CC = ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString();
        oSubprofile1_Mobile = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
        oSubprofile1_Alt_CC = ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString();
        oSubprofile1_Alternate = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
        oSubprofile2_CC = ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString();
        oSubprofile2_Mobile = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
        oSubprofile2_Alt_CC = ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString();
        oSubprofile2_Alternate = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
        oSubprofile3_CC = ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString();
        oSubprofile3_Mobile = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();
        oSubprofile3_Alt_CC = ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString();
        oSubprofile3_Alternate = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
        oSubprofile4_CC = ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString();
        oSubprofile4_Mobile = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();
        oSubprofile4_Alt_CC = ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString();
        oSubprofile4_Alternate = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();


        oPrimary_Email = ds.Tables[0].Rows[0]["Primary_Email"].ToString();
        oSecondary_Email = ds.Tables[0].Rows[0]["Secondary_Email"].ToString();
        oSubprofile1_Email = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();
        oSubprofile2_Email = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();
        oSubprofile3_Email = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
        oSubprofile4_Email = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();
        oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
        oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
        oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
        oProfile_Stay_Arrival_Date = ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString();
        if (oProfile_Stay_Arrival_Date=="" || oProfile_Stay_Arrival_Date==null)
        {

        }else
        {
            oProfile_Stay_Arrival_Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
        }

        oProfile_Stay_Departure_Date = ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString();
        if (oProfile_Stay_Departure_Date=="" || oProfile_Stay_Departure_Date==null)
        {

        }else
        {
            oProfile_Stay_Departure_Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");
        }

     

        oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
        oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
        oTour_Details_Tour_Date =  Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
        tourweekno = ds.Tables[0].Rows[0]["Week_number"].ToString();
        oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
        oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
        oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
        oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
        oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
        oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
        oregTerms = ds.Tables[0].Rows[0]["RegTerms"].ToString();

        //update profile

        string user =(string)Session["username"]; 
        CreatedByTextBox.Text = user;
        //get office of user
        string office = Queries.GetOffice(user);

        string profile = ProfileIDTextBox.Text;
        string createdby = CreatedByTextBox.Text;
        string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
        string venue = VenueDropDownList.SelectedItem.Text;
        string venuegroup = GroupVenueDropDownList.SelectedItem.Text;
        string viewPointID = ViewPointTextBox.Text;
        if (viewPointID == "" || viewPointID == null)
        {
            viewPointID = "";
        }else
        {
            viewPointID = ViewPointTextBox.Text;
        }
        string mktg = Request.Form[MarketingPrgmDropDownList.UniqueID];//MarketingPrgmDropDownList.SelectedItem.Text;
        string agents = Request.Form[AgentsDropDownList.UniqueID]; //AgentsDropDownList.SelectedItem.Text;
        string agentcode = Request.Form[TonameDropDownList.UniqueID];// TonameDropDownList.SelectedItem.Text;
        string mgr; //= mgrDropDownList.SelectedItem.Text;

        string photoidentity; 
        if (Request.Form["pidentity"] == null)
        {
            photoidentity = "";
        }
        else
        {
            photoidentity = Request.Form["pidentity"];
        }
        string card; 
        if (Request.Form["card"] == null)
        {
            card = "";
        }
        else
        {
            card = Request.Form["card"];
        }
        //member details
      //  string membertype1 = MemType1DropDownList.SelectedItem.Text;
      //  string memno1 = Memno1TextBox.Text;
        if (mktg == "Owner" || mktg == "OWNER")
        {
            membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno = Memno1TextBox.Text;
            if (memno == null)
            {
                memno1 = "";
            }
            else
            {
                memno1 = Memno1TextBox.Text;
            }

        }
        else
        {
            membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno = Request.Form[TypeDropDownList.UniqueID];//TypeDropDownList.SelectedItem.Text;
            if (memno == null)
            {

                memno1 = "";
            }
            else
            {

                memno1 = Request.Form[TypeDropDownList.UniqueID];
            }


        }


        string membertype2 = MemType2DropDownList.SelectedItem.Text;
        string memno2 = Memno2TextBox.Text;

        if (venuegroup == "Coldline"|| venuegroup == "COLDLINE")
        {
            mgr = Request.Form[mgrDropDownList.UniqueID];
        }
        else
        {
            mgr = agentcode;
        }

        //primary profile
        string primarytitle = Request.Form[primarytitleDropDownList.UniqueID]; //primarytitleDropDownList.SelectedItem.Text;


        string primaryfname = pfnameTextBox.Text;
        string primaylname = plnameTextBox.Text;
        string primarydob = pdobdatepicker.Text;//Convert.ToDateTime(pdobdatepicker.Text).ToString("yyyy-MM-dd");
        string primarynationality = Request.Form[primarynationalityDropDownList.UniqueID]; //primarynationalityDropDownList.SelectedItem.Text;
        string primarycountry = Request.Form[PrimaryCountryDropDownList.UniqueID];// PrimaryCountryDropDownList.SelectedItem.Text;
        string npage = primaryAge.Text;
        string npdesg = pdesginationTextBox.Text;
        string primarylanguage;


        if (Request.Form["primarylang"] == null)
        {
            primarylanguage = "";
        }
        else
        {
            primarylanguage = Request.Form["primarylang"];

        }
        if (primarymobileDropDownList.SelectedIndex == 0)
        {
            pcc = "";

        }
        else
        {
          
            pcc = Request.Form[primarymobileDropDownList.UniqueID]; //primarymobileDropDownList.SelectedItem.Text;

        }
        if (primaryalternateDropDownList.SelectedIndex == 0)
        {
            paltrcc = "";
        }
        else
        {
          
            paltrcc = Request.Form[primarymobileDropDownList.UniqueID]; //primaryalternateDropDownList.SelectedItem.Text; 
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

        if (pofficecodeDropDownList.SelectedIndex == 0)
        {
            priOfficecc = "";
        }
        else
        {

            priOfficecc = Request.Form[pofficecodeDropDownList.UniqueID]; //primaryalternateDropDownList.SelectedItem.Text; 
        }


      
        if (pofficenoTextBox.Text == "" || pofficenoTextBox.Text == null)
        {
            priOfficeno = "";
        }
        else
        {
            priOfficeno = pofficenoTextBox.Text;
        }

      


        if (pemailTextBox.Text == "" || pemailTextBox.Text == null)
        {
            pemail = "";
        }
        else
        {
            pemail = pemailTextBox.Text;
        }

        //secondary profile

        string secondarytitle = Request.Form[secondarytitleDropDownList.UniqueID]; //secondarytitleDropDownList.SelectedItem.Text;

        string secondaryfname = sfnameTextBox.Text;
        string secondarylname = slnameTextBox.Text;
        string secondarydob = sdobdatepicker.Text;//Convert.ToDateTime(sdobdatepicker.Text).ToString("yyyy-MM-dd"); 
        string secondarynationality = Request.Form[secondarynationalityDropDownList.UniqueID]; //secondarynationalityDropDownList.SelectedItem.Text;
        string secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID]; //SecondaryCountryDropDownList.SelectedItem.Text;
        string nsage = secondaryAge.Text;
        string nsdesg = sdesignationTextBox.Text;

        string secondarylanguage; 
        if (Request.Form["seclang"] == null)
        {
            secondarylanguage = "";
        }
        else
        {
            secondarylanguage = Request.Form["seclang"];

        }
        if (secondarymobileDropDownList.SelectedIndex == 0)
        {
            scc = "";
        }
        else
        {

            scc = Request.Form[secondarymobileDropDownList.UniqueID]; //secondarymobileDropDownList.SelectedItem.Text;  
        }

        if (secondaryalternateDropDownList.SelectedIndex == 0)
        {
            saltcc = "";
        }
        else
        {
            
            saltcc = Request.Form[secondaryalternateDropDownList.UniqueID]; //secondaryalternateDropDownList.SelectedItem.Text; 
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

        if (sofficecodeDropDownList.SelectedIndex == 0)
        {
            secOfficecc = "";
        }
        else
        {

            secOfficecc = Request.Form[sofficecodeDropDownList.UniqueID]; //primaryalternateDropDownList.SelectedItem.Text; 
        }



        if (sofficenoTextBox.Text == "" || sofficenoTextBox.Text == null)
        {
            secOfficeno = "";
        }
        else
        {
            secOfficeno = sofficenoTextBox.Text;
        }

        if (semailTextBox.Text == "" || semailTextBox.Text == null)
        {
            semail = "";
        }
        else
        {
            semail = semailTextBox.Text;
        }
        //sub profile1

        string sp1title = Request.Form[subprofile1titleDropDownList.UniqueID];// subprofile1titleDropDownList.SelectedItem.Text;
        string sp1fname = sp1fnameTextBox.Text;
        string sp1lname = sp1lnameTextBox.Text;
        string sp1dob = sp1dobdatepicker.Text;//Convert.ToDateTime(sp1dobdatepicker.Text).ToString("yyyy-MM-dd"); 


        string sp1nationality = Request.Form[subprofile1nationalityDropDownList.UniqueID]; //subprofile1nationalityDropDownList.SelectedItem.Text;
        string sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID]; //SubProfile1CountryDropDownList.SelectedItem.Text;
        string nsp1age = subProfile1Age.Text;
        if (subprofile1mobileDropDownList.SelectedIndex == 0)
        {
            sp1cc = "";
        }
        else
        {
           
            sp1cc = Request.Form[subprofile1mobileDropDownList.UniqueID];//subprofile1mobileDropDownList.SelectedItem.Text; 
        }

        if (subprofile1alternateDropDownList.SelectedIndex == 0)
        {
            sp1altcc = "";
        }
        else
        {
             
            sp1altcc = Request.Form[subprofile1alternateDropDownList.UniqueID];//subprofile1alternateDropDownList.SelectedItem.Text; 
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



        //sub profile 2
        string sp2title = Request.Form[subprofile2titleDropDownList.UniqueID]; //subprofile2titleDropDownList.SelectedItem.Text;
        string sp2fname = sp2fnameTextBox.Text;
        string sp2lname = sp2lnameTextBox.Text;
        string sp2dob = sp2dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp2nationality = Request.Form[subprofile2nationalityDropDownList.UniqueID]; //subprofile2nationalityDropDownList.SelectedItem.Text;
        string sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID]; //SubProfile2CountryDropDownList.SelectedItem.Text;
        string nsp2age = subProfile2Age.Text;
        if (subprofile2mobileDropDownList.SelectedIndex == 0)
        {
            sp2cc = "";
        }
        else
        {
            
            sp2cc = Request.Form[subprofile2mobileDropDownList.UniqueID]; //subprofile2mobileDropDownList.SelectedItem.Text; 
        }

        if (subprofile2alternateDropDownList.SelectedIndex == 0)
        {
            sp2altccc = "";
        }
        else
        {
           
            sp2altccc = Request.Form[subprofile2alternateDropDownList.UniqueID];// subprofile2alternateDropDownList.SelectedItem.Text; 
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




        //sub profile 3
        string sp3title = Request.Form[subprofile3titleDropDownList.UniqueID];  //subprofile3titleDropDownList.SelectedItem.Text;
        string sp3fname = sp3fnameTextBox.Text;
        string sp3lname = sp3lnameTextBox.Text;
        string sp3dob = sp3dobdatepicker.Text;
        string sp3nationality = Request.Form[subprofile3nationalityDropDownList.UniqueID]; //subprofile3nationalityDropDownList.SelectedItem.Text;
        string sp3country = Request.Form[SubProfile3CountryDropDownList.UniqueID];//SubProfile3CountryDropDownList.SelectedItem.Text;
        string nsp3age = subProfile3Age.Text;
        if (subprofile3mobileDropDownList.SelectedIndex == 0)
        {
            sp3cc = "";
        }
        else
        {

            sp3cc = Request.Form[subprofile3mobileDropDownList.UniqueID]; //subprofile3mobileDropDownList.SelectedItem.Text;
        }

        if (subprofile3alternateDropDownList.SelectedIndex == 0)
        {
            sp3altccc = "";
        }
        else
        {

            sp3altccc = Request.Form[subprofile3alternateDropDownList.UniqueID]; //subprofile3alternateDropDownList.SelectedItem.Text;
        }


        if (sp3mobileTextBox.Text == "" || sp3mobileTextBox.Text == null)
        {
            sp3mobile = "";
        }
        else
        {
            sp3mobile = sp3mobileTextBox.Text;

        }
        if (sp3alternateTextBox.Text == "" || sp3alternateTextBox.Text == null)
        {
            sp3alternate = "";

        }
        else
        {
            sp3alternate = sp3alternateTextBox.Text;

        }
        if (sp3emailTextBox.Text == "" || sp3emailTextBox.Text == null)
        {
            sp3email = "";
        }
        else
        {
            sp3email = sp3emailTextBox.Text;
        }


        //sub profile 4
        string sp4title = Request.Form[subprofile4titleDropDownList.UniqueID]; //subprofile4titleDropDownList.SelectedItem.Text;
        string sp4fname = sp4fnameTextBox.Text;
        string sp4lname = sp4lnameTextBox.Text;
        string sp4dob = sp4dobdatepicker.Text;
        string sp4nationality = Request.Form[subprofile4nationalityDropDownList.UniqueID];  //subprofile4nationalityDropDownList.SelectedItem.Text;
        string sp4country = Request.Form[SubProfile4CountryDropDownList.UniqueID]; //SubProfile4CountryDropDownList.SelectedItem.Text;
        string nsp4age = subProfile4Age.Text;
        if (subprofile4mobileDropDownList.SelectedIndex == 0)
        {
            sp4cc = "";
        }
        else
        {

            sp4cc = Request.Form[subprofile4mobileDropDownList.UniqueID]; //subprofile4mobileDropDownList.SelectedItem.Text;
        }

        if (subprofile4alternateDropDownList.SelectedIndex == 0)
        {
            sp4altccc = "";
        }
        else
        {

            sp4altccc = Request.Form[subprofile4alternateDropDownList.UniqueID]; //subprofile4alternateDropDownList.SelectedItem.Text;
        }


        if (sp4mobileTextBox.Text == "" || sp4mobileTextBox.Text == null)
        {
            sp4mobile = "";
        }
        else
        {
            sp4mobile = sp4mobileTextBox.Text;

        }
        if (sp4alternateTextBox.Text == "" || sp4alternateTextBox.Text == null)
        {
            sp4alternate = "";

        }
        else
        {
            sp4alternate = sp4alternateTextBox.Text;

        }
        if (sp4emailTextBox.Text == "" || sp4emailTextBox.Text == null)
        {
            sp4email = "";
        }
        else
        {
            sp4email = sp4emailTextBox.Text;
        }


        //address

        string address1 = address1TextBox.Text;
        string address2 = address2TextBox.Text;
        string state1 = Request.Form[StateDropDownList.UniqueID];// SelectedItem.Text;

        string state;
        if (state1 == "" || state1 == null)
        {
            state = "";
        }
        else
        {
            state = Request.Form[StateDropDownList.UniqueID];
        }
        string city = cityTextBox.Text;
        string pincode = pincodeTextBox.Text;
        string acountry = Request.Form[AddCountryDropDownList.UniqueID]; //AddCountryDropDownList.SelectedItem.Text;
        //other details

        string employmentstatus = Request.Form[employmentstatusDropDownList.UniqueID];//employmentstatusDropDownList.SelectedItem.Text;
        string maritalstatus = Request.Form[MaritalStatusDropDownList.UniqueID];//MaritalStatusDropDownList.SelectedItem.Text;
        string livingyrs = livingyrsTextBox.Text;

        //string maledesgination = pdesginationTextBox.Text;
       // string femaledesignation = sdesignationTextBox.Text;
       

        //stay details
        string resort = hotelTextBox.Text;
        string roomno = roomnoTextBox.Text;
        string arrivaldate = Convert.ToDateTime(checkindatedatepicker.Text).ToString("dd-MM-yyyy"); //checkindatedatepicker.Text;
        string departuredate = Convert.ToDateTime(checkoutdatedatepicker.Text).ToString("dd-MM-yyyy"); //checkoutdatedatepicker.Text;
       
        //guest status

        string gueststatus = Request.Form[gueststatusDropDownList.UniqueID]; //gueststatusDropDownList.SelectedItem.Text;
        string salesrep = Request.Form[salesrepDropDownList.UniqueID];//salesrepDropDownList.SelectedItem.Text;
        string timeIn =  deckcheckintimeTextBox.Text;
        string timeOut =  deckcheckouttimeTextBox.Text;

        //  string tourdate = tourdatedatepicker.Text;
        string tourdate;
        int wkno;
        if (tourdatedatepicker.Text == "" || tourdatedatepicker.Text == null || tourdatedatepicker.Text == "NaN" || tourdatedatepicker.Text == "01-01-1900")
        {
            tourdate = "";
            wkno = 0;
        }
        else
        {
            tourdate = tourdatedatepicker.Text;
            //string  dt = Convert.ToDateTime(tourdate).ToString("dd-MM-yyyy");
            wkno = Queries.GetWkNumber(Convert.ToDateTime(tourdate));

            tourdate = Convert.ToDateTime(tourdatedatepicker.Text).ToString("dd-MM-yyyy") ;
        }
        string taxin = taxipriceInTextBox.Text;
        string taxirefin = TaxiRefInTextBox.Text;
        string taxiout = TaxiPriceOutTextBox.Text;
        string taxirefout = TaxiRefOutTextBox.Text;
        string ProfileComments = commentsTextBox.Text;

        if (CheckBox1.Checked)
        {


            regTerms = "Y";
        }
        else
        {
            regTerms = "N";

        }

        if (String.Compare(oProfile_Venue_Country, venuecountry) != 0)
        {
            string act = "venue country changed from:" + oProfile_Venue_Country + "To:" + venuecountry;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Venue, venue) != 0)
        { string act = "venue changed from:" + oProfile_Venue + "To:" + venue;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Group_Venue, venuegroup) != 0)
        { string act = "venue group changed from:" + oProfile_Group_Venue + "To:" + venuegroup;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }

        if (String.Compare(oVP_ID, viewPointID) != 0)
        {
            string act = "view point ID changed from:" + oVP_ID + "To:" + viewPointID;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Marketing_Program, mktg) != 0)
        { string act = "marketing prgm changed from:" + oProfile_Marketing_Program + "To:" + mktg;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Agent, agents) != 0)
         { string act = "agent name changed from:" + oProfile_Agent + "To:" + agents;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Agent_Code, agentcode) != 0)
        { string act = "To Name changed from:" + oProfile_Agent_Code + "To:" + agentcode;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oManager, mgr) != 0)
        { string act = "manager changed from:" + oManager + "To:" + mgr;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Type1, membertype1) != 0)
        { string act = "membertype1 changed from:" + oProfile_Member_Type1 + "To:" + membertype1;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(ophid, photoidentity) != 0)
        {
            string act = "Photo Identity changed from:" + ophid + "To:" + photoidentity;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(ocard, card) != 0)
        {
            string act = "Card Holder value changed from:" + ocard + "To:" + card;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Number1, memno1) != 0)
          { string act = "memno1 changed from:" + oProfile_Member_Number1 + "To:" + memno1;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Type2, membertype2) != 0)
         { string act = "membertype2 changed from:" + oProfile_Member_Type2 + "To:" + membertype2;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Number2, memno2) != 0)
         {
            string act = "memno2 changed from:" + oProfile_Member_Number2 + "To:" + memno2;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oProfile_Primary_Title, primarytitle) != 0)
        { string act = "primary title changed from:" + oProfile_Primary_Title + "To:" + primarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Fname, primaryfname) != 0)
       {
            string act = "primary fname changed from:" + oProfile_Primary_Fname + "To:" + primaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Lname, primaylname) != 0)
         { string act = "primay lname changed from:" + oProfile_Primary_Lname + "To:" + primaylname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_DOB, primarydob) != 0)
       { string act = "primary dob changed from:" + oProfile_Primary_DOB + "To:" + primarydob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Nationality, primarynationality) != 0)
        { string act = "primary nationality changed from:" + oProfile_Primary_Nationality + "To:" + primarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Country, primarycountry) != 0)
          { string act = "primary country changed from:" + oProfile_Primary_Country + "To:" + primarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opage,npage) != 0)
        {
            string act = "primary age changed from:" + opage + "To:" + npage;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opdesignation,npdesg) != 0)
        {
            string act = "primary designation changed from:" + opdesignation + "To:" + npdesg;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oplang,primarylanguage) != 0)
        {
            string act = "primary Language changed from:" + oplang + "To:" + primarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_CC, pcc) != 0)
        { string act = "primary mobile code changed from:" + oPrimary_CC + "To:" + pcc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Mobile, pmobile) != 0)
        { string act = "primary mobile no changed from:" + oPrimary_Mobile + "To:" + pmobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Alt_CC, paltrcc) != 0)
        {
            string act = "primary mobile changed from:" + oPrimary_Alt_CC + "To:" + paltrcc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Alternate, palternate) != 0)
         { string act = "primary alternate no changed from:" + oPrimary_Alternate + "To:" + palternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opriOfficeCC, priOfficecc) != 0)
        {
            string act = "primary office cc changed from:" + opriOfficeCC + "To:" + priOfficecc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opriOfficeNo, priOfficeno) != 0)
        {
            string act = "primary office no changed from:" + opriOfficeNo + "To:" + priOfficeno;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        
        if (String.Compare(oPrimary_Email, pemail) != 0)
         { string act = "primary email changed from:" + oPrimary_Email + "To:" + pemail;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Title, secondarytitle) != 0)
        {
            string act = "secondary title changed from:" + oProfile_Secondary_Title + "To:" + secondarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Fname, secondaryfname) != 0)
         {
            string act = "secondary fname changed from:" + oProfile_Secondary_Fname + "To:" + secondaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Lname, secondarylname) != 0)
         {
            string act = "secondary lname changed from:" + oProfile_Secondary_Lname + "To:" + secondarylname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_DOB, secondarydob) != 0)
        { string act = "secondary dob changed from:" + oProfile_Secondary_DOB + "To:" + secondarydob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }

        if (String.Compare(oProfile_Secondary_Nationality, secondarynationality) != 0)
         { string act = "secondary nationality changed from:" + oProfile_Secondary_Nationality + "To:" + secondarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osage, nsage) != 0)
        {
            string act = "secondary age changed from:" + osage + "To:" + nsage;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osdesignation, nsdesg) != 0)
        {
            string act = "secondary designation changed from:" + osdesignation + "To:" + nsdesg;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oslang, secondarylanguage) != 0)
        {
            string act = "secondary Language changed from:" + oslang + "To:" + secondarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Country, secondarycountry) != 0)
            { string act = "secondary country changed from:" + oProfile_Secondary_Country + "To:" + secondarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
            if (String.Compare(oSecondary_CC, scc) != 0)
            {        string act = "secondary mobile code changed from:" + oSecondary_CC + "To:" + scc;
                    int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
            } else { }
            if (String.Compare(oSecondary_Mobile, smobile) != 0)
            {
            string act = "secondary mobile no changed from:" + oSecondary_Mobile + "To:" + smobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());

        } else { }
            if (String.Compare(oSecondary_Alt_CC, saltcc) != 0)
            { string act = "secondary alternaet num code changed from:" + oSecondary_Alt_CC + "To:" + saltcc;
              int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
                } else { }
            if (String.Compare(oSecondary_Alternate, salternate) != 0)
            { string act = "secondary alternate no changed from:" + oSecondary_Alternate + "To:" + salternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }

        if (String.Compare(osecOfficeCC, secOfficecc) != 0)
        {
            string act = "secondary office cc changed from:" + osecOfficeCC + "To:" + secOfficecc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osecOfficeNo, secOfficeno) != 0)
        {
            string act = "secondary office no changed from:" + osecOfficeNo + "To:" + secOfficeno;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        
        if (String.Compare(oSecondary_Email, semail) != 0)
        {
            string act = "secondary email changed from:" + oSecondary_Email + "To:" + semail;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oSub_Profile1_Title, sp1title) != 0)
        { string act = "subprofile1 title changed from:" + oSub_Profile1_Title + "To:" + sp1title;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
         else { }
         if (String.Compare(oSub_Profile1_Fname, sp1fname) != 0)
        { string act = "subprofile1 fname changed from:" + oSub_Profile1_Fname + "To:" + sp1fname;
                  int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
         }
            else { }
            if (String.Compare(oSub_Profile1_Lname, sp1lname) != 0)
             {
            string act = "subprofile1 lname changed from:" + oSub_Profile1_Lname + "To:" + sp1lname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
            }
            else { }
            if (String.Compare(oSub_Profile1_DOB, sp1dob) != 0)
            {
            string act = "subprofile1 dob changed from:" + oSub_Profile1_DOB + "To:" + sp1dob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
            }
            else { }
        if (String.Compare(oSub_Profile1_Nationality, sp1nationality) != 0)
        { string act = "subprofile1 nationality changed from:" + oSub_Profile1_Nationality + "To:" + sp1nationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(osp1age, nsp1age) != 0)
        {
            string act = "subprofile1 age changed from:" + osp1age + "To:" + nsp1age;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Country, sp1country) != 0)
          { string act = "subprofile1 country changed from:" + oSub_Profile1_Country + "To:" + sp1country;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
                else { }
                if (String.Compare(oSubprofile1_CC, sp1cc) != 0)
                 { string act = "subprofile1 mobile code changed from:" + oSubprofile1_CC + "To:" + sp1cc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
                else { }
                if (String.Compare(oSubprofile1_Mobile, sp1mobile) != 0)
                { string act = "subprofile1 mobile no changed from:" + oSubprofile1_Mobile + "To:" + sp1mobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
                else { }
                if (String.Compare(oSubprofile1_Alt_CC, sp1altcc) != 0)
                 { string act = "subprofile1 alternate no code changed from:" + oSubprofile1_Alt_CC + "To:" + sp1altcc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
                else { }
        if (String.Compare(oSubprofile1_Alternate, sp1alternate) != 0)
        { string act = "subprofile1 alternate changed from:" + oSubprofile1_Alternate + "To:" + sp1alternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }


        if (String.Compare(oSubprofile1_Email, sp1email) != 0)
        {
            string act = "subprofile1 email changed from:" + oSubprofile1_Email + "To:" + sp1email;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oSub_Profile2_Title, sp2title) != 0)
        {
            string act = "subprofile2 title changed from:" + oSub_Profile2_Title + "To:" + sp2title;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oSub_Profile2_Fname, sp2fname) != 0)
        { string act = "subprofile2 fname changed from:" + oSub_Profile2_Fname + "To:" + sp2fname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
         if (String.Compare(oSub_Profile2_Lname, sp2lname) != 0)
        { string act = "subprofile2 lname changed from:" + oSub_Profile2_Lname + "To:" + sp2lname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
      if (String.Compare(oSub_Profile2_DOB, sp2dob) != 0)
        { string act = "subprofile2 dob changed from:" + oSub_Profile2_DOB + "To:" + sp2dob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
       if (String.Compare(oSub_Profile2_Nationality, sp2nationality) != 0)
       { string act = "subprofile2 nationality changed from:" + oSub_Profile2_Nationality + "To:" + sp2nationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
         else { }
        if (String.Compare(osp2age, nsp2age) != 0)
        {
            string act = "subprofile2 age changed from:" + osp2age + "To:" + nsp2age;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Country, sp2country) != 0)

        { string act = "subprofile2 country changed from:" + oSub_Profile2_Country + "To:" + sp2country;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_CC, sp2cc) != 0)
        {
            string act = "subprofile2 mobile code changed from:" + oSubprofile2_CC + "To:" + sp2cc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Mobile, sp2mobile) != 0)
        { string act = "subprofile2 mobile no changed from:" + oSubprofile2_Mobile + "To:" + sp2mobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
         if (String.Compare(oSubprofile2_Alt_CC, sp2altccc) != 0)
         { string act = "subprofile2 alternate no code changed from:" + oSubprofile2_Alt_CC + "To:" + sp2altccc ;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
       if (String.Compare(oSubprofile2_Alternate, sp2alternate) != 0)
        { string act = "subprofile2 alternate no changed from:" + oSubprofile2_Alternate + "To:" + sp2alternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Email, sp2email) != 0)
        { string act = "subprofile2 email changed from:" + oSubprofile2_Email + "To:" + sp2email;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        //sub profile 3
        if (String.Compare(oSub_Profile3_Title, sp3title) != 0)
        {
            string act = "subprofile3 title changed from:" + oSub_Profile3_Title + "To:" + sp3title;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Fname, sp3fname) != 0)
        {
            string act = "subprofile3 fname changed from:" + oSub_Profile3_Fname + "To:" + sp3fname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Lname, sp3lname) != 0)
        {
            string act = "subprofile3 lname changed from:" + oSub_Profile3_Lname + "To:" + sp3lname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_DOB, sp3dob) != 0)
        {
            string act = "subprofile3 dob changed from:" + oSub_Profile3_DOB + "To:" + sp3dob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Nationality, sp3nationality) != 0)
        {
            string act = "subprofile3 nationality changed from:" + oSub_Profile3_Nationality + "To:" + sp3nationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp3age, nsp3age) != 0)
        {
            string act = "subprofile3 age changed from:" + osp3age + "To:" + nsp3age;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Country, sp3country) != 0)

        {
            string act = "subprofile3 country changed from:" + oSub_Profile3_Country + "To:" + sp3country;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_CC, sp3cc) != 0)
        {
            string act = "subprofile3 mobile code changed from:" + oSubprofile3_CC + "To:" + sp3cc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Mobile, sp3mobile) != 0)
        {
            string act = "subprofile3 mobile no changed from:" + oSubprofile3_Mobile + "To:" + sp3mobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Alt_CC, sp3altccc) != 0)
        {
            string act = "subprofile3 alternate no code changed from:" + oSubprofile3_Alt_CC + "To:" + sp3altccc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Alternate, sp3alternate) != 0)
        {
            string act = "subprofile3 alternate no changed from:" + oSubprofile3_Alternate + "To:" + sp3alternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Email, sp3email) != 0)
        {
            string act = "subprofile3 email changed from:" + oSubprofile3_Email + "To:" + sp3email;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        //end//


        //sub profile 4
        if (String.Compare(oSub_Profile4_Title, sp4title) != 0)
        {
            string act = "subprofile4 title changed from:" + oSub_Profile4_Title + "To:" + sp4title;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Fname, sp4fname) != 0)
        {
            string act = "subprofile4 fname changed from:" + oSub_Profile4_Fname + "To:" + sp4fname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Lname, sp4lname) != 0)
        {
            string act = "subprofile4 lname changed from:" + oSub_Profile4_Lname + "To:" + sp4lname;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_DOB, sp4dob) != 0)
        {
            string act = "subprofile4 dob changed from:" + oSub_Profile4_DOB + "To:" + sp4dob;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Nationality, sp4nationality) != 0)
        {
            string act = "subprofile4 nationality changed from:" + oSub_Profile4_Nationality + "To:" + sp4nationality;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp4age, nsp4age) != 0)
        {
            string act = "subprofile4 age changed from:" + osp4age + "To:" + nsp4age;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Country, sp4country) != 0)

        {
            string act = "subprofile4 country changed from:" + oSub_Profile4_Country + "To:" + sp4country;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_CC, sp4cc) != 0)
        {
            string act = "subprofile4 mobile code changed from:" + oSubprofile4_CC + "To:" + sp4cc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Mobile, sp4mobile) != 0)
        {
            string act = "subprofile4 mobile no changed from:" + oSubprofile4_Mobile + "To:" + sp4mobile;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Alt_CC, sp4altccc) != 0)
        {
            string act = "subprofile4 alternate no code changed from:" + oSubprofile4_Alt_CC + "To:" + sp4altccc;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Alternate, sp4alternate) != 0)
        {
            string act = "subprofile4 alternate no changed from:" + oSubprofile4_Alternate + "To:" + sp4alternate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Email, sp4email) != 0)
        {
            string act = "subprofile4 email changed from:" + oSubprofile4_Email + "To:" + sp3email;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        //end//


        if (String.Compare(oProfile_Address_Line1, address1) != 0)

        { string act = "address1 changed from:" + oProfile_Address_Line1 + "To:" + address1;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Address_Line2, address2) != 0)
        { string act = "address2 changed from:" + oProfile_Address_Line2 + "To:" + address2;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Address_State, state) != 0)
        { string act = "state changed from:" + oProfile_Address_State + "To:" + state;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_city, city) != 0)
        { string act = "city changed from:" + oProfile_Address_city + "To:" + city;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Address_Postcode, pincode) != 0)
        { string act = "pincode changed from:" + oProfile_Address_Postcode + "To:" + pincode;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }

        if (String.Compare(oProfile_Address_Country, acountry) != 0)
        {
            string act = "Address Country changed from:" + oProfile_Address_Country + "To:" + acountry;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oProfile_Employment_status, employmentstatus) != 0)
        { string act = "employment status changed from:" + oProfile_Employment_status + "To:" + employmentstatus;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Marital_status, maritalstatus) != 0)
        { string act = "marital status changed from:" + oProfile_Marital_status + "To:" + maritalstatus;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_NOY_Living_as_couple, livingyrs) != 0)
        { string act = "livingyrs changed from:" + oProfile_NOY_Living_as_couple + "To:" + livingyrs;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oComments, ProfileComments) != 0)
        {
            string act = "comments changed from:" + oComments + "To:" + ProfileComments;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oProfile_Stay_Resort_Name, resort) != 0)
        { string act = "resort changed from:" + oProfile_Stay_Resort_Name + "To:" + resort;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Stay_Resort_Room_Number, roomno) != 0)
        { string act = "roomno changed from:" + oProfile_Stay_Resort_Room_Number + "To:" + roomno;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Stay_Arrival_Date, arrivaldate) != 0)
        { string act = "arrival date changed from:" + oProfile_Stay_Arrival_Date + "To:" + arrivaldate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oProfile_Stay_Departure_Date, departuredate) != 0)
        { string act = "departure date changed from:" + oProfile_Stay_Departure_Date + "To:" + departuredate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Guest_Status, gueststatus) != 0)
        { string act = "guest status changed from:" + oTour_Details_Guest_Status + "To:" + gueststatus;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Guest_Sales_Rep, salesrep) != 0)

        { string act = "salesrep changed from:" + oTour_Details_Guest_Sales_Rep + "To:" + salesrep;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Sales_Deck_Check_In, timeIn) != 0)
        {
            string act = "time In changed from:" + oTour_Details_Sales_Deck_Check_In + "To:" + timeIn;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oTour_Details_Sales_Deck_Check_Out, timeOut) != 0)
        { string act = "time Out changed from:" + oTour_Details_Sales_Deck_Check_Out + "To:" + timeOut;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Tour_Date, tourdate) != 0)
        { string act = "tour date changed from:" + oTour_Details_Tour_Date + "To:" + tourdate;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(tourweekno, wkno.ToString()) != 0)
        {
            string act = "Week number changed from:" + tourweekno + "To:" + wkno.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Taxi_In_Price, taxin) != 0)
        { string act = "taxi in price changed from:" + oTour_Details_Taxi_In_Price + "To:" + taxin;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Taxi_In_Ref, taxirefin) != 0)
        { string act = "taxi reference in changed from:" + oTour_Details_Taxi_In_Ref + "To:" + taxirefin;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }
        if (String.Compare(oTour_Details_Taxi_Out_Price, taxiout) != 0)
        { string act = "taxi outprice changed from:" + oTour_Details_Taxi_Out_Price + "To:" + taxiout;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oTour_Details_Taxi_Out_Ref, taxirefout) != 0)
        { string act = "taxi reference out changed from:" + oTour_Details_Taxi_Out_Ref + "To:" + taxirefout;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        } else { }

        if (String.Compare(oregTerms, regTerms) != 0)
        {
            string act = "Registration Terms changed from:" + oregTerms + "To:" + regTerms;
            int insertlog1 = Queries.InsertContractLogs_India(ProfileIDTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        //update profile
        int updateprofile = Queries.UpdateProfile(profile, venuecountry, venue, venuegroup,  mktg,  agents,  agentcode, membertype1, memno1,  membertype2, memno2,  employmentstatus, maritalstatus, livingyrs,mgr,photoidentity,card,ProfileComments,"","",regTerms,viewPointID);
        int primary = Queries.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, primarydob, primarynationality, primarycountry,npage,npdesg,primarylanguage);

        if (secondarytitle=="")
        {

        }else
        {
            int secondary = Queries.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, nsage, nsdesg, secondarylanguage);
        }

        if (sp1title == "")
        {

        }else
        {
            int sp1 = Queries.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, nsp1age);
        }

        if (sp2title=="")
        {

        }
        else
        {
            int sp2 = Queries.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, nsp2age);
        }

        if (sp3title=="")
        {

        }else
        {
            int sp3 = Queries.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, nsp3age);
        }

        if (sp4title=="")
        {

        }else
        {
            int sp4 = Queries.UpdateSubProfile4(profile, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, nsp4age);
        }
       
       
        int address = Queries.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);
        int phone = Queries.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3cc, sp3mobile, sp3altccc, sp3alternate, sp4cc, sp4mobile, sp4altccc, sp4alternate,priOfficecc,priOfficeno,secOfficecc,secOfficeno);
        int email = Queries.UpdateEmail(profile, pemail, semail, sp1email, sp2email,"","","","",sp3email,"",sp4email,"");
        int stay = Queries.UpdateProfileStay(profile, resort, roomno, arrivaldate, departuredate);
        int tour = Queries.UpdateTourDetails(profile, gueststatus, salesrep, tourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout,"",wkno);

        string msg = "Details updated for Profile :" + " " + profile;
        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
    }



    [WebMethod]
    public static string getVenueOnCountry(string countryName)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = " select venue.Venue_Name,venue.Venue_ID from venue where Venue_Country_ID in(select Venue_Country_ID from VenueCountry where Venue_Country_Name = '" + countryName + "')";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
      
        sqlcon.Close();
        return JSON;
    }


    [WebMethod]
    public static string getVenueGroupOnVenue(string venue)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select vg.Venue_Group_ID,vg.Venue_Group_Name from Venue_Group vg where vg.Venue_ID in(select venue.Venue_ID from venue where venue.Venue_Name ='"+venue+"')";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(1);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
 
        sqlcon.Close();
        return JSON;
    }


    [WebMethod]
    public static string getdata(string prid)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        //string query = "SELECT Primary_Language FROM Profile_Primary WHERE Profile_ID ='"+ '""
     //   SqlCommand sql = new SqlCommand(query, sqlcon);

        //SqlDataReader reader = sql.ExecuteReader();
        SqlDataReader reader = Queries.LoadPrimaryLang(prid);
        while (reader.Read())
        {
            string name = reader.GetString(0);

            string[] arr = name.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {

                JSON += "[\"" + arr[i] + "\"],";
            }
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
   
        sqlcon.Close();
        return JSON;
    }

    [WebMethod]
    public static string Secondarylang(string prid)
    {
     
        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadSecLang(prid);
        if (reader.HasRows)
        {

      
        while (reader.Read())
        {
            string name = reader.GetString(0);
           
              
                string[] arr = name.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {

                    JSON += "[\"" + arr[i] + "\"],";
                }
           
        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
        
            JSON += "[\""+ "[]"+ "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
    

        return JSON;
    }


    [WebMethod]
    public static string PhotoIdentity(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadPhotoID(prid);
        if (reader.HasRows)
        {


            while (reader.Read())
            {
                string name = reader.GetString(0);

                string[] arr = name.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {

                    JSON += "[\"" + arr[i] + "\"],";
                }
            }

            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        } else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }

        return JSON;
    }
    [WebMethod]
    public static string CardType(string prid)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadCardType(prid);
        if (reader.HasRows)
        {

       
        while (reader.Read())
        {
            string name = reader.GetString(0);

            string[] arr = name.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {

                JSON += "[\"" + arr[i] + "\"],";
            }
        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      

        return JSON;
    }


    [WebMethod]
    public static string getMarketingProgram(string venue,string venueGroup,string profileID)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select distinct Marketing_Program_Name from Marketing_Program join Venue_Group vg on vg.Venue_group_ID=Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID= vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID ='"+ profileID + "' ) and vg.Venue_Group_Name='"+ venueGroup + "' and v.Venue_Name= '"+venue+"'";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            JSON += "[\"" + name + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }


    [WebMethod]
    public static string LoadManagersOnVenue(string venue)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadManagersOnVenue1(venue);
        while (reader.Read())
        {
            string mn = reader.GetString(0);

            JSON += "[\"" + mn + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;
    }


    [WebMethod]
    public static string LoadAgentsOnVenuegrp(string venue, string vgrp)
    {

        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline")
        {
            SqlDataReader reader = Queries.LoadAgentsOnVenue1(venue);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            SqlDataReader reader = Queries.GetSalesRepOnlyVenue(venue);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        return JSON;
    }


    [WebMethod]
    public static string LoadTOOnVenueNVGrp(string venue, string vgrp)
    {

        string JSON = "{\n \"names\":[";

        if (vgrp == "Coldline")
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenue1(venue);
            while (reader.Read())
            {
                string tom = reader.GetString(0);

                JSON += "[\"" + tom + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

            return JSON;
        }
        else
        {
            SqlDataReader reader = Queries.LoadTOOPCOnVenueNGrp(venue);
            while (reader.Read())
            {
                string tom = reader.GetString(0);

                JSON += "[\"" + tom + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

            return JSON;

        }
    }

    [WebMethod]
    public static string LoadSalutations()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Salutation from Salutations where status='active' order by 1;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string salutations = reader.GetString(0);



            JSON += "[\"" + salutations + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;





    }


    [WebMethod]
    public static string LoadNationality()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct  nationality_name from nationality order by 1;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string nationality = reader.GetString(0);



            JSON += "[\"" + nationality + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static string LoadCountry()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct country_name   from country order by 1;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string country = reader.GetString(0);



            JSON += "[\"" + country + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }
    [WebMethod]
    public static string LoadCountryCode(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "  select Country_Code from Country  where country_name ='"+country+"' union all select Country_Code from Country  where country_name !='"+country+"' ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string countryCode = reader.GetString(0);



            JSON += "[\"" + countryCode + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadAllCountryCode(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='"+country+"' union all select Country_Code from Country  where country_name !='"+country+"';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string countryCode = reader.GetString(0);



            JSON += "[\"" + countryCode + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string LoadSubProfile3Data()
    {
       
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select sub3.Sub_Profile3_Title,sub3.Sub_Profile3_Fname,sub3.Sub_Profile3_Lname,sub3.Sub_Profile3_DOB,sub3.Sub_Profile3_Nationality,sub3.Sub_Profile3_Country,sub3.Sub_Profile3_Age from  Sub_Profile3 sub3 where Profile_ID='"+profile_ID+"';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            
        while (reader.Read())
        {

            string title = reader.GetString(0);
            string fname = reader.GetString(1);
            string lname = reader.GetString(2);
            string dob = Convert.ToDateTime(reader["Sub_Profile3_DOB"]).ToString("dd-MM-yyyy");
            string nationality = reader.GetString(4);
            string country = reader.GetString(5);
            int age = reader.GetInt32(6);


            JSON += "[\"" + title + "\",\"" + fname + "\",\"" + lname + "\",\"" + dob + "\",\"" + nationality + "\",\"" + country + "\",\"" + age + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
     
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadSubProfile3n4PhoneData()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Subprofile1_CC,Subprofile1_Mobile,Subprofile1_Alt_CC,Subprofile1_Alternate,Subprofile2_CC,Subprofile2_Mobile,Subprofile2_Alt_CC,Subprofile2_Alternate, Subprofile3_CC,Subprofile3_Mobile,Subprofile3_Alt_CC,Subprofile3_Alternate,Subprofile4_CC,Subprofile4_Mobile,Subprofile4_Alt_CC,Subprofile4_Alternate,Primary_CC,Primary_Mobile,Primary_Alt_CC,Primary_Alternate,Secondary_CC,Secondary_Mobile,Secondary_Alt_CC,Secondary_Alternate,Primary_office_cc,Primary_office_num,Secondary_office_cc,Secondary_office_num from phone where Profile_ID='" + profile_ID+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

       
        while (reader.Read())
        {

            string sub1pricc = reader.GetString(0);
            string sub1prino = reader.GetString(1);

            string sub1altcc = reader.GetString(2);
            string sub1altno = reader.GetString(3);


            string sub2pricc = reader.GetString(4);
            string sub2prino = reader.GetString(5);

            string sub2altcc = reader.GetString(6);
            string sub2altno = reader.GetString(7);


            string sub3pricc = reader.GetString(8);
            string sub3prino = reader.GetString(9);

            string sub3altcc = reader.GetString(10);
            string sub3altno = reader.GetString(11);


            string sub4pricc = reader.GetString(12);
            string sub4prino = reader.GetString(13);

            string sub4altcc = reader.GetString(14);
            string sub4altno = reader.GetString(15);

            string pricc = reader.GetString(16);
            string prino = reader.GetString(17);

            string prialtcc = reader.GetString(18);
            string prialtno = reader.GetString(19);


            string seccc = reader.GetString(20);
            string secno = reader.GetString(21);

            string secaltcc = reader.GetString(22);
            string secaltno = reader.GetString(23);

            string priOfficecc = reader.GetString(24);
            string priOfficeno = reader.GetString(25);

            string secOfficecc = reader.GetString(26);
            string secOfficeno = reader.GetString(27);





            JSON += "[\"" + sub1pricc + "\",\"" + sub1prino + "\",\"" + sub1altcc + "\",\"" + sub1altno + "\",\"" + sub2pricc + "\",\"" + sub2prino + "\",\"" + sub2altcc + "\",\"" + sub2altno + "\",\"" + sub3pricc + "\",\"" + sub3prino + "\",\"" + sub3altcc + "\",\"" + sub3altno + "\",\"" + sub4pricc + "\",\"" + sub4prino + "\",\"" + sub4altcc + "\",\"" + sub4altno + "\",\"" + pricc + "\",\"" + prino + "\",\"" + prialtcc + "\",\"" + prialtno + "\",\"" + seccc + "\",\"" + secno + "\",\"" + secaltcc + "\",\"" + secaltno + "\",\"" + priOfficecc + "\",\"" + priOfficeno + "\",\"" + secOfficecc + "\",\"" + secOfficeno + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static string LoadEmail()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select e.Primary_Email,e.Secondary_Email,e.Subprofile1_Email,e.Subprofile2_Email,e.Subprofile3_Email,e.Subprofile4_Email from Email e where Profile_ID='"+profile_ID+"';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

      
        while (reader.Read())
        {

            string priEmail = reader.GetString(0);
            string secEmail = reader.GetString(1);
            string sub1Email = reader.GetString(2);
            string sub2Email = reader.GetString(3);
            string sub3Email = reader.GetString(4);
            string sub4Email = reader.GetString(5);



            JSON += "[\"" + priEmail + "\",\"" + secEmail + "\",\"" + sub1Email + "\",\"" + sub2Email + "\",\"" + sub3Email + "\",\"" + sub4Email + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
    
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string LoadSubProfile4Data()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select sub4.Sub_Profile4_Title,sub4.Sub_Profile4_Fname,sub4.Sub_Profile4_Lname,sub4.Sub_Profile4_DOB,sub4.Sub_Profile4_Nationality,sub4.Sub_Profile4_Country,sub4.Sub_Profile4_Age from  Sub_Profile4 sub4 where Profile_ID='"+profile_ID+"';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            
            while (reader.Read())
            {

                string title = reader.GetString(0);
                string fname = reader.GetString(1);
                string lname = reader.GetString(2);
                string dob = Convert.ToDateTime(reader["Sub_Profile4_DOB"]).ToString("dd-MM-yyyy");
                string nationality = reader.GetString(4);
                string country = reader.GetString(5);
                int age = reader.GetInt32(6);


                JSON += "[\"" + title + "\",\"" + fname + "\",\"" + lname + "\",\"" + dob + "\",\"" + nationality + "\",\"" + country + "\",\"" + age + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadSubProfile1Data()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        string query = " select sub1.Sub_Profile1_Title,sub1.Sub_Profile1_Fname,sub1.Sub_Profile1_Lname,sub1.Sub_Profile1_DOB,sub1.Sub_Profile1_Nationality,sub1.Sub_Profile1_Country,sub1.Sub_Profile1_Age from  Sub_Profile1 sub1 where Profile_ID='"+profile_ID+"';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string title = reader.GetString(0);
                string fname = reader.GetString(1);
                string lname = reader.GetString(2);
                string dob = Convert.ToDateTime(reader["Sub_Profile1_DOB"]).ToString("dd-MM-yyyy");
                string nationality = reader.GetString(4);
                string country = reader.GetString(5);
                string age = reader.GetString(6);


                JSON += "[\"" + title + "\",\"" + fname + "\",\"" + lname + "\",\"" + dob + "\",\"" + nationality + "\",\"" + country + "\",\"" + age + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadSubProfile2Data()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select sub2.Sub_Profile2_Title,sub2.Sub_Profile2_Fname,sub2.Sub_Profile2_Lname,sub2.Sub_Profile2_DOB,sub2.Sub_Profile2_Nationality,sub2.Sub_Profile2_Country,sub2.Sub_Profile2_Age from  Sub_Profile2 sub2 where Profile_ID='" + profile_ID + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            
            while (reader.Read())
            {

                string title = reader.GetString(0);
                string fname = reader.GetString(1);
                string lname = reader.GetString(2);
                string dob = Convert.ToDateTime(reader["Sub_Profile2_DOB"]).ToString("dd-MM-yyyy");
                string nationality = reader.GetString(4);
                string country = reader.GetString(5);
                string age = reader.GetString(6);


                JSON += "[\"" + title + "\",\"" + fname + "\",\"" + lname + "\",\"" + dob + "\",\"" + nationality + "\",\"" + country + "\",\"" + age + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadStates(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select s.State_Name from state s join Country c on s.State_Country=c.Country_Name where c.Country_Name='" + country + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

      
        while (reader.Read())
        {

            string stateName = reader.GetString(0);



            JSON += "[\"" + stateName + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;





    }



    [WebMethod]
    public static string LoadAddress()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Profile_Address_Line1,Profile_Address_Line2,Profile_Address_State,Profile_Address_city,Profile_Address_Postcode,Profile_Address_Country from Profile_Address where Profile_ID='"+profile_ID+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

       
        while (reader.Read())
        {

            string addressLine1 = reader.GetString(0);
            string addressLine2 = reader.GetString(1);
            string state = reader.GetString(2);
            string city = reader.GetString(3);
            string postCode = reader.GetString(4);
            string country = reader.GetString(5);


            JSON += "[\"" + addressLine1 + "\",\"" + addressLine2 + "\",\"" + state + "\",\"" + city + "\",\"" + postCode + "\",\"" + country + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;





    }



    [WebMethod]
    public static string loadEmployment()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Name  from EmploymentStatus  where  Status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string name = reader.GetString(0);



            JSON += "[\"" + name + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;





    }

    [WebMethod]
    public static string loadMartial()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select MaritalStatus  from MaritalStatus  where  Status='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

    
        while (reader.Read())
        {

            string name = reader.GetString(0);



            JSON += "[\"" + name + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {

            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;





    }



    [WebMethod]
    public static string LoadOtherDetails()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select p.Profile_Employment_status,p.Profile_Marital_status,p.Profile_NOY_Living_as_couple,p.Photo_identity,p.Card_Holder, pp.Primary_Designation,ps.Secondary_Designation from profile p join Profile_Primary pp on p.Profile_ID = pp.Profile_ID join Profile_Secondary ps on p.Profile_ID = ps.Profile_ID where p.Profile_ID = '"+profile_ID+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string employment = reader.GetString(0);
                string martial = reader.GetString(1);
                string no_of_living = reader.GetString(2);
                string photo_identity = reader.GetString(3);
                string card_holder = reader.GetString(4);
                string priDesg = reader.GetString(5);
                string secDesg = reader.GetString(6);




                JSON += "[\"" + employment + "\",\"" + martial + "\",\"" + no_of_living + "\",\"" + photo_identity + "\",\"" + card_holder + "\",\"" + priDesg + "\",\"" + secDesg + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;





    }

    [WebMethod]
    public static string LoadSalesRepOnVenue(string venue, string country)
    {



        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.GetSalesRepOnVenue(venue, country);
        while (reader.Read())
        {
            string sr = reader.GetString(0);

            JSON += "[\"" + sr + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
      
        return JSON;

    }


    [WebMethod]
    public static string LoadGuest()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Guest_Status_name  from Guest_Status where Guest_Status_Status ='Active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string name = reader.GetString(0);



            JSON += "[\"" + name + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;





    }


    [WebMethod]
    public static string LoadStayDetails()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select ps.Profile_Stay_Resort_Name,ps.Profile_Stay_Resort_Room_Number,ps.Profile_Stay_Arrival_Date,ps.Profile_Stay_Departure_Date,td.Tour_Details_Guest_Sales_Rep,td.Tour_Details_Guest_Status,td.Tour_Details_Tour_Date,td.Tour_Details_Sales_Deck_Check_In,td.Tour_Details_Sales_Deck_Check_Out,td.Tour_Details_Taxi_In_Price,td.Tour_Details_Taxi_In_Ref,td.Tour_Details_Taxi_Out_Price,td.Tour_Details_Taxi_Out_Ref,p.Comments  from Profile_Stay ps join Tour_Details td on ps.Profile_ID = td.Profile_ID join profile p on ps.Profile_ID=p.Profile_ID where ps.Profile_ID = '" + profile_ID+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {


            while (reader.Read())
            {

                string resort = reader.GetString(0);
                string resortNo = reader.GetString(1);
                string arrival = Convert.ToDateTime(reader["Profile_Stay_Arrival_Date"]).ToString("dd-MM-yyyy");
                string depature = Convert.ToDateTime(reader["Profile_Stay_Departure_Date"]).ToString("dd-MM-yyyy");
                string salesRep = reader.GetString(4);
                string guestStatus = reader.GetString(5);
                string tourdate = Convert.ToDateTime(reader["Tour_Details_Tour_Date"]).ToString("dd-MM-yyyy");
                string checkin = reader["Tour_Details_Sales_Deck_Check_In"].ToString();
                string checkout = reader["Tour_Details_Sales_Deck_Check_Out"].ToString();
                decimal taxi_in_price = reader.GetDecimal(9);
                string taxi_in_ref = reader.GetString(10);
                decimal taxi_out_price = reader.GetDecimal(11);
                string taxi_out_ref = reader.GetString(12);
                string comments = reader.GetString(13);

                JSON += "[\"" + resort + "\",\"" + resortNo + "\",\"" + arrival + "\",\"" + depature + "\",\"" + salesRep + "\",\"" + guestStatus + "\",\"" + tourdate + "\",\"" + checkin + "\",\"" + checkout + "\",\"" + taxi_in_price + "\",\"" + taxi_in_ref + "\",\"" + taxi_out_price + "\",\"" + taxi_out_ref + "\",\"" + comments + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;





    }



    [WebMethod]
    public static string LoadSecondaryData()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select ps.Profile_Secondary_Title,ps.Profile_Secondary_Fname,ps.Profile_Secondary_Lname,ps.Profile_Secondary_DOB,ps.Profile_Secondary_Nationality,ps.Profile_Secondary_Country,ps.Secondary_Age,ps.Secondary_Designation,ps.Secondary_Language from Profile_Secondary ps where Profile_ID='"+profile_ID+"';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {


            while (reader.Read())
            {

                string title = reader.GetString(0);
                string fname = reader.GetString(1);
                string lname = reader.GetString(2);
                string dob = Convert.ToDateTime(reader["Profile_Secondary_DOB"]).ToString("dd-MM-yyyy");
                string nationality = reader.GetString(4);
                string country = reader.GetString(5);
                string age = reader.GetString(6);



                JSON += "[\"" + title + "\",\"" + fname + "\",\"" + lname + "\",\"" + dob + "\",\"" + nationality + "\",\"" + country + "\",\"" + age + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static string LoadPrimaryData()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select pp.Profile_Primary_Title,pp.Profile_Primary_Fname,pp.Profile_Primary_Lname,pp.Profile_Primary_DOB,pp.Profile_Primary_Nationality,pp.Profile_Primary_Country,pp.Primary_Age from Profile_Primary pp where Profile_ID='"+profile_ID+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {


            while (reader.Read())
            {

                string title = reader.GetString(0);
                string fname = reader.GetString(1);
                string lname = reader.GetString(2);
                string dob = Convert.ToDateTime(reader["Profile_Primary_DOB"]).ToString("dd-MM-yyyy");
                string nationality = reader.GetString(4);
                string country = reader.GetString(5);
                string age = reader.GetString(6);



                JSON += "[\"" + title + "\",\"" + fname + "\",\"" + lname + "\",\"" + dob + "\",\"" + nationality + "\",\"" + country + "\",\"" + age + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadTypes()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Type_Name from Type;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {


            while (reader.Read())
            {

                string Type = reader.GetString(0);



                JSON += "[\"" + Type + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
    
        sqlcon.Close();
        return JSON;





    }

    [WebMethod]
    public static string Loadtype()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Profile_Member_Number1 from profile where Profile_ID='"+profile_ID+"';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string Type = reader.GetString(0);



                JSON += "[\"" + Type + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
  
        sqlcon.Close();
        return JSON;





    }


    [WebMethod]
    public static string loadMarketingProgram(string venue, string venueGroup)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct Marketing_Program_Name   from Marketing_Program join Venue_Group vg on vg.Venue_group_ID = Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID ='" + profile_ID + "') and vg.Venue_Group_Name ='" + venueGroup + "' and v.Venue_Name ='" + venue + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string marktg = reader.GetString(0);



            JSON += "[\"" + marktg + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;





    }

    [WebMethod]
    public static string loadMarketingProgram1(string venue, string venueGroup)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select distinct Marketing_Program_Name from Marketing_Program join Venue_Group vg on vg.Venue_group_ID = Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID = vg.Venue_ID where Marketing_Program_Status = 'active'  and vg.Venue_Group_Name = '"+venueGroup+"' and v.Venue_Name = '"+ venue + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string marktg = reader.GetString(0);



            JSON += "[\"" + marktg + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;





    }

    [WebMethod]
    public static string loadProfile()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select p.Profile_Marketing_Program,p.Profile_Agent,p.Profile_Agent_Code,p.Manager from profile p where Profile_ID='"+profile_ID+"'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

        
        while (reader.Read())
        {

            string marktg = reader.GetString(0);
            string agent = reader.GetString(1);
            string toName = reader.GetString(2);
            string manager = reader.GetString(3);



            JSON += "[\"" + marktg + "\",\"" + agent + "\",\"" + toName + "\",\"" + manager + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;





    }




    [WebMethod]
    public static string LoadStates1()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select s.State_Name from state s  where State_Status='active'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string stateName = reader.GetString(0);



                JSON += "[\"" + stateName + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
     
        sqlcon.Close();
        return JSON;





    }


    [WebMethod]
    public static string LoadAllCountryCodePri(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string countryCode = reader.GetString(0);



                JSON += "[\"" + countryCode + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";

            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadCountryCodePri(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string countryCode = reader.GetString(0);



                JSON += "[\"" + countryCode + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
   
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static string LoadAllCountryCodeSec(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string countryCode = reader.GetString(0);



                JSON += "[\"" + countryCode + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadCountryCodeSec(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

      
        while (reader.Read())
        {

            string countryCode = reader.GetString(0);



            JSON += "[\"" + countryCode + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
     
        sqlcon.Close();
        return JSON;



    }


    [WebMethod]
    public static string LoadAllCountryCodeSub1(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string countryCode = reader.GetString(0);



                JSON += "[\"" + countryCode + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
     
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadCountryCodeSub1(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {


            while (reader.Read())
            {

                string countryCode = reader.GetString(0);



                JSON += "[\"" + countryCode + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        JSON += "[\"" + "[]" + "\"],";
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
        sqlcon.Close();
        return JSON;



    }



    [WebMethod]
    public static string LoadAllCountryCodeSub2(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

      
        while (reader.Read())
        {

            string countryCode = reader.GetString(0);



            JSON += "[\"" + countryCode + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadCountryCodeSub2(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

       
        while (reader.Read())
        {

            string countryCode = reader.GetString(0);



            JSON += "[\"" + countryCode + "\"],";


        }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";

            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
     
        sqlcon.Close();
        return JSON;



    }




    [WebMethod]
    public static string LoadAllCountryCodeSub3(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string countryCode = reader.GetString(0);



                JSON += "[\"" + countryCode + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadCountryCodeSub3(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string countryCode = reader.GetString(0);



                JSON += "[\"" + countryCode + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;



    }




    [WebMethod]
    public static string LoadAllCountryCodeSub4(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                string countryCode = reader.GetString(0);



                JSON += "[\"" + countryCode + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";

            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string LoadCountryCodeSub4(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' ;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string countryCode = reader.GetString(0);



                JSON += "[\"" + countryCode + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {

            JSON += "[\"" + "[]" + "\"],";

            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        sqlcon.Close();
        return JSON;



    }

    [WebMethod]
    public static string loadRegTerms()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select RegTerms from profile p where Profile_ID='"+profile_ID+"';";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string RegTerms = reader.GetString(0);



                JSON += "[\"" + RegTerms + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "[]" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        
        sqlcon.Close();
        return JSON;



    }

}