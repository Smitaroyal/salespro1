<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Indian_contracts_View.aspx.cs" Inherits="_Default" %>


<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">

       <style>

           #check{
    display: none;
}
     
    #myBtn {
  display: block;
  position: fixed;
  bottom: 20px;
  right: 30px;
  z-index: 99;

  border: none;
  outline: none;
  background-color: #555;
  color: white;
  cursor: pointer;
  padding: 15px;
  border-radius: 10px;
}

#myBtn:hover {
  background-color: #555;
}  
</style>
<script src="jquery-3.2.1.min.js"></script>

<meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Contracts</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

  <link rel="stylesheet" href="/resources/demos/style.css">

  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#tabs").tabs();//{ disabled: [1, 2, 3, 4] }
          //$("#Btn1").on('click', function () {
          //    $("#tabs").tabs({ disabled: [2, 3, 4] });
          //    $("#tabs").tabs("option", "active", 1);
          //});
          //$("#Btn2").on('click', function () {
          //    $("#tabs").tabs({ disabled: [3, 4] });
          //    $("#tabs").tabs("option", "active", 2);
          //});

      });

 
      /*$("#btn").on('click', function () {
          $("#tabs").tabs("option", "active", 2);
      });*/

  </script>
    <script type="text/javascript">

             function topFunction()
           {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location='<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

           }

  </script>
 

        <style type="text/css">
            #tabs {
                padding: 10px;
                border: 1px solid #4c4c4c;
                /* max-width:1000px;*/
            }

           

            #panel, #chs2, #chs3, #panel2 {
                display: none;
            }

          
             

            

         

            .space {
                margin-right: 10px;
            }

            body {
            }
            /*#incrTextBox,*/
            #ffractional1, #tfractional, #pointsamtTextBox, #pointstaxTextBox, #testTextBox, #AffiliationamtTextBox,#findocfeeTextBox,#igstamtTextBox,#lastfingennoTextBox,#AffiliationvalueTextBox,#lblMCFees,#MCFeesTextBox,#testresTextBox,#testresnoTextBox, #lblfptsResidenceno1,#fptsResidenceno1TextBox,#lblfptsresidencetype1,#fptsresidencetype1TextBox,#lblfwresidenceno1,#fwresidenceno1TextBox,#lblfwresidencetype1,#fwresidencetype1TextBox,#oldcontracttypeTextBox,#lblinitaldepamt,#initaldepamtTextBox,#lblbaladepamt,#baldepamtTextBox,#firstdepamtTextBox,#lblfirstdepamt

 {
                /*float:left;*/
                display: none;
            }

            p {
                margin: 0px;
                padding: 0px;
            }

            .auto-style1 {
                width: 157px;
            }
            .auto-style2 {
                height: 30px;
            }
        </style>

</head>
<body>
 
<div id="tabs">
     <button onclick="topFunction();" id="myBtn" title="Go to top">Home</button>
  <form id="form1" runat="server"> 
        
  <ul>
    <%--<li><a href="#tabs-1">Profile</a></li>
    <li><a href="#tabs-2">Contract</a></li>
    <li><a href="#tabs-3">Finance Details</a></li>--%>
    <li><a href="#tabs-4">Print</a></li>
  </ul>
        <a href="#tabs-4">
      <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
      </a>

  
   </div>
      <div id="tabs-4" style="background-color:#e9e9e9;">
          <div id="Tab4cont">

              <asp:DropDownList ID="PrintPdfDropDownList" runat="server" ></asp:DropDownList> &nbsp;&nbsp <asp:Button ID="Button5" runat="server" Text="Print" OnClick="Button5_Click" />

          </div>
      </div>

        </form>
   </div>
      
    
 
 

    

</body>

</html>
