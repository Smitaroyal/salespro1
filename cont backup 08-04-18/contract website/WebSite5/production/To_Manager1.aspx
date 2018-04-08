<%@ Page Language="C#" AutoEventWireup="true" CodeFile="To_Manager1.aspx.cs" Inherits="WebSite5_production_To_Manager1" %>

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
                 

                     <% Response.Write(getdata()); %>

                   
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
              <a data-toggle="tooltip" data-placement="top" title="Lock">
                <span class="glyphicon glyphicon-eye-close" aria-hidden="true"></span>
              </a>
              <a data-toggle="tooltip" data-placement="top" title="Logout" href="login.html">
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
                    <img src="images/img.jpg" alt=""><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <span class=" fa fa-angle-down"></span>
                  </a>
                  <ul class="dropdown-menu dropdown-usermenu pull-right">
                    <li><a href="javascript:;"> Profile</a></li>
                   
                    <li><a href="javascript:;">Help</a></li>
                    <li><a href="login.aspx"><i class="fa fa-sign-out pull-right"></i> Log Out</a></li>
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

                <div class="container-fluid">
                    <button type="button" id="insertButton" class="btn btn-primary pull-right btn-block">Insert</button>
                    <button type="button" id="view" class="btn btn-primary pull-right btn-block">View</button>
          <div class="row">
          
          <div class="col-md-12 " id="head" ><br />
        <h3 class="text-center">ADD VENUE COUNTRY</h3>
              </div>
              </div>
            </div>
              <br /><br />
        <div class="container-fluid">
          <div class="row"> 
              
                <div class="col-md-2" id="toManagerID">
                  <div class="form-group">
                      <label for="sel1">TO Manager ID:</label>
                      <asp:TextBox ID="TextBox1" class="form-control pull-right" runat="server" ReadOnly></asp:TextBox>
                     
                  </div>
              </div>

               <div class="col-md-2" id="toManagerName">
                  <div class="form-group">
                      <label for="sel1">TO Manager Name:</label>
                      <asp:TextBox ID="TextBox2" class="form-control pull-right" runat="server"></asp:TextBox>
                  </div>
              </div>
               <div class="col-md-2" id="Office">
                  <div class="form-group">
                      <label for="sel1">Manager Office:</label>
                      <select class="form-control"  id="office">
                          <option disabled selected value>--Select an Option--</option>
                          <option value="IVO">IVO</option>
                          <option value="HML">HML</option>
                      </select>
                  </div>
              </div>

               <div class="col-md-2" id="managerstatus">
                  <div class="form-group">
                      <label for="sel1">Status:</label>
                      <select class="form-control"  id="status">
                          <option disabled selected value>--Select an Option--</option>
                          <option value="Active">Active</option>
                          <option value="Inactive">Inactive</option>
                      </select>
                  </div>
              </div>
              
               <div class="col-md-2" id="vCountry">
                  <div class="form-group">
                      <label for="sel1">Venue Country:</label>
                      <select class="form-control"  id="venuecountry">
                          <option disabled selected value>--Select an Option--</option>
                 <%Response.Write(getAllVenueCountry()); %>
                      </select>
                  </div>
              </div>


               <div class="col-md-2" id="Venue">
                  <div class="form-group">
                      <label for="sel1">Status:</label>
                      <select class="form-control"  id="venue">
                  
                      </select>
                  </div>
              </div>
           

        

         
              <div id="alert">

              </div>
             

              <div class="col-md-2">
                  <label for="sel1">&nbsp;</label>
                  
                <button type="button"  runat="server" id="insert" class="btn btn-primary pull-right btn-block">Insert</button>
                 <button type="button"  runat="server" id="update" class="btn btn-primary pull-right btn-block">Update</button>
                
              </div>

              </div>
              </div>
        
                     <div class="container-fluid" id="directory">
          <div class="row">

          <div class="col-md-12 " ">
        <h3 class="text-center"> TO MANAGER DIRECTORY</h3>
           
              </div>
              </div>
  <div class="row">

           <div class="col-md-4 col-md-offset-4" >
                    <div class="form-group">
                       <label for="sel1"></label>
                      <asp:TextBox ID="TextBox5" class="form-control pull-right" runat="server"  data-table="table table-hover" ></asp:TextBox>
                  </div>
              </div>
      </div><br />
                         
           
                    <table class="table table-hover" id="task-table">
            <thead>
                <tr>
                    <th>TO MANAGER ID</th>
                    
                    <th>TO MANAGER NAME</th>
                   

                    <th>OFFICE</th>
                    <th>STATUS</th>
                    <th>VENUE COUNTRY</th>
                    <th>VENUE</th>
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
            $("#update").hide();
            $("#toManagerID").hide();
            $("#insert").click(function () {
                var toManagerName = $("#TextBox2").val();
                var toManagerOffice = $("#office").val();
                var status = $("#status").val();
                var venueCountryID = $("#venuecountry").val();
                var venue=$("#venue").val();
                //alert(toManagerName);
                //alert(toManagerOffice);
                //alert(status);
                //alert(venue);
                $.ajax({

                    type:'Post',
                    url: 'To_Manager1.aspx/insertToManager',
                    contentType:"application/json; charset=utf-8",
                    data: "{'tomanagername':'" + toManagerName + "','tomanageroffice':'" + toManagerOffice + "','status':'" + status + "','venueCountryID':'" + venueCountryID + "','venue':'" + venue + "'}",
                    async: false,
                    success: function (data) {
                        $("#TextBox2").val("");
                        $("#office").val("");
                        $("#status").val('');
                        $("#venuecountry").val('');
                        $("#venue").empty();
                      
                        alert("TO Manager added successfully!!");
                        
                    },
                    error: function () {
                        alert("hello something went wrong");
                    }

                });
                return false;


            });
        });
    </script>
    

        <script>
            $(document).ready(function () {
            
                $("#head").hide();
                $("#toManagerName").hide();
                $("#Office").hide();
                $("#managerstatus").hide();
                $("#directory").hide();
                $("#insert").hide();
                $("#Venue").hide();
                $("#vCountry").hide();
                $("#insertButton").click(function () {
                    $("#head").show();
                    $("#toManagerName").show();
                    $("#Office").show();
                    $("#vCountry").show();
                    $("#managerstatus").show();
                    $("#Venue").show();
                    $("#insert").show();
                    $("#insertButton").hide();
                    $("#view").show();
                    $("#directory").hide();
                    $("#update").hide();
                    $("#toManagerID").hide();
                    $("#TextBox1").val("");
                    $("#TextBox2").val("");
                    $("#office").val('');
                    $("#status").val('');
                    $("#venue").empty()
                    $("#venuecountry").val('');
                });
                $("#view").click(function () {
                    $("#head").hide();
                    $("#toManagerName").hide();
                    $("#Office").hide();
                    $("#insert").hide();
                    $("#insertButton").show();
                    $("#view").hide();
                    $("#directory").show();
                    $("#toManagerID").hide();
                    $("#managerstatus").hide();
                    $("#update").hide();
                    $("#Venue").hide();
                    $("#vCountry").hide();

                });

                $(document).on('click','.edit-btn', function () {
                    $("#insertButton").show();
                    $("#view").hide();
                  
                    $("#toManagerID").show();
                    $("#toManagerName").show();
                    $("#Office").show();
                    $("#update").show();
                    $("#managerstatus").show;
                    $("#directory").hide();
                    $("#managerstatus").show();
                    $("#Venue").show();
                    $("#vCountry").show();

                    var row = $(this).closest("tr");
                    var ID = row.find("td:eq(0)").text();
                    var name = row.find("td:eq(1)").text();
                    var office = row.find("td:eq(2)").text();
                    var status = row.find("td:eq(3)").text();
                    var venuecountryID = row.find("td:eq(4)").text();
                  

                    $("#TextBox1").val(ID);
                    $("#TextBox2").val(name);
                  
                    $("#office option[value='" + office + "']").prop('selected', true);
                    $("#status option[value='" + status + "']").prop('selected', true);
                    $("#venuecountry option[value='" + venuecountryID + "']").prop('selected', true);

                });
                

            });
        </script>




        <script>
            $(document).ready(function () {

                $("#view").click(function () {

                    $.ajax({

                        type: 'POST',
                        url: 'To_Manager1.aspx/getAllToManager',
                        contentType: "application/json; charset=utf-8",
                        data: "{}",
                        async: false,
                        success: function (data) {
                            //alert(data.d);
                            $("#task-table tbody").empty();

                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $("#task-table tbody").append("<tr><td>" + value1[0] + "</td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td>" + value1[3] + "</td><td style='display:none;'>" + value1[4] + "</td><td>" + value1[5] + "</td><td>" + value1[6] + "</td><td><button type='button'  class='edit-btn btn btn-primary col-md-12' >Edit</button></td><td><button type='button'  class='delete-btn btn btn-primary col-md-12' >Delete</button></td></tr>");

                                });

                            });


                        },
                        error: function () {
                            alert("hello something went wrong");
                        }

                    });
                    return false;


                });
            });

        </script>

        <script>

            $(document).ready(function () {
                $(document).on('click','.delete-btn',function () {
                    var row = $(this).closest("tr");
                    var ToManagerID = row.find("td:eq(0)").text();
                    //alert(ToManagerID);
                    var ToManagerName = row.find("td:eq(1)").text();
                    var confirmation = confirm("are you sure you want to delete " + ToManagerName + " ?");

                    if (confirmation) {
                        $.ajax({
                            type: 'POST',
                            url: 'To_Manager1.aspx/deleteToManager',
                            contentType: "application/json; charset=utf-8",
                            data: "{'toManagerID':'" + ToManagerID + "'}",
                            async: false,
                            success: function (data) {

                                alert("To Manager deleted successfully!!");

                            },
                            error: function () {
                                alert("hello something went wrong");
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

                    var toManagerID = $("#TextBox1").val();
                    var toManagerName = $("#TextBox2").val();
                    var office = $("#office").val();
                    var toManagerStatus = $("#status").val();
                    var venuecountry = $("#venuecountry").val();
                    var venue = $("#venue").val();
                    $.ajax({
                        type: 'POST',
                        url: 'To_Manager1.aspx/updateToManager',
                        contentType: "application/json; charset=utf-8",
                        data: "{'toManagerID':'" + toManagerID + "','toManagername':'" + toManagerName + "','office':'" + office + "','toManagerstatus':'" + toManagerStatus + "','venue':'" + venue + "','venuecountry':'" + venuecountry + "'}",
                        async: false,
                        success: function (data) {
                            $("#TextBox1").val("");
                            $("#TextBox2").val("");
                            $("#office").val('');
                            $("#status").val('');
                            $("#venuecountry").val('');
                            $("#venue").empty();
                            alert("TO Manager updated successfully!!");

                        },
                        error: function () {
                            alert("hello something went wrong");
                        }

                    });

                    return false;


                });

            })
        </script>

        <script>

            $(document).ready(function () {
                $("#update").click(function () {
                    $("#toManagerID").hide();
                    $("#toManagerName").hide();
                    $("#Office").hide();
                    $("#managerstatus").hide();
                    $("#update").hide();
                    $("#insertButton").show();
                    $("#Venue").hide();
                    $("#vCountry").hide();
                });
            });
        </script>


           <script>
            $(document).ready(function () {
                $("#venuecountry").change(function () {
                    var venuecountryID = $("#venuecountry").val();
               

                    $.ajax({
                        type: 'POST',
                        url: 'To_Manager1.aspx/getAllVenue1',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venuecountryID':'" + venuecountryID + "'}",
                        async: false,
                        success: function (data) {
                           // alert(data.d);
                           $("#venue").empty();
                            $("#venue").append("<option disabled selected value>--Select an Option--</option>");

                            subJson = JSON.parse(data.d);
                            
                            $.each(subJson, function (key, value) {
                                
                                $.each(value, function (index1, value1) {
                                    $("#venue").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");
                                });
                            });

                        },
                        error: function () {
                            alert("hello something went wrong");
                        }

                    });

                    return false;

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




        <script>
            $(document).ready(function () {

                $(document).on('click', '.edit-btn', function () {

                    var venuecountry = $("#venuecountry").val();
                  
                    $.ajax({

                        type: 'Post',
                        url: 'To_Manager1.aspx/getAllVenue',
                        contentType: "application/json; charset=utf-8",
                        data: "{'venuecountry':'" + venuecountry + "'}",
                        async: false,
                        success: function (data) {
                            $("#venue").empty();
                            $("#venue").append("<option disabled selected value>--Select an Option--</option>");
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $("#venue").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");

                                });
                            });


                        },
                        error: function () {
                            alert("hello something went wrong");
                        }

                    });
                    return false;


                });

            });


        </script>
</body>
</html>
