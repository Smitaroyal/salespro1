<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="IndiaEdit Profile.aspx.cs" Inherits="_Default" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Edit Profile</title>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
        $(function () {
            $("#tabs").tabs();
        });

        $(function () {
            $("#pdobdatepicker,#sdobdatepicker,#sp1dobdatepicker,#sp2dobdatepicker,#sp3dobdatepicker,#sp4dobdatepicker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0",
                dateFormat: 'dd-mm-yy'


            });

            $("#tourdatedatepicker").datepicker({
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




        function topFunction() {
            //alert('hi');

            //window.location.href = "~/WebSite5/production/Dashboard.aspx";
            window.location = '<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

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

    </script>

    <style type="text/css">
        #panel, #chs2, #chs3, #chs4, #chs5, #panel2, #panel3, #panel4 {
            display: none;
        }

        #TextBox22 {
            vertical-align: top;
        }
        #hidden1{
            display:none;
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

</head>
<body>

    <div id="tabs">
        <button onclick="topFunction();" id="myBtn" title="Go to top">Home</button>
        <ul>
            <li><a href="#tabs-1">Profile</a></li>
            <%--  <li><a href="#tabs-2">Contracts</a></li>
    <li><a href="#tabs-3">Finance Data</a></li>--%>
        </ul>


        <div id="tabs-1">
            <div style="border: thin solid #C0C0C0;">
                <form id="form1" runat="server">

                    <div style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <h3>PROFILE</h3>
                        <hr />
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Label">Profile ID</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="ProfileIDTextBox" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True" ReadOnly="True"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Created Date"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="createddateTextBox" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Label">Created By</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="CreatedByTextBox" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True" ReadOnly="True"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Label">Marketing Program</asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="MarketingPrgmDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server" Font-Names="Times New Roman"></asp:DropDownList></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Label">Venue Country</asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="VenueCountryDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server" OnSelectedIndexChanged="VenueCountryDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="Label">Venue</asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="VenueDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server" OnSelectedIndexChanged="VenueDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Label">Group Venue</asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="GroupVenueDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server" OnSelectedIndexChanged="GroupVenueDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                                 <td><asp:Label ID="Label112" runat="server" Font-Size="Medium" Text="View Point ID" ></asp:Label></td>
                    <td><asp:TextBox ID="ViewPointTextBox" Font-Size="Small" style="width:165px; height:20px" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Font-Size="Medium" Text="Label">Agents</asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="AgentsDropDownList" Font-Size="Small" runat="server" Style="width: 175px; height: 25px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Font-Size="Medium" Text="TO"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="TonameDropDownList" Font-Size="Small" runat="server" Style="width: 175px; height: 25px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:Label ID="Label72" runat="server" Font-Size="Medium" Text="Manager"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="mgrDropDownList" Font-Size="Small" runat="server" Style="width: 175px; height: 25px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList></td>

                            </tr>

                            <tr>
                                <td>
                                    <input id="chs" type="checkbox" onclick="shows();" />
                                    <asp:Label ID="Label10" runat="server" Text="Label">Are you a Member?</asp:Label></td>

                            </tr>
                        </table>
                        <br />
                        <table style="width: 57%;">
                            <tbody id="hidden1">
                                <tr>
                                    <td><asp:Label ID="Label11" runat="server" Font-Size="Medium" Text="Label">Choose Source</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="MemType1DropDownList" Font-Size="Small" Style="width: 155px; height: 25px" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Font-Size="Medium" Text="Label">Member Number</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="Memno1TextBox" runat="server" Font-Size="Small" Style="width: 150px; height: 20px" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label109" runat="server" Font-Size="Medium" Text="Label">Type</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="TypeDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>

                                    <td>
                                        <asp:Label ID="Label12" runat="server" Font-Size="Medium" Text="Label">Choose Member Type</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="MemType2DropDownList" Font-Size="Small" Style="width: 155px; height: 25px" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Font-Size="Medium" Text="Label">Member Number</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="Memno2TextBox" Font-Size="Small" runat="server" Style="width: 150px; height: 20px" Enabled="True"></asp:TextBox></td>
                                </tr>
                            </tbody>

                        </table>
                        <br />
                    </div>

                    <div style="padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <h3>PRIMARY PROFILE</h3>
                        <hr />
                        <br />
                        <table style="width: 100%;">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label79" runat="server" Text="Label">Title</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="primarytitleDropDownList" Font-Size="small" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Label">First Name</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="pfnameTextBox" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Label">Last Name</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="plnameTextBox" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="pdobdatepicker" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="Label">Nationality</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="primarynationalityDropDownList" Style="width: 175px; height: 25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Text="Label">Country</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="PrimaryCountryDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label73" runat="server" Text="Label">Age</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="primaryAge" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" Text="Label">Mobile #</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="primarymobileDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="pmobileTextBox" Font-Size="Small" runat="server" Style="width: 95px; height: 20px" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label22" runat="server" Text="Label">Home #</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="primaryalternateDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="palternateTextBox" Font-Size="Small" Style="width: 95px; height: 20px" runat="server" Enabled="True"></asp:TextBox>

                                    </td>
                                      <td><asp:Label ID="Label113" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                                     <td><asp:DropDownList ID="pofficecodeDropDownList" runat="server" Font-Size="Small" style="width:70px; height:25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="pofficenoTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                                
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                     <td>
                                        <asp:Label ID="Label20" runat="server" Text="Label">Email</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="pemailTextBox" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label77" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                                    <td>
                                        <select multiple="multiple" style="width: 175px; height: 70px" id="primlg" name="primarylang">
                                            <option value="English">English</option>
                                            <option value="Hindi">Hindi</option>
                                            <option value="Konkani">Konkani</option>
                                            <option value="Marathi">Marathi</option>
                                            <option value="French">French</option>
                                            <option value="Portuguese">Portuguese</option>

                                        </select></td>
                                </tr>


                            </tbody>
                        </table>
                        <br />
                        <br />
                    </div>


                    <div style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <h3>SECONDARY PROFILE</h3>
                        <hr />
                        <br />
                        <table style="width: 100%;">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label78" runat="server" Text="Label">Title</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="secondarytitleDropDownList" Font-Size="small" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" Text="Label">First Name</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="sfnameTextBox" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Text="Label">Last Name</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="slnameTextBox" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label25" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="sdobdatepicker" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label26" runat="server" Text="Label">Nationality</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="secondarynationalityDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label27" runat="server" Text="Label">Country</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="SecondaryCountryDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label74" runat="server" Text="Label">Age</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="secondaryAge" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label29" runat="server" Text="Label">Mobile #</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="secondarymobileDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="smobileTextBox" Font-Size="Small" runat="server" Style="width: 95px; height: 20px" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label30" runat="server" Text="Label">Home #</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="secondaryalternateDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="salternateTextBox" Font-Size="Small" Style="width: 95px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label114" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="sofficecodeDropDownList" runat="server" Font-Size="Small" Style="width: 70px; height: 25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="sofficenoTextBox" runat="server" Font-Size="Small" Style="width: 95px; height: 20px" Enabled="True"></asp:TextBox></td>
                                </tr>
                                  
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label28" runat="server" Text="Label">Email</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="semailTextBox" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>

                                    <td>
                                        <asp:Label ID="Label88" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                                    <td>
                                        <select multiple="multiple" style="width: 175px; height: 70px" id="seclang" name="seclang">
                                            <option value="English">English</option>
                                            <option value="Hindi">Hindi</option>
                                            <option value="Konkani">Konkani</option>
                                            <option value="Marathi">Marathi</option>
                                            <option value="French">French</option>
                                            <option value="Portuguese">Portuguese</option>

                                        </select></td>
                                </tr>


                            </tbody>
                        </table>
                        <br />
                        <br />
                    </div>

                    <div style="padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <h3>ADDRESS</h3>
                        <hr />
                        <br />
                        <table style="width: 100%;">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label31" runat="server" Text="Label">Address Line1</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="address1TextBox" Font-Size="Small" runat="server" Enabled="True" Width="250px" Height="20px"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label32" runat="server" Text="Label">Address Line1</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="address2TextBox" Font-Size="Small" runat="server" Enabled="True" Width="250px" Height="20px"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label70" runat="server" Font-Size="Medium" Text="Label">Country</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="AddCountryDropDownList" Font-Size="Small" Style="width: 170px; height: 25px" runat="server"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label33" runat="server" Text="Label">State</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="StateDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label34" runat="server" Text="Label">City</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="cityTextBox" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label39" runat="server" Text="Label">Pincode</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="pincodeTextBox" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                </tr>

                            </tbody>
                        </table>
                        <br />
                        <br />
                    </div>
                    <div style="padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <h3>OTHER DETAILS</h3>
                        <hr />
                        <br />
                        <table style="width: 100%;">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label40" runat="server" Text="Label">Employee Status</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="employmentstatusDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label35" runat="server" Text="Label">Marital Status</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="MaritalStatusDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label41" runat="server" Text="Label">No of Year living together as a couple</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="livingyrsTextBox" Style="width: 170px; height: 20px" Font-Size="Small" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="Label80" runat="server" Font-Size="Medium" Text="Label">Professional/Designation :</asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label81" runat="server" Font-Size="Medium" Text="Label">Primary</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="pdesginationTextBox" Font-Size="Small" Style="width: 170px; height: 25px" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label82" runat="server" Font-Size="Medium" Text="Label">Secondary</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="sdesignationTextBox" Font-Size="Small" Style="width: 170px; height: 25px" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="Label83" runat="server" Font-Size="Medium" Text="Label">Photo Identity:</asp:Label></td>
                                    <td>
                                        <select multiple="multiple" style="width: 175px; height: 70px" id="phid" name="pidentity">
                                            <option value="Membership Card">Membership Card(if member with any club)</option>
                                            <option value="Driving License">Driving License</option>
                                            <option value="Pan Card">PAN Card</option>
                                            <option value="Adhar Card">Adhar Card</option>
                                            <option value="Passport">Passport</option>
                                            <option value="Others">Others</option>
                                        </select></td>

                                    <td>
                                        <asp:Label ID="Label84" runat="server" Font-Size="Medium" Text="Label">Kind Of Card:</asp:Label></td>
                                    <td>
                                        <select multiple="multiple" style="width: 175px; height: 70px" id="card" name="card">
                                            <option value="Titanium">Titanium</option>
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
                        <br />
                        <br />
                    </div>
                    <div style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <input id="chs2" type="checkbox" onclick="shows2();" />
                        <label for="chs2">SUB PROFILE 1</label>
                        <div id="panel" style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                            <hr />
                            <br />
                            <table style="width: 100%;">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label85" runat="server" Text="Label">Title</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile1titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label36" runat="server" Text="Label">First Name</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp1fnameTextBox" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label37" runat="server" Text="Label">Last Name</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp1lnameTextBox" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label38" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp1dobdatepicker" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label42" runat="server" Text="Label">Nationality</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile1nationalityDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label43" runat="server" Text="Label">Country</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="SubProfile1CountryDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label75" runat="server" Text="Label">Age</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="subProfile1Age" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label45" runat="server" Text="Label">Mobile Number</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile1mobileDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1mobileTextBox" Font-Size="Small" Style="width: 95px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label46" runat="server" Text="Label">Alternate Number</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile1alternateDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1alternateTextBox" Font-Size="Small" runat="server" Style="width: 95px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label44" runat="server" Text="Label">Email</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp1emailTextBox" Font-Size="Small" Style="width: 170px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>


                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <br />
                        <br />
                    </div>

                    <div style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <input id="chs3" type="checkbox" onclick="shows3();" />
                        <label for="chs3">SUB PROFILE 2</label>
                        <div id="panel2" style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                            <hr />
                            <br />
                            <table style="width: 100%;">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label86" runat="server" Text="Label">Title</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile2titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label47" runat="server" Text="Label">First Name</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp2fnameTextBox" Font-Size="Small" runat="server" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label48" runat="server" Text="Label">Last Name</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp2lnameTextBox" Font-Size="Small" runat="server" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label49" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp2dobdatepicker" Font-Size="Small" runat="server" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label50" runat="server" Text="Label">Nationality</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile2nationalityDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label51" runat="server" Text="Label">Country</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="SubProfile2CountryDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label76" runat="server" Text="Label">Age</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="subProfile2Age" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>

                                    </tr>

                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label53" runat="server" Text="Label">Mobile Number</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile2mobileDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2mobileTextBox" Font-Size="Small" Style="width: 95px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label54" runat="server" Text="Label">Alternate Number</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile2alternateDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2alternateTextBox" Font-Size="Small" Style="width: 95px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label52" runat="server" Text="Label">Email</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp2emailTextBox" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>

                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <br />
                        <br />
                    </div>
                    <!-- sub profile 3 -->

                    <div style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <input id="chs4" type="checkbox" onclick="shows4();" />
                        <label for="chs4">SUB PROFILE 3</label>
                        <div id="panel3" style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                            <hr />
                            <br />
                            <table style="width: 100%;">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label87" runat="server" Text="Label">Title</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile3titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label89" runat="server" Text="Label">First Name</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp3fnameTextBox" Font-Size="Small" runat="server" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label90" runat="server" Text="Label">Last Name</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp3lnameTextBox" Font-Size="Small" runat="server" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label91" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp3dobdatepicker" Font-Size="Small" runat="server" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label92" runat="server" Text="Label">Nationality</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile3nationalityDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label93" runat="server" Text="Label">Country</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="SubProfile3CountryDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label94" runat="server" Text="Label">Age</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="subProfile3Age" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>

                                    </tr>

                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label95" runat="server" Text="Label">Mobile Number</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile3mobileDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp3mobileTextBox" Font-Size="Small" Style="width: 95px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label96" runat="server" Text="Label">Alternate Number</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile3alternateDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp3alternateTextBox" Font-Size="Small" Style="width: 95px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label97" runat="server" Text="Label">Email</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp3emailTextBox" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>

                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <br />
                        <br />
                    </div>

                    <!-- end -->


                    <!-- sub profile 4-->

                    <div style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <input id="chs5" type="checkbox" onclick="shows5();" />
                        <label for="chs5">SUB PROFILE 4</label>
                        <div id="panel4" style="background-color: #e9e9e9; padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                            <hr />
                            <br />
                            <table style="width: 100%;">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label98" runat="server" Text="Label">Title</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile4titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label99" runat="server" Text="Label">First Name</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp4fnameTextBox" Font-Size="Small" runat="server" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label100" runat="server" Text="Label">Last Name</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp4lnameTextBox" Font-Size="Small" runat="server" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label101" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp4dobdatepicker" Font-Size="Small" runat="server" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label102" runat="server" Text="Label">Nationality</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile4nationalityDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label103" runat="server" Text="Label">Country</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="SubProfile4CountryDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="Label104" runat="server" Text="Label">Age</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="subProfile4Age" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>





                                    </tr>

                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="Label105" runat="server" Text="Label">Mobile Number</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile4mobileDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp4mobileTextBox" Font-Size="Small" Style="width: 95px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label106" runat="server" Text="Label">Alternate Number</asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="subprofile4alternateDropDownList" Font-Size="Small" Style="width: 70px; height: 25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp4alternateTextBox" Font-Size="Small" Style="width: 95px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label107" runat="server" Text="Label">Email</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="sp4emailTextBox" runat="server" Font-Size="Small" Style="width: 170px; height: 20px" Enabled="True"></asp:TextBox></td>





                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <br />
                        <br />
                    </div>


                    <!-- end -->



                    <div style="padding-top: 10px; padding-left: 5px; padding-right: 5px;">
                        <h3>STAY DETAILS</h3>
                        <hr />
                        <br />
                        <table style="width: 100%;">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label55" runat="server" Text="Label">Resort Name</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="hotelTextBox" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label56" runat="server" Text="Label">Resort Room No</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="roomnoTextBox" runat="server" Font-Size="Small" Style="width: 160px; height: 20px" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label57" runat="server" Text="Label">Arrival</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="checkindatedatepicker" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label58" runat="server" Text="Label">Departure</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="checkoutdatedatepicker" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>

                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="Label59" runat="server" Text="Label">Choose Gift Option</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="giftoptionDropDownList" Font-Size="Small" Style="width: 165px; height: 25px" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="Label60" runat="server" Text="Label">Voucher No.</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="vouchernoTextBox" runat="server" Font-Size="Small" Style="width: 160px; height: 20px" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label61" runat="server" Text="Label">Comment if Any</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="commentTextBox" runat="server" Font-Size="Small" Enabled="True" Style="width: 160px; height: 20px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label62" runat="server" Text="Label">Guest Status</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="gueststatusDropDownList" Font-Size="Small" Style="width: 165px; height: 25px" runat="server"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label71" runat="server" Text="Tour Date"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="tourdatedatepicker" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label63" runat="server" Text="Label">Sales Represntative</asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="salesrepDropDownList" Font-Size="Small" Style="width: 165px; height: 25px" runat="server"></asp:DropDownList></td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="Label64" runat="server" Text="Label">Sales Deck Check-In Time</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="deckcheckintimeTextBox" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label65" runat="server" Text="Label">Sales Deck Check-Out Time</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="deckcheckouttimeTextBox" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label66" runat="server" Text="Label">Taxi in Price</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="taxipriceInTextBox" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label67" runat="server" Text="Label">Taxi in Reference</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TaxiRefInTextBox" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label68" runat="server" Text="Label">Taxi out Price</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TaxiPriceOutTextBox" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label69" runat="server" Text="Label">Taxi out Reference</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="TaxiRefOutTextBox" Font-Size="Small" Style="width: 160px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>

                        <table style="width: 64%;">

                            <tr>
                                <td>
                                    <asp:Label ID="Label108" runat="server" Font-Size="Medium" Text="Comments" BorderStyle="None"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="commentsTextBox" runat="server" Style="width: 300px; height: 120px" TextMode="MultiLine"></asp:TextBox></td>

                            </tr>

                        </table>
                        <br />
                        <br />
                        <table style="width: 59%;">
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Registration Card Terms" /></td>


                            </tr>
                        </table>
                        <br />
                    </div>

                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button1" runat="server" Text="Edit Profile" OnClick="Button1_Click" /></center>
                    <br />

                </form>
            </div>

        </div>

        <div id="tabs-2">
        </div>
        <div id="tabs-3">
        </div>

    </div>
    <script>

        $(document).ready(function () {
            //$("#hidden1").hide();
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
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
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
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
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
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
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
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
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
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile3Age').val(age);
            });



        });
    </script>

    <script>
        $(document).ready(function () {
            $("#sp4dobdatepicker").change(function () {
                var date = $("#sp4dobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#subProfile4Age').val(age);
            });



        });
    </script>

    <script>
        $(document).ready(function () {
            $("#VenueCountryDropDownList").change(function () {
                var v = document.getElementById("VenueCountryDropDownList");
                var countryName = v.options[v.selectedIndex].text;
                // alert(countryName)
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/getVenueOnCountry',
                    data: "{'countryName':'" + countryName + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#VenueDropDownList").empty();
                        $("#VenueDropDownList").append("<option disabled selected value>select an option  </option>");

                        $("#GroupVenueDropDownList").empty();
                        //  $("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>");

                        $("#MarketingPrgmDropDownList").empty();
                        // $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>");


                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#VenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong getVenueOnCountry");
                    }



                });
            });


        });


    </script>

    <script>

        $(document).ready(function () {


            $("#VenueDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;
                // alert(countryName)
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/getVenueGroupOnVenue',
                    data: "{'venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#GroupVenueDropDownList").empty();
                        $("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>");



                        $("#MarketingPrgmDropDownList").empty();
                        $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#GroupVenueDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong getVenueGroupOnVenue");
                    }



                });

                //get sales rep name
                var v = document.getElementById("VenueCountryDropDownList");
                var vcountry = v.options[v.selectedIndex].text;

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadSalesRepOnVenue',
                    data: "{'venue':'" + venue + "','country':'" + vcountry + "'}",
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
                        alert("wrong LoadSalesRepOnVenue");
                    }



                });



                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;
                //alert(venue);
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadManagersOnVenue',
                    data: "{'venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                        //   alert(data.d);
                        $("#mgrDropDownList").empty();
                        $("#mgrDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        //alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#mgrDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong LoadManagersOnVenue");
                    }



                });

                return false;



            });


        });


    </script>

    <script>
        $(document).ready(function () {

            var venue = $("#VenueDropDownList option:selected").text();
            var v = document.getElementById("VenueCountryDropDownList");
            var vcountry = v.options[v.selectedIndex].text;

            //alert(venue);
            //alert(vcountry);

            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadSalesRepOnVenue',
                data: "{'venue':'" + venue + "','country':'" + vcountry + "'}",
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
                    alert("wrong LoadSalesRepOnVenue");
                }



            });


        });


    </script>


    <script>
        $(document).ready(function () {

            $("#GroupVenueDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;

                var vg = document.getElementById("GroupVenueDropDownList");
                var venueGroup = vg.options[vg.selectedIndex].text;


                var profileID = $("#ProfileIDTextBox").val();


                if (venueGroup == "Coldline") {
                    //alert("hello");

                    $("#Label72").show();
                    $("#mgrDropDownList").show();
                }
                else {
                    $("#Label72").hide();
                    $("#mgrDropDownList").hide();
                }


                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;

                var vg = document.getElementById("GroupVenueDropDownList");
                var venueGroup = vg.options[vg.selectedIndex].text;
                //alert(venue);
                //alert(venueGroup);

                var profileID = $("#ProfileIDTextBox").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/getMarketingProgram',
                    data: "{'venue':'" + venue + "','venueGroup':'" + venueGroup + "','profileID':'" + profileID + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#MarketingPrgmDropDownList").empty();
                        $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#MarketingPrgmDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                            });
                        });
                    },
                    error: function () {
                        alert("wrong getMarketingProgram");
                    }



                });
                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;

                var vg = document.getElementById("GroupVenueDropDownList");
                var venueGroup = vg.options[vg.selectedIndex].text;

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAgentsOnVenuegrp',
                    data: "{'venue':'" + venue + "','vgrp':'" + venueGroup + "'}",
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
                        alert("wrong LoadAgentsOnVenuegrp");
                    }



                });

                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;

                var vg = document.getElementById("GroupVenueDropDownList");
                var venueGroup = vg.options[vg.selectedIndex].text;

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadTOOnVenueNVGrp',
                    data: "{'venue':'" + venue + "','vgrp':'" + venueGroup + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#TonameDropDownList").empty();
                        $("#TonameDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#TonameDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong LoadTOOnVenueNVGrp");
                    }



                });

                return false;

            });
        });
    </script>


    <script>
        $(document).ready(function () {
            //  alert("hiee");
            var prid = $("#ProfileIDTextBox").val();
            // alert(prid);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/getdata',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#primlg option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

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
                url: 'IndiaEdit Profile.aspx/Secondarylang',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#seclang option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

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
                url: 'IndiaEdit Profile.aspx/PhotoIdentity',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#phid option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

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
                url: 'IndiaEdit Profile.aspx/CardType',
                data: "{'prid':'" + prid + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                            i = 0, size = valArr.length,
                            $options = $('#card option');
                            // alert(valArr);

                            for (i; i < size; i++) {
                                $options.filter('[value="' + valArr[i] + '"]').prop('selected', true);
                            }

                        });
                    });
                },
                error: function () {
                    alert("wrong");
                }



            });
            return false;



        });



    </script>


    <script>
        $(document).ready(function () {
            $("#Button1").click(function (e) {


                var isValid = true;

                if ($.trim($("#MarketingPrgmDropDownList option:selected").text()) == "") {
                    //alert(hiee);
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
                    // alert("hieee");
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                //alert(venueCountry);

                var isValid = true;
                if ($.trim($("#VenueCountryDropDownList option:selected").text()) == "") {
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
                if ($.trim($("#VenueDropDownList option:selected").text()) == "") {
                    isValid = false;
                    alert("Select Venue ");
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
                if ($.trim($("#GroupVenueDropDownList option:selected").text()) == "") {
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
                if ($.trim($("#AgentsDropDownList option:selected").text()) == "") {
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
                if ($.trim($("#TonameDropDownList option:selected").text()) == "") {
                    isValid = false;
                    alert("Select TO Name");
                    $("#TonameDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#TonameDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }




                ////primary profile


                var isValid = true;
                if ($.trim($("#primarytitleDropDownList option:selected").text()) == "") {
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
                if ($.trim($("#plnameTextBox").val()) == "") {
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
                if ($.trim($("#pdobdatepicker ").val()) == "") {
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
                if ($.trim($("#primarynationalityDropDownList option:selected").text()) == "") {
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
                if ($.trim($("#PrimaryCountryDropDownList option:selected").text()) == "") {
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
                if ($.trim($("#primaryAge").val()) == "") {
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
                    //    //$("#TextBox1").val("");
                    //}


                }
                // alert("inside1");
                var isValid = true;
                if ($("#primarymobileDropDownList option:selected").text() == "") {
                    //alert("inside");
                    isValid = false;
                    alert("Select Country Code");
                    $("#primarymobileDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#primarymobileDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert("hiee");
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }




                var isValid = true;
                if ($.trim($("#pmobileTextBox ").val()) == "") {
                    isValid = false;
                    alert("Enter Mobile Number");
                    $("#pmobileTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#pmobileTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#pemailTextBox").val()) == "") {
                    isValid = false;
                    alert("Enter Email");
                    $("#pemailTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#pemailTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }









                ////// Stay Details/////


                var isValid = true;
                if ($.trim($("#hotelTextBox ").val()) == '') {
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





            });

        });


    </script>

    <script>
        $(document).ready(function () {

            //  $("#Label12").hide();
            // $("#MemType2DropDownList").hide();
            // $("#Label16").hide();
            //  $("#Memno2TextBox").hide();

            $("#MemType2DropDownList").hide();
            $("#Label12").hide();
            $("#Label16").hide();
            $("#Memno2TextBox").hide();


            $("#Label15").hide();
            $("#Memno1TextBox").hide();
            $("#Label109").hide();
            $("#TypeDropDownList").hide();

            $("#Label11").hide();
            $("#MemType1DropDownList").hide();

            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadTypes',
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
                    alert("wrong LoadTypes");
                }



            });



          


            $("#MarketingPrgmDropDownList").change(function () {

                var marketingValue = $("#MarketingPrgmDropDownList").val();
                //alert(marketingValue);
                if (marketingValue == "OWNER" || marketingValue == "Owner" || marketingValue == "owner") {

                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").show();
                    $("#Memno1TextBox").show();
                    $("#Label109").hide();
                    $("#TypeDropDownList").hide();


                }
                else {
                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").hide();
                    $("#Memno1TextBox").hide();
                    $("#Label109").show();
                    $("#TypeDropDownList").show();

                }

            });


        });


    </script>

     <script>
        $(document).ready(function(){
        var venue = $("#VenueDropDownList option:selected").text();
          var vgroup = $("#GroupVenueDropDownList option:selected").text();
          //alert(venue);
          //alert(vgroup);

          $.ajax({

              type: 'post',
              contentType: "application/json; charset=utf-8",
              url: 'IndiaEdit Profile.aspx/loadMarketingProgram1',
              data: "{'venue':'" + venue + "','venueGroup':'" + vgroup + "'}",
              async: false,
              success: function (data) {
                  // alert(data.d);
              
                  $("#MarketingPrgmDropDownList").empty();
                  $("#MarketingPrgmDropDownList").append("<option disabled selected value>select an option  </option>");
                  subJson = JSON.parse(data.d);


                  $.each(subJson, function (key, value) {
                      $.each(value, function (index1, value1) {

                          $("#MarketingPrgmDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                      });
                  });
              },
              error: function () {
                 alert("wrong on load marketing program");
              }



          });

          var venue = $("#VenueDropDownList option:selected").text();
          $.ajax({

              type: 'post',
              contentType: "application/json; charset=utf-8",
              url: 'IndiaEdit Profile.aspx/LoadManagersOnVenue',
              data: "{'venue':'" + venue + "'}",
              async: false,
              success: function (data) {
                  //   alert(data.d);
                  $("#mgrDropDownList").empty();
                  $("#mgrDropDownList").append("<option disabled selected value>select an option  </option>")
                  subJson = JSON.parse(data.d);

                  //alert(subJson);
                  $.each(subJson, function (key, value) {
                      $.each(value, function (index1, value1) {

                          $("#mgrDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                      });
                  });
              },
              error: function () {
                  alert("wrong error on load manager");
              }



          });

          var venue = $("#VenueDropDownList option:selected").text();
          var vgroup = $("#GroupVenueDropDownList option:selected").text();
          $.ajax({

              type: 'post',
              contentType: "application/json; charset=utf-8",
              url: 'IndiaEdit Profile.aspx/LoadAgentsOnVenuegrp',
              data: "{'venue':'" + venue + "','vgrp':'" + vgroup + "'}",
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
                  alert("wrong error on load agents");
              }



          });

          var venue = $("#VenueDropDownList option:selected").text();
          var vgroup = $("#GroupVenueDropDownList option:selected").text();
          $.ajax({

              type: 'post',
              contentType: "application/json; charset=utf-8",
              url: 'IndiaEdit Profile.aspx/LoadTOOnVenueNVGrp',
              data: "{'venue':'" + venue + "','vgrp':'" + vgroup + "'}",
              async: false,
              success: function (data) {
                  // alert(data.d);
                  
                  $("#TonameDropDownList").empty();
                  $("#TonameDropDownList").append("<option disabled selected value>select an option  </option>")
                  subJson = JSON.parse(data.d);

                  // alert(subJson);
                  $.each(subJson, function (key, value) {
                      $.each(value, function (index1, value1) {

                          $("#TonameDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                      });
                  });
              },
              error: function () {
                  alert("wrong error on load Toname");
              }

 

          });
          return false;
          });


          </script>

    <script>
        $(document).ready(function () {


            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/loadProfile',
                data: "{}",
                async: false,
                success: function (data) {
                    //   alert(data.d);

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            //alert(value1[0]+" "+value1[1]+" "+value1[2]+" "+value1[3]);
                            
                            
                            
                            $("#MarketingPrgmDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            $("#AgentsDropDownList option[value='" + value1[1] + "']").prop('selected', true);
                            $("#TonameDropDownList option[value='" + value1[2] + "']").prop('selected', true);
                            $("#mgrDropDownList option[value='" + value1[3] + "']").prop('selected', true);

                        });
                    });
                },
                error: function () {
                    alert("wrong load profile");
                }



            });
            return false;
            // end//

        });

    </script>



    <script>
        $(document).ready(function () {


            //  loading salutations for primary,secondary sub profile 1,2,  3 and 4
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadSalutations',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);


                    $("#primarytitleDropDownList").empty();
                    $("#primarytitleDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#secondarytitleDropDownList").empty();
                    $("#secondarytitleDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#subprofile1titleDropDownList").empty();
                    $("#subprofile1titleDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#subprofile2titleDropDownList").empty();
                    $("#subprofile2titleDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#subprofile3titleDropDownList").empty();
                    $("#subprofile3titleDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#subprofile4titleDropDownList").empty();
                    $("#subprofile4titleDropDownList").append("<option disabled selected value>select an option  </option>");
                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            $("#primarytitleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#secondarytitleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#subprofile1titleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#subprofile2titleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#subprofile3titleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#subprofile4titleDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                        });
                    });
                },
                error: function () {
                    alert("wrong  loading salutations for primary,secondary sub profile 1,2,  3 and 4");
                }



            });
            /// end ///


            //loading nationality for primary,secondary,subprofile 1, 2, 3 and 4

            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadNationality',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);


                    $("#primarynationalityDropDownList").empty();
                    $("#primarynationalityDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#secondarynationalityDropDownList").empty();
                    $("#secondarynationalityDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#subprofile1nationalityDropDownList").empty();
                    $("#subprofile1nationalityDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#subprofile2nationalityDropDownList").empty();
                    $("#subprofile2nationalityDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#subprofile3nationalityDropDownList").empty();
                    $("#subprofile3nationalityDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#subprofile4nationalityDropDownList").empty();
                    $("#subprofile4nationalityDropDownList").append("<option disabled selected value>select an option  </option>");
                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            $("#primarynationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#secondarynationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#subprofile1nationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#subprofile2nationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#subprofile3nationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#subprofile4nationalityDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                        });
                    });
                },
                error: function () {
                    alert("wrong loading nationality for primary,secondary,subprofile 1, 2, 3 and 4");
                }



            });
            // end ///


            // load country for primary,secondary sub profile 1,2 , 3 and 4

            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadCountry',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);



                    $("#PrimaryCountryDropDownList").empty();
                    $("#PrimaryCountryDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#SecondaryCountryDropDownList").empty();
                    $("#SecondaryCountryDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#SubProfile1CountryDropDownList").empty();
                    $("#SubProfile1CountryDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#SubProfile2CountryDropDownList").empty();
                    $("#SubProfile2CountryDropDownList").append("<option disabled selected value>select an option  </option>");


                    $("#SubProfile3CountryDropDownList").empty();
                    $("#SubProfile3CountryDropDownList").append("<option disabled selected value>select an option  </option>");

                    $("#SubProfile4CountryDropDownList").empty();
                    $("#SubProfile4CountryDropDownList").append("<option disabled selected value>select an option  </option>");
                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            $("#PrimaryCountryDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#SecondaryCountryDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#SubProfile1CountryDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#SubProfile2CountryDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#SubProfile3CountryDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            $("#SubProfile4CountryDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                        });
                    });
                },
                error: function () {
                    alert("wrong  load country for primary,secondary sub profile 1,2 , 3 and 4");
                }



            });




            return false;

            // end//

        });



    </script>

    <script>
        $(document).ready(function () {

            // loading country code primary for primary as per country//
            $("#PrimaryCountryDropDownList").change(function () {
                var country = $("#PrimaryCountryDropDownList").val();
                //  alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#primarymobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loading country code primary for primary as per country");
                    }





                });

                // end//


                // loding all country code alternative for primary as per country//


                var country = $("#PrimaryCountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
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
                        alert("wrong loding all country code alternative for primary as per country");
                    }



                });
               
                //end//
                //loding all country code office for primary as per country//
                var country = $("#PrimaryCountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
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
                        alert("wrong loding all country code office for primary as per country");
                    }



                });
                return false;
              //end//


            });

        });
    </script>




    <script>
        $(document).ready(function () {

            // loading country code primary for secondary as per country//
            $("#SecondaryCountryDropDownList").change(function () {
                var country = $("#SecondaryCountryDropDownList").val();
                //  alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#secondarymobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loading country code primary for secondary as per country");
                    }




                });

                // end//


                // loding all country code alternative for secondary as per country//


                var country = $("#SecondaryCountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
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
                        alert("wrong loding all country code alternative for secondary as per country");
                    }



                });
             

                //end//

                // loding all country code office for secondary as per country//


                var country = $("#SecondaryCountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
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
                        alert("wrong loding all country code office for secondary as per country");
                    }



                });
                return false;

                //end//


            });



        });


    </script>



    <script>
        $(document).ready(function () {

            // loding country code primary for sub profile 1 as per country//
            $("#SubProfile1CountryDropDownList").change(function () {
                var country = $("#SubProfile1CountryDropDownList").val();
                //  alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#subprofile1mobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile1mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 1 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 1 as per country//


                var country = $("#SubProfile1CountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#subprofile1alternateDropDownList").empty();
                        $("#subprofile1alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile1alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 1 as per country");
                    }



                });
                return false;

                //end//


            });



        });


    </script>




    <script>
        $(document).ready(function () {

            // loding country code primary for sub profile 2 as per country//
            $("#SubProfile2CountryDropDownList").change(function () {
                var country = $("#SubProfile2CountryDropDownList").val();
                //  alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#subprofile2mobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile2mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 2 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 2 as per country//


                var country = $("#SubProfile2CountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#subprofile2alternateDropDownList").empty();
                        $("#subprofile2alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile2alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 2 as per country");
                    }



                });
                return false;

                //end//


            });



        });


    </script>

    <script>
        $(document).ready(function () {

            // loding country code primary for sub profile 3 as per country//
            $("#SubProfile3CountryDropDownList").change(function () {
                var country = $("#SubProfile3CountryDropDownList").val();
                //  alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#subprofile3mobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile3mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 3 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 3 as per country//


                var country = $("#SubProfile3CountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#subprofile3alternateDropDownList").empty();
                        $("#subprofile3alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 3 as per country/");
                    }




                });
                //end//
                return false;

            });
        });


    </script>


    <script>
        $(document).ready(function () {

            // loading country code primary for sub profile 4 on country
            $("#SubProfile4CountryDropDownList").change(function () {
                var country = $("#SubProfile4CountryDropDownList").val();
                //  alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#subprofile4mobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile4mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loading country code primary for sub profile 4 on country");
                    }



                });

                // end//

                // loading all country code alternate for sub profile 4 on country
                var country = $("#SubProfile4CountryDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#subprofile4alternateDropDownList").empty();
                        $("#subprofile4alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile4alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loading all country code alternate for sub profile 4 on country ");
                    }



                });
                return false;
                // end//

            });

        });
    </script>


    <script>
        $(document).ready(function () {
            // loading primary data
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadPrimaryData',
                data: "{}",
                async: false,
                success: function (data) {
                    //  alert(data.d);

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#primarytitleDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            $("#pfnameTextBox").val(value1[1]);
                            $("#plnameTextBox").val(value1[2]);
                            $("#pdobdatepicker").val(value1[3]);
                            $("#primarynationalityDropDownList option[value='" + value1[4] + "']").prop('selected', true);
                            $("#PrimaryCountryDropDownList option[value='" + value1[5] + "']").prop('selected', true);
                            $("#primaryAge").val(value1[6]);

                        });
                    });
                },
                error: function () {
                    alert("wrong loading primary data");
                }



            });
            //end//


            // loading Secondary data
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadSecondaryData',
                data: "{}",
                async: false,
                success: function (data) {
                    //   alert(data.d);

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#secondarytitleDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            $("#sfnameTextBox").val(value1[1]);
                            $("#slnameTextBox").val(value1[2]);
                            $("#sdobdatepicker").val(value1[3]);
                            $("#secondarynationalityDropDownList option[value='" + value1[4] + "']").prop('selected', true);
                            $("#SecondaryCountryDropDownList option[value='" + value1[5] + "']").prop('selected', true);
                            $("#secondaryAge").val(value1[6]);

                        });
                    });
                },
                error: function () {
                    alert("wrong  loading Secondary data");
                }



            });
            //end//



            // loading sub profile 1 data
            $.ajax({

                type: 'post',
 		dataType: 'json',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadSubProfile1Data',
                data: "{}",
                async: false,
                success: function (data) {
                    //   alert(data.d);
  if (data == "") {

                    } else {

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#subprofile1titleDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            $("#sp1fnameTextBox").val(value1[1]);
                            $("#sp1lnameTextBox").val(value1[2]);
                            $("#sp1dobdatepicker").val(value1[3]);
                            $("#subprofile1nationalityDropDownList option[value='" + value1[4] + "']").prop('selected', true);
                            $("#SubProfile1CountryDropDownList option[value='" + value1[5] + "']").prop('selected', true);
                            $("#subProfile1Age").val(value1[6]);

                        });
                    });
}
                },
                error: function () {
                    alert("wrong loading sub profile 1 data");
                }



            });
            //end//



            // loading sub profile 2 data
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadSubProfile2Data',
                data: "{}",
                async: false,
                success: function (data) {
                    //   alert(data.d);

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#subprofile2titleDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            $("#sp2fnameTextBox").val(value1[1]);
                            $("#sp2lnameTextBox").val(value1[2]);
                            $("#sp2dobdatepicker").val(value1[3]);
                            $("#subprofile2nationalityDropDownList option[value='" + value1[4] + "']").prop('selected', true);
                            $("#SubProfile2CountryDropDownList option[value='" + value1[5] + "']").prop('selected', true);
                            $("#subProfile2Age").val(value1[6]);

                        });
                    });
                },
                error: function () {
                    alert("wrong loading sub profile 2 data");
                }



            });
            //end//
            // loading sub profile 3 data
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadSubProfile3Data',
                data: "{}",
                async: false,
                success: function (data) {
                    //   alert(data.d);

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#subprofile3titleDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            $("#sp3fnameTextBox").val(value1[1]);
                            $("#sp3lnameTextBox").val(value1[2]);
                            $("#sp3dobdatepicker").val(value1[3]);
                            $("#subprofile3nationalityDropDownList option[value='" + value1[4] + "']").prop('selected', true);
                            $("#SubProfile3CountryDropDownList option[value='" + value1[5] + "']").prop('selected', true);
                            $("#subProfile3Age").val(value1[6]);

                        });
                    });
                },
                error: function () {
                    alert("wrong loading sub profile 3 data");
                }



            });
            //end//

            // loading sub profile 4 data

            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadSubProfile4Data',
                data: "{}",
                async: false,
                success: function (data) {
                    //   alert(data.d);

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#subprofile4titleDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            $("#sp4fnameTextBox").val(value1[1]);
                            $("#sp4lnameTextBox").val(value1[2]);
                            $("#sp4dobdatepicker").val(value1[3]);
                            $("#subprofile4nationalityDropDownList option[value='" + value1[4] + "']").prop('selected', true);
                            $("#SubProfile4CountryDropDownList option[value='" + value1[5] + "']").prop('selected', true);
                            $("#subProfile4Age").val(value1[6]);

                        });
                    });
                },
                error: function () {
                    alert("wrong loading sub profile 4 data");
                }



            });
            //end//

            return false;



        });


    </script>

    <script>

        $(document).ready(function () {

            // on load Primary country code primary on country
            var country = $("#PrimaryCountryDropDownList option:selected").val();
            //alert(country);
            if (country == "") {
                var country = $("#PrimaryCountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCodePri',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);



                        $("#primarymobileDropDownList").empty();
                        $("#primarymobileDropDownList").append("<option disabled selected value>select an option </option>");
                        //$("#subprofile3alternateDropDownList").empty();
                        //$("#subprofile3alternateDropDownList").append("<option disabled selected value>select an option </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                //$("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load Primary country code primary on country");
                    }



                });

                //end//

            } else {
                var country = $("#PrimaryCountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCodePri',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);



                        $("#primarymobileDropDownList").empty();
                        $("#primarymobileDropDownList").append("<option disabled selected value>select an option </option>");
                        //$("#subprofile3alternateDropDownList").empty();
                        //$("#subprofile3alternateDropDownList").append("<option disabled selected value>select an option </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#primarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                //$("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load Primary country code primary on country");
                    }



                });

                //end//

            }
           

            // on load primary all country code primary on country alternative

            var country = $("#PrimaryCountryDropDownList option:selected").val();
            //alert(country);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAllCountryCodePri',
                data: "{'country':'" + country + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);


                    $("#primaryalternateDropDownList").empty();
                    $("#primaryalternateDropDownList").append("<option disabled selected value>select an option </option>");

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#primaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                        });
                    });
                },
                error: function () {
                    alert("wrong on load primary all country code alternate on country");
                }



            });

            //end//



            // on load primary all country code primary on country office

            var country = $("#PrimaryCountryDropDownList option:selected").val();
            //alert(country);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAllCountryCodePri',
                data: "{'country':'" + country + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);


                    $("#pofficecodeDropDownList").empty();
                    $("#pofficecodeDropDownList").append("<option disabled selected value>select an option</option>");

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#pofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                        });
                    });
                },
                error: function () {
                    alert("wrong on load primary all country code office on country");
                }



            });

            //end//



            // on load secondary country code secondary on country
            var country = $("#SecondaryCountryDropDownList option:selected").val();
            //  alert(country);
            if (country == "") {
                var country = $("#SecondaryCountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSec',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);



                        $("#secondarymobileDropDownList").empty();
                        $("#secondarymobileDropDownList").append("<option disabled selected value>select an option </option>");
                        //$("#subprofile3alternateDropDownList").empty();
                        //$("#subprofile3alternateDropDownList").append("<option disabled selected value>select an option </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                //$("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong  on load secondary country code primary on country");
                    }



                });

                //end//

            } else {
                var country = $("#SecondaryCountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCodeSec',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);



                        $("#secondarymobileDropDownList").empty();
                        $("#secondarymobileDropDownList").append("<option disabled selected value>select an option </option>");
                        //$("#subprofile3alternateDropDownList").empty();
                        //$("#subprofile3alternateDropDownList").append("<option disabled selected value>select an option </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#secondarymobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                //$("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong  on load secondary country code primary on country");
                    }



                });

                //end//

            }



            // on load secondary all country code alternate on country

            var country = $("#SecondaryCountryDropDownList option:selected").val();
            //alert(country);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSec',
                data: "{'country':'" + country + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);


                    $("#secondaryalternateDropDownList").empty();
                    $("#secondaryalternateDropDownList").append("<option disabled selected value>select an option </option>");

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#secondaryalternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                        });
                    });
                },
                error: function () {
                    alert("wrong on load secondary all country code alternate on country");
                }



            });

            //end//


            // on load secondary all country code office on country

            var country = $("#SecondaryCountryDropDownList option:selected").val();
            //alert(country);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSec',
                data: "{'country':'" + country + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);


                    $("#sofficecodeDropDownList").empty();
                    $("#sofficecodeDropDownList").append("<option disabled selected value>select an option </option>");

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#sofficecodeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                        });
                    });
                },
                error: function () {
                    alert("wrong on load secondary all country code office on country");
                }



            });

            //end//



            // on load sub profile 1 country code primary on country
            var country = $("#SubProfile1CountryDropDownList option:selected").val();
            //  alert(country);
            if (country == "") {
                var country = $("#SubProfile1CountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSub1',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);


                        $("#subprofile1mobileDropDownList").empty();
                        $("#subprofile1mobileDropDownList").append("<option disabled selected value>select an option </option>");
                        //$("#subprofile3alternateDropDownList").empty();
                        //$("#subprofile3alternateDropDownList").append("<option disabled selected value>select an option </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile1mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                //$("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load sub profile 1 country code primary on country");
                    }



                });

                //end//
            } else {
                var country = $("#SubProfile1CountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCodeSub1',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);


                        $("#subprofile1mobileDropDownList").empty();
                        $("#subprofile1mobileDropDownList").append("<option disabled selected value>select an option </option>");
                        //$("#subprofile3alternateDropDownList").empty();
                        //$("#subprofile3alternateDropDownList").append("<option disabled selected value>select an option </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile1mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                //$("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load sub profile 1 country code primary on country");
                    }



                });

                //end//


            }



            // on load sub profile 1 all country code alternate on country

            var country = $("#SubProfile1CountryDropDownList option:selected").val();
            //alert(country);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSub1',
                data: "{'country':'" + country + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);


                    $("#subprofile1alternateDropDownList").empty();
                    $("#subprofile1alternateDropDownList").append("<option disabled selected value>select an option </option>");

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#subprofile1alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                        });
                    });
                },
                error: function () {
                    alert("wrong on load sub profile 1 all country code alternate on country");
                }



            });

            //end//




            // on load sub profile 2 country code primary on country
            var country = $("#SubProfile2CountryDropDownList option:selected").val();
            //  alert(country);
            if(country==""){
                var country = $("#SubProfile2CountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSub2',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);


                        $("#subprofile2mobileDropDownList").empty();
                        $("#subprofile2mobileDropDownList").append("<option disabled selected value>select an option </option>");

                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile2mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load sub profile 2 country code primary on country");
                    }



                });

                //end//
            }else{
                var country = $("#SubProfile2CountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCodeSub2',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);


                        $("#subprofile2mobileDropDownList").empty();
                        $("#subprofile2mobileDropDownList").append("<option disabled selected value>select an option </option>");

                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile2mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load sub profile 2 country code primary on country");
                    }



                });

                //end//
        }


            // on load sub profile 2  all country code alternate on country

            var country = $("#SubProfile2CountryDropDownList option:selected").val();
            //alert(country);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSub2',
                data: "{'country':'" + country + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);


                    $("#subprofile2alternateDropDownList").empty();
                    $("#subprofile2alternateDropDownList").append("<option disabled selected value>select an option </option>");

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#subprofile2alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                        });
                    });
                },
                error: function () {
                    alert("wrong on load sub profile 2  all country code alternate on country");
                }



            });

            //end//




            // on load sub profile 3 country code primary on country
            var country = $("#SubProfile3CountryDropDownList option:selected").val();
            //  alert(country);
            if (country == "") {
                var country = $("#SubProfile3CountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSub3',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);


                        $("#subprofile3mobileDropDownList").empty();
                        $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option </option>");

                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile3mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load sub profile 3 country code primary on country");
                    }



                });

                //end//

            } else {
                var country = $("#SubProfile3CountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCodeSub3',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);


                        $("#subprofile3mobileDropDownList").empty();
                        $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option </option>");

                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile3mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load sub profile 3 country code primary on country");
                    }



                });

                //end//


            }

           
            // on load sub profile 3 all country code alternate on country

            var country = $("#SubProfile3CountryDropDownList option:selected").val();
            //alert(country);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSub3',
                data: "{'country':'" + country + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);


                    $("#subprofile3alternateDropDownList").empty();
                    $("#subprofile3alternateDropDownList").append("<option disabled selected value>select an option </option>");

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                        });
                    });
                },
                error: function () {
                    alert("wrong on load sub profile 3 all country code alternate on country");
                }



            });

            //end//


            // on load sub profile 4 country code primary on country
            var country = $("#SubProfile4CountryDropDownList option:selected").val();
            // alert(country);
            if (country == "") {
                var country = $("#SubProfile4CountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSub4',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);


                        $("#subprofile4mobileDropDownList").empty();
                        $("#subprofile4mobileDropDownList").append("<option disabled selected value>select an option </option>");

                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile4mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                //$("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load sub profile 4 country code primary on country");
                    }



                });

                //end//

            } else {
                var country = $("#SubProfile4CountryDropDownList option:selected").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadCountryCodeSub4',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);


                        $("#subprofile4mobileDropDownList").empty();
                        $("#subprofile4mobileDropDownList").append("<option disabled selected value>select an option </option>");

                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#subprofile4mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                                //$("#subprofile3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                            });
                        });
                    },
                    error: function () {
                        alert("wrong on load sub profile 4 country code primary on country");
                    }



                });

                //end//




            }

            

            // on load sub profile 4 all country code alternate on country

            var country = $("#SubProfile4CountryDropDownList option:selected").val();
            //alert(country);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAllCountryCodeSub4',
                data: "{'country':'" + country + "'}",
                async: false,
                success: function (data) {
                    //alert(data.d);


                    $("#subprofile4alternateDropDownList").empty();
                    $("#subprofile4alternateDropDownList").append("<option disabled selected value>select an option </option>");

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#subprofile4alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                        });
                    });
                },
                error: function () {
                    alert("wrong on load sub profile 4 all country code alternate on country");
                }



            });

            //end//




            // loading phone data for sub profile 1, 2, 3 and 4

            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadSubProfile3n4PhoneData',
                data: "{}",
                async: false,
                success: function (data) {
                    //alert(data.d);

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {


                            $("#primarymobileDropDownList option[value='" + value1[16] + "']").prop('selected', true);
                            $("#pmobileTextBox").val(value1[17]);
                            $("#primaryalternateDropDownList option[value='" + value1[18] + "']").prop('selected', true);
                            $("#palternateTextBox").val(value1[19]);

                            $("#secondarymobileDropDownList option[value='" + value1[20] + "']").prop('selected', true);
                            $("#smobileTextBox").val(value1[21]);
                            $("#secondaryalternateDropDownList option[value='" + value1[22] + "']").prop('selected', true);
                            $("#salternateTextBox").val(value1[23]);

                            $("#subprofile1mobileDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            $("#sp1mobileTextBox").val(value1[1]);
                            $("#subprofile1alternateDropDownList option[value='" + value1[2] + "']").prop('selected', true);
                            $("#sp1alternateTextBox").val(value1[3]);

                            $("#subprofile2mobileDropDownList option[value='" + value1[4] + "']").prop('selected', true);
                            $("#sp2mobileTextBox").val(value1[5]);
                            $("#subprofile2alternateDropDownList option[value='" + value1[6] + "']").prop('selected', true);
                            $("#sp2alternateTextBox").val(value1[7]);

                            $("#subprofile3mobileDropDownList option[value='" + value1[8] + "']").prop('selected', true);
                            $("#sp3mobileTextBox").val(value1[9]);
                            $("#subprofile3alternateDropDownList option[value='" + value1[10] + "']").prop('selected', true);
                            $("#sp3alternateTextBox").val(value1[11]);

                            $("#subprofile4mobileDropDownList option[value='" + value1[12] + "']").prop('selected', true);
                            $("#sp4mobileTextBox").val(value1[13]);
                            $("#subprofile4alternateDropDownList option[value='" + value1[14] + "']").prop('selected', true);
                            $("#sp4alternateTextBox").val(value1[15]);

                            $("#pofficecodeDropDownList option[value='" + value1[24] + "']").prop('selected', true);
                            $("#pofficenoTextBox").val(value1[25]);
                            $("#sofficecodeDropDownList option[value='" + value1[26] + "']").prop('selected', true);
                            $("#sofficenoTextBox").val(value1[27]);

                        });
                    });
                },
                error: function () {
                    alert("wrong loading phone data for sub profile 1, 2, 3 and 4");
                }



            });
            return false;


            // end//


        });


    </script>




    <script>
        $(document).ready(function () {
            // loading email for primary ,secondary sub profile 1,2, 3 and 4
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadEmail',
                data: "{}",
                async: false,
                success: function (data) {
                    //   alert(data.d);

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            //alert(value1[0]+" "+value1[1]+" "+value1[2]+" "+value1[3]);

                            $("#pemailTextBox").val(value1[0]);
                            $("#semailTextBox").val(value1[1]);

                            $("#sp1emailTextBox").val(value1[2]);

                            $("#sp2emailTextBox").val(value1[3]);

                            $("#sp3emailTextBox").val(value1[4]);

                            $("#sp4emailTextBox").val(value1[5]);

                        });
                    });
                },
                error: function () {
                    alert("wrong load email sub profile 1,2, 3 and 4");
                }



            });
            return false;
            // end//

        });

    </script>


    <script>

        $(document).ready(function () {
            //loading country for adresss
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadCountry',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);


                    $("#AddCountryDropDownList").empty();
                    $("#AddCountryDropDownList").append("<option disabled selected value>select an option  </option>");
                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            $("#AddCountryDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                        });
                    });
                },
                error: function () {
                    alert("wrong load country for address");
                }



            });


            //end//

            return false;



        });
    </script>


    <script>

        $(document).ready(function () {
            // loading states on country////
            $("#AddCountryDropDownList").change(function () {
                var country = $("#AddCountryDropDownList").val();
                //   alert(country);

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadStates',
                    data: "{'country':'" + country + "'}",
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
                        alert("wrong load states");
                    }

                });
                return false;

            });
            //end///
        });
    </script>
    <script>
        $(document).ready(function () {
            // loading address data
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAddress',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);

                    
                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            
                            
                            
                            $("#address1TextBox").val(value1[0]);
                            $("#address2TextBox").val(value1[1]);
                         
                           // $("#StateDropDownList option[value='" + value1[2] + "']").prop('selected', true);
                            $("#cityTextBox").val(value1[3]);
                            $("#pincodeTextBox").val(value1[4]);
                            $("#AddCountryDropDownList option[value='" + value1[5] + "']").prop('selected', true);
                            

                        });
                    });
                },
                error: function () {
                    alert("wrong  load address");
                }



            });

        });


    </script>


    <script>
        $(document).ready(function () {
            var country = $("#AddCountryDropDownList option:selected").val();

            if (country == "") {
                // on load states on country 
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadStates1',
                    data: "{'country':'" + country + "'}",
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
                        alert("wrong load states");
                    }

                });
                //end//

            } else {
                // on load states on country 
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/LoadStates',
                    data: "{'country':'" + country + "'}",
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
                        alert("wrong load states");
                    }

                });
                //end//
            }

            

            // loading state//
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadAddress',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);


                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                             $("#StateDropDownList option[value='" + value1[2] + "']").prop('selected', true);
                           
                        });
                    });
                },
                error: function () {
                    alert("wrong load Address");
                }



            });
            return false;
            // end//

        });


    </script>

    <script>
        $(document).ready(function () {
            // loading employment status//
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/loadEmployment',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);
                    $("#employmentstatusDropDownList").empty();
                    $("#employmentstatusDropDownList").append("<option disabled selected value>select an option  </option>");
                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            $("#employmentstatusDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                        });
                    });
                },
                error: function () {
                    alert("wrong loading employment status");
                }



            });

            // end//

            // loading martial status//
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/loadMartial',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);
                    $("#MaritalStatusDropDownList").empty();
                    $("#MaritalStatusDropDownList").append("<option disabled selected value>select an option  </option>");
                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {
                            
                            $("#MaritalStatusDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                        });
                    });
                },
                error: function () {
                    alert("wrong loading martial status");
                }



            });
            return false;
            // end//



        })


    </script>

    <script>

        $(document).ready(function () {

            $.ajax({
                // loading other details
                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadOtherDetails',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);


                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#employmentstatusDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            $("#MaritalStatusDropDownList option[value='" + value1[1] + "']").prop('selected', true);
                            $("#livingyrsTextBox").val(value1[2]);
                            $("#pdesginationTextBox").val(value1[5]);
                            $("#sdesignationTextBox").val(value1[6]);
                            
                            
                        });
                    });
                },
                error: function () {
                    alert("wrong   loading other details");
                }



            });
            // end//

            // loading guest status
            $.ajax({
               
                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadGuest',
                data: "{}",
                async: false,
                success: function (data) {
                    // alert(data.d);
                    $("#gueststatusDropDownList").empty();
                    $("#gueststatusDropDownList").append("<option disabled selected value>select an option  </option>");

                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                         
                            $("#gueststatusDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");

                        });
                    });
                },
                error: function () {
                    alert("wrong  loading guest status");
                }



            });
            // end//



            $.ajax({
                //loading stay details
                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'IndiaEdit Profile.aspx/LoadStayDetails',
                data: "{}",
                async: false,
                success: function (data) {
                  //  alert(data.d);
                  
                    subJson = JSON.parse(data.d);

                    // alert(subJson);
                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {

                            $("#hotelTextBox").val(value1[0]);
                            $("#roomnoTextBox").val(value1[1]);
                            $("#checkindatedatepicker").val(value1[2]);
                            $("#checkoutdatedatepicker").val(value1[3]);
                            $("#salesrepDropDownList option[value='" + value1[4] + "']").prop('selected', true);
                            $("#gueststatusDropDownList option[value='" + value1[5] + "']").prop('selected', true);
                            $("#tourdatedatepicker").val(value1[6]);
                            $("#deckcheckintimeTextBox").val(value1[7]);
                            $("#deckcheckouttimeTextBox").val(value1[8]);
                            $("#taxipriceInTextBox").val(value1[9]);
                            $("#TaxiRefInTextBox").val(value1[10]);
                            $("#TaxiPriceOutTextBox").val(value1[11]);
                            $("#TaxiRefOutTextBox").val(value1[12]);
                            $("#commentsTextBox").val(value1[13]);
                            
                        });
                    });
                },
                error: function () {
                    alert("wrong  loading stay details");
                }



            });
            // end//
            return false
          


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
        $(document).ready(function () {

// hide show manager based on venue group
            var value = $("#GroupVenueDropDownList option:selected").text();
            // alert(value);
            if (value == "Coldline") {

                $("#Label72").show();
                $("#mgrDropDownList").show();
            }
            else {
                $("#Label72").hide();
                $("#mgrDropDownList").hide();
            }
            //end//




            //  MarketingPrgmDropDownList
            var marketingValue = $("#MarketingPrgmDropDownList option:selected").val();
            //alert(marketingValue);
            if (marketingValue == "OWNER" || marketingValue == "Owner" || marketingValue == "owner") {

                $("#Label11").show();
                $("#MemType1DropDownList").show();
                $("#Label15").show();
                $("#Memno1TextBox").show();
                $("#Label109").hide();
                $("#TypeDropDownList").hide();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/Loadtype',
                    data: "{}",
                    async: false,
                    success: function (data) {
                        //   alert(data.d);

                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#Memno1TextBox").val(value1[0]);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

            }
            else {
                $("#Label11").show();
                $("#MemType1DropDownList").show();
                $("#Label15").hide();
                $("#Memno1TextBox").hide();
                $("#Label109").show();
                $("#TypeDropDownList").show();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'IndiaEdit Profile.aspx/Loadtype',
                    data: "{}",
                    async: false,
                    success: function (data) {

                        //alert("hello"+data.d);

                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#TypeDropDownList option[value='" + value1[0] + "']").prop('selected', true);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

            }


        });


    </script>

   

    <script>
    $(document).ready(function(){
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'IndiaEdit Profile.aspx/loadRegTerms',
            data: "{}",
            async: false,
            success: function (data) {

                //alert("hello"+data.d);

                subJson = JSON.parse(data.d);


                $.each(subJson, function (key, value) {
                    $.each(value, function (index1, value1) {
                        if (value1[0] == "Y") {
                            $('#CheckBox1').prop('checked', true);
                        } else {
                            $('#CheckBox1').prop('checked', false);
                        }
                      
                    });
                });
            },
            error: function () {
                alert("wrong");
            }



        });


   });
   </script>







</body>

</html>
