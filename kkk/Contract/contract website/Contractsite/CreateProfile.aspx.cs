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
using System.Diagnostics;

public partial class _Default : System.Web.UI.Page
{
    static string officeo;
    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate, sp3mobile, sp3alternate, sp4mobile, sp4alternate;
    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec;
    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc, sp3cc, sp3altcc, sp4cc, sp4altcc; 

    static string ProfileIDo,testo;

    static string pemail, semail,sp1email, sp2email, pemail2, semail2, sp1email2, sp2email2, sp3email, sp3email2, sp4email, sp4email2;
    protected void Page_Load(object sender, EventArgs e)
    {

        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        // string user =(string) Session["username"];
        //this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        if (!Page.IsPostBack)
        {
            //string user = (string)Session["username"];// "Caroline";
            CreatedByTextBox.Text = user;
            //get office of user
            string office = Queries.GetOffice(user);
            officeo = office;
       
            ProfileIDTextBox.ReadOnly = true;


           /* ProfileIDTextBox.Text = Queries.GetProfileID(office);// VenueCountryDropDownList.SelectedItem.Text);
            string PID = Queries.GetProfileID(office);
            int PCount = Queries2.CheckProfileID(PID);

            while(PCount != 0)
            {
                 PID = Queries.GetProfileID(office);
                 PCount = Queries2.CheckProfileID(PID);
            }*/
            // ProfileIDTextBox.Text = Queries.GetProfileID(office);

            //load values in respective dropdown listbox

            DataSet ds = Queries2.LoadVenueCountry(officeo);
        VenueCountryDropDownList.DataSource = ds;
        VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
        VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
        VenueCountryDropDownList.AppendDataBoundItems = true;
        VenueCountryDropDownList.Items.Insert(0, new ListItem("", ""));
        VenueCountryDropDownList.DataBind();

        //load venues
      /*  DataSet ds1 = Queries.LoadVenue();
        VenueDropDownList.DataSource = ds1;
        VenueDropDownList.DataTextField = "Venue_Name";
        VenueDropDownList.DataValueField = "Venue_Name";
        VenueDropDownList.AppendDataBoundItems = true;
        VenueDropDownList.Items.Insert(0, new ListItem("", ""));
        VenueDropDownList.DataBind();*/


        //load venue group
      /*  DataSet ds2 = Queries.LoadVenueGroup();
        GroupVenueDropDownList.DataSource = ds2;
        GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
        GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
        GroupVenueDropDownList.AppendDataBoundItems = true;
        GroupVenueDropDownList.Items.Insert(0, new ListItem("", ""));
        GroupVenueDropDownList.DataBind();*/

        //load venue group
       /* DataSet ds3 = Queries.LoadMarketingProgram();
        MarketingPrgmDropDownList.DataSource = ds3;
        MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
        MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
        MarketingPrgmDropDownList.AppendDataBoundItems = true;
        MarketingPrgmDropDownList.Items.Insert(0, new ListItem("", ""));
        MarketingPrgmDropDownList.DataBind();*/

        //load agents
      /*  DataSet ds4 = Queries.LoadAgents();
        AgentsDropDownList.DataSource = ds4;
        AgentsDropDownList.DataTextField = "Agent_Name";
        AgentsDropDownList.DataValueField = "Agent_Name";
        AgentsDropDownList.AppendDataBoundItems = true;
        AgentsDropDownList.Items.Insert(0, new ListItem("", ""));
        AgentsDropDownList.DataBind();*/

          

            //load agent code
            DataSet ds5 = Queries.LoadAgentCode();
        AgentCodeDropDownList.DataSource = ds5;
        AgentCodeDropDownList.DataTextField = "Agent_Code_Name";
        AgentCodeDropDownList.DataValueField = "Agent_Code_Name";
        AgentCodeDropDownList.AppendDataBoundItems = true;
        AgentCodeDropDownList.Items.Insert(0, new ListItem("", ""));
        AgentCodeDropDownList.DataBind();

        //load membertype
        DataSet ds6 = Queries.LoadMemberType();
        MemType1DropDownList.DataSource = ds6;
        MemType1DropDownList.DataTextField = "Member_Type_name";
        MemType1DropDownList.DataValueField = "Member_Type_name";
        MemType1DropDownList.AppendDataBoundItems = true;
        MemType1DropDownList.Items.Insert(0, new ListItem("", ""));
        MemType1DropDownList.DataBind();

        DataSet ds7 = Queries.LoadMemberType();
        MemType2DropDownList.DataSource = ds7;
        MemType2DropDownList.DataTextField = "Member_Type_name";
        MemType2DropDownList.DataValueField = "Member_Type_name";
        MemType2DropDownList.AppendDataBoundItems = true;
        MemType2DropDownList.Items.Insert(0, new ListItem("", ""));
        MemType2DropDownList.DataBind();


        //load country names in respective country dropdowns
       /* DataSet ds8 = Queries.LoadCountryName();
        PrimaryCountryDropDownList.DataSource = ds8;
        PrimaryCountryDropDownList.DataTextField = "country_name";
        PrimaryCountryDropDownList.DataValueField = "country_name";
        PrimaryCountryDropDownList.AppendDataBoundItems = true;
        PrimaryCountryDropDownList.Items.Insert(0, new ListItem("", ""));
        PrimaryCountryDropDownList.DataBind();

        DataSet ds9 = Queries.LoadCountryName();
        SecondaryCountryDropDownList.DataSource = ds9;
        SecondaryCountryDropDownList.DataTextField = "country_name";
        SecondaryCountryDropDownList.DataValueField = "country_name";
        SecondaryCountryDropDownList.AppendDataBoundItems = true;
        SecondaryCountryDropDownList.Items.Insert(0, new ListItem("", ""));
        SecondaryCountryDropDownList.DataBind();

        DataSet ds10 = Queries.LoadCountryName();
        SubProfile1CountryDropDownList.DataSource = ds10;
        SubProfile1CountryDropDownList.DataTextField = "country_name";
        SubProfile1CountryDropDownList.DataValueField = "country_name";
        SubProfile1CountryDropDownList.AppendDataBoundItems = true;
        SubProfile1CountryDropDownList.Items.Insert(0, new ListItem("", ""));
        SubProfile1CountryDropDownList.DataBind();

        DataSet ds11 = Queries.LoadCountryName();
        SubProfile2CountryDropDownList.DataSource = ds11;
        SubProfile2CountryDropDownList.DataTextField = "country_name";
        SubProfile2CountryDropDownList.DataValueField = "country_name";
        SubProfile2CountryDropDownList.AppendDataBoundItems = true;
        SubProfile2CountryDropDownList.Items.Insert(0, new ListItem("", ""));
        SubProfile2CountryDropDownList.DataBind();

        DataSet sp3country = Queries.LoadCountryName();
            SubP3CountryDropDownList.DataSource = sp3country;
            SubP3CountryDropDownList.DataTextField = "country_name";
            SubP3CountryDropDownList.DataValueField = "country_name";
            SubP3CountryDropDownList.AppendDataBoundItems = true;
            SubP3CountryDropDownList.Items.Insert(0, new ListItem("", ""));
            SubP3CountryDropDownList.DataBind();

            DataSet sp4country = Queries.LoadCountryName();
            SubP4CountryDropDownList.DataSource = sp4country;
            SubP4CountryDropDownList.DataTextField = "country_name";
            SubP4CountryDropDownList.DataValueField = "country_name";
            SubP4CountryDropDownList.AppendDataBoundItems = true;
            SubP4CountryDropDownList.Items.Insert(0, new ListItem("", ""));
            SubP4CountryDropDownList.DataBind();*/


            //load country with code for mobile nos n alternate nos
            DataSet ds12 = Queries2.LoadCountryWithCode();
            primarymobileDropDownList.DataSource = ds12;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem("", ""));
            primarymobileDropDownList.DataBind();

            DataSet ds12a = Queries2.LoadCountryWithCode();
        primaryalternateDropDownList.DataSource = ds12a;
        primaryalternateDropDownList.DataTextField = "name";
        primaryalternateDropDownList.DataValueField = "name";
        primaryalternateDropDownList.AppendDataBoundItems = true;
        primaryalternateDropDownList.Items.Insert(0, new ListItem("", ""));
        primaryalternateDropDownList.DataBind();

        DataSet ds13 = Queries2.LoadCountryWithCode();
        secondarymobileDropDownList.DataSource = ds13;
        secondarymobileDropDownList.DataTextField = "name";
        secondarymobileDropDownList.DataValueField = "name";
        secondarymobileDropDownList.AppendDataBoundItems = true;
        secondarymobileDropDownList.Items.Insert(0, new ListItem("", ""));
        secondarymobileDropDownList.DataBind();


        DataSet ds13a = Queries2.LoadCountryWithCode();
        secondaryalternateDropDownList.DataSource = ds13a;
        secondaryalternateDropDownList.DataTextField = "name";
        secondaryalternateDropDownList.DataValueField = "name";
        secondaryalternateDropDownList.AppendDataBoundItems = true;
        secondaryalternateDropDownList.Items.Insert(0, new ListItem("", ""));
        secondaryalternateDropDownList.DataBind();

        DataSet ds14 = Queries2.LoadCountryWithCode();
        subprofile1mobileDropDownList.DataSource = ds14;
        subprofile1mobileDropDownList.DataTextField = "name";
        subprofile1mobileDropDownList.DataValueField = "name";
        subprofile1mobileDropDownList.AppendDataBoundItems = true;
        subprofile1mobileDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile1mobileDropDownList.DataBind();

        DataSet ds14a = Queries2.LoadCountryWithCode();
        subprofile1alternateDropDownList.DataSource = ds14a;
        subprofile1alternateDropDownList.DataTextField = "name";
        subprofile1alternateDropDownList.DataValueField = "name";
        subprofile1alternateDropDownList.AppendDataBoundItems = true;
        subprofile1alternateDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile1alternateDropDownList.DataBind();

        DataSet ds15 = Queries2.LoadCountryWithCode();
        subprofile2mobileDropDownList.DataSource = ds15;
        subprofile2mobileDropDownList.DataTextField = "name";
        subprofile2mobileDropDownList.DataValueField = "name";
        subprofile2mobileDropDownList.AppendDataBoundItems = true;
        subprofile2mobileDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile2mobileDropDownList.DataBind();

        DataSet ds15a = Queries2.LoadCountryWithCode();
        subprofile2alternateDropDownList.DataSource = ds15a;
        subprofile2alternateDropDownList.DataTextField = "name";
        subprofile2alternateDropDownList.DataValueField = "name";
        subprofile2alternateDropDownList.AppendDataBoundItems = true;
        subprofile2alternateDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile2alternateDropDownList.DataBind();



            DataSet sp3altcc1 = Queries2.LoadCountryWithCode();
            SubP3CCDropDownList.DataSource = sp3altcc1;
            SubP3CCDropDownList.DataTextField = "name";
            SubP3CCDropDownList.DataValueField = "name";
            SubP3CCDropDownList.AppendDataBoundItems = true;
            SubP3CCDropDownList.Items.Insert(0, new ListItem("", ""));
            SubP3CCDropDownList.DataBind();

            DataSet sp4altcc1 = Queries2.LoadCountryWithCode();
            SubP4CCDropDownList.DataSource = sp4altcc1;
            SubP4CCDropDownList.DataTextField = "name";
            SubP4CCDropDownList.DataValueField = "name";
            SubP4CCDropDownList.AppendDataBoundItems = true;
            SubP4CCDropDownList.Items.Insert(0, new ListItem("", ""));
            SubP4CCDropDownList.DataBind();





            DataSet sp3altcc = Queries2.LoadCountryWithCode();
            SubP3CCDropDownList2.DataSource = sp3altcc;
            SubP3CCDropDownList2.DataTextField = "name";
            SubP3CCDropDownList2.DataValueField = "name";
            SubP3CCDropDownList2.AppendDataBoundItems = true;
            SubP3CCDropDownList2.Items.Insert(0, new ListItem("", ""));
            SubP3CCDropDownList2.DataBind();

            DataSet sp4altcc = Queries2.LoadCountryWithCode();
            SubP4CCDropDownList2.DataSource = sp4altcc;
            SubP4CCDropDownList2.DataTextField = "name";
            SubP4CCDropDownList2.DataValueField = "name";
            SubP4CCDropDownList2.AppendDataBoundItems = true;
            SubP4CCDropDownList2.Items.Insert(0, new ListItem("", ""));
            SubP4CCDropDownList2.DataBind();

            //load nationality

            DataSet ds16 = Queries2.LoadNationality();
        primarynationalityDropDownList.DataSource = ds16;
        primarynationalityDropDownList.DataTextField = "nationality_name";
        primarynationalityDropDownList.DataValueField = "nationality_name";
        primarynationalityDropDownList.AppendDataBoundItems = true;
        primarynationalityDropDownList.Items.Insert(0, new ListItem("", ""));
        primarynationalityDropDownList.DataBind();

        DataSet ds17 = Queries2.LoadNationality();
        secondarynationalityDropDownList.DataSource = ds17;
        secondarynationalityDropDownList.DataTextField = "nationality_name";
        secondarynationalityDropDownList.DataValueField = "nationality_name";
        secondarynationalityDropDownList.AppendDataBoundItems = true;
        secondarynationalityDropDownList.Items.Insert(0, new ListItem("", ""));
        secondarynationalityDropDownList.DataBind();

        DataSet ds18 = Queries2.LoadNationality();
        subprofile1nationalityDropDownList.DataSource = ds18;
        subprofile1nationalityDropDownList.DataTextField = "nationality_name";
        subprofile1nationalityDropDownList.DataValueField = "nationality_name";
        subprofile1nationalityDropDownList.AppendDataBoundItems = true;
        subprofile1nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile1nationalityDropDownList.DataBind();

        DataSet ds19 = Queries2.LoadNationality();
        subprofile2nationalityDropDownList.DataSource = ds19;
        subprofile2nationalityDropDownList.DataTextField = "nationality_name";
        subprofile2nationalityDropDownList.DataValueField = "nationality_name";
        subprofile2nationalityDropDownList.AppendDataBoundItems = true;
        subprofile2nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
        subprofile2nationalityDropDownList.DataBind();

         DataSet sp3nat = Queries2.LoadNationality();
         SubP3NationalityDropDownList.DataSource = sp3nat;
            SubP3NationalityDropDownList.DataTextField = "nationality_name";
            SubP3NationalityDropDownList.DataValueField = "nationality_name";
            SubP3NationalityDropDownList.AppendDataBoundItems = true;
            SubP3NationalityDropDownList.Items.Insert(0, new ListItem("", ""));
            SubP3NationalityDropDownList.DataBind();

            DataSet sp4nat = Queries2.LoadNationality();
            SubP4NationalityDropDownList.DataSource = sp4nat;
            SubP4NationalityDropDownList.DataTextField = "nationality_name";
            SubP4NationalityDropDownList.DataValueField = "nationality_name";
            SubP4NationalityDropDownList.AppendDataBoundItems = true;
            SubP4NationalityDropDownList.Items.Insert(0, new ListItem("", ""));
            SubP4NationalityDropDownList.DataBind();


            //load guest status
            DataSet ds20 = Queries.LoadGuestStatus();
        gueststatusDropDownList.DataSource = ds20;
        gueststatusDropDownList.DataTextField = "Guest_Status_name";
        gueststatusDropDownList.DataValueField = "Guest_Status_name";
        gueststatusDropDownList.AppendDataBoundItems = true;
        gueststatusDropDownList.Items.Insert(0, new ListItem("", ""));
        gueststatusDropDownList.DataBind();

            DataSet ds24 = Queries2.LoadQStatus();
            QStatusDropDownList1.DataSource = ds24;
            QStatusDropDownList1.DataTextField = "Qstatus_Name";
            QStatusDropDownList1.DataValueField = "Qstatus_Name";
            QStatusDropDownList1.AppendDataBoundItems = true;
            QStatusDropDownList1.Items.Insert(0, new ListItem("", ""));
            QStatusDropDownList1.DataBind();



            DataSet ds21 = Queries2.LoadCountryName();
            AddCountryDropDownList.DataSource = ds21;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem("", ""));
            AddCountryDropDownList.DataBind();

            //load guest status
            //DataSet ds21 = Queries.LoadSalesReps();
            // DataSet ds21 = Queries2.LoadSalesReps(Queries2.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text));
            //salesrepDropDownList.DataSource = ds21;
            //salesrepDropDownList.DataTextField = "sales_rep_name";
            //salesrepDropDownList.DataValueField = "sales_rep_name";
            //salesrepDropDownList.AppendDataBoundItems = true;
            //salesrepDropDownList.Items.Insert(0, new ListItem("", ""));
            //salesrepDropDownList.DataBind();


            //load Employment status
            DataSet dsemploy = Queries.LoadEmploymentStatus();
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem("", ""));
            employmentstatusDropDownList.DataBind();

            DataSet Secondemploy = Queries.LoadEmploymentStatus();
            SecondemploymentstatusDropDownList.DataSource = Secondemploy;
            SecondemploymentstatusDropDownList.DataTextField = "Name";
            SecondemploymentstatusDropDownList.DataValueField = "Name";
            SecondemploymentstatusDropDownList.AppendDataBoundItems = true;
            SecondemploymentstatusDropDownList.Items.Insert(0, new ListItem("", ""));
            SecondemploymentstatusDropDownList.DataBind();

            /*      employmentstatusDropDownList.Items.Add("");
              employmentstatusDropDownList.Items.Add("Employee");
              employmentstatusDropDownList.Items.Add("Worker");
              employmentstatusDropDownList.Items.Add("Self Employed");
              employmentstatusDropDownList.Items.Add("Director");
              employmentstatusDropDownList.Items.Add("Office Holder");
              employmentstatusDropDownList.Items.Add("Unemployed");*/


            //load marital status
            DataSet dsmart = Queries.LoadMaritalStatus();
            MaritalStatusDropDownList.DataSource = dsmart;
            MaritalStatusDropDownList.DataTextField = "MaritalStatus";
            MaritalStatusDropDownList.DataValueField = "MaritalStatus";
            MaritalStatusDropDownList.AppendDataBoundItems = true;
            MaritalStatusDropDownList.Items.Insert(0, new ListItem("", ""));
            MaritalStatusDropDownList.DataBind();

       /*     MaritalStatusDropDownList.Items.Add("");
        MaritalStatusDropDownList.Items.Add("Single");
        MaritalStatusDropDownList.Items.Add("Married");
        MaritalStatusDropDownList.Items.Add("Divorced");
        MaritalStatusDropDownList.Items.Add("Just Friend");
        MaritalStatusDropDownList.Items.Add("Female Couple");
        MaritalStatusDropDownList.Items.Add("Male Couple");
        MaritalStatusDropDownList.Items.Add("Living Together as couple");*/

        //load title dropdown

        TextBox1.Text = DateTime.Today.ToString("yyyy/MM/dd");
            //tourdatedatepicker.Text = DateTime.Today.ToString("yyyy/MM/dd");

            DataSet dsptitle = Queries2.LoadSalutations(office);
            primarytitleDropDownList.DataSource = dsptitle;
            primarytitleDropDownList.DataTextField = "Salutation";
            primarytitleDropDownList.DataValueField = "Salutation";
            primarytitleDropDownList.AppendDataBoundItems = true;
            primarytitleDropDownList.Items.Insert(0, new ListItem("", ""));
            primarytitleDropDownList.DataBind();

            DataSet dsstitle = Queries2.LoadSalutations(office);
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem("", ""));
            secondarytitleDropDownList.DataBind();


            DataSet dssp1title = Queries2.LoadSalutations(office);
            subprofile1titleDropDownList.DataSource = dssp1title;
            subprofile1titleDropDownList.DataTextField = "Salutation";
            subprofile1titleDropDownList.DataValueField = "Salutation";
            subprofile1titleDropDownList.AppendDataBoundItems = true;
            subprofile1titleDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile1titleDropDownList.DataBind();


            DataSet dssp2title = Queries2.LoadSalutations(office);
            subprofile2titleDropDownList.DataSource = dssp2title;
            subprofile2titleDropDownList.DataTextField = "Salutation";
            subprofile2titleDropDownList.DataValueField = "Salutation";
            subprofile2titleDropDownList.AppendDataBoundItems = true;
            subprofile2titleDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile2titleDropDownList.DataBind();

            DataSet dssp3title = Queries2.LoadSalutations(office);
            SubP3TitleDropDownList.DataSource = dssp3title;
            SubP3TitleDropDownList.DataTextField = "Salutation";
            SubP3TitleDropDownList.DataValueField = "Salutation";
            SubP3TitleDropDownList.AppendDataBoundItems = true;
            SubP3TitleDropDownList.Items.Insert(0, new ListItem("", ""));
            SubP3TitleDropDownList.DataBind();

            DataSet dssp4title = Queries2.LoadSalutations(office);
            SubP4TitleDropDownList.DataSource = dssp4title;
            SubP4TitleDropDownList.DataTextField = "Salutation";
            SubP4TitleDropDownList.DataValueField = "Salutation";
            SubP4TitleDropDownList.AppendDataBoundItems = true;
            SubP4TitleDropDownList.Items.Insert(0, new ListItem("", ""));
            SubP4TitleDropDownList.DataBind();


            //load gift

            DataSet dsgift1 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList.DataSource = dsgift1;
            giftoptionDropDownList.DataTextField = "item";
            giftoptionDropDownList.DataValueField = "item";
            giftoptionDropDownList.AppendDataBoundItems = true;
            giftoptionDropDownList.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList.DataBind();

            DataSet dsgift2 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList2.DataSource = dsgift2;
            giftoptionDropDownList2.DataTextField = "item";
            giftoptionDropDownList2.DataValueField = "item";
            giftoptionDropDownList2.AppendDataBoundItems = true;
            giftoptionDropDownList2.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList2.DataBind();


            DataSet dsgift3 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList3.DataSource = dsgift3;
            giftoptionDropDownList3.DataTextField = "item";
            giftoptionDropDownList3.DataValueField = "item";
            giftoptionDropDownList3.AppendDataBoundItems = true;
            giftoptionDropDownList3.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList3.DataBind();

            DataSet dsgift4 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList4.DataSource = dsgift4;
            giftoptionDropDownList4.DataTextField = "item";
            giftoptionDropDownList4.DataValueField = "item";
            giftoptionDropDownList4.AppendDataBoundItems = true;
            giftoptionDropDownList4.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList4.DataBind();

            DataSet dsgift5 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList5.DataSource = dsgift5;
            giftoptionDropDownList5.DataTextField = "item";
            giftoptionDropDownList5.DataValueField = "item";
            giftoptionDropDownList5.AppendDataBoundItems = true;
            giftoptionDropDownList5.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList5.DataBind();

            DataSet dsgift6 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList6.DataSource = dsgift6;
            giftoptionDropDownList6.DataTextField = "item";
            giftoptionDropDownList6.DataValueField = "item";
            giftoptionDropDownList6.AppendDataBoundItems = true;
            giftoptionDropDownList6.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList6.DataBind();

            DataSet dsgift7 = Queries2.LoadGiftOption(office);
            giftoptionDropDownList7.DataSource = dsgift7;
            giftoptionDropDownList7.DataTextField = "item";
            giftoptionDropDownList7.DataValueField = "item";
            giftoptionDropDownList7.AppendDataBoundItems = true;
            giftoptionDropDownList7.Items.Insert(0, new ListItem("", ""));
            giftoptionDropDownList7.DataBind();



            DataSet recep = Queries2.LoadRecept();

            ReceptionistDropDownList.DataSource = recep;
            ReceptionistDropDownList.DataTextField = "name";
            ReceptionistDropDownList.DataValueField = "Recep_ID";
            ReceptionistDropDownList.AppendDataBoundItems = true;
            ReceptionistDropDownList.Items.Insert(0, new ListItem("", ""));
            ReceptionistDropDownList.DataBind();



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


            //DataSet ds22 = Queries.LoadSalesReps(office);
            //salesrepDropDownList.DataSource = ds22;
            //salesrepDropDownList.DataTextField = "sales_rep_name";
            //salesrepDropDownList.DataValueField = "sales_rep_name";
            //salesrepDropDownList.AppendDataBoundItems = true;
            //salesrepDropDownList.Items.Insert(0, new ListItem("", ""));
            //salesrepDropDownList.DataBind();



            /*    primarytitleDropDownList.Items.Add("");
            primarytitleDropDownList.Items.Add("Mr");
            primarytitleDropDownList.Items.Add("Ms");
            primarytitleDropDownList.Items.Add("Mrs");
            primarytitleDropDownList.Items.Add("Adv");
            primarytitleDropDownList.Items.Add("Dr");


            secondarytitleDropDownList.Items.Add("");
            secondarytitleDropDownList.Items.Add("Mr");
            secondarytitleDropDownList.Items.Add("Ms");
            secondarytitleDropDownList.Items.Add("Mrs");
            secondarytitleDropDownList.Items.Add("Adv");
            secondarytitleDropDownList.Items.Add("Dr");


            subprofile1titleDropDownList.Items.Add("");
            subprofile1titleDropDownList.Items.Add("Mr");
            subprofile1titleDropDownList.Items.Add("Ms");
            subprofile1titleDropDownList.Items.Add("Mrs");
            subprofile1titleDropDownList.Items.Add("Adv");
            subprofile1titleDropDownList.Items.Add("Dr");

            subprofile2titleDropDownList.Items.Add("");
            subprofile2titleDropDownList.Items.Add("Mr");
            subprofile2titleDropDownList.Items.Add("Ms");
            subprofile2titleDropDownList.Items.Add("Mrs");
            subprofile2titleDropDownList.Items.Add("Adv");
            subprofile2titleDropDownList.Items.Add("Dr");*/
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
           

            //display username
            string user = CreatedByTextBox.Text;

            string office = Queries.GetOffice(user);
            int year = DateTime.Now.Year;


            //ProfileIDTextBox.Text = Queries.GetProfileID(office);// VenueCountryDropDownList.SelectedItem.Text);
            string PID = Queries.GetProfileID(office);
            int PCount = Queries2.CheckProfileID(PID);

            while (PCount != 0)
            {
                PID = Queries.GetProfileID(office);
                PCount = Queries2.CheckProfileID(PID);
            }

            ProfileIDo = PID;
            int update = Queries.UpdateProfileValue(office, year);

            string VPID = TextVPID.Text;
            //get office of user
            
            //venue details

            string createdby = CreatedByTextBox.Text;
            string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
            string reception = ReceptionistDropDownList.SelectedItem.Text;
            //Request.Form[AgentCodeDropDownList.UniqueID];
            string venue = Request.Form[VenueDropDownList.UniqueID];
            string venuegroup = Request.Form[GroupVenueDropDownList.UniqueID];
            string mktg = Request.Form[MarketingPrgmDropDownList.UniqueID];

            string agents, agentcode, leadsource,prearrival;



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

            //member details

            string membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno1 = Memno1TextBox.Text;
            string membertype2 = MemType2DropDownList.SelectedItem.Text;
            string memno2 = Memno2TextBox.Text;

            string employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
            string Secondemploymentstatus = SecondemploymentstatusDropDownList.SelectedItem.Text;
            string maritalstatus = MaritalStatusDropDownList.SelectedItem.Text;
            string livingyrs = livingyrsTextBox.Text;

            string regTerms, regTerms2;
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

            int profile = Queries2.InsertProfile(PID, DateTime.Now, createdby, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, office, commentTextBox.Text, "", "", "", reception, "", regTerms, VPID, "", regTerms2, Secondemploymentstatus,leadsource,prearrival);
            string log1 = "Profile Details:" + " " + "Profile ID:" + PID + "," + "Created date:" + TextBox1.Text + "," + createdby + "," + "venue country:" + venuecountry + "," + "Venue:" + venue + "," + "Venue Group:" + venuegroup + "," + "mktg prgm:" + mktg + "," + "Agent:" + agents + "," + "Agent Code:" + agentcode + "," + "membertype1:" + membertype1 + "," + "memno1:" + memno1 + "," + "membertype2:" + membertype2 + "," + "memno2:" + memno2 + "," + "Employmentstatus:" + employmentstatus + "," + "Maritalstatus:" + maritalstatus + "," + "Living Yrs:" + livingyrs + "," + "Office:" + office + "," + "Comments:" + commentTextBox.Text + "," + "Reception:" + reception + "," + "VP_ID:" + VPID + "," + "reg term1:" + regTerms + "," + "reg term2:" + regTerms2 + "," + "Secondemploymentstatus:" + Secondemploymentstatus;
            int insertlog1 = Queries2.InsertContractLogs(PID, "", log1, "ProfileMain", user, DateTime.Now.ToString());




            //int profile = Queries2.InsertProfile(PID, DateTime.Now, createdby, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, office, commentTextBox.Text, "", "", "", reception, "", regTerms, VPID, "");
            //string log1 = "Profile Details:" + " " + "Profile ID:" + PID + "," + "Created date:" + TextBox1.Text + "," + createdby + "," + "venue country:" + venuecountry + "," + "Venue:" + venue + "," + "Venue Group:" + venuegroup + "," + "mktg prgm:" + mktg + "," + "Agent:" + agents + "," + "Agent Code:" + agentcode + "," + "membertype1:" + membertype1 + "," + "memno1:" + memno1 + "," + "membertype2:" + membertype2 + "," + "memno2:" + memno2 + "," + "Employmentstatus:" + employmentstatus + "," + "Maritalstatus:" + maritalstatus + "," + "Living Yrs:" + livingyrs + "," + "Office:" + office + "," + "Comments:" + commentTextBox.Text + "," + "Reception:" + reception + "," + "VP_ID:" + VPID;
            //int insertlog1 = Queries2.InsertContractLogs(PID, "", log1, "ProfileMain", user, DateTime.Now.ToString());
            

            //primary profile

            string primarytitle = primarytitleDropDownList.SelectedItem.Text;
            string primaryfname = pfnameTextBox.Text;

           // if(primaryfname == "")
           // {
                //MessageBox.Show("please enter valid name");
               // return false;
           // }
            string primaylname = plnameTextBox.Text;
            string primarydob = pdobdatepicker.Text;
            string tprimarydob;


           // DateTime dt;

            //DateTime dt = DateTime.ParseExact(dateString, "ddMMyyyy",CultureInfo.InvariantCulture);
           // dt.ToString("yyyyMMdd");


            // DateTime.ParseExact(primarydob, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (primarydob == "")
            {
                tprimarydob = "01-01-1900";
               // dt = DateTime.ParseExact("1900-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            else
            {
                tprimarydob = primarydob;//DateTime.ParseExact(primarydob, "ddMMyyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd");
                //tprimarydob = dt.ToString("yyyy-MM-dd");
            }
            




            string primarynationality = primarynationalityDropDownList.SelectedItem.Text;
            string primarycountry = Request.Form[PrimaryCountryDropDownList.UniqueID]; //.SelectedItem.Text;
            if (primarycountry == "")
            {
                pcc = "";
                paltrcc = "";
                pmobile = "";
                palternate = "";
            }
            else
            {
                if (primarymobileDropDownList.SelectedItem.Text=="")
                {
                    pcc = "";

                }
                else
                { //Request.Form[primarymobileDropDownList.UniqueID];
                    string pcc1;
                    pcc = primarymobileDropDownList.SelectedItem.Text;//Request.Form[primarymobileDropDownList.UniqueID];
                    pcc1 = Queries2.getcountrycodefromstring(pcc);
                    pcc = pcc1;

                 }
                if (primaryalternateDropDownList.SelectedItem.Text == "")
                {
                    paltrcc = "";
                }
                else
                {
                    string paltrcc1;
                    paltrcc = primaryalternateDropDownList.SelectedItem.Text;
                    paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                    paltrcc = paltrcc1;
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
                tsecondarydob = secondarydob;//Convert.ToDateTime(secondarydob).ToString("yyyy-MM-dd");
            }

            string secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
            string secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID]; //SecondaryCountryDropDownList.SelectedItem.Text; //Request.Form[SecondaryCountryDropDownList.UniqueID]; //
            if (secondarycountry== "" || secondarycountry==null)
            {
                scc = "";
                saltcc = "";
                smobile = "";
                salternate = "";
                secondarycountry = "";
            }
            else
            {
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
                    scc1 = Queries2.getcountrycodefromstring(scc);
                    scc = scc1;

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
                    saltcc1 = Queries2.getcountrycodefromstring(saltcc);
                    saltcc = saltcc1;
                    
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
            string tsp1dob;
            if (sp1dob == "")
            {
                tsp1dob = "1900-01-01";
            }
            else
            {
                tsp1dob = sp1dob;//Convert.ToDateTime(sp1dob).ToString("yyyy-MM-dd");
            }

            string sp1nationality = subprofile1nationalityDropDownList.SelectedItem.Text;
            string sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID]; //SubProfile1CountryDropDownList.SelectedItem.Text;
            if (sp1country== "" || sp1country == null)
            {
                sp1cc = "";
                sp1altcc = "";
                sp1mobile = "";
                sp1alternate = "";
                sp1country = "";
            }
            else
            {
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
                    sp1cc1 = Queries2.getcountrycodefromstring(sp1cc);
                    sp1cc = sp1cc1;

                }
                //sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID];

                if (subprofile1alternateDropDownList.SelectedItem.Text == "")
                {
                    sp1altcc = "";
                }
                else
                {

                    //sp1altcc = Request.Form[subprofile1alternateDropDownList.UniqueID];

                    string sp1altcc1;
                    sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];
                    sp1altcc1 = Queries2.getcountrycodefromstring(sp1altcc);
                    sp1altcc = sp1altcc1;

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


            string SubProfile1age = TextSP1Age.Text;

            //sub profile 2
            string sp2title = subprofile2titleDropDownList.SelectedItem.Text;
            string sp2fname = sp2fnameTextBox.Text;
            string sp2lname = sp2lnameTextBox.Text;
            string sp2dob = sp2dobdatepicker.Text;
            string tsp2dob;
            if (sp2dob == "")
            {
                tsp2dob = "1900-01-01";
            }
            else
            {
                tsp2dob = sp2dob;//Convert.ToDateTime(sp1dob).ToString("yyyy-MM-dd");
            }

            string sp2nationality = subprofile2nationalityDropDownList.SelectedItem.Text;
            string sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID]; //.SelectedItem.Text;
            if (sp2country == "" || sp2country == null)
            {
                sp2cc = "";
                sp2altccc = "";
                sp2mobile = "";
                sp2alternate = "";
                sp2country = "";
            }
            else
            {

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
                    sp2cc1 = Queries2.getcountrycodefromstring(sp2cc);
                    sp2cc = sp2cc1;

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
                    sp2altccc1 = Queries2.getcountrycodefromstring(sp2altccc);
                    sp2altccc = sp2altccc1;


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


            string Subprofile2 = TextSP2Age.Text;


            //sub profile3



            string sp3title = SubP3TitleDropDownList.SelectedItem.Text;
            string sp3fname = SubP3FnameTextBox.Text;
            string sp3lname = SubP3LnameTextBox.Text;
            string sp3dob = SubP3DOB.Text;
            string tsp3dob;
            if (sp3dob == "")
            {
                tsp3dob = "1900-01-01";
            }
            else
            {
                tsp3dob = sp3dob;// Convert.ToDateTime(sp3dob).ToString("yyyy-MM-dd");
            }

            string sp3nationality = SubP3NationalityDropDownList.SelectedItem.Text;
            string sp3country = Request.Form[SubP3CountryDropDownList.UniqueID]; //SubP3CountryDropDownList.SelectedItem.Text;
            if (sp3country == "" || sp3country == null)
            {
                sp3cc = "";
                sp3altcc = "";
                sp3mobile = "";
                sp3alternate = "";
                sp3country = "";
            }
            else
            {
                if (SubP3CCDropDownList.SelectedItem.Text == "")
                {
                    sp3cc = "";
                }
                else
                {
                    string sp3cc1;
                    sp3cc = SubP3CCDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];
                    sp3cc1 = Queries2.getcountrycodefromstring(sp3cc);
                    sp3cc = sp3cc1;


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
                    sp3altcc1 = Queries2.getcountrycodefromstring(sp3altcc);
                    sp3altcc = sp3altcc1;


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


            string Subprofile3 = TextSP3Age.Text;

            //sub profile4



            string sp4title = SubP4TitleDropDownList.SelectedItem.Text;
            string sp4fname = SubP4FnameTextBox.Text;
            string sp4lname = SubP4LnameTextBox.Text;
            string sp4dob = SubP4DOB.Text;
            string tsp4dob;
            if (sp4dob == "")
            {
                tsp4dob = "1900-01-01";
            }
            else
            {
                tsp4dob = sp4dob;// Convert.ToDateTime(sp4dob).ToString("yyyy-MM-dd");
            }

            string sp4nationality = SubP4NationalityDropDownList.SelectedItem.Text;
            string sp4country = Request.Form[SubP4CountryDropDownList.UniqueID]; //.SelectedItem.Text;
            if (sp4country == "" || sp4country == null)
            {
                sp4cc = "";
                sp4altcc = "";
                sp4mobile = "";
                sp4alternate = "";
                sp4country = "";
            }
            else
            {
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
                sp4cc1 = Queries2.getcountrycodefromstring(sp4cc);
                sp4cc = sp4cc1;
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
                    sp4altcc1 = Queries2.getcountrycodefromstring(sp4altcc);
                    sp4altcc = sp4altcc1;

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


            string Subprofile4 = TextSP4Age.Text;

            //address

            string address1 = address1TextBox.Text;
            string address2 = address2TextBox.Text;
            string state = stateTextBox.Text;
            string city = cityTextBox.Text;
            string pincode = pincodeTextBox.Text;
            string acountry = AddCountryDropDownList.SelectedItem.Text;
            //other details

            

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

            string QualiStatus = QStatusDropDownList1.SelectedItem.Text;

            string salesrep = Request.Form[salesrepDropDownList.UniqueID];
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

            string taxin = taxipriceInTextBox.Text;
            string taxirefin = TaxiRefInTextBox.Text;
            string taxiout = TaxiPriceOutTextBox.Text;
            string taxirefout = TaxiRefOutTextBox.Text;

            string chargeback = TextBoxChargeBack.Text;


            //= Request.Form["regTerms"];





            // int exists = Queries.ProfileExists(ProfileIDTextBox.Text);
            //if (exists == 0)
            // {


            //insert  profile
            if (VenueCountryDropDownList.SelectedIndex == 0 || VenueDropDownList.SelectedIndex == 0)
                { }
                else
                {
                    //int profile = Queries2.InsertProfile(ProfileIDTextBox.Text, DateTime.Now, createdby, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, office, commentTextBox.Text, "","","",reception,"",regTerms,VPID,"");
                    //string log1 = "Profile Details:" + " " + "Profile ID:" + ProfileIDTextBox.Text + "," + "Created date:" + TextBox1.Text + "," + createdby + "," + "venue country:" + venuecountry + "," + "Venue:" + venue + "," + "Venue Group:" + venuegroup + "," + "mktg prgm:" + mktg + "," + "Agent:" + agents + "," + "Agent Code:" + agentcode + "," + "membertype1:" + membertype1 + "," + "memno1:" + memno1 + "," + "membertype2:" + membertype2 + "," + "memno2:" + memno2 + "," + "Employmentstatus:" + employmentstatus + "," + "Maritalstatus:" + maritalstatus + "," + "Living Yrs:" + livingyrs + "," + "Office:" + office + "," + "Comments:" + commentTextBox.Text + "," + "Reception:" + reception + "," + "VP_ID:" + VPID;
                   // int insertlog1 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log1, "ProfileMain", user, DateTime.Now.ToString());

                    //insert into primary profile
                    string primaryprofileid = Queries.GetPrimaryProfileID(office);
                    int primary = Queries2.InsertPrimaryProfile(primaryprofileid, primarytitle, primaryfname, primaylname, tprimarydob, primarynationality, primarycountry, PID,primaryage,"","");
                    string log2 = "Primary details:" + " " + "primary id:" + primaryprofileid + "," + "title:" + primarytitle + "," + "Fname:" + primaryfname + "," + "Lname:" + primaylname + "," + "DOB:" + primarydob + "," + "nationality:" + primarynationality + "," + "Country:" + primarycountry + "," + "Profile ID:" + PID + "," + "Profile Primary Age:" + primaryage ;
                    int insertlog2 = Queries2.InsertContractLogs(PID, "", log2, "ProfilePrimary", user, DateTime.Now.ToString());

                //insert secondaryprofileid
                if (secondaryfname != "")
                {


                    string secondaryprofileid = Queries.GetSecondaryProfileID(office);
                    int secondary = Queries2.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, PID, secondaryage, "", "");
                    string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + PID + "," + "Profile Secondary Age:" + secondaryage;
                    int insertlog3 = Queries2.InsertContractLogs(PID, "", log3, "ProfileSecondary", user, DateTime.Now.ToString());
                    //insert address details
                }
                    string addressID = Queries.GetAddressProfileID(office);
                    int address = Queries.InsertProfileAddress(addressID, address1, address2, state, city, pincode, DateTime.Now, "", PID, acountry);
                    string log4 = "Address details:" + " " + "address  id:" + addressID + "," + "address1:" + address1 + "," + "address2:" + address2 + "," + "state:" + state + "," + "city:" + city + "," + "pincode:" + pincode + "," + "Country: " + acountry + "," + "Created Date:" + DateTime.Now + "," + "Profile ID:" + PID;
                    int insertlog4 = Queries2.InsertContractLogs(PID, "", log4, "ProfileAddress", user, DateTime.Now.ToString());
                //insert into sub profile1

                if (sp1fname != "")
                {
                    string subprofile1id = Queries.GetSubProfile1ID(office);
                    int subprofielid = Queries2.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, PID, SubProfile1age);
                    string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + PID + "," + "Sub Profile 1 Age:" + SubProfile1age;
                    int insertlog5 = Queries2.InsertContractLogs(PID, "", log5, "ProfileSubProfie1", user, DateTime.Now.ToString());
                }
                //insert into sub profile2

                if (sp2fname != "")
                {
                    string subprofile2id = Queries.GetSubProfile2ID(office);
                    int subprofielid2 = Queries2.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, PID, Subprofile2);
                    string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + PID + "," + "Sub Profile 2 Age:" + Subprofile2;
                    int insertlog6 = Queries2.InsertContractLogs(PID, "", log6, "ProfileSubProfie2", user, DateTime.Now.ToString());

                }
                    if (sp3fname != "")
                    {
                        string subprofile3id = Queries.GetSubProfile3ID(office);
                        int subprofielid3 = Queries2.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, PID, Subprofile3);
                        string log11 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + PID + "," + "Sub Profile 3 Age:" + Subprofile3; 
                        int insertlog11 = Queries2.InsertContractLogs(PID, "", log11, "ProfileSubProfie2", user, DateTime.Now.ToString());
                    }

                    if (sp4fname != "")
                    {
                        string subprofile4id = Queries.GetSubProfile4ID(office);
                        int subprofielid4 = Queries2.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, tsp4dob, sp4nationality, sp4country, PID, Subprofile4);
                        string log12 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + PID + "," + "Sub Profile 4 Age:" + Subprofile4;
                        int insertlog12 = Queries2.InsertContractLogs(PID, "", log12, "ProfileSubProfie2", user, DateTime.Now.ToString());
                    }

                    //  insert phone
                    string phid = Queries.GetPhoneID(office);
                    int phone = Queries2.InsertPhone(phid, PID, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate,sp3cc,sp3mobile,sp4cc,sp4mobile,sp3altcc,sp3alternate,sp4altcc,sp4alternate,"","","","");
                    string log7 = "Phone Details:" + " " + "Phone id:" + phid + "," + "Profile id:" + PID + "," + "Primary mobile:" + pcc + "" + pmobile + "," + "primary alternate:" + paltrcc + "" + palternate + "," + "Secondary mobile:" + scc + "" + smobile + "," + "Secondary alternate:" + saltcc + "" + salternate + "," + "Subprofile1 mobile:" + sp1cc + " " + sp1mobile + "," + "Subprofile1 alternate:" + sp1altcc + "" + sp1alternate + "," + "Subprofile2 mobile:" + sp2cc + "" + sp2mobile + "," + "subprofile2 alternate:" + sp2altccc + "" + sp2alternate;
                    int insertlog7 = Queries2.InsertContractLogs(PID, "", log7, "Profilephone", user, DateTime.Now.ToString());
                    //email
                    string emid = Queries.GetEmailID(office);
                    int email = Queries.InsertEmail(emid, PID, pemail, semail, sp1email, sp2email,pemail2,semail2,sp1email2,sp2email2,sp3email,sp3email2,sp4email,sp4email2);
                    string log8 = "Email Details:" + " " + "Email id:" + emid + "," + "profile id:" + PID + "," + "Primary email:" + pemail + "," + "Secondary email:" + semail + "," + "Subprofile1 email:" + sp1email + "," + "subprofile2 email:" + sp2email + "," + "Primary email2:" + pemail2 + "," + "Secondary email2:" + semail2 + "," + "Subprofile1 email2:" + sp1email2 + "," + "subprofile2 email2:" + sp2email2 + "," + "subprofile3 email:" + sp3email + "," + "subprofile3 email2:" + sp3email2 + "," + "subprofile4 email:" + sp4email + "," + "subprofile4 email2:" + sp4email2;
                    int insertlog8 = Queries2.InsertContractLogs(PID, "", log8, "ProfileEmail", user, DateTime.Now.ToString());
                    //insert  stay details
                    string stayid = Queries.GetStayDetailsID(office);
                    int staydetails = Queries2.InsertProfileStay(stayid, resort, roomno, tarrivaldate, tdeparturedate, PID);
                    string log9 = "Stay details:" + " " + "Stay ID:" + stayid + "," + "Resort:" + resort + "," + "room#:" + roomno + "," + "Arrival date:" + arrivaldate + "," + "Departure date:" + departuredate + "," + "Profile id:" + PID;
                    int insertlog9 = Queries2.InsertContractLogs(PID, "", log9, "ProfileStaydetails", user, DateTime.Now.ToString());
                    //tour details

                    string tourid = Queries.GetTourDetailsID(office);
                    int tourdetails = Queries2.InsertTourDetails(tourid, gueststatus, salesrep, ttourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout, PID, QualiStatus, weekno);
                    string log10 = "Tour Details:" + "Tour ID:" + tourid + "," + "Guest status:" + gueststatus + "," + "Sales rep:" + salesrep + "," + "tour date:" + ttourdate + "," + "Time in:" + timeIn + "," + "Time out:" + timeOut + "," + "Taxi In:" + taxin + "," + "Taxi Ref In:" + taxirefin + "," + "taxi out:" + taxiout + "," + "taxi Ref out:" + taxirefout + "," + "Profile id:" + PID + "," + "Quali status:" + QualiStatus + "," + "Weekno:" + weekno;

                    int insertlog10 = Queries2.InsertContractLogs(PID, "", log10, "ProfileTourDetails", user, DateTime.Now.ToString());


                    if (giftoptionDropDownList.SelectedIndex != 0)
                    {
                        string giftid = Queries.GetProfileGift(office);

                    string tg1 = TextBoxGPrice1.Text;
                    if(tg1=="")
                    {
                        tg1 = "0";

                    }
                        int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList.SelectedItem.Text, vouchernoTextBox.Text, chargeback, PID, "",tg1);
                        int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                    }

                    if (giftoptionDropDownList2.SelectedIndex != 0)
                    {
                        string giftid = Queries.GetProfileGift(office);

                    string tg2 = TextBoxGPrice2.Text;
                    if (tg2 == "")
                    {
                        tg2 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList2.SelectedItem.Text, vouchernoTextBox2.Text, "", PID, "", tg2);
                        int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                    }

                    if (giftoptionDropDownList3.SelectedIndex != 0)
                    {
                        string giftid = Queries.GetProfileGift(office);

                    string tg3 = TextBoxGPrice3.Text;
                    if (tg3 == "")
                    {
                        tg3 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList3.SelectedItem.Text, vouchernoTextBox3.Text, "", PID, "", tg3);
                        int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                    }

                if (giftoptionDropDownList4.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg4 = TextBoxGPrice4.Text;
                    if (tg4 == "")
                    {
                        tg4 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList4.SelectedItem.Text, vouchernoTextBox4.Text, "", PID, "", tg4);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (giftoptionDropDownList5.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg5 = TextBoxGPrice5.Text;
                    if (tg5 == "")
                    {
                        tg5 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList5.SelectedItem.Text, vouchernoTextBox5.Text, "", PID, "", tg5);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                if (giftoptionDropDownList6.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg6 = TextBoxGPrice6.Text;
                    if (tg6 == "")
                    {
                        tg6 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList6.SelectedItem.Text, vouchernoTextBox6.Text, "", PID, "", tg6);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                if (giftoptionDropDownList7.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg7 = TextBoxGPrice7.Text;
                    if (tg7 == "")
                    {
                        tg7 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList7.SelectedItem.Text, vouchernoTextBox7.Text, "", PID, "", tg7);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                //update profile id to 1

                // int update = Queries.UpdateProfileValue(office, year);
                int updatep = Queries.UpdatePrimaryValue(office, year);
                if (secondaryfname != "")
                {
                    int updates = Queries.UpdateSecondaryValue(office, year);
                }


                if (sp1fname != "")
                {
                    int updatesp1 = Queries.UpdateSubprofile1Value(office, year);
                }

                if (sp2fname != "")
                {
                    int updatesp2 = Queries.UpdateSubprofile2Value(office, year);
                }

                if (sp3fname != "")
                    {
                        int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);
                    }
                    if (sp4fname != "")
                    {
                        int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);
                    }
                    int updateadd = Queries.UpdateAddressValue(office, year);
                    int updatestay = Queries.UpdateStayValue(office, year);
                    int updatetour = Queries.UpdateTourValue(office, year);
                    int updatephone = Queries.UpdatePhoneValue(office, year);
                    int updateemail = Queries.UpdateEmailValue(office, year);
                }

                // Response.Write("<script> $( function() {alert('Profile Created Successfully')});</script>");

                // Response.Redirect("CreateProfile.aspx", false);
                string msg = "Profile Created with ID = "+PID;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele('" + msg + "')", true);


           // }
          //  else if (exists == 1)
          //  {
               

              //  string msg = "Profile exist ";
              //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele('" + msg + "')", true);

                // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
          //  }


        }
        catch(Exception ex)
        {

            var st = new StackTrace(ex, true);
            // Get the top stack frame
            var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();

            string msg = "Error while creating profile " + ex.Message +"  "+line;
            //MessageBox.Show("Error while creating profile " + ex.Message);
            //string msg = "Details updated for Profile :" + " " + profile;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
            
            int delete = Queries2.Deleteprofileonerror(ProfileIDo);

           // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            
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
    }

    protected void MarketingPrgmDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
         
        //DataSet ds4 = Queries.LoadAgentsIVO(MarketingPrgmDropDownList.SelectedItem.Text);
        //AgentsDropDownList.DataSource = ds4;
        //AgentsDropDownList.DataTextField = "Agent_Name";
        //AgentsDropDownList.DataValueField = "Agent_Name";
        //AgentsDropDownList.AppendDataBoundItems = true;
        //AgentsDropDownList.Items.Insert(0, new ListItem("", ""));
        //AgentsDropDownList.DataBind();
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
            //using (SqlCommand cmd = new SqlCommand("select Venue_Group_Name from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "'))", con))
            using (SqlCommand cmd = new SqlCommand("select Venue2_Name from venue2 where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "') and venue2_status='Active'", con))
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
           // using (SqlCommand cmd = new SqlCommand("select Marketing_Program_Name from Marketing_Program  where Venue_Group_ID in (select Venue_Group_ID from Venue_Group where Venue_ID in (select Venue_ID from venue where Venue_Name = '" + venueid + "' and Venue_Country_ID in (select Venue_Country_ID from VenueCountry where Venue_Country_Name='" + countid + "')))", con))
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
    public static string PopulateAgentDropDownList(string markid,string venueid, string countid)
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
    public static string PopulateAgentCodeDropDownList(string markid,string agentid,string venueid)
    {
        DataTable dt = new DataTable();
        List<AgentCodeType> listRes = new List<AgentCodeType>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
        {
            // using (SqlCommand cmd = new SqlCommand("select Agent_Code from Agent_Code where Agent_id in (select Agent_ID from Agent_marketing where Agent_Name = '"+ agentid +"' and marketing_program_id in (select Marketing_Program_ID from Marketing_Program where Marketing_Program_Name='"+ markid +"'))", con))

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

                        objst2.AgentCodeTypeName = Convert.ToString(dt.Rows[i]["SCode_Name"]) ;

                        listRes.Insert(i, objst2);


                    }
                }
                JavaScriptSerializer jscript = new JavaScriptSerializer();

                return jscript.Serialize(listRes);
            }
        }
    }


    //public class CountryCodeType
    //{
    //    public string CountryCodeTypeID { get; set; }
    //    public string CountryCodeTypeName { get; set; }
    //}


    //[WebMethod]
    //public static string PopulateCountryCodeDropDownList(string Countid)
    //{
    //    DataTable dt = new DataTable();
    //    List<CountryCodeType> listRes = new List<CountryCodeType>();

    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("select Country_Code from Country where Country_Name='"+ Countid + "'", con))
    //        {
    //            con.Open();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd);
    //            da.Fill(dt);
    //            if (dt.Rows.Count > 0)
    //            {
    //                for (int i = 0; i < dt.Rows.Count; i++)
    //                {
    //                    /*objRes.Add(new resort
    //                    {
    //                        //ResortID = Convert.ToInt32(dt.Rows[i]["DeptId"]),
    //                        ResortName = dt.Rows[i]["Contract_Resort_Name"].ToString()
    //                    });*/

    //                    CountryCodeType objst2 = new CountryCodeType();

    //                    //objst2.VenueGroupTypeID = Convert.ToString(dt.Rows[i]["Venue_ID"]);

    //                    objst2.CountryCodeTypeName = Convert.ToString(dt.Rows[i]["Country_Code"]);

    //                    listRes.Insert(i, objst2);


    //                }
    //            }
    //            JavaScriptSerializer jscript = new JavaScriptSerializer();

    //            return jscript.Serialize(listRes);
    //        }
    //    }
    //}


        //nationality with Country

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
    public static string testfunc(string id)
    {
        //return "Hello "+name;
        // dostuff2(ProfileIDo);
        //return "hi";

        // MyClass myClass = new MyClass();
        // myClass.dostuff3(ProfileIDo);

        //CheckBox1.checkd;

        // Regterms1.Checked = true;

        testo = id;
        return "hi";

    }

    

    protected void Button2_Click(object sender, EventArgs e)
    {


        try
        {


            //display username
            string user = CreatedByTextBox.Text;
            string office = Queries.GetOffice(user);
            int year = DateTime.Now.Year;

            string PID = Queries.GetProfileID(office);
            int PCount = Queries2.CheckProfileID(PID);

            while (PCount != 0)
            {
                PID = Queries.GetProfileID(office);
                PCount = Queries2.CheckProfileID(PID);
            }

            ProfileIDo = PID;
            int update = Queries.UpdateProfileValue(office, year);



            //ProfileIDo = ProfileIDTextBox.Text;

            string VPID = TextVPID.Text;
            //get office of user
           
            //venue details

            string createdby = CreatedByTextBox.Text;
            string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
            string reception = ReceptionistDropDownList.SelectedItem.Text;
            //Request.Form[AgentCodeDropDownList.UniqueID];
            string venue = Request.Form[VenueDropDownList.UniqueID];
            string venuegroup = Request.Form[GroupVenueDropDownList.UniqueID];
            string mktg = Request.Form[MarketingPrgmDropDownList.UniqueID];
            //string agents = Request.Form[AgentsDropDownList.UniqueID];
           // string agentcode = Request.Form[AgentCodeDropDownList.UniqueID];


            string agents, agentcode, leadsource,prearrival;



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


            //member details

            string membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno1 = Memno1TextBox.Text;
            string membertype2 = MemType2DropDownList.SelectedItem.Text;
            string memno2 = Memno2TextBox.Text;

            string employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
            string Secondemploymentstatus = SecondemploymentstatusDropDownList.SelectedItem.Text;
            string maritalstatus = MaritalStatusDropDownList.SelectedItem.Text;
            string livingyrs = livingyrsTextBox.Text;

            string regTerms, regTerms2; //= Request.Form["regTerms"];

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

            int profile = Queries2.InsertProfile(PID, DateTime.Now, createdby, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, office, commentTextBox.Text, "", "", "", reception, "", regTerms, VPID, "",regTerms2,Secondemploymentstatus,leadsource,prearrival);
            string log1 = "Profile Details:" + " " + "Profile ID:" + PID + "," + "Created date:" + TextBox1.Text + "," + createdby + "," + "venue country:" + venuecountry + "," + "Venue:" + venue + "," + "Venue Group:" + venuegroup + "," + "mktg prgm:" + mktg + "," + "Agent:" + agents + "," + "Agent Code:" + agentcode + "," + "membertype1:" + membertype1 + "," + "memno1:" + memno1 + "," + "membertype2:" + membertype2 + "," + "memno2:" + memno2 + "," + "Employmentstatus:" + employmentstatus + "," + "Maritalstatus:" + maritalstatus + "," + "Living Yrs:" + livingyrs + "," + "Office:" + office + "," + "Comments:" + commentTextBox.Text + "," + "Reception:" + reception + "," + "VP_ID:" + VPID + "," + "reg term1:" + regTerms + "," + "reg term2:" + regTerms2 + "," + "Secondemploymentstatus:" + Secondemploymentstatus; 
            int insertlog1 = Queries2.InsertContractLogs(PID, "", log1, "ProfileMain", user, DateTime.Now.ToString());
            

            //primary profile

            string primarytitle = primarytitleDropDownList.SelectedItem.Text;
            string primaryfname = pfnameTextBox.Text;

            // if(primaryfname == "")
            // {
            //MessageBox.Show("please enter valid name");
            // return false;
            // }
            string primaylname = plnameTextBox.Text;
            string primarydob = pdobdatepicker.Text;
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
            string primarycountry = Request.Form[PrimaryCountryDropDownList.UniqueID]; //PrimaryCountryDropDownList.SelectedItem.Text;
            if (primarycountry == "" || primarycountry == null)
            {
                pcc = "";
                paltrcc = "";
                pmobile = "";
                palternate = "";
                primarycountry = "";
            }
            else
            {
                //if (primarymobileDropDownList.SelectedIndex == 0)
                //{
                //    pcc = "";

                //}
                //else
                //{Request.Form[primarymobileDropDownList.UniqueID];
                //pcc = Request.Form[primarymobileDropDownList.UniqueID];
                // primarycountry = Request.Form[PrimaryCountryDropDownList.UniqueID];
                //  }
                //if (primaryalternateDropDownList.SelectedIndex == 0)
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
                    pcc1 = Queries2.getcountrycodefromstring(pcc);
                    pcc = pcc1;

                }
                if (primaryalternateDropDownList.SelectedItem.Text == "")
                {
                    paltrcc = "";
                }
                else
                {
                    string paltrcc1;
                    paltrcc = primaryalternateDropDownList.SelectedItem.Text;
                    paltrcc1 = Queries2.getcountrycodefromstring(paltrcc);
                    paltrcc = paltrcc1;
                }


                if (pmobileTextBox.Text == "" || pmobileTextBox.Text == null)
                {
                    pmobile = "0";
                }
                else
                {
                    pmobile = pmobileTextBox.Text;
                }

                if (palternateTextBox.Text == "" || palternateTextBox.Text == null)
                {
                    palternate = "0";
                }
                else
                {
                    palternate = palternateTextBox.Text;
                }
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
            string secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID]; //.SelectedItem.Text;
            if (secondarycountry == "" || secondarycountry==null)
            {
                scc = "";
                saltcc = "";
                smobile = "";
                salternate = "";
                secondarycountry = "";
            }
            else
            {
                //if (secondarymobileDropDownList.SelectedIndex == 0)
                //{
                //    scc = "";
                //}
                //else
                //{
                // Request.Form[secondarymobileDropDownList.UniqueID];
                // scc = Request.Form[secondarymobileDropDownList.UniqueID];
                //}
                //secondarycountry = Request.Form[SecondaryCountryDropDownList.UniqueID];

                //if (secondaryalternateDropDownList.SelectedIndex == 0)
                //{
                //    saltcc = "";
                //}
                //else
                //{

                //    saltcc = Request.Form[secondaryalternateDropDownList.UniqueID];
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
                    scc = secondarymobileDropDownList.SelectedItem.Text;//Request.Form[primarymobileDropDownList.UniqueID];
                    scc1 = Queries2.getcountrycodefromstring(scc);
                    scc = scc1;

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
                    saltcc1 = Queries2.getcountrycodefromstring(saltcc);
                    saltcc = saltcc1;

                }



                if (smobileTextBox.Text == "" || smobileTextBox.Text == null)
                {
                    smobile = "0";
                }
                else
                {
                    smobile = smobileTextBox.Text;
                }
                if (salternateTextBox.Text == "" || salternateTextBox.Text == null)
                {
                    salternate = "0";
                }
                else
                {
                    salternate = salternateTextBox.Text;
                }
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
            string sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID]; //.SelectedItem.Text;
            if (sp1country == "" || sp1country == null)
            {
                sp1cc = "";
                sp1altcc = "";
                sp1mobile = "";
                sp1alternate = "";
                sp1country = "";
            }
            else
            {
                //if (subprofile1mobileDropDownList.SelectedIndex == 0)
                //{
                //    sp1cc = "";
                //}
                //else
                //{
                //Request.Form[subprofile1mobileDropDownList.UniqueID];
                //sp1cc = Request.Form[subprofile1mobileDropDownList.UniqueID];
                //}
                //sp1country = Request.Form[SubProfile1CountryDropDownList.UniqueID];

                //if (subprofile1alternateDropDownList.SelectedIndex == 0)
                //{
                //    sp1altcc = "0";
                //}
                //else
                //{

                //    sp1altcc = Request.Form[subprofile1alternateDropDownList.UniqueID];
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
                    sp1cc1 = Queries2.getcountrycodefromstring(sp1cc);
                    sp1cc = sp1cc1;

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
                    sp1altcc1 = Queries2.getcountrycodefromstring(sp1altcc);
                    sp1altcc = sp1altcc1;

                }



                if (sp1mobileTextBox.Text == "" || sp1mobileTextBox.Text == null)
                {
                    sp1mobile = "0";
                }
                else
                {
                    sp1mobile = sp1mobileTextBox.Text;
                }
                if (sp1alternateTextBox.Text == "" || sp1alternateTextBox.Text == null)
                {
                    sp1alternate = "0";
                }
                else
                {
                    sp1alternate = sp1alternateTextBox.Text;
                }
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


            string SubProfile1age = TextSP1Age.Text;

            //sub profile 2
            string sp2title = subprofile2titleDropDownList.SelectedItem.Text;
            string sp2fname = sp2fnameTextBox.Text;
            string sp2lname = sp2lnameTextBox.Text;
            string sp2dob = sp2dobdatepicker.Text;
            string tsp2dob;
            if (sp2dob == "" )
            {
                tsp2dob = "1900-01-01";
            }
            else
            {
                tsp2dob = sp2dob;// Convert.ToDateTime(sp1dob).ToString("yyyy-MM-dd");
            }

            string sp2nationality = subprofile2nationalityDropDownList.SelectedItem.Text;
            string sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID];// SubProfile2CountryDropDownList.SelectedItem.Text;
            if (sp2country == "" || sp2country == null)
            {
                sp2cc = "";
                sp2altccc = "";
                sp2mobile = "";
                sp2alternate = "";
                sp2country = "";
            }
            else
            {

                //if (subprofile2mobileDropDownList.SelectedIndex == 0)
                //{
                //    sp2cc = "";
                //}
                //else
                //{
                // Request.Form[subprofile2mobileDropDownList.UniqueID];
                //sp2cc = Request.Form[subprofile2mobileDropDownList.UniqueID];
                //}
                //sp2country = Request.Form[SubProfile2CountryDropDownList.UniqueID];

                //if (subprofile2alternateDropDownList.SelectedIndex == 0)
                //{
                //    sp2altccc = "";
                //}
                //else
                //{

                //    sp2altccc = Request.Form[subprofile2alternateDropDownList.UniqueID];
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
                    sp2cc1 = Queries2.getcountrycodefromstring(sp2cc);
                    sp2cc = sp2cc1;

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
                    sp2altccc1 = Queries2.getcountrycodefromstring(sp2altccc);
                    sp2altccc = sp2altccc1;


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


            string Subprofile2 = TextSP2Age.Text;


            //sub profile3



            string sp3title = SubP3TitleDropDownList.SelectedItem.Text;
            string sp3fname = SubP3FnameTextBox.Text;
            string sp3lname = SubP3LnameTextBox.Text;
            string sp3dob = SubP3DOB.Text;
            string tsp3dob;
            if (sp3dob == "" )
            {
                tsp3dob = "1900-01-01";
            }
            else
            {
                tsp3dob = sp3dob;// Convert.ToDateTime(sp3dob).ToString("yyyy-MM-dd");
            }

            string sp3nationality = SubP3NationalityDropDownList.SelectedItem.Text;
            string sp3country = Request.Form[SubP3CountryDropDownList.UniqueID]; //.SelectedItem.Text;
            if (sp3country == "" || sp3country == null)
            {
                sp3cc = "";
                sp3altcc = "";
                sp3mobile = "";
                sp3alternate = "";
                sp3country = "";
            }
            else
            {
                //if (subprofile1mobileDropDownList.SelectedIndex == 0)
                //{
                //    sp1cc = "";
                //}
                //else
                //{



                //sp3cc = Request.Form[SubP3CCDropDownList.UniqueID];
                //}
                // sp3country = Request.Form[SubP3CountryDropDownList.UniqueID];

                //if (sp3cc == "")
                //{
                //    sp3altcc = "";
                //}
                //else
                //{

                //    sp3altcc = Request.Form[SubP3CCDropDownList2.UniqueID];
                //}

                if (SubP3CCDropDownList.SelectedItem.Text == "")
                {
                    sp3cc = "";
                }
                else
                {
                    string sp3cc1;
                    sp3cc = SubP3CCDropDownList.SelectedItem.Text;//Request.Form[secondaryalternateDropDownList.UniqueID];
                    sp3cc1 = Queries2.getcountrycodefromstring(sp3cc);
                    sp3cc = sp3cc1;


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
                    sp3altcc1 = Queries2.getcountrycodefromstring(sp3altcc);
                    sp3altcc = sp3altcc1;


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


            string Subprofile3 = TextSP3Age.Text;

            //sub profile4



            string sp4title = SubP4TitleDropDownList.SelectedItem.Text;
            string sp4fname = SubP4FnameTextBox.Text;
            string sp4lname = SubP4LnameTextBox.Text;
            string sp4dob = SubP4DOB.Text;
            string tsp4dob;
            if (sp4dob == "")
            {
                tsp4dob = "1900-01-01";
            }
            else
            {
                tsp4dob = sp4dob;// Convert.ToDateTime(sp4dob).ToString("yyyy-MM-dd");
            }

            string sp4nationality = SubP4NationalityDropDownList.SelectedItem.Text;
            string sp4country = Request.Form[SubP4CountryDropDownList.UniqueID]; //SubP4CountryDropDownList.SelectedItem.Text;
            if (sp4country == "" || sp3country == null)
            {
                sp4cc = "";
                sp4altcc = "";
                sp4mobile = "";
                sp4alternate = "";
                sp4country = "";
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
                // sp4country = Request.Form[SubP4CountryDropDownList.UniqueID];

                //if (sp4cc == "")
                //{
                //    sp4altcc = "";
                //}
                //else
                //{

                //    sp4altcc = Request.Form[SubP4CCDropDownList2.UniqueID];
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
                    sp4cc1 = Queries2.getcountrycodefromstring(sp4cc);
                    sp4cc = sp4cc1;
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
                    sp4altcc1 = Queries2.getcountrycodefromstring(sp4altcc);
                    sp4altcc = sp4altcc1;

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


            string Subprofile4 = TextSP4Age.Text;

            //address

            string address1 = address1TextBox.Text;
            string address2 = address2TextBox.Text;
            string state = stateTextBox.Text;
            string city = cityTextBox.Text;
            string pincode = pincodeTextBox.Text;
            string acountry = AddCountryDropDownList.SelectedItem.Text;
            //other details

           

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
                tarrivaldate = arrivaldate;// Convert.ToDateTime(arrivaldate).ToString("yyyy-MM-dd");
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

            string QualiStatus = QStatusDropDownList1.SelectedItem.Text;

            string salesrep = Request.Form[salesrepDropDownList.UniqueID];
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

            string taxin = taxipriceInTextBox.Text;
            string taxirefin = TaxiRefInTextBox.Text;
            string taxiout = TaxiPriceOutTextBox.Text;
            string taxirefout = TaxiRefOutTextBox.Text;

            string chargeback = TextBoxChargeBack.Text;

            // string lk = TextBox2.Text;





            // int exists = Queries.ProfileExists(ProfileIDTextBox.Text);
            // if (exists == 0)
            // {


            //insert  profile
            if (VenueCountryDropDownList.SelectedIndex == 0 || VenueDropDownList.SelectedIndex == 0)
                { }
                else
                {
                    //int profile = Queries.InsertProfile(PID, DateTime.Now, createdby, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, office, commentTextBox.Text, "", "", "", reception, "", regTerms, VPID,"");
                   // string log1 = "Profile Details:" + " " + "Profile ID:" + PID + "," + "Created date:" + TextBox1.Text + "," + createdby + "," + "venue country:" + venuecountry + "," + "Venue:" + venue + "," + "Venue Group:" + venuegroup + "," + "mktg prgm:" + mktg + "," + "Agent:" + agents + "," + "Agent Code:" + agentcode + "," + "membertype1:" + membertype1 + "," + "memno1:" + memno1 + "," + "membertype2:" + membertype2 + "," + "memno2:" + memno2 + "," + "Employmentstatus:" + employmentstatus + "," + "Maritalstatus:" + maritalstatus + "," + "Living Yrs:" + livingyrs + "," + "Office:" + office + "," + "Comments:" + commentTextBox.Text + "," + "Reception:" + reception + "," + "VP_ID:" + VPID;
                   // int insertlog1 = Queries2.InsertContractLogs(ProfileIDTextBox.Text, "", log1, "ProfileMain", user, DateTime.Now.ToString());

                    //insert into primary profile
                    string primaryprofileid = Queries.GetPrimaryProfileID(office);
                    int primary = Queries2.InsertPrimaryProfile(primaryprofileid, primarytitle, primaryfname, primaylname, tprimarydob, primarynationality, primarycountry, PID, primaryage, "", "");
                    string log2 = "Primary details:" + " " + "primary id:" + primaryprofileid + "," + "title:" + primarytitle + "," + "Fname:" + primaryfname + "," + "Lname:" + primaylname + "," + "DOB:" + primarydob + "," + "nationality:" + primarynationality + "," + "Country:" + primarycountry + "," + "Profile ID:" + PID + "," + "Profile Primary Age:" + primaryage;
                    int insertlog2 = Queries2.InsertContractLogs(PID, "", log2, "ProfilePrimary", user, DateTime.Now.ToString());

                //insert secondaryprofileid
                if (secondaryfname != "")
                {
                    string secondaryprofileid = Queries.GetSecondaryProfileID(office);
                    int secondary = Queries2.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, tsecondarydob, secondarynationality, secondarycountry, PID, secondaryage, "", "");
                    string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + PID + "," + "Profile Secondary Age:" + secondaryage;
                    int insertlog3 = Queries2.InsertContractLogs(PID, "", log3, "ProfileSecondary", user, DateTime.Now.ToString());
                }
                    //insert address details
                    string addressID = Queries.GetAddressProfileID(office);
                    int address = Queries.InsertProfileAddress(addressID, address1, address2, state, city, pincode, DateTime.Now, "", PID, acountry);
                    string log4 = "Address details:" + " " + "address  id:" + addressID + "," + "address1:" + address1 + "," + "address2:" + address2 + "," + "state:" + state + "," + "city:" + city + "," + "pincode:" + pincode + "," + "Country: " + acountry + "," + "Created Date:" + DateTime.Now + "," + "Profile ID:" + PID;
                    int insertlog4 = Queries2.InsertContractLogs(PID, "", log4, "ProfileAddress", user, DateTime.Now.ToString());
                //insert into sub profile1
                if (sp1fname != "")
                {
                    string subprofile1id = Queries.GetSubProfile1ID(office);
                    int subprofielid = Queries2.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, tsp1dob, sp1nationality, sp1country, PID, SubProfile1age);
                    string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + PID + "," + "Sub Profile 1 Age:" + SubProfile1age;
                    int insertlog5 = Queries2.InsertContractLogs(PID, "", log5, "ProfileSubProfie1", user, DateTime.Now.ToString());
                }
                //insert into sub profile2

                if (sp2fname != "")
                {
                    string subprofile2id = Queries.GetSubProfile2ID(office);
                    int subprofielid2 = Queries2.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, tsp2dob, sp2nationality, sp2country, PID, Subprofile2);
                    string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + PID + "," + "Sub Profile 2 Age:" + Subprofile2;
                    int insertlog6 = Queries2.InsertContractLogs(PID, "", log6, "ProfileSubProfie2", user, DateTime.Now.ToString());
                }
                    if (sp3fname != "")
                    {
                        string subprofile3id = Queries.GetSubProfile3ID(office);
                        int subprofielid3 = Queries2.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, tsp3dob, sp3nationality, sp3country, PID, Subprofile3);
                        string log11 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + PID + "," + "Sub Profile 3 Age:" + Subprofile3;
                        int insertlog11 = Queries2.InsertContractLogs(PID, "", log11, "ProfileSubProfie2", user, DateTime.Now.ToString());
                    }

                    if (sp4fname != "")
                    {
                        string subprofile4id = Queries.GetSubProfile4ID(office);
                        int subprofielid4 = Queries2.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, tsp4dob, sp4nationality, sp4country, PID, Subprofile4);
                        string log12 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + PID + "," + "Sub Profile 4 Age:" + Subprofile4;
                        int insertlog12 = Queries2.InsertContractLogs(PID, "", log12, "ProfileSubProfie2", user, DateTime.Now.ToString());
                    }

                    //  insert phone
                    string phid = Queries.GetPhoneID(office);
                    int phone = Queries2.InsertPhone(phid, PID, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3cc, sp3mobile, sp4cc, sp4mobile, sp3altcc, sp3alternate, sp4altcc, sp4alternate,"","","","");
                    string log7 = "Phone Details:" + " " + "Phone id:" + phid + "," + "Profile id:" + PID + "," + "Primary mobile:" + pcc + "" + pmobile + "," + "primary alternate:" + paltrcc + "" + palternate + "," + "Secondary mobile:" + scc + "" + smobile + "," + "Secondary alternate:" + saltcc + "" + salternate + "," + "Subprofile1 mobile:" + sp1cc + " " + sp1mobile + "," + "Subprofile1 alternate:" + sp1altcc + "" + sp1alternate + "," + "Subprofile2 mobile:" + sp2cc + "" + sp2mobile + "," + "subprofile2 alternate:" + sp2altccc + "" + sp2alternate;
                    int insertlog7 = Queries2.InsertContractLogs(PID, "", log7, "Profilephone", user, DateTime.Now.ToString());
                    //email
                    string emid = Queries.GetEmailID(office);
                    int email = Queries.InsertEmail(emid, PID, pemail, semail, sp1email, sp2email, pemail2, semail2, sp1email2, sp2email2, sp3email, sp3email2, sp4email, sp4email2);
                    string log8 = "Email Details:" + " " + "Email id:" + emid + "," + "profile id:" + PID + "," + "Primary email:" + pemail + "," + "Secondary email:" + semail + "," + "Subprofile1 email:" + sp1email + "," + "subprofile2 email:" + sp2email + "," + "Primary email2:" + pemail2 + "," + "Secondary email2:" + semail2 + "," + "Subprofile1 email2:" + sp1email2 + "," + "subprofile2 email2:" + sp2email2 + "," + "subprofile3 email:" + sp3email + "," + "subprofile3 email2:" + sp3email2 + "," + "subprofile4 email:" + sp4email + "," + "subprofile4 email2:" + sp4email2;
                    int insertlog8 = Queries2.InsertContractLogs(PID, "", log8, "ProfileEmail", user, DateTime.Now.ToString());
                    //insert  stay details
                    string stayid = Queries.GetStayDetailsID(office);
                    int staydetails = Queries2.InsertProfileStay(stayid, resort, roomno, tarrivaldate, tdeparturedate, PID);
                    string log9 = "Stay details:" + " " + "Stay ID:" + stayid + "," + "Resort:" + resort + "," + "room#:" + roomno + "," + "Arrival date:" + arrivaldate + "," + "Departure date:" + departuredate + "," + "Profile id:" + PID;
                    int insertlog9 = Queries2.InsertContractLogs(PID, "", log9, "ProfileStaydetails", user, DateTime.Now.ToString());
                    //tour details

                    string tourid = Queries.GetTourDetailsID(office);
                    int tourdetails = Queries2.InsertTourDetails(tourid, gueststatus, salesrep, ttourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout, PID, QualiStatus,weekno);
                    string log10 = "Tour Details:" + "Tour ID:" + tourid + "," + "Guest status:" + gueststatus + "," + "Sales rep:" + salesrep + "," + "tour date:" + ttourdate + "," + "Time in:" + timeIn + "," + "Time out:" + timeOut + "," + "Taxi In:" + taxin + "," + "Taxi Ref In:" + taxirefin + "," + "taxi out:" + taxiout + "," + "taxi Ref out:" + taxirefout + "," + "Profile id:" + PID + "," + "Quali status:" + QualiStatus + "," + "Weekno:" + weekno;
                    int insertlog10 = Queries2.InsertContractLogs(PID, "", log10, "ProfileTourDetails", user, DateTime.Now.ToString());



                if (giftoptionDropDownList.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg1 = TextBoxGPrice1.Text;
                    if (tg1 == "")
                    {
                        tg1 = "0";

                    }
                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList.SelectedItem.Text, vouchernoTextBox.Text, chargeback, PID, "", tg1);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (giftoptionDropDownList2.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg2 = TextBoxGPrice2.Text;
                    if (tg2 == "")
                    {
                        tg2 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList2.SelectedItem.Text, vouchernoTextBox2.Text, "", PID, "", tg2);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (giftoptionDropDownList3.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg3 = TextBoxGPrice3.Text;
                    if (tg3 == "")
                    {
                        tg3 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList3.SelectedItem.Text, vouchernoTextBox3.Text, "", PID, "", tg3);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (giftoptionDropDownList4.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg4 = TextBoxGPrice4.Text;
                    if (tg4 == "")
                    {
                        tg4 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList4.SelectedItem.Text, vouchernoTextBox4.Text, "", PID, "", tg4);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }

                if (giftoptionDropDownList5.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg5 = TextBoxGPrice5.Text;
                    if (tg5 == "")
                    {
                        tg5 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList5.SelectedItem.Text, vouchernoTextBox5.Text, "", PID, "", tg5);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                if (giftoptionDropDownList6.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg6 = TextBoxGPrice6.Text;
                    if (tg6 == "")
                    {
                        tg6 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList6.SelectedItem.Text, vouchernoTextBox6.Text, "", PID, "", tg6);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }
                if (giftoptionDropDownList7.SelectedIndex != 0)
                {
                    string giftid = Queries.GetProfileGift(office);

                    string tg7 = TextBoxGPrice7.Text;
                    if (tg7 == "")
                    {
                        tg7 = "0";

                    }

                    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList7.SelectedItem.Text, vouchernoTextBox7.Text, "", PID, "", tg7);
                    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                }



                //if (giftoptionDropDownList.SelectedIndex != 0)
                //    {
                //        string giftid = Queries.GetProfileGift(office);

                //        int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList.SelectedItem.Text, vouchernoTextBox.Text, chargeback, PID, "",TextBoxGPrice1.Text);
                //        int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                //    }

                //    if (giftoptionDropDownList2.SelectedIndex != 0)
                //    {
                //        string giftid = Queries.GetProfileGift(office);

                //        int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList2.SelectedItem.Text, vouchernoTextBox2.Text, "", PID, "", TextBoxGPrice2.Text);
                //        int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                //    }

                //    if (giftoptionDropDownList3.SelectedIndex != 0)
                //    {
                //        string giftid = Queries.GetProfileGift(office);

                //        int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList3.SelectedItem.Text, vouchernoTextBox3.Text, "", PID, "", TextBoxGPrice3.Text);
                //        int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                //    }

                //if (giftoptionDropDownList4.SelectedIndex != 0)
                //{
                //    string giftid = Queries.GetProfileGift(office);

                //    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList4.SelectedItem.Text, vouchernoTextBox4.Text, "", PID, "", TextBoxGPrice4.Text);
                //    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                //}

                //if (giftoptionDropDownList5.SelectedIndex != 0)
                //{
                //    string giftid = Queries.GetProfileGift(office);

                //    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList5.SelectedItem.Text, vouchernoTextBox5.Text, "", PID, "", TextBoxGPrice5.Text);
                //    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                //}
                //if (giftoptionDropDownList6.SelectedIndex != 0)
                //{
                //    string giftid = Queries.GetProfileGift(office);

                //    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList6.SelectedItem.Text, vouchernoTextBox6.Text, "", PID, "", TextBoxGPrice6.Text);
                //    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                //}
                //if (giftoptionDropDownList7.SelectedIndex != 0)
                //{
                //    string giftid = Queries.GetProfileGift(office);

                //    int insert = Queries2.InsertGiftOption(giftid, giftoptionDropDownList7.SelectedItem.Text, vouchernoTextBox7.Text, "", PID, "", TextBoxGPrice7.Text);
                //    int update1 = Queries.UpdateGiftValue(office, DateTime.Now.Year);
                //}

                //update profile id to 1

                // int update = Queries.UpdateProfileValue(office, year);
                int updatep = Queries.UpdatePrimaryValue(office, year);

                if(secondaryfname!="")
                {
                    int updates = Queries.UpdateSecondaryValue(office, year);
                }

                    
                if (sp1fname != "")
                {
                    int updatesp1 = Queries.UpdateSubprofile1Value(office, year);
                }

                if (sp2fname != "")
                {
                    int updatesp2 = Queries.UpdateSubprofile2Value(office, year);
                }

                    if (sp3fname != "")
                    {
                        int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);
                    }
                    if (sp4fname != "")
                    {
                        int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);
                    }
                    int updateadd = Queries.UpdateAddressValue(office, year);
                    int updatestay = Queries.UpdateStayValue(office, year);
                    int updatetour = Queries.UpdateTourValue(office, year);
                    int updatephone = Queries.UpdatePhoneValue(office, year);
                    int updateemail = Queries.UpdateEmailValue(office, year);
                }

            //string radalertscript = "<script> $( function() {alert('hi')});</script>";


            string msg = "Profile Created with ID = " + PID;
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + msg + "')", true);

            Response.Redirect("DisplayReg.aspx?Profile_ID=" + ProfileIDo,false);

           // }
           // else if (exists == 1)
           // {
                

               // string msg = "Profile exist ";
               
               // Response.Redirect("DisplayReg.aspx?Profile_ID=" + ProfileIDo);
          //  }


        }
        catch (Exception ex)
        {

            string msg = "Error while creating profile " + ex.Message;
            //MessageBox.Show("Error while creating profile " + ex.Message);
            //string msg = "Details updated for Profile :" + " " + profile;
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);

            int delete = Queries2.Deleteprofileonerror(ProfileIDo);

            // HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);

        }
    }

    protected void dostuff()
    {


        string radalertscript = "<script> $( function() {alert('hi')});</script>";
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", radalertscript);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "radalert", radalertscript, true);

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", radalertscript, false);
    }


    protected void dostuff2 (string profileID)
    {

        DataTable datatable = Queries2.loadregcard(profileID);
        var printr = "Guest Reg Form";


        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
        crystalReport.SetDataSource(datatable);

        System.IO.FileStream fs = null;
        long FileSize = 0;
        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
        //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        oDest.DiskFileName = ExportFileName;
        crystalReport.ExportOptions.DestinationOptions = oDest;
        crystalReport.Export();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("Content-Type", "application/pdf");
        string fn = "Guest Reg Form" + ".pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

        fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
        FileSize = fs.Length;
        byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
        fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
        fs.Close();
        // Response.Write("<script>$(function() {alert('hi'); });</script>");

        Response.BinaryWrite(bBuffer);
        Response.Flush();
        Response.Clear();
    }

}