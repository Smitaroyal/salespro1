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
using Microsoft.Reporting.WebForms;

public partial class Contractsite_ReportPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void show_report()
    {
        ReportViewer1.Reset();

        DataTable dt = Queries2.loadDSR(TextBox1.Text);

        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportViewer1.LocalReport.ReportPath = "reports/report.rdlc";

        ReportParameter[] rptParam = new ReportParameter[]
        {
            new ReportParameter("year",TextBox1.Text)
        };


        ReportViewer1.LocalReport.SetParameters(rptParam);

        ReportViewer1.LocalReport.Refresh();
       

            
            


        

     }

    protected void Button1_Click(object sender, EventArgs e)
    {
        show_report();

    }
}