<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="WebSite5_production_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title></title>

  
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
   
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
   
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <link href="../production/css/login.css" rel="stylesheet">
    
   

   
    <link href="../build/css/custom.min.css" rel="stylesheet">

  
</head>
<body class='login'>

    <form id="form1" runat="server">

        <div class="container-fluid">
            <div class="row">
                <div>
                    <nav class="navbar navbar-default navbar-fixed-top">
<!--<nav style="background-color:red;height:23px;padding:1px 20px 1px 10px;"><p style="font:bold;color:white;font-size:18px;font-family:Arial,Helvetica,sans-serif;">TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TESTING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p></nav>-->
                        <div class="navbar-header">
                        </div>
                        <ul class="nav navbar-nav">
                        </ul>

                    </nav>

                </div>
                <div class="col-md-12">
                    <div class="col-md-1">

                    </div>
                    <div class="col-md-2" >
                        

                    </div>

                    <div id="all" >
                        <div class="col-md-2" id="img">
                             <img src="../production/images/k.png" class="img-square" alt="" width="120" height="160"/>
                           
                            <div id="hellll"></div>
                        </div>
                        

                         <div class="col-md-3" id="move" style="text-align: left">
                             
                         
                        <div id="hell" >
                           
                           
                          <!--  <img src="../production/images/karmagroup.png" class="img-circle" alt="" width="250" height="100"/>-->
                             
                               
                        </div>
                             
                        <div class="input-group" id="user">
                          
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                           
                             
                            <asp:TextBox ID="TextBox1" class="form-control" placeholder="Username" runat="server"></asp:TextBox>
                        </div>

                        <div class="input-group"  id="pass">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="TextBox2" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                             <div class="form-check">
                                 <label class="form-check-label">
                                   <%-- <asp:CheckBox ID="CheckBox1" class="form-check-input" runat="server" />
                                     Remember Me--%>
                                      <a href="forgotpassword.aspx" >Forgot password?</a>

                                 </label>
                             </div>

                             <div>

                            <asp:Button ID="Button1"  class="btn btn-default  btn btn-block" runat="server" Text="Log In" />


                        </div>
                             <div id="googlesign">
                                 <center><a href="../../Contractsite/googlesign.aspx"><img border="0" alt="W3Schools" src="../../Contractsite/img/google2.jpg" width="50" height="50"></a></centre> 
                             </div>
                             <div id="helll"></div>
                    
                    </div>
                    </div>
                   
                     <div class="col-md-4">
                    </div>

                </div>
                <div>
         
                    <nav class="navbar navbar-default navbar-fixed-bottom" id="bottom">

                        <div class="navbar-header">

                        </div>
                        <ul class="nav navbar-nav">
                            
                        </ul>

                    </nav>

                </div>

            </div>

        </div>


    </form>

</body>
</html>
