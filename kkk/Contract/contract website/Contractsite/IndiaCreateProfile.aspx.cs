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
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page
{
    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate,sp3mobile,sp3alternate, sp4mobile, sp4alternate;
    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec;
    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc, sp3cc, sp3altccc, sp4cc, sp4altccc;
    static string membertype1, memno1;
    static string pemail, semail, sp1email, sp2email, sp3email, sp4email;
    static string pofficecode, pofficenum,sofficecode,sofficenum;
    static string profileid;
    protected void Page_Load(object sender, EventArgs e)
    {
       

        string user = (string)Session["username"];

        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
     
        if (!Page.IsPostBack)
        {
            // string user = "Caroline";
            CreatedByTextBox.Text = user;
            //get office of user
            string office = Queries.GetOffice(user);

            ProfileIDTextBox.ReadOnly = true;
            //ProfileIDTextBox.Text = Queries.GetProfileID(office); 

            Button3.Visible = false;
            Button4.Visible = false;
            //load values in respective dropdown listbox

            DataSet ds = Queries.LoadVenueCountry();
            VenueCountryDropDownList.DataSource = ds;
            VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
            VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
            VenueCountryDropDownList.AppendDataBoundItems = true;
            VenueCountryDropDownList.Items.Insert(0, new ListItem("", ""));
            VenueCountryDropDownList.DataBind();

            GroupVenueDropDownList.Items.Clear();
            VenueDropDownList.Items.Clear();
            MarketingPrgmDropDownList.Items.Clear();

            //load agent code
            //    DataSet ds5 = Queries.LoadAgentCode();
            //TONameDropDownList.DataSource = ds5;
            //TONameDropDownList.DataTextField = "Agent_Code_Name";
            //TONameDropDownList.DataValueField = "Agent_Code_Name";
            //TONameDropDownList.AppendDataBoundItems = true;
            //TONameDropDownList.Items.Insert(0, new ListItem("", ""));
            //TONameDropDownList.DataBind();

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
            DataSet ds8 = Queries.LoadCountryName();
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

            // load country sub profile 3
            DataSet ds11a = Queries.LoadCountryName();
            subprofile3countryDropDownList.DataSource = ds11a;
            subprofile3countryDropDownList.DataTextField = "country_name";
            subprofile3countryDropDownList.DataValueField = "country_name";
            subprofile3countryDropDownList.AppendDataBoundItems = true;
            subprofile3countryDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile3countryDropDownList.DataBind();

            // load country sub profile 4
            DataSet ds11ab = Queries.LoadCountryName();
            subprofile4countryDropDownList.DataSource = ds11ab;
            subprofile4countryDropDownList.DataTextField = "country_name";
            subprofile4countryDropDownList.DataValueField = "country_name";
            subprofile4countryDropDownList.AppendDataBoundItems = true;
            subprofile4countryDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile4countryDropDownList.DataBind();


            // load country with code for mobile nos n alternate nos
            DataSet ds12 = Queries.LoadCountryWithCode();
            primarymobileDropDownList.DataSource = ds12;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem("", ""));
            primarymobileDropDownList.DataBind();

            DataSet ds12a = Queries.LoadCountryWithCode();
            primaryalternateDropDownList.DataSource = ds12a;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem("", ""));
            primaryalternateDropDownList.DataBind();

            
            pofficecodeDropDownList.DataSource = ds12a;
            pofficecodeDropDownList.DataTextField = "name";
            pofficecodeDropDownList.DataValueField = "name";
            pofficecodeDropDownList.AppendDataBoundItems = true;
            pofficecodeDropDownList.Items.Insert(0, new ListItem("", ""));
            pofficecodeDropDownList.DataBind();

            sofficecodeDropDownList.DataSource = ds12a;
            sofficecodeDropDownList.DataTextField = "name";
            sofficecodeDropDownList.DataValueField = "name";
            sofficecodeDropDownList.AppendDataBoundItems = true;
            sofficecodeDropDownList.Items.Insert(0, new ListItem("", ""));
            sofficecodeDropDownList.DataBind();

            DataSet ds13 = Queries.LoadCountryWithCode();
            secondarymobileDropDownList.DataSource = ds13;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem("", ""));
            secondarymobileDropDownList.DataBind();

            DataSet ds13a = Queries.LoadCountryWithCode();
            secondaryalternateDropDownList.DataSource = ds13a;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem("", ""));
            secondaryalternateDropDownList.DataBind();

            DataSet ds14 = Queries.LoadCountryWithCode();
            subprofile1mobileDropDownList.DataSource = ds14;
            subprofile1mobileDropDownList.DataTextField = "name";
            subprofile1mobileDropDownList.DataValueField = "name";
            subprofile1mobileDropDownList.AppendDataBoundItems = true;
            subprofile1mobileDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile1mobileDropDownList.DataBind();
            DataSet ds14a = Queries.LoadCountryWithCode();
            subprofile1alternateDropDownList.DataSource = ds14a;
            subprofile1alternateDropDownList.DataTextField = "name";
            subprofile1alternateDropDownList.DataValueField = "name";
            subprofile1alternateDropDownList.AppendDataBoundItems = true;
            subprofile1alternateDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile1alternateDropDownList.DataBind();

            DataSet ds15 = Queries.LoadCountryWithCode();
            subprofile2mobileDropDownList.DataSource = ds15;
            subprofile2mobileDropDownList.DataTextField = "name";
            subprofile2mobileDropDownList.DataValueField = "name";
            subprofile2mobileDropDownList.AppendDataBoundItems = true;
            subprofile2mobileDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile2mobileDropDownList.DataBind();
            DataSet ds15a = Queries.LoadCountryWithCode();
            subprofile2alternateDropDownList.DataSource = ds15a;
            subprofile2alternateDropDownList.DataTextField = "name";
            subprofile2alternateDropDownList.DataValueField = "name";
            subprofile2alternateDropDownList.AppendDataBoundItems = true;
            subprofile2alternateDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile2alternateDropDownList.DataBind();

            //load nationality

            DataSet ds16 = Queries.LoadNationality();
            primarynationalityDropDownList.DataSource = ds16;
            primarynationalityDropDownList.DataTextField = "nationality_name";
            primarynationalityDropDownList.DataValueField = "nationality_name";
            primarynationalityDropDownList.AppendDataBoundItems = true;
            primarynationalityDropDownList.Items.Insert(0, new ListItem("", ""));
            primarynationalityDropDownList.DataBind();

            DataSet ds17 = Queries.LoadNationality();
            secondarynationalityDropDownList.DataSource = ds17;
            secondarynationalityDropDownList.DataTextField = "nationality_name";
            secondarynationalityDropDownList.DataValueField = "nationality_name";
            secondarynationalityDropDownList.AppendDataBoundItems = true;
            secondarynationalityDropDownList.Items.Insert(0, new ListItem("", ""));
            secondarynationalityDropDownList.DataBind();

            DataSet ds18 = Queries.LoadNationality();
            subprofile1nationalityDropDownList.DataSource = ds18;
            subprofile1nationalityDropDownList.DataTextField = "nationality_name";
            subprofile1nationalityDropDownList.DataValueField = "nationality_name";
            subprofile1nationalityDropDownList.AppendDataBoundItems = true;
            subprofile1nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile1nationalityDropDownList.DataBind();

            DataSet ds19 = Queries.LoadNationality();
            subprofile2nationalityDropDownList.DataSource = ds19;
            subprofile2nationalityDropDownList.DataTextField = "nationality_name";
            subprofile2nationalityDropDownList.DataValueField = "nationality_name";
            subprofile2nationalityDropDownList.AppendDataBoundItems = true;
            subprofile2nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile2nationalityDropDownList.DataBind();


            
            // load nationality for sub profile 3
            DataSet ds19a = Queries.LoadNationality();
            subprofile3nationalityDropDownList.DataSource = ds19a;
            subprofile3nationalityDropDownList.DataTextField = "nationality_name";
            subprofile3nationalityDropDownList.DataValueField = "nationality_name";
            subprofile3nationalityDropDownList.AppendDataBoundItems = true;
            subprofile3nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile3nationalityDropDownList.DataBind();

            // load nationality for sub profile 4
            DataSet ds19ab= Queries.LoadNationality();
            subprofile4nationalityDropDownList.DataSource = ds19ab;
            subprofile4nationalityDropDownList.DataTextField = "nationality_name";
            subprofile4nationalityDropDownList.DataValueField = "nationality_name";
            subprofile4nationalityDropDownList.AppendDataBoundItems = true;
            subprofile4nationalityDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile4nationalityDropDownList.DataBind();


            //load guest status
            DataSet ds20 = Queries.LoadGuestStatus();
            gueststatusDropDownList.DataSource = ds20;
            gueststatusDropDownList.DataTextField = "Guest_Status_name";
            gueststatusDropDownList.DataValueField = "Guest_Status_name";
            gueststatusDropDownList.AppendDataBoundItems = true;
            gueststatusDropDownList.Items.Insert(0, new ListItem("", ""));
            gueststatusDropDownList.DataBind();



            //load Employment status
            DataSet dsemploy = Queries.LoadEmploymentStatus();
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem("", ""));
            employmentstatusDropDownList.DataBind();



            //load marital status
            DataSet dsmart = Queries.LoadMaritalStatus();
            MaritalStatusDropDownList.DataSource = dsmart;
            MaritalStatusDropDownList.DataTextField = "MaritalStatus";
            MaritalStatusDropDownList.DataValueField = "MaritalStatus";
            MaritalStatusDropDownList.AppendDataBoundItems = true;
            MaritalStatusDropDownList.Items.Insert(0, new ListItem("", ""));
            MaritalStatusDropDownList.DataBind();

            //load gift

            DataSet dsgift = Queries.LoadGiftOption(office);
            giftListBox.DataSource = dsgift;
            giftListBox.DataTextField = "item";
            giftListBox.DataValueField = "item";
            giftListBox.DataBind();

            //load title dropdown

            createddateTextBox.Text = DateTime.Today.ToString("yyyy/MM/dd");

            DataSet dsptitle = Queries.LoadSalutations();
            primarytitleDropDownList.DataSource = dsptitle;
            primarytitleDropDownList.DataTextField = "Salutation";
            primarytitleDropDownList.DataValueField = "Salutation";
            primarytitleDropDownList.AppendDataBoundItems = true;
            primarytitleDropDownList.Items.Insert(0, new ListItem("", ""));
            primarytitleDropDownList.DataBind();

            DataSet dsstitle = Queries.LoadSalutations();
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem("", ""));
            secondarytitleDropDownList.DataBind();


            DataSet dssp1title = Queries.LoadSalutations();
            subprofile1titleDropDownList.DataSource = dssp1title;
            subprofile1titleDropDownList.DataTextField = "Salutation";
            subprofile1titleDropDownList.DataValueField = "Salutation";
            subprofile1titleDropDownList.AppendDataBoundItems = true;
            subprofile1titleDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile1titleDropDownList.DataBind();


            DataSet dssp2title = Queries.LoadSalutations();
            subprofile2titleDropDownList.DataSource = dssp2title;
            subprofile2titleDropDownList.DataTextField = "Salutation";
            subprofile2titleDropDownList.DataValueField = "Salutation";
            subprofile2titleDropDownList.AppendDataBoundItems = true;
            subprofile2titleDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile2titleDropDownList.DataBind();


            DataSet ds21 = Queries.LoadCountryName();
            AddCountryDropDownList.DataSource = ds21;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem("", ""));
            AddCountryDropDownList.DataBind();


            // load title for sub profile 3
            DataSet dssp3title = Queries.LoadSalutations();
            subprofile3titleDropDownList.DataSource = dssp3title;
            subprofile3titleDropDownList.DataTextField = "Salutation";
            subprofile3titleDropDownList.DataValueField = "Salutation";
            subprofile3titleDropDownList.AppendDataBoundItems = true;
            subprofile3titleDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile3titleDropDownList.DataBind();


            // load title for sub profile 4
            DataSet dssp4title = Queries.LoadSalutations();
            subprofile4titleDropDownList.DataSource = dssp4title;
            subprofile4titleDropDownList.DataTextField = "Salutation";
            subprofile4titleDropDownList.DataValueField = "Salutation";
            subprofile4titleDropDownList.AppendDataBoundItems = true;
            subprofile4titleDropDownList.Items.Insert(0, new ListItem("", ""));
            subprofile4titleDropDownList.DataBind();


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

         //   string user = CreatedByTextBox.Text;
            string user = (string)Session["username"];
            //get office of user
            string office = Queries.GetOffice(user);
            int year = DateTime.Now.Year;
            //venue details
            profileid = Queries.GetProfileID(office);
            string createdby = CreatedByTextBox.Text;
            string venuecountry = Request.Form[VenueCountryDropDownList.UniqueID];// .SelectedItem.Text;
            string venue = Request.Form[VenueDropDownList.UniqueID];//.SelectedItem.Text;
            string venuegroup = Request.Form[GroupVenueDropDownList.UniqueID];// GroupVenueDropDownList.SelectedItem.Text;
            string viewPointID = ViewPointTextBox.Text;
            if (viewPointID == "")
            {
                viewPointID = "";
            }else
            {
                viewPointID = ViewPointTextBox.Text;
            }
            string mktg = Request.Form[MarketingPrgmDropDownList.UniqueID];// MarketingPrgmDropDownList.SelectedItem.Text;
            string agents = Request.Form[AgentsDropDownList.UniqueID];// AgentsDropDownList.SelectedItem.Text;
            string agentcode = Request.Form[TONameDropDownList.UniqueID];// TONameDropDownList.SelectedItem.Text;
            string mgr;// = Request.Form[ManagerDropDownList.UniqueID];// .SelectedItem.Text;
                                                                    //member details

            //string membertype1 = MemType1DropDownList.SelectedItem.Text;
            //string memno1 = Memno1TextBox.Text;
            if (mktg == "Owner" || mktg == "OWNER")
            {
                membertype1 = MemType1DropDownList.SelectedItem.Text;
               string memno = Memno1TextBox.Text.ToUpper();
                if(memno == null)
                {
                    memno1 = "";
                }else
                {
                    memno1= Memno1TextBox.Text;
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

            if (venuegroup=="Coldline")
            {
                mgr = Request.Form[ManagerDropDownList.UniqueID];
            }
            else
            {
                mgr = agentcode;
            }
           

            //primary profile

            string primarytitle = primarytitleDropDownList.SelectedItem.Text;
            string primaryfname = pfnameTextBox.Text.ToUpper();
            string primaylname = plnameTextBox.Text.ToUpper();
            string primarydob = pdobdatepicker.Text;//Convert.ToDateTime(pdobdatepicker.Text).ToString("yyyy-MM-dd");
            string primaryage = primaryAge.Text;
            string primarynationality = primarynationalityDropDownList.SelectedItem.Text.ToUpper();
            string primarycountry = PrimaryCountryDropDownList.SelectedItem.Text.ToUpper();
            string primarylanguage;


            if (Request.Form["primarylang"] == null)
            {
                primarylanguage = "";
            }
            else
            {
                primarylanguage = Request.Form["primarylang"];

            }
            if (PrimaryCountryDropDownList.SelectedIndex == 0)
            {
                pcc = "";
                paltrcc = "";
                pmobile = "";
                palternate = "";
                pofficecode = "";pofficenum = "";
            }
            else
            {
                //if (primarymobileDropDownList.SelectedIndex == 0)
                //{
                //    pcc = "";

                //}
                //else
                //{
                pcc = primarymobileDropDownList.SelectedItem.Text;

                //  }
                if (primaryalternateDropDownList.SelectedIndex == 0)
                {
                    paltrcc = "";
                }
                else
              {

                    paltrcc = primaryalternateDropDownList.SelectedItem.Text;
                }
                if(pofficecodeDropDownList.SelectedIndex==0)
                {
			pofficecode ="";
                }
                else
                {
                    pofficecode = pofficecodeDropDownList.SelectedItem.Text;
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
                if(pofficenoTextBox.Text==""||pofficenoTextBox.Text==null)
                {
                    pofficenum = "";

                }
                else
                {
                    pofficenum = pofficenoTextBox.Text;
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



            //secondary profile

            string secondarytitle = secondarytitleDropDownList.SelectedItem.Text;
            string secondaryfname = sfnameTextBox.Text;
            string secondarylname = slnameTextBox.Text;
            string secondarydob = sdobdatepicker.Text;//Convert.ToDateTime(sdobdatepicker.Text).ToString("yyyy-MM-dd");
            string secondaryage = secondaryAge.Text;
            string secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
            string secondarycountry = SecondaryCountryDropDownList.SelectedItem.Text;


            string secondarylanguage;// = Request.Form["seclang"];
            if (Request.Form["seclang"] == null)
            {
                secondarylanguage = "";
            }
            else
            {
                secondarylanguage = Request.Form["seclang"];

            }
            if (SecondaryCountryDropDownList.SelectedIndex == 0)
            {
                scc = "";
                saltcc = "";
                smobile = "";
                salternate = "";
                sofficecode = "";sofficenum = "";
            }
            else
            {
                //if (secondarymobileDropDownList.SelectedIndex == 0)
                //{
                //    scc = "";
                //}
                //else
                //{

                scc = secondarymobileDropDownList.SelectedItem.Text;
                //}

                if (secondaryalternateDropDownList.SelectedIndex == 0)
                {
                    saltcc = "";
                }
                else
                {

                    saltcc = secondaryalternateDropDownList.SelectedItem.Text;
                }
                if (sofficecodeDropDownList.SelectedIndex == 0)
                {
			sofficecode ="";	
                }
                else
                {
                    sofficecode = sofficecodeDropDownList.SelectedItem.Text;
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
                if (sofficenoTextBox.Text==""|| sofficenoTextBox.Text == null)
                {
                    sofficenum = "";
                }
                else
                {
                    sofficenum = sofficenoTextBox.Text;
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




            //sub profile1

            string sp1title = subprofile1titleDropDownList.SelectedItem.Text;
            string sp1fname = sp1fnameTextBox.Text;
            string sp1lname = sp1lnameTextBox.Text;
            string sp1dob = sp1dobdatepicker.Text;//Convert.ToDateTime(sp1dobdatepicker.Text).ToString("yyyy-MM-dd");
            string sp1age = subProfile1Age.Text;
            string sp1nationality = subprofile1nationalityDropDownList.SelectedItem.Text;
            string sp1country = SubProfile1CountryDropDownList.SelectedItem.Text;
            if (SubProfile1CountryDropDownList.SelectedIndex == 0)
            {
                sp1cc = "";
                sp1altcc = "";
                sp1mobile = "";
                sp1alternate = "";
            }
            else
            {
                //if (subprofile1mobileDropDownList.SelectedIndex == 0)
                //{
                //    sp1cc = "";
                //}
                //else
                //{

                sp1cc = subprofile1mobileDropDownList.SelectedItem.Text;
                //}

                if (subprofile1alternateDropDownList.SelectedIndex == 0)
                {
                    sp1altcc = "";
                }
                else
                {

                    sp1altcc = subprofile1alternateDropDownList.SelectedItem.Text;
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



            //sub profile 2
            string sp2title = subprofile2titleDropDownList.SelectedItem.Text;
            string sp2fname = sp2fnameTextBox.Text;
            string sp2lname = sp2lnameTextBox.Text;
            string sp2dob = sp2dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
            string sp2age = subProfile2Age.Text;
            string sp2nationality = subprofile2nationalityDropDownList.SelectedItem.Text;
            string sp2country = SubProfile2CountryDropDownList.SelectedItem.Text;
            if (SubProfile2CountryDropDownList.SelectedIndex == 0)
            {
                sp2cc = "";
                sp2altccc = "";
                sp2mobile = "";
                sp2alternate = "";
            }
            else
            {

                //if (subprofile2mobileDropDownList.SelectedIndex == 0)
                //{
                //    sp2cc = "";
                //}
                //else
                //{

                sp2cc = subprofile2mobileDropDownList.SelectedItem.Text;
                //}

                if (subprofile2alternateDropDownList.SelectedIndex == 0)
                {
                    sp2altccc = "";
                }
                else
                {

                    sp2altccc = subprofile2alternateDropDownList.SelectedItem.Text;
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


            //sub profile 3
            string sp3title = subprofile3titleDropDownList.SelectedItem.Text;
            string sp3fname = sp3fnameTextBox.Text;
            string sp3lname = sp3lnameTextBox.Text;
            string sp3dob = sp3dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
            string sp3age = sp3ageTextBox.Text;
            string sp3nationality = subprofile3nationalityDropDownList.SelectedItem.Text;
            string sp3country = subprofile3countryDropDownList.SelectedItem.Text;
            if (subprofile3countryDropDownList.SelectedIndex == 0)
            {
                sp3cc = "";
                sp3altccc = "";
                sp3mobile = "";
                sp3alternate = "";
            }
            else
            {

                //if (subprofile2mobileDropDownList.SelectedIndex == 0)
                //{
                //    sp2cc = "";
                //}
                //else
                //{

                sp3cc = Request.Form[sp3mobileDropDownList.UniqueID]; //sp3mobileDropDownList.SelectedItem.Text;
                //}

                if (sp3altmobileDropDownList.SelectedIndex == 0)
                {
                    sp3altccc = "";
                }
                else
                {

                    sp3altccc = Request.Form[sp3mobileDropDownList.UniqueID];
                }


                if (sp3mobileTextBox.Text == "" || sp3mobileTextBox.Text == null)
                {
                    sp3mobile = "";
                }
                else
                {
                    sp3mobile = sp3mobileTextBox.Text;

                }
                if (sp3altmobileTextBox.Text == "" || sp3altmobileTextBox.Text == null)
                {
                    sp3alternate = "";

                }
                else
                {
                    sp3alternate = sp3altmobileTextBox.Text;

                }
            }
            if (sp3emailTextBox.Text == "" || sp3emailTextBox.Text == null)
            {
                sp3email = "";
            }
            else
            {
                sp3email = sp3emailTextBox.Text;
            }

            ///// end//////



            //sub profile 4
            string sp4title = subprofile4titleDropDownList.SelectedItem.Text;
            string sp4fname = sp4fnameTextBox.Text;
            string sp4lname = sp4lnameTextBox.Text;
            string sp4dob = sp4dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
            string sp4age = sp4ageTextBox.Text;
            string sp4nationality = subprofile4nationalityDropDownList.SelectedItem.Text;
            string sp4country = subprofile4countryDropDownList.SelectedItem.Text;
            if (subprofile4countryDropDownList.SelectedIndex == 0)
            {
                sp4cc = "";
                sp4altccc = "";
                sp4mobile = "";
                sp4alternate = "";
            }
            else
            {

                //if (subprofile2mobileDropDownList.SelectedIndex == 0)
                //{
                //    sp2cc = "";
                //}
                //else
                //{

                sp4cc = Request.Form[sp4mobileDropDownList.UniqueID]; //sp3mobileDropDownList.SelectedItem.Text;
                //}

                if (sp4altmobileDropDownList.SelectedIndex == 0)
                {
                    sp4altccc = "";
                }
                else
                {

                    sp4altccc = Request.Form[sp4mobileDropDownList.UniqueID];
                }


                if (sp4mobileTextBox.Text == "" || sp4mobileTextBox.Text == null)
                {
                    sp4mobile = "";
                }
                else
                {
                    sp4mobile = sp4mobileTextBox.Text;

                }
                if (sp4altmobileTextBox.Text == "" || sp4altmobileTextBox.Text == null)
                {
                    sp4alternate = "";

                }
                else
                {
                    sp4alternate = sp4altmobileTextBox.Text;

                }
            }
            if (sp4emailTextBox.Text == "" || sp4emailTextBox.Text == null)
            {
                sp4email = "";
            }
            else
            {
                sp4email = sp4emailTextBox.Text;
            }

            ///// end//////





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
                state= Request.Form[StateDropDownList.UniqueID];
            }
            string city = cityTextBox.Text;
            string pincode = pincodeTextBox.Text;
            string acountry = AddCountryDropDownList.SelectedItem.Text;

            //other details

            string employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
            string maritalstatus = MaritalStatusDropDownList.SelectedItem.Text;
            string livingyrs = livingyrsTextBox.Text;
            string maledesgination = maledesgTextBox.Text;
            string femaledesignation = femaledesgTextBox.Text;
            string photoidentity;// = Request.Form["pidentity"];
            if (Request.Form["pidentity"] == null)
            {
                photoidentity = "";
            }
            else
            {
                photoidentity = Request.Form["pidentity"];
            }
            string card;//= Request.Form["card"];
            if (Request.Form["card"] == null)
            {
                card = "";
            }
            else
            {
                card = Request.Form["card"];
            }


            //stay details
            string resort = hotelTextBox.Text;
            string roomno = roomnoTextBox.Text;
            string arrivaldate = checkindatedatepicker.Text;
            string departuredate = checkoutdatedatepicker.Text;

            //guest status

            string gueststatus = gueststatusDropDownList.SelectedItem.Text;
            string salesrep;
            string salesrep1 = Request.Form[salesrepDropDownList.UniqueID];//salesrepDropDownList.SelectedItem.Text;
            if (salesrep1 == "" || salesrep1 == null)
            {
                salesrep = "";
            }
            else
            {
                salesrep = Request.Form[salesrepDropDownList.UniqueID];
            }
            string timeIn=/*timepicker.Text;*/ deckcheckintimeTextBox.Text;
            string timeOut = deckcheckouttimeTextBox.Text;
            string tourdate;
            int wkno;
            if (tourdatedatepicker.Text==""|| tourdatedatepicker.Text==null|| tourdatedatepicker.Text=="NaN")
            {
                tourdate = "";
                wkno = 0;
            }
            else
            {
                 tourdate = tourdatedatepicker.Text;
                wkno = Queries.GetWkNumber(Convert.ToDateTime(tourdate));

            }
            
            string taxin = taxipriceInTextBox.Text;
            string taxirefin = TaxiRefInTextBox.Text;
            string taxiout = TaxiPriceOutTextBox.Text;
            string taxirefout = TaxiRefOutTextBox.Text;
            string regTerms; //= Request.Form["regTerms"];          
            if (CheckBox1.Checked)
            {

               regTerms = "Y";
            }
            else
            {
                regTerms = "N";

            }


            //int exists = Queries.ProfileExists(profileid);// (ProfileIDTextBox.Text);
            //if (exists == 0)
            //{


                //insert  profile

                if (venuecountry == "")
                { }
                else
                {
                    int profile = Queries.InsertProfile(profileid, DateTime.Now, createdby, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, office, commentsTextBox.Text, mgr, photoidentity, card,"","", regTerms, viewPointID,"");
                    string log1 = "Profile Details:" + " " + "Profile ID:" + profileid + "," + "Created date:" + createddateTextBox.Text + "," + CreatedByTextBox.Text + "," + "venue country:" + venuecountry + "," + "mktg prgm:" + mktg + "," + "Agent:" + agents + "," + "TO Name:" + agentcode + "," + "Manager:" + mgr + "," + "membertype1:" + membertype1 + "," + "memno1:" + memno1 + "," + "membertype2:" + membertype2 + "," + "memno2:" + memno2 + "," + "Employmentstatus:" + employmentstatus + "," + "Maritalstatus:" + maritalstatus + "," + "Living Yrs:" + livingyrs + "," + "Office:" + office + "," + "Comments:" + commentsTextBox.Text + "," + "Mgr:" + mgr + "," + "Photo Identity:" + photoidentity + "," + "Card Holder:" + card+","+"Registration Terms:"+ regTerms+","+"View Point ID:"+viewPointID+","+"Company Name:"+"";
                    int insertlog1 = Queries.InsertContractLogs_India(profileid, "", log1, user, DateTime.Now.ToString());
                int update = Queries.UpdateProfileValue(office, year);
                
                //insert into primary profile
                string primaryprofileid = Queries.GetPrimaryProfileID(office);
                    int primary = Queries.InsertPrimaryProfile(primaryprofileid, primarytitle, primaryfname, primaylname, primarydob, primarynationality, primarycountry, profileid, primaryage, maledesgination, primarylanguage);
                int updatep = Queries.UpdatePrimaryValue(office, year);
                
                string log2 = "Primary details:" + " " + "primary id:" + primaryprofileid + "," + "title:" + primarytitle + "," + "Fname:" + primaryfname + "," + "Lname:" + primaylname + "," + "DOB:" + primarydob + "," + "nationality:" + primarynationality + "," + "Country:" + primarycountry + "," + "Profile ID:" + profileid + "Age:" + primaryage + "," + "Designation:" + maledesgination + "," + "Languages spoken:" + primarylanguage;
                    int insertlog2 = Queries.InsertContractLogs_India(profileid, "", log2, user, DateTime.Now.ToString());


                if (secondarytitleDropDownList.SelectedIndex == 0)
                {

                }
                else
                {
                    //insert secondaryprofileid
                    string secondaryprofileid = Queries.GetSecondaryProfileID(office);
                    int secondary = Queries.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, profileid, secondaryage, femaledesignation, secondarylanguage);
                    int updates = Queries.UpdateSecondaryValue(office, year);

                    string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + profileid + "Age:" + secondaryage + "," + "Designation:" + femaledesignation + "," + "Languages spoken:" + secondarylanguage;
                    int insertlog3 = Queries.InsertContractLogs_India(profileid, "", log3, user, DateTime.Now.ToString());
                }
                    //insert address details
                    string addressID = Queries.GetAddressProfileID(office);
                    int address = Queries.InsertProfileAddress(addressID, address1, address2, state, city, pincode, DateTime.Now, "", profileid, acountry);
                int updateadd = Queries.UpdateAddressValue(office, year);
               
                string log4 = "Address details:" + " " + "address  id:" + addressID + "," + "address1:" + address1 + "," + "address2:" + address2 + "," + "state:" + state + "," + "city:" + city + "," + "pincode:" + pincode + "," + "Country: " + acountry + "," + "Created Date:" + DateTime.Now + "," + "Profile ID:" + profileid;
                    int insertlog4 = Queries.InsertContractLogs_India(profileid, "", log4, user, DateTime.Now.ToString());

                if (subprofile1titleDropDownList.SelectedIndex == 0)
                { }
                else
                {
                    //insert into sub profile1

                    string subprofile1id = Queries.GetSubProfile1ID(office);
                    int subprofielid = Queries.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, profileid, sp1age);
                    int updatesp1 = Queries.UpdateSubprofile1Value(office, year);


                    string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + profileid;
                    int insertlog5 = Queries.InsertContractLogs_India(profileid, "", log5, user, DateTime.Now.ToString());
                }
                if (subprofile2titleDropDownList.SelectedIndex == 0)
                {

                }
                else
                {


                    //insert into sub profile2

                    string subprofile2id = Queries.GetSubProfile2ID(office);
                    int subprofielid2 = Queries.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, profileid, sp2age);
                    int updatesp2 = Queries.UpdateSubprofile2Value(office, year);

                    string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + profileid;
                    int insertlog6 = Queries.InsertContractLogs_India(profileid, "", log6, user, DateTime.Now.ToString());

                }
                //insert into sub profile3
                if (subprofile3titleDropDownList.SelectedIndex == 0)
                {

                }
                else
                {
                    string subprofile3id = Queries.GetSubProfile3ID(office);
                    int subprofielid3 = Queries.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, profileid, sp3age);
                    int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);

                    string log12 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + profileid;
                    int insertlog12 = Queries.InsertContractLogs_India(profileid, "", log12, user, DateTime.Now.ToString());

                }    // insert into sub profile4
                if (subprofile4titleDropDownList.SelectedIndex == 0)
                { }
                else
                {
                    string subprofile4id = Queries.GetSubProfile4ID(office);
                    int subprofielid4 = Queries.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, profileid, sp4age);
                    int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);


                    string log13 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + profileid;
                    int insertlog13 = Queries.InsertContractLogs_India(profileid, "", log13, user, DateTime.Now.ToString());
                }

                    //  insert phone
                    string phid = Queries.GetPhoneID(office);
                    int phone = Queries.InsertPhone(phid, profileid, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate, sp3cc, sp3mobile, sp4cc, sp4mobile, sp3altccc, sp3alternate, sp4altccc, sp4alternate,pofficecode,pofficenum,sofficecode,sofficenum);
                int updatephone = Queries.UpdatePhoneValue(office, year);
              
                
               
                  string log7 = "Phone Details:" + " " + "Phone id:" + phid + "," + "Profile id:" + profileid + "," + "Primary mobile:" + pcc + "" + pmobile + "," + "primary alternate:" + paltrcc + "" + palternate + "," + "Secondary mobile:" + scc + "" + smobile + "," + "Secondary alternate:" + saltcc + "" + salternate + "," + "Subprofile1 mobile:" + sp1cc + " " + sp1mobile + "," + "Subprofile1 alternate:" + sp1altcc + "" + sp1alternate + "," + "Subprofile2 mobile:" + sp2cc + "" + sp2mobile + "," + "subprofile2 alternate:" + sp2altccc + "" + sp2alternate + "," + "Subprofile3 mobile:" + sp3cc + "" + sp3mobile + "," + "subprofile3 alternate:" + sp3altccc + "" + sp3alternate + "," + "Subprofile4 mobile:" + sp4cc + "" + sp4mobile + "," + "subprofile4 alternate:" + sp4altccc + "" + sp4alternate+","+"Primary office code:"+ pofficecode+","+"Primary Office No:"+ pofficenum+","+"Sec office code:"+ sofficecode+","+"Sec office num:"+ sofficenum;
                    int insertlog7 = Queries.InsertContractLogs_India(profileid, "", log7, user, DateTime.Now.ToString());
                    //email
                    string emid = Queries.GetEmailID(office);
                    int email = Queries.InsertEmail(emid, profileid, pemail, semail, sp1email, sp2email, "", "", "", "", sp3email, "", sp4email, "");
                    int updateemail = Queries.UpdateEmailValue(office, year);
                    string log8 = "Email Details:" + " " + "Email id:" + emid + "," + "profile id:" + profileid + "," + "Primary email:" + pemail + "," + "Secondary email:" + semail + "," + "Subprofile1 email:" + sp1email + "," + "subprofile2 email:" + sp2email + "," + "subprofile3 email:" + sp3email + "," + "subprofile4 email:" + sp4email;
                    int insertlog8 = Queries.InsertContractLogs_India(profileid, "", log8, user, DateTime.Now.ToString());

                    //insert  stay details
                    string stayid = Queries.GetStayDetailsID(office);
                    int staydetails = Queries.InsertProfileStay(stayid, resort, roomno, arrivaldate, departuredate, profileid);
                    string log9 = "Stay details:" + " " + "Stay ID:" + stayid + "," + "Resort:" + resort + "," + "room#:" + roomno + "," + "Arrival date:" + arrivaldate + "," + "Departure date:" + departuredate + "," + "Profile id:" + profileid;
                int updatestay = Queries.UpdateStayValue(office, year);
               
                int insertlog9 = Queries.InsertContractLogs_India(profileid, "", log9, user, DateTime.Now.ToString());
                    //tour details

                    string tourid = Queries.GetTourDetailsID(office);
                    int tourdetails = Queries.InsertTourDetails(tourid, gueststatus, salesrep, tourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout, profileid, "",wkno);
                      int updatetour = Queries.UpdateTourValue(office, year);
                     string log10 = "Tour Details:" + "Tour ID:" + tourid + "," + "Guest status:" + gueststatus + "," + "Sales rep:" + salesrep + "," + "tour date:" + tourdate + "," + "Time in:" + timeIn + "," + "Time out:" + timeOut + "," + "Taxi In:" + taxin + "," + "Taxi Ref In:" + taxirefin + "," + "taxi out:" + taxiout + "," + "taxi Ref out:" + taxirefout + "," + "Profile id:" + profileid;
                    int insertlog10 = Queries.InsertContractLogs_India(profileid, "", log10, user, DateTime.Now.ToString());

                    int x = 0;
                    foreach (ListItem item in giftListBox.Items)
                    {

                        string gift = item.ToString();
                        string[] giftlist = gift.Split('-');
                        string giftoption = giftlist[0];
                        string giftitem = giftlist[1];
                        if (item.Selected == true)
                        {

                            string giftid = Queries.GetProfileGift(office);

                            int insert = Queries.InsertGiftOption(giftid, giftoption, vouchernoTextBox.Text, commentTextBox.Text, profileid, giftitem);
                            int updategift = Queries.UpdateGiftValue(office, year);
                            string log11 = "gift Details:" + "gift ID:" + giftid + "," + "Gift Option:" + giftoption + "," + "Voucherno:" + vouchernoTextBox.Text + "," + "Comments:" + commentTextBox.Text + "," + "Profile id:" + profileid + "," + "Item:" + giftitem;
                            int insertlog11 = Queries.InsertContractLogs_India(profileid, "", log11, user, DateTime.Now.ToString());
                            x++;
                        }
                    }
                Button3.Visible = true;
                Button4.Visible = true;
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Profile created succesfully');", true);


                if (venuegroup == "Coldline")
                {

                    DataSet dsms = Queries2.LoadSMSReciever();



                    string text1 = dsms.Tables[0].Rows[0]["SMS_Reciever"].ToString(); //TextBox3.Text;
                    string Username = "RGBC";
                    string Password = "P7$2e_Ut";
                    string url = "http://test-contracts.karmagroup.com/Contractsite/ProfileDetailsView.aspx?Profile_ID=" + profileid;
                    string Message = "Hi " + text1 + ", Profile created, ID: " + profileid + ", " + primarytitle + " " + primaryfname + " " + primaylname + "," + primaryage + "," + maledesgination + " " + secondarytitle + " " + secondaryfname + " " + secondarylname + "," + secondaryage + "," + femaledesignation + ", Resort:" + resort+", url:"+url;
                    string MobileNo = dsms.Tables[0].Rows[0]["SMS_Mobile"].ToString();
                    string senderid = "KarmaG";


                    string msg = "http://123.63.33.43/blank/sms/user/urlsms.php?username=" + Username + "&pass=" + Password + "&senderid=" + senderid + "&dest_mobileno=" + MobileNo + "&message=" + HttpUtility.UrlEncode(Message) + "&response=Y";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "pele('" + msg + "')", true);
                }


                ProfileIDTextBox.Text = profileid;
              
            }
               
              /*  DataTable datatable = Queries2.loadregcard1(ProfileIDTextBox.Text);
                var printr = "Guest Reg form india";
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
                string fn = ProfileIDTextBox.Text + "_Guest Reg Form" + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
                string script = "<script>$(function() {alert('hi')});}</script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false); */
            //Response.Close();



            //}
            //else if (exists == 1)
            //{
            //    //Queries.ProfileView(ProfileIDTextBox.Text);

            //    DataTable datatable = Queries2.loadregcard1(profileid);
            //    var printr = "Guest Reg form india";
            //    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
            //    crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
            //    crystalReport.SetDataSource(datatable);

            //    System.IO.FileStream fs = null;
            //    long FileSize = 0;
            //    DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();
            //    //string ExportFileName = Server.MapPath("~/Copy of holiday_confirm.rpt") + "Export";
            //    string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
            //    crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            //    crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            //    oDest.DiskFileName = ExportFileName;
            //    crystalReport.ExportOptions.DestinationOptions = oDest;
            //    crystalReport.Export();
            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.AddHeader("Content-Type", "application/pdf");
            //    string fn = ProfileIDTextBox.Text + "_Guest Reg Form" + ".pdf";
            //    Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

            //    fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
            //    FileSize = fs.Length;
            //    byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
            //    fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
            //    fs.Close();
            //    Response.BinaryWrite(bBuffer);
            //    Response.Flush();
            //    //Response.Close();


            //} 

        


        }
    catch(Exception se){

            Response.Write("<script>alert('" + se.Message + "');</script>");
            int delete = Queries2.Deleteprofileonerror(ProfileIDTextBox.Text);

            //Response.Redirect("~/WebSite5/production/Dashboard.aspx");


        }


        Response.Write("<script language = javascript > window.navigate('Dashboard.aspx');</script>");

    }
    


    protected void VenueCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////get code
        //string venuecountry =Queries.GetVenueCountryCode( VenueCountryDropDownList.SelectedItem.Text);
        ////ProfileIDTextBox.ReadOnly = true;
        ////ProfileIDTextBox.Text = Queries.GetProfileID(VenueCountryDropDownList.SelectedItem.Text);

        //DataSet ds1 = Queries.LoadVenuebasedOnCountryID(venuecountry);
        //VenueDropDownList.DataSource = ds1;
        //VenueDropDownList.DataTextField = "Venue_Name";
        //VenueDropDownList.DataValueField = "Venue_Name";
        //VenueDropDownList.AppendDataBoundItems = true;
        //VenueDropDownList.Items.Insert(0, new ListItem("", ""));
        //VenueDropDownList.DataBind();
    }
    protected void VenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GroupVenueDropDownList.Items.Clear();
        ////get venue code based on venue 
        //string venuecode= Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text, (Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));

        
        //DataSet ds1 = Queries.LoadVenueGroup(venuecode);
        //GroupVenueDropDownList.DataSource = ds1;
        //GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
        //GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
        //GroupVenueDropDownList.AppendDataBoundItems = true;
        //GroupVenueDropDownList.Items.Insert(0, new ListItem("", ""));
        //GroupVenueDropDownList.DataBind();

        //load sales rep

        //DataSet ds21 = Queries.LoadSalesRep();
        //salesrepDropDownList.DataSource = ds21;
        //salesrepDropDownList.DataTextField = "sales_rep_name";
        //salesrepDropDownList.DataValueField = "sales_rep_name";
        //salesrepDropDownList.AppendDataBoundItems = true;
        //salesrepDropDownList.Items.Insert(0, new ListItem("", ""));
        //salesrepDropDownList.DataBind();

        //DataSet ds21 = Queries.LoadSalesReponVenue(VenueDropDownList.SelectedItem.Text, (Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));
        //salesrepDropDownList.DataSource = ds21;
        //salesrepDropDownList.DataTextField = "sales_rep_name";
        //salesrepDropDownList.DataValueField = "sales_rep_name";
        //salesrepDropDownList.AppendDataBoundItems = true;
        //salesrepDropDownList.Items.Insert(0, new ListItem("", ""));
        //salesrepDropDownList.DataBind();


    }

    protected void GroupVenueDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //MarketingPrgmDropDownList.Items.Clear();
        //AgentsDropDownList.Items.Clear();
        //TONameDropDownList.Items.Clear();
        //ManagerDropDownList.Items.Clear();
        ////get code
        //string venuecode = Queries.GetVenueGroupCode(GroupVenueDropDownList.SelectedItem.Text);


        //// DataSet ds1 = Queries.LoadMarketingProgram(venuecode);
        //DataSet ds1 = Queries.LoadMarketingProgramOnVenueNVGroup(VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
        //MarketingPrgmDropDownList.DataSource = ds1;
        //MarketingPrgmDropDownList.DataTextField = "Marketing_Program_Name";
        //MarketingPrgmDropDownList.DataValueField = "Marketing_Program_Name";
        //MarketingPrgmDropDownList.AppendDataBoundItems = true;
        //MarketingPrgmDropDownList.Items.Insert(0, new ListItem("", ""));
        //MarketingPrgmDropDownList.DataBind();

        ////load agents based on venue n venue group
        //DataSet ds2 = Queries.LoadAgentsOnVenue(VenueDropDownList.SelectedItem.Text);//, GroupVenueDropDownList.SelectedItem.Text);
        //AgentsDropDownList.DataSource = ds2;
        //AgentsDropDownList.DataTextField = "Agent_Name";
        //AgentsDropDownList.DataValueField = "Agent_Name";
        //AgentsDropDownList.AppendDataBoundItems = true;
        //AgentsDropDownList.Items.Insert(0, new ListItem("", ""));
        //AgentsDropDownList.DataBind();

        ////load to based on venue n venue group
        //DataSet ds3 = Queries.LoadTOOPCOnVenue(VenueDropDownList.SelectedItem.Text);//, GroupVenueDropDownList.SelectedItem.Text);
        //TONameDropDownList.DataSource = ds3;
        //TONameDropDownList.DataTextField = "to_name";
        //TONameDropDownList.DataValueField = "to_name";
        //TONameDropDownList.AppendDataBoundItems = true;
        //TONameDropDownList.Items.Insert(0, new ListItem("", ""));
        //TONameDropDownList.DataBind();



        ////load manager based on venue n venue group
        //DataSet ds4 = Queries.LoadManagersOnVenue(VenueDropDownList.SelectedItem.Text);//, GroupVenueDropDownList.SelectedItem.Text);

        //ManagerDropDownList.DataSource = ds4;
        //ManagerDropDownList.DataTextField = "Manager_Name";
        //ManagerDropDownList.DataValueField = "Manager_Name";
        //ManagerDropDownList.AppendDataBoundItems = true;
        //ManagerDropDownList.Items.Insert(0, new ListItem("", ""));
        //ManagerDropDownList.DataBind();
    }

    protected void PrimaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //primarymobileDropDownList.Items.Clear();
        //string code = Queries.GetCountryCode(PrimaryCountryDropDownList.SelectedItem.Text);
        //DataSet ds12 = Queries.LoadCountryWithCode();
        //primarymobileDropDownList.DataSource = ds12;
        //primarymobileDropDownList.DataTextField = "name";
        //primarymobileDropDownList.DataValueField = "name";
        //primarymobileDropDownList.AppendDataBoundItems = true;
        //primarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        //primarymobileDropDownList.DataBind();

    }

    protected void SecondaryCountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //secondarymobileDropDownList.Items.Clear();
        //string code = Queries.GetCountryCode(SecondaryCountryDropDownList.SelectedItem.Text);
        //DataSet ds12 = Queries.LoadCountryWithCode();
        //secondarymobileDropDownList.DataSource = ds12;
        //secondarymobileDropDownList.DataTextField = "name";
        //secondarymobileDropDownList.DataValueField = "name";
        //secondarymobileDropDownList.AppendDataBoundItems = true;
        //secondarymobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        //secondarymobileDropDownList.DataBind();
    }

    protected void SubProfile1CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //subprofile1mobileDropDownList.Items.Clear();
        //string code = Queries.GetCountryCode(SubProfile1CountryDropDownList.SelectedItem.Text);
        //DataSet ds12 = Queries.LoadCountryWithCode();
        //subprofile1mobileDropDownList.DataSource = ds12;
        //subprofile1mobileDropDownList.DataTextField = "name";
        //subprofile1mobileDropDownList.DataValueField = "name";
        //subprofile1mobileDropDownList.AppendDataBoundItems = true;
        //subprofile1mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        //subprofile1mobileDropDownList.DataBind();
    }
    protected void SubProfile2CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //subprofile2mobileDropDownList.Items.Clear();
        //string code = Queries.GetCountryCode(SubProfile2CountryDropDownList.SelectedItem.Text);
        //DataSet ds12 = Queries.LoadCountryWithCode();
        //subprofile2mobileDropDownList.DataSource = ds12;
        //subprofile2mobileDropDownList.DataTextField = "name";
        //subprofile2mobileDropDownList.DataValueField = "name";
        //subprofile2mobileDropDownList.AppendDataBoundItems = true;
        //subprofile2mobileDropDownList.Items.Insert(0, new ListItem(code, ""));
        //subprofile2mobileDropDownList.DataBind();
    }

    protected void MarketingPrgmDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
         
    //    DataSet ds4 = Queries.LoadAgents(MarketingPrgmDropDownList.SelectedItem.Text);
    //    AgentsDropDownList.DataSource = ds4;
    //    AgentsDropDownList.DataTextField = "Agent_Name";
    //    AgentsDropDownList.DataValueField = "Agent_Name";
    //    AgentsDropDownList.AppendDataBoundItems = true;
    //    AgentsDropDownList.Items.Insert(0, new ListItem("", ""));
    //    AgentsDropDownList.DataBind();
    }

    
    [WebMethod]
    
    public static string LoadVenueOnVenueCountry(string venuecountry)
    {


        //String conn = "Data Source=192.168.20.7;Initial Catalog=Contractapp;user id=sa;pwd=c10h12n2o";
        //SqlConnection sqlcon = new SqlConnection(conn);
        //sqlcon.Open();
        string JSON = "{\n \"names\":[";
        //string query = "select amount,taxValue from PointsContract where currency='" + venuecountry + "' and status='Active' ;";
        //SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = Queries.LoadVenueonVCountry(venuecountry);       
        while (reader.Read())
        {
            string venue = reader.GetString(0);
            
            JSON += "[\"" + venue + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string LoadGroupVenueOnVenue(string venue)
    {


        
        string JSON = "{\n \"names\":[";
        //string query = "select amount,taxValue from PointsContract where currency='" + venuecountry + "' and status='Active' ;";
        //SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = Queries.GetVgroupOnVenue(venue);
        while (reader.Read())
        {
            string gvenue = reader.GetString(0);

            JSON += "[\"" + gvenue + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string LoadSalesRepOnVenue(string venue,string country)
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
    public static string LoadAgents(string venue)
    {

        string JSON = "{\n \"names\":[";

       
            SqlDataReader reader = Queries.LoadAgentsOnVenue1(venue);
            while (reader.Read())
            {
                string ag = reader.GetString(0);

                JSON += "[\"" + ag + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
    
        return JSON;
    }
    [WebMethod]
    public static string LoadAgentsOnVenuegrp(string venue,string vgrp)
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
    public static string LoadTO(string venue)
    {

        string JSON = "{\n \"names\":[";


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
    [WebMethod]
    public static string LoadTOOnVenueNVGrp(string venue,string vgrp)
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
    public static string LoadMktgOnVenuenVenueGrp(string venue,string venuegrp)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadMarketingProgramOnVenueNVGroup1(venue, venuegrp);
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
    public static string LoadCountryCode(string country)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadCodeOnCountry(country);
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
    public static string LoadAllCountryCode(string country)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadAllCodeOnCountry(country);
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
    public static string getAllMemberType()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Member_type_Name from Member_Type;";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string MemeberType = reader.GetString(0);
            


            JSON += "[\"" + MemeberType + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;





    }


    [WebMethod]
    public static string LoadStates(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select s.State_Name from state s join Country c on s.State_Country=c.Country_Name where c.Country_Name='"+ country + "'";
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
		}else{
	JSON += "[\"" + "[]"+ "\"],";
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";
		}
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
        while (reader.Read())
        {

            string Type = reader.GetString(0);



            JSON += "[\"" + Type + "\"],";


        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;





    }




    protected void Button2_Click(object sender, EventArgs e)
    {
        string pweda = "karmasalesindia@2018"; //password
        string from = "karmasalesindia@gmail.com"; //email from
       string to = emailTo.Text;//"gaurav.phaldessai@karmagroup.com"; //email to
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
       // mail.To.Add(to);
        mail.From = new MailAddress(from);
        mail.Subject = emailSubject.Text;//"This is a test mail";
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = emailBody.Text;//"Test Mail.";
        string[] mail3 = to.Split(',');
        foreach (string Multiemailid in mail3)
        {
            mail.To.Add(new MailAddress(Multiemailid));
        }
        if (FileUpload1.HasFile)
        {
            HttpFileCollection hfc = Request.Files;
            for (int i = 0; i <= hfc.Count - 1; i++)
            {
                HttpPostedFile hpf = hfc[i];
                Attachment objAttachements =
                    new Attachment(hpf.InputStream,
                        hpf.FileName);
                mail.Attachments.Add(objAttachements);
            }


        }


        mail.Priority = MailPriority.High;
        SmtpClient smtp = new SmtpClient();


        smtp.UseDefaultCredentials = true;
        smtp.Credentials = new System.Net.NetworkCredential(from,pweda);
        smtp.Port = 587; 
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true; 

        try
        {
            smtp.Send(mail);
          //  Response.Write("Message Sent...");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try
        emailSubject.Text = "";
        emailBody.Text = "";
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        DataTable datatable = Queries2.loadregcard1(ProfileIDTextBox.Text);
        var printr = "Guest Reg form india";
        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
        crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt")); // path of report       
        crystalReport.SetDataSource(datatable);

        System.IO.FileStream fs = null;
        long FileSize = 0;
        DiskFileDestinationOptions oDest = new DiskFileDestinationOptions();       
        string ExportFileName = Server.MapPath("~/reports/" + printr + ".rpt") + "Export";
        crystalReport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crystalReport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        oDest.DiskFileName = ExportFileName;
        crystalReport.ExportOptions.DestinationOptions = oDest;
        crystalReport.Export();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("Content-Type", "application/pdf");
        string fn = ProfileIDTextBox.Text + "_Guest Reg Form" + ".pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

        fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
        FileSize = fs.Length;
        byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
        fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
        fs.Close();
        Response.BinaryWrite(bBuffer);
        Response.Flush();
        //string script = "<script>$(function() {alert('hi')});}</script>";

        //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}
