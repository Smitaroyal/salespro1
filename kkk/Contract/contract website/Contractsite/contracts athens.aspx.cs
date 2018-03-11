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
    static string officeo,user;
    static string ProfileIDo;
    static string contFinance;
    static string purchaseservice;
    private string Values;
    static string venuecountryG, venueG, markG;


    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = DateTime.Today.ToString("yyyy/MM/dd");

        string user1 = (string)Session["username"];
        //TextBox tb = new TextBox();
        user = user1;
        //user = "athensuser";

        //string ProfileID = "IVO20178";
        string ProfileID = Convert.ToString(Request.QueryString["Profile_ID"]);
        ProfileIDo = ProfileID;

        string ContType = DropDownList40.SelectedItem.Text;
        //string Venue_country =Convert.ToString(Request.Q)
        if (!Page.IsPostBack)
        {


            DataSet ds4 = Queries2.LoadProfileOnCreation(ProfileID);
            ProfileIDTextBox.Text = ds4.Tables[0].Rows[0]["Profile_ID"].ToString();
            TextBox1.Text = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Date_Of_Insertion"]).ToString("yyyy-MM-dd");
            primarytitleDropDownList.DataSource = ds4;
            primarytitleDropDownList.DataTextField = "Profile_Primary_Title";
            primarytitleDropDownList.DataValueField = "Profile_Primary_Title";
            primarytitleDropDownList.DataBind();
            pfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();

            primarynationalityDropDownList.DataSource = ds4;
            primarynationalityDropDownList.DataTextField = "Profile_Primary_Nationality";
            primarynationalityDropDownList.DataValueField = "Profile_Primary_Nationality";
            primarynationalityDropDownList.DataBind();


            PrimaryCountryDropDownList.Items.Clear();
            DataSet ds28 = Queries2.LoadCountryName();
           
            PrimaryCountryDropDownList.DataSource = ds28;
            PrimaryCountryDropDownList.DataTextField = "country_name";
            PrimaryCountryDropDownList.DataValueField = "country_name";
            PrimaryCountryDropDownList.AppendDataBoundItems = true;
            PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            PrimaryCountryDropDownList.DataBind();


            string vencountry = Queries2.GetVenueCountryCode(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString());
            VenueCountryDropDownList.Items.Clear();
            DataSet ds8 = Queries2.LoadVenueCountry1(ProfileID);

            VenueCountryDropDownList.DataSource = ds8;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
            VenueCountryDropDownList.DataBind();

            VenueDropDownList.Items.Clear();
            DataSet ds24 = Queries.LoadVenuebasedOnCountryID(vencountry);
            VenueDropDownList.DataSource = ds24; 
            VenueDropDownList.DataTextField = "Venue_Name";
            VenueDropDownList.DataValueField = "Venue_Name";
            VenueDropDownList.AppendDataBoundItems = true;
            VenueDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
            VenueDropDownList.DataBind();

            string venuecode = Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, vencountry);

            GroupVenueDropDownList.Items.Clear();
            DataSet ds25 = Queries.LoadVenueGroup(venuecode);
            GroupVenueDropDownList.DataSource = ds25;
            GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
            GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
            GroupVenueDropDownList.AppendDataBoundItems = true;
            GroupVenueDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
            GroupVenueDropDownList.DataBind();

            string Groupvenuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);

            MarketingPrgmDropDownList.Items.Clear();
            DataSet ds26 = Queries.LoadMarketingProgram(Groupvenuecode);
            MarketingPrgmDropDownList.DataSource = ds26;
            MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            MarketingPrgmDropDownList.AppendDataBoundItems = true;
            MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            MarketingPrgmDropDownList.DataBind();

            string MarketingPCode = Queries2.getMarketingProgram(MarketingPrgmDropDownList.SelectedItem.Text, Groupvenuecode);
            MarketingPrgmDropDownList.Items.Clear();
            MarketingPrgmDropDownList.DataSource = ds26;
            MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
            MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
            MarketingPrgmDropDownList.AppendDataBoundItems = true;
            MarketingPrgmDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
            MarketingPrgmDropDownList.DataBind();

            AgentsDropDownList.Items.Clear();
            DataSet ds27 = Queries2.LoadAgentsIVO(MarketingPrgmDropDownList.SelectedItem.Text);
            AgentsDropDownList.DataSource = ds27;
            AgentsDropDownList.DataTextField = "Agent_Name";
            AgentsDropDownList.DataValueField = "Agent_Name";
            AgentsDropDownList.AppendDataBoundItems = true;
            AgentsDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
            AgentsDropDownList.DataBind();

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
            DataSet ds7 = Queries2.LoadSalesReps(vencountry,"");
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

            string datear = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd"); ; 
            // datepicker5.Text = DateTime.datear.ToString();
            // datepicker5.Text
            //Response.Write(datear);
            //DateTime dae = DateTime.ParseExact(datear, "yyyy/MM/dd", null);
            datepicker5.Text = datear;

            AgentCodeDropDownList.Items.Clear();
            DataSet ds29 = Queries.LoadProfileAgentCode(ProfileID);
            AgentCodeDropDownList.DataSource = ds29;
            AgentCodeDropDownList.DataTextField = "Agent_Code_Name";
            AgentCodeDropDownList.DataValueField = "Agent_Code_Name";
            AgentCodeDropDownList.AppendDataBoundItems = true;
            AgentCodeDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            AgentCodeDropDownList.DataBind();

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

            employmentstatusDropDownList.Items.Clear();
            employmentstatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Employment_status"].ToString());
            employmentstatusDropDownList.Items.Add("Employee");
            employmentstatusDropDownList.Items.Add("Worker");
            employmentstatusDropDownList.Items.Add("Self Employed");
            employmentstatusDropDownList.Items.Add("Director");
            employmentstatusDropDownList.Items.Add("Office Holder");
            employmentstatusDropDownList.Items.Add("Unemployed");

            MaritalStatusDropDownList.Items.Clear();
            MaritalStatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Marital_status"].ToString());
            MaritalStatusDropDownList.Items.Add("Single");
            MaritalStatusDropDownList.Items.Add("Married");
            MaritalStatusDropDownList.Items.Add("Divorced");
            MaritalStatusDropDownList.Items.Add("Just Friend");
            MaritalStatusDropDownList.Items.Add("Female Couple");
            MaritalStatusDropDownList.Items.Add("Male Couple");
            MaritalStatusDropDownList.Items.Add("Living Together as couple");

            livingyrsTextBox.Text = ds4.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();

            primarytitleDropDownList.Items.Clear();
            primarytitleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Primary_Title"].ToString());
            primarytitleDropDownList.Items.Add("Mr");
            primarytitleDropDownList.Items.Add("Ms");
            primarytitleDropDownList.Items.Add("Mrs");
            primarytitleDropDownList.Items.Add("Adv");
            primarytitleDropDownList.Items.Add("Dr");

            DataSet ds32 = Queries.LoadCountryPrimary(ProfileID);
            PrimaryCountryDropDownList.DataSource = ds32;
            PrimaryCountryDropDownList.DataTextField = "country_name";
            PrimaryCountryDropDownList.DataValueField = "country_name";
            PrimaryCountryDropDownList.AppendDataBoundItems = true;
            PrimaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            PrimaryCountryDropDownList.DataBind();
            DataSet ds33 = Queries.LoadCountryWithCodePrimaryMobile(ProfileID);
            primarymobileDropDownList.DataSource = ds33;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            primarymobileDropDownList.DataBind();
            DataSet ds34 = Queries.LoadCountryWithCodePrimaryAlt(ProfileID);
            primaryalternateDropDownList.DataSource = ds34;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            primaryalternateDropDownList.DataBind();

             pmobileTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Mobile"].ToString();
           palternateTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Alternate"].ToString();
            pemailTextBox.Text = ds4.Tables[0].Rows[0]["Primary_Email"].ToString();



            //secondary profile

            secondarytitleDropDownList.Items.Clear();
            secondarytitleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString());
            secondarytitleDropDownList.Items.Add("Mr");
            secondarytitleDropDownList.Items.Add("Ms");
            secondarytitleDropDownList.Items.Add("Mrs");
            secondarytitleDropDownList.Items.Add("Adv");
            secondarytitleDropDownList.Items.Add("Dr");



            sfnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            slnameTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            //

            string datep1 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Primary_DOB"]).ToString("yyyy-MM-dd");
            if (datep1 == " " || datep1 == "1900-01-01")
            {
                datepicker1.Text = "";
            }
            else
            {
                datepicker1.Text = datep1;
            }



            string datep2 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Secondary_DOB"]).ToString("yyyy-MM-dd");

            if (datep2 == " " || datep2== "1900-01-01")
            {
                datepicker2.Text = "";
            }
            else
            {
                datepicker2.Text = datep2;
            }
            secondarynationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString());
            DataSet ds35 = Queries.LoadCountrySecondary(ProfileID);
            SecondaryCountryDropDownList.DataSource = ds35;
            SecondaryCountryDropDownList.DataTextField = "country_name";
            SecondaryCountryDropDownList.DataValueField = "country_name";
            SecondaryCountryDropDownList.AppendDataBoundItems = true;
            SecondaryCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString(), ""));
            SecondaryCountryDropDownList.DataBind();
            DataSet ds36 = Queries.LoadCountryWithCodeSecondaryMobile(ProfileID);
            secondarymobileDropDownList.DataSource = ds36;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_CC"].ToString(), ""));
            secondarymobileDropDownList.DataBind();
            DataSet ds37 = Queries.LoadCountryWithCodeSecondaryAlt(ProfileID);
            secondaryalternateDropDownList.DataSource = ds37;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Secondary_Alt_CC"].ToString(), ""));
            secondaryalternateDropDownList.DataBind();

            smobileTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Mobile"].ToString();
            salternateTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Alternate"].ToString();
            semailTextBox.Text = ds4.Tables[0].Rows[0]["Secondary_Email"].ToString();

            //subprofile 1
            subprofile1titleDropDownList.Items.Clear();
            subprofile1titleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            subprofile1titleDropDownList.Items.Add("Mr");
            subprofile1titleDropDownList.Items.Add("Ms");
            subprofile1titleDropDownList.Items.Add("Mrs");
            subprofile1titleDropDownList.Items.Add("Adv");
            subprofile1titleDropDownList.Items.Add("Dr");



            //  subprofile1titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString());
            sp1fnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            //datepicker3.Text = ds4.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString();

            string datep3 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile1_DOB"]).ToString("yyyy-MM-dd");

            if (datep3 == " " || datep3 == "1900-01-01")
            {
                datepicker3.Text = "";
            }
            else
            {
                datepicker3.Text = datep3;
            }


            subprofile1nationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString());
            DataSet ds38 = Queries.LoadCountrySP1(ProfileID);
            SubProfile1CountryDropDownList.DataSource = ds38;
            SubProfile1CountryDropDownList.DataTextField = "country_name";
            SubProfile1CountryDropDownList.DataValueField = "country_name";
            SubProfile1CountryDropDownList.AppendDataBoundItems = true;
            SubProfile1CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            SubProfile1CountryDropDownList.DataBind();


            DataSet ds39 = Queries.LoadCountryWithCodeSP1Mobile(ProfileID);
            subprofile1mobileDropDownList.DataSource = ds39;
            subprofile1mobileDropDownList.DataTextField = "name";
            subprofile1mobileDropDownList.DataValueField = "name";
            subprofile1mobileDropDownList.AppendDataBoundItems = true;
            subprofile1mobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            subprofile1mobileDropDownList.DataBind();
            DataSet ds40 = Queries.LoadCountryWithCodeSP1Alt(ProfileID);
            subprofile1alternateDropDownList.DataSource = ds40;
            subprofile1alternateDropDownList.DataTextField = "name";
            subprofile1alternateDropDownList.DataValueField = "name";
            subprofile1alternateDropDownList.AppendDataBoundItems = true;
            subprofile1alternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            subprofile1alternateDropDownList.DataBind();


            sp1mobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();
            sp1alternateTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();
            sp1emailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile1_Email"].ToString();

            //subprofile2
            subprofile2titleDropDownList.Items.Clear();
            subprofile2titleDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            subprofile2titleDropDownList.Items.Add("Mr");
            subprofile2titleDropDownList.Items.Add("Ms");
            subprofile2titleDropDownList.Items.Add("Mrs");
            subprofile2titleDropDownList.Items.Add("Adv");
            subprofile2titleDropDownList.Items.Add("Dr");
            //  subprofile2titleDropDownList.Items.Add(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString());
            sp2fnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
           // datepicker4.Text = ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString();

            string datep4 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Sub_Profile2_DOB"]).ToString("yyyy-MM-dd");

            if (datep4 == " " || datep4 == "1900-01-01")
            {
                datepicker4.Text = "";
            }
            else
            {
                datepicker4.Text = datep4;
            }


            subprofile2nationalityDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString());

            DataSet ds41 = Queries.LoadCountrySP2(ProfileID);
            SubProfile2CountryDropDownList.DataSource = ds41;
            SubProfile2CountryDropDownList.DataTextField = "country_name";
            SubProfile2CountryDropDownList.DataValueField = "country_name";
            SubProfile2CountryDropDownList.AppendDataBoundItems = true;
            SubProfile2CountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            SubProfile2CountryDropDownList.DataBind();



            DataSet ds42 = Queries.LoadCountryWithCodeSP2Mobile(ProfileID);
            subprofile2mobileDropDownList.DataSource = ds42;
            subprofile2mobileDropDownList.DataTextField = "name";
            subprofile2mobileDropDownList.DataValueField = "name";
            subprofile2mobileDropDownList.AppendDataBoundItems = true;
            subprofile2mobileDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            subprofile2mobileDropDownList.DataBind();
            DataSet ds43 = Queries.LoadCountryWithCodeSP2Alt(ProfileID);
            subprofile2alternateDropDownList.DataSource = ds43;
            subprofile2alternateDropDownList.DataTextField = "name";
            subprofile2alternateDropDownList.DataValueField = "name";
            subprofile2alternateDropDownList.AppendDataBoundItems = true;
            subprofile2alternateDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            subprofile2alternateDropDownList.DataBind();


            sp2mobileTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();
            sp2alternateTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();
            sp2emailTextBox.Text = ds4.Tables[0].Rows[0]["Subprofile2_Email"].ToString();

            address1TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            address2TextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            stateTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            cityTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            pincodeTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();

            DataSet ds64 = Queries.LoadCountryName();
            AddCountryDropDownList.DataSource = ds64;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
            AddCountryDropDownList.DataBind();


            //stay details
            hotelTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            roomnoTextBox.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            datepicker5.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString();
            datepicker6.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString();

            string datep5 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToString("yyyy-MM-dd");

            if (datep5 == " " || datep5 == "1900-01-01")
            {
                datepicker5.Text = "";
            }
            else
            {
                datepicker5.Text = datep5;
            }


            string datep6 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToString("yyyy-MM-dd");

            if (datep6 == " " || datep6 == "1900-01-01")
            {
                datepicker6.Text = "";
            }
            else
            {
                datepicker6.Text = datep6;
            }


            //guest status

            gueststatusDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString());
            salesrepDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());
            contsalesrepDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString());
            deckcheckintimeTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            deckcheckouttimeTextBox.Text = ds4.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            //tourdatedatepicker.Text = ds4.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString();

            string datep7 = Convert.ToDateTime(ds4.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToString("yyyy-MM-dd");

            if (datep7 == " " || datep7 == "1900-01-01")
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


            //ContTypeTPDropDownList.Items.Add(ds4.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString());
            //ContTypeTPDropDownList.Items.FindByValue("hi").Selected = true;

            //string Profile_Office = ds.Tables[0].Rows[0]["Office"].ToString();
            // PrimaryMobileDropDownList
            /*  DataSet ds29 = Queries.LoadAgentsIVO(MarketingProgramDropDownList.SelectedItem.Text);
         AgentNameDropDownList.DataSource = ds27;
         AgentNameDropDownList.DataTextField = "Agent_Name";
         AgentNameDropDownList.DataValueField = "Agent_Name";
         AgentNameDropDownList.AppendDataBoundItems = true;
         AgentNameDropDownList.Items.Insert(0, new ListItem(ds4.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
         AgentNameDropDownList.DataBind();
         */

            // datepicker6.Text = ds4.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString();
            // Response.Write(@"<script language='javascript'>alert('The following errors have occurred: \n" + datear + " .');</script>");

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
            FinanceCurrencyDropDownList.Items.Insert(0, new ListItem("", ""));
            FinanceCurrencyDropDownList.DataBind();

            DataSet ds10 = Queries2.LoadDepositPayMethod(officeo);
            DPMFractDropDownList.DataSource = ds10;
            DPMFractDropDownList.DataTextField = "Deposit_pay_method_name";
            DPMFractDropDownList.DataValueField = "Deposit_pay_method_name";
            DPMFractDropDownList.AppendDataBoundItems = true;
            DPMFractDropDownList.Items.Insert(0, new ListItem("", ""));
            DPMFractDropDownList.DataBind();

            DataSet ds11 = Queries2.LoadDepositPayMethod(officeo);
            DPMPointsDropDownList.DataSource = ds11;
            DPMPointsDropDownList.DataTextField = "Deposit_pay_method_name";
            DPMPointsDropDownList.DataValueField = "Deposit_pay_method_name";
            DPMPointsDropDownList.AppendDataBoundItems = true;
            DPMPointsDropDownList.Items.Insert(0, new ListItem("", ""));
            DPMPointsDropDownList.DataBind();

            DataSet ds12 = Queries2.LoadDepositPayMethod(officeo);
            DPMTFractDropDownList.DataSource = ds12;
            DPMTFractDropDownList.DataTextField = "Deposit_pay_method_name";
            DPMTFractDropDownList.DataValueField = "Deposit_pay_method_name";
            DPMTFractDropDownList.AppendDataBoundItems = true;
            DPMTFractDropDownList.Items.Insert(0, new ListItem("", ""));
            DPMTFractDropDownList.DataBind();

            DataSet ds13 = Queries2.LoadDepositPayMethod(officeo);
            DPMTPointsDropDownList.DataSource = ds13;
            DPMTPointsDropDownList.DataTextField = "Deposit_pay_method_name";
            DPMTPointsDropDownList.DataValueField = "Deposit_pay_method_name";
            DPMTPointsDropDownList.AppendDataBoundItems = true;
            DPMTPointsDropDownList.Items.Insert(0, new ListItem("", ""));
            DPMTPointsDropDownList.DataBind();

            DataSet ds14 = Queries2.LoadDepositPayMethod(officeo);
            BPMDropDownList.DataSource = ds14;
            BPMDropDownList.DataTextField = "Deposit_pay_method_name";
            BPMDropDownList.DataValueField = "Deposit_pay_method_name";
            BPMDropDownList.AppendDataBoundItems = true;
            BPMDropDownList.Items.Insert(0, new ListItem("", ""));
            BPMDropDownList.DataBind();

            DataSet ds15 = Queries2.LoadDealDrawer();
            DealDrawerDropDownList.DataSource = ds15;
            DealDrawerDropDownList.DataTextField = "Deal_Drawer_Name";
            DealDrawerDropDownList.DataValueField = "Deal_Drawer_Name";
            DealDrawerDropDownList.AppendDataBoundItems = true;
            DealDrawerDropDownList.Items.Insert(0, new ListItem("", ""));
            DealDrawerDropDownList.DataBind();

            officeo = Queries2.getoffice(ProfileID);

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

            DataSet ds19 = Queries2.LoadTOManager(officeo,"");
            TOManagerDropDownList.DataSource = ds19;
            TOManagerDropDownList.DataTextField = "TO_Manager_name";
            TOManagerDropDownList.DataValueField = "TO_Manager_name";
            TOManagerDropDownList.AppendDataBoundItems = true;
            TOManagerDropDownList.Items.Insert(0, new ListItem("", ""));
            TOManagerDropDownList.DataBind();

            DataSet ds20 = Queries2.LoadButtonUp(officeo,"");
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


            DataSet ds47 = Queries2.LoadContResort();
            ResortTPDropDownList.DataSource = ds47;
            ResortTPDropDownList.DataTextField = "Contract_Resort_Name";
            ResortTPDropDownList.DataValueField = "Contract_Resort_Name";
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


            DataSet ds55 = Queries2.LoadContResort();
            ResortDropDownListTF1.DataSource = ds55;
            ResortDropDownListTF1.DataTextField = "Contract_Resort_Name";
            ResortDropDownListTF1.DataValueField = "Contract_Resort_Name";
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


            //load gift

            DataSet dsgift = Queries2.LoadGiftOption(officeo);
            GiftOptDropDownList.DataSource = dsgift;
            GiftOptDropDownList.DataTextField = "item";
            GiftOptDropDownList.DataValueField = "item";
            GiftOptDropDownList.DataBind();


            //string resortf = ResortDropDownListF.SelectedItem.Text;

            // string conttype = DropDownList40.SelectedItem.Text;

            // if (conttype == "Points")
            // {

            // string contnumid2 = Queries2.getContractID(officeo);
            // }
            // else if (conttype == "Fractional")
            // {
            //  string ContFracid = Queries2.getContFracID(officeo);
            // }
            //TextBox96.Text = contnumid;

            // string contfinaid = Queries2.getContractFinanceID(officeo);

            // string contPASAid = Queries2.getContractPASAID(officeo);
            TextBox96.Text = officeo;





        }
        //   string venuecountry = DropDownList1.SelectedItem.Text;

    }



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        contsalesrepDropDownList.Items.Clear();
        string venuecountry = Queries2.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text);

        DataSet ds7 = Queries2.LoadSalesReps(venuecountry,"");
        contsalesrepDropDownList.DataSource = ds7;
        contsalesrepDropDownList.DataTextField = "Sales_Rep_Name";
        contsalesrepDropDownList.DataValueField = "Sales_Rep_Name";
        contsalesrepDropDownList.AppendDataBoundItems = true;
        contsalesrepDropDownList.Items.Insert(0, new ListItem("", ""));
        contsalesrepDropDownList.DataBind();
    }

    //DealDrawerDropDownList
    




    public void Button1_Click(object sender, EventArgs e)
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
        string contnumid2 = null;
        string ContFracid2 = null; 
        // {
        string conttype = DropDownList40.SelectedItem.Text;

        if(conttype == "Points")
        {

            string contnumid = Queries2.getContractID(officeo);
            contnumid2 = contnumid;
        }
        else if (conttype == "Fractional")
        {
            string ContFracid = Queries2.getContFracID(officeo);
            ContFracid2 = ContFracid;
        }
        else if (conttype == "Trade Into Points")
        {
            string ContFracid = Queries2.getContTPID(officeo);
            ContFracid2 = ContFracid;
        }
        else if (conttype == "Trade Into Fractional")
        {
            string ContFracid = Queries2.getContTFID(officeo);
            ContFracid2 = ContFracid;
        }
        //TextBox96.Text = officeo;



        string contfinaid = Queries2.getContractFinanceID(officeo);
        string contPASAid = Queries2.getContractPASAID(officeo);
        contFinance = contfinaid;
        //string conttype = DropDownList40.SelectedItem.Text;


        

        string GenContNumb = TextContractNumb.Text;
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
            string BPaymethod = BPMDropDownList.SelectedItem.Text;
            string Pan = TextPan.Text;
            string Adhar = TextAdhar.Text;
            string ID_Card = TextOtherID.Text;


            string ContClub = ContractClubPDropDownList.SelectedItem.Text;
            string NoofPoints = TextNoPoints.Text;
            string PointsEntitle = EntitlementPoinDropDownList.SelectedItem.Text;
            string PointsMemFees = TextPMemFees.Text;
            string PointsPropFees = TextPPropFees.Text;
            string PointsFOccu = TextPFOccu.Text;
            string PointsDura = TextPDura.Text;
            string PointsLOccu = TextPLOccu.Text;

            /*string ResortF = ResortDropDownListF.SelectedItem.Text;
            string ResidenceNoF = ResidenceNoDropDownListF.SelectedItem.Text;
            string ResidenceTypeF = ResidenceTypeDropDownListF.SelectedItem.Text;
            string FractionalInt = FractionalIDropDownListF.SelectedItem.Text;
            string FractEntitle = EntitlementFracDropDownList.SelectedItem.Text;
            string FractFOccu = TextFOccuF.Text;
            string FractDura = TextFDuration.Text;
            string FractLOccu = TextFOccuL.Text;
            string FractLease = "";*/



            string DepositP_PM = DPMPointsDropDownList.SelectedItem.Text;
            string DepositP = TextDepositP.Text;
            string DepoPPA = TextDepoPPA.Text;
            string AdmissFeesP = TextAdminFeesP.Text;
            string AdminFeesP = TextAdminFeesP.Text;
            string PurchasePriceP = TextPpurchasePrice.Text;
            string CoutryTaxP = TextCountryTaxP.Text;
            string GrandTotalP = TextGrandTotalP.Text;
            string BalanceDuePAP = TextPBalaceDPA.Text;
            string PANoOfInstallP = TextPPANoInstall.Text;
            string PAFirstPayDateP = datepicker8.Text;
            string PAAmountInstallP = TextPPAAmountInstall.Text;
            string PAFirstInstallP = TextPPAFInstall.Text;
            string BalanceDueDatesPAP = TextPBalanceDDates.Text;
            string DepositSAP = TextPDepositSA.Text;
            /*string ApplicationFeesP = TextAppliFeesP.Text;
            string AdminServiceP = TextAdminServiceP.Text;
            string TotalServicePriceP = TextTotalServicePriceP.Text;
            string BalanceDueSAP = TextBalanceDueSAP.Text;
            string SANoOfInstallP = TextSANoInstallP.Text;
            string SAFirstPayDateP = datepicker9.Text;
            string SAAmountInstallP = TextSAAmountInstallP.Text;
            string SAFirstInstallP = TextSAFInstallP.Text;*/

        string ApplicationFeesP = "";
        string AdminServiceP = "";
        string TotalServicePriceP = "";
        string BalanceDueSAP = "";
        string SANoOfInstallP = "";
        string SAFirstPayDateP = "";
        string SAAmountInstallP = "";
        string SAFirstInstallP = "";
        string BalanceDueDatesSAP = "";
            string RemarksP = TextRemarksP.Text;
            string EuroRatesP = TextEuroRateP.Text;
            string AusRatesP = TextAusRateP.Text;
            string GbpRates = TextGbpRateP.Text;
            string IdaRates = TextIdaRateP.Text;
            string UsePayProtectP = "";
            string YearOfInterestP = "";
        string TotalBalance = TextTotalBalanceF.Text;
        // YearOfIntDropDownList.SelectedItem.Text;






         int ContractFinance = Queries2.InsertContractFinance(contfinaid, GenContNumb, ContType, affilice, affilhp, salesrep, tomanager,
          buttonup, FinaCurrency, PurchasePrice, AdminFees, MCFees, DealDrawer, PaymentMethod, FinanceNumb, BPaymethod, Pan, Adhar, ID_Card, ProfileIDo, officeo,"","");
        string log1 = "Contract Finance: " + "Finance_ID:" + contfinaid + "," + "Finance_Cont_Numb:" + GenContNumb + "," + "Finance_Cont_Type:" + ContType + "," + "Finance_Affil_ICE:" + affilice + "," + "Finance_Affil_HP:" + affilhp + ","+ "Finance_Sales_Rep:" + salesrep + "," + "Finance_TO_Manager:" + tomanager + "," + "Finance_Button_UP:" + buttonup + "," + "Finance_Currency:" + FinaCurrency + "," + "Finance_Purchase_Price:" + PurchasePrice + ","+ "Finance_Admin_Fees:" + AdminFees + "," + "Finance_MC_Fees:" + MCFees + "," + "Finance_Deal_Drawer:" + DealDrawer + "," + "Finance_Payment_Method:" + PaymentMethod + "," + "Finance_Finance_Num:" + FinanceNumb + ","+ "Finance_BPayment_Method:" + BPaymethod + "," + "Finance_Pan_Card:" + Pan + "," + "Finance_Adhar_Card:" + Adhar + "," + "Finance_ID_Card:" + ID_Card + "," + "Profile ID:" + ProfileIDo;
        int insertlog1 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log1, "Contract Finance", user, DateTime.Now.ToString());


        if (conttype == "Points")
        {
            // string desc, text12, text13, text14, text15, message;
            string desc, amot1, amot2, date, curr, text11, text12, text13, text14, text15;
            string PA = "PA";
            string SA = "SA";
            //GenContNumb = TextBox49.Text;

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

                if (int.Parse(amot1) != 0)
                {
                    string finaInstI = Queries2.getFinanceInstallID(officeo);
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
                }

                if (int.Parse(amot2) != 0)
                {
                    string finaInstI = Queries2.getFinanceInstallID(officeo);
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot2, curr, GenContNumb, ProfileIDo, SA, officeo);
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
            
            string log2 = "Points Contract  "+"Points_ID:" + contnumid2 + "," + "Points_Club:" + ContClub + "," + "Points_Entle:" + PointsEntitle + "," + "Points_Member_fees:" + PointsMemFees + "," + "Points_Points_Property_fees:" + PointsPropFees + "," + "Points_FYear_Occ:" + PointsFOccu + "," + "Points_Duration:" + PointsDura + "," + "Points_LYear_Occ:" + PointsLOccu + "," + "Points_Noof_Points:" + NoofPoints + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;
            int insertlog2 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log2, "Points", user, DateTime.Now.ToString());

            int PurchaseService2 = Queries2.InserPurchaseService(contPASAid, DepositP_PM, DepositP, DepoPPA, DepositSAP, AdmissFeesP, ApplicationFeesP, AdminFeesP, AdminServiceP, PurchasePriceP, TotalServicePriceP, CoutryTaxP, GrandTotalP, BalanceDuePAP, BalanceDueSAP, PANoOfInstallP, SANoOfInstallP, PAFirstPayDateP, SAFirstPayDateP, PAAmountInstallP, SAAmountInstallP, PAFirstInstallP, SAFirstInstallP, BalanceDueDatesPAP,
              BalanceDueDatesSAP, RemarksP, EuroRatesP, AusRatesP, GbpRates, IdaRates, UsePayProtectP, YearOfInterestP, ProfileIDo, contfinaid, TotalBalance, DateTime.Now, officeo);

            string log3 = "Points Finance  "+"ID:" + contPASAid + "," + "Deposit_Pay_Method:" + DepositP_PM + "," + "Deposit:" + DepositP + "," + "Deposit_PA:" + DepoPPA + "," + "Deposit_SA:" + DepositSAP + "," + "PA_Admission:" + AdmissFeesP + "," + "SA_Application:" + ApplicationFeesP + "," + "PA_Administration:" + AdminFeesP + "," + "SA_Administration:" + AdminServiceP + "," + "Total_Purchase:" + PurchasePriceP + "," + "Total_Service:" + TotalServicePriceP + "," + "Country_Tax:" + CoutryTaxP + "," + "Grand_Total:" + GrandTotalP + "," + "PA_Balance_Due:" + BalanceDuePAP + "," + "SA_Balance_Due:" + BalanceDueSAP + "," 
                + "PA_No_Install:" + PANoOfInstallP + "," + "SA_No_Install:" + SANoOfInstallP + "," + "PA_FInstall_Date:" + PAFirstPayDateP + "," + "SA_FInstall_Date:" + SAFirstPayDateP + "," + "PA_Install_Amt:" + PAAmountInstallP + "," + "SA_Install_Amt:" + SAAmountInstallP + "," + "PA_FInstall_Amt:" + PAFirstInstallP + "," + "SA_FInstall_Amt:" + SAFirstInstallP + "," + "PA_Balance_Due_Dates:" + BalanceDueDatesPAP + ","
                + "SA_Balance_Due_Dates:" + BalanceDueDatesSAP + "," + "Remarks:" + RemarksP + "," + "EURO_Rate:" + EuroRatesP + "," + "AUS_Rate:" + AusRatesP + "," + "GBP_Rate:" + GbpRates + "," + "IDA_Rate:" + IdaRates + "," + "Pay_Protect:" + UsePayProtectP + "," + "YOInterest:" + YearOfInterestP + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid + "," + "Total_Balance:" + TotalBalance;

            int insertlog3 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log3, "Points Finance", user, DateTime.Now.ToString());


        }
        else if (conttype == "Fractional")
        {


            string desc, amot1, date, curr, text11, text12, text13, text14;
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

                // if (int.Parse(amot1) != 0)
                //{
                string finaInstI = Queries2.getFinanceInstallID(officeo);
                int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
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
            string mark = MarketingPrgmDropDownList.SelectedItem.Text;//,  venue,  mark;

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

            string DepositF_PM = DPMFractDropDownList.SelectedItem.Text;
            string DepositF = TextDepositF.Text;
            // string DepoPPA = TextDepoPPA.Text;
            string AdmissFeesF = TextAdmissFeesF.Text;
            string AdminFeesF = TextAdminFeesF.Text;
            string PurchasePriceF = TextTotalPurchasePriceF.Text;
            string CoutryTaxF = TextCountryTaxF.Text;
            //string GrandTotalP = TextGrandTotalP.Text;
            string BalanceDuePAF = TextBalanceDueF.Text;

            string PAFirstPayDateF = datepicker10.Text;
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
            string RemarksF = TextRemarksP.Text;
            string EuroRatesF = TextEuroRateP.Text;
            string AusRatesF = TextAusRateP.Text;
            string GbpRatesF = TextGbpRateP.Text;
            string IdaRatesF = TextIdaRateP.Text;
            string UsePayProtectF = "";
            string YearOfInterestF = "";

            int ContFracid = Queries2.InsertContractFractional(ContFracid2, ResortF, ResidenceNoF, ResidenceTypeF, FractionalInt, FractEntitle, FractFOccu, FractDura, FractLOccu, FractLease, contfinaid, ProfileIDo, officeo);


            //string log2 = "Points Contract  " + "Points_ID:" + contnumid2 + "," + "Points_Club:" + ContClub + "," + "Points_Entle:" + PointsEntitle + "," + "Points_Member_fees:" + PointsMemFees + "," + "Points_Points_Property_fees:" + PointsPropFees + "," + "Points_FYear_Occ:" + PointsFOccu + "," + "Points_Duration:" + PointsDura + "," + "Points_LYear_Occ:" + PointsLOccu + "," + "Points_Noof_Points:" + NoofPoints + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;

            string log4 = "Fractional Contract  " + "Fractional_ID:" + ContFracid2 + "," + "Fractional_Resort:" + ResortF + "," + "Fractional_Residence_No:" + ResidenceNoF + "," + "Fractional_Residence_Type:" + ResidenceTypeF + "," + "Fractional_Fractional_Int:" + FractionalInt + "," + "Fractional_Entitle:" + FractEntitle + "," + "Fractional_First_Occu:" + FractFOccu + "," + "Fractional_Duration:" + FractDura + "," + "Fractional_Last_Occu:" + FractLOccu + "," + "Fractional_Lease_Back:" + FractLease + "," + "Contract_Finance_ID:" + contfinaid + "," + "Profile_ID:" + ProfileIDo;
            int insertlog4 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log4, "Points Finance", user, DateTime.Now.ToString());

            int PurchaseService = Queries2.InserPurchaseService(contPASAid, DepositF_PM, DepositF, "", "", AdmissFeesF, "", AdminFeesF, "", PurchasePriceF, "", CoutryTaxF, "", BalanceDuePAF, "", PANoOfInstallF, "", PAFirstPayDateF, "", PAAmountInstallF, "", PAFirstInstallF, "", BalanceDueDatesPAF,
                "", RemarksF, EuroRatesF, AusRatesF, GbpRatesF, IdaRatesF, UsePayProtectF, YearOfInterestF, ProfileIDo, contfinaid, TotalBalance, DateTime.Now, officeo);

            string log5 = "Fractional Finance  " + "ID:" + contPASAid + "," + "Deposit_Pay_Method:" + DepositF_PM + "," + "Deposit:" + DepositF + "," + "PA_Admission:" + AdmissFeesF + ","  + "PA_Administration:" + AdminFeesF + "," +  "Total_Purchase:" + PurchasePriceF + ","  + "Country_Tax:" + CoutryTaxF + "," + "PA_Balance_Due:" + BalanceDuePAF + "," 
               + "PA_No_Install:" + PANoOfInstallF + "," + "PA_FInstall_Date:" + PAFirstPayDateF + "," + "PA_Install_Amt:" + PAAmountInstallF + ","  + "PA_FInstall_Amt:" + PAFirstInstallF + "," + "PA_Balance_Due_Dates:" + BalanceDueDatesPAF + ","
               + "Remarks:" + RemarksF + "," + "EURO_Rate:" + EuroRatesF + "," + "AUS_Rate:" + AusRatesF + "," + "GBP_Rate:" + GbpRatesF + "," + "IDA_Rate:" + IdaRatesF + "," + "Pay_Protect:" + UsePayProtectF + "," + "YOInterest:" + YearOfInterestF + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid + "," + "Total_Balance:" + TotalBalance;

            int insertlog3 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log5, "Fractional Finance", user, DateTime.Now.ToString());


        }

        else if (conttype == "Trade Into Fractional")
        {


            string desc, amot1, date, curr, text11, text12, text13, text14;
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

            string DepositTF_PM = DPMTFractDropDownList.SelectedItem.Text;
            string DepositTF = TextDepositTF.Text;
            // string DepoPPA = TextDepoPPA.Text;
            string AdmissFeesTF = TextAdmissFeeTF.Text;
            string AdminFeesTF = TextAdminFeeTF.Text;
            string PurchasePriceTF = TextPurchasePriceTF.Text;
            string CoutryTaxTF = TextCountryTaxTF.Text;
            //string GrandTotalP = TextGrandTotalP.Text;
            string BalanceDuePATF = TextBalanceDuePATF.Text;

            string PAFirstPayDateTF = datepicker13.Text;
            string PAAmountInstallTF = TextInstallAmtTF.Text;
            string PAFirstInstallTF = TextFInstallAmtTF.Text;
            string BalanceDueDatesPATF = TextBalanceDueDatesPATF.Text;

            string RemarksTF = TextRemarksTF.Text;


            int ContFracid = Queries2.InsertContractTF(ContFracid2, OldAgreeNoTF, OldClubTF, OldNoOfPointsTF, OldEntitleTF, OldResortTF, OldAppartTypeTF, OldNoOccuTF, OldPeriodTF, OldSeasonTF, OldResidenceNoTF, OldResiTypeTF, OldFracIntTF, ResortTF, ResidenceNoTF, ResidenceTypeTF, TFractionalInt, TFractEntitle, TFractFOccu, TFractDura, TFractLOccu, TFractLease, ProfileIDo, contfinaid, officeo, conttypeTF);

           // string log4 = "Fractional Contract  " + "Fractional_ID:" + ContFracid2 + "," + "Fractional_Resort:" + ResortF + "," + "Fractional_Residence_No:" + ResidenceNoF + "," + "Fractional_Residence_Type:" + ResidenceTypeF + "," + "Fractional_Fractional_Int:" + FractionalInt + "," + "Fractional_Entitle:" + FractEntitle + "," + "Fractional_First_Occu:" + FractFOccu + "," + "Fractional_Duration:" + FractDura + "," + "Fractional_Last_Occu:" + FractLOccu + "," + "Fractional_Lease_Back:" + FractLease + "," + "Contract_Finance_ID:" + contfinaid + "," + "Profile_ID:" + ProfileIDo;

            string log6 = "Trade Into Fractional  "+"ID:" + ContFracid2 + "," + "Old_Cont_Numb:" + OldAgreeNoTF + "," + "Old_Club:" + OldClubTF + "," + "Old_NoOf_Points:" + OldNoOfPointsTF + "," + "Old_Entitle:" + OldEntitleTF + "," 
                + "Old_Resort:" + OldResortTF + "," + "Old_Apmnt_Type:" + OldAppartTypeTF + "," + "Old_No_Occu:" + OldNoOccuTF + "," + "Old_Period:" + OldPeriodTF + "," + "Old_Season:" + OldSeasonTF + "," + "Old_Resi_No:" + OldResidenceNoTF + "," + "Old_Resi_Type:" + OldResiTypeTF + "," + "Old_Frac_Int:" + OldFracIntTF + "," + "Resort:" + ResortTF + "," + "Resi_No:" + ResidenceNoTF + ","
                + "Resi_Type:" + ResidenceTypeTF + "," + "Frac_Int:" + TFractionalInt + "," + "Entitle:" + TFractEntitle + "," + "First_Occ:" + TFractFOccu + "," + "Duration:" + TFractDura + "," + "Last_Occ:" + TFractLOccu + "," + "Leas:" + TFractLease + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;
            int insertlog6 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log6, "Trade Into Fractional ", user, DateTime.Now.ToString());

            int PurchaseService = Queries2.InserPurchaseService(contPASAid, DepositTF_PM, DepositTF, "", "", AdmissFeesTF, "", AdminFeesTF, "", PurchasePriceTF, "", CoutryTaxTF, "", BalanceDuePATF, "", PANoOfInstallTF, "", PAFirstPayDateTF, "", PAAmountInstallTF, "", PAFirstInstallTF, "", BalanceDueDatesPATF,
                "", RemarksTF, EuroRatesP, AusRatesP, GbpRates, IdaRates, UsePayProtectP, YearOfInterestP, ProfileIDo, contfinaid, TotalBalance, DateTime.Now, officeo);

            string log7 = "Fractional Finance  " + "ID:" + contPASAid + "," + "Deposit_Pay_Method:" + DepositTF_PM + "," + "Deposit:" + DepositTF + "," + "PA_Admission:" + AdmissFeesTF + "," + "PA_Administration:" + AdminFeesTF + "," + "Total_Purchase:" + PurchasePriceTF + "," + "Country_Tax:" + CoutryTaxTF + "," + "PA_Balance_Due:" + BalanceDuePATF + ","
              + "PA_No_Install:" + PANoOfInstallTF + "," + "PA_FInstall_Date:" + PAFirstPayDateTF + "," + "PA_Install_Amt:" + PAAmountInstallTF + "," + "PA_FInstall_Amt:" + PAFirstInstallTF + "," + "PA_Balance_Due_Dates:" + BalanceDueDatesPATF + ","
              + "Remarks:" + RemarksTF + "," + "EURO_Rate:" + EuroRatesP + "," + "AUS_Rate:" + AusRatesP + "," + "GBP_Rate:" + GbpRates + "," + "IDA_Rate:" + IdaRates + "," + "Pay_Protect:" + UsePayProtectP + "," + "YOInterest:" + YearOfInterestP + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid + "," + "Total_Balance:" + TotalBalance;

            int insertlog7 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log7, "Trade Into Fractional Finance", user, DateTime.Now.ToString());




            string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
            string venue = VenueDropDownList.SelectedItem.Text;
            string mark = MarketingPrgmDropDownList.SelectedItem.Text;//,  venue,  mark;


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

                    // if (int.Parse(amot1) != 0)
                    //{
                    string finaInstI = Queries2.getFinanceInstallID(officeo);
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
                    // }


                }
        }




        }

        else if (conttype == "Trade Into Points")
        {
            string desc, amot1, amot2, date, curr, text11, text12, text13, text14, text15;
            string PA = "PA";
            string SA = "SA";
            //GenContNumb = TextBox49.Text;
            string OldAgreeNo = "";
            string OldClub = "", OldNoPoints ="", OldEntitle="", ContResort="", AppartmentType="", NumbOccuTP = "", ContPeriod = "", ContSeason = "";


            string ContTPType = hiddentconttype.Text;

            if (ContTPType == "From Points To Points")
            {
              OldAgreeNo =TextOldAgreeNoTP1.Text;
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
           else if(ContTPType == "From Weeks To Points")
            {
                OldClub = "";
                OldNoPoints = "";
                 OldAgreeNo =TextOldAgreeNoTP2.Text;
                 ContResort = ResortTPDropDownList.SelectedItem.Text;
                if(AppartmentTypeTPDropDownList.SelectedItem.Text == "")
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


            string DepositPayMethodTP = DPMTPointsDropDownList.SelectedItem.Text;
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
            /*string DepositSATP = TextDepositSATP.Text;
            string AppliFeesTP = TextAppliFeesTP.Text;
            string AdminServiceTP = TextAdminServiceTP.Text;
            string TotalServiceTP = TextTotalServiceTP.Text;
            string BalanceDueSATP = TextBalanceDueSATP.Text;
            string NoOfInstallSATP = TextNoOfInstallSATP.Text;
            string InstallAmtSATP = TextInstallAmtSATP.Text;
            string FInstallAmtSATP = TextFInstallAmtSATP.Text;*/

            string DepositSATP = "";
            string AppliFeesTP = "";
            string AdminServiceTP = "";
            string TotalServiceTP = "";
            string BalanceDueSATP = "";
            string NoOfInstallSATP = "";
            string InstallAmtSATP = "";
            string FInstallAmtSATP = "";

            string remarkTP = TextRemarksTP.Text;
            string BalanceDueDatesPATP = TextBalanceDueDatesPATP.Text;
            string BalanceDueDatesSATP = "";

            string PaymentDatePA = datepicker11.Text;
            //string PaymentDateSA = datepicker12.Text;
            string PaymentDateSA = "";


            int ContractPoints = Queries2.InsertContractTP(ContFracid2, ContTPType, OldAgreeNo, ContResort, AppartmentType, NumbOccuTP, ContPeriod, ContSeason, OldEntitle, OldClub, OldNoPoints, NewPoints, TotalPoints, ContNewClub, ContNewEntitle, Memberfees, PropertyFees, FYOcc, DurationTP, LYOcc,ProfileIDo, contfinaid, officeo);

            //string log2 = "Points Contract  " + "Points_ID:" + contnumid2 + "," + "Points_Club:" + ContClub + "," + "Points_Entle:" + PointsEntitle + "," + "Points_Member_fees:" + PointsMemFees + "," + "Points_Points_Property_fees:" + PointsPropFees + "," + "Points_FYear_Occ:" + PointsFOccu + "," + "Points_Duration:" + PointsDura + "," + "Points_LYear_Occ:" + PointsLOccu + "," + "Points_Noof_Points:" + NoofPoints + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;

            string log8 = "Trade Into Points  " + "ID:" + ContFracid2 + "," + "Cont_Type:" + ContTPType + "," + "Old_Agree_Numb:" + OldAgreeNo + "," + "Resort:" + ContResort + "," + "Appartment_Type:" + AppartmentType + "," + "Num_Occ:" + NumbOccuTP + "," 
                + "Period:" + ContPeriod + "," + "Season:" + ContSeason + "," + "Old_Entitlement:" + OldEntitle + "," + "Old_Club:" + OldClub + "," + "Old_No_Points:" + OldNoPoints + "," + "New_No_Points:" + NewPoints + "," + "Total_Points:" + TotalPoints + "," + "New_CLub:" + ContNewClub + "," + "New_Entitlement:" + ContNewEntitle + "," + "Member_Fees:" + Memberfees + "," + "Property_Fees:" + PropertyFees + "," + "FY_Occu:" + FYOcc + "," + "Duration:" + DurationTP + "," + "LY_Occu:" + LYOcc + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid;

            int insertlog8 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log8, "Trade Into Points ", user, DateTime.Now.ToString());

            int PurchaseService2 = Queries2.InserPurchaseService(contPASAid, DepositPayMethodTP, DepositTP, DepositPATP, DepositSATP, AdmissFTP, AppliFeesTP, AdminFeesTP, AdminServiceTP, PurchasePriceTP, TotalServiceTP, CountryTaxTP, GrandTotalTP, BalanceDuePATP, BalanceDueSATP, NoOfInstallPATP, NoOfInstallSATP, PaymentDatePA, PaymentDateSA, InstallAmtPATP, InstallAmtSATP, FInstallAmtPATP, FInstallAmtSATP, BalanceDueDatesPATP,
            BalanceDueDatesSATP, remarkTP, EuroRatesP, AusRatesP, GbpRates, IdaRates, UsePayProtectP, YearOfInterestP, ProfileIDo, contfinaid, TotalBalance, DateTime.Now, officeo);



            string log9 = "Trade Into Points Finance  " + "ID:" + contPASAid + "," + "Deposit_Pay_Method:" + DepositPayMethodTP + "," + "Deposit:" + DepositTP + "," + "Deposit_PA:" + DepositPATP + "," + "Deposit_SA:" + DepositSATP + "," + "PA_Admission:" + AdmissFTP + "," + "SA_Application:" + AppliFeesTP + "," + "PA_Administration:" + AdminFeesTP + "," + "SA_Administration:" + AdminServiceTP + "," + "Total_Purchase:" + PurchasePriceTP + "," + "Total_Service:" + TotalServiceTP + "," + "Country_Tax:" + CountryTaxTP + "," + "Grand_Total:" + GrandTotalTP + "," + "PA_Balance_Due:" + BalanceDuePATP + "," + "SA_Balance_Due:" + BalanceDueSATP + ","
                + "PA_No_Install:" + NoOfInstallPATP + "," + "SA_No_Install:" + NoOfInstallSATP + "," + "PA_FInstall_Date:" + PaymentDatePA + "," + "SA_FInstall_Date:" + PaymentDateSA + "," + "PA_Install_Amt:" + InstallAmtPATP + "," + "SA_Install_Amt:" + InstallAmtSATP + "," + "PA_FInstall_Amt:" + FInstallAmtPATP + "," + "SA_FInstall_Amt:" + FInstallAmtSATP + "," + "PA_Balance_Due_Dates:" + BalanceDueDatesPATP + ","
                + "SA_Balance_Due_Dates:" + BalanceDueDatesSATP + "," + "Remarks:" + remarkTP + "," + "EURO_Rate:" + EuroRatesP + "," + "AUS_Rate:" + AusRatesP + "," + "GBP_Rate:" + GbpRates + "," + "IDA_Rate:" + IdaRates + "," + "Pay_Protect:" + UsePayProtectP + "," + "YOInterest:" + YearOfInterestP + "," + "Profile_ID:" + ProfileIDo + "," + "Contract_Finance_ID:" + contfinaid + "," + "Total_Balance:" + TotalBalance;


            int insertlog9 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, GenContNumb, log9, "Trade Into Points Finance", user, DateTime.Now.ToString());




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

                if (int.Parse(amot1) != 0)
                {
                    string finaInstI = Queries2.getFinanceInstallID(officeo);
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot1, curr, GenContNumb, ProfileIDo, PA, officeo);
                }

                if (int.Parse(amot2) != 0)
                {
                    string finaInstI = Queries2.getFinanceInstallID(officeo);
                    int FinanceInvoice = Queries2.InsertFinanceInv(finaInstI, desc, date, amot2, curr, GenContNumb, ProfileIDo, SA, officeo);
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

        string script = "<script> $(function() { $('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
        //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

    }

    //}

    public void Button2_Click(object sender, EventArgs e)
    {
        PrintPdfDropDownList.Items.Clear();
        string ContType = DropDownList40.SelectedItem.Text;
        DataSet ds21 = Queries2.LoadPrintFiles(ContType, officeo);
        PrintPdfDropDownList.DataSource = ds21;
        PrintPdfDropDownList.DataTextField = "Printpdf_name";
        PrintPdfDropDownList.DataValueField = "Printpdf_name";
        PrintPdfDropDownList.AppendDataBoundItems = true;
        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
        PrintPdfDropDownList.DataBind();

        string script = "<script> $(function() { $( '#tabs' ).tabs({ active: 3 }); });</script> ";
        //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
    }


    

    protected void Button5_Click(object sender, EventArgs e)
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
        string Pcomments = "";//TextPrimaryCCard.Text;
        string Scomments = "";// TextSecondaryCCard.Text;




        int PmentDetails = Queries2.InserPaymentDetails(PmentDetailsId, PCard_Type, PIssuing_Bank, PCredit_Card_No, PCard_Holders_Name, PExpiry, PSecurity_No,
            PFor_Depo, PFor_Bala, SCard_Type, SIssuing_Bank, SCredit_Card, SCard_Holders_Name, SExpiry, SSecurity_No, SFor_Depo, SFor_Bala, ProfileIDo, contFinance, entrydate, officeo, Pcomments, Scomments);

        string script = "<script> $(function() { $('#tabs').tabs({ disabled: [] }); $( '#tabs' ).tabs({ active: 4 }); });</script> ";
        //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
    }



    protected void Button4_Click(object sender, EventArgs e)
    {

        var printr = PrintPdfDropDownList.SelectedItem.Text;
        DataTable datatable = Queries2.loadreport(ProfileIDo, printr, officeo);
       
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
        Response.Close();







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
            using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
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

                        objst2.VenueGroupTypeName = Convert.ToString(dt.Rows[i]["Venue_Group_Name"]);

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
            using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
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

                        objst2.MrktProgTypeName = Convert.ToString(dt.Rows[i]["Marketing_Program_Name"]);

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
            using (SqlCommand cmd = new SqlCommand("select Agent_Name from Agent_marketing where marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "' and Marketing_Program_ID in (select Marketing_Program_ID from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))))", con))
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

                        objst2.AgentTypeName = Convert.ToString(dt.Rows[i]["Agent_Name"]);

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
    public static string PopulateAgentCodeDropDownList(string markid, string agentid)
    {
        DataTable dt = new DataTable();
        List<AgentCodeType> listRes = new List<AgentCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select Agent_Code from Agent_Code where Agent_id in (select Agent_ID from Agent_marketing where Agent_Name = '" + agentid + "' and marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='" + markid + "'))", con))
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

                        objst2.AgentCodeTypeName = Convert.ToString(dt.Rows[i]["Agent_Code"]);

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
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
    public static string [] LoadPropfess(string NoPoints)
    {
        // string[] finaInstI = new string[3];
        //return "Hello "+name;
        string[] s = new string[2];
        string finaInstI = Queries2.LoadPropfess(NoPoints);
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


    protected void Button6_Click(object sender, EventArgs e)
    {
        string pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate;
        string pemail, semail, sp1email, sp2email;
        string venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, membertype2, employmentstatus, maritalstatus, primarytitle, primarynationality;
        string primarycountry, secondarytitle, secondarynationality, secondarycountry, sp1title, sp1nationality, sp1country, sp2title, sp2nationality, sp2country;
        string gueststatus, salesrep, gift_option;

        string profile = ProfileIDTextBox.Text;
        string createdby = CreatedByTextBox.Text;

        if (VenueCountryDropDownList.SelectedItem.Text == "")
        {
            venuecountry = "";
        }
        else {
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

        if (GroupVenueDropDownList.SelectedItem.Text == "")
        {
            venuegroup = "";
        }
        else
        {
            venuegroup = GroupVenueDropDownList.SelectedItem.Text;
        }

        if (MarketingPrgmDropDownList.SelectedItem.Text == "")
        {
            mktg = "";
        }
        else
        {
            mktg = MarketingPrgmDropDownList.SelectedItem.Text;
        }

        if (AgentsDropDownList.SelectedItem.Text == "")
        {
            agents = "";
        }
        else
        {
            agents = AgentsDropDownList.SelectedItem.Text;
        }

        // if (AgentCodeDropDownList.SelectedItem.Text == "" || AgentCodeDropDownList.SelectedIndex == 0)
        //{
        //  agentcode = "";
        // }
        // else
        // {
         agentcode = AgentCodeDropDownList.SelectedItem.Text;
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

        //other details

        if (employmentstatusDropDownList.SelectedItem.Text == "")
        {
            employmentstatus = "";
        }
        else
        {
            employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
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


        int updateprofile = Queries.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs,"","","","","","","","");


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

        if (primarynationalityDropDownList.SelectedItem.Text == "")
        {
            primarynationality = "";
        }
        else
        {
            primarynationality = primarynationalityDropDownList.SelectedItem.Text;
        }

        if (PrimaryCountryDropDownList.SelectedItem.Text == "")
        {
            primarycountry = "";
        }
        else
        {
            primarycountry = PrimaryCountryDropDownList.SelectedItem.Text;
        }
     
        int primary = Queries.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, primarydob, primarynationality, primarycountry,"","","");

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

        if (secondarynationalityDropDownList.SelectedItem.Text == "")
        {
            secondarynationality = "";
        }
        else
        {
            secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
        }

        if (SecondaryCountryDropDownList.SelectedItem.Text == "")
        {
            secondarycountry = "";
        }
        else
        {
            secondarycountry = SecondaryCountryDropDownList.SelectedItem.Text;
        }


       
        int secondary = Queries.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry,"","","");


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

        if (subprofile1nationalityDropDownList.SelectedItem.Text == "")
        {
            sp1nationality = "";
        }
        else
        {
            sp1nationality = subprofile1nationalityDropDownList.SelectedItem.Text;
        }

        if (SubProfile1CountryDropDownList.SelectedItem.Text == "")
        {
            sp1country = "";
        }
        else
        {
            sp1country = SubProfile1CountryDropDownList.SelectedItem.Text;
        }

        
        int sp1 = Queries.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country,"");

        // subprofile1
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

        if (subprofile2nationalityDropDownList.SelectedItem.Text == "")
        {
            sp2nationality = "";
        }
        else
        {
            sp2nationality = subprofile2nationalityDropDownList.SelectedItem.Text;
        }


        if (SubProfile2CountryDropDownList.SelectedItem.Text == "")
        {
            sp2country = "";
        }
        else
        {
            sp2country = SubProfile2CountryDropDownList.SelectedItem.Text;
        }
        

        int sp2 = Queries.UpdateSubProfile1(profile, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country,"");

        //address

        string address1 = address1TextBox.Text;
        string address2 = address2TextBox.Text;
        string state = stateTextBox.Text;
        string city = cityTextBox.Text;
        string pincode = pincodeTextBox.Text;

        string acountry = AddCountryDropDownList.SelectedItem.Text;

        int address = Queries.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);


        if (primarymobileDropDownList.SelectedIndex == 0)
        {
            pcc = "";

        }
        else
        {

            pcc = primarymobileDropDownList.SelectedItem.Text;

        }
        if (primaryalternateDropDownList.SelectedIndex == 0)
        {
            paltrcc = "";
        }
        else
        {

            paltrcc = primaryalternateDropDownList.SelectedItem.Text;
        }

        pmobile = pmobileTextBox.Text;

        palternate = palternateTextBox.Text;

        pemail = pemailTextBox.Text;




        if (secondarymobileDropDownList.SelectedIndex == 0)
        {
            scc = "";
        }
        else
        {

            scc = secondarymobileDropDownList.SelectedItem.Text;
        }

        if (secondaryalternateDropDownList.SelectedIndex == 0)
        {
            saltcc = "";
        }
        else
        {

            saltcc = secondaryalternateDropDownList.SelectedItem.Text;
        }

        smobile = smobileTextBox.Text;

        salternate = salternateTextBox.Text;


        semail = semailTextBox.Text;


        if (subprofile1mobileDropDownList.SelectedIndex == 0)
        {
            sp1cc = "";
        }
        else
        {

            sp1cc = subprofile1mobileDropDownList.SelectedItem.Text;
        }

        if (subprofile1alternateDropDownList.SelectedIndex == 0)
        {
            sp1altcc = "";
        }
        else
        {

            sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;
        }


        sp1mobile = sp1mobileTextBox.Text;

        sp1alternate = sp1alternateTextBox.Text;


        sp1email = sp1emailTextBox.Text;


        if (subprofile2mobileDropDownList.SelectedIndex == 0)
        {
            sp2cc = "";
        }
        else
        {

            sp2cc = subprofile2mobileDropDownList.SelectedItem.Text;
        }

        if (subprofile2alternateDropDownList.SelectedIndex == 0)
        {
            sp2altccc = "";
        }
        else
        {

            sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text;
        }

        sp2mobile = sp2mobileTextBox.Text;


        sp2alternate = sp2alternateTextBox.Text;



        sp2email = sp2emailTextBox.Text;


      //  int phone = Queries.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate,"","","","","","","","");
        int email = Queries.UpdateEmail(profile, pemail, semail, sp1email, sp2email,"","","","","","","","");


        //stay details
        string resort = hotelTextBox.Text;
        string roomno = roomnoTextBox.Text;
        string arrivaldate = datepicker5.Text;
        string departuredate = datepicker6.Text;

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
        string taxin = taxipriceInTextBox.Text;
        string taxirefin = TaxiRefInTextBox.Text;
        string taxiout = TaxiPriceOutTextBox.Text;
        string taxirefout = TaxiRefOutTextBox.Text;

       

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




        int stay = Queries.UpdateProfileStay(profile, resort, roomno, arrivaldate, departuredate);
        int tour = Queries.UpdateTourDetails(profile, gueststatus, salesrep, tourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout,"",0);

        //int giftoption = Queries2.Updategiftoption(profile, gift_option, VoucherNo, giftcomm);
    }
}






