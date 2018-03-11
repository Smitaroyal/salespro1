<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit_Contract.aspx.cs" Inherits="Contractsite_Edit_Contract" EnableEventValidation="false" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Contracts</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">

  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
       <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
       <script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
  <script>
  $( function () {
      $("#tabs").tabs({ disabled: [1, 2, 3, 4] });
      $("#btn").on('click', function () {
          //contracttype();
         // displaycrownfina();
          $("#tabs").tabs({ disabled: [2, 3, 4] });
      $("#tabs").tabs("option", "active", 1);
      });
      $("#Btn2").on('click', function () {
          if (!val2()) return false;
          $("#tabs").tabs({ disabled: [3, 4] });
          $("#tabs").tabs("option", "active", 2);
          //addvalue1();
          //addvalue2();
          return false;
      });
      $("#Button2").on('click', function () {
          //if (!val3()) return false;
          $("#tabs").tabs({ disabled: [4] });
          $("#tabs").tabs("option", "active", 3);
          return false;
      });

      $("#myBtnNext").click(function () {
          //alert('hi');
          var selected = $("#tabs").tabs("option", "active");
          

          if (selected == '0') {
              document.getElementById('myBtnBack').style.display = 'block';
              document.getElementById('myBtnNext').style.display = 'block';
              document.getElementById('btn').click();
          }
          else if (selected == '1') {
              document.getElementById('myBtnBack').style.display = 'block';
              document.getElementById('myBtnNext').style.display = 'block';
              document.getElementById('Btn2').click();
          }
          else if (selected == '2') {
              document.getElementById('Button2').click();
              document.getElementById('myBtnBack').style.display = 'block';
              document.getElementById('myBtnNext').style.display = 'none';
              document.getElementById('myBtnBack').style.bottom = '75px';
              // bottom: 130px;
          }
      });
      $("#myBtnBack").click(function () {
          var selected = $("#tabs").tabs("option", "active");
          $("#tabs").tabs("option", "active", selected - 1);

          var selected2 = parseInt(selected) - 1;

          if (selected2 == '0') {
             // alert('0');
              document.getElementById('myBtnBack').style.display = 'none';
              if (document.getElementById('myBtnNext').style.display === 'none') {
                  //alert('new 0');
                  document.getElementById('myBtnNext').style.display = 'block';
              }
              //document.getElementById('myBtnNext').style.display = 'block';
              //document.getElementById('btn').click();
          }
          else if (selected2 == '1') {
             // alert('1');
              document.getElementById('myBtnBack').style.display = 'block';
              
              var x = document.getElementById('myBtnNext');

              if (x.style.display === 'none')
              {
                  //alert('new 1');
                  x.style.display = 'block';
              }
        
              document.getElementById('myBtnNext').style.display = 'block';
              //document.getElementById('Btn2').click();
          }
          else if (selected2 == '2') {
             // alert('2');
             // document.getElementById('Button2').click();
              document.getElementById('myBtnBack').style.display = 'block';

              var x = document.getElementById('myBtnNext');

              if (x.style.display === 'none') {
                  //alert('new 1');
                  x.style.display = 'block';
              }
              //document.getElementById('myBtnNext').style.display = 'none';
              document.getElementById('myBtnBack').style.bottom = '130px';
              // bottom: 130px;
          }


         
      });

     

      });
      

  $(function () {
      $("#datepicker1,#datepicker2,#datepicker3,#datepicker4,#SubP3DOB,#SubP4DOB").datepicker({
          changeMonth: true,
          changeYear: true,
          yearRange: "-100:",
          maxDate: "31-12-2000",
          dateFormat: 'dd-mm-yy'

      });

      $("#tourdatedatepicker,#datepicker5,#datepicker6,#datepicker13,#datepicker11,#datepicker10,#datepicker8").datepicker({
          changeMonth: true,
          changeYear: true,
          yearRange: "1950:2050",
          dateFormat: 'dd-mm-yy',
          minDate: 0
      });

      $("#datepicker5,#datepicker6").datepicker({
          changeMonth: true,
          changeYear: true,
          yearRange: "1950:2050",
          dateFormat: 'dd-mm-yy',
          //minDate: 0
      });


      $('#deckcheckintimeTextBox').timepicker({
          timeFormat: 'HH:mm',
          interval: 1,
          minTime: '24',
          maxTime: '23:59',
          startTime: '00:00',
          dynamic: false,
          dropdown: true,
          scrollbar: true

      });

      $('#deckcheckouttimeTextBox').timepicker({
          timeFormat: 'HH:mm',
          interval: 1,
          minTime: '24',
          maxTime: '23:59',
          startTime: '00:00',
          dynamic: false,
          dropdown: true,
          scrollbar: true

      });

  });

  /*$("#btn").on('click', function () {
      $("#tabs").tabs("option", "active", 2);
  });*/

      


  </script>

       <script>

           $(document).ready(function (){
               $('#DropDownList40').change( function () {
                   var id = $("#DropDownList40").val();

                   var tid;
                   
                   if(id=="Trade Into Points")
                   {
                      tid = "#ContTypeTPDropDownList";
                   }
                   else if(id=="Trade Into Fractional")
                   {
                       tid = "#ContTypeDropDownListTF";
                   }
                     
                 
                   //alert('hi');

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateDropDownList",
                       data: "{}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#ResortDropDownListF").empty();
                           $("#ResortDropDownListF").append("<option disabled selected value>--Select an Option--</option>");
                           jsdata = JSON.parse(data.d);
                           
                           $.each(jsdata, function (key, value) {

                               $("#ResortDropDownListF").append($("<option></option>").val(value.ResortName).html(value.ResortName));



                           });

                       },
                       //called on jquery ajax call failure
                       error: function ajaxError(result) {
                           alert(result.status + ' : ' + result.statusText);
                       }
                   });
                   //return false;


                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/ContracttypeDropDownList",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $(tid).empty();
                           $(tid).append("<option disabled selected value>--Select an Option--</option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $(tid).append($("<option></option>").val(value.ContracttypeName).html(value.ContracttypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;

                  

               });


           
                 
               });


           
       </script>

       <script>

           $(document).ready(function () {
               $("#ResortDropDownListF").change(function () {

                   var id = $("#ResortDropDownListF").val();
                   //alert(id);
                   document.getElementById("texttest").value = id;
                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateResortNoDropDownList",
                       data: "{'id': '"+ id +"'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#ResidenceNoDropDownListF").empty();
                           $("#ResidenceNoDropDownListF").append("<option disabled selected value>--Select an Option--</option>");
                           jsdata = JSON.parse(data.d);
                           //alert(jsdata);
                           $.each(jsdata, function (key, value) {

                               $("#ResidenceNoDropDownListF").append($("<option></option>").val(value.ResortNoName).html(value.ResortNoName));



                           });


                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });
           //for residence type

           $(document).ready(function () {
               $("#ResidenceNoDropDownListF").change(function () {

                   var id = $("#ResidenceNoDropDownListF").val();

                   //alert(id);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateResidenceTypeDropDownList",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#ResidenceTypeDropDownListF").empty();
                           $("#ResidenceTypeDropDownListF").append("<option disabled selected value>--Select an Option--</option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#ResidenceTypeDropDownListF").append($("<option></option>").val(value.ResidenceTypeName).html(value.ResidenceTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });


           //for resort type TF


           $(document).ready(function () {
               $("#ResortDropDownListTF").change(function () {

                   var id = $("#ResortDropDownListTF").val();
                   //alert(id);
                   document.getElementById("texttest").value = id;
                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateResortNoDropDownList",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#ResidenceNoDropDownListTF1").empty();
                           $("#ResidenceNoDropDownListTF1").append("<option disabled selected value>--Select an Option--</option>");
                           jsdata = JSON.parse(data.d);
                           //alert(jsdata);
                           $.each(jsdata, function (key, value) {

                               $("#ResidenceNoDropDownListTF1").append($("<option></option>").val(value.ResortNoName).html(value.ResortNoName));



                           });


                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });
           //for residence type

           $(document).ready(function () {
               $("#ResidenceNoDropDownListTF1").change(function () {

                   var id = $("#ResidenceNoDropDownListTF1").val();

                   //alert(id);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateResidenceTypeDropDownList",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#ResiTypeDropDownListTF1").empty();
                           $("#ResiTypeDropDownListTF1").append("<option disabled selected value>--Select an Option--</option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#ResiTypeDropDownListTF1").append($("<option></option>").val(value.ResidenceTypeName).html(value.ResidenceTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });


           //for contract type function TF


           $(document).ready(function () {
               $("#ResortDropDownListTF3").change(function () {

                   var id = $("#ResortDropDownListTF3").val();
                   //alert(id);
                   document.getElementById("texttest").value = id;
                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateResortNoDropDownList",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#ResidenceNoDropDownListTF").empty();
                           $("#ResidenceNoDropDownListTF").append("<option disabled selected value>--Select an Option--</option>");
                           jsdata = JSON.parse(data.d);
                           //alert(jsdata);
                           $.each(jsdata, function (key, value) {

                               $("#ResidenceNoDropDownListTF").append($("<option></option>").val(value.ResortNoName).html(value.ResortNoName));



                           });


                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });
           //for residence type

           $(document).ready(function () {
               $("#ResidenceNoDropDownListTF").change(function () {

                   var id = $("#ResidenceNoDropDownListTF").val();

                   //alert(id);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateResidenceTypeDropDownList",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#ResiTypeDropDownListTF").empty();
                           $("#ResiTypeDropDownListTF").append("<option disabled selected value>--Select an Option--</option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#ResiTypeDropDownListTF").append($("<option></option>").val(value.ResidenceTypeName).html(value.ResidenceTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });




           //for contract type in TP
           //ContTypeDropDownListTF
           $(document).ready(function () {
               $("#ContTypeTPDropDownList").change(function () {
                   
                   //alert('hi');
                   var v1 = document.getElementById("ContTypeTPDropDownList");
                   var conttype = v1.options[v1.selectedIndex].text;
                   document.getElementById("hiddentconttype").value = conttype;
                   
                   //alert(conttype);
                   if (conttype == "From Weeks To Points") {
                       document.getElementById("table1").style.display = 'none';
                       document.getElementById("table2").style.display = 'block';
                       //document.getElementById("w2").style.display = 'block';
                   }
                   else if 
                       (conttype == "From Points To Points") {
                       document.getElementById("table2").style.display = 'none';
                       document.getElementById("table1").style.display = 'block';
                       
                       //document.getElementById("w2").style.display = 'block';
                   }
                   else {
                       document.getElementById("table2").style.display = 'none';
                       document.getElementById("table1").style.display = 'none';
                   }
                  

               });

           });



           //for contract type in TF
           //ContTypeDropDownListTF
           $(document).ready(function () {
               $("#ContTypeDropDownListTF").change(function () {

                   //alert('hi');
                   var v1 = document.getElementById("ContTypeDropDownListTF");
                   var conttype = v1.options[v1.selectedIndex].text;
                   var v2  = document.getElementById("FinanceCurrencyDropDownList");
                   var Currtype = v2.options[v2.selectedIndex].text;
                   document.getElementById("hiddentconttype2").value = conttype;

                   //alert(conttype);
                   if (conttype == "From Points To Fractional") {
                       document.getElementById("tableTF2").style.display = 'none';
                       document.getElementById("tableTF3").style.display = 'none';
                       document.getElementById("tableTF1").style.display = 'block';
                       //document.getElementById("w2").style.display = 'block';
                   }
                   else if 
                       (conttype == "From Weeks To Fractional") {
                       document.getElementById("tableTF2").style.display = 'block';
                       document.getElementById("tableTF3").style.display = 'none';
                       document.getElementById("tableTF1").style.display = 'none';

                       //document.getElementById("w2").style.display = 'block';
                   }
                   else if 
                       (conttype == "From Fractional To Fractional") {
                       document.getElementById("tableTF2").style.display = 'none';
                       document.getElementById("tableTF3").style.display = 'block';
                       document.getElementById("tableTF1").style.display = 'none';

                       //document.getElementById("w2").style.display = 'block';
                   }
                   else {
                       document.getElementById("tableTF2").style.display = 'none';
                       document.getElementById("tableTF3").style.display = 'none';
                       document.getElementById("tableTF1").style.display = 'none';
                   }

                   //alert('TFadminfees');
                   //var v1 = document.getElementById("ContTypeDropDownListTF");
                   //var conttype = v1.options[v1.selectedIndex].text;
                   //alert(conttype);
                   if (conttype == "From Points To Fractional" && Currtype == "USD") {
                       document.getElementById("TextAdminFees").value = "1500";
                       document.getElementById("ca1").checked = true;
                       document.getElementById("ca2").checked = true;
                       addvalue1(); addvalue2();
                   }
                   else if (conttype == "From Weeks To Fractional" && Currtype == "USD") {
                       document.getElementById("TextAdminFees").value = "1500";
                       document.getElementById("ca1").checked = true;
                       document.getElementById("ca2").checked = true;
                       addvalue1(); addvalue2();
                   }
                   else if (conttype == "From Fractional To Fractional" && Currtype == "USD") {
                       document.getElementById("TextAdminFees").value = "750";
                       document.getElementById("ca1").checked = true;
                       document.getElementById("ca2").checked = true;
                       addvalue1(); addvalue2();
                   }

                   //CurrencyFees();
               });

           });



           $(document).ready(function () {
               $("#DealDrawerDropDownList").change(function () { 

                   var v1 = document.getElementById("DealDrawerDropDownList");
                   var dealstat = v1.options[v1.selectedIndex].text;

                   var vv1 = document.getElementById("DropDownList40");
                   var conttype = vv1.options[vv1.selectedIndex].text;
                   var v4;
                   var club = "";
                   alert(dealstat + "       " + conttype);

                   if (dealstat == 'Deal' || dealstat == 'Top Drawer')
                   {
                       // alert('deal');
                       document.getElementById("item203b").style.display = 'none';
                       document.getElementById("item204b").style.display = 'none';
                       document.getElementById("item203c").style.display = 'none';
                       document.getElementById("item204c").style.display = 'none';
                       document.getElementById("item203d").style.display = 'none';
                       document.getElementById("item204d").style.display = 'none';

                       var v2 = document.getElementById("VenueCountryDropDownList");
                       var ven = v2.options[v2.selectedIndex].text;

                       var v3 = document.getElementById("VenueDropDownList");
                       var venue = v3.options[v3.selectedIndex].text;

                       if (conttype == 'Points') {
                           v4 = document.getElementById("ContractClubPDropDownList");
                           club = v4.options[v4.selectedIndex].text;
                       } else if (conttype == 'Trade Into Points')
                       {
                           v4 = document.getElementById("ContractClubTPDropDownList2");
                           club = v4.options[v4.selectedIndex].text;
                       }
                       else if (conttype == 'Trade Into Fractional') {
                           club = "";
                       }
                       else if (conttype == 'Fractional') {
                           club = "";
                       }
                       //var club = v4.options[v4.selectedIndex].text;

                       var v5 = document.getElementById("GroupVenueDropDownList");
                       var mark = v5.options[v5.selectedIndex].text;

                      // alert(conttype + ' ' + ven + ' ' + venue + ' ' + club +' '+ mark);

                       //MarketingPrgmDropDownList

                       /*var v = document.getElementById("VenueCountryDropDownList");
                       var venuecount = v.options[v.selectedIndex].text;
    
                       var v2 = document.getElementById("VenueDropDownList");
                       var ven = v2.options[v2.selectedIndex].text;
    
                       var deals = $("#DealDrawerDropDownList").val();
                       //var venuecount = $("#VenueCountryDropDownList").val();
                       //var ven = $("#VenueDropDownList").val();
    
                       //var vc = document.getElementById("VenueCountryDropDownList").value;
    
                       alert(deals + ' ' + venuecount + ' ' + ven);
                       alert(venuecount);
                       alert(vc);*/

                       /* $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            //url is the path of our web method (Page name/function name)
                            url: "Edit_Contract.aspx/loadpointcont1",
                            data: "{}",
                            dataType: "json",
                            success: function (data) {
                               // alert("data"+data.d);
                                /*if (result) {
                                    alert(result);
                                }
         
                                //$('TextContractNumb').val(data.d.contnumbgenno);
                            },
                            error: function (error) {
                                alert(error);
                            }
         
                        });*/


                       $.ajax({
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           //url is the path of our web method (Page name/function name)
                           url: "Edit_Contract.aspx/helo1",
                           data: "{'name': '" + ven + "','venue': '" + venue + "','club': '" + club + "','mark': '" + mark + "','conttype': '" + conttype + "'}",
                           dataType: "json",
                           //called on jquery ajax call success
                           success: function (data) {
                              // alert(data.d);
                               $("#TextContractNumb").val(data.d);


                               if (conttype == 'Points') {
                                   $("#ContractNoPointsTextBox").val($("#TextContractNumb").val());
                               } else if (conttype == 'Trade Into Points') {
                                   $("#ContractNoTPTextBox").val($("#TextContractNumb").val());
                               }
                               else if (conttype == 'Trade Into Fractional') {
                                   $("#ContractNoTFTextBox").val($("#TextContractNumb").val());
                               }
                               else if (conttype == 'Fractional') {
                                   $("#ContractNoFractTextBox").val($("#TextContractNumb").val());
                               }
                           },
                           //called on jquery ajax call failure
                           error: function () {
                               alert('error');
                           }
                       });
                       return false;

                   }
                   else if(dealstat == 'Cancel')
                   {
                       alert('into cancel');
                       document.getElementById("item203b").style.display = 'grid';
                       document.getElementById("item204b").style.display = 'grid';
                       document.getElementById("item203c").style.display = 'grid';
                       document.getElementById("item204c").style.display = 'grid';
                       document.getElementById("item203d").style.display = 'grid';
                       document.getElementById("item204d").style.display = 'grid';
                       
                       var todayDate = new Date().toISOString().slice(0, 10);
                       document.getElementById("CancelDateTextBox").value = todayDate;
                       //alert(todayDate);
                   }
                   else if (dealstat == 'Kick Off')
                   {
                       document.getElementById("item203b").style.display = 'none';
                       document.getElementById("item204b").style.display = 'none';
                       document.getElementById("item203c").style.display = 'none';
                       document.getElementById("item204c").style.display = 'none';
                       document.getElementById("item203d").style.display = 'none';
                       document.getElementById("item204d").style.display = 'none';

                   }
                   });

           
           });



///for property fees
           $(document).ready(function () {
               $("#EntitlementTPoinDropDownList").change(function () {

                   //alert('EntitlementTPoinDropDownList');
                   var v1 = document.getElementById("EntitlementTPoinDropDownList");
                   var ent = v1.options[v1.selectedIndex].text;

                   var v2 = $("#TextNewPointsTP").val();

                  // alert(v2);
                   var v3 = document.getElementById("DropDownList40");
                   var drop = v3.options[v3.selectedIndex].text;
                   //alert(drop);
                   if (drop == 'Trade Into Points') {

                       document.getElementById("item202a1").style.display = "block";
                       document.getElementById("item202b1").style.display = "block";
                       document.getElementById("item202a2").style.display = "block";
                       document.getElementById("item202b2").style.display = "block";

                       $.ajax({
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           //url is the path of our web method (Page name/function name)
                           url: "Edit_Contract.aspx/LoadPropfess",
                           data: "{}",
                           dataType: "json",
                           //called on jquery ajax call success
                           success: function (data) {

                               // alert(data.d[0] + "     " + data.d[1]);

                               //alert(data.d);
                               if (ent == "FULL") {
                                   $("#TextPropertyFeesTP").val(data.d[0]);
                                   $("#TextMembershipFeesTP").val(data.d[1]);

                               }
                               else {
                                   $("#TextPropertyFeesTP").val(parseFloat(data.d[0]) / 2);
                                   $("#TextMembershipFeesTP").val(parseFloat(data.d[1]) / 2);
                               }

                               $("#TextMCFees").val(((parseFloat(v2) * parseFloat($("#TextPropertyFeesTP").val())) + parseFloat($("#TextMembershipFeesTP").val())).toFixed(2));
                               $("#TextPropFeesp").val($("#TextPropertyFeesTP").val());
                               $("#TextMemFeesp").val($("#TextMembershipFeesTP").val());

                               //TextBox ID="TextMembershipFeesTP"
                           },

                           error: function () {
                               alert('error');
                           }
                       });
                       return false;

                   }
               });


           });



           //propfee for points

           $(document).ready(function () {
               $("#EntitlementPoinDropDownList").change(function () {

                   //alert('EntitlementTPoinDropDownList');
                   var v1 = document.getElementById("EntitlementPoinDropDownList");
                   var ent = v1.options[v1.selectedIndex].text;

                   var v2 = $("#TextNoPoints").val();

                   var v3 = document.getElementById("DropDownList40");
                   var drop = v3.options[v3.selectedIndex].text;

                   

                  // alert(drop);
                   if (drop == 'Points') {
                       document.getElementById("item202a1").style.display = "block";
                       document.getElementById("item202b1").style.display = "block";
                       document.getElementById("item202a2").style.display = "block";
                       document.getElementById("item202b2").style.display = "block";



                       $.ajax({
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           //url is the path of our web method (Page name/function name)
                           url: "Edit_Contract.aspx/LoadPropfess",
                           data: "{}",
                           dataType: "json",
                           //called on jquery ajax call success
                           success: function (data) {

                               // alert(data.d[0] + "     " + data.d[1]);

                               //alert(data.d);
                               if (ent == "FULL") {
                                   $("#TextPPropFees").val(data.d[0]);
                                   $("#TextPMemFees").val(data.d[1]);

                               }
                               else {
                                   $("#TextPPropFees").val(parseFloat(data.d[0]) / 2);
                                   $("#TextPMemFees").val(parseFloat(data.d[1]) / 2);
                               }

                               $("#TextMCFees").val(((parseFloat(v2) * parseFloat($("#TextPPropFees").val())) + parseFloat($("#TextPMemFees").val())).toFixed(2));


                               $("#TextPropFeesp").val($("#TextPPropFees").val());
                               $("#TextMemFeesp").val($("#TextPMemFees").val());
                               //TextMemFeesp
                               //TextPropFeesp
                           },

                           error: function () {
                               alert('error');
                           }
                       });
                       return false;

                   }
               });


           });




           function talert()
           {
               alert('hi');
           }



           //for venue
           $(document).ready(function () {
               $("#VenueCountryDropDownList").change(function () {

                   //var id = $("#VenueCountryDropDownList").val();
                   var v1 = document.getElementById("VenueCountryDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   //alert(id);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateVenueDropDownList",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#VenueDropDownList").empty();
                           $("#VenueDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#VenueDropDownList").append($("<option></option>").val(value.VenueTypeName).html(value.VenueTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });


           $(document).ready(function () {
               $("#VenueDropDownList").change(function () {

                   // var id = $("#VenueDropDownList").val();

                   //var id2 = $("#VenueCountryDropDownList").val();

                   var v1 = document.getElementById("VenueDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   var v2 = document.getElementById("VenueCountryDropDownList");
                   var id2 = v2.options[v2.selectedIndex].text;


                   //alert(id+"   "+id2);
                   //part 1
                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateVenueGroupDropDownList",
                       data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#GroupVenueDropDownList").empty();
                           $("#GroupVenueDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#GroupVenueDropDownList").append($("<option></option>").val(value.VenueGroupTypeName).html(value.VenueGroupTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });


                   // to load sub venue
                   //$.ajax({
                   //    type: "POST",
                   //    contentType: "application/json; charset=utf-8",
                   //    //url is the path of our web method (Page name/function name)
                   //    url: "CreateProfile.aspx/PopulateSubVenueGroupDropDownList",
                   //    data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                   //    dataType: "json",
                   //    //called on jquery ajax call success
                   //    success: function (data) {
                   //        alert('f2');
                   //        $("#VenueDropDownList2").empty();
                   //        $("#VenueDropDownList2").append("<option disabled selected value></option>");
                   //        jsdata = JSON.parse(data.d);
                   //        $.each(jsdata, function (key, value) {

                   //            $("#VenueDropDownList2").append($("<option></option>").val(value.SubVenueGroupTypeName).html(value.SubVenueGroupTypeName));

                   //        });
                   //    },
                   //    //called on jquery ajax call failure
                   //    error: function () {
                   //        alert('error');
                   //    }
                   //});
                   return false;


               });



               $("#VenueDropDownList").change(function () {

                   // var id = $("#VenueDropDownList").val();

                   //var id2 = $("#VenueCountryDropDownList").val();

                   var v1 = document.getElementById("VenueDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   var v2 = document.getElementById("VenueCountryDropDownList");
                   var id2 = v2.options[v2.selectedIndex].text;


                   if (id == "Flybuys") {
                       // alert('hi');
                       document.getElementById("itemFly").style.display = "grid";

                       document.getElementById("item9a1").style.display = "grid";

                       document.getElementById("item9").style.display = "none";


                       document.getElementById("item9a2").style.display = "grid";

                       document.getElementById("item9a3").style.display = "grid";

                       document.getElementById("item8").style.display = "none";

                       document.getElementById("gueststatusDropDownList").selectedIndex = "4";
                       loadQStatus();
                       document.getElementById("QStatusDropDownList1").selectedIndex = "1";
                   }
                   else {
                       document.getElementById("itemFly").style.display = "none";
                       document.getElementById("gueststatusDropDownList").selectedIndex = "0";
                       loadQStatus();
                       document.getElementById("QStatusDropDownList1").selectedIndex = "0";

                       document.getElementById("item9a1").style.display = "none";


                       document.getElementById("item9a2").style.display = "none";

                       document.getElementById("item9a3").style.display = "none";

                       document.getElementById("item9").style.display = "grid";


                       document.getElementById("item8").style.display = "grid";
                   }

                   //alert(id+"   "+id2);
                   //part 1
                   //$.ajax({
                   //    type: "POST",
                   //    contentType: "application/json; charset=utf-8",
                   //    //url is the path of our web method (Page name/function name)
                   //    url: "Edit_Contract.aspx/PopulateVenueGroupDropDownList",
                   //    data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                   //    dataType: "json",
                   //    //called on jquery ajax call success
                   //    success: function (data) {
                   //        $("#GroupVenueDropDownList").empty();
                   //        $("#GroupVenueDropDownList").append("<option disabled selected value></option>");
                   //        jsdata = JSON.parse(data.d);
                   //        $.each(jsdata, function (key, value) {

                   //            $("#GroupVenueDropDownList").append($("<option></option>").val(value.VenueGroupTypeName).html(value.VenueGroupTypeName));

                   //        });
                   //    },
                   //    //called on jquery ajax call failure
                   //    error: function () {
                   //        alert('error');
                   //    }
                   //});


                   // to load sub venue
                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateSubVenueGroupDropDownList",
                       data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           //alert('f2');
                           $("#VenueDropDownList2").empty();
                           $("#VenueDropDownList2").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#VenueDropDownList2").append($("<option></option>").val(value.SubVenueGroupTypeName).html(value.SubVenueGroupTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });




                   //for sales rep to populate according to venue

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/SalesRepTypeList",
                       data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#salesrepDropDownList").empty();
                           $("#salesrepDropDownList").append("<option></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#salesrepDropDownList").append($("<option></option>").val(value.SalesRepTypeName).html(value.SalesRepTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });

                   return false;


               });



           });



           //$(document).ready(function () {
           //    $("#VenueDropDownList2").click(function () {
           //        alert('hi');
           //        // var id = $("#VenueDropDownList").val();

           //        //var id2 = $("#VenueCountryDropDownList").val();

           //        var v1 = document.getElementById("VenueDropDownList");
           //        var id = v1.options[v1.selectedIndex].text;

           //        var v2 = document.getElementById("VenueCountryDropDownList");
           //        var id2 = v2.options[v2.selectedIndex].text;




           //        alert(id+"   "+id2);
           //        //part 1
           //        //$.ajax({
           //        //    type: "POST",
           //        //    contentType: "application/json; charset=utf-8",
           //        //    //url is the path of our web method (Page name/function name)
           //        //    url: "CreateProfile.aspx/PopulateVenueGroupDropDownList",
           //        //    data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
           //        //    dataType: "json",
           //        //    //called on jquery ajax call success
           //        //    success: function (data) {
           //        //        $("#GroupVenueDropDownList").empty();
           //        //        $("#GroupVenueDropDownList").append("<option disabled selected value></option>");
           //        //        jsdata = JSON.parse(data.d);
           //        //        $.each(jsdata, function (key, value) {

           //        //            $("#GroupVenueDropDownList").append($("<option></option>").val(value.VenueGroupTypeName).html(value.VenueGroupTypeName));

           //        //        });
           //        //    },
           //        //    //called on jquery ajax call failure
           //        //    error: function () {
           //        //        alert('error');
           //        //    }
           //        //});


           //        // to load sub venue
           //        $.ajax({
           //            type: "POST",
           //            contentType: "application/json; charset=utf-8",
           //            //url is the path of our web method (Page name/function name)
           //            url: "Edit_Contract.aspx/PopulateSubVenueGroupDropDownList",
           //            data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
           //            dataType: "json",
           //            //called on jquery ajax call success
           //            success: function (data) {
           //                alert('f2');
           //                $("#VenueDropDownList2").empty();
           //                $("#VenueDropDownList2").append("<option disabled selected value></option>");
           //                jsdata = JSON.parse(data.d);
           //                $.each(jsdata, function (key, value) {

           //                    $("#VenueDropDownList2").append($("<option></option>").val(value.SubVenueGroupTypeName).html(value.SubVenueGroupTypeName));

           //                });
           //            },
           //            //called on jquery ajax call failure
           //            error: function () {
           //                alert('error');
           //            }
           //        });
           //        return false;


           //    });

           //});


           $(document).ready(function () {
               $("#GroupVenueDropDownList").change(function () {

                   //var id = $("#VenueDropDownList").val();

                   // var id2 = $("#VenueCountryDropDownList").val();


                   //var v1 = document.getElementById("VenueDropDownList");
                   //var id = v1.options[v1.selectedIndex].text;

                   var v1 = document.getElementById("GroupVenueDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   var v2 = document.getElementById("VenueCountryDropDownList");
                   var id2 = v2.options[v2.selectedIndex].text;

                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateMrktProgDropDownList",
                       data: "{'venueid': '" + id + "','countid' : '" + id2 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#MarketingPrgmDropDownList").empty();
                           $("#MarketingPrgmDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#MarketingPrgmDropDownList").append($("<option></option>").val(value.MrktProgTypeName).html(value.MrktProgTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });



           $(document).ready(function () {
               $("#MarketingPrgmDropDownList").change(function () {
                   // alert("hi");
                   // var id = $("#MarketingPrgmDropDownList").val();

                   //var id2 = $("#VenueDropDownList").val();

                   // var id3 = $("#VenueCountryDropDownList").val();


                   var v1 = document.getElementById("MarketingPrgmDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   //var v2 = document.getElementById("VenueDropDownList");
                   //var id2 = v2.options[v2.selectedIndex].text;

                   var v2 = document.getElementById("GroupVenueDropDownList");
                   var id2 = v2.options[v2.selectedIndex].text;

                   var v3 = document.getElementById("VenueCountryDropDownList");
                   var id3 = v3.options[v3.selectedIndex].text;

                   // alert(id );

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateAgentDropDownList",
                       data: "{'markid': '" + id + "','venueid': '" + id2 + "','countid': '" + id3 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#AgentsDropDownList").empty();
                           $("#AgentsDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#AgentsDropDownList").append($("<option></option>").val(value.AgentTypeName).html(value.AgentTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });


           $(document).ready(function () {
               $("#AgentsDropDownList").change(function () {
                   //alert("hi");
                   // var id = $("#AgentsDropDownList").val();

                   //var id2 = $("#MarketingPrgmDropDownList").val();

                   var v1 = document.getElementById("AgentsDropDownList");
                   var id = v1.options[v1.selectedIndex].text;

                   var v2 = document.getElementById("MarketingPrgmDropDownList");
                   var id2 = v2.options[v2.selectedIndex].text;

                   var v3 = document.getElementById("GroupVenueDropDownList");
                   var id3 = v3.options[v3.selectedIndex].text;

                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateAgentCodeDropDownList",
                       data: "{'markid': '" + id2 + "','agentid':'" + id + "','venueid':'" + id3 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#AgentCodeDropDownList").empty();
                           $("#AgentCodeDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#AgentCodeDropDownList").append($("<option></option>").val(value.AgentCodeTypeName).html(value.AgentCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });



           //populate country 
           $(document).ready(function () {




               //nationality with country primary
               $("#primarynationalityDropDownList").change(function () {
                   // alert("hi");
                   var id = $("#primarynationalityDropDownList").val();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#PrimaryCountryDropDownList").empty();
                           //$("#primarymobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#PrimaryCountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });


               //for primary
               //$("#PrimaryCountryDropDownList").change(function () {
               //    // alert("hi");
               //    var id = $("#PrimaryCountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#primarymobileDropDownList").empty();
               //           /* $("#primarymobileDropDownList").append("<option disabled selected value></option>");*/
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#primarymobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});

               //for secondary
               //$("#SecondaryCountryDropDownList").change(function () {
               //    //alert("hi");

               //    var v1 = document.getElementById("SecondaryCountryDropDownList");
               //    var id = v1.options[v1.selectedIndex].text;
               //    //var id = $("#SecondaryCountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#secondarymobileDropDownList").empty();
               //            /*$("#secondarymobileDropDownList").append("<option disabled selected value></option>");*/
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#secondarymobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});


               $("#secondarynationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#secondarynationalityDropDownList").val();


                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SecondaryCountryDropDownList").empty();
                           // $("#secondarymobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SecondaryCountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });




               //for Subprofile1
               //$("#SubProfile1CountryDropDownList").change(function () {
               //    //alert("hi");
               //    var v1 = document.getElementById("SubProfile1CountryDropDownList");
               //    var id = v1.options[v1.selectedIndex].text;
               //    //var id = $("#SubProfile1CountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#subprofile1mobileDropDownList").empty();
               //            //$("#subprofile1mobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#subprofile1mobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});

               $("#subprofile1nationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#subprofile1nationalityDropDownList").val();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SubProfile1CountryDropDownList").empty();
                           //$("#subprofile1mobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SubProfile1CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });


               //for Subprofile2
               //$("#SubProfile2CountryDropDownList").change(function () {
               //    //alert("hi");

               //    var v1 = document.getElementById("SubProfile2CountryDropDownList");
               //    var id = v1.options[v1.selectedIndex].text;
               //  //  var id = $("#SubProfile2CountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#subprofile2mobileDropDownList").empty();
               //           // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#subprofile2mobileDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});

               $("#subprofile2nationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#subprofile2nationalityDropDownList").val();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SubProfile2CountryDropDownList").empty();
                           // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SubProfile2CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });


               //for Subprofile3
               //$("#SubP3CountryDropDownList").change(function () {
                  
               //    var id = $("#SubP3CountryDropDownList").val();


               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#SubP3CCDropDownList").empty();
               //            // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#SubP3CCDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});


               $("#SubP3NationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#SubP3NationalityDropDownList").val();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SubP3CountryDropDownList").empty();
                           // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SubP3CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });



               //for Subprofile4
               //$("#SubP4CountryDropDownList").change(function () {
               //    //alert("hi");
               //    var id = $("#SubP4CountryDropDownList").val();



               //    // alert(id + "   " + id2);

               //    $.ajax({
               //        type: "POST",
               //        contentType: "application/json; charset=utf-8",
               //        //url is the path of our web method (Page name/function name)
               //        url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
               //        data: "{'Countid': '" + id + "'}",
               //        dataType: "json",
               //        //called on jquery ajax call success
               //        success: function (data) {
               //            $("#SubP4CCDropDownList").empty();
               //            // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
               //            jsdata = JSON.parse(data.d);
               //            $.each(jsdata, function (key, value) {

               //                $("#SubP4CCDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

               //            });
               //        },
               //        //called on jquery ajax call failure
               //        error: function () {
               //            alert('error');
               //        }
               //    });
               //    return false;


               //});


               $("#SubP4NationalityDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#SubP4NationalityDropDownList").val();



                   // alert(id + "   " + id2);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/PopulateCountryCodeDropDownList",
                       data: "{'Countid': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           $("#SubP4CountryDropDownList").empty();
                           // $("#subprofile2mobileDropDownList").append("<option disabled selected value></option>");
                           jsdata = JSON.parse(data.d);
                           $.each(jsdata, function (key, value) {

                               $("#SubP4CountryDropDownList").append($("<option></option>").val(value.CountryCodeTypeName).html(value.CountryCodeTypeName));

                           });
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });





           });



           $(document).ready(function () {
               $("#pro1").one("mouseenter" ,function () {
                   //alert("hi");
                   // var id = $("#AgentsDropDownList").val();

                   //var id2 = $("#MarketingPrgmDropDownList").val();

                   //var v1 = document.getElementById("AgentsDropDownList");
                   //var id = v1.options[v1.selectedIndex].text;

                   //var v2 = document.getElementById("MarketingPrgmDropDownList");
                   //var id2 = v2.options[v2.selectedIndex].text;

                   // alert(id + "   " + id2);
                   var k, i, s, p;
                   //alert('hhhh');

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/totalgift",
                       data: "{}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           k = (data.d);
                           //$("#vouchernoTextBox").val(data.d);

                           for (i = 1; i <= k; i++) {

                               s = 'item88s' + i;
                               p = 'item88p' + i;
                               //alert('kkk');
                               document.getElementById(s).style.display = "block";
                               document.getElementById(p).style.display = "block";
                           }

                           //alert(k);

                       },
                       //called on jquery ajax call failure
                       error: function () {
                           //alert('error');
                       }
                   });
                   return false;


               });

           });


           
           $(document).ready(function () {
               $("#CrownFinanceCurrDropDownList").change(function () {
                   //alert("hi");
                   var id = $("#CrownFinanceCurrDropDownList").val();

                   

                   //var id2 = $("#MarketingPrgmDropDownList").val();

                   //var v1 = document.getElementById("AgentsDropDownList");
                   //var id = v1.options[v1.selectedIndex].text;

                   //var v2 = document.getElementById("MarketingPrgmDropDownList");
                   //var id2 = v2.options[v2.selectedIndex].text;

                   // alert(id + "   " + id2);
                   var n = document.getElementById("DropDownList40");
                   var pay = n.options[n.selectedIndex].text;

                    
                   var k;//, i, s, p;
                   //alert('hhhh');

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/pnumberCount",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           k = (data.d);
                           //alert(k);
                           $("#TextPnumb").val(k);

                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });


                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/Erates",
                       data: "{'id': '" + id + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                           //k = (data.d);
                           //alert(k);
                           if (id == 'EUR')
                           {
                               document.getElementById("item2017a").style.display = 'grid';
                               document.getElementById("item2018a").style.display = 'grid';
                               document.getElementById("item2017b").style.display = 'none';
                               document.getElementById("item2018b").style.display = 'none';
                               document.getElementById("item2017c").style.display = 'none';
                               document.getElementById("item2018c").style.display = 'none';
                               document.getElementById("item2017d").style.display = 'none';
                               document.getElementById("item2018d").style.display = 'none';
                               $("#TextEuroRateP").val(data.d);
                              // TextGbpRatePTextIdaRateP
                           }
                           else if(id == 'AUD')
                           {
                               document.getElementById("item2017a").style.display = 'none';
                               document.getElementById("item2018a").style.display = 'none';
                               document.getElementById("item2017b").style.display = 'grid';
                               document.getElementById("item2018b").style.display = 'grid';
                               document.getElementById("item2017c").style.display = 'none';
                               document.getElementById("item2018c").style.display = 'none';
                               document.getElementById("item2017d").style.display = 'none';
                               document.getElementById("item2018d").style.display = 'none';
                               $("#TextAusRateP").val(data.d);
                           }
                           else if (id == 'USD')
                           {
                               document.getElementById("item2017a").style.display = 'none';
                               document.getElementById("item2018a").style.display = 'none';
                               document.getElementById("item2017b").style.display = 'none';
                               document.getElementById("item2018b").style.display = 'none';
                               document.getElementById("item2017c").style.display = 'none';
                               document.getElementById("item2018c").style.display = 'none';
                               document.getElementById("item2017d").style.display = 'none';
                               document.getElementById("item2018d").style.display = 'none';
                               //$("#TextAusRateP").val(data.d);
                           }
                           else if (id == 'GBP') {
                               document.getElementById("item2017a").style.display = 'none';
                               document.getElementById("item2018a").style.display = 'none';
                               document.getElementById("item2017b").style.display = 'none';
                               document.getElementById("item2018b").style.display = 'none';
                               document.getElementById("item2017c").style.display = 'grid';
                               document.getElementById("item2018c").style.display = 'grid';
                               document.getElementById("item2017d").style.display = 'none';
                               document.getElementById("item2018d").style.display = 'none';
                               $("#TextGbpRateP").val(data.d);
                           }

                           if (pay == "Points") {
                              // document.getElementById("PFina").style.display = 'block';
                               changeInstallNo('Button7', 'Button12');
                           }
                           else if (pay == "Fractional") {
                              // document.getElementById("FracFina").style.display = 'block';
                               changeInstallNo('Button9', 'Button13');
                           }
                           else if (pay == "Trade Into Fractional") {
                              // document.getElementById("TFFina").style.display = 'block';
                               changeInstallNo('Button11', 'Button14');
                           }
                           else if (pay == "Trade Into Points") {
                             //  document.getElementById("TPFina").style.display = 'block';
                               changeInstallNo('Button10', 'tButton1');

                           }

                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });




           //for mcharge


           $(document).ready(function () {
               $("#FractionalIDropDownListF").change(function () {

                   var id = $("#ResidenceTypeDropDownListF").val();

                   var id2 = $("#FractionalIDropDownListF").val();
                   //alert(id);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/gmcharge",
                       data: "{'id': '" + id + "','id2': '"+ id2 +"'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {
                          

                           $("#TextMCFees").val(data.d);

                          
                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });




               $("#FracIntDropDownListTF1").change(function () {

                   var id = $("#ResiTypeDropDownListTF1").val();

                   var id2 = $("#FracIntDropDownListTF1").val();
                   //alert(id);

                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //url is the path of our web method (Page name/function name)
                       url: "Edit_Contract.aspx/gmcharge",
                       data: "{'id': '" + id + "','id2': '" + id2 + "'}",
                       dataType: "json",
                       //called on jquery ajax call success
                       success: function (data) {


                           $("#TextMCFees").val(data.d);


                       },
                       //called on jquery ajax call failure
                       error: function () {
                           alert('error');
                       }
                   });
                   return false;


               });

           });




       </script>

       
       <script type="text/javascript">


           function callservermethod() {
              
               var deals = $("#DealDrawerDropDownList").val();
               var vcount = $("#VenueCountryDropDownList").val();
               var vvenue = $("#VenueDropDownList").val();
               
               //alert(deals);
               //var name = $get("txtName").value;
               PageMethods.LoadPointCont(deals,vcount,vvenue, OnSuccess, OnFailure);
           }

           function OnSuccess(result) {
               if (result) {
                   alert(result);
               }
           }
           function OnFailure(error) {

           }

          
           function topFunction()
           {
               //alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location = '<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>';

           }


           function pp(giftprice) {
               //alert('lpo');
               var x = document.getElementById(giftprice).value;
               document.getElementById(giftprice).value = addCommas(x);


           }


           function addCommas(x) {
               var parts = x.toString().split(".");
               parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
               return parts.join(".");
           }



           function shows() {
              var checkbox1 = document.getElementById('chs');
             if (checkbox1.checked) {
               document.getElementById("hidden").style.display = "block";
               }
               else {
                   document.getElementById("hidden").style.display = "none";
                    }

           }


          /* function othercurrency()
           {
              // alert('othercurrency');
               var conttype = document.getElementById("DropDownList40").value;
               var Currtype = document.getElementById("FinanceCurrencyDropDownList").value;
               //alert(conttype);
               //alert(Currtype);
            if (conttype == "Fractional" && Currtype != "USD") {
               document.getElementById("TextAdminFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 1500);
               //var t = (Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 1500));
               //alert(Math.round(parseFloat(document.getElementById("TextExchangeRate").value)));
               //alert(t);
           }
           else if (conttype == "Points" && Currtype != "USD") {
               document.getElementById("TextAdminFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 1250);
               // alert(Math.round(parseFloat(document.getElementById("TextExchangeRate").value)) * 1250);
               //alert(Math.round(parseFloat(document.getElementById("TextExchangeRate").value)));
           }
           else if (conttype == "Trade Into Fractional" && Currtype != "USD") {
               document.getElementById("TextAdminFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 750);
           }
           else if (conttype == "Trade Into Points" && Currtype != "USD") {
               document.getElementById("TextAdminFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 650);
           }

           }*/



           function CurrencyFees()
           {
              // alert('infunc');
               var conttype = document.getElementById("DropDownList40").value;
               var Currtype = document.getElementById("FinanceCurrencyDropDownList").value;

               //if (Currtype != "USD")
               //{
               //    //alert('if not usd')
               //    document.getElementById("texte").style.display = "block";
               //    for (i = 0; i <= 0; i++) {
               //        break;
               //    }
              
               //}

               if(conttype == "Fractional" && Currtype=="USD")
               {
                   document.getElementById("TextAdminFees").value = "1500";
                   //document.getElementById("TextAdminFeesF").value = document.getElementById("TextAdminFees").value;
                   addvalue1(); addvalue2();
                 
               }
               else if (conttype == "Points" && Currtype == "USD")
               {
                   document.getElementById("TextAdminFees").value = "1250";
                   addvalue1(); addvalue2();
               }
               /*else if (conttype == "Trade Into Fractional" && Currtype == "USD")
               {
                   TFadminfees();
               }*/
               else if (conttype == "Trade Into Points" && Currtype == "USD")
               {
                   document.getElementById("TextAdminFees").value = "650";
                   addvalue1(); addvalue2();
               }

                   //not USD
              
           }

           function TFadminfees()
           {
              // alert('TFadminfees');
               var v1 = document.getElementById("ContTypeDropDownListTF");
               var conttype = v1.options[v1.selectedIndex].text;
              // alert(conttype);
               if (conttype == "From Points To Fractional")
               {
                   document.getElementById("TextAdminFees").value = "1500";
               }
               else if (conttype == "From Weeks To Fractional")
               {
                   document.getElementById("TextAdminFees").value = "1500";
               }
               else if (conttype == "From Fractional To Fractional")
               {
                   document.getElementById("TextAdminFees").value = "750";
               }
               //CurrencyFees();
           }

           function financeadminfees()
           {
               var conttype = document.getElementById("DropDownList40").value;

               if (conttype == "Fractional")
               {
                   var adminf = document.getElementById("TextAdminFees").value;
                   
                   document.getElementById("TextAdminFeesF").value = parseInt(adminf);
                   //alert(adminf);
               }
               else if (conttype == "Points")
               {
                   var adminp = document.getElementById("TextAdminFees").value;
                   
                   document.getElementById("TextAdminFeesP").value = parseInt(adminp) / 2;
                   document.getElementById("TextAdminServiceP").value = parseInt(adminp) / 2;
                   
                  // alert(adminp);

               }
               else if (conttype == "Trade Into Fractional") {
                   var admintf = document.getElementById("TextAdminFees").value;

                   document.getElementById("TextAdminFeeTF").value = parseInt(admintf);
                
                   //alert(admintf);

               }
               else
               {
                   var admintp = document.getElementById("TextAdminFees").value;

                   document.getElementById("TextAdminFeesTP").value = parseInt(admintp) / 2;
                   document.getElementById("TextAdminServiceTP").value = parseInt(admintp) / 2;

                   //alert(admintp);

               }
               
               //var adminf = document.getElementById("TextAdminFees").value;
              // alert(adminf);
               //document.getElementById("TextAdminFeesP").value = adminf;

           }

           function adminfee()
           {
               var conttype = document.getElementById("DropDownList40").value;
               if (conttype == "Points")
               {
                   financeadminfees();
                   var PurchaseP = document.getElementById("TextPurchasePrice").value;

                   // alert(PurchaseP);
                   var adminis = document.getElementById("TextAdminFeesP").value;
                   //alert(adminis);
                   var text1 = Math.round(parseInt(PurchaseP) / 2.1);
                   //alert(text1);
                   var result = text1 - parseInt(adminis);
                   //alert(result);

                   // TextTotalBalance
                   // TextDepositF
                   document.getElementById("TextTotalBalance").value = parseInt(PurchaseP) - parseInt(document.getElementById("TextDepositP").value);




                   document.getElementById("TextAdmissFeesP").value = result;


                   document.getElementById("TextPpurchasePrice").value = parseInt(document.getElementById("TextAdmissFeesP").value) + parseInt(document.getElementById("TextAdminFeesP").value);

                   document.getElementById("TextCountryTaxP").value = Math.round((parseInt(PurchaseP) / 2.1) * 0.1);
                   document.getElementById("TextGrandTotalP").value = parseInt(document.getElementById("TextCountryTaxP").value) + parseInt(document.getElementById("TextPpurchasePrice").value);


                   var result2 = parseInt(PurchaseP) - parseInt(document.getElementById("TextGrandTotalP").value) - parseInt(document.getElementById("TextAdminServiceP").value);
                   document.getElementById("TextAppliFeesP").value = result2;
                   document.getElementById("TextTotalServicePriceP").value = parseInt(document.getElementById("TextAppliFeesP").value) + parseInt(document.getElementById("TextAdminServiceP").value);


                   if ((parseInt(document.getElementById("TextGrandTotalP").value) - parseInt(document.getElementById("TextDepositP").value)) < 0) {
                       document.getElementById("TextDepoPPA").value = document.getElementById("TextGrandTotalP").value;
                   }
                   else {
                       document.getElementById("TextDepoPPA").value = document.getElementById("TextDepositP").value;
                   }

                   var t112 = parseInt(document.getElementById("TextDepoPPA").value);
                   //var res = Math.round((parseInt(PurchaseP) / 2.1) + ((parseInt(PurchaseP) / 2.1) * 0.1) - t112);
                   var res = Math.round(parseInt(document.getElementById("TextGrandTotalP").value) - parseInt(document.getElementById("TextDepoPPA").value));

                   //alert(res);

                   if (res < 0) {
                       document.getElementById("TextPBalaceDPA").value = 0;
                   }
                   else {
                       document.getElementById("TextPBalaceDPA").value = res;
                   }

                   document.getElementById("TextPDepositSA").value = parseInt(document.getElementById("TextDepositP").value) - parseInt(document.getElementById("TextDepoPPA").value);
                   var res3 = PurchaseP - (parseInt(document.getElementById("TextPBalaceDPA").value) + parseInt(document.getElementById("TextDepoPPA").value)) - parseInt(document.getElementById("TextPDepositSA").value);
                   document.getElementById("TextBalanceDueSAP").value = res3;

                   var depop = document.getElementById("TextDepositP").value;
                   if (PurchaseP == depop) {
                       document.getElementById("TextPPANoInstall").value = '0';
                       installFirstSecondP()
                   }
                   else {
                       document.getElementById("TextPPANoInstall").value = '';
                   }

                   /*document.getElementById("TextPPAAmountInstall").value = Math.round((parseInt(document.getElementById("TextPBalaceDPA").value) / parseInt(document.getElementById("TextPPANoInstall").value)));

                   document.getElementById("TextPPAFInstall").value = parseInt(document.getElementById("TextPBalaceDPA").value) - (parseInt(document.getElementById("TextPPAAmountInstall").value) * (parseInt(document.getElementById("TextPPANoInstall").value) - 1));

                   document.getElementById("TextSANoInstallP").value = document.getElementById("TextPPANoInstall").value;

                   document.getElementById("TextSAAmountInstallP").value = Math.round((parseInt(document.getElementById("TextBalanceDueSAP").value) / parseInt(document.getElementById("TextSANoInstallP").value)));

                   document.getElementById("TextSAFInstallP").value = parseInt(document.getElementById("TextBalanceDueSAP").value) - (parseInt(document.getElementById("TextSAAmountInstallP").value) * (parseInt(document.getElementById("TextSANoInstallP").value) - 1));

                   document.getElementById("datepicker9").value = document.getElementById("datepicker8").value;

                   var datePA = document.getElementById("datepicker8").value;
                   var dateSA = document.getElementById("datepicker9").value;

                   var PAFInstallAmt = document.getElementById("TextPPAFInstall").value;
                   var SAFInstallAmt = document.getElementById("TextSAFInstallP").value;

                   var PASInstallAmt = document.getElementById("TextPPAAmountInstall").value;
                   var SASInstallAmt = document.getElementById("TextSAAmountInstallP").value;
                   
                   var yr1 = parseInt(datePA.substring(0, 4));
                   var mon1 = parseInt(datePA.substring(5, 7));
                   var dt1 = parseInt(datePA.substring(8, 10));

                   var yr2 = parseInt(dateSA.substring(0, 4));
                   var mon2 = parseInt(dateSA.substring(5, 7));
                   var dt2 = parseInt(dateSA.substring(8, 10));
                   //var date1 = new Date(yr1, mon1 - 1, dt1);
                   //var n = date1.toISOString();
                   //var p = parseInt(date.substring(0, 11));
                   
                   //alert(datePA);
                  // alert(yr1);
                  // alert(mon1);
                  // alert(dt1);

                   var NoIPA = parseInt(document.getElementById("TextPPANoInstall").value);
                   var NoISA = parseInt(document.getElementById("TextSANoInstallP").value);

                   var textIDPA = "TextPBalanceDDates";
                   var textIDSA = "TextBalanceDDatesSAP";
                   var textPASARem = "TextRemarksP";

                   datePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, textIDPA);
                   datePS(NoISA, dateSA, SAFInstallAmt, SASInstallAmt, textIDSA);
                   RemdatePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, SAFInstallAmt, SASInstallAmt, textPASARem)
                   */

               }

              else if (conttype == "Fractional") {
                  //alert("Fractional");
                  financeadminfees();
                   var PurchaseP = document.getElementById("TextPurchasePrice").value;

                    //alert(PurchaseP);
                   var adminis = document.getElementById("TextAdminFeesF").value;
                  //alert(adminis);
                   var text2 = Math.round((parseInt(PurchaseP) / 11 * 10) * 0.1);
                   //var text1 = Math.round(parseInt(PurchaseP) / 2.1);
                   //alert(text2);
                   //var result = text1 - parseInt(adminis);
                  //alert(result);

                   document.getElementById("TextTotalBalanceF").value = parseInt(PurchaseP) - parseInt(document.getElementById("TextDepositF").value);
                   var idt = document.getElementById("TextTotalBalanceF").value;
                   //alert("idt"+idt);
                   document.getElementById("TextCountryTaxF").value = '0';//text2;
                   document.getElementById("TextAdmissFeesF").value = parseInt(PurchaseP) - parseInt(document.getElementById("TextCountryTaxF").value) - parseInt(adminis);
                   document.getElementById("TextTotalPurchasePriceF").value = parseInt(adminis) + parseInt(document.getElementById("TextCountryTaxF").value) + parseInt(document.getElementById("TextAdmissFeesF").value);

                   document.getElementById("TextBalanceDueF").value = parseInt(document.getElementById("TextTotalPurchasePriceF").value) - parseInt(document.getElementById("TextDepositF").value);
                   
                   var depop = document.getElementById("TextDepositF").value;
                   if (PurchaseP == depop) {
                       document.getElementById("TextNoOfInstallF").value = '0';
                       installFirstSecond()
                   }
                   else {
                       document.getElementById("TextNoOfInstallF").value = '';
                   }
                  

              }

              else if (conttype == "Trade Into Points")
              {
                  //alert("Trade Into Points");
                  financeadminfees();
                  var PurchaseP = document.getElementById("TextPurchasePrice").value;

                  // alert(PurchaseP);
                  var adminis = document.getElementById("TextAdminFeesTP").value;
                  //alert(adminis);
                  var text1 = Math.round(parseInt(PurchaseP) / 2.1);
                  //alert(text1);
                  var result = text1 - parseInt(adminis);
                  //alert(result);

                  // TextTotalBalance
                  // TextDepositF
                  document.getElementById("TextTotalBalanceTP").value = parseInt(PurchaseP) - parseInt(document.getElementById("TextDepositTP").value);



                  document.getElementById("TextAdmissFTP").value = result;
                  // document.getElementById("TextAppliFeesTP").value = result;

                  document.getElementById("TextPurchasePriceTP").value = parseInt(document.getElementById("TextAdmissFTP").value) + parseInt(document.getElementById("TextAdminFeesTP").value);
                  document.getElementById("TextGrandTotalTP").value = parseInt(document.getElementById("TextCountryTaxTP").value) + parseInt(document.getElementById("TextPurchasePriceTP").value);

                  var result2 = parseInt(PurchaseP) - parseInt(document.getElementById("TextGrandTotalTP").value) - parseInt(document.getElementById("TextAdminServiceTP").value);
                  document.getElementById("TextAppliFeesTP").value = result2;

                  document.getElementById("TextTotalServiceTP").value = parseInt(document.getElementById("TextAppliFeesTP").value) + parseInt(document.getElementById("TextAdminServiceTP").value);

                  document.getElementById("TextCountryTaxTP").value = Math.round((parseInt(PurchaseP) / 2.1) * 0.1);


                  if ((parseInt(document.getElementById("TextGrandTotalTP").value) - parseInt(document.getElementById("TextDepositTP").value)) < 0) {
                      document.getElementById("TextDepositPATP").value = document.getElementById("TextGrandTotalTP").value;
                  }
                  else {
                      document.getElementById("TextDepositPATP").value = document.getElementById("TextDepositTP").value;
                  }

                  var t112 = parseInt(document.getElementById("TextDepositPATP").value);
                  //var res = Math.round((parseInt(PurchaseP) / 2.1) + ((parseInt(PurchaseP) / 2.1) * 0.1) - t112);
                  var res = Math.round(parseInt(document.getElementById("TextGrandTotalTP").value) - parseInt(document.getElementById("TextDepositPATP").value));
                  //alert(res);

                  if (res < 0) {
                      document.getElementById("TextBalanceDuePATP").value = 0;
                  }
                  else {
                      document.getElementById("TextBalanceDuePATP").value = res;
                  }

                  document.getElementById("TextDepositSATP").value = parseInt(document.getElementById("TextDepositTP").value) - parseInt(document.getElementById("TextDepositPATP").value);
                  var res3 = PurchaseP - (parseInt(document.getElementById("TextBalanceDuePATP").value) + parseInt(document.getElementById("TextDepositPATP").value)) - parseInt(document.getElementById("TextDepositSATP").value);
                  document.getElementById("TextBalanceDueSATP").value = res3;

                  var depop = document.getElementById("TextDepositTP").value;
                  if (PurchaseP == depop) {
                      document.getElementById("TextNoOfInstallPATP").value = '0';
                      installFirstSecondTP()
                  }
                  else {
                      document.getElementById("TextNoOfInstallPATP").value = '';
                  }

              }

              else if (conttype == "Trade Into Fractional") {
                  //alert("Fractional");
                  financeadminfees();
                  var PurchaseP = document.getElementById("TextPurchasePrice").value;

                  //alert(PurchaseP);
                  var adminis = document.getElementById("TextAdminFeeTF").value;
                  //alert(adminis);
                  var text2 = Math.round((parseInt(PurchaseP) / 11 * 10) * 0.1);
                  //var text1 = Math.round(parseInt(PurchaseP) / 2.1);
                  //alert(text2);
                  //var result = text1 - parseInt(adminis);
                  //alert(result);

                  document.getElementById("TextTotalBalanceTF").value = parseInt(PurchaseP) - parseInt(document.getElementById("TextDepositTF").value);
                  var idt = document.getElementById("TextTotalBalanceTF").value;
                  //alert("idt"+idt);
                  document.getElementById("TextCountryTaxTF").value = '0';//text2;
                  document.getElementById("TextAdmissFeeTF").value = parseInt(PurchaseP) - parseInt(document.getElementById("TextCountryTaxTF").value) - parseInt(adminis);
                  document.getElementById("TextPurchasePriceTF").value = parseInt(adminis) + parseInt(document.getElementById("TextCountryTaxTF").value) + parseInt(document.getElementById("TextAdmissFeeTF").value);

                  document.getElementById("TextBalanceDuePATF").value = parseInt(document.getElementById("TextPurchasePriceTF").value) - parseInt(document.getElementById("TextDepositTF").value);


                  var depop = document.getElementById("TextDepositTF").value;
                  if (PurchaseP == depop) {
                      document.getElementById("TextNoOfInstallTF").value = '0';
                      installFirstSecondTP()
                  }
                  else {
                      document.getElementById("TextNoOfInstallTF").value = '';
                  }

            

              }


           }

           var glob;
           var balanceamt;

           function installFirstSecondP()
           {
              // alert("installFirstSecondP");
               //document.getElementById("TextPPAAmountInstall").value = Math.round((parseInt(document.getElementById("TextPBalaceDPA").value) / parseInt(document.getElementById("TextPPANoInstall").value)));
               document.getElementById("TextModTotalBalance").value = document.getElementById("TextTotalBalance").value;

               document.getElementById("TextModNoofInvoice").value = document.getElementById("TextPPANoInstall").value;

               var noinvoice = document.getElementById("TextPPANoInstall").value;


               if (noinvoice == '0') {
                   document.getElementById("TextPPAAmountInstall").value = '0';

                   document.getElementById("TextPPAFInstall").value = '0';

                   document.getElementById("TextRemarkP").value = 'No Invoice';

                   document.getElementById("TextPBalanceDDates").value = 'No Invoice';

                   document.getElementById("TextBalanceDDatesSAP").value = 'No Invoice';


                   return false;
               }
               else {

                   document.getElementById("TextPPAAmountInstall").value = Math.floor(parseInt(document.getElementById("TextTotalBalance").value) / parseInt(document.getElementById("TextPPANoInstall").value));

                   var tt = Math.round(parseInt(document.getElementById("TextTotalBalance").value) - (parseInt(document.getElementById("TextPPAAmountInstall").value) * (parseInt(document.getElementById("TextPPANoInstall").value) - 1)));
                   document.getElementById("TextPPAFInstall").value = tt;
               }
               //alert(tt);
               //document.getElementById("TextPPAFInstall").value = Math.round(parseInt(document.getElementById("TextTotalBalance").value) - (parseInt(document.getElementById("TextPPAAmountInstall").value) * (parseInt(document.getElementById("TextPPAFInstall").value) - 1)));

               //var tempnoi = (parseInt(document.getElementById("TextPPANoInstall").value) - 1);
               //var tempc = (parseInt(document.getElementById("TextTotalBalance").value) - parseInt(qq)) / parseInt(tempnoi);

               //document.getElementById("TextPPAAmountInstall").value = tempc;//parseInt(document.getElementById("TextTotalBalance").value) - parseInt(tempc) ;
               //var pp = document.getElementById("TextPPAAmountInstall").value;

              // var bal = document.getElementById("TextTotalBalance").value;

               //alert('1  ' + qq + '  2  ' + pp + '  temp  ' + tempc + '  tempnoi ' + tempnoi + '  bal  ' + bal);

               //if (parseInt(document.getElementById("TextPPAFInstall").value) < parseInt(document.getElementById("TextPPAAmountInstall").value))
               //{
               //    var t = "";
               //    t = document.getElementById("TextPPAFInstall").value;
               //    document.getElementById("TextPPAFInstall").value = document.getElementById("TextPPAAmountInstall").value;
               //    document.getElementById("TextPPAAmountInstall").value = t;
               //}

               //document.getElementById("TextSANoInstallP").value = document.getElementById("TextPPANoInstall").value;

               //document.getElementById("TextSAAmountInstallP").value = Math.round((parseInt(document.getElementById("TextBalanceDueSAP").value) / parseInt(document.getElementById("TextSANoInstallP").value)));

               //document.getElementById("TextSAFInstallP").value = parseInt(document.getElementById("TextBalanceDueSAP").value) - (parseInt(document.getElementById("TextSAAmountInstallP").value) * (parseInt(document.getElementById("TextSANoInstallP").value) - 1));

              // document.getElementById("datepicker9").value = document.getElementById("datepicker8").value;

               var datePA = document.getElementById("datepicker8").value;
               //var dateSA = document.getElementById("datepicker9").value;


               var PAFInstallAmt = document.getElementById("TextPPAFInstall").value;
               //var PAFInstallAmt = document.getElementById("TextPPAFInstall").value;
               //var SAFInstallAmt = document.getElementById("TextSAFInstallP").value;

               var PASInstallAmt = document.getElementById("TextPPAAmountInstall").value;
               //var PASInstallAmt = document.getElementById("TextPPAAmountInstall").value;
               //var SASInstallAmt = document.getElementById("TextSAAmountInstallP").value;

               var yr1 = parseInt(datePA.substring(0, 4));
               var mon1 = parseInt(datePA.substring(5, 7));
               var dt1 = parseInt(datePA.substring(8, 10));

              // var yr2 = parseInt(dateSA.substring(0, 4));
               //var mon2 = parseInt(dateSA.substring(5, 7));
              // var dt2 = parseInt(dateSA.substring(8, 10));
            

               var NoIPA = parseInt(document.getElementById("TextPPANoInstall").value);
               //var NoISA = parseInt(document.getElementById("TextSANoInstallP").value);
               //alert("installFirstSecond");

               //var textIDPA = "TextPBalanceDDates";
               //var textIDSA = "TextBalanceDDatesSAP";
               var textPASARem = "TextRemarkP";


               var balanceamttemp = document.getElementById("TextTotalBalance").value;
               glob = NoIPA;
               balanceamt = balanceamttemp;

               //alert("installFirstSecond" + glob + balanceamt);

               //datePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, textIDPA);
               //datePS(NoISA, dateSA, SAFInstallAmt, SASInstallAmt, textIDSA);
               //RemdatePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, SAFInstallAmt, SASInstallAmt, textPASARem);
               remarksupdated(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, textPASARem);





           }


           function installFirstSecondTP() {
               //alert("installFirstSecondP");



               //document.getElementById("TextPPAAmountInstall").value = Math.round((parseInt(document.getElementById("TextPBalaceDPA").value) / parseInt(document.getElementById("TextPPANoInstall").value)));
               document.getElementById("TextModTotalBalance").value = document.getElementById("TextTotalBalanceTP").value;

               document.getElementById("TextModNoofInvoice").value = document.getElementById("TextNoOfInstallPATP").value;
               var noinvoice = document.getElementById("TextNoOfInstallPATP").value;


               if (noinvoice == '0') {
                   document.getElementById("TextInstallAmtPATP").value = '0';

                   document.getElementById("TextFInstallAmtPATP").value = '0';

                   document.getElementById("TextRemarksTP").value = 'No Invoice';

                   document.getElementById("TextBalanceDueDatesPATP").value = 'No Invoice';

                   document.getElementById("TextBalanceDueDatesSATP").value = 'No Invoice';

                   
                   return false;
               }
               else {


                   document.getElementById("TextInstallAmtPATP").value = Math.floor((parseInt(document.getElementById("TextTotalBalanceTP").value) / parseInt(document.getElementById("TextNoOfInstallPATP").value)));

                   document.getElementById("TextFInstallAmtPATP").value = parseInt(document.getElementById("TextTotalBalanceTP").value) - (parseInt(document.getElementById("TextInstallAmtPATP").value) * (parseInt(document.getElementById("TextNoOfInstallPATP").value) - 1));
               }
               //if (parseInt(document.getElementById("TextFInstallAmtPATP").value) < parseInt(document.getElementById("TextInstallAmtPATP").value)) {
               //    var t = "";
               //    t = document.getElementById("TextFInstallAmtPATP").value;
               //    document.getElementById("TextFInstallAmtPATP").value = document.getElementById("TextInstallAmtPATP").value;
               //    document.getElementById("TextInstallAmtPATP").value = t;
               //}

               //document.getElementById("TextNoOfInstallSATP").value = document.getElementById("TextNoOfInstallPATP").value;

               //document.getElementById("TextSAAmountInstallP").value = Math.round((parseInt(document.getElementById("TextBalanceDueSAP").value) / parseInt(document.getElementById("TextSANoInstallP").value)));

               //document.getElementById("TextSAFInstallP").value = parseInt(document.getElementById("TextBalanceDueSAP").value) - (parseInt(document.getElementById("TextSAAmountInstallP").value) * (parseInt(document.getElementById("TextSANoInstallP").value) - 1));

              // document.getElementById("datepicker12").value = document.getElementById("datepicker11").value;
              // alert('hi');
               var datePA = document.getElementById("datepicker11").value;
               //var dateSA = document.getElementById("datepicker12").value;


               var PAFInstallAmt = document.getElementById("TextFInstallAmtPATP").value;
               //var PAFInstallAmt = document.getElementById("TextPPAFInstall").value;
               //var SAFInstallAmt = document.getElementById("TextSAFInstallP").value;

               var PASInstallAmt = document.getElementById("TextInstallAmtPATP").value;
               //var PASInstallAmt = document.getElementById("TextPPAAmountInstall").value;
               //var SASInstallAmt = document.getElementById("TextSAAmountInstallP").value;

               var yr1 = parseInt(datePA.substring(0, 4));
               var mon1 = parseInt(datePA.substring(5, 7));
               var dt1 = parseInt(datePA.substring(8, 10));

               //var yr2 = parseInt(dateSA.substring(0, 4));
               //var mon2 = parseInt(dateSA.substring(5, 7));
              // var dt2 = parseInt(dateSA.substring(8, 10));


               var NoIPA = parseInt(document.getElementById("TextNoOfInstallPATP").value);
              // var NoISA = parseInt(document.getElementById("TextNoOfInstallSATP").value);

               var textIDPA = "TextBalanceDueDatesPATP";
              // var textIDSA = "TextBalanceDueDatesSATP";
               var textPASARem = "TextRemarksTP";


               var balanceamttemp = document.getElementById("TextTotalBalanceTP").value;
               glob = NoIPA;
               balanceamt = balanceamttemp;

               //alert("installFirstSecond" + glob + balanceamt);

               //datePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, textIDPA);
               //datePS(NoISA, dateSA, SAFInstallAmt, SASInstallAmt, textIDSA);
               //RemdatePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, SAFInstallAmt, SASInstallAmt, textPASARem);
               remarksupdatedTP(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, textPASARem);





           }
           //global variable 
          // = document.getElementById("TextTotalBalance").value;

           function installFirstSecond()
           {

               document.getElementById("TextModTotalBalance").value = document.getElementById("TextTotalBalanceF").value;

               document.getElementById("TextModNoofInvoice").value = document.getElementById("TextNoOfInstallF").value;
               //alert("1st Fractional");

               var noinvoice = document.getElementById("TextNoOfInstallF").value;


               if (noinvoice == '0') {
                   document.getElementById("TextInstallAmtF").value = '0';

                   document.getElementById("TextFirstInstallAmtF").value = '0';

                   document.getElementById("TextRemarksF").value = 'No Invoice';

                   document.getElementById("TextDueDatesPAF").value = 'No Invoice';

                   


                   return false;
               }
               else {


                   document.getElementById("TextInstallAmtF").value = Math.floor((parseInt(document.getElementById("TextTotalBalanceF").value) / parseInt(document.getElementById("TextNoOfInstallF").value)));


                   document.getElementById("TextFirstInstallAmtF").value = parseInt(document.getElementById("TextTotalBalanceF").value) - (parseInt(document.getElementById("TextInstallAmtF").value) * (parseInt(document.getElementById("TextNoOfInstallF").value) - 1));
               }
              // alert("1st" + document.getElementById("TextFirstInstallAmtF").value);
              // alert("2nd" + document.getElementById("TextInstallAmtF").value); 

               //if (parseInt(document.getElementById("TextFirstInstallAmtF").value) < parseInt(document.getElementById("TextInstallAmtF").value)) {
               //    var t = "";
               //    t = document.getElementById("TextFirstInstallAmtF").value;
               //    document.getElementById("TextFirstInstallAmtF").value = document.getElementById("TextInstallAmtF").value;
               //    document.getElementById("TextInstallAmtF").value = t;
               //}


               var NoIPA = parseInt(document.getElementById("TextNoOfInstallF").value);
               var datePA = document.getElementById("datepicker10").value;
               
               var textIDPA = "TextDueDatesPAF";
               var textPASARem = "TextRemarksF";
               var PAFInstallAmt = parseInt(document.getElementById("TextFirstInstallAmtF").value);
               var PASInstallAmt = parseInt(document.getElementById("TextInstallAmtF").value);

               var balanceamttemp = document.getElementById("TextTotalBalanceF").value;
               glob = NoIPA;
               balanceamt = balanceamttemp;
              

              
               //datePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, textIDPA);
              // RemdatePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, 0, 0, textPASARem);
               remarksupdatedf(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, textPASARem);


           }

           function installFirstSecondTF() {
               //alert("1st Fractional");
               document.getElementById("TextModTotalBalance").value = document.getElementById("TextTotalBalanceTF").value;

               document.getElementById("TextModNoofInvoice").value = document.getElementById("TextNoOfInstallTF").value;
               var noinvoice = document.getElementById("TextNoOfInstallTF").value;

               if (noinvoice == '0')
               {
                   document.getElementById("TextInstallAmtTF").value = '0';

                   document.getElementById("TextFInstallAmtTF").value = '0';

                   document.getElementById("TextRemarksTF").value = 'No Invoice';

                   document.getElementById("TextBalanceDueDatesPATF").value = 'No Invoice';
                   
                   return false;
               }
               else {
                   document.getElementById("TextInstallAmtTF").value = Math.floor((parseInt(document.getElementById("TextTotalBalanceTF").value) / parseInt(document.getElementById("TextNoOfInstallTF").value)));

                   document.getElementById("TextFInstallAmtTF").value = parseInt(document.getElementById("TextTotalBalanceTF").value) - (parseInt(document.getElementById("TextInstallAmtTF").value) * (parseInt(document.getElementById("TextNoOfInstallTF").value) - 1));


               }
                              // alert("1st" + document.getElementById("TextFirstInstallAmtF").value);
               // alert("2nd" + document.getElementById("TextInstallAmtF").value); 

               //if (parseInt(document.getElementById("TextFInstallAmtTF").value) < parseInt(document.getElementById("TextInstallAmtTF").value)) {
               //    var t = "";
               //    t = document.getElementById("TextFInstallAmtTF").value;
               //    document.getElementById("TextFInstallAmtTF").value = document.getElementById("TextInstallAmtTF").value;
               //    document.getElementById("TextInstallAmtTF").value = t;
               //}


               var NoIPA = parseInt(document.getElementById("TextNoOfInstallTF").value);
               var datePA = document.getElementById("datepicker13").value;

               var textIDPA = "TextBalanceDueDatesPATF";
               var textPASARem = "TextRemarksTF";
               var PAFInstallAmt = parseInt(document.getElementById("TextFInstallAmtTF").value);
               var PASInstallAmt = parseInt(document.getElementById("TextInstallAmtTF").value);

               var balanceamttemp = document.getElementById("TextTotalBalanceTF").value;
               glob = NoIPA;
               balanceamt = balanceamttemp;



               //datePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, textIDPA);
               // RemdatePS(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, 0, 0, textPASARem);
               remarksupdatedTF(NoIPA, datePA, PAFInstallAmt, PASInstallAmt, textPASARem);


           }


           function remarksupdated(NumI, DateI, Famt, Samt, textid)
           {
               
               //alert("changes  remarksupdated");
              /* alert('datePS');
                  alert(NumI);
                  alert(DateI);
                  alert(Famt);
                  alert(Samt);
                  alert(textid);*/
               var z,kz;
               var numb = NumI;
               var i;
               var text2 = "";
               var date = DateI;

               var yr1 = parseInt(date.substring(6, 10));
               var mon1 = parseInt(date.substring(3, 5));
               var dt1 = parseInt(date.substring(0, 2));

               kz = caldays(dt1, mon1, yr1);

              // var yr1 = parseInt(date.substring(0, 4));
              // var mon1 = parseInt(date.substring(5, 7));
               //var dt1 = parseInt(date.substring(8, 10));
               var amt = Famt;
               var amt2 = Samt;
               var textids = textid;
               var ncurr = document.getElementById("FinanceCurrencyDropDownList");
               var curr = ncurr.options[ncurr.selectedIndex].text;
               //alert(yr1);
               //alert(mon1);
               // alert(dt1);
               var s = kz;//yr1 + "-" + mon1 + "-" + dt1;
               //var s = mon1 + "-" + dt1 + "-" + yr1;
               //var s = dt1 + "-" + mon1 + "-" + yr1;
               //alert(s);

               for (i = 1; i <= numb; i++) {
                   //alert("hi");
                   if (i == 1) {
                       var text = "Installment " + i + " " + curr + " " + amt + " on " + s;
                       //alert(text);
                   }
                   else {
                      /* if (mon1 >= 12) {
                           mon1 = 0;

                       }
                       */

                       if (mon1 >= 12) {
                          
                           mon1 = 1;
                           yr1 = yr1 + 1;;

                       }
                       else {
                           mon1 = mon1 + 1;
                         
                       }





                       //alert(mon1);
                      // mon1 = mon1 + 1;
                       //var s2 = yr1 + "-" + mon1 + "-" + dt1;
                       z = caldays(dt1, mon1, yr1);
                       // var s2 = mon1 + "-" + dt1 + "-" + yr1;
                       var s2 = z;

                       text2 += "Installment " + i + " " + curr + " " + amt2 + " on " + s2 + ";" + " ";

                   }

                   

               }



               document.getElementById(textids).value = text + "; " + text2;
               //alert("balance and golb" + glob + "   " + balanceamt);
               datetoi(NumI, DateI, Famt, Samt, glob, balanceamt);
           }



           function remarksupdatedTP(NumI, DateI, Famt, Samt, textid) {

               //alert("changes");
               /* alert('datePS');
                   alert(NumI);
                   alert(DateI);
                   alert(Famt);
                   alert(Samt);
                   alert(textid);*/
               var z,kz;
               var numb = NumI;
               var i;
               var text2 = "";
               var date = DateI;
               var yr1 = parseInt(date.substring(6, 10));
               var mon1 = parseInt(date.substring(3, 5));
                var dt1 = parseInt(date.substring(0, 2));
               //var yr1 = parseInt(date.substring(0, 4));
               //var mon1 = parseInt(date.substring(5, 7));
               //var dt1 = parseInt(date.substring(8, 10));

               var amt = Famt;
               var amt2 = Samt;
               var textids = textid;
               var ncurr = document.getElementById("FinanceCurrencyDropDownList");
               var curr = ncurr.options[ncurr.selectedIndex].text;
               //alert(yr1);
               //alert(mon1);
               // alert(dt1);
               kz = caldays(dt1, mon1, yr1);
               var s = kz;//yr1 + "-" + mon1 + "-" + dt1;
               //var s = mon1 + "-" + dt1 + "-" + yr1;
               //alert(s);

               for (i = 1; i <= numb; i++) {
                   //alert("hi");
                   if (i == 1) {
                       var text = "Installment " + i + " " + curr + " " + amt + " on " + s;
                       //alert(text);
                   }
                   else {

                       if (mon1 >= 12) {

                           mon1 = 1;
                           yr1 = yr1 + 1;;

                       }
                       else {
                           mon1 = mon1 + 1;

                       }


                       //alert(mon1);
                       // mon1 = mon1 + 1;
                       //var s2 = yr1 + "-" + mon1 + "-" + dt1;
                       z = caldays(dt1, mon1, yr1);
                       // var s2 = mon1 + "-" + dt1 + "-" + yr1;
                       var s2 = z;

                       text2 += "Installment " + i + " " + curr + " " + amt2 + " on " + s2 + ";" + " ";

                   }



               }



               document.getElementById(textids).value = text + "; " + text2;
               //alert("balance and golb" + glob + "   " + balanceamt);
               datetoi(NumI, DateI, Famt, Samt, glob, balanceamt);
           }

           function remarksupdatedf(NumI, DateI, Famt, Samt, textid) {

               //alert("changes");
               /* alert('datePS');
                   alert(NumI);
                   alert(DateI);
                   alert(Famt);
                   alert(Samt);
                   alert(textid);*/
               var z,kz;
               var numb = NumI;
               var i;
               var text2 = "";
               var date = DateI;
               //var yr1 = parseInt(date.substring(0, 4));
              // var mon1 = parseInt(date.substring(5, 7));
               //var dt1 = parseInt(date.substring(8, 10));
               var yr1 = parseInt(date.substring(6, 10));
               var mon1 = parseInt(date.substring(3, 5));
               var dt1 = parseInt(date.substring(0, 2));

               kz = caldays(dt1, mon1, yr1);
               var amt = Famt;
               var amt2 = Samt;
               var textids = textid;
               var ncurr = document.getElementById("FinanceCurrencyDropDownList");
               var curr = ncurr.options[ncurr.selectedIndex].text;
               //alert(yr1);
               //alert(mon1);
               // alert(dt1);
               var s = kz;//yr1 + "-" + mon1 + "-" + dt1;
               //var s = mon1 + "-" + dt1 + "-" + yr1;
               //alert(s);

               for (i = 1; i <= numb; i++) {
                   //alert("hi");
                   if (i == 1) {
                       var text = "Installment " + i + " " + curr + " " + amt + " on " + s;
                       //alert(text);
                   }
                   else {

                       if (mon1 >= 12) {

                           mon1 = 1;
                           yr1 = yr1 + 1;;

                       }
                       else {
                           mon1 = mon1 + 1;

                       }





                       //alert(mon1);
                       // mon1 = mon1 + 1;
                       //var s2 = yr1 + "-" + mon1 + "-" + dt1;
                       z = caldays(dt1, mon1, yr1);
                       // var s2 = mon1 + "-" + dt1 + "-" + yr1;
                       var s2 = z;

                       text2 += "Installment " + i + " " + curr + " " + amt2 + " on " + s2 + ";" + " ";

                   }



               }



               document.getElementById(textids).value = text + "; " + text2;
               //alert("balance and golb" + glob + "   " + balanceamt);
               datetoi(NumI, DateI, Famt, Samt, glob, balanceamt);
           }




           function remarksupdatedTF(NumI, DateI, Famt, Samt, textid) {

               //alert("changes");
               /* alert('datePS');
                   alert(NumI);
                   alert(DateI);
                   alert(Famt);
                   alert(Samt);
                   alert(textid);*/
               var z,kz;
               var numb = NumI;
               var i;
               var text2 = "";
               var date = DateI;
               //var yr1 = parseInt(date.substring(0, 4));
               //var mon1 = parseInt(date.substring(5, 7));
              // var dt1 = parseInt(date.substring(8, 10));
               var yr1 = parseInt(date.substring(6, 10));
               var mon1 = parseInt(date.substring(3, 5));
               var dt1 = parseInt(date.substring(0, 2));
               var amt = Famt;
               var amt2 = Samt;
               var textids = textid;
               var ncurr = document.getElementById("FinanceCurrencyDropDownList");
               var curr = ncurr.options[ncurr.selectedIndex].text;
               //alert(yr1);
               //alert(mon1);
               // alert(dt1);
               kz = caldays(dt1, mon1, yr1);
               var s = kz;// yr1 + "-" + mon1 + "-" + dt1;
               //var s = mon1 + "-" + dt1 + "-" + yr1;
               //alert(s);

               for (i = 1; i <= numb; i++) {
                   //alert("hi");
                   if (i == 1) {
                       var text = "Installment " + i + " " + curr + " " + amt + " on " + s;
                       //alert(text);
                   }
                   else {

                       if (mon1 >= 12) {

                           mon1 = 1;
                           yr1 = yr1 + 1;;

                       }
                       else {
                           mon1 = mon1 + 1;

                       }





                       //alert(mon1);
                       // mon1 = mon1 + 1;
                       //var s2 = yr1 + "-" + mon1 + "-" + dt1;
                       z = caldays(dt1, mon1, yr1);
                       // var s2 = mon1 + "-" + dt1 + "-" + yr1;
                       var s2 = z;

                       text2 += "Installment " + i + " " + curr + " " + amt2 + " on " + s2 + ";" + " ";

                   }



               }



               document.getElementById(textids).value = text + "; " + text2;
               //alert("balance and golb" + glob + "   " + balanceamt);
               datetoi(NumI, DateI, Famt, Samt, glob, balanceamt);
           }


           function datePS(NumI, DateI, Famt, Samt, textid) {
               /*alert('datePS');
               alert(NumI);
               alert(DateI);
               alert(Famt);
               alert(Samt);
               alert(textid);*/

               var numb = NumI;
               var i;
               var text2 = "";
               var date = DateI;
               var yr1 = parseInt(date.substring(0, 4));
               var mon1 = parseInt(date.substring(5, 7));
               var dt1 = parseInt(date.substring(8, 10));
               var amt = Famt;
               var amt2 = Samt;
               var textids = textid;
               var curr = document.getElementById("FinanceCurrencyDropDownList").value;
               //alert(yr1);
               //alert(mon1);
               // alert(dt1);
               //var s = yr1 + "-" + mon1 + "-" + dt1;
               var s = mon1 + "-" + dt1 + "-" + yr1;
               //alert(s);

               for (i = 1; i <= numb; i++) {
                   //alert("hi");
                   if (i == 1) {
                       var text = "Installment " + i + " " + amt + " " + curr + " on " + s;
                       //alert(text);
                   }
                   else {
                       if (mon1 >= 12) {
                           mon1 = 0;

                       }
                       //alert(mon1);
                       mon1 = mon1 + 1;
                       //var s2 = yr1 + "-" + mon1 + "-" + dt1;
                       var s2 = mon1 + "-" + dt1 + "-" + yr1;

                       text2 += "Installment " + i + " " + amt2 + " " + curr + " on " + s2 + ";" + " ";
                      
                   }
                 
               }
               

            
               document.getElementById(textids).value = text + "; " + text2;
              
           }


           function RemdatePS(NumI, DateI, FamtP, SamtP,FamtS, SamtS, textid) {
               /*alert('datePSremark');
               alert(NumI);
               alert(DateI);
               alert(FamtP);
               alert(SamtP);
               alert(FamtS);
               alert(SamtS);
               alert(textid);*/

               var numb = NumI;
               var i;
               var text2 = "";
               var date = DateI;
               var yr1 = parseInt(date.substring(0, 4));
               var mon1 = parseInt(date.substring(5, 7));
               var dt1 = parseInt(date.substring(8, 10));
               var Pamt = FamtP;
               var Pamt2 = SamtP;

               var Samt = FamtS;
               var Samt2 = SamtS;

               var sum1 = parseInt(Pamt) + parseInt(Samt);
               var sum2 = parseInt(Pamt2) + parseInt(Samt2);
               var textids = textid;
               //alert(yr1);
               //alert(mon1);
               // alert(dt1);
               //var s = yr1 + "-" + mon1 + "-" + dt1;
               var s = mon1 + "-" + dt1 + "-" + yr1;
               //alert(s);

               for (i = 1; i <= numb; i++) {
                  // alert("hi");
                   if (i == 1) {
                       var text = "Installment " + i + " " + "(" + sum1 + ")" + " USD on " + s;
                       //alert(text);
                   }
                   else {
                       if (mon1 >= 12) {
                           mon1 = 0;

                       }
                       //alert(mon1);
                       mon1 = mon1 + 1;
                      // var s2 = yr1 + "-" + mon1 + "-" + dt1;
                       var s2 = mon1 + "-" + dt1 + "-" + yr1;

                       text2 += "Installment " + i + " " + "(" + sum2 + ")" + " USD on " + s2 + ";" + " ";
                       // document.getElementById("t2").value = text2;
                   }
                   //alert(text2);
               }


               //document.getElementById("t1").value = text;
               //document.getElementById("t2").value = text2;
               document.getElementById(textids).value = text + "; " + text2;

           }



           //change focus

           function changefocus(Tid)
           {
               //alert('hi');
               var id = Tid;
               //alert(id);
               document.getElementById(id).focus();

           }

           function changeInstallNo(b1,b2)
           {
               document.getElementById(b1).style.display = "inline-block";
               document.getElementById(b2).style.display = "inline-block";
           }



           function contracttype()
           {
               //alert("hi");
               var conttype = document.getElementById("DropDownList40").value;

               if(conttype == "Fractional")
               {
                   //alert("Fractional");
                  // TextFOccuF
                   //TextFDuration
                   document.getElementById("item202a1").style.display = "none";
                   document.getElementById("item202b1").style.display = "none";
                   document.getElementById("item202a2").style.display = "none";
                   document.getElementById("item202b2").style.display = "none";
                   document.getElementById("TextFOccuF").value = '2018';
                   document.getElementById("TextFDuration").value = '15';
                   add1('TextFOccuF', 'TextFDuration', 'TextFOccuL');
                   document.getElementById("texte").style.display = 'none';
                   document.getElementById("remarkP").style.display = "none";
                   document.getElementById("PointsAdd").style.display = "none";
                   document.getElementById("remarkTP").style.display = "none";
                   document.getElementById("TPAdd").style.display = "none";
                   document.getElementById("cdiv3").style.display = 'none';
                   document.getElementById("cdiv2").style.display = 'none';
                   document.getElementById("cdiv1").style.display = 'block';
                   document.getElementById("cdiv4").style.display = 'none';
                   document.getElementById("cright").style.display = 'block';
                   document.getElementById("ffractional1").style.display = 'grid';
                   document.getElementById("remarks").style.display = 'Block';
                   document.getElementById("Points").style.display = 'none';
                   document.getElementById("tfractional").style.display = 'none';
                   document.getElementById("tpoints").style.display = 'none';
                   //document.getElementById("TextAdminFees").value = "";
                   //document.getElementById("TextMCFees").value = "";
                  // document.getElementById("PayMethodDropDownList").value = "";
                   //document.getElementById("FinanceCurrencyDropDownList").value = "";
                   //document.getElementById("TextRemarksP").value = "";
                   //document.getElementById("TextEuroRateP").value = "";
                   //document.getElementById("TextAusRateP").value = "";
                   //document.getElementById("TextGbpRateP").value = "";
                   //document.getElementById("TextIdaRateP").value = "";
                   document.getElementById("UsePayProtectCheckBox").checked = false;
                   document.getElementById("YearOfIntDropDownList").value = "";
    

                
               }
               else if (conttype == "Points")
               {
                   document.getElementById("item202a1").style.display = "none";
                   document.getElementById("item202b1").style.display = "none";
                   document.getElementById("item202a2").style.display = "none";
                   document.getElementById("item202b2").style.display = "none";
                   document.getElementById("TextPFOccu").value = '2018';
                   document.getElementById("TextPDura").value = '25';
                   add1('TextPFOccu', 'TextPDura', 'TextPLOccu');
                   document.getElementById("remarkP").style.display = 'block';
                   document.getElementById("PointsAdd").style.display = 'block';
                   document.getElementById("remarkTP").style.display = "none";
                   document.getElementById("TPAdd").style.display = "none";
                   document.getElementById("cdiv1").style.display = 'none';
                   document.getElementById("cdiv2").style.display = 'block';
                   document.getElementById("cdiv3").style.display = 'none';
                   document.getElementById("cdiv4").style.display = 'none';
                   document.getElementById("cright").style.display = 'block';
                   document.getElementById("ffractional1").style.display = 'none';
                   document.getElementById("Points").style.display = 'block';
                   document.getElementById("remarks").style.display = 'block';
                   document.getElementById("tfractional").style.display = 'none';
                   document.getElementById("tpoints").style.display = 'none';
                   //document.getElementById("TextAdminFees").value = "";
                  // document.getElementById("TextMCFees").value = "";
                   //document.getElementById("PayMethodDropDownList").value = "";
                   //document.getElementById("FinanceCurrencyDropDownList").value = "";
                   //document.getElementById("TextRemarksP").value = "";
                   //document.getElementById("TextEuroRateP").value = "";
                   //document.getElementById("TextAusRateP").value = "";
                   //document.getElementById("TextGbpRateP").value = "";
                   //document.getElementById("TextIdaRateP").value = "";
                   document.getElementById("UsePayProtectCheckBox").checked = false;
                   document.getElementById("YearOfIntDropDownList").value = "";
                   document.getElementById("texte").style.display = 'none';
  
               }
               else if (conttype == "Trade Into Fractional")
               {
                   document.getElementById("item202a1").style.display = "none";
                   document.getElementById("item202b1").style.display = "none";
                   document.getElementById("item202a2").style.display = "none";
                   document.getElementById("item202b2").style.display = "none";
                   document.getElementById("TextFYOccuTF").value = '2018';
                   document.getElementById("TextDurationTF").value = '15';
                   add1('TextFYOccuTF', 'TextDurationTF', 'TextLYOccuTF');
                   document.getElementById("remarkP").style.display = 'none';
                   document.getElementById("PointsAdd").style.display = 'none';
                   document.getElementById("cdiv1").style.display = 'none';
                   document.getElementById("cdiv2").style.display = 'none';
                   document.getElementById("cdiv3").style.display = 'block';
                   document.getElementById("cdiv4").style.display = 'none';
                   document.getElementById("cright").style.display = 'block';
                   document.getElementById("ffractional1").style.display = 'none';
                   document.getElementById("Points").style.display = 'none';
                   document.getElementById("remarks").style.display = 'block';
                   document.getElementById("tfractional").style.display = 'grid';
                   document.getElementById("tpoints").style.display = 'none';
                   //document.getElementById("TextAdminFees").value = "";
                  // document.getElementById("TextMCFees").value = "";
                   //document.getElementById("PayMethodDropDownList").value = "";
                   //document.getElementById("FinanceCurrencyDropDownList").value = "";
                   //document.getElementById("TextRemarksP").value = "";
                  // document.getElementById("TextEuroRateP").value = "";
                  // document.getElementById("TextAusRateP").value = "";
                  // document.getElementById("TextGbpRateP").value = "";
                  // document.getElementById("TextIdaRateP").value = "";
                   document.getElementById("UsePayProtectCheckBox").checked = false;
                   document.getElementById("YearOfIntDropDownList").value = "";
                   document.getElementById("TextAdminFeesP").value = document.getElementById("TextAdminFees").value;
                   document.getElementById("texte").style.display = 'none';
                   document.getElementById("remarkTP").style.display = 'none';
                   document.getElementById("TPAdd").style.display = 'none';
                  
               }
                  
               else if (conttype == "Choose Contract Type")
               {
                   document.getElementById("cdiv1").style.display = 'none';
                   document.getElementById("cdiv2").style.display = 'none';
                   document.getElementById("cdiv3").style.display = 'none';
                   document.getElementById("cdiv4").style.display = 'none';
                   document.getElementById("cright").style.display = 'none';
                   document.getElementById("b1").style.display = 'none';
                   document.getElementById("texte").style.display = 'none';

               }
               else if (conttype == "Trade Into Points")
               {
                   // alert("remarktp");

                   document.getElementById("item202a1").style.display = "none";
                   document.getElementById("item202b1").style.display = "none";
                   document.getElementById("item202a2").style.display = "none";
                   document.getElementById("item202b2").style.display = "none";
                   document.getElementById("TextFYOccTP").value = '2018';
                   document.getElementById("TextDurationTP").value = '25';
                   add1('TextFYOccTP', 'TextDurationTP', 'TextLYOccTP');
                   document.getElementById("remarkP").style.display = 'none';
                   document.getElementById("PointsAdd").style.display = 'none';
                   document.getElementById("remarkTP").style.display = "block";
                   document.getElementById("TPAdd").style.display = "block";
                   document.getElementById("cdiv1").style.display = 'none';
                   document.getElementById("cdiv2").style.display = 'none';
                   document.getElementById("cdiv3").style.display = 'none';
                   document.getElementById("cdiv4").style.display = 'block';
                   document.getElementById("cright").style.display = 'block';
                   document.getElementById("ffractional1").style.display = 'none';
                   document.getElementById("Points").style.display = 'none';
                   document.getElementById("remarks").style.display = 'block';
                   document.getElementById("tfractional").style.display = 'none';
                   document.getElementById("tpoints").style.display = 'block';
                   //document.getElementById("TextAdminFees").value = "";
                   //document.getElementById("TextMCFees").value = "";
                   //document.getElementById("PayMethodDropDownList").value = "";
                   //document.getElementById("FinanceCurrencyDropDownList").value = "";
                   //document.getElementById("TextRemarksP").value = "";
                   //document.getElementById("TextEuroRateP").value = "";
                   //document.getElementById("TextAusRateP").value = "";
                   //document.getElementById("TextGbpRateP").value = "";
                   //document.getElementById("TextIdaRateP").value = "";
                   document.getElementById("UsePayProtectCheckBox").checked = false;
                   document.getElementById("YearOfIntDropDownList").value = "";
                   document.getElementById("TextAdminFeesP").value = document.getElementById("TextAdminFees").value;
                   document.getElementById("texte").style.display = 'none';
            
               }

              
           }

           function entitlementP()
           {
               
               var ent = document.getElementById("EntitlementPoinDropDownList").value;
               var Currtype = document.getElementById("FinanceCurrencyDropDownList").value;

               Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 1500)
               if (ent == "ALTERNATE" && Currtype == "USD")
               {
                   document.getElementById("TextPMemFees").value = '154.5';
                   document.getElementById("TextPPropFees").value = '2.46';
                   document.getElementById("TextMCFees").value = '479.22';
                   
               }
               else if (ent == "FULL" && Currtype == "USD") {
                   document.getElementById("TextPMemFees").value = '309';
                   document.getElementById("TextPPropFees").value = '4.92';
                   document.getElementById("TextMCFees").value = '958.44';
               }

                   //not usd
             /*  else if (ent == "Alt" && Currtype != "USD") {
                   document.getElementById("TextPMemFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 154.5);
                   document.getElementById("TextPPropFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 2.46);
                   document.getElementById("TextMCFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 479.22);

               }
               else if (ent == "Full" && Currtype != "USD") {
                   document.getElementById("TextPMemFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 309);
                   document.getElementById("TextPPropFees").value =Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 4.92);
                   document.getElementById("TextMCFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 958.44);
               }*/
               
           }

           function entitlementTP() {

               var ent = document.getElementById("EntitlementTPoinDropDownList").value;
               var Currtype = document.getElementById("FinanceCurrencyDropDownList").value;
               if (ent == "ALTERNATE" && Currtype == "USD") {
                   document.getElementById("TextBox61").value = '154.5';
                   document.getElementById("TextBox62").value = '2.46';
                   document.getElementById("TextMCFees").value = '479.22';
               }
               else if (ent == "FULL" && Currtype == "USD") {
                   document.getElementById("TextBox61").value = '309';
                   document.getElementById("TextBox62").value = '4.92';
                   document.getElementById("TextMCFees").value = '958.44';
               }

               //not usd
              /* else if (ent == "Alt" && Currtype != "USD") {
                   document.getElementById("TextBox61").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 154.5);
                   document.getElementById("TextBox62").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 2.46);
                   document.getElementById("TextMCFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 479.22);
               }
               else if (ent == "Full" && Currtype != "USD") {
                   document.getElementById("TextBox61").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 309);
                   document.getElementById("TextBox62").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 4.92);
                   document.getElementById("TextMCFees").value = Math.round(parseFloat(document.getElementById("TextExchangeRate").value) * 958.44);
               }*/
           }
           

           function pay_method() {

               //var ent = document.getElementById("PayMethodDropDownList").value;
               var n1 = document.getElementById("PayMethodDropDownList");
               var ent = n1.options[n1.selectedIndex].text;

               var n = document.getElementById("DropDownList40");
               var pay = n.options[n.selectedIndex].text;

               if (ent == "Crown Finance") {
                   document.getElementById("item207").style.display = 'grid';
                   document.getElementById("item208").style.display = 'grid';
                   document.getElementById("item208a").style.display = 'grid';
                   document.getElementById("item208b").style.display = 'grid';
                   document.getElementById("item208c").style.display = 'grid';
                   document.getElementById("item208d").style.display = 'grid';
                   document.getElementById("item2017").style.display = 'grid';
                   document.getElementById("item2018").style.display = 'grid';

                   if (pay == "Points")
                   {
                       document.getElementById("PFina").style.display = 'block';
                       changeInstallNo('Button7', 'Button12');
                   }
                   else if (pay == "Fractional")
                   {
                       document.getElementById("FracFina").style.display = 'block';
                       changeInstallNo('Button9', 'Button13');
                   }
                   else if (pay == "Trade Into Fractional") {
                       document.getElementById("TFFina").style.display = 'block';
                       changeInstallNo('Button11', 'Button14');
                   }
                   else if (pay == "Trade Into Points") {
                       document.getElementById("TPFina").style.display = 'block';
                       changeInstallNo('Button10', 'tButton1');



                   }
                   //document.getElementById("pnumb").style.display = 'grid';
                  
               }
               else {
                   //document.getElementById("pnumb").style.display = 'none';
                   document.getElementById("item207").style.display = 'none';
                   document.getElementById("item208").style.display = 'none';
                   document.getElementById("item208a").style.display = 'none';
                   document.getElementById("item208b").style.display = 'none';
                   document.getElementById("item208c").style.display = 'none';
                   document.getElementById("item208d").style.display = 'none';
                   document.getElementById("item2017").style.display = 'none';
                   document.getElementById("item2018").style.display = 'none';
                   document.getElementById("item2017a").style.display = 'none';
                   document.getElementById("item2018a").style.display = 'none';
                   document.getElementById("item2017b").style.display = 'none';
                   document.getElementById("item2018b").style.display = 'none';

                   document.getElementById("PFina").style.display = 'none';
                   document.getElementById("FracFina").style.display = 'none';
                   document.getElementById("TFFina").style.display = 'none';
                   document.getElementById("TPFina").style.display = 'none';
               }
           }
          

       </script>

<script type="text/javascript">

    var l = 1;

    function f() {
        //var p = 1;




        l++;
        //alert(l);
        var s = 'item88s' + l;
        var p = 'item88p' + l;
        var q = 'item88q' + l;
        //alert('kkk');
        document.getElementById(s).style.display = "block";
        document.getElementById(p).style.display = "block";
        document.getElementById(q).style.display = "block";
        //alert('kkk');
        if (l == '7') {
            document.getElementById("bittu").style.display = "none";
            //alert('kkk');
        }

    }


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

    function shows4chs4() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs4');
        //var Currtype = document.getElementById("FinanceCurrencyDropDownList").value;

        var n = document.getElementById("FinanceCurrencyDropDownList");
        var Currtype = n.options[n.selectedIndex].text;
        //alert(Currtype);
        if (checkbox2.checked) {
           // alert('checkd');
            if (Currtype == 'USD')
            {
                //indiadetails
               // alert("usd yes");
                //document.getElementById('usddetails').style.display = 'grid';
                //document.getElementById('indiadetails').style.display = 'none';
                document.getElementById('item111').style.display = 'grid';
                document.getElementById('item112').style.display = 'grid';
                document.getElementById('item101').style.display = 'none';
                document.getElementById('item102').style.display = 'none';
                document.getElementById('item103').style.display = 'none';
                document.getElementById('item104').style.display = 'none';
               // document.getElementById("pan").style.display = "block";
                //document.getElementById("adhar").style.display = "block";
                document.getElementById('no').style.display = 'block';
                document.getElementById('yes').style.display = 'none';
            }
            else if (Currtype == 'INR')
            {
               //alert("not usd yes");
                document.getElementById('item111').style.display = 'none';
                document.getElementById('item112').style.display = 'none';
                document.getElementById('item101').style.display = 'grid';
                document.getElementById('item102').style.display = 'grid';
                document.getElementById('item103').style.display = 'grid';
                document.getElementById('item104').style.display = 'grid';
                // document.getElementById("pan").style.display = "block";
                //document.getElementById("adhar").style.display = "block";
                document.getElementById('no').style.display = 'block';
                document.getElementById('yes').style.display = 'none';
            }
        }
        else {
            //alert("no");
            document.getElementById('item111').style.display = 'none';
            document.getElementById('item112').style.display = 'none';
            document.getElementById('item101').style.display = 'none';
            document.getElementById('item102').style.display = 'none';
            document.getElementById('item103').style.display = 'none';
            document.getElementById('item104').style.display = 'none';
            document.getElementById("no").style.display = "none";
            document.getElementById("yes").style.display = "block";

        }

    }

    function shows5() {
       // alert("shows5");
        var checkbox2 = document.getElementById('chs5');

        if (checkbox2.checked) {

           
            document.getElementById("no1").style.display = "none";
            document.getElementById("yes1").style.display = "block";
            document.getElementById("yess1").style.display = "block";
        }
        else {
          
            document.getElementById("no1").style.display = "block";
            document.getElementById("yes1").style.display = "none";
            document.getElementById("yess1").style.display = "none";

        }

    }
    function shows6() {
        //alert("shows5");
        var checkbox2 = document.getElementById('chs6');

        if (checkbox2.checked) {


            document.getElementById("no2").style.display = "none";
            document.getElementById("yes2").style.display = "block";
            document.getElementById("yess2").style.display = "block";
        }
        else {

            document.getElementById("no2").style.display = "block";
            document.getElementById("yes2").style.display = "none";
            document.getElementById("yess2").style.display = "none";

        }

    }
    
    /*add value*/

    function addvalue1() {
        
        //var j = pp;
        var checkbox3 = document.getElementById('ca1');
        var text = document.getElementById("TextAdminFees").value;
        if (checkbox3.checked) {
            var result = parseInt(text) + 100;
            document.getElementById("TextAdminFees").value = result;
            document.getElementById("TextICE").value = '1';
        }
        else {
            
            document.getElementById("TextAdminFees").value = parseInt(text) - 100;
            document.getElementById("TextICE").value = '0';
        }
    }

    function addvalue2() {

        //var j = pp;
        var checkbox4 = document.getElementById('ca2');
        var text = document.getElementById("TextAdminFees").value;
        if (checkbox4.checked) {
            var result = parseInt(text) + 40;
            document.getElementById("TextAdminFees").value = result;
            document.getElementById("TextHP").value = '1';
        }
        else {

            document.getElementById("TextAdminFees").value = parseInt(text) - 40;
            document.getElementById("TextHP").value = '0';
            
        }
    }

    function add1(t1,t2,t3)
    {
        var q1 = t1;
        var q2 = t2;
        var q3 = t3;
        var text1 = document.getElementById(q1).value;
        var text2 = document.getElementById(q2).value;
        
        var text3 = parseInt(text1) + (parseInt(text2) - 1);
       // alert(text3);
        if (text3 < 0)
        {
            document.getElementById(q3).value = "0";
        }
        else
        {
            document.getElementById(q3).value = text3;
        }
    }

    function lease_back(p1,p2)
    {
        var g1 = p1;
        var g2 = p2;
        var checkbox2 = document.getElementById(p1);

        if (checkbox2.checked) {

            document.getElementById(p2).value = 0;

        }
        else {
            document.getElementById(p2).value = "";
        }

    }

    function CCpurpose(checkID, TextID) {
        //var k1 = p1;
        //var k2 = p2;
        //alert(checkID);
        //alert(TextID);
        var checkbox2 = document.getElementById(checkID);

        if (checkbox2.checked) {

            document.getElementById(TextID).value = 1;

        }
        else {
            document.getElementById(TextID).value = 0;
        }

    }
</script>



       <script type="text/javascript">

           function b1cclick()
           {
               var b1cp = document.getElementById('b1c');
               if (b1cp.checked)
               {
                   btnclick();
               }
           }

// Get the modal
var modal = document.getElementById('myModal');

// Get the button that opens the modal
var btn = document.getElementById("myBtn2");

// Get the <span> element that closes the modal
//var span = document.getElementsByClassName("close")[0];
var span = document.getElementsById('class1');

var label = document.getElementById('close1');


// When the user clicks the button, open the modal 
/*btn.onclick = function() {
    modal.style.display = "block";
    return false;
}*/
function btnclick()
{
    //alert("bcl");
    var modal = document.getElementById('myModal');
    modal.style.display = "block";
    /*var span = document.getElementsById('class1');
    span.onclick = function () {
        modal.style.display = "none";
     }*/
    var label = document.getElementById('close1');
    label.onclick = function () {
        //alert("label");
        modal.style.display = "none";
    }

    window.onclick = function (event) {
        //alert("out");
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

}





           // check date for cases pertaining to different months

function caldays(d, m, y) {
    //alert(d + "  " + m + "  " + y);
    //alert('hi');

    var dmax;
    if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12) {
        if(d > 31)
        {	
            dmax = 31;
        }
        else {
            dmax = d;
        }
        //alert('dmax1');		
        //alert(dmax);	
        //return dmax;	        

    }
    else if (m == 4 || m == 6 || m == 9 || m == 11) {
        if (d > 30) {
            dmax = 30;
        }
        else {
            dmax = d;
        }
        //return dmax;	
        //alert('dmax2');	  
        //alert(dmax);

    }
    else if (m == 2) {
        //alert('dmax3');

        if ((y % 4 == 0) || (y % 400 == 0 && y % 100 != 0)) {
            if (d > 29) {
                dmax = 29;
            }
            else {
                dmax = d;
            }
            //return dmax;

        }
        else {
            if (d > 28) {
                dmax = 28;
            }
            else {
                dmax = d;
            }
        }
        //return dmax;*/
        //alert(dmax);
    }

    if (m == 1) {
        //alert('hi');
        m = '01';
    }
    else if (m == 2) {
        m = '02';
    }
    else if (m == 3) {
        m = '03';
    }
    else if (m == 4) {
        m = '04';
    }
    else if (m == 5) {
        m = '05';
    }
    else if (m == 6) {
        m = '06';
    }
    else if (m == 7) {
        m = '07';
    }
    else if (m == 8) {
        m = '08';
    }
    else if (m == 9) {
        m = '09';
    }



    if (dmax == 1) {
        //alert('hi');
        dmax = '01';
    }
    else if (dmax == 2) {
        dmax = '02';
    }
    else if (dmax == 3) {
        dmax = '03';
    }
    else if (dmax == 4) {
        dmax = '04';
    }
    else if (dmax == 5) {
        dmax = '05';
    }
    else if (dmax == 6) {
        dmax = '06';
    }
    else if (dmax == 7) {
        dmax = '07';
    }
    else if (dmax == 8) {
        dmax = '08';
    }
    else if (dmax == 9) {
        dmax = '09';
    }

    //var k = dmax+"-"+m+"-"+y;
    //var k = m + "-" + dmax + "-" + y;
    var k = dmax + "-" + m + "-" + y;
    // var k =  + "-" + m + "-" + y;
    //var k = y + "-" + m + "-" + dmax;
    //alert(k);

    return k;



}





           //to get invoices


function datetoi(numi,datei,famt,samt,globv,balanceamtv) {
   // alert('dateoi' + globv + '   ' + balanceamtv);
    //var numb =2;
    //alert("datetoi");
    document.getElementById("ch").innerHTML = "";
    document.getElementById("ch1").innerHTML = "";

    var n1 = parseInt(numi);
    //alert(n1);
    var i, j, k, l, s3, m, y, x, n, qqq, e,ll;
    var text2 = "";
    var texts2 = "";
    var text3 = "";
    var text4 = "";
    //var date = "2017-10-30";
    //var date = "07-12-2017";
    var date = datei;
   var yr1 = parseInt(date.substring(6, 10));
    var mon1 = parseInt(date.substring(3, 5));
    var dt1 = parseInt(date.substring(0, 2));

    //var yr1 = parseInt(date.substring(0, 4));
    //var mon1 = parseInt(date.substring(5, 7));
    //var dt1 = parseInt(date.substring(8, 10));
   // var amt = 108;
    //var amt2 = 107;
    var amt = famt;
    var amt2 = samt;
    var smon1;
    var syr1, tsyr1;
    var zy,kzy;

    //var a = parseInt(document.getElementById("nochapter").value);
    //var ch = document.getElementById("t6");
    //alert('before' + date);
   // alert(dt1 + "-" + mon1 + "-" + yr1);
    kzy = caldays(dt1, mon1, yr1);
    //alert(yr1);
    //alert(mon1);
    // alert(dt1);
    var s = kzy;//yr1 + "-" + mon1 + "-" + dt1;
    //var s = mon1 + "-" + dt1 + "-" + yr1;
    //var s = dt1 + "-" + mon1 + "-" + yr1;
   // alert('after'+s);

    smon1 = mon1;
    syr1 = yr1;

   
    var dropval = document.getElementById("DropDownList40").value;
   // alert(dropval);
    if (dropval == "Points") {


        for (i = 1 ; i <= n1; i++) {
            //alert("hi2");
            if (i == 1) {
                var text = "Installment " + i + " " + amt + " USD on " + s;
                //alert(text);
            }
            else {
                if (mon1 >= 12) {
                    mon1 = 0;

                }
                //alert(mon1);
                mon1 = mon1 + 1;
                //var s2 = yr1 + "-" + mon1 + "-" + dt1;
                //z = caldays(dt1, mon1, yr1);
                //var s2 = dt1 + "-" + mon1 + "-" + yr1;
                var s2 = yr1 + "-" + mon1 + "-" + dt1;
                //var s2 = z;
                text2 += "Installment " + i + " " + amt2 + " USD on " + s2 + ";" + " ";
                // document.getElementById("t2").value = text2;
            }


        }


        for (k = 1; k <= n1 ; k++) {
            //alert('f1');
            //alert(amt);

            for (l = 1; l < 5; l++) {

                var input = document.createElement("input");
                input.type = 'text';
                input.id = 'textBox_' + k + l;
                input.name = 'textBox_' + k + l;
                //input.value = 'hi' + k + '4';
                input.onkeyup = function () { sum(globv, balanceamtv); };
                ch.appendChild(input);
                var id1 = input.name;
                var tid1 = input.id;
                //alert(id1);
               

            }
            var space1 = document.createElement("BR");
            var space2 = document.createElement("BR");
            ch.appendChild(space1);
            ch.appendChild(space2);


            //this is for dummy installment for SA and PA
            for (ll = 1; ll < 5; ll++) {

                var input = document.createElement("input");
                input.type = 'text';
                input.id = 'textBoxN_' + k + ll;
                //input.value = 'textBoxN_' + k + ll;
                input.name = 'textBoxN_' + k + ll;
                // input.onkeyup=function() {sum();};
                ch1.appendChild(input);
                var id2 = input.id;
                //alert(id1);

            }
            var spaceN1 = document.createElement("BR");
            var spaceN2 = document.createElement("BR");
            ch1.appendChild(spaceN1);
            ch1.appendChild(spaceN2);


            var z = 'textBox_' + k + '1';
            var z2 = 'textBoxN_' + k + '1';
            var xz = 'textBox_' + k + '4';
            var xz2 = 'textBoxN_' + k + '4';
            //alert("Z"+z);
            if (k == "1") {
                //alert('k=1');
                y = 'textBox_' + k + '2';
                //alert("y"+y);
                document.getElementById(y).value = amt;
                m = 'textBox_' + k + '3';
                //alert("m"+m);
                qqq = 'Installment' + k;
            }
            else {
                x = 'textBox_' + k + '2';
                n = 'textBox_' + k + '3';




                //alert(z+" x "+x+" n "+n);

                //alert("y2"+y); 

                qqq = 'Installment' + k;
                //alert(smon1);
                if (smon1 >= 12) {
                    //alert("smon1=1");
                    smon1 = 1;
                    syr1 = syr1 + 1;;

                }
                else {
                    smon1 = smon1 + 1;
                   
                }
                // s3 = syr1 + "-" + smon1 + "-" + dt1;
                //alert(syr1);
                zy = caldays(dt1, smon1, syr1);
                 //s3 = smon1 + "-" + dt1 + "-" + syr1;
                s3 = zy;
                document.getElementById(x).value = amt2;
                document.getElementById(n).value = s3;
                //alert("later");
                //alert(qqq);
                //alert(z+" "+x+" "+m+" "+n+" "+s+" "+s3);
            }
            document.getElementById(z).value = qqq;
            //alert('plk');
           // document.getElementById(z).readOnly = true;
            //alert('pk');
            document.getElementById(z2).value = qqq;
            //document.getElementById(z).disabled = true;
            //document.getElementById(z2).disabled = true;

            var n23 = document.getElementById("FinanceCurrencyDropDownList");
            var nnnn = n23.options[n23.selectedIndex].text;

            document.getElementById(xz).value = nnnn;
            document.getElementById(xz2).value = nnnn;
            //document.getElementById(y).value = amt;
            //document.getElementById(x).value = amt2;
            document.getElementById(m).value = s;

            //document.getElementById(n).value = s3;


        }
    }

    else if(dropval=="Fractional")
    {
       // alert("Fractional");
        for (i = 1 ; i <= n1; i++) {
            //alert("hi2");
            if (i == 1) {
                var text = "Installment " + i + " " + amt + " USD on " + s;
                //alert(text);
            }
            else {
                if (mon1 >= 12) {
                    mon1 = 0;

                }
                //alert(mon1);
                mon1 = mon1 + 1;
                //var s2 = yr1 + "-" + mon1 + "-" + dt1;
                z = caldays(dt1, mon1, yr1);
                // var s2 = mon1 + "-" + dt1 + "-" + yr1;
                var s2 = z;

                text2 += "Installment " + i + " " + amt2 + " USD on " + s2 + ";" + " ";
                // document.getElementById("t2").value = text2;
            }


        }


        for (k = 1; k <= n1 ; k++) {
            //alert('f1');
            //alert(amt);

            for (l = 1; l < 5; l++) {

                var input = document.createElement("input");
                input.type = 'text';
                input.id = 'textBox_' + k + l;
                input.name = 'textBox_' + k + l;
                //input.value = 'hi' + k + '4';
                input.onkeyup = function () { sum(globv, balanceamtv); };
                ch.appendChild(input);
                var id1 = input.name;
                //alert(id1);

            }
            var space1 = document.createElement("BR");
            var space2 = document.createElement("BR");
            ch.appendChild(space1);
            ch.appendChild(space2);


            //this is for dummy installment for SA and PA
            for (ll = 1; ll < 5; ll++) {

                var input = document.createElement("input");
                input.type = 'text';
                input.id = 'textBoxN_' + k + ll;
                //input.value = 'textBoxN_' + k + ll;
                input.name = 'textBoxN_' + k + ll;
                // input.onkeyup=function() {sum();};
                ch1.appendChild(input);
                var id2 = input.id;
                //alert(id1);

            }
            var spaceN1 = document.createElement("BR");
            var spaceN2 = document.createElement("BR");
            ch1.appendChild(spaceN1);
            ch1.appendChild(spaceN2);


            var z = 'textBox_' + k + '1';
            var z2 = 'textBoxN_' + k + '1';
            var xz = 'textBox_' + k + '4';
            var xz2 = 'textBox_' + k + '4';
            //alert("Z"+z);
            if (k == "1") {
                //alert('k=1');
                y = 'textBox_' + k + '2';
                //alert("y"+y);
                document.getElementById(y).value = amt;
                m = 'textBox_' + k + '3';
                //alert("m"+m);
                qqq = 'Installment' + k;
            }
            else {
                x = 'textBox_' + k + '2';
                n = 'textBox_' + k + '3';




                //alert(z+" x "+x+" n "+n);

                //alert("y2"+y); 

                qqq = 'Installment' + k;
                //alert(smon1);
                if (smon1 >= 12) {
                    //alert("smon1=1");
                    smon1 = 1;
                    syr1 = syr1 + 1;;

                }
                else {
                    smon1 = smon1 + 1;
                    //tsyr1 = syr1 + 1;
                    //alert("inc");
                    // alert(smon1);
                    //s3 = yr1+"-"+smon1+"-"+dt1;
                }
                // s3 = syr1 + "-" + smon1 + "-" + dt1;
                zy = caldays(dt1, smon1, syr1);
                //s3 = smon1 + "-" + dt1 + "-" + syr1;
                s3 = zy;
                document.getElementById(x).value = amt2;
                document.getElementById(n).value = s3;
                //alert("later");
                //alert(qqq);
                //alert(z+" "+x+" "+m+" "+n+" "+s+" "+s3);
            }
            document.getElementById(z).value = qqq;
            document.getElementById(z2).value = qqq;

            //document.getElementById(z).disabled = true;
            //document.getElementById(z2).disabled = true;
            var n23 = document.getElementById("FinanceCurrencyDropDownList");
            var nnnn = n23.options[n23.selectedIndex].text;

            document.getElementById(xz).value = nnnn;
            document.getElementById(xz2).value = nnnn;
            //document.getElementById(y).value = amt;
            //document.getElementById(x).value = amt2;
            document.getElementById(m).value = s;

            //document.getElementById(n).value = s3;


        }
    }

    else if (dropval == "Trade Into Fractional") {
        // alert("Fractional");
        for (i = 1 ; i <= n1; i++) {
            //alert("hi2");
            if (i == 1) {
                var text = "Installment " + i + " " + amt + " USD on " + s;
                //alert(text);
            }
            else {
                if (mon1 >= 12) {
                    mon1 = 0;

                }
                //alert(mon1);
                mon1 = mon1 + 1;
                //var s2 = yr1 + "-" + mon1 + "-" + dt1;
                z = caldays(dt1, mon1, yr1);
                // var s2 = mon1 + "-" + dt1 + "-" + yr1;
                var s2 = z;

                text2 += "Installment " + i + " " + amt2 + " USD on " + s2 + ";" + " ";
                // document.getElementById("t2").value = text2;
            }


        }


        for (k = 1; k <= n1 ; k++) {
            //alert('f1');
            //alert(amt);

            for (l = 1; l < 5; l++) {

                var input = document.createElement("input");
                input.type = 'text';
                input.id = 'textBox_' + k + l;
                input.name = 'textBox_' + k + l;
                //input.value = 'hi' + k + '4';
                input.onkeyup = function () { sum(globv, balanceamtv); };
                ch.appendChild(input);
                var id1 = input.name;
                //alert(id1);

            }
            var space1 = document.createElement("BR");
            var space2 = document.createElement("BR");
            ch.appendChild(space1);
            ch.appendChild(space2);


            //this is for dummy installment for SA and PA
            for (ll = 1; ll < 5; ll++) {

                var input = document.createElement("input");
                input.type = 'text';
                input.id = 'textBoxN_' + k + ll;
                //input.value = 'textBoxN_' + k + ll;
                input.name = 'textBoxN_' + k + ll;
                // input.onkeyup=function() {sum();};
                ch1.appendChild(input);
                var id2 = input.id;
                //alert(id1);

            }
            var spaceN1 = document.createElement("BR");
            var spaceN2 = document.createElement("BR");
            ch1.appendChild(spaceN1);
            ch1.appendChild(spaceN2);


            var z = 'textBox_' + k + '1';
            var z2 = 'textBoxN_' + k + '1';
            var xz = 'textBox_' + k + '4';
            var xz2 = 'textBoxN_' + k + '4';
            //alert("Z"+z);
            if (k == "1") {
                //alert('k=1');
                y = 'textBox_' + k + '2';
                //alert("y"+y);
                document.getElementById(y).value = amt;
                m = 'textBox_' + k + '3';
                //alert("m"+m);
                qqq = 'Installment' + k;
            }
            else {
                x = 'textBox_' + k + '2';
                n = 'textBox_' + k + '3';




                //alert(z+" x "+x+" n "+n);

                //alert("y2"+y); 

                qqq = 'Installment' + k;
                //alert(smon1);
                if (smon1 >= 12) {
                    //alert("smon1=1");
                    smon1 = 1;
                    syr1 = syr1 + 1;;

                }
                else {
                    smon1 = smon1 + 1;
                    //tsyr1 = syr1 + 1;
                    //alert("inc");
                    // alert(smon1);
                    //s3 = yr1+"-"+smon1+"-"+dt1;
                }
                // s3 = syr1 + "-" + smon1 + "-" + dt1;
                zy = caldays(dt1, smon1, syr1);
                //s3 = smon1 + "-" + dt1 + "-" + syr1;
                s3 = zy;
                document.getElementById(x).value = amt2;
                document.getElementById(n).value = s3;
                //alert("later");
                //alert(qqq);
                //alert(z+" "+x+" "+m+" "+n+" "+s+" "+s3);
            }
            document.getElementById(z).value = qqq;
            document.getElementById(z2).value = qqq;

           // document.getElementById(z).disabled = true;
           // document.getElementById(z2).disabled = true;
            var n23 = document.getElementById("FinanceCurrencyDropDownList");
            var nnnn = n23.options[n23.selectedIndex].text;

            document.getElementById(xz).value = nnnn;
            document.getElementById(xz2).value = nnnn;
            //document.getElementById(y).value = amt;
            //document.getElementById(x).value = amt2;
            document.getElementById(m).value = s;

            //document.getElementById(n).value = s3;


        }
    }


    else if (dropval == "Trade Into Points") {


        for (i = 1 ; i <= n1; i++) {
            //alert("hi2");
            if (i == 1) {
                var text = "Installment " + i + " " + amt + " USD on " + s;
                //alert(text);
            }
            else {
                if (mon1 >= 12) {
                    mon1 = 0;

                }
                //alert(mon1);
                mon1 = mon1 + 1;
                //var s2 = yr1 + "-" + mon1 + "-" + dt1;
                z = caldays(dt1, mon1, yr1);
                // var s2 = mon1 + "-" + dt1 + "-" + yr1;
                var s2 = z;

                text2 += "Installment " + i + " " + amt2 + " USD on " + s2 + ";" + " ";
                // document.getElementById("t2").value = text2;
            }


        }


        for (k = 1; k <= n1 ; k++) {
            //alert('f1');
            //alert(amt);

            for (l = 1; l < 5; l++) {

                var input = document.createElement("input");
                input.type = 'text';
                input.id = 'textBox_' + k + l;
                input.name = 'textBox_' + k + l;
                //input.value = 'hi' + k + '4';
                input.onkeyup = function () { sum(globv, balanceamtv); };
                ch.appendChild(input);
                var id1 = input.name;
                //alert(id1);

            }
            var space1 = document.createElement("BR");
            var space2 = document.createElement("BR");
            ch.appendChild(space1);
            ch.appendChild(space2);


            //this is for dummy installment for SA and PA
            for (ll = 1; ll < 5; ll++) {

                var input = document.createElement("input");
                input.type = 'text';
                input.id = 'textBoxN_' + k + ll;
                //input.value = 'textBoxN_' + k + ll;
                input.name = 'textBoxN_' + k + ll;
                // input.onkeyup=function() {sum();};
                ch1.appendChild(input);
                var id2 = input.id;
                //alert(id1);

            }
            var spaceN1 = document.createElement("BR");
            var spaceN2 = document.createElement("BR");
            ch1.appendChild(spaceN1);
            ch1.appendChild(spaceN2);


            var z = 'textBox_' + k + '1';
            var z2 = 'textBoxN_' + k + '1';
            var xz = 'textBox_' + k + '4';
            var xz2 = 'textBoxN_' + k + '4';
            //alert("Z"+z);
            if (k == "1") {
                //alert('k=1');
                y = 'textBox_' + k + '2';
                //alert("y"+y);
                document.getElementById(y).value = amt;
                m = 'textBox_' + k + '3';
                //alert("m"+m);
                qqq = 'Installment' + k;
            }
            else {
                x = 'textBox_' + k + '2';
                n = 'textBox_' + k + '3';




                //alert(z+" x "+x+" n "+n);

                //alert("y2"+y); 

                qqq = 'Installment' + k;
                //alert(smon1);
                if (smon1 >= 12) {
                    //alert("smon1=1");
                    smon1 = 1;
                    syr1 = syr1 + 1;;

                }
                else {
                    smon1 = smon1 + 1;
                    //tsyr1 = syr1 + 1;
                    //alert("inc");
                    // alert(smon1);
                    //s3 = yr1+"-"+smon1+"-"+dt1;
                }
                // s3 = syr1 + "-" + smon1 + "-" + dt1;
                zy = caldays(dt1, smon1, syr1);
                //s3 = smon1 + "-" + dt1 + "-" + syr1;
                s3 = zy;
                document.getElementById(x).value = amt2;
                document.getElementById(n).value = s3;
                //alert("later");
                //alert(qqq);
                //alert(z+" "+x+" "+m+" "+n+" "+s+" "+s3);
            }
            document.getElementById(z).value = qqq;
            document.getElementById(z2).value = qqq;

            //document.getElementById(z).disabled = true;
           // document.getElementById(z2).disabled = true;
            var n23 = document.getElementById("FinanceCurrencyDropDownList");
            var nnnn = n23.options[n23.selectedIndex].text;

            document.getElementById(xz).value = nnnn;
            document.getElementById(xz2).value = nnnn;
            //document.getElementById(y).value = amt;
            //document.getElementById(x).value = amt2;
            document.getElementById(m).value = s;

            //document.getElementById(n).value = s3;


        }
    }
}

function sum(numi,bamt) {
    //alert("bamt" + bamt);
    //alert(numi+"    "+bamt);
    var t23 = "";
    var pe;
    var sum = 0;
    var pam = bamt;

    for (pe = 1; pe <= numi; pe++) {
        sum = sum + parseInt(document.getElementById("textBox_" + pe + "2").value);
        //t23 += parseInt(document.getElementById("textBox_"+pe+"2").value);
    }
   // alert(sum);
    document.getElementById('t45').value = parseInt(pam) - sum;

}


function print() {

   // alert('hi');
    var text13 = "";
    //alert("hi");
    //alert("textBox_"+"1");
    //alert(numb);
    var k = "";
    var m = document.getElementById("PayMethodDropDownList");
    var paym = m.options[m.selectedIndex].text;
    // var v1 = document.getElementById("DealDrawerDropDownList");

    var n = document.getElementById("DropDownList40");
    var payn = n.options[n.selectedIndex].text;

    

    
    //alert(paym);
    for (e = 1; e <= glob; e++) {   //alert("hi"+e); 
        // text3 ="eee";
        //alert(text13);
        // var qq = 'textBox_'+e+'1';


        if (e == glob) {
            if (paym == "Crown Finance") {
                text13 += document.getElementById("textBox_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBox_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + " By Crown Finance LTD. " + document.getElementById("TextContractNumb").value + "/" + document.getElementById("TextPnumb").value + ";";
            }
            else {
                text13 += document.getElementById("textBox_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBox_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
            }

        }
        else {

            text13 += document.getElementById("textBox_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBox_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
        }

       //  alert(text13);

        //alert(qq);
        //alert(text3);

    }
    //document.getElementById('t44').value = text13;
    

    
    if (payn == "Points") {
        document.getElementById('TextRemarkP').value = text13;
    }
    else if (payn == "Fractional")
    {
        document.getElementById('TextRemarksF').value = text13;
    }
    else if (payn == "Trade Into Fractional")
    {
        document.getElementById('TextRemarksTF').value = text13;
    }
    else if (payn == "Trade Into Points") {
        //alert(text13);
        var j = "TextRemarksTP";
        //alert(j);
        //document.getElementById("TextRemarksTP").value = "hi";
        //document.getElementById('TextRemarksTP').value = text13;
        //document.getElementById('TextRemarksTP').value = text13;
        //var d = document.getElementById(j).value;
       // alert(d);
        document.getElementById(j).value = text13;
       // alert(document.getElementById(j).value);
        //k = text13;
    }
    //document.getElementById("TextRemarkTP").value = "hi";
    //alert('hieeee');
    var modal = document.getElementById('myModal');
    modal.style.display = "none";

    gendetails();

    //alert('hi');
}

function gendetails()
{
    //alert('into gendetails ');
    var n2 = document.getElementById("DropDownList40");
    var drop = n2.options[n2.selectedIndex].text;

    if (drop == "Fractional")
    {

        document.getElementById('fcurrTP').style.display = "inline-block";
        document.getElementById('fcurrQD').style.display = "inline-block";
        document.getElementById('fcurrAC').style.display = "inline-block";

        //alert('helo');
        var curramt;
        var n = document.getElementById("CrownFinanceCurrDropDownList");
        var payn = n.options[n.selectedIndex].text;

        document.getElementById("TotalPurTextBoxFFC").value = document.getElementById("TextPurchasePrice").value;

        var k = document.getElementById("textBox_" + glob + "2").value;

        document.getElementById("AmountCreditTextBoxFFC").value = k;

        document.getElementById("QualTextBoxFFC").value = parseInt(document.getElementById("TextPurchasePrice").value) - parseInt(k);

        if (payn == "USD") {
            curramt = '1';
            //curramt = document.getElementById("TextAusRateP").value;
            document.getElementById('fcurr1CAC').style.display = "inline-block";
            document.getElementById('fcurr1MP').style.display = "inline-block";
        }
        else if (payn == "AUD") {
            curramt = document.getElementById("TextAusRateP").value;
            document.getElementById('fcurr3CAC').style.display = "inline-block";
            document.getElementById('fcurr3MP').style.display = "inline-block";
        }
        else if (payn == "EUR") {
            curramt = document.getElementById("TextEuroRateP").value;
            document.getElementById('fcurr2CAC').style.display = "inline-block";
            document.getElementById('fcurr2MP').style.display = "inline-block";
        }
        else if (payn == "GBP") {
            curramt = document.getElementById("TextGbpRateP").value;
            document.getElementById('fcurr4CAC').style.display = "inline-block";
            document.getElementById('fcurr4MP').style.display = "inline-block";
        }


        document.getElementById("AmountCreditCurrTextBoxFFC").value = (parseFloat(document.getElementById("AmountCreditTextBoxFFC").value) * parseFloat(curramt)).toFixed(2);

        var p = document.getElementById("YearOfIntDropDownList");
        var yoi = p.options[p.selectedIndex].text;
        var yoi2,month2;
        //alert(yoi);

        var yr1 = parseInt(yoi.substring(0, 2));

        //alert(yr1);
        if (yr1 == "2") {
            yoi2 = '14';
            month2 = '2';
            //alert('2 Years	14%');
        }
        else if (yr1 == "3") {
            yoi2 = '17';
            month2 = '3';
        }
        else {
            yoi2 = '19';
            month2 = '5';
        }
       // alert(month2);
        document.getElementById("RateInterestTextBoxFFC").value = yoi2;
        document.getElementById("NoMonthsTextBoxFFC").value = parseInt(month2) * 12;

        var pp = document.getElementById("AmountCreditCurrTextBoxFFC").value;
        var term = document.getElementById("NoMonthsTextBoxFFC").value;
        var int = parseInt(document.getElementById("RateInterestTextBoxFFC").value) / 1200;

        document.getElementById("MonthRepayTextBoxFFC").value = ((pp * int) / (1 - (Math.pow(1 / (1 + int), term)))).toFixed(2);



        document.getElementById("tPurchase").value = document.getElementById("TotalPurTextBoxFFC").value;
        document.getElementById("QDepo").value = document.getElementById("QualTextBoxFFC").value;
        document.getElementById("AmtCre").value = document.getElementById("AmountCreditTextBoxFFC").value;
        document.getElementById("CreCurr").value = document.getElementById("AmountCreditCurrTextBoxFFC").value;
        
        document.getElementById("NoOfMonth").value = document.getElementById("NoMonthsTextBoxFFC").value;
        document.getElementById("RateOfInt").value = document.getElementById("RateInterestTextBoxFFC").value;
        document.getElementById("MonthlyRepay").value = document.getElementById("MonthRepayTextBoxFFC").value;
        

        
    }
    else if (drop == "Points")
    {
        //alert('points 1');
        document.getElementById('pcurrTP').style.display = "inline-block";
        document.getElementById('pcurrQD').style.display = "inline-block";
        document.getElementById('pcurrAC').style.display = "inline-block";

        var curramt;
        var n = document.getElementById("CrownFinanceCurrDropDownList");
        var payn = n.options[n.selectedIndex].text;

        //alert(payn+'         '+glob);

        document.getElementById("TotalPurTextBoxPFC").value = document.getElementById("TextPurchasePrice").value;

        var k = document.getElementById("textBox_" + glob + "2").value;

       // alert('1234ff' + k);

        document.getElementById("AmountCreditTextBoxPFC").value = k;

        document.getElementById("QualTextBoxPFC").value = parseInt(document.getElementById("TextPurchasePrice").value) - parseInt(k);
        //alert('kkk'+payn);
        if (payn == "USD") {
            curramt = '1';
            //curramt = document.getElementById("TextAusRateP").value;
            document.getElementById('pcurr1CAC').style.display = "inline-block";
            document.getElementById('pcurr1MP').style.display = "inline-block";
        }
        else if (payn == "AUD") {
            curramt = document.getElementById("TextAusRateP").value;
            document.getElementById('pcurr3CAC').style.display = "inline-block";
            document.getElementById('pcurr3MP').style.display = "inline-block";
        }
        else if (payn == "EUR") {
            curramt = document.getElementById("TextEuroRateP").value;
            document.getElementById('pcurr2CAC').style.display = "inline-block";
            document.getElementById('pcurr2MP').style.display = "inline-block";
        }
        else if (payn == "GBP") {
            curramt = document.getElementById("TextGbpRateP").value;
            document.getElementById('pcurr4CAC').style.display = "inline-block";
            document.getElementById('pcurr4MP').style.display = "inline-block";
        }

       // alert('points 2');
        document.getElementById("AmountCreditCurrTextBoxPFC").value = (parseFloat(document.getElementById("AmountCreditTextBoxPFC").value) * parseFloat(curramt)).toFixed(2);
        //alert("yoip");
        var p = document.getElementById("YearOfIntDropDownList");
        var yoi = p.options[p.selectedIndex].text;
        var yoi2,month2;
        //alert("yoi"+yoi);

        var yr1 = parseInt(yoi.substring(0, 2));

        //alert(yr1);
        if (yr1 == "2") {
            yoi2 = '14';
            month2 = '2';
            //alert('2 Years	14%');
        }
        else if (yr1 == "3") {
            yoi2 = '17';
            month2 = '3';
        }
        else {
            //alert('19%');
            yoi2 = '19';
            month2 = '5';
        }
        document.getElementById("RateInterestTextBoxPFC").value = yoi2;
        //alert(month2);
        document.getElementById("NoMonthsTextBoxPFC").value = parseInt(month2) * 12;

        var pp = document.getElementById("AmountCreditCurrTextBoxPFC").value;
        var term = document.getElementById("NoMonthsTextBoxPFC").value;
        var int = document.getElementById("RateInterestTextBoxPFC").value / 1200;

        //(pp * int) / (1 - (Math.pow(1 / (1 + int), term)));
        //alert(pp + "  " + term + "   " + int);
        document.getElementById("MonthRepayTextBoxPFC").value = ((pp * int) / (1 - (Math.pow(1 / (1 + int), term)))).toFixed(2);
        //alert('1  '+month2);

        document.getElementById("tPurchase").value = document.getElementById("TotalPurTextBoxPFC").value;
        document.getElementById("QDepo").value = document.getElementById("QualTextBoxPFC").value;
        document.getElementById("AmtCre").value = document.getElementById("AmountCreditTextBoxPFC").value;
        document.getElementById("CreCurr").value = document.getElementById("AmountCreditCurrTextBoxPFC").value;
        //alert('2  ' + month2);
        document.getElementById("NoOfMonth").value = document.getElementById("NoMonthsTextBoxPFC").value;
        document.getElementById("RateOfInt").value = document.getElementById("RateInterestTextBoxPFC").value;
        document.getElementById("MonthlyRepay").value = document.getElementById("MonthRepayTextBoxPFC").value;

      //  alert('3  ' + month2);
        

    }
    else if (drop == "Trade Into Points")
    {

        document.getElementById('tpcurrTP').style.display = "inline-block";
        document.getElementById('tpcurrQD').style.display = "inline-block";
        document.getElementById('tpcurrAC').style.display = "inline-block";


        var curramt;
        var n = document.getElementById("CrownFinanceCurrDropDownList");
        var payn = n.options[n.selectedIndex].text;

        document.getElementById("TotalPurTextBoxTPFC").value = document.getElementById("TextPurchasePrice").value;

        var k = document.getElementById("textBox_" + glob + "2").value;

        document.getElementById("AmountCreditTextBoxTPFC").value = k;

        document.getElementById("QualTextBoxTPFC").value = parseInt(document.getElementById("TextPurchasePrice").value) - parseInt(k);


        
        if (payn == "USD") {
            curramt = '1';
            //curramt = document.getElementById("TextAusRateP").value;
            document.getElementById('tpcurr1CAC').style.display = "inline-block";
            document.getElementById('tpcurr1MP').style.display = "inline-block";
        }
        else if (payn == "AUD") {
            curramt = document.getElementById("TextAusRateP").value;
            document.getElementById('tpcurr3CAC').style.display = "inline-block";
            document.getElementById('tpcurr3MP').style.display = "inline-block";
        }
        else if (payn == "EUR") {
            curramt = document.getElementById("TextEuroRateP").value;
            document.getElementById('tpcurr2CAC').style.display = "inline-block";
            document.getElementById('tpcurr2MP').style.display = "inline-block";
        }
        else if (payn == "GBP") {
            curramt = document.getElementById("TextGbpRateP").value;
            document.getElementById('tpcurr4CAC').style.display = "inline-block";
            document.getElementById('tpcurr4MP').style.display = "inline-block";
        }


        document.getElementById("AmountCreditCurrTextBoxTPFC").value = (parseFloat(document.getElementById("AmountCreditTextBoxTPFC").value) * parseFloat(curramt)).toFixed(2);

        var p = document.getElementById("YearOfIntDropDownList");
        var yoi = p.options[p.selectedIndex].text;
        var yoi2,month2;
        //alert("yoi"+yoi);

        var yr1 = parseInt(yoi.substring(0, 2));

        // alert(yr1);
        if (yr1 == "2") {
            yoi2 = '14';
            month2 = '2';
            //alert('2 Years	14%');
        }
        else if (yr1 == "3") {
            yoi2 = '17';
            month2 = '3';
        }
        else {
            //alert('19%');
            yoi2 = '19';
            month2 = '5';
        }
        document.getElementById("RateInterestTextBoxTPFC").value = yoi2;
        document.getElementById("NoMonthsTextBoxTPFC").value = parseInt(month2) * 12;

        var pp = document.getElementById("AmountCreditCurrTextBoxTPFC").value;
        var term = document.getElementById("NoMonthsTextBoxTPFC").value;
        var int = parseInt(document.getElementById("RateInterestTextBoxTPFC").value) / 1200;

        document.getElementById("MonthRepayTextBoxTPFC").value = ((pp * int) / (1 - (Math.pow(1 / (1 + int), term)))).toFixed(2);



        document.getElementById("tPurchase").value = document.getElementById("TotalPurTextBoxTPFC").value;
        document.getElementById("QDepo").value = document.getElementById("QualTextBoxTPFC").value;
        document.getElementById("AmtCre").value = document.getElementById("AmountCreditTextBoxTPFC").value;
        document.getElementById("CreCurr").value = document.getElementById("AmountCreditCurrTextBoxTPFC").value;

        document.getElementById("NoOfMonth").value = document.getElementById("NoMonthsTextBoxTPFC").value;
        document.getElementById("RateOfInt").value = document.getElementById("RateInterestTextBoxTPFC").value;
        document.getElementById("MonthlyRepay").value = document.getElementById("MonthRepayTextBoxTPFC").value;

    }
    else if (drop == "Trade Into Fractional")
    {
        //alert('Trade Into Fractional');

        document.getElementById('tfcurrTP').style.display = "inline-block";
        document.getElementById('tfcurrQD').style.display = "inline-block";
        document.getElementById('tfcurrAC').style.display = "inline-block";

        var curramt;
        var n = document.getElementById("CrownFinanceCurrDropDownList");
        var payn = n.options[n.selectedIndex].text;

        document.getElementById("TotalPurTextBoxTFFC").value = document.getElementById("TextPurchasePrice").value;

        var k = document.getElementById("textBox_" + glob + "2").value;

        document.getElementById("AmountCreditTextBoxTFFC").value = k;

        document.getElementById("QualTextBoxTFFC").value = parseInt(document.getElementById("TextPurchasePrice").value) - parseInt(k);

        if (payn == "USD") {
            curramt = '1';
            //curramt = document.getElementById("TextAusRateP").value;
            document.getElementById('tfcurr1CAC').style.display = "inline-block";
            document.getElementById('tfcurr1MP').style.display = "inline-block";
        }
        else if (payn == "AUD") {
            curramt = document.getElementById("TextAusRateP").value;
            document.getElementById('tfcurr3CAC').style.display = "inline-block";
            document.getElementById('tfcurr3MP').style.display = "inline-block";
        }
        else if (payn == "EUR") {
            curramt = document.getElementById("TextEuroRateP").value;
            document.getElementById('tfcurr2CAC').style.display = "inline-block";
            document.getElementById('tfcurr2MP').style.display = "inline-block";
        }
        else if (payn == "GBP") {
            curramt = document.getElementById("TextGbpRateP").value;
            document.getElementById('tfcurr4CAC').style.display = "inline-block";
            document.getElementById('tfcurr4MP').style.display = "inline-block";
        }


        document.getElementById("AmountCreditCurrTextBoxTFFC").value = (parseFloat(document.getElementById("AmountCreditTextBoxTFFC").value) * parseFloat(curramt)).toFixed(2);

        var p = document.getElementById("YearOfIntDropDownList");
        var yoi = p.options[p.selectedIndex].text;
        var yoi2,month2;
        //alert(yoi);

        var yr1 = parseInt(yoi.substring(0, 2));

        //alert(yr1);
        if (yr1 == "2") {
            yoi2 = '14';
            month2 = '2';
            //alert('2 Years	14%');
        }
        else if (yr1 == "3") {
            yoi2 = '17';
            month2 = '3';
        }
        else  {
            yoi2 = '19';
            month2 = '5';
        }
        document.getElementById("RateInterestTextBoxTFFC").value = yoi2;
        document.getElementById("NoMonthsTextBoxTFFC").value = parseInt(month2) * 12;

        var pp = document.getElementById("AmountCreditCurrTextBoxTFFC").value;
        var term = document.getElementById("NoMonthsTextBoxTFFC").value;
        var int = parseInt(document.getElementById("RateInterestTextBoxTFFC").value) / 1200;

        document.getElementById("MonthRepayTextBoxTFFC").value = ((pp * int) / (1 - (Math.pow(1 / (1 + int), term)))).toFixed(2);


        document.getElementById("tPurchase").value = document.getElementById("TotalPurTextBoxTFFC").value;
        document.getElementById("QDepo").value = document.getElementById("QualTextBoxTFFC").value;
        document.getElementById("AmtCre").value = document.getElementById("AmountCreditTextBoxTFFC").value;
        document.getElementById("CreCurr").value = document.getElementById("AmountCreditCurrTextBoxTFFC").value;

        document.getElementById("NoOfMonth").value = document.getElementById("NoMonthsTextBoxTFFC").value;
        document.getElementById("RateOfInt").value = document.getElementById("RateInterestTextBoxTFFC").value;
        document.getElementById("MonthlyRepay").value = document.getElementById("MonthRepayTextBoxTFFC").value;
    }

    
}


/*display on load*/
function gendetails2()
{

    //alert('gendetails2-1');
    var n2 = document.getElementById("DropDownList40");
    var drop = n2.options[n2.selectedIndex].text;

    
    var n3 = document.getElementById("PayMethodDropDownList");
    var fina = n3.options[n3.selectedIndex].text;

    if (fina == "Crown Finance") {

       // alert('gendetails2-2');
        if (drop == "Fractional") {

            //alert('helo');
            document.getElementById('fcurrTP').style.display = "inline-block";
            document.getElementById('fcurrQD').style.display = "inline-block";
            document.getElementById('fcurrAC').style.display = "inline-block";


            var curramt;
            var n = document.getElementById("CrownFinanceCurrDropDownList");
            var payn = n.options[n.selectedIndex].text;

            if (payn == "USD") {

                //curramt = document.getElementById("TextAusRateP").value;
                document.getElementById('fcurr1CAC').style.display = "inline-block";
                document.getElementById('fcurr1MP').style.display = "inline-block";
            }
            else if (payn == "AUD") {

                document.getElementById('fcurr3CAC').style.display = "inline-block";
                document.getElementById('fcurr3MP').style.display = "inline-block";
            }
            else if (payn == "EUR") {

                document.getElementById('fcurr2CAC').style.display = "inline-block";
                document.getElementById('fcurr2MP').style.display = "inline-block";
            }
            else if (payn == "GBP") {

                document.getElementById('fcurr4CAC').style.display = "inline-block";
                document.getElementById('fcurr4MP').style.display = "inline-block";
            }



        }
        else if (drop == "Points") {

            //alert('gendetails2-2-points');
            document.getElementById('pcurrTP').style.display = "inline-block";
            document.getElementById('pcurrQD').style.display = "inline-block";
            document.getElementById('pcurrAC').style.display = "inline-block";


            var curramt;
            var n = document.getElementById("CrownFinanceCurrDropDownList");
            var payn = n.options[n.selectedIndex].text;

            if (payn == "USD") {

                //curramt = document.getElementById("TextAusRateP").value;
                document.getElementById('pcurr1CAC').style.display = "inline-block";
                document.getElementById('pcurr1MP').style.display = "inline-block";
            }
            else if (payn == "AUD") {

                document.getElementById('pcurr3CAC').style.display = "inline-block";
                document.getElementById('pcurr3MP').style.display = "inline-block";
            }
            else if (payn == "EUR") {

                document.getElementById('pcurr2CAC').style.display = "inline-block";
                document.getElementById('pcurr2MP').style.display = "inline-block";
            }
            else if (payn == "GBP") {

                document.getElementById('pcurr4CAC').style.display = "inline-block";
                document.getElementById('pcurr4MP').style.display = "inline-block";
            }




        }
        else if (drop == "Trade Into Points") {

           // alert('gendetails2-3');
            document.getElementById('tpcurrTP').style.display = "inline-block";
            document.getElementById('tpcurrQD').style.display = "inline-block";
            document.getElementById('tpcurrAC').style.display = "inline-block";


            var curramt;
            var n = document.getElementById("CrownFinanceCurrDropDownList");
            var payn = n.options[n.selectedIndex].text;

            if (payn == "USD") {

               // alert('gendetails2-4');

                //curramt = document.getElementById("TextAusRateP").value;
                document.getElementById('tpcurr1CAC').style.display = "inline-block";
                document.getElementById('tpcurr1MP').style.display = "inline-block";
            }
            else if (payn == "AUD") {

                document.getElementById('tpcurr3CAC').style.display = "inline-block";
                document.getElementById('tpcurr3MP').style.display = "inline-block";
            }
            else if (payn == "EUR") {

                document.getElementById('tpcurr2CAC').style.display = "inline-block";
                document.getElementById('tpcurr2MP').style.display = "inline-block";
            }
            else if (payn == "GBP") {

                document.getElementById('tpcurr4CAC').style.display = "inline-block";
                document.getElementById('tpcurr4MP').style.display = "inline-block";
            }

            //alert('gendetails2-5');

        }
        else if (drop == "Trade Into Fractional") {
            //alert('Trade Into Fractional');
            document.getElementById('tfcurrTP').style.display = "inline-block";
            document.getElementById('tfcurrQD').style.display = "inline-block";
            document.getElementById('tfcurrAC').style.display = "inline-block";


            var curramt;
            var n = document.getElementById("CrownFinanceCurrDropDownList");
            var payn = n.options[n.selectedIndex].text;

            if (payn == "USD") {

                //curramt = document.getElementById("TextAusRateP").value;
                document.getElementById('tfcurr1CAC').style.display = "inline-block";
                document.getElementById('tfcurr1MP').style.display = "inline-block";
            }
            else if (payn == "AUD") {

                document.getElementById('tfcurr3CAC').style.display = "inline-block";
                document.getElementById('tfcurr3MP').style.display = "inline-block";
            }
            else if (payn == "EUR") {

                document.getElementById('tfcurr2CAC').style.display = "inline-block";
                document.getElementById('tfcurr2MP').style.display = "inline-block";
            }
            else if (payn == "GBP") {

                document.getElementById('tfcurr4CAC').style.display = "inline-block";
                document.getElementById('tfcurr4MP').style.display = "inline-block";
            }

           
        }

    }

    //alert('gendetails2-6');
}



function deleteinvoice()
{
   // alert('deleteinvoice');
    CallPageMethod();
}


function CallPageMethod()
{
    //alert('CallPageMethod');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //url is the path of our web method (Page name/function name)
        url: "Edit_Contract.aspx/DeleteInvoiceOnEdit",
        data: "{}",
        dataType: "json",
        //called on jquery ajax call success
        success: function (data) {
            
            var k = data.d;
            //alert(k);
            
        },
        //called on jquery ajax call failure
        error: function () {
            alert('error');
        }
    });
    return false;
}



function loadFirstcrowncurr() {
    //alert('CallPageMethod');
    var id = $("#CrownFinanceCurrDropDownList").val();

                         
    var k;//, i, s, p;
    //alert('hhhh');

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //url is the path of our web method (Page name/function name)
        url: "Edit_Contract.aspx/pnumberCount",
        data: "{'id': '" + id + "'}",
        dataType: "json",
        //called on jquery ajax call success
        success: function (data) {
            k = (data.d);
            //alert(k);
            $("#TextPnumb").val(k);

        },
        //called on jquery ajax call failure
        error: function () {
            alert('error');
        }
    });


    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //url is the path of our web method (Page name/function name)
        url: "Edit_Contract.aspx/Erates",
        data: "{'id': '" + id + "'}",
        dataType: "json",
        //called on jquery ajax call success
        success: function (data) {
            //k = (data.d);
            //alert(k);
            if (id == 'EUR')
            {
                document.getElementById("item2017a").style.display = 'grid';
                document.getElementById("item2018a").style.display = 'grid';
                document.getElementById("item2017b").style.display = 'none';
                document.getElementById("item2018b").style.display = 'none';
                document.getElementById("item2017c").style.display = 'none';
                document.getElementById("item2018c").style.display = 'none';
                document.getElementById("item2017d").style.display = 'none';
                document.getElementById("item2018d").style.display = 'none';
                $("#TextEuroRateP").val(data.d);
                // TextGbpRatePTextIdaRateP
            }
            else if(id == 'AUD')
            {
                document.getElementById("item2017a").style.display = 'none';
                document.getElementById("item2018a").style.display = 'none';
                document.getElementById("item2017b").style.display = 'grid';
                document.getElementById("item2018b").style.display = 'grid';
                document.getElementById("item2017c").style.display = 'none';
                document.getElementById("item2018c").style.display = 'none';
                document.getElementById("item2017d").style.display = 'none';
                document.getElementById("item2018d").style.display = 'none';
                $("#TextAusRateP").val(data.d);
            }
            else if (id == 'USD')
            {
                document.getElementById("item2017a").style.display = 'none';
                document.getElementById("item2018a").style.display = 'none';
                document.getElementById("item2017b").style.display = 'none';
                document.getElementById("item2018b").style.display = 'none';
                document.getElementById("item2017c").style.display = 'none';
                document.getElementById("item2018c").style.display = 'none';
                document.getElementById("item2017d").style.display = 'none';
                document.getElementById("item2018d").style.display = 'none';
                //$("#TextAusRateP").val(data.d);
            }
            else if (id == 'GBP') {
                document.getElementById("item2017a").style.display = 'none';
                document.getElementById("item2018a").style.display = 'none';
                document.getElementById("item2017b").style.display = 'none';
                document.getElementById("item2018b").style.display = 'none';
                document.getElementById("item2017c").style.display = 'grid';
                document.getElementById("item2018c").style.display = 'grid';
                document.getElementById("item2017d").style.display = 'none';
                document.getElementById("item2018d").style.display = 'none';
                $("#TextGbpRateP").val(data.d);
            }

                           

        },
        //called on jquery ajax call failure
        error: function () {
            alert('error');
        }
    });
    return false;




}



function ClearI()
{
    var e;

    for (e = 1; e <= glob; e++) {   //alert("hi"+e); 
        
        document.getElementById("textBox_" + e + "2").value = '0';

         //t45
            
                
    }
    document.getElementById("t45").value = document.getElementById("TextModTotalBalance").value;
}

function assign1() {
    //alert("hi");
    var pe, ke, qe;
    //var p1 = parseInt(numb) / 2;
    //var p2 = parseInt(p1) + 1;
    //var balancepa = 7119;  TextPBalaceDPA TextBalanceDuePATP
    var balancepa = document.getElementById("TextPBalaceDPA").value;
    var balancepaTP = document.getElementById("TextBalanceDuePATP").value;
    var pre = 0;
    var te1 = 0;
    var tem;
    var dropval = document.getElementById("DropDownList40").value;

    //alert(" 1st "+p1+" "+p2);
    if (dropval == "Points") {


        for (pe = 1; pe <= glob; pe++) {
            tem = (parseInt(balancepa) - parseInt(pre));
            //alert("1 tem "+tem);
            //alert("pre  start of for loop"+pre);
            var temp = document.getElementById("textBox_" + pe + "2").value;
            // alert ("value of text"+temp);

            if (parseInt(document.getElementById("textBox_" + pe + "2").value) <= (parseInt(balancepa) - parseInt(pre))) {
                //alert("yes");
                //alert("1"+tem);
                te1 += document.getElementById("textBox_" + pe + "2").value;
                document.getElementById("textBoxN_" + pe + "2").value = document.getElementById("textBox_" + pe + "2").value;
                var temp2 = document.getElementById("textBoxN_" + pe + "2").value;
                //alert ("value of temp2"+temp);
            }
            else {
                //alert("no");
                te1 = (parseInt(balancepa) - parseInt(pre));
                //alert("te  "+ te1);
                if (parseInt(te1) > 0) {
                    document.getElementById("textBoxN_" + pe + "2").value = parseInt(te1);
                }
                else {
                    document.getElementById("textBoxN_" + pe + "2").value = "0";
                }
                var temp3 = document.getElementById("textBoxN_" + pe + "2").value;
                //alert(temp3);
            }
            pre = parseInt(pre) + parseInt(document.getElementById("textBox_" + pe + "2").value);
            // alert("pre  "+pre);

            //document.getElementById("textBoxN_"+pe+"2").value=pre;

        }
        //document.getElementById("t46").value=te1;

        for (qe = 1; qe <= glob; qe++) {
            //alert("hi2");
            var name1 = 'textBox_' + qe + '2';
            //alert(name1);
            if (parseInt(document.getElementById("textBox_" + qe + "2").value) == parseInt(document.getElementById("textBoxN_" + qe + "2").value)) {
                //alert("yes");
                document.getElementById("textBoxN_" + qe + "3").value = "0";

            }
            else {
                //alert("No");
                document.getElementById("textBoxN_" + qe + "3").value = parseInt(parseInt(document.getElementById("textBox_" + qe + "2").value) - parseInt(document.getElementById("textBoxN_" + qe + "2").value));

            }

        }

    }
    else if (dropval == "Fractional")
    {
        for (qe = 1; qe <= glob; qe++) {

            document.getElementById("textBoxN_" + qe + "2").value = parseInt(document.getElementById("textBox_" + qe + "2").value);

        }
    }

    else if (dropval == "Trade Into Fractional") {
        for (qe = 1; qe <= glob; qe++) {

            document.getElementById("textBoxN_" + qe + "2").value = parseInt(document.getElementById("textBox_" + qe + "2").value);

        }
    }
    else if (dropval == "Trade Into Points") {


        for (pe = 1; pe <= glob; pe++) {
            tem = (parseInt(balancepaTP) - parseInt(pre));
            //alert("1 tem "+tem);
            //alert("pre  start of for loop"+pre);
            var temp = document.getElementById("textBox_" + pe + "2").value;
            // alert ("value of text"+temp);

            if (parseInt(document.getElementById("textBox_" + pe + "2").value) <= (parseInt(balancepaTP) - parseInt(pre))) {
                //alert("yes");
                //alert("1"+tem);
                te1 += document.getElementById("textBox_" + pe + "2").value;
                document.getElementById("textBoxN_" + pe + "2").value = document.getElementById("textBox_" + pe + "2").value;
                var temp2 = document.getElementById("textBoxN_" + pe + "2").value;
                //alert ("value of temp2"+temp);
            }
            else {
                //alert("no");
                te1 = (parseInt(balancepaTP) - parseInt(pre));
                //alert("te  "+ te1);
                if (parseInt(te1) > 0) {
                    document.getElementById("textBoxN_" + pe + "2").value = parseInt(te1);
                }
                else {
                    document.getElementById("textBoxN_" + pe + "2").value = "0";
                }
                var temp3 = document.getElementById("textBoxN_" + pe + "2").value;
                //alert(temp3);
            }
            pre = parseInt(pre) + parseInt(document.getElementById("textBox_" + pe + "2").value);
            // alert("pre  "+pre);

            //document.getElementById("textBoxN_"+pe+"2").value=pre;

        }
        //document.getElementById("t46").value=te1;

        for (qe = 1; qe <= glob; qe++) {
            //alert("hi2");
            var name1 = 'textBox_' + qe + '2';
            //alert(name1);
            if (parseInt(document.getElementById("textBox_" + qe + "2").value) == parseInt(document.getElementById("textBoxN_" + qe + "2").value)) {
                //alert("yes");
                document.getElementById("textBoxN_" + qe + "3").value = "0";

            }
            else {
                //alert("No");
                document.getElementById("textBoxN_" + qe + "3").value = parseInt(parseInt(document.getElementById("textBox_" + qe + "2").value) - parseInt(document.getElementById("textBoxN_" + qe + "2").value));

            }

        }

    }
}



function displayI() {
    var text13 = "";
    var text14 = "";
    var e;
    var dropval = document.getElementById("DropDownList40").value;


    var m = document.getElementById("PayMethodDropDownList");
    var paym = m.options[m.selectedIndex].text;

    if (dropval == "Points") {

        //alert('point');
        for (e = 1; e <= glob; e++) {   //alert("hi"+e); 
            // text3 ="eee";
            //alert(text13);
            // var qq = 'textBox_'+e+'1';
            if (e == glob) {

                if (paym == "Crown Finance") {


                    // alert('pointddd');
                    if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                        text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + " By Crown Finance LTD. " + document.getElementById("TextContractNumb").value + "/" + document.getElementById("TextPnumb").value + ";";
                        // alert(text13);
                        //var br = document.createElement('br');
                        //TextPBalanceDDates.appendChild(br);
                    }

                    if (document.getElementById("textBoxN_" + e + "3").value != 0) {
                        text14 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "3").value + " on " + document.getElementById("textBox_" + e + "3").value + " By Crown Finance LTD. " + document.getElementById("TextContractNumb").value + "/" + document.getElementById("TextPnumb").value + ";";
                        // var br = document.createElement('br');
                        // TextBalanceDDatesSAP.appendChild(br);
                    }
                }
                else {
                    if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                        text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                        // alert(text13);
                        //var br = document.createElement('br');
                        //TextPBalanceDDates.appendChild(br);
                    }

                    if (document.getElementById("textBoxN_" + e + "3").value != 0) {
                        text14 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "3").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                        // var br = document.createElement('br');
                        // TextBalanceDDatesSAP.appendChild(br);
                    }

                }

            }
            else {



                if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                    text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                    // alert(text13);
                    //var br = document.createElement('br');
                    //TextPBalanceDDates.appendChild(br);
                }

                if (document.getElementById("textBoxN_" + e + "3").value != 0) {
                    text14 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "3").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                    // var br = document.createElement('br');
                    // TextBalanceDDatesSAP.appendChild(br);
                }


            }

            //alert(qq);
            //alert(text3);

        }
        document.getElementById('TextPBalanceDDates').value = text13;
        document.getElementById('TextBalanceDDatesSAP').value = text14;

    }
    else if (dropval == "Fractional") {

        for (e = 1; e <= glob; e++) {   //alert("hi"+e); 

            if (e == glob) {

                if (paym == "Crown Finance") {



                    if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                        text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBox_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + " By Crown Finance LTD. " + document.getElementById("TextContractNumb").value + "/" + document.getElementById("TextPnumb").value + ";";
                        // alert(text13);
                        //var br = document.createElement('br');
                        //TextPBalanceDDates.appendChild(br);
                    }
                }
                else {

                    if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                        text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBox_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                        // alert(text13);
                        var br = document.createElement('br');
                        TextPBalanceDDates.appendChild(br);
                    }

                }
            }
            else {

                if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                    text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBox_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                    // alert(text13);
                    var br = document.createElement('br');
                    TextPBalanceDDates.appendChild(br);
                }

            }




        }
        document.getElementById('TextDueDatesPAF').value = text13;
        //document.getElementById('TextBalanceDDatesSAP').value = text14;

    }
    else if (dropval == "Trade Into Points") {

        for (e = 1; e <= glob; e++) {   //alert("hi"+e); 

            if (e == glob) {

                if (paym == "Crown Finance") {

                    if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                        text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + " By Crown Finance LTD. " + document.getElementById("TextContractNumb").value + "/" + document.getElementById("TextPnumb").value + ";";

                    }

                    if (document.getElementById("textBoxN_" + e + "3").value != 0) {
                        text14 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "3").value + " on " + document.getElementById("textBox_" + e + "3").value + " By Crown Finance LTD. " + document.getElementById("TextContractNumb").value + "/" + document.getElementById("TextPnumb").value + ";";

                    }
                }
                else {
                    if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                        text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";

                    }

                    if (document.getElementById("textBoxN_" + e + "3").value != 0) {
                        text14 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "3").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";

                    }


                }

            }
            else {



                if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                    text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                    // alert(text13);
                    //var br = document.createElement('br');
                    //TextPBalanceDDates.appendChild(br);
                }

                if (document.getElementById("textBoxN_" + e + "3").value != 0) {
                    text14 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBoxN_" + e + "3").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                    // var br = document.createElement('br');
                    // TextBalanceDDatesSAP.appendChild(br);
                }


            }

            //alert(qq);
            //alert(text3);

        }
        document.getElementById('TextBalanceDueDatesPATP').value = text13;
        document.getElementById('TextBalanceDueDatesSATP').value = text14;

    }
    else if (dropval == "Trade Into Fractional") {
        for (e = 1; e <= glob; e++) {   //alert("hi"+e); 

            if (e == glob) {

                if (paym == "Crown Finance") {

                    if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                        text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBox_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + " By Crown Finance LTD. " + document.getElementById("TextContractNumb").value + "/" + document.getElementById("TextPnumb").value + ";";
                        // alert(text13);
                        // var br = document.createElement('br');
                        // TextPBalanceDDates.appendChild(br);
                    }

                }
                else {

                    if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                        text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBox_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                        // alert(text13);
                        // var br = document.createElement('br');
                        // TextPBalanceDDates.appendChild(br);
                    }

                }
            }
            else {

                if (document.getElementById("textBoxN_" + e + "2").value != 0) {
                    text13 += document.getElementById("textBoxN_" + e + "1").value + " " + document.getElementById("textBox_" + e + "4").value + " " + document.getElementById("textBox_" + e + "2").value + " on " + document.getElementById("textBox_" + e + "3").value + "; ";
                    // alert(text13);
                    // var br = document.createElement('br');
                    // TextPBalanceDDates.appendChild(br);
                }

            }




        }
        document.getElementById('TextBalanceDueDatesPATF').value = text13;
        //document.getElementById('TextBalanceDDatesSAP').value = text14;

    }
}


// When the user clicks on <span> (x), close the modal
//span.onclick = function() {
  //  modal.style.display = "none";
//}

//label.onclick = function () {
  //  alert("label");
   // modal.style.display = "none";
//}

// When the user clicks anywhere outside of the modal, close it
//window.onclick = function(event) {
    //if (event.target == modal) {
      //  modal.style.display = "none";
    //}
           //}




function TotalPointsCalc()
{
    var conttype = document.getElementById("ContTypeTPDropDownList").value;

    if(conttype == "From Points To Points")
    {
        
        document.getElementById("TextTotalPointsTP").value = parseInt(document.getElementById("TextNewPointsTP").value) + parseInt(document.getElementById("TextOldNoPointsTP").value);

    }
    else if (conttype == "From Weeks To Points") {
        
        document.getElementById("TextTotalPointsTP").value = parseInt(document.getElementById("TextNewPointsTP").value) + parseInt(document.getElementById("TextTPPoints").value);

    }

}

  function hi3()
        {
          document.getElementById('<%= pfnameTextBox.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= VenueCountryDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= VenueDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= GroupVenueDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= MarketingPrgmDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= AgentsDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
           document.getElementById('<%= AgentCodeDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          var rem = true;
          var v1 = document.getElementById("VenueCountryDropDownList");
          var id = v1.options[v1.selectedIndex].text;
          var v2 = document.getElementById("VenueDropDownList");
          var id2 = v2.options[v2.selectedIndex].text;
          var v3 = document.getElementById("GroupVenueDropDownList");
          var id3 = v3.options[v3.selectedIndex].text;
          var v4 = document.getElementById("MarketingPrgmDropDownList");
          var id4 = v4.options[v4.selectedIndex].text;
          var v5 = document.getElementById("AgentsDropDownList");
          var id5 = v5.options[v5.selectedIndex].text;
          var v6 = document.getElementById("AgentCodeDropDownList");
          var id6 = v6.options[v6.selectedIndex].text;
          //alert(id);
        if (document.getElementById('<%= pfnameTextBox.ClientID %>').value == '')
        {
            //alert('pfnameTextBox');
            document.getElementById('<%= pfnameTextBox.ClientID %>').style.backgroundColor = '#fcccd2';
            //alert(document.getElementById('<%= pfnameTextBox.ClientID %>').value);
            rem = false;
            //alert(rem);
        }
          //alert('venuec1' + rem);
          //alert(id);
        if (id == '')
        {
            //alert('12');
            document.getElementById('<%= VenueCountryDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
            rem = false;
           // alert(rem);
        }
        //alert('venuec'+rem);
         if (id2 == '')
        {
             //alert('venuec');
            document.getElementById('<%= VenueDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
           // alert(rem);
         }
          //alert('venue'+rem);
         if (id3 == '')
        {
            //alert('hi');
            document.getElementById('<%= GroupVenueDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
           // alert(rem);
         }
         // alert('groupv' + rem);
         if (id4 == '')
        {
            //alert('hi');
            document.getElementById('<%= MarketingPrgmDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
           // alert(rem);
         }
         // alert('mark' + rem);
         if (id5 == '')
        {
            //alert('hi');
            document.getElementById('<%= AgentsDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
           // alert(rem);
         }
          //alert('agent' + rem);
         if (id6 == '')
        {
            //alert('hi');
            document.getElementById('<%= AgentCodeDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
             rem = false;
           // alert(rem);
        }
          // alert('ERROR');

          if (rem == false) {
              alert('Please Enter Data in Required Field!!');
              
          }
          return rem;
        //alert('ERROR');
  }


    function val2()
    {
        //alert('hi2');
        document.getElementById('<%= DropDownList40.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= FinanceCurrencyDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= ContractClubPDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= TextNoPoints.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= EntitlementPoinDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= ResortDropDownListF.ClientID %>').style.backgroundColor = '#ffffff';
        document.getElementById('<%= ResidenceNoDropDownListF.ClientID %>').style.backgroundColor = '#ffffff';
        document.getElementById('<%= ResidenceTypeDropDownListF.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= FractionalIDropDownListF.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= EntitlementFracDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= TextOldAgreeNoTF3.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= EntitlementPoinDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= ResortDropDownListTF3.ClientID %>').style.backgroundColor = '#ffffff';
           document.getElementById('<%= ResidenceNoDropDownListTF.ClientID %>').style.backgroundColor = '#ffffff';
        
        document.getElementById('<%= ResiTypeDropDownListTF.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= FracIntDropDownListTF.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= EntitleDropDownListTF3.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= TextOldAgreeNoTF1.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= OldClubDropDownListTF.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= TextOldNoOfPointsTF.ClientID %>').style.backgroundColor = '#ffffff';
        document.getElementById('<%= EntitleDropDownListTF1.ClientID %>').style.backgroundColor = '#ffffff';
        document.getElementById('<%= TextOldAgreeNoTF2.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= ResortDropDownListTF1.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= AppartTypeDropDownListTF.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= NoOccuDropDownListTF.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= PeriodDropDownListTF.ClientID %>').style.backgroundColor = '#ffffff';
          document.getElementById('<%= SeasonDropDownListTF.ClientID %>').style.backgroundColor = '#ffffff';
        document.getElementById('<%= EntitleDropDownListTF2.ClientID %>').style.backgroundColor = '#ffffff';
              document.getElementById('<%= TextOldAgreeNoTP1.ClientID %>').style.backgroundColor = '#ffffff';
        document.getElementById('<%= ContractClubTPDropDownList1.ClientID %>').style.backgroundColor = '#ffffff';
                 document.getElementById('<%= TextOldNoPointsTP.ClientID %>').style.backgroundColor = '#ffffff';
      
                    document.getElementById('<%= EntitlementDropDownList1.ClientID %>').style.backgroundColor = '#ffffff';
                   
                    document.getElementById('<%= TextOldAgreeNoTP2.ClientID %>').style.backgroundColor = '#ffffff';
                       
                    document.getElementById('<%= ResortTPDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
                       
                    document.getElementById('<%= AppartmentTypeTPDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
     
                    document.getElementById('<%= NumbOccuTPDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
                       
                    document.getElementById('<%= PeriodTPDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
           
                    document.getElementById('<%= SeasonTPDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
       
                    document.getElementById('<%= EntitleTPDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
        
                    document.getElementById('<%= TextNewPointsTP.ClientID %>').style.backgroundColor = '#ffffff';
                      
                    document.getElementById('<%= ContractClubTPDropDownList2.ClientID %>').style.backgroundColor = '#ffffff';
                       
                    //document.getElementById('<%= EntitleTPDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
                       
        document.getElementById('<%= EntitlementTPoinDropDownList.ClientID %>').style.backgroundColor = '#ffffff';

        document.getElementById('<%= ResortDropDownListTF.ClientID %>').style.backgroundColor = '#ffffff';
        
                    document.getElementById('<%= ResidenceNoDropDownListTF1.ClientID %>').style.backgroundColor = '#ffffff';
                   
                    document.getElementById('<%= ResiTypeDropDownListTF1.ClientID %>').style.backgroundColor = '#ffffff';
      
                    document.getElementById('<%= FracIntDropDownListTF1.ClientID %>').style.backgroundColor = '#ffffff';
          
        document.getElementById('<%= EntitlementTFracDropDownList.ClientID %>').style.backgroundColor = '#ffffff';
        document.getElementById('<%= TextTotalPointsTP.ClientID %>').style.backgroundColor = '#ffffff';

        var rem = true;
        var cam;
        var v1 = document.getElementById("DropDownList40");
        var id = v1.options[v1.selectedIndex].text;
         if (document.getElementById('<%= DropDownList40.ClientID %>').value == 'Choose Contract Type')
                     {
            //alert('hi');
                    document.getElementById('<%= DropDownList40.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
           // alert(rem);
                }

        if (document.getElementById('<%= FinanceCurrencyDropDownList.ClientID %>').value == '')
                     {
            //alert('hi');
                    document.getElementById('<%= FinanceCurrencyDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
           // alert(rem);
        }

        if (id == 'Points')
        {
            cam = 'points';
             if (document.getElementById('<%= ContractClubPDropDownList.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= ContractClubPDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
             }

              if (document.getElementById('<%= TextNoPoints.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= TextNoPoints.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
              }
             if (document.getElementById('<%= EntitlementPoinDropDownList.ClientID %>').value == '')
                     {
            
                 var v1 = document.getElementById("EntitlementPoinDropDownList");
                var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                if (id != '')
                {
                    //alert('ideeee');
                }
                else 
                {
                    //alert('id');
                     document.getElementById('<%= EntitlementPoinDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
            
                  
                       // rem = false;
             }
        }
        else if (id == 'Fractional')
        {
            cam = 'Fractional';
            if (document.getElementById('<%= ResortDropDownListF.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= ResortDropDownListF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
            }
            if (document.getElementById('<%= ResidenceNoDropDownListF.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= ResidenceNoDropDownListF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
            }
            if (document.getElementById('<%= ResidenceTypeDropDownListF.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= ResidenceTypeDropDownListF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
            }
            if (document.getElementById('<%= FractionalIDropDownListF.ClientID %>').value == '')
               // if (document.getElementById(FractionalIDropDownListF).value == '')
            {
                var v1 = document.getElementById("FractionalIDropDownListF");
                var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                if (id != '')
                {
                    //alert('ideeee');
                }
                else 
                {
                    //alert('id');
                     document.getElementById('<%= FractionalIDropDownListF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
            
                   
            }
            if (document.getElementById('<%= EntitlementFracDropDownList.ClientID %>').value == '')
                var v1 = document.getElementById("EntitlementFracDropDownList");
            var id = v1.options[v1.selectedIndex].text;
            // alert('FractionalIDropDownListF');
            //alert(id);
            if (id != '') {
                //alert('ideeee');
            }
            else {
            
                    document.getElementById('<%= EntitlementFracDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
            }

            
        }
        else if (id == 'Trade Into Fractional')
        {
            //ContTypeDropDownListTF
            cam = 'Trade Into Fractional';
            var v2 = document.getElementById("ContTypeDropDownListTF");
            var id2 = v2.options[v2.selectedIndex].text;

            if (id2 == 'From Fractional To Fractional')
            {
                cam = 'Trade Into Fractional From Fractional To Fractional ';
                if (document.getElementById('<%= TextOldAgreeNoTF3.ClientID %>').value == '')
                {

            
                    document.getElementById('<%= TextOldAgreeNoTF3.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
                if (document.getElementById('<%= ResortDropDownListTF3.ClientID %>').value == '')
                {
                    var v1 = document.getElementById("ResortDropDownListTF3");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                     }
                 else {
            
                    document.getElementById('<%= ResortDropDownListTF3.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }

                }
                if (document.getElementById('<%= ResidenceNoDropDownListTF.ClientID %>').value == '')
                {
                    var v1 = document.getElementById("ResidenceNoDropDownListTF");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                     }
                 else {
            
                    document.getElementById('<%= ResidenceNoDropDownListTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
            
                   
                }
                if (document.getElementById('<%= ResiTypeDropDownListTF.ClientID %>').value == '')
                     {
            
                    var v1 = document.getElementById("ResiTypeDropDownListTF");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                     }
                 else {
            
                    document.getElementById('<%= ResiTypeDropDownListTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                    
                }
                if (document.getElementById('<%= FracIntDropDownListTF.ClientID %>').value == '')
                     {
                    var v1 = document.getElementById("FracIntDropDownListTF");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= FracIntDropDownListTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                   
                }
                if (document.getElementById('<%= EntitleDropDownListTF3.ClientID %>').value == '')
                     {
                    var v1 = document.getElementById("EntitleDropDownListTF3");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= EntitleDropDownListTF3.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                    
                    }
            }
            else if(id2=='From Points To Fractional')
            {
                cam = 'Trade Into Fractional From Points To Fractional ';
                if (document.getElementById('<%= TextOldAgreeNoTF1.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= TextOldAgreeNoTF1.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
                if (document.getElementById('<%= OldClubDropDownListTF.ClientID %>').value == '')
                     {
                    var v1 = document.getElementById("OldClubDropDownListTF");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= OldClubDropDownListTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                    
                }
                if (document.getElementById('<%= TextOldNoOfPointsTF.ClientID %>').value == '')
                {

            
                    document.getElementById('<%= TextOldNoOfPointsTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
                if (document.getElementById('<%= EntitleDropDownListTF1.ClientID %>').value == '')
                     {
                    
                    var v1 = document.getElementById("EntitleDropDownListTF1");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= EntitleDropDownListTF1.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                   
                }
            }
            else if('From Weeks To Fractional')
            {
                cam = 'Trade Into Fractional From Weeks To Fractional';
                if (document.getElementById('<%= TextOldAgreeNoTF2.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= TextOldAgreeNoTF2.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
                if (document.getElementById('<%= ResortDropDownListTF1.ClientID %>').value == '')
                {
                    var v1 = document.getElementById("ResortDropDownListTF1");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= ResortDropDownListTF1.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
            
                    
                }
                if (document.getElementById('<%= AppartTypeDropDownListTF.ClientID %>').value == '')
                {
                    var v1 = document.getElementById("AppartTypeDropDownListTF");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= AppartTypeDropDownListTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
            
                    
                }
                if (document.getElementById('<%= NoOccuDropDownListTF.ClientID %>').value == '')
                     {
            
                    var v1 = document.getElementById("NoOccuDropDownListTF");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= NoOccuDropDownListTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                    
                }
                if (document.getElementById('<%= PeriodDropDownListTF.ClientID %>').value == '')
                {
                    var v1 = document.getElementById("PeriodDropDownListTF");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= PeriodDropDownListTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
            
                   
                }
                if (document.getElementById('<%= SeasonDropDownListTF.ClientID %>').value == '')
                {
                    var v1 = document.getElementById("SeasonDropDownListTF");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= SeasonDropDownListTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
            
                   
                }
                if (document.getElementById('<%= EntitleDropDownListTF2.ClientID %>').value == '')
                     {
            
                    var v1 = document.getElementById("EntitleDropDownListTF2");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= EntitleDropDownListTF2.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                   
                }
            }
            
        if (document.getElementById('<%= ResortDropDownListTF.ClientID %>').value == '')
                     {
            
                    var v1 = document.getElementById("ResortDropDownListTF");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= ResortDropDownListTF.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                    
                }
                if (document.getElementById('<%= ResidenceNoDropDownListTF1.ClientID %>').value == '')
                     {
                    var v1 = document.getElementById("ResidenceNoDropDownListTF1");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= ResidenceNoDropDownListTF1.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                    
                }
                if (document.getElementById('<%= ResiTypeDropDownListTF1.ClientID %>').value == '')
                     {
                    
                    var v1 = document.getElementById("ResiTypeDropDownListTF1");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= ResiTypeDropDownListTF1.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
                   
                }
                if (document.getElementById('<%= FracIntDropDownListTF1.ClientID %>').value == '')
                {
                    var v1 = document.getElementById("FracIntDropDownListTF1");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= FracIntDropDownListTF1.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }
            
                    
                }
                if (document.getElementById('<%= EntitlementTFracDropDownList.ClientID %>').value == '')
                     {
            
                    var v1 = document.getElementById("EntitlementTFracDropDownList");
                    var id = v1.options[v1.selectedIndex].text;
           
                    if (id != '') {
               
                        }
                     else {
            
                    document.getElementById('<%= EntitlementTFracDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                     }

                    
                }

        }
        else if (id == 'Trade Into Points')
        {
            cam = 'Trade Into Points';
            var v3 = document.getElementById("ContTypeTPDropDownList");
            var id3 = v3.options[v3.selectedIndex].text;

            if(id3=='From Points To Points')
            {
                cam = 'Trade Into Points From Points To Points';
                 if (document.getElementById('<%= TextOldAgreeNoTP1.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= TextOldAgreeNoTP1.ClientID %>').style.backgroundColor = '#fcccd2';
                     rem = false;
                     cam = 'Trade Into Points From Points To Points TextOldAgreeNoTP1';
                 }
                if (document.getElementById('<%= ContractClubTPDropDownList1.ClientID %>').value == '')
                     {
            
                    var v1 = document.getElementById("ContractClubTPDropDownList1");
                var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                if (id != '')
                {
                    //alert('ideeee');
                }
                else 
                {
                    //alert('id');
                     document.getElementById('<%= ContractClubTPDropDownList1.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
                }
                if (document.getElementById('<%= TextOldNoPointsTP.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= TextOldNoPointsTP.ClientID %>').style.backgroundColor = '#fcccd2';
                    rem = false;
                    cam = 'Trade Into Points From Points To Points TextOldNoPointsTP';
                }
                if (document.getElementById('<%= EntitlementDropDownList1.ClientID %>').value == '')
                     {
            
                    var v1 = document.getElementById("EntitlementDropDownList1");
                var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                if (id != '')
                {
                    //alert('ideeee');
                }
                else 
                {
                    //alert('id');
                     document.getElementById('<%= EntitlementDropDownList1.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
                }
            }
            else if (id3=='From Weeks To Points')
            {
                cam = 'Trade Into Points From Weeks To Points';
                if (document.getElementById('<%= TextOldAgreeNoTP2.ClientID %>').value == '')
                     {
            
                    
                    //var v1 =
                    var id =  document.getElementById("TextOldAgreeNoTP2").value;
               // alert('FractionalIDropDownListF');
                //alert(id);
                if (id != '')
                {
                    //alert('ideeee');
                }
                else 
                {
                    //alert('id');
                     document.getElementById('<%= TextOldAgreeNoTP2.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
                                   }
                if (document.getElementById('<%= ResortTPDropDownList.ClientID %>').value == '')
                     {
            
                    
                    
                    var v1 = document.getElementById("ResortTPDropDownList");
                var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                if (id != '')
                {
                    //alert('ideeee');
                }
                else 
                {
                    //alert('id');
                     document.getElementById('<%= ResortTPDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
                   
                }
                if (document.getElementById('<%= AppartmentTypeTPDropDownList.ClientID %>').value == '')
                     {
            
                    var v1 = document.getElementById("AppartmentTypeTPDropDownList");
                var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                if (id != '')
                {
                    //alert('ideeee');
                }
                else 
                {
                    //alert('id');
                     document.getElementById('<%= AppartmentTypeTPDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                }
                }
                if (document.getElementById('<%= NumbOccuTPDropDownList.ClientID %>').value == '')
                {
            
                    var v1 = document.getElementById("NumbOccuTPDropDownList");
                 var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                 if (id != '')
                 {
                    //alert('ideeee');
                 }
                 else 
                    {
                    //alert('id');
                     document.getElementById('<%= NumbOccuTPDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                    }
                }
                if (document.getElementById('<%= PeriodTPDropDownList.ClientID %>').value == '')
                     {
                    var v1 = document.getElementById("PeriodTPDropDownList");
                 var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                 if (id != '')
                 {
                    //alert('ideeee');
                 }
                 else 
                    {
                    //alert('id');
                     document.getElementById('<%= PeriodTPDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                    }
                   
                }
                if (document.getElementById('<%= SeasonTPDropDownList.ClientID %>').value == '')
                     {
                    var v1 = document.getElementById("SeasonTPDropDownList");
                 var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                 if (id != '')
                 {
                    //alert('ideeee');
                 }
                 else 
                    {
                    //alert('id');
                     document.getElementById('<%= SeasonTPDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                    }
                   
                }
                if (document.getElementById('<%= EntitleTPDropDownList.ClientID %>').value == '')
                     {
            
                    var v1 = document.getElementById("EntitleTPDropDownList");
                 var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                 if (id != '')
                 {
                    //alert('ideeee');
                 }
                 else 
                    {
                    //alert('id');
                     document.getElementById('<%= EntitleTPDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                    }
                }

            }
            
            if (document.getElementById('<%= TextNewPointsTP.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= TextNewPointsTP.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
            }
            if (document.getElementById('<%= TextTotalPointsTP.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= TextTotalPointsTP.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
        }
        if (document.getElementById('<%= ContractClubTPDropDownList2.ClientID %>').value == '')
                     {
            
            var v1 = document.getElementById("ContractClubTPDropDownList2");
                 var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                 if (id != '')
                 {
                    //alert('ideeee');
                 }
                 else 
                    {
                    //alert('id');
                     document.getElementById('<%= ContractClubTPDropDownList2.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                    }
        }
        //if (document.getElementById('<%= EntitleTPDropDownList.ClientID %>').value == '')
                    // {
            
                   // document.getElementById('<%= EntitleTPDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                       // rem = false;
        //}
        if (document.getElementById('<%= EntitlementTPoinDropDownList.ClientID %>').value == '')
                     {
            
            var v1 = document.getElementById("EntitlementTPoinDropDownList");
                 var id = v1.options[v1.selectedIndex].text;
               // alert('FractionalIDropDownListF');
                //alert(id);
                 if (id != '')
                 {
                    //alert('ideeee');
                 }
                 else 
                    {
                    //alert('id');
                     document.getElementById('<%= EntitlementTPoinDropDownList.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
                    }
        }
       }

        



               if (rem == false) {
                   alert('Please Enter Data in Required Field!!');

               }
               return rem;

    }

           <%-- function val3()
           {
               alert('hi');
               var v1 = document.getElementById("DropDownList40");
               var id = v1.options[v1.selectedIndex].text;
               var rem = true;
        //var cam;
        //var v1 = document.getElementById("DropDownList40");
               // var id = v1.options[v1.selectedIndex].text;
               DPMPointsDropDownList
               TextDepositP
               TextPPANoInstall
               datepicker8
               TextPPAAmountInstall
               TextPPAFInstall
         

        if (id == 'Points')
        {
            cam = 'points';
             if (document.getElementById('<%= TextPurchasePrice.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= TextPurchasePrice.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
             }
            if (document.getElementById('<%= TextPurchasePrice.ClientID %>').value == '')
                     {
            
                    document.getElementById('<%= TextPurchasePrice.ClientID %>').style.backgroundColor = '#fcccd2';
                        rem = false;
             }



               if (rem == false) {
                   alert('Please Enter Data in Required Field!!');

               }
               return rem;
           }--%>


           function shows4() {
               //alert("shows2");
               var checkbox2 = document.getElementById('chsp4');

               if (checkbox2.checked) {

                   document.getElementById("panel3").style.display = "block";

               }
               else {
                   document.getElementById("panel3").style.display = "none";

               }

           }

           function shows5() {
               //alert("shows2");
               var checkbox2 = document.getElementById('chsp5');

               if (checkbox2.checked) {

                   document.getElementById("panel4").style.display = "block";

               }
               else {
                   document.getElementById("panel4").style.display = "none";

               }

           }

           function showflybuys() {
               var v1 = document.getElementById("VenueDropDownList");
               var id = v1.options[v1.selectedIndex].text;

               var v2 = document.getElementById("VenueCountryDropDownList");
               var id2 = v2.options[v2.selectedIndex].text;

               if (id == "Flybuys") {
                   // alert('hi');
                   document.getElementById("itemFly").style.display = "grid";

                   document.getElementById("item9a1").style.display = "grid";

                   document.getElementById("item9").style.display = "none";


                   document.getElementById("item9a2").style.display = "grid";

                   document.getElementById("item9a3").style.display = "grid";

                   document.getElementById("item8").style.display = "none";
               }
               else {
                   document.getElementById("itemFly").style.display = "none";

                   document.getElementById("item9a1").style.display = "none";


                   document.getElementById("item9a2").style.display = "none";

                   document.getElementById("item9a3").style.display = "none";

                   document.getElementById("item9").style.display = "grid";


                   document.getElementById("item8").style.display = "grid";
               }

           }

           /*script for laoding data*/
           /* crown finance*/
           function displaycrownfina()
           {
               //alert('hi');
               var v1 = document.getElementById("PayMethodDropDownList");
               var id = v1.options[v1.selectedIndex].text;

               var v2 = document.getElementById("CrownFinanceCurrDropDownList");
               var id2 = v2.options[v2.selectedIndex].text;
               //alert(id+'   '+id2);
               if(id == 'Crown Finance')
               {

                   if (id2 == 'EUR') {
                       document.getElementById("item2017a").style.display = 'grid';
                       document.getElementById("item2018a").style.display = 'grid';
                       document.getElementById("item2017").style.display = 'grid';
                       document.getElementById("item2018").style.display = 'grid';
                       document.getElementById("item207").style.display = 'grid';
                       document.getElementById("item208").style.display = 'grid';
                       //document.getElementById("item2017b").style.display = 'none';
                       //document.getElementById("item2018b").style.display = 'none';
                       //document.getElementById("item2017c").style.display = 'none';
                       //document.getElementById("item2018c").style.display = 'none';
                       //document.getElementById("item2017d").style.display = 'none';
                       //document.getElementById("item2018d").style.display = 'none';
                       //$("#TextEuroRateP").val(data.d);
                       // TextGbpRatePTextIdaRateP
                   }
                   else if (id2 == 'AUD') {
                       //document.getElementById("item2017a").style.display = 'none';
                       //document.getElementById("item2018a").style.display = 'none';
                       document.getElementById("item2017b").style.display = 'grid';
                       document.getElementById("item2018b").style.display = 'grid';
                       document.getElementById("item2017").style.display = 'grid';
                       document.getElementById("item2018").style.display = 'grid';
                       //document.getElementById("item2017c").style.display = 'none';
                       //document.getElementById("item2018c").style.display = 'none';
                       //document.getElementById("item2017d").style.display = 'none';
                       //document.getElementById("item2018d").style.display = 'none';
                       document.getElementById("item207").style.display = 'grid';
                       document.getElementById("item208").style.display = 'grid';



                       //$("#TextAusRateP").val(data.d);
                   }
                   else if (id2 == 'USD') {
                       //document.getElementById("item2017a").style.display = 'none';
                       //document.getElementById("item2018a").style.display = 'none';
                       //document.getElementById("item2017b").style.display = 'none';
                       //document.getElementById("item2018b").style.display = 'none';
                       //document.getElementById("item2017c").style.display = 'none';
                       //document.getElementById("item2018c").style.display = 'none';
                       //document.getElementById("item2017d").style.display = 'none';
                       //document.getElementById("item2018d").style.display = 'none';
                       document.getElementById("item207").style.display = 'grid';
                       document.getElementById("item208").style.display = 'grid';
                       document.getElementById("item2017").style.display = 'grid';
                       document.getElementById("item2018").style.display = 'grid';
                       //$("#TextAusRateP").val(data.d);
                   }



               }
           }




           function getAge(date, ageid) {
               // alert('hi');

               var today = new Date();
               //alert('hi2');
               //  alert(date + '  ' + ageid);
               var dateString = document.getElementById(date).value;
               var birthDate = new Date(dateString);

               //alert(dateString + '      ' + today + '     ' + dateString);


               var age = today.getFullYear() - birthDate.getFullYear();
               var m = today.getMonth() - birthDate.getMonth();
               if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                   age--;
               }

               document.getElementById(ageid).value = age;
               //return age;

           }




           function loadQStatus() {

               var v1 = document.getElementById("gueststatusDropDownList");
               var gueststat = v1.options[v1.selectedIndex].text;


               if (gueststat == 'Qualified') {
                   document.getElementById('gs2').style.display = 'block';
                   document.getElementById('QStatusDropDownList1').style.display = 'block';

               }
               else {
                   document.getElementById('gs2').style.display = 'none';
                   document.getElementById('QStatusDropDownList1').style.display = 'none';
               }



           }



           function topFunction2() {
               //alert('hi');

               window.location.href = "Edit_Contract.aspx";


           }

           function pele(kk) {
               alert(kk);
               //alert('hi');
               // window.location.href("Dashboard.aspx");
               //topFunction2();
               return false;
           }


           function loadgifts() {
               var k, i, s, p;
               //alert('hhhh');

               $.ajax({
                   type: "POST",
                   contentType: "application/json; charset=utf-8",
                   //url is the path of our web method (Page name/function name)
                   url: "Edit_Contract.aspx/totalgift",
                   data: "{}",
                   dataType: "json",
                   //called on jquery ajax call success
                   success: function (data) {
                       k = (data.d);
                       //$("#vouchernoTextBox").val(data.d);

                       if (k == '7') {
                           // alert('zz');
                           document.getElementById('bittu').style.display = "none";
                       }


                       for (i = 1; i <= k; i++) {

                           s = 'item88s' + i;
                           p = 'item88p' + i;
                           q = 'item88q' + i;
                           //alert('kkk');
                           document.getElementById(s).style.display = "block";
                           document.getElementById(p).style.display = "block";
                           document.getElementById(q).style.display = "block";
                       }

                       //alert(k);

                   },
                   //called on jquery ajax call failure
                   error: function () {
                       //alert('error');
                   }
               });
               return false;

           }

           function inibaldisplay()
           {

               var v1 = document.getElementById("DealDrawerDropDownList");
               var dealstat = v1.options[v1.selectedIndex].text;

               if (dealstat == 'Top Drawer') {
                   if (conttype == 'Points') {

                       document.getElementById("pbala").style.display = 'block';
                   }
                   else if (conttype == 'Fractional') {

                       document.getElementById("fbala").style.display = 'block';
                   }
                   else if (conttype == 'Trade Into Points') {

                       document.getElementById("tpbala").style.display = 'block';

                   }
                   else if (conttype == 'Trade Into Fractional') {

                       document.getElementById("tfbala").style.display = 'block';
                   }


               }
               else {
                   document.getElementById("pbala").style.display = 'none';
                   document.getElementById("fbala").style.display = 'none';
                   document.getElementById("tpbala").style.display = 'none';
                   document.getElementById("tfbala").style.display = 'none';
               }

           }

</script>

       

       <script>
           /*on load Jquery*/
           $(window).on("load", function () {
               //console.log( "window loaded" );
               
              // alert('onloadjquery');
               // $("#ResortDropDownListF").onclick(function () {

               //load Crown finance details 
               loadQStatus();
               loadgifts();
               showflybuys();
              // alert('1');
               contracttype();
               //alert('2');
               displaycrownfina();
               //alert('3');
               pay_method();
               // alert('4');
               //gendetails();

               gendetails2();
              // alert('5');

                var d1 = document.getElementById("DealDrawerDropDownList");
                var dealstat = d1.options[d1.selectedIndex].text;
                if (dealstat == 'Cancel') {
                   // alert('canel on load');
                    document.getElementById("item203b").style.display = 'grid';
                    document.getElementById("item204b").style.display = 'grid';
                    document.getElementById("item203c").style.display = 'grid';
                    document.getElementById("item204c").style.display = 'grid';
                    document.getElementById("item203d").style.display = 'grid';
                    document.getElementById("item204d").style.display = 'grid';
                }

                //alert('6');
                var v1 = document.getElementById("DropDownList40");
                var id = v1.options[v1.selectedIndex].text;

                //alert('7');
               //var id = $("#DropDownList40").val();

                //alert(id);
                //var tid;

                //if (id == "Trade Into Points") {
                //    tid = "#ContTypeTPDropDownList";
                //}
                //else if (id == "Trade Into Fractional") {
                //    tid = "#ContTypeDropDownListTF";
                //}
                if (id == "Fractional") {

                   // alert('Fractional');
                    var rf = $("#TextRemarksF").val();
                    var paf = $("#TextDueDatesPAF").val();

                    installFirstSecond();

                    $("#TextRemarksF").val(rf);
                    $("#TextDueDatesPAF").val(paf);



                    //alert('hi');

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //url is the path of our web method (Page name/function name)
                        url: "Edit_Contract.aspx/PopulateDropDownList",
                        data: "{}",
                        dataType: "json",
                        //called on jquery ajax call success
                        success: function (data) {
                            //$("#ResortDropDownListF").empty();
                            //$("#ResortDropDownListF").append("<option disabled selected value>--Select an Option--</option>");
                            jsdata = JSON.parse(data.d);

                            $.each(jsdata, function (key, value) {

                                $("#ResortDropDownListF").append($("<option></option>").val(value.ResortName).html(value.ResortName));



                            });

                        },
                        //called on jquery ajax call failure
                        error: function ajaxError(result) {
                            alert(result.status + ' : ' + result.statusText);
                        }
                    });
                    //return false;

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //url is the path of our web method (Page name/function name)
                        url: "Edit_Contract.aspx/ContracttypeDropDownList",
                        data: "{'id': '" + id + "'}",
                        dataType: "json",
                        //called on jquery ajax call success
                        success: function (data) {
                            //$(tid).empty();
                            //$(tid).append("<option disabled selected value>--Select an Option--</option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $(tid).append($("<option></option>").val(value.ContracttypeName).html(value.ContracttypeName));

                            });
                        },
                        //called on jquery ajax call failure
                        error: function () {
                            alert('error');
                        }
                    });


                }
                //else if (id == "Trade Into Fractional") {
                //    tid = "#ContTypeDropDownListTF";
                //}
                else if (id == "Points")
                {

                    var rp = $("#TextRemarkP").val();
                    var pap = $("#TextPBalanceDDates").val();
                    var sap = $("#TextBalanceDDatesSAP").val();

                    installFirstSecondP();

                    $("#TextRemarkP").val(rp);
                    $("#TextPBalanceDDates").val(pap);
                    $("#TextBalanceDDatesSAP").val(sap);


                    var v1 = document.getElementById("EntitlementPoinDropDownList");
                    var ent = v1.options[v1.selectedIndex].text;

                    var v2 = $("#TextNoPoints").val();

                    var v3 = document.getElementById("DropDownList40");
                    var drop = v3.options[v3.selectedIndex].text;

                   

                    // alert(drop);
                    if (drop == 'Points') {
                        document.getElementById("item202a1").style.display = "block";
                        document.getElementById("item202b1").style.display = "block";
                        document.getElementById("item202a2").style.display = "block";
                        document.getElementById("item202b2").style.display = "block";



                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            //url is the path of our web method (Page name/function name)
                            url: "Edit_Contract.aspx/LoadPropfess",
                            data: "{}",
                            dataType: "json",
                            //called on jquery ajax call success
                            success: function (data) {

                                // alert(data.d[0] + "     " + data.d[1]);

                                //alert(data.d);
                                if (ent == "FULL") {
                                    $("#TextPPropFees").val(data.d[0]);
                                    $("#TextPMemFees").val(data.d[1]);

                                }
                                else {
                                    $("#TextPPropFees").val(parseFloat(data.d[0]) / 2);
                                    $("#TextPMemFees").val(parseFloat(data.d[1]) / 2);
                                }

                                $("#TextMCFees").val(((parseFloat(v2) * parseFloat($("#TextPPropFees").val())) + parseFloat($("#TextPMemFees").val())).toFixed(2));


                                $("#TextPropFeesp").val($("#TextPPropFees").val());
                                $("#TextMemFeesp").val($("#TextPMemFees").val());
                                //TextMemFeesp
                                //TextPropFeesp
                            },

                            error: function () {
                                alert('error');
                            }
                        });
                        return false;

                    }
                

                   
                    

                }

                else if (id == "Trade Into Points")
                {


                    var vct = document.getElementById("ContTypeTPDropDownList");
                    var conttypetp = vct.options[vct.selectedIndex].text;
                    document.getElementById("hiddentconttype").value = conttypetp;

                    //alert(conttypetp);
                    if (conttypetp == "From Weeks To Points") {
                        document.getElementById("table1").style.display = 'none';
                        document.getElementById("table2").style.display = 'block';
                        //document.getElementById("w2").style.display = 'block';
                    }
                    else if 
                       (conttypetp == "From Points To Points") {

                       // alert("From Points To Points");
                        document.getElementById("table2").style.display = 'none';
                        document.getElementById("table1").style.display = 'block';

                        //document.getElementById("w2").style.display = 'block';
                    }
                    else {
                        document.getElementById("table2").style.display = 'none';
                        document.getElementById("table1").style.display = 'none';
                    }




                    var rp = $("#TextRemarksTP").val();
                    var pap = $("#TextBalanceDueDatesPATP").val();
                    var sap = $("#TextBalanceDueDatesPATP").val();

                    installFirstSecondTP();

                    $("#TextRemarksTP").val(rp);
                    $("#TextBalanceDueDatesPATP").val(pap);
                    $("#TextBalanceDueDatesPATP").val(sap);
                    
                    
                    var v1 = document.getElementById("EntitlementTPoinDropDownList");
                    var ent = v1.options[v1.selectedIndex].text;

                    var v2 = $("#TextNewPointsTP").val();

                    // alert(v2);
                    var v3 = document.getElementById("DropDownList40");
                    var drop = v3.options[v3.selectedIndex].text;
                    //alert(drop);
                    if (drop == 'Trade Into Points') {

                        document.getElementById("item202a1").style.display = "block";
                        document.getElementById("item202b1").style.display = "block";
                        document.getElementById("item202a2").style.display = "block";
                        document.getElementById("item202b2").style.display = "block";

                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            //url is the path of our web method (Page name/function name)
                            url: "Edit_Contract.aspx/LoadPropfess",
                            data: "{}",
                            dataType: "json",
                            //called on jquery ajax call success
                            success: function (data) {

                                // alert(data.d[0] + "     " + data.d[1]);

                                //alert(data.d);
                                if (ent == "FULL") {
                                    $("#TextPropertyFeesTP").val(data.d[0]);
                                    $("#TextMembershipFeesTP").val(data.d[1]);

                                }
                                else {
                                    $("#TextPropertyFeesTP").val(parseFloat(data.d[0]) / 2);
                                    $("#TextMembershipFeesTP").val(parseFloat(data.d[1]) / 2);
                                }

                                $("#TextMCFees").val(((parseFloat(v2) * parseFloat($("#TextPropertyFeesTP").val())) + parseFloat($("#TextMembershipFeesTP").val())).toFixed(2));
                                $("#TextPropFeesp").val($("#TextPropertyFeesTP").val());
                                $("#TextMemFeesp").val($("#TextMembershipFeesTP").val());

                                //TextBox ID="TextMembershipFeesTP"
                            },

                            error: function () {
                                alert('error');
                            }
                        });
                        return false;

                    }
                    
                }
                else if (id == "Trade Into Fractional")
                {
                    var rf = $("#TextRemarksTF").val();
                    var paf = $("#TextBalanceDueDatesPATF").val();

                    installFirstSecondTF();

                    $("#TextRemarksTF").val(rf);
                    $("#TextBalanceDueDatesPATF").val(paf);


                    var v1 = document.getElementById("ContTypeDropDownListTF");
                    var conttype = v1.options[v1.selectedIndex].text;
                    var v2 = document.getElementById("FinanceCurrencyDropDownList");
                    var Currtype = v2.options[v2.selectedIndex].text;
                    document.getElementById("hiddentconttype2").value = conttype;

                    //alert(conttype);
                    if (conttype == "From Points To Fractional") {
                        document.getElementById("tableTF2").style.display = 'none';
                        document.getElementById("tableTF3").style.display = 'none';
                        document.getElementById("tableTF1").style.display = 'block';
                        //document.getElementById("w2").style.display = 'block';
                    }
                    else if 
                       (conttype == "From Weeks To Fractional") {
                        document.getElementById("tableTF2").style.display = 'block';
                        document.getElementById("tableTF3").style.display = 'none';
                        document.getElementById("tableTF1").style.display = 'none';

                        //document.getElementById("w2").style.display = 'block';
                    }
                    else if 
                       (conttype == "From Fractional To Fractional") {
                        document.getElementById("tableTF2").style.display = 'none';
                        document.getElementById("tableTF3").style.display = 'block';
                        document.getElementById("tableTF1").style.display = 'none';

                        //document.getElementById("w2").style.display = 'block';
                    }
                    else {
                        document.getElementById("tableTF2").style.display = 'none';
                        document.getElementById("tableTF3").style.display = 'none';
                        document.getElementById("tableTF1").style.display = 'none';
                    }

                    //alert('TFadminfees');
                    //var v1 = document.getElementById("ContTypeDropDownListTF");
                    //var conttype = v1.options[v1.selectedIndex].text;
                    //alert(conttype);
                    //if (conttype == "From Points To Fractional" && Currtype == "USD") {
                    //    document.getElementById("TextAdminFees").value = "1500";
                    //    addvalue1(); addvalue2();
                    //}
                    //else if (conttype == "From Weeks To Fractional" && Currtype == "USD") {
                    //    document.getElementById("TextAdminFees").value = "1500";
                    //    addvalue1(); addvalue2();
                    //}
                    //else if (conttype == "From Fractional To Fractional" && Currtype == "USD") {
                    //    document.getElementById("TextAdminFees").value = "750";
                    //    addvalue1(); addvalue2();
                    //}





                    //alert('hi');

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //url is the path of our web method (Page name/function name)
                        url: "Edit_Contract.aspx/PopulateDropDownList",
                        data: "{}",
                        dataType: "json",
                        //called on jquery ajax call success
                        success: function (data) {
                            //$("#ResortDropDownListF").empty();
                            //$("#ResortDropDownListF").append("<option disabled selected value>--Select an Option--</option>");
                            jsdata = JSON.parse(data.d);

                            $.each(jsdata, function (key, value) {

                                $("#ResortDropDownListTF").append($("<option></option>").val(value.ResortName).html(value.ResortName));



                            });

                        },
                        //called on jquery ajax call failure
                        error: function ajaxError(result) {
                            alert(result.status + ' : ' + result.statusText);
                        }
                    });


                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //url is the path of our web method (Page name/function name)
                        url: "Edit_Contract.aspx/PopulateDropDownList",
                        data: "{}",
                        dataType: "json",
                        //called on jquery ajax call success
                        success: function (data) {
                            //$("#ResortDropDownListF").empty();
                            //$("#ResortDropDownListF").append("<option disabled selected value>--Select an Option--</option>");
                            jsdata = JSON.parse(data.d);

                            $.each(jsdata, function (key, value) {

                                $("#ResortDropDownListTF3").append($("<option></option>").val(value.ResortName).html(value.ResortName));



                            });

                        },
                        //called on jquery ajax call failure
                        error: function ajaxError(result) {
                            alert(result.status + ' : ' + result.statusText);
                        }
                    });
                    //return false;

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //url is the path of our web method (Page name/function name)
                        url: "Edit_Contract.aspx/ContracttypeDropDownList",
                        data: "{'id': '" + id + "'}",
                        dataType: "json",
                        //called on jquery ajax call success
                        success: function (data) {
                            //$(tid).empty();
                            //$(tid).append("<option disabled selected value>--Select an Option--</option>");
                            jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {

                                $(tid).append($("<option></option>").val(value.ContracttypeName).html(value.ContracttypeName));

                            });
                        },
                        //called on jquery ajax call failure
                        error: function () {
                            alert('error');
                        }
                    });

                }
              



                var vs1 = document.getElementById("VenueDropDownList");
                var sid = vs1.options[vs1.selectedIndex].text;

                var vs2 = document.getElementById("VenueCountryDropDownList");
                var sid2 = vs2.options[vs2.selectedIndex].text;

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    //url is the path of our web method (Page name/function name)
                    url: "Edit Profile.aspx/SalesRepTypeList",
                    data: "{'venueid': '" + sid + "','countid' : '" + sid2 + "'}",
                    dataType: "json",
                    //called on jquery ajax call success
                    success: function (data) {
                        //$("#salesrepDropDownList").empty();
                        //$("#salesrepDropDownList").append("<option></option>");
                        jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {

                            $("#salesrepDropDownList").append($("<option></option>").val(value.SalesRepTypeName).html(value.SalesRepTypeName));

                        });
                    },
                    //called on jquery ajax call failure
                    error: function () {
                        alert('error');
                    }
                });







                   return false;

               });

           //});


       </script>
        <style type="text/css">
    

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


  #myBtnNext {
  display: block;
  position: fixed;
  bottom: 75px;
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

#myBtnNext:hover {
  background-color: #555;
}

 #myBtnBack {
  display: none;
  position: fixed;
  bottom: 130px;
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

#myBtnBack:hover {
  background-color: #555;
}


     #tabs { 
    padding: 10px; 
    border: 1px solid #4c4c4c; 
    }

    #hidden,#item202a1,#item202b1,#item202a2,#item202b2{
        display: none;
     }

    #panel,#chs2,#chs3,#panel2,#chsp4,#panel3,#chsp5,#panel4,#hpprofees,#hpmemfees,#htpprofees,#htpmemfees {
        display: none;
    }
    #TextBox22 {
        vertical-align: top;
    }
   #cleft {
       float:left;
       
    }
     #cright {
       float:right;
       display:none;
          }
     #cdiv1,#cdiv2,#cdiv3,#cdiv4{
         display:none;
     }
     #pan,#adhar,#no,#yes1,#yess1,#yes2,#yess2,#remarks,#Points,#pnumb,#usddetails,#indiadetails{
         display: none;
     }
     body {
         
     }
     #ffractional1,#tfractional,#tpoints,#TextFDepo2,#TextFBala2,#TextFDepo1,#TextFBala1,#TextFFina1,#TextFFina2,#TextBox96,#TextICE,#TextHP,#texttest,#texte,#remarkP,#Button3,#PointsAdd,#TPAdd,#remarkTP,#hiddentconttype,#hiddentconttype2{
         /*float:left;*/
         display:none;
     }
     
      /*for cont type*/
      #table1,#table2,#tableTF1,#tableTF2,#tableTF3{
          display:none;
      }


      #tPurchase,#QDepo,#AmtCre,#CreCurr,#NoOfMonth,#RateOfInt,#MonthlyRepay,#Textcheckchs4,#Button9,#Button13,#Button7,#Button12,#Button10,#tButton1,#Button11,#Button14,#pbala,#fbala,#tpbala,#tfbala
      {
    display:none;
      }

      #tpcurrTP,#tpcurrQD,#tpcurrAC,#tpcurr1CAC,#tpcurr2CAC,#tpcurr3CAC,#tpcurr4CAC,
      #tfcurrTP,#tfcurrQD,#tfcurrAC,#tfcurr1CAC,#tfcurr2CAC,#tfcurr3CAC,#tfcurr4CAC,
      #pcurrTP,#pcurrQD,#pcurrAC,#pcurr1CAC,#pcurr2CAC,#pcurr3CAC,#pcurr4CAC,
      #fcurrTP,#fcurrQD,#fcurrAC,#fcurr1CAC,#fcurr2CAC,#fcurr3CAC,#fcurr4CAC,
      #tpcurr1MP,#tpcurr2MP,#tpcurr3MP,#tpcurr4MP,
      #tfcurr1MP,#tfcurr2MP,#tfcurr3MP,#tfcurr4MP,
      #fcurr1MP,#fcurr2MP,#fcurr3MP,#fcurr4MP,
      #pcurr1MP,#pcurr2MP,#pcurr3MP,#pcurr4MP
      {
        display:none;
      }

       #gs2,#QStatusDropDownList1{
             display: none;
    }

     p{
         margin:0px 0px 3px 0px;
         padding:0px;
     }

            .auto-style2 {
                width: 352px;
            }

            .auto-style3 {
                width: 185px;
            }

            .auto-style4 {
                width: 353px;
            }

            .auto-style7 {
                width: 120px;
                
            }

            .auto-style8 {
                width: 426px;
            }

            .auto-style11 {
                width: 181px;
            }

            .auto-style12 {
                width: 354px;
                padding-top:20px;
            }

            .auto-style14 {
                width: 243px;
            }
            .auto-style15 {
                width: 270px;
            }
            .auto-style16 {
                width: 545px;
            }


            /*for pop up div*/
            /* The Modal (background) */
.modal {
    display: none; /* Hidden by default */
    position: fixed; /* Stay in place */
    z-index: 1; /* Sit on top */
    padding-top: 100px; /* Location of the box */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
}

/* Modal Content */
.modal-content {
    background-color: #fefefe;
    margin: auto;
    padding: 20px;
    border: 1px solid #888;
    width: 80%;
    height: 70%;
    overflow:auto;
}

/* The Close Button */
#close1 {
    color: #aaaaaa;
    float: right;
    font-size: 18px;
    font-weight: bold;
}

#close1:hover,
#close1:focus {
    color: #000;
    text-decoration: none;
    cursor: pointer;
}



.grid-container{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr 1fr;
    /*background-color: #2196F3;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
     
  
  padding: 10px;
  grid-template-areas:
    'item1 itemVPID item3a item2 item3 item9a3 itemFly'
      'item4 item5 item5a item6 item7 item8 item9';
}

.grid-container>div {
  /*background-color: rgba(255, 255, 255, 0.8);*/
  padding:5px 2.5px;
  
}

.grid-container2{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  width:1200px;
  padding: 10px;
  grid-template-areas:
    'item21 item22 item23 item24';
}

.grid-container2>div {
 
  padding:5px 2.5px;
  
}

.grid-container3{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  grid-template-areas:
    'item31 item32 item32 item33 item33 item33'
      'item34 item35 item312 item37 item37a .'
      'item311age item38 item39 item310 item311 item311';
}

.grid-container3>div {
  
  padding:5px 2.5px;
  
}


.grid-container4{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'item41 item42 item42 item43 item43 item43'
      'item44 item45 item412 item47 item47a .'
      'item411age item48 item49 item410 item411 item411';
}

.grid-container4>div {
 
  padding:5px 2.5px;
  
}

.grid-container5{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  grid-template-areas:
    'item51 item51 item51 item52 item52 item52'
      'item54 item53 item53 item551 item55 .'
      'item57 . . item58 item58 .';
}

.grid-container5>div {
  
  padding:5px 2.5px;
  
}

.grid-container6{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'item61 item62 item62 item63 item63 item43'
      'item64 item65 item66 item67 item67a .'
      'item611age item68 item69 item610 item611 item611';
}

.grid-container6>div {
  
  padding:5px 2.5px;
  
}

.grid-container7{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'item71 item72 item72 item73 item73 item73'
      'item74 item75 item76 item77 item77a .'
      'item711age item78 item79 item710 item711 item711';
}

.grid-container7>div {
  
  padding:5px 2.5px;
  
}

/*.grid-container8{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;
    grid-gap: 5px;
  
  padding: 10px;
  width:1200px;
  grid-template-areas:
    'item81 item82 . .'
      'item83 item84 item85 item86 '
      'item87 item88  item810 item810 '
       'item811 item812 item89 .'
      'item813 item814 item815 item816';
}

.grid-container8>div {
  
  padding:5px 2.5px;
  
}*/

.grid-container8{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  width:1200px;
  grid-template-areas:
    'item81 item82 . .'
      'item83 item84 item85 item86 ';
}

.grid-container8>div {
  
  padding:5px 2.5px;
  
}


.grid-container88{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  width:1200px;
  grid-template-areas:
    'item88s1 item88p1 item88q1 item88cb'
      'item88s2 item88p2 item88q2 .'
      'item88s3 item88p3 item88q3 .'
      'item88s4 item88p4 item88q4 .'
      'item88s5 item88p5 item88q5 .'
      'item88s6 item88p6 item88q6 .'
      'item88s7 item88p7 item88q7 .';
}

.grid-container88>div {
  
  padding:5px 2.5px;
  
}

.grid-container882{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*background-color:blue;
    grid-template-rows: auto auto;*/
    grid-gap: 5px;
  
  padding: 10px;
  width:1200px;
  grid-template-areas:
    'item8822 item8824 item8823 item8821'
     'item8826 item8827 item8828 item8829' ;
}

.grid-container882>div {
  /*background-color: aqua;*/
  padding:5px 2.5px;
  
}

.grid-container9{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    /*grid-template-rows: auto auto;*/
    
    grid-gap: 5px;
  
  padding: 10px;
  width:1200px;
  grid-template-areas:
    'item91 item96 item93 item94'
     'item95 item92 . .' ;
}

.grid-container9>div {
  
  padding:5px 2.5px;
  
}

/*#indiadetails{
    /*display: grid;
    grid-template-columns: 1fr 1fr;
 
    /*grid-template-rows: auto auto;
    grid-gap: 5px;
    
  padding: 10px;
  width:500px;
  grid-template-areas:
    'item101 item102'
     'item103 item104' ;
}

#indiadetails>div {
  
   /*padding:5px 2.5px;

  
}*/


/*#pnumb{
    /*display: grid;
    grid-template-columns: 1fr 1fr;
 
    /*grid-template-rows: auto auto;
    grid-gap: 5px;
    
  padding: 10px;
  width:500px;
  grid-template-areas:
    'item207 item208';
}

#pnumb>div {
  
   /*padding:5px 2.5px;

  
}*/

/*
#usddetails{
    /*display: grid;
    grid-template-columns: 1fr 1fr;
   
    /*grid-template-rows: auto auto;
    grid-gap: 5px;
    
  padding: 10px;
  width:500px;
  grid-template-areas:
    'item111 item112';
}

#usddetails>div {
  
  /*padding:5px 2.5px;

  
}*/

.grid-container20{
    display: grid;
    grid-template-columns: 1fr 1fr;
    /*background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    
    grid-gap: 5px;
  
  padding: 10px;
  width:500px;
  grid-template-areas:
      
    'item2016 item2016'
      'item203a item204a'
      'item203b item204b'
      'item203c item204c'
      'item203d item204d'
     'item201 item202'
      'item202a1 item202b1'
      'item202a2 item202b2'
      'item203 item204'
      'item205 item206'
      'item2017 item2018'
      'item2017a item2018a'
      'item2017b item2018b'
      'item2017c item2018c'
      'item2017d item2018d'
      'item207 item208'
      'item208a item208b'
      'item208c item208d'
      'item209 item2010'
      'item2011 item2012'
      'item101 item102'
     'item103 item104'
      'item111 item112'
      'item2013 item2013' 
      'item2014 item2015';
}

.grid-container20>div {
  /*background-color:aqua;*/
  padding:5px 2.5px;
  
}


.grid-SubProf3{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'item9s31 item9s32 item9s32 item9s33 item9s33 item9s33'
      'item9s34 item9s35 item9s36 item9s37 item9s38 .'
      'item9sage item9s39 item9s40 item9s41 item9s42 item9s42';
}

.grid-SubProf3>div {
  /*background-color:aqua;*/
  padding:5px 2.5px;
  
}

.grid-SubProf4{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    /*background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'item9s4s1 item9s4s2 item9s4s2 item9s4s3 item9s4s3 item9s4s3'
      'item9s4s4 item9s4s5 item9s4s6 item9s4s7 item9s4s8 .'
      'item9s4age item9s4s9 item9s4s10 item9s4s11 item9s4s12 item9s4s12';
}

.grid-SubProf4>div {
  /*background-color:aqua;*/
  padding:5px 2.5px;
  
}

/*Fractional payment details*/


#ffractional1{
    /*display: grid;*/
    grid-template-columns: auto auto;
    /*background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'FracPA FracFina';
}

#ffractional1>div {
  /*background-color:aqua;*/
  padding:5px 2.5px;
  
}

/*Trade Into Fractional payment details*/


#tfractional{
    /*display: grid;*/
    grid-template-columns: auto auto;
    /*background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'TFPA TFFina';
}

#tfractional>div {
  /*background-color:aqua;*/
  padding:5px 2.5px;
  
}


/*Fractional payment sub details*/


.grid-FFinaContainer{
    display: grid;
    grid-template-columns: 1fr 1fr;
    /*background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'itemFFC1 .'
     'itemFFC2 itemFFC3'
     'itemFFC4 itemFFC5'
     'itemFFC6 itemFFC7'
     'itemFFC8 itemFFC9'
     'itemFFC10 itemFFC11'     
      'itemFFC12 itemFFC13'
      'itemFFC14 itemFFC15'
      '. itemFFC16';
}

.grid-FFinaContainer>div {
  /*background-color:aqua;*/
  padding:5px 2.5px;
  
}

.grid-TFFinaContainer{
    display: grid;
    grid-template-columns: 1fr 1fr;
    /*background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'itemTFFC1 .'
     'itemTFFC2 itemTFFC3'
     'itemTFFC4 itemTFFC5'
     'itemTFFC6 itemTFFC7'
     'itemTFFC8 itemTFFC9'
     'itemTFFC10 itemTFFC11'     
      'itemTFFC12 itemTFFC13'
      'itemTFFC14 itemTFFC15'
      '. itemTFFC16';
}

.grid-TFFinaContainer>div {
  /*background-color:aqua;*/
  padding:5px 2.5px;
  
}

/*points fina details*/

.points_col{
    display: grid;
    grid-template-columns: auto auto;
    /*background-color:blue;*/
    grid-template-rows: auto auto;
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'PA1 SA1'
      'PA1 PFina';
}

.points_col>div {
 /*background-color:aqua;*/
  padding:5px 2.5px;
  
}



.grid-PFinaContainer{
    display: grid;
    grid-template-columns: 1fr 1fr;
    /*background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'itemPFC1 .'
     'itemPFC2 itemPFC3'
     'itemPFC4 itemPFC5'
     'itemPFC6 itemPFC7'
     'itemPFC8 itemPFC9'
     'itemPFC10 itemPFC11'     
      'itemPFC12 itemPFC13'
      'itemPFC14 itemPFC15'
      '. itemPFC16';
}

.grid-PFinaContainer>div {
  /*background-color:aqua;*/
  padding:5px 2.5px;
  
}


/*trade into points fina details*/

.tpoints_col{
    display: grid;
    grid-template-columns: auto auto;
    /*background-color:blue;*/
    grid-template-rows: auto auto;
    grid-gap: 5px;
 
  padding: 10px;
  grid-template-areas:
    'PA2 SA2'
      'PA2 TPFina';
}

.tpoints_col>div {
 /*background-color:aqua;*/
  padding:5px 2.5px;
  
}



.grid-TPFinaContainer{
    display: grid;
    grid-template-columns: 1fr 1fr;
    /*background-color:blue;*/
    /*grid-template-rows: auto auto;*/
    grid-gap: 5px;
    width:650px;
 
  padding: 10px;
  grid-template-areas:
    'itemTPFC1 .'
     'itemTPFC2 itemTPFC3'
     'itemTPFC4 itemTPFC5'
     'itemTPFC6 itemTPFC7'
     'itemTPFC8 itemTPFC9'
     'itemTPFC10 itemTPFC11'     
      'itemTPFC12 itemTPFC13'
      'itemTPFC14 itemTPFC15'
      '. itemTPFC16';
}

.grid-TPFinaContainer>div {
  /*background-color:aqua;*/
  padding:5px 2.5px;
  
}
                           

.item1 {
   grid-area: item1;
}
.itemVPID {
   grid-area: itemVPID;
}
#itemFly {
   grid-area: itemFly;
   display:none;
}

.item2{
grid-area: item2;
}
.item3 {
   grid-area: item3;
}
.item3a {
   grid-area: item3a;
}


.item4{
    grid-area: item4;
}
.item5{
    grid-area: item5;

}
.item5a{
    grid-area: item5a;

}
.item6{grid-area: item6;

}
.item7{
    grid-area: item7;
}
#item8{
    grid-area: item8;

}
#item9{
    grid-area: item9;

}

#item9a3{
    grid-area: item9a3;
    display:none;

}

#item9a1{
    /*grid-area: item9a1;*/
    grid-column-start: 6;
  grid-column-end: 7;
  grid-row-start: 2;
  grid-row-end: 3;
    display:none;

}
#item9a2{
    /*grid-area: item9a1;*/
    grid-column-start: 7;
  grid-column-end: 8;
  grid-row-start: 2;
  grid-row-end: 3;
    display:none;

}

.item21 {
   grid-area: item21;
}
.item22{
grid-area: item22;
}
.item23 {
   grid-area: item23;
}

.item24{
    grid-area: item24;
}


/*primary profile*/
.item31 {
   grid-area: item31;
}
.item32{
grid-area: item32;
}
.item33 {
   grid-area: item33;
}

.item34{
    grid-area: item34;
}
.item35{
    grid-area: item35;

}
.item36{grid-area: item36;
 display:none;
}
.item37{
    grid-area: item37;
}
.item37a{
    grid-area: item37a;
}
.item38{
    grid-area: item38;
    
}
.item39{
    grid-area: item39;

}
.item310{
    grid-area: item310;
    

}
.item311{
    grid-area: item311;

}

.item311age{
    grid-area: item311age;

}
.item312{
    grid-area: item312;

}


/*Secondary profile*/
.item41 {
   grid-area: item41;
}
.item42{
grid-area: item42;
}
.item43 {
   grid-area: item43;
}

.item44{
    grid-area: item44;
}
.item45{
    grid-area: item45;

}
.item46{grid-area: item46;
 display:none;
}
.item47{
    grid-area: item47;
}
.item47a{
    grid-area: item47a;
}
.item48{
    grid-area: item48;
    
}
.item49{
    grid-area: item49;

}
.item410{
    grid-area: item410;
    

}
.item411{
    grid-area: item411;

}
.item411age{
    grid-area: item411age;

}
.item412{
    grid-area: item412;

}

/*Address*/
.item51 {
   grid-area: item51;
}
.item52{
grid-area: item52;
}
.item53 {
   grid-area: item53;
}

.item54{
    grid-area: item54;
}
.item55{
    grid-area: item55;

}
.item551{
    grid-area: item551;

}
.item56{grid-area: item56;
display:none;
}
.item57{
    grid-area: item57;
}
.item58{
    grid-area: item58;
    
}


/*Sub profile 1*/
.item61 {
   grid-area: item61;
}
.item62{
grid-area: item62;
}
.item63 {
   grid-area: item63;
}

.item64{
    grid-area: item64;
}
.item65{
    grid-area: item65;

}
.item66{grid-area: item66;

}
.item67{
    grid-area: item67;
}
.item67a{
    grid-area: item67a;
}
.item68{
    grid-area: item68;
    
}
.item69{
    grid-area: item69;

}
.item610{
    grid-area: item610;
    

}
.item611{
    grid-area: item611;

}
.item611age{
    grid-area: item611age;

}

/*Sub profile 2*/
.item71 {
   grid-area: item71;
}
.item72{
grid-area: item72;
}
.item73 {
   grid-area: item73;
}

.item74{
    grid-area: item74;
}
.item75{
    grid-area: item75;

}
.item76{grid-area: item76;

}
.item77{
    grid-area: item77;
}
.item77a{
    grid-area: item77a;
}
.item78{
    grid-area: item78;
    
}
.item79{
    grid-area: item79;

}
.item710{
    grid-area: item710;
    

}
.item711{
    grid-area: item711;

}
.item711age{
    grid-area: item711age;

}


/*Stay Details */


.item81 {
   grid-area: item81;
}
.item82{
grid-area: item82;
}
.item83 {
   grid-area: item83;
}

.item84{
    grid-area: item84;
}
.item85{
    grid-area: item85;

}
.item86{grid-area: item86;

}
#item88s1{
    grid-area: item88s1;
}
#item88p1{
    grid-area: item88p1;
    
}
#item88q1{
    grid-area: item88q1;
    
}
#item88cb{
    grid-area: item88cb;
    
}
#item88s2{
    grid-area: item88s2;
    display: none;
}
#item88p2{
    grid-area: item88p2;
    display :none;
}
#item88q2{
    grid-area: item88q2;
    display :none;
}
#item88s3{
    grid-area: item88s3;
    display :none;
}
#item88p3{
    grid-area: item88p3;
    display :none;
}
#item88q3{
    grid-area: item88q3;
    display :none;
}

#item88s4{
    grid-area: item88s4;
    display :none;
}
#item88p4{
    grid-area: item88p4;
    display :none;
}
#item88q4{
    grid-area: item88q4;
    display :none;
}
#item88s5{
    grid-area: item88s5;
    display :none;
}
#item88p5{
    grid-area: item88p5;
    display :none;
}
#item88q5{
    grid-area: item88q5;
    display :none;
}
#item88s6{
    grid-area: item88s6;
    display :none;
}
#item88p6{
    grid-area: item88p6;
    display :none;
}
#item88q6{
    grid-area: item88q6;
    display :none;
}
#item88s7{
    grid-area: item88s7;
    display :none;
}
#item88p7{
    grid-area: item88p7;
    display :none;
}
#item88q7{
    grid-area: item88q7;
    display :none;
}

.item8821{
    grid-area: item8821;

}
.item8822{
    grid-area: item8822;
    

}
.item8823{
    grid-area: item8823;

}
.item8824{
    grid-area: item8824;

}
.item8829{
    grid-area: item8829;

}
.item8826{
    grid-area: item8826;

}
.item8827{
    grid-area: item8827;

}
.item8828{
    grid-area: item8828;

}

/*.item81 {
   grid-area: item81;
}
.item82{
grid-area: item82;
}
.item83 {
   grid-area: item83;
}

.item84{
    grid-area: item84;
}
.item85{
    grid-area: item85;

}
.item86{grid-area: item86;

}
.item87{
    grid-area: item87;
}
.item88{
    grid-area: item88;
    
}
.item89{
    grid-area: item89;

}
.item810{
    grid-area: item810;
    

}
.item811{
    grid-area: item811;

}
.item812{
    grid-area: item812;

}
.item813{
    grid-area: item813;

}
.item814{
    grid-area: item814;

}
.item815{
    grid-area: item815;

}
.item816{
    grid-area: item816;

}*/







/*contract typr*/
.item91 {
   grid-area: item91;
}
.item92{
grid-area: item92;
}
.item93 {
   grid-area: item93;
}

.item94{
    grid-area: item94;
}
.item95{
    grid-area: item95;

}
.item96{grid-area: item96;

}
/*.item97{grid-area: item97;

}*/



#item101{grid-area: item101;
display:none;
}
#item102{grid-area: item102;

display:none;
}
#item103{grid-area: item103;
display:none;
}
#item104{grid-area: item104;

display:none;
}

#item111{grid-area: item111;
display:none;
}
#item112{grid-area: item112;


display:none;
}
#item2017{grid-area: item2017;


display:none;
}
#item2018{grid-area: item2018;


display:none;
}
#item2017a{grid-area: item2017a;


display:none;
}
#item2018a{grid-area: item2018a;


display:none;
}
#item2017b{grid-area: item2017b;


display:none;
}
#item2018b{grid-area: item2018b;


display:none;
}
#item2017c{grid-area: item2017c;


display:none;
}
#item2018c{grid-area: item2018c;


display:none;
}
#item2017d{grid-area: item2017d;


display:none;
}
#item2018d{grid-area: item2018d;


display:none;
}

/* Contract Finance*/
.item201{grid-area: item201;

}

.item202{grid-area: item202;

}
#item202a1{grid-area: item202a1;

}
#item202b1{grid-area: item202b1;

}
#item202a2{grid-area: item202a2;

}
#item202b2{grid-area: item202b2;

}
.item203{grid-area: item203;

}
.item204{grid-area: item204;

}
.item203a{grid-area: item203a;

}
.item204a{grid-area: item204a;

}

#item203b{grid-area: item203b;
display:none;
}
#item204b{grid-area: item204b;
display:none;
}

#item203c{grid-area: item203c;
display:none;
}
#item204c{grid-area: item204c;
display:none;
}

#item203d{grid-area: item203d;
display:none;
}
#item204d{grid-area: item204d;
display:none;
}

.item205{grid-area: item205;

}
.item206{grid-area: item206;

}
#item207{grid-area: item207;
         display:none;

}
#item208{grid-area: item208;
display:none;
}
#item208a{grid-area: item208a;
display:none;
}
#item208b{grid-area: item208b;
display:none;
}
#item208c{grid-area: item208c;
display:none;
}
#item208d{grid-area: item208d;
display:none;
}
.item209{grid-area: item209;
display:none;
}
.item2010{grid-area: item2010;
display:none;
}
.item2011{grid-area: item2011;

}
.item2012{grid-area: item2012;

}
.item2013{grid-area: item2013;
display:none;
}
.item2014{grid-area: item2014;
display:none;
}
.item2015{grid-area: item2015;
display:none;
}
.item2016{grid-area: item2016;

}



/*sub profile3*/
.item9s31{
    grid-area: item9s31;

}
.item9s32{
    grid-area: item9s32;

}
.item9s33{
    grid-area: item9s33;

}
.item9s34{
    grid-area: item9s34;

}
.item9s35{
    grid-area: item9s35;

}
.item9s36{
    grid-area: item9s36;

}
.item9s37{
    grid-area: item9s37;

}
.item9s38{
    grid-area: item9s38;

}
.item9s39{
    grid-area: item9s39;

}
.item9s40{
    grid-area: item9s40;

}
.item9s41{
    grid-area: item9s41;

}
.item9s42{
    grid-area: item9s42;

}
.item9sage{
    grid-area: item9sage;

}



/*Sub Profile 4*/
.item9s4s1{
    grid-area: item9s4s1;

}
.item9s4s2{
    grid-area: item9s4s2;

}
.item9s4s3{
    grid-area: item9s4s3;

}
.item9s4s4{
    grid-area: item9s4s4;

}
.item9s4s5{
    grid-area: item9s4s5;

}
.item9s4s6{
    grid-area: item9s4s6;

}
.item9s4s7{
    grid-area: item9s4s7;

}
.item9s4s8{
    grid-area: item9s4s8;

}
.item9s4s9{
    grid-area: item9s4s9;

}
.item9s4s10{
    grid-area: item9s4s10;

}
.item9s4s11{
    grid-area: item9s4s11;

}
.item9s4s12{
    grid-area: item9s4s12;

}
.item9s4age{
    grid-area: item9s4age;

}

#FracPA{
    grid-area: FracPA;
}
#FracFina{
    grid-area: FracFina;
    display: none;
}

#TFPA{
    grid-area: TFPA;
}
#TFFina{
    grid-area: TFFina;
    display: none;
}

#PA1{
grid-area: PA1;
}

#SA1{
grid-area: SA1;
}

#PFina{
grid-area: PFina;
display: none;
}


#PA2{
grid-area: PA2;
}

#SA2{
grid-area: SA2;
}

#TPFina{
grid-area: TPFina;
/*display: none;*/
}
/*Finance details*/

.itemFFC1{
    grid-area: itemFFC1;

}
.itemFFC2{
    grid-area: itemFFC2;

}
.itemFFC3{
    grid-area: itemFFC3;

}
.itemFFC4{
    grid-area: itemFFC4;

}
.itemFFC5{
    grid-area: itemFFC5;

}
.itemFFC6{
    grid-area: itemFFC6;

}
.itemFFC7{
    grid-area: itemFFC7;

}
.itemFFC8{
    grid-area: itemFFC8;

}
.itemFFC9{
    grid-area: itemFFC9;

}
.itemFFC10{
    grid-area: itemFFC10;

}
.itemFFC11{
    grid-area: itemFFC11;

}
.itemFFC12{
    grid-area: itemFFC12;

}
.itemFFC13{
    grid-area: itemFFC13;

}
.itemFFC14{
    grid-area: itemFFC14;

}
.itemFFC15{
    grid-area: itemFFC15;

}
.itemFFC16{
    grid-area: itemFFC16;

}

/*TF*/

.itemTFFC1{
    grid-area: itemTFFC1;

}
.itemTFFC2{
    grid-area: itemTFFC2;

}
.itemTFFC3{
    grid-area: itemTFFC3;

}
.itemTFFC4{
    grid-area: itemTFFC4;

}
.itemTFFC5{
    grid-area: itemTFFC5;

}
.itemTFFC6{
    grid-area: itemTFFC6;

}
.itemTFFC7{
    grid-area: itemTFFC7;

}
.itemTFFC8{
    grid-area: itemTFFC8;

}
.itemTFFC9{
    grid-area: itemTFFC9;

}
.itemTFFC10{
    grid-area: itemTFFC10;

}
.itemTFFC11{
    grid-area: itemTFFC11;

}
.itemTFFC12{
    grid-area: itemTFFC12;

}
.itemTFFC13{
    grid-area: itemTFFC13;

}
.itemTFFC14{
    grid-area: itemTFFC14;

}
.itemTFFC15{
    grid-area: itemTFFC15;

}
.itemTFFC16{
    grid-area: itemTFFC16;

}

/*p*/


.itemPFC1{
    grid-area: itemPFC1;

}
.itemPFC2{
    grid-area: itemPFC2;

}
.itemPFC3{
    grid-area: itemPFC3;

}
.itemPFC4{
    grid-area: itemPFC4;

}
.itemPFC5{
    grid-area: itemPFC5;

}
.itemPFC6{
    grid-area: itemPFC6;

}
.itemPFC7{
    grid-area: itemPFC7;

}
.itemPFC8{
    grid-area: itemPFC8;

}
.itemPFC9{
    grid-area: itemPFC9;

}
.itemPFC10{
    grid-area: itemPFC10;

}
.itemPFC11{
    grid-area: itemPFC11;

}
.itemPFC12{
    grid-area: itemPFC12;

}
.itemPFC13{
    grid-area: itemPFC13;

}
.itemPFC14{
    grid-area: itemPFC14;

}
.itemPFC15{
    grid-area: itemPFC15;

}
.itemPFC16{
    grid-area: itemPFC16;

}


/*Tp*/


.itemTPFC1{
    grid-area: itemTPFC1;

}
.itemTPFC2{
    grid-area: itemTPFC2;
    

}


.itemTPFC3{
    grid-area: itemTPFC3;

}
.itemTPFC4{
    grid-area: itemTPFC4;

}
.itemTPFC5{
    grid-area: itemTPFC5;

}
.itemTPFC6{
    grid-area: itemTPFC6;

}
.itemTPFC7{
    grid-area: itemTPFC7;

}
.itemTPFC8{
    grid-area: itemTPFC8;

}
.itemTPFC9{
    grid-area: itemTPFC9;

}
.itemTPFC10{
    grid-area: itemTPFC10;

}
.itemTPFC11{
    grid-area: itemTPFC11;

}
.itemTPFC12{
    grid-area: itemTPFC12;

}
.itemTPFC13{
    grid-area: itemTPFC13;

}
.itemTPFC14{
    grid-area: itemTPFC14;

}
.itemTPFC15{
    grid-area: itemTPFC15;

}
.itemTPFC16{
    grid-area: itemTPFC16;

}


html,body
{
    width: 100%;
    height: auto;
    margin: 0px;
    padding: 0px;
    overflow-x: hidden; 
}

</style>

</head>
<body>
  <nav style="background-color:red;height:20px;padding:1px 20px 1px 10px;"><p style="font:bold;color:white;font-size:18px;font-family:Arial,Helvetica,sans-serif;">TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p></nav>
<div id="tabs">
    
  <button onclick="topFunction();" id="myBtn" title="Go to top">Home</button>
    <button  id="myBtnNext" >Next</button>
    <button  id="myBtnBack" >Back</button>
    <ul>
    <li><a href="#tabs-1">Profile</a></li>
    <li><a href="#tabs-2">Contracts</a></li>
    <li><a href="#tabs-3">Finance Data</a></li>
    <li><a href="#tabs-4">Payment Details</a></li>
    <li><a href="#tabs-5">Print</a></li>
   
  </ul>
  <form id="form1" runat="server"> 
      <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
      

  <div id="tabs-1">
    <div style="border:thin solid #C0C0C0;">
      
        
       <div id="pro1" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PROFILE</h3>
        <hr />
        <br />
         <div class="grid-container">
            <div class="item1">
        <p class="help_text_style">Profile ID</p>
                    <asp:TextBox ID="ProfileIDTextBox" runat="server" Enabled="True" Width="150px" class="text_input_style"></asp:TextBox>
           </div>
             <div class="itemVPID">
        <p>ViewPoint ID</p>
        <asp:TextBox ID="TextVPID" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                  </div>
             <div id="itemFly">
        <p>Lead Source</p>
        <asp:DropDownList ID="DropDownListFly" runat="server" Width="150px" ></asp:DropDownList>
           
                  </div>
 
            <div class="item2">                              
               
                    <p class="help_text_style">Date Insert</p>
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Width="150px" class="text_input_style"></asp:TextBox>
           </div>
            <div class="item3">              
                    <p class="help_text_style">Created By</p>
                    <asp:TextBox ID="CreatedByTextBox" runat="server" Enabled="False" Width="150px"></asp:TextBox>
           </div>

             <div class="item3a">
                   <p>Receptionist</p>
       
        <asp:DropDownList ID="ReceptionistDropDownList" runat="server" Width="150px" ></asp:DropDownList>
                   </div>
            <div class="item4">    
                       
                       <p class="help_text_style">Venue Country</p>
        <asp:DropDownList ID="VenueCountryDropDownList" runat="server" Width="150px"></asp:DropDownList>
           </div>
            <div class="item5">                   
                        
                       <p class="help_text_style">Sales Venue Group</p>
        <asp:DropDownList ID="VenueDropDownList" runat="server" Width="150px"></asp:DropDownList>
           </div>
             <div class="item5a">                   
                        
                       <p class="help_text_style">Sub Venue</p>
        <asp:DropDownList ID="VenueDropDownList2" runat="server" Width="150px"></asp:DropDownList>
           </div>
            <div class="item6">                  
                      
                       <p class="help_text_style">Venue</p>
        <asp:DropDownList ID="GroupVenueDropDownList" runat="server" Width="150px"></asp:DropDownList>
           </div>
            <div class="item7">
                  
                       <p class="help_text_style">Marketing Program</p>
        <asp:DropDownList ID="MarketingPrgmDropDownList" runat="server" Width="150px"></asp:DropDownList>
           </div>
            <div id="item8">                
                       
                       <p class="help_text_style">Marketing Source</p>
        <asp:DropDownList ID="AgentsDropDownList" runat="server" Width="150px"></asp:DropDownList>
           </div>
            <div id="item9">                  
                       
                       <p class="help_text_style">Source Code</p>
        <asp:DropDownList ID="AgentCodeDropDownList" runat="server" Width="150px"></asp:DropDownList>
           </div>

             <div id="item9a1">
            <p>Office Source</p>
            <asp:DropDownList ID="OfficeSourceDropDownList" runat="server" Width="150px"></asp:DropDownList>
        </div>

        <div id="item9a2">
            <p>Agent</p>
            <asp:DropDownList ID="FAgentDropDownList" runat="server" Width="150px"></asp:DropDownList>
        </div>
             <div id="item9a3">
            <p>Pre Arrival</p>
            <asp:DropDownList ID="PreArrivalDropDownList" runat="server" Width="150px"></asp:DropDownList>
        </div>


        </div>
       
        <br />
        <input id="chs" type="checkbox" onclick="shows();"/> <asp:Label ID="Label10" runat="server" Text="Label">Are you a Member?</asp:Label>
        <br />
                <div id ="hidden">
         <div class="grid-container2">
             <div class="item21">
                        <p class="help_text_style">Choose Member Type</p>
        <asp:DropDownList ID="MemType1DropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>
                 </div>
             <div class="item22">                 
                         <p class="help_text_style">Member Number</p>  
                        <asp:TextBox ID="Memno1TextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                 </div>
             <div class="item23">                   
                             <p class="help_text_style">Choose Member Type</p>
        <asp:DropDownList ID="MemType2DropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>
                 </div>
             <div class="item24">                 
    <p class="help_text_style">Member Number</p>  
        <asp:TextBox ID="Memno2TextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                 </div>
             </div>
   
        </div>
        <br />
        
        </div>
        
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PRIMARY PROFILE</h3>
        <hr />
        <br />
            <div class="grid-container3">
            <div class="item31">
                       <p class="help_text_style">Title</p>
                      <asp:DropDownList ID="primarytitleDropDownList" runat="server" Width="100px" style="height: 25px" ></asp:DropDownList>
                </div>
            <div class="item32">
    <p class="help_text_style">First Name</p>
        <asp:TextBox ID="pfnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                </div>
            <div class="item33">                 
                       <p class="help_text_style">Last Name</p>
        <asp:TextBox ID="plnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                </div>
                
            <div class="item34">    
       
                      <p class="help_text_style">Date Of Birth</p>
                       
        <asp:TextBox ID="datepicker1" runat="server" Enabled="True" Width="150px" onchange="getAge('datepicker1', 'TextPrimaryAge');"></asp:TextBox>
                </div>
                 
            <div class="item35"> 
                      <p class="help_text_style">Nationality</p>
        <asp:DropDownList ID="primarynationalityDropDownList" runat="server" Width="150px" style="height: 25px"></asp:DropDownList>
                </div>
                 
            <div class="item36">
                      <p class="help_text_style">Country</p>
        <asp:DropDownList ID="PrimaryCountryDropDownList" runat="server" Width="150px" style="height: 25px"></asp:DropDownList>
                </div>              
            <div class="item37">
 <p class="help_text_style">Email1</p>
        <asp:TextBox ID="pemailTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>
                 <div class="item37a">
 <p class="help_text_style">Email2</p>
        <asp:TextBox ID="pemailTextBox2" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>
        
            <div class="item38">
                       <p class="help_text_style">CCode</p>
                      <asp:DropDownList ID="primarymobileDropDownList" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
                </div>                 
            <div class="item39">
         <p class="help_text_style">Mobile Number</p>
        <asp:TextBox ID="pmobileTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>
                 
            <div class="item310">
                       <p class="help_text_style">CCode</p>
                      <asp:DropDownList ID="primaryalternateDropDownList" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
                </div>                  
            <div class="item311">
        <p class="help_text_style">Alternate Number</p>
        <asp:TextBox ID="palternateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>

                <div class="item311age">
                    <p>Age</p>
        <asp:TextBox ID="TextPrimaryAge" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                </div>

                <div class="item312">

                     <p class="help_text_style">Employee Status</p>
        <asp:DropDownList ID="employmentstatusDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>

                </div>

    </div>
         </div>
     <br />
        <br />

        <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>SECONDARY PROFILE</h3>
        <hr />
         <br />
            <div class="grid-container4">
            <div class="item41">
            <p class="help_text_style">Title</p>
            <asp:DropDownList ID="secondarytitleDropDownList" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
             </div>     
            <div class="item42">
                        <p class="help_text_style">First Name</p>
    
        <asp:TextBox ID="sfnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
             </div>                  
            <div class="item43">                    
                        <p class="help_text_style">Last Name</p>
        <asp:TextBox ID="slnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
             </div>                   
             <div class="item44">
                    
                        <p class="help_text_style">Date Of Birth</p>
        <asp:TextBox ID="datepicker2" runat="server" Enabled="True" Width="150px" onchange="getAge('datepicker2', 'TextSecondAge');"></asp:TextBox>
             </div>                   
            <div class="item45">                         
                        <p class="help_text_style">Nationality</p>
        <asp:DropDownList ID="secondarynationalityDropDownList" runat="server" Width="150px" style="height: 25px"></asp:DropDownList>
             </div>                 
            <div class="item46">
                        <p class="help_text_style">Country</p>
        <asp:DropDownList ID="SecondaryCountryDropDownList" runat="server" Width="150px" style="height: 25px"></asp:DropDownList>
             </div>              
            <div class="item47">                         
                        <p class="help_text_style">Email1</p>
        <asp:TextBox ID="semailTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
             </div>  
                <div class="item47a">                         
                        <p class="help_text_style">Email2</p>
        <asp:TextBox ID="semailTextBox2" runat="server" Enabled="True" Width="200px"></asp:TextBox>
             </div>                  
            <div class="item48">    
                         <p class="help_text_style">CCode</p>
                        <asp:DropDownList ID="secondarymobileDropDownList" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
             </div>                                
            <div class="item49">                       
         <p class="help_text_style">Mobile Number</p>
        <asp:TextBox ID="smobileTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
             </div>                
            <div class="item410">
                          <p class="help_text_style">CCode</p>
        <asp:DropDownList ID="secondaryalternateDropDownList" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
             </div>                    
            <div class="item411">
                        <p class="help_text_style">Alternate Number</p>
                        <asp:TextBox ID="salternateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
            </div>   
                
                <div class="item411age">
                    <p>Age</p>
        <asp:TextBox ID="TextSecondAge" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                </div>  
                
                <div class="item412">

                     <p class="help_text_style">Employee Status</p>
        <asp:DropDownList ID="SecondemploymentstatusDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>

                </div>
                
                           
            </div>
                 
   
         <br />
        <br />
        </div>
  
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>ADDRESS</h3>
        <hr />
        <br />
        <div class="grid-container5">
            <div class="item51">
         
                     <p class="help_text_style">Address Line1</p>
        <asp:TextBox ID="address1TextBox" runat="server" Enabled="True" Width="500px"></asp:TextBox>
            </div>
                <div class="item52">                
                      <p class="help_text_style">Address Line2</p>
        <asp:TextBox ID="address2TextBox" runat="server" Enabled="True" Width="500px"></asp:TextBox>
            </div>              
            <div class="item53">
                            <p class="help_text_style">State</p>
        <asp:TextBox ID="stateTextBox" runat="server" Enabled="True"></asp:TextBox>
            </div>                
            <div class="item54">
                      <p class="help_text_style">City</p>
      <asp:TextBox ID="cityTextBox" runat="server" Enabled="True"></asp:TextBox>
            </div>     
            <div class="item551">
                  <p>Country</p>
        
      <asp:DropDownList ID="AddCountryDropDownList" runat="server" Width="150px"></asp:DropDownList>
                  </div>            
            <div class="item55">
                      <p class="help_text_style">Postcode</p>
      <asp:TextBox ID="pincodeTextBox" runat="server" Enabled="True"></asp:TextBox>
            </div>                 
            <div class="item56">        
        
            </div>                
            <div class="item57">
                      <p class="help_text_style">Marital Status</p>
        <asp:DropDownList ID="MaritalStatusDropDownList" runat="server" Width="200px"></asp:DropDownList>
            </div>                 
            <div class="item58">
                      <p class="help_text_style">No of Year living together as a couple</p>
                <asp:TextBox ID="livingyrsTextBox" runat="server" Enabled="True"></asp:TextBox>
     
            </div>               
            
            </div>  
    
         
    
       <br />
       <br />
    </div>
      
   <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs2" type="checkbox" onclick="shows2();"/>
 <label for="chs2">SUB PROFILE 1</label>      
        <div id="panel" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <div class="grid-container6">
                <div class="item61">
                        <p class="help_text_style">Title</p>
                        <asp:DropDownList ID="subprofile1titleDropDownList" runat="server" style="height: 25px" Width="100px"></asp:DropDownList>
                </div>
                    <div class="item62">                  
                        <p class="help_text_style">First Name</p>
        <asp:TextBox ID="sp1fnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                </div>
                <div class="item63">                   
                     <p class="help_text_style">Last Name</p>
        <asp:TextBox ID="sp1lnameTextBox" runat="server" Enabled="True" Width="530px"></asp:TextBox>
                </div>
                <div class="item64">       
                        <p class="help_text_style">Date Of Birth</p>
        <asp:TextBox ID="datepicker3" runat="server" Enabled="True" Width="150px" onchange="getAge('datepicker3', 'TextSP1Age');"></asp:TextBox>
                </div>
                <div class="item65">                    
                        <p class="help_text_style">Nationality</p>
        <asp:DropDownList ID="subprofile1nationalityDropDownList" runat="server" style="height: 25px" Width="150px"></asp:DropDownList>
                </div>
                <div class="item66">                    
                         <p class="help_text_style">Country</p>
                       
        <asp:DropDownList ID="SubProfile1CountryDropDownList" runat="server" style="height: 25px" Width="150px"></asp:DropDownList>
                </div>
                <div class="item67">                   
                        
                        <p class="help_text_style">Email1</p>
        <asp:TextBox ID="sp1emailTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>
                <div class="item67a">                   
                        
                        <p class="help_text_style">Email2</p>
        <asp:TextBox ID="sp1emailTextBox2" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>

                <div class="item68">                  
      
                         <p class="help_text_style">CCode</p>

                         <asp:DropDownList ID="subprofile1mobileDropDownList" runat="server" style="height: 25px" Width="100px"></asp:DropDownList>
                </div>                  
                <div class="item69">                        
                        <p class="help_text_style">Mobile Number</p>
       
        <asp:TextBox ID="sp1mobileTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>
                 <div class="item610">                  
                        <p class="help_text_style">CCode</p>
                        <asp:DropDownList ID="subprofile1alternateDropDownList" runat="server" style="height: 25px" Width="100px"></asp:DropDownList>
                </div>                 
                <div class="item611">                             
                         <p class="help_text_style">Alternate Number</p>
        
        <asp:TextBox ID="sp1alternateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>
                <div class="item611age">
                    <p>Age</p>
        <asp:TextBox ID="TextSP1Age" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                </div>
                </div>       
   
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
            <div class="grid-container7">
                <div class="item71">
           
                         <p class="help_text_style">Title</p>
                        <asp:DropDownList ID="subprofile2titleDropDownList" runat="server" style="height: 25px" Width="100px"></asp:DropDownList>
                </div>  
                <div class="item72">                        
                        <p class="help_text_style">First Name</p>
     
        <asp:TextBox ID="sp2fnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                </div>  
                    
                <div class="item73">                        
                        <p class="help_text_style">Last Name</p>
        <asp:TextBox ID="sp2lnameTextBox" runat="server" Enabled="True" Width="430px"></asp:TextBox>
                </div>       
                <div class="item74">
                         <p class="help_text_style">Date Of Birth</p>
        <asp:TextBox ID="datepicker4" runat="server" Enabled="True" Width="150px" onchange="getAge('datepicker4', 'TextSP2Age');"></asp:TextBox>
                </div>                    
                <div class="item75">
                         <p class="help_text_style">Nationality</p>
                         <asp:DropDownList ID="subprofile2nationalityDropDownList" runat="server" style="height: 25px" Width="150px"></asp:DropDownList>
                </div>                  
                <div class="item76">
                        <p class="help_text_style">Country</p>
                        
        <asp:DropDownList ID="SubProfile2CountryDropDownList" runat="server" style="height: 25px" Width="150px"></asp:DropDownList>
                </div>                    
                <div class="item77">                        
                        <p class="help_text_style">Email1</p>
        <asp:TextBox ID="sp2emailTextBox" runat="server" Enabled="True" style="height: 25px" Width="200px"></asp:TextBox>
                </div> 
                <div class="item77a">                        
                        <p class="help_text_style">Email2</p>
        <asp:TextBox ID="sp2emailTextBox2" runat="server" Enabled="True" style="height: 25px" Width="200px"></asp:TextBox>
                </div>                   
                <div class="item78">         
                       <p class="help_text_style">CCode</p>
                      <asp:DropDownList ID="subprofile2mobileDropDownList" runat="server" style="height: 25px" Width="100px"></asp:DropDownList>
                </div>                   
                <div class="item79">                     
                        <p class="help_text_style">Mobile Number</p>
        <asp:TextBox ID="sp2mobileTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>                   
                <div class="item710">
                      <p class="help_text_style">CCode</p>
                <asp:DropDownList ID="subprofile2alternateDropDownList" runat="server" style="height: 25px" Width="100px"></asp:DropDownList>
                </div>                   
                <div class="item711">                      
                    <p class="help_text_style">Alternate Number</p>
        <asp:TextBox ID="sp2alternateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                </div>

                <div class="item711age">
                    <p>Age</p>
        <asp:TextBox ID="TextSP2Age" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                </div>
                </div>  
        
        
    </div>
         <br />
     <br />
   </div>


         
 <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chsp4" type="checkbox" onclick="shows4();"/>
 <label for="chsp4">SUB PROFILE 3</label>      
        <div id="panel3" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <div class="grid-SubProf3">
                <div class="item9s31">
                    <p>Title</p>
        <asp:DropDownList ID="SubP3TitleDropDownList" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s32">
                    <p>First Name</p>
        
        <asp:TextBox ID="SubP3FnameTextBox" runat="server" Enabled="True" Width="430px" ></asp:TextBox>
                    </div>
                <div class="item9s33">
                    <p>Last Name</p>
        
        <asp:TextBox ID="SubP3LnameTextBox" runat="server" Enabled="True" Width="430px" ></asp:TextBox>
                    </div>
        <div class="item9s34">
            <p>Date Of Birth</p>
       
        <asp:TextBox ID="SubP3DOB" runat="server" Enabled="True" Width="150px" onchange="getAge('SubP3DOB', 'TextSP3Age');"></asp:TextBox>
            </div>
                <div class="item9s35">
                    <p>Nationality</p>
          
        <asp:DropDownList ID="SubP3NationalityDropDownList" runat="server" Width="150px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s36">
                    <p>Country</p>
           
        <asp:DropDownList ID="SubP3CountryDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s37">
            <p>Email1</p>
          
        <asp:TextBox ID="SubP3EmailTextBox" runat="server" Enabled="True" Width="200px" ></asp:TextBox>
                    </div>
                <div class="item9s38">
            <p>Email2</p>
          
        <asp:TextBox ID="SubP3EmailTextBox2" runat="server" Enabled="True" Width="200px" ></asp:TextBox>
                    </div>
                <div class="item9s39">
        <p>CCode</p>
        <asp:DropDownList ID="SubP3CCDropDownList" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s40">
                    <p>Mobile Number</p>
                    
        <asp:TextBox ID="SubP3MobileTextBox" runat="server" Enabled="True" Width="200px" ></asp:TextBox>
                    </div>
                <div class="item9s41">
        <p>CCode</p>
        <asp:DropDownList ID="SubP3CCDropDownList2" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s42">
                    <p>Alternate Number</p>
                    
        <asp:TextBox ID="SubP3AMobileTextBox" runat="server" Enabled="True" Width="200px" ></asp:TextBox>
                    </div>
                <div class="item9sage">
                    <p>Age</p>
        <asp:TextBox ID="TextSP3Age" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                </div>
         </div>
    </div>
         <br />
     <br />
   </div>

      
 <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chsp5" type="checkbox" onclick="shows5();"/>
 <label for="chsp5">SUB PROFILE 4</label>      
        <div id="panel4" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <div class="grid-SubProf4">
                <div class="item9s4s1">
                    <p>Title</p>
        <asp:DropDownList ID="SubP4TitleDropDownList" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s4s2">
                    <p>First Name</p>
        
        <asp:TextBox ID="SubP4FnameTextBox" runat="server" Enabled="True" Width="430px" ></asp:TextBox>
                    </div>
                <div class="item9s4s3">
                    <p>Last Name</p>
        
        <asp:TextBox ID="SubP4LnameTextBox" runat="server" Enabled="True" Width="430px" ></asp:TextBox>
                    </div>
        <div class="item9s4s4">
            <p>Date Of Birth</p>
       
        <asp:TextBox ID="SubP4DOB" runat="server" Enabled="True" Width="150px"  onchange="getAge('SubP4DOB', 'TextSP4Age');" ></asp:TextBox>
            </div>
                <div class="item9s4s5">
                    <p>Nationality</p>
          
        <asp:DropDownList ID="SubP4NationalityDropDownList" runat="server" Width="150px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s4s6">
                    <p>Country</p>
           
        <asp:DropDownList ID="SubP4CountryDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s4s7">
            <p>Email1</p>
          
        <asp:TextBox ID="SubP4EmailTextBox" runat="server" Enabled="True" Width="200px" ></asp:TextBox>
                    </div>
                <div class="item9s4s8">
            <p>Email2</p>
          
        <asp:TextBox ID="SubP4EmailTextBox2" runat="server" Enabled="True" Width="200px" ></asp:TextBox>
                    </div>
                <div class="item9s4s9">
        <p>CCode</p>
        <asp:DropDownList ID="SubP4CCDropDownList" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s4s10">
                    <p>Mobile Number</p>
                    
        <asp:TextBox ID="SubP4MobileTextBox" runat="server" Enabled="True" Width="200px" ></asp:TextBox>
                    </div>
                <div class="item9s4s11">
        <p>CCode</p>
        <asp:DropDownList ID="SubP4CCDropDownList2" runat="server" Width="100px" style="height: 25px"></asp:DropDownList>
                    </div>
                <div class="item9s4s12">
                    <p>Alternate Number</p>
                    
        <asp:TextBox ID="SubP4AMobileTextBox" runat="server" Enabled="True" Width="200px" ></asp:TextBox>
                    </div>
                <div class="item9s4age">
                    <p>Age</p>
        <asp:TextBox ID="TextSP4Age" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                </div>
         </div>
    </div>
         <br />
     <br />
   </div>

 
        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>STAY DETAILS</h3>
        <hr />
        <br />
            <div class="grid-container8">
           <div class="item81">    
                <p>Resort Name</p>
        
        <asp:TextBox ID="hotelTextBox" runat="server" Enabled="True"></asp:TextBox>
               </div> 
                <div class="item82"> 
                     <p>Resort Room No</p>
        
        <asp:TextBox ID="roomnoTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div> 
        <div class="item83"> 
             <p>Arrival</p> 
     
        <asp:TextBox ID="datepicker5" runat="server" Enabled="True"></asp:TextBox>
            </div>
                <div class="item84"> 
                     <p>Departure</p> 
    
        <asp:TextBox ID="datepicker6" runat="server" Enabled="True"></asp:TextBox>
                </div>

                <div class="item85"> 
                     <p>Sales Deck Check-In Time</p>
      
        <asp:TextBox ID="deckcheckintimeTextBox" runat="server" placeholder="HH:MM" Enabled="True"></asp:TextBox>
                    </div>
                <div class="item86"> 
                     <p>Sales Deck Check-Out Time</p> 
     
        <asp:TextBox ID="deckcheckouttimeTextBox" runat="server" placeholder="HH:MM" Enabled="True"></asp:TextBox>
                    </div>
                </div>
             <div class="grid-container88">
                <div id="item88s1">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p1">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div id="item88q1">
                     <p>Gift Price</p>
      
        <asp:TextBox ID="TextBoxGPrice1" runat="server" Enabled="True" onchange="pp('TextBoxGPrice1');"></asp:TextBox>
                    </div>
                <div id="item88cb">
                     <p>Charge Back</p>
      
        <asp:TextBox ID="TextBoxChargeBack" runat="server" Enabled="True" TextMode="MultiLine" Height="50px" Width="200px"></asp:TextBox>
                    </div>

                <div id="item88s2">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList2" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p2">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox2" runat="server" Enabled="True" ></asp:TextBox>
                    </div>
                
                <div id="item88q2">
                     <p>Gift Price</p>
      
        <asp:TextBox ID="TextBoxGPrice2" runat="server" Enabled="True" onchange="pp('TextBoxGPrice2');"></asp:TextBox>
                    </div>
                <div id="item88s3">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList3" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p3">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox3" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                
                <div id="item88q3">
                     <p>Gift Price</p>
      
        <asp:TextBox ID="TextBoxGPrice3" runat="server" Enabled="True" onchange="pp('TextBoxGPrice3');"></asp:TextBox>
                    </div>
                  <div id="item88s4">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList4" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p4">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox4" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                
                <div id="item88q4">
                     <p>Gift Price</p>
      
        <asp:TextBox ID="TextBoxGPrice4" runat="server" Enabled="True" onchange="pp('TextBoxGPrice4');"></asp:TextBox>
                    </div>
                        <div id="item88s5">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList5" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p5">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox5" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                
                <div id="item88q5">
                     <p>Gift Price</p>
      
        <asp:TextBox ID="TextBoxGPrice5" runat="server" Enabled="True" onchange="pp('TextBoxGPrice5');"></asp:TextBox>
                    </div>
                <div id="item88s6">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList6" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p6">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox6" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                
                <div id="item88q6">
                     <p>Gift Price</p>
      
        <asp:TextBox ID="TextBoxGPrice6" runat="server" Enabled="True" onchange="pp('TextBoxGPrice6');"></asp:TextBox>
                    </div>
                   <div id="item88s7">
         <p>Choose Gift Option</p>
     
        <asp:DropDownList ID="giftoptionDropDownList7" runat="server" Width="200px"></asp:DropDownList>
                    </div>
                <div id="item88p7">
                     <p>Voucher No.</p>
      
        <asp:TextBox ID="vouchernoTextBox7" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                
                <div id="item88q7">
                     <p>Gift Price</p>
      
        <asp:TextBox ID="TextBoxGPrice7" runat="server" Enabled="True" onchange="pp('TextBoxGPrice7');"></asp:TextBox>
                    </div>
                </div>
           
             <div id='kk2'>
		<input type="button" id="bittu" value="More Gifts" onclick="f();"/>
	</div>
             
            <div class="grid-container882">
                <div class="item8821">  
                     <p>Comment if Any</p>
    
        <asp:TextBox ID="commentTextBox" runat="server" Enabled="True" TextMode="MultiLine" Height="50px" Width="200px"></asp:TextBox>
                    </div>
        <div class="item8822"> 
             <p>Guest Status</p>
     
        <asp:DropDownList ID="gueststatusDropDownList" runat="server" Width="200px" onchange="loadQStatus();"></asp:DropDownList>
            <br />
            <br />
            
             <p id="gs2" ">Q Status</p>
     
        <asp:DropDownList ID="QStatusDropDownList1" runat="server" Width="200px"></asp:DropDownList>
            </div>
                <div class="item8823">
                     <p>Tour Date</p>
        
        <asp:TextBox ID="tourdatedatepicker" runat="server" Enabled="True"></asp:TextBox>
                    </div>
               <div class="item8824"> 
                     <p>Sales Represntative</p> 
       
        <asp:DropDownList ID="salesrepDropDownList" runat="server" Width="200px"></asp:DropDownList>
                    </div>

                <div class="item8826">
                     <p>Taxi in Price</p>
        
        <asp:TextBox ID="taxipriceInTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div class="item8827"> 
                     <p>Taxi in Reference</p> 
     
        <asp:TextBox ID="TaxiRefInTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div class="item8828"> 
                     <p>Taxi out Price</p>
          
        <asp:TextBox ID="TaxiPriceOutTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                <div class="item8829">
                     <p>Taxi out Reference</p>  
     
        <asp:TextBox ID="TaxiRefOutTextBox" runat="server" Enabled="True"></asp:TextBox>
                    </div>
         </div>

        
       
       
        
        </div>
        <br />
        <asp:CheckBox ID="Regterms1" runat="server" Text="Registration Card Terms 1" />
        <asp:CheckBox ID="Regterms2" runat="server" Text="Registration Card Terms 2" />
        <br />

          <asp:Button ID="btn" runat="server" Text="Next Step" OnClientClick="return false;" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button6" runat="server" Text="Update" OnClientClick="if (!hi3()) return false;" OnClick="Button6_Click" />
    
   
</div>

  </div>

    <div id="tabs-2" style="background-color:#e9e9e9">
   
       <div id="contract_tab" style="margin-top:10px;margin-left:5px;margin-right:5px; margin-bottom:10px; overflow:hidden; ">
           <div class="grid-container9">
               <div class="item91">
            <p>Choose Contract Type:</p>
          <asp:DropDownList ID="DropDownList40" runat="server"  Width="200px" style="height: 25px" onchange="contracttype();">
              <%--<asp:ListItem>Choose Contract Type</asp:ListItem>
              <asp:ListItem>Fractional</asp:ListItem>
              <asp:ListItem Enabled="True">Points</asp:ListItem>
              <asp:ListItem>Trade Into Fractional</asp:ListItem>
              <asp:ListItem>Trade Into Points</asp:ListItem>--%>
          </asp:DropDownList>
           </div>
               <div class="item92">
          <p>Affiliate Type</p>
          <input id="ca1" type="checkbox" onclick="addvalue1();" checked="checked" /><asp:Label ID="Label80" runat="server" Text="Label">ICE</asp:Label>
          <input id="ca2" type="checkbox" onclick="addvalue2();" checked="checked"  /><asp:Label ID="Label81" runat="server" Text="Label">Holiday Plus</asp:Label>
            </div>          
               <div class="item93">
          <p>Sales Representative</p>
          <asp:DropDownList ID="contsalesrepDropDownList" runat="server" style="height: 25px" Width="200px"></asp:DropDownList>
            </div>
               <div class="item94">
                   <p>TO Manager</p>
         
          <asp:DropDownList ID="TOManagerDropDownList" runat="server" style="height: 25px" Width="200px"></asp:DropDownList>
            </div>
               <div class="item95">
          <p>Button Up</p>
           
          <asp:DropDownList ID="ButtonUpDropDownList" runat="server" style="height: 25px" Width="200px"></asp:DropDownList>
            </div>
               <div class="item96">
                   <p>Finance Currency</p>
          
           <asp:DropDownList ID="FinanceCurrencyDropDownList" onchange="CurrencyFees();" style="height: 25px" runat="server" Width="200px"></asp:DropDownList>
            </div>
               <%--<div class="item97">
                   <p>Deal Status</p>
                    <asp:DropDownList ID="DealDrawerDropDownList" runat="server" Width="200px" style="height: 25px"  ></asp:DropDownList>
               </div>--%>

            </div>
           <br />
           <p id="texte"><asp:Label ID="Label1" runat="server" Text="Label">Exchange Rate</asp:Label>&nbsp;&nbsp;<asp:TextBox ID="TextExchangeRate" runat="server" Enabled="True"  Width="200px" onchange="othercurrency();"></asp:TextBox></p>
           <asp:TextBox ID="TextBox96" runat="server" Enabled="True"></asp:TextBox>
           <asp:TextBox ID="TextICE" runat="server" Enabled="True"></asp:TextBox>
           <asp:TextBox ID="TextHP" runat="server" Enabled="True"></asp:TextBox>
           <asp:TextBox ID="texttest" runat="server" Enabled="True" ></asp:TextBox>
          <br />
           
           
           <div id="contract-container">
            <div id="cleft" style=" width:605px;">
                <div id="cdiv1" style="margin:5px 5px;">
                <table  cellpadding="5px" cellspacing="5px">
                    <tr>
                        <td><h5>FRACTIONAL</h5></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label85" runat="server" Text="Label">Choose Resort</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ResortDropDownListF"  runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label37" runat="server" Text="Label">Contract Number</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="ContractNoFractTextBox" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label70" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ResidenceNoDropDownListF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label71" runat="server" Text="Label">Choose Residence Type</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ResidenceTypeDropDownListF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label72" runat="server" Text="Label">Fractional Interest</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="FractionalIDropDownListF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label73" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="EntitlementFracDropDownList"  runat="server" Width="200px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label74" runat="server" Text="Label">First Year Occupancy</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextFOccuF" runat="server" Enabled="True" onchange="add1('TextFOccuF','TextFDuration','TextFOccuL');"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label75" runat="server" Text="Label">Duration</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextFDuration" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label76" runat="server" Text="Label">Last Year Occupancy</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextFOccuL" runat="server" Enabled="True"  onclick="add1('TextFOccuF','TextFDuration','TextFOccuL');"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px">
                        
                         Lease Back?<input type="checkbox" id="chs6" onclick="shows6();lease_back('chs6', 'TextMCFees');"/> <label id="yes2" style="color:forestgreen">YES</label><label id="yess2" style="color:forestgreen">(management charge: 0)</label><label id="no2" style="color: red">NO</label>
                        </td>
                    </tr>
                </table>

                </div>
                <div id="cdiv2" style="margin:5px 5px;">

                       <table cellpadding="5px" cellspacing="5px">
                    <tr>
                        <td><h5>POINTS</h5></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label94" runat="server" Text="Label">Club</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ContractClubPDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label38" runat="server" Text="Label">Contract Number</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="ContractNoPointsTextBox" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label100" runat="server" Text="Label">No of Points Purchased</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextNoPoints" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label97" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="EntitlementPoinDropDownList" onchange="entitlementP();" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                                
                     <tr id="hpmemfees">
                        <td width="300px"><asp:Label ID="Label101" runat="server" Text="Label">Membership Fees</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextPMemFees" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr id="hpprofees">
                        <td width="300px"><asp:Label ID="Label102" runat="server" Text="Label">Points Property Fees</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextPPropFees" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label95" runat="server" Text="Label">First Year Occupancy</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextPFOccu" runat="server" Enabled="True" onchange="add1('TextPFOccu','TextPDura','TextPLOccu');"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label98" runat="server" Text="Label">Duration</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextPDura" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label99" runat="server" Text="Label">Last Year Occupancy</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextPLOccu" runat="server" Enabled="True" onclick="add1('TextPFOccu','TextPDura','TextPLOccu');"></asp:TextBox></td>
                    </tr>
                   
                </table>

                </div>
            <div id="cdiv3" style="margin:5px 5px;">
               <table cellpadding="5px" cellspacing="5px"  >
                   
                     <tr>
                        <td><h5>OLD CONTRACT DETAILS</h5></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label13" runat="server" Text="Label">From Contract Type </asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ContTypeDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList><asp:TextBox ID="hiddentconttype2" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr>
                       
                    </table>

                
                 <div id="tableTF1">
                <table cellpadding="5px" cellspacing="5px"  >
                    <tr>
                        <td width="300px"><asp:Label ID="Label14" runat="server" Text="Label">Old Agreement No.</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextOldAgreeNoTF1" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label15" runat="server" Text="Label" >Club</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="OldClubDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label16" runat="server" Text="Label">Old No of Points</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextOldNoOfPointsTF" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr >
                        <td  width="300px"><asp:Label ID="Label17" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="EntitleDropDownListTF1" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>  
                    </table>
                    </div>
                <div id="tableTF2">
                    <table cellpadding="5px" cellspacing="5px"  >
                        <tr>
                        <td width="300px"><asp:Label ID="Label18" runat="server" Text="Label">Old Agreement No.</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextOldAgreeNoTF2" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                        <tr >
                        <td  width="300px"><asp:Label ID="Label19" runat="server" Text="Label">Choose Resort</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="ResortDropDownListTF1" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                     <tr >
                        <td  width="300px"><asp:Label ID="Label20" runat="server" Text="Label">Appartment Type</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="AppartTypeDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                        <tr >
                        <td  width="300px"><asp:Label ID="Label21" runat="server" Text="Label">Num Occupied</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="NoOccuDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    
                        <tr >
                        <td  width="300px"><asp:Label ID="Label22" runat="server" Text="Label">Period</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="PeriodDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                        
                    <tr >
                        <td  width="300px"><asp:Label ID="Label23" runat="server" Text="Label">Season</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="SeasonDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr >
                        <td  width="300px"><asp:Label ID="Label24" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="EntitleDropDownListTF2" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    
                        </table>
                </div>
                <div id="tableTF3">
                    <table cellpadding="5px" cellspacing="5px" >
                        <tr>
                        <td width="300px"><asp:Label ID="Label25" runat="server" Text="Label">Old Agreement No.</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextOldAgreeNoTF3" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                        <tr >
                        <td  width="300px"><asp:Label ID="Label26" runat="server" Text="Label">Choose Resort</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="ResortDropDownListTF3" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                     <tr >
                        <td  width="300px"><asp:Label ID="Label27" runat="server" Text="Label">Residence No</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="ResidenceNoDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                        <tr >
                        <td  width="300px"><asp:Label ID="Label28" runat="server" Text="Label">Choose Residence Type</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="ResiTypeDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    
                        <tr >
                        <td  width="300px"><asp:Label ID="Label29" runat="server" Text="Label">Fractional Interest</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="FracIntDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                        
                     <tr >
                        <td  width="300px"><asp:Label ID="Label31" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="EntitleDropDownListTF3" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    
                        </table>
                </div>
                <table cellpadding="5px" cellspacing="5px" >
                    <tr>
                        <td><h5>TRADE INTO FRACTIONAL</h5></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label103" runat="server" Text="Label">Choose Resort</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ResortDropDownListTF" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label39" runat="server" Text="Label">Contract Number</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="ContractNoTFTextBox" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label104" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ResidenceNoDropDownListTF1" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label105" runat="server" Text="Label">Choose Residence Type</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ResiTypeDropDownListTF1" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label106" runat="server" Text="Label">Fractional Interest</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="FracIntDropDownListTF1" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label107" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="EntitlementTFracDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label108" runat="server" Text="Label">First Year Occupancy</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextFYOccuTF" runat="server" Enabled="True" onchange="add1('TextFYOccuTF','TextDurationTF','TextLYOccuTF');"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label109" runat="server" Text="Label">Duration</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextDurationTF" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label110" runat="server" Text="Label">Last Year Occupancy</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextLYOccuTF" runat="server"  onclick="add1('TextFYOccuTF','TextDurationTF','TextLYOccuTF');" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px">
                        Lease Back?<input type="checkbox" id="chs5" onclick="shows5();lease_back('chs5','TextMCFees');"/> <label id="yes1" style="color:forestgreen">YES</label><label id="yess1" style="color:forestgreen">(management charge: 0)</label><label id="no1" style="color: red">NO</label>
                        </td>
                    </tr>
                </table>


            </div>
            <div id="cdiv4" style="margin:5px 5px;">
                    <table cellpadding="5px" cellspacing="5px"  >
                   
                     <tr>
                        <td><h5>OLD CONTRACT DETAILS</h5></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label2" runat="server" Text="Label">From Contract Type </asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ContTypeTPDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList><asp:TextBox ID="hiddentconttype" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr>
                       
                    </table>
                <div id="table1">
                <table cellpadding="5px" cellspacing="5px"  >
                    <tr>
                        <td width="300px"><asp:Label ID="Label124" runat="server" Text="Label">Old Agreement No.</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextOldAgreeNoTP1" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label121" runat="server" Text="Label" >Club</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ContractClubTPDropDownList1" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label125" runat="server" Text="Label">Old No of Points</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextOldNoPointsTP" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr >
                        <td  width="300px"><asp:Label ID="Label11" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="EntitlementDropDownList1" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>  
                    </table>
                    </div>
                <div id="table2">
                    <table cellpadding="5px" cellspacing="5px"  >
                        <tr>
                        <td width="300px"><asp:Label ID="Label3" runat="server" Text="Label">Old Agreement No.</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextOldAgreeNoTP2" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                        <tr >
                        <td  width="300px"><asp:Label ID="Label4" runat="server" Text="Label">Choose Resort</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="ResortTPDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                     <tr >
                        <td  width="300px"><asp:Label ID="Label5" runat="server" Text="Label">Appartment Type</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="AppartmentTypeTPDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                        <tr >
                        <td  width="300px"><asp:Label ID="Label6" runat="server" Text="Label">Num Occupied</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="NumbOccuTPDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    
                        <tr >
                        <td  width="300px"><asp:Label ID="Label7" runat="server" Text="Label">Period</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="PeriodTPDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                        
                    <tr >
                        <td  width="300px"><asp:Label ID="Label8" runat="server" Text="Label">Season</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="SeasonTPDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr >
                        <td  width="300px"><asp:Label ID="Label9" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td  width="300px"><asp:DropDownList ID="EntitleTPDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr >
                        <td  width="300px"><asp:Label ID="Label41" runat="server" Text="Label">Points</asp:Label></td>
                         <td width="300px"><asp:TextBox ID="TextTPPoints" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                        </table>
                </div>
                        
                         
                      
                <table cellpadding="5px" cellspacing="5px"  >
                    <tr>
                        <td><h5>TRADE INTO POINTS</h5></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label126" runat="server" Text="Label">New Points Purchased</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextNewPointsTP" runat="server" Enabled="True" onchange="TotalPointsCalc();"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label127" runat="server" Text="Label">Total Points</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextTotalPointsTP" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label113" runat="server" Text="Label">Club</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="ContractClubTPDropDownList2" runat="server" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label40" runat="server" Text="Label">Contract Number</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="ContractNoTPTextBox" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label115" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td width="300px"><asp:DropDownList ID="EntitlementTPoinDropDownList" runat="server" onchange="entitlementTP();" Width="200px" style="height: 25px"></asp:DropDownList></td>
                    </tr>
                                
                     <tr id="htpmemfees">
                        <td width="300px"><asp:Label ID="Label116" runat="server" Text="Label">Membership Fees</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextMembershipFeesTP" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr id="htpprofees">
                        <td width="300px"><asp:Label ID="Label117" runat="server" Text="Label">Points Property Fees</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextPropertyFeesTP" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label118" runat="server" Text="Label">First Year Occupancy</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextFYOccTP" runat="server" Enabled="True" onchange="add1('TextFYOccTP','TextDurationTP','TextLYOccTP');"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="300px"><asp:Label ID="Label119" runat="server" Text="Label">Duration</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextDurationTP" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="300px"><asp:Label ID="Label120" runat="server" Text="Label">Last Year Occupancy</asp:Label></td>
                        <td width="300px"><asp:TextBox ID="TextLYOccTP" runat="server" onclick="add1('TextFYOccTP','TextDurationTP','TextLYOccTP');" Enabled="True"></asp:TextBox></td>
                    </tr>
                   
                </table>
                </div>
            </div>
            <div id="cright" style=" width:605px;">
                <div class="grid-container20">
                   <div class="item2016">
                    <h5>FINANCE</h5>
                       </div>
                    
                    <div class="item201">
                        <p>Management Charge Fees</p>
                    </div>
                    <div class="item202">
                        <asp:TextBox ID="TextMCFees" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                    <div id="item202a1">
                        <p>Membership Fees</p>
                    </div>
                    <div id="item202b1">
                         <asp:TextBox ID="TextMemFeesp" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                    <div id="item202a2">
                        <p>Points Property Fees</p>
                    </div>
                    <div id="item202b2">
                         <asp:TextBox ID="TextPropFeesp" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                    <div class="item203a">
                        <p>Deal Status</p>
                    </div>
                    <div class="item204a">
                        <asp:DropDownList ID="DealDrawerDropDownList" runat="server" Width="200px" style="height: 25px"  ></asp:DropDownList>
                    </div>
                    <div id="item203b">
                        <p>Cancel Group Venue</p>
                    </div>
                    <div id="item204b">
                        <asp:DropDownList ID="CGroupvenueDropDownList" runat="server" Width="200px" style="height: 25px"  ></asp:DropDownList>
                    </div>
                    <div id="item203c">
                        <p>Cancel Reason</p>
                    </div>
                    <div id="item204c">
                        <asp:DropDownList ID="CReasonDropDownList" runat="server" Width="200px" style="height: 25px"  ></asp:DropDownList>
                    </div>
                    <div id="item203d">
                        <p>Cancel Date</p>
                    </div>
                    <div id="item204d">
                         <asp:TextBox ID="CancelDateTextBox" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                    </div>
                    <div class="item203">
                    <p>Deposit Payment Method</p>
                    </div>
                    <div class="item204">
                         <asp:DropDownList ID="DPMFractDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>
                    </div>
                    <div class="item205">
                        <p>Balance Payment Method</p>
                    </div>
                     <div class="item206">
                        <asp:DropDownList ID="PayMethodDropDownList" onchange="pay_method();" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>
                    </div>
                    
                    <div id="item2017">
                        <p>Finance Currency</p>
                    </div>
                     <div id="item2018">
                        <asp:DropDownList ID="CrownFinanceCurrDropDownList"  runat="server" Width="200px" style="height: 25px"></asp:DropDownList>
                    </div>
                    <div id="item2017a">
                        <p>EUR</p>   
                    </div>
                     <div id="item2018a">
                        <asp:TextBox ID="TextEuroRateP" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                    </div>
                    <div id="item2017b">
                        <p>AUD</p>
                    </div>
                     <div id="item2018b">
                        <asp:TextBox ID="TextAusRateP" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                    </div>
                    <div id="item2017c">
                        <p>GBP</p>
                    </div>
                     <div id="item2018c">
                        <asp:TextBox ID="TextGbpRateP" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                    </div>
                    <div id="item2017d">
                        <p>IDA</p>
                    </div>
                     <div id="item2018d">
                        <asp:TextBox ID="TextIdaRateP" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                    </div>
                    <div id="item207">
                        <p>Finance Number</p>
                    </div>
                     <div id="item208">
                        <asp:TextBox ID="TextPnumb" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                    </div>
                    <div id="item208a">
                        <p>Year Of Interest</p>
                    </div>
                    <div id="item208b">
                         <asp:DropDownList ID="YearOfIntDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>
                    </div>
                    <div id="item208c">
                        <p>Use Payment Protection</p>
                    </div>
                    <div id="item208d">
                         <asp:CheckBox ID="UsePayProtectCheckBox" runat="server" />
                    </div>
                     
                             

                    
                    
                     <div class="item209">
                        <p>Balance Payment Method</p>
                    </div>
                     <div class="item2010">
                       <%--<asp:DropDownList ID="BPMDropDownList" runat="server" Width="200px" style="height: 25px"></asp:DropDownList>--%>
                    </div>
                    <div class="item2011">
                        <p>Identity Proof</p>
                    </div>
                     <div class="item2012">
                       <input id="chs4" type="checkbox" onclick="shows4chs4();"/><label id="yes" style="color:forestgreen">YES</label><label id="no" style="color: red">NO</label><asp:TextBox ID="Textcheckchs4" runat="server" Enabled="True" Width="200px"></asp:TextBox> 
                    </div>
                       
                        <div id="item101">
                        <asp:Label ID="Label92" runat="server" Text="Label">PAN Card</asp:Label>
                        </div>
                        <div id="item102">
                        <asp:TextBox ID="TextPan" runat="server" Enabled="True" Width="200px"></asp:TextBox> 
                        </div>                                  
                 
                        <div id="item103">            
                        <asp:Label ID="Label93" runat="server" Text="Label">ADHAR Card</asp:Label>
                        </div>
                        <div id="item104">
                        <asp:TextBox ID="TextAdhar" runat="server" Enabled="True" Width="200px"></asp:TextBox>                
                        </div>
                      

                    
                      <div id="item111" >  
                      <asp:Label ID="Label32" runat="server" Text="Label">ID</asp:Label>
                      </div>
                      <div id="item112">
                      <asp:TextBox ID="TextOtherID" runat="server" Enabled="True" Width="200px"></asp:TextBox>
                      </div>  
                    
                    <div class="item2013">
                        <h5>CONTRACT NUMBER</h5>
                    </div>
                     <div class="item2014">
                       <p>Generated Contract Number</p>
                    </div>
                    <div class="item2015">
                       <asp:TextBox ID="TextContractNumb" runat="server" Enabled="True"></asp:TextBox>
                    </div>
                </div>
        
            </div>                                                          
          
          </div>
           <br />
           
      </div>
        <br />
        <div id="b1" >
           <asp:Button ID="Btn2" runat="server" Text="Next Step" />
            </div>
   </div>

  
       <div id="tabs-3" style="background-color:#e9e9e9;">
          <div id="finance-container1" style="margin-top:10px;padding-top:10px; ">
              <br />
              <table>
                  <tr>
                <td width="300px"><asp:Label ID="Label78" runat="server" Text="Label">Purchase Price</asp:Label></td>
                <td width="300px"><asp:TextBox ID="TextPurchasePrice" runat="server" Enabled="True" ></asp:TextBox></td>
            </tr>
                 <tr></tr>
                  <tr></tr>
            <tr>
                <td width="300px"><asp:Label ID="Label86" runat="server" Text="Label">Admin Fees</asp:Label></td>
                <td width="300px"><asp:TextBox ID="TextAdminFees" runat="server" Enabled="True"></asp:TextBox></td>
            </tr> 
              </table>
               <div id="ffractional1" >
                   <div id="FracPA"><h4>PURCHASE AGREEMENT</h4>
                <table cellpadding="5px" cellspacing="5px">
                    
                    <tr>
                        <td width="180px"><asp:Label ID="Label129" runat="server" Text="Label">Deposit</asp:Label>
                        </td>  

                        <td width="400px">
                           <%-- <asp:DropDownList ID="DPMFractDropDownList" runat="server" Width="150px"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label130" runat="server" Text="Label">Deposit</asp:Label>--%>
                        <asp:TextBox ID="TextDepositF" runat="server" Enabled="True" Width="100px" onchange="adminfee();"></asp:TextBox></td>
                    </tr>
                     </table>
                    
                       <table id="fbala"  cellpadding="5px" cellspacing="5px">
                           <tr>
                               <td width="180px"><asp:Label ID="Label46" runat="server" Text="Label">Initial Deposit</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextInitDepoF" runat="server" Enabled="True" Width="328px" onchange="load_Ibalance();"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td width="180px"><asp:Label ID="Label47" runat="server" Text="Label">Balance Deposit</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextBalDepoF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                           </tr>
                            <tr>
                               <td width="180px"><asp:Label ID="Label53" runat="server" Text="Label">Next Balance Deposit Date</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextBoxNBDF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                           </tr>
                           </table>


                     <table cellpadding="5px" cellspacing="5px">
                    <tr>
                        <td><asp:Label ID="Labtotalbalance" runat="server" Text="Label">Total Balance</asp:Label></td>
                        <td><asp:TextBox ID="TextTotalBalanceF" runat="server" Enabled="True" Width="328px" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label131" runat="server" Text="Label">Admission Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAdmissFeesF" runat="server" Enabled="True" Width="328px" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label132" runat="server" Text="Label">Administration Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAdminFeesF" runat="server" Enabled="True" Width="328px"  ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label133" runat="server" Text="Label">Total Purchase Price</asp:Label></td>
                        <td><asp:TextBox ID="TextTotalPurchasePriceF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label134" runat="server" Text="Label">Country Tax</asp:Label></td>
                        <td><asp:TextBox ID="TextCountryTaxF" runat="server" Enabled="True" Width="100px"></asp:TextBox></td>
                        
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label136" runat="server" Text="Label">Balance Due PA</asp:Label></td>
                        <td><asp:TextBox ID="TextBalanceDueF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label137" runat="server" Text="Label">No of Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextNoOfInstallF" runat="server" Enabled="True" Width="328px" onchange="changeInstallNo('Button9','Button13');"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label138" runat="server" Text="Label">First Payment Date</asp:Label></td>
                        <td><asp:TextBox ID="datepicker10" runat="server" Enabled="True" Width="328px" onchange="changefocus('TextAdmissFeesF');"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label139" runat="server" Text="Label">Amount Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextInstallAmtF" runat="server" onclick="installFirstSecond();" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label140" runat="server" Text="Label">First Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextFirstInstallAmtF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><p>Remarks</p></td>
                    <td><asp:TextBox ID="TextRemarksF" runat="server" Enabled="True" Width="328px" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><p>Balance Due Dates in PA</p></td>
                    <td><asp:TextBox ID="TextDueDatesPAF" runat="server" Enabled="True" Width="328px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                </table>
                   <br />
                        <br />
                       <div style="display:none;" >
                       <asp:TextBox ID="TextRemarksF2" runat="server" Enabled="True" Width="328px" Height="150px" TextMode="MultiLine"></asp:TextBox>
                       <br />
                       <asp:TextBox ID="TextDueDatesPAF2" runat="server" Enabled="True" Width="328px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                       <br />
                           </div>
                   <asp:Button ID="Button9" runat="server" Text="Modify Invoice" OnClientClick="btnclick();return false;" />&nbsp;&nbsp&nbsp;&nbsp<asp:Button ID="Button13" runat="server" Text="Save Invoice" OnClientClick="assign1();deleteinvoice();print();displayI();return false;" />
                   </div>
                   <div id="FracFina">
                        <div class="grid-FFinaContainer">
                            <div class="itemFFC1">
                                <h4>Finance Details</h4>
                            </div>
                            <div class="itemFFC2">
                                <label>Total Purchase</label>&nbsp;&nbsp <label id="fcurrTP" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemFFC3">
                                <%--<input type="text" id="TotalPurTextBoxFFC" readonly />--%>
                               <asp:TextBox ID="TotalPurTextBoxFFC" runat="server" Enabled="False" Width="200px" ReadOnly="true" ></asp:TextBox> 
                            </div>
                            <div class="itemFFC4">
                                <label>Qualifying Deposit</label>&nbsp;&nbsp<label id="fcurrQD" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemFFC5">
                                <asp:TextBox ID="QualTextBoxFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemFFC6">
                                <label>Amount of Credit</label>&nbsp;&nbsp<label id="fcurrAC" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemFFC7">
                                <asp:TextBox ID="AmountCreditTextBoxFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemFFC8">
                                <label>Credit Amount in Curr</label>&nbsp;&nbsp<label id="fcurr1CAC" style="font-weight:bold">USD</label><label id="fcurr2CAC" style="font-weight:bold">EUR</label><label id="fcurr3CAC" style="font-weight:bold">AUD</label><label id="fcurr4CAC" style="font-weight:bold">GBP</label>
                            </div>
                                  <div class="itemFFC9">
                                <asp:TextBox ID="AmountCreditCurrTextBoxFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemFFC10">
                                <p>No. of Months</p>
                            </div>
                            <div class="itemFFC11">
                               <asp:TextBox ID="NoMonthsTextBoxFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemFFC12">
                                <p>Rate of Interset</p>
                            </div>
                            <div class="itemFFC13">
                               <asp:TextBox ID="RateInterestTextBoxFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemFFC14">
                                <label>Monthly Repayment</label>&nbsp;&nbsp<label id="fcurr1MP" style="font-weight:bold">USD</label><label id="fcurr2MP" style="font-weight:bold">EUR</label><label id="fcurr3MP" style="font-weight:bold">AUD</label><label id="fcurr4MP" style="font-weight:bold">GBP</label>
                            </div>
                            <div class="itemFFC15">
                                <asp:TextBox ID="MonthRepayTextBoxFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemFFC16">
                                <asp:Button ID="Button111" runat="server" Text="Generate Details" OnClientClick="gendetails();return false;" />
                            </div>

                        </div>
                   </div>
               </div>
              <br />
              <div id="Points" >
              <div class="points_col" style="margin:10px 0px;padding-top:10px;">
                   <div id="PA1" style="width:650px; float:left;">
                   <h4>PURCHASE AGREEMENT</h4>
                <table  cellpadding="5px" cellspacing="5px">
                    
                    <tr>
                        <td width="210px"><asp:Label ID="Label158" runat="server" Text="Label">Deposit</asp:Label>
                        </td>  

                        <td width="400px">
                            <%--<asp:DropDownList ID="DPMPointsDropDownList" runat="server" Width="150px"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label159" runat="server" Text="Label">Deposit</asp:Label>--%>
                        <asp:TextBox ID="TextDepositP" runat="server" Enabled="True" Width="100px" onchange="adminfee();"></asp:TextBox></td>
                    </tr>
                     </table>
                       <table id="pbala"  cellpadding="5px" cellspacing="5px">
                           <tr>
                               <td width="210px"><asp:Label ID="Label45" runat="server" Text="Label">Initial Deposit</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextInitDepo" runat="server" Enabled="True" Width="328px" onchange="load_Ibalance();"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td width="210px"><asp:Label ID="Label48" runat="server" Text="Label">Balance Deposit</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextBalDepo" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td width="210px"><asp:Label ID="Label52" runat="server" Text="Label">Next Balance Deposit Date</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextBoxNBDP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                           </tr>
                           </table>

                       <table  cellpadding="5px" cellspacing="5px">
                    <tr>
                        <td><asp:Label ID="Label170" runat="server" Text="Label">Deposit Purchase Agreement</asp:Label></td>
                        <td><asp:TextBox ID="TextDepoPPA" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="LabelTBalace" runat="server" Text="Label">Total Balance</asp:Label></td>
                        <td><asp:TextBox ID="TextTotalBalance" runat="server" Enabled="True" Width="328px" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label160" runat="server" Text="Label">Admission Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAdmissFeesP" runat="server" Enabled="True" Width="328px" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label161" runat="server" Text="Label">Administration Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAdminFeesP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label162" runat="server" Text="Label">Total Purchase Price</asp:Label></td>
                        <td><asp:TextBox ID="TextPpurchasePrice" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label163" runat="server" Text="Label">Country Tax</asp:Label></td>
                        <td><asp:TextBox ID="TextCountryTaxP" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label164" runat="server" Text="Label">Grand Total</asp:Label>
                            <asp:TextBox ID="TextGrandTotalP" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                            

                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label165" runat="server" Text="Label">Balance Due PA</asp:Label></td>
                        <td><asp:TextBox ID="TextPBalaceDPA" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label166" runat="server" Text="Label">No of Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextPPANoInstall" runat="server" Enabled="True" Width="328px" onchange="changeInstallNo('Button7','Button12');"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label167" runat="server" Text="Label">First Payment Date</asp:Label></td>
                        <td><asp:TextBox ID="datepicker8" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label168" runat="server" Text="Label">Amount Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextPPAAmountInstall" runat="server" Enabled="True" Width="328px" onclick="installFirstSecondP();"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label169" runat="server" Text="Label">First Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextPPAFInstall" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    
                </table>
                   <br />
                        <br />
                  <asp:Button ID="Button7" runat="server" Text="Modify Invoices" OnClientClick="btnclick();return false;" />&nbsp;&nbsp&nbsp;&nbsp<asp:Button ID="Button12" runat="server" Text="Save Invoice" OnClientClick="assign1();deleteinvoice();print();displayI();return false;" />

              </div>
               <div id="SA1" style="width:600px; float:right;">
                       <h4>SERVICE AGREEMENT</h4>
                   
                <table cellpadding="5px" cellspacing="5px">
                    <tr>
                        <td height="25px">

                        </td>
                    </tr>
                    
                    <tr>
                        <td><asp:Label ID="Label171" runat="server" Text="Label" height="35px">Deposit service Agreement</asp:Label></td>
                        <td><asp:TextBox ID="TextPDepositSA" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label148" runat="server" Text="Label">Application Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAppliFeesP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label149" runat="server" Text="Label">Administration Service</asp:Label></td>
                        <td><asp:TextBox ID="TextAdminServiceP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label150" runat="server" Text="Label">Total Service Price</asp:Label></td>
                        <td><asp:TextBox ID="TextTotalServicePriceP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td height="25px"></td>
                        
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label153" runat="server" Text="Label">Balance Due SA</asp:Label></td>
                        <td><asp:TextBox ID="TextBalanceDueSAP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <!--<tr>
                        <td><asp:Label ID="Label154" runat="server" Text="Label">SA No of Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextSANoInstallP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label155" runat="server" Text="Label">First Payment Date</asp:Label></td>
                        <td><asp:TextBox ID="datepicker9" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label156" runat="server" Text="Label">SA Amount Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextSAAmountInstallP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label157" runat="server" Text="Label">SA First Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextSAFInstallP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>-->
                    
                </table>

              </div>
                  <div id="PFina">
                      <div class="grid-PFinaContainer">
                            <div class="itemPFC1">
                                <h4>Finance Details</h4>
                            </div>
                            <div class="itemPFC2">
                                <label>Total Purchase</label>&nbsp;&nbsp <label id="pcurrTP" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemPFC3">
                               <asp:TextBox ID="TotalPurTextBoxPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox> 
                            </div>
                            <div class="itemPFC4">
                                <label>Qualifying Deposit</label>&nbsp;&nbsp<label id="pcurrQD" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemPFC5">
                                <asp:TextBox ID="QualTextBoxPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemPFC6">
                                <label>Amount of Credit</label>&nbsp;&nbsp<label id="pcurrAC" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemPFC7">
                                <asp:TextBox ID="AmountCreditTextBoxPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemPFC8">
                                <label>Credit Amount in Curr</label>&nbsp;&nbsp<label id="pcurr1CAC" style="font-weight:bold">USD</label><label id="pcurr2CAC" style="font-weight:bold">EUR</label><label id="pcurr3CAC" style="font-weight:bold">AUD</label><label id="pcurr4CAC" style="font-weight:bold">GBP</label>
                            </div>
                                  <div class="itemPFC9">
                                <asp:TextBox ID="AmountCreditCurrTextBoxPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemPFC10">
                                <p>No. of Months</p>
                            </div>
                            <div class="itemPFC11">
                               <asp:TextBox ID="NoMonthsTextBoxPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemPFC12">
                                <p>Rate of Interset</p>
                            </div>
                            <div class="itemPFC13">
                               <asp:TextBox ID="RateInterestTextBoxPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemPFC14">
                                <label>Monthly Repayment</label>&nbsp;&nbsp<label id="pcurr1MP" style="font-weight:bold">USD</label><label id="pcurr2MP" style="font-weight:bold">EUR</label><label id="pcurr3MP" style="font-weight:bold">AUD</label><label id="pcurr4MP" style="font-weight:bold">GBP</label>
                            </div>
                            <div class="itemPFC15">
                                <asp:TextBox ID="MonthRepayTextBoxPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemPFC16">
                                <asp:Button ID="Button1pfina" runat="server" Text="Generate Details" OnClientClick="gendetails();return false;" />
                            </div>

                        </div>
                  </div>
                </div>
                
             
              <div id="remarkP">
               <br />
              <br />
                  <p>Remarks</p>
                  <asp:TextBox ID="TextRemarkP" runat="server" Enabled="True" Width="1300px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                  <br />
                  <div id="remp" style="display:none;">
                  <asp:TextBox ID="TextRemarkP2" runat="server" Enabled="True" Width="1300px" Height="50px" TextMode="MultiLine"></asp:TextBox>

                  <br />
                  <asp:TextBox ID="TextPBalanceDDates2" runat="server" Enabled="True" Width="1300px" Height="50px" TextMode="MultiLine"></asp:TextBox>

                   <br />
                  <asp:TextBox ID="TextBalanceDDatesSAP2" runat="server" Enabled="True" Width="1300px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </div>
              </div>
           
              <div id="PointsAdd"style="margin:10px 0px;padding-top:10px; overflow:hidden;">
                   <br />
                  <br />
                <div style="width:650px; float:left;" >
                    <table cellpadding="5px" cellspacing="5px">
                        <tr>
                        <td><p>Balance Due Dates in PA</p></td>
                    <td><asp:TextBox ID="TextPBalanceDDates" runat="server" Enabled="True" Width="328px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    </table>

                </div>
                  <div style="width:600px; float:right;">
                      <table cellpadding="5px" cellspacing="5px">
                          <tr>
                        <td><p>Balance Due Dates in SA</p></td>
                    <td><asp:TextBox ID="TextBalanceDDatesSAP" runat="server" Enabled="True" Width="328px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                      </table>
                  </div>
            </div>
                  </div>
              
              
              <div id="tfractional" >
                  <div id="TFPA"><h4>PURCHASE AGREEMENT</h4>
                <table  cellpadding="5px" cellspacing="5px">
                    
                    <tr>
                        <td width="180px"><asp:Label ID="Label146" runat="server" Text="Label">Deposit</asp:Label>
                        </td>  

                        <td width="400px">
                           <%-- <asp:DropDownList ID="DPMTFractDropDownList" runat="server" Width="150px"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label147" runat="server" Text="Label">Deposit</asp:Label>--%>
                        <asp:TextBox ID="TextDepositTF" runat="server" Enabled="True" Width="100px" onchange="adminfee();"></asp:TextBox></td>
                    </tr>
                     </table>

                     <table id="tfbala"  cellpadding="5px" cellspacing="5px">
                           <tr>
                               <td width="180px"><asp:Label ID="Label49" runat="server" Text="Label">Initial Deposit</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextInitDepoTF" runat="server" Enabled="True" Width="328px" onchange="load_Ibalance();"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td width="180px"><asp:Label ID="Label50" runat="server" Text="Label">Balance Deposit</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextBalDepoTF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                           </tr>
                         <tr>
                               <td width="180px"><asp:Label ID="Label54" runat="server" Text="Label">Next Balance Deposit Date</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextBoxNBDTF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                           </tr>
                           </table>

                      <table  cellpadding="5px" cellspacing="5px">
                    <tr>
                        <td><asp:Label ID="Label30" runat="server" Text="Label">Total Balance</asp:Label></td>
                        <td><asp:TextBox ID="TextTotalBalanceTF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label151" runat="server" Text="Label">Admission Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAdmissFeeTF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label152" runat="server" Text="Label">Administration Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAdminFeeTF" runat="server" Enabled="True" Width="328px" onclick="financeadminfees();"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label172" runat="server" Text="Label">Total Purchase Price</asp:Label></td>
                        <td><asp:TextBox ID="TextPurchasePriceTF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label173" runat="server" Text="Label">Country Tax</asp:Label></td>
                        <td><asp:TextBox ID="TextCountryTaxTF" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                            
                            

                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label175" runat="server" Text="Label">Balance Due PA</asp:Label></td>
                        <td><asp:TextBox ID="TextBalanceDuePATF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label176" runat="server" Text="Label">No of Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextNoOfInstallTF" runat="server" Enabled="True" Width="328px" onchange="changeInstallNo('Button11','Button14');"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label177" runat="server" Text="Label">First Payment Date</asp:Label></td>
                        <td><asp:TextBox ID="datepicker13" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label178" runat="server" Text="Label">Amount Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextInstallAmtTF" runat="server" Enabled="True" Width="328px" onclick="installFirstSecondTF();" ></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label179" runat="server" Text="Label">First Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextFInstallAmtTF" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><p>Remarks</p></td>
                    <td><asp:TextBox ID="TextRemarksTF" runat="server" Enabled="True" Width="328px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><p>Balance Due Dates in PA</p></td>
                    <td><asp:TextBox ID="TextBalanceDueDatesPATF" runat="server" Enabled="True" Width="328px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                </table>
                      <br />
                        <br />
                      <div style="display:none;">
                      <asp:TextBox ID="TextRemarksTF2" runat="server" Enabled="True" Width="328px" Height="150px" TextMode="MultiLine"></asp:TextBox>
                       <br />
                       <asp:TextBox ID="TextBalanceDueDatesPATF2" runat="server" Enabled="True" Width="328px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                       <br />
                          </div>
                      <asp:Button ID="Button11" runat="server" Text="Modify Invoice" OnClientClick="btnclick();return false;" />&nbsp;&nbsp&nbsp;&nbsp<asp:Button ID="Button14" runat="server" Text="Save Invoice" OnClientClick="assign1();deleteinvoice();print();displayI();return false;" />
                 </div>  
                  <div id="TFFina">
                         <div class="grid-TFFinaContainer">
                            <div class="itemTFFC1">
                                <h4>Finance Details</h4>
                            </div>
                            <div class="itemTFFC2">
                                <label>Total Purchase</label>&nbsp;&nbsp <label id="tfcurrTP" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemTFFC3">
                               <asp:TextBox ID="TotalPurTextBoxTFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox> 
                            </div>
                            <div class="itemTFFC4">
                                <label>Qualifying Deposit</label>&nbsp;&nbsp<label id="tfcurrQD" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemTFFC5">
                                <asp:TextBox ID="QualTextBoxTFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTFFC6">
                                <label>Amount of Credit</label>&nbsp;&nbsp<label id="tfcurrAC" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemTFFC7">
                                <asp:TextBox ID="AmountCreditTextBoxTFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTFFC8">
                                <label>Credit Amount in Curr</label>&nbsp;&nbsp<label id="tfcurr1CAC" style="font-weight:bold">USD</label><label id="tfcurr2CAC" style="font-weight:bold">EUR</label><label id="tfcurr3CAC" style="font-weight:bold">AUD</label><label id="tfcurr4CAC" style="font-weight:bold">GBP</label>
                            </div>
                            <div class="itemTFFC9">
                             <asp:TextBox ID="AmountCreditCurrTextBoxTFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTFFC10">
                                <p>No. of Months</p>
                            </div>
                            <div class="itemTFFC11">
                               <asp:TextBox ID="NoMonthsTextBoxTFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTFFC12">
                                <p>Rate of Interset</p>
                            </div>
                            <div class="itemTFFC13">
                               <asp:TextBox ID="RateInterestTextBoxTFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTFFC14">
                                <label>Monthly Repayment</label>&nbsp;&nbsp<label id="tfcurr1MP" style="font-weight:bold">USD</label><label id="tfcurr2MP" style="font-weight:bold">EUR</label><label id="tfcurr3MP" style="font-weight:bold">AUD</label><label id="tfcurr4MP" style="font-weight:bold">GBP</label>
                            </div>
                            <div class="itemTFFC15">
                                <asp:TextBox ID="MonthRepayTextBoxTFFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTFFC16">
                                <asp:Button ID="Button1tf" runat="server" Text="Generate Details" OnClientClick="gendetails();return false;" />
                            </div>

                        </div>

                  </div>

              </div>

              <div id="tpoints" >
               <div class="tpoints_col" style=" margin:10px 0px;padding-top:10px;">
                  <div id="PA2" style="width:650px; float:left;" >
                   <h4>PURCHASE AGREEMENT</h4>
                <table  cellpadding="5px" cellspacing="5px">
                    
                    <tr>
                        <td width="210px">
                           <%-- <asp:Label ID="Label180" runat="server" Text="Label">Deposit Payment Method</asp:Label>--%>
                            <asp:Label ID="Label44" runat="server" Text="Label">Deposit</asp:Label>
                        </td>  

                        <td width="400px">
                            <%--<asp:DropDownList ID="DPMTPointsDropDownList" runat="server" Width="150px"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;--%>
                            
                        <asp:TextBox ID="TextDepositTP" runat="server" Enabled="True" Width="100px" onchange="adminfee();"></asp:TextBox></td>
                    </tr>

                    </table>
                       <table id="tpbala"  cellpadding="5px" cellspacing="5px">
                           <tr>
                               <td width="210px"><asp:Label ID="Label51" runat="server" Text="Label">Initial Deposit</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextInitDepoTP" runat="server" Enabled="True" Width="328px" onchange="load_Ibalance();"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td width="210px"><asp:Label ID="Label55" runat="server" Text="Label">Balance Deposit</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextBalDepoTP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td width="210px"><asp:Label ID="Label56" runat="server" Text="Label">Next Balance Deposit Date</asp:Label></td>
                        <td width="400px"><asp:TextBox ID="TextBoxNBDTP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                           </tr>
                           </table>

                       <table  cellpadding="5px" cellspacing="5px">

                    <tr>
                        <td><asp:Label ID="Label182" runat="server" Text="Label">Deposit Purchase Agreement</asp:Label></td>
                        <td><asp:TextBox ID="TextDepositPATP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label12" runat="server" Text="Label">Total Balance</asp:Label></td>
                        <td><asp:TextBox ID="TextTotalBalanceTP" runat="server" Enabled="True" Width="328px" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label183" runat="server" Text="Label">Admission Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAdmissFTP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label184" runat="server" Text="Label">Administration Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAdminFeesTP" runat="server" Enabled="True" Width="328px" onclick="financeadminfees();"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label185" runat="server" Text="Label">Total Purchase Price</asp:Label></td>
                        <td><asp:TextBox ID="TextPurchasePriceTP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label186" runat="server" Text="Label">Country Tax</asp:Label></td>
                        <td><asp:TextBox ID="TextCountryTaxTP" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label187" runat="server" Text="Label">Grand Total</asp:Label>
                            <asp:TextBox ID="TextGrandTotalTP" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                            

                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label188" runat="server" Text="Label">Balance Due PA</asp:Label></td>
                        <td><asp:TextBox ID="TextBalanceDuePATP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label189" runat="server" Text="Label">No of Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextNoOfInstallPATP" runat="server" Enabled="True" Width="328px" onchange="changeInstallNo('Button10','tButton1');"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label190" runat="server" Text="Label">First Payment Date</asp:Label></td>
                        <td><asp:TextBox ID="datepicker11" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label191" runat="server" Text="Label">Amount Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextInstallAmtPATP" runat="server" Enabled="True" Width="328px" onclick="installFirstSecondTP()"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label192" runat="server" Text="Label">First Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextFInstallAmtPATP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    
                </table>

                      <br />
                        <br />
                      <asp:Button ID="Button10" runat="server" Text="Modify Invoices" OnClientClick="btnclick();return false;" />&nbsp;&nbsp&nbsp;&nbsp<asp:Button ID="tButton1" runat="server" Text="Save Invoice" OnClientClick="assign1();deleteinvoice();print();displayI();return false;" />
              </div>
               <div id="SA2" style="width:650px; float:right;">
                       <h4>SERVICE AGREEMENT</h4>
                   
                <table cellpadding="5px" cellspacing="5px">
                    <tr>
                        <td height="25px">

                        </td>
                    </tr>
                    
                    <tr>
                        <td><asp:Label ID="Label193" runat="server" Text="Label" height="35px">Deposit service Agreement</asp:Label></td>
                        <td><asp:TextBox ID="TextDepositSATP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label194" runat="server" Text="Label">Application Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextAppliFeesTP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label195" runat="server" Text="Label">Administration Service</asp:Label></td>
                        <td><asp:TextBox ID="TextAdminServiceTP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label196" runat="server" Text="Label">Total Service Price</asp:Label></td>
                        <td><asp:TextBox ID="TextTotalServiceTP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td height="25px"></td>
                        
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label197" runat="server" Text="Label">Balance Due SA</asp:Label></td>
                        <td><asp:TextBox ID="TextBalanceDueSATP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <!--<tr>
                        <td><asp:Label ID="Label198" runat="server" Text="Label">SA No of Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextNoOfInstallSATP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label199" runat="server" Text="Label">First Payment Date</asp:Label></td>
                        <td><asp:TextBox ID="datepicker12" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label200" runat="server" Text="Label">SA Amount Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextInstallAmtSATP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label201" runat="server" Text="Label">SA First Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextFInstallAmtSATP" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>-->
                    
                </table>

              </div>
                   <div id="TPFina">
                     <div class="grid-TPFinaContainer">
                            <div class="itemTPFC1">
                                <h4>Finance Details</h4>
                            </div>
                            <div class="itemTPFC2">
                                <label>Total Purchase</label>&nbsp;&nbsp <label id="tpcurrTP" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemTPFC3">
                               <asp:TextBox ID="TotalPurTextBoxTPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox> 
                            </div>
                            <div class="itemTPFC4">
                                <label>Qualifying Deposit</label>&nbsp;&nbsp<label id="tpcurrQD" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemTPFC5">
                                <asp:TextBox ID="QualTextBoxTPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTPFC6">
                                <label>Amount of Credit</label>&nbsp;&nbsp<label id="tpcurrAC" style="font-weight:bold">USD</label>
                            </div>
                            <div class="itemTPFC7">
                                <asp:TextBox ID="AmountCreditTextBoxTPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTPFC8">
                                <label>Credit Amount in Curr</label>&nbsp;&nbsp<label id="tpcurr1CAC" style="font-weight:bold">USD</label><label id="tpcurr2CAC" style="font-weight:bold">EUR</label><label id="tpcurr3CAC" style="font-weight:bold">AUD</label><label id="tpcurr4CAC" style="font-weight:bold">GBP</label>
                            </div>
                                  <div class="itemTPFC9">
                                <asp:TextBox ID="AmountCreditCurrTextBoxTPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTPFC10">
                                <p>No. of Months</p>
                            </div>
                            <div class="itemTPFC11">
                               <asp:TextBox ID="NoMonthsTextBoxTPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTPFC12">
                                <p>Rate of Interset</p>
                            </div>
                            <div class="itemTPFC13">
                               <asp:TextBox ID="RateInterestTextBoxTPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTPFC14">
                                 <label>Monthly Repayment</label>&nbsp;&nbsp<label id="tpcurr1MP" style="font-weight:bold">USD</label><label id="tpcurr2MP" style="font-weight:bold">EUR</label><label id="tpcurr3MP" style="font-weight:bold">AUD</label><label id="tpcurr4MP" style="font-weight:bold">GBP</label>
                            </div>
                            <div class="itemTPFC15">
                                <asp:TextBox ID="MonthRepayTextBoxTPFC" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            </div>
                            <div class="itemTPFC16">
                                <asp:Button ID="Button1TPF" runat="server" Text="Generate Details" OnClientClick="gendetails();return false;" />
                            </div>

                        </div>  
                   
                   </div>
               </div>
              
              
              
              <div id="remarkTP">
                  <br />
                  <br />
                  <p>Remarks</p>
                  <asp:TextBox ID="TextRemarksTP" runat="server" Enabled="True" Width="1300px" Height="100px" TextMode="MultiLine"></asp:TextBox></div>
            
                  <br />
                   <div style="display:none;">
                  <asp:TextBox ID="TextRemarksTP2" runat="server" Enabled="True" Width="1300px" Height="50px" TextMode="MultiLine"></asp:TextBox>

                  <br />
                  <asp:TextBox ID="TextBalanceDueDatesPATP2" runat="server" Enabled="True" Width="1300px" Height="50px" TextMode="MultiLine"></asp:TextBox>

                   <br />
                  <asp:TextBox ID="TextBalanceDueDatesSATP2" runat="server" Enabled="True" Width="1300px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </div>
              <div id="TPAdd"style="margin:10px 0px;padding-top:10px; overflow:hidden;">
                  <br />
                  <br />
                <div style="width:650px; float:left; ">
                    <table cellpadding="5px" cellspacing="5px">
                        <tr>
                        <td><p>Balance Due Dates in PA</p></td>
                    <td><asp:TextBox ID="TextBalanceDueDatesPATP" runat="server" Enabled="True" Width="328px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    </table>

                </div>
                  <div style="width:600px; float:right; ">
                      <table cellpadding="5px" cellspacing="5px">
                          <tr>
                        <td><p>Balance Due Dates in SA</p></td>
                    <td><asp:TextBox ID="TextBalanceDueDatesSATP" runat="server" Enabled="True" Width="328px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                      </table>
                  </div>
            </div>
              </div>
               <div id="myModal" class="modal">
    
  <!-- Modal content -->
                    <div class="modal-content">
                        
                        <label id="close1">Close[X]</label>
                        <p>Change Installment Amount</p>
                        <br />
                        <br />
                        <asp:Label ID="Label33" runat="server" Text="Label">Total Balance</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp
                        <asp:TextBox ID="TextModTotalBalance" runat="server" Enabled="false" Width="200px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label34" runat="server" Text="Label">No Of Invoice</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp
                        <asp:TextBox ID="TextModNoofInvoice" runat="server" Enabled="false" Width="200px"></asp:TextBox>
                         <br />  
                        <br />                     
                    <input type="text" name="text1" onclick="date();" style="visibility:hidden;" />
                        <br />
                        <p style="width:195px;display:inline-block;font-weight:bold;">Installments</p><p style="width:195px;display:inline-block;font-weight:bold;">Amount</p><p style="width:195px;display:inline-block;font-weight:bold;">Date</p><p style="width:180px;display:inline-block;font-weight:bold;">Currency</p>
                    <div id="ch"></div>
                  
                         &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp<input id="t45" type="text" name="ter"  />
                        <br />
                        <br />                  
                        <asp:Button ID="sbutton" runat="server" Text="Generate Invoice" OnClientClick="assign1();return false;" />&nbsp;&nbsp;&nbsp;&nbsp
                        <asp:Button ID="Button8" runat="server" Text="Save Invoice" OnClientClick="print();deleteinvoice();displayI();return false;" />&nbsp;&nbsp;&nbsp;&nbsp <asp:Button ID="clear" runat="server" Text="Clear Invoice" OnClientClick="ClearI();return false;" />
                        <br />
                        <br />
                        <br />
                        <p style="width:195px;display:inline-block;font-weight:bold;">Installments</p><p style="width:195px;display:inline-block;font-weight:bold;">PA Amount</p><p style="width:195px;display:inline-block;font-weight:bold;">SA Amount</p><p style="width:180px;display:inline-block;font-weight:bold;">Currency</p>
                         <div id="ch1" ></div>

                    </div>

                </div>
              <div id="remarks">
                  <p style="display: none">Remarks</p>
                  <asp:TextBox ID="TextRemarksP" runat="server" Enabled="True" Width="1200px" TextMode="MultiLine" Visible="False"></asp:TextBox>
                  <br />
                  <table cellpadding="5px" cellspacing="5px" width="1200px">
                 <tr>
                      <td><asp:TextBox ID="tPurchase" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                          <asp:TextBox ID="QDepo" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                          <asp:TextBox ID="AmtCre" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                          <asp:TextBox ID="CreCurr" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                          <asp:TextBox ID="NoOfMonth" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                          <asp:TextBox ID="RateOfInt" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                          <asp:TextBox ID="MonthlyRepay" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                          
                      </td>
                      
                  </tr> 
                      <tr>
                          <td></td>
                          <td></td>
                          <%--<td>
                              <asp:CheckBox ID="UsePayProtectCheckBox" runat="server" /> Use Payment Protection</td>--%>
                         <%-- <td><asp:Label ID="Label145" runat="server" Text="Label">Year Of Interest</asp:Label>
                              <asp:DropDownList ID="YearOfIntDropDownList" runat="server" Width="150px"></asp:DropDownList>
                          </td>--%>
                      </tr>  
                      <tr>
                          <td>
                              
                              <asp:Button ID="Button2" runat="server" Text="Next Step" />
                              <%--<asp:Button ID="Button3" runat="server" Text="Next2" OnClick="Button2_Click" />--%>
                              
                          </td>
                      </tr>
                  
                  </table>
              </div>
           
   </div>
   </div>

      <div id="tabs-4" style="background-color:#e9e9e9;">
          <div id="Tab4cont" style="margin:10px 0px;padding-top:10px; overflow:hidden;">
            <div id="PCC1" style="width:650px; float:left;">
              <h4>PRIMARY CREDIT CARD</h4>
                <table  cellpadding="5px" cellspacing="5px" >
                    <tr>
                        <td width="200px"><asp:Label ID="Cardty" runat="server" Text="Label">Card Type</asp:Label>
                        </td>  

                        <td width="400px">
                            <asp:DropDownList ID="CardPrimaryDropDownList" runat="server" Width="328px" onclick="cardremark('CardPrimaryDropDownList','TextPrimaryCCard');"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label77" runat="server" Text="Label">Issuing Bank</asp:Label>
                        </td>  

                        <td width="400px">
                            <asp:TextBox ID="TextIssuingP" runat="server" Enabled="True" Width="328px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="Label204" runat="server" Text="Label">Credit Card Number</asp:Label>
                        </td>  

                        <td width="400px">
                            <asp:TextBox ID="TextCardNumbP" runat="server" Enabled="True" Width="328px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="Label206" runat="server" Text="Label">Card Holders Name</asp:Label>
                        </td>  

                        <td width="400px">
                            <asp:TextBox ID="TextCardHNameP" runat="server" Enabled="True" Width="328px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td width="200px"><asp:Label ID="Label208" runat="server" Text="Label" >Expired Month/Year</asp:Label>
                        &nbsp;
                        </td>
                        <td width="400px">
                            <asp:TextBox ID="TextExpMonthP" runat="server" Enabled="True" Width="110px"></asp:TextBox>
                            <asp:Label ID="Label209" runat="server" Text="Label" Width="100px" Style="word-break: break-word;">Security Number</asp:Label>
                       <asp:TextBox ID="TextSecurityP" runat="server" Enabled="True" Width="110px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label212" runat="server" Text="Label">Purpose</asp:Label>
                        </td>  

                        <td width="400px">
                           <input type="checkbox" id="FDepo1" onclick="CCpurpose('FDepo1', 'TextFDepo1');"/><asp:Label ID="Label216" runat="server" Text="Label">For Deposit</asp:Label>&nbsp;
                            <input type="checkbox" id="FBala1" onclick="CCpurpose('FBala1', 'TextFBala1');"/><asp:Label ID="Label217" runat="server" Text="Label">For Balance</asp:Label>&nbsp;
                            <input type="checkbox" id="FFina1" onclick="CCpurpose('FFina1', 'TextFFina1');"/><asp:Label ID="Label42" runat="server" Text="Label">For Finance</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label35" runat="server" Text="Label">Comments</asp:Label>
                        </td>  
                        <td width="400px">
                            <asp:TextBox ID="TextPrimaryCCard" runat="server" Enabled="True" Width="330px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>

                </table>

              
            </div>
            <div id="SCC1" style="width:600px; float:Right;">
                <h4>SECONDARY CREDIT CARD</h4>
                <table  cellpadding="5px" cellspacing="5px" >
                    <tr>
                        <td width="200px"><asp:Label ID="Label202" runat="server" Text="Label">Card Type</asp:Label>
                        </td>  

                        <td width="400px">
                            <asp:DropDownList ID="CardSecondaryDropDownList" runat="server" Width="328px" onclick="cardremark('CardSecondaryDropDownList','TextSecondaryCCard');"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label203" runat="server" Text="Label">Issuing Bank</asp:Label>
                        </td>  

                        <td width="400px">
                            <asp:TextBox ID="TextIssuingS" runat="server" Enabled="True" Width="328px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="Label205" runat="server" Text="Label">Credit Card Number</asp:Label>
                        </td>  

                        <td width="400px">
                            <asp:TextBox ID="TextCardNumbS" runat="server" Enabled="True" Width="328px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="Label207" runat="server" Text="Label">Card Holders Name</asp:Label>
                        </td>  

                        <td width="400px">
                            <asp:TextBox ID="TextCardHNameS" runat="server" Enabled="True" Width="328px"></asp:TextBox>
                        </td>
                    </tr>
                  
                     <tr>
                        <td width="200px"><asp:Label ID="Label210" runat="server" Text="Label" >Expired Month/Year</asp:Label>
                        &nbsp;
                        </td>
                        <td width="400px">
                            <asp:TextBox ID="TextExpiryS" runat="server" Enabled="True" Width="110px"></asp:TextBox>
                            <asp:Label ID="Label211" runat="server" Text="Label" Width="100px" Style="word-break: break-word;">Security Number</asp:Label>
                        <asp:TextBox ID="TextSecurityS" runat="server" Enabled="True" Width="110px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label213" runat="server" Text="Label">Purpose</asp:Label>
                        </td>  

                        <td width="400px">
                            <input type="checkbox" id="FDepo2" onclick="CCpurpose('FDepo2', 'TextFDepo2');" /><asp:Label ID="Label214" runat="server" Text="Label">For Deposit</asp:Label>&nbsp;
                            <input type="checkbox" id="FBala2" onclick="CCpurpose('FBala2', 'TextFBala2');"/><asp:Label ID="Label215" runat="server" Text="Label">For Balance</asp:Label>&nbsp;
                            <input type="checkbox" id="FFina2" onclick="CCpurpose('FFina2', 'TextFFina2');"/><asp:Label ID="Label43" runat="server" Text="Label">For Finance</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label36" runat="server" Text="Label">Comments</asp:Label>
                        </td>  
                        <td width="400px">
                            <asp:TextBox ID="TextSecondaryCCard" runat="server" Enabled="True" Width="330px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>

            </div>
               
              
          </div>
          
              <br />
                <br />
                <p><b>Remarks:</b></p>
                <p>Amex cards: 4 Digits on the front right side of Card.</p>
                <p>Master cards: Last 3 Digits shown on the back of card in Signature Section.</p>
                <p>Other cards: 4 Digits shown seperately on the Back (Where Applicable) of the Card. </p>
          <br />
          <br />
          <asp:TextBox ID="TextFDepo2" runat="server" Enabled="True" Width="110px"></asp:TextBox>
          <asp:TextBox ID="TextFBala2" runat="server" Enabled="True" Width="110px"></asp:TextBox>
          <asp:TextBox ID="TextFDepo1" runat="server" Enabled="True" Width="110px"></asp:TextBox>
          <asp:TextBox ID="TextFBala1" runat="server" Enabled="True" Width="110px"></asp:TextBox>
           <asp:TextBox ID="TextFFina1" runat="server" Enabled="True" Width="110px"></asp:TextBox>
          <asp:TextBox ID="TextFFina2" runat="server" Enabled="True" Width="110px"></asp:TextBox>
          <asp:Button ID="Button4" runat="server" Text="Update Contract" OnClick="Button5_Click"  />
      </div>

       <div id="tabs-5" style="background-color:#e9e9e9;">
          <div id="Tab5cont">

              <asp:DropDownList ID="PrintPdfDropDownList" runat="server" ></asp:DropDownList> &nbsp;&nbsp 
              <asp:Button ID="Button5" runat="server" Text="Print" OnClick="Button4_Click"  />

          </div>
      </div>

     
   </form>
</div>
 
 
</body>

</html>
