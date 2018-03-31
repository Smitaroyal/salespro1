<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="Contractsite_test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Page</title>
      <script type="text/javascript">

          
           function topFunction()
           {
              // alert('hi');

               //window.location.href = "~/WebSite5/production/Dashboard.aspx";
               window.location='<%= ResolveUrl("~/WebSite5/production/Dashboard.aspx") %>'

           }
          </script>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
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
       
        .grid{ border-collapse:collapse;text-align:center;

                   font-family: "Helvetica Neue",Roboto,Arial,"Droid Sans",sans-serif;
    font-size: 18px;
    font-weight: 400;
    color:#73879C;
      border-radius: 10px;
        }

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
    border: none;

      border-radius: 10px;
}

#GridView1{
    width:auto;
}

#searchbyTextBox {
              
        
    height:40px;
    width: 90%;
     font-family: "Helvetica Neue",Roboto,Arial,"Droid Sans",sans-serif;
    font-size: 20px;
    font-weight: 400;
    color:#73879C;
    display:inline-block;
}
#Button1{
height:45px;
width: 8%;
 font-family: "Helvetica Neue",Roboto,Arial,"Droid Sans",sans-serif;
    font-size: 18px;
    font-weight: 400;
    color:#73879C;
    display:inline-block;
}

body {
    font-family: "Helvetica Neue",Roboto,Arial,"Droid Sans",sans-serif;
    font-size: 20px;
    font-weight: 400;
    color:#73879C;
}

@media only screen 
  and (min-device-width: 768px) 
  and (max-device-width: 1024px) 
  and (-webkit-min-device-pixel-ratio: 1) {

    #searchbyTextBox {
              
        
   
    width: 80%;
    
}

}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <div id="searchbar">
            <asp:TextBox ID="searchbyTextBox" runat="server"></asp:TextBox>&nbsp<asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />

        </div>

        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="grid" Width="100%" OnRowCommand="GridView1_RowCommand"  >
            <Columns>
                <asp:TemplateField HeaderText="Profile_ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="Linkbtn1" OnClick="LinkbtnClick" Text='<%#Eval("Profile_ID") %>' runat="server">Linkbtn</asp:LinkButton>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:BoundField HeaderText="Profile ID" DataField="Profile_ID" Visible="false" />
                <asp:BoundField HeaderText="Title" DataField="Title" />
                <asp:BoundField HeaderText="Name" DataField="Name" />
                <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Tour Date" DataField="Tour Date" />
                <asp:BoundField HeaderText="Tour_Id" DataField="Tour_Id" />
                

                 <asp:TemplateField HeaderText="Guest Card">
                    <ItemTemplate>
                        <asp:LinkButton ID="Linkbtn2"  CommandArgument='<%#Eval("Profile_ID") %>' CommandName="VIEW" runat="server">Guest Card</asp:LinkButton>
                    </ItemTemplate>

                </asp:TemplateField>
              

            </Columns>
        </asp:GridView>
        <button onclick="topFunction();return false;" id="myBtn" title="Go to top">Home</button>
    </div>
    </form>
</body>
</html>
