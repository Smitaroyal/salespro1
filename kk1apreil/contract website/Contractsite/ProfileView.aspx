<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileView.aspx.cs" Inherits="ProfileView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Label ID="Label1" runat="server" BorderStyle="None" Text="NAME"></asp:Label>
&nbsp;<asp:Label ID="lblptitle" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" BorderStyle="None" Font-Italic="True" Text="First Name"></asp:Label>
&nbsp;<asp:Label ID="lblpfname" runat="server" BorderStyle="None" Width="333px"></asp:Label>
        <asp:Label ID="Label3" runat="server" BorderStyle="None" Font-Italic="True" Text="Last Name"></asp:Label>
&nbsp;<asp:Label ID="lblplname" runat="server" BorderStyle="None" Width="333px"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" BorderStyle="None" Text="NAME"></asp:Label>
&nbsp;<asp:Label ID="lblstitle" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" BorderStyle="None" Font-Italic="True" Text="First Name"></asp:Label>
&nbsp;<asp:Label ID="lblsfname" runat="server" BorderStyle="None" Width="333px"></asp:Label>
        <asp:Label ID="Label6" runat="server" BorderStyle="None" Font-Italic="True" Text="Last Name"></asp:Label>
&nbsp;<asp:Label ID="lblslname" runat="server" BorderStyle="None" Width="333px"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" BorderStyle="None" Text="NATIONALITY :"></asp:Label>
&nbsp;<br />
        <br />
        <asp:Label ID="Label8" runat="server" BorderStyle="None" Font-Italic="True" Text="Husband"></asp:Label>
&nbsp;<asp:Label ID="lblpnationality" runat="server" BorderStyle="None" Width="333px"></asp:Label>
        <asp:Label ID="Label9" runat="server" BorderStyle="None" Font-Italic="True" Text="Wife" Width="43px"></asp:Label>
&nbsp;<asp:Label ID="lblsnationality" runat="server" BorderStyle="None" Width="333px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" BorderStyle="None" Text="LIVING PERMANENTLY IN :" Width="216px"></asp:Label>
        <br />
        <asp:Label ID="Label11" runat="server" BorderStyle="None" Font-Italic="True" Text="Country"></asp:Label>
&nbsp;&nbsp;
        <asp:Label ID="lblpcountry" runat="server" BorderStyle="None" Width="333px"></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" BorderStyle="None" Font-Italic="True" Text="Phone"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblphone" runat="server" BorderStyle="None" Width="333px"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" BorderStyle="None" Font-Italic="True" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblemail" runat="server" BorderStyle="None" Width="333px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label14" runat="server" BorderStyle="None" Text="ARE YOU CURRENTLY EMPLOYED :" Width="286px"></asp:Label>
        <br />
        <asp:Label ID="lblemployment" runat="server" BorderStyle="None" Width="184px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label15" runat="server" BorderStyle="None" Text="ARE YOU :" Width="113px"></asp:Label>
        <br />
        <asp:Label ID="lblmaritalstatus" runat="server" BorderStyle="None" Width="184px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label20" runat="server" BorderStyle="None" Text="WHICH AGE GROUP DO YOU FALL UNDER  :" Width="332px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label16" runat="server" BorderStyle="None" Text="DATE OF BIRTH  :" Width="163px"></asp:Label>
        &nbsp;&nbsp;
        <br />
        <asp:Label ID="Label21" runat="server" BorderStyle="None" Font-Italic="True" Text="Male   :" Width="54px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblmaritalstatus0" runat="server" BorderStyle="None" Width="63px">Under 30</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblmaritalstatus1" runat="server" BorderStyle="None" Width="74px">Over 30</asp:Label>
&nbsp;
        <asp:Label ID="lblmaritalstatus2" runat="server" BorderStyle="None" Width="99px">Over 68 Years</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbldob" runat="server" BorderStyle="None" Width="184px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label22" runat="server" BorderStyle="None" Font-Italic="True" Text="Female  :" Width="66px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblmaritalstatus3" runat="server" BorderStyle="None" Width="63px">Under 30</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblmaritalstatus4" runat="server" BorderStyle="None" Width="74px">Over 30</asp:Label>
&nbsp;
        <asp:Label ID="lblmaritalstatus5" runat="server" BorderStyle="None" Width="99px">Over 68 Years</asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label17" runat="server" BorderStyle="None" Text="NAME OF HOTEL YOU ARE STAYING AT  :" Width="339px"></asp:Label>
        <br />
        <asp:Label ID="lblhotel" runat="server" BorderStyle="None" Width="184px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label18" runat="server" BorderStyle="None" Text="ARRIVAL DATE :" Width="138px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label19" runat="server" BorderStyle="None" Text="DEPARTURE DATE :" Width="159px"></asp:Label>
        <br />
        <asp:Label ID="lblcheckindate" runat="server" BorderStyle="None" Width="184px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblcheckoutdate" runat="server" BorderStyle="None" Width="184px"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label25" runat="server" BorderStyle="None" Text="YES" Width="51px" Height="28px"></asp:Label>
        &nbsp;
        <asp:Label ID="Label23" runat="server" BorderStyle="None" Text="We understand that Royal Resorts International have invited us to the VIP Preview center here in Jimbaran to showcase the world of Karma Group Memberships, which will take a minimum of 60mintues to qualify for the promotional gift and we confirm that we are participating freely in the program and have the option to leave at any time if we so choose. " Width="1075px"></asp:Label>
&nbsp;<br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label26" runat="server" BorderStyle="None" Text="YES" Width="51px" Height="21px"></asp:Label>
        <asp:Label ID="Label27" runat="server" BorderStyle="None" Text="We understand that we are under no cost or obligation to purchase and that this Karma Groups way of advertising its wonderful resorts, beach clubs and spas." Width="1075px"></asp:Label>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
