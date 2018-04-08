<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Searchprofile.aspx.cs" Inherits="Contractsite_Searchprofile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Page</title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
       
        .grid{ border-collapse:collapse;text-align:center}

.grid td{padding:10px ;border:1px solid #c1c1c1;color:#444;font-size:1em;}

.grid th{padding:4px 2px ; color:#ffffff; height:10px;
         
         background: #2175ac;
         
         border:1px solid #c1c1c1;font-size:1em;text-align:center ;}
         
.grid th a{color:White;text-decoration:none  ; }

.grid th a:hover{color:#444;text-decoration:none  ;}

#searchbar {
    height:45px;
    width:auto;
    background:#2175ac;
      font-family: "Helvetica Neue",Roboto,Arial,"Droid Sans",sans-serif;
    font-size: 18px;
    font-weight: 400;
    color:#73879C;
    padding:10px 10px;
}

#searchbyTextBox {
                  
    height:40px;
    width: 90%;
     font-family: "Helvetica Neue",Roboto,Arial,"Droid Sans",sans-serif;
    font-size: 20px;
    font-weight: 400;
    color:#73879C;
}
#Button1{
height:45px;
width: 120px;
 font-family: "Helvetica Neue",Roboto,Arial,"Droid Sans",sans-serif;
    font-size: 18px;
    font-weight: 400;
    color:#73879C;
}

body {
    font-family: "Helvetica Neue",Roboto,Arial,"Droid Sans",sans-serif;
    font-size: 20px;
    font-weight: 400;
    color:#73879C;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--<table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" BorderStyle="None" Font-Bold="True" Text="Search By" Width="89px"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem>Name</asp:ListItem>
                        <asp:ListItem>Phone No</asp:ListItem>
                        <asp:ListItem>Profile ID</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                
                
            </tr>
            <tr>
                <td aria-busy="False">
    
                </td>
               
            </tr>
        </table>-->

        <div id="searchbar">
            <asp:TextBox ID="searchbyTextBox" runat="server"></asp:TextBox>&nbsp<asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />

        </div>

        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="grid" Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Profile_ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="Linkbtn1" OnClick="LinkbtnClick" Text='<%#Eval("Profile_ID") %>' runat="server">Linkbtn</asp:LinkButton>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:BoundField HeaderText="Profile ID" DataField="Profile_Primary_ID" />
                <asp:BoundField HeaderText="Profile Primary_Title" DataField="Profile_Primary_Title" />
                <asp:BoundField HeaderText="Profile Fname" DataField="Profile_Primary_Fname" />
                <asp:BoundField HeaderText="Profile Lname" DataField="Profile_Primary_Lname" />

            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
