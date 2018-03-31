<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Indian_contracts.aspx.cs" Inherits="_Default" %>


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

#hidden1, #Label205,#ManagerDropDownList{
    display:none;
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
          $("#tabs").tabs({ disabled: [1, 2, 3, 4] });
          $("#Btn1").on('click', function () {
              $("#tabs").tabs({ disabled: [2, 3, 4] });
              $("#tabs").tabs("option", "active", 1);
             
            
          });
          $("#Btn2").on('click', function () {
              $("#tabs").tabs({ disabled: [4] });
              $("#tabs").tabs("option", "active", 2);
              $("#tabs").tabs("option", "active", 3);
              
          });

      });

      $(function () {
          $("#primarydobdatepicker,#secondarydobdatepicker,#sp1dobdatepicker,#sp2dobdatepicker,#sp3dobdatepicker,#sp4dobdatepicker,#arrivaldatedatepicker,#departuredatedatepicker,#baladepamtdateTextBox").datepicker({
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


           function shows() {
               var checkbox1 = document.getElementById('chs');
               if (checkbox1.checked) {
                   document.getElementById("hidden").style.display = "block";
               }
               else {
                   document.getElementById("hidden").style.display = "none";
               }

           }
           function EMICalculation_fractional() {
               var emi = document.getElementById("noemiTextBox").value;
               var months = "12";
               var term = parseInt(emi) / parseInt(months);
               //  alert(term)
               var rateofinterest = "11%";
               var interest = parseInt(rateofinterest) / 100;
               //  alert(interest);
               var principalloanamt = document.getElementById("balamtpayableTextBox").value;
               //  alert(principalloanamt);
               var documentationfee = "1";
               var igst = "18";
               var r = parseFloat(interest) / parseInt(months);
               var exponent = parseInt(term) * parseInt(months);
               var emiamt = Math.round(parseInt(principalloanamt) * parseFloat(r) * (Math.pow((1 + parseFloat(r)), parseInt(exponent))) / ((Math.pow((1 + parseFloat(r)), parseInt(exponent))) - 1));
               //  alert(emiamt);
               document.getElementById("emiamtTextBox").value = emiamt;
               //  alert(emiamt);
               var caldocfee = Math.round(parseInt(principalloanamt) * (parseInt(documentationfee) / 100));
               //  alert(caldocfee);
               document.getElementById("findocfeeTextBox").value = caldocfee;
               //  alert(igst);

               var caligst = Math.round(parseInt(caldocfee) * (parseInt(igst) / 100));

               //   alert(caligst);
               document.getElementById("igstamtTextBox").value = caligst;
               var startvalue, endvalue, financeno;
               var ct = document.getElementById("contracttypeDropDownList");
               var contract_type = ct.options[ct.selectedIndex].text;
               var v = document.getElementById("VenueDropDownList");
               var venue = v.options[v.selectedIndex].text;
               var lastno = document.getElementById("lastfingennoTextBox").value;

           }


           function EMICalculation() {
               var emi = document.getElementById("noemiTextBox").value;
               var months = "12";
               var term = parseInt(emi) / parseInt(months);
             //  alert(term)
               var rateofinterest = "19%";
               var interest = parseInt(rateofinterest) / 100;
             //  alert(interest);
               var principalloanamt = document.getElementById("balamtpayableTextBox").value;
             //  alert(principalloanamt);
               var documentationfee = "1";
               var igst = "18";
               var r = parseFloat(interest) / parseInt(months);
               var exponent = parseInt(term) * parseInt(months);
               var emiamt = Math.round(parseInt(principalloanamt) * parseFloat(r) * (Math.pow((1 + parseFloat(r)), parseInt(exponent))) / ((Math.pow((1 + parseFloat(r)), parseInt(exponent))) - 1));
             //  alert(emiamt);
               document.getElementById("emiamtTextBox").value = emiamt;
             //  alert(emiamt);
               var caldocfee =Math.round(parseInt(principalloanamt) * (parseInt(documentationfee) / 100));
             //  alert(caldocfee);
               document.getElementById("findocfeeTextBox").value = caldocfee;
             //  alert(igst);
              
                var caligst = Math.round(parseInt(caldocfee) * (parseInt(igst) / 100));
             
            //   alert(caligst);
               document.getElementById("igstamtTextBox").value = caligst;
               var startvalue, endvalue, financeno;
               var ct = document.getElementById("contracttypeDropDownList");
               var contract_type = ct.options[ct.selectedIndex].text;
               var v = document.getElementById("VenueDropDownList");
               var venue = v.options[v.selectedIndex].text;
               var lastno = document.getElementById("lastfingennoTextBox").value;
              
           }
           function LoanEMICalculation() {
               var ct = document.getElementById("contracttypeDropDownList");
               var contract_type = ct.options[ct.selectedIndex].text;
               if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals") {
                   EMICalculation_fractional();
               }
               else {
                   EMICalculation();
               }

           }

           function pay_method()
           {
               var startvalue, endvalue, financeno;
               var ct = document.getElementById("contracttypeDropDownList");
               var contract_type = ct.options[ct.selectedIndex].text;
               var v = document.getElementById("VenueDropDownList");
               var venue = v.options[v.selectedIndex].text;
               var ent = document.getElementById("financemethodDropDownList").value;
               
               if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals")
               {
                   if (ent == "CROWN FINANCE" || ent == "Crown Finance") {
                       //  document.getElementById("pnumb").style.display = 'block';
                       document.getElementById("lblfinanceno").style.display = 'block';
                       document.getElementById("FinancenoTextBox").style.display = 'block';
                       document.getElementById("lblnoemi").style.display = 'block';
                       document.getElementById("noemiTextBox").style.display = 'block';
                       document.getElementById("lblemiamt").style.display = 'block';
                       document.getElementById("emiamtTextBox").style.display = 'block';
                   }
                   else if (ent == "PASHURAM FINANCE" || ent == "Pashuram Finance") {
                       //  document.getElementById("pnumb").style.display = 'block';
                       document.getElementById("lblfinanceno").style.display = 'block';
                       document.getElementById("FinancenoTextBox").style.display = 'block';
                       document.getElementById("lblnoemi").style.display = 'block';
                       document.getElementById("noemiTextBox").style.display = 'block';
                       document.getElementById("lblemiamt").style.display = 'block';
                       document.getElementById("emiamtTextBox").style.display = 'block';
                       //calculation
                       EMICalculation_fractional();


                   }
                   else {
                       //document.getElementById("pnumb").style.display = 'none';
                       document.getElementById("lblfinanceno").style.display = 'none';
                       document.getElementById("FinancenoTextBox").style.display = 'none';
                       document.getElementById("lblnoemi").style.display = 'none';
                       document.getElementById("noemiTextBox").style.display = 'none';
                       document.getElementById("lblemiamt").style.display = 'none';
                       document.getElementById("emiamtTextBox").style.display = 'none';

                   }
               }
               else {
                   if (ent == "CROWN FINANCE" || ent == "Crown Finance") {
                       //  document.getElementById("pnumb").style.display = 'block';
                       document.getElementById("lblfinanceno").style.display = 'block';
                       document.getElementById("FinancenoTextBox").style.display = 'block';
                       document.getElementById("lblnoemi").style.display = 'block';
                       document.getElementById("noemiTextBox").style.display = 'block';
                       document.getElementById("lblemiamt").style.display = 'block';
                       document.getElementById("emiamtTextBox").style.display = 'block';
                   }
                   else if (ent == "PASHURAM FINANCE" || ent == "Pashuram Finance") {
                       //  document.getElementById("pnumb").style.display = 'block';
                       document.getElementById("lblfinanceno").style.display = 'block';
                       document.getElementById("FinancenoTextBox").style.display = 'block';
                       document.getElementById("lblnoemi").style.display = 'block';
                       document.getElementById("noemiTextBox").style.display = 'block';
                       document.getElementById("lblemiamt").style.display = 'block';
                       document.getElementById("emiamtTextBox").style.display = 'block';
                       //calculation
                       EMICalculation();


                   }
                   else {
                       //document.getElementById("pnumb").style.display = 'none';
                       document.getElementById("lblfinanceno").style.display = 'none';
                       document.getElementById("FinancenoTextBox").style.display = 'none';
                       document.getElementById("lblnoemi").style.display = 'none';
                       document.getElementById("noemiTextBox").style.display = 'none';
                       document.getElementById("lblemiamt").style.display = 'none';
                       document.getElementById("emiamtTextBox").style.display = 'none';

                   }
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

    function shows3a() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs3a');

        if (checkbox2.checked) {

            document.getElementById("panel3").style.display = "block";

        }
        else {
            document.getElementById("panel3").style.display = "none";

        }

    }

    function shows4a() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs4a');

        if (checkbox2.checked) {

            document.getElementById("panel4").style.display = "block";

        }
        else {
            document.getElementById("panel4").style.display = "none";

        }

    }


    function shows4() {
        //alert("shows2");
        var checkbox2 = document.getElementById('chs4');

        if (checkbox2.checked) {

            document.getElementById("identitytable").style.display = "block";
            //document.getElementById("adhar").style.display = "block";
            //  document.getElementById("pan").style.display = "block";
            document.getElementById("no").style.display = "none";
            document.getElementById("yes").style.display = "block";
            //    document.getElementById("pan").style.display = "block";
            identitytable

        }
        else {
            document.getElementById("identitytable").style.display = "none";
            //document.getElementById("pan").style.display = "none";
            //document.getElementById("adhar").style.display = "none";
            document.getElementById("no").style.display = "block";
            document.getElementById("yes").style.display = "none";

        }

    }

    function shows5() {
        // alert("shows5");
        var checkbox2 = document.getElementById('chs5');

        if (checkbox2.checked) {

            document.getElementById('MCFeesTextBox').value = "Yes";
            document.getElementById("no1").style.display = "none";
            document.getElementById("yes1").style.display = "block";
            document.getElementById("yess1").style.display = "block";
        }
        else {
            document.getElementById('MCFeesTextBox').value = "No";
            document.getElementById("no1").style.display = "block";
            document.getElementById("yes1").style.display = "none";
            document.getElementById("yess1").style.display = "none";

        }

    }
    function shows6() {
        //alert("shows5");
        var checkbox2 = document.getElementById('chs6');

        if (checkbox2.checked) {

            document.getElementById('MCFeesTextBox').value="Yes";

            document.getElementById("no2").style.display = "none";
            document.getElementById("yes2").style.display = "block";
            document.getElementById("yess2").style.display = "block";
        }
        else
        {
            document.getElementById('MCFeesTextBox').value = "No";
            document.getElementById("no2").style.display = "block";
            document.getElementById("yes2").style.display = "none";
            document.getElementById("yess2").style.display = "none";

        }

    }
    function shows7() {
        // alert("shows5");
        var checkbox2 = document.getElementById('chs7');

        if (checkbox2.checked) {

            document.getElementById('MCFeesTextBox').value = "Yes";
            document.getElementById("pno1").style.display = "none";
            document.getElementById("ptyes1").style.display = "block";
            document.getElementById("pyess1").style.display = "block";
        }
        else {
            document.getElementById('MCFeesTextBox').value = "No";
            document.getElementById("pno1").style.display = "block";
            document.getElementById("ptyes1").style.display = "none";
            document.getElementById("pyess1").style.display = "none";

        }

    }
    function shows8() {
        // alert("shows5");
        var checkbox2 = document.getElementById('chs8');

        if (checkbox2.checked) {

            document.getElementById('MCFeesTextBox').value = "Yes";
            document.getElementById("TIFno1").style.display = "none";
            document.getElementById("TIFyes1").style.display = "block";
            document.getElementById("TIFyess1").style.display = "block";
        }
        else {
            document.getElementById('MCFeesTextBox').value = "No";
            document.getElementById("TIFno1").style.display = "block";
            document.getElementById("TIFyes1").style.display = "none";
            document.getElementById("TIFpyess1").style.display = "none";

        }

    }
    //function MCWaiver1()
    //{

    //    var ct = document.getElementById("contracttypeDropDownList");
    //    var contracttype = ct.options[ct.selectedIndex].text;

    //    var ccode;
    //    if ((document.getElementById("mcRadioButtonList").checked == true))
    //    {
    //        if (contracttype == "Fractional" || contracttype == "Trade In Fractionals")
    //        {
    //            var tenure = document.getElementById("ftenureTextBox").value;

    //        }
    //        else if (contracttype == "Points")
    //        {
    //            var tenure = document.getElementById("tenureTextBox").value;
    //            var cd =   document.getElementById("incrTextBox").value;
    //            if(tenure==30)
    //            {
    //                var cd1 = cd.replace("(30)", "");
    //                ccode = cd1 + "W" + "(30)";
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //            else
    //            {
    //                ccode = cd1 + "W";
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //        }
    //        else if (contracttype == "Trade-In-Points")
    //        {
    //            var tenure = document.getElementById("tiptenureTextBox").value;
    //            var cd = document.getElementById("incrTextBox").value;
    //            if (tenure == 30) {
    //                var cd1 = cd.replace("(30)", "");
    //                ccode = cd1 + "W" + "(30)";
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //            else
    //            {
    //                ccode = cd1 + "W";
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //        }
    //        else if (contracttype == "Trade-In-Weeks")
    //        {
    //            var tenure = document.getElementById("nmtenureTextBox").value;
    //            var cd = document.getElementById("incrTextBox").value;
    //            if (tenure == 30) {
    //                var cd1 = cd.replace("(30)", "");
    //                ccode = cd1 + "W" + "(30)";
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //            else {
    //                ccode = cd1 + "W";
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //        }




    //    }

    //    else
    //    {
    //        //ccode1 = document.getElementById("contractnoTextBox").value;
    //        //ccode = ccode1.slice(0, -1);
    //        //document.getElementById("contractnoTextBox").value = ccode;
    //        if (contracttype == "Fractional" || contracttype == "Trade In Fractionals")
    //        {
    //            var tenure = document.getElementById("ftenureTextBox").value;

    //        }
    //        else if (contracttype == "Points")
    //        {
    //            var tenure = document.getElementById("tenureTextBox").value;
    //            var cd = document.getElementById("contractnoTextBox").value;
    //            if (tenure == 30) {
    //                var cd1 = cd.replace("(30)", "");
    //                ccode = cd1 + "(30)";
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //            else {
    //                ccode = cd1;
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //        }
    //        else if (contracttype == "Trade-In-Points") {
    //            var tenure = document.getElementById("tiptenureTextBox").value;
    //            var cd = document.getElementById("contractnoTextBox").value;
    //            if (tenure == 30)
    //            {
    //                var cd1 = cd.replace("(30)", "");
    //                ccode = cd1 + "(30)";
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //            else {
    //                ccode = cd1;
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //        }
    //        else if (contracttype == "Trade-In-Weeks") {
    //            var tenure = document.getElementById("nmtenureTextBox").value;
    //            var cd = document.getElementById("contractnoTextBox").value;
    //            if (tenure == 30)
    //            {
    //                var cd1 = cd.replace("(30)", "");
    //                ccode = cd1 + "(30)";
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //            else {
    //                ccode = cd1;
    //                document.getElementById("contractnoTextBox").value = ccode;
    //            }
    //        }

    //    }


    //}

    function MCWaiver()
    {       
       
        var ccode;
        if (document.getElementById("contractnoTextBox").value == "")
        { }
        else

        {
            if ((document.getElementById("mcRadioButtonList").checked == true))
            {
                //ccode = document.getElementById("contractnoTextBox").value + "W";
                //document.getElementById("contractnoTextBox").value = ccode;
                Procedure_Generation_Contract1();
            }

            else {
                //ccode1 = document.getElementById("contractnoTextBox").value;
                //ccode = ccode1.slice(0, -1);
                //document.getElementById("contractnoTextBox").value = ccode;
                Procedure_Generation_Contract1();

            }
        }


    }
    //function EmeraldCheck() {

    //    //var ccode;
    //    //if ((document.getElementById("ca1").checked == true))
    //    //{
    //    //    ccode = document.getElementById("contractnoTextBox").value;
    //    //    if (ccode.endsWith("(30)"))
    //    //    {

    //    //    }
                 
    //    //    document.getElementById("contractnoTextBox").value = ccode;
    //    //}

    //    //else {
    //    //    ccode1 = document.getElementById("contractnoTextBox").value;
    //    //    ccode = ccode1.slice(0, -1);
    //    //    document.getElementById("contractnoTextBox").value = ccode;


    //    //}
    //    //var cy = document.getElementById("contracttypeDropDownList");
    //    //var contracttype = cy.options[cy.selectedIndex].text;
    //    //if (contracttype == "Trade-In-Fractionals") {

    //    //    if ((document.getElementById("ca3").checked == true)) {
    //    //        document.getElementById("lblregcoll").display = 'block';
    //    //        document.getElementById("regcollectiontermTextBox").display = 'block';
    //    //    }

    //    //    else {
    //    //        document.getElementById("lblregcoll").display = 'none';
    //    //        document.getElementById("regcollectiontermTextBox").display = 'none';

    //    //    }
    //    //}
    //    //else

    //    //{
    //    //    document.getElementById("lblregcoll").display = 'none';
    //    //    document.getElementById("regcollectiontermTextBox").display = 'none';
    //    //}

    

    //}

   
 
    function Procedure_Generation_Contract1()
    {
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;

        var vg = document.getElementById("GroupVenueDropDownList");
        var venugroup = vg.options[vg.selectedIndex].text;

        var club = document.getElementById("nmclubDropDownList").value;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var pm = document.getElementById("PrimarynationalityDropDownList");
        var nationality = pm.options[pm.selectedIndex].text;

        var incrvalue = document.getElementById("incrTextBox").value;

        var ct = document.getElementById("contracttypeDropDownList");
        var contracttype = ct.options[ct.selectedIndex].text;
        var ccode;
        var oct = document.getElementById("oldcontracttypeDropDownList");
        var ocontracttype = oct.options[oct.selectedIndex].text;
        // document.getElementById("oldcontracttypeTextBox").value = ocontracttype;
        if (contracttype == "Fractional" || contracttype == "Trade-In-Fractionals") {

            ccode = incrvalue;
            document.getElementById("contractnoTextBox").value = ccode;


        }
        else if (contracttype == "Points")
        {
            var tenure = document.getElementById("tenureTextBox").value;
            if (tenure == "30")
            {

                if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == false))
                {


                    ccode = incrvalue + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == true))
                {
                    ccode = incrvalue +"W"+ "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == false))
                {
                    ccode = incrvalue + "E" + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == true))
                {
                    ccode = incrvalue +"W"+ "E" + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }

            }
            else
            {
                if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == false))
                {
                    ccode = incrvalue ;
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == true))
                {
                    ccode = incrvalue +"W";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == false))
                {
                    ccode = incrvalue + "E";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == true))
                {
                    ccode = incrvalue +"W"+ "E";
                    document.getElementById("contractnoTextBox").value = ccode;
                }

            }


        }
        else if (contracttype == "Trade-In-Points")
        {
        //    alert("tip");
           
            var tenure = document.getElementById("tiptenureTextBox").value;
            //alert(tenure);
            //alert(incrvalue);
            if (tenure == "30")
            {
                
                if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == false)) {

                   // alert("1");
                    ccode = incrvalue + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == true)) {
                  //  alert("2");
                    ccode = incrvalue + "W" + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == false)) {
                   // alert("3");
                    ccode = incrvalue + "E" + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == true)) {
                  //  alert("4");
                    ccode = incrvalue + "W" + "E" + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }

            }
            else
            {
               
                if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == false)) {
                    ccode = incrvalue;
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == true)) {
                    ccode = incrvalue + "W";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == false)) {
                    ccode = incrvalue + "E";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == true)) {
                    ccode = incrvalue + "W" + "E";
                    document.getElementById("contractnoTextBox").value = ccode;
                }

            }
        }
        else if (contracttype == "Trade-In-Weeks")
        {
            var tenure = document.getElementById("nmtenureTextBox").value;
            if (tenure == "30") {

                if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == false)) {


                    ccode = incrvalue + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == true)) {
                    ccode = incrvalue + "W" + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == false)) {
                    ccode = incrvalue + "E" + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == true)) {
                    ccode = incrvalue + "W" + "E" + "(" + tenure + ")";
                    document.getElementById("contractnoTextBox").value = ccode;
                }

            }
            else {
                if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == false)) {
                    ccode = incrvalue;
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == false) && (document.getElementById("mcRadioButtonList").checked == true)) {
                    ccode = incrvalue + "W";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == false)) {
                    ccode = incrvalue + "E";
                    document.getElementById("contractnoTextBox").value = ccode;
                }
                else if ((document.getElementById("ca1").checked == true) && (document.getElementById("mcRadioButtonList").checked == true)) {
                    ccode = incrvalue + "W" + "E";
                    document.getElementById("contractnoTextBox").value = ccode;
                }

            }
        }
       
            
           
        }





    
    function Procedure_Generation_Contract(nat, cont,ten,inc)
    {

        var nationality = nat;
        var contracttype = cont;
        var tenure = ten;
        var incrvalue = inc;
        var ccode;
        //alert("p:" + contracttype);
        //alert("t:" + tenure);
        //alert("i:" + incrvalue);
        var oct = document.getElementById("oldcontracttypeDropDownList");
        var ocontracttype = oct.options[oct.selectedIndex].text;
       // document.getElementById("oldcontracttypeTextBox").value = ocontracttype;
        if(contracttype=="Fractional"||contracttype == "Trade-In-Fractionals")
        {
           
                    ccode = incrvalue;
                    document.getElementById("contractnoTextBox").value = ccode;

          


        }
       
        else
        {
            //alert("inside");
            if (tenure == "30")
            {
             
                //alert("inside:30");
                //if (document.getElementById("bittu").style.display = "block")
                //{
                    //alert("inside:30 visibility");
                    if ((document.getElementById("mcRadioButtonList").checked == true)) {

                        ccode = incrvalue + "W" + "(" + tenure + ")";
                        document.getElementById("contractnoTextBox").value = ccode;
                    }
                    else {
                        ccode = incrvalue + "(" + tenure + ")";
                        document.getElementById("contractnoTextBox").value = ccode;
                    }

                //}
                //else //if (document.getElementById("mcRadioButtonList").style.display = "none")
                //{
                //    alert("hiee");
                //    ccode = incrvalue + "(" + tenure + ")";
                //    document.getElementById("contractnoTextBox").value = ccode;

                //}

                
            }
            else 
            {
                //alert("25");
                //if (document.getElementById("bittu").style.display = "block")
                //{
                    //alert("visibility");
                    if ((document.getElementById("mcRadioButtonList").checked == true))
                    {
                        ccode = incrvalue + "W";
                        document.getElementById("contractnoTextBox").value = ccode;
                    }
                    else
                    {
                        //alert("correct");
                        ccode = incrvalue;
                        document.getElementById("contractnoTextBox").value = ccode;

                    }
                //}
                //else if (document.getElementById("bittu").style.display = "none")
                //{
                    
                //    alert("correct");
                //    ccode = incrvalue;
                //    document.getElementById("contractnoTextBox").value = ccode;


                //}
                    

                
                
            }
        }
        
       
       
          

    }
    
    /*function ChangeIntitalBalAmt()
    {
        var oct = document.getElementById("contracttypeDropDownList");
        var contracttype = oct.options[oct.selectedIndex].text;
       
        
        var initalbal = document.getElementById("baldepamtTextBox").value;
           var balamt = document.getElementById("balamtpayableTextBox").value;
           var balamtpayable = parseInt(balamt) - parseInt(initalbal);
        //from initialbal get the installment
           DisplayInstallmentAmt();

 
           var total = parseInt(initalbal) + parseInt(balamtpayable);
           if (contracttype == "Fractional" || contracttype == "Trade-In-Fractionals")
           {

               document.getElementById("fractionalbalanceTextBox").value = total;
           }
           else
           {
               document.getElementById("balanceTextBox").value = total;

           }
    }*/
   
    //occupancy calculation for fractional

    function GetFractionalLastYr()
    {
        document.getElementById("ftenureTextBox").value = "15";
        var firstyr = document.getElementById("ffirstyrTextBox").value;
        var tenure = document.getElementById("ftenureTextBox").value;

        var lastyr = parseInt(firstyr) + ( parseInt(tenure) - 1);
        document.getElementById("flastyrTextBox").value = lastyr;

        var d = new Date();
        var n = d.getDate();
        var m = d.getMonth() + 1;
        var y = d.getFullYear().toString().substr(2, 2);
        var currdate = n + "" + m + "" + y;


        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;

        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venugroup = vg.options[vg.selectedIndex].text;

        var club = document.getElementById("resortDropDownList").value;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var pm = document.getElementById("PrimarynationalityDropDownList");
        var nationality = pm.options[pm.selectedIndex].text;

        var incrvalue = document.getElementById("incrTextBox").value;
   
        var ct = document.getElementById("contracttypeDropDownList");
        var contracttype = ct.options[ct.selectedIndex].text;
       
        var ccode;
         Procedure_Generation_Contract(nationality, contracttype, tenure, incrvalue);
        var rt = document.getElementById("residencetypeDropDownList");
        var rtype = rt.options[rt.selectedIndex].text;
        document.getElementById("testresTextBox").value = rtype;

        var rn = document.getElementById("residenceDropDownListno");
        var resno = rn.options[rn.selectedIndex].text;
        document.getElementById("testresnoTextBox").value = resno;
       // alert(rtype);
    }

    function GetFractionalWeekLastYr() {
        document.getElementById("fwtenureTextBox").value = "15";
        var firstyr = document.getElementById("fwfirstyrTextBox").value;
        var tenure = document.getElementById("fwtenureTextBox").value;

        var lastyr = parseInt(firstyr) + (parseInt(tenure) - 1);
        document.getElementById("fwlastyrTextBox").value = lastyr;

        var d = new Date();
        var n = d.getDate();
        var m = d.getMonth() + 1;
        var y = d.getFullYear().toString().substr(2, 2);
        var currdate = n + "" + m + "" + y;


        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;

        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venugroup = vg.options[vg.selectedIndex].text;

        var club = document.getElementById("fwresortDropDownList").value;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var pm = document.getElementById("PrimarynationalityDropDownList");
        var nationality = pm.options[pm.selectedIndex].text;

        var incrvalue = document.getElementById("incrTextBox").value;

        var ct = document.getElementById("contracttypeDropDownList");
        var contracttype = ct.options[ct.selectedIndex].text;

        var ccode;
        // ContractNo_GenerationProcedure(nationality, venue, venugroup, club, mktg, currdate, incrvalue, contracttype, tenure);
        Procedure_Generation_Contract(nationality, contracttype, tenure, incrvalue);
        var rt = document.getElementById("fwresidencetypeDropDownList");
        var rtype = rt.options[rt.selectedIndex].text;
        document.getElementById("fwresidencetype1TextBox").value = rtype;

        var rn = document.getElementById("fwresidencenoDropDownList");
        var resno = rn.options[rn.selectedIndex].text;
        document.getElementById("fwresidenceno1TextBox").value = resno;
        // alert(rtype);
    }
    function GetFractionaltoFractionalLastYr() {
        document.getElementById("fftenureTextBox").value = "15";
        var firstyr = document.getElementById("fffirstyrTextBox").value;
        var tenure = document.getElementById("fftenureTextBox").value;

        var lastyr = parseInt(firstyr) + (parseInt(tenure) - 1);
        document.getElementById("fflastyrTextBox").value = lastyr;

        var d = new Date();
        var n = d.getDate();
        var m = d.getMonth() + 1;
        var y = d.getFullYear().toString().substr(2, 2);
        var currdate = n + "" + m + "" + y;


        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;

        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venugroup = vg.options[vg.selectedIndex].text;

        var club = document.getElementById("ffresortDropDownList").value;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var pm = document.getElementById("PrimarynationalityDropDownList");
        var nationality = pm.options[pm.selectedIndex].text;

        var incrvalue = document.getElementById("incrTextBox").value;

        var ct = document.getElementById("contracttypeDropDownList");
        var contracttype = ct.options[ct.selectedIndex].text;

        var ccode;
        // ContractNo_GenerationProcedure(nationality, venue, venugroup, club, mktg, currdate, incrvalue, contracttype, tenure);
        Procedure_Generation_Contract(nationality, contracttype, tenure, incrvalue);
        var rt = document.getElementById("ffresidencetypeDropDownList");
        var rtype = rt.options[rt.selectedIndex].text;
        document.getElementById("ffresidencetype1TextBox").value = rtype;

        var rn = document.getElementById("ffresidencenoDropDownList");
        var resno = rn.options[rn.selectedIndex].text;
        document.getElementById("ffresidenceno1TextBox").value = resno;
        // alert(rtype);
    }
    function GetFractionalPointsLastYr() {
        document.getElementById("fptstenureTextBox").value = "15";
        var firstyr = document.getElementById("fptsfirstyrTextBox").value;
        var tenure = document.getElementById("fptstenureTextBox").value;

        var lastyr = parseInt(firstyr) + (parseInt(tenure) - 1);
        document.getElementById("fptslastyrTextBox").value = lastyr;

        var d = new Date();
        var n = d.getDate();
        var m = d.getMonth() + 1;
        var y = d.getFullYear().toString().substr(2, 2);
        var currdate = n + "" + m + "" + y;


        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;

        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venugroup = vg.options[vg.selectedIndex].text;

        var club = document.getElementById("fptsresortDropDownList").value;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var pm = document.getElementById("PrimarynationalityDropDownList");
        var nationality = pm.options[pm.selectedIndex].text;

        var incrvalue = document.getElementById("incrTextBox").value;

        var ct = document.getElementById("contracttypeDropDownList");
        var contracttype = ct.options[ct.selectedIndex].text;

        var ccode;
        
        Procedure_Generation_Contract(nationality, contracttype, tenure, incrvalue);
        var rt = document.getElementById("fptsresidencetypeDropDownList");
        var rtype = rt.options[rt.selectedIndex].text;
        document.getElementById("fptsresidencetype1TextBox").value = rtype;

        var rn = document.getElementById("fptsResidencenoDropDownList");
        var resno = rn.options[rn.selectedIndex].text;
        document.getElementById("fptsResidenceno1TextBox").value = resno;
        // alert(rtype);
    }

    //display new points=total new pts pOINTS CONTRACT
    function New_totalPoints() {
        var new_points = document.getElementById("newpointsrightTextBox").value;
        document.getElementById("totalptrightsTextBox").value = new_points;

    }
    function GetLastYr()
    {
        var firstyr = document.getElementById("firstyrTextBox").value;
        var tenure = document.getElementById("tenureTextBox").value;

        var lastyr = parseInt(firstyr) + (tenure - 1);
        document.getElementById("lastyrTextBox").value = lastyr;

    
        var d = new Date();
        var n = d.getDate();
        var m = d.getMonth() + 1;
        var y = d.getFullYear().toString().substr(2, 2);
        var currdate = n + "" + m + "" + y;
       
       
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;      

        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venugroup = vg.options[vg.selectedIndex].text;

        var club = document.getElementById("pointsclubDropDownList").value;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var pm = document.getElementById("PrimarynationalityDropDownList");
        var nationality = pm.options[pm.selectedIndex].text;

        var incrvalue = document.getElementById("incrTextBox").value;

        var ct = document.getElementById("contracttypeDropDownList");
        var contracttype = ct.options[ct.selectedIndex].text;
        var ccode;
        //Procedure_Generation_Contract(nationality, contracttype, tenure, incrvalue);
    }
   

    //calculate trade in non member
    function PointsCalculation_NonMemberFromTotalpoints() {
        var tradeinpoints = document.getElementById("nmpointsvalueTextBox").value;
        var new_points = document.getElementById("nmnewpointsrightsTextBox").value;

        if (new_points == "" || new_points == "0") {
            document.getElementById("nmtotalpointsTextBox").value = tradeinpoints;

        }
        else {
            var totalpoints = parseInt(new_points) + parseInt(tradeinpoints);
            document.getElementById("nmtotalpointsTextBox").value = totalpoints;
        }


    }
    function Tradeintoweekscalculation() {
        var tradeinpoints = document.getElementById("nmpointsvalueTextBox").value;
        var new_points = document.getElementById("nmnewpointsrightsTextBox").value;

        if (new_points == "" || new_points == "0") {
            document.getElementById("nmtotalpointsTextBox").value = tradeinpoints;

        }
        else {
            var totalpoints = parseInt(new_points) + parseInt(tradeinpoints);
            document.getElementById("nmtotalpointsTextBox").value = totalpoints;
        }


    }
    function TradeintoweeksOccupancyCalculation() {
        var firstyr = document.getElementById("nmfirstyrTextBox").value;
        var tenure = document.getElementById("nmtenureTextBox").value;

        var lastyr = parseInt(firstyr) + (tenure - 1);
        document.getElementById("nmlastyrTextBox").value = lastyr;

        var d = new Date();
        var n = d.getDate();
        var m = d.getMonth() + 1;
        var y = d.getFullYear().toString().substr(2, 2);
        var currdate = n + "" + m + "" + y;


        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;

        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venugroup = vg.options[vg.selectedIndex].text;

        var club = document.getElementById("nmclubDropDownList").value;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var pm = document.getElementById("PrimarynationalityDropDownList");
        var nationality = pm.options[pm.selectedIndex].text;

        var incrvalue = document.getElementById("incrTextBox").value;

        var ct = document.getElementById("contracttypeDropDownList");
        var contracttype = ct.options[ct.selectedIndex].text;
        var ccode;
      
      //  Procedure_Generation_Contract(nationality, contracttype, tenure, incrvalue);

        
    }

    function FractionalTradeintopointscalculation()
    {
        var NOPOINTS, POINTSVALUE, NEWPOINTSRIGHTS, TOTALPOINTSRIGHTS, newpts;
        var tradeinpoints = document.getElementById("fptsnoptsTextBox").value;
        document.getElementById("fptsvalTextBox").value = tradeinpoints;
       

    }

    function Tradeintopointscalculation()
    {
        var NOPOINTS, POINTSVALUE, NEWPOINTSRIGHTS, TOTALPOINTSRIGHTS, newpts ;
    

       
        var tradeinpoints = document.getElementById("tipnopointsTextBox").value;
       document.getElementById("tipptsvalueTextBox").value = tradeinpoints;
        var new_points = document.getElementById("tipnewpointsTextBox").value;

        if (new_points == "" || new_points == "0")
        {

            document.getElementById("tiptotalpointsTextBox").value = tradeinpoints;

        }
        else {
            var totalpoints = parseInt(new_points) + parseInt(tradeinpoints);
            document.getElementById("tiptotalpointsTextBox").value = totalpoints;
        } 
        

    }
    function TradeintopointsOccupancyCalculation() {
        var firstyr = document.getElementById("tipfirstyrTextBox").value;
        var tenure = document.getElementById("tiptenureTextBox").value;

        var lastyr = parseInt(firstyr) + (tenure - 1);
        document.getElementById("tiplastyrTextBox").value = lastyr;

        var d = new Date();
        var n = d.getDate();
        var m = d.getMonth() + 1;
        var y = d.getFullYear().toString().substr(2, 2);
        var currdate = n + "" + m + "" + y;
       
       
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;      

        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venugroup = vg.options[vg.selectedIndex].text;

        var club = document.getElementById("ntipclubDropDownList").value;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var pm = document.getElementById("PrimarynationalityDropDownList");
        var nationality = pm.options[pm.selectedIndex].text;

        var incrvalue = document.getElementById("incrTextBox").value;
        
        var ct = document.getElementById("contracttypeDropDownList");
        var contracttype = ct.options[ct.selectedIndex].text;
        var ccode;
       
        //Procedure_Generation_Contract(nationality, contracttype, tenure, incrvalue);
        
    }


    function GetRDBValue() {
        var radio = document.getElementsByName('rdbGender');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {
                //  alert(radio[i].value);
            }
        }
    }

    function ViewFractionalTradeIntype()
    {
        var ct = document.getElementById("oldcontracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;

        //var oct = document.getElementById("oldcontracttypeDropDownList").value;
        //var ocontracttype = oct.options[oct.selectedIndex].text;
        document.getElementById("oldcontracttypeTextBox").value = contract_type;

        if(contract_type=="Points")
        {
            document.getElementById("cdivtradeinweeks").style.display = 'none';
            document.getElementById("cdivtradeinpoints").style.display = 'none';

            document.getElementById("lblfwconno").style.display = 'none';
            document.getElementById("fwconnoTextBox").style.display = 'none';
            document.getElementById("lblfwresort").style.display = 'none';
            document.getElementById("fwresortDropDownList").style.display = 'none';
            document.getElementById("lblfwresidenceno").style.display = 'none';
            document.getElementById("fwresidencenoDropDownList").style.display = 'none';
            document.getElementById("lblfwresidenceno1").style.display = 'none';
            document.getElementById("fwresidenceno1TextBox").style.display = 'none';
            document.getElementById("lblfwresidencetype").style.display = 'none';
            document.getElementById("fwresidencetypeDropDownList").style.display = 'none';
            document.getElementById("lblfwresidencetype1").style.display = 'none';
            document.getElementById("fwresidencetype1TextBox").style.display = 'none';
            document.getElementById("lblfwfractInt").style.display = 'none';
            document.getElementById("fwfractIntDropDownList").style.display = 'none';
            document.getElementById("lblfwentitlement").style.display = 'none';
            document.getElementById("fwentitlementDropDownList").style.display = 'none';
            document.getElementById("lblfwfirstyr").style.display = 'none';
            document.getElementById("fwfirstyrTextBox").style.display = 'none';
            document.getElementById("lblfwtenure").style.display = 'none';
            document.getElementById("fwtenureTextBox").style.display = 'none';
            document.getElementById("lblfwlastyr").style.display = 'none';
            document.getElementById("fwlastyrTextBox").style.display = 'none';
            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("fractionalpoints").style.display = 'block';
            document.getElementById("fractionaltofractionals").style.display = 'none';
            

        }
        else if(contract_type=="Weeks")
        {
            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionalweeks").style.display = 'block';
            document.getElementById("lblfwconno").style.display = 'block';
            document.getElementById("fwconnoTextBox").style.display = 'block';
            document.getElementById("lblfwresort").style.display = 'block';
            document.getElementById("fwresortDropDownList").style.display = 'block';
            document.getElementById("lblfwresidenceno").style.display = 'block';
            document.getElementById("fwresidencenoDropDownList").style.display = 'block';
            document.getElementById("lblfwresidenceno1").style.display = 'none';
            document.getElementById("fwresidenceno1TextBox").style.display = 'none';
            document.getElementById("lblfwresidencetype").style.display = 'block';
            document.getElementById("fwresidencetypeDropDownList").style.display = 'block';
            document.getElementById("lblfwresidencetype1").style.display = 'none';
            document.getElementById("fwresidencetype1TextBox").style.display = 'none';
            document.getElementById("lblfwfractInt").style.display = 'block';
            document.getElementById("fwfractIntDropDownList").style.display = 'block';
            document.getElementById("lblfwentitlement").style.display = 'block';
            document.getElementById("fwentitlementDropDownList").style.display = 'block';
            document.getElementById("lblfwfirstyr").style.display = 'block';
            document.getElementById("fwfirstyrTextBox").style.display = 'block';
            document.getElementById("lblfwtenure").style.display = 'block';
            document.getElementById("fwtenureTextBox").style.display = 'block';
            document.getElementById("lblfwlastyr").style.display = 'block';
            document.getElementById("fwlastyrTextBox").style.display = 'block';
            document.getElementById("fractionaltofractionals").style.display = 'none';

        }
        else if (contract_type == "Fractionals") {
            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("lblffconno").style.display = 'block';
            document.getElementById("ffconnoTextBox").style.display = 'block';
            document.getElementById("lblffresort").style.display = 'block';
            document.getElementById("ffresortDropDownList").style.display = 'block';
            document.getElementById("lblffresidenceno").style.display = 'block';
            document.getElementById("ffresidencenoDropDownList").style.display = 'block';
            document.getElementById("lblffresidenceno1").style.display = 'none';
            document.getElementById("ffresidenceno1TextBox").style.display = 'none';
            document.getElementById("lblffresidencetype").style.display = 'block';
            document.getElementById("ffresidencetypeDropDownList").style.display = 'block';
            document.getElementById("lblffresidencetype1").style.display = 'none';
            document.getElementById("ffresidencetype1TextBox").style.display = 'none';
            document.getElementById("lblfffractInt").style.display = 'block';
            document.getElementById("fffractIntDropDownList").style.display = 'block';
            document.getElementById("lblffentitlement").style.display = 'block';
            document.getElementById("ffentitlementDropDownList").style.display = 'block';
            document.getElementById("lblfffirstyr").style.display = 'block';
            document.getElementById("fwfirstyrTextBox").style.display = 'block';
            document.getElementById("lblfftenure").style.display = 'block';
            document.getElementById("fftenureTextBox").style.display = 'block';
            document.getElementById("lblfflastyr").style.display = 'block';
            document.getElementById("fflastyrTextBox").style.display = 'block';
            document.getElementById("fractionaltofractionals").style.display = 'block';

        }
    }
    function contracttype() {

      //  var conttype = document.getElementById("contracttypeDropDownList").value;
        var ct = document.getElementById("contracttypeDropDownList");
        var conttype = ct.options[ct.selectedIndex].text;
        if (conttype == "Fractional") {
         
            document.getElementById("cdiv3").style.display = 'none';
            document.getElementById("cdiv2").style.display = 'none';
            document.getElementById("cdivtradeinweeks").style.display = 'none';
            document.getElementById("cdivtradeinpoints").style.display = 'none';
            document.getElementById("cdiv1").style.display = 'block';
            document.getElementById("cdiv4").style.display = 'none';
           document.getElementById("financetitle").style.display = 'block';
            document.getElementById("cright").style.display = 'none';
            document.getElementById("ffractional1").style.display = 'block';
            document.getElementById("remarks").style.display = 'Block';
            document.getElementById("Points").style.display = 'none';
            document.getElementById("tfractional").style.display = 'none';
           
            document.getElementById("TextBox45").value = "1500";
            document.getElementById("TextBox46").value = "";
            document.getElementById("PayMethodDropDownList").value = "";
            document.getElementById("financemethodDropDownList").value = "";
            document.getElementById("FinancenoTextBox").value = "";
            //  document.getElementById("emiamtTextBox").value = "";
            document.getElementById("noemiTextBox").value = "";
            document.getElementById("lblchk3").style.display = 'block';
            document.getElementById("mcRadioButtonList").style.display = 'none';
            document.getElementById("ftenureTextBox").value = "15";
          

          //  document.getElementById("TextBox49").value = "krr/"

            document.getElementById("financeradiobuttonlist").value = "";
            document.getElementById("totalfinpriceIntaxTextBox").value = "";
            document.getElementById("currencyDropDownList").value = "";
            document.getElementById("totalfinpriceIntaxTextBox").value = "";
            document.getElementById("intialdeppercentTextBox").value = "";
            document.getElementById("initaldepamtTextBox").value = "";
            document.getElementById("PayMethodDropDownList").value = "";
            document.getElementById("firstdepamtTextBox").value = "";
            document.getElementById("balamtpayableTextBox").value = "";
            document.getElementById("NoinstallmentTextBox").value = "";
            document.getElementById("installmentamtTextBox").value = "";
            document.getElementById("lblconversionfee").style.display = 'none';
            document.getElementById("conversionfeeTextBox").style.display = 'none';

            document.getElementById("nmpointsvalueTextBox").value = "0";
            document.getElementById("nmnewpointsrightsTextBox").value = "0";
            document.getElementById("nmtotalpointsTextBox").value = "0";
            document.getElementById("tipnopointsTextBox").value = "0";
            document.getElementById("tipptsvalueTextBox").value = "0";
            document.getElementById("tipnewpointsTextBox").value = "0";
            document.getElementById("tiptotalpointsTextBox").value = "0";

         
            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionaltofractionals").style.display = 'none';
        }
        else if (conttype == "Points") {
            document.getElementById("cdiv1").style.display = 'none';
            document.getElementById("cdiv2").style.display = 'block';
            document.getElementById("cdiv3").style.display = 'none';
            document.getElementById("cdiv4").style.display = 'none';
            document.getElementById("cdivtradeinweeks").style.display = 'none';
            document.getElementById("cdivtradeinpoints").style.display = 'none';
             document.getElementById("financetitle").style.display = 'block';
            document.getElementById("cright").style.display = 'none';
            document.getElementById("ffractional1").style.display = 'none';
            document.getElementById("Points").style.display = 'block';
            document.getElementById("remarks").style.display = 'block';
            document.getElementById("tfractional").style.display = 'none';
          
            //  var adfees = document.getElementById("pointsamtTextBox").value;
            //  document.getElementById("adminfeeTextBox").value = adfees;
            document.getElementById("lblconversionfee").style.display = 'none';
            document.getElementById("conversionfeeTextBox").style.display = 'none';
            document.getElementById("lblchk3").style.display = 'none';
           //document.getElementById("mcRadioButtonList").style.display = 'block';

            document.getElementById("totalfinpriceIntaxTextBox").value = "";
            document.getElementById("financeradiobuttonlist").value = "";
            document.getElementById("currencyDropDownList").value = "";
            document.getElementById("totalfinpriceIntaxTextBox").value = "";
         document.getElementById("intialdeppercentTextBox").value = "";
            document.getElementById("initaldepamtTextBox").value = "";
            document.getElementById("PayMethodDropDownList").value = "";
            document.getElementById("firstdepamtTextBox").value = "";
            document.getElementById("balamtpayableTextBox").value = "";
            document.getElementById("NoinstallmentTextBox").value = "";
            document.getElementById("installmentamtTextBox").value = "";
            document.getElementById("financemethodDropDownList").value = "";
            document.getElementById("FinancenoTextBox").value = "";
            //   document.getElementById("emiamtTextBox").value = "";
            document.getElementById("noemiTextBox").value = "";

            document.getElementById("nmpointsvalueTextBox").value = "0";
            document.getElementById("nmnewpointsrightsTextBox").value = "0";
            document.getElementById("nmtotalpointsTextBox").value = "0";
            document.getElementById("tipnopointsTextBox").value = "0";
            document.getElementById("tipptsvalueTextBox").value = "0";
            document.getElementById("tipnewpointsTextBox").value = "0";
            document.getElementById("tiptotalpointsTextBox").value = "0";


            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("fractionaltofractionals").style.display = 'none';
        }
        else if (conttype == "Trade-In-NonMembers") {
            document.getElementById("cdiv1").style.display = 'none';
            document.getElementById("cdiv2").style.display = 'none';
            document.getElementById("cdivtradeinweeks").style.display = 'block';
            document.getElementById("cdivtradeinpoints").style.display = 'none';
            document.getElementById("cdiv3").style.display = 'none';
            document.getElementById("cdiv4").style.display = 'none';
         document.getElementById("financetitle").style.display = 'block';
         document.getElementById("cright").style.display = 'none';
            document.getElementById("ffractional1").style.display = 'none';
            document.getElementById("Points").style.display = 'block';
            document.getElementById("remarks").style.display = 'block';
            document.getElementById("tfractional").style.display = 'none';
          
            //var adfees = document.getElementById("pointsamtTextBox").value;
            //document.getElementById("adminfeeTextBox").value = adfees;

           // document.getElementById("mcRadioButtonList").style.display = 'block';
                    

            document.getElementById("nmpointsvalueTextBox").value = "0";
            document.getElementById("nmnewpointsrightsTextBox").value = "0";
            document.getElementById("nmtotalpointsTextBox").value = "0";
            document.getElementById("tipnopointsTextBox").value = "0";
            document.getElementById("tipptsvalueTextBox").value = "0";
            document.getElementById("tipnewpointsTextBox").value = "0";
            document.getElementById("tiptotalpointsTextBox").value = "0";

            document.getElementById("totalfinpriceIntaxTextBox").value = "";
            document.getElementById("financeradiobuttonlist").value = "";
            document.getElementById("currencyDropDownList").value = "";
            document.getElementById("totalfinpriceIntaxTextBox").value = "";
       document.getElementById("intialdeppercentTextBox").value = "";
            document.getElementById("initaldepamtTextBox").value = "";
            document.getElementById("PayMethodDropDownList").value = "";
            document.getElementById("firstdepamtTextBox").value = "";
            document.getElementById("balamtpayableTextBox").value = "";
            document.getElementById("NoinstallmentTextBox").value = "";
            document.getElementById("installmentamtTextBox").value = "";
            document.getElementById("financemethodDropDownList").value = "";
            document.getElementById("FinancenoTextBox").value = "";
            //  document.getElementById("emiamtTextBox").value = "";
            document.getElementById("noemiTextBox").value = "";
            document.getElementById("lblconversionfee").style.display = 'none';
            document.getElementById("conversionfeeTextBox").style.display = 'none';

            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("fractionaltofractionals").style.display = 'none';
        }
        else if (conttype == "Trade-In-Weeks") {
            document.getElementById("cdiv1").style.display = 'none';
            document.getElementById("cdiv2").style.display = 'none';
            document.getElementById("cdivtradeinweeks").style.display = 'block';
            document.getElementById("cdivtradeinpoints").style.display = 'none';
            document.getElementById("cdiv3").style.display = 'none';
            document.getElementById("cdiv4").style.display = 'none';
           document.getElementById("financetitle").style.display = 'block';
            document.getElementById("cright").style.display = 'none';
            document.getElementById("ffractional1").style.display = 'none';
            document.getElementById("Points").style.display = 'block';
            document.getElementById("remarks").style.display = 'block';
            document.getElementById("tfractional").style.display = 'none';
         
            //var adfees = document.getElementById("pointsamtTextBox").value;
            //document.getElementById("adminfeeTextBox").value = adfees;
            document.getElementById("lblconversionfee").style.display = 'block';
            document.getElementById("conversionfeeTextBox").style.display = 'block';

            document.getElementById("totalfinpriceIntaxTextBox").value = "";
            document.getElementById("financeradiobuttonlist").value = "";
            document.getElementById("currencyDropDownList").value = "";
            document.getElementById("totalfinpriceIntaxTextBox").value = "";
           document.getElementById("intialdeppercentTextBox").value = "";
            document.getElementById("initaldepamtTextBox").value = "";
            document.getElementById("PayMethodDropDownList").value = "";
            document.getElementById("firstdepamtTextBox").value = "";
            document.getElementById("balamtpayableTextBox").value = "";
            document.getElementById("NoinstallmentTextBox").value = "";
            document.getElementById("installmentamtTextBox").value = "";
            document.getElementById("financemethodDropDownList").value = "";
            document.getElementById("FinancenoTextBox").value = "";
            // document.getElementById("emiamtTextBox").value = "";
            document.getElementById("noemiTextBox").value = "";

           // document.getElementById("mcRadioButtonList").style.display = 'block';
            document.getElementById("nmpointsvalueTextBox").value = "0";
            document.getElementById("nmnewpointsrightsTextBox").value = "0";
            document.getElementById("nmtotalpointsTextBox").value = "0";
            document.getElementById("tipnopointsTextBox").value = "0";
            document.getElementById("tipptsvalueTextBox").value = "0";
            document.getElementById("tipnewpointsTextBox").value = "0";
            document.getElementById("tiptotalpointsTextBox").value = "0";
            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionaltofractionals").style.display = 'none';
        }
        else if (conttype == "Trade-In-Points") {
            document.getElementById("cdiv1").style.display = 'none';
            document.getElementById("cdiv2").style.display = 'none';
            document.getElementById("cdivtradeinweeks").style.display = 'none';
            document.getElementById("cdivtradeinpoints").style.display = 'block';
            document.getElementById("cdiv3").style.display = 'none';
            document.getElementById("cdiv4").style.display = 'none';
           document.getElementById("financetitle").style.display = 'block';
            document.getElementById("cright").style.display = 'none';
            document.getElementById("ffractional1").style.display = 'none';
            document.getElementById("Points").style.display = 'block';
            document.getElementById("remarks").style.display = 'block';
            document.getElementById("tfractional").style.display = 'none';
         
            //var adfees = document.getElementById("pointsamtTextBox").value;
            //document.getElementById("adminfeeTextBox").value = adfees;
            document.getElementById("lblconversionfee").style.display = 'block';
            document.getElementById("conversionfeeTextBox").style.display = 'block';
          //  document.getElementById("lblconversionfee").style.text = 'Purchase Price';
            document.getElementById("totalfinpriceIntaxTextBox").value = "";
            document.getElementById("financeradiobuttonlist").value = "";
            document.getElementById("currencyDropDownList").value = "";
            document.getElementById("totalfinpriceIntaxTextBox").value = "";
          document.getElementById("intialdeppercentTextBox").value = "";
            document.getElementById("initaldepamtTextBox").value = "";
            document.getElementById("PayMethodDropDownList").value = "";
            document.getElementById("firstdepamtTextBox").value = "";
            document.getElementById("balamtpayableTextBox").value = "";
            document.getElementById("NoinstallmentTextBox").value = "";
            document.getElementById("installmentamtTextBox").value = "";
            document.getElementById("financemethodDropDownList").value = "";
            document.getElementById("FinancenoTextBox").value = "";
            //document.getElementById("emiamtTextBox").value = "";
            document.getElementById("noemiTextBox").value = "";
          //  document.getElementById("mcRadioButtonList").style.display = 'block';

            document.getElementById("nmpointsvalueTextBox").value = "0";
            document.getElementById("nmnewpointsrightsTextBox").value = "0";
            document.getElementById("nmtotalpointsTextBox").value = "0";
            document.getElementById("tipnopointsTextBox").value = "0";
            document.getElementById("tipptsvalueTextBox").value = "0";
            document.getElementById("tipnewpointsTextBox").value = "0";
            document.getElementById("tiptotalpointsTextBox").value = "0";
            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionaltofractionals").style.display = 'none';
        }
        else if (conttype == "Trade-In-Fractionals") {
            document.getElementById("cdiv1").style.display = 'none';
            document.getElementById("cdiv2").style.display = 'none';
            document.getElementById("cdivtradeinweeks").style.display = 'none';
            document.getElementById("cdivtradeinpoints").style.display = 'none';
            document.getElementById("cdiv3").style.display = 'block';
            document.getElementById("cdiv4").style.display = 'none';
             document.getElementById("financetitle").style.display = 'block';
             document.getElementById("cright").style.display = 'none';
            document.getElementById("ffractional1").style.display = 'block';
            document.getElementById("Points").style.display = 'none';
            document.getElementById("remarks").style.display = 'block';
            document.getElementById("tfractional").style.display = 'none';
         
         //   document.getElementById("TextBox45").value = "750";
         //   document.getElementById("TextBox46").value = "";
            document.getElementById("PayMethodDropDownList").value = "";
            document.getElementById("totalfinpriceIntaxTextBox").value = "";
            document.getElementById("financeradiobuttonlist").value = "";
            document.getElementById("currencyDropDownList").value = "";
            document.getElementById("totalfinpriceIntaxTextBox").value = "";
           document.getElementById("intialdeppercentTextBox").value = "";
            document.getElementById("initaldepamtTextBox").value = "";
            document.getElementById("PayMethodDropDownList").value = "";
            document.getElementById("firstdepamtTextBox").value = "";
            document.getElementById("balamtpayableTextBox").value = "";
            document.getElementById("NoinstallmentTextBox").value = "";
            document.getElementById("installmentamtTextBox").value = "";
            document.getElementById("financemethodDropDownList").value = "";
            document.getElementById("FinancenoTextBox").value = "";
            // document.getElementById("emiamtTextBox").value = "";
            document.getElementById("noemiTextBox").value = "";
            document.getElementById("lblconversionfee").style.display = 'none';
            document.getElementById("conversionfeeTextBox").style.display = 'none';

            document.getElementById("nmpointsvalueTextBox").value = "0";
            document.getElementById("nmnewpointsrightsTextBox").value = "0";
            document.getElementById("nmtotalpointsTextBox").value = "0";
            document.getElementById("tipnopointsTextBox").value = "0";
            document.getElementById("tipptsvalueTextBox").value = "0";
            document.getElementById("tipnewpointsTextBox").value = "0";
            document.getElementById("tiptotalpointsTextBox").value = "0";
            document.getElementById("mcRadioButtonList").style.display = 'none';

            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionaltofractionals").style.display = 'none';
        }

        else if (conttype == "Choose Contract Type")
        {
            document.getElementById("cdiv1").style.display = 'none';
            document.getElementById("cdiv2").style.display = 'none';
            document.getElementById("cdivtradeinweeks").style.display = 'none';
            document.getElementById("cdivtradeinpoints").style.display = 'none';
            document.getElementById("cdiv3").style.display = 'none';
            document.getElementById("cdiv4").style.display = 'none';
            document.getElementById("cright").style.display = 'none';
          document.getElementById("financetitle").style.display = 'none';
            document.getElementById("cright").style.display = 'none';
            document.getElementById("b1").style.display = 'none';
            //document.getElementById("PayMethodDropDownList").value = "";
            //document.getElementById("totalfinpriceIntaxTextBox").value = "";
            //document.getElementById("financeradiobuttonlist").value = "";
            //document.getElementById("currencyDropDownList").value = "";
            //document.getElementById("totalfinpriceIntaxTextBox").value = "";
            //document.getElementById("intialdeppercentTextBox").value = "";
            //document.getElementById("initaldepamtTextBox").value = "";
            //document.getElementById("PayMethodDropDownList").value = "";
            //document.getElementById("firstdepamtTextBox").value = "";
            //document.getElementById("balamtpayableTextBox").value = "";
            //document.getElementById("NoinstallmentTextBox").value = "";
            //document.getElementById("installmentamtTextBox").value = "";
            //document.getElementById("financemethodDropDownList").value = "";
            //document.getElementById("FinancenoTextBox").value = "";
            ////document.getElementById("emiamtTextBox").value = "";
            //document.getElementById("noemiTextBox").value = "";
            document.getElementById("lblconversionfee").style.display = 'none';
            document.getElementById("conversionfeeTextBox").style.display = 'none';
            document.getElementById("mcRadioButtonList").style.display = 'none';

            document.getElementById("nmpointsvalueTextBox").value = "0";
            document.getElementById("nmnewpointsrightsTextBox").value = "0";
            document.getElementById("nmtotalpointsTextBox").value = "0";
            document.getElementById("tipnopointsTextBox").value = "0";
            document.getElementById("tipptsvalueTextBox").value = "0";
            document.getElementById("tipnewpointsTextBox").value = "0";
            document.getElementById("tiptotalpointsTextBox").value = "0";
            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionaltofractionals").style.display = 'none';
        }
        else {
            document.getElementById("cdiv1").style.display = 'none';
            document.getElementById("cdiv2").style.display = 'none';
            document.getElementById("cdivtradeinweeks").style.display = 'none';
            document.getElementById("cdivtradeinpoints").style.display = 'none';
            document.getElementById("cdiv3").style.display = 'none';
            document.getElementById("cdiv4").style.display = 'block';
            document.getElementById("financetitle").style.display = 'block';
            document.getElementById("cright").style.display = 'none';
           document.getElementById("mcRadioButtonList").style.display = 'none';
            document.getElementById("ffractional1").style.display = 'none';
            document.getElementById("Points").style.display = 'none';
            document.getElementById("remarks").style.display = 'block';
            document.getElementById("tfractional").style.display = 'none';
         

            document.getElementById("PayMethodDropDownList").value = "";

            //document.getElementById("totalfinpriceIntaxTextBox").value = "";
            //document.getElementById("financeradiobuttonlist").value = "";
            //document.getElementById("currencyDropDownList").value = "";
            //document.getElementById("intialdeppercentTextBox").value = "";
            //document.getElementById("initaldepamtTextBox").value = "";
            //document.getElementById("PayMethodDropDownList").value = "";
            //document.getElementById("firstdepamtTextBox").value = "";
            //document.getElementById("balamtpayableTextBox").value = "";
            //document.getElementById("NoinstallmentTextBox").value = "";
            //document.getElementById("installmentamtTextBox").value = "";
            //document.getElementById("financemethodDropDownList").value = "";
            //document.getElementById("FinancenoTextBox").value = "";
            //// document.getElementById("emiamtTextBox").value = "";
            //document.getElementById("noemiTextBox").value = "";
            //document.getElementById("lblconversionfee").style.display = 'none';
            //document.getElementById("conversionfeeTextBox").style.display = 'none';
            document.getElementById("fractionalweeks").style.display = 'none';
            document.getElementById("fractionalpoints").style.display = 'none';
            document.getElementById("fractionaltofractionals").style.display = 'none';
        }
    }
    function InitialBalCalculation()
    {
        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
        var oct = document.getElementById("oldcontracttypeDropDownList");
        var ocontract_type = oct.options[oct.selectedIndex].text;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
       
                 
        if (contract_type == "Fractional") {
            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
            var depositamt = document.getElementById("intialdeppercentTextBox").value;
            var intitalbal = document.getElementById("balinitialdepamtTextBox").value;
            var intitaldepbal = document.getElementById("baldepamtTextBox").value;
            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
            if (percent < 10) {
                document.getElementById("lblbaladepamt").style.display = 'block';
                document.getElementById("baldepamtTextBox").style.display = 'block';
                document.getElementById("lblbaladepamtdate").style.display = 'block';
                document.getElementById("baladepamtdateTextBox").style.display = 'block';               
                var bal = document.getElementById("baldepamtTextBox").value;// bal of intital dep(if <10)

                var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(intitalbal));

                document.getElementById("balamtpayableTextBox").value = intitalbal1;
                var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;
                var totalval = "0";
                document.getElementById("ftradeinvalueTextBox").value = totalval;
                document.getElementById("ftotalvalueTextBox").value = totalval;

            }
            else
            {
                document.getElementById("lblbaladepamt").style.display = 'none';
                document.getElementById("baldepamtTextBox").style.display = 'none';
                document.getElementById("lblbaladepamtdate").style.display = 'none';
                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(intitalbal));

                document.getElementById("balamtpayableTextBox").value = intitalbal1;
                var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;
                var totalval = "0";
                document.getElementById("ftradeinvalueTextBox").value = totalval;
                document.getElementById("ftotalvalueTextBox").value = totalval;
            }
            
            EMICalculation_fractional();
        }
       else if (contract_type == "Trade-In-Fractionals") {
           var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
//alert("totalpurchase"+totalpurchase);
           var depositamt = document.getElementById("intialdeppercentTextBox").value;
         //  alert("depositamt:"+depositamt);
           var intitalbal = document.getElementById("balinitialdepamtTextBox").value;
         //  alert("intitalbal1:"+intitalbal);
           var intitaldepbal = document.getElementById("baldepamtTextBox").value;
          // alert("intitaldepbal:" + intitaldepbal);

           var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
          // alert("percent:"+percent);
            if (percent < 10) {
                document.getElementById("lblbaladepamt").style.display = 'block';
                document.getElementById("baldepamtTextBox").style.display = 'block';
                document.getElementById("lblbaladepamtdate").style.display = 'block';
                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                var bal = document.getElementById("baldepamtTextBox").value;// bal of intital dep(if <10)

                var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal) + parseInt(intitalbal));

                document.getElementById("balamtpayableTextBox").value = intitalbal1;
            
                var oldloanamt = "";
                var loan1;
                if (ocontract_type == "Weeks") {
                    
                    oldloanamt = document.getElementById("foldloanamountTextBox").value;
                    if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN")
                    {
                        loan1 = "0";
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                    }
                    else
                    {
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                    }
                 
                   
                    
                    document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;
                }
                else if (ocontract_type == "Fractionals") {

                    oldloanamt = document.getElementById("ffoldloanamountTextBox").value;
                    if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN") {
                        loan1 = "0";
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                    }
                    else {
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                    }



                    document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;
                }
                else if (ocontract_type == "Points")
                {
                   
                    oldloanamt = document.getElementById("oldloanamountTextBox").value

                
                    if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN") {
                        loan1 = "0";
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                    }
                    else {
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                    }

                    
                    document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;
                }
              
            }
            else {
                document.getElementById("lblbaladepamt").style.display = 'none';
                document.getElementById("baldepamtTextBox").style.display = 'none';
                document.getElementById("lblbaladepamtdate").style.display = 'none';
                document.getElementById("baladepamtdateTextBox").style.display = 'none';

                var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(intitalbal));
              //  alert("intitalbal1" + intitalbal1);
                document.getElementById("balamtpayableTextBox").value = intitalbal1;
               var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
          
                var oldloanamt = "";
                if (ocontract_type == "Weeks") {
              
                    oldloanamt = document.getElementById("foldloanamountTextBox").value;
                    if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN") {
                        loan1 = "0";
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                    }
                    else {
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                    }
                    document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;
                }
                else if (ocontract_type == "Fractionals") {

                    oldloanamt = document.getElementById("ffoldloanamountTextBox").value;
                    if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN") {
                        loan1 = "0";
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                    }
                    else {
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                    }



                    document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;
                }
                else if (ocontract_type == "Points") {
                    if (oldloanamt == "0" || oldloanamt == "" || oldloanamt == "NaN") {
                        loan1 = "0";
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(loan1);
                    }
                    else {
                        var totalbalpayable = (parseInt(totalpurchase) - parseInt(depositamt)) + parseInt(oldloanamt);
                    }
                    document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;
                }

              
            }
           
            EMICalculation_fractional();
        }
        else
        {
           
            //old code
           /* var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
            var depositamt = document.getElementById("intialdeppercentTextBox").value;
            var intitalbal = document.getElementById("balinitialdepamtTextBox").value;           
            var intitaltotal = parseInt(depositamt) + parseInt(intitalbal);
            var totalbal = parseInt(totalpurchase) - parseInt(intitaltotal);

            document.getElementById("balamtpayableTextBox").value = totalbal;
            var totalbalpayable = parseInt(totalbal) + parseInt(intitalbal);
            document.getElementById("balanceTextBox").value = totalbalpayable;*/
          
            var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;            
            var depositamt = document.getElementById("intialdeppercentTextBox").value;//deposit amt
            var intitalbal=document.getElementById("balinitialdepamtTextBox").value; 
            //var ;
            //if (bb == "0" || bb == "NaN")
            //{
               
            //    intitalbal = "0";
            //}
            //else
            //{
            //    intitalbal = document.getElementById("balinitialdepamtTextBox").value;
            //}
            var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
            if (percent < 10)
            {
                document.getElementById("lblbaladepamt").style.display = 'block';
                document.getElementById("baldepamtTextBox").style.display = 'block';
                document.getElementById("lblbaladepamtdate").style.display = 'block';
                document.getElementById("baladepamtdateTextBox").style.display = 'block';
                var bal = document.getElementById("baldepamtTextBox").value;// bal of intital dep(if <10)
                
                var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal)+parseInt(intitalbal));
                 
                document.getElementById("balamtpayableTextBox").value = intitalbal1;
                var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                document.getElementById("balanceTextBox").value = totalbalpayable; 
            }
            else
            {
                document.getElementById("lblbaladepamt").style.display = 'none';
                document.getElementById("baldepamtTextBox").style.display = 'none';
                document.getElementById("lblbaladepamtdate").style.display = 'none';
                document.getElementById("baladepamtdateTextBox").style.display = 'none';
                var intitalbal1 = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(intitalbal));
             
                document.getElementById("balamtpayableTextBox").value = intitalbal1;
                var totalbalpayable = parseInt(totalpurchase) - parseInt(depositamt);
                document.getElementById("balanceTextBox").value = totalbalpayable;
            }
            EMICalculation();
        }
       
        DisplayInstallmentAmt();
       

    }

    function AmountBreakupCalculation() {
        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
        //get venue name
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;
        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venuegroup = vg.options[vg.selectedIndex].text;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        var nl = document.getElementById("PrimarynationalityDropDownList");
        var nationality = nl.options[nl.selectedIndex].text;
        if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals") {
            if (nationality == "Indian"||nationality=="INDIAN" || nationality == "OCI"||nationality == "PIO") {
                if (checkvalue == "Finance") {
                    if (currency == "INR") {
                      //  alert("amountbreakup fucntion");
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("fractionaldepositTextBox").value = depositamt;
                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                        var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        

                        document.getElementById("balinitialdepamtTextBox").value = "0";
                        document.getElementById("balamtpayableTextBox").value = intitalbal;
                    //    alert("amountbreakup fucntion:"+intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';

                        document.getElementById("balamtpayableTextBox").value = intitalbal;
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();

                    }
                    else if (currency == "USD") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("fractionaldepositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                        var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);

                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                        document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();

                    }
                }
                else if (checkvalue == "Non Finance") {
                    if (currency == "INR") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("fractionaldepositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                        var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);

                        document.getElementById("balinitialdepamtTextBox").value = "0";
                        document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'none';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();
                    }
                    else if (currency == "USD") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("fractionaldepositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                        var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);

                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                        document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'none';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();

                    }

                }
            }
            else {
                if (checkvalue == "Finance") {
                    if (currency == "INR") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("fractionaldepositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                        var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);

                        document.getElementById("balinitialdepamtTextBox").value = "0"; intitalbal;
                        document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();
                    }
                    else if (currency == "USD") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("fractionaldepositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                        var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);

                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                        document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();

                    }
                }
                else if (checkvalue == "Non Finance") {
                    if (currency == "INR") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("fractionaldepositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                        var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);

                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                        document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'none';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();
                    }
                    else if (currency == "USD") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("fractionaldepositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);

                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                        document.getElementById("balamtpayableTextBox").value = intitalbal;


                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'none';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();

                    }

                }
            }
        }//END of contract type 
        else {
            if (nationality == "Indian" || nationality == "INDIAN" || nationality == "OCI" || nationality == "PIO") {
                if (checkvalue == "Finance") {
                    if (currency == "INR") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = depositamt;
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        

                        var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                     //   alert(percent);
                        if (percent < 10)
                        {
                            document.getElementById("lblbaladepamt").style.display = 'block';
                            document.getElementById("baldepamtTextBox").style.display = 'block';
                            document.getElementById("lblbaladepamtdate").style.display = 'block';
                            document.getElementById("baladepamtdateTextBox").style.display = 'block';
                            var bal = document.getElementById("baldepamtTextBox").value;
                        //    alert(bal);
                            var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                            //alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }
                        else
                        {

                            document.getElementById("lblbaladepamt").style.display = 'none';
                            document.getElementById("baldepamtTextBox").style.display = 'none';
                            document.getElementById("lblbaladepamtdate").style.display = 'none';
                            document.getElementById("baladepamtdateTextBox").style.display = 'none';
                            var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                          //  alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }

                        
                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                     
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                       // InitialBalCalculation();

                    }
                    else if (currency == "USD") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                        //var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                        //   alert(percent);
                        if (percent < 10) {
                            document.getElementById("lblbaladepamt").style.display = 'block';
                            document.getElementById("baldepamtTextBox").style.display = 'block';
                            document.getElementById("lblbaladepamtdate").style.display = 'block';
                            document.getElementById("baladepamtdateTextBox").style.display = 'block';
                            var bal = document.getElementById("baldepamtTextBox").value;
                            //    alert(bal);
                            var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                            //alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }
                        else {
                            document.getElementById("lblbaladepamt").style.display = 'none';
                            document.getElementById("baldepamtTextBox").style.display = 'none';
                            document.getElementById("lblbaladepamtdate").style.display = 'none';
                            document.getElementById("baladepamtdateTextBox").style.display = 'none';
                            var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                            //  alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }


                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                       // document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();

                    }
                }
                else if (checkvalue == "Non Finance") {
                    if (currency == "INR") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                        //   var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                        //   alert(percent);
                        if (percent < 10) {
                            document.getElementById("lblbaladepamt").style.display = 'block';
                            document.getElementById("baldepamtTextBox").style.display = 'block';
                            document.getElementById("lblbaladepamtdate").style.display = 'block';
                            document.getElementById("baladepamtdateTextBox").style.display = 'block';
                            var bal = document.getElementById("baldepamtTextBox").value;
                            //    alert(bal);
                            var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                            //alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }
                        else
                        {
                          //  alert("nf");
                            document.getElementById("lblbaladepamt").style.display = 'none';
                            document.getElementById("baldepamtTextBox").style.display = 'none';
                            document.getElementById("lblbaladepamtdate").style.display = 'none';
                            document.getElementById("baladepamtdateTextBox").style.display = 'none';
                            var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                         //   alert(intitalbal);
                            //  alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }


                        document.getElementById("balinitialdepamtTextBox").value = "0";//intitalbal;
                      //  document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'none';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();
                    }
                    else if (currency == "USD") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                       // var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                        //   alert(percent);
                        if (percent < 10) {
                            document.getElementById("lblbaladepamt").style.display = 'block';
                            document.getElementById("baldepamtTextBox").style.display = 'block';
                            document.getElementById("lblbaladepamtdate").style.display = 'block';
                            document.getElementById("baladepamtdateTextBox").style.display = 'block';
                            var bal = document.getElementById("baldepamtTextBox").value;
                            //    alert(bal);
                            var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                            //alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }
                        else {
                            document.getElementById("lblbaladepamt").style.display = 'none';
                            document.getElementById("baldepamtTextBox").style.display = 'none';
                            document.getElementById("lblbaladepamtdate").style.display = 'none';
                            document.getElementById("baladepamtdateTextBox").style.display = 'none';
                            var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                            //  alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }

                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                      //  document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'none';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();

                    }

                }
            }
            else {
                if (checkvalue == "Finance") {
                    if (currency == "INR") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                     //   var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                        //   alert(percent);
                        if (percent < 10) {
                            document.getElementById("lblbaladepamt").style.display = 'block';
                            document.getElementById("baldepamtTextBox").style.display = 'block';
                            document.getElementById("lblbaladepamtdate").style.display = 'block';
                            document.getElementById("baladepamtdateTextBox").style.display = 'block';
                            var bal = document.getElementById("baldepamtTextBox").value;
                            //    alert(bal);
                            var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                            //alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }
                        else {
                            document.getElementById("lblbaladepamt").style.display = 'none';
                            document.getElementById("baldepamtTextBox").style.display = 'none';
                            document.getElementById("lblbaladepamtdate").style.display = 'none';
                            document.getElementById("baladepamtdateTextBox").style.display = 'none';
                            var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                            //  alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }

                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                       // document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();
                    }
                    else if (currency == "USD") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                       // var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                        //   alert(percent);
                        if (percent < 10) {
                            document.getElementById("lblbaladepamt").style.display = 'block';
                            document.getElementById("baldepamtTextBox").style.display = 'block';
                            document.getElementById("lblbaladepamtdate").style.display = 'block';
                            document.getElementById("baladepamtdateTextBox").style.display = 'block';
                            var bal = document.getElementById("baldepamtTextBox").value;
                            //    alert(bal);
                            var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                            //alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }
                        else {
                            document.getElementById("lblbaladepamt").style.display = 'none';
                            document.getElementById("baldepamtTextBox").style.display = 'none';
                            document.getElementById("lblbaladepamtdate").style.display = 'none';
                            document.getElementById("baladepamtdateTextBox").style.display = 'none';
                            var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                            //  alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }

                        document.getElementById("balinitialdepamtTextBox").value = "0";//intitalbal;
                       // document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';

                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();

                    }
                }
                else if (checkvalue == "Non Finance") {
                    if (currency == "INR") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                        // alert(depositamt);

                       // var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                        //   alert(percent);
                        if (percent < 10) {
                            document.getElementById("lblbaladepamt").style.display = 'block';
                            document.getElementById("baldepamtTextBox").style.display = 'block';
                            document.getElementById("lblbaladepamtdate").style.display = 'block';
                            document.getElementById("baladepamtdateTextBox").style.display = 'block';
                            var bal = document.getElementById("baldepamtTextBox").value;
                            //    alert(bal);
                            var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                            //alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }
                        else {
                            document.getElementById("lblbaladepamt").style.display = 'none';
                            document.getElementById("baldepamtTextBox").style.display = 'none';
                            document.getElementById("lblbaladepamtdate").style.display = 'none';
                            document.getElementById("baladepamtdateTextBox").style.display = 'none';
                            var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                            //  alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }

                        document.getElementById("balinitialdepamtTextBox").value = "0";//intitalbal;
                      //  document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'none';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();
                    }
                    else if (currency == "USD") {
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                        document.getElementById("initaldepamtTextBox").style.display = 'none';
                        document.getElementById("lblinitaldepamt").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        //enter initial deposit amt in respective dep textbox
                        var depositamt = document.getElementById("intialdeppercentTextBox").value;
                        document.getElementById("depositTextBox").value = depositamt;

                        document.getElementById("firstdepamtTextBox").value = depositamt;

                       // var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        var percent = parseFloat((parseInt(depositamt) / parseInt(totalpurchase)) * 100);
                        //   alert(percent);
                        if (percent < 10) {
                            document.getElementById("lblbaladepamt").style.display = 'block';
                            document.getElementById("baldepamtTextBox").style.display = 'block';
                            document.getElementById("lblbaladepamtdate").style.display = 'block';
                            document.getElementById("baladepamtdateTextBox").style.display = 'block';
                            var bal = document.getElementById("baldepamtTextBox").value;
                            //    alert(bal);
                            var intitalbal = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(bal));
                            //alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }
                        else {
                            document.getElementById("lblbaladepamt").style.display = 'none';
                            document.getElementById("baldepamtTextBox").style.display = 'none';
                            document.getElementById("lblbaladepamtdate").style.display = 'none';
                            document.getElementById("baladepamtdateTextBox").style.display = 'none';
                            var intitalbal = parseInt(totalpurchase) - parseInt(depositamt);
                            //  alert(intitalbal);
                            document.getElementById("balamtpayableTextBox").value = intitalbal;
                        }

                        document.getElementById("balinitialdepamtTextBox").value = "0";// intitalbal;
                       // document.getElementById("balamtpayableTextBox").value = intitalbal;
                        //  alert(intitalbal);

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'none';
                        document.getElementById("lblfirstdepamt").style.display = 'none';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'none';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'none';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        InitialBalCalculation();

                    }

                }
            }

        }

    }

    
    function PercentCalculation()
    {
        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
        //get venue name
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;
        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venuegroup = vg.options[vg.selectedIndex].text;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        var nl = document.getElementById("PrimarynationalityDropDownList");
        var nationality = nl.options[nl.selectedIndex].text;
        if (nationality == "Indian" || nationality == "INDIAN" || nationality == "OCI" || nationality == "PIO")
        {
            if (checkvalue == "Finance")
            {
                if (currency == "INR")
                {
                    var totalpercent = 25;

                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    //calculate inital dep based on intial percent
                 var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    //display deposit amt in respective dep textbox
                    document.getElementById("initaldepamtTextBox").value = depositamt;

                    document.getElementById("depositTextBox").value = depositamt; 

                    //CHECK IF PERCENT IS BELOW 10%
                    if (deppercent < 10) {
                        
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.color = 'Red';
                        document.getElementById("baldepamtTextBox").style.fontWeight = 'bold';
                        //get remaining percent of deppercent
                        var balpercent = 10 - parseInt(deppercent);
                        //get the remaining bal based on the balpercent %
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        //display value in textbox
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        //to take loan need 25% dep

                        //get bal percent on inital dep
                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent) + parseInt(balpercent));
                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        //  alert(remgbal);

                        document.getElementById("balinitialdepamtTextBox").value = remgbal;
                        var totaldepositpayable = (parseInt(depositamt) + parseInt(baldepamt));
                        var totalbalpayable = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(baldepamt) + parseInt(remgbal));
                        document.getElementById("balanceTextBox").value = totalbalpayable;

                        document.getElementById("balamtpayableTextBox").value = totalbalpayable;
                        // document.getElementById("balanceTextBox").value = remgbal;
                        var final = parseInt(totalbalpayable) + parseInt(remgbal);
                        document.getElementById("balanceTextBox").value = final;

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("firstdepamtTextBox").value = totaldepositpayable;
                        document.getElementById("firstdepamtTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                    }
                    else if (deppercent >= 10 && deppercent <= 25) //(deppercent>=10)
                    {

                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent));

                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        document.getElementById("balinitialdepamtTextBox").value = remgbal;

                        //get total bal whoch is loan
                        var totalbal = parseInt(totalpurchase) - (parseInt(remgbal) + parseInt(depositamt));

                        //  document.getElementById("balanceTextBox").value = remgbal;

                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        var final = parseInt(totalbal) + parseInt(remgbal);
                        document.getElementById("balanceTextBox").value = final;
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                     
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        
                    }
                    else if (deppercent > 25 && deppercent <= 100) {
                        // alert(depositamt);

                        document.getElementById("lblbalinitialdep").style.display = 'NONE';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'NONE';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        var totalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("balanceTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';


                    }
                    EMICalculation();

                }
                else if (currency == "USD") {
                    var totalpercent = 25;
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    //calculate inital dep based on intial percent
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    //display deposit amt in respective dep textbox
                    document.getElementById("initaldepamtTextBox").value = depositamt;

                    document.getElementById("depositTextBox").value = depositamt;

                    //CHECK IF PERCENT IS BELOW 10%
                    if (deppercent < 10) {

                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.color = 'Red';
                        document.getElementById("baldepamtTextBox").style.fontWeight = 'bold';
                        //get remaining percent of deppercent
                        var balpercent = 10 - parseInt(deppercent);
                        //get the remaining bal based on the balpercent %
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        //display value in textbox
                        document.getElementById("baldepamtTextBox").value = baldepamt;

                        //get bal percent on inital dep
                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent) + parseInt(balpercent));
                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        //  alert(remgbal);

                        document.getElementById("balinitialdepamtTextBox").value = remgbal;
                        var totaldepositpayable = (parseInt(depositamt) + parseInt(baldepamt));
                        var totalbalpayable = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(baldepamt) + parseInt(remgbal));
                        document.getElementById("balanceTextBox").value = totalbalpayable;

                        document.getElementById("balamtpayableTextBox").value = totalbalpayable;
                        // document.getElementById("balanceTextBox").value = remgbal;
                        var final = parseInt(totalbalpayable) + parseInt(remgbal);
                        document.getElementById("balanceTextBox").value = final;

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("firstdepamtTextBox").value = totaldepositpayable;
                        document.getElementById("firstdepamtTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                    }
                    else if (deppercent >= 10 && deppercent <= 25) //(deppercent>=10)
                    {

                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent));

                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        document.getElementById("balinitialdepamtTextBox").value = remgbal;

                        //get total bal whoch is loan
                        var totalbal = parseInt(totalpurchase) - (parseInt(remgbal) + parseInt(depositamt));

                        //  document.getElementById("balanceTextBox").value = remgbal;

                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        var final = parseInt(totalbal) + parseInt(remgbal);
                        document.getElementById("balanceTextBox").value = final;
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';

                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }
                    else if (deppercent > 25 && deppercent <= 100) {
                        // alert(depositamt);

                        document.getElementById("lblbalinitialdep").style.display = 'NONE';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'NONE';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        var totalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("balanceTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';

                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }

                }

            }
            else if (checkvalue == "Non Finance") {
                if (currency == "INR") {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("depositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("balanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10) {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("balanceTextBox") = balpayable;
                    }
                    else {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("balanceTextBox") = balpayable;
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                      
                    }

                }
                else if (currency == "USD") {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("depositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("balanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10) {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("balanceTextBox") = balpayable;
                    }
                    else {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("balanceTextBox") = balpayable;
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }

                }

            }

        }
        else

        {
            if (checkvalue == "Finance") {
                if (currency == "INR") {
                    var totalpercent = 25;

                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    //calculate inital dep based on intial percent
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    //display deposit amt in respective dep textbox
                    document.getElementById("initaldepamtTextBox").value = depositamt;

                    document.getElementById("depositTextBox").value = depositamt;

                    //CHECK IF PERCENT IS BELOW 10%
                    if (deppercent < 10) {

                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.color = 'Red';
                        document.getElementById("baldepamtTextBox").style.fontWeight = 'bold';
                        //get remaining percent of deppercent
                        var balpercent = 10 - parseInt(deppercent);
                        //get the remaining bal based on the balpercent %
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        //display value in textbox
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        //to take loan need 25% dep

                        //get bal percent on inital dep
                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent) + parseInt(balpercent));
                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        //  alert(remgbal);

                        document.getElementById("balinitialdepamtTextBox").value = remgbal;
                        var totaldepositpayable = (parseInt(depositamt) + parseInt(baldepamt));
                        var totalbalpayable = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(baldepamt) + parseInt(remgbal));
                        document.getElementById("balanceTextBox").value = totalbalpayable;

                        document.getElementById("balamtpayableTextBox").value = totalbalpayable;
                        // document.getElementById("balanceTextBox").value = remgbal;
                        var final = parseInt(totalbalpayable) + parseInt(remgbal);
                        document.getElementById("balanceTextBox").value = final;

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("firstdepamtTextBox").value = totaldepositpayable;
                        document.getElementById("firstdepamtTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                    }
                    else if (deppercent >= 10 && deppercent <= 25) //(deppercent>=10)
                    {

                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent));

                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        document.getElementById("balinitialdepamtTextBox").value = remgbal;

                        //get total bal whoch is loan
                        var totalbal = parseInt(totalpurchase) - (parseInt(remgbal) + parseInt(depositamt));

                        //  document.getElementById("balanceTextBox").value = remgbal;

                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        var final = parseInt(totalbal) + parseInt(remgbal);
                        document.getElementById("balanceTextBox").value = final;
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';

                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';


                    }
                    else if (deppercent > 25 && deppercent <= 100) {
                        // alert(depositamt);

                        document.getElementById("lblbalinitialdep").style.display = 'NONE';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'NONE';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        var totalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("balanceTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';


                    }

                }
                else if (currency == "USD") {
                    var totalpercent = 25;
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    //calculate inital dep based on intial percent
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    //display deposit amt in respective dep textbox
                    document.getElementById("initaldepamtTextBox").value = depositamt;

                    document.getElementById("depositTextBox").value = depositamt;

                    //CHECK IF PERCENT IS BELOW 10%
                    if (deppercent < 10) {

                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.color = 'Red';
                        document.getElementById("baldepamtTextBox").style.fontWeight = 'bold';
                        //get remaining percent of deppercent
                        var balpercent = 10 - parseInt(deppercent);
                        //get the remaining bal based on the balpercent %
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        //display value in textbox
                        document.getElementById("baldepamtTextBox").value = baldepamt;

                        //get bal percent on inital dep
                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent) + parseInt(balpercent));
                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        //  alert(remgbal);

                        document.getElementById("balinitialdepamtTextBox").value = remgbal;
                        var totaldepositpayable = (parseInt(depositamt) + parseInt(baldepamt));
                        var totalbalpayable = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(baldepamt) + parseInt(remgbal));
                        document.getElementById("balanceTextBox").value = totalbalpayable;

                        document.getElementById("balamtpayableTextBox").value = totalbalpayable;
                        // document.getElementById("balanceTextBox").value = remgbal;
                        var final = parseInt(totalbalpayable) + parseInt(remgbal);
                        document.getElementById("balanceTextBox").value = final;

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("firstdepamtTextBox").value = totaldepositpayable;
                        document.getElementById("firstdepamtTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                    }
                    else if (deppercent >= 10 && deppercent <= 25) //(deppercent>=10)
                    {

                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent));

                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        document.getElementById("balinitialdepamtTextBox").value = remgbal;

                        //get total bal whoch is loan
                        var totalbal = parseInt(totalpurchase) - (parseInt(remgbal) + parseInt(depositamt));

                        //  document.getElementById("balanceTextBox").value = remgbal;

                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        var final = parseInt(totalbal) + parseInt(remgbal);
                        document.getElementById("balanceTextBox").value = final;
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';

                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';

                    }
                    else if (deppercent > 25 && deppercent <= 100) {
                        // alert(depositamt);

                        document.getElementById("lblbalinitialdep").style.display = 'NONE';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'NONE';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        var totalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("balanceTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';

                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';

                    }

                }

            }
            else if (checkvalue == "Non Finance") {
                if (currency == "INR") {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("depositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("balanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10) {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("balanceTextBox") = balpayable;
                    }
                    else {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("balanceTextBox") = balpayable;
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }

                }
                else if (currency == "USD") {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("depositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("balanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10) {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("balanceTextBox") = balpayable;
                    }
                    else {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("balanceTextBox") = balpayable;
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }

                }

            }

        }

      


    }
    //
    function PercentCalculationFractional() {
        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
        //get venue name
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;
        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venuegroup = vg.options[vg.selectedIndex].text;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        var nl = document.getElementById("PrimarynationalityDropDownList");
        var nationality = nl.options[nl.selectedIndex].text;
        if (nationality == "Indian" || nationality == "INDIAN" || nationality == "OCI" || nationality == "PIO") {



            if (checkvalue == "Finance") {
                if (currency == "INR") {
                    var totalpercent = 25;

                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    //calculate inital dep based on intial percent
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    //display deposit amt in respective dep textbox
                    document.getElementById("initaldepamtTextBox").value = depositamt;

                    document.getElementById("fractionaldepositTextBox").value = depositamt;

                    //CHECK IF PERCENT IS BELOW 10%
                    if (deppercent < 10) {

                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.color = 'Red';
                        document.getElementById("baldepamtTextBox").style.fontWeight = 'bold';
                        //get remaining percent of deppercent
                        var balpercent = 10 - parseInt(deppercent);
                        //get the remaining bal based on the balpercent %
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        //display value in textbox
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        //to take loan need 25% dep

                        //get bal percent on inital dep
                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent) + parseInt(balpercent));
                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        //  alert(remgbal);

                        document.getElementById("balinitialdepamtTextBox").value = remgbal;
                        var totaldepositpayable = (parseInt(depositamt) + parseInt(baldepamt));
                        var totalbalpayable = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(baldepamt) + parseInt(remgbal));
                        document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;

                        document.getElementById("balamtpayableTextBox").value = totalbalpayable;
                        // document.getElementById("balanceTextBox").value = remgbal;
                        var final = parseInt(totalbalpayable) + parseInt(remgbal);
                        document.getElementById("fractionalbalanceTextBox").value = final;

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';


                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("firstdepamtTextBox").value = totaldepositpayable;
                        document.getElementById("firstdepamtTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                    }
                    else if (deppercent >= 10 && deppercent <= 25) //(deppercent>=10)
                    {

                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent));

                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        document.getElementById("balinitialdepamtTextBox").value = remgbal;

                        //get total bal whoch is loan
                        var totalbal = parseInt(totalpurchase) - (parseInt(remgbal) + parseInt(depositamt));

                        //  document.getElementById("balanceTextBox").value = remgbal;

                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        var final = parseInt(totalbal) + parseInt(remgbal);
                        document.getElementById("fractionalbalanceTextBox").value = final;
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';

                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';

                    }
                    else if (deppercent > 25 && deppercent <= 100) {
                        // alert(depositamt);

                        document.getElementById("lblbalinitialdep").style.display = 'NONE';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'NONE';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        var totalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("fractionalbalanceTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';


                    }

                }
                else if (currency == "USD") {
                    var totalpercent = 25;
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    //calculate inital dep based on intial percent
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    //display deposit amt in respective dep textbox
                    document.getElementById("initaldepamtTextBox").value = depositamt;

                    document.getElementById("fractionaldepositTextBox").value = depositamt;

                    //CHECK IF PERCENT IS BELOW 10%
                    if (deppercent < 10) {

                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.color = 'Red';
                        document.getElementById("baldepamtTextBox").style.fontWeight = 'bold';
                        //get remaining percent of deppercent
                        var balpercent = 10 - parseInt(deppercent);
                        //get the remaining bal based on the balpercent %
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        //display value in textbox
                        document.getElementById("baldepamtTextBox").value = baldepamt;

                        //get bal percent on inital dep
                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent) + parseInt(balpercent));
                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        //  alert(remgbal);

                        document.getElementById("balinitialdepamtTextBox").value = remgbal;
                        var totaldepositpayable = (parseInt(depositamt) + parseInt(baldepamt));
                        var totalbalpayable = parseInt(totalpurchase) - (parseInt(depositamt) + parseInt(baldepamt) + parseInt(remgbal));
                        document.getElementById("fractionalbalanceTextBox").value = totalbalpayable;

                        document.getElementById("balamtpayableTextBox").value = totalbalpayable;
                        // document.getElementById("balanceTextBox").value = remgbal;
                        var final = parseInt(totalbalpayable) + parseInt(remgbal);
                        document.getElementById("fractionalbalanceTextBox").value = final;

                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("firstdepamtTextBox").value = totaldepositpayable;
                        document.getElementById("firstdepamtTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                    }
                    else if (deppercent >= 10 && deppercent <= 25) //(deppercent>=10)
                    {

                        var balrempercent = parseInt(totalpercent) - (parseInt(deppercent));

                        //remaing bal of initial dep of remaining 15%
                        var remgbal = (parseInt(totalpurchase) * parseInt(balrempercent)) / 100;
                        document.getElementById("balinitialdepamtTextBox").value = remgbal;

                        //get total bal whoch is loan
                        var totalbal = parseInt(totalpurchase) - (parseInt(remgbal) + parseInt(depositamt));

                        //  document.getElementById("balanceTextBox").value = remgbal;

                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        var final = parseInt(totalbal) + parseInt(remgbal);
                        document.getElementById("fractionalbalanceTextBox").value = final;
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("firstdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblfirstdepamt").style.display = 'BLOCK';
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';

                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';
                        document.getElementById("lblbalinitialdep").style.display = 'BLOCK';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';

                    }
                    else if (deppercent > 25 && deppercent <= 100) {
                        // alert(depositamt);

                        document.getElementById("lblbalinitialdep").style.display = 'NONE';
                        document.getElementById("balinitialdepamtTextBox").style.display = 'NONE';
                        document.getElementById("firstdepamtTextBox").value = depositamt;
                        var totalbal = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("firstdepamtTextBox").style.color = 'Red';
                        document.getElementById("firstdepamtTextBox").style.fontWeight = 'bold';


                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("fractionalbalanceTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").value = totalbal;
                        document.getElementById("balamtpayableTextBox").style.fontWeight = 'bold';
                        document.getElementById("balamtpayableTextBox").style.textDecoration = 'underline';
                        document.getElementById("balamtpayableTextBox").style.color = 'Green';
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';


                    }

                }

            }
            else if (checkvalue == "Non Finance") {
                if (currency == "INR") {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("fractionaldepositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("fractionalbalanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10) {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                    }
                    else {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }

                }
                else if (currency == "USD")
                {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("fractionaldepositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("fractionalbalanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10)
                    {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                    }
                    else
                    {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }

                }

            }
        }
            //other nationality besides India
        else
        {

            if (checkvalue == "Finance")
            {
                if (currency == "INR") {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("fractionaldepositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("fractionalbalanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10)
                    {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                    }
                    else
                    {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;

                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }

                }
                else if (currency == "USD") {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("fractionaldepositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("fractionalbalanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10) {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                    }
                    else {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }

                }

            

            }
            else if (checkvalue == "Non Finance")
            {
                if (currency == "INR") {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("fractionaldepositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("fractionalbalanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10) {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                    }
                    else {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }

                }
                else if (currency == "USD") {
                    var deppercent = document.getElementById("intialdeppercentTextBox").value;
                    document.getElementById("initaldepamtTextBox").style.display = 'BLOCK';
                    document.getElementById("lblinitaldepamt").style.display = 'BLOCK';
                    var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                    var depositamt = (parseInt(totalpurchase) * parseInt(deppercent)) / 100;
                    document.getElementById("initaldepamtTextBox").value = depositamt;
                    document.getElementById("fractionaldepositTextBox").value = depositamt;
                    var bal = parseInt(totalpurchase) - parseInt(depositamt);
                    document.getElementById("fractionalbalanceTextBox").value = bal;

                    document.getElementById("lblfinancemethod").style.display = 'NONE';
                    document.getElementById("financemethodDropDownList").style.display = 'NONE';
                    document.getElementById("lblfinanceno").style.display = 'NONE';
                    document.getElementById("FinancenoTextBox").style.display = 'NONE';

                    if (deppercent < 10) {
                        document.getElementById("baldepamtTextBox").style.display = 'BLOCK';
                        document.getElementById("lblbaladepamt").style.display = 'BLOCK';
                        var balpercent = 10 - parseInt(deppercent);
                        var baldepamt = (parseInt(totalpurchase) * parseInt(balpercent)) / 100;
                        document.getElementById("baldepamtTextBox").value = baldepamt;
                        var totalinitialdep = parseInt(depositamt) + parseInt(baldepamt);
                        var balpayable = parseInt(totalpurchase) - parseInt(totalinitialdep);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;
                    }
                    else {
                        document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                        document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                        document.getElementById("baldepamtTextBox").style.display = 'NONE';
                        document.getElementById("lblbaladepamt").style.display = 'NONE';

                        var balpayable = parseInt(totalpurchase) - parseInt(depositamt);
                        document.getElementById("balamtpayableTextBox").value = balpayable;
                        document.getElementById("fractionalbalanceTextBox") = balpayable;

                        document.getElementById("baldepamtTextBox").style.display = 'none';
                        document.getElementById("lblbaladepamt").style.display = 'none';
                    }//else

                }//currency

            }//nationlaity

        }


    }
    //
    //function for calculation -
    function InitialDepositCalculation1() {
       
        //firstdepamtTextBox ---store 1st part of inintial dep percent
        //    //baldepamtTextBox ---store bal part of inintial dep percent
        //    //balinitialdepamtTextBox -- store bal of initial dep
        //    //balamtpayableTextBox--store bal amt from total purchase

       // document.getElementById("PayMethodDropDownList").value = "";
        document.getElementById("firstdepamtTextBox").value = "";
        document.getElementById("balamtpayableTextBox").value = "";
       // document.getElementById("NoinstallmentTextBox").value = "";
      //  document.getElementById("installmentamtTextBox").value = "";
        document.getElementById("depositTextBox").value = "";
        document.getElementById("balanceTextBox").value = "";
        document.getElementById("baldepamtTextBox").value = "";
        document.getElementById("balamtpayableTextBox").value = "";
        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
        //get venue name
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;
        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venuegroup = vg.options[vg.selectedIndex].text;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var nl = document.getElementById("PrimarynationalityDropDownList");
        var nationality = nl.options[nl.selectedIndex].text;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        // alert(checkvalue);

        if (contract_type == "Fractional")
        {
            if (venuegroup == "Inhouse"||venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY")
            {
                if(mktg=="OWNER")
                {
                    //   PercentCalculationFractional();
                    AmountBreakupCalculation();
                    InitialBalCalculation();
                }
                else
                {
                    //   PercentCalculationFractional();
                    AmountBreakupCalculation();
                    InitialBalCalculation();
                }
            }
            else
            {       
                // PercentCalculationFractional();
                AmountBreakupCalculation();
                InitialBalCalculation();
            }
        }
        else if (contract_type == "Points")
        {
            
            AmountBreakupCalculation();
            InitialBalCalculation();


        }
        else if (contract_type == "Trade-In-Points")
        {
            // PercentCalculation();
            AmountBreakupCalculation();
            InitialBalCalculation();

        }

        else if (contract_type == "Trade-In-Weeks")
        {
           
            //  PercentCalculation();
            AmountBreakupCalculation();
            InitialBalCalculation();
        }
        else if (contract_type == "Trade-In-Fractionals")
        {
            //  PercentCalculationFractional();
            AmountBreakupCalculation();
            InitialBalCalculation();
          
        }





    }

    
    function DisplayonPayMethod() {
        var radio = document.getElementsByName('financeradiobuttonlist');
        var method = document.getElementById("PayMethodDropDownList").value;
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        if (checkvalue == "Finance") {
            if (method == "INSTALLMENT" || method == "Installment") {
                document.getElementById("lblnoinstallment").style.display = 'BLOCK';
                document.getElementById("NoinstallmentTextBox").style.display = 'BLOCK';
                document.getElementById("lblinstallmentamt").style.display = 'BLOCK';
                document.getElementById("installmentamtTextBox").style.display = 'BLOCK';
            }
            else {
                document.getElementById("lblnoinstallment").style.display = 'NONE';
                document.getElementById("NoinstallmentTextBox").style.display = 'NONE';
                document.getElementById("lblinstallmentamt").style.display = 'NONE';
                document.getElementById("installmentamtTextBox").style.display = 'NONE';

            }
        }
        else if (checkvalue == "Non Finance") {
            if (method == "INSTALLMENT" || method == "Installment") {
                document.getElementById("lblnoinstallment").style.display = 'BLOCK';
                document.getElementById("NoinstallmentTextBox").style.display = 'BLOCK';
                document.getElementById("lblinstallmentamt").style.display = 'BLOCK';
                document.getElementById("installmentamtTextBox").style.display = 'BLOCK';
                document.getElementById("lblfirstdepamt").style.display = 'NONE';
                document.getElementById("firstdepamtTextBox").style.display = 'NONE';
                document.getElementById("lblbalamtpayable").style.display = 'BLOCK';
                document.getElementById("balamtpayableTextBox").style.display = 'BLOCK';
                var totalpurchase = document.getElementById("totalpriceInTaxTextBox").value;
                var depositpercent = document.getElementById("intialdeppercentTextBox").value;
                var depositamt = document.getElementById("initaldepamtTextBox").value;
               
            }
            else {
                document.getElementById("lblfirstdepamt").style.display = 'NONE';
                document.getElementById("firstdepamtTextBox").style.display = 'NONE';
                document.getElementById("lblbalamtpayable").style.display = 'NONE';
                document.getElementById("balamtpayableTextBox").style.display = 'NONE';
                document.getElementById("lblnoinstallment").style.display = 'NONE';
                document.getElementById("NoinstallmentTextBox").style.display = 'NONE';
                document.getElementById("lblinstallmentamt").style.display = 'NONE';
                document.getElementById("installmentamtTextBox").style.display = 'NONE';

              
            }

        }
    
        
    }
    function fractionaltradeinamt()
    {
        //alert("in");
        var ct = document.getElementById("oldcontracttypeDropDownList");
        var ocontract_type = ct.options[ct.selectedIndex].text;
        if (ocontract_type == "Weeks")
        {
            var tradein = document.getElementById("ftradeinamtTextBox").value;
            document.getElementById("ftradeinvalueTextBox").value = tradein;
            if (tradein == 0) {
                var totalvalue = "0";
                document.getElementById("ftotalvalueTextBox").value = totalvalue;

            }
            else
            {
                var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                var totalvalue = parseInt(tradein) + parseInt(totalpurchase);
                document.getElementById("ftotalvalueTextBox").value = totalvalue;
            }

        }
        else if (ocontract_type == "Fractionals") {
            var tradein = document.getElementById("fftradeinamtTextBox").value;
            document.getElementById("ftradeinvalueTextBox").value = tradein;
            if (tradein == 0) {
                var totalvalue = "0";
                document.getElementById("ftotalvalueTextBox").value = totalvalue;

            }
            else {
                var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                var totalvalue = parseInt(tradein) + parseInt(totalpurchase);
                document.getElementById("ftotalvalueTextBox").value = totalvalue;
            }

        }
        else if (ocontract_type == "Points")
        {
            //alert("points f");
            var tradein = document.getElementById("fptradeinamtTextBox").value;
            document.getElementById("ftradeinvalueTextBox").value = tradein;
            if (tradein == 0)
            {
                var totalvalue = "0";
                document.getElementById("ftotalvalueTextBox").value = totalvalue;

            }
            else {
                //alert(tradein);
                var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
                var totalvalue = parseInt(tradein) + parseInt(totalpurchase);
                document.getElementById("ftotalvalueTextBox").value = totalvalue;
            }

        }
         
       
    }
   
    function ConversionfeeWithNewPoints()
    {
        var holidayplus, emerald, total;
        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
        //get venue name
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;
        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venuegroup = vg.options[vg.selectedIndex].text;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var newpointsprice = document.getElementById("newpointsTextBox").value;
        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
        var admintotal = document.getElementById("adminfeeTextBox").value;
        var totpurchaseprice = document.getElementById("totpurchpriceTextBox").value
        var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
        document.getElementById("conversionfeeTextBox").value = convfee;

    }
    function PACalculationOwner(tot, aftotal)
    {
 
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;

        var totalpurchase = tot; 
        var total = aftotal;
     
        document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
       
        if (checkvalue == "Finance")
        {

            if (currency == "INR")
            {
                
                document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                document.getElementById("Label148").style.display = 'block';
                document.getElementById("cgstTextBox").style.display = 'block';
                document.getElementById("Label149").style.display = 'block';
                document.getElementById("sgstTextBox").style.display = 'block';
                document.getElementById("Label150").style.display = 'block';
                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';
                if (totalpurchase > "240000") {

                       var adminfees = "30000";
                   /* var adminfees;
                    var adminfees1 = "30000";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("cgstTextBox").value = cgst;


                    var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = true;
                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 240000) {

                    var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("cgstTextBox").value = cgst;


                    var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = true;

                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }
            else if (currency == "USD")
            {
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';
                if (totalpurchase > "5984") {

                     var adminfees = "748";
                  /*  var adminfees;
                    var adminfees1 = "748";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;


                    
                    document.getElementById("newpointsTextBox").style.display = 'none';                    
                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 5984)
                {

                    var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;


                    document.getElementById("newpointsTextBox").style.display = 'none';
                 

                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }

            }
        }
        else if (checkvalue == "Non Finance")
        {
            //alert("non finance");
            if (currency == "INR") {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                document.getElementById("Label148").style.display = 'block';
                document.getElementById("cgstTextBox").style.display = 'block';
                document.getElementById("Label149").style.display = 'block';
                document.getElementById("sgstTextBox").style.display = 'block';
                document.getElementById("Label150").style.display = 'block';
                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';
                if (totalpurchase > "240000") {
                    var adminfees = "30000";
                   /* var adminfees;
                    var adminfees1 = "30000";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("cgstTextBox").value = cgst;


                    var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = true;

                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 240000) {
                    var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("cgstTextBox").value = cgst;


                    var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = true;

                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }

            }
            else if (currency == "USD") {
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';
                if (totalpurchase > "5984") {

                     var adminfees = "748";
                   /* var adminfees;
                    var adminfees1 = "748";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;



                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 5984) {

                    var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;


                    document.getElementById("newpointsTextBox").style.display = 'none';


                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }
        }
    }
    //
    function PACalculationOwnerFractional(tot, atotal) {

       
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;

        var nl = document.getElementById("PrimarynationalityDropDownList");
        var nationality = nl.options[nl.selectedIndex].text;


        var totalpurchase = tot; 
        var total = atotal;
        
        document.getElementById("TotalPurchasePriceTextBox").value = totalpurchase;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        if (nationality == "INDIAN" || nationality == "Indian"  || nationality == "OCI" || nationality == "PIO") {
            if (checkvalue == "Finance") {

                if (currency == "INR") {

                   // alert(total);
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'block';
                    document.getElementById("fcgstTextBox").style.display = 'block';
                    document.getElementById("lblfsgst").style.display = 'block';
                    document.getElementById("fsgstTextBox").style.display = 'block';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                      var adminfees = "77050";
                   /* var adminfees;
                    var adminfees1 = "77050";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "18";

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fcgstTextBox").value = cgst;


                    var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var dep = document.getElementById("initaldepamtTextBox").value;  //firstdepamtTextBox
                    //alert(dep);
                    //var bal = parseInt(totalpurchase) - parseInt(dep);
                    //document.getElementById("balanceTextBox").value = bal;
                    //  var dep = document.getElementById("fractionaldepositTextBox").value;
                    document.getElementById("fractionaldepositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;




                }
                else if (currency == "USD") {
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'none';
                    document.getElementById("fcgstTextBox").style.display = 'none';
                    document.getElementById("lblfsgst").style.display = 'none';
                    document.getElementById("fsgstTextBox").style.display = 'none';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';

                       var adminfees = "1110";
                   /* var adminfees;
                    var adminfees1 = "1110";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("AdministrationFeesTextBox").value = admintotal;
                    var tax = "0";
                    var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var sgst = "0";
                    document.getElementById("fsgstTextBox").value = sgst;
                    var cgst = "0";
                    document.getElementById("fcgstTextBox").value = cgst;


                  
                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("fractionaldepositTextBox").value = dep;
                  // var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;


                }
            }
            else if (checkvalue == "Non Finance") {

                if (currency == "INR") {


                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'block';
                    document.getElementById("fcgstTextBox").style.display = 'block';
                    document.getElementById("lblfsgst").style.display = 'block';
                    document.getElementById("fsgstTextBox").style.display = 'block';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                         var adminfees = "77050";
                   /* var adminfees;
                    var adminfees1 = "77050";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "18";

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fcgstTextBox").value = cgst;


                    var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("fractionaldepositTextBox").value = dep;
                  //  var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;




                }
                else if (currency == "USD") {
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'none';
                    document.getElementById("fcgstTextBox").style.display = 'none';
                    document.getElementById("lblfsgst").style.display = 'none';
                    document.getElementById("fsgstTextBox").style.display = 'none';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                       var adminfees = "1110";
                  /*  var adminfees;
                    var adminfees1 = "1110";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "0";

                    var AdmissionFees  = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var sgst = "0";
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("fcgstTextBox").value = cgst;



                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("fractionaldepositTextBox").value = dep;
                    //var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;


                }



            }
        }
            //as of my understanding this part of fin n noon finance is same for all nationalities
        else
        {
            if (checkvalue == "Finance") {

                if (currency == "INR") {

                   // alert(total);
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'block';
                    document.getElementById("fcgstTextBox").style.display = 'block';
                    document.getElementById("lblfsgst").style.display = 'block';
                    document.getElementById("fsgstTextBox").style.display = 'block';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                   var adminfees = "77050";
                   /* var adminfees;
                    var adminfees1 = "77050";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "18";

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fcgstTextBox").value = cgst;


                    var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;

                    var dep = document.getElementById("initaldepamtTextBox").value;
                   document.getElementById("fractionaldepositTextBox").value=dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;




                }
                else if (currency == "USD") {
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'none';
                    document.getElementById("fcgstTextBox").style.display = 'none';
                    document.getElementById("lblfsgst").style.display = 'none';
                    document.getElementById("fsgstTextBox").style.display = 'none';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';

                     var adminfees = "1110";
                   /* var adminfees;
                    var adminfees1 = "1110";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("AdministrationFeesTextBox").value = admintotal;
                    var tax = "0";
                    var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var sgst = "0";
                    document.getElementById("fsgstTextBox").value = sgst;
                    var cgst = "0";
                    document.getElementById("fcgstTextBox").value = cgst;

                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("fractionaldepositTextBox").value = dep;


                    //var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;


                }
            }
            else if (checkvalue == "Non Finance") {

                if (currency == "INR") {


                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'block';
                    document.getElementById("fcgstTextBox").style.display = 'block';
                    document.getElementById("lblfsgst").style.display = 'block';
                    document.getElementById("fsgstTextBox").style.display = 'block';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                       var adminfees = "77050";
               

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "18";

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fcgstTextBox").value = cgst;


                    var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;

                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("fractionaldepositTextBox").value = dep;
                   // var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;




                }
                else if (currency == "USD") {
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'none';
                    document.getElementById("fcgstTextBox").style.display = 'none';
                    document.getElementById("lblfsgst").style.display = 'none';
                    document.getElementById("fsgstTextBox").style.display = 'none';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                    var adminfees = "1110";
                /*    var adminfees;
                    var adminfees1 = "1110";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "0";

                    var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var sgst = "0";
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("fcgstTextBox").value = cgst;


                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("fractionaldepositTextBox").value = dep;

                   // var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;


                }



            }

        }
    }
    //
    function PACalculationOwnerTradeIn_Fractional(tot, atotal) {


        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;

        var nl = document.getElementById("PrimarynationalityDropDownList");
        var nationality = nl.options[nl.selectedIndex].text;

        var cl = document.getElementById("oldcontracttypeDropDownList"); 
        var ocontracttype = cl.options[cl.selectedIndex].text;
       // alert(ocontracttype);

        var totalpurchase = tot;
        var total = atotal;

        document.getElementById("TotalPurchasePriceTextBox").value = totalpurchase;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        if (nationality == "INDIAN" || nationality == "Indian"  || nationality == "OCI" || nationality == "PIO") {
            if (checkvalue == "Finance") {

                if (currency == "INR") {

                    // alert(total);
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'block';
                    document.getElementById("fcgstTextBox").style.display = 'block';
                    document.getElementById("lblfsgst").style.display = 'block';
                    document.getElementById("fsgstTextBox").style.display = 'block';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                     var adminfees = "77050";
                  
                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "18";

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fcgstTextBox").value = cgst;


                    var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var dep = document.getElementById("intialdeppercentTextBox").value;   //initaldepamtTextBox  //firstdepamtTextBox
                   // alert(dep);
                    //var bal = parseInt(totalpurchase) - parseInt(dep);
                    //document.getElementById("balanceTextBox").value = bal;
                    //  var dep = document.getElementById("fractionaldepositTextBox").value;
                    document.getElementById("fractionaldepositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
          
                    document.getElementById("fractionalbalanceTextBox").value = bal;

                   


                }
                else if (currency == "USD") {
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'none';
                    document.getElementById("fcgstTextBox").style.display = 'none';
                    document.getElementById("lblfsgst").style.display = 'none';
                    document.getElementById("fsgstTextBox").style.display = 'none';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';

                     var adminfees = "1110";
                
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("AdministrationFeesTextBox").value = admintotal;
                    var tax = "0";
                    var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var sgst = "0";
                    document.getElementById("fsgstTextBox").value = sgst;
                    var cgst = "0";
                    document.getElementById("fcgstTextBox").value = cgst;



                    var dep = document.getElementById("intialdeppercentTextBox").value;//initaldepamtTextBox
                    document.getElementById("fractionaldepositTextBox").value = dep;
                    // var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                   
                     document.getElementById("fractionalbalanceTextBox").value = bal;

                   


                }
            }
            else if (checkvalue == "Non Finance") {

                if (currency == "INR") {


                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'block';
                    document.getElementById("fcgstTextBox").style.display = 'block';
                    document.getElementById("lblfsgst").style.display = 'block';
                    document.getElementById("fsgstTextBox").style.display = 'block';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                     var adminfees = "77050";
                  

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "18";

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fcgstTextBox").value = cgst;


                    var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var dep = document.getElementById("intialdeppercentTextBox").value;//initaldepamtTextBox
                    document.getElementById("fractionaldepositTextBox").value = dep;
                    //  var dep = document.getElementById("fractionaldepositTextBox").value;
                    alert("Dep:"+dep);
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    alert("Bal:"+bal);
                    document.getElementById("fractionalbalanceTextBox").value = bal;
                   



                }
                else if (currency == "USD") {
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'none';
                    document.getElementById("fcgstTextBox").style.display = 'none';
                    document.getElementById("lblfsgst").style.display = 'none';
                    document.getElementById("fsgstTextBox").style.display = 'none';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                        var adminfees = "1110";
             

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "0";

                    var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var sgst = "0";
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("fcgstTextBox").value = cgst;



                    var dep = document.getElementById("intialdeppercentTextBox").value;//initaldepamtTextBox
                    document.getElementById("fractionaldepositTextBox").value = dep;
                    //var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;
                  
                    
 

                }



            }
        }
            //as of my understanding this part of fin n noon finance is same for all nationalities
        else {
            if (checkvalue == "Finance") {

                if (currency == "INR") {

                    // alert(total);
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'block';
                    document.getElementById("fcgstTextBox").style.display = 'block';
                    document.getElementById("lblfsgst").style.display = 'block';
                    document.getElementById("fsgstTextBox").style.display = 'block';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                       var adminfees = "77050";
                

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "18";

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fcgstTextBox").value = cgst;


                    var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;

                    var dep = document.getElementById("intialdeppercentTextBox").value;//initaldepamtTextBox
                    document.getElementById("fractionaldepositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;
                 




                }
                else if (currency == "USD") {
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'none';
                    document.getElementById("fcgstTextBox").style.display = 'none';
                    document.getElementById("lblfsgst").style.display = 'none';
                    document.getElementById("fsgstTextBox").style.display = 'none';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';

                     var adminfees = "1110";
                  
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("AdministrationFeesTextBox").value = admintotal;
                    var tax = "0";
                    var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var sgst = "0";
                    document.getElementById("fsgstTextBox").value = sgst;
                    var cgst = "0";
                    document.getElementById("fcgstTextBox").value = cgst;

                    var dep = document.getElementById("intialdeppercentTextBox").value;//initaldepamtTextBox
                    document.getElementById("fractionaldepositTextBox").value = dep;


                    //var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                     document.getElementById("fractionalbalanceTextBox").value = bal;
                   
                }
            }
            else if (checkvalue == "Non Finance") {

                if (currency == "INR") {


                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'block';
                    document.getElementById("fcgstTextBox").style.display = 'block';
                    document.getElementById("lblfsgst").style.display = 'block';
                    document.getElementById("fsgstTextBox").style.display = 'block';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                      var adminfees = "77050";
                  

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "18";

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);

                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("fcgstTextBox").value = cgst;


                    var AdmissionFees = parseInt(totalpurchase) - parseInt(admintotal) - parseInt(cgst) - parseInt(sgst);
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;

                    var dep = document.getElementById("intialdeppercentTextBox").value;//initaldepamtTextBox
                    document.getElementById("fractionaldepositTextBox").value = dep;
                    // var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("fractionalbalanceTextBox").value = bal;
                   




                }
                else if (currency == "USD") {
                    document.getElementById("lblAdmissionFees").style.display = 'block';
                    document.getElementById("AdmissionFeesTextBox").style.display = 'block';
                    document.getElementById("lblAdministrationFees").style.display = 'block';
                    document.getElementById("AdministrationFeesTextBox").style.display = 'block';
                    document.getElementById("lblfcgst").style.display = 'none';
                    document.getElementById("fcgstTextBox").style.display = 'none';
                    document.getElementById("lblfsgst").style.display = 'none';
                    document.getElementById("fsgstTextBox").style.display = 'none';
                    document.getElementById("lblTotalPurchasePrice").style.display = 'block';
                    document.getElementById("TotalPurchasePriceTextBox").style.display = 'block';
                    document.getElementById("lblfractionaldeposit").style.display = 'block';
                    document.getElementById("fractionaldepositTextBox").style.display = 'block';
                    document.getElementById("lblfractionalbalance").style.display = 'block';
                    document.getElementById("fractionalbalanceTextBox").style.display = 'block';


                      var adminfees = "1110";
                  /*  var adminfees;
                    var adminfees1 = "1110";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("AdministrationFeesTextBox").value = admintotal;

                    var tax = "0";

                    var AdmissionFees = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("AdmissionFeesTextBox").value = AdmissionFees;
                    var sgst = "0";
                    document.getElementById("fsgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("fcgstTextBox").value = cgst;


                    var dep = document.getElementById("intialdeppercentTextBox").value;//initaldepamtTextBox
                    document.getElementById("fractionaldepositTextBox").value = dep;

                    // var dep = document.getElementById("fractionaldepositTextBox").value;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                      document.getElementById("fractionalbalanceTextBox").value = bal;
                  

                }



            }

        }
        fractionaltradeinamt();
    }
    //
    function PACalculationOwner_TradeIn(tot, aftotal) {


        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var totalpurchase = tot;
        var total = aftotal;
        document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        if (checkvalue == "Finance") {

            if (currency == "INR") {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                document.getElementById("Label148").style.display = 'block';
                document.getElementById("cgstTextBox").style.display = 'block';
                document.getElementById("Label149").style.display = 'block';
                document.getElementById("sgstTextBox").style.display = 'block';
                document.getElementById("Label150").style.display = 'block';
                document.getElementById("lblconversionfee").style.display = 'block';
                document.getElementById("conversionfeeTextBox").style.display = 'block';
            
                if (totalpurchase > 240000) {
                      var adminfees = "30000";
                   /* var adminfees;
                    var adminfees1 = "30000";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;
                    var tax = "18";
                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("sgstTextBox").value = sgst;
                    var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("cgstTextBox").value = cgst;

                    //var newpointsprice = document.getElementById("newpointsTextBox").value;
                    //document.getElementById("newpointsTextBox").readOnly = false;
                    var newpts = "0";
                    var newpointsprice = newpts;
                    //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    // alert("confee:" + convfee);
                    document.getElementById("conversionfeeTextBox").value = convfee;
                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 240000) {
                    // alert(totalpurchase);
                    var adminfees = parseInt(totalpurchase) * (12.5 / 100);
                    //alert(adminfees);
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = Math.floor( (parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst =Math.floor(  (parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("cgstTextBox").value = cgst;

                    //var newpointsprice =   document.getElementById("newpointsTextBox").value;
                    //
                    var newpts = "0";
                    var newpointsprice = newpts;
                    //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;
                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }
            else if (currency == "USD") {
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';
                if (totalpurchase > "5984") {

                      var adminfees = "748";
                 /*   var adminfees;
                    var adminfees1 = "748";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;



                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 5984) {

                    var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;


                    document.getElementById("newpointsTextBox").style.display = 'none';


                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }

            }
        }
        else if (checkvalue == "Non Finance") {

            if (currency == "INR") {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                document.getElementById("Label148").style.display = 'block';
                document.getElementById("cgstTextBox").style.display = 'block';
                document.getElementById("Label149").style.display = 'block';
                document.getElementById("sgstTextBox").style.display = 'block';
                document.getElementById("Label150").style.display = 'block';
                document.getElementById("lblconversionfee").style.display = 'block';
                document.getElementById("conversionfeeTextBox").style.display = 'block';
              
                if (totalpurchase > "240000") {
                     var adminfees = "30000";
                   /* var adminfees;
                    var adminfees1 = "30000";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/
                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst =Math.round(  (parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst =Math.round(  (parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("cgstTextBox").value = cgst;


                    var newpts = "0";
                    var newpointsprice = newpts;

                    //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;

                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 240000) {
                    var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "18";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = Math.floor( (parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = Math.floor( (parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                    document.getElementById("cgstTextBox").value = cgst;

                    //var newpointsprice = document.getElementById("newpointsTextBox").value;
                    //document.getElementById("newpointsTextBox").readOnly = false;
                    var newpts = "0";
                    var newpointsprice = newpts;
                    //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                    document.getElementById("newpointsTextBox").value = newpointsprice;
                    document.getElementById("newpointsTextBox").readOnly = false;
                    var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                    document.getElementById("conversionfeeTextBox").value = convfee;

                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }

            }
            else if (currency == "USD") {
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';
                if (totalpurchase > "5984") {

                      var adminfees = "748";
                 /*   var adminfees;
                    var adminfees1 = "748";
                    var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                    if (adminfees1 == oadminfees) {
                        adminfees = adminfees1;
                    }
                    else {
                        adminfees = oadminfees;
                    }*/

                    var admintotal = parseInt(total) + parseInt(adminfees);

                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;



                    document.getElementById("newpointsTextBox").style.display = 'none';
                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
                else if (totalpurchase < 5984) {

                    var adminfees = parseInt(totalpurchase) * (12.5 / 100);

                    var admintotal = parseInt(total) + parseInt(adminfees);
                    document.getElementById("adminfeeTextBox").value = admintotal;

                    var tax = "0";//document.getElementById("pointstaxTextBox").value;

                    var totpurchaseprice = Math.round(parseInt(totalpurchase) / parseInt(admintotal));
                    document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                    var sgst = "0";
                    document.getElementById("sgstTextBox").value = sgst;

                    var cgst = "0";
                    document.getElementById("cgstTextBox").value = cgst;


                    document.getElementById("newpointsTextBox").style.display = 'none';


                    var dep = document.getElementById("initaldepamtTextBox").value;
                    document.getElementById("depositTextBox").value = dep;
                    var bal = parseInt(totalpurchase) - parseInt(dep);
                    document.getElementById("balanceTextBox").value = bal;

                }
            }
        }
    }

    function PACalculationNonMember(tot, aftotal)
    {
        
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var totalpurchase = tot;// document.getElementById("totalfinpriceIntaxTextBox").value;
        var total = aftotal;
       
      
        document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        if (checkvalue == "Finance") {
            if (currency == "INR") {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                document.getElementById("Label148").style.display = 'block';
                document.getElementById("cgstTextBox").style.display = 'block';
                document.getElementById("Label149").style.display = 'block';
                document.getElementById("sgstTextBox").style.display = 'block';
                document.getElementById("Label150").style.display = 'block';

                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';
            
                

                 var adminfees="30000";
               // var adminfees = document.getElementById("adminamtfeesTextBox").value;
               
               /* var adminfees1 = "30000";
                var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                if (adminfees1 == oadminfees) {
                    adminfees = adminfees1;
                }
                else
                {
                    adminfees = oadminfees;
                }*/

             
                
               
                var admintotal = parseInt(total) + parseInt(adminfees);
                //alert(admintotal);
                document.getElementById("adminfeeTextBox").value = admintotal;

                var tax = "18";//document.getElementById("pointstaxTextBox").value;

                var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                //var sgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                var sgst = Math.floor ((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                document.getElementById("sgstTextBox").value = sgst;

                //var cgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                document.getElementById("cgstTextBox").value = cgst;


                var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                document.getElementById("newpointsTextBox").value = newpointsprice;
                document.getElementById("newpointsTextBox").readOnly = true;

                var dep = document.getElementById("initaldepamtTextBox").value;
                document.getElementById("depositTextBox").value = dep;
                var bal = parseInt(totalpurchase) - parseInt(dep);
                document.getElementById("balanceTextBox").value = bal;
            }
            else if (currency == "USD")
            {
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';
                  var adminfees = "748";
             /*   var adminfees;
                var adminfees1 = "748";
                var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                if (adminfees1 == oadminfees) {
                    adminfees = adminfees1;
                }
                else {
                    adminfees = oadminfees;
                }*/

                var admintotal = parseInt(total) + parseInt(adminfees);
                document.getElementById("adminfeeTextBox").value = admintotal;

                var tax = "0";//document.getElementById("pointstaxTextBox").value;

                var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


                var sgst = "0";
                document.getElementById("sgstTextBox").value = sgst;

                var cgst = "0";
                document.getElementById("cgstTextBox").value = cgst;                
                document.getElementById("newpointsTextBox").style.display = 'none';
                

                var dep = document.getElementById("initaldepamtTextBox").value;
                document.getElementById("depositTextBox").value = dep;
                var bal = parseInt(totalpurchase) - parseInt(dep);
                document.getElementById("balanceTextBox").value = bal;

            }
        }
        else if (checkvalue == "Non Finance") {
            if (currency == "INR") {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                document.getElementById("Label148").style.display = 'block';
                document.getElementById("cgstTextBox").style.display = 'block';
                document.getElementById("Label149").style.display = 'block';
                document.getElementById("sgstTextBox").style.display = 'block';
                document.getElementById("Label150").style.display = 'block';
                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';

                var adminfees = "30000";
              /*  var adminfees;
                var adminfees1 = "30000";
                var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                if (adminfees1 == oadminfees) {
                    adminfees = adminfees1;
                }
                else {
                    adminfees = oadminfees;
                }*/
                var admintotal = parseInt(total) + parseInt(adminfees);
                document.getElementById("adminfeeTextBox").value = admintotal;

                var tax = "18";//document.getElementById("pointstaxTextBox").value;

                var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


              //  var sgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                document.getElementById("sgstTextBox").value = sgst;

               // var cgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                document.getElementById("cgstTextBox").value = cgst;

                var newpointsprice = parseInt(totpurchaseprice) - parseInt(admintotal);
                document.getElementById("newpointsTextBox").value = newpointsprice;
                document.getElementById("newpointsTextBox").readOnly = true;
                var dep = document.getElementById("initaldepamtTextBox").value;
                document.getElementById("depositTextBox").value = dep;
                var bal = parseInt(totalpurchase) - parseInt(dep);
                document.getElementById("balanceTextBox").value = bal;
            }
            else if (currency == "USD")
            {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("lblconversionfee").style.display = 'none';
                document.getElementById("conversionfeeTextBox").style.display = 'none';

                  var adminfees = "748";
              /*  var adminfees;
                var adminfees1 = "748";
                var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                if (adminfees1 == oadminfees) {
                    adminfees = adminfees1;
                }
                else {
                    adminfees = oadminfees;
                }*/
                var admintotal = parseInt(total) + parseInt(adminfees);
                document.getElementById("adminfeeTextBox").value = admintotal;

                var tax = "0"; 
                var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;                
                var sgst = "0";
                document.getElementById("sgstTextBox").value = sgst;

                var cgst = "0";
                document.getElementById("cgstTextBox").value = cgst;                 
                document.getElementById("newpointsTextBox").style.display = 'none';                
                var dep = document.getElementById("initaldepamtTextBox").value;
                document.getElementById("depositTextBox").value = dep;
                var bal = parseInt(totalpurchase) - parseInt(dep);
                document.getElementById("balanceTextBox").value = bal;

            }
        }

    }
    function PACalculationNonMember_TradeIn(tot, aftotal) {
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var totalpurchase = tot;// document.getElementById("totalfinpriceIntaxTextBox").value;
        document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
        var total = aftotal;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        if (checkvalue == "Finance") {
            if (currency == "INR") {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                document.getElementById("Label148").style.display = 'block';
                document.getElementById("cgstTextBox").style.display = 'block';
                document.getElementById("Label149").style.display = 'block';
                document.getElementById("sgstTextBox").style.display = 'block';
                document.getElementById("Label150").style.display = 'block';
                document.getElementById("lblconversionfee").style.display = 'block';
                document.getElementById("conversionfeeTextBox").style.display = 'block';
                  var adminfees = "30000";
              /*  var adminfees;
                var adminfees1 = "30000";
                var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                if (adminfees1 == oadminfees) {
                    adminfees = adminfees1;
                }
                else {
                    adminfees = oadminfees;
                }*/
                var admintotal = parseInt(total) + parseInt(adminfees);
                document.getElementById("adminfeeTextBox").value = admintotal;

                var tax = "18";//document.getElementById("pointstaxTextBox").value;

                var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
              //  var sgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                document.getElementById("sgstTextBox").value = sgst;
               // var cgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                document.getElementById("cgstTextBox").value = cgst;
                //var newpointsprice = document.getElementById("newpointsTextBox").value;
                //document.getElementById("newpointsTextBox").readOnly = false;
                var newpts = "0";
                var newpointsprice = newpts;
                //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                document.getElementById("newpointsTextBox").value = newpointsprice;
            //    document.getElementById("newpointsTextBox").readOnly = false;
                var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                document.getElementById("conversionfeeTextBox").value = convfee;

                var dep = document.getElementById("initaldepamtTextBox").value;
                document.getElementById("depositTextBox").value = dep;
                var bal = parseInt(totalpurchase) - parseInt(dep);
                document.getElementById("balanceTextBox").value = bal;
            }
            else if (currency == "USD")
            {
                
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("lblconversionfee").style.display = 'block';
                document.getElementById("conversionfeeTextBox").style.display = 'block';

                  var adminfees = "748";
               /* var adminfees;
                var adminfees1 = "748";
                var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                if (adminfees1 == oadminfees) {
                    adminfees = adminfees1;
                }
                else {
                    adminfees = oadminfees;
                }*/
                var admintotal = parseInt(total) + parseInt(adminfees);
                document.getElementById("adminfeeTextBox").value = admintotal;

                var tax = "0";
                var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                var sgst = "0";
                document.getElementById("sgstTextBox").value = sgst;

                var cgst = "0";
                document.getElementById("cgstTextBox").value = cgst;
                document.getElementById("newpointsTextBox").style.display = 'none';
                var dep = document.getElementById("initaldepamtTextBox").value;
                document.getElementById("depositTextBox").value = dep;
                var bal = parseInt(totalpurchase) - parseInt(dep);
                document.getElementById("balanceTextBox").value = bal;
            }
        }
        else if (checkvalue == "Non Finance") {
            if (currency == "INR") {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'block';
                document.getElementById("Label148").style.display = 'block';
                document.getElementById("cgstTextBox").style.display = 'block';
                document.getElementById("Label149").style.display = 'block';
                document.getElementById("sgstTextBox").style.display = 'block';
                document.getElementById("Label150").style.display = 'block';
                document.getElementById("lblconversionfee").style.display = 'block';
                document.getElementById("conversionfeeTextBox").style.display = 'block';

                var adminfees = "30000";
               /* var adminfees;
                var adminfees1 = "30000";
                var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                if (adminfees1 == oadminfees) {
                    adminfees = adminfees1;
                }
                else {
                    adminfees = oadminfees;
                }*/
                var admintotal = parseInt(total) + parseInt(adminfees);
                document.getElementById("adminfeeTextBox").value = admintotal;

                var tax = "18";//document.getElementById("pointstaxTextBox").value;

                var totpurchaseprice = Math.round(parseInt(totalpurchase) / (parseInt(tax) + 100) * 100);
                document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;


              //  var sgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                var sgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                document.getElementById("sgstTextBox").value = sgst;

               // var cgst = Math.round((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                var cgst = Math.floor((parseInt(totalpurchase) - parseInt(totpurchaseprice)) / 2);
                document.getElementById("cgstTextBox").value = cgst;



                //var newpointsprice = document.getElementById("newpointsTextBox").value;
                //document.getElementById("newpointsTextBox").readOnly = false;
                var newpts = "0";
                var newpointsprice = newpts;
                //  var newpointsprice =  document.getElementById("newpointsTextBox").value ;
                document.getElementById("newpointsTextBox").value = newpointsprice;
                document.getElementById("newpointsTextBox").readOnly = false;
                var convfee = Math.round(parseInt(totpurchaseprice) - parseInt(admintotal) - parseInt(newpointsprice));
                document.getElementById("conversionfeeTextBox").value = convfee;


                var dep = document.getElementById("initaldepamtTextBox").value;
                document.getElementById("depositTextBox").value = dep;
                var bal = parseInt(totalpurchase) - parseInt(dep);
                document.getElementById("balanceTextBox").value = bal;
            }
            else if (currency == "USD")
            {
                document.getElementById("totalpriceInTaxTextBox").style.display = 'none';
                document.getElementById("Label148").style.display = 'none';
                document.getElementById("cgstTextBox").style.display = 'none';
                document.getElementById("Label149").style.display = 'none';
                document.getElementById("sgstTextBox").style.display = 'none';
                document.getElementById("Label150").style.display = 'none';
                document.getElementById("lblconversionfee").style.display = 'block';
                document.getElementById("conversionfeeTextBox").style.display = 'block';

                  var adminfees = "748";
             /*   var adminfees;
                var adminfees1 = "748";
                var oadminfees = document.getElementById("adminamtfeesTextBox").value;
                if (adminfees1 == oadminfees) {
                    adminfees = adminfees1;
                }
                else {
                    adminfees = oadminfees;
                }*/
                var admintotal = parseInt(total) + parseInt(adminfees);
                document.getElementById("adminfeeTextBox").value = admintotal;

                var tax = "0";
                var totpurchaseprice = Math.round(parseInt(totalpurchase) - parseInt(admintotal));
                document.getElementById("totpurchpriceTextBox").value = totpurchaseprice;
                var sgst = "0";
                document.getElementById("sgstTextBox").value = sgst;

                var cgst = "0";
                document.getElementById("cgstTextBox").value = cgst;
                document.getElementById("newpointsTextBox").style.display = 'none';
                var dep = document.getElementById("initaldepamtTextBox").value;
                document.getElementById("depositTextBox").value = dep;
                var bal = parseInt(totalpurchase) - parseInt(dep);
                document.getElementById("balanceTextBox").value = bal;
            }
        }
    }
    function CheckboxValue()
    {
        var holidayplus, emerald, total, registry;
        emerald = "Emerald";
        holidayplus = "Holiday Plus";
        registry = "Registry Collection";
        var cy = document.getElementById("contracttypeDropDownList");
        var contracttype = cy.options[cy.selectedIndex].text;

            if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false)) {

                total = "";
                document.getElementById("AffiliationvalueTextBox").value = total;


            }
            else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true)) {

                total = registry;
                document.getElementById("AffiliationvalueTextBox").value = total;


            }
            else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false)) {

                total = holidayplus;
                document.getElementById("AffiliationvalueTextBox").value = total;


            }
            else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true)) {

                total = holidayplus + " " + registry;
                document.getElementById("AffiliationvalueTextBox").value = total;

            }
            if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false)) {

                total = emerald;
                document.getElementById("AffiliationvalueTextBox").value = total;



            }
            else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true)) {

                total = emerald + " " + registry;
                document.getElementById("AffiliationvalueTextBox").value = total;

            }
            else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false)) {

                
                total = emerald + " " + holidayplus;
                document.getElementById("AffiliationvalueTextBox").value = total;


            }
            else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true)) {

                total = emerald + " " + holidayplus + " " + registry;
                document.getElementById("AffiliationvalueTextBox").value = total;

            }
        Procedure_Generation_Contract1();

    }
    //function for caluclation
    function PointsPurchase1() {
        // alert("enter PointsPurchase1");
        var holidayplus, emerald, total, registry;
       
        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
        //get venue name
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;
        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venuegroup = vg.options[vg.selectedIndex].text;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var totalpurchase = document.getElementById("totalfinpriceIntaxTextBox").value;
        document.getElementById("totalpriceInTaxTextBox").value = totalpurchase;
        document.getElementById("intialdeppercentTextBox").style.display = 'BLOCK';
        var regcollterm = document.getElementById("regcollectiontermTextBox").value;
        //    alert(regcollterm);
        //load affilaiation values based on selected checkbox
       
         if (currency == "INR") {
             if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false))
             {
                emerald = "0";
                holidayplus = "0";
                registry = "0";
                total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

            }
             else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true))
             {
              
                emerald = "0";
                holidayplus = "0";
                if (regcollterm < 5)
                {
                    // alert("less than 5");
                    var regcollamt = document.getElementById("regcollamtTextBox").value;
                    //  alert("textbox value:" + regcollamt);
                    registry = regcollamt;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //  alert(total);
                }
                
                else if (regcollterm = 5)
                {
                    registry = "47302";
                    document.getElementById("regcollamtTextBox").value=registry;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //alert(total);
                }
               
              
            }
             else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false))
             {
                emerald = "0";
                holidayplus = "2680";
                registry = "0";
                total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

            }
             else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true))
             {
                emerald = "0";
                holidayplus = "2680";
                //registry = "47302";
                if (regcollterm < 5) {
                    // alert("less than 5");
                    var regcollamt = document.getElementById("regcollamtTextBox").value;
                    //  alert("textbox value:" + regcollamt);
                    registry = regcollamt;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //  alert(total);
                }

                else if (regcollterm = 5)
                {
                    registry = "47302";
                    document.getElementById("regcollamtTextBox").value = registry;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //alert(total);
                }
                //total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
            }
             if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false))
             {
                emerald = "23852";
                holidayplus = "0";
                registry = "0";
                total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

            }
             else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true))
             {
                emerald = "23852";
                holidayplus = "0";
                //registry = "47302";
                if (regcollterm < 5) {
                    // alert("less than 5");
                    var regcollamt = document.getElementById("regcollamtTextBox").value;
                    //  alert("textbox value:" + regcollamt);
                    registry = regcollamt;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //  alert(total);
                }

                else if (regcollterm = 5) {
                    registry = "47302";
                    document.getElementById("regcollamtTextBox").value = registry;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //alert(total);
                }
                //  total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
            }
             else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false))
             {
                emerald = "23852";
                holidayplus = "2680";
                registry = "0";
                total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

            }
             else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true))
             {
                emerald = "23852";
                holidayplus = "2680";
                if (regcollterm < 5) {
                    // alert("less than 5");
                    var regcollamt = document.getElementById("regcollamtTextBox").value;
                    //  alert("textbox value:" + regcollamt);
                    registry = regcollamt;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //  alert(total);
                }

                else if (regcollterm = 5) {
                    registry = "47302";
                    document.getElementById("regcollamtTextBox").value = registry;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //alert(total);
                }
                //registry = "47302";
                //  total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
             }
           //  var ad = "77050";
            // document.getElementById("adminamtfeesTextBox").value = ad;

             
        }
        else if (currency == "USD")
        {
            if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false)) {
                emerald = "0";
                holidayplus = "0";
                registry = "0";
                total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

            }
            else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true)) {
                emerald = "0";
                holidayplus = "0";
                //registry = "706";
                //total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                if (regcollterm < 5) {
                    // alert("less than 5");
                    var regcollamt = document.getElementById("regcollamtTextBox").value;
                    //  alert("textbox value:" + regcollamt);
                    registry = regcollamt;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //  alert(total);
                }

                else if (regcollterm = 5) {
                    registry = "706";
                    document.getElementById("regcollamtTextBox").value = registry;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //alert(total);
                }
            }
            else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false)) {
                emerald = "0";
                holidayplus = "40";
                registry = "0";
                total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

            }
            else if ((document.getElementById("ca1").checked == false) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true)) {
                emerald = "0";
                holidayplus = "40";
                //registry = "706";
                //total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                if (regcollterm < 5) {
                    // alert("less than 5");
                    var regcollamt = document.getElementById("regcollamtTextBox").value;
                    //  alert("textbox value:" + regcollamt);
                    registry = regcollamt;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //  alert(total);
                }

                else if (regcollterm = 5) {
                    registry = "706";
                    document.getElementById("regcollamtTextBox").value = registry;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //alert(total);
                }
            }
            if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == false)) {
                emerald = "150";
                holidayplus = "0";
                registry = "0";
                total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

            }
            else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == false) && (document.getElementById("ca3").checked == true)) {
                emerald = "150";
                holidayplus = "0";
                //registry = "706";
                //total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                if (regcollterm < 5) {
                    // alert("less than 5");
                    var regcollamt = document.getElementById("regcollamtTextBox").value;
                    //  alert("textbox value:" + regcollamt);
                    registry = regcollamt;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //  alert(total);
                }

                else if (regcollterm = 5) {
                    registry = "706";
                    document.getElementById("regcollamtTextBox").value = registry;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //alert(total);
                }
            }
            else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == false)) {
                emerald = "150";
                holidayplus = "40";
                registry = "0";
                total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);

            }
            else if ((document.getElementById("ca1").checked == true) && (document.getElementById("ca2").checked == true) && (document.getElementById("ca3").checked == true)) {
                emerald = "150";
                holidayplus = "40";
                //registry = "706";
                //total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                if (regcollterm < 5) {
                    // alert("less than 5");
                    var regcollamt = document.getElementById("regcollamtTextBox").value;
                    //  alert("textbox value:" + regcollamt);
                    registry = regcollamt;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //  alert(total);
                }

                else if (regcollterm = 5) {
                    registry = "706";
                    document.getElementById("regcollamtTextBox").value = registry;
                    // alert(registry);
                    total = parseInt(emerald) + parseInt(holidayplus) + parseInt(registry);
                    //alert(total);
                }
            }
           // var ad = "1110";
          //  document.getElementById("adminamtfeesTextBox").value = ad;

        }
    
    
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
  
        if (contract_type == "Fractional")
        {
            
            //if (venuegroup == "Inhouse")
            if (venuegroup == "Inhouse"||venuegroup=="INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY")
            {
                if (mktg == "OWNER")
                {
                    PACalculationOwnerFractional(totalpurchase, total);


                }
                     
                else
                {
                   // PACalculationNonMember(totalpurchase, total);
                    PACalculationOwnerFractional(totalpurchase, total);

                }

            }
            else
            {
                //  PACalculationNonMember(totalpurchase, total);
                PACalculationOwnerFractional(totalpurchase, total);
            }
        }
        else if (contract_type == "Points")
        {
          //  alert("points");
           // alert(venuegroup);
            // if (venuegroup == "Inhouse")
            if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY")
            {
                if (mktg == "OWNER") {
                    PACalculationOwner(totalpurchase, total);

                }//if block mktg
                else
                {

                    PACalculationNonMember(totalpurchase, total);

                }//else block mktg
            }//if block venuegrp
            else
            {
                PACalculationNonMember(totalpurchase, total);

            }//else block venuegrp

        }//else contract type
        else if (contract_type == "Trade-In-Points") {
            //  if (venuegroup == "Inhouse")
            if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY")

            {
                if (mktg == "OWNER") {

                    PACalculationOwner_TradeIn(totalpurchase, total);
                }
                else {
                    PACalculationNonMember_TradeIn(totalpurchase, total);

                }
            }
            else {
                PACalculationNonMember_TradeIn(totalpurchase, total);

            }

        }
        else if (contract_type == "Trade-In-Weeks")
        {
            // if (venuegroup == "Inhouse")
            if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY")
            {
                if (mktg == "OWNER")
                {

                    PACalculationOwner_TradeIn(totalpurchase, total);
                }
                else
                {
                    PACalculationNonMember_TradeIn(totalpurchase, total);

                }
            }
            else {
                PACalculationNonMember_TradeIn(totalpurchase, total);

            }

        }
        else if (contract_type == "Trade-In-Fractionals") {
            //            if (venuegroup == "Inhouse")
            if (venuegroup == "Inhouse" || venuegroup == "INHOUSE" || venuegroup == "Collections" || venuegroup == "Odyssey" || venuegroup == "COLLECTIONS" || venuegroup == "MC" || venuegroup == "ODYSSEY")

            {
                if (mktg == "OWNER")
                {

                     PACalculationOwnerTradeIn_Fractional(totalpurchase, total);
                //    PACalculationOwnerFractional(totalpurchase, total);
                }
                else
                {
                    PACalculationOwnerTradeIn_Fractional(totalpurchase, total);
                   // PACalculationOwnerFractional(totalpurchase, total);
                }
            }
            else
            {
                PACalculationOwnerTradeIn_Fractional(totalpurchase, total);
              //  PACalculationOwnerFractional(totalpurchase, total);
            }

        }
      // InitialDepositCalculation1();
     //  DisplayInstallmentAmt();
    }
    
    

  
    function RemoveTextBox()
    {
        //document.getElementById("installmentDIV").removeChild(installmentDIV.parentNode);
        document.getElementById("installmentDIV").innerHTML = "";
    }
    // check date for cases pertaining to different months
    function caldays(d, m, y) {
        
       // alert('d ' + d + 'm '+ m + 'y ' + y);

        var dmax;
        if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12) {
            if (d > 31) {
                dmax = 31;
            }
            else {
                dmax = d
            }
          
        }
        else if (m == 4 || m == 6 || m == 9 || m == 11) {
            if (d > 30) {
                dmax = 30;
            }
            else {
                dmax = d
            }
        
        }
        else if (m == 2) {
           
            if ((y % 4 == 0) || (y % 400 == 0 && y % 100 != 0)) {
                if (d > 29) {
                    dmax = 29;
                }
                else {
                    dmax = d
                }
            
            }
            else {
                if (d > 28) {
                    dmax = 28;
                }
                else {
                    dmax = d
                }
            }
       
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
        var k = dmax + "-" + m + "-" + y;

       // alert(k);
     
        return k;



    }



    function re(noofInstall, remark,balamddate) {
        // alert('hi');

        // alert(noofInstall + '     ' + remark);
        var am, k, l, m;
        var p = 0, d = 0;
        var da = "";
        var re = "";
        //11
        var temp = "", temp2 = 0;
        var arr = [];


        for (k = 1; k <= noofInstall ; k++) {


            //alert('s ' + temp2 + document.getElementById("t" + k + "1").value);
            for (m = 0; m < arr.length; m++) {
                //alert('m '+m);
                var kk = k + m;

                if (document.getElementById("textBox_" + k + "1").value == arr[m]) {
                    temp2 = 1;
                }
            }


            if (temp2 != 1) {

                for (l = 1; l <= noofInstall ; l++) {



                    if (document.getElementById("textBox_" + k + "1").value == document.getElementById("textBox_" + l + "1").value) {
                        //alert('loop2');
                        p++;

                        da += document.getElementById("textBox_" + l + "2").value + ", ";


                    }


                }

            }
            arr[k - 1] = document.getElementById("textBox_" + k + "1").value;
            temp = document.getElementById("textBox_" + k + "1").value;
            //alert(k+"  "+temp);
            //alert('arr   '+arr+'          '+p);
            if (temp2 != 1) {
                // alert('inloop');
                if (p > 1) {
                    //alert('p>1');
                    re += " Rs." + document.getElementById("textBox_" + k + "1").value + "/- X " + p + " INST ON " + da + " ";
                    // alert('p>1   '+re);
                }
                else {
                    // alert(' else p>1');
                    re += " Rs." + document.getElementById("textBox_" + k + "1").value + "/- " + " INST ON " + da + " ";//document.getElementById("t" + l + "2").value+",";
                    // alert(' else p>1 '+re);
                }
            }

            p = 0; da = ""; temp2 = 0;
            // alert(re);

        }

        
        re = re.slice(0, -3);

        //re = balamddate + re;
        var re1 = balamddate + re;

        //alert(re);
        document.getElementById(remark).value = re1;

    }
    function sum(numi, bamt) {
     
        var t23 = "";
        var pe;
        var sum = 0;
        var pam = bamt;
      //  var baldue = "";
        var baldue;
        var baldepamount = document.getElementById("baldepamtTextBox").value;
        var baldepdate = document.getElementById("baladepamtdateTextBox").value;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var curr;
        if (currency == "INR")
        {
            curr = "Rs";
        }
        else if (currency == "USD")
        {
            curr = "$";
        }
        if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
            baldue = "";

        }
        else {
            baldue = curr + " " + baldepamount+"/-"+ "  on " + baldepdate + ",";
        }
       for (pe = 1; pe <= numi; pe++) {
            sum = sum + parseInt(document.getElementById("textBox_" + pe + "1").value);        

         //   baldue +=curr+" "+ document.getElementById("textBox_" + pe + "1").value +"/-"+ " " + "on" + " " + document.getElementById("textBox_" + pe + "2").value + " ";

        }
     
        document.getElementById('totalamt').value = parseInt(pam) - sum;
        //document.getElementById("balancedueTextBox").value = baldue;

        var remarkt = "balancedueTextBox";
        re(numi, remarkt, baldue);

    }
    function sumf(numi, bamt) {
      
        var t23 = "";
        var pe;
        var sum = 0;
        var pam = bamt;
     //   var baldue = "";
        var baldue;
        var baldepamount = document.getElementById("baldepamtTextBox").value;
        var baldepdate = document.getElementById("baladepamtdateTextBox").value;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var curr;
        if (currency == "INR") {
            curr = "Rs";
        }
        else if (currency == "USD") {
            curr = "$";
        }
        if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
            baldue = "";

        }
        else {
            baldue = curr + " " +baldepamount +"/-"+ "  on " + baldepdate + ",";
        }
       
        for (pe = 1; pe <= numi; pe++) {
            sum = sum + parseInt(document.getElementById("textBox_" + pe + "1").value);
        
          //  baldue += curr + " " + document.getElementById("textBox_" + pe + "1").value + "/-" + " " + "on" + " " + document.getElementById("textBox_" + pe + "2").value + " ";

        } 
     
        document.getElementById('totalamt1').value = parseInt(pam) - sum;
        //document.getElementById("fractionalbalduedateTextBox").value = baldue;

        var remarkt = "fractionalbalduedateTextBox";
        re(numi, remarkt, baldue);

    }

   


    function InstallmentGeneration(no, amt,balamt)
    {
        RemoveTextBox();
          //alert('points');
      
        var noinstallment = no;
        var instalmentamt = amt;
        var bal = balamt;
       
      //  var bal = document.getElementById("balinitialdepamtTextBox").value;
        document.getElementById('totalamt').value = bal;
      
        var baldue;
        var baldepamount = document.getElementById("baldepamtTextBox").value;
        var baldepdate = document.getElementById("baladepamtdateTextBox").value;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var curr;
        if (currency == "INR") {
            curr = "Rs";
        }
        else if (currency == "USD") {
            curr = "$";
        }
        if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
            baldue = "";

        }
        else {
            baldue = curr + " " +baldepamount +"/-"+ " on " + baldepdate + ",";
        }
      
        var ch = document.getElementById("installmentDIV");
        var newdate;
        var date = "2017-10-30";
        var yr1 = parseInt(date.substring(0, 4));
        var mon1 = parseInt(date.substring(5, 7));
        var dt1 = parseInt(date.substring(8, 10));
        var amt = 2420;
        var amt2 = 2416;
        var smon1;
        var syr1, tsyr1;
        var s = yr1 + "-" + mon1 + "-" + dt1;

        var d = new Date();


        //var tomorrow = new Date();

       // alert(tomorrow);
        //tomorrow.setDate(tomorrow.getDate() + 1);
        //d.setDate(d.getDate() + 1);

        //var k = d;

       // alert(k);

        var n = d.getDate();
        var m = d.getMonth() + 2;
        var y = d.getFullYear();
        var currdate = y + "-" + m + "-" + n;

        //alert(currdate);
        var zy;
        
        smon1 = m;
        syr1 = y;
        var cr = parseInt(m);// + 1;


        for (i = 1; i <= noinstallment ; i++) {
            //   alert(i);

            for (j = 1; j < 3; j++) {
                //alert('f2');
                var input = document.createElement("input");

                input.type = 'text';
                input.id = 'textBox_' + i + j;
                input.name = 'textBox_' + i + j;
                input.onkeyup = function () { sum(noinstallment, bal); };
                input.className = 'space';
                ch.appendChild(input);
                var id1 = input.id;
                

            }//j loop
            var space1 = document.createElement("BR");
            var space2 = document.createElement("BR");
            ch.appendChild(space1);
            ch.appendChild(space2);
            var z = 'textBox_' + i + '1';
            document.getElementById(z).value = instalmentamt;
           // alert('out of if' + cr);
            if (cr > 12) {
                cr = "1";
                y = parseInt(y) + 1;
                 //alert(y);
                 newdate = y + "-" + cr + "-" + n;
                 zy = caldays(n, cr, y);
                cr = parseInt(cr) + 1;
                //cr = 1;
            }
            else {

                newdate = y + "-" + cr + "-" + n;
                zy = caldays(n, cr, y);
                cr = parseInt(cr) + 1;
                //alert('else '+ y);

            }
            //alert('2 '+y);
           // alert('not in cal  d ' + n + 'm ' + cr + 'y ' + y);
            //var zy = caldays(n, cr, y);
            newdate = zy;

            var indate = 'textBox_' + i + '2';

            document.getElementById(indate).value = newdate;

            // baldue += curr + " " + document.getElementById("textBox_" + i + "1").value + "/-" + " " + "on" + " " + document.getElementById("textBox_" + i + "2").value + " ";
            //   str = str.replace(/,\s*$/, "");
           
            // document.getElementById("balancedueTextBox").value = baldue;
           

        }
        var remarkt = "balancedueTextBox";
        re(noinstallment, remarkt, baldue);
        

    }
    function RemoveTextBoxFractional() {
        //document.getElementById("installmentDIV").removeChild(installmentDIV.parentNode);
        document.getElementById("installmentDIV1").innerHTML = "";
    }
    function InstallmentGenerationFractional(no, amt,balamt) {
        RemoveTextBoxFractional();
        //  alert(no);
        var noinstallment = no;
        var instalmentamt = amt;
      //  var baldue = "";
        var bal = balamt; //document.getElementById("balinitialdepamtTextBox").value;
        document.getElementById('totalamt1').value = bal;
        var baldue;
        var baldepamount = document.getElementById("baldepamtTextBox").value;
        var baldepdate = document.getElementById("baladepamtdateTextBox").value;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var curr;
        if (currency == "INR") {
            curr = "Rs";
        }
        else if (currency == "USD") {
            curr = "$";
        }
        if (baldepamount == "" || baldepamount == "0" || baldepamount == "NaN") {
            baldue = "";

        }
        else {
            baldue = curr+" "+baldepamount+"/-"+ " on " + baldepdate + ",";
        }
        var ch = document.getElementById("installmentDIV1");
        var newdate;
        var date = "2017-10-30";
        var yr1 = parseInt(date.substring(0, 4));
        var mon1 = parseInt(date.substring(5, 7));
        var dt1 = parseInt(date.substring(8, 10));
        var amt = 2420;
        var amt2 = 2416;
        var smon1;
        var syr1, tsyr1;
        var s = yr1 + "-" + mon1 + "-" + dt1;

        var d = new Date();
        var n = d.getDate();
        var m = d.getMonth() + 2;
        var y = d.getFullYear();
        var zy;
        var currdate = y + "-" + m + "-" + n;
        //  var currdate = dt.setMonth(dt.getMonth() + noinstallment);
        smon1 = m;
        syr1 = y;
        var cr = parseInt(m);//+ 1;


        for (i = 1; i <= noinstallment ; i++) {
            //   alert(i);

            for (j = 1; j < 3; j++) {
                //alert('f2');
                var input = document.createElement("input");

                input.type = 'text';
                input.id = 'textBox_' + i + j;
                input.name = 'textBox_' + i + j;
                input.className = 'space';
                input.onkeyup = function () { sumf(noinstallment, bal); };                 
                ch.appendChild(input);
                var id1 = input.id;


            }//j loop
            var space1 = document.createElement("BR");
            var space2 = document.createElement("BR");
            ch.appendChild(space1);
            ch.appendChild(space2);
            var z = 'textBox_' + i + '1';
            document.getElementById(z).value = instalmentamt;

            if (cr > 12) {
                cr = "1";
                y = parseInt(y) + 1;
                // alert(y);
                newdate = y + "-" + cr + "-" + n;
                zy = caldays(n, cr, y);
                cr = parseInt(cr) + 1;
            }
            else {

                newdate = y + "-" + cr + "-" + n;
                zy = caldays(n, cr, y);
                cr = parseInt(cr) + 1;

            }

            //var zy = caldays(n, cr, y);
            newdate = zy;

            var indate = 'textBox_' + i + '2';

            document.getElementById(indate).value = newdate;

            //baldue += curr + " " + document.getElementById("textBox_" + i + "1").value + "/-" + " " + "on" + " " + document.getElementById("textBox_" + i + "2").value + " ";
           // document.getElementById("fractionalbalduedateTextBox").value = baldue;

            

        }
        var remarkt = "fractionalbalduedateTextBox";
        re(noinstallment, remarkt, baldue);

    }
    function DisplayInstallmentAmt() {

        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
        var i;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {

                var checkvalue = radio[i].value;
            }
        }
        if (contract_type == "Fractional" || contract_type == "Trade-In-Fractionals")
        {
            if (checkvalue == "Finance") {
                // var balpayable = document.getElementById("balamtpayableTextBox").value;
                var balpayable = document.getElementById("balinitialdepamtTextBox").value;
                var balamt = document.getElementById("balamtpayableTextBox").value;
                var noinstallment = document.getElementById("NoinstallmentTextBox").value;

                var instalmentamt = Math.round(parseInt(balpayable) / parseInt(noinstallment));
                document.getElementById("installmentamtTextBox").value = instalmentamt;
                InstallmentGenerationFractional(noinstallment, instalmentamt, balpayable);

            }

            else if (checkvalue == "Non Finance") {
                var balpayable = document.getElementById("balamtpayableTextBox").value;

                var balamt = document.getElementById("balamtpayableTextBox").value;
                var noinstallment = document.getElementById("NoinstallmentTextBox").value;

                var instalmentamt = Math.round(parseInt(balpayable) / parseInt(noinstallment));
                document.getElementById("installmentamtTextBox").value = instalmentamt;

                InstallmentGenerationFractional(noinstallment, instalmentamt, balpayable);


            }


        }
        else
        {

            if (checkvalue == "Finance")
            {
                // var balpayable = document.getElementById("balamtpayableTextBox").value;
                var balpayable = document.getElementById("balinitialdepamtTextBox").value;
                var balamt = document.getElementById("balamtpayableTextBox").value;
                var noinstallment = document.getElementById("NoinstallmentTextBox").value;

                var instalmentamt = Math.round(parseInt(balpayable) / parseInt(noinstallment));
                document.getElementById("installmentamtTextBox").value = instalmentamt;
                InstallmentGeneration(noinstallment, instalmentamt, balpayable);

            }

            else if (checkvalue == "Non Finance") {
                var balpayable = document.getElementById("balamtpayableTextBox").value;

                var balamt = document.getElementById("balamtpayableTextBox").value;
                var noinstallment = document.getElementById("NoinstallmentTextBox").value;

                var instalmentamt = Math.round(parseInt(balpayable) / parseInt(noinstallment));
                document.getElementById("installmentamtTextBox").value = instalmentamt;

                InstallmentGeneration(noinstallment, instalmentamt, balpayable);


            }
        }

    }

    

        



    function Radiobuttonlistdisplay()
    {
        var startvalue, endvalue, financeno;
 
        
        document.getElementById("cright").style.display = 'block';
        document.getElementById("totalfinpriceIntaxTextBox").value = "";
        document.getElementById("currencyDropDownList").value = "";

        document.getElementById("intialdeppercentTextBox").value = "";
        document.getElementById("initaldepamtTextBox").value = "";
        document.getElementById("PayMethodDropDownList").value = "";
        document.getElementById("firstdepamtTextBox").value = "";
        document.getElementById("balamtpayableTextBox").value = "";
        document.getElementById("NoinstallmentTextBox").value = "";
        document.getElementById("installmentamtTextBox").value = "";
        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
        //get venue name
        var v = document.getElementById("VenueDropDownList");
        var venue = v.options[v.selectedIndex].text;
        //get venue grp name
        var vg = document.getElementById("GroupVenueDropDownList");
        var venuegroup = vg.options[vg.selectedIndex].text;
        var m = document.getElementById("MarketingProgramDropDownList");
        var mktg = m.options[m.selectedIndex].text;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var i;
        var radio = document.getElementsByName('financeradiobuttonlist');
        for (var i = 0; i < radio.length; i++)
        {
            if (radio[i].checked)
            {

                var checkvalue = radio[i].value;
            }
        }

        if (checkvalue == "Finance")
        {
            document.getElementById("lblfinancemethod").style.display = 'BLOCK';
            document.getElementById("financemethodDropDownList").style.display = 'BLOCK';
            var emi = "60";
            document.getElementById("noemiTextBox").value = emi;
         
        }
        else {
            document.getElementById("lblfinancemethod").style.display = 'none';
            document.getElementById("financemethodDropDownList").style.display = 'none';
        }

    }


   <%-- function getvalue() {

alert($('#<%=financeradiobuttonlist.ClientID %> input[type=radio]:checked').val());
}--%>
    function dispplayvalue() {
        // alert("hi");
        var checkedvalue = document.getElementByName("aamt");
        if (checkedvalue.checked) {
            // alert("checked");
        }


    }

    function RemoveSORAdditionalNames() {
       
        document.getElementById("sorDIV").innerHTML = "";
    }
     
    function SORAdditionalNames()
    {
        RemoveSORAdditionalNames();
        var num = document.getElementById("asornoTextBox").value;
        var ch = document.getElementById("sorDIV");
        for (i = 1; i <= num ; i++)
        {
            for (j = 1; j < 6; j++)
            {
                var input = document.createElement("input");
                input.type = 'text';
                input.id = 'textBox1_' + i + j;
                input.name = 'textBox1_' + i + j;            
                input.className = 'space';
                ch.appendChild(input);
                var id1 = input.id;


            }//j loop
            var space1 = document.createElement("BR");
            var space2 = document.createElement("BR");
            ch.appendChild(space1);
            ch.appendChild(space2);
           // var z = 'textBox_' + i + '1';
          //  document.getElementById(z).value = instalmentamt;

//
            var indate = 'textBox1_' + i + '2';

          //  document.getElementById(indate).value = newdate;

          
        }


    }

    function lease_back(p1, p2) {
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

    function VoidAgreementamt()
    {
         
        var ct = document.getElementById("contracttypeDropDownList");
        var contract_type = ct.options[ct.selectedIndex].text;
       
        var oldcontno = document.getElementById("CanxContractNoTextBox").value;
       
    
        var depmth = document.getElementById("depositmethodDropDownList");
        var depositmethod = depmth.options[depmth.selectedIndex].text;
        var cy = document.getElementById("currencyDropDownList");
        var currency = cy.options[cy.selectedIndex].text;
        var curr;
        if (currency == "INR") {
            curr = "Rs.";
        }
        else if (currency == "USD") {
            curr = "$";
        }
      
        if(contract_type=="Fractionals" || contract_type=="Trade-In-Fractionals")
        {
            var depamt = document.getElementById("intialdeppercentTextBox").value;
         
            var oamt = document.getElementById("frpdoldamtTextBox").value;
            var actualdep = parseInt(depamt) - parseInt(oamt);
            var strrmk = curr + oamt+"/-"+ " " + "TRANSFERRED FROM " + oldcontno + " " + "& "+ curr +actualdep+"/-"+" "+"BY "+depositmethod;
            document.getElementById("remarksTextBox").value = strrmk;
         
        }
        else
        {
            var depamt = document.getElementById("intialdeppercentTextBox").value;
            var oamt = document.getElementById("pdoldamtTextBox").value;
            var actualdep = parseInt(depamt) - parseInt(oamt);
            
            var strrmk = curr + oamt + "/-" + " " + "TRANSFERRED FROM " + oldcontno + " " + "& " + curr + actualdep + "/-" + " " + "BY " + depositmethod;
           
            document.getElementById("remarksTextBox").value = strrmk;
        }
    }
</script>

        <style type="text/css">
            #tabs {
                padding: 10px;
                border: 1px solid #4c4c4c;
                /* max-width:1000px;*/
            }

           

            #panel, #chs2, #chs3,#chs3a,#chs4a,#panel2,#panel3,#panel4 {
                display: none;
            }

            #TextBox22 {
                vertical-align: top;
            }

            #cleft {
                float: left;
            }

            #cright {
                float: right;
                display: none;
            }

            #financetitle {
                float: right;
                display: none;
                width: 600px;
            }

            #cdiv1, #cdiv2, #cdiv3, #cdiv4, #cdivtradeinweeks, #cdivtradeinpoints,#fractionalweeks,#fractionalpoints,#fractionaltofractionals  {
                display: none;
            }
            /*#pan,#adhar,*/
            #identitytable, #yes, #yes1, #yess1, #yes2, #yess2, #ptyes1,#pyess1, #remarks, #Points, #pnumb, #initaldepamtTextBox, #lblinitaldepamt, #lblbaladepamt, #baldepamtTextBox, #lblfirstdepamt, #firstdepamtTextBox, #lblbalamtpayable, #balamtpayableTextBox, #lblnoinstallment, #NoinstallmentTextBox, #lblinstallmentamt, #installmentamtTextBox, #lblfinancemethod, #financemethodDropDownList, #lblfinanceno, #FinancenoTextBox, #lblbalinitialdep, #balinitialdepamtTextBox {
                display: none;
            }

            #lblfinanceno,
            #FinancenoTextBox,
            #lblnoemi,
            #noemiTextBox,
            #lblemiamt,
            #emiamtTextBox,#lbladminamtfees,#adminamtfeesTextBox {
                display: none;
            }

            .space {
                margin-right: 10px;
            }

            body {
            }
            /*#incrTextBox,*/
            #ffractional1, #tfractional, #pointsamtTextBox, #pointstaxTextBox, #testTextBox, #AffiliationamtTextBox,#findocfeeTextBox,#igstamtTextBox,#lastfingennoTextBox,#AffiliationvalueTextBox,#lblMCFees,#MCFeesTextBox,#testresTextBox,#testresnoTextBox, #lblfptsResidenceno1,#fptsResidenceno1TextBox,#lblfptsresidencetype1,#fptsresidencetype1TextBox,#lblfwresidenceno1,#fwresidenceno1TextBox,#lblfwresidencetype1,#fwresidencetype1TextBox,#oldcontracttypeTextBox,#lblinitaldepamt,#initaldepamtTextBox,#lblbaladepamt,#baldepamtTextBox,#firstdepamtTextBox,#lblfirstdepamt,#lblregcoll,#regcollectiontermTextBox,#lblregcollamt,#regcollamtTextBox,#lblbaladepamtdate,#baladepamtdateTextBox

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
    <li><a href="#tabs-1">Profile</a></li>
    <li><a href="#tabs-2">Contract</a></li>
    <li><a href="#tabs-3">SOR/Additional Names</a></li>   
     <li><a href="#tabs-4">Finance Details</a></li>
       <li><a href="#tabs-5">Print</a></li>
  </ul>
        <a href="#tabs-5">
      <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
      </a>

  <div id="tabs-1">
    <div style="border:thin solid #C0C0C0;">
      
        
       <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PROFILE</h3>
        <hr />
        <br />
          
         <table style="width:100%; ">

             <tbody>
               <tr>
                   <td class="auto-style2"><asp:Label ID="Label1" runat="server" Text="Profile ID" Font-Size="Medium"></asp:Label> </td>
                   <td class="auto-style2"><asp:TextBox ID="profileidTextBox" runat="server" style="width:170px; height:20px" Enabled="True" ReadOnly="True" Font-Size="Small"></asp:TextBox> </td>
                   <td class="auto-style2"><asp:Label ID="Label2" runat="server" Text="Date Insert" Font-Size="Medium"></asp:Label></td>
                   <td class="auto-style2"><asp:TextBox ID="indateTextBox" runat="server" Enabled="False" style="width:170px; height:20px" ReadOnly="True" Font-Size="Small"></asp:TextBox></td>
                   <td class="auto-style2"><asp:Label ID="Label3" runat="server" Text="Created By" Font-Size="Medium"></asp:Label></td>
                   <td class="auto-style2"><asp:TextBox ID="createdbyTextBox" runat="server" Enabled="True" style="width:170px; height:20px" ReadOnly="True" Font-Size="Small"></asp:TextBox></td>
                    <td class="auto-style2"><asp:Label ID="Label7" runat="server" Font-Size="Medium" Text="Label">Marketing Program</asp:Label></td>
                   <td class="auto-style2"><asp:DropDownList ID="MarketingProgramDropDownList" style="width:170px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                   <%--   <td>   &nbsp;</td>
                   <td>   &nbsp;</td>--%>
               </tr>
           
               <tr>
                   <td>   <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Label">Venue Country</asp:Label></td>
                   <td>  <asp:DropDownList ID="VenueCountryDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server" ></asp:DropDownList></td>
                   <td>  <asp:Label ID="Label5" runat="server" Font-Size="Medium"  Text="Label">Venue</asp:Label></td>
                   <td>  <asp:DropDownList ID="VenueDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td>  <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Label">Group Venue</asp:Label></td>
                   <td>  <asp:DropDownList ID="GroupVenueDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>
                  
               </tr>
               <tr>
                   <td><asp:Label ID="Label8" runat="server" Font-Size="Medium" Text="Label">Agents</asp:Label></td>
                   <td><asp:DropDownList ID="AgentDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>
                   <td><asp:Label ID="Label9" runat="server" Text="TO Name" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="TONameDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>
                   <td><asp:Label ID="Label205" runat="server" Text="Manager" Font-Size="Medium"></asp:Label></td>
                   <td><asp:DropDownList ID="ManagerDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server" ></asp:DropDownList></td>
                   <td><asp:TextBox ID="officeTextBox" runat="server" Font-Size="Small" ReadOnly="True" Visible="False" Width="47px"></asp:TextBox></td>
                   <td>&nbsp;</td>
               </tr>
                 <tr>
                    
                     <td>
                         <input id="chs" type="checkbox" onclick="shows();" />
                         <asp:Label ID="Label10" runat="server" Text="Label">Are you a Member?</asp:Label></td>
                 </tr>

             </tbody>
         </table>
           <br />
           <table style="width: 57%;">

               <tbody id="hidden1">
                   <tr>
                       <td><asp:Label ID="Label11" runat="server" Font-Size="Medium"  Text="Label">Choose Source</asp:Label></td>
                       <td><asp:DropDownList ID="MemType1DropDownList" Font-Size="Small" Style="width:150px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label15" runat="server" Font-Size="Medium"  Text="Label">Member Number</asp:Label></td>
                       <td><asp:TextBox ID="Memno1TextBox" runat="server" Font-Size="Small" Style="width: 150px; height: 20px" Enabled="True"></asp:TextBox></td>
                       <td><asp:Label ID="Label114" runat="server" Font-Size="Medium" Text="Label">Type</asp:Label></td>
                       <td><asp:DropDownList ID="TypeDropDownList" Font-Size="Small" Style="width: 175px; height: 25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label12" runat="server"  Font-Size="Medium"  Text="Label">Choose Member Type</asp:Label></td>
                       <td><asp:DropDownList ID="MemType2DropDownList" Font-Size="Small" Style="width: 150px; height: 25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label16" runat="server" Font-Size="Medium"  Text="Label">Member Number</asp:Label></td>
                       <td><asp:TextBox ID="Memno2TextBox" Font-Size="Small" Style="width:150px; height: 20px" runat="server" Enabled="True"></asp:TextBox></td>
                   </tr>
                  
               </tbody>

           </table>
           <br />
        <br />
        </div>
       
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>PRIMARY PROFILE</h3>
        <hr />
        <br />
          <table style="width:100%;">
              <tr>

                  <td><asp:Label ID="Label86" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                  <td><asp:DropDownList ID="PrimaryTitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                  <td><asp:Label ID="Label13" runat="server"  Text="Label">First Name</asp:Label></td>
                   <td> <asp:TextBox ID="pfnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td> <asp:Label ID="Label14" runat="server" Text="Label">Last Name</asp:Label></td>
                   <td> <asp:TextBox ID="plnameTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                   <td>  <asp:Label ID="Label17" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                   <td> <asp:TextBox ID="primarydobdatepicker" style="width:170px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
              </tr>

              <tr>
                  <td></td>
                  <td></td>
                   <td> <asp:Label ID="Label18" runat="server" Text="Label">Nationality</asp:Label></td>
                   <td> <asp:DropDownList ID="PrimarynationalityDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                   <td> <asp:Label ID="Label19" runat="server" Text="Label">Country</asp:Label></td>
                   <td> <asp:DropDownList ID="primarycountryDropDownList" style="width:175px; height:25px" Font-Size="Small" runat="server"></asp:DropDownList></td>
                  <td> <asp:Label ID="Label107" runat="server" Text="Label">Age</asp:Label></td>
                  <td>  <asp:TextBox ID="primaryAge" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
              </tr>

              <tr>
                  <td></td>
                  <td></td>
                   <td> <asp:Label ID="Label21" runat="server" Text="Label">Mobile #</asp:Label></td>
                   <td> <asp:DropDownList ID="primarymobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="pmobileTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   <td> <asp:Label ID="Label22" runat="server" Text="Label">Home #</asp:Label></td>
                   <td> <asp:DropDownList ID="primaryalternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="palternateTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label121" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                    <td><asp:DropDownList ID="pofficecodeDropDownList" runat="server" Font-Size="Small" style="width:70px; height:25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="pofficenoTextBox" runat="server" Font-Size="Small" style="width:95px; height:20px" Enabled="True"></asp:TextBox></td>
                   
              </tr>

              <tr>
                  <td></td>
                   <td></td>
                   <td> <asp:Label ID="Label20" runat="server" Text="Label">Email</asp:Label></td>
                  <td>  <asp:TextBox ID="pemailTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
              </tr>
             
               <tr>
                  <td></td>
                   <td></td>
                  <td><asp:Label ID="Label80" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                  <td><select multiple="multiple"  style="width:175px; height:70px" id="primlg" name="primarylang" >
                             <option value="English">English</option>
                              <option value="Hindi">Hindi</option>
                              <option value="Konkani">Konkani</option>
                              <option value="Marathi">Marathi</option>
                              <option value="French">French</option>
                              <option value="Portuguese">Portuguese</option>

                      </select></td>
              </tr>


          </table>
          <br />
        <br />
         </div>
     
         
        <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>SECONDARY PROFILE</h3>
        <hr />
         <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label81" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td> <asp:DropDownList ID="secondarytitleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                        <td> <asp:Label ID="Label23" runat="server" Text="Label">First Name</asp:Label></td>
                        <td><asp:TextBox ID="sfnameTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label24" runat="server" Text="Label">Last Name</asp:Label></td>
                        <td> <asp:TextBox ID="slnameTextBox" runat="server" Font-Size="Small" style="width:170px; height:20px"  Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label25" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                        <td> <asp:TextBox ID="secondarydobdatepicker" Font-Size="Small" style="width:170px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                         <td></td>
                        <td></td>
                        <td>  <asp:Label ID="Label26" runat="server" Text="Label">Nationality</asp:Label></td>
                        <td>  <asp:DropDownList ID="secondarynationalityDropDownList" style="width:175px; height:25px"  Font-Size="Small"  runat="server"></asp:DropDownList></td>
                        <td> <asp:Label ID="Label27" runat="server" Text="Label">Country</asp:Label></td>
                        <td>  <asp:DropDownList ID="secondarycountryDropDownList" Font-Size="Small" style="width:175px; height:25px"  runat="server"></asp:DropDownList></td>
                        <td><asp:Label ID="Label108" runat="server" Text="Label">Age</asp:Label></td>
                        <td> <asp:TextBox ID="secondaryAge" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>

                    </tr>

                    <tr>
                        <td></td>
                        <td></td>
                        <td> <asp:Label ID="Label29" runat="server" Text="Label">Mobile #</asp:Label></td>
                        <td> <asp:DropDownList ID="secondarymobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="smobileTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    
                        <td> <asp:Label ID="Label30" runat="server" Text="Label">Home #</asp:Label></td>
                        <td><asp:DropDownList ID="secondaryalternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="salternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>


                        <td>
                            <asp:Label ID="Label122" runat="server" Font-Size="Medium" Text="Office #"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="sofficecodeDropDownList" runat="server" Font-Size="Small" Style="width: 70px; height: 25px"></asp:DropDownList>&nbsp;<asp:TextBox ID="sofficenoTextBox" runat="server" Font-Size="Small" Style="width: 95px; height: 20px" Enabled="True"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label28" runat="server" Text="Label">Email</asp:Label></td>
                        <td> <asp:TextBox ID="semailTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>

                     <tr>
                  <td></td>
                   <td></td>
                  <td><asp:Label ID="Label87" runat="server" Font-Size="Medium" Text="Preferred Language:"></asp:Label></td>
                    <td><select multiple="multiple" style="width:175px; height:70px" id="seclang" name="seclang">
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
 
      <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>ADDRESS</h3>
        <hr />
        <br />

          <table style="width:100%;">
              <tbody>
                  <tr>

                      <td ><asp:Label ID="Label31" runat="server" Font-Size="Medium" Style="width:200px;" Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="address1TextBox" Font-Size="Small" runat="server" Enabled="True" Width="250px" Height="20px"></asp:TextBox></td>
                      <td ><asp:Label ID="Label32" Font-Size="Medium" runat="server"  Text="Label">Address Line1</asp:Label></td>
                      <td><asp:TextBox ID="address2TextBox" Font-Size="Small" runat="server"  Enabled="True" Width="250px" Height="20px"></asp:TextBox></td>
                       <td ><asp:Label ID="Label112" Font-Size="Medium" runat="server"  Text="Label">Country</asp:Label></td>
                      <td><asp:DropDownList ID="AddCountryDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                  </tr>
                  <tr>

                      <%-- <td><asp:Label ID="Label33" runat="server" Text="Label">State</asp:Label></td>
                      <td><asp:TextBox ID="stateTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>--%>
                      <td><asp:Label ID="Label333" runat="server" Text="Label">State</asp:Label></td>
                      <td><asp:DropDownList ID="StateDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                      <td><asp:Label ID="Label34" runat="server" Text="Label">City</asp:Label></td>
                      <td><asp:TextBox ID="cityTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                      <td><asp:Label ID="Label39" runat="server" Text="Label">Pincode</asp:Label></td>
                      <td><asp:TextBox ID="pincodeTextBox" runat="server" style="width:150px; height:20px" Font-Size="Small"  Enabled="True"></asp:TextBox></td>
                  </tr>
                 
              </tbody>
          </table>
       <br />
       <br />
    </div>


        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>OTHER DETAILS</h3>
        <hr />
        <br />
            <table style="width:100%;">
              <tbody>
                   <tr>
                      <td><asp:Label ID="Label40" runat="server" Text="Label">Employee Status</asp:Label></td>
                       <td><asp:DropDownList ID="employmentstatusDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label35" runat="server" Text="Label">Marital Status</asp:Label></td>
                       <td><asp:DropDownList ID="maritalstatusDropDownList" Font-Size="Small" style="width:155px; height:25px" runat="server"></asp:DropDownList></td>
                       <td><asp:Label ID="Label41" runat="server" Text="Label">No of Year living together as a couple</asp:Label></td>
                       <td><asp:TextBox ID="livingyrsTextBox" Font-Size="Small" style="width:150px; height:20px"  runat="server"></asp:TextBox></td>
                  </tr>

                   <tr>
                      <td><asp:Label ID="Label90" runat="server" Font-Size="Medium" Text="Label">Professional/Designation</asp:Label></td>
                      <td></td>
                      <td><asp:Label ID="Label103" runat="server" Font-Size="Medium" Text="Label">Male</asp:Label></td>
                      <td><asp:TextBox ID="pdesginationTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label104" runat="server" Font-Size="Medium" Text="Label">Female</asp:Label></td>
                      <td><asp:TextBox ID="sdesignationTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>

                  </tr>

                   <tr>
                      <td><asp:Label ID="Label334" runat="server" Font-Size="Medium" Text="Company Name" BorderStyle="None"></asp:Label></td>
                      <td><asp:TextBox ID="companynameTextBox" Font-Size="Small" runat="server" Height="30px" TextMode="MultiLine" Width="251px"></asp:TextBox></td>
                      <td><asp:Label ID="Label335" runat="server" Font-Size="Medium" Text="GSTIN No" BorderStyle="None"></asp:Label></td>
                      <td><asp:TextBox ID="gstinTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>
                        <td><asp:Label ID="Label336" runat="server" Font-Size="Medium" Text="Pan Card #" BorderStyle="None"></asp:Label></td>
                      <td><asp:TextBox ID="companypanoTextBox" Font-Size="Small" style="width:150px; height:20px" runat="server"></asp:TextBox></td>

                  </tr>
                  <tr>
                    <td><asp:Label ID="Label105" runat="server" Font-Size="Medium" Text="Label">Photo Identity</asp:Label></td>
                    <td><select multiple="multiple" style="width:155px; height:70px" id="phid" name="pidentity">
                        <option value="Membership Card">Membership Card(if member with any club)</option>
                          <option value="Driving License">Driving License</option>
                          <option value="Pan Card">PAN Card</option>                         
                          <option value="Passport">Passport</option>
                         <option value="Adhar Card">Adhar Card</option>
                          <option value="Others">Others</option>


                        </select></td>
                    <td><asp:Label ID="Label106" runat="server" Font-Size="Medium" Text="Label">Kind Of Card</asp:Label></td>
                     <td><select multiple="multiple" style="width:155px; height:70px"id="card" name="card">
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
      
   <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs2" type="checkbox" onclick="shows2();"/>
       
 <label for="chs2">SUB PROFILE 1</label>      
        <div id="panel" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />
            <table style="width:100%;">
           <tbody>

               <tr>
                   <td><asp:Label ID="Label200" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                   <td><asp:DropDownList ID="sp1titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                    <td><asp:Label ID="Label36" runat="server"  Text="Label">First Name</asp:Label></td>
                    <td><asp:TextBox ID="sp1fnameTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label37" runat="server" Text="Label">Last Name</asp:Label></td>
                    <td><asp:TextBox ID="sp1lnameTextBox" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    <td><asp:Label ID="Label38" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                    <td><asp:TextBox ID="sp1dobdatepicker" Font-Size="Small" runat="server" style="width:170px; height:20px" Enabled="True"></asp:TextBox></td>
                    
               </tr>

               <tr>
                   <td></td>
                   <td></td>
                   <td><asp:Label ID="Label42" runat="server" Text="Label">Nationality</asp:Label></td>
                   <td><asp:DropDownList ID="sp1nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td><asp:Label ID="Label43" runat="server" Text="Label">Country</asp:Label></td>
                   <td><asp:DropDownList ID="sp1countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                   <td><asp:Label ID="Label109" runat="server" Text="Label">Age</asp:Label></td>
                   <td><asp:TextBox ID="subProfile1Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                  
               </tr>
               <tr>
                   <td></td>
                   <td></td>
                    <td><asp:Label ID="Label45" runat="server" Text="Label">Mobile Number</asp:Label></td>
                    <td> <asp:DropDownList ID="sp1mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1mobileTextBox" style="width:95px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
                    <td> <asp:Label ID="Label46" runat="server" Text="Label">Alternate Number</asp:Label></td>
                    <td><asp:DropDownList ID="sp1alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp1alternateTextBox" runat="server" style="width:95px;  height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                     <td><asp:Label ID="Label44" runat="server" Text="Label">Email</asp:Label></td>
                   <td><asp:TextBox ID="sp1pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
               </tr>
           </tbody>
       </table>
          <br />
          <br /> 
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

            <table  style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label78" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="sp2titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label47" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sp2fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label48" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="sp2lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label49" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                         <td><asp:TextBox ID="sp2dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                   
                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label50" runat="server" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="sp2nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label51" runat="server" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="sp2countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label110" runat="server" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="subProfile2Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                   
                    </tr>

                    <tr> 
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label53" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp2mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2mobileTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label54" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp2alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp2alternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label52" runat="server" Text="Label">Email</asp:Label></td>
                         <td><asp:TextBox ID="sp2pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                </tbody>
                
            </table>
          <br />
          <br />    
    </div>
         <br />
     <br />
   </div>

             <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs3a" type="checkbox" onclick="shows3a();"/>
 <label for="chs3a">SUB PROFILE 3</label>      
        <div id="panel3" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />

            <table  style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label129" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="sp3titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label130" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sp3fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label131" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="sp3lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label132" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                         <td><asp:TextBox ID="sp3dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                  
                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label133" runat="server" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="sp3nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label134" runat="server" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="sp3countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label135" runat="server" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="subProfile3Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>

                    </tr>
                          
                    <tr> 
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label136" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp3mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp3mobileTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label137" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp3alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp3alternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label138" runat="server" Text="Label">Email</asp:Label></td>
                         <td><asp:TextBox ID="sp3pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    
                </tbody>
            </table>
          <br />
          <br />    
    </div>
         <br />
     <br />
   </div>


        
             <div style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
<input id="chs4a" type="checkbox" onclick="shows4a();"/>
 <label for="chs4a">SUB PROFILE 4</label>      
        <div id="panel4" style="background-color:#e9e9e9;padding-top:10px;padding-left:5px;padding-right:5px;">
        <hr />
            <br />

            <table  style="width:100%;">
                <tbody>
                    <tr>
                        <td><asp:Label ID="Label139" runat="server" Font-Size="Medium" Text="Label">Title</asp:Label></td>
                        <td><asp:DropDownList ID="sp4titleDropDownList" Font-Size="Small" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label140" runat="server" Text="Label">First Name</asp:Label></td>
                         <td><asp:TextBox ID="sp4fnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label141" runat="server" Text="Label">Last Name</asp:Label></td>
                         <td><asp:TextBox ID="sp4lnameTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label142" runat="server" Text="Label">Date Of Birth</asp:Label></td>
                         <td><asp:TextBox ID="sp4dobdatepicker" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                         <td><asp:Label ID="Label143" runat="server" Text="Label">Nationality</asp:Label></td>
                         <td><asp:DropDownList ID="sp4nationalityDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label144" runat="server" Text="Label">Country</asp:Label></td>
                         <td><asp:DropDownList ID="sp4countryDropDownList" Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                         <td><asp:Label ID="Label145" runat="server" Text="Label">Age</asp:Label></td>
                         <td><asp:TextBox ID="subProfile4Age" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                          

                    </tr>     
                    <tr>     
                         <td></td>
                        <td></td>
                         <td><asp:Label ID="Label155" runat="server" Text="Label">Mobile Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp4mobileDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp4mobileTextBox" style="width:95px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label156" runat="server" Text="Label">Alternate Number</asp:Label></td>
                         <td><asp:DropDownList ID="sp4alternateDropDownList" Font-Size="Small" style="width:70px; height:25px" runat="server"></asp:DropDownList>&nbsp;<asp:TextBox ID="sp4alternateTextBox" runat="server" style="width:95px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td><asp:Label ID="Label157" runat="server" Text="Label">Email</asp:Label></td>
                         <td><asp:TextBox ID="sp4pemailTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>
          <br />
          <br />    
    </div>
         <br />
     <br />
   </div>



 
        <div style="padding-top:10px;padding-left:5px;padding-right:5px;">
        <h3>STAY DETAILS</h3>
        <hr />
        <br />
           
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td> <asp:Label ID="Label55" runat="server" Text="Label">Resort Name</asp:Label></td>
                         <td>   <asp:TextBox ID="resortTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label56" runat="server" Text="Label">Resort Room No</asp:Label></td>
                         <td> <asp:TextBox ID="roomnoTextBox" Font-Size="Small" style="width:170px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label57" runat="server" Text="Label">Arrival</asp:Label></td>
                         <td> <asp:TextBox ID="arrivaldatedatepicker" style="width:170px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label58" runat="server" Text="Label">Departure</asp:Label></td>
                        <td><asp:TextBox ID="departuredatedatepicker" style="width:170px; height:20px" Font-Size="Small" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label59" runat="server" Text="Label">Choose Gift Option</asp:Label></td>
                        <td>
                            <select multiple="multiple" style="width: 165px; height: 70px" id="giftoptionDropDownList" name="giftoptionDropDownList">
                                <%Response.Write(loadGifts()); %>
                            </select>

                        </td>
                        <td> <asp:Label ID="Label60" runat="server" Text="Label">Voucher No.</asp:Label></td>
                        <td><asp:TextBox ID="TextBox13" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                        <td> <asp:Label ID="Label61" runat="server" Text="Label">Comment if Any</asp:Label></td>
                        <td> <asp:TextBox ID="TextBox22" runat="server" style="width:170px; height:30px" Font-Size="Small" Enabled="True" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                        <td> <asp:Label ID="Label62" runat="server" Text="Label">Guest Status</asp:Label></td>
                        <td><asp:DropDownList ID="guestatusDropDownList" style="width:175px; height:25px" Font-Size="Small"  runat="server"></asp:DropDownList></td>
                    </tr>
                  
                    <tr>
                        <td><asp:Label ID="Label202" runat="server" Text="Tour Date"></asp:Label></td>
                         <td><asp:TextBox ID="tourdatedatepicker" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label63" runat="server" Text="Label">Sales Represntative</asp:Label></td>
                         <td><asp:DropDownList ID="toursalesrepDropDownList"  Font-Size="Small" style="width:175px; height:25px" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td> <asp:Label ID="Label64" runat="server" Text="Label">Sales Deck Check-In Time</asp:Label></td>
                         <td><asp:TextBox ID="timeinTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label65" runat="server" Text="Label">Sales Deck Check-Out Time</asp:Label></td>
                         <td><asp:TextBox ID="timeoutTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> <asp:Label ID="Label66" runat="server" Text="Label">Taxi in Price</asp:Label></td>
                         <td><asp:TextBox ID="inpriceTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label67" runat="server" Text="Label">Taxi in Reference</asp:Label></td>
                         <td><asp:TextBox ID="inrefTextBox" runat="server" style="width:170px; height:20px" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td><asp:Label ID="Label68" runat="server" Text="Label">Taxi out Price</asp:Label></td>
                         <td><asp:TextBox ID="outpriceTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                         <td> <asp:Label ID="Label69" runat="server" Text="Label">Taxi out Reference</asp:Label></td>
                         <td> <asp:TextBox ID="outrefTextBox" style="width:170px; height:20px" runat="server" Font-Size="Small" Enabled="True"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>

            <table style="width: 56.5%;">

                <tr>
                    <td>
                        <asp:Label ID="Label33" runat="server" Font-Size="Medium" Text="Comments" BorderStyle="None"></asp:Label></td>
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
        <br />
        </div>
        <%-- <input type="button" />&nbsp;&nbsp;
          <asp:Button ID="btn" runat="server" Text="Button" OnClientClick="return false;" Visible="False"/>
    --%>
       
</div>
      <br />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Btn1" runat="server" Text="Next Step" OnClientClick="return false;" />&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="Button1" runat="server" Text="Client Details" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Edit" Width="65px" />
  </div>

    <div id="tabs-2" style="background-color:#e9e9e9">
   
       <div id="contract_tab" style="margin-top:10px;margin-left:5px;margin-right:5px; margin-bottom:10px; border:thin solid #999999; overflow:hidden; ">
        
           <br />
            <table style="width:100%;">
                <tbody>
                <tr>
                    <td class="auto-style1"> <asp:Label ID="Label206" runat="server"  BorderStyle="None" Font-Size="Medium" style="width:200px;"  Text="Choose Contract Type:"></asp:Label></td>
                    <td> <asp:DropDownList ID="contracttypeDropDownList" runat="server" Font-Size="Small" style="width:200px; height:25px" onchange="contracttype();"></asp:DropDownList></td>
                  
                </tr>
                    
                <tr><td></td></tr>
                <tr>
                    <td class="auto-style1"><asp:Label ID="Label82" runat="server" Text="Sales Rep" BorderStyle="None" Font-Size="Medium"></asp:Label> </td>
                    <td><asp:DropDownList ID="contsalesrepDropDownList" Font-Size="Small" style="width:200px; height:25px" runat="server"></asp:DropDownList></td>
                    <td><asp:Label ID="Label83" runat="server" Text="TO Manager" BorderStyle="None" Font-Size="Medium"></asp:Label></td>
                    <td><asp:DropDownList ID="TOManagerDropDownList" runat="server" Font-Size="Small" style="width:200px; height:25px"><asp:ListItem></asp:ListItem></asp:DropDownList></td>
                    <td><asp:Label ID="Label84" runat="server" Text="Button Up" BorderStyle="None" Font-Size="Medium"></asp:Label></td>
                    <td><asp:DropDownList ID="ButtonUpDropDownList" Font-Size="Small" runat="server" style="width:200px; height:25px"><asp:ListItem></asp:ListItem></asp:DropDownList></td>                                   
                </tr>
                     <tr>
                      <td><asp:Label ID="lblLoanBUOfficer" runat="server" Text="Loan BU Officer" BorderStyle="None" Font-Size="Medium"></asp:Label></td>
                     <td><asp:TextBox ID="LoanBUOfficerTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                  </tr>

                 <tr>
                     <td><h5>CONTRACT NUMBER</h5></td>
               </tr>
               <tr>
                <td><asp:Label ID="Label96" runat="server" Font-Size="Medium" Text="Label">Generated Contract #</asp:Label></td>
                <td><asp:TextBox ID="contractnoTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                   
                <td><asp:Label ID="Label203"  Font-Size="Medium" runat="server" Text="Deal Registered Date"></asp:Label></td>
                <td><asp:TextBox ID="dealdateTextBox" style="width:200px; height:20px"  Font-Size="Small" runat="server" Enabled="True" ReadOnly="True"></asp:TextBox></td>
                <td><asp:Label ID="Label204" runat="server"  Font-Size="Medium" Text="Deal Status"></asp:Label></td>
                <td><asp:DropDownList ID="dealstatusDropDownList" style="width:200px;  height:25px" Font-Size="Small"  runat="server"></asp:DropDownList></td>
              </tr>
                <tr>
                <td><asp:Label ID="Label158" runat="server" Font-Size="Medium" Text="Label">Canx Contract #</asp:Label></td>
                <td><asp:TextBox ID="CanxContractNoTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
               
                <td><asp:Label ID="lblContractdetailsID" runat="server" Font-Size="Medium" Text="Contract Details ID" Visible="False"></asp:Label></td>
                <td><asp:TextBox ID="ContractdetailsIDTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True" Visible="False"></asp:TextBox></td>
                </tr> 
                </tbody>
            </table>
           <br /> 
           <table style="width:100%;">
               <tbody>       
            <tr>
                <td width="100px">
                   <div id="check"> 
                       <asp:CheckBox ID="mcRadioButtonList" runat="server" onclick="MCWaiver();" BorderStyle="None" Font-Size="Small" Text="MC Waiver Applicable" Width="165px" EnableViewState="False" /></div>
                </td>
            </tr> 
           </tbody>           
           </table>
         
           <br />
           <div id="contract-container">
          
            <div id="cleft" style="">
                <div id="cdiv1" >
                <table style="width:100%;">
                    <tbody>
                    <tr>
                        <td><h5>FRACTIONAL</h5></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label85" runat="server" Font-Size="Medium" Text="Label">Choose Resort</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="resortDropDownList" runat="server" Font-Size="Small"  style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label70" runat="server" Font-Size="Medium" Text="Label">Residence No.</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="residenceDropDownListno" runat="server" Font-Size="Small" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr> 
                     <tr>
                        <td width="200px"><asp:Label ID="Label71" runat="server" Font-Size="Medium" Text="Label">Choose Residence Type</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="residencetypeDropDownList" runat="server" Font-Size="Small" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                     <tr>
                       <td width="200px"><asp:TextBox ID="testresTextBox" runat="server" Width="200px"></asp:TextBox></td>
                        <td width="100px"><asp:TextBox ID="testresnoTextBox" runat="server"  Width="200px"></asp:TextBox></td>
                         
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="Label72" runat="server" Font-Size="Medium" Text="Label">Fractional Interest</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="FractionalInterestDropDownList" Font-Size="Small" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label73" runat="server" Font-Size="Medium" Text="Label">Entitlement</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="EntitlementFracDropDownList" Font-Size="Small" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    
                    <tr>
                        <td width="200px"><asp:Label ID="Label74" runat="server" Font-Size="Medium" Text="Label">First Year Occupancy</asp:Label></td>
                        <td><asp:TextBox ID="ffirstyrTextBox" runat="server" Font-Size="Small" style="width:200px; height:20px" onchange="GetFractionalLastYr();" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="Label75" runat="server" Font-Size="Medium" Text="Label">Tenure</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="ftenureTextBox" onchange="GetFractionalLastYr();" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label76" runat="server" Font-Size="Medium" Text="Label">Last Year Occupancy</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="flastyrTextBox" runat="server" Enabled="True" Font-Size="Small" style="width:200px; height:20px"  onclick="add1('TextBox41','TextBox42','TextBox43');"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                        
                         Lease Back?<input type="checkbox" id="chs6" onclick="shows6();"/> <label id="yes2" style="color:forestgreen">YES</label><label id="yess2" style="color:forestgreen">(management charge: 0)</label><label id="no2" style="color: red">NO</label>
                        </td>
                    </tr>
                        </tbody>
                </table>

                </div>
                <div id="cdiv2">

                       <table style="width:100%;">
                    <tr>
                        <td><h5>POINTS</h5></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label94" Font-Size="Medium"  runat="server" Text="Label">Club</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="pointsclubDropDownList"   runat="server" Font-Size="Small"  style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label100" runat="server" Font-Size="Medium"  Text="Label">New Points Rights</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="newpointsrightTextBox" Font-Size="Small" style="width:200px; height:20px" onchange="New_totalPoints();" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="Label97" runat="server" Font-Size="Medium"  Text="Label">Type Of Membership</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="EntitlementPoinDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>                               
                      
                    <tr>
                        <td width="200px"><asp:Label ID="Label102" runat="server" Font-Size="Medium"  Text="Label">Total Points Rights</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="totalptrightsTextBox" Font-Size="Small"  runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lblnopersons" runat="server" Font-Size="Medium"  Text="Label">No.of Persons</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nopersonsTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label95" runat="server" Font-Size="Medium"  Text="Label">First Year Occupancy</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="firstyrTextBox" Font-Size="Small" style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="Label98" Font-Size="Medium"  runat="server" Text="Label">Tenure</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tenureTextBox" Font-Size="Small" style="width:200px; height:20px" onchange="GetLastYr();" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="Label99" runat="server" Font-Size="Medium"  Text="Label">Last Year Occupancy</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="lastyrTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr>

                    </table>
                     <asp:TextBox ID="pointsamtTextBox" runat="server" Enabled="True"  ></asp:TextBox>
                   <asp:TextBox ID="pointstaxTextBox" runat="server" Enabled="True"  ></asp:TextBox>
                        <asp:TextBox ID="testTextBox" runat="server" Enabled="True"   Visible="true"  ></asp:TextBox>
                        <asp:TextBox ID="AffiliationamtTextBox" runat="server" Enabled="True" Visible="true"  ></asp:TextBox>
                        <asp:TextBox ID="incrTextBox" runat="server" Enabled="True"   Visible="true"  ></asp:TextBox>
                      <asp:TextBox ID="findocfeeTextBox" runat="server" Enabled="True"   Visible="true"  ></asp:TextBox>
                      <asp:TextBox ID="igstamtTextBox" runat="server" Enabled="True"   Visible="true"  ></asp:TextBox>
                    <asp:TextBox ID="lastfingennoTextBox" runat="server" Enabled="True"   Visible="true"  ></asp:TextBox>
                      <asp:TextBox ID="AffiliationvalueTextBox" runat="server" Enabled="True"   Visible="true"  ></asp:TextBox>
                </div>
               
                 <div id="cdivtradeinweeks">
                     
                       <table style="width:100%;">
                    <tr>
                        <td><h5>TRADE IN DETAILS</h5></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lbltmresort" Font-Size="Medium"  runat="server" Text="Label">Resort</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tnmresortTextBox" Font-Size="Small"  runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lbltmapttype" runat="server" Font-Size="Medium"  Text="Label">Apt Type</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tnmapttypeTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lbltnmseason" runat="server" Font-Size="Medium"  Text="Label">Season</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="tnmseasonDropDownList" Font-Size="Small" style="width:205px; height:25px" runat="server" ></asp:DropDownList></td>
                    </tr>                               
                      
                    <tr>
                        <td width="200px"><asp:Label ID="lnltnmnowks" runat="server" Font-Size="Medium"  Text="Label">No.Of Weeks</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmnowksTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lbltnmcontrcino" runat="server" Font-Size="Medium"  Text="Label">Cont.No / Rci No</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmcontrcinoTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lbltnmpointsvalue" Font-Size="Medium"  runat="server" Text="Label">Points Value</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmpointsvalueTextBox" Font-Size="Small"  style="width:200px; height:20px"  onchange="Tradeintoweekscalculation();"   runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>  
                           <tr>
                        <td><h5>NEW DETAILS</h5></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lblnmclub" Font-Size="Medium"  runat="server" Text="Label">Club</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="nmclubDropDownList" runat="server" Font-Size="Small"  style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lblnmnewpointsrights" runat="server" Font-Size="Medium"  Text="Label">New Points Rights</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmnewpointsrightsTextBox" Font-Size="Small" style="width:200px; height:20px" onchange="Tradeintoweekscalculation();" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lblnmembtype" runat="server" Font-Size="Medium"  Text="Label">Type Of Membership</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="nmembtypeDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>                               
                      
                    <tr>
                        <td width="200px"><asp:Label ID="lblnmtotalpoints" runat="server" Font-Size="Medium"  Text="Label">Total Points Rights</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmtotalpointsTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lblnmnopersons" runat="server" Font-Size="Medium"  Text="Label">No.of Persons</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmnopersonsTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lblnmfirstyr" runat="server" Font-Size="Medium"  Text="Label">First Year Occupancy</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmfirstyrTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lblnmtenure" Font-Size="Medium"  runat="server" Text="Label">Tenure</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmtenureTextBox" Font-Size="Small" style="width:200px; height:20px" onchange="TradeintoweeksOccupancyCalculation();" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lblnmlastyr" runat="server" Font-Size="Medium"  Text="Label">Last Year Occupancy</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="nmlastyrTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr>                

                    </table>
                    
                    
                </div>
                <div id="cdivtradeinpoints" >

                       <table style="width:100%;">
                    <tr>
                        <td><h5>TRADE IN DETAILS</h5></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbltipresort" Font-Size="Medium"  runat="server" Text="Label">Resort/Club</asp:Label></td>
                        <td><asp:TextBox ID="tipresortTextBox" Font-Size="Small" runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>                  
                    
                    <tr>
                        <td><asp:Label ID="lbltipnopoints" runat="server" Font-Size="Medium"  Text="Label">No. Of Points</asp:Label></td>
                        <td><asp:TextBox ID="tipnopointsTextBox" Font-Size="Small"  onchange="Tradeintopointscalculation();"  style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbltipcontno" runat="server" Font-Size="Medium"  Text="Label">Cont.No / Rci No</asp:Label></td>
                        <td><asp:TextBox ID="tipcontnoTextBox" Font-Size="Small"  style="width:200px; height:20px"   runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lbltipptsvalue" Font-Size="Medium"  runat="server" Text="Label">Points Value</asp:Label></td>
                        <td><asp:TextBox ID="tipptsvalueTextBox" Font-Size="Small"  style="width:200px; height:20px"  onchange="Tradeintopointscalculation();"   runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>  
                           <tr>
                        <td><h5>NEW POINTS DETAILS</h5></td>
                    </tr>
                    <tr>                        
                        <td width="100px"><asp:Label ID="lblntipclub" Font-Size="Medium"  runat="server" Text="Label">Club</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="ntipclubDropDownList" runat="server" Font-Size="Small"  style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="100px"><asp:Label ID="lbltipnewpoints" runat="server" Font-Size="Medium"  Text="Label">New Points Rights</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tipnewpointsTextBox" Font-Size="Small" onchange="Tradeintopointscalculation();" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lbltipmtype" runat="server" Font-Size="Medium"  Text="Label">Type Of Membership</asp:Label></td>
                        <td width="100px"><asp:DropDownList ID="tipmtypeDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>                               
                      
                    <tr>
                        <td width="200px"><asp:Label ID="lbltiptotalpoints" runat="server" Font-Size="Medium"  Text="Label">Total Points Rights</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tiptotalpointsTextBox" Font-Size="Small"  runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lbltipnopersons" runat="server" Font-Size="Medium"  Text="Label">No.of Persons</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tipnopersonsTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lbltipfirstyr" runat="server" Font-Size="Medium"  Text="Label">First Year Occupancy</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tipfirstyrTextBox" Font-Size="Small"   runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td width="200px"><asp:Label ID="lbltiptenure" Font-Size="Medium"  runat="server" Text="Label">Tenure</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tiptenureTextBox" Font-Size="Small" style="width:200px; height:20px" onchange="TradeintopointsOccupancyCalculation();" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px"><asp:Label ID="lbltiplastyr" runat="server" Font-Size="Medium"  Text="Label">Last Year Occupancy</asp:Label></td>
                        <td width="100px"><asp:TextBox ID="tiplastyrTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True" ></asp:TextBox></td>
                    </tr> 
                    </table>
                    
                </div>
                
            <div id="cdiv3">
               <table style="width:100%;">
                   <tbody>
                     <tr>
                        <td><h5>OLD CONTRACT DETAILS</h5></td>
                    </tr>
                    <tr>
                    <td width="200px"><asp:Label ID="Label111" Font-Size="Medium" runat="server" Text="Label">From Contract Type</asp:Label></td>
                    <td width="100px"><asp:DropDownList ID="oldcontracttypeDropDownList" runat="server" onchange="ViewFractionalTradeIntype();"  style="width:205px; height:25px"></asp:DropDownList></td>
                    <td width="100px"><asp:TextBox ID="oldcontracttypeTextBox" Font-Size="Small" runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>
                    </tbody>
                   </table>
                </div>
                <div id="fractionalweeks">
               <table style="width:100%;">
                   <tbody>
                    <tr>
                        <td><h5>TRADE IN DETAILS</h5></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwresorttrade" Font-Size="Medium"  runat="server" Text="Label">Resort</asp:Label></td>
                        <td><asp:TextBox ID="fwresorttradeTextBox" Font-Size="Small" runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwapt" runat="server" Font-Size="Medium"  Text="Label">Apt Type</asp:Label></td>
                        <td><asp:TextBox ID="fwaptTextBox" Font-Size="Small" style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfwseason" runat="server" Font-Size="Medium"  Text="Label">Season</asp:Label></td>
                        <td><asp:DropDownList ID="fwseasonDropDownList" Font-Size="Small" style="width:205px; height:25px"   runat="server" ></asp:DropDownList></td>
                    </tr>                               
                      
                    <tr>
                        <td><asp:Label ID="lblfwnowks" runat="server" Font-Size="Medium"  Text="Label">No.Of Weeks</asp:Label></td>
                        <td><asp:TextBox ID="fwnowksTextBox" Font-Size="Small"   style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    
                     <tr>
                        <td><asp:Label ID="lblfwptsvalue" Font-Size="Medium"  runat="server" Text="Label">Points Value</asp:Label></td>
                        <td><asp:TextBox ID="fwptsvalueTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr> 
                    <tr>
                        <td><asp:Label ID="lblfwconno" runat="server" Text="Label">Contract No.</asp:Label></td>
                        <td><asp:TextBox ID="fwconnoTextBox" runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                        <tr>
                        <td><asp:Label ID="lblftradeinamt" runat="server" Text="Label">Trade In Value</asp:Label></td>
                        <td><asp:TextBox ID="ftradeinamtTextBox" runat="server" onchange="fractionaltradeinamt();" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                       <tr>
                <td width="100px" ><asp:Label ID="lblfoldloanagreementno" runat="server" Font-Size="Small" Text="Label">Old Loan Agreement No</asp:Label></td>
                <td width="100px"><asp:TextBox ID="foldloanagreementnoTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>
                 <tr>
                <td width="100px" ><asp:Label ID="lblfoldloanamount" runat="server" Font-Size="Small" Text="Label">Old Loan Amount</asp:Label></td>
                <td width="100px"><asp:TextBox ID="foldloanamountTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>
                    <tr>
                        <td><h5>TRADE INTO FRACTIONAL</h5></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwresort" runat="server" Text="Label">Choose Resort</asp:Label></td>
                        <td><asp:DropDownList ID="fwresortDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwresidenceno" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:DropDownList ID="fwresidencenoDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwresidenceno1" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:TextBox ID="fwresidenceno1TextBox" runat="server" style="width:200px; height:25px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfwresidencetype" runat="server" Text="Label">Choose Residence Type</asp:Label></td>
                        <td><asp:DropDownList ID="fwresidencetypeDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                   <tr>
                        <td><asp:Label ID="lblfwresidencetype1" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:TextBox ID="fwresidencetype1TextBox" runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfwfractInt" runat="server" Text="Label">Fractional Interest</asp:Label></td>
                        <td><asp:DropDownList ID="fwfractIntDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwentitlement" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td><asp:DropDownList ID="fwentitlementDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwfirstyr" runat="server" Text="Label">First Year Occupancy</asp:Label></td>
                        <td><asp:TextBox ID="fwfirstyrTextBox" runat="server" style="width:200px; height:20px" onchange="GetFractionalWeekLastYr();" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfwtenure" runat="server" Text="Label">Tenure</asp:Label></td>
                        <td><asp:TextBox ID="fwtenureTextBox" runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfwlastyr" runat="server" Text="Label">Last Year Occupancy</asp:Label></td>
                        <td><asp:TextBox ID="fwlastyrTextBox" runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px">
                        Lease Back?<input type="checkbox" id="chs5" onclick="shows5();"/> <label id="yes1" style="color:forestgreen">YES</label><label id="yess1" style="color:forestgreen">(management charge: 0)</label><label id="no1" style="color: red">NO</label>
                        </td>
                    </tr>
                       </tbody>
                </table>


            </div>
                 <div id="fractionaltofractionals">
               <table style="width:100%;">
                   <tbody>
                    <tr>
                        <td><h5>TRADE IN DETAILS</h5></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblffresorttrade" Font-Size="Medium"  runat="server" Text="Label">Resort</asp:Label></td>
                        <td><asp:TextBox ID="ffresorttradeTextBox" Font-Size="Small" runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblffapt" runat="server" Font-Size="Medium"  Text="Label">Apt Type</asp:Label></td>
                        <td><asp:TextBox ID="ffaptTextBox" Font-Size="Small" style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                                               
                      
                    <tr>
                        <td><asp:Label ID="lblffnowks" runat="server" Font-Size="Medium"  Text="Label">No.Of Weeks</asp:Label></td>
                        <td><asp:TextBox ID="ffnowksTextBox" Font-Size="Small"   style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    
                      
                    <tr>
                        <td><asp:Label ID="lblffconno" runat="server" Text="Label">Contract No.</asp:Label></td>
                        <td><asp:TextBox ID="ffconnoTextBox" runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                        <tr>
                        <td><asp:Label ID="lblfftradeinamt" runat="server" Text="Label">Trade In Value</asp:Label></td>
                        <td><asp:TextBox ID="fftradeinamtTextBox" runat="server" onchange="fractionaltradeinamt();" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                       <tr>
                <td width="100px" ><asp:Label ID="lblffoldloanagreementno" runat="server" Font-Size="Small" Text="Label">Old Loan Agreement No</asp:Label></td>
                <td width="100px"><asp:TextBox ID="ffoldloanagreementnoTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>
                 <tr>
                <td width="100px" ><asp:Label ID="lblffoldloanamount" runat="server" Font-Size="Small" Text="Label">Old Loan Amount</asp:Label></td>
                <td width="100px"><asp:TextBox ID="ffoldloanamountTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>
                    <tr>
                        <td><h5>TRADE INTO FRACTIONAL</h5></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblffresort" runat="server" Text="Label">Choose Resort</asp:Label></td>
                        <td><asp:DropDownList ID="ffresortDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblffresidenceno" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:DropDownList ID="ffresidencenoDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblffresidenceno1" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:TextBox ID="ffresidenceno1TextBox" runat="server" style="width:200px; height:25px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblffresidencetype" runat="server" Text="Label">Choose Residence Type</asp:Label></td>
                        <td><asp:DropDownList ID="ffresidencetypeDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                   <tr>
                        <td><asp:Label ID="lblffresidencetype1" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:TextBox ID="ffresidencetype1TextBox" runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfffractInt" runat="server" Text="Label">Fractional Interest</asp:Label></td>
                        <td><asp:DropDownList ID="fffractIntDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblffentitlement" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td><asp:DropDownList ID="ffentitlementDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfffirstyr" runat="server" Text="Label">First Year Occupancy</asp:Label></td>
                        <td><asp:TextBox ID="fffirstyrTextBox" runat="server" style="width:200px; height:20px" onchange="GetFractionalWeekLastYr();" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label124" runat="server" Text="Label">Tenure</asp:Label></td>
                        <td><asp:TextBox ID="fftenureTextBox" runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label125" runat="server" Text="Label">Last Year Occupancy</asp:Label></td>
                        <td><asp:TextBox ID="fflastyrTextBox" runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px">
                        Lease Back?<input type="checkbox" id="chs8" onclick="shows8();"/> <label id="TIFyes1" style="color:forestgreen">YES</label><label id="TIFyess1" style="color:forestgreen">(management charge: 0)</label><label id="TIFno1" style="color: red">NO</label>
                        </td>
                    </tr>
                       </tbody>
                </table>
            </div>
                 <div id="fractionalpoints">
               <table style="width:100%;">
                   <tbody>
                    <tr>
                        <td><h5>TRADE IN DETAILS</h5></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfptsclub" Font-Size="Medium"  runat="server" Text="Label">Resort/Club</asp:Label></td>
                        <td><asp:TextBox ID="fptsclubTextBox" Font-Size="Small"  runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>                  
                    
                    <tr>
                        <td><asp:Label ID="lblfptsnopts" runat="server" Font-Size="Medium"  Text="Label">No.Of Points</asp:Label></td>
                        <td><asp:TextBox ID="fptsnoptsTextBox" Font-Size="Small"  onchange="FractionalTradeintopointscalculation();"  style="width:200px; height:20px"  runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfptscontno" runat="server" Font-Size="Medium"  Text="Label">Cont.No / Rci No</asp:Label></td>
                        <td><asp:TextBox ID="fptscontnoTextBox" Font-Size="Small"  style="width:200px; height:20px"   runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfptsval" Font-Size="Medium"  runat="server" Text="Label">Points Value</asp:Label></td>
                        <td><asp:TextBox ID="fptsvalTextBox" Font-Size="Small"  style="width:200px; height:20px"   runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>  
                    <tr>
                        <td><asp:Label ID="lblfptradeinamt" Font-Size="Medium"  runat="server" Text="Label">Trade In Value</asp:Label></td>
                        <td><asp:TextBox ID="fptradeinamtTextBox" Font-Size="Small" onchange="fractionaltradeinamt();"  style="width:200px; height:20px"   runat="server" Enabled="True"></asp:TextBox></td>
                    </tr>  
                       <tr>
                <td width="100px" ><asp:Label ID="lbloldLoanAgreement" runat="server" Font-Size="Small" Text="Label">Old Loan Agreement No</asp:Label></td>
                <td width="100px"><asp:TextBox ID="oldLoanAgreementTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>
                         <tr>
                <td width="100px" ><asp:Label ID="lbloldloanamount" runat="server" Font-Size="Small" Text="Label">Old Loan Amount</asp:Label></td>
                <td width="100px"><asp:TextBox ID="oldloanamountTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>
                    <tr>
                        <td><h5>TRADE INTO FRACTIONAL</h5></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfptsresort" runat="server" Text="Label">Choose Resort</asp:Label></td>
                        <td><asp:DropDownList ID="fptsresortDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfptsResidenceno" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:DropDownList ID="fptsResidencenoDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfptsResidenceno1" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:TextBox ID="fptsResidenceno1TextBox" runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfptsresidencetype" runat="server" Text="Label">Choose Residence Type</asp:Label></td>
                        <td><asp:DropDownList ID="fptsresidencetypeDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                   <tr>
                        <td><asp:Label ID="lblfptsresidencetype1" runat="server" Text="Label">Residence No.</asp:Label></td>
                        <td><asp:TextBox ID="fptsresidencetype1TextBox" runat="server" style="width:200px; height:20px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfptsfracint" runat="server" Text="Label">Fractional Interest</asp:Label></td>
                        <td><asp:DropDownList ID="fptsfracintDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfptsentitlement" runat="server" Text="Label">Entitlement</asp:Label></td>
                        <td><asp:DropDownList ID="fptsentitlementDropDownList" runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfptsfirstyr" runat="server" Text="Label">First Year Occupancy</asp:Label></td>
                        <td><asp:TextBox ID="fptsfirstyrTextBox" runat="server" style="width:200px; height:20px" onchange="GetFractionalPointsLastYr();" Enabled="True"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfptstenure" runat="server" Text="Label">Tenure</asp:Label></td>
                        <td><asp:TextBox ID="fptstenureTextBox" runat="server" style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfptslastyr" runat="server" Text="Label">Last Year Occupancy</asp:Label></td>
                        <td><asp:TextBox ID="fptslastyrTextBox" runat="server" style="width:200px; height:20px"  Enabled="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="200px">
                        Lease Back?<input type="checkbox" id="chs7" onclick="shows7();"/> <label id="ptyes1" style="color:forestgreen">YES</label><label id="pyess1" style="color:forestgreen">(management charge: 0)</label><label id="pno1" style="color: red">NO</label>
                        </td>
                    </tr>
                       </tbody>
                </table>


            </div>
                <div id="cdiv4" >                    
                </div>
            </div>
                <div id="financetitle" style=" width:605px;">
                   <table style="width:100%;">
                   <tr>
                        <td width="100px">
                        <h5>FINANCE</h5>
                        </td>
                        <td><asp:RadioButtonList ID="financeradiobuttonlist" onchange="Radiobuttonlistdisplay();" runat="server"  Font-Size="large"  RepeatDirection="Horizontal">
                            <asp:ListItem>Finance</asp:ListItem>
                            <asp:ListItem>Non Finance</asp:ListItem>                             
                        </asp:RadioButtonList></td>
                       </tr>
                   
                     </table>
               </div>
              
            <div id="cright" style=" width:605px;">
                
            <table  cellpadding="3px" cellspacing="3px"> 
              <tr>
                <td width="100px"><asp:Label ID="lblMCFees" runat="server" Font-Size="Small" Text="Label">MC Fees</asp:Label></td>
                <td width="100px"><asp:TextBox ID="MCFeesTextBox"  Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
            </tr>  
                 
            <tr>
                <td width="100px"><asp:Label ID="Label77" runat="server" Font-Size="Small" Width="75px" Text="Label">CURRENCY</asp:Label></td>
                <td width="80px"><asp:DropDownList ID="currencyDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>            
            </tr>  
                <tr>
                    <td width="100px"><asp:Label ID="Label79" runat="server" Font-Size="Small" Text="Label">AFFILIATE TYPE</asp:Label></td>
                   <td  width="200px"> 
                     <input id="ca1" type="checkbox" onchange="PointsPurchase1(); CheckboxValue();"  /><asp:Label ID="lblchk1" runat="server" Font-Size="Small" Text="Label">Emerald</asp:Label>
                     <input id="ca2" type="checkbox" onchange="PointsPurchase1();  CheckboxValue();"   /><asp:Label ID="lblchk2" runat="server" Font-Size="Small" Text="Label">Holiday Plus</asp:Label><br />
                     <input id="ca3" type="checkbox" onchange="PointsPurchase1();  CheckboxValue();"  /><asp:Label ID="lblchk3" runat="server" Font-Size="Small" Text="Label">Registry Collection</asp:Label></td>
                </tr>  
                <tr>
                <td width="100px"><asp:Label ID="lblregcoll" runat="server" Font-Size="Small"  Width="100px" Text="Label">REGISTRY COLLECTION TERM</asp:Label></td>
                <td width="100px"><asp:TextBox ID="regcollectiontermTextBox"   Font-Size="Small" style="width:200px; height:20px" runat="server"  Text="5"></asp:TextBox></td>
              
            </tr>    
                <tr>
                <td width="100px"><asp:Label ID="lblregcollamt" runat="server" Font-Size="Small"  Width="100px" Text="Label">REGISTRY COLLECTION AMOUNT</asp:Label></td>
                <td width="100px"><asp:TextBox ID="regcollamtTextBox"   Font-Size="Small" style="width:200px; height:20px" runat="server"></asp:TextBox></td>
              
            </tr>    
                  <tr>
                <td width="100px"><asp:Label ID="lbladminamtfees" runat="server" Font-Size="Small"  Width="100px" Visible="false" Text="Label">ADMIN FEE</asp:Label></td>
                <td width="100px"><asp:TextBox ID="adminamtfeesTextBox" onchange="PointsPurchase1();" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
              
            </tr> 
             <tr>
                <td width="100px"><asp:Label ID="Label101" runat="server" Font-Size="Small"  Width="100px" Text="Label">TOTAL PRICE INCLUDING TAX</asp:Label></td>
                <td width="100px"><asp:TextBox ID="totalfinpriceIntaxTextBox" onchange="PointsPurchase1(); Procedure_Generation_Contract1();" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>
              
            </tr> 
             <tr>
                <td width="100px"><asp:Label ID="lblinitialdeppercent" runat="server" Font-Size="Small"    Text="Label">DEPOSIT AMOUNT</asp:Label></td> 
                <td width="100px"><asp:TextBox ID="intialdeppercentTextBox" onchange="InitialDepositCalculation1();" Font-Size="Small" runat="server" Enabled="True"    style="width:200px; height:20px"></asp:TextBox></td>
            </tr> 
               
            <tr>
                <td width="100px"><asp:Label ID="lblinitaldepamt" runat="server" Font-Size="Small" Text="Label">INITIAL DEPOSIT AMOUNT</asp:Label></td>
                <td width="100px"><asp:TextBox ID="initaldepamtTextBox" runat="server" style="width:200px; height:20px" Font-Size="Small" Enabled="True"  ></asp:TextBox></td>
                </tr>
                <tr>
                <td width="100px"><asp:Label ID="lblbaladepamt" runat="server" Font-Size="Small" Text="Label">BALANCE PAYABLE(INITIAL DEPOSIT)</asp:Label></td>
                <td width="100px"><asp:TextBox ID="baldepamtTextBox" runat="server" Enabled="True" onchange="AmountBreakupCalculation();"  Font-Size="Small" style="width:200px; height:20px" ></asp:TextBox></td>
              </tr> 
                <tr>
                <td width="100px"><asp:Label ID="lblbaladepamtdate" runat="server" Font-Size="Small" Text="Label">Date</asp:Label></td>
                <td width="100px"><asp:TextBox ID="baladepamtdateTextBox" runat="server" Enabled="True" Font-Size="Small" style="width:200px; height:20px" ></asp:TextBox></td>
              </tr> 

                 <tr>
                <td width="100px"><asp:Label ID="lblfirstdepamt" Font-Size="Small" runat="server" Text="Label">AMOUNT PAYABLE</asp:Label></td>
                <td width="100px"><asp:TextBox ID="firstdepamtTextBox" runat="server" Font-Size="Small" Enabled="True"   style="width:200px; height:20px" ></asp:TextBox></td>
            </tr> 
            <tr>
                <td width="100px"><asp:Label ID="lblbalinitialdep" Font-Size="Small" runat="server" Text="Label">BALANCE DEPOSIT</asp:Label></td>
                <td width="100px"><asp:TextBox ID="balinitialdepamtTextBox" runat="server" Font-Size="Small"  Enabled="True" onchange="InitialBalCalculation();" style="width:200px; height:20px"></asp:TextBox></td><!--onchange="ChangeIntitalBalAmt();"-->
            </tr> 
            
            <tr>
                <td width="100px"><asp:Label ID="Label89" runat="server" Font-Size="Small" Text="Label">PAYMENT METHOD</asp:Label></td>
                <td width="100px"><asp:DropDownList ID="PayMethodDropDownList" onchange="DisplayonPayMethod();" Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
            </tr>
             
             <tr>
                <td width="100px"><asp:Label ID="lblnoinstallment" runat="server" Font-Size="Small" Text="Label"># OF INSTALLMENTS</asp:Label></td>
                <td width="100px"><asp:TextBox ID="NoinstallmentTextBox" Font-Size="Small" onchange="DisplayInstallmentAmt();"  style="width:200px; height:20px" runat="server" Enabled="True" ></asp:TextBox></td>
            </tr> 
              <tr>
                <td width="100px"><asp:Label ID="lblinstallmentamt" runat="server" Font-Size="Small" Text="Label">INSTALLMENT AMOUNT</asp:Label></td>
                <td width="100px"><asp:TextBox ID="installmentamtTextBox" runat="server" Font-Size="Small" Enabled="True"  style="width:200px; height:20px" ></asp:TextBox></td>
            </tr>      
                 <tr>
              <td width="100px"><asp:Label ID="lblbalamtpayable" runat="server" Font-Size="Small" Text="Label">BALANCE AMOUNT</asp:Label></td>
              <td width="100px"><asp:TextBox ID="balamtpayableTextBox" runat="server" Font-Size="Small" Enabled="True"    style="width:200px; height:20px"></asp:TextBox></td>
            </tr> 
                                   
            <tr>
                <td width="100px"><asp:Label ID="lblfinancemethod" runat="server" Font-Size="Small" Text="Label">FINANCE TYPE</asp:Label></td>
                <td width="100px"><asp:DropDownList ID="financemethodDropDownList" onchange="pay_method();"  Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
            </tr>
              
               <tr>
                 <td width="100px"><asp:Label ID="lblfinanceno" runat="server" Font-Size="Small" Text="Label">FINANCE #</asp:Label></td>
                <td width="100px"><asp:TextBox ID="FinancenoTextBox" Font-Size="Small" style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>                
                   </tr>
               
                 <tr>
                <td width="100px"><asp:Label ID="lblnoemi" runat="server" Font-Size="Small" Text="Label">No.EMI #</asp:Label></td>
                <td width="100px"><asp:TextBox ID="noemiTextBox" Font-Size="Small" onchange="LoanEMICalculation();"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>                
               </tr>
                <tr>
                <td width="100px" ><asp:Label ID="lblemiamt" runat="server" Font-Size="Small" Text="Label">EMI Installment</asp:Label></td>
                <td width="100px"><asp:TextBox ID="emiamtTextBox" Font-Size="Small"  style="width:200px; height:20px" runat="server" Enabled="True"></asp:TextBox></td>  
                </tr>
                 <tr>
                <td width="100px"><asp:Label ID="lbldepositmethod" runat="server" Font-Size="Small" Text="Label">DEPOSIT PAYMENT MODE</asp:Label></td>
                <td width="100px"><asp:DropDownList ID="depositmethodDropDownList" Font-Size="Small"  runat="server" style="width:205px; height:25px"></asp:DropDownList></td>
            </tr>
                         
            <tr>
                <td width="200px"><asp:Label ID="Label91" Font-Size="Small" runat="server" Text="Label">IDENTITY PROOF</asp:Label></td>
                <td width="200px"><input id="chs4" type="checkbox" onclick="shows4();"/> <!--<label id="yes" style="color:forestgreen">YES</label><label id="no" style="color: red">NO</label>-->
                </td>
            </tr>                                  
            </table>
                <div>
                <table id="identitytable" >
                  <tr> <!--id="pan"> -->
                <td width="200px"><asp:Label ID="Label92" runat="server"  style="width:210px;"  Font-Size="Small" Text="Label">PAN CARD #</asp:Label></td>
                <td width="200px" ><asp:TextBox ID="pancardnoTextBox" runat="server"   style="width:200px; height:20px"  Font-Size="Small" Enabled="True"></asp:TextBox></td>                
                </tr> 
             <tr> <!--id="adhar">-->
            <td width="200px"><asp:Label ID="Label93" runat="server" style="width:210px;"  Font-Size="Small"  Text="Label">ADHAR CARD #</asp:Label></td>
            <td width="200px"><asp:TextBox ID="adharcardTextBox" runat="server" Font-Size="Small"  style="width:200px; height:20px" Enabled="True"></asp:TextBox></td>                
            </tr> 
                </table>
                    </div>
                <div id="TextBoxContainer">
                    <!--Textboxes will be added here -->
                </div>
                <br />

            </div>
          </div>
           <br />

         
      </div>
        <br />
        <%-- <div id="b1" style="border:thin solid #ff0000; " >
           <asp:Button ID="Btn2" runat="server" Text="Button" Visible="false" OnClientClick="return false;"/>
            </div>--%>
          <asp:Button ID="Btn2" runat="server" Text="Next Step" OnClientClick="return false;" />
   </div>

  <div id="tabs-3" style="background-color:#e9e9e9;">
          <div id="Tab4cont">
              <table>
                  <tr>
                       <td><asp:Label ID="Label113" runat="server" Text="Label">Select Option</asp:Label></td>
                        <td><asp:DropDownList ID="SORDropDownList" runat="server">
                             <asp:ListItem Text=""></asp:ListItem>
                            <asp:ListItem Text="SOR Name"></asp:ListItem>
                            <asp:ListItem Text="Additional Name"></asp:ListItem>
                            </asp:DropDownList> </td>
                  </tr>
                  <tr>
                       <td><asp:Label ID="Label115" runat="server" Text="Label">Enter No</asp:Label></td>
                        <td><asp:TextBox ID="asornoTextBox" runat="server" onchange="SORAdditionalNames();" Enabled="True" Width="328px"></asp:TextBox></td>
                  </tr>
                  </table>
                   </div>
                            <div id="sorheading1">                            
                           <table>
                          <tr>
                              <td width="250px" align="center"><asp:Label ID="Label116" runat="server" Text="Label">Name</asp:Label> </td>
                              <td width="100px" align="center"><asp:Label ID="Label117" runat="server" Text="Label">Address</asp:Label> </td>
                              <td width="250px" align="center"><asp:Label ID="Label118" runat="server" Text="Label">State</asp:Label> </td>
                              <td width="100px" align="center"><asp:Label ID="Label119" runat="server" Text="Label">Country</asp:Label> </td>                              
                               <td width="100px" align="center"><asp:Label ID="Label120" runat="server" Text="Label">Post Code</asp:Label> </td>
                          </tr>
                      </table>
                            <div id="sorDIV">                   
                     
                      
                       </div>
                               
                           
                         <asp:Button ID="Button7" runat="server" Text="Add" OnClick="Button7_Click" Width="55px" /> 
                      </div>
              
              
           

          </div>
       <div id="tabs-4" style="background-color:#e9e9e9;">
          <div id="finance-container1" style="margin-top:10px;padding-top:10px; ">
               <div id="ffractional1" style="overflow:hidden;">            
                   <div id="fract"style="float:left;">
                
                   <h4>PURCHASE AGREEMENT</h4>
                <table cellpadding="5px" cellspacing="5px">                 
                    <tr>
                        <td><asp:Label ID="lblftotalvalue" runat="server" Text="Label">Total Value</asp:Label></td>
                        <td><asp:TextBox ID="ftotalvalueTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr><tr>
                        <td><asp:Label ID="lblftradeinvalue" runat="server" Text="Label">Trade-In Value</asp:Label></td>
                        <td><asp:TextBox ID="ftradeinvalueTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblAdmissionFees" runat="server" Text="Label">Admission Fees</asp:Label></td>
                        <td><asp:TextBox ID="AdmissionFeesTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblAdministrationFees" runat="server" Text="Label">Administration Fees</asp:Label></td>
                        <td><asp:TextBox ID="AdministrationFeesTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfcgst" runat="server" Text="Label">CGST (9%)</asp:Label></td>
                        <td><asp:TextBox ID="fcgstTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblfsgst" runat="server" Text="Label">SGST (9%)</asp:Label></td>
                        <td><asp:TextBox ID="fsgstTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblTotalPurchasePrice" runat="server" Text="Label">Total Purchase Price</asp:Label></td>
                        <td><asp:TextBox ID="TotalPurchasePriceTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfractionaldeposit" runat="server" Text="Label">Deposit</asp:Label></td>
                        <td><asp:TextBox ID="fractionaldepositTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblfractionalbalance" runat="server" Text="Label">Balance</asp:Label></td>
                        <td><asp:TextBox ID="fractionalbalanceTextBox" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>                 
                     <tr>
                        <td><asp:Label ID="lblrfoldamt" runat="server" Text="Label">Previous Paid Amt</asp:Label></td>
                        <td><asp:TextBox ID="frpdoldamtTextBox" runat="server" Enabled="True" Width="328px" Text="0" onchange="VoidAgreementamt();" ></asp:TextBox></td>
                    </tr>      
                    <tr>
                        <td><p>Balance Due Dates in PA</p></td>
                    <td><asp:TextBox ID="fractionalbalduedateTextBox" runat="server" Enabled="True" Width="328px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                </table>
                   </div>
                            <div id="instalheading1" style="float:left;">
                            <h4>INSTALLMENT DETAILS</h4>
                           <table>
                          <tr>
                              <td width="250px" align="center"><asp:Label ID="lblfamt" runat="server" Text="Label">Amount</asp:Label> </td>
                              <td width="100px" align="center"><asp:Label ID="lblfdate" runat="server" Text="Label">Date</asp:Label> </td>
                          </tr>
                      </table>
                            <div id="installmentDIV1" style="float:left;">                   
                     
                      
                       </div>
                               
                            <input id="totalamt1" type="text" name="ter"  />
                  
                     
                      </div>
            </div>  
              
              <br />
              <div id="Points" style="margin:10px 0px;padding-top:10px; overflow:hidden;">
               <div id="PA1" style="width:650px; float:left;">
                   <h4>PURCHASE AGREEMENT</h4>
                <table  cellpadding="5px" cellspacing="5px">
                    
                              
                    <tr>
                        <td><asp:Label ID="lblnewpoints" runat="server" Text="Label">NEW POINTS PRICE</asp:Label></td>
                        <td><asp:TextBox ID="newpointsTextBox" runat="server" onchange="ConversionfeeWithNewPoints();"   Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblconversionfee" runat="server" Text="Label">CONVERSION FEE</asp:Label></td>
                        <td><asp:TextBox ID="conversionfeeTextBox" runat="server"    Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label88" runat="server" Text="Label">ADMIN FEE</asp:Label></td>
                        <td><asp:TextBox ID="adminfeeTextBox"    runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label128" runat="server" Text="Label">TOTAL PURCHASE PRICE</asp:Label></td>
                        <td><asp:TextBox ID="totpurchpriceTextBox"    runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label148" runat="server" Text="Label">CGST(9%)</asp:Label></td>
                        <td><asp:TextBox ID="cgstTextBox"   runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label149" runat="server" Text="Label">SGST(9%)</asp:Label></td>
                        <td><asp:TextBox ID="sgstTextBox"    runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label150" runat="server" Text="Label">TOTAL PRICE INCLUDING TAX</asp:Label></td>
                        <td><asp:TextBox ID="totalpriceInTaxTextBox"  runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>

                     <tr>
                        <td><asp:Label ID="Label153" runat="server" Text="Label">DEPOSIT</asp:Label></td>
                        <td><asp:TextBox ID="depositTextBox"  runat="server" Enabled="True" Width="328px"></asp:TextBox></td><!--onchange="balanceAmtCalculation();" -->
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label154" runat="server" Text="Label">BALANCE</asp:Label></td>
                        <td><asp:TextBox ID="balanceTextBox"    runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>                    
                 <tr>
                        <td><asp:Label ID="lbloldamt" runat="server" Text="Label">Previous Paid Amt</asp:Label></td>
                        <td><asp:TextBox ID="pdoldamtTextBox" runat="server" Enabled="True" Width="328px" Text="0" onchange="VoidAgreementamt();" ></asp:TextBox></td>
                    </tr>      
                    <tr>
                        <td><p>Balance Due Dates in PA</p></td>
                    <td><asp:TextBox ID="balancedueTextBox" runat="server" Enabled="True" Width="328px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                </table>
              </div>
               
                      <div  id="instalheading" style="float:left;">
                            <h4>INSTALLMENT DETAILS</h4>
                           <table>
                          <tr>
                              <td width="250px" align="center"><asp:Label ID="lblamt" runat="server" Text="Label">Amount</asp:Label> </td>
                              <td width="100px" align="center"><asp:Label ID="lbldate" runat="server" Text="Label">Date</asp:Label> </td>
                          </tr>
                      </table>
                            <div id="installmentDIV" style="float:left;">                   
                     
                      
                       </div>

                              <input id="totalamt" type="text" name="ter"  />

                      </div>
                 
              </div>
                  
              <div id="tradeinPointsPurchase" style="margin:10px 0px;padding-top:10px; overflow:hidden;">
                  </div>
              
              <div id="tfractional" style="width:620px;">
                  <h4>PURCHASE AGREEMENT</h4>
                <table  cellpadding="5px" cellspacing="5px">
                    
                    <tr>
                        <td width="200px"><asp:Label ID="Label146" runat="server" Text="Label">Deposit Payment Method</asp:Label>
                        </td>  

                        <td width="400px">
                            <asp:DropDownList ID="DropDownList63" runat="server" Width="150px"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label147" runat="server" Text="Label">Deposit</asp:Label>
                        <asp:TextBox ID="TextBox88" runat="server" Enabled="True" Width="100px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label151" runat="server" Text="Label">Admission Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextBox92" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label152" runat="server" Text="Label">Administration Fees</asp:Label></td>
                        <td><asp:TextBox ID="TextBox93" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label172" runat="server" Text="Label">Total Purchase Price</asp:Label></td>
                        <td><asp:TextBox ID="TextBox114" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label173" runat="server" Text="Label">Country Tax</asp:Label></td>
                        <td><asp:TextBox ID="TextBox115" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label174" runat="server" Text="Label">Grand Total</asp:Label>
                            <asp:TextBox ID="TextBox116" runat="server" Enabled="True" Width="100px"></asp:TextBox>
                            

                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label175" runat="server" Text="Label">Balance Due PA</asp:Label></td>
                        <td><asp:TextBox ID="TextBox117" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label176" runat="server" Text="Label">PA No of Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextBox118" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label177" runat="server" Text="Label">First Payment Date</asp:Label></td>
                        <td><asp:TextBox ID="TextBox119" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label178" runat="server" Text="Label">PA Amount Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextBox120" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="Label179" runat="server" Text="Label">PA First Installments</asp:Label></td>
                        <td><asp:TextBox ID="TextBox121" runat="server" Enabled="True" Width="328px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><p>Balance Due Dates in PA</p></td>
                    <td><asp:TextBox ID="TextBox122" runat="server" Enabled="True" Width="328px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                </table>
                   

              </div>
              
              </div>
              <br />
              <br />
             
              <br />
              <div id="remarks" >
                  <p>Remarks</p>
                  <asp:TextBox ID="remarksTextBox" runat="server" Enabled="True" Width="1200px" TextMode="MultiLine"></asp:TextBox>
                  <br />
                 
              </div>
            <asp:Button ID="CreateButton" runat="server" Text="Create Contract" OnClick="CreateButton_Click"></asp:Button> <!--OnClick="CreateButton_Click " -->
            
   </div>
      
      <div id="tabs-5" style="background-color:#e9e9e9;">
          <div id="Tab5cont">

              <asp:DropDownList ID="PrintPdfDropDownList" runat="server" ></asp:DropDownList> &nbsp;&nbsp <asp:Button ID="Button5" runat="server" Text="Print" OnClick="Button5_Click" />

            

          </div>
      </div>

      
      </div>

        </form>
   </div>
    
      
    
 

    <script>

        $(document).ready(function () {


            $("#currencyDropDownList").change(function () {
                var value = $("#currencyDropDownList").val();
                if(value=="USD"){
                    $("#totalfinpriceIntaxTextBox").val("");
                    $("#intialdeppercentTextBox").val("");

                    $("#balinitialdepamtTextBox").val("");
                    $("#PayMethodDropDownList").val('');
                    $("#NoinstallmentTextBox").val("");
                    $("#installmentamtTextBox").val("");

                    $("#balamtpayableTextBox").val("");
                    $("#FinancenoTextBox").val("");
                   // $("#noemiTextBox").val("");
                    $("#emiamtTextBox").val("");
                    $("#pancardnoTextBox").val("");
                    $("#adharcardTextBox").val("");
                    $("#financemethodDropDownList").val('');
                    $("#depositmethodDropDownList").val('');
                    $("#chs4").attr('checked', false);
                    $("#ca1").attr('checked', false);
                    $("#ca2").attr('checked', false);
                    $("#ca3").attr('checked', false);

                }
                else {
                    $("#totalfinpriceIntaxTextBox").val("");
                    $("#intialdeppercentTextBox").val("");

                    $("#balinitialdepamtTextBox").val("");
                    $("#PayMethodDropDownList").val('');
                    $("#NoinstallmentTextBox").val("");
                    $("#installmentamtTextBox").val("");

                    $("#balamtpayableTextBox").val("");
                    $("#FinancenoTextBox").val("");
                   // $("#noemiTextBox").val("");
                    $("#emiamtTextBox").val("");
                    $("#pancardnoTextBox").val("");
                    $("#adharcardTextBox").val("");
                    $("#financemethodDropDownList").val('');
                    $("#depositmethodDropDownList").val('');
                    $("#chs4").attr('checked', false);
                    $("#ca1").attr('checked', false);
                    $("#ca2").attr('checked', false);
                    $("#ca3").attr('checked', false);
                }

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getPointsAmoountTax',
                    data: "{'currency':'" + value + "'}",
                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                // $("#adminfeeTextBox").val(value1[0]);
                                // $("#pointstaxTextBox").val(value1[1]);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;
            });
            //load contractno
            $("#resortDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var value = v.options[v.selectedIndex].text;
                var value3 = $("#resortDropDownList").val();
                var v4 = document.getElementById("PrimarynationalityDropDownList");
                var value4 = v4.options[v4.selectedIndex].text;
 
            
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getContractnoOnResort',
                    data: "{'venue':'" + value + "','club':'" + value3 + "','nationality':'" + value4 + "'}",
                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#incrTextBox").val(value1[0]);
                                // $("#pointstaxTextBox").val(value1[1]);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;
            });

            //weeks
            $("#fwresortDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var value = v.options[v.selectedIndex].text;
                var value3 = $("#fwresortDropDownList").val();
                var v4 = document.getElementById("PrimarynationalityDropDownList");
                var value4 = v4.options[v4.selectedIndex].text;
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getContractnoOnResort',
                    data: "{'venue':'" + value + "','club':'" + value3 + "','nationality':'" + value4 + "'}",
                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#incrTextBox").val(value1[0]);
                                // $("#pointstaxTextBox").val(value1[1]);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;
            });
            //fractionals
            $("#ffresortDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var value = v.options[v.selectedIndex].text;
                var value3 = $("#ffresortDropDownList").val();
                var v4 = document.getElementById("PrimarynationalityDropDownList");
                var value4 = v4.options[v4.selectedIndex].text;
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getContractnoOnResort',
                    data: "{'venue':'" + value + "','club':'" + value3 + "','nationality':'" + value4 + "'}",
                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#incrTextBox").val(value1[0]);
                                // $("#pointstaxTextBox").val(value1[1]);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;
            });
            //points
            $("#fptsresortDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var value = v.options[v.selectedIndex].text;
                var value3 = $("#fptsresortDropDownList").val();
                var v4 = document.getElementById("PrimarynationalityDropDownList");
                var value4 = v4.options[v4.selectedIndex].text;
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getContractnoOnResort',
                    data: "{'venue':'" + value + "','club':'" + value3 + "','nationality':'" + value4 + "'}",
                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#incrTextBox").val(value1[0]);
                                // $("#pointstaxTextBox").val(value1[1]);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;
            });


            $("#pointsclubDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var value = v.options[v.selectedIndex].text;
                var v2 = document.getElementById("GroupVenueDropDownList");
                var value2 = v2.options[v2.selectedIndex].text;
                var value3 = $("#pointsclubDropDownList").val();
                var v4 = document.getElementById("PrimarynationalityDropDownList");
                var value4 = v4.options[v4.selectedIndex].text;
                var v5 = document.getElementById("MarketingProgramDropDownList");
                var value5 = v5.options[v5.selectedIndex].text;
                //alert(value);
                //alert(value2);
                //alert(value3);
                //alert(value4);

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getContractnoOnClub',
                    data: "{'venue':'" + value + "','venuegrp':'" + value2 + "','club':'" + value3 + "','mk':'" + value5 + "','nationality':'" + value4 + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d)
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#incrTextBox").val(value1[0]);// $("#incrTextBox").val(value1[2]);
                                // $("#pointstaxTextBox").val(value1[1]);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;
            });

            $("#ntipclubDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var value = v.options[v.selectedIndex].text;
                var v2 = document.getElementById("GroupVenueDropDownList");
                var value2 = v2.options[v2.selectedIndex].text;
                var value3 = $("#ntipclubDropDownList").val();
                var v4 = document.getElementById("PrimarynationalityDropDownList");
                var value4 = v4.options[v4.selectedIndex].text;
                var v5 = document.getElementById("MarketingProgramDropDownList");
                var value5 = v5.options[v5.selectedIndex].text;

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getContractnoOnClub',
                  //  data: "{'venue':'" + value + "','venuegrp':'" + value2 + "','club':'" + value3 + "','nationality':'" + value4 + "'}",
                    data: "{'venue':'" + value + "','venuegrp':'" + value2 + "','club':'" + value3 + "','mk':'" + value5 + "','nationality':'" + value4 + "'}",

                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //   alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#incrTextBox").val(value1[0]); //$("#incrTextBox").val(value1[2]);
                                // $("#pointstaxTextBox").val(value1[1]);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;
            });

            $("#nmclubDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var value = v.options[v.selectedIndex].text;
                var v2 = document.getElementById("GroupVenueDropDownList");
                var value2 = v2.options[v2.selectedIndex].text;
                var value3 = $("#nmclubDropDownList").val();
                var v4 = document.getElementById("PrimarynationalityDropDownList");
                var value4 = v4.options[v4.selectedIndex].text;
                var v5 = document.getElementById("MarketingProgramDropDownList");
                var value5 = v5.options[v5.selectedIndex].text;

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getContractnoOnClub',
                    //   data: "{'venue':'" + value + "','venuegrp':'" + value2 + "','club':'" + value3 + "','nationality':'" + value4 + "'}",
                    data: "{'venue':'" + value + "','venuegrp':'" + value2 + "','club':'" + value3 + "','mk':'" + value5 + "','nationality':'" + value4 + "'}",

                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#incrTextBox").val(value1[0]); //$("#incrTextBox").val(value1[2]);
                                // $("#pointstaxTextBox").val(value1[1]);
                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });
                return false;
            });

            $("#financemethodDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var value = v.options[v.selectedIndex].text;
                var v2 = document.getElementById("contracttypeDropDownList");
                var value2 = v2.options[v2.selectedIndex].text;
                var value3 = $("#financemethodDropDownList").val();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getFinanceNo',
                    data: "{'venue':'" + value + "','finance':'" + value3 + "','type':'" + value2 + "'}",
                    async: false,
                    success: function (data) {

                        subJson = JSON.parse(data.d);

                        //alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#FinancenoTextBox").val(value1[0]);

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

   <!-- load all club name base don contract type-->
    <script>
        $(document).ready(function () {
            $("#contracttypeDropDownList").change(function () {
                var value = $("#contracttypeDropDownList").val();
                //alert(value);
                if (value == "Fractional") {
                    $("#contsalesrepDropDownList").val('');
                    $("#TOManagerDropDownList").val('');
                    $("#ButtonUpDropDownList").val('');
                    $("#contractnoTextBox").val("");
                    $("#dealstatusDropDownList").val('');
                    $("#resortDropDownList").val('');
                    $("#residenceDropDownListno").val('');
                    $("#residencetypeDropDownList").empty();
                    $("#FractionalInterestDropDownList").val('');
                    $("#EntitlementFracDropDownList").val('');
                    $("#ffirstyrTextBox").val("");
                    $("#ftenureTextBox").val("");
                    $("#flastyrTextBox").val("");
                    $("#cdiv1").show();
                    $("#cdiv2").hide();
                    $("#cdiv3").hide();
                    $("#cdivtradeinweeks").hide();
                    $("#cdivtradeinpoints").hide();
                    $("#fractionalweeks").hide();
                    $("#fractionaltofractionals").hide();
                    $("#fractionalpoints").hide();
                    $("#financeradiobuttonlist :checked").prop('checked', false);
                    $("#ca1").hide();
                    $("#lblchk1").hide();
                    $("#ca3").show();
                    $("#lblchk3").show();
                    $("#lblregcoll").hide(); $("#regcollectiontermTextBox").hide(); $("#lblregcollamt").hide(); $("#regcollamtTextBox").hide();
                }

                else if (value == "Points") {
                    $("#contsalesrepDropDownList").val('');
                    $("#TOManagerDropDownList").val('');
                    $("#ButtonUpDropDownList").val('');
                    $("#contractnoTextBox").val("");
                    $("#dealstatusDropDownList").val('');
                    $("#resortDropDownList").val('');

                    $("#pointsclubDropDownList").val('');
                    $("#newpointsrightTextBox").val("");
                    $("#EntitlementPoinDropDownList").val('');
                    $("#totalptrightsTextBox").val("");
                    $("#nopersonsTextBox").val("");
                    $("#firstyrTextBox").val("");
                    $("#tenureTextBox").val("");
                    $("#lastyrTextBox").val("");
                    $("#cdiv1").hide();
                    $("#cdiv2").show();
                    $("#cdiv3").hide();
                    $("#cdivtradeinweeks").hide();
                    $("#cdivtradeinpoints").hide();
                    $("#fractionalweeks").hide();
                    $("#fractionalpoints").hide();
                    $("#fractionaltofractionals").hide();
                  $("#incrTextBox").hide();
                    $("#financeradiobuttonlist :checked").prop('checked', false);
                    $("#ca3").hide();
                    $("#lblchk3").hide();
                    $("#ca1").show();
                    $("#lblchk1").show();
                    $("#lblregcoll").hide(); $("#regcollectiontermTextBox").hide(); $("#lblregcollamt").hide(); $("#regcollamtTextBox").hide();
                }

                else if (value == "Trade-In-Points") {
                    $("#contsalesrepDropDownList").val('');
                    $("#TOManagerDropDownList").val('');
                    $("#ButtonUpDropDownList").val('');
                    $("#contractnoTextBox").val("");
                    $("#dealstatusDropDownList").val('');
                    $("#tipresortTextBox").val("");
                    $("#tipnopointsTextBox").val("");
                    $("#tipcontnoTextBox").val("");
                    $("#tipptsvalueTextBox").val("");
                    $("#cdiv1").hide();
                    $("#cdiv2").hide();
                    $("#cdiv3").hide();
                    $("#cdivtradeinweeks").hide();
                    $("#cdivtradeinpoints").show();
                    $("#fractionalweeks").hide();
                    $("#fractionalpoints").hide();
                    $("#fractionaltofractionals").hide();
                    $("#lblchk3").hide();
                    $("#ntipclubDropDownList").val('');
                    $("#tipnewpointsTextBox").val("");
                    $("#tipmtypeDropDownList").val('');
                    $("#tiptotalpointsTextBox").val("");
                    $("#tipnopersonsTextBox").val("");
                    $("#tipfirstyrTextBox").val("");
                    $("#tiptenureTextBox").val("");
                    $("#tiplastyrTextBox").val("");
                    $("#ca3").hide(); 
                    $("#ca1").show();
                    $("#lblchk1").show();
                    $("#financeradiobuttonlist :checked").prop('checked', false);
                    $("#lblregcoll").hide(); $("#regcollectiontermTextBox").hide(); $("#lblregcollamt").hide(); $("#regcollamtTextBox").hide();
                }

                else if (value == "Trade-In-Weeks") {
                    $("#contsalesrepDropDownList").val('');
                    $("#TOManagerDropDownList").val('');
                    $("#ButtonUpDropDownList").val('');
                    $("#contractnoTextBox").val("");
                    $("#dealstatusDropDownList").val('');

                    $("#tnmresortTextBox").val("");
                    $("#tnmapttypeTextBox").val("");
                    $("#tnmseasonDropDownList").val('');
                    $("#nmnowksTextBox").val("");
                    $("#nmcontrcinoTextBox").val("");
                    $("#nmpointsvalueTextBox").val("");
                    $("#lblchk3").hide();
                    $("#nmclubDropDownList").val('');
                    $("#nmnewpointsrightsTextBox").val("");
                    $("#nmembtypeDropDownList").val('');
                    $("#nmtotalpointsTextBox").val("");
                    $("#nmnopersonsTextBox").val("");                    
                    $("#nmfirstyrTextBox").val("");
                    $("#nmtenureTextBox").val("");
                    $("#nmlastyrTextBox").val("");
                    $("#cdivtradeinweeks").show();
                    $("#cdiv1").hide();
                    $("#cdiv2").hide();
                    $("#cdiv3").hide();
                    $("#cdivtradeinpoints").hide();
                    $("#fractionalweeks").hide();
                    $("#fractionaltofractionals").hide();
                    $("#fractionalpoints").hide();
                    $("#financeradiobuttonlist :checked").prop('checked', false);
                    $("#ca3").hide();
                    $("#ca1").show();
                    $("#lblchk1").show();
                    $("#lblregcoll").hide(); $("#regcollectiontermTextBox").hide(); $("#lblregcollamt").hide(); $("#regcollamtTextBox").hide();

                }
                else if (value == "Trade-In-Fractionals") {
                    $("#contsalesrepDropDownList").val('');
                    $("#TOManagerDropDownList").val('');
                    $("#ButtonUpDropDownList").val('');
                    $("#contractnoTextBox").val("");
                    $("#dealstatusDropDownList").val('');
                   $("#lblchk1").hide();
                    $("#oldcontracttypeDropDownList").val('');
                    $("#cdiv1").hide();
                    $("#cdiv2").hide();
                    $("#cdiv3").show();
                    $("#cdivtradeinweeks").hide();
                    $("#cdivtradeinpoints").hide();
                    $("#fractionalweeks").hide();
                    $("#fractionalpoints").hide();
                    $("#fractionaltofractionals").hide();
                    $("#financeradiobuttonlist :checked").prop('checked', false);
                    $("#ca1").hide();
                    $("#lblregcoll").hide(); $("#regcollectiontermTextBox").hide(); $("#lblregcollamt").hide(); $("#regcollamtTextBox").hide();
                }
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadClubNameonContractType',
                    data: "{'contracttype':'" + value + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#pointsclubDropDownList").empty();
                        $("#pointsclubDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {                               
                                $("#pointsclubDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
                    url: 'Indian_contracts.aspx/LoadClubNameonContractType',
                    data: "{'contracttype':'" + value + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#nmclubDropDownList").empty();
                        $("#nmclubDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#nmclubDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
                    url: 'Indian_contracts.aspx/LoadClubNameonContractType',
                    data: "{'contracttype':'" + value + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#ntipclubDropDownList").empty();
                        $("#ntipclubDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                $("#ntipclubDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
            $("#resortDropDownList").change(function () {
                var value = $("#resortDropDownList").val();

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/GetfractionalResidenceType',
                    data: "{'resort':'" + value + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#residencetypeDropDownList").empty();
                        $("#residencetypeDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        //  alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {
                                // $("#adminfeeTextBox").val(value1[0]);
                                // $("#pointstaxTextBox").val(value1[1]);
                                $("#residencetypeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
                    url: 'Indian_contracts.aspx/LoadfractionalResidenceNo',
                    data: "{'resort':'" + value + "'}",
                    async: false,
                    success: function (data) {
                        //  alert(data.d);
                        $("#residenceDropDownListno").empty();
                        //$("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#residenceDropDownListno").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
  <!--fracttional weeks-->
      <script>

          $(document).ready(function () {
              $("#fwresortDropDownList").change(function () {
                  var value = $("#fwresortDropDownList").val();

                  $.ajax({

                      type: 'post',
                      contentType: "application/json; charset=utf-8",
                      url: 'Indian_contracts.aspx/GetfractionalResidenceType',
                      data: "{'resort':'" + value + "'}",
                      async: false,
                      success: function (data) {
                          // alert(data.d);
                          $("#fwresidencetypeDropDownList").empty();
                          $("#fwresidencetypeDropDownList").append("<option disabled selected value>select an option  </option>")
                          subJson = JSON.parse(data.d);

                          //  alert(subJson);
                          $.each(subJson, function (key, value) {
                              $.each(value, function (index1, value1) {
                                  // $("#adminfeeTextBox").val(value1[0]);
                                  // $("#pointstaxTextBox").val(value1[1]);
                                  $("#fwresidencetypeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
                      url: 'Indian_contracts.aspx/LoadfractionalResidenceNo',
                      data: "{'resort':'" + value + "'}",
                      async: false,
                      success: function (data) {
                          //  alert(data.d);
                          $("#fwresidencenoDropDownList").empty();
                          //$("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>")
                          subJson = JSON.parse(data.d);

                          // alert(subJson);
                          $.each(subJson, function (key, value) {
                              $.each(value, function (index1, value1) {

                                  $("#fwresidencenoDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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

    <!--fractionals to fractionals-->
     <script>

          $(document).ready(function () {
              $("#ffresortDropDownList").change(function () {
                  var value = $("#ffresortDropDownList").val();

                  $.ajax({

                      type: 'post',
                      contentType: "application/json; charset=utf-8",
                      url: 'Indian_contracts.aspx/GetfractionalResidenceType',
                      data: "{'resort':'" + value + "'}",
                      async: false,
                      success: function (data) {
                          // alert(data.d);
                          $("#ffresidencetypeDropDownList").empty();
                          $("#ffresidencetypeDropDownList").append("<option disabled selected value>select an option  </option>")
                          subJson = JSON.parse(data.d);

                          //  alert(subJson);
                          $.each(subJson, function (key, value) {
                              $.each(value, function (index1, value1) {
                                  // $("#adminfeeTextBox").val(value1[0]);
                                  // $("#pointstaxTextBox").val(value1[1]);
                                  $("#ffresidencetypeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
                      url: 'Indian_contracts.aspx/LoadfractionalResidenceNo',
                      data: "{'resort':'" + value + "'}",
                      async: false,
                      success: function (data) {
                          //  alert(data.d);
                          $("#ffresidencenoDropDownList").empty();
                          //$("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>")
                          subJson = JSON.parse(data.d);

                          // alert(subJson);
                          $.each(subJson, function (key, value) {
                              $.each(value, function (index1, value1) {

                                  $("#ffresidencenoDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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


    <!--fracttional points-->
      <script>

          $(document).ready(function () {
              $("#fptsresortDropDownList").change(function () {
                  var value = $("#fptsresortDropDownList").val();

                  $.ajax({

                      type: 'post',
                      contentType: "application/json; charset=utf-8",
                      url: 'Indian_contracts.aspx/GetfractionalResidenceType',
                      data: "{'resort':'" + value + "'}",
                      async: false,
                      success: function (data) {
                          // alert(data.d);
                          $("#fptsresidencetypeDropDownList").empty();
                          $("#fptsresidencetypeDropDownList").append("<option disabled selected value>select an option  </option>")
                          subJson = JSON.parse(data.d);

                          //  alert(subJson);
                          $.each(subJson, function (key, value) {
                              $.each(value, function (index1, value1) {
                                  // $("#adminfeeTextBox").val(value1[0]);
                                  // $("#pointstaxTextBox").val(value1[1]);
                                  $("#fptsresidencetypeDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
                      url: 'Indian_contracts.aspx/LoadfractionalResidenceNo',
                      data: "{'resort':'" + value + "'}",
                      async: false,
                      success: function (data) {
                          //  alert(data.d);
                          $("#fptsResidencenoDropDownList").empty();
                          //$("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>")
                          subJson = JSON.parse(data.d);

                          // alert(subJson);
                          $.each(subJson, function (key, value) {
                              $.each(value, function (index1, value1) {

                                  $("#fptsResidencenoDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
            $(".hello").on("click", function () {

                var amount = this.checked ? this.value : '';
                //  alert(amount);
                $("#AffiliationamtTextBox").val(amount);
            });


        });

    </script>


    <script>

        $(document).ready(function () {
            var marketprogram = $("#MarketingProgramDropDownList :selected").text();
            var ctype = $("#contracttypeDropDownList :selected").text();
            if (ctype == "Fractional" || ctype == "Trade - In - Fractionals")
            {
                if (marketprogram == "OWNER") {
                    $('#check').css('display', 'none');
                    //alert("hiee");
                } else {
                    $('#check').css('display', 'none');
                    //alert("else");
                }
            }
            else

            {
                if (marketprogram == "OWNER") {
                    $('#check').css('display', 'block');
                    //alert("hiee");
                } else {
                    $('#check').css('display', 'none');
                    //alert("else");
                }

            }
           
        });

    </script>
   
 
    <script>

        $(document).ready(function () {
           // $("#hidden1").hide();
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
            $("#cdiv1").hide();
            $("#cdiv2").hide();
            $("#cdiv3").hide();
            $("#cdivtradeinweeks").hide();
            $("#cdivtradeinpoints").hide();
            $("#fractionalweeks").hide();
            $("#fractionalpoints").hide();
            $("#fractionaltofractionals").hide();

          
            $("#oldcontracttypeDropDownList").change(function () {
                var value1 = $("#oldcontracttypeDropDownList").val();
                
                if (value1 == "Points") {
                    $("#fractionalpoints").show();

                    //$("#contsalesrepDropDownList").val('');
                    //$("#TOManagerDropDownList").val('');
                    //$("#ButtonUpDropDownList").val('');
                    //$("#contractnoTextBox").val("");
                    //$("#dealstatusDropDownList").val('');


                    $("#fptsnoptsTextBox").val("");
                    $("#fptsclubTextBox").val("");
                    $("#fptscontnoTextBox").val("");
                    $("#fptsvalTextBox").val("");
                    $("#fptradeinamtTextBox").val("");
                    $("#foldloanagreementnoTextBox").val("");
                    $("#foldloanamountTextBox").val("");
                    
                    $("#fptsresortDropDownList").val('');
                    $("#fptsResidencenoDropDownList").val('');
                    $("#fptsResidenceno1TextBox").val("");
                    $("#fptsresidencetypeDropDownList").empty();
                    $("#fptsresidencetype1TextBox").val("");
                    $("#fptsfracintDropDownList").val('');
                    $("#fptsentitlementDropDownList").val('');
                    $("#fptsfirstyrTextBox").val("");
                    $("#fptstenureTextBox").val("");
                    $("#fptslastyrTextBox").val("");    

                } else if (value1 == "Weeks") {
                    $("#fractionalweeks").show();
                    //$("#contsalesrepDropDownList").val('');
                    //$("#TOManagerDropDownList").val('');
                    //$("#ButtonUpDropDownList").val('');
                    //$("#contractnoTextBox").val("");
                    //$("#dealstatusDropDownList").val('');

                    $("#fwresorttradeTextBox").val("");
                    $("#fwaptTextBox").val("");
                    $("#fwseasonDropDownList").val('');
                    $("#fwnowksTextBox").val("");
                    $("#fwptsvalueTextBox").val("");
                    $("#fwconnoTextBox").val("");
                    $("#ftradeinamtTextBox").val("");
                    $("#oldLoanAgreementTextBox").val("");
                    $("#oldloanamountTextBox").val("");
                    

                    $("#fwresortDropDownList").val('');
                    $("#fwresidencenoDropDownList").val('');
                    $("#fwresidenceno1TextBox").val("");
                    $("#fwresidencetypeDropDownList").empty();
                    $("#fwresidencetype1TextBox").val("");

                    $("#fwfractIntDropDownList").val("");
                    $("#fwentitlementDropDownList").val("");
                    $("#fwfirstyrTextBox").val("");
                    $("#fwtenureTextBox").val("");
                    $("#fwlastyrTextBox").val("");
                }
                else if (value1 == "Fractionals") {
                    $("#fractionaltofractionals").show();
                    //$("#contsalesrepDropDownList").val('');
                    //$("#TOManagerDropDownList").val('');
                    //$("#ButtonUpDropDownList").val('');
                    //$("#contractnoTextBox").val("");
                    //$("#dealstatusDropDownList").val('');

                    $("#ffresorttradeTextBox").val("");
                    $("#ffaptTextBox").val("");
                     
                    $("#ffnowksTextBox").val("");
                    
                    $("#ffconnoTextBox").val("");
                    $("#fftradeinamtTextBox").val("");
                    $("#oldLoanAgreementTextBox").val("");
                    $("#oldloanamountTextBox").val("");


                    $("#ffresortDropDownList").val('');
                    $("#ffresidencenoDropDownList").val('');
                    $("#ffresidenceno1TextBox").val("");
                    $("#ffresidencetypeDropDownList").empty();
                    $("#ffresidencetype1TextBox").val("");

                    $("#fffractIntDropDownList").val("");
                    $("#ffentitlementDropDownList").val("");
                    $("#fffirstyrTextBox").val("");
                    $("#ffenureTextBox").val("");
                    $("#fflastyrTextBox").val("");
                }

            });


        }); 



    </script>

   
    
    <script>

        $(document).ready(function () {
            $("#financeradiobuttonlist").click(function () {
                var value = $("#financeradiobuttonlist").text();
                $("#currencyDropDownList").val('');
                $("#totalfinpriceIntaxTextBox").val("");
                $("#intialdeppercentTextBox").val("");
                $("#initaldepamtTextBox").val("");
                $("#baldepamtTextBox").val("");
                $("#firstdepamtTextBox").val("");
                $("#balinitialdepamtTextBox").val("");
                $("#balamtpayableTextBox").val("");
                $("#PayMethodDropDownList").val('');
                $("#NoinstallmentTextBox").val("");
                $("#installmentamtTextBox").val("");
                $("#financemethodDropDownList").val('');
                $("#depositmethodDropDownList").val('');
                $("#FinancenoTextBox").val("");
                $("#noemiTextBox").val("");
                $("#emiamtTextBox").val("");
                $("#pancardnoTextBox").val("");
                $("#adharcardTextBox").val("");
                $("#initaldepamtTextBox").val("");
                $("#baldepamtTextBox").val("");
                $("#firstdepamtTextBox").val("");
                $("#balinitialdepamtTextBox").val("");
                $("#balamtpayableTextBox").val("");
                $("#baladepamtdateTextBox").val("");
                
                
                
                
                $("#NoinstallmentTextBox").hide();
                $("#installmentamtTextBox").hide();
                $("#lblnoinstallment").hide();
                $("#lblinstallmentamt").hide();
                $("#lbladminamtfees").hide();
                $("#adminamtfeesTextBox").hide();
               
                
                $("#balamtpayableTextBox").hide();
                $("#lblbalamtpayable").hide();
               
                $("#pancardnoTextBox").hide();
                $("#adharcardTextBox").hide();
                $("#Label92").hide();
                $("#Label93").hide();

                $("#chs4").attr('checked', false);
                $("#ca1").attr('checked', false);
                $("#ca2").attr('checked', false);
                $("#ca3").attr('checked', false);
                
                $("#lblfinanceno").hide();
                $("#FinancenoTextBox").hide();
                $("#lblnoemi").hide();
                $("#noemiTextBox").hide();
                $("#lblemiamt").hide();
                $("#emiamtTextBox").hide();
                $("#initaldepamtTextBox").hide();
                $("#baldepamtTextBox").hide();
                $("#firstdepamtTextBox").hide();
                $("#balinitialdepamtTextBox").hide();
                $("#balamtpayableTextBox").hide();

                $("#lblbaladepamtdate").hide();
                $("#baladepamtdateTextBox").hide();
                $("#lblinitaldepamt").hide();
                $("#lblbaladepamt").hide();
                $("#lblfirstdepamt").hide();
                $("#lblbalinitialdep").hide();
                $("#lblbalamtpayable").hide();
                
                
                
                
            });


            $("#chs4").click(function () {
                
                $("#pancardnoTextBox").show();
                $("#adharcardTextBox").show();
                $("#Label92").show();
                $("#Label93").show();


            });


        });

    </script>


           <script>
        $(document).ready(function () {
            $("#primarydobdatepicker").change(function () {
                
                var date = $("#primarydobdatepicker").val();
                dob = new Date(date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#primaryAge').val(age);
            });
        });

    </script>

    <script>
        $(document).ready(function () {
            $("#secondarydobdatepicker").change(function () {
                var date = $("#secondarydobdatepicker").val();
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
                    url: 'Indian_contracts.aspx/getVenueOnCountry',
                    data: "{'countryName':'" + countryName + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#VenueDropDownList").empty();
                        $("#VenueDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

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
                        $("#GroupVenueDropDownList").append("<option disabled selected value>select an option  </option>")

                        $("#MarketingProgramDropDownList").empty();
                        $("#MarketingProgramDropDownList").append("<option disabled selected value>select an option  </option>");
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

                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadManagersOnVenue',
                    data: "{'venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#ManagerDropDownList").empty();
                        $("#ManagerDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
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



            $("#GroupVenueDropDownList").change(function () {
                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;

                var vg = document.getElementById("GroupVenueDropDownList");
                var venueGroup = vg.options[vg.selectedIndex].text;


                var profileID = $("#profileidTextBox").val();

                if (venueGroup == "Coldline" || venueGroup == "COLDLINE") {
                    //alert("hello");

                    $("#Label205").show();
                    $("#ManagerDropDownList").show();
                }
                else {
                    $("#Label205").hide();
                    $("#ManagerDropDownList").hide();
                }
           

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/getMarketingProgram',
                    data: "{'venue':'" + venue + "','venueGroup':'" + venueGroup + "','profileID':'" + profileID + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#MarketingProgramDropDownList").empty();
                        $("#MarketingProgramDropDownList").append("<option disabled selected value>select an option  </option>");
                        subJson = JSON.parse(data.d);


                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#MarketingProgramDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");


                            });
                        });
                    },
                    error: function () {
                        alert("wrong");
                    }



                });

                var v = document.getElementById("VenueDropDownList");
                var venue = v.options[v.selectedIndex].text;

                var vg = document.getElementById("GroupVenueDropDownList");
                var venueGroup = vg.options[vg.selectedIndex].text;
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadAgentsOnVenuegrp',
                    data: "{'venue':'" + venue + "','vgrp':'" + venueGroup + "'}",
                    async: false,
                    success: function (data) {
                       // alert(data.d);
                        $("#AgentDropDownList").empty();
                        $("#AgentDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#AgentDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
                    url: 'Indian_contracts.aspx/LoadTOOnVenueNVGrp',
                    data: "{'venue':'" + venue + "','vgrp':'" + venueGroup + "'}",
                    async: false,
                    success: function (data) {
                    //    alert(data.d);
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
            var prid = $("#profileidTextBox").val();
           // alert(prid);
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts.aspx/primaryl',
                data: "{'prid':'"+prid+"'}",
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
                    alert("wrong p");
                }



            });
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts.aspx/Secondarylang',
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
                    alert("wrong s");
                }



            });
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts.aspx/PhotoIdentity',
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
                    alert("wrong pi");
                }



            });
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts.aspx/CardType',
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
                    alert("wrongct");
                }



            });
            return false;



        });



    </script>




                    
                    
                    
    
    <script>

        $(document).ready(function () {
            $("#Btn2").click(function (e) {

                var isValid = true;
                if ($.trim($("#contsalesrepDropDownList option:selected").text()) == "") {
                    isValid = false;
                    alert("Select Sales Rep");
                    $("#contsalesrepDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#contsalesrepDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#TOManagerDropDownList option:selected").text()) == "") {
                    isValid = false;
                    alert("Select TO Manager");
                    $("#TOManagerDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#TOManagerDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#ButtonUpDropDownList option:selected").text()) == "") {
                    isValid = false;
                    alert("Select Button Up");
                    $("#ButtonUpDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#ButtonUpDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }


                var isValid = true;
                if ($.trim($("#dealstatusDropDownList option:selected").text()) == "") {
                    isValid = false;
                    alert("Select Deals Status");
                    $("#dealstatusDropDownList").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#dealstatusDropDownList").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                
                


                var isValid = true;
                if ($.trim($("#totalfinpriceIntaxTextBox").val()) == "") {
                    isValid = false;
                    alert("Enter Total Price Including Tax");
                    $("#totalfinpriceIntaxTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#totalfinpriceIntaxTextBox").css({

                        "border": "",

                        "background": ""

                    });
                    // alert('Thank you for submitting');
                    //$("#TextBox1").val("");
                }

                var isValid = true;
                if ($.trim($("#intialdeppercentTextBox").val()) == "") {
                    isValid = false;
                    alert("Enter Initial Amount");
                    $("#intialdeppercentTextBox").css({

                        "border": "1px solid red",

                        "background": "#FFCECE"
                    });
                    if (isValid == false)
                        e.preventDefault();


                } else {
                    $("#intialdeppercentTextBox").css({

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
            // hide show manager based on venue group
            
            
            var value = $("#GroupVenueDropDownList option:selected").text();
            // alert(value);
            if (value == "Coldline") {

               // $("#Label205").show();
               //$("#ManagerDropDownList").show();

                $("#Label205").css("display", "block");
                $("#ManagerDropDownList").css("display", "block");
            }
            else {
             //   $("#Label205").hide();
              //  $("#ManagerDropDownList").hide();
                $("#Label205").css("display", "none");
                $("#ManagerDropDownList").css("display", "none");
            }
            //end//
           
            $("#Label11").hide();
            $("#MemType1DropDownList").hide();
            $("#Label15").hide();
            $("#Memno1TextBox").hide();
            $("#Label114").hide();
            $("#TypeDropDownList").hide();
            
            $("#Label12").hide();
            $("#MemType2DropDownList").hide();

            $("#Label16").hide();
            $("#Memno2TextBox").hide();



            //  MarketingPrgmDropDownList
            var marketingValue = $("#MarketingProgramDropDownList option:selected").text();
           // alert(marketingValue);
            //alert(marketingValue);
            if (marketingValue == "OWNER" || marketingValue == "Owner" || marketingValue == "owner") {

                $("#Label11").show();
                $("#MemType1DropDownList").show();
                $("#Label15").show();
                $("#Memno1TextBox").show();
                $("#Label114").hide();
                $("#TypeDropDownList").hide();
              
                
                
            } else {
                $("#Label11").show();
                $("#MemType1DropDownList").show();
                $("#Label15").hide();
                $("#Memno1TextBox").hide();
                $("#Label114").show();
                $("#TypeDropDownList").show();

            }

        });

    </script>

    

    <script>
        $(document).ready(function () {

            // loading country code primary for primary as per country//
            $("#primarycountryDropDownList").change(function () {
                var country = $("#primarycountryDropDownList option:selected").text();
               
                 //alert(country);

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadCountryCode',
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


                var country = $("#primarycountryDropDownList option:selected").text();

                //alert(country);
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#primaryalternateDropDownList").empty();
                        $("#primaryalternateDropDownList").append("<option disabled selected value>select an option  </option>");
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


                // loding all country code office for primary as per country//


                var country = $("#primarycountryDropDownList option:selected").text();
                //alert(country);
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#pofficecodeDropDownList").empty();
                        $("#pofficecodeDropDownList").append("<option disabled selected value>select an option  </option>");
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
            $("#secondarycountryDropDownList").change(function () {
                var country = $("#secondarycountryDropDownList option:selected").text();
               // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_Contracts.aspx/LoadCountryCode',
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


                var country = $("#secondarycountryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#secondaryalternateDropDownList").empty();
                        $("#secondaryalternateDropDownList").append("<option disabled selected value>select an option  </option>");
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


                var country = $("#secondarycountryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sofficecodeDropDownList").empty();
                        $("#sofficecodeDropDownList").append("<option disabled selected value>select an option  </option>");
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
            $("#sp1countryDropDownList").change(function () {
                var country = $("#sp1countryDropDownList option:selected").text();
                //  alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp1mobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp1mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 1 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 1 as per country//

                
                
                var country = $("#sp1countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp1alternateDropDownList").empty();
                        $("#sp1alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp1alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
            $("#sp2countryDropDownList").change(function () {
                var country = $("#sp2countryDropDownList option:selected").text();
                // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp2mobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp2mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 1 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 2 as per country//

                
                
                var country = $("#sp2countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp2alternateDropDownList").empty();
                        $("#sp2alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp2alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
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
            $("#sp3countryDropDownList").change(function () {
                var country = $("#sp3countryDropDownList option:selected").text();
                // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp3mobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp3mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 3 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 3 as per country//

                
                
                var country = $("#sp3countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp3alternateDropDownList").empty();
                        $("#sp3alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp3alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 3 as per country");
                    }

                });
                return false;

                //end//
            });
        });


    </script>

    <script>
        $(document).ready(function () {
            
            // loding country code primary for sub profile 4 as per country//
            $("#sp4countryDropDownList").change(function () {
                var country = $("#sp4countryDropDownList option:selected").text();
                // alert(country);


                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp4mobileDropDownList").empty();
                        //   $("#subprofile3mobileDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp4mobileDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding country code primary for sub profile 4 as per country");
                    }



                });

                // end//


                // loding all country code alternative for sub profile 4 as per country//

                
                
                var country = $("#sp4countryDropDownList option:selected").text();
                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadAllCountryCode',
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                        // alert(data.d);
                        $("#sp4alternateDropDownList").empty();
                        $("#sp4alternateDropDownList").append("<option disabled selected value>select an option  </option>")
                        subJson = JSON.parse(data.d);

                        // alert(subJson);
                        $.each(subJson, function (key, value) {
                            $.each(value, function (index1, value1) {

                                $("#sp4alternateDropDownList").append("<option value='" + value1[0] + "'> " + value1[0] + "</option>");
                            });
                        });
                    },
                    error: function () {
                        alert("wrong loding all country code alternative for sub profile 4 as per country");
                    }

                });
                return false;

                //end//
            });
        });


    </script>



    <script>

        $(document).ready(function () {
            // loading states on country////
            $("#AddCountryDropDownList").change(function () {
                var country = $("#AddCountryDropDownList option:selected").text();
                //   alert(country);

                $.ajax({

                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    url: 'Indian_contracts.aspx/LoadStates',
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
    $(document).ready(function(){
        $.ajax({

            type: 'post',
            contentType: "application/json; charset=utf-8",
            url: 'Indian_contracts.aspx/loadRegTerms',
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

    <script>
        $(document).ready(function () {
            $("#MarketingProgramDropDownList").change(function () {
                var marketingValue1 = $("#MarketingProgramDropDownList option:selected").val();
    
              // alert(marketingValue1);
                if (marketingValue1 == "OWNER" || marketingValue1 == "Owner" || marketingValue1 == "owner") {
                   // alert("hiee");
                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").show();
                    $("#Memno1TextBox").show();
                    $("#Label114").hide();
                    $("#TypeDropDownList").hide();



                } else {
                    $("#Label11").show();
                    $("#MemType1DropDownList").show();
                    $("#Label15").hide();
                    $("#Memno1TextBox").hide();
                    $("#Label114").show();
                    $("#TypeDropDownList").show();

                }



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
                        alert('Enter valid number');


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
            // $("#hidden1").hide();
            $('#lblregcoll').css('display', 'none');
            $('#regcollectiontermTextBox').css('display', 'none');
            $('#lblregcollamt').css('display', 'none');
            $('#regcollamtTextBox').css('display', 'none');
            $("#ca3").click(function () {
                if ($("#ca3").is(':checked')) {

                    $('#lblregcoll').css('display', 'block');
                    $('#regcollectiontermTextBox').css('display', 'block');
                    $('#lblregcollamt').css('display', 'block');
                    $('#regcollamtTextBox').css('display', 'block');
                } else {
                    $('#lblregcoll').css('display', 'none');
                    $('#regcollectiontermTextBox').css('display', 'none');
                    $('#lblregcollamt').css('display', 'none');
                    $('#regcollamtTextBox').css('display', 'none');
                }
            });
        });


    </script>

      <script>

        $(document).ready(function () {
          
            $.ajax({

                type: 'post',
                contentType: "application/json; charset=utf-8",
                url: 'Indian_contracts.aspx/loadgiftdata',
                data: "{}",
                async: false,
                success: function (data) {
                   // alert(data.d);

                    subJson = JSON.parse(data.d);


                    $.each(subJson, function (key, value) {
                        $.each(value, function (index1, value1) {



                            var valArr = [value1[0]],

                           
                            i = 0, size = valArr.length,
                            $options = $('#giftoptionDropDownList option');
                         //   alert(size);
                         

                            for (i; i < size; i++) {
                                //alert(valArr[i]);

                                $("#giftoptionDropDownList option[value='" + valArr[i] + "']").attr('selected', true);
                               // $("#giftoptionDropDownList option:contains('"+valArr[i]+"')").attr("selected", true);

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
