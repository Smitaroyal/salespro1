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
    static string office;
    static string pointsamt, pointstax, poinstcgst, pointssgst,mrgcode;
    string IGSTrate, Interestrate,mcwaiver;
    string Finance_No, documentationfee, IGST_Amount, No_Emi, emiamt;

    static string oProfile_Venue_Country, oProfile_Venue, oProfile_Group_Venue, oProfile_Marketing_Program, oProfile_Agent, oProfile_Agent_Code, oProfile_Member_Type1, oProfile_Member_Number1, oProfile_Member_Type2, oProfile_Member_Number2, oProfile_Employment_status, oProfile_Marital_status, oProfile_NOY_Living_as_couple, oOffice, oComments, oManager, ophid, ocard;
    static string oProfile_Primary_ID, oProfile_Primary_Title, oProfile_Primary_Fname, oProfile_Primary_Lname, oProfile_Primary_DOB, oProfile_Primary_Nationality, oProfile_Primary_Country, oProfile_ID, opage, oplang, opdesignation;
    static string oProfile_Secondary_ID, oProfile_Secondary_Title, oProfile_Secondary_Fname, oProfile_Secondary_Lname, oProfile_Secondary_DOB, oProfile_Secondary_Nationality, oProfile_Secondary_Country, osage, oslang, osdesignation;
    static string oSub_Profile1_ID,oSub_Profile1_Title, oSub_Profile1_Fname, oSub_Profile1_Lname, oSub_Profile1_DOB, oSub_Profile1_Nationality, oSub_Profile1_Country, osp1age;
    static string oSub_Profile2_ID, oSub_Profile2_Title, oSub_Profile2_Fname, oSub_Profile2_Lname, oSub_Profile2_DOB, oSub_Profile2_Nationality, oSub_Profile2_Country, osp2age;
    static string oSub_Profile3_ID, oSub_Profile3_Title, oSub_Profile3_Fname, oSub_Profile3_Lname, oSub_Profile3_DOB, oSub_Profile3_Nationality, oSub_Profile3_Country, osp3age;
    static string oSub_Profile4_ID, oSub_Profile4_Title, oSub_Profile4_Fname, oSub_Profile4_Lname, oSub_Profile4_DOB, oSub_Profile4_Nationality, oSub_Profile4_Country, osp4age;
    static string oProfile_Address_ID, oProfile_Address_Line1, oProfile_Address_Line2, oProfile_Address_State, oProfile_Address_Country, oProfile_Address_city, oProfile_Address_Postcode, oProfile_Address_Created_Date, oProfile_Address_Expiry_Date;
    static string oPhone_ID, oPrimary_CC, oPrimary_Mobile, oPrimary_Alt_CC, oPrimary_Alternate, oSecondary_CC, oSecondary_Mobile, oSecondary_Alt_CC, oSecondary_Alternate, oSubprofile1_CC, oSubprofile1_Mobile, oSubprofile1_Alt_CC, oSubprofile1_Alternate, oSubprofile2_CC, oSubprofile2_Mobile, oSubprofile2_Alt_CC, oSubprofile2_Alternate, oSubprofile3_CC, oSubprofile3_Mobile, oSubprofile3_Alt_CC, oSubprofile3_Alternate, oSubprofile4_CC, oSubprofile4_Mobile, oSubprofile4_Alt_CC, oSubprofile4_Alternate,opriOfficecc,opriOfficeno,osecOfficecc,osecofficeno;
    static string oEmail_ID, oPrimary_Email, oSecondary_Email, oSubprofile1_Email, oSubprofile2_Email, oSubprofile3_Email, oSubprofile4_Email;
    static string oProfile_Stay_ID, oProfile_Stay_Resort_Name, oProfile_Stay_Resort_Room_Number, oProfile_Stay_Arrival_Date, oProfile_Stay_Departure_Date;
    static string oTour_Details_ID, oTour_Details_Guest_Status, oTour_Details_Guest_Sales_Rep, oTour_Details_Tour_Date, oTour_Details_Sales_Deck_Check_In, oTour_Details_Sales_Deck_Check_Out, oTour_Details_Taxi_In_Price, oTour_Details_Taxi_In_Ref, oTour_Details_Taxi_Out_Price, oTour_Details_Taxi_Out_Ref;
    static string pmobile, palternate, smobile, salternate, sp1mobile, sp1alternate, sp2mobile, sp2alternate, sp3mobile, sp3alternate, sp4mobile, sp4alternate,priOfficeno,secOfficeno;
    static string pmobilec, palternatec, smobilec, salternatec, sp1mobilec, sp1alternatec, sp2mobilec, sp2alternatec, sp3mobilec, sp3alternatec, sp4mobilec, sp4alternatec;
    static string pcc, paltrcc, scc, saltcc, sp1cc, sp1altcc, sp2cc, sp2altccc, sp3cc, sp3altccc, sp4cc, sp4altccc,priOfficecc,secOfficecc;
    static string ocompanyname;
    static string pemail, semail, sp1email, sp2email,sp3email, sp4email;

    static string regTerms, oregTerms, tourweekno;
    static string ProfileID, contractdetailsID;
    public string getdata()
    {
        string htmlstr = "";
        SqlDataReader dr = Queries.LoadAffiliationType(office); //,currencyDropDownList.SelectedItem.Text);
        while (dr.Read())
        {

            int id = dr.GetInt32(0);
            string name = dr.GetString(1);
            double amt = dr.GetDouble(2);
            string addvalue = "dispplayvalue";
            string ca = "ca";

            htmlstr += " <input id=" + ca + "" + id + " type='checkbox' class='hello' name='aamt' onClick="  + addvalue + "() value='" + amt + "'>" + name + "";


        }

        return htmlstr;
    }
    public void LoadDocuments(string ContractDetails_ID, string office, string Finance_Details, string ContractType, string aftype, string mc, string canxcontno, string companyname,string statename)
    {
        if (mc == "Yes")
        {
            //check if id exists in othernames
            int othersid = Queries.ContractNo_OthernamesExistsA(ContractDetails_ID);
            if (othersid == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    
                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {

                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
            }
            int othersid1 = Queries.ContractNo_OthernamesExistsNone(ContractDetails_ID);
            if (othersid1 == 0)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }

                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points4MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points5MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points6MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
            }
            int othersid2 = Queries.ContractNo_OthernamesExistsB(ContractDetails_ID);
            if (othersid2 == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "Goa" || statename == "GOA")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points7MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points8MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points9MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
            }
            int othersid3 = Queries.ContractNo_OthernamesExistsS(ContractDetails_ID);
            if (othersid3 == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MCGOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points10MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points11MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points12MC(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
            }
        }
        else if (mc == "No")
        {
            //check if id exists in othernames
            int othersid = Queries.ContractNo_OthernamesExistsA(ContractDetails_ID);
            if (othersid == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();
                    if (statename == "GOA" || statename == "Goa")
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3GOA(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }

                    }
                    else
                    {
                        if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points1(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points2(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();

                        }
                        else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                        {
                            PrintPdfDropDownList.Items.Clear();
                            DataSet ds21 = Queries.LoadPrintPDFFiles_Points3(ContractType, office, club, curr, Finance_Details, aftype, mc);
                            PrintPdfDropDownList.DataSource = ds21;
                            PrintPdfDropDownList.DataTextField = "printname";
                            PrintPdfDropDownList.DataValueField = "printname";
                            PrintPdfDropDownList.AppendDataBoundItems = true;
                            PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                            PrintPdfDropDownList.DataBind();
                        }
                        else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                        {

                        }
                    }
                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points1(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points2(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points3(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points1(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points2(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points3(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
            }
            int othersid1 = Queries.ContractNo_OthernamesExistsNone(ContractDetails_ID);
            if (othersid1 == 0)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points4(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points5(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points6(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points4(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points5(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points6(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points4(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points5(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points6(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
            }
            int othersid2 = Queries.ContractNo_OthernamesExistsB(ContractDetails_ID);
            if (othersid2 == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points7(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points8(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points9(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points7(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points8(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points9(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points7(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points8(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points9(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
            }
            int othersid3 = Queries.ContractNo_OthernamesExistsS(ContractDetails_ID);
            if (othersid3 == 1)
            {
                if (ContractType == "Fractional")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Trade-In-Fractionals")
                {
                    DataSet dsp = Queries.loadtradeinfractional(ContractDetails_ID);
                    string club = dsp.Tables[0].Rows[0]["resort"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    DataSet ds21 = Queries.LoadPrintPDFFiles_Fractionals(ContractType, office, club, curr, Finance_Details);
                    PrintPdfDropDownList.DataSource = ds21;
                    PrintPdfDropDownList.DataTextField = "printname";
                    PrintPdfDropDownList.DataValueField = "printname";
                    PrintPdfDropDownList.AppendDataBoundItems = true;
                    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    PrintPdfDropDownList.DataBind();
                }
                else if (ContractType == "Points")
                {
                    DataSet dsp = Queries.LoadNewPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points10(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points11(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points12(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }

                }
                else if (ContractType == "Trade-In-Points")
                {
                    DataSet dsp = Queries.LoadTradeinPointsDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["New_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points10(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points11(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points12(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
                else if (ContractType == "Trade-In-Weeks")
                {
                    DataSet dsp = Queries.LoadTradeinWeeksDetails(ContractDetails_ID);

                    string club = dsp.Tables[0].Rows[0]["NewPointsW_Club"].ToString();
                    string curr = dsp.Tables[0].Rows[0]["Currency"].ToString();

                    if ((canxcontno == "" || canxcontno == null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points10(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname == "" || companyname == null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points11(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();

                    }
                    else if ((canxcontno == "" || canxcontno == null) && (companyname != "" || companyname != null))
                    {
                        PrintPdfDropDownList.Items.Clear();
                        DataSet ds21 = Queries.LoadPrintPDFFiles_Points12(ContractType, office, club, curr, Finance_Details, aftype, mc);
                        PrintPdfDropDownList.DataSource = ds21;
                        PrintPdfDropDownList.DataTextField = "printname";
                        PrintPdfDropDownList.DataValueField = "printname";
                        PrintPdfDropDownList.AppendDataBoundItems = true;
                        PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                        PrintPdfDropDownList.DataBind();
                    }
                    else if ((canxcontno != "" || canxcontno != null) && (companyname != "" || companyname != null))
                    {

                    }
                }
            }
        }

    }
    public void SOR_AdditionalName(string contractdetails_ID)
    {
       // string ContractdetailsID = ContractdetailsIDTextBox.Text;
        string contractno = contractnoTextBox.Text;
      
        int ik;
        string iname, iadd, istate, icountry, ipincode;
        string name, add, state, country, pincode;
        string user = (string)Session["username"];
        if (asornoTextBox.Text == "")
        {
        }
        else
        {
            int num = Convert.ToInt32(asornoTextBox.Text);
            if (SORDropDownList.SelectedItem.Text == "")
            {

            }
            else if (SORDropDownList.SelectedItem.Text == "SOR Name")
            {
                for (ik = 1; ik <= Convert.ToInt32(num); ik++)
                {
                    string id = Queries.GetContractNo_OthernamesID(officeTextBox.Text);
                    iname = "textBox1_" + ik + "1";
                    name = Request.Form[iname];
                    iadd = "textBox1_" + ik + "2";
                    add = Request.Form[iadd];
                    istate = "textBox1_" + ik + "3";
                    state = Request.Form[istate];
                    icountry = "textBox1_" + ik + "4";
                    country = Request.Form[icountry];
                    ipincode = "textBox1_" + ik + "5";
                    pincode = Request.Form[ipincode];

                    int insertrow = Queries.InsertContractNo_Othernames(id, contractnoTextBox.Text, contractdetails_ID, SORDropDownList.SelectedItem.Text, name.ToUpper(), add.ToUpper(), state.ToUpper(), country.ToUpper(), pincode, "Active", "", DateTime.Now.ToString());
                     string log5in = "SOR Details:" + "ContractdetailsID: " + contractdetails_ID + "," + "Contractno: " + contractnoTextBox.Text + "," + "Type:" + SORDropDownList.SelectedItem.Text + "," + "Name:" + name.ToUpper() + "," + "address:" + add.ToUpper() + "," + "state:" + state.ToUpper() + "," + "country:" +country.ToUpper() + "," + "postcode:" + pincode;
                     int insertlogin = Queries.InsertContractLogs_India(profileidTextBox.Text , contractdetails_ID,log5in, user, DateTime.Now.ToString());

                }



            }
            else if (SORDropDownList.SelectedItem.Text == "Additional Name")
            {
                for (ik = 1; ik <= Convert.ToInt32(num); ik++)
                {
                    string id = Queries.GetContractNo_OthernamesID(officeTextBox.Text);
                    iname = "textBox1_" + ik + "1";
                    name = Request.Form[iname];
                    iadd = "textBox1_" + ik + "2";
                    add = Request.Form[iadd];
                    istate = "textBox1_" + ik + "3";
                    state = Request.Form[istate];
                    icountry = "textBox1_" + ik + "4";
                    country = Request.Form[icountry];
                    ipincode = "textBox1_" + ik + "5";
                    pincode = Request.Form[ipincode];

                    int insertrow = Queries.InsertContractNo_Othernames(id, contractnoTextBox.Text, contractdetails_ID, SORDropDownList.SelectedItem.Text, name.ToUpper(), add.ToUpper(), state.ToUpper(), country.ToUpper(), pincode, "Active", "", DateTime.Now.ToString());
                    string log5in = "Additional Name Details:" + "ContractdetailsID: " + contractdetails_ID + "," + "Contractno: " + contractnoTextBox.Text + "," + "Type:" + SORDropDownList.SelectedItem.Text + "," + "Name:" + name.ToUpper() + "," + "address:" + add.ToUpper() + "," + "state:" + state.ToUpper() + "," + "country:" + country.ToUpper() + "," + "postcode:" + pincode;
                    int insertlogin = Queries.InsertContractLogs_India(profileidTextBox.Text, contractdetails_ID, log5in, user, DateTime.Now.ToString());
                    int updatesor = Queries.UpdateContractNo_OthernamesID(officeTextBox.Text);
                }


            }

        }

    }
    public void financebreakup(string noemi, string financeamt, string emiamt, string contractid, string ctype, string contno)
    {
        int emimonths = Convert.ToInt32(noemi);// (noemiTextBox.Text);
        double principalamt = Convert.ToDouble(financeamt);// balamtpayableTextBox.Text);
        double emiamt1 = Convert.ToDouble(emiamt);// emiamtTextBox.Text);
        int months = 12;
        int ik;
        string month, fmonth;

        if (ctype == "Fractional" || ctype == "Trade-In-Fractionals")
        {
            int interest = 11;
            for (ik = 1; ik <= emimonths; ik++)
            {

                //if contractdetails id doesnt exists then
                int exists = Queries.CheckIDExistsInFinance_Breakup(contractid);
                if (exists == 1)
                {
                    //get min principalamt
                    int ink = ik - 1;
                    double pa = Queries.GetMinPrinicipalAmt(contractid);
                    double mi = Queries.GetMinMonthlyPrincipal(contractid, ink, pa);
                    double newba = pa - mi;
                    double Yearly_interest = Math.Round((newba * interest) / 100);
                    double Monthly_Instalment = emiamt1;
                    double Installments = ik;
                    double Monthly_Interest = Math.Round(Yearly_interest / months);
                    double Monthly_Principal = Math.Round(Monthly_Instalment - Monthly_Interest);
                    fmonth = Queries.FinanceInstallmentMonthF(contractid);
                    month = Queries.FinanceInstallmentMonthStartdate(contractid);
                    int insert = Queries.InsertFinance_Breakup(contractid, contno, newba, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);
                }
                else
                {
                    double Yearly_interest = Math.Round((principalamt * interest) / 100);
                    double Monthly_Instalment = emiamt1;
                    double Installments = ik;
                    double Monthly_Interest = Math.Round(Yearly_interest / months);
                    double Monthly_Principal = Math.Round(Monthly_Instalment - Monthly_Interest);
                    //get max month from installment table
                    fmonth = Queries.FinanceInstallmentMonthStartdateNewF(contractid);
                    month = Queries.FinanceInstallmentMonthStartdateNew(contractid);
                    int insert = Queries.InsertFinance_Breakup(contractid, contno, principalamt, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);

                }

            }
        }
        else
        {
            int interest = 19;
            for (ik = 1; ik <= emimonths; ik++)
            {

                //if contractdetails id doesnt exists then
                int exists = Queries.CheckIDExistsInFinance_Breakup(contractid);
                if (exists == 1)
                {
                    //get min principalamt
                    int ink = ik - 1;
                    double pa = Queries.GetMinPrinicipalAmt(contractid);
                    double mi = Queries.GetMinMonthlyPrincipal(contractid, ink, pa);
                    double newba = pa - mi;
                    double Yearly_interest = Math.Round((newba * interest) / 100);
                    double Monthly_Instalment = emiamt1;
                    double Installments = ik;
                    double Monthly_Interest = Math.Round(Yearly_interest / months);
                    double Monthly_Principal = Math.Round(Monthly_Instalment - Monthly_Interest);
                    fmonth = Queries.FinanceInstallmentMonthF(contractid);
                    month = Queries.FinanceInstallmentMonthStartdate(contractid);
                    int insert = Queries.InsertFinance_Breakup(contractid, contno, newba, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);
                }
                else
                {
                    double Yearly_interest = Math.Round((principalamt * interest) / 100);
                    double Monthly_Instalment = emiamt1;
                    double Installments = ik;
                    double Monthly_Interest = Math.Round(Yearly_interest / months);
                    double Monthly_Principal = Math.Round(Monthly_Instalment - Monthly_Interest);
                    //get max month from installment table
                    fmonth = Queries.FinanceInstallmentMonthStartdateNewF(contractid);
                    month = Queries.FinanceInstallmentMonthStartdateNew(contractid);
                    int insert = Queries.InsertFinance_Breakup(contractid, contno, principalamt, Yearly_interest, Monthly_Principal, Monthly_Interest, Monthly_Instalment, Installments.ToString(), month, fmonth);

                }

            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = (string)Session["username"];
        if (user == null)
        {
            Response.Redirect("~/WebSite5/production/login.aspx");
        }
        if (!IsPostBack)
        {

            dealdateTextBox.Text = DateTime.Today.ToString("dd/MM/yyyy");
            DataSet dsdeal = Queries.DisplayDealstatus();
            dealstatusDropDownList.DataSource = dsdeal;
            dealstatusDropDownList.DataTextField = "status_type";
            dealstatusDropDownList.DataValueField = "status_type";
            dealstatusDropDownList.DataBind();


           
 

            ProfileID = Convert.ToString(Request.QueryString["Profile_ID"]);

              DataSet ds = Queries.LoadProfielDetailsFull(ProfileID);
              profileidTextBox.Text = ds.Tables[0].Rows[0]["Profile_ID"].ToString();
              indateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Date_Of_Insertion"].ToString();
              createdbyTextBox.Text = ds.Tables[0].Rows[0]["Profile_Created_By"].ToString(); 
              office = ds.Tables[0].Rows[0]["Office"].ToString();
              officeTextBox.Text= ds.Tables[0].Rows[0]["Office"].ToString();
              ophid = ds.Tables[0].Rows[0]["Photo_identity"].ToString();
              ocard = ds.Tables[0].Rows[0]["Card_Holder"].ToString();
		companynameTextBox.Text= ds.Tables[0].Rows[0]["Company_Name"].ToString();


            //loading venuecountry on load
              DataSet ds1 = Queries.LoadProfileVenueCountry(ProfileID);
              VenueCountryDropDownList.DataSource = ds1;
              VenueCountryDropDownList.DataTextField = "Venue_Country_Name";
              VenueCountryDropDownList.DataValueField = "Venue_Country_Name";
              VenueCountryDropDownList.AppendDataBoundItems = true;
              VenueCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue_Country"].ToString(), ""));
              VenueCountryDropDownList.DataBind();

              //loading venue on load
              DataSet ds2 = Queries.LoadProfileVenue(ProfileID, VenueCountryDropDownList.SelectedItem.Text );
              VenueDropDownList.DataSource = ds2;
              VenueDropDownList.DataTextField = "Venue_Name";
              VenueDropDownList.DataValueField = "Venue_Name";
              VenueDropDownList.AppendDataBoundItems = true;
              VenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Venue"].ToString(), ""));
              VenueDropDownList.DataBind();

            // loading venuegroup on load
            DataSet ds3 = Queries.LoadProfileVenueGroup(ProfileID, VenueDropDownList.SelectedItem.Text);
              GroupVenueDropDownList.DataSource = ds3;
              GroupVenueDropDownList.DataTextField = "Venue_Group_Name";
              GroupVenueDropDownList.DataValueField = "Venue_Group_Name";
              GroupVenueDropDownList.AppendDataBoundItems = true;
              GroupVenueDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Group_Venue"].ToString(), ""));
              GroupVenueDropDownList.DataBind();

            //loading marketing program on load
              DataSet ds4 = Queries.LoadProfileMktg(ProfileID, VenueDropDownList.SelectedItem.Text, GroupVenueDropDownList.SelectedItem.Text);
              MarketingProgramDropDownList.DataSource = ds4;
              MarketingProgramDropDownList.DataTextField = "Marketing_Program_Name";
              MarketingProgramDropDownList.DataValueField = "Marketing_Program_Name";
              MarketingProgramDropDownList.AppendDataBoundItems = true;
              MarketingProgramDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marketing_Program"].ToString(), ""));
              MarketingProgramDropDownList.DataBind();

            // loading agents on load as per venue group
            if (GroupVenueDropDownList.SelectedItem.Text == "Coldline")
            {
                //     DataSet ds5 = Queries.LoadProfileAgent(ProfileID);
                DataSet ds5 = Queries.LoadProfileAgent1(ProfileID, VenueDropDownList.SelectedItem.Text);
                AgentDropDownList.DataSource = ds5;
                AgentDropDownList.DataTextField = "agentname";
                AgentDropDownList.DataValueField = "agentname";
                AgentDropDownList.AppendDataBoundItems = true;
                AgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                AgentDropDownList.DataBind();


            }
            else
            {
                DataSet ds5 = Queries.LoadProfileAgentNotColdline(ProfileID, VenueDropDownList.SelectedItem.Text);
                AgentDropDownList.DataSource = ds5;
                AgentDropDownList.DataTextField = "Sales_Rep_Name";
                AgentDropDownList.DataValueField = "Sales_Rep_Name";
                AgentDropDownList.AppendDataBoundItems = true;
                AgentDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent"].ToString(), ""));
                AgentDropDownList.DataBind();



            }

            // loading To name on load as per venue group
            if (GroupVenueDropDownList.SelectedItem.Text == "Coldline"|| GroupVenueDropDownList.SelectedItem.Text == "COLDLINE")
            {
                // load to11
                DataSet ds5aa = Queries.LoadTOOPCOnVenue11(ProfileID,VenueDropDownList.SelectedItem.Text);
                TONameDropDownList.DataSource = ds5aa;
                TONameDropDownList.DataTextField = "to_name";
                TONameDropDownList.DataValueField = "to_name";
                TONameDropDownList.AppendDataBoundItems = true;
                TONameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
                TONameDropDownList.DataBind();


            }
            else
            {
                // load to12
                DataSet ds5aa = Queries.LoadTOOPCOnVenue12(ProfileID, VenueDropDownList.SelectedItem.Text);
                TONameDropDownList.DataSource = ds5aa;
                TONameDropDownList.DataTextField = "TO_Manager_Name";
                TONameDropDownList.DataValueField = "TO_Manager_Name";
                TONameDropDownList.AppendDataBoundItems = true;
                TONameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
                TONameDropDownList.DataBind();



            }

            //DataSet ds6 = Queries.LoadProfileTOName(ProfileID, VenueDropDownList.SelectedItem.Text);
            //TONameDropDownList.DataSource = ds6;
            //TONameDropDownList.DataTextField = "TO_Manager_Name";
            //TONameDropDownList.DataValueField = "TO_Manager_Name";
            //TONameDropDownList.AppendDataBoundItems = true;
            //TONameDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Agent_Code"].ToString(), ""));
            //TONameDropDownList.DataBind();




            DataSet dsmg = Queries.LoadProfileManager(ProfileID, VenueDropDownList.SelectedItem.Text);
            ManagerDropDownList.DataSource = dsmg;
            ManagerDropDownList.DataTextField = "Manager_Name";
            ManagerDropDownList.DataValueField = "Manager_Name";
            ManagerDropDownList.AppendDataBoundItems = true;
            ManagerDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["manager"].ToString(), ""));
            ManagerDropDownList.DataBind();



            if (MarketingProgramDropDownList.SelectedItem.Text =="Owner" || MarketingProgramDropDownList.SelectedItem.Text == "OWNER")
            {
                // loadprofilememebertype
                DataSet dsmgs = Queries.LoadProfileMemberType(ProfileID);
                MemType1DropDownList.DataSource = dsmgs;
                MemType1DropDownList.DataTextField = "Member_Type_Name";
                MemType1DropDownList.DataValueField = "Member_Type_Name";
                MemType1DropDownList.AppendDataBoundItems = true;
                MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
                MemType1DropDownList.DataBind();


                Memno1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString();

                // load profiletype
                DataSet dsmgss = Queries.LoadProfileType(ProfileID);
                TypeDropDownList.DataSource = dsmgss;
                TypeDropDownList.DataTextField = "Type_Name";
                TypeDropDownList.DataValueField = "Type_Name";
                TypeDropDownList.AppendDataBoundItems = true;
                TypeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString(), ""));
                TypeDropDownList.DataBind();
            }
            else
            {
                
               
                // profilemembertype
                DataSet dsmgs = Queries.LoadProfileMemberType(ProfileID);
                MemType1DropDownList.DataSource = dsmgs;
                MemType1DropDownList.DataTextField = "Member_Type_Name";
                MemType1DropDownList.DataValueField = "Member_Type_Name";
                MemType1DropDownList.AppendDataBoundItems = true;
                MemType1DropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Type1"].ToString(), ""));
                MemType1DropDownList.DataBind();
                // load profiletype
                DataSet dsmgss = Queries.LoadProfileType(ProfileID);
                TypeDropDownList.DataSource = dsmgss;
                TypeDropDownList.DataTextField = "Type_Name";
                TypeDropDownList.DataValueField = "Type_Name";
                TypeDropDownList.AppendDataBoundItems = true;
                TypeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Member_Number1"].ToString(), ""));
                TypeDropDownList.DataBind();


            }
           
            DataSet dsptitle = Queries.LoadPrimarySalutation(ProfileID);
            PrimaryTitleDropDownList.DataSource = dsptitle;
            PrimaryTitleDropDownList.DataTextField = "Salutation";
            PrimaryTitleDropDownList.DataValueField = "Salutation";
            PrimaryTitleDropDownList.AppendDataBoundItems = true;
            PrimaryTitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString(), ""));
            PrimaryTitleDropDownList.DataBind();
                
            pfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            plnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            primarydobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            primaryAge.Text = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            pdesginationTextBox.Text = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();


            DataSet dspnationality = Queries.LoadPrimaryNationality(ProfileID);
            PrimarynationalityDropDownList.DataSource = dspnationality;
            PrimarynationalityDropDownList.DataTextField = "Nationality_Name";
            PrimarynationalityDropDownList.DataValueField = "Nationality_Name";
            PrimarynationalityDropDownList.AppendDataBoundItems = true;
            PrimarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString(), ""));
            PrimarynationalityDropDownList.DataBind();

            DataSet dspcountry = Queries.LoadCountryPrimary(ProfileID);
            primarycountryDropDownList.DataSource = dspcountry;
            primarycountryDropDownList.DataTextField = "country_name";
            primarycountryDropDownList.DataValueField = "country_name";
            primarycountryDropDownList.AppendDataBoundItems = true;
            primarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString(), ""));
            primarycountryDropDownList.DataBind();

           

            pemailTextBox.Text = ds.Tables[0].Rows[0]["Primary_Email"].ToString();

            DataSet dspm = Queries.LoadCountryWithCodePrimaryMobile(ProfileID);
            primarymobileDropDownList.DataSource = dspm;
            primarymobileDropDownList.DataTextField = "name";
            primarymobileDropDownList.DataValueField = "name";
            primarymobileDropDownList.AppendDataBoundItems = true;
            primarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_CC"].ToString(), ""));
            primarymobileDropDownList.DataBind();                     
            
            pmobileTextBox.Text = ds.Tables[0].Rows[0]["Primary_Mobile"].ToString();

            DataSet dspalt = Queries.LoadCountryWithCodePrimaryAlt(ProfileID);
            primaryalternateDropDownList.DataSource = dspalt;
            primaryalternateDropDownList.DataTextField = "name";
            primaryalternateDropDownList.DataValueField = "name";
            primaryalternateDropDownList.AppendDataBoundItems = true;
            primaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_Alt_CC"].ToString(), ""));
            primaryalternateDropDownList.DataBind();                      
            palternateTextBox.Text = ds.Tables[0].Rows[0]["Primary_Alternate"].ToString();

            DataSet dspoff = Queries.LoadCountryWithCodePrimaryOffice(ProfileID);
            pofficecodeDropDownList.DataSource = dspoff;
            pofficecodeDropDownList.DataTextField = "name";
            pofficecodeDropDownList.DataValueField = "name";
            pofficecodeDropDownList.AppendDataBoundItems = true;
            pofficecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Primary_office_cc"].ToString(), ""));
            pofficecodeDropDownList.DataBind();
            pofficenoTextBox.Text = ds.Tables[0].Rows[0]["Primary_office_num"].ToString();



            //secondary details
            DataSet dsstitle = Queries.LoadSecondarySalutation(ProfileID);
            secondarytitleDropDownList.DataSource = dsstitle;
            secondarytitleDropDownList.DataTextField = "Salutation";
            secondarytitleDropDownList.DataValueField = "Salutation";
            secondarytitleDropDownList.AppendDataBoundItems = true;
            secondarytitleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Title"].ToString(), ""));
            secondarytitleDropDownList.DataBind();

            sfnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Fname"].ToString();
            slnameTextBox.Text = ds.Tables[0].Rows[0]["Profile_secondary_Lname"].ToString();
            secondarydobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_secondary_DOB"]);            
            secondaryAge.Text = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            sdesignationTextBox.Text = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();

            DataSet dssnationality = Queries.LoadSecondaryNationality(ProfileID);
            secondarynationalityDropDownList.DataSource = dssnationality;
            secondarynationalityDropDownList.DataTextField = "Nationality_Name";
            secondarynationalityDropDownList.DataValueField = "Nationality_Name";
            secondarynationalityDropDownList.AppendDataBoundItems = true;
            secondarynationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Nationality"].ToString(), ""));
            secondarynationalityDropDownList.DataBind();

            DataSet dsscountry = Queries.LoadCountrySecondary(ProfileID);
            secondarycountryDropDownList.DataSource = dsscountry;
            secondarycountryDropDownList.DataTextField = "country_name";
            secondarycountryDropDownList.DataValueField = "country_name";
            secondarycountryDropDownList.AppendDataBoundItems = true;
            secondarycountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_secondary_Country"].ToString(), ""));
            secondarycountryDropDownList.DataBind();



            semailTextBox.Text = ds.Tables[0].Rows[0]["secondary_Email"].ToString();

            DataSet dssm = Queries.LoadCountryWithCodeSecondaryMobile(ProfileID);
            secondarymobileDropDownList.DataSource = dssm;
            secondarymobileDropDownList.DataTextField = "name";
            secondarymobileDropDownList.DataValueField = "name";
            secondarymobileDropDownList.AppendDataBoundItems = true;
            secondarymobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_CC"].ToString(), ""));
            secondarymobileDropDownList.DataBind();

            smobileTextBox.Text = ds.Tables[0].Rows[0]["secondary_Mobile"].ToString();

            DataSet dssalt = Queries.LoadCountryWithCodeSecondaryAlt(ProfileID);
            secondaryalternateDropDownList.DataSource = dssalt;
            secondaryalternateDropDownList.DataTextField = "name";
            secondaryalternateDropDownList.DataValueField = "name";
            secondaryalternateDropDownList.AppendDataBoundItems = true;
            secondaryalternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["secondary_Alt_CC"].ToString(), ""));
            secondaryalternateDropDownList.DataBind();
            salternateTextBox.Text = ds.Tables[0].Rows[0]["secondary_Alternate"].ToString();


            DataSet dssoff = Queries.LoadCountryWithCodeSecondaryAlt(ProfileID);
            sofficecodeDropDownList.DataSource = dssoff;
            sofficecodeDropDownList.DataTextField = "name";
            sofficecodeDropDownList.DataValueField = "name";
            sofficecodeDropDownList.AppendDataBoundItems = true;
            sofficecodeDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString(), ""));
            sofficecodeDropDownList.DataBind();
            sofficenoTextBox.Text = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();


            //address
            address1TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line1"].ToString();
            address2TextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Line2"].ToString();
            //stateTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_State"].ToString();
            cityTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_city"].ToString();
            pincodeTextBox.Text = ds.Tables[0].Rows[0]["Profile_Address_Postcode"].ToString();
            livingyrsTextBox.Text = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();

            DataSet ds12 = Queries.LoadCountryName();
            AddCountryDropDownList.DataSource = ds12;
            AddCountryDropDownList.DataTextField = "country_name";
            AddCountryDropDownList.DataValueField = "country_name";
            AddCountryDropDownList.AppendDataBoundItems = true;
            AddCountryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_Country"].ToString(), ""));
            AddCountryDropDownList.DataBind();

            //state Name
            DataSet ds1222 = Queries.LoadStateName(ProfileID,AddCountryDropDownList.SelectedItem.Text);
            StateDropDownList.DataSource = ds1222;
            StateDropDownList.DataTextField = "State_Name";
            StateDropDownList.DataValueField = "State_Name";
            StateDropDownList.AppendDataBoundItems = true;
            StateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Address_State"].ToString(), ""));
            StateDropDownList.DataBind();

            DataSet dsemploy= Queries.LoadEmploymentStatusNotInProfile(ProfileID);
            employmentstatusDropDownList.DataSource = dsemploy;
            employmentstatusDropDownList.DataTextField = "Name";
            employmentstatusDropDownList.DataValueField = "Name";
            employmentstatusDropDownList.AppendDataBoundItems = true;
            employmentstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Employment_status"].ToString(), ""));
            employmentstatusDropDownList.DataBind();


            DataSet dsmart = Queries.LoadMaritalStatusNotInProfile(ProfileID);
            maritalstatusDropDownList.DataSource = dsmart;
            maritalstatusDropDownList.DataTextField = "MaritalStatus";
            maritalstatusDropDownList.DataValueField = "MaritalStatus";
            maritalstatusDropDownList.AppendDataBoundItems = true;
            maritalstatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString(), ""));
            maritalstatusDropDownList.DataBind();
                     


            DataSet dssp1title = Queries.LoadSub_Profile1Salutation(ProfileID);
            sp1titleDropDownList.DataSource = dssp1title;
            sp1titleDropDownList.DataTextField = "Salutation";
            sp1titleDropDownList.DataValueField = "Salutation";
            sp1titleDropDownList.AppendDataBoundItems = true;
            sp1titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString(), ""));
            sp1titleDropDownList.DataBind();

            sp1fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            sp1lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();

            //secondarydobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_secondary_DOB"]);

            sp1dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);// Convert.ToDateTime( ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            subProfile1Age.Text = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

            DataSet dssp1nationality = Queries.LoadSub_Profile1Nationality(ProfileID);  
            sp1nationalityDropDownList.DataSource = dssp1nationality;
            sp1nationalityDropDownList.DataTextField = "Nationality_Name";
            sp1nationalityDropDownList.DataValueField = "Nationality_Name";
            sp1nationalityDropDownList.AppendDataBoundItems = true;
            sp1nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString(), ""));
            sp1nationalityDropDownList.DataBind();

            DataSet dssp1country = Queries.LoadCountrySP1(ProfileID);
            sp1countryDropDownList.DataSource = dssp1country;
            sp1countryDropDownList.DataTextField = "country_name";
            sp1countryDropDownList.DataValueField = "country_name";
            sp1countryDropDownList.AppendDataBoundItems = true;
            sp1countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString(), ""));
            sp1countryDropDownList.DataBind();



            sp1pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Email"].ToString();

            DataSet dssp1m = Queries.LoadCountryWithCodeSP1Mobile(ProfileID);
            sp1mobileDropDownList.DataSource = dssp1m;
            sp1mobileDropDownList.DataTextField = "name";
            sp1mobileDropDownList.DataValueField = "name";
            sp1mobileDropDownList.AppendDataBoundItems = true;
            sp1mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_CC"].ToString(), ""));
            sp1mobileDropDownList.DataBind();

            sp1mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Mobile"].ToString();

            DataSet dssp1alt = Queries.LoadCountryWithCodeSP1Alt(ProfileID);
            sp1alternateDropDownList.DataSource = dssp1alt;
            sp1alternateDropDownList.DataTextField = "name";
            sp1alternateDropDownList.DataValueField = "name";
            sp1alternateDropDownList.AppendDataBoundItems = true;
            sp1alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile1_Alt_CC"].ToString(), ""));
            sp1alternateDropDownList.DataBind();
            sp1alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile1_Alternate"].ToString();



            DataSet dssp2title = Queries.LoadSub_Profile2Salutation(ProfileID);
            sp2titleDropDownList.DataSource = dssp2title;
            sp2titleDropDownList.DataTextField = "Salutation";
            sp2titleDropDownList.DataValueField = "Salutation";
            sp2titleDropDownList.AppendDataBoundItems = true;
            sp2titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString(), ""));
            sp2titleDropDownList.DataBind();

            sp2fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            sp2lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            sp2dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            subProfile2Age.Text = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

            DataSet dssp2nationality = Queries.LoadSub_Profile2Nationality(ProfileID);
            sp2nationalityDropDownList.DataSource = dssp2nationality;
            sp2nationalityDropDownList.DataTextField = "Nationality_Name";
            sp2nationalityDropDownList.DataValueField = "Nationality_Name";
            sp2nationalityDropDownList.AppendDataBoundItems = true;
            sp2nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString(), ""));
            sp2nationalityDropDownList.DataBind();

            DataSet dssp2country = Queries.LoadCountrySP2(ProfileID);
            sp2countryDropDownList.DataSource = dssp2country;
            sp2countryDropDownList.DataTextField = "country_name";
            sp2countryDropDownList.DataValueField = "country_name";
            sp2countryDropDownList.AppendDataBoundItems = true;
            sp2countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString(), ""));
            sp2countryDropDownList.DataBind();
            sp2pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Email"].ToString();

            DataSet dssp2m = Queries.LoadCountryWithCodeSP2Mobile(ProfileID);
            sp2mobileDropDownList.DataSource = dssp2m;
            sp2mobileDropDownList.DataTextField = "name";
            sp2mobileDropDownList.DataValueField = "name";
            sp2mobileDropDownList.AppendDataBoundItems = true;
            sp2mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_CC"].ToString(), ""));
            sp2mobileDropDownList.DataBind();

            sp2mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Mobile"].ToString();

            DataSet dssp2alt = Queries.LoadCountryWithCodeSP2Alt(ProfileID);
            sp2alternateDropDownList.DataSource = dssp2alt;
            sp2alternateDropDownList.DataTextField = "name";
            sp2alternateDropDownList.DataValueField = "name";
            sp2alternateDropDownList.AppendDataBoundItems = true;
            sp2alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile2_Alt_CC"].ToString(), ""));
            sp2alternateDropDownList.DataBind();
            sp2alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile2_Alternate"].ToString();



            //sub profile 3///
            DataSet dssp3title = Queries.LoadSub_Profile3Salutation(ProfileID);
            sp3titleDropDownList.DataSource = dssp3title;
            sp3titleDropDownList.DataTextField = "Salutation";
            sp3titleDropDownList.DataValueField = "Salutation";
            sp3titleDropDownList.AppendDataBoundItems = true;
            sp3titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString(), ""));
            sp3titleDropDownList.DataBind();

            sp3fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
            sp3lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
           
                sp3dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
            
            subProfile3Age.Text = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();

            DataSet dssp3nationality = Queries.LoadSub_Profile3Nationality(ProfileID);
            sp3nationalityDropDownList.DataSource = dssp3nationality;
            sp3nationalityDropDownList.DataTextField = "Nationality_Name";
            sp3nationalityDropDownList.DataValueField = "Nationality_Name";
            sp3nationalityDropDownList.AppendDataBoundItems = true;
            sp3nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString(), ""));
            sp3nationalityDropDownList.DataBind();

            DataSet dssp3country = Queries.LoadCountrySP3(ProfileID);
            sp3countryDropDownList.DataSource = dssp3country;
            sp3countryDropDownList.DataTextField = "country_name";
            sp3countryDropDownList.DataValueField = "country_name";
            sp3countryDropDownList.AppendDataBoundItems = true;
            sp3countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString(), ""));
            sp3countryDropDownList.DataBind();
            sp3pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Email"].ToString();

            DataSet dssp3m = Queries.LoadCountryWithCodeSP3Mobile(ProfileID);
            sp3mobileDropDownList.DataSource = dssp3m;
            sp3mobileDropDownList.DataTextField = "name";
            sp3mobileDropDownList.DataValueField = "name";
            sp3mobileDropDownList.AppendDataBoundItems = true;
            sp3mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_CC"].ToString(), ""));
            sp3mobileDropDownList.DataBind();

            sp3mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Mobile"].ToString();

            DataSet dssp3alt = Queries.LoadCountryWithCodeSP3Alt(ProfileID);
            sp3alternateDropDownList.DataSource = dssp3alt;
            sp3alternateDropDownList.DataTextField = "name";
            sp3alternateDropDownList.DataValueField = "name";
            sp3alternateDropDownList.AppendDataBoundItems = true;
            sp3alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile3_Alt_CC"].ToString(), ""));
            sp3alternateDropDownList.DataBind();
            sp3alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile3_Alternate"].ToString();
            // end//


            //// sub profile 4//
            DataSet dssp4title = Queries.LoadSub_Profile3Salutation(ProfileID);
            sp4titleDropDownList.DataSource = dssp4title;
            sp4titleDropDownList.DataTextField = "Salutation";
            sp4titleDropDownList.DataValueField = "Salutation";
            sp4titleDropDownList.AppendDataBoundItems = true;
            sp4titleDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString(), ""));
            sp4titleDropDownList.DataBind();

            sp4fnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
            sp4lnameTextBox.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
          
                sp4dobdatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
            
            subProfile4Age.Text = ds.Tables[0].Rows[0]["Sub_Profile4_Age"].ToString();

            DataSet dssp4nationality = Queries.LoadSub_Profile3Nationality(ProfileID);
            sp4nationalityDropDownList.DataSource = dssp4nationality;
            sp4nationalityDropDownList.DataTextField = "Nationality_Name";
            sp4nationalityDropDownList.DataValueField = "Nationality_Name";
            sp4nationalityDropDownList.AppendDataBoundItems = true;
            sp4nationalityDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Nationality"].ToString(), ""));
            sp4nationalityDropDownList.DataBind();

            DataSet dssp4country = Queries.LoadCountrySP3(ProfileID);
            sp4countryDropDownList.DataSource = dssp4country;
            sp4countryDropDownList.DataTextField = "country_name";
            sp4countryDropDownList.DataValueField = "country_name";
            sp4countryDropDownList.AppendDataBoundItems = true;
            sp4countryDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Sub_Profile4_Country"].ToString(), ""));
            sp4countryDropDownList.DataBind();
            sp4pemailTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();

            DataSet dssp4m = Queries.LoadCountryWithCodeSP3Mobile(ProfileID);
            sp4mobileDropDownList.DataSource = dssp4m;
            sp4mobileDropDownList.DataTextField = "name";
            sp4mobileDropDownList.DataValueField = "name";
            sp4mobileDropDownList.AppendDataBoundItems = true;
            sp4mobileDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_CC"].ToString(), ""));
            sp4mobileDropDownList.DataBind();

            sp4mobileTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Mobile"].ToString();


            DataSet dssp4alt = Queries.LoadCountryWithCodeSP3Alt(ProfileID);
            sp4alternateDropDownList.DataSource = dssp4alt;
            sp4alternateDropDownList.DataTextField = "name";
            sp4alternateDropDownList.DataValueField = "name";
            sp4alternateDropDownList.AppendDataBoundItems = true;
            sp4alternateDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Subprofile4_Alt_CC"].ToString(), ""));
            sp4alternateDropDownList.DataBind();
            sp4alternateTextBox.Text = ds.Tables[0].Rows[0]["Subprofile4_Alternate"].ToString();
            ////end//

            DataSet dsss = Queries.LoadGift(ProfileID);


            if (dsss.Tables[0].Rows.Count == 0)
            {

            }
            else
            {
                TextBox13.Text = dsss.Tables[0].Rows[0]["Gift_Voucher_numb"].ToString();
                TextBox22 .Text = dsss.Tables[0].Rows[0]["Gift_Comment"].ToString();
            }


            resortTextBox.Text= ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();

            roomnoTextBox.Text = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            arrivaldatedatepicker.Text = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]).ToShortDateString();
            departuredatedatepicker.Text= String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]).ToShortDateString();
          
                tourdatedatepicker.Text =  Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]).ToShortDateString();
                oTour_Details_Tour_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
           
            timeinTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            timeoutTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            inpriceTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            inrefTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            outpriceTextBox.Text= ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            outrefTextBox.Text = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
            commentsTextBox.Text= ds.Tables[0].Rows[0]["Comments"].ToString();

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
            oProfile_Marital_status = ds.Tables[0].Rows[0]["Profile_Marital_status"].ToString();
            oProfile_NOY_Living_as_couple = ds.Tables[0].Rows[0]["Profile_NOY_Living_as_couple"].ToString();
            oOffice = ds.Tables[0].Rows[0]["Office"].ToString();
            oComments = ds.Tables[0].Rows[0]["Comments"].ToString();
            oManager = ds.Tables[0].Rows[0]["Manager"].ToString();

            oProfile_Primary_Title = ds.Tables[0].Rows[0]["Profile_Primary_Title"].ToString();
            oProfile_Primary_Fname = ds.Tables[0].Rows[0]["Profile_Primary_Fname"].ToString();
            oProfile_Primary_Lname = ds.Tables[0].Rows[0]["Profile_Primary_Lname"].ToString();
            oProfile_Primary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
            oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
            opage = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
            opdesignation = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
            oplang = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

            oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
            oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
            oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
            oProfile_Secondary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
            oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
            osage = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
            osdesignation = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
            oslang = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();


            oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
            oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
            oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
            oSub_Profile1_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
            oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
            osp1age = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();


            oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
            oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
            oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
            oSub_Profile2_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
            oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
            oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
            osp2age = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

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
            oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
            oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
            oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
            oProfile_Stay_Arrival_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
            oProfile_Stay_Departure_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]);// Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

            oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
            oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
            
             
            
            oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
            oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
            oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
            oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
            oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
            oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();



            DataSet dsqual = Queries.LoadGuestStatusInProfile(ProfileID);
            guestatusDropDownList.DataSource = dsqual;
            guestatusDropDownList.DataTextField = "Guest_Status_name";
            guestatusDropDownList.DataValueField = "Guest_Status_name";
            guestatusDropDownList.AppendDataBoundItems = true;
            guestatusDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString(), ""));
            guestatusDropDownList.DataBind();

            DataSet dstour = Queries.LoadSalesRepsInProfile1(office, ProfileID,VenueDropDownList.SelectedItem.Text);
            toursalesrepDropDownList.DataSource = dstour;
            toursalesrepDropDownList.DataTextField = "Sales_Rep_Name";
            toursalesrepDropDownList.DataValueField = "Sales_Rep_Name";
            toursalesrepDropDownList.AppendDataBoundItems = true;
            toursalesrepDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
            toursalesrepDropDownList.DataBind();

            

            //  load all sales rep based on office
            contsalesrepDropDownList.Items.Clear();
            DataSet ds7 = Queries.LoadSalesRepsInProfile1(office, ProfileID,VenueDropDownList.SelectedItem.Text);// LoadSalesReps(office);
            contsalesrepDropDownList.DataSource = ds7;
            contsalesrepDropDownList.DataTextField = "Sales_Rep_Name";
            contsalesrepDropDownList.DataValueField = "Sales_Rep_Name";
            contsalesrepDropDownList.AppendDataBoundItems = true;
            //contsalesrepDropDownList.Items.Insert(0, new ListItem("", ""));
            contsalesrepDropDownList.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString(), ""));
            contsalesrepDropDownList.DataBind();

          ///  load TO based on office

            TOManagerDropDownList.Items.Clear();
            DataSet dsto = Queries.LoadTOManagerOnVenue(office, VenueDropDownList.SelectedItem.Text);// LoadTOManager(office);
            TOManagerDropDownList.DataSource = dsto;
            TOManagerDropDownList.DataTextField = "TO_Manager_Name";
            TOManagerDropDownList.DataValueField = "TO_Manager_Name";
            TOManagerDropDownList.AppendDataBoundItems = true;
            TOManagerDropDownList.Items.Insert(0, new ListItem("", ""));
            TOManagerDropDownList.DataBind();

            ButtonUpDropDownList.Items.Clear();
            DataSet dsbu = Queries.LoadButtonUpOnVenue(office, VenueDropDownList.SelectedItem.Text);// LoadButtonUp(office);
            ButtonUpDropDownList.DataSource = dsbu;
            ButtonUpDropDownList.DataTextField = "ButtonUp_Name";
            ButtonUpDropDownList.DataValueField = "ButtonUp_Name";
            ButtonUpDropDownList.AppendDataBoundItems = true;
            ButtonUpDropDownList.Items.Insert(0, new ListItem("", ""));
            ButtonUpDropDownList.DataBind(); 

            
          
            //Contract tab
            //load contract type

            DataSet dsct = Queries.LoadContractType(office);
            contracttypeDropDownList.DataSource = dsct;
            contracttypeDropDownList.DataTextField = "ContractType_name";
            contracttypeDropDownList.DataValueField = "ContractType_name";
            contracttypeDropDownList.AppendDataBoundItems = true;
            contracttypeDropDownList.Items.Insert(0, new ListItem("Choose Contract Type", ""));
            contracttypeDropDownList.DataBind();



            DataSet dsfc = Queries.LoadFinanceOffice(office);
            currencyDropDownList.DataSource = dsfc;
            currencyDropDownList.DataTextField = "Finance_Currency_Name";
            currencyDropDownList.DataValueField = "Finance_Currency_Name";
            currencyDropDownList.AppendDataBoundItems = true;
            currencyDropDownList.Items.Insert(0, new ListItem("", ""));
            currencyDropDownList.DataBind();



            //load club based on contract type
            //type=points
            //Request.Form[VenueDropDownList.UniqueID]

         /* DataSet dsc = Queries.LoadPointsClub(office,Queries.GetVenueCode(VenueDropDownList.SelectedItem.Text,Queries.GetVenueCountryCode(VenueCountryDropDownList.SelectedItem.Text)));
           
            pointsclubDropDownList.DataSource = dsc;
            pointsclubDropDownList.DataTextField = "Contract_Club_Name";
            pointsclubDropDownList.DataValueField = "Contract_Club_Name";
            pointsclubDropDownList.AppendDataBoundItems = true;
            pointsclubDropDownList.Items.Insert(0, new ListItem("Select Club", ""));
            pointsclubDropDownList.DataBind();

            nmclubDropDownList.DataSource = dsc;
            nmclubDropDownList.DataTextField = "Contract_Club_Name";
            nmclubDropDownList.DataValueField = "Contract_Club_Name";
            nmclubDropDownList.AppendDataBoundItems = true;
            nmclubDropDownList.Items.Insert(0, new ListItem("Select Club", ""));
            nmclubDropDownList.DataBind();

            ntipclubDropDownList.DataSource = dsc;
            ntipclubDropDownList.DataTextField = "Contract_Club_Name";
            ntipclubDropDownList.DataValueField = "Contract_Club_Name";
            ntipclubDropDownList.AppendDataBoundItems = true;
            ntipclubDropDownList.Items.Insert(0, new ListItem("Select Club", ""));
            ntipclubDropDownList.DataBind();*/


            DataSet dspym = Queries.LoadPaymentMethod(office);
            PayMethodDropDownList.DataSource = dspym;
            PayMethodDropDownList.DataTextField = "pay_method_name";
            PayMethodDropDownList.DataValueField = "pay_method_name";
            PayMethodDropDownList.AppendDataBoundItems = true;
            PayMethodDropDownList.Items.Insert(0, new ListItem("Select Payment Method", ""));
            PayMethodDropDownList.DataBind();

            DataSet dsfm = Queries.LoadFinanceMethod(office);
            financemethodDropDownList.DataSource = dsfm;
            financemethodDropDownList.DataTextField = "Finance_Name";
            financemethodDropDownList.DataValueField = "Finance_Name";
            financemethodDropDownList.AppendDataBoundItems = true;
            financemethodDropDownList.Items.Insert(0, new ListItem("", ""));
            financemethodDropDownList.DataBind();

            DataSet dsdm = Queries.LoadDepositPaymentMethod(office);
            depositmethodDropDownList.DataSource = dsdm;
            depositmethodDropDownList.DataTextField = "Deposit_pay_method_name";
            depositmethodDropDownList.DataValueField = "Deposit_pay_method_name";
            depositmethodDropDownList.AppendDataBoundItems = true;
            depositmethodDropDownList.Items.Insert(0, new ListItem("", ""));
            depositmethodDropDownList.DataBind();

            DataSet dsseason = Queries.LoadSeason();
            tnmseasonDropDownList.DataSource = dsseason;
            tnmseasonDropDownList.DataTextField = "season_name";
            tnmseasonDropDownList.DataValueField = "season_name";
            tnmseasonDropDownList.AppendDataBoundItems = true;
            tnmseasonDropDownList.Items.Insert(0, new ListItem("", ""));
            tnmseasonDropDownList.DataBind();

            fwseasonDropDownList.DataSource = dsseason;
            fwseasonDropDownList.DataTextField = "season_name";
            fwseasonDropDownList.DataValueField = "season_name";
            fwseasonDropDownList.AppendDataBoundItems = true;
            fwseasonDropDownList.Items.Insert(0, new ListItem("", ""));
            fwseasonDropDownList.DataBind();

            //load alt or full
            DataSet dsen = Queries.LoadMembershipEntitlement();
            EntitlementPoinDropDownList.DataSource = dsen;
            EntitlementPoinDropDownList.DataTextField = "Entitlement_Name";
            EntitlementPoinDropDownList.DataValueField = "Entitlement_Name";
            EntitlementPoinDropDownList.AppendDataBoundItems = true;
            EntitlementPoinDropDownList.Items.Insert(0, new ListItem("", ""));
            EntitlementPoinDropDownList.DataBind();


            tipmtypeDropDownList.DataSource = dsen;
            tipmtypeDropDownList.DataTextField = "Entitlement_Name";
            tipmtypeDropDownList.DataValueField = "Entitlement_Name";
            tipmtypeDropDownList.AppendDataBoundItems = true;
            tipmtypeDropDownList.Items.Insert(0, new ListItem("", ""));
            tipmtypeDropDownList.DataBind();

            nmembtypeDropDownList.DataSource = dsen;
            nmembtypeDropDownList.DataTextField = "Entitlement_Name";
            nmembtypeDropDownList.DataValueField = "Entitlement_Name";
            nmembtypeDropDownList.AppendDataBoundItems = true;
            nmembtypeDropDownList.Items.Insert(0, new ListItem("", ""));
            nmembtypeDropDownList.DataBind();

            EntitlementFracDropDownList.DataSource = dsen;
            EntitlementFracDropDownList.DataTextField = "Entitlement_Name";
            EntitlementFracDropDownList.DataValueField = "Entitlement_Name";
            EntitlementFracDropDownList.AppendDataBoundItems = true;
            EntitlementFracDropDownList.Items.Insert(0, new ListItem("", ""));
            EntitlementFracDropDownList.DataBind();

            fwentitlementDropDownList.DataSource = dsen;
            fwentitlementDropDownList.DataTextField = "Entitlement_Name";
            fwentitlementDropDownList.DataValueField = "Entitlement_Name";
            fwentitlementDropDownList.AppendDataBoundItems = true;
            fwentitlementDropDownList.Items.Insert(0, new ListItem("", ""));
            fwentitlementDropDownList.DataBind();

            fptsentitlementDropDownList.DataSource = dsen;
            fptsentitlementDropDownList.DataTextField = "Entitlement_Name";
            fptsentitlementDropDownList.DataValueField = "Entitlement_Name";
            fptsentitlementDropDownList.AppendDataBoundItems = true;
            fptsentitlementDropDownList.Items.Insert(0, new ListItem("", ""));
            fptsentitlementDropDownList.DataBind();
            
                

            if (PrimarynationalityDropDownList.SelectedItem.Text== "INDIAN"|| PrimarynationalityDropDownList.SelectedItem.Text == "Indian" || PrimarynationalityDropDownList.SelectedItem.Text == "OCI" || PrimarynationalityDropDownList.SelectedItem.Text == "PIO")
            {
                //load alt or full
                DataSet dsres = Queries.LoadFractionalResortIndia();
                resortDropDownList.DataSource = dsres;
                resortDropDownList.DataTextField = "Contract_Resort_Name";
                resortDropDownList.DataValueField = "Contract_Resort_Name";
                resortDropDownList.AppendDataBoundItems = true;
                resortDropDownList.Items.Insert(0, new ListItem("", ""));
                resortDropDownList.DataBind();
                //weeks
                fwresortDropDownList.DataSource = dsres;
                fwresortDropDownList.DataTextField = "Contract_Resort_Name";
                fwresortDropDownList.DataValueField = "Contract_Resort_Name";
                fwresortDropDownList.AppendDataBoundItems = true;
                fwresortDropDownList.Items.Insert(0, new ListItem("", ""));
                fwresortDropDownList.DataBind();
                //pts
                fptsresortDropDownList.DataSource = dsres;
                fptsresortDropDownList.DataTextField = "Contract_Resort_Name";
                fptsresortDropDownList.DataValueField = "Contract_Resort_Name";
                fptsresortDropDownList.AppendDataBoundItems = true;
                fptsresortDropDownList.Items.Insert(0, new ListItem("", ""));
                fptsresortDropDownList.DataBind();
                

                  
                 
            }
            else
            {
                //load alt or full
                DataSet dsres1 = Queries.LoadFractionalResortNonIndia();
                resortDropDownList.DataSource = dsres1;
                resortDropDownList.DataTextField = "Contract_Resort_Name";
                resortDropDownList.DataValueField = "Contract_Resort_Name";
                resortDropDownList.AppendDataBoundItems = true;
                resortDropDownList.Items.Insert(0, new ListItem("", ""));
                resortDropDownList.DataBind();

                //weeks
                fwresortDropDownList.DataSource = dsres1;
                fwresortDropDownList.DataTextField = "Contract_Resort_Name";
                fwresortDropDownList.DataValueField = "Contract_Resort_Name";
                fwresortDropDownList.AppendDataBoundItems = true;
                fwresortDropDownList.Items.Insert(0, new ListItem("", ""));
                fwresortDropDownList.DataBind();
                //pts
                fptsresortDropDownList.DataSource = dsres1;
                fptsresortDropDownList.DataTextField = "Contract_Resort_Name";
                fptsresortDropDownList.DataValueField = "Contract_Resort_Name";
                fptsresortDropDownList.AppendDataBoundItems = true;
                fptsresortDropDownList.Items.Insert(0, new ListItem("", ""));
                fptsresortDropDownList.DataBind();



            }
            DataSet dsfint = Queries.LoadFractionalInterest();
            FractionalInterestDropDownList.DataSource = dsfint;
            FractionalInterestDropDownList.DataTextField = "Contract_Fractional_Int_Name";
            FractionalInterestDropDownList.DataValueField = "Contract_Fractional_Int_Name";
            FractionalInterestDropDownList.AppendDataBoundItems = true;
            FractionalInterestDropDownList.Items.Insert(0, new ListItem("", ""));
            FractionalInterestDropDownList.DataBind();

            //weeks

            fwfractIntDropDownList.DataSource = dsfint;
            fwfractIntDropDownList.DataTextField = "Contract_Fractional_Int_Name";
            fwfractIntDropDownList.DataValueField = "Contract_Fractional_Int_Name";
            fwfractIntDropDownList.AppendDataBoundItems = true;
            fwfractIntDropDownList.Items.Insert(0, new ListItem("", ""));
            fwfractIntDropDownList.DataBind();

            //pts

            fptsfracintDropDownList.DataSource = dsfint;
            fptsfracintDropDownList.DataTextField = "Contract_Fractional_Int_Name";
            fptsfracintDropDownList.DataValueField = "Contract_Fractional_Int_Name";
            fptsfracintDropDownList.AppendDataBoundItems = true;
            fptsfracintDropDownList.Items.Insert(0, new ListItem("", ""));
            fptsfracintDropDownList.DataBind();


        }

        oldcontracttypeDropDownList.Items.Clear();
        oldcontracttypeDropDownList.Items.Add("");
        oldcontracttypeDropDownList.Items.Add("Points");
        oldcontracttypeDropDownList.Items.Add("Weeks");

       

     //   Response.Write(ContractdetailsIDTextBox.Text);
    }
   
    public void CreateButton_Click(object sender, EventArgs e)
    {
         contractdetailsID = Queries.GetContractDetails_Indian_ID(officeTextBox.Text); 
        //ContractdetailsIDTextBox.Text = contractdetailsID;

        int i;
        string inst = "Installment No";
        string iamt, idate,ia,idt;
        

        string user =(string)Session["username"];// "Caroline";
        string propertyfee, memberfee,membercgst,membersgst;

        if (financeradiobuttonlist.SelectedIndex == -1)
        {

        }
        else
        {

            string contracttype = contracttypeDropDownList.SelectedItem.Text;
            string contractno = contractnoTextBox.Text;
            string profileid = profileidTextBox.Text;
            string Finance_Details_Id = Queries.GetFinance_Details_Indian_ID(officeTextBox.Text);// GetFinance_Details_Indian();
            string financeradio = financeradiobuttonlist.SelectedItem.Text;
            string currency = currencyDropDownList.SelectedItem.Text;
            string Affiliate_Type = AffiliationvalueTextBox.Text;
            string Total_Price_Including_Tax = totalfinpriceIntaxTextBox.Text;
            string Initial_Deposit_Percent = intialdeppercentTextBox.Text;
            string Initial_Deposit_Amount = initaldepamtTextBox.Text;
            string Balance_Payable = baldepamtTextBox.Text;
            string Total_Inital_Deposit = firstdepamtTextBox.Text;
            string Initial_Deposit_Balance = balinitialdepamtTextBox.Text;
            string Bal_Amount_Payable = balamtpayableTextBox.Text;
            string Payment_Method;
            //= PayMethodDropDownList.SelectedItem.Text;
            if(PayMethodDropDownList.SelectedIndex==0)
            {
                Payment_Method = "";
            }
            else
            {
                Payment_Method = PayMethodDropDownList.SelectedItem.Text;
            }
            string No_Installments = NoinstallmentTextBox.Text;
            string Installment_Amount = installmentamtTextBox.Text;
            string Finance_Type = financemethodDropDownList.SelectedItem.Text;
            
            if(companynameTextBox.Text==""||companynameTextBox.Text==null)
            {

            }
            else
            {
                //update
                if (String.Compare(ocompanyname, companynameTextBox.Text) != 0)
                {
                    int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, companynameTextBox.Text.ToUpper());
                    string log3 = "Company Name changed from:" + ocompanyname + " " + "to" + companynameTextBox.Text;
                    int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, contractdetailsID, log3, user, DateTime.Now.ToString());

                }
                else
                {
                }
            }


            if (mcRadioButtonList.Checked == true)
                {
                    mcwaiver = "Yes";
                }
                else
                {
                    mcwaiver = "No";

                }

                if (contracttype == "Fractional")
                {
                    if (financeradio == "Finance")
                    {
                        if (Finance_Type == "Pashuram Finance")
                        {
                            IGSTrate = "18";
                            Interestrate = "11";
                        }
                        else
                        {
                            IGSTrate = "0";
                            Interestrate = "0";
                        }
                        Finance_No = FinancenoTextBox.Text;
                        documentationfee = findocfeeTextBox.Text;
                        IGST_Amount = igstamtTextBox.Text;
                        No_Emi = noemiTextBox.Text;
                        emiamt = emiamtTextBox.Text;
                    }
                    else if (financeradio == "Non Finance")
                    {

                        Finance_No = "0";
                        documentationfee = "0";
                        IGST_Amount = "0";
                        No_Emi = "0";
                        emiamt = "0";
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    string resort = resortDropDownList.SelectedItem.Text;
                    string yr = ffirstyrTextBox.Text;
                    string cur = currencyDropDownList.SelectedItem.Text;
                    string res = testresTextBox.Text;
                    string farr = FractionalInterestDropDownList.SelectedItem.Text;
                    //lease back saved on mcfeestextbox

                    //get mc charges
                    DataSet dsmc = Queries.LoadMCChartfractional(resort, yr, cur, farr, res);
                    if (dsmc.Tables[0].Rows.Count == 0)
                    {
                        propertyfee = "0";
                        memberfee = "0";
                    membercgst = "TBA";
                    membersgst = "TBA";

                }
                    else
                    {
                        propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                        memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                    membercgst = dsmc.Tables[0].Rows[0]["Member_CGST"].ToString();
                    membersgst = dsmc.Tables[0].Rows[0]["Member_SGST"].ToString();
                }

                    int occyr = Convert.ToInt32(ffirstyrTextBox.Text) - 1;
                    string mcstartdate = "01/10/" + occyr;
               
                int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee, membercgst, membersgst, CanxContractNoTextBox.Text, contractdetailsID,"",LoanBUOfficerTextBox.Text,gstinTextBox.Text,companypanoTextBox.Text);
                //update
                int updateGetContractDetails_Indian_ID = Queries.UpdateContractDetails_Indian_ID(officeTextBox.Text);
                // update contractno n finance no
                if (PrimarynationalityDropDownList.SelectedItem.Text == "INDIAN"|| PrimarynationalityDropDownList.SelectedItem.Text == "Indian" || PrimarynationalityDropDownList.SelectedItem.Text == "OCI" || PrimarynationalityDropDownList.SelectedItem.Text == "PIO")
                {
                    int updatecontno = Queries.UpdateResortNoInd(VenueDropDownList.SelectedItem.Text, resortDropDownList.SelectedItem.Text);
                }
                else
                {
                    int updatecontno = Queries.UpdateResortNoNonInd(VenueDropDownList.SelectedItem.Text, resortDropDownList.SelectedItem.Text);

                }
                string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee + memberfee + "," + "Canx Contract No:" + CanxContractNoTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Canx Date:" + ""+","+"Loan BU Officer:"+LoanBUOfficerTextBox.Text+","+"GSTIN No:"+gstinTextBox.Text+","+"Co. Pan No:"+companypanoTextBox.Text;
                int insertlog1 = Queries.InsertContractLogs_India(profileid,  contractdetailsID, log1, user, DateTime.Now.ToString());

                string ContractFractionalIndian_ID = Queries.GetContract_Fractional_Indian_ID(officeTextBox.Text);// GetContract_Fractional_Indian();
                    int insertfractional = Queries.InsertContract_Fractional_Indian(ContractFractionalIndian_ID, profileid, contractno, resortDropDownList.SelectedItem.Text, testresnoTextBox.Text, testresTextBox.Text, FractionalInterestDropDownList.SelectedItem.Text, EntitlementFracDropDownList.SelectedItem.Text, ffirstyrTextBox.Text, ftenureTextBox.Text, flastyrTextBox.Text, MCFeesTextBox.Text, propertyfee, contractdetailsID);
                    string log2 = "Fractional Details:" + "ContractFractionalIndian_ID:" + ContractFractionalIndian_ID + "," + "profileid:" + profileid + "," + "contractno:" + contractno + "," + "Resort:" + resortDropDownList.SelectedItem.Text + "," + "Residence No:" + testresnoTextBox.Text + "," + "Residence type:" + testresTextBox.Text + "," + "Fractional Interest:" + FractionalInterestDropDownList.SelectedItem.Text + "," + "Entitlement:" + EntitlementFracDropDownList.SelectedItem.Text + "," + "1st Yr Occ:" + ffirstyrTextBox.Text + "," + "Tenure:" + ftenureTextBox.Text + "," + "last Yr Occ:" + flastyrTextBox.Text + "," + "Lease Back:" + MCFeesTextBox.Text + "," + "Profperty fee:" + propertyfee+","+"ContractDetailsID:"+ contractdetailsID;
                    int insertlog2 = Queries.InsertContractLogs_India(profileid,   contractdetailsID, log2, user, DateTime.Now.ToString());
                int updatefract = Queries.UpdateContract_Fractional_Indian_ID(officeTextBox.Text);

                    int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "","",regcollectiontermTextBox.Text,regcollamtTextBox.Text, contractdetailsID,baladepamtdateTextBox.Text,"");
                int updatefinanceid = Queries.UpdateFinance_Details_Indian_ID(officeTextBox.Text);


                string Contract_Fractional_PA_Id = Queries.GetContract_Fractional_PA_Indian_ID(officeTextBox.Text);// GetContract_Fractional_PA_Indian();
                string fbal;
                if(fractionalbalduedateTextBox.Text==""|| fractionalbalduedateTextBox.Text==null|| fractionalbalduedateTextBox.Text=="NaN")
                {
                    fbal = "NIL";
                }
                else
                {
                    fbal = fractionalbalduedateTextBox.Text;
                }
                int insertpointsPA = Queries.InsertContract_Fractional_PA_Indian(Contract_Fractional_PA_Id, profileid, contractno, AdmissionFeesTextBox.Text, AdministrationFeesTextBox.Text, fcgstTextBox.Text, fsgstTextBox.Text, TotalPurchasePriceTextBox.Text, Total_Price_Including_Tax, fractionaldepositTextBox.Text, fractionalbalanceTextBox.Text, fbal, remarksTextBox.Text, "","", contractdetailsID);
                string log4 = "Fractional PA Details:" + "Fractional_PA_Id:" + Contract_Fractional_PA_Id + "," + "Profile:" + profileid + "," + "Contract no:" + contractno + "," + "Trade in value:" + "" + "," + "Total Value:" + "" + "," + "AdmissionFees:" + AdmissionFeesTextBox.Text + "," + " AdministrationFees:" + AdministrationFeesTextBox.Text + "," + "CGST:" + fcgstTextBox.Text + "," + "SGST:" + fsgstTextBox.Text + "," + "total Purchase price:" + TotalPurchasePriceTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "Deposit Amt:" + fractionaldepositTextBox.Text + "," + "balance:" + fractionalbalanceTextBox.Text + "," + "Balance due dates:" + fbal + "," + "Remarks:" + remarksTextBox.Text + "," + "contractdetailsID:" + contractdetailsID;
                int insertlog4 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log4, user, DateTime.Now.ToString());
                int updatefractpa = Queries.UpdateContract_Fractional_PA_Indian_ID(officeTextBox.Text);

                if (NoinstallmentTextBox.Text == "")
                { }
                else
                {
                    for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office),  contractdetailsID);
                        string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "contractdetailsID:" + contractdetailsID;
                        int insertlog5 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                    if (financeradio == "Finance")
                    {
                        //get max installmentdate n update finance startdate
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno) + "," + "Old Loan Agreement No:" + "" + "," + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID+","+"bal Dep Date:"+baladepamtdateTextBox.Text+","+"Old loan amt:"+""; 
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());
                        int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type, contracttypeDropDownList.SelectedItem.Text);
                        financebreakup(noemiTextBox.Text, balamtpayableTextBox.Text, emiamtTextBox.Text, contractdetailsID, contracttypeDropDownList.SelectedItem.Text, contractno);
                    }
                    else if (financeradio == "Non Finance")
                    {
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + "";
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());

                    }
                  
                }
                //generate receipt               
                DataSet dsrecp = Queries.LoadIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                int CurrentYear = DateTime.Today.Year;
                int PreviousYear = DateTime.Today.Year - 1;
                int NextYear = DateTime.Today.Year + 1;
                string PreYear = PreviousYear.ToString();
                string NexYear = NextYear.ToString();
                string CurYear = CurrentYear.ToString();
                int cyr = Convert.ToInt32(CurYear) % 100;              
                int tpyr = Convert.ToInt32(PreYear) % 100;
                int nxyr = Convert.ToInt32(NexYear) % 100;
                string FinYear = null;

                if (DateTime.Today.Month > 3)
                {
                  //  FinYear = cyr + "-" + nxyr;
                  FinYear= CurrentYear+"-"+nxyr;
                }
                else
                {
                    //FinYear = tpyr + "-" + cyr;
                    FinYear = PreviousYear + "-" + cyr;
                    
                }                
                string invoiceno = dsrecp.Tables[0].Rows[0]["ReceiptStart"].ToString() + "/" + FinYear + "/" + dsrecp.Tables[0].Rows[0]["ReceiptGen_Code"].ToString();
              
                //calculate gst on intial dep    
                if (frpdoldamtTextBox.Text==""|| frpdoldamtTextBox.Text=="NaN"|| frpdoldamtTextBox.Text=="0"|| frpdoldamtTextBox.Text==null)
                {
                    double indeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }   
                else
                {
                    double oldamt = Convert.ToDouble(frpdoldamtTextBox.Text);
                    double fulldeposit= Convert.ToDouble(intialdeppercentTextBox.Text);                  
                    double indeposit = fulldeposit - oldamt;                    
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }       
             
                SOR_AdditionalName(contractdetailsID);
                LoadDocuments(contractdetailsID, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeDropDownList.SelectedItem.Text, Affiliate_Type, mcwaiver,CanxContractNoTextBox.Text,companynameTextBox.Text,StateDropDownList.SelectedItem.Text);
               

               



            }
                else if (contracttype == "Points")
                {
                    if (financeradio == "Finance")
                    {
                        if (Finance_Type == "Pashuram Finance")
                        {
                            IGSTrate = "18";
                            Interestrate = "19";
                        }
                        else
                        {
                            IGSTrate = "0";
                            Interestrate = "0";
                        }
                        Finance_No = FinancenoTextBox.Text;
                        documentationfee = findocfeeTextBox.Text;
                        IGST_Amount = igstamtTextBox.Text;
                        No_Emi = noemiTextBox.Text;
                        emiamt = emiamtTextBox.Text;
                    }
                    else if (financeradio == "Non Finance")
                    {

                        Finance_No = "0";
                        documentationfee = "0";
                        IGST_Amount = "0";
                        No_Emi = "0";
                        emiamt = "0";
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                
                //get mc charges
              //  DataSet dsmc = Queries.LoadMCChart(pointsclubDropDownList.SelectedItem.Text, firstyrTextBox.Text, currencyDropDownList.SelectedItem.Text);
                DataSet dsmc = Queries.LoadMCChart(Request.Form[pointsclubDropDownList.UniqueID], firstyrTextBox.Text, currencyDropDownList.SelectedItem.Text);


                if (dsmc.Tables[0].Rows.Count == 0)
                    {
                        propertyfee = "0";
                        memberfee = "0";
                    membercgst = "TBA";
                    membersgst = "TBA";

                }
                else
                {
                    propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                    memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                    membercgst = dsmc.Tables[0].Rows[0]["Member_CGST"].ToString();
                    membersgst = dsmc.Tables[0].Rows[0]["Member_SGST"].ToString();
                }

                int occyr = Convert.ToInt32(firstyrTextBox.Text) - 1;
                    string mcstartdate = "01/10/" + occyr;
            
                int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee, membercgst, membersgst, CanxContractNoTextBox.Text,contractdetailsID,"",LoanBUOfficerTextBox.Text,gstinTextBox.Text,companypanoTextBox.Text);
                string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee + memberfee + "," + "Canx Contract No:" + CanxContractNoTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Canx Date:" + "" + "," + "Loan BU Officer:" + LoanBUOfficerTextBox.Text+","+"GSTIN No:"+gstinTextBox.Text + "," + "Co. Pan No:" + companypanoTextBox.Text;
                int insertlog1 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log1, user, DateTime.Now.ToString());

                //update
                int updateGetContractDetails_Indian_ID = Queries.UpdateContractDetails_Indian_ID(officeTextBox.Text);

                if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian"|| PrimarynationalityDropDownList.SelectedItem.Text == "INDIAN" || PrimarynationalityDropDownList.SelectedItem.Text == "OCI" || PrimarynationalityDropDownList.SelectedItem.Text == "PIO")
                {
                    //int updatecontno = Queries.UpdateContractNoInd(VenueDropDownList.SelectedItem.Text, pointsclubDropDownList.SelectedItem.Text);
                    int updatecontno = Queries.UpdateContractNoInd(VenueDropDownList.SelectedItem.Text, Request.Form[pointsclubDropDownList.UniqueID]);


                }
                else
                {
                    // int updatecontno = Queries.UpdateContractNoNInd(VenueDropDownList.SelectedItem.Text, pointsclubDropDownList.SelectedItem.Text);
                    int updatecontno = Queries.UpdateContractNoNInd(VenueDropDownList.SelectedItem.Text, Request.Form[pointsclubDropDownList.UniqueID]);
                }



                    int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "","","","",contractdetailsID,baladepamtdateTextBox.Text,"");
                int updatefinanceid = Queries.UpdateFinance_Details_Indian_ID(officeTextBox.Text);


                string ContractPoints_ID = Queries.GetContract_Points_Indian_ID(officeTextBox.Text);// GetContract_Points_Indian();                
                int insertpoints = Queries.InsertContract_Points_Indian(ContractPoints_ID, profileid, contractno, Request.Form[pointsclubDropDownList.UniqueID], newpointsrightTextBox.Text, EntitlementPoinDropDownList.SelectedItem.Text, totalptrightsTextBox.Text, firstyrTextBox.Text, tenureTextBox.Text, lastyrTextBox.Text,nopersonsTextBox.Text, contractdetailsID);

                 string log2 = "New Points Details:" + "Points ID:" + ContractPoints_ID + "," + "Profileid:" + profileid + "," + "ContractNO:" + contractno + "," + "Club:" + Request.Form[pointsclubDropDownList.UniqueID] + "," + "New Points:" + newpointsrightTextBox.Text + "," + "Entitlement:" + EntitlementPoinDropDownList.SelectedItem.Text + "," + "total Points Right:" + totalptrightsTextBox.Text + "," + "1st Yr Occ:" + firstyrTextBox.Text + "," + "Tenure:" + tenureTextBox.Text + "," + "Last Yr Occ:" + lastyrTextBox.Text + "," + "No.Persons:" + nopersonsTextBox.Text + "," + "contractdetailsID:" + contractdetailsID;
                int insertlog2 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log2, user, DateTime.Now.ToString());
                int updatepointgeno = Queries.UpdateContract_Points_Indian_ID(officeTextBox.Text);

                string Contract_PA_Id = Queries.GetContract_PA_Indian_ID(officeTextBox.Text);// GetContract_PA_Indian();
                string balpa;
                if (balancedueTextBox.Text == "" || balancedueTextBox.Text == null || balancedueTextBox.Text == "NaN")
                {
                    balpa = "NIL";
                }
                else
                {
                    balpa = balancedueTextBox.Text;
                }
                int insertpointsPA = Queries.InsertContract_PA_Indian(Contract_PA_Id, profileid, contractno, newpointsTextBox.Text, conversionfeeTextBox.Text, adminfeeTextBox.Text, totpurchpriceTextBox.Text, cgstTextBox.Text, sgstTextBox.Text, Total_Price_Including_Tax, depositTextBox.Text, balanceTextBox.Text, balpa, remarksTextBox.Text, contractdetailsID);
                    string log4 = "New Points PA:" + "PA_ID:" + Contract_PA_Id + "," + "Profileid:" + profileid + "," + "ContractNO:" + contractno + "," + "New Points:" + newpointsTextBox.Text + "," + "Conversion Fee:" + conversionfeeTextBox.Text + "," + "Admin Fee:" + adminfeeTextBox.Text + "," + "Total Purchase price:" + totpurchpriceTextBox.Text + "," + "CGST:" + cgstTextBox.Text + "," + "SGST:" + sgstTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Deposit Amt:" + depositTextBox.Text + "," + "balance Amt:" + balanceTextBox.Text + "," + "Balance Due date:" + balpa + "," + "remark:" + remarksTextBox.Text + "," + "contractdetailsID:" + contractdetailsID;
                int insertlog4 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log4, user, DateTime.Now.ToString());
                int updatepageno = Queries.UpdateContract_PA_Indian_ID(officeTextBox.Text);
                if (NoinstallmentTextBox.Text == "")
                { }
                else
                {
                    for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), contractdetailsID);
                        string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "contractdetailsID:" + contractdetailsID;
                        int insertlog5 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }
                    if (financeradio == "Finance")
                    {
                        //get max installmentdate n update finance startdate
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno) + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + "0" + "," + "RegistryCollection Amt:" + "0" + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + "";
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());
                        //update contractno n finance no 

                        int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type, contracttypeDropDownList.SelectedItem.Text);

                        financebreakup(noemiTextBox.Text, balamtpayableTextBox.Text, emiamtTextBox.Text, contractdetailsID, contracttypeDropDownList.SelectedItem.Text, contractno);



                    }
                    else if (financeradio == "Non Finance")
                    {
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + "0" + "," + "RegistryCollection Amt:" + "0" + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + "";
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());

                    }
                }
                //generate receipt               
                DataSet dsrecp = Queries.LoadIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                int CurrentYear = DateTime.Today.Year;
                int PreviousYear = DateTime.Today.Year - 1;
                int NextYear = DateTime.Today.Year + 1;
                string PreYear = PreviousYear.ToString();
                string NexYear = NextYear.ToString();
                string CurYear = CurrentYear.ToString();
                int cyr = Convert.ToInt32(CurYear) % 100;
                string cyr1 = cyr.ToString("yy");
                int tpyr = Convert.ToInt32(PreYear) % 100;
                int nxyr = Convert.ToInt32(NexYear) % 100;
                string FinYear = null;

                if (DateTime.Today.Month > 3)
                {
                    //  FinYear = cyr + "-" + nxyr;
                    FinYear = CurrentYear + "-" + nxyr;
                }
                else
                {
                    //FinYear = tpyr + "-" + cyr;
                    FinYear = PreviousYear + "-" + cyr;

                }
                string invoiceno = dsrecp.Tables[0].Rows[0]["ReceiptStart"].ToString() + "/" + FinYear + "/" + dsrecp.Tables[0].Rows[0]["ReceiptGen_Code"].ToString();
                //calculate gst on intial dep    
                if (pdoldamtTextBox.Text == "" || pdoldamtTextBox.Text == "NaN" || pdoldamtTextBox.Text == "0" || pdoldamtTextBox.Text == null)
                {
                    double indeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }
                else
                {
                    double oldamt = Convert.ToDouble(pdoldamtTextBox.Text);
                    double fulldeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                    double indeposit = fulldeposit - oldamt;
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }
                //SOR_AdditionalName(ContractdetailsIDTextBox.Text);
                //if (mcwaiver=="Yes")
                //{
                //    PrintPdfDropDownList.Items.Clear();

                //     DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, Request.Form[pointsclubDropDownList.UniqueID], currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text, Affiliate_Type, mcwaiver);
                //    PrintPdfDropDownList.DataSource = ds21;
                //    PrintPdfDropDownList.DataTextField = "printname";
                //    PrintPdfDropDownList.DataValueField = "printname";
                //    PrintPdfDropDownList.AppendDataBoundItems = true;
                //    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                //    PrintPdfDropDownList.DataBind();

                //    // string script = "<script> $(function() {$('#tabs').tabs({ disabled: [3] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";
                //    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";


                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                //}
                //else if(mcwaiver=="No")
                //{
                //    PrintPdfDropDownList.Items.Clear();

                //     DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, Request.Form[pointsclubDropDownList.UniqueID], currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text, Affiliate_Type, mcwaiver);
                //    PrintPdfDropDownList.DataSource = ds21;
                //    PrintPdfDropDownList.DataTextField = "printname";
                //    PrintPdfDropDownList.DataValueField = "printname";
                //    PrintPdfDropDownList.AppendDataBoundItems = true;
                //    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                //    PrintPdfDropDownList.DataBind();

                //    //  string script = "<script> $(function() {$('#tabs').tabs({ disabled: [3] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";
                //    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";


                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                //}
                SOR_AdditionalName(contractdetailsID);
                LoadDocuments(contractdetailsID, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeDropDownList.SelectedItem.Text, Affiliate_Type, mcwaiver, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);
                string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";


                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

            }
            else if (contracttype == "Trade-In-Points")
                {
                    if (financeradio == "Finance")
                    {
                        if (Finance_Type == "Pashuram Finance")
                        {
                            IGSTrate = "18";
                            Interestrate = "19";
                        }
                        else
                        {
                            IGSTrate = "0";
                            Interestrate = "0";
                        }
                        Finance_No = FinancenoTextBox.Text;
                        documentationfee = findocfeeTextBox.Text;
                        IGST_Amount = igstamtTextBox.Text;
                        No_Emi = noemiTextBox.Text;
                        emiamt = emiamtTextBox.Text;
                    }
                    else if (financeradio == "Non Finance")
                    {

                        Finance_No = "0";
                        documentationfee = "0";
                        IGST_Amount = "0";
                        No_Emi = "0";
                        emiamt = "0";
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    DataSet dsmc = Queries.LoadMCChart(Request.Form[ntipclubDropDownList.UniqueID], tipfirstyrTextBox.Text, currencyDropDownList.SelectedItem.Text);

                    if (dsmc.Tables[0].Rows.Count == 0)
                    {
                        propertyfee = "0";
                        memberfee = "0";
                    membercgst = "TBA";
                    membersgst = "TBA";

                }
                else
                {
                    propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                    memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                    membercgst = dsmc.Tables[0].Rows[0]["Member_CGST"].ToString();
                    membersgst = dsmc.Tables[0].Rows[0]["Member_SGST"].ToString();
                }
                int occyr = Convert.ToInt32(tipfirstyrTextBox.Text) - 1;
                    string mcstartdate = "01/10/" + occyr;
           
                int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee, membercgst, membersgst, CanxContractNoTextBox.Text,contractdetailsID,"",LoanBUOfficerTextBox.Text ,gstinTextBox.Text,companypanoTextBox.Text  );
                string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee + memberfee + "," + "Canx Contract No:" + CanxContractNoTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "Canx Date:" + "" + "," + "Loan BU Officer:" + LoanBUOfficerTextBox.Text + "," + "GSTIN No:" + gstinTextBox.Text + "," + "Co. Pan No:" + companypanoTextBox.Text;
                int insertlog1 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log1, user, DateTime.Now.ToString());

                //update
                int updateGetContractDetails_Indian_ID = Queries.UpdateContractDetails_Indian_ID(officeTextBox.Text);

                if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian"|| PrimarynationalityDropDownList.SelectedItem.Text == "INDIAN" || PrimarynationalityDropDownList.SelectedItem.Text == "OCI" || PrimarynationalityDropDownList.SelectedItem.Text == "PIO")
                {
                    int updatecontno = Queries.UpdateContractNoInd(VenueDropDownList.SelectedItem.Text, Request.Form[ntipclubDropDownList.UniqueID]);

                }
                else
                {
                    int updatecontno = Queries.UpdateContractNoNInd(VenueDropDownList.SelectedItem.Text, Request.Form[ntipclubDropDownList.UniqueID]);
                }


                string ContractTradeInPoint_ID = Queries.GetContract_Trade_In_Points_Indian_ID(officeTextBox.Text);// GetContract_Trade_In_Points_Indian();
                    int inserttradeinpoints = Queries.InsertContract_Trade_In_Points_Indian(ContractTradeInPoint_ID, profileid, contractno, tipresortTextBox.Text.ToUpper(), tipnopointsTextBox.Text, tipcontnoTextBox.Text.ToUpper(), tipptsvalueTextBox.Text, Request.Form[ntipclubDropDownList.UniqueID], tipnewpointsTextBox.Text, tipmtypeDropDownList.SelectedItem.Text, tiptotalpointsTextBox.Text, tipfirstyrTextBox.Text, tiptenureTextBox.Text, tiplastyrTextBox.Text,tipnopersonsTextBox.Text, contractdetailsID);
                    string log2 = "Trade In Points:" + "Tradeinpoints id:" + ContractTradeInPoint_ID + "," + "Profile:" + profileid + "," + "Contractno:" + contractno + "," + "Resort:" + tipresortTextBox.Text.ToUpper() + "," + "Points:" + tipnopointsTextBox.Text + "," + "Cont.No:" + tipcontnoTextBox.Text.ToUpper() + "," + "Points Value:" + tipptsvalueTextBox.Text + "," + "Club:" + Request.Form[ntipclubDropDownList.UniqueID] + "," + "New Points:" + tipnewpointsTextBox.Text + "," + "Entitlement:" + tipmtypeDropDownList.SelectedItem.Text + "," + "Total Points:" + tiptotalpointsTextBox.Text + "," + "1st Yr Occ:" + tipfirstyrTextBox.Text + "," + "Tenure:" + tiptenureTextBox.Text + "," + "Last Yr Occ:" + tiplastyrTextBox.Text+","+"No.persons:"+tipnopersonsTextBox.Text + "," + "contractdetailsID:" + contractdetailsID; 
                    int insertlog2 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log2, user, DateTime.Now.ToString());
                int updatetipgeno = Queries.UpdateContract_Trade_In_Points_Indian_ID(officeTextBox.Text);

                int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "","","","", contractdetailsID,baladepamtdateTextBox.Text,"" );
                int updatefinanceid = Queries.UpdateFinance_Details_Indian_ID(officeTextBox.Text);


                //  string Contract_PA_Id = Queries.GetContract_PA_Indian();
                string Contract_PA_Id = Queries.GetContract_PA_Indian_ID(officeTextBox.Text);
                string balpa;
                if (balancedueTextBox.Text == "" || balancedueTextBox.Text == null || balancedueTextBox.Text == "NaN")
                {
                    balpa = "NIL";
                }
                else
                {
                    balpa = balancedueTextBox.Text;
                }
                int insertpointsPA = Queries.InsertContract_PA_Indian(Contract_PA_Id, profileid, contractno, newpointsTextBox.Text, conversionfeeTextBox.Text, adminfeeTextBox.Text, totpurchpriceTextBox.Text, cgstTextBox.Text, sgstTextBox.Text, Total_Price_Including_Tax, depositTextBox.Text, balanceTextBox.Text, balpa, remarksTextBox.Text, contractdetailsID);
                    string log4 = "Trade in Points PA:" + "PA_ID:" + Contract_PA_Id + "," + "Profileid:" + profileid + "," + "ContractNO:" + contractno + "," + "New Points:" + newpointsTextBox.Text + "," + "Conversion Fee:" + conversionfeeTextBox.Text + "," + "Admin Fee:" + adminfeeTextBox.Text + "," + "Total Purchase price:" + totpurchpriceTextBox.Text + "," + "CGST:" + cgstTextBox.Text + "," + "SGST:" + sgstTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Deposit Amt:" + depositTextBox.Text + "," + "balance Amt:" + balanceTextBox.Text + "," + "Balance Due date:" + balpa + "," + "remark:" + remarksTextBox.Text + "," + "contractdetailsID:" + contractdetailsID;
                int insertlog4 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log4, user, DateTime.Now.ToString());
                int updatepageno = Queries.UpdateContract_PA_Indian_ID(officeTextBox.Text);
                if (NoinstallmentTextBox.Text == "") { }
                else
                {
                    for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];


                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), contractdetailsID);
                        string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "contractdetailsID:" + contractdetailsID;
                        int insertlog5 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update = Queries.UpdateInstallmentInvoiceNo(office);
                    }

                    if (financeradio == "Finance")
                    {
                        //get max installmentdate n update finance startdate
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno) + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + "0" + "," + "RegistryCollection Amt:" + "0" + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + "";
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());
                        //update contractno n finance no 
                        int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type, contracttypeDropDownList.SelectedItem.Text);
                        financebreakup(noemiTextBox.Text, balamtpayableTextBox.Text, emiamtTextBox.Text, contractdetailsID, contracttypeDropDownList.SelectedItem.Text, contractno);
                    }
                    else if (financeradio == "Non Finance")
                    {
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + "0" + "," + "RegistryCollection Amt:" + "0" + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + "";
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());

                    }
                }
                //generate receipt               
                DataSet dsrecp = Queries.LoadIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                int CurrentYear = DateTime.Today.Year;
                int PreviousYear = DateTime.Today.Year - 1;
                int NextYear = DateTime.Today.Year + 1;
                string PreYear = PreviousYear.ToString();
                string NexYear = NextYear.ToString();
                string CurYear = CurrentYear.ToString();
                int cyr = Convert.ToInt32(CurYear) % 100;
                string cyr1 = cyr.ToString("yy");
                int tpyr = Convert.ToInt32(PreYear) % 100;
                int nxyr = Convert.ToInt32(NexYear) % 100;
                string FinYear = null;

                if (DateTime.Today.Month > 3)
                {
                    //  FinYear = cyr + "-" + nxyr;
                    FinYear = CurrentYear + "-" + nxyr;
                }
                else
                {
                    //FinYear = tpyr + "-" + cyr;
                    FinYear = PreviousYear + "-" + cyr;

                }
                string invoiceno = dsrecp.Tables[0].Rows[0]["ReceiptStart"].ToString() + "/" + FinYear + "/" + dsrecp.Tables[0].Rows[0]["ReceiptGen_Code"].ToString();
                //calculate gst on intial dep                 
                if (pdoldamtTextBox.Text == "" || pdoldamtTextBox.Text == "NaN" || pdoldamtTextBox.Text == "0" || pdoldamtTextBox.Text == null)
                {
                    double indeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }
                else
                {
                    double oldamt = Convert.ToDouble(pdoldamtTextBox.Text);
                    double fulldeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                    double indeposit = fulldeposit - oldamt;
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }
                //SOR_AdditionalName(ContractdetailsIDTextBox.Text);
                //if (mcwaiver=="Yes")
                //{
                //    PrintPdfDropDownList.Items.Clear();
                //    DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, Request.Form[ntipclubDropDownList.UniqueID], currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text, Affiliate_Type, mcwaiver);
                //    PrintPdfDropDownList.DataSource = ds21;
                //    PrintPdfDropDownList.DataTextField = "printname";
                //    PrintPdfDropDownList.DataValueField = "printname";
                //    PrintPdfDropDownList.AppendDataBoundItems = true;
                //    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                //    PrintPdfDropDownList.DataBind();

                //    //   string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
                //    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";

                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                //}
                //else if(mcwaiver=="No")
                //{
                //    PrintPdfDropDownList.Items.Clear();
                //    DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, Request.Form[ntipclubDropDownList.UniqueID], currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text, Affiliate_Type, mcwaiver);
                //    PrintPdfDropDownList.DataSource = ds21;
                //    PrintPdfDropDownList.DataTextField = "printname";
                //    PrintPdfDropDownList.DataValueField = "printname";
                //    PrintPdfDropDownList.AppendDataBoundItems = true;
                //    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                //    PrintPdfDropDownList.DataBind();

                //    //string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
                //    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";

                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                //}
                SOR_AdditionalName(contractdetailsID);
                LoadDocuments(contractdetailsID, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeDropDownList.SelectedItem.Text, Affiliate_Type, mcwaiver, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);
                string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";


                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);


            }
            else if (contracttype == "Trade-In-Weeks")
                {
                    if (financeradio == "Finance")
                    {
                        if (Finance_Type == "Pashuram Finance")
                        {
                            IGSTrate = "18";
                            Interestrate = "19";
                        }
                        else
                        {
                            IGSTrate = "0";
                            Interestrate = "0";
                        }
                        Finance_No = FinancenoTextBox.Text;
                        documentationfee = findocfeeTextBox.Text;
                        IGST_Amount = igstamtTextBox.Text;
                        No_Emi = noemiTextBox.Text;
                        emiamt = emiamtTextBox.Text;
                    }
                    else if (financeradio == "Non Finance")
                    {

                        Finance_No = "0";
                        documentationfee = "0";
                        IGST_Amount = "0";
                        No_Emi = "0";
                        emiamt = "0";
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    DataSet dsmc = Queries.LoadMCChart(Request.Form[nmclubDropDownList.UniqueID] , nmfirstyrTextBox.Text, currencyDropDownList.SelectedItem.Text);

                    if (dsmc.Tables[0].Rows.Count == 0)
                    {
                        propertyfee = "0";
                        memberfee = "0";
                    membercgst = "TBA";
                    membersgst = "TBA";

                }
                else
                {
                    propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                    memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                    membercgst = dsmc.Tables[0].Rows[0]["Member_CGST"].ToString();
                    membersgst = dsmc.Tables[0].Rows[0]["Member_SGST"].ToString();
                }
                int occyr = Convert.ToInt32(nmfirstyrTextBox.Text) - 1;
                    string mcstartdate = "01/10/" + occyr;
             
                int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee, membercgst, membersgst, CanxContractNoTextBox.Text,contractdetailsID,"",LoanBUOfficerTextBox.Text,gstinTextBox.Text,companypanoTextBox.Text  );
                string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee + memberfee + "," + "Canx Contract No:" + CanxContractNoTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Canx Date:" + "" + "," + "Loan BU Officer:" + LoanBUOfficerTextBox.Text + "," + "GSTIN No:" + gstinTextBox.Text + "," + "Co. Pan No:" + companypanoTextBox.Text;
                int insertlog1 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log1, user, DateTime.Now.ToString());

                //update
                int updateGetContractDetails_Indian_ID = Queries.UpdateContractDetails_Indian_ID(officeTextBox.Text);

                if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian"||PrimarynationalityDropDownList.SelectedItem.Text == "INDIAN" || PrimarynationalityDropDownList.SelectedItem.Text == "OCI" || PrimarynationalityDropDownList.SelectedItem.Text == "PIO")
                {
                    int updatecontno = Queries.UpdateContractNoInd(VenueDropDownList.SelectedItem.Text, Request.Form[nmclubDropDownList.UniqueID]);

                }
                else
                {
                    int updatecontno = Queries.UpdateContractNoNInd(VenueDropDownList.SelectedItem.Text, Request.Form[nmclubDropDownList.UniqueID]);
                }

                string ContractTradeInWeeks_ID = Queries.GetContract_Trade_In_Weeks_Indian_ID(officeTextBox.Text);// GetContract_Trade_In_Points_Indian();
                    int inserttradeinweeks = Queries.InsertContract_Trade_In_Weeks_Indian(ContractTradeInWeeks_ID, profileid, contractno, tnmresortTextBox.Text.ToUpper(), tnmapttypeTextBox.Text.ToUpper(), tnmseasonDropDownList.SelectedItem.Text, nmnowksTextBox.Text.ToUpper(), nmcontrcinoTextBox.Text.ToUpper(), nmpointsvalueTextBox.Text, Request.Form[nmclubDropDownList.UniqueID], nmnewpointsrightsTextBox.Text, nmembtypeDropDownList.SelectedItem.Text, nmtotalpointsTextBox.Text, nmfirstyrTextBox.Text, nmtenureTextBox.Text, nmlastyrTextBox.Text,nmnopersonsTextBox.Text, contractdetailsID);
                string log2 = "Trade in weeks details:" + "tradeinweeks id:" + ContractTradeInWeeks_ID + "," + "Profile id:" + profileid + "," + "ContractNo:" + contractno + "," + "Resort:" + tnmresortTextBox.Text.ToUpper() + "," + "Apt Type:" + tnmapttypeTextBox.Text.ToUpper() + "," + "Season:" + tnmseasonDropDownList.SelectedItem.Text + "," + "No Wks:" + nmnowksTextBox.Text.ToUpper() + "," + "Cont.No:" + nmcontrcinoTextBox.Text.ToUpper() + "," + "PointsValue:" + nmpointsvalueTextBox.Text + "," + "Club:" + Request.Form[nmclubDropDownList.UniqueID] + "," + "New Points:" + nmnewpointsrightsTextBox.Text + "," + "Entitlement:" + nmembtypeDropDownList.SelectedItem.Text + "," + "Total Points:" + nmtotalpointsTextBox.Text + "," + "1st Yr Occ:" + nmfirstyrTextBox.Text + "," + "Tenure:" + nmtenureTextBox.Text + "," + "Last Yr Occ:" + nmlastyrTextBox.Text + "," + "No.persons:" + nmnopersonsTextBox.Text + "," + "contractdetailsID:" + contractdetailsID;
                int insertlog2 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log2, user, DateTime.Now.ToString());
                int updatetiwgeno = Queries.UpdateContract_Trade_In_Weeks_Indian_ID(officeTextBox.Text);


                int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "","","","", contractdetailsID,baladepamtdateTextBox.Text ,"");
                int updatefinanceid = Queries.UpdateFinance_Details_Indian_ID(officeTextBox.Text);



                // string Contract_PA_Id = Queries.GetContract_PA_Indian();
                string Contract_PA_Id = Queries.GetContract_PA_Indian_ID(officeTextBox.Text);
                string balpa;
                if (balancedueTextBox.Text == "" || balancedueTextBox.Text == null || balancedueTextBox.Text == "NaN")
                {
                    balpa = "NIL";
                }
                else
                {
                    balpa = balancedueTextBox.Text;
                }
                int insertpointsPA = Queries.InsertContract_PA_Indian(Contract_PA_Id, profileid, contractno, newpointsTextBox.Text, conversionfeeTextBox.Text, adminfeeTextBox.Text, totpurchpriceTextBox.Text, cgstTextBox.Text, sgstTextBox.Text, Total_Price_Including_Tax, depositTextBox.Text, balanceTextBox.Text, balpa, remarksTextBox.Text, contractdetailsID);
                    string log4 = "Trade in weeks:" + "PA_ID:" + Contract_PA_Id + "," + "Profileid:" + profileid + "," + "ContractNO:" + contractno + "," + "New Points:" + newpointsTextBox.Text + "," + "Conversion Fee:" + conversionfeeTextBox.Text + "," + "Admin Fee:" + adminfeeTextBox.Text + "," + "Total Purchase price:" + totpurchpriceTextBox.Text + "," + "CGST:" + cgstTextBox.Text + "," + "SGST:" + sgstTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Deposit Amt:" + depositTextBox.Text + "," + "balance Amt:" + balanceTextBox.Text + "," + "Balance Due date:" + balpa + "," + "remark:" + remarksTextBox.Text + "," + "contractdetailsID:" + contractdetailsID;
                int insertlog4 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log4, user, DateTime.Now.ToString());
                int updatepageno = Queries.UpdateContract_PA_Indian_ID(officeTextBox.Text);

                if (NoinstallmentTextBox.Text == "")
                { }
                else
                {

                    for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                    {
                        string installemnt_No = inst + " " + i;
                        ia = "textBox_" + i + "1";
                        iamt = Request.Form[ia];
                        idt = "textBox_" + i + "2";
                        idate = Request.Form[idt];

                        int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), contractdetailsID);
                        string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "contractdetailsID:" + contractdetailsID;
                        int insertlog5 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log5, user, DateTime.Now.ToString());
                        //update instalmentno
                        int update  = Queries.UpdateInstallmentInvoiceNo(office);
                    }


                    if (financeradio == "Finance")
                    {
                        //get max installmentdate n update finance startdate
                        int updatefin = Queries.UpdatefinanceStartdate(contractno);
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno) + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + "0" + "," + "RegistryCollection Amt:" + "0" + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + "";
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());
                        int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type, contracttypeDropDownList.SelectedItem.Text);
                        financebreakup(noemiTextBox.Text, balamtpayableTextBox.Text, emiamtTextBox.Text, contractdetailsID, contracttypeDropDownList.SelectedItem.Text, contractno);
                    }
                    else if (financeradio == "Non Finance")
                    {
                        string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + "0" + "," + "RegistryCollection Amt:" + "0" + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + "";
                        int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());

                    }
                }

                //generate receipt               
                DataSet dsrecp = Queries.LoadIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                int CurrentYear = DateTime.Today.Year;
                int PreviousYear = DateTime.Today.Year - 1;
                int NextYear = DateTime.Today.Year + 1;
                string PreYear = PreviousYear.ToString();
                string NexYear = NextYear.ToString();
                string CurYear = CurrentYear.ToString();
                int cyr = Convert.ToInt32(CurYear) % 100;
                string cyr1 = cyr.ToString("yy");
                int tpyr = Convert.ToInt32(PreYear) % 100;
                int nxyr = Convert.ToInt32(NexYear) % 100;
                string FinYear = null;

                if (DateTime.Today.Month > 3)
                {
                    //  FinYear = cyr + "-" + nxyr;
                    FinYear = CurrentYear + "-" + nxyr;
                }
                else
                {
                    //FinYear = tpyr + "-" + cyr;
                    FinYear = PreviousYear + "-" + cyr;

                }
                string invoiceno = dsrecp.Tables[0].Rows[0]["ReceiptStart"].ToString() + "/" + FinYear + "/" + dsrecp.Tables[0].Rows[0]["ReceiptGen_Code"].ToString();
                //calculate gst on intial dep                 
                if (pdoldamtTextBox.Text == "" || pdoldamtTextBox.Text == "NaN" || pdoldamtTextBox.Text == "0" || pdoldamtTextBox.Text == null)
                {
                    double indeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }
                else
                {
                    double oldamt = Convert.ToDouble(pdoldamtTextBox.Text);
                    double fulldeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                    double indeposit = fulldeposit - oldamt;
                    double gst = Math.Round(indeposit / 118 * 18 / 2);
                    double taxableamt = Math.Round(indeposit / 118 * 100);
                    string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "SALE OF POINTS (TIMESHARE)", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                    string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "SALE OF POINTS (TIMESHARE)" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                    int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                    int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                    //update receiptgen no
                    int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                }
                //SOR_AdditionalName(ContractdetailsIDTextBox.Text);
                //if (mcwaiver == "Yes")
                //{
                //    PrintPdfDropDownList.Items.Clear();

                //    DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, Request.Form[nmclubDropDownList.UniqueID], currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text, Affiliate_Type, mcwaiver);
                //    PrintPdfDropDownList.DataSource = ds21;
                //    PrintPdfDropDownList.DataTextField = "printname";
                //    PrintPdfDropDownList.DataValueField = "printname";
                //    PrintPdfDropDownList.AppendDataBoundItems = true;
                //    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                //    PrintPdfDropDownList.DataBind();
                //    //  string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
                //    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";

                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                //}
                //else if (mcwaiver=="No")
                //{
                //    PrintPdfDropDownList.Items.Clear();

                //    DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, Request.Form[nmclubDropDownList.UniqueID], currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text, Affiliate_Type, mcwaiver);
                //    PrintPdfDropDownList.DataSource = ds21;
                //    PrintPdfDropDownList.DataTextField = "printname";
                //    PrintPdfDropDownList.DataValueField = "printname";
                //    PrintPdfDropDownList.AppendDataBoundItems = true;
                //    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                //    PrintPdfDropDownList.DataBind();

                //    //string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });  $( '#tabs' ).tabs({ active: 3 }); });</script> ";
                //    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";

                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                //}
                SOR_AdditionalName(contractdetailsID);
                LoadDocuments(contractdetailsID, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeDropDownList.SelectedItem.Text, Affiliate_Type, mcwaiver, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);
                string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";


                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);


            }
            else if (contracttype == "Trade-In-Fractionals")
                {

                    if (oldcontracttypeTextBox.Text == "Weeks")
                    {
                        if (financeradio == "Finance")
                        {
                            if (Finance_Type == "Pashuram Finance")
                            {
                                IGSTrate = "18";
                                Interestrate = "11";
                            }
                            else
                            {
                                IGSTrate = "0";
                                Interestrate = "0";
                            }
                            Finance_No = FinancenoTextBox.Text;
                            documentationfee = findocfeeTextBox.Text;
                            IGST_Amount = igstamtTextBox.Text;
                            No_Emi = noemiTextBox.Text;
                            emiamt = emiamtTextBox.Text;
                        }
                        else if (financeradio == "Non Finance")
                        {

                            Finance_No = "0";
                            documentationfee = "0";
                            IGST_Amount = "0";
                            No_Emi = "0";
                            emiamt = "0";
                            IGSTrate = "0";
                            Interestrate = "0";
                        }
                      string resort = Request.Form[fwresortDropDownList.UniqueID];// .SelectedItem.Text;
                        string yr = fwfirstyrTextBox.Text;
                        string cur = currencyDropDownList.SelectedItem.Text;
                        string res = fwresidencetype1TextBox.Text;
                        string farr = fwfractIntDropDownList.SelectedItem.Text;
                        //lease back saved on mcfeestextbox

                        //get mc charges
                        DataSet dsmc = Queries.LoadMCChartfractional(resort, yr, cur, farr, res);
                        if (dsmc.Tables[0].Rows.Count == 0)
                        {
                            propertyfee = "0";
                            memberfee = "0";
                        membercgst = "TBA";
                        membersgst = "TBA";

                    }
                    else
                    {
                        propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                        memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                        membercgst = dsmc.Tables[0].Rows[0]["Member_CGST"].ToString();
                        membersgst = dsmc.Tables[0].Rows[0]["Member_SGST"].ToString();
                    }

                    int occyr = Convert.ToInt32(fwfirstyrTextBox.Text) - 1;
                        string mcstartdate = "01/10/" + occyr;
                 
                    int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee, membercgst, membersgst, CanxContractNoTextBox.Text,contractdetailsID,"",LoanBUOfficerTextBox.Text,gstinTextBox.Text,companypanoTextBox.Text );

                    string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee + memberfee + "," + "Canx Contract No:" + CanxContractNoTextBox.Text + "," + "contractdetailsID:" + contractdetailsID+","+"Canx Date:"+"" + "," + "Loan BU Officer:" + LoanBUOfficerTextBox.Text + "," + "GSTIN No:" + gstinTextBox.Text + "," + "Co. Pan No:" + companypanoTextBox.Text;
                    int insertlog1 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log1, user, DateTime.Now.ToString());
                    //update
                    int updateGetContractDetails_Indian_ID = Queries.UpdateContractDetails_Indian_ID(officeTextBox.Text);

                    if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian"|| PrimarynationalityDropDownList.SelectedItem.Text == "INDIAN" || PrimarynationalityDropDownList.SelectedItem.Text == "OCI" || PrimarynationalityDropDownList.SelectedItem.Text == "PIO")
                    {
                        int updatecontno = Queries.UpdateResortNoInd(VenueDropDownList.SelectedItem.Text, Request.Form[fwresortDropDownList.UniqueID]);
                    }
                    else
                    {
                        int updatecontno = Queries.UpdateResortNoNonInd(VenueDropDownList.SelectedItem.Text, Request.Form[fwresortDropDownList.UniqueID]);

                    }


                    string ContractFractionalIndian_ID = Queries.GetContract_Fractional_Indian_ID(officeTextBox.Text);//  GetContract_Fractional_Indian();
                        int insertfractional = Queries.InsertContract_Fractional_Indian(ContractFractionalIndian_ID, profileid, contractno, Request.Form[fwresortDropDownList.UniqueID], fwresidenceno1TextBox.Text, fwresidencetype1TextBox.Text, fwfractIntDropDownList.SelectedItem.Text, fwentitlementDropDownList.SelectedItem.Text, fwfirstyrTextBox.Text, fwtenureTextBox.Text, fwlastyrTextBox.Text, MCFeesTextBox.Text, propertyfee, contractdetailsID);
                        string log2 = "Fractional Details:" + "ContractFractionalIndian_ID:" + ContractFractionalIndian_ID + "," + "profileid:" + profileid + "," + "contractno:" + contractno + "," + "Resort:" + Request.Form[fwresortDropDownList.UniqueID] + "," + "Residence No:" + testresnoTextBox.Text + "," + "Residence type:" + testresTextBox.Text + "," + "Fractional Interest:" + FractionalInterestDropDownList.SelectedItem.Text + "," + "Entitlement:" + EntitlementFracDropDownList.SelectedItem.Text + "," + "1st Yr Occ:" + ffirstyrTextBox.Text + "," + "Tenure:" + ftenureTextBox.Text + "," + "last Yr Occ:" + flastyrTextBox.Text + "," + "Lease Back:" + MCFeesTextBox.Text + "," + "Profperty fee:" + propertyfee + "," + "contractdetailsID:" + contractdetailsID; 
                        int insertlog2 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log2, user, DateTime.Now.ToString());
                        int updatefactgeno = Queries.UpdateContract_Fractional_Indian_ID(officeTextBox.Text);

                    string ContractTradeInFractionalIndian_ID = Queries.GetContract_Trade_In_Fractional_Indian_ID(officeTextBox.Text);// GetContract_Trade_In_Fractional_Indian();
                        int inserttradeinfractweeks = Queries.InsertContract_Trade_In_Fractional_Indian(ContractTradeInFractionalIndian_ID, profileid, contractno, oldcontracttypeTextBox.Text, fwresorttradeTextBox.Text.ToUpper(), fwaptTextBox.Text.ToUpper(), fwnowksTextBox.Text.ToUpper(), fwseasonDropDownList.SelectedItem.Text, "", fwptsvalueTextBox.Text, fwconnoTextBox.Text, contractdetailsID);

                        string log6 = "trade in weeks to Fractional:" + "TradeInFractionalIndian_ID:" + ContractTradeInFractionalIndian_ID + "," + "Profile ID:" + profileid + "," + "Contract No:" + contractno + "," + "Old Contract No:" + oldcontracttypeTextBox.Text + "," + "Club:" + fwresorttradeTextBox.Text.ToUpper() + "," + "Apt:" + fwaptTextBox.Text.ToUpper() + "," + "No.Weeks:" + fwnowksTextBox.Text.ToUpper() + "," + "Resort:" + fwseasonDropDownList.SelectedItem.Text + "," + "" + "Points Value:" + fwptsvalueTextBox.Text + "," + "Cont.No:" + fwconnoTextBox.Text.ToUpper() + "," + "contractdetailsID:" + contractdetailsID; 
                        int insertlog6 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log6, user, DateTime.Now.ToString());
                    int updatefacttiw = Queries.UpdateContract_Trade_In_Fractional_Indian_ID(officeTextBox.Text);

                    int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "",foldloanagreementnoTextBox.Text,regcollectiontermTextBox.Text,regcollamtTextBox.Text, contractdetailsID,baladepamtdateTextBox.Text,foldloanamountTextBox.Text );
                    int updatefinanceid = Queries.UpdateFinance_Details_Indian_ID(officeTextBox.Text);



                    string Contract_Fractional_PA_Id = Queries.GetContract_Fractional_PA_Indian_ID(officeTextBox.Text);// Contract_Fractional_PA_Indian();
                    string balpa;
                    if (fractionalbalduedateTextBox.Text == "" || fractionalbalduedateTextBox.Text == null || fractionalbalduedateTextBox.Text == "NaN")
                    {
                        balpa = "NIL";
                    }
                    else
                    {
                        balpa = fractionalbalduedateTextBox.Text;
                    }
                    int insertpointsPA = Queries.InsertContract_Fractional_PA_Indian(Contract_Fractional_PA_Id, profileid, contractno, AdmissionFeesTextBox.Text, AdministrationFeesTextBox.Text, fcgstTextBox.Text, fsgstTextBox.Text, TotalPurchasePriceTextBox.Text, Total_Price_Including_Tax, fractionaldepositTextBox.Text, fractionalbalanceTextBox.Text, balpa, remarksTextBox.Text, ftradeinvalueTextBox.Text, ftotalvalueTextBox.Text, contractdetailsID);
                        string log4 = "Fractional PA Details:" + "Fractional_PA_Id:" + Contract_Fractional_PA_Id + "," + "Profile:" + profileid + "," + "Contract no:" + contractno + "," +"Trade in value:"+ ftradeinvalueTextBox.Text+","+"Total Value:"+ ftotalvalueTextBox.Text+","+"AdmissionFees:" + AdmissionFeesTextBox.Text + "," + " AdministrationFees:" + AdministrationFeesTextBox.Text + "," + "CGST:" + fcgstTextBox.Text + "," + "SGST:" + fsgstTextBox.Text + "," + "total Purchase price:" + TotalPurchasePriceTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "Deposit Amt:" + fractionaldepositTextBox.Text + "," + "balance:" + fractionalbalanceTextBox.Text + "," + "Balance due dates:" + balpa + "," + "Remarks:" + remarksTextBox.Text + "," + "contractdetailsID:" + contractdetailsID; 
                        int insertlog4 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log4, user, DateTime.Now.ToString());
                    int updatefactpa = Queries.UpdateContract_Fractional_PA_Indian_ID(officeTextBox.Text);
                    if (NoinstallmentTextBox.Text == "")
                    { }
                    else
                    {


                        for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), contractdetailsID);
                            string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "contractdetailsID:" + contractdetailsID; 
                            int insertlog5 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        if (financeradio == "Finance")
                        {
                            //get max installmentdate n update finance startdate
                            int updatefin = Queries.UpdatefinanceStartdate(contractno);
                            string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno) + "," + "Old Loan Agreement No:" + foldloanagreementnoTextBox.Text +","+ "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + foldloanamountTextBox.Text; 
                            int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());
                            int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type, contracttypeDropDownList.SelectedItem.Text);
                            financebreakup(noemiTextBox.Text, balamtpayableTextBox.Text, emiamtTextBox.Text, contractdetailsID, contracttypeDropDownList.SelectedItem.Text, contractno);
                        }
                        else if (financeradio == "Non Finance")
                        {
                            string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + foldloanagreementnoTextBox.Text+","+ "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" +foldloanamountTextBox.Text ; 
                            int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());

                        }
                    }
                    //generate receipt               
                    DataSet dsrecp = Queries.LoadIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    int CurrentYear = DateTime.Today.Year;
                    int PreviousYear = DateTime.Today.Year - 1;
                    int NextYear = DateTime.Today.Year + 1;
                    string PreYear = PreviousYear.ToString();
                    string NexYear = NextYear.ToString();
                    string CurYear = CurrentYear.ToString();
                    int cyr = Convert.ToInt32(CurYear) % 100;
                    string cyr1 = cyr.ToString("yy");
                    int tpyr = Convert.ToInt32(PreYear) % 100;
                    int nxyr = Convert.ToInt32(NexYear) % 100;
                    string FinYear = null;

                    if (DateTime.Today.Month > 3)
                    {
                        //  FinYear = cyr + "-" + nxyr;
                        FinYear = CurrentYear + "-" + nxyr;
                    }
                    else
                    {
                        //FinYear = tpyr + "-" + cyr;
                        FinYear = PreviousYear + "-" + cyr;

                    }
                    string invoiceno = dsrecp.Tables[0].Rows[0]["ReceiptStart"].ToString() + "/" + FinYear + "/" + dsrecp.Tables[0].Rows[0]["ReceiptGen_Code"].ToString();
                    //calculate gst on intial dep                 
                    if (frpdoldamtTextBox.Text == "" || frpdoldamtTextBox.Text == "NaN" || frpdoldamtTextBox.Text == "0" || frpdoldamtTextBox.Text == null)
                    {
                        double indeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                        double gst = Math.Round(indeposit / 118 * 18 / 2);
                        double taxableamt = Math.Round(indeposit / 118 * 100);
                        string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                        string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                        int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                        int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        //update receiptgen no
                        int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    }
                    else
                    {
                        double oldamt = Convert.ToDouble(frpdoldamtTextBox.Text);
                        double fulldeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                        double indeposit = fulldeposit - oldamt;
                        double gst = Math.Round(indeposit / 118 * 18 / 2);
                        double taxableamt = Math.Round(indeposit / 118 * 100);
                        string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                        string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                        int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                        int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        //update receiptgen no
                        int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    }
                   
                    SOR_AdditionalName(contractdetailsID);
                    LoadDocuments(contractdetailsID, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeDropDownList.SelectedItem.Text, Affiliate_Type, mcwaiver, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);
                    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";


                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);



                }
                else if (oldcontracttypeTextBox.Text == "Fractionals")
                {
                    if (financeradio == "Finance")
                    {
                        if (Finance_Type == "Pashuram Finance")
                        {
                            IGSTrate = "18";
                            Interestrate = "11";
                        }
                        else
                        {
                            IGSTrate = "0";
                            Interestrate = "0";
                        }
                        Finance_No = FinancenoTextBox.Text;
                        documentationfee = findocfeeTextBox.Text;
                        IGST_Amount = igstamtTextBox.Text;
                        No_Emi = noemiTextBox.Text;
                        emiamt = emiamtTextBox.Text;
                    }
                    else if (financeradio == "Non Finance")
                    {

                        Finance_No = "0";
                        documentationfee = "0";
                        IGST_Amount = "0";
                        No_Emi = "0";
                        emiamt = "0";
                        IGSTrate = "0";
                        Interestrate = "0";
                    }
                    string resort = Request.Form[ffresortDropDownList.UniqueID];// .SelectedItem.Text;
                    string yr = fffirstyrTextBox.Text;
                    string cur = currencyDropDownList.SelectedItem.Text;
                    string res = ffresidencetype1TextBox.Text;
                    string farr = fwfractIntDropDownList.SelectedItem.Text;
                    //lease back saved on mcfeestextbox

                    //get mc charges
                    DataSet dsmc = Queries.LoadMCChartfractional(resort, yr, cur, farr, res);
                    if (dsmc.Tables[0].Rows.Count == 0)
                    {
                        propertyfee = "0";
                        memberfee = "0";
                        membercgst = "TBA";
                        membersgst = "TBA";

                    }
                    else
                    {
                        propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                        memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                        membercgst = dsmc.Tables[0].Rows[0]["Member_CGST"].ToString();
                        membersgst = dsmc.Tables[0].Rows[0]["Member_SGST"].ToString();
                    }

                    int occyr = Convert.ToInt32(fwfirstyrTextBox.Text) - 1;
                    string mcstartdate = "01/10/" + occyr;

                    int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee, membercgst, membersgst, CanxContractNoTextBox.Text, contractdetailsID, "", LoanBUOfficerTextBox.Text, gstinTextBox.Text, companypanoTextBox.Text);

                    string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee + memberfee + "," + "Canx Contract No:" + CanxContractNoTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Canx Date:" + "" + "," + "Loan BU Officer:" + LoanBUOfficerTextBox.Text + "," + "GSTIN No:" + gstinTextBox.Text + "," + "Co. Pan No:" + companypanoTextBox.Text;
                    int insertlog1 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log1, user, DateTime.Now.ToString());
                    //update
                    int updateGetContractDetails_Indian_ID = Queries.UpdateContractDetails_Indian_ID(officeTextBox.Text);

                    if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian" || PrimarynationalityDropDownList.SelectedItem.Text == "INDIAN" || PrimarynationalityDropDownList.SelectedItem.Text == "OCI" || PrimarynationalityDropDownList.SelectedItem.Text == "PIO")
                    {
                        int updatecontno = Queries.UpdateResortNoInd(VenueDropDownList.SelectedItem.Text, Request.Form[ffresortDropDownList.UniqueID]);
                    }
                    else
                    {
                        int updatecontno = Queries.UpdateResortNoNonInd(VenueDropDownList.SelectedItem.Text, Request.Form[ffresortDropDownList.UniqueID]);

                    }


                    string ContractFractionalIndian_ID = Queries.GetContract_Fractional_Indian_ID(officeTextBox.Text);//  GetContract_Fractional_Indian();
                    int insertfractional = Queries.InsertContract_Fractional_Indian(ContractFractionalIndian_ID, profileid, contractno, Request.Form[ffresortDropDownList.UniqueID], ffresidenceno1TextBox.Text, ffresidencetype1TextBox.Text, fffractIntDropDownList.SelectedItem.Text, ffentitlementDropDownList.SelectedItem.Text, fffirstyrTextBox.Text, fftenureTextBox.Text, fflastyrTextBox.Text, MCFeesTextBox.Text, propertyfee, contractdetailsID);
                    string log2 = "Fractional Details:" + "ContractFractionalIndian_ID:" + ContractFractionalIndian_ID + "," + "profileid:" + profileid + "," + "contractno:" + contractno + "," + "Resort:" + Request.Form[ffresortDropDownList.UniqueID] + "," + "Residence No:" + testresnoTextBox.Text + "," + "Residence type:" + testresTextBox.Text + "," + "Fractional Interest:" + fffractIntDropDownList.SelectedItem.Text + "," + "Entitlement:" + ffentitlementDropDownList.SelectedItem.Text + "," + "1st Yr Occ:" + fffirstyrTextBox.Text + "," + "Tenure:" +  fftenureTextBox.Text + "," + "last Yr Occ:" +   fflastyrTextBox.Text + "," + "Lease Back:" + MCFeesTextBox.Text + "," + "Profperty fee:" + propertyfee + "," + "contractdetailsID:" + contractdetailsID;
                    int insertlog2 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log2, user, DateTime.Now.ToString());
                    int updatefactgeno = Queries.UpdateContract_Fractional_Indian_ID(officeTextBox.Text);

                    string ContractTradeInFractionalIndian_ID = Queries.GetContract_Trade_In_Fractional_Indian_ID(officeTextBox.Text);// GetContract_Trade_In_Fractional_Indian();
                    int inserttradeinfractweeks = Queries.InsertContract_Trade_In_Fractional_Indian(ContractTradeInFractionalIndian_ID, profileid, contractno, oldcontracttypeTextBox.Text, ffresorttradeTextBox.Text.ToUpper(), ffaptTextBox.Text.ToUpper(), ffnowksTextBox.Text.ToUpper(), "", "", "", ffconnoTextBox.Text, contractdetailsID);

                    string log6 = "trade in weeks to Fractional:" + "TradeInFractionalIndian_ID:" + ContractTradeInFractionalIndian_ID + "," + "Profile ID:" + profileid + "," + "Contract No:" + contractno + "," + "Old Contract No:" + oldcontracttypeTextBox.Text + "," + "Club:" + ffresorttradeTextBox.Text.ToUpper() + "," + "Apt:" + ffaptTextBox.Text.ToUpper() + "," + "No.Weeks:" + ffnowksTextBox.Text.ToUpper() + "," + "Resort:" + "N" + "," + "No. Pts:"+""+ "Points Value:" + ""+ "," + "Cont.No:" + ffconnoTextBox.Text.ToUpper() + "," + "contractdetailsID:" + contractdetailsID;
                    int insertlog6 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log6, user, DateTime.Now.ToString());
                    int updatefacttiw = Queries.UpdateContract_Trade_In_Fractional_Indian_ID(officeTextBox.Text);

                    int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "", foldloanagreementnoTextBox.Text, regcollectiontermTextBox.Text, regcollamtTextBox.Text, contractdetailsID, baladepamtdateTextBox.Text, ffoldloanamountTextBox.Text);
                    int updatefinanceid = Queries.UpdateFinance_Details_Indian_ID(officeTextBox.Text);



                    string Contract_Fractional_PA_Id = Queries.GetContract_Fractional_PA_Indian_ID(officeTextBox.Text);// Contract_Fractional_PA_Indian();
                    string balpa;
                    if (fractionalbalduedateTextBox.Text == "" || fractionalbalduedateTextBox.Text == null || fractionalbalduedateTextBox.Text == "NaN")
                    {
                        balpa = "NIL";
                    }
                    else
                    {
                        balpa = fractionalbalduedateTextBox.Text;
                    }
                    int insertpointsPA = Queries.InsertContract_Fractional_PA_Indian(Contract_Fractional_PA_Id, profileid, contractno, AdmissionFeesTextBox.Text, AdministrationFeesTextBox.Text, fcgstTextBox.Text, fsgstTextBox.Text, TotalPurchasePriceTextBox.Text, Total_Price_Including_Tax, fractionaldepositTextBox.Text, fractionalbalanceTextBox.Text, balpa, remarksTextBox.Text, ftradeinvalueTextBox.Text, ftotalvalueTextBox.Text, contractdetailsID);
                    string log4 = "Fractional PA Details:" + "Fractional_PA_Id:" + Contract_Fractional_PA_Id + "," + "Profile:" + profileid + "," + "Contract no:" + contractno + "," + "Trade in value:" + ftradeinvalueTextBox.Text + "," + "Total Value:" + ftotalvalueTextBox.Text + "," + "AdmissionFees:" + AdmissionFeesTextBox.Text + "," + " AdministrationFees:" + AdministrationFeesTextBox.Text + "," + "CGST:" + fcgstTextBox.Text + "," + "SGST:" + fsgstTextBox.Text + "," + "total Purchase price:" + TotalPurchasePriceTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "Deposit Amt:" + fractionaldepositTextBox.Text + "," + "balance:" + fractionalbalanceTextBox.Text + "," + "Balance due dates:" + balpa + "," + "Remarks:" + remarksTextBox.Text + "," + "contractdetailsID:" + contractdetailsID;
                    int insertlog4 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log4, user, DateTime.Now.ToString());
                    int updatefactpa = Queries.UpdateContract_Fractional_PA_Indian_ID(officeTextBox.Text);
                    if (NoinstallmentTextBox.Text == "")
                    { }
                    else
                    {


                        for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), contractdetailsID);
                            string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "contractdetailsID:" + contractdetailsID;
                            int insertlog5 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        if (financeradio == "Finance")
                        {
                            //get max installmentdate n update finance startdate
                            int updatefin = Queries.UpdatefinanceStartdate(contractno);
                            string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno) + "," + "Old Loan Agreement No:" + foldloanagreementnoTextBox.Text + "," + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + ffoldloanamountTextBox.Text;
                            int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());
                            int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type, contracttypeDropDownList.SelectedItem.Text);
                            financebreakup(noemiTextBox.Text, balamtpayableTextBox.Text, emiamtTextBox.Text, contractdetailsID, contracttypeDropDownList.SelectedItem.Text, contractno);
                        }
                        else if (financeradio == "Non Finance")
                        {
                            string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + foldloanagreementnoTextBox.Text + "," + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + ffoldloanamountTextBox.Text;
                            int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());

                        }
                    }
                    //generate receipt               
                    DataSet dsrecp = Queries.LoadIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    int CurrentYear = DateTime.Today.Year;
                    int PreviousYear = DateTime.Today.Year - 1;
                    int NextYear = DateTime.Today.Year + 1;
                    string PreYear = PreviousYear.ToString();
                    string NexYear = NextYear.ToString();
                    string CurYear = CurrentYear.ToString();
                    int cyr = Convert.ToInt32(CurYear) % 100;
                    string cyr1 = cyr.ToString("yy");
                    int tpyr = Convert.ToInt32(PreYear) % 100;
                    int nxyr = Convert.ToInt32(NexYear) % 100;
                    string FinYear = null;

                    if (DateTime.Today.Month > 3)
                    {
                        //  FinYear = cyr + "-" + nxyr;
                        FinYear = CurrentYear + "-" + nxyr;
                    }
                    else
                    {
                        //FinYear = tpyr + "-" + cyr;
                        FinYear = PreviousYear + "-" + cyr;

                    }
                    string invoiceno = dsrecp.Tables[0].Rows[0]["ReceiptStart"].ToString() + "/" + FinYear + "/" + dsrecp.Tables[0].Rows[0]["ReceiptGen_Code"].ToString();
                    //calculate gst on intial dep                 
                    if (frpdoldamtTextBox.Text == "" || frpdoldamtTextBox.Text == "NaN" || frpdoldamtTextBox.Text == "0" || frpdoldamtTextBox.Text == null)
                    {
                        double indeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                        double gst = Math.Round(indeposit / 118 * 18 / 2);
                        double taxableamt = Math.Round(indeposit / 118 * 100);
                        string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                        string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                        int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                        int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        //update receiptgen no
                        int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    }
                    else
                    {
                        double oldamt = Convert.ToDouble(frpdoldamtTextBox.Text);
                        double fulldeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                        double indeposit = fulldeposit - oldamt;
                        double gst = Math.Round(indeposit / 118 * 18 / 2);
                        double taxableamt = Math.Round(indeposit / 118 * 100);
                        string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                        string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                        int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                        int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        //update receiptgen no
                        int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    }
                   
                    SOR_AdditionalName(contractdetailsID);
                    LoadDocuments(contractdetailsID, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeDropDownList.SelectedItem.Text, Affiliate_Type, mcwaiver, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);
                    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";


                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);



                }
                else if (oldcontracttypeTextBox.Text == "Points")
                    {
                        if (financeradio == "Finance")
                        {
                            if (Finance_Type == "Pashuram Finance")
                            {
                                IGSTrate = "18";
                                Interestrate = "11";
                            }
                            else
                            {
                                IGSTrate = "0";
                                Interestrate = "0";
                            }
                            Finance_No = FinancenoTextBox.Text;
                            documentationfee = findocfeeTextBox.Text;
                            IGST_Amount = igstamtTextBox.Text;
                            No_Emi = noemiTextBox.Text;
                            emiamt = emiamtTextBox.Text;
                        }
                        else if (financeradio == "Non Finance")
                        {

                            Finance_No = "0";
                            documentationfee = "0";
                            IGST_Amount = "0";
                            No_Emi = "0";
                            emiamt = "0";
                            IGSTrate = "0";
                            Interestrate = "0";
                        }
                    string resort = Request.Form[fptsresortDropDownList.UniqueID];
                        string yr = fptsfirstyrTextBox.Text;
                        string cur = currencyDropDownList.SelectedItem.Text;
                        string res = fptsresidencetype1TextBox.Text;
                        string farr = fptsfracintDropDownList.SelectedItem.Text;
                        //lease back saved on mcfeestextbox

                        //get mc charges
                        DataSet dsmc = Queries.LoadMCChartfractional(resort, yr, cur, farr, res);
                        if (dsmc.Tables[0].Rows.Count == 0)
                        {
                            propertyfee = "0";
                            memberfee = "0";
                        membercgst = "TBA";
                        membersgst = "TBA";

                    }
                    else
                    {
                        propertyfee = dsmc.Tables[0].Rows[0]["Property_fee"].ToString();
                        memberfee = dsmc.Tables[0].Rows[0]["Member_fee"].ToString();
                        membercgst = dsmc.Tables[0].Rows[0]["Member_CGST"].ToString();
                        membersgst = dsmc.Tables[0].Rows[0]["Member_SGST"].ToString();
                    }

                       int occyr = Convert.ToInt32(fptsfirstyrTextBox.Text) - 1;
                        string mcstartdate = "01/10/" + occyr;
                   // string contractdetailsID = Queries.GetContractDetails_Indian();
                    int insertcontractdetails = Queries.InsertContractDetails_Indian(contractno, profileid, contsalesrepDropDownList.SelectedItem.Text, TOManagerDropDownList.SelectedItem.Text, ButtonUpDropDownList.SelectedItem.Text, dealdateTextBox.Text, dealstatusDropDownList.SelectedItem.Text, DateTime.Now.ToShortDateString(), "", contracttypeDropDownList.SelectedItem.Text, mcwaiver, financeradiobuttonlist.SelectedItem.Text, "", pancardnoTextBox.Text, adharcardTextBox.Text, propertyfee, mcstartdate, memberfee, membercgst, membersgst, CanxContractNoTextBox.Text,contractdetailsID,"",LoanBUOfficerTextBox.Text,gstinTextBox.Text,companypanoTextBox.Text  );
                    string log1 = "Contract Created:" + " " + "with Contract # : " + "contractno" + " " + "for profile ID:" + profileid + "  " + "SalesRep:" + contsalesrepDropDownList.SelectedItem.Text + "," + "TO Manager:" + TOManagerDropDownList.SelectedItem.Text + "," + "Button Up:" + ButtonUpDropDownList.SelectedItem.Text + "," + "Deal Date:" + dealdateTextBox.Text + "," + "Deal Status:" + dealstatusDropDownList.SelectedItem.Text + "," + "Contract Created DAte:" + DateTime.Now.ToShortDateString() + "," + "" + "Contract type:" + contracttypeDropDownList.SelectedItem.Text + "," + "MC Waiver Applicable:" + mcwaiver + "," + "Mode:" + financeradiobuttonlist.SelectedItem.Text + "," + "Remark:" + "" + "Pancard:" + pancardnoTextBox.Text + "," + "Adhar card:" + adharcardTextBox.Text + "," + "Property fee:" + propertyfee + "," + "MC First Yr:" + mcstartdate + "," + "Memberfee:" + memberfee + memberfee + "," + "Canx Contract No:" + CanxContractNoTextBox.Text + "," + "contractdetailsID:" + contractdetailsID+","+"Canx Date:"+"" + "," + "Loan BU Officer:" + LoanBUOfficerTextBox.Text + "," + "GSTIN No:" + gstinTextBox.Text + "," + "Co. Pan No:" + companypanoTextBox.Text;
                    int insertlog1 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log1, user, DateTime.Now.ToString());
                    //update
                    int updateGetContractDetails_Indian_ID = Queries.UpdateContractDetails_Indian_ID(officeTextBox.Text);

                    // update contractno n finance no
                    if (PrimarynationalityDropDownList.SelectedItem.Text == "Indian"|| PrimarynationalityDropDownList.SelectedItem.Text == "INDIAN" || PrimarynationalityDropDownList.SelectedItem.Text == "OCI" || PrimarynationalityDropDownList.SelectedItem.Text == "PIO")
                    {
                        int updatecontno = Queries.UpdateResortNoInd(VenueDropDownList.SelectedItem.Text, Request.Form[fptsresortDropDownList.UniqueID]);
                    }
                    else
                    {
                        int updatecontno = Queries.UpdateResortNoNonInd(VenueDropDownList.SelectedItem.Text, Request.Form[fptsresortDropDownList.UniqueID]);

                    }
                    // string ContractFractionalIndian_ID = Queries.GetContract_Fractional_Indian();
                    string ContractFractionalIndian_ID = Queries.GetContract_Fractional_Indian_ID(officeTextBox.Text);
 
                         int insertfractional = Queries.InsertContract_Fractional_Indian(ContractFractionalIndian_ID, profileid, contractno, Request.Form[fptsresortDropDownList.UniqueID], fptsResidenceno1TextBox.Text, fptsresidencetype1TextBox.Text, fptsfracintDropDownList.SelectedItem.Text, fptsentitlementDropDownList.SelectedItem.Text, fptsfirstyrTextBox.Text, fptstenureTextBox.Text, fptslastyrTextBox.Text, MCFeesTextBox.Text, propertyfee, contractdetailsID);
                        string log2 = "Fractional Details:" + "ContractFractionalIndian_ID:" + ContractFractionalIndian_ID + "," + "profileid:" + profileid + "," + "contractno:" + contractno + "," + "Resort:" + Request.Form[fptsresortDropDownList.UniqueID] + "," + "Residence No:" + testresnoTextBox.Text + "," + "Residence type:" + testresTextBox.Text + "," + "Fractional Interest:" + FractionalInterestDropDownList.SelectedItem.Text + "," + "Entitlement:" + EntitlementFracDropDownList.SelectedItem.Text + "," + "1st Yr Occ:" + ffirstyrTextBox.Text + "," + "Tenure:" + ftenureTextBox.Text + "," + "last Yr Occ:" + flastyrTextBox.Text + "," + "Lease Back:" + MCFeesTextBox.Text + "," + "Profperty fee:" + propertyfee + "," + "contractdetailsID:" + contractdetailsID; 
                        int insertlog2 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log2, user, DateTime.Now.ToString());
                    int updatefactgeno = Queries.UpdateContract_Fractional_Indian_ID(officeTextBox.Text);

                    //    string ContractTradeInFractionalIndian_ID = Queries.GetContract_Trade_In_Fractional_Indian();
                    string ContractTradeInFractionalIndian_ID = Queries.GetContract_Trade_In_Fractional_Indian_ID(officeTextBox.Text);// GetContract_Trade_In_Fractional_Indian();
                    int inserttradeinfractpoints = Queries.InsertContract_Trade_In_Fractional_Indian(ContractTradeInFractionalIndian_ID, profileid, contractno, oldcontracttypeTextBox.Text, fptsclubTextBox.Text.ToUpper(), "", "", "", fptsnoptsTextBox.Text, fptsvalTextBox.Text, fptscontnoTextBox.Text.ToUpper(), contractdetailsID);

                        string log6 = "trade in points to Fractional:" + "TradeInFractionalIndian_ID:" + ContractTradeInFractionalIndian_ID + "," + "Profile ID:" + profileid + "," + "Contract No:" + contractno + "," + "Old Contract No:" + oldcontracttypeTextBox.Text + "," + "Club:" + fptsclubTextBox.Text.ToUpper() + "," + "Points:" + fptsnoptsTextBox.Text + "," + "Points Value:" + fptsvalTextBox.Text + "," + "Cont.No:" + fptscontnoTextBox.Text.ToUpper() + "," + "contractdetailsID:" + contractdetailsID;
                    int insertlog6 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log6, user, DateTime.Now.ToString());
                    int updatefacttiw = Queries.UpdateContract_Trade_In_Fractional_Indian_ID(officeTextBox.Text);

                    int insertpointsfinancedetails = Queries.InsertFinance_Details_Indian(Finance_Details_Id, profileid, contractno, financeradio, currency, Affiliate_Type, Total_Price_Including_Tax, Initial_Deposit_Percent, Initial_Deposit_Amount, Balance_Payable, Total_Inital_Deposit, Initial_Deposit_Balance, Bal_Amount_Payable, Payment_Method, No_Installments.ToString(), Installment_Amount, Finance_Type, Finance_No, IGSTrate, Interestrate, documentationfee, IGST_Amount, No_Emi, emiamt, "",oldLoanAgreementTextBox.Text,regcollectiontermTextBox.Text,regcollamtTextBox.Text, contractdetailsID,baladepamtdateTextBox.Text,oldloanamountTextBox.Text);
                    int updatefinanceid = Queries.UpdateFinance_Details_Indian_ID(officeTextBox.Text);

                    // string Contract_Fractional_PA_Id = Queries.GetContract_Fractional_PA_Indian();
                    string Contract_Fractional_PA_Id = Queries.GetContract_Fractional_PA_Indian_ID(officeTextBox.Text);// Contract_Fractional_PA_Indian();
                    string balpa;
                    if (fractionalbalduedateTextBox.Text == "" || fractionalbalduedateTextBox.Text == null || fractionalbalduedateTextBox.Text == "NaN")
                    {
                        balpa = "NIL";
                    }
                    else
                    {
                        balpa = fractionalbalduedateTextBox.Text;
                    }
                    int insertpointsPA = Queries.InsertContract_Fractional_PA_Indian(Contract_Fractional_PA_Id, profileid, contractno, AdmissionFeesTextBox.Text, AdministrationFeesTextBox.Text, fcgstTextBox.Text, fsgstTextBox.Text, TotalPurchasePriceTextBox.Text, Total_Price_Including_Tax, fractionaldepositTextBox.Text, fractionalbalanceTextBox.Text, balpa, remarksTextBox.Text, ftradeinvalueTextBox.Text, ftotalvalueTextBox.Text, contractdetailsID);
                    string log4 = "Fractional PA Details:" + "Fractional_PA_Id:" + Contract_Fractional_PA_Id + "," + "Profile:" + profileid + "," + "Contract no:" + contractno + "," + "Trade in value:" + ftradeinvalueTextBox.Text + "," + "Total Value:" + ftotalvalueTextBox.Text + "," + "AdmissionFees:" + AdmissionFeesTextBox.Text + "," + " AdministrationFees:" + AdministrationFeesTextBox.Text + "," + "CGST:" + fcgstTextBox.Text + "," + "SGST:" + fsgstTextBox.Text + "," + "total Purchase price:" + TotalPurchasePriceTextBox.Text + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "Deposit Amt:" + fractionaldepositTextBox.Text + "," + "balance:" + fractionalbalanceTextBox.Text + "," + "Balance due dates:" + balpa + "," + "Remarks:" + remarksTextBox.Text + "," + "contractdetailsID:" + contractdetailsID;
                    int insertlog4 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log4, user, DateTime.Now.ToString());
                    int updatefactpa = Queries.UpdateContract_Fractional_PA_Indian_ID(officeTextBox.Text);

                    if (NoinstallmentTextBox.Text == "")
                    {

                    }
                    else
                    {
                        for (i = 1; i <= Convert.ToInt32(No_Installments); i++)
                        {
                            string installemnt_No = inst + " " + i;
                            ia = "textBox_" + i + "1";
                            iamt = Request.Form[ia];
                            idt = "textBox_" + i + "2";
                            idate = Request.Form[idt];

                            int FinanceInvoice = Queries.InsertContract_Installments_Indian(profileid, contractno, installemnt_No, iamt, idate, Queries.GetInstallmentInvoiceNo(office), contractdetailsID);
                            string log5 = "Installment Details:" + "Profile id: " + profileid + "," + "Contractno: " + contractno + "," + "Installment #:" + installemnt_No + "," + "Installment Amt:" + iamt + "," + "Installment Date:" + idate + "," + "contractdetailsID:" + contractdetailsID;
                            int insertlog5 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log5, user, DateTime.Now.ToString());
                            //update instalmentno
                            int update = Queries.UpdateInstallmentInvoiceNo(office);
                        }
                        if (financeradio == "Finance")
                        {
                            //get max installmentdate n update finance startdate
                            int updatefin = Queries.UpdatefinanceStartdate(contractno);
                            string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + Queries.GetFinanceMonth(contractno) + "," + "Old Loan Agreement No:" + oldLoanAgreementTextBox.Text +","+ "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + oldloanamountTextBox.Text ;
                            int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());
                            int updatefinanceno = Queries.UpdateFinanceNo(VenueDropDownList.SelectedItem.Text, Finance_Type, contracttypeDropDownList.SelectedItem.Text);
                            financebreakup(noemiTextBox.Text, balamtpayableTextBox.Text, emiamtTextBox.Text, contractdetailsID, contracttypeDropDownList.SelectedItem.Text, contractno);
                        }
                        else if (financeradio == "Non Finance")
                        {
                            string log3 = "Finance Details:" + " Finance ID:" + Finance_Details_Id + "," + "Profile id:" + profileid + "," + "Contractno:" + contractno + "," + "Mode:" + financeradio + "," + "Currency:" + currency + "," + "Affiliation:" + Affiliate_Type + "," + "Total Price Incl. Tax:" + Total_Price_Including_Tax + "," + "Initial Deposit%:" + Initial_Deposit_Percent + "," + "Depsoit Amt:" + Initial_Deposit_Amount + "," + "Bal Payable if less than 10%:" + Balance_Payable + "," + "Total Initial Deposit:" + Total_Inital_Deposit + "," + "Deposit Bal:" + Initial_Deposit_Balance + "," + "Bal Amt.:" + Bal_Amount_Payable + "," + "Payment Method:" + Payment_Method + "," + "No. Installment:" + No_Installments.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + oldLoanAgreementTextBox.Text +","+ "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "bal Dep Date:" + baladepamtdateTextBox.Text + "," + "Old loan amt:" + oldloanamountTextBox.Text; 
                            int insertlog3 = Queries.InsertContractLogs_India(profileid, contractdetailsID, log3, user, DateTime.Now.ToString());

                        }

                    }

                    //generate receipt               
                    DataSet dsrecp = Queries.LoadIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    int CurrentYear = DateTime.Today.Year;
                    int PreviousYear = DateTime.Today.Year - 1;
                    int NextYear = DateTime.Today.Year + 1;
                    string PreYear = PreviousYear.ToString();
                    string NexYear = NextYear.ToString();
                    string CurYear = CurrentYear.ToString();
                    int cyr = Convert.ToInt32(CurYear) % 100;
                    string cyr1 = cyr.ToString("yy");
                    int tpyr = Convert.ToInt32(PreYear) % 100;
                    int nxyr = Convert.ToInt32(NexYear) % 100;
                    string FinYear = null;
                    if (DateTime.Today.Month > 3)
                    {
                        //  FinYear = cyr + "-" + nxyr;
                        FinYear = CurrentYear + "-" + nxyr;
                    }
                    else
                    {
                        //FinYear = tpyr + "-" + cyr;
                        FinYear = PreviousYear + "-" + cyr;

                    }
                    string invoiceno = dsrecp.Tables[0].Rows[0]["ReceiptStart"].ToString() + "/" + FinYear + "/" + dsrecp.Tables[0].Rows[0]["ReceiptGen_Code"].ToString();
                    //calculate gst on intial dep                 
                    if (frpdoldamtTextBox.Text == "" || frpdoldamtTextBox.Text == "NaN" || frpdoldamtTextBox.Text == "0" || frpdoldamtTextBox.Text == null)
                    {
                        double indeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                        double gst = Math.Round(indeposit / 118 * 18 / 2);
                        double taxableamt = Math.Round(indeposit / 118 * 100);
                        string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                        string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                        int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                        int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        //update receiptgen no
                        int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    }
                    else
                    {
                        double oldamt = Convert.ToDouble(frpdoldamtTextBox.Text);
                        double fulldeposit = Convert.ToDouble(intialdeppercentTextBox.Text);
                        double indeposit = fulldeposit - oldamt;
                        double gst = Math.Round(indeposit / 118 * 18 / 2);
                        double taxableamt = Math.Round(indeposit / 118 * 100);
                        string Contract_Indian_Deposit_ReceiptID = Queries.GetContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        int receipt = Queries.InsertContract_Indian_Deposit_Receipt(Contract_Indian_Deposit_ReceiptID, contractdetailsID, contractno, invoiceno, DateTime.Now.ToShortDateString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString(), dsrecp.Tables[0].Rows[0]["StateCode"].ToString(), "PRESTIGE ROYAL RESIDENCES", "996311", taxableamt.ToString(), taxableamt.ToString(), "9%", gst.ToString(), "9%", gst.ToString(), indeposit.ToString(), depositmethodDropDownList.SelectedItem.Text);
                        string logr = "Invoice Details:" + "Deposit_ReceiptID:" + Contract_Indian_Deposit_ReceiptID + "," + "contractdetails ID:" + contractdetailsID + "," + "Contractno:" + contractno + "," + "Invoice No:" + invoiceno + "," + "Date:" + DateTime.Now.ToShortDateString() + "," + "Supply Place:" + dsrecp.Tables[0].Rows[0]["SupplyPlace"].ToString() + "," + "State Code:" + dsrecp.Tables[0].Rows[0]["StateCode"].ToString() + "," + "Product Code:" + "PRESTIGE ROYAL RESIDENCES" + "," + "SAC:" + "996311" + "," + "Amount:" + taxableamt.ToString() + "," + "Taxable value:" + taxableamt.ToString() + "," + "CGST:" + "9%" + "," + "CGST Amt.:" + gst.ToString() + "," + "SGST:" + "9%" + "," + "SGST Amt:" + gst.ToString() + "," + "Installment Amt.:" + Installment_Amount + "," + "Finance type:" + Finance_Type + "," + "Finance No:" + Finance_No + "," + "IGST Rate:" + IGSTrate + "," + "Interest rate:" + Interestrate + "," + "Documentation fee:" + documentationfee + "," + "IGST Amt:" + IGST_Amount + "," + "No. EMI:" + No_Emi + "," + "Emai Amt:" + emiamt + "," + "Finance Start month:" + "" + "," + "Old Loan Agreement No:" + "" + "RegistryCollection term:" + regcollectiontermTextBox.Text + "," + "RegistryCollection Amt:" + regcollamtTextBox.Text + "," + "contractdetailsID:" + contractdetailsID + "," + "Deposit Payment mode:" + depositmethodDropDownList.SelectedItem.Text;
                        int insertlogr = Queries.InsertContractLogs_India(profileid, contractdetailsID, logr, user, DateTime.Now.ToString());
                        int updategenno = Queries.UpdateContract_Indian_Deposit_Receipt_ID(officeTextBox.Text);
                        //update receiptgen no
                        int updaterecno = Queries.UpdateIndian_ReceiptGeneration(VenueDropDownList.SelectedItem.Text);
                    }
                    //SOR_AdditionalName(ContractdetailsIDTextBox.Text);
                    //if (mcwaiver=="Yes")
                    //{
                    //    PrintPdfDropDownList.Items.Clear();
                    //    DataSet ds21 = Queries.LoadPrintPDFFiles_IndianMC(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, fptsresortDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text, Affiliate_Type, mcwaiver);
                    //    PrintPdfDropDownList.DataSource = ds21;
                    //    PrintPdfDropDownList.DataTextField = "printname";
                    //    PrintPdfDropDownList.DataValueField = "printname";
                    //    PrintPdfDropDownList.AppendDataBoundItems = true;
                    //    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    //    PrintPdfDropDownList.DataBind();
                    //    //  string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });   $( '#tabs' ).tabs({ active: 3 }); });</script> ";
                    //    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                    //}
                    //else if(mcwaiver=="No")
                    //{
                    //    PrintPdfDropDownList.Items.Clear();
                    //    DataSet ds21 = Queries.LoadPrintPDFFiles_IndianNOMC(contracttypeDropDownList.SelectedItem.Text, officeTextBox.Text, fptsresortDropDownList.SelectedItem.Text, currencyDropDownList.SelectedItem.Text, financeradiobuttonlist.SelectedItem.Text, Affiliate_Type, mcwaiver);
                    //    PrintPdfDropDownList.DataSource = ds21;
                    //    PrintPdfDropDownList.DataTextField = "printname";
                    //    PrintPdfDropDownList.DataValueField = "printname";
                    //    PrintPdfDropDownList.AppendDataBoundItems = true;
                    //    PrintPdfDropDownList.Items.Insert(0, new ListItem("", ""));
                    //    PrintPdfDropDownList.DataBind();
                    //    //string script = "<script> $(function() {$('#tabs').tabs({ disabled: [4] });   $( '#tabs' ).tabs({ active: 3 }); });</script> ";
                    //    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                    //}
                    SOR_AdditionalName(contractdetailsID);
                    LoadDocuments(contractdetailsID, officeTextBox.Text, financeradiobuttonlist.SelectedItem.Text, contracttypeDropDownList.SelectedItem.Text, Affiliate_Type, mcwaiver, CanxContractNoTextBox.Text, companynameTextBox.Text, StateDropDownList.SelectedItem.Text);
                    string script = "<script> $(function() {$('#tabs').tabs({ disabled: [5] });  $( '#tabs' ).tabs({ active: 4 }); });</script> ";


                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);


                }

            }

            }     
        


     

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (contracttypeDropDownList.SelectedItem.Text == "Fractionals" )
        {

            string printr = PrintPdfDropDownList.SelectedItem.Text;

            if (printr == "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr.Contains("RECEIPT"))// (printr == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr == "REP REPORT")
            {
                DataTable datatable = Queries.Rep_ReportProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr.Contains("ADDITION"))//(printr == "ADDITION OF NAME LETTER")
            {
                DataTable datatable = Queries.AdditionalName_FractionalProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }
            /*else if (printr.Contains("sor"))
            {
                DataTable datatable = Queries.SOR_FractionalProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }*/
            else
            {
                DataTable datatable = Queries.Fractional_PA(contractnoTextBox.Text);
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(Server.MapPath("~/reports/" + printr + ".rpt"));
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
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");
                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }

        }
        else if (contracttypeDropDownList.SelectedItem.Text == "Points")
        {


            string printr = PrintPdfDropDownList.SelectedItem.Text;
            if (printr == "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr == "REP REPORT")
            {
                DataTable datatable = Queries.Rep_ReportProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr.Contains("ADDITION"))//(printr == "ADDITION OF NAME LETTER")
            {
                DataTable datatable = Queries.AdditionalName_NewPointsProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }
          /*  else if (printr.Contains("sor"))
            {

                

            }*/
            else
            {
                DataTable datatable = Queries.NewPoints_PA(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }


        }
        else if (contracttypeDropDownList.SelectedItem.Text == "Trade-In-Points")
        {


            string printr = PrintPdfDropDownList.SelectedItem.Text;
            if (printr == "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr == "REP REPORT")
            {
                DataTable datatable = Queries.Rep_ReportProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr.Contains("ADDITION"))//(printr == "ADDITION OF NAME LETTER")
            {
                DataTable datatable = Queries.AdditionalName_TIPProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }
            else if (printr.Contains("sor"))
            {
                DataTable datatable = Queries.SOR_TIPProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }
            else
            {
                DataTable datatable = Queries.TradeInPoints_PA(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }

        }
        else if (contracttypeDropDownList.SelectedItem.Text == "Trade-In-Weeks")
        {
            string printr = PrintPdfDropDownList.SelectedItem.Text;
            if (printr == "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr == "REP REPORT")
            {
                DataTable datatable = Queries.Rep_ReportProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr.Contains("ADDITION"))// (printr == "ADDITION OF NAME LETTER")
            {
                DataTable datatable = Queries.AdditionalName_TIWProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }
            else if (printr.Contains("sor"))
            {
                DataTable datatable = Queries.SOR_TIWProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }
            else
            {
                DataTable datatable = Queries.TradeInWeeks_PA(contractnoTextBox.Text);

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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }

        }
        else if (contracttypeDropDownList.SelectedItem.Text == "Trade-In-Fractionals")
        {
            string printr = PrintPdfDropDownList.SelectedItem.Text;
            if (printr == "BREAKUP")
            {
                DataTable datatable = Queries.LoanEMIBreakupFinance(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr == "RECEIPT")
            {
                DataTable datatable = Queries.ReceiptPage(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr == "REP REPORT")
            {
                DataTable datatable = Queries.Rep_ReportProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();
            }
            else if (printr.Contains("ADDITION"))//(printr == "ADDITION OF NAME LETTER")
            {
                DataTable datatable = Queries.AdditionalName_FractionalProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }
            else if (printr.Contains("sor"))
            {
                DataTable datatable = Queries.SOR_FractionalProc(contractnoTextBox.Text);
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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }
            else
            {
                DataTable datatable = Queries.FractionalTradeIn_PA(contractnoTextBox.Text);

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
                //   string fn = "test" + ".pdf";
                string fn = printr + ".pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

                fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
                FileSize = fs.Length;
                byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
                fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
                fs.Close();
                Response.BinaryWrite(bBuffer);
                Response.Flush();

            }
        }



    }


    [WebMethod]
    public static string getPointsAmoountTax(string currency)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        string JSON = "{\n \"names\":[";
        string query = "select amount,taxValue from PointsContract where currency='"+currency+"' and status='Active' ;";
        SqlCommand sql =new SqlCommand(query,sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            double amount = reader.GetDouble(0);
            double tax = reader.GetDouble(1);
            JSON += "[\"" + amount + "\",\"" + tax + "\"],";
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    //Code commented by gaurav 8-12-2017
    //[WebMethod]
    //public static string getContractnoOnClub(string venue, string venuegrp, string club,string nationality)
    //{

    //    string JSON = "{\n \"names\":[";
    //    if(nationality=="Indian")
    //    {
    //        SqlDataReader reader = Queries.GetIncrementValueofContractClubIndian(venue, venuegrp, club, nationality);
    //        while (reader.Read())
    //        {
    //            string code = reader.GetString(0);
    //            //  string src = reader.GetString(1);
    //            //  string inc = reader.GetString(2);
    //            //JSON += "[\"" + code + "\",\"" + src + "\",\"" + inc + "\"],";

    //            JSON += "[\"" + code + "\"],";
    //        }
    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";

    //    }

    //    else
    //    {
    //        SqlDataReader reader = Queries.GetIncrementValueofContractClubNonIndian(venue, venuegrp, club, nationality);
    //        while (reader.Read())
    //        {
    //            string code = reader.GetString(0);
    //            //  string src = reader.GetString(1);
    //            //  string inc = reader.GetString(2);
    //            //JSON += "[\"" + code + "\",\"" + src + "\",\"" + inc + "\"],";
    //            JSON += "[\"" + code + "\"],";
    //        }
    //        JSON = JSON.Substring(0, JSON.Length - 1);
    //        JSON += "] \n}";

    //    }


    //    return JSON;

    //}




        // new code gaurav
    [WebMethod]
        public static string getContractnoOnClub(string venue,string venuegrp,string club,string mk, string nationality)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        sqlcon.Open();
        string JSON = "{\n \"names\":[";
        if (mk == "CANCELLED MEMBER" || mk == "Cancelled Member")
        {
            if (nationality == "Indian" || nationality == "INDIAN" || nationality == "OCI" || nationality == "PIO")
            {
                string query = "SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code+'R' from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality ='INDIAN' or cc.Nationality ='Indian')";
                SqlCommand sql = new SqlCommand(query, sqlcon);

                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    string code = reader.GetString(0);
                    JSON += "[\"" + code + "\"],";
                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }
            else
            {
                string query = "SELECT Contract_Code + '/' + REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '') + '/' + Increment_Value + vg.Venue_group_Code+'R' from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality !='INDIAN'  or cc.Nationality !='Indian')";
                SqlCommand sql = new SqlCommand(query, sqlcon);

                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    string code = reader.GetString(0);
                    JSON += "[\"" + code + "\"],";
                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";

            }

        }
        else
        {


            if (nationality == "Indian" || nationality == "INDIAN" || nationality == "OCI" || nationality == "PIO")
            {
                string query = "SELECT Contract_Code+'/'+ REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '')+'/'+Increment_Value+vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality ='INDIAN' or cc.Nationality ='Indian')";
                SqlCommand sql = new SqlCommand(query, sqlcon);

                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    string code = reader.GetString(0);
                    JSON += "[\"" + code + "\"],";
                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";
            }
            else
            {
                string query = "SELECT Contract_Code + '/' + REPLACE(CONVERT(CHAR(8), GETDATE(), 3), '/', '') + '/' + Increment_Value + vg.Venue_group_Code from Contract_Club cc join Venue_Group vg on vg.Venue_ID = cc.Venue_ID join venue v on v.Venue_ID = vg.Venue_ID where v.Venue_Name ='" + venue + "' and cc.Contract_Club_Name ='" + club + "' and vg.Venue_Group_Name ='" + venuegrp + "' and (cc.Nationality !='INDIAN'  or cc.Nationality !='Indian')";
                SqlCommand sql = new SqlCommand(query, sqlcon);

                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    string code = reader.GetString(0);
                    JSON += "[\"" + code + "\"],";
                }
                JSON = JSON.Substring(0, JSON.Length - 1);
                JSON += "] \n}";

            }
        }

        return JSON;
    }



    [WebMethod]
    public static string getFinanceNo(string venue, string finance,string type)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.GetFinanceNoIncrementValue(venue,finance,type);
        while (reader.Read())
        {
            string code = reader.GetString(0);
             
            JSON += "[\"" + code + "\"],";
           
        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string GetfractionalResidenceType(string resort)
    {

        string JSON = "{\n \"names\":[";
        SqlDataReader reader = Queries.LoadfractionalResidencetype(resort);
        while (reader.Read())
        {
            string type = reader.GetString(0);

            JSON += "[\"" + type + "\"],";

        }
        JSON = JSON.Substring(0, JSON.Length - 1);
        JSON += "] \n}";

        return JSON;

    }
    [WebMethod]
    public static string LoadfractionalResidenceNo(string resort)
    {

        string JSON = "{\n \"names\":[";


        SqlDataReader reader = Queries.LoadfractionalResidenceNo(resort);
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
    public static string getContractnoOnResort(string venue, string club, string nationality)
    {

        string JSON = "{\n \"names\":[";
        if (nationality == "Indian"|| nationality == "INDIAN" || nationality == "OCI" || nationality == "PIO")

        {
            SqlDataReader reader = Queries.GetIncrementValueofContractResortIndian(venue, club);//, nationality);
            while (reader.Read())
            {
                string code = reader.GetString(0);
                 
                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            SqlDataReader reader = Queries.GetIncrementValueofContractResortNonIndian(venue, club);//, nationality);
            while (reader.Read())
            {
                string code = reader.GetString(0);

                JSON += "[\"" + code + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }
        return JSON;

    }


[WebMethod]
public static string LoadClubNameonContractType(string contracttype)
{

    string JSON = "{\n \"names\":[";


    SqlDataReader reader = Queries.LoadClubOnContractType(contracttype);
    while (reader.Read())
    {
        string club = reader.GetString(0);

        JSON += "[\"" + club + "\"],";
    }
    JSON = JSON.Substring(0, JSON.Length - 1);
    JSON += "] \n}";

    return JSON;
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

        string query = "select vg.Venue_Group_ID,vg.Venue_Group_Name from Venue_Group vg where vg.Venue_ID in(select venue.Venue_ID from venue where venue.Venue_Name ='" + venue + "')";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(1);
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








    protected void Button6_Click(object sender, EventArgs e)
    {
        DataSet ds = Queries.LoadProfielDetailsFull(profileidTextBox.Text);
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
        oProfile_Primary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Primary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Primary_DOB"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Primary_Nationality = ds.Tables[0].Rows[0]["Profile_Primary_Nationality"].ToString();
        oProfile_Primary_Country = ds.Tables[0].Rows[0]["Profile_Primary_Country"].ToString();
        opage = ds.Tables[0].Rows[0]["Primary_Age"].ToString();
        opdesignation = ds.Tables[0].Rows[0]["Primary_Designation"].ToString();
        oplang = ds.Tables[0].Rows[0]["Primary_Language"].ToString();

        oProfile_Secondary_Title = ds.Tables[0].Rows[0]["Profile_Secondary_Title"].ToString();
        oProfile_Secondary_Fname = ds.Tables[0].Rows[0]["Profile_Secondary_Fname"].ToString();
        oProfile_Secondary_Lname = ds.Tables[0].Rows[0]["Profile_Secondary_Lname"].ToString();
        
        oProfile_Secondary_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Secondary_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Secondary_DOB"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Secondary_Nationality = ds.Tables[0].Rows[0]["Profile_Secondary_Nationality"].ToString();
        oProfile_Secondary_Country = ds.Tables[0].Rows[0]["Profile_Secondary_Country"].ToString();
        osage = ds.Tables[0].Rows[0]["Secondary_Age"].ToString();
        osdesignation = ds.Tables[0].Rows[0]["Secondary_Designation"].ToString();
        oslang = ds.Tables[0].Rows[0]["Secondary_Language"].ToString();

        oSub_Profile1_Title = ds.Tables[0].Rows[0]["Sub_Profile1_Title"].ToString();
        oSub_Profile1_Fname = ds.Tables[0].Rows[0]["Sub_Profile1_Fname"].ToString();
        oSub_Profile1_Lname = ds.Tables[0].Rows[0]["Sub_Profile1_Lname"].ToString();
        oSub_Profile1_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile1_DOB"]);//Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile1_DOB"].ToString()).ToString("yyyy-MM-dd");
        oSub_Profile1_Nationality = ds.Tables[0].Rows[0]["Sub_Profile1_Nationality"].ToString();
        oSub_Profile1_Country = ds.Tables[0].Rows[0]["Sub_Profile1_Country"].ToString();
        osp1age = ds.Tables[0].Rows[0]["Sub_Profile1_Age"].ToString();

        oSub_Profile2_Title = ds.Tables[0].Rows[0]["Sub_Profile2_Title"].ToString();
        oSub_Profile2_Fname = ds.Tables[0].Rows[0]["Sub_Profile2_Fname"].ToString();
        oSub_Profile2_Lname = ds.Tables[0].Rows[0]["Sub_Profile2_Lname"].ToString();
        oSub_Profile2_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile2_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile2_DOB"].ToString()).ToString("yyyy-MM-dd");
        oSub_Profile2_Nationality = ds.Tables[0].Rows[0]["Sub_Profile2_Nationality"].ToString();
        oSub_Profile2_Country = ds.Tables[0].Rows[0]["Sub_Profile2_Country"].ToString();
        osp2age = ds.Tables[0].Rows[0]["Sub_Profile2_Age"].ToString();

        oSub_Profile3_Title = ds.Tables[0].Rows[0]["Sub_Profile3_Title"].ToString();
        oSub_Profile3_Fname = ds.Tables[0].Rows[0]["Sub_Profile3_Fname"].ToString();
        oSub_Profile3_Lname = ds.Tables[0].Rows[0]["Sub_Profile3_Lname"].ToString();
       
            oSub_Profile3_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile3_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile3_DOB"].ToString()).ToString("yyyy-MM-dd");
      
        oSub_Profile3_Nationality = ds.Tables[0].Rows[0]["Sub_Profile3_Nationality"].ToString();
        oSub_Profile3_Country = ds.Tables[0].Rows[0]["Sub_Profile3_Country"].ToString();
        osp3age = ds.Tables[0].Rows[0]["Sub_Profile3_Age"].ToString();

        oSub_Profile4_Title = ds.Tables[0].Rows[0]["Sub_Profile4_Title"].ToString();
        oSub_Profile4_Fname = ds.Tables[0].Rows[0]["Sub_Profile4_Fname"].ToString();
        oSub_Profile4_Lname = ds.Tables[0].Rows[0]["Sub_Profile4_Lname"].ToString();
       
       
            oSub_Profile4_DOB = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Sub_Profile4_DOB"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Sub_Profile4_DOB"].ToString()).ToString("yyyy-MM-dd");
     
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
        opriOfficecc = ds.Tables[0].Rows[0]["Primary_office_cc"].ToString();
        opriOfficeno= ds.Tables[0].Rows[0]["Primary_office_num"].ToString();
        osecOfficecc = ds.Tables[0].Rows[0]["Secondary_office_cc"].ToString();
        osecofficeno = ds.Tables[0].Rows[0]["Secondary_office_num"].ToString();
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
        oSubprofile4_Email = ds.Tables[0].Rows[0]["Subprofile4_Email"].ToString();

        oProfile_Stay_ID = ds.Tables[0].Rows[0]["Profile_Stay_ID"].ToString();
        oProfile_Stay_Resort_Name = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Name"].ToString();
        oProfile_Stay_Resort_Room_Number = ds.Tables[0].Rows[0]["Profile_Stay_Resort_Room_Number"].ToString();
        oProfile_Stay_Arrival_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Arrival_Date"].ToString()).ToString("yyyy-MM-dd");
        oProfile_Stay_Departure_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Profile_Stay_Departure_Date"].ToString()).ToString("yyyy-MM-dd");

        oTour_Details_Guest_Status = ds.Tables[0].Rows[0]["Tour_Details_Guest_Status"].ToString();
        oTour_Details_Guest_Sales_Rep = ds.Tables[0].Rows[0]["Tour_Details_Guest_Sales_Rep"].ToString();
        oTour_Details_Tour_Date = String.Format("{0:dd-MM-yyyy}", ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"]); //Convert.ToDateTime(ds.Tables[0].Rows[0]["Tour_Details_Tour_Date"].ToString()).ToString("yyyy-MM-dd");
        tourweekno = ds.Tables[0].Rows[0]["Week_number"].ToString();
        oTour_Details_Sales_Deck_Check_In = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_In"].ToString();
        oTour_Details_Sales_Deck_Check_Out = ds.Tables[0].Rows[0]["Tour_Details_Sales_Deck_Check_Out"].ToString();
        oTour_Details_Taxi_In_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Price"].ToString();
        oTour_Details_Taxi_In_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_In_Ref"].ToString();
        oTour_Details_Taxi_Out_Price = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Price"].ToString();
        oTour_Details_Taxi_Out_Ref = ds.Tables[0].Rows[0]["Tour_Details_Taxi_Out_Ref"].ToString();
        oComments= ds.Tables[0].Rows[0]["Comments"].ToString();
        oregTerms = ds.Tables[0].Rows[0]["RegTerms"].ToString();
        //update profile

        string user =(string)Session["username"]; 
        createdbyTextBox.Text = user;
        //get office of user
        string office = Queries.GetOffice(user);

        string profile = profileidTextBox.Text;
        string createdby = createdbyTextBox.Text;
        string venuecountry = VenueCountryDropDownList.SelectedItem.Text;
        string venue = VenueDropDownList.SelectedItem.Text;
        string venuegroup = GroupVenueDropDownList.SelectedItem.Text;
        string mktg = Request.Form["MarketingProgramDropDownList"];//MarketingProgramDropDownList.SelectedItem.Text;
        if (mktg=="")
        {
            mktg= MarketingProgramDropDownList.Items[0].Text;

        }
        else
        {
            mktg= Request.Form["MarketingProgramDropDownList"];
        }
        string agents= Request.Form["AgentDropDownList"];// .SelectedItem.Text;
        //string agents1;
        if (agents == "")
        {
            agents = AgentDropDownList.Items[0].Text;
        }
        else
        {
            agents = Request.Form["AgentDropDownList"];
        }
        string agentcode = Request.Form["TONameDropDownList"];// .SelectedItem.Text;
        if (agentcode == "")
        {
            agentcode = TONameDropDownList.Items[0].Text;

        }else
        {
            agentcode = Request.Form["TONameDropDownList"];
        }

        string mgr;

        if (venuegroup=="Coldline" || venuegroup=="COLDLINE")
        {
           mgr = Request.Form["ManagerDropDownList"];// SelectedItem.Text;
            if (mgr == "")
            {
                mgr = ManagerDropDownList.Items[0].Text;

            }
            else
            {
                mgr = Request.Form["ManagerDropDownList"];
            }

        }
        else
        {

             mgr = agentcode;
        }

      



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
        string membertype1 = MemType1DropDownList.SelectedItem.Text;// .SelectedItem.Text;
        string memno1 = Memno1TextBox.Text;
        if (mktg == "Owner" || mktg == "OWNER")
        {
            membertype1 = MemType1DropDownList.SelectedItem.Text;
            string memno = Memno1TextBox.Text;
            if (memno == null || memno=="")
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
            string memno =TypeDropDownList.SelectedItem.Text;
            if (memno == null || memno=="")
            {

                memno1 = "";
            }
            else
            {

                memno1 = TypeDropDownList.SelectedItem.Text;
            }


        }



        string membertype2 = Request.Form[MemType2DropDownList.UniqueID];// .SelectedItem.Text;
        string memno2 = Memno2TextBox.Text;




        //primary profile
        string primarytitle = PrimaryTitleDropDownList.SelectedItem.Text;
        string primaryfname = pfnameTextBox.Text;
        string primaylname = plnameTextBox.Text;
        string primarydob = primarydobdatepicker.Text;//Convert.ToDateTime(pdobdatepicker.Text).ToString("yyyy-MM-dd");
        string primarynationality = PrimarynationalityDropDownList.SelectedItem.Text;
        string primarycountry = primarycountryDropDownList.SelectedItem.Text;
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

        //if (primarymobileDropDownList.SelectedIndex == 0)
        //{
        //    pcc = "";

        //}
        //else
        //{

            pcc = Request.Form["primarymobileDropDownList"];//primarymobileDropDownList.SelectedItem.Text;

            if (pcc == "")
            {
                pcc = primarymobileDropDownList.Items[0].Text;
            }
            else {
                pcc = Request.Form["primarymobileDropDownList"];

            }

        //}
        //if (primaryalternateDropDownList.SelectedIndex == 0)
        //{
        //    paltrcc = "";
        //}
        //else
        //{

            paltrcc = Request.Form["primaryalternateDropDownList"]; //primaryalternateDropDownList.SelectedItem.Text;
            if (paltrcc == "")
            {
                paltrcc= primaryalternateDropDownList.Items[0].Text;
            }
            else {
                paltrcc=Request.Form["primaryalternateDropDownList"];
            }
        //}
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

        //secondary profile

        string secondarytitle = secondarytitleDropDownList.SelectedItem.Text;
        string secondaryfname = sfnameTextBox.Text;
        string secondarylname = slnameTextBox.Text;
        string secondarydob = secondarydobdatepicker.Text;//Convert.ToDateTime(sdobdatepicker.Text).ToString("yyyy-MM-dd"); 
        string secondarynationality = secondarynationalityDropDownList.SelectedItem.Text;
        string secondarycountry = secondarycountryDropDownList.SelectedItem.Text;
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
        //if (secondarymobileDropDownList.SelectedIndex == 0)
        //{
        //    scc = "";
        //}
        //else
        //{

            scc = Request.Form["secondarymobileDropDownList"];//secondarymobileDropDownList.SelectedItem.Text;
            if (scc=="")
            {
              scc= secondarymobileDropDownList.Items[0].Text;
            }else
            {
                scc = Request.Form["secondarymobileDropDownList"];
            }
        //}

        //if (secondaryalternateDropDownList.SelectedIndex == 0)
        //{
        //    saltcc = "";
        //}
        //else
        //{

            saltcc = Request.Form["secondaryalternateDropDownList"];//secondaryalternateDropDownList.SelectedItem.Text;
            if (saltcc=="")
            {
                saltcc = secondaryalternateDropDownList.Items[0].Text;
            }
            else
            {

                saltcc = Request.Form["secondaryalternateDropDownList"];


            }

        priOfficecc = Request.Form["pofficecodeDropDownList"];
        if (priOfficecc == "")
        {
            priOfficecc = pofficecodeDropDownList.Items[0].Text;
        }
        else
        {
            priOfficecc = Request.Form["pofficecodeDropDownList"];
        }


        secOfficecc = Request.Form["sofficecodeDropDownList"];
        if (secOfficecc == "")
        {
            secOfficecc = sofficecodeDropDownList.Items[0].Text;
        }
        else
        {
            secOfficecc = Request.Form["sofficecodeDropDownList"];
        }

        //}

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

        if (pofficenoTextBox.Text == "" || pofficenoTextBox.Text == null)
        {
            priOfficeno = "";
        }
        else
        {
            priOfficeno = pofficenoTextBox.Text;
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


        string sp1title = sp1titleDropDownList.SelectedItem.Text;
        string sp1fname = sp1fnameTextBox.Text;
        string sp1lname = sp1lnameTextBox.Text;
        string sp1dob = sp1dobdatepicker.Text;//Convert.ToDateTime(sp1dobdatepicker.Text).ToString("yyyy-MM-dd"); 


        string sp1nationality = sp1nationalityDropDownList.SelectedItem.Text;
        string sp1country = sp1countryDropDownList.SelectedItem.Text;
        string nsp1age = subProfile1Age.Text;
        //if (sp1mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp1cc = "";
        //}
        //else
        //{

            sp1cc = Request.Form["sp1mobileDropDownList"];//sp1mobileDropDownList.SelectedItem.Text;
            if (sp1cc == "")
            {
                sp1cc = sp1mobileDropDownList.Items[0].Text;
            }
            else
            {

             sp1cc= Request.Form["sp1mobileDropDownList"];

            }
        //}

        //if (sp1alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp1altcc = "";
        //}
        //else
        //{

            sp1altcc = Request.Form["sp1alternateDropDownList"];// sp1alternateDropDownList.SelectedItem.Text;
           
            if (sp1altcc=="")
            {
                sp1altcc= sp1alternateDropDownList.Items[0].Text;
            }
            else
            {
                sp1altcc = Request.Form["sp1alternateDropDownList"]; ;
            }
        //}


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
        if (sp1pemailTextBox.Text == "" || sp1pemailTextBox.Text == null)
        {
            sp1email = "";
        }
        else
        {
            sp1email = sp1pemailTextBox.Text;
        }



        //sub profile 2
        string sp2title = sp2titleDropDownList.SelectedItem.Text;
        string sp2fname = sp2fnameTextBox.Text;
        string sp2lname = sp2lnameTextBox.Text;
        string sp2dob = sp2dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp2nationality = sp2nationalityDropDownList.SelectedItem.Text;
        string sp2country = sp2countryDropDownList.SelectedItem.Text;
        string nsp2age = subProfile2Age.Text;
        //if (sp2mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp2cc = "";
        //}
        //else
        //{

            sp2cc = Request.Form["sp2mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
            if (sp2cc=="")
            {
                sp2cc= sp2mobileDropDownList.Items[0].Text;
            }else
            {

                sp2cc = Request.Form["sp2mobileDropDownList"];

            }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

            sp2altccc = Request.Form["sp2alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
            if (sp2altccc=="")
            {
                sp2altccc = sp2alternateDropDownList.Items[0].Text;
            }
            else
            {
                sp2altccc = Request.Form["sp2alternateDropDownList"];

            }
        //}


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
        if (sp2pemailTextBox.Text == "" || sp2pemailTextBox.Text == null)
        {
            sp2email = "";
        }
        else
        {
            sp2email = sp2pemailTextBox.Text;
        }

        // sub profile 3//
        string sp3title = sp3titleDropDownList.SelectedItem.Text;
        string sp3fname = sp3fnameTextBox.Text;
        string sp3lname = sp3lnameTextBox.Text;
        string sp3dob = sp3dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp3nationality = sp3nationalityDropDownList.SelectedItem.Text;
        string sp3country = sp3countryDropDownList.SelectedItem.Text;
        string nsp3age = subProfile3Age.Text;
        //if (sp2mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp2cc = "";
        //}
        //else
        //{

        sp3cc = Request.Form["sp3mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (sp3cc == "")
        {
            sp3cc = sp3mobileDropDownList.Items[0].Text;
        }
        else
        {

            sp3cc = Request.Form["sp3mobileDropDownList"];

        }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

        sp3altccc = Request.Form["sp3alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (sp3altccc == "")
        {
            sp3altccc = sp3alternateDropDownList.Items[0].Text;
        }
        else
        {
            sp3altccc = Request.Form["sp3alternateDropDownList"];

        }
        //}


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
        if (sp3pemailTextBox.Text == "" || sp3pemailTextBox.Text == null)
        {
            sp3email = "";
        }
        else
        {
            sp3email = sp3pemailTextBox.Text;
        }
        //end//

        // sub profile 4//
        string sp4title = sp4titleDropDownList.SelectedItem.Text;
        string sp4fname = sp4fnameTextBox.Text;
        string sp4lname = sp4lnameTextBox.Text;
        string sp4dob = sp4dobdatepicker.Text;//Convert.ToDateTime(sp2dobdatepicker.Text).ToString("yyyy-MM-dd");
        string sp4nationality = sp4nationalityDropDownList.SelectedItem.Text;
        string sp4country = sp4countryDropDownList.SelectedItem.Text;
        string nsp4age = subProfile4Age.Text;
        //if (sp2mobileDropDownList.SelectedIndex == 0)
        //{
        //    sp2cc = "";
        //}
        //else
        //{

        sp4cc = Request.Form["sp4mobileDropDownList"];//sp2mobileDropDownList.SelectedItem.Text;
        if (sp4cc == "")
        {
            sp4cc = sp4mobileDropDownList.Items[0].Text;
        }
        else
        {

            sp4cc = Request.Form["sp4mobileDropDownList"];

        }
        //}

        //if (sp2alternateDropDownList.SelectedIndex == 0)
        //{
        //    sp2altccc = "";
        //}
        //else
        //{

        sp4altccc = Request.Form["sp4alternateDropDownList"]; //sp2alternateDropDownList.SelectedItem.Text;
        if (sp4altccc == "")
        {
            sp4altccc = sp4alternateDropDownList.Items[0].Text;
        }
        else
        {
            sp4altccc = Request.Form["sp4alternateDropDownList"];

        }
        //}


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
        if (sp4pemailTextBox.Text == "" || sp4pemailTextBox.Text == null)
        {
            sp4email = "";
        }
        else
        {
            sp4email = sp4pemailTextBox.Text;
        }
        // end//


        //address

        string address1 = address1TextBox.Text;
        string address2 = address2TextBox.Text;
        string state = Request.Form["StateDropDownList"];// StateDropDownList.SelectedItem.Text;
        if (state=="")
        {
            state = StateDropDownList.Items[0].Text;
        }else
        {
            state = Request.Form["StateDropDownList"];


        }
        string city = cityTextBox.Text;
        string pincode = pincodeTextBox.Text;
        string acountry = AddCountryDropDownList.SelectedItem.Text;

        //other details

        string employmentstatus = employmentstatusDropDownList.SelectedItem.Text;
        string maritalstatus = maritalstatusDropDownList.SelectedItem.Text;
        string livingyrs = livingyrsTextBox.Text;

        //stay details
        string resort = resortTextBox.Text;
        string roomno = roomnoTextBox.Text;
        string arrivaldate = arrivaldatedatepicker.Text;
        string departuredate = departuredatedatepicker.Text;

        //guest status

        string gueststatus = guestatusDropDownList.SelectedItem.Text;
        string salesrep = toursalesrepDropDownList.SelectedItem.Text;
        string timeIn = timeinTextBox.Text;
        string timeOut = timeoutTextBox.Text;
        // string tourdate = tourdatedatepicker.Text;
        string tourdate;
        int wkno;
        if (tourdatedatepicker.Text == "" || tourdatedatepicker.Text == null || tourdatedatepicker.Text == "NaN" || tourdatedatepicker.Text == "1-1-1990")
        {
            tourdate = "";
            wkno = 0;
        }
        else
        {
            tourdate = tourdatedatepicker.Text;
            wkno = Queries.GetWkNumber(Convert.ToDateTime(tourdate));
            tourdate = Convert.ToDateTime(tourdatedatepicker.Text).ToString("dd-MM-yyyy");
        }
        string taxin = inpriceTextBox.Text;
        string taxirefin = inrefTextBox.Text;
        string taxiout = outpriceTextBox.Text;
        string taxirefout = outrefTextBox.Text;
        string ProComments = commentsTextBox.Text;

        if (CheckBox1.Checked)
        {


            regTerms = "Y";
        }
        else
        {
            regTerms = "N";

        }

                //update
                if (String.Compare(ocompanyname, companynameTextBox.Text) != 0)
                {
                    int update = Queries.UpdateProfileCompanyName(profileidTextBox.Text, companynameTextBox.Text.ToUpper());
                    string log3 = "Company Name changed from:" + ocompanyname + " " + "to" + companynameTextBox.Text;
                    int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());

                }
                else
                {
                }
             	
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon4 = new SqlConnection(conn);

        string query4 = "select Gift_ID_Option+'-'+GiftItem from gift where Profile_ID='" + ProfileID + "'";
        sqlcon4.Open();
        SqlCommand cmd4 = new SqlCommand(query4, sqlcon4);
        SqlDataReader reader4 = cmd4.ExecuteReader();
        while (reader4.Read())
        {
            string name = reader4.GetString(0);
            string act1 = "Deleted:" + name;
            int insertlog2 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act1, user, DateTime.Now.ToString());
        }

        reader4.Close();
        sqlcon4.Close();

        SqlConnection sqlcon2 = new SqlConnection(conn);
        string query2 = "delete from gift where Profile_ID='" + ProfileID + "'";
        sqlcon2.Open();
        SqlCommand cmd2 = new SqlCommand(query2, sqlcon2);
        cmd2.ExecuteNonQuery();
        sqlcon2.Close();


           string val = Request.Form["giftoptionDropDownList"];
        if (val=="" || val==null)
        {

        }else
        {


        string[] value = val.Split(new Char[] { ',', '-' },
                                  StringSplitOptions.RemoveEmptyEntries);




        for (int i = 0; i < value.Length; i = i + 2)
        {
            conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string query = "select Gift_Option_Name,Item from Gift_Option where Gift_Option_Name='" + value[i] + "' and Item='" + value[i + 1] + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string giftname = reader.GetString(0);
                string item = reader.GetString(1);


                SqlConnection sqlcon1 = new SqlConnection(conn);
                string query1 = "select distinct Profile_ID from Gift where Profile_ID='" + ProfileID + "'";
                sqlcon1.Open();
                SqlCommand cmd1 = new SqlCommand(query1, sqlcon1);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {



                        int year = DateTime.Now.Year;
                        string giftid = Queries.GetProfileGift(office);
                        int insert = Queries.InsertGiftOption(giftid, giftname.Trim(), TextBox13.Text, TextBox22.Text,profileidTextBox.Text, item.Trim(), "");
                        int updategift = Queries.UpdateGiftValue(office, year);
                        string log11 = "gift Details:" + "gift ID:" + giftid + "," + "Gift Option:" + giftname + "," + "Voucherno:" + TextBox13.Text + "," + "Comments:" + TextBox22.Text + "," + "Profile id:" + ProfileID + "," + "Item:" + item;
                        int insertlog11 = Queries.InsertContractLogs_India(ProfileID, "", log11, user, DateTime.Now.ToString());



                    }
                }
                else
                {


                    int year = DateTime.Now.Year;
                    string giftid = Queries.GetProfileGift(office);
                    int insert = Queries.InsertGiftOption(giftid, giftname.Trim(), TextBox13.Text, TextBox22.Text, ProfileID, item.Trim(), "");
                    int updategift = Queries.UpdateGiftValue(office, year);
                    string log11 = "gift Details:" + "gift ID:" + giftid + "," + "Gift Option:" + giftname + "," + "Voucherno:" + TextBox13.Text + "," + "Comments:" + TextBox22.Text + "," + "Profile id:" + ProfileID + "," + "Item:" + item;
                    int insertlog11 = Queries.InsertContractLogs_India(ProfileID, "", log11, user, DateTime.Now.ToString());

                }

                reader1.Close();
                sqlcon1.Close();


            }
            reader.Close();
            sqlcon.Close();

        }
}

        if (String.Compare(oProfile_Venue_Country, venuecountry) != 0)
        {
            string act = "venue country changed from:" + oProfile_Venue_Country + "To:" + venuecountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Venue, venue) != 0)
        {
            string act = "venue changed from:" + oProfile_Venue + "To:" + venue;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Group_Venue, venuegroup) != 0)
        {
            string act = "venue group changed from:" + oProfile_Group_Venue + "To:" + venuegroup;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Marketing_Program, mktg) != 0)
        {
            string act = "marketing prgm changed from:" + oProfile_Marketing_Program + "To:" + mktg;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Agent, agents) != 0)
        {
            string act = "agent name changed from:" + oProfile_Agent + "To:" + agents;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Agent_Code, agentcode) != 0)
        {
            string act = "To Name changed from:" + oProfile_Agent_Code + "To:" + agentcode;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oManager, mgr) != 0)
        {
            string act = "manager changed from:" + oManager + "To:" + mgr;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Type1, membertype1) != 0)
        {
            string act = "membertype1 changed from:" + oProfile_Member_Type1 + "To:" + membertype1;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(ophid, photoidentity) != 0)
        {
            string act = "Photo Identity changed from:" + ophid + "To:" + photoidentity;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(ocard, card) != 0)
        {
            string act = "Card Holder value changed from:" + ocard + "To:" + card;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Number1, memno1) != 0)
        {
            string act = "memno1 changed from:" + oProfile_Member_Number1 + "To:" + memno1;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Type2, membertype2) != 0)
        {
            string act = "membertype2 changed from:" + oProfile_Member_Type2 + "To:" + membertype2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Member_Number2, memno2) != 0)
        {
            string act = "memno2 changed from:" + oProfile_Member_Number2 + "To:" + memno2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Title, primarytitle) != 0)
        {
            string act = "primary title changed from:" + oProfile_Primary_Title + "To:" + primarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Fname, primaryfname) != 0)
        {
            string act = "primary fname changed from:" + oProfile_Primary_Fname + "To:" + primaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Lname, primaylname) != 0)
        {
            string act = "primay lname changed from:" + oProfile_Primary_Lname + "To:" + primaylname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_DOB, primarydob) != 0)
        {
            string act = "primary dob changed from:" + oProfile_Primary_DOB + "To:" + primarydob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Nationality, primarynationality) != 0)
        {
            string act = "primary nationality changed from:" + oProfile_Primary_Nationality + "To:" + primarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Primary_Country, primarycountry) != 0)
        {
            string act = "primary country changed from:" + oProfile_Primary_Country + "To:" + primarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opage, npage) != 0)
        {
            string act = "primary age changed from:" + opage + "To:" + npage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(opdesignation, npdesg) != 0)
        {
            string act = "primary designation changed from:" + opdesignation + "To:" + npdesg;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oplang, primarylanguage) != 0)
        {
            string act = "primary Language changed from:" + oplang + "To:" + primarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_CC, pcc) != 0)
        {
            string act = "primary mobile code changed from:" + oPrimary_CC + "To:" + pcc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Mobile, pmobile) != 0)
        {
            string act = "primary mobile no changed from:" + oPrimary_Mobile + "To:" + pmobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Alt_CC, paltrcc) != 0)
        {
            string act = "primary mobile changed from:" + oPrimary_Alt_CC + "To:" + paltrcc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oPrimary_Alternate, palternate) != 0)
        {
            string act = "primary alternate no changed from:" + oPrimary_Alternate + "To:" + palternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(opriOfficecc, priOfficecc) != 0)
        {
            string act = "primary office cc changed from:" + opriOfficecc + "To:" + priOfficecc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(opriOfficeno, priOfficeno) != 0)
        {
            string act = "primary office no changed from:" + opriOfficeno + "To:" + priOfficeno;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(oPrimary_Email, pemail) != 0)
        {
            string act = "primary email changed from:" + oPrimary_Email + "To:" + pemail;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Title, secondarytitle) != 0)
        {
            string act = "secondary title changed from:" + oProfile_Secondary_Title + "To:" + secondarytitle;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Fname, secondaryfname) != 0)
        {
            string act = "secondary fname changed from:" + oProfile_Secondary_Fname + "To:" + secondaryfname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Lname, secondarylname) != 0)
        {
            string act = "secondary lname changed from:" + oProfile_Secondary_Lname + "To:" + secondarylname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_DOB, secondarydob) != 0)
        {
            string act = "secondary dob changed from:" + oProfile_Secondary_DOB + "To:" + secondarydob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oProfile_Secondary_Nationality, secondarynationality) != 0)
        {
            string act = "secondary nationality changed from:" + oProfile_Secondary_Nationality + "To:" + secondarynationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osage, nsage) != 0)
        {
            string act = "secondary age changed from:" + osage + "To:" + nsage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osdesignation, nsdesg) != 0)
        {
            string act = "secondary designation changed from:" + osdesignation + "To:" + nsdesg;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oslang, secondarylanguage) != 0)
        {
            string act = "secondary Language changed from:" + oslang + "To:" + secondarylanguage;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Secondary_Country, secondarycountry) != 0)
        {
            string act = "secondary country changed from:" + oProfile_Secondary_Country + "To:" + secondarycountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSecondary_CC, scc) != 0)
        {
            string act = "secondary mobile code changed from:" + oSecondary_CC + "To:" + scc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSecondary_Mobile, smobile) != 0)
        {
            string act = "secondary mobile no changed from:" + oSecondary_Mobile + "To:" + smobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());

        }
        else { }
        if (String.Compare(oSecondary_Alt_CC, saltcc) != 0)
        {
            string act = "secondary alternaet num code changed from:" + oSecondary_Alt_CC + "To:" + saltcc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSecondary_Alternate, salternate) != 0)
        {
            string act = "secondary alternate no changed from:" + oSecondary_Alternate + "To:" + salternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(osecOfficecc, secOfficecc) != 0)
        {
            string act = "secondary office cc changed from:" + osecOfficecc + "To:" + secOfficecc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(osecofficeno, secOfficeno) != 0)
        {
            string act = "secondary office no changed from:" + osecofficeno + "To:" + secOfficeno;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oSecondary_Email, semail) != 0)
        {
            string act = "secondary email changed from:" + oSecondary_Email + "To:" + semail;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Title, sp1title) != 0)
        {
            string act = "subprofile1 title changed from:" + oSub_Profile1_Title + "To:" + sp1title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Fname, sp1fname) != 0)
        {
            string act = "subprofile1 fname changed from:" + oSub_Profile1_Fname + "To:" + sp1fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Lname, sp1lname) != 0)
        {
            string act = "subprofile1 lname changed from:" + oSub_Profile1_Lname + "To:" + sp1lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_DOB, sp1dob) != 0)
        {
            string act = "subprofile1 dob changed from:" + oSub_Profile1_DOB + "To:" + sp1dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Nationality, sp1nationality) != 0)
        {
            string act = "subprofile1 nationality changed from:" + oSub_Profile1_Nationality + "To:" + sp1nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp1age, nsp1age) != 0)
        {
            string act = "subprofile1 age changed from:" + osp1age + "To:" + nsp1age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile1_Country, sp1country) != 0)
        {
            string act = "subprofile1 country changed from:" + oSub_Profile1_Country + "To:" + sp1country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile1_CC, sp1cc) != 0)
        {
            string act = "subprofile1 mobile code changed from:" + oSubprofile1_CC + "To:" + sp1cc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile1_Mobile, sp1mobile) != 0)
        {
            string act = "subprofile1 mobile no changed from:" + oSubprofile1_Mobile + "To:" + sp1mobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile1_Alt_CC, sp1altcc) != 0)
        {
            string act = "subprofile1 alternate no code changed from:" + oSubprofile1_Alt_CC + "To:" + sp1altcc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile1_Alternate, sp1alternate) != 0)
        {
            string act = "subprofile1 alternate changed from:" + oSubprofile1_Alternate + "To:" + sp1alternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }


        if (String.Compare(oSubprofile1_Email, sp1email) != 0)
        {
            string act = "subprofile1 email changed from:" + oSubprofile1_Email + "To:" + sp1email;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Title, sp2title) != 0)
        {
            string act = "subprofile2 title changed from:" + oSub_Profile2_Title + "To:" + sp2title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Fname, sp2fname) != 0)
        {
            string act = "subprofile2 fname changed from:" + oSub_Profile2_Fname + "To:" + sp2fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Lname, sp2lname) != 0)
        {
            string act = "subprofile2 lname changed from:" + oSub_Profile2_Lname + "To:" + sp2lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_DOB, sp2dob) != 0)
        {
            string act = "subprofile2 dob changed from:" + oSub_Profile2_DOB + "To:" + sp2dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Nationality, sp2nationality) != 0)
        {
            string act = "subprofile2 nationality changed from:" + oSub_Profile2_Nationality + "To:" + sp2nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp2age, nsp2age) != 0)
        {
            string act = "subprofile2 age changed from:" + osp2age + "To:" + nsp2age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile2_Country, sp2country) != 0)

        {
            string act = "subprofile2 country changed from:" + oSub_Profile2_Country + "To:" + sp2country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_CC, sp2cc) != 0)
        {
            string act = "subprofile2 mobile code changed from:" + oSubprofile2_CC + "To:" + sp2cc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Mobile, sp2mobile) != 0)
        {
            string act = "subprofile2 mobile no changed from:" + oSubprofile2_Mobile + "To:" + sp2mobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Alt_CC, sp2altccc) != 0)
        {
            string act = "subprofile2 alternate no code changed from:" + oSubprofile2_Alt_CC + "To:" + sp2altccc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Alternate, sp2alternate) != 0)
        {
            string act = "subprofile2 alternate no changed from:" + oSubprofile2_Alternate + "To:" + sp2alternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile2_Email, sp2email) != 0)
        {
            string act = "subprofile2 email changed from:" + oSubprofile2_Email + "To:" + sp2email;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        // sub profile 3//
        if (String.Compare(oSub_Profile3_Title, sp3title) != 0)
        {
            string act = "subprofile3 title changed from:" + oSub_Profile3_Title + "To:" + sp3title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Fname, sp3fname) != 0)
        {
            string act = "subprofile3 fname changed from:" + oSub_Profile3_Fname + "To:" + sp3fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Lname, sp3lname) != 0)
        {
            string act = "subprofile3 lname changed from:" + oSub_Profile3_Lname + "To:" + sp3lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_DOB, sp3dob) != 0)
        {
            string act = "subprofile3 dob changed from:" + oSub_Profile3_DOB + "To:" + sp3dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Nationality, sp3nationality) != 0)
        {
            string act = "subprofile3 nationality changed from:" + oSub_Profile3_Nationality + "To:" + sp3nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp3age, nsp3age) != 0)
        {
            string act = "subprofile3 age changed from:" + osp3age + "To:" + nsp3age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile3_Country, sp3country) != 0)

        {
            string act = "subprofile3 country changed from:" + oSub_Profile3_Country + "To:" + sp3country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_CC, sp3cc) != 0)
        {
            string act = "subprofile3 mobile code changed from:" + oSubprofile3_CC + "To:" + sp3cc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Mobile, sp3mobile) != 0)
        {
            string act = "subprofile3 mobile no changed from:" + oSubprofile3_Mobile + "To:" + sp3mobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Alt_CC, sp3altccc) != 0)
        {
            string act = "subprofile3 alternate no code changed from:" + oSubprofile3_Alt_CC + "To:" + sp3altccc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Alternate, sp3alternate) != 0)
        {
            string act = "subprofile3 alternate no changed from:" + oSubprofile3_Alternate + "To:" + sp3alternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile3_Email, sp3email) != 0)
        {
            string act = "subprofile3 email changed from:" + oSubprofile3_Email + "To:" + sp3email;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        // end//



        // sub profile 4//
        if (String.Compare(oSub_Profile4_Title, sp4title) != 0)
        {
            string act = "subprofile4 title changed from:" + oSub_Profile4_Title + "To:" + sp4title;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Fname, sp4fname) != 0)
        {
            string act = "subprofile4 fname changed from:" + oSub_Profile4_Fname + "To:" + sp4fname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Lname, sp4lname) != 0)
        {
            string act = "subprofile4 lname changed from:" + oSub_Profile4_Lname + "To:" + sp4lname;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_DOB, sp4dob) != 0)
        {
            string act = "subprofile4 dob changed from:" + oSub_Profile4_DOB + "To:" + sp4dob;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Nationality, sp4nationality) != 0)
        {
            string act = "subprofile4 nationality changed from:" + oSub_Profile4_Nationality + "To:" + sp4nationality;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(osp4age, nsp4age) != 0)
        {
            string act = "subprofile4 age changed from:" + osp4age + "To:" + nsp4age;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSub_Profile4_Country, sp4country) != 0)

        {
            string act = "subprofile4 country changed from:" + oSub_Profile4_Country + "To:" + sp4country;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_CC, sp4cc) != 0)
        {
            string act = "subprofile4 mobile code changed from:" + oSubprofile4_CC + "To:" + sp4cc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Mobile, sp4mobile) != 0)
        {
            string act = "subprofile4 mobile no changed from:" + oSubprofile4_Mobile + "To:" + sp4mobile;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Alt_CC, sp4altccc) != 0)
        {
            string act = "subprofile4 alternate no code changed from:" + oSubprofile4_Alt_CC + "To:" + sp4altccc;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Alternate, sp4alternate) != 0)
        {
            string act = "subprofile4 alternate no changed from:" + oSubprofile4_Alternate + "To:" + sp4alternate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oSubprofile4_Email, sp4email) != 0)
        {
            string act = "subprofile4 email changed from:" + oSubprofile4_Email + "To:" + sp4email;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        // end//


        if (String.Compare(oProfile_Address_Line1, address1) != 0)

        {
            string act = "address1 changed from:" + oProfile_Address_Line1 + "To:" + address1;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_Line2, address2) != 0)
        {
            string act = "address2 changed from:" + oProfile_Address_Line2 + "To:" + address2;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_State, state) != 0)
        {
            string act = "state changed from:" + oProfile_Address_State + "To:" + state;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_city, city) != 0)
        {
            string act = "city changed from:" + oProfile_Address_city + "To:" + city;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_Postcode, pincode) != 0)
        {
            string act = "pincode changed from:" + oProfile_Address_Postcode + "To:" + pincode;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Address_Country, acountry) != 0)
        {
            string act = "Address Country changed from:" + oProfile_Address_Country + "To:" + acountry;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Employment_status, employmentstatus) != 0)
        {
            string act = "employment status changed from:" + oProfile_Employment_status + "To:" + employmentstatus;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Marital_status, maritalstatus) != 0)
        {
            string act = "marital status changed from:" + oProfile_Marital_status + "To:" + maritalstatus;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_NOY_Living_as_couple, livingyrs) != 0)
        {
            string act = "livingyrs changed from:" + oProfile_NOY_Living_as_couple + "To:" + livingyrs;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Stay_Resort_Name, resort) != 0)
        {
            string act = "resort changed from:" + oProfile_Stay_Resort_Name + "To:" + resort;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Stay_Resort_Room_Number, roomno) != 0)
        {
            string act = "roomno changed from:" + oProfile_Stay_Resort_Room_Number + "To:" + roomno;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Stay_Arrival_Date, arrivaldate) != 0)
        {
            string act = "arrival date changed from:" + oProfile_Stay_Arrival_Date + "To:" + arrivaldate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oProfile_Stay_Departure_Date, departuredate) != 0)
        {
            string act = "departure date changed from:" + oProfile_Stay_Departure_Date + "To:" + departuredate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Guest_Status, gueststatus) != 0)
        {
            string act = "guest status changed from:" + oTour_Details_Guest_Status + "To:" + gueststatus;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Guest_Sales_Rep, salesrep) != 0)

        {
            string act = "salesrep changed from:" + oTour_Details_Guest_Sales_Rep + "To:" + salesrep;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Sales_Deck_Check_In, timeIn) != 0)
        {
            string act = "time In changed from:" + oTour_Details_Sales_Deck_Check_In + "To:" + timeIn;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oTour_Details_Sales_Deck_Check_Out, timeOut) != 0)
        {
            string act = "time Out changed from:" + oTour_Details_Sales_Deck_Check_Out + "To:" + timeOut;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Tour_Date, tourdate) != 0)
        {
            string act = "tour date changed from:" + oTour_Details_Tour_Date + "To:" + tourdate;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(tourweekno, wkno.ToString()) != 0)
        {
            string act = "week num changed from:" + tourweekno + "To:" + wkno.ToString();
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Taxi_In_Price, taxin) != 0)
        {
            string act = "taxi in price changed from:" + oTour_Details_Taxi_In_Price + "To:" + taxin;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Taxi_In_Ref, taxirefin) != 0)
        {
            string act = "taxi reference in changed from:" + oTour_Details_Taxi_In_Ref + "To:" + taxirefin;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }
        if (String.Compare(oTour_Details_Taxi_Out_Price, taxiout) != 0)
        {
            string act = "taxi outprice changed from:" + oTour_Details_Taxi_Out_Price + "To:" + taxiout;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oTour_Details_Taxi_Out_Ref, taxirefout) != 0)
        {
            string act = "taxi reference out changed from:" + oTour_Details_Taxi_Out_Ref + "To:" + taxirefout;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oComments, ProComments) != 0)
        {
            string act = "Profile Comments changed from:" + oComments + "To:" + ProComments;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }

        if (String.Compare(oregTerms, regTerms) != 0)
        {
            string act = "Registration Terms changed from:" + oregTerms + "To:" + regTerms;
            int insertlog1 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", act, user, DateTime.Now.ToString());
        }
        else { }


        //update profile
        int updateprofile = Queries.UpdateProfile(profile, venuecountry, venue, venuegroup, mktg, agents, agentcode, membertype1, memno1, membertype2, memno2, employmentstatus, maritalstatus, livingyrs, mgr, photoidentity, card,ProComments,"","",regTerms,"");
        int primary = Queries.UpdateProfilePrimary(profile, primarytitle, primaryfname, primaylname, primarydob, primarynationality, primarycountry, npage, npdesg, primarylanguage);
        if (secondarytitle == "")
        {
          
        }
        else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);
           
            string query = "select * from Profile_Secondary where Profile_ID = '"+ProfileID+"'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int secondary = Queries.UpdateProfileSecondary(profile, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, nsage, nsdesg, secondarylanguage);
            }
            else
            {
                int year = DateTime.Now.Year;
                string secondaryprofileid = Queries.GetSecondaryProfileID(office);
                int secondary = Queries.InsertSecondaryProfile(secondaryprofileid, secondarytitle, secondaryfname, secondarylname, secondarydob, secondarynationality, secondarycountry, profileidTextBox.Text, nsage, nsdesg, secondarylanguage);
                int updates = Queries.UpdateSecondaryValue(office, year);

                string log3 = "secondary details:" + " " + "secondary id:" + secondaryprofileid + "," + "title:" + secondarytitle + "," + "Fname:" + secondaryfname + "," + "Lname:" + secondarylname + "," + "DOB:" + secondarydob + "," + "nationality:" + secondarynationality + "," + "Country:" + secondarycountry + "," + "Profiel ID:" + profileidTextBox.Text + "Age:" + nsage + "," + "Designation:" + nsdesg + "," + "Languages spoken:" + secondarylanguage;
                int insertlog3 = Queries.InsertContractLogs_India(profileidTextBox.Text, "", log3, user, DateTime.Now.ToString());
               
            }
            reader.Close();
            sqlcon.Close();

        }

       
        if (sp1title == "")
        {

        }else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile1 where Profile_ID = '"+ProfileID+"'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp1 = Queries.UpdateSubProfile1(profile, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, nsp1age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile1id = Queries.GetSubProfile1ID(office);
                int subprofielid = Queries.InsertSub_Profile1(subprofile1id, sp1title, sp1fname, sp1lname, sp1dob, sp1nationality, sp1country, ProfileID, nsp1age);
                int updatesp1 = Queries.UpdateSubprofile1Value(office, year);


                string log5 = "sub profile1 details:" + " " + "sp1 id:" + subprofile1id + "," + "title:" + sp1title + "," + "Fname:" + sp1fname + "," + "Lname:" + sp1lname + "," + "DOB:" + sp1dob + "," + "nationality:" + sp1nationality + "," + "Country:" + sp1country + "," + "Profiel ID:" + ProfileID;
                int insertlog5 = Queries.InsertContractLogs_India(ProfileID, "", log5, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();

        }


        if (sp2title=="")
        {

        }else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile2 where Profile_ID = '" + ProfileID + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp2 = Queries.UpdateSubProfile2(profile, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, nsp2age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile2id = Queries.GetSubProfile2ID(office);
                int subprofielid2 = Queries.InsertSub_Profile2(subprofile2id, sp2title, sp2fname, sp2lname, sp2dob, sp2nationality, sp2country, ProfileID, nsp2age);
                int updatesp2 = Queries.UpdateSubprofile2Value(office, year);

                string log6 = "sub profile2 details:" + " " + "sp2 id:" + subprofile2id + "," + "title:" + sp2title + "," + "Fname:" + sp2fname + "," + "Lname:" + sp2lname + "," + "DOB:" + sp2dob + "," + "nationality:" + sp2nationality + "," + "Country:" + sp2country + "," + "Profiel ID:" + ProfileID;
                int insertlog6 = Queries.InsertContractLogs_India(ProfileID, "", log6, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();
        }

        if (sp3title == "")
        {

        }else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile3 where Profile_ID = '" + ProfileID + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp3 = Queries.UpdateSubProfile3(profile, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, nsp3age);

            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile3id = Queries.GetSubProfile3ID(office);
                int subprofielid3 = Queries.InsertSub_Profile3(subprofile3id, sp3title, sp3fname, sp3lname, sp3dob, sp3nationality, sp3country, ProfileID, nsp3age);
                int updatesp3 = Queries2.UpdateSubprofile3Value(office, year);

                string log12 = "sub profile3 details:" + " " + "sp3 id:" + subprofile3id + "," + "title:" + sp3title + "," + "Fname:" + sp3fname + "," + "Lname:" + sp3lname + "," + "DOB:" + sp3dob + "," + "nationality:" + sp3nationality + "," + "Country:" + sp3country + "," + "Profiel ID:" + ProfileID;
                int insertlog12 = Queries.InsertContractLogs_India(ProfileID, "", log12, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();

        }

        if (sp4title == "")
        {

        }else
        {
            string connn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(connn);

            string query = "select * from Sub_Profile4 where Profile_ID = '" + ProfileID + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int sp4 = Queries.UpdateSubProfile4(profile, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, nsp4age);
            }
            else
            {
                int year = DateTime.Now.Year;
                string subprofile4id = Queries.GetSubProfile4ID(office);
                int subprofielid4 = Queries.InsertSub_Profile4(subprofile4id, sp4title, sp4fname, sp4lname, sp4dob, sp4nationality, sp4country, ProfileID, nsp4age);
                int updatesp4 = Queries2.UpdateSubprofile4Value(office, year);


                string log13 = "sub profile4 details:" + " " + "sp4 id:" + subprofile4id + "," + "title:" + sp4title + "," + "Fname:" + sp4fname + "," + "Lname:" + sp4lname + "," + "DOB:" + sp4dob + "," + "nationality:" + sp4nationality + "," + "Country:" + sp4country + "," + "Profiel ID:" + ProfileID;
                int insertlog13 = Queries.InsertContractLogs_India(ProfileID, "", log13, user, DateTime.Now.ToString());
            }
            reader.Close();
            sqlcon.Close();
        }
       
       
        int address = Queries.UpdateProfileAddress(profile, address1, address2, state, city, pincode, acountry);
        int phone = Queries.UpdatePhone(profile, pcc, pmobile, paltrcc, palternate, scc, smobile, saltcc, salternate, sp1cc, sp1mobile, sp1altcc, sp1alternate, sp2cc, sp2mobile, sp2altccc, sp2alternate,sp3cc,sp3mobile, sp4cc, sp4mobile, sp3altccc, sp3alternate, sp4altccc, sp4alternate,priOfficecc,priOfficeno,secOfficecc,secOfficeno);
        int email = Queries.UpdateEmail(profile, pemail, semail, sp1email, sp2email,"","","","", sp3email, "", sp4email, "");
        int stay = Queries.UpdateProfileStay(profile, resort, roomno, arrivaldate, departuredate);
        int tour = Queries.UpdateTourDetails(profile, gueststatus, salesrep, tourdate, timeIn, timeOut, taxin, taxirefin, taxiout, taxirefout,"",wkno);


        Response.Redirect(Request.RawUrl);
        //   string msg = "Details updated for Profile :" + " " + profile;
        //   Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('" + msg + "');", true);
        //  Response.Write("<script>alert(' successfully')</script>");
        //Response.Write(@"<script alert('Record successful.'); window.location = '" + Request.RawUrl + @"'; </script>");
    }
    
    [WebMethod]
    public static string primaryl(string prid)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        //string query = "SELECT Primary_Language FROM Profile_Primary WHERE Profile_ID ='"+ '""
        //   SqlCommand sql = new SqlCommand(query, sqlcon);

        //SqlDataReader reader = sql.ExecuteReader();
        SqlDataReader reader = Queries.LoadPrimaryLang(prid);
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
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";

        }

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
            JSON += "[\"" + "" + "\"],";
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
        }else
        {
            JSON += "[\"" + "" + "\"],";
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
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
      
        return JSON;
    }



    [WebMethod]
    public static string getMarketingProgram(string venue, string venueGroup, string profileID)
    {
        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string JSON = "{\n \"names\":[";
        sqlcon.Open();

        string query = "select distinct Marketing_Program_Name from Marketing_Program join Venue_Group vg on vg.Venue_group_ID=Marketing_Program.Venue_Group_ID join venue v on v.Venue_ID= vg.Venue_ID where Marketing_Program_Status = 'active' and Marketing_Program_Name not in(select Profile_Marketing_Program   from Profile where Profile_ID ='" + profileID + "' ) and vg.Venue_Group_Name='" + venueGroup + "' and v.Venue_Name= '" + venue + "'";
        SqlCommand sql = new SqlCommand(query, sqlcon);

        SqlDataReader reader = sql.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);
                JSON += "[\"" + name + "\"],";
            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
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
    public static string LoadCountryCode(string country)
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
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
        string query = " select Country_Code from Country  where country_name ='" + country + "' union all select Country_Code from Country  where country_name !='" + country + "';";
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
        }else
        {
            JSON += "[\"" + "" + "\"],";
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
        string query = "select RegTerms from profile p where Profile_ID='" + ProfileID + "';";
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
        }else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
       
        sqlcon.Close();
        return JSON;



    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        SOR_AdditionalName(ContractdetailsIDTextBox.Text);


    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable datatable = Queries.loadClientDetails(profileidTextBox.Text);
        var printr = "";
        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
        crystalReport.Load(Server.MapPath("~/reports/Client_Details.rpt")); // path of report       
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
        string fn = profileidTextBox.Text + "Client_Details" + ".pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fn + ";");

        fs = new System.IO.FileStream(ExportFileName, FileMode.Open);
        FileSize = fs.Length;
        byte[] bBuffer = new byte[Convert.ToInt32(FileSize) + 1];
        fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
        fs.Close();
        Response.BinaryWrite(bBuffer);
        Response.Flush();
    }


    public string loadGifts()
    {
        string htmlstr = "";
        string conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        string query = "select * from Gift_Option  where Gift_Option_Status='Active' and office='hml'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string giftname = reader.GetString(1);
            string giftItem = reader.GetString(5);
            htmlstr += "<option value='" + giftname + "-" + giftItem + "'>" + giftname + "-" + giftItem + "</option>";
        }
        sqlcon.Close();
        return htmlstr;

    }

    [WebMethod]
    public static string loadgiftdata()
    {

        String conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        SqlConnection sqlcon = new SqlConnection(conn);
        String JSON = "{\n \"names\":[";
        string query = "select Gift_ID_Option+'-'+GiftItem from Gift where Profile_ID='" + ProfileID + "'";
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand(query, sqlcon);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {

            while (reader.Read())
            {

                string gift = reader.GetString(0);



                JSON += "[\"" + gift + "\"],";


            }
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }
        else
        {
            JSON += "[\"" + "" + "\"],";
            JSON = JSON.Substring(0, JSON.Length - 1);
            JSON += "] \n}";
        }

        sqlcon.Close();
        return JSON;



    }
}



