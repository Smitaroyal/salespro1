<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeFile="IndiaCreateProfile.aspx.cs" Inherits="_Default" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
       <style>
           #hrf{
               color:#C0C0C0;

           }
          
       </style>
      
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Contracts Application</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
       <%--<link rel="stylesheet" href="/resources/demos/style.css">--%>
   
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
    $( "#tabs" ).tabs();
  });

  $(function () {
      $("#pdobdatepicker,#sdobdatepicker,#sp1dobdatepicker,#sp2dobdatepicker,#sp3dobdatepicker,#sp4dobdatepicker,#tourdatedatepicker").datepicker({
          changeMonth: true,
          changeYear: true,
          yearRange: "-100:+0",
          dateFormat: 'yy-mm-dd'
     
          
      });

      var dates = $("#checkoutdatedatepicker,#checkindatedatepicker").datepicker({
        
          defaultDate: "+1w",
          yearRange: "-100:+0",
          dateFormat: 'yy-mm-dd',
          changeMonth: true,
          changeYear: true,
          numberOfMonths: 1,
          onSelect: function (date) {
              for (var i = 0; i < dates.length; ++i) {
                  if (dates[i].id < this.id)
                      $(dates[i]).datepicker('option', 'maxDate', date);
                  else if (dates[i].id > this.id)
                      $(dates[i]).datepicker('option', 'minDate', date);
              }
          }


      });
  });

   

  
  $("#btn").on('click', function () {
      $("#tabs").fetchTabID('2');
  });

  </script>
       <script>

           $(document).ready(function () {

               
               $("#checkindatedatepicker,#checkoutdatedatepicker").datepicker({
                   dateFormat: "yy-mm-dd"
               });

              
              
               $('#tourdatedatepicker').click(function () {

                   var minDate = $("#checkindatedatepicker").val();
                   var maxDate = $("#checkoutdatedatepicker").val();

               
                   $('#tourdatedatepicker').datepicker('destroy');

               
                   $('#tourdatedatepicker').datepicker({
                       dateFormat: "yy-mm-dd",
                   });

                 
                   if (minDate != '') {
                       $('#tourdatedatepicker').datepicker('option', 'minDate', new Date(minDate));
                   }

                   if (maxDate != '') {
                       $('#tourdatedatepicker').datepicker('option', 'maxDate', new Date(maxDate));
                   }
               });
           });
       </script>
      
       <script type="text/javascript">

           function shows() {
              var checkbox1 = document.getElementById('chs');
             if (checkbox1.checked) {
               document.getElementById("hidden").style.display = "block";
               }
               else {
                   document.getElementById("hidden").style.display = "none";
                    }

           }


       </script>

<script type="text/javascript">


    function shows2() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs2');
        
        if (checkbox2.checked) {

            document.getElementById("panel").style.display = "block";

        }
        else {
            document.getElementById("panel").style.display = "none";

        }

    }

    function shows3() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs3');

        if (checkbox2.checked) {

            document.getElementById("panel2").style.display = "block";

        }
        else {
            document.getElementById("panel2").style.display = "none";

        }

    }

    function shows4() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs4');

        if (checkbox2.checked) {

            document.getElementById("panel3").style.display = "block";

        }
        else {
            document.getElementById("panel3").style.display = "none";

        }

    }

    function shows5() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs5');

        if (checkbox2.checked) {

            document.getElementById("panel4").style.display = "block";

        }
        else {
            document.getElementById("panel4").style.display = "none";

        }

    }

    
           function topFunction()
           {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location='<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

           }

    function pele(msg) {
        //alert('hi');
        $('iframe').attr('src', msg);

    }

    
</script>

        <style type="text/css">
    
    
    #panel,#chs2,#chs3,#chs4,#chs5,#panel2,#panel3,#panel4 {
        display: none;
    }
    #TextBox22 {
        vertical-align: top;
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


#hidden1{
    display:none;
}

  iframe{
    display:none;
}            
   
        </style>

</head>
<body>
 
<div id="tabs">
    <button onclick="topFunction();" id="myBtn" title="Go to top">Home</button>
  <ul>
    <li><a href="#tabs-1">Profile</a></li>
       <li><a href="#tabs-2">Mail</a></li>
   <!-- <li><a href="#tabs-2">Contracts</a></li>
    <li><a href="#tabs-3">Finance Data</a></li>-->
  </ul>
    
     <form id="form1" runat="server">    
  <div id="tabs-1">
    <div style="border:thin solid #C0C0C0;">
    
        
       <div style="background-color:#e9e9e9; padding-top:10px; padding-left:5px; padding-right:5px;">
        <h3>PROFILE</h3>
        <hr />
          
           <table style="width:100%;">
               <tbody>
               <tr>
                   <td><asp:Label ID="Label1" runat="server" Font-Size="Medium"  Text="Profile ID" ></asp:Label></td>
                   <td><asp:TextBox ID="ProfileIDTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Label">Date Insert</asp:Label></td>
                   <td><asp:TextBox ID="createddateTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="False"></asp:TextBox></td>
                   <td><asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Label">Created By</asp:Label></td>
                   <td><asp:TextBox ID="CreatedByTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label7" runat="server" Text="Marketing Program"  Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="MarketingPrgmDropDownList" runat="server" Font-Size="small" style="width:170px; height:25px" OnSelectedIndexChanged="MarketingPrgmDropDownList_SelectedIndexChanged" Height="16px" Width="178px"></asp:DropDownList></td>
                   
               </tr>
                   
               <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="Venue Country" Font-Size="Medium"></asp:Label></td>
                    <td><asp:DropDownList ID="VenueCountryDropDownList" Font-Size="Small" runat="server" style="width:175px; height:25px" OnSelectedIndexChanged="VenueCountryDropDownList_SelectedIndexChanged" Height="24px" Width="148px"></asp:DropDownList></td>
                    <td><asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="Venue" ></asp:Label></td>
                    <td><asp:DropDownList ID="VenueDropDownList"  Font-Size="Small" runat="server" style="width:175px; height:25px" OnSelectedIndexChanged="VenueDropDownList_SelectedIndexChanged" Height="21px" Width="142px"></asp:DropDownList></td>
                    <td><asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Group Venue" ></asp:Label></td>
                    <td><asp:DropDownList ID="GroupVenueDropDownList" Font-Size="Small" runat="server" style="width:175px; height:25px" OnSelectedIndexChanged="GroupVenueDropDownList_SelectedIndexChanged" Height="21px" Width="149px"></asp:DropDownList></td>
                   <td><asp:Label ID="Label112" runat="server" Font-Size="Medium" Text="View Point ID" ></asp:Label></td>
                    <td><asp:TextBox ID="ViewPointTextBox" Font-Size="Small" style="width:165px; height:20px" runat="server" ></asp:TextBox></td>
               </tr>

               <tr>
                   <td><asp:Label ID="Label8" runat="server" Text="Agents" BorderStyle="None" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="AgentsDropDownList" runat="server" Font-Size="Small" style="width:175px; height:25px"></asp:DropDownList></td>
                   <td><asp:Label ID="Label9" runat="server" Text="TO Name" BorderStyle="None"></asp:Label></td>
                   <td><asp:DropDownList ID="TONameDropDownList" Font-Size="Small" runat="server" style="width:175px; height:25px"></asp:DropDownList></td>
                   <td><asp:Label ID="Label72" runat="server" Text="Manager"></asp:Label></td>
                   <td><asp:DropDownList ID="ManagerDropDownList" Font-Size="Small" runat="server" style="width:175px; height:25px"></asp:DropDownList></td>
                   
               </tr>
                   <tr>
                       <td> <input id="chs" type="checkbox" onclick="shows();"/> <asp:Label ID="Label10" runat="server" Font-Size="Medium" Text="Label">Are you a Member?</asp:Label></td>

                   </tr>
            </tbody>
           </table>

           <table style="width:57%;">
           <tbody id="hidden1">
              <tr>
                  <td><asp:Label ID="Label11" runat="server" Font-Size="Medium" Text="Label">Choose Source</asp:Label></td>
                  <td><asp:DropDownList ID="MemType1DropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label15" runat="server" Font-Size="Medium" Text="Label">Member Number</asp:Label></td>
                  <td><asp:TextBox ID="Memno1TextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label87" runat="server" Font-Size="Medium" Text="Label">Type</asp:Label></td>
                  <td><asp:DropDownList ID="TypeDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                  
                   <td><asp:Label ID="Label12" runat="server" Font-Size="Medium" Text="Label">Choose Member Type</asp:Label></td>
                  <td><asp:DropDownList ID="MemType2DropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label16" runat="server" Font-Size="Medium" Text="Label">Member Number</asp:Label></td>
                  <td><asp:TextBox ID="Memno2TextBox" runat="server" Font-Size="Small" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
               </tr>
           </tbody>  
           </table>
        <br /> 
        </div>
   
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PRIMARY PROFILE</h3>
        <hr />
        <br />
          <table style="width:100%;">
              <tr>
                    <td><asp:Label ID="Label90" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                  <td ><asp:DropDownList ID="primarytitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label13" runat="server" Font-Size="Medium" Text="Label">First Name</asp:Label></td>
                  <td><asp:TextBox ID="pfnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                  <td><asp:Label ID="Label14" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                  <td><asp:TextBox ID="plnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                  <td><asp:Label ID="Label17" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                  <td><asp:TextBox ID="pdobdatepicker" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
              </tr>
              <tr>
                   <td></td>
                  <td></td>
                  <td> <asp:Label ID="Label18" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                  <td><asp:DropDownList ID="primarynationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label19" runat="server" Font-Size="Medium"  Text="Label">Country</asp:Label></td>
                  <td><asp:DropDownList ID="PrimaryCountryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" OnSelectedIndexChanged="PrimaryCountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                   <td><asp:Label ID="Label70" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                  <td><asp:TextBox ID="primaryAge" runat="server" Font-Size="Small" Enabled="True" style="width:170px; height:20px"></asp:TextBox></td>
              </tr>
              <tr>
                   <td></td>
                   <td></td>
                  <td><asp:Label ID="Label21" runat="server" Font-Size="Medium" Text="Mobile #"></asp:Label></td>
                  <td><asp:DropDownList ID="primarymobileDropDownList" Font-Size="Small" runat="server" style="width:70px; height:25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="pmobileTextBox" Font-Size="Small" style="width:95px; height:20px" runat="server"  Enabled="True"></asp:TextBox></td>
                  <td><asp:Label ID="Label22" runat="server" Font-Size="Medium" Text="Home #"></asp:Label></td>
                  <td><asp:DropDownList ID="primaryalternateDropDownList" runat="server" Font-Size="Small" style="width:70px; height:25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="palternateTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td><asp:Label ID="Label113" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                  <td><asp:DropDownList ID="pofficecodeDropDownList" runat="server" Font-Size="Small" style="width:70px; height:25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="pofficenoTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   
              </tr>
              <tr>
                  <td></td>
                    <td></td>
                  <td><asp:Label ID="Label20" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                  <td><asp:TextBox ID="pemailTextBox" runat="server" Font-Size="Small" Enabled="True" style="width:170px; height:20px"></asp:TextBox></td>
              </tr>
              <tr>
                  
                  <td></td>
                  <td></td>
                  <td><asp:Label ID="Label85" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                    <td><select multiple="multiple" style="width:175px; height:70px" name="primarylang" id="primarylang">
                              <option value="English">English</option>
                              <option value="Hindi">Hindi</option>
                              <option value="Konkani">Konkani</option>
                              <option value="Marathi">Marathi</option>
                              <option value="Kannada">Kannada</option>
                              <option value="Malayam">Malayam</option>
                              <option value="Tamil">Tamil</option>
                              <option value="Telegu">Telegu</option>
                              <option value="French">French</option>
                              <option value="Portuguese">Portuguese</option>

                      </select></td>
              </tr>

             
          </table>
        <br />
         </div>
     
         
        <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>SECONDARY PROFILE</h3>
        <hr />
         <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                         <td><asp:Label ID="Label73" runat="server" Font-Size="Medium"  Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="secondarytitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label23" runat="server" Font-Size="Medium" Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sfnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label24" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="slnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label25" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sdobdatepicker" runat="server" Font-Size="Small" style="width:170px; height:20px"  Enabled="True"></asp:TextBox></td>

                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label26" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="secondarynationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label27" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="SecondaryCountryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" OnSelectedIndexChanged="SecondaryCountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                         
                         <td><asp:Label ID="Label77" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="secondaryAge" runat="server" Font-Size="Small" Enabled="True" style="width:170px; height:20px"></asp:TextBox></td>
                    </tr>

                    <tr>
                         <td></td>
                         <td></td>
                         <td><asp:Label ID="Label29" runat="server" Font-Size="Medium" Text="Mobile #"></asp:Label></td>
                         <td><asp:DropDownList ID="secondarymobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="smobileTextBox" runat="server" style="width:95px; height:20px" Font-Size="Medium" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label30" runat="server" Font-Size="Medium"  Text="Alternate #"></asp:Label></td>
                         <td><asp:DropDownList ID="secondaryalternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="salternateTextBox" Font-Size="Small" style="width:95px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label114" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                         <td><asp:DropDownList ID="sofficecodeDropDownList" runat="server" Font-Size="Small" style="width:70px; height:25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="sofficenoTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                         
                    </tr>
              <tr>
                  <td></td>
                    <td></td>
                  <td><asp:Label ID="Label28" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="semailTextBox" runat="server" Font-Size="Small" style="width:170px; height:25px" Enabled="True"></asp:TextBox></td>
              </tr>
                     <tr>
                  <td></td>
                  <td></td>
                  <td><asp:Label ID="Label88" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                         <td><select multiple="multiple" style="width:175px; height:70px" name="seclang">
                             <option value="English">English</option>
                              <option value="Hindi">Hindi</option>
                              <option value="Konkani">Konkani</option>
                              <option value="Marathi">Marathi</option>
                              <option value="Kannada">Kannada</option>
                              <option value="Malayam">Malayam</option>
                              <option value="Tamil">Tamil</option>
                              <option value="Telegu">Telegu</option>
                              <option value="French">French</option>
                              <option value="Portuguese">Portuguese</option>

                      </select></td>
              </tr>

             
                </tbody>
            </table> 
         <br />
        <br />
        </div>
 
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>ADDRESS</h3>
        <hr />
        <br />
          <table style="width:100%;">
              <tbody>
                  <tr>
                      <td><asp:Label ID="Label31" runat="server" Font-Size="Medium" Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="address1TextBox" runat="server" Font-Size="Small" style="height:25px" Enabled="True" Width="250px"></asp:TextBox></td>
                      <td><asp:Label ID="Label32" runat="server" Font-Size="Medium" Text="Label">Address Line2</asp:Label></td>
                      <td><asp:TextBox ID="address2TextBox" runat="server" Font-Size="Small" style="height:25px" Enabled="True" Width="220px"></asp:TextBox></td>
                      <td><asp:Label ID="Label61" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                      <td><asp:DropDownList ID="AddCountryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>

                  </tr>

                  <tr>
                      <td><asp:Label ID="Label33" runat="server" Font-Size="Medium" Text="Label">State</asp:Label></td>
                      <td><asp:DropDownList ID="StateDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>
                      <td><asp:Label ID="Label34" runat="server" Font-Size="Medium" Text="Label">City</asp:Label></td>
                      <td><asp:TextBox ID="cityTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="Label39" runat="server"  Font-Size="Medium" Text="Label">Pincode</asp:Label></td>
                      <td><asp:TextBox ID="pincodeTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                  </tr>

                 
     <!--stateTextBox-->
              </tbody>
          </table>
    </div>

          <div style="padding-top: 10px; padding-left: 5px; padding-right: 5px;">
              <h3>OTHER DETAILS</h3>
              <hr />
              <br />
              <table style="width: 100%;">
                  <tbody>
                       <tr>
                      <td><asp:Label ID="Label40" runat="server" Font-Size="Medium" Text="Label">Employee Status</asp:Label></td>
                      <td><asp:DropDownList ID="employmentstatusDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label35" runat="server" Font-Size="Medium" Text="Label">Marital Status</asp:Label></td>
                      <td><asp:DropDownList ID="MaritalStatusDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label41" runat="server" Font-Size="Medium" Text="Label">No of Year living together as a couple</asp:Label></td>
                      <td><asp:TextBox ID="livingyrsTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server"></asp:TextBox></td>

                  </tr>

                  <tr>
                      <td><asp:Label ID="Label80" runat="server" Font-Size="Medium" Text="Label">Professional/Designation :</asp:Label></td>
                      <td></td>
                      <td><asp:Label ID="Label81" runat="server" Font-Size="Medium" Text="Label">Primary</asp:Label></td>
                      <td><asp:TextBox ID="maledesgTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label82" runat="server" Font-Size="Medium" Text="Label">Secondary</asp:Label></td>
                      <td><asp:TextBox ID="femaledesgTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server"></asp:TextBox></td>

                  </tr>
                  <tr>
                    <td><asp:Label ID="Label83" runat="server" Font-Size="Medium" Text="Label">Photo Identity:</asp:Label></td>
                    <td><select multiple="multiple" style="width:175px; height:70px" name="pidentity">
                       <option value="Membership Card">Membership Card(if member with any club)</option>
                          <option value="Driving License">Driving License</option>
                          <option value="Pan Card">PAN Card</option>
                          <option value="Passport">Passport</option>
                             <option value="Adhar Card">Adhar Card</option>
                          <option value="Others">Others</option>
                        </select></td>
                    <td><asp:Label ID="Label84" runat="server" Font-Size="Medium" Text="Label">Kind Of Card:</asp:Label></td>
                    <td><select multiple="multiple" style="width:175px; height:70px" name="card">
                        <option value="T1">Titanium</option>
                        <option value="Platinum">Platinum</option>
                        <option value="Gold">Gold</option>
                        <option value="Silver">Silver</option>
                        <option value="Visa">Visa</option>
                        <option value="Mastercard">Mastercard</option>
                        <option value="Debit Card">Debit Card</option>
                        <option value="Others">Others</option>

                        </select></td>

                  </tr>


                  </tbody>

              </table>


          </div><br>
      
   <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs2" type="checkbox" onclick="shows2();"/>
 <label for="chs2">SUB PROFILE 1</label>      
        <div id="panel" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                         <td><asp:Label ID="Label75" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile1titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label36" runat="server" Font-Size="Medium" Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sp1fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label37" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="sp1lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label38" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sp1dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label42" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile1nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label43" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                        <td><asp:DropDownList ID="SubProfile1CountryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" OnSelectedIndexChanged="SubProfile1CountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                      <td><asp:Label ID="Label78" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                        <td><asp:TextBox ID="subProfile1Age" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                      
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label45" runat="server" Font-Size="Medium" Text="Label">Mobile Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile1mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1mobileTextBox" runat="server" style="width:95px;  height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label46" runat="server" Font-Size="Medium" Text="Label">Alternate Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile1alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1alternateTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                          <td><asp:Label ID="Label44" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="sp1emailTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>

                </tbody>
            </table>
  
    </div>
       <br />
     <br />
   </div>
     
     <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs3" type="checkbox" onclick="shows3();"/>
 <label for="chs3">SUB PROFILE 2</label>      
        <div id="panel2" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                         <td><asp:Label ID="Label76" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2titleDropDownList" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label47" runat="server" Font-Size="Medium"  Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sp2fnameTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label48" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="sp2lnameTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label49" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sp2dobdatepicker" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label50" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2nationalityDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label51" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                        <td><asp:DropDownList ID="SubProfile2CountryDropDownList" runat="server" style="width:175px; height:25px" Font-Size="Small"  OnSelectedIndexChanged="SubProfile2CountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:Label ID="Label79" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                        <td><asp:TextBox ID="subProfile2Age" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label53" runat="server" Font-Size="Medium" Text="Label">Mobile Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2mobileDropDownList" style="width:70px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2mobileTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label54" runat="server" Font-Size="Medium" Text="Label">Alternate Number</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile2alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2alternateTextBox" Font-Size="Small" runat="server" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label52" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="sp2emailTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                          </tr>
                      
                </tbody>
            </table>   
           </div>
         <br />
     <br />
   </div>
          <!-- sub profile 3-->

            <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs4" type="checkbox" onclick="shows4();"/>
 <label for="chs4">SUB PROFILE 3</label>      
        <div id="panel3" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                         <td><asp:Label ID="Label89" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile3titleDropDownList" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label91" runat="server" Font-Size="Medium"  Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sp3fnameTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label92" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="sp3lnameTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label93" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sp3dobdatepicker" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        
                    </tr>
                   
                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label94" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile3nationalityDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label95" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile3countryDropDownList" runat="server" style="width:175px; height:25px" Font-Size="Small"  OnSelectedIndexChanged="SubProfile2CountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:Label ID="Label96" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                        <td><asp:TextBox ID="sp3ageTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        
                    </tr>
                   
                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label97" runat="server" Font-Size="Medium" Text="Label">Mobile Number</asp:Label></td>
                        <td><asp:DropDownList ID="sp3mobileDropDownList" style="width:70px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp3mobileTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label98" runat="server" Font-Size="Medium" Text="Label">Alternate Number</asp:Label></td>
                        <td><asp:DropDownList ID="sp3altmobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp3altmobileTextBox" Font-Size="Small" runat="server" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label99" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="sp3emailTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                          </tr>
              
                </tbody>
            </table>   
           </div>
         <br />
     <br />
   </div>
          <!--end--->


          <!--- sub profile 4 -->
           <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs5" type="checkbox" onclick="shows5();"/>
 <label for="chs5">SUB PROFILE 4</label>      
        <div id="panel4" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                         
                         <td><asp:Label ID="Label100" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile4titleDropDownList" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label101" runat="server" Font-Size="Medium"  Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sp4fnameTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label102" runat="server" Font-Size="Medium" Text="Label">Last Name</asp:Label></td>
                        <td><asp:TextBox ID="sp4lnameTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label103" runat="server" Font-Size="Medium" Text="Label">Date Of Birth</asp:Label></td>
                        <td><asp:TextBox ID="sp4dobdatepicker" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label104" runat="server" Font-Size="Medium" Text="Label">Nationality</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile4nationalityDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label105" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                        <td><asp:DropDownList ID="subprofile4countryDropDownList" runat="server" style="width:175px; height:25px" Font-Size="Small"  OnSelectedIndexChanged="SubProfile2CountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:Label ID="Label106" runat="server" Font-Size="Medium" Text="Label">Age</asp:Label></td>
                        <td><asp:TextBox ID="sp4ageTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td><asp:Label ID="Label107" runat="server" Font-Size="Medium" Text="Label">Mobile Number</asp:Label></td>
                        <td><asp:DropDownList ID="sp4mobileDropDownList" style="width:70px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp4mobileTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label108" runat="server" Font-Size="Medium" Text="Label">Alternate Number</asp:Label></td>
                        <td><asp:DropDownList ID="sp4altmobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp4altmobileTextBox" Font-Size="Small" runat="server" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label109" runat="server" Font-Size="Medium" Text="Label">Email</asp:Label></td>
                        <td><asp:TextBox ID="sp4emailTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                          </tr>
                  
                    
                 
                </tbody>
            </table>   
           </div>
         <br />
     <br />
   </div>


          <!---- end-->
 
        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>STAY DETAILS</h3>
        <hr />
        <br />
            <table style="width:100%;">
                <tbody>
          
                    <tr>
                        <td><asp:Label ID="Label55" runat="server" Font-Size="Medium" Text="Label">Resort Name</asp:Label></td>
                        <td><asp:TextBox ID="hotelTextBox" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label56" runat="server" Font-Size="Medium" Text="Label">Resort Room No</asp:Label></td>
                        <td><asp:TextBox ID="roomnoTextBox" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label57" runat="server" Font-Size="Medium" Text="Label">Arrival-Date</asp:Label></td>
                        <td><asp:TextBox ID="checkindatedatepicker" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label58" runat="server" Font-Size="Medium" Text="Label">Departure-Date</asp:Label></td>
                        <td><asp:TextBox ID="checkoutdatedatepicker" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label59" runat="server" Font-Size="Medium" Text="Choose Gift Option"  BorderStyle="None" ></asp:Label></td>
                        <td><asp:ListBox ID="giftListBox" runat="server" Font-Size="Small" Height="100px" SelectionMode="Multiple" Width="155px" ></asp:ListBox></td>
                        <td><asp:Label ID="Label60" runat="server" Font-Size="Medium" Text="Label">Voucher No.</asp:Label></td>
                        <td><asp:TextBox ID="vouchernoTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label74" runat="server" Font-Size="Medium" Text="Comment"></asp:Label></td>
                        <td><asp:TextBox ID="commentTextBox" runat="server" Font-Size="Small" Enabled="True" TextMode="MultiLine" Height="60px" Width="150px"></asp:TextBox></td>
                        <td><asp:Label ID="Label62" runat="server" Font-Size="Medium" Text="Label">Guest Status</asp:Label></td>
                        <td><asp:DropDownList ID="gueststatusDropDownList" Font-Size="Small" style="width:150px; height:25px" runat="server"></asp:DropDownList></td>

                    </tr>

                    <tr>
                        <td><asp:Label ID="Label71" runat="server" Font-Size="Medium" Text="Tour Date"></asp:Label></td>
                        <td><asp:TextBox ID="tourdatedatepicker" Font-Size="Small" style="width:150px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label63" runat="server" Font-Size="Medium" Text="Sales Rep"></asp:Label></td>
                        <td><asp:DropDownList ID="salesrepDropDownList" Font-Size="Small" style="width:155px; height:25px;" runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label64" runat="server" Font-Size="Medium"  Text="Check-In Time" BorderStyle="None" ></asp:Label></td>
                        <td><asp:TextBox ID="deckcheckintimeTextBox" Font-Size="Small" placeholder="HH:MM" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label65" runat="server" Font-Size="Medium" Text="Check-Out Time" BorderStyle="None" ></asp:Label></td>
                        <td><asp:TextBox ID="deckcheckouttimeTextBox" Font-Size="Small" placeholder="HH:MM" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td><asp:Label ID="Label66" runat="server" Font-Size="Medium" Text="Taxi in Price" BorderStyle="None"></asp:Label></td>
                        <td><asp:TextBox ID="taxipriceInTextBox" runat="server" Font-Size="Small" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label67" runat="server" Font-Size="Medium" Text="Taxi in Reference" BorderStyle="None"></asp:Label></td>
                        <td><asp:TextBox ID="TaxiRefInTextBox" runat="server" Font-Size="Small" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label68" runat="server" Font-Size="Medium" Text="Label">Taxi out Price</asp:Label></td>
                        <td><asp:TextBox ID="TaxiPriceOutTextBox" runat="server" Font-Size="Small" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label69" runat="server" Font-Size="Medium" Text="Label">Taxi out Reference</asp:Label></td>
                        <td><asp:TextBox ID="TaxiRefOutTextBox" Font-Size="Small" runat="server" style="width:150px; height:20px" Enabled="True"></asp:TextBox></td>

                    </tr>
                   
                </tbody>
            </table>
             <table style="width:59%;">

                    <tr>
                          <td><asp:Label ID="Label86" runat="server" Font-Size="Medium" Text="Comments" BorderStyle="None"></asp:Label></td>
                          <td><asp:TextBox ID="commentsTextBox"  runat="server" style="width:300px; height:120px" TextMode="MultiLine"></asp:TextBox></td>

                    </tr>
                  

               </table>
        <br />
        <br />
            <table style="width: 59%;">
                <tr>
                    <td><asp:CheckBox ID="CheckBox1" runat="server" Text="Registration Card Terms" /></td>
                    

                </tr>
            </table>
             <br />
        <br />
        </div>
           <br />
        
    
          <%--<asp:Label ID="Label70" runat="server" Text="Label"></asp:Label>--%>
          
    
          <br />

         <center><asp:Button ID="Button1"  runat="server"  autopostback="true" OnClick="Button1_Click" Text="Create Profile" />&nbsp; <asp:Button ID="Button3"  runat="server"  autopostback="true" OnClick="Button3_Click" Text="Print" Width="66px" />&nbsp; <asp:Button ID="Button4"  runat="server"  autopostback="true" OnClick="Button4_Click" Text="Refresh" Width="66px" /></center> <br />
          <br />
        <iframe src="" style="width:100px;height:100px;"></iframe>
          
    
  
</div>

  </div>

  <div id="tabs-2">
      <div style="border:thin solid #C0C0C0;">
    
       <div style="background-color:#e9e9e9; padding-top:10px; padding-left:5px; padding-right:5px;">
        <h3>Mail</h3>
        <hr />
           <asp:Label ID="Label1000" runat="server" Font-Size="Medium" Text="TO" BorderStyle="None"></asp:Label><br />
           <asp:TextBox ID="emailTo" runat="server" Width="300px"></asp:TextBox><br /><br />
           <asp:Label ID="Label110" runat="server" Font-Size="Medium" Text="Subject" BorderStyle="None"></asp:Label><br />
              <asp:TextBox ID="emailSubject" runat="server" Width="300px"></asp:TextBox><br /><br />
           <asp:Label ID="Label111" runat="server" Font-Size="Medium" Text="Body" BorderStyle="None"></asp:Label><br />
              <asp:TextBox ID="emailBody" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox><br /><br />
             <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" /><br /><br />

            <asp:Button ID="Button2" runat="server" Text="send" OnClick="Button2_Click" style="height: 26px" />

           </div>
          </div>
          
  </div>
  <div id="tabs-3">
    

  </div>
    </form>
</div>
  <script>

        $(document).ready(function () {
            $("#VenueCountryDropDownList").change(function ()
            {
                var value = $("#VenueCountryDropDownList").val();
                $.ajax({
                    
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadVenueOnVenueCountry',
                    data: "{'venuecountry':'" + value + "'}",
                    async: false,
                    success: function (data) {
                       // alert(data.d);
                        $("#VenueDropDownList").empty();
                        $("#VenueDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                      //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                               // $("#adminfeeTextBox").val(value1[0]);
                                // $("#pointstaxTextBox").val(value1[1]);
                                $("#VenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }
                    


                });

              
                return false;
                
            });
 


        });
    </script>
    <script>
        $(document).ready(function () {
            $("#VenueDropDownList").change(function () {
                var value = $("#VenueDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadGroupVenueOnVenue',
                    data: "{'venue':'" + value + "'}",
                    async: false,
                    success: function (data) {
                       //  alert(data.d);
                         $("#GroupVenueDropDownList").empty();
                         $("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                       // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                
                            $("#GroupVenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                //get sales rep name
                var v = document.getElementById("VenueCountryDropDownList");
                var vcountry = v.options[v.selectedIndex].text;
               
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadSalesRepOnVenue',
                    data: "{'venue':'" + value + "','country':'"+vcountry+"'}",
                    async: false,
                    success: function (data) {
                       // alert(data.d);
                        $("#salesrepDropDownList").empty();
                        $("#salesrepDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                       // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#salesrepDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
               
                ////agents
                //$.ajax({

                //    type: 'post',
                //    contentType: "application/json; charset=utf-8",
                //    url: 'IndiaCreateProfile.aspx/LoadAgents',
                //    data: "{'venue':'"+value+"'}",
                //    async: false,
                //    success: function (data) {
                //       /// alert(data.d);
                //        $("#AgentsDropDownList").empty();
                //        $("#AgentsDropDownList").append("<option disabled selected value>select an option  </option>")
                //        subJson = JSON.parse(data.d);

                //     //   alert(subJson);
                //        $.each(subJson, function (key, value) {
                //            $.each(value, function (index1, value1) {

                //                $("#AgentsDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                //            });
                //        });
                //    },
                //    error: function () {
                //        alert("wrong");
                //    }



                //});

                ////to amnagers
                //$.ajax({

                //    type: 'post',
                //    contentType: "application/json; charset=utf-8",
                //    url: 'IndiaCreateProfile.aspx/LoadTO',
                //    data: "{'venue':'" + value + "'}",
                //    async: false,
                //    success: function (data) {
                //      //  alert(data.d);
                //        $("#TONameDropDownList").empty();
                //        $("#TONameDropDownList").append("<option disabled selected value>select an option  </option>")
                //        subJson = JSON.parse(data.d);

                //       // alert(subJson);
                //        $.each(subJson, function (key, value) {
                //            $.each(value, function (index1, value1) {

                //                $("#TONameDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                //            });
                //        });
                //    },
                //    error: function () {
                //        alert("wrong");
                //    }



                //});
                //to venue mgrs
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadManagersOnVenue',
                    data: "{'venue':'" + value + "'}",
                    async: false,
                    success: function (data) {
                     //   alert(data.d);
                        $("#ManagerDropDownList").empty();
                        $("#ManagerDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

//alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#ManagerDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;

            });



        });
    </script>

    <script>
        //    mktg prgm
        $(document).ready(function () {
            $("#GroupVenueDropDownList").change(function () {
                var value = $("#GroupVenueDropDownList").val();
                var v1 = document.getElementById("VenueDropDownList");
                var venue = v1.options[v1.selectedIndex].text;
                if (value == "Coldline") {
                    
                    $("#Label72").show();
                    $("#ManagerDropDownList").show();
                }
                else {
                    $("#Label72").hide();
                    $("#ManagerDropDownList").hide();
                }
                var value = $("#GroupVenueDropDownList").val();
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaCreateProfile.aspx/LoadMktgOnVenuenVenueGrp',
            data: "{'venue':'" + venue + "','venuegrp':'" + value + "'}",
            async: false,
            success: function (data) {
                // alert(data.d);
                $("#MarketingPrgmDropDownList").empty();
                $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                subJson = JSON.parse(data.d);

                // alert(subJson);
                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {

                        $("#MarketingPrgmDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                    });
                });
            },
            error: function () {
                alert("wrong");
            }
            


        });
       
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaCreateProfile.aspx/LoadAgentsOnVenuegrp',
            data: "{'venue':'" + venue + "','vgrp':'" + value + "'}",
            async: false,
            success: function (data) {
                // alert(data.d);
                $("#AgentsDropDownList").empty();
                $("#AgentsDropDownList").append("<option disabled selected value>select an option  </option>")
                subJson = JSON.parse(data.d);

                // alert(subJson);
                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {

                        $("#AgentsDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                    });
                });
            },
            error: function () {
                alert("wrong");
            }



        });
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaCreateProfile.aspx/LoadTOOnVenueNVGrp',
            data: "{'venue':'" + venue + "','vgrp':'" + value + "'}",
            async: false,
            success: function (data) {
                // alert(data.d);
                $("#TONameDropDownList").empty();
                $("#TONameDropDownList").append("<option disabled selected value>select an option  </option>")
                subJson = JSON.parse(data.d);

                // alert(subJson);
                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {

                        $("#TONameDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                    });
                });
            },
            error: function () {
                alert("wrong");
            }



        });
       
            });
        });
    </script>

    <script>
      //country code
        $(document).ready(function () {
            $("#PrimaryCountryDropDownList").change(function () {
                var value = $("#PrimaryCountryDropDownList").val();
              
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaCreateProfile.aspx/LoadCountryCode',
            data: "{'country':'" + value + "'}",
            async: false,
            success: function (data) {
             
                $("#primarymobileDropDownList").empty();
              //  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                subJson = JSON.parse(data.d);

                // alert(subJson);
                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {

                        $("#primarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                    });
                });
            },
            error: function () {
                alert("wrong");
            }



        });
            });

            $("#PrimaryCountryDropDownList").change(function () {
                var value = $("#PrimaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#primaryalternateDropDownList").empty();
                       $("#primaryalternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            $("#PrimaryCountryDropDownList").change(function () {
                var value = $("#PrimaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#pofficecodeDropDownList").empty();
                          $("#pofficecodeDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#pofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            //secondary

            $("#SecondaryCountryDropDownList").change(function () {
                var value = $("#SecondaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#secondarymobileDropDownList").empty();
                        //  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            $("#SecondaryCountryDropDownList").change(function () {
                var value = $("#SecondaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#secondaryalternateDropDownList").empty();
                      $("#secondaryalternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            $("#SecondaryCountryDropDownList").change(function () {
                var value = $("#SecondaryCountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#sofficecodeDropDownList").empty();
                      $("#sofficecodeDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            //subprofile1

            $("#SubProfile1CountryDropDownList").change(function () {
                var value = $("#SubProfile1CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#subprofile1mobileDropDownList").empty();
                        //  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile1mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            $("#SubProfile1CountryDropDownList").change(function () {
                var value = $("#SubProfile1CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#subprofile1alternateDropDownList").empty();
                     //   $("#subprofile1alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile1alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            //subprofile2

            $("#SubProfile2CountryDropDownList").change(function () {
                var value = $("#SubProfile2CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#subprofile2mobileDropDownList").empty();
                        //  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile2mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

            $("#SubProfile2CountryDropDownList").change(function () {
                var value = $("#SubProfile2CountryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#subprofile2alternateDropDownList").empty();
                     //   $("#subprofile2alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile2alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
            });

        });
    </script>
 
    <script>

        $(document).ready(function () {
         //   $("#hidden1").hide();
            $("#chs").click(function () {
                if ($("#chs").is(':checked')) {

                    $("#hidden1").show();
                } else {
                    $("#hidden1").hide();
                }
            });
        });


    </script>

    <script>
        $(document).ready(function () {
            $("#pdobdatepicker").change(function () {
                
                var date = $("#pdobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#primaryAge').val(age);
            });
        });

    </script>

    <script>
        $(document).ready(function () {
            $("#sdobdatepicker").change(function () {
                var date = $("#sdobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#secondaryAge').val(age);
            });



        });
    </script>

     <script>
        $(document).ready(function () {
            $("#sp1dobdatepicker").change(function () {
                var date = $("#sp1dobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile1Age').val(age);
            });



        });
    </script>

    <script>
        $(document).ready(function () {
            $("#sp2dobdatepicker").change(function () {
                var date = $("#sp2dobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile2Age').val(age);
            });



        });
    </script>
     <script>
        $(document).ready(function () {
            $("#sp3dobdatepicker").change(function () {
                var date = $("#sp3dobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#sp3ageTextBox').val(age);
            });



        });
    </script>

     <script>
        $(document).ready(function () {
            $("#sp4dobdatepicker").change(function () {
                var date = $("#sp4dobdatepicker").val();
                dob = new Date(date);
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#sp4ageTextBox').val(age);
            });



        });
    </script>


    <script>
        $(document).ready(function () {
            $("#Button1").click(function (e) {
                var isValid = true;
                if ($.trim($("#MarketingPrgmDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Marketing Program");
                    $("#MarketingPrgmDropDownList").css({
                   
                        "border": "1px solid red",
                       
                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();
          
                       
                } else {
                    $("#MarketingPrgmDropDownList").css({
                      
                        "border": "",
                     
                        "background": ""
               
                });
                   // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#VenueCountryDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Venue Country ");
                    $("#VenueCountryDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#VenueCountryDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                   // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }
               
                var isValid = true;
                if ($.trim($("#VenueDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Venue  ");
                    $("#VenueDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#VenueDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#GroupVenueDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Venue Group");
                    $("#GroupVenueDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#GroupVenueDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#AgentsDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Agent");
                    $("#AgentsDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#AgentsDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#TONameDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select TO Name");
                    $("#TONameDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#TONameDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                //var isValid = true;
                //if ($.trim($("#ManagerDropDownList").val()) == '') {
                //    isValid = false;
                //    alert("Select Manager");
                //    $("#ManagerDropDownList").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#ManagerDropDownList").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}
                   
                //primary profile

                var isValid = true;
                if ($.trim($("#primarytitleDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Title");
                    $("#primarytitleDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#primarytitleDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#pfnameTextBox").val()) == '') {
                    isValid = false;
                    alert("Enter First Name");
                    $("#pfnameTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#pfnameTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }
                var isValid = true;
                if ($.trim($("#plnameTextBox").val()) == '') {
                    isValid = false;
                    alert("Enter Last Name");
                    $("#plnameTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#plnameTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }
                var isValid = true;
                if ($.trim($("#pdobdatepicker").val()) == '') {
                    isValid = false;
                    alert("Select Date Of Birth");
                    $("#pdobdatepicker").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#pdobdatepicker").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#primarynationalityDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Nationality");
                    $("#primarynationalityDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#primarynationalityDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#PrimaryCountryDropDownList").val()) == '') {
                    isValid = false;
                    alert("Select Country");
                    $("#PrimaryCountryDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#PrimaryCountryDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#primaryAge").val()) == '') {
                    isValid = false;
                    alert("Enter Age");
                    $("#primaryAge").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#primaryAge").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                //var isValid = true;
                //if ($.trim($("#primarymobileDropDownList").val()) == '') {
                //    isValid = false;
                //    alert("Select Country Code");
                //    $("#primarymobileDropDownList").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#primarymobileDropDownList").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}


                //var isValid = true;
                //if ($.trim($("#pmobileTextBox").val()) == '') {
                //    isValid = false;
                //    alert("Enter Mobile Number");
                //    $("#pmobileTextBox").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#pmobileTextBox").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}

                //var isValid = true;
                //if ($.trim($("#primaryalternateDropDownList").val()) == '') {
                //    isValid = false;
                //    alert("Select Country Code");
                //    $("#primaryalternateDropDownList").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#primaryalternateDropDownList").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}

                ////////
                //var isValid = true;
                //if ($.trim($("#palternateTextBox").val()) == '') {
                //    isValid = false;
                //    alert("Enter Mobile Number");
                //    $("#palternateTextBox").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#palternateTextBox").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}



                //var isValid = true;
                //if ($.trim($("#pemailTextBox").val()) == '') {
                //    isValid = false;
                //    alert("Enter Email");
                //    $("#pemailTextBox").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#pemailTextBox").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}

                //var isValid = true;
                //if ($.trim($("#primarylang").val()) == '') {
                //    isValid = false;
                //    alert("Select Language");
                //    $("#primarylang").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#primarylang").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}


                ////// Stay Details/////

                var isValid = true;
                if ($.trim($("#hotelTextBox").val()) == '') {
                    isValid = false;
                    alert("Enter Resort Name");
                    $("#hotelTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#hotelTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                //var isValid = true;
                //if ($.trim($("#roomnoTextBox").val()) == '') {
                //    isValid = false;
                //    alert("Enter Resort Room Number");
                //    $("#roomnoTextBox").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#roomnoTextBox").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}


                //var isValid = true;
                //if ($.trim($("#checkindatedatepicker").val()) == '') {
                //    isValid = false;
                //    alert("Enter Arrival-Date");
                //    $("#checkindatedatepicker").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#checkindatedatepicker").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}


                //var isValid = true;
                //if ($.trim($("#checkoutdatedatepicker").val()) == '') {
                //    isValid = false;
                //    alert("Enter Depature-Date");
                //    $("#checkoutdatedatepicker").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#checkoutdatedatepicker").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}
   

                //var isValid = true;
                //if ($.trim($("#gueststatusDropDownList").val()) == '') {
                //    isValid = false;
                //    alert("Enter Guest Status");
                //    $("#gueststatusDropDownList").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#gueststatusDropDownList").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}


                //var isValid = true;
                //if ($.trim($("#tourdatedatepicker").val()) == '') {
                //    isValid = false;
                //    alert("Enter Tour Date");
                //    $("#tourdatedatepicker").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#tourdatedatepicker").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}

                //var isValid = true;
                //if ($.trim($("#salesrepDropDownList").val()) == '') {
                //    isValid = false;
                //    alert("Select Sales Rep");
                //    $("#salesrepDropDownList").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#salesrepDropDownList").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}

                //var isValid = true;
                //if ($.trim($("#deckcheckintimeTextBox").val()) == '') {
                //    isValid = false;
                //    alert("Select Check-In-Date");
                //    $("#deckcheckintimeTextBox").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#deckcheckintimeTextBox").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}

                //var isValid = true;
                //if ($.trim($("#deckcheckouttimeTextBox").val()) == '') {
                //    isValid = false;
                //    alert("Select Check-Out Time");
                //    $("#deckcheckouttimeTextBox").css({

                //        "border": "1px solid red",

                //        "background": "#FFCECE"
                //    });
                //    if (isValid == false)
                //        e.preventDefault();


                //} else {
                //    $("#deckcheckouttimeTextBox").css({

                //        "border": "",

                //        "background": ""

                //    });
                //    // alert('Thank you for submitting');
                //    //$("#TextBox1").val("");
                //}

            });

        });
       
    </script>
    <script>
        $(document).ready(function () {
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaCreateProfile.aspx/getAllMemberType',
                data: "{}",
                async: false,
                success: function (data) {

                    $("#MemType1DropDownList").empty();
                    $("#MemType1DropDownList").append("<option disabled selected value>select an option  </option>")

                    $("#MemType2DropDownList").empty();
                    $("#MemType2DropDownList").append("<option disabled selected value>select an option  </option>")
                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#MemType1DropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#MemType2DropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                        });
                    });
                },
                error: function () {
                    alert("wrong");
                }
                
          


            });




        });
    </script>


    <script>
        $(document).ready(function () {
            $("#MemType2DropDownList").hide();
            $("#Label12").hide();
            $("#Label16").hide();
            $("#Memno2TextBox").hide();


            $("#Label15").hide();
            $("#Memno1TextBox").hide();
            $("#Label87").hide();
            $("#TypeDropDownList").hide();

            $("#Label11").hide();
            $("#MemType1DropDownList").hide();
            
            

            $("#AddCountryDropDownList").change(function () {

                var value = $("#AddCountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadStates',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        $("#StateDropDownList").empty();
                        $("#StateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#StateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
               //return false;



            });


            $("#MarketingPrgmDropDownList").change(function () {

                var marketingValue = $("#MarketingPrgmDropDownList").val();
                //alert(marketingValue);
                if (marketingValue == "OWNER" || marketingValue == "Owner" || marketingValue == "owner") {

                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").show();
                    $("#Memno1TextBox").show();
                    $("#Label87").hide();
                    $("#TypeDropDownList").hide();
                }
                else {
                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").hide();
                    $("#Memno1TextBox").hide();
                    $("#Label87").show();
                    $("#TypeDropDownList").show();
                  
                }


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadTypes',
                    data: "{}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        $("#TypeDropDownList").empty();
                        $("#TypeDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#TypeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                //return false;


               



            });




        });


    </script>


    <script>

        $(document).ready(function () {
            
            

            $("#subprofile3countryDropDownList").change(function () {
                var country = $("#subprofile3countryDropDownList").val();

                //alert(country); 
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                      //  alert(data.d);
                        $("#sp3mobileDropDownList").empty();
                    //    $("#sp3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp3mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;

            });

            $("#subprofile3countryDropDownList").change(function () {
                var value = $("#subprofile3countryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#sp3altmobileDropDownList").empty();
                        $("#sp3altmobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp3altmobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

                return false;
            });


        });


    </script>


    <script>

        $(document).ready(function () {
            $("#subprofile4countryDropDownList").change(function () {

                var country = $("#subprofile4countryDropDownList").val();
             //   alert(country);
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //  alert(data.d);
                        $("#sp4mobileDropDownList").empty();
                        //    $("#sp3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp4mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;



            });


            $("#subprofile4countryDropDownList").change(function () {
                var value = $("#subprofile4countryDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaCreateProfile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        $("#sp4altmobileDropDownList").empty();
                        $("#sp4altmobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp4altmobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

                return false;
            });



        });


    </script>

    <script>

        $(document).ready(function () {

            $("#pmobileTextBox").on("blur", function (e) {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                      //  alert("valid");
                      
                    } else {
                        alert('Enter valid number ');
                   
                        return false;
                    }
                    $("#pmobileTextBox").css({

                        "border": "",

                        "background": ""
                    });

                }
                else {
                    alert('Not a valid number');
                  
                    $("#pmobileTextBox").css({

                                "border": "1px solid red",

                                "background": "#FFCECE"
                            });
                    return false;
                  
                }
                
            });

            $("#palternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }

                    $("#palternateTextBox").css({

                        "border": "",

                        "background": ""
                    });

                }
                else {
                    alert('Not a valid number');
                    $("#palternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


                $("#pofficenoTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }

                    $("#pofficenoTextBox").css({

                        "border": "",

                        "background": ""
                    });

                }
                else {
                    alert('Not a valid number');
                    $("#pofficenoTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });
            $("#smobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#smobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#smobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#salternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#salternateTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#salternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


               $("#sofficenoTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^[0-9\s]*$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sofficenoTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sofficenoTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });



            
            
            $("#sp1mobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp1mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp1mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            
            
            
            
           


            $("#sp1alternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }

                    $("#sp1alternateTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp1alternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });



            $("#sp2mobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp2mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp2mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp2alternateTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp2alternateTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp2alternateTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp3mobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp3mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp3mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp3altmobileTextBox").on("blur", function () {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp3altmobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp3altmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });


            $("#sp4mobileTextBox").on("blur", function (e) {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {
                    if (mobNum.length <= 15) {
                        //  alert("valid");

                    } else {
                        alert('Enter valid number ');

                        return false;
                    }
                    $("#sp4mobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                    $("#sp4mobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });



            $("#sp4altmobileTextBox").on("blur", function (e) {
                var mobNum = $(this).val();
                var filter = /^\d*(?:\.\d{1,2})?$/;

                if (filter.test(mobNum)) {

                    if (mobNum.length <= 15) {
                        //  alert("valid");
                      
                       
                    } else {
                        alert('Enter valid number ');
                       

                        return false;
                    }
                    $("#sp4altmobileTextBox").css({

                        "border": "",

                        "background": ""
                    });
                }
                else {
                    alert('Not a valid number');
                   
                    $("#sp4altmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    return false;
                }

            });

        });
        
        
        
    </script>




    <script>
        (function ($) {
            jQuery.fn.timepicker = function () {
                this.each(function () {
                    // get the ID and value of the current element
                    var i = this.id;
                    var v = $(this).val();

                    // the options we need to generate
                    var hrs = new Array('01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12');
                    var mins = new Array('00', '01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30', '31', '32', '33', '34', '35', '36', '37', '38', '39', '40', '41', '42', '43', '44', '45', '46', '47', '48', '49', '50', '51', '52', '53', '54', '55', '56', '57', '58', '59'); 
                    var ap = new Array('am', 'pm');

                    // default to the current time
                    var d = new Date;
                    var h = d.getHours();
                    var m = d.getMinutes();
                    var p = (h >= 12 ? 'pm' : 'am');

                    // adjust hour to 12-hour format
                    if (h > 12) h = h - 12;

                    // round minutes to nearest quarter hour
                    for (mn in mins) {
                        if (m <= parseInt(mins[mn])) {
                            m = parseInt(mins[mn]);
                            break;
                        }
                    }

                    // increment hour if we push minutes to next 00
                    if (m > 45) {
                        m = 0;

                        switch (h) {
                            case (11):
                                h += 1;
                                p = (p == 'am' ? 'pm' : 'am');
                                break;

                            case (12):
                                h = 1;
                                break;

                            default:
                                h += 1;
                                break;
                        }
                    }

                    // override with current values if applicable
                    if (v.length == 7) {
                        h = parseInt(v.substr(0, 2));
                        m = parseInt(v.substr(3, 2));
                        p = v.substr(5);
                    }

                    // build the new DOM objects
                    var output = '';

                    output += '<select id="h_' + i + '" class="h timepicker">';
                    for (hr in hrs) {
                        output += '<option value="' + hrs[hr] + '"';
                        if (parseInt(hrs[hr]) == h) output += ' selected';
                        output += '>' + hrs[hr] + '</option>';
                    }
                    output += '</select>';

                    output += '<select id="m_' + i + '" class="m timepicker">';
                    for (mn in mins) {
                        output += '<option value="' + mins[mn] + '"';
                        if (parseInt(mins[mn]) == m) output += ' selected';
                        output += '>' + mins[mn] + '</option>';
                    }
                    output += '</select>';

                    output += '<select id="p_' + i + '" class="p timepicker">';
                    for (pp in ap) {
                        output += '<option value="' + ap[pp] + '"';
                        if (ap[pp] == p) output += ' selected';
                        output += '>' + ap[pp] + '</option>';
                    }
                    output += '</select>';

                    // hide original input and append new replacement inputs
                    $(this).attr('type', 'hidden').after(output);
                });

                $('select.timepicker').change(function () {
                    var i = this.id.substr(2);
                    var h = $('#h_' + i).val();
                    var m = $('#m_' + i).val();
                    var p = $('#p_' + i).val();
                    var v = h + ':' + m + p;
                    $('#' + i).val(v);
                });

                return this;
            };
        })(jQuery);
        $(document).ready(function () {
            $('#deckcheckintimeTextBox').timepicker();
        });

    </script>

    <script>
        (function ($) {
            jQuery.fn.timepicker = function () {
                this.each(function () {
                    // get the ID and value of the current element
                    var i = this.id;
                    var v = $(this).val();

                    // the options we need to generate
                    var hrs = new Array('00','01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12');
                    var mins = new Array('00','01','02','03','04','05','06','07','08','09','10','11','12','13','14','15','16','17','18','19','20','21','22','23','24','25','26','27','28','29','30','31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46','47','48','49','50','51','52','53','54','55','56','57','58','59');
                    var ap = new Array('am', 'pm');

                    // default to the current time
                    var d = new Date;
                    var h = d.getHours();
                    var m = d.getMinutes();
                    var p = (h >= 12 ? 'pm' : 'am');

                    // adjust hour to 12-hour format
                    if (h > 12) h = h - 12;

                    // round minutes to nearest quarter hour
                    for (mn in mins) {
                        if (m <= parseInt(mins[mn])) {
                            m = parseInt(mins[mn]);
                            break;
                        }
                    }

                    // increment hour if we push minutes to next 00
                    if (m > 45) {
                        m = 0;

                        switch (h) {
                            case (11):
                                h += 1;
                                p = (p == 'am' ? 'pm' : 'am');
                                break;

                            case (12):
                                h = 1;
                                break;

                            default:
                                h += 1;
                                break;
                        }
                    }

                    // override with current values if applicable
                    if (v.length == 7) {
                        h = parseInt(v.substr(0, 2));
                        m = parseInt(v.substr(3, 2));
                        p = v.substr(5);
                    }

                    // build the new DOM objects
                    var output = '';

                    output += '<select id="h_' + i + '" class="h timepicker">';
                    for (hr in hrs) {
                        output += '<option value="' + hrs[hr] + '"';
                        if (parseInt(hrs[hr]) == h) output += ' selected';
                        output += '>' + hrs[hr] + '</option>';
                    }
                    output += '</select>';

                    output += '<select id="m_' + i + '" class="m timepicker">';
                    for (mn in mins) {
                        output += '<option value="' + mins[mn] + '"';
                        if (parseInt(mins[mn]) == m) output += ' selected';
                        output += '>' + mins[mn] + '</option>';
                    }
                    output += '</select>';

                    output += '<select id="p_' + i + '" class="p timepicker">';
                    for (pp in ap) {
                        output += '<option value="' + ap[pp] + '"';
                        if (ap[pp] == p) output += ' selected';
                        output += '>' + ap[pp] + '</option>';
                    }
                    output += '</select>';

                    // hide original input and append new replacement inputs
                    $(this).attr('type', 'hidden').after(output);
                });

                $('select.timepicker').change(function () {
                    var i = this.id.substr(2);
                    var h = $('#h_' + i).val();
                    var m = $('#m_' + i).val();
                    var p = $('#p_' + i).val();
                    var v = h + ':' + m + p;
                    $('#' + i).val(v);
                });

                return this;
            };
        })(jQuery);
        $(document).ready(function () {
            $('#deckcheckouttimeTextBox').timepicker();
        });

    </script>

     <%-- <script>

        $(document).ready(function () {
            $("#tourdatedatepicker").click(function () {
                var arrival = $("#checkindatedatepicker").val();
                var depature = $("#checkoutdatedatepicker").val();
                var arr = arrival.split("-");
                var dep = depature.split("-");
                alert("OK");

               
                $(function () {
                    $("#tourdatedatepicker").datepicker({
                        dateFormat: 'yy-mm-dd',

                        minDate:new Date(arr[0], arr[1] - 1, arr[2]),
                        maxDate:new Date(dep[0], dep[1] - 1, dep[2])
                      
                    });
                });

            });

        });

    </script>--%>
 
   


    
 
</body>

</html>
