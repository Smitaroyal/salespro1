<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="WebSite5_production_Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title> </title>
    
    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
   
    <style>

    #img1 {
            text-align: center;

           -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
-moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }

      #success-alert,#danger-alert,#danger-alert1{
            display:none;
        }
      
      #update,#userName,#head,#Password,#Name,#userStatus,#Office,#Group,#Department,#directory,#insert,#Email,#Title{
          display:none;
      }
      #TextBox5{
          text-align:center;
      }
</style>
   
    <!-- bootstrap-wysiwyg -->
    <link href="../vendors/google-code-prettify/bin/prettify.min.css" rel="stylesheet">

    <!-- Custom styling plus plugins -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
    <script src="jquery-3.2.1.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.2.1.min.js"></script>
</head>
<body class="nav-md">
   
    <div class="container body">
      <div class="main_container">
        <div class="col-md-3 left_col">
          <div class="left_col scroll-view">
               <div class="navbar nav_title" style="border-bottom:2px;   height:auto; color:#172D44;  " id="img1">
                 <img src="../production/images/k.png"  class="img-square"  alt="" width="40" height="40"/> <br />
                <a href="#" class="site_title"> <span style="opacity: 0.5;">Karma Group</span></a>
            </div>

            <div class="clearfix"></div>

            <!-- menu profile quick info -->
            <div class="profile clearfix">
              <div class="profile_pic">
                <img src="images/img.jpg" alt="..." class="img-circle profile_img">
              </div>
              <div class="profile_info">
                <span>Welcome,</span>
              <h2><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2>
              </div>
            </div>
            <!-- /menu profile quick info -->

            <br />

            <!-- sidebar menu -->
            <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
              <div class="menu_section">
                <h3>General</h3>
                <ul class="nav side-menu">
                <%Response.Write(getdata()); %>
                </ul>
              </div>
             

            </div>
            <!-- /sidebar menu -->

            <!-- /menu footer buttons -->
            <div class="sidebar-footer hidden-small">
              <a data-toggle="tooltip" data-placement="top" title="Settings">
                <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
              </a>
              <a data-toggle="tooltip" data-placement="top" title="FullScreen">
                <span class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span>
              </a>
             <a data-toggle="tooltip" data-placement="top" title="Home" href="Dashboard.aspx">
                <span class="glyphicon glyphicon-home" aria-hidden="true"></span>
              </a>

              <a data-toggle="tooltip" data-placement="top" title="Logout" href="logout.aspx">
                <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
              </a>
            </div>
            <!-- /menu footer buttons -->
          </div>
        </div>

        <!-- top navigation -->
        <div class="top_nav">
          <div class="nav_menu">
            <nav>
              <div class="nav toggle">
                <a id="menu_toggle"><i class="fa fa-bars"></i></a>
              </div>

              <ul class="nav navbar-nav navbar-right">
                <li class="">
                  <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    <img src="images/img.jpg" alt=""/><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <span class=" fa fa-angle-down"></span>
                  </a>
                  <ul class="dropdown-menu dropdown-usermenu pull-right">
                    <li><a href="Profile_Page.aspx">Change Password</a></li>
                   
                    <li><a href="javascript:;">Help</a></li>
                    <li><a href="logout.aspx"><i class="fa fa-sign-out pull-right"></i> Log Out</a></li>
                  </ul>
                </li>
              </ul>
            </nav>
          </div>
        </div>
        <!-- /top navigation -->

        <!-- page content -->
           <form id="form1" runat="server">
        <div class="right_col" role="main">
          <div class="">

           

            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12">
                <div class="x_panel">
                      <div class="alert alert-success" id="success-alert">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Success! </strong>
                        
                    </div>
                     <div class="alert alert-danger" id="danger-alert">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Something went wrong! </strong>
                        
                    </div>
                     <div class="alert alert-danger" id="danger-alert1">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Enter Details! </strong>
                        
                    </div>
                <div class="container-fluid">
                    <button type="button" id="insertButton" class="btn btn-primary pull-right btn-block">Insert</button>
                    <button type="button" id="view" class="btn btn-primary pull-right btn-block">View</button>
          <div class="row">
          <div class="col-md-12 " id="head" ><br />
        <h3 class="text-center">ADD USERS</h3>
              </div>
              </div>
            </div>
              <br /><br />
        <div class="container-fluid">
          <div class="row"> 
              <div class="col-md-3" id="userName">
                  <div class="form-group">
                      <label for="sel1">User Name:</label>
                      <asp:TextBox ID="TextBox1" class="form-control pull-right" placeholder="Enter Username"  runat="server" ></asp:TextBox>
                     
                  </div>
              </div>

              <div class="col-md-3" id="Password">
                  <div class="form-group">
                      <label for="sel1">Password:</label>
                      <asp:TextBox ID="TextBox2" class="form-control pull-right" placeholder="Enter Password" runat="server"></asp:TextBox>
                  </div>
              </div>
                 <div class="col-md-3" id="Name">
                  <div class="form-group">
                      <label for="sel1">Name:</label>
                      <asp:TextBox ID="TextBox3" class="form-control pull-right" placeholder="Enter Name" runat="server" ></asp:TextBox>
                     
                  </div>
              </div>
              </div>
             </div>
          <div class="container-fluid">
            <div class="row">
                 <div class="col-md-3" id="Email">
                  <div class="form-group">
                      <label for="sel1">Email:</label>
                      <asp:TextBox ID="TextBox4" class="form-control pull-right" placeholder="Enter Email"  runat="server" ></asp:TextBox>
                     
                  </div>
              </div>
               <div class="col-md-3" id="Title">
                  <div class="form-group">
                      <label for="sel1">Title:</label>
                      <asp:TextBox ID="TextBox6" class="form-control pull-right" placeholder="Enter Title"  runat="server" ></asp:TextBox>
                     
                  </div>
              </div>

               <div class="col-md-3" id="userStatus">
                  <div class="form-group">
                      <label for="sel1">Status:</label>
                      <select class="form-control"  id="status">
                          <option disabled selected value>--Select an Option--</option>
                          <option value="Active">Active</option>
                          <option value="Inactive">Inactive</option>
                      </select>
                  </div>
              </div>
                </div>
              </div>
                     <div class="container-fluid">
                         <div class="row">
              <div class="col-md-3" id="Office">
                  <div class="form-group">
                      <label for="sel1">Office:</label>
                      <select class="form-control"  id="office">
                          <option disabled selected value>--Select an Option--</option>
                         <option value="IVO">IVO</option>
                          <option value="HML">HML</option>
                           <option value="ATH">ATH</option>
                      </select>
                  </div>
              </div>
              <div class="col-md-3" id="Department">
                  <div class="form-group">
                      <label for="sel1">Department:</label>
                      <select class="form-control"  id="department">
                          <option disabled selected value>--Select an Option--</option>
                     <%Response.Write(getAllDepartments()); %>
                      </select>
                  </div>
              </div>
              <div class="col-md-3" id="Group">
                  <div class="form-group">
                      <label for="sel1">Group:</label>
                      <select class="form-control"  id="group">
                          <option disabled selected value>--Select an Option--</option>
                         <%Response.Write(getAllGroups()); %>
                      </select>
                  </div>
              </div>
             

              <div class="col-md-2">
                  <label for="sel1">&nbsp;</label>
                  
                <button type="button"  runat="server" id="insert" class="btn btn-primary pull-right btn-block">Insert</button>
                   <label for="sel1">&nbsp;</label>
                 <button type="button"  runat="server" id="update" class="btn btn-primary pull-right btn-block">Update</button>
                
              </div>

              </div>
             </div>
        
                     <div class="container-fluid" id="directory">
       <div class="row">
              
                   <div class="col-md-12 " "><br />
                        <h3 class="text-center">USERS DIRECTORY</h3>
                               </div>
              
              </div>
                      <div class="row">
                   <div class="col-md-4 col-md-offset-4" >
                    <div class="form-group">
                       <label for="sel1"></label>
                      <asp:TextBox ID="TextBox5" class="form-control pull-right" runat="server" placeholder="Search"  data-table="table table-hover" ></asp:TextBox>
                  </div>
              </div>
          </div><br />
          
           
                    <table class="table table-hover" id="task-table">
            <thead>
                <tr>
                    <th>USER NAME</th>
                    <th>PASSWORD</th>
                    <th>NAME</th>
                    <th>STATUS</th>
                    <th>OFFICE</th>
                   
                    <th>GROUP</th>
                    <th>EMAIL</th>
                    <th>TITLE</th>
                    <th>EDIT</th>
                    <th>DELETE</th>
                </tr>
            </thead>
            <tbody>
                
              
               

                </tbody>
            </table>
                   </div>
                </div>
              </div>
            </div>
          </div>
        </div>

               </form>
        <!-- /page content -->

        <!-- footer content -->
        <footer>
          <div class="pull-right">
           
          </div>
          <div class="clearfix"></div>
        </footer>
        <!-- /footer content -->
      </div>
    </div>

    <!-- compose -->
    <div class="compose col-md-6 col-xs-12">
      <div class="compose-header">
        New Message
        <button type="button" class="close compose-close">
          <span>×</span>
        </button>
      </div>

      <div class="compose-body">
        <div id="alerts"></div>

        <div class="btn-toolbar editor" data-role="editor-toolbar" data-target="#editor">
          <div class="btn-group">
            <a class="btn dropdown-toggle" data-toggle="dropdown" title="Font"><i class="fa fa-font"></i><b class="caret"></b></a>
            <ul class="dropdown-menu">
            </ul>
          </div>

          <div class="btn-group">
            <a class="btn dropdown-toggle" data-toggle="dropdown" title="Font Size"><i class="fa fa-text-height"></i>&nbsp;<b class="caret"></b></a>
            <ul class="dropdown-menu">
              <li>
                <a data-edit="fontSize 5">
                  <p style="font-size:17px">Huge</p>
                </a>
              </li>
              <li>
                <a data-edit="fontSize 3">
                  <p style="font-size:14px">Normal</p>
                </a>
              </li>
              <li>
                <a data-edit="fontSize 1">
                  <p style="font-size:11px">Small</p>
                </a>
              </li>
            </ul>
          </div>

        

          

         

        <div id="editor" class="editor-wrapper"></div>
      </div>

      <div class="compose-footer">
        <button id="send" class="btn btn-sm btn-success" type="button">Send</button>
      </div>
    </div>
    <!-- /compose -->

    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- bootstrap-wysiwyg -->
    <script src="../vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js"></script>
    <script src="../vendors/jquery.hotkeys/jquery.hotkeys.js"></script>
    <script src="../vendors/google-code-prettify/src/prettify.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
  
    
    <script>

        $(document).ready(function () {
     
            $("#insert").click(function () {
                var username = $("#TextBox1").val();
                if (username == "" || username == null) {
                    username = "";
                } else {
                    username = $("#TextBox1").val();
                }
                var password = $("#TextBox2").val();
                if (password == "" || password == null) {
                    password = "";
                } else {
                    password = $("#TextBox2").val();
                }
                var name = $("#TextBox3").val();
                if (name == "" || name == null) {
                    name = "";
                } else {
                    name = $("#TextBox3").val();
                }
                var email = $("#TextBox4").val();
                if (email == "" || email == null) {
                    email = "";
                } else {
                    email = $("#TextBox4").val();
                }
                var title = $("#TextBox6").val();
                if (title == "" || title == null) {
                    title = "";
                } else {
                    title = $("#TextBox6").val();
                }
                var office = $("#office").val();
                if (office=="" || office==null) {
                    office = "";
                }else{
                    office = $("#office").val();
                }
                var department = $("#department").val();
                if (department == "" || department == null) {
                    department = "";
                } else {
                    department = $("#department").val();
                }
                var group = $("#group").val();
                if (group == "" || group == null) {
                    group = "";
                } else {
                    group = $("#group").val();
                }


                $.ajax({

                    type:'Post',
                    url:'Users.aspx/insertUsers',
                    contentType:"application/json; charset=utf-8",
                    data: "{'username':'" + username + "','password':'" + password + "','name':'" + name + "','email':'" + email + "','office':'" + office + "','department':'" + department + "','group':'" + group + "','title':'" + title + "'}",
                    async: false,
                    success: function (data) {
                        $("#TextBox1").val("");
                        $("#TextBox2").val("");
                        $("#TextBox3").val("");
                        $("#TextBox4").val("");
                        $("#TextBox6").val("");
                        $("#status").val('');
                        $("#office").val('');
                        $("#department").val('');
                        $("#group").val('');
                        $("#success-alert").fadeTo(1500, 500).slideUp(500, function () {
                            $("#success-alert").slideUp(500);
                        });
                           
                    },
                    error: function () {
                        $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                            $("#danger-alert").slideUp(500);
                        });
                    }

                });
                return false;


            });
        });
    </script>
    

        <script>
            $(document).ready(function () {
               
                $("#insertButton").click(function () {
                    $("#head").show();
                    $("#Title").show();
                    $("#userName").show();
                    $("#Password").show();
                    $("#userStatus").hide();
                    $("#Name").show();
                    $("#Email").show();
                    $("#Office").show();
                    $("#Group").show();
                    $("#Department").show();
                    $("#insert").show();
                    $("#insertButton").hide();
                    $("#view").show();
                    $("#directory").hide();
                    $("#update").hide();
                    $("#venueID").hide();
                    $("#TextBox1").val("");
                    $("#TextBox2").val("");
                    $("#TextBox3").val("");
                    $("#TextBox4").val("");
                    $("#TextBox6").val("");
                    $("#status").val('');
                    $("#office").val('');
                    $("#department").val('');
                    $("#group").val('');

                });

                $("#view").click(function () {
                    $("#head").hide();
                    $("#userName").hide();
                    $("#insert").hide();
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#directory").show();
                    $("#update").hide();
                    $("#Password").hide();
                    $("#Name").hide();
                    $("#userStatus").hide();
                    $("#Office").hide();
                    $("#Group").hide();
                    $("#Department").hide();
                    $("#Email").hide();
                    $("#Title").hide();
                });
                $(document).on('click','.edit-btn', function () {
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#userName").show();
                    $("#Password").show();
                    $("#userStatus").show();
                    $("#Name").show();
                    $("#Email").show();
                    $("#Title").show();
                    $("#Office").show();
                    $("#Group").show();
                    $("#Department").show();
             
                    $("#update").show();
                
                    $("#directory").hide();
                   

                    var row = $(this).closest("tr");
                    var username = row.find("td:eq(0)").text();
                    var password = row.find("td:eq(1)").text();
                    var name = row.find("td:eq(2)").text();
                    var  userstatus = row.find("td:eq(3)").text();
                    var office = row.find("td:eq(4)").text();
                    var deptCode= row.find("td:eq(5)").text();
                    var groupID = row.find("td:eq(7)").text();
                    var email = row.find("td:eq(9)").text();
                    var title = row.find("td:eq(10)").text();
               
                    $("#TextBox1").val(username);
                    $("#TextBox2").val(password);
                    $("#TextBox3").val(name);
                    $("#TextBox4").val(email);
                    $("#TextBox6").val(title);
                    $("#status option[value='" + userstatus + "']").prop('selected', true);
                    $("#office option[value='" + office + "']").prop('selected', true);
                    $("#department option[value='" + deptCode + "']").prop('selected', true);
                    $("#group option[value='" + groupID + "']").prop('selected', true);
                });
                

            });
        </script>
        



        <script>
            $(document).ready(function () {

                $("#view").click(function () {

                    $.ajax({

                        type: 'Post',
                        url: 'Users.aspx/getAllUsers',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
                           
                            $("#task-table tbody").empty();

                            
                            subJson = JSON.parse(data.d);
                            
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {

                                    $("#task-table tbody").append("<tr><td>" + value1[0] + "</td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td>" + value1[3] + "</td><td>" + value1[4] + "</td><td style='display:none;'>" + value1[5] + "</td><td style='display:none;'>" + value1[6] + "</td><td style='display:none;'>" + value1[7] + "</td><td>" + value1[8] + "</td><td>" + value1[9] + "</td><td>" + value1[10] + "</td><td><button type='button'  class='edit-btn btn btn-primary col-md-12' >Edit</button></td><td><button type='button'  class='delete-btn btn btn-primary col-md-12' >Delete</button></td></tr>");

                                });

                            });
                            
                          
                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                    });
                    return false;


                });
            });

        </script>

        <script>

            $(document).ready(function () {
                $(document).on('click', '.delete-btn', function () {
                    var row = $(this).closest("tr");
                    var username = row.find("td:eq(0)").text();
                    var confirmation = confirm("are you sure you want to delete " + username + " ?");
                   
                    if (confirmation) {

                        $.ajax({
                            type: 'POST',
                            url: 'Users.aspx/deleteUsers',
                            contentType: "application/json; charset=utf-8",
                            data: "{'username':'" + username + "'}",
                            async: false,
                            success: function (data) {

                                $("#success-alert").fadeTo(1500, 500).slideUp(500, function () {
                                    $("#success-alert").slideUp(500);
                                });

                            },
                            error: function () {
                                $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                    $("#danger-alert").slideUp(500);
                                });
                            }

                        });
                        $(this).parents("tr").remove();
                    }
                    return false;
                   

                });


             

                });
      
         
        </script>
        <script>
            $(document).ready(function () {
                $("#update").click(function () {
                    $("#insertButton").hide();
                    $("#view").show();
                
                  
                  
                    
                    var username = $("#TextBox1").val();
                    if (username == "" || username == null) {
                        username = "";
                    } else {
                        username = $("#TextBox1").val();
                    }
                    var password = $("#TextBox2").val();
                    if (password == "" || password == null) {
                        password = "";
                    } else {
                        password = $("#TextBox2").val();
                    }
                    var name = $("#TextBox3").val();
                    if (name == "" || name == null) {
                        name = "";
                    } else {
                        name = $("#TextBox3").val();
                    }
                    var email = $("#TextBox4").val();
                    if (email == "" || email == null) {
                        email = "";
                    } else {
                        email = $("#TextBox4").val();
                    }
                    var title = $("#TextBox6").val();
                    if (title == "" || title == null) {
                        title = "";
                    } else {
                        title = $("#TextBox6").val();
                    }
                    var office = $("#office").val();
                    if (office == "" || office == null) {
                        office = "";
                    } else {
                        office = $("#office").val();
                    }
                    var department = $("#department").val();
                    if (department == "" || department == null) {
                        department = "";
                    } else {
                        department = $("#department").val();
                    }
                    var group = $("#group").val();
                    if (group == "" || group == null) {
                        group = "";
                    } else {
                        group = $("#group").val();
                    }

                    var status = $("#status").val();
                    if (status == "" || status == null) {
                        status = "";
                    } else {
                        status = $("#status").val();
                    }

                    $.ajax({
                        type: 'POST',
                        url: 'Users.aspx/updateUsers',
                        contentType: "application/json; charset=utf-8",
                        data: "{'username':'" + username + "','password':'" + password + "','name':'" + name + "','email':'" + email + "','status':'" + status + "','office':'" + office + "','department':'" + department + "','group':'" + group + "','title':'" + title + "'}",
                        async: false,
                        success: function (data) {
                            $("#TextBox1").val("");
                            $("#TextBox2").val("");
                            $("#TextBox3").val("");
                            $("#TextBox4").val("");
                            $("#TextBox6").val("");
                            $("#status").val('');
                            $("#office").val('');
                            $("#department").val('');
                            $("#group").val('');
                            $("#success-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#success-alert").slideUp(500);
                            });

                        },
                        error: function () {
                            $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                                $("#danger-alert").slideUp(500);
                            });
                        }

                    });

                    return false;


                });

            })
        </script>


        <script>

            $(document).ready(function () {
                $("#update").click(function () {
                    $("#userName").hide();
                    $("#Password").hide();
                    $("#Name").hide();
                    $("#userStatus").hide();
                    $("#Office").hide();
                    $("#Group").hide();
                    $("#Department").hide();
                    $("#Email").hide();
                    $("#Title").hide();
                    $("#update").hide();
                    $("#insertButton").show();

                });
            });
        </script>
        <script>
                                
    (function (document) {
                                
        'use strict';

                                
        var LightTableFilter = (function (Arr) {

                                
            var _input;

                                
            function _onInputEvent(e) {
                                
                _input = e.target;
                                
                var tables = document.getElementsByClassName(_input.getAttribute('data-table'));
                                
                Arr.forEach.call(tables, function (table) {
                                
                    Arr.forEach.call(table.tBodies, function (tbody) {
                                
                        Arr.forEach.call(tbody.rows, _filter);
                                
                    });
                                
                });
                                
            }

                                
            function _filter(row) {
                                
                var text = row.textContent.toLowerCase(), val = _input.value.toLowerCase();
                                
                row.style.display = text.indexOf(val) === -1 ? 'none' : 'table-row';
                                
            }

                                
            return {
                                
                init: function () {
                                
                    var inputs = document.getElementsByClassName('form-control pull-right');
                                
                    Arr.forEach.call(inputs, function (input) {
                                
                        input.oninput = _onInputEvent;
                                
                    });
                                
                }
                                
            };
                                
        })(Array.prototype);

                                
        document.addEventListener('readystatechange', function () {
                                
            if (document.readyState === 'complete') {
                                
                LightTableFilter.init();
                                
            }
                                
        });

                                
    })(document);
        </script>
</body>
</html>
