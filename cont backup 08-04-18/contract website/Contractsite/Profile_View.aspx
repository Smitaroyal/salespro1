<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile_View.aspx.cs" Inherits="Contractsite_Profile_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 323px;
        }
        .auto-style2 {
            width: 358px;
        }
        .auto-style3 {
            width: 258px;
        }
        .auto-style4 {
            width: 214px;
        }
        .auto-style7 {
            width: 64px;
        }
        .auto-style8 {
            width: 77px;
        }
        .auto-style9 {
            width: 102px;
        }
        .auto-style10 {
            width: 590px;
        }
        .auto-style11 {
            width: 76px;
        }
        .auto-style12 {
            width: 308px;
        }
        .auto-style13 {
            width: 125px;
        }
        .auto-style14 {
            width: 152px;
        }
        .auto-style15 {
            width: 140px;
        }
        .auto-style16 {
            height: 42px;
        }
        .auto-style17 {
            height: 23px;
        }
        .auto-style18 {
            height: 23px;
            width: 71px;
        }
        .auto-style19 {
            width: 84px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Image ID="Image1" runat="server" BorderStyle="None" ImageUrl="~/Contractsite/header.jpg" Height="307px" Width="1223px" />
        <br />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">
        <asp:Label ID="Label1" runat="server" BorderStyle="None" Text="NAME"></asp:Label>
                </td>
                <td class="auto-style1"><asp:Label ID="lblptitle" runat="server"></asp:Label>
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
        <asp:Label ID="Label2" runat="server" BorderStyle="None" Font-Italic="True" Text="First Name" Font-Size="Small" Width="87px"></asp:Label>
                </td>
                <td class="auto-style1"><asp:Label ID="lblpfname" runat="server" BorderStyle="None" Width="287px"></asp:Label>
                </td>
                <td class="auto-style19">
        <asp:Label ID="Label3" runat="server" BorderStyle="None" Font-Italic="True" Text="Last Name" Font-Size="Small" Width="89px"></asp:Label>
                </td>
                <td class="auto-style2"><asp:Label ID="lblplname" runat="server" BorderStyle="None" Width="287px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
        <asp:Label ID="Label4" runat="server" BorderStyle="None" Text="NAME"></asp:Label>
                </td>
                <td class="auto-style1"><asp:Label ID="lblstitle" runat="server"></asp:Label>
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
        <asp:Label ID="Label5" runat="server" BorderStyle="None" Font-Italic="True" Text="First Name" Font-Size="Small"></asp:Label>
                </td>
                <td class="auto-style1"><asp:Label ID="lblsfname" runat="server" BorderStyle="None" Width="261px"></asp:Label>
                </td>
                <td class="auto-style19">
        <asp:Label ID="Label6" runat="server" BorderStyle="None" Font-Italic="True" Text="Last Name" Font-Size="Small"></asp:Label>
                </td>
                <td class="auto-style2"><asp:Label ID="lblslname" runat="server" BorderStyle="None" Width="230px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
        <asp:Label ID="Label7" runat="server" BorderStyle="None" Text="NATIONALITY :" Font-Size="Small"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
        <asp:Label ID="Label8" runat="server" BorderStyle="None" Font-Italic="True" Text="Husband" Font-Size="Small"></asp:Label>
                </td>
                <td class="auto-style1"><asp:Label ID="lblpnationality" runat="server" BorderStyle="None" Width="203px"></asp:Label>
                </td>
                <td class="auto-style19">
        <asp:Label ID="Label9" runat="server" BorderStyle="None" Font-Italic="True" Text="Wife" Width="43px" Font-Size="Small"></asp:Label>
                </td>
                <td class="auto-style2"><asp:Label ID="lblsnationality" runat="server" BorderStyle="None" Width="192px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Label ID="Label10" runat="server" BorderStyle="None" Text="LIVING PERMANENTLY IN :" Width="212px" Font-Size="Small"></asp:Label>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style4">
        <asp:Label ID="Label11" runat="server" BorderStyle="None" Font-Italic="True" Text="Country"></asp:Label>
                </td>
                <td>
        <asp:Label ID="lblpcountry" runat="server" BorderStyle="None" Width="245px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="Label12" runat="server" BorderStyle="None" Font-Italic="True" Text="Phone"></asp:Label>
                </td>
                <td>
        <asp:Label ID="lblphone" runat="server" BorderStyle="None" Width="331px" Height="33px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="Label13" runat="server" BorderStyle="None" Font-Italic="True" Text="Email"></asp:Label>
                </td>
                <td>
        <asp:Label ID="lblemail" runat="server" BorderStyle="None" Width="310px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
            <table style="width:100%;">
            <tr>
                <td class="auto-style4">
        <asp:Label ID="Label14" runat="server" BorderStyle="None" Text="ARE YOU CURRENTLY EMPLOYED :" Width="231px" Font-Size="Small"></asp:Label>
                </td>
                <td>
        <asp:Label ID="lblemployment" runat="server" BorderStyle="None" Width="184px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="Label15" runat="server" BorderStyle="None" Text="ARE YOU :" Width="113px" Font-Size="Small"></asp:Label>
                </td>
                <td>
        <asp:Label ID="lblmaritalstatus" runat="server" BorderStyle="None" Width="184px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
        <br />
        <asp:Label ID="Label20" runat="server" BorderStyle="None" Text="WHICH AGE GROUP DO YOU FALL UNDER  :" Width="332px" Font-Size="Small"></asp:Label>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style11">
        <asp:Label ID="Label21" runat="server" BorderStyle="None" Font-Italic="True" Text="Male   :" Width="54px"></asp:Label>
                </td>
                <td class="auto-style7">
        <asp:Label ID="lblmaritalstatus0" runat="server" BorderStyle="None" Width="63px" Font-Size="Small">Under 30</asp:Label>
                </td>
                <td class="auto-style8">
        <asp:Label ID="lblmaritalstatus1" runat="server" BorderStyle="None" Width="56px" Font-Size="Small">Over 30</asp:Label>
                </td>
                <td class="auto-style9">
        <asp:Label ID="lblmaritalstatus2" runat="server" BorderStyle="None" Width="99px" Font-Size="Small">Over 68 Years</asp:Label>
                </td>
                <td>&nbsp;</td>
                <td class="auto-style10">
        <asp:Label ID="Label16" runat="server" BorderStyle="None" Text="DATE OF BIRTH  :" Width="126px" Font-Size="Small"></asp:Label>
        <asp:Label ID="lbldob" runat="server" BorderStyle="None" Width="184px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="Label22" runat="server" BorderStyle="None" Font-Italic="True" Text="Female  :" Width="66px"></asp:Label>
                </td>
                <td class="auto-style7">
        <asp:Label ID="lblmaritalstatus3" runat="server" BorderStyle="None" Width="63px" Font-Size="Small">Under 30</asp:Label>
                </td>
                <td class="auto-style8">
        <asp:Label ID="lblmaritalstatus4" runat="server" BorderStyle="None" Width="57px" Font-Size="Small">Over 30</asp:Label>
                </td>
                <td class="auto-style9">
        <asp:Label ID="lblmaritalstatus5" runat="server" BorderStyle="None" Width="99px" Font-Size="Small">Over 68 Years</asp:Label>
                </td>
                <td>&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style12">
        <asp:Label ID="Label17" runat="server" BorderStyle="None" Text="NAME OF HOTEL YOU ARE STAYING AT  :" Width="272px" Font-Size="Small"></asp:Label>
                </td>
                <td>
        <asp:Label ID="lblhotel" runat="server" BorderStyle="None" Width="184px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style13">
        <asp:Label ID="Label18" runat="server" BorderStyle="None" Text="ARRIVAL DATE :" Width="138px" Font-Size="Small"></asp:Label>
                </td>
                <td class="auto-style14">
        <asp:Label ID="lblcheckindate" runat="server" BorderStyle="None" Width="133px"></asp:Label>
                </td>
                <td class="auto-style15">
        <asp:Label ID="Label19" runat="server" BorderStyle="None" Text="DEPARTURE DATE :" Width="126px" Font-Size="Small"></asp:Label>
                </td>
                <td>
        <asp:Label ID="lblcheckoutdate" runat="server" BorderStyle="None" Width="184px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
        <br />
        <table style="width: 100%;">
            <tr>
                <td class="auto-style16">
        <asp:Label ID="Label25" runat="server" BorderStyle="None" Text="YES" Width="51px" Height="28px"></asp:Label>
                </td>
                <td class="auto-style16">
        <asp:Label ID="Label23" runat="server" BorderStyle="None" Text="We understand that Royal Resorts International have invited us to the VIP Preview center here in Jimbaran to showcase the world of Karma Group Memberships, which will take a minimum of 60mintues to qualify for the promotional gift and we confirm that we are participating freely in the program and have the option to leave at any time if we so choose. " Width="1075px" Font-Size="Small"></asp:Label>
                </td>
                <td class="auto-style16"></td>
                <td class="auto-style16"></td>
                <td class="auto-style16"></td>
                <td class="auto-style16"></td>
                <td class="auto-style16"></td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label26" runat="server" BorderStyle="None" Text="YES" Width="51px" Height="21px"></asp:Label>
                </td>
                <td>
        <asp:Label ID="Label27" runat="server" BorderStyle="None" Text="We understand that we are under no cost or obligation to purchase and that this Karma Groups way of advertising its wonderful resorts, beach clubs and spas." Width="1075px" Font-Size="Small"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Image ID="Image2" runat="server" Height="100px" ImageUrl="~/Contractsite/footer.jpg" Width="1223px" />
        <br />
        <br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td class="auto-style17"></td>
                <td class="auto-style18">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Print" />
                </td>
                <td class="auto-style17"></td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
