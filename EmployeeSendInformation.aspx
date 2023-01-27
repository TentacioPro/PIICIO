<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeSendInformation.aspx.cs" Inherits="EmployeeSendInformation" %>

<!DOCTYPE html>
<html lang="zxx">

<head>
    <title>Company Organization</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8" />
    <meta name="keywords" content="Subject Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
	SmartPhone Compatible web template, free WebDesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola web design" />
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- Custom Theme files -->
    <link href="css/bootstrap.css" type="text/css" rel="stylesheet" media="all">
    <link href="css/style.css" type="text/css" rel="stylesheet" media="all">
	<!-- font-awesome icons -->
    <link href="css/fontawesome-all.min.css" rel="stylesheet">
	<!-- //Custom Theme files -->
    <!-- online-fonts -->
	<link href="//fonts.googleapis.com/css?family=Roboto:100i,400,500,700" rel="stylesheet">
	<link href="//fonts.googleapis.com/css?family=Montserrat:300,400,500,600,700,800" rel="stylesheet">
	<!-- //online-fonts -->
</head>
<body>
    <!-- banner -->
    <div class="inner-banner">
        <!-- header -->
        <header>
            <nav class="navbar navbar-expand-lg navbar-light bg-gradient-secondary pt-3">
               <h1><a class="navbar-brand" href="#">Organization
							<span></span>
						</a></h1>

                <button class="navbar-toggler ml-md-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto">
								
                                <li class="nav-item mx-xl-4 mx-lg-3 my-lg-0 my-3 ">
									<a class="nav-link" href="EmployeeHome.aspx">Home</a>
								</li>
								<li class="nav-item mx-xl-4 mx-lg-3 my-lg-0 my-3 ">
									<a class="nav-link" href="EmployeeDailyUpdate.aspx">Daily Update</a>
								</li>
								<li class="nav-item mx-xl-4 mx-lg-3 my-lg-0 my-3 active">
									<a class="nav-link" href="EmployeeSendInformation.aspx">Send Information</a>
								</li>
                                <li class="nav-item mx-xl-4 mx-lg-3 my-lg-0 my-3">
									<a class="nav-link" href="EmployeeNotification.aspx">Notification</a>
								</li>                                
                                <li class="nav-item mx-xl-4 mx-lg-3 my-lg-0 my-3">
									<a class="nav-link" href="Home.aspx">Logout</a>
								</li>
								
					</ul>
				</div>
			</nav>
        </header>
        <!-- //header -->
       
    </div>
	 <!-- //banner-text -->
	   <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#">Employee</a>
        </li>
        <li class="breadcrumb-item active">Send Information</li>
    </ol>
    <!-- contact -->
    <section class="banner-bottom-w3ls pt-lg-5 pt-md-3 pt-3">
        <div class="inner-sec-wthreelayouts pt-md-5 pt-md-3 pt-3" align="center">
			<h2 class="heading-agileinfo text-center  mb-4">Send <span> Information</span></h2>
			
            <div class="container-fluid" align="center">
                <div class="" align="center">
                    
                    <div class="col-md-6 " align="center">
                        <div class="form" align="center">
                            
                            <form id="form1" runat="server">

                                <div class="form-group">
                                    <label class="my-2">Employee ID</label>
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" style="text-align: center" placeholder="" required="" Height="50" Width="400" BorderColor="#003300" Font-Italic="False" ForeColor="#003300" Font-Size="13pt" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                </div> 
                                <div class="form-group">
                                    <label class="my-2">Name</label>
                                    <asp:TextBox ID="TextBox2" runat="server" style="text-align: center" class="form-control" placeholder="" required="" Height="50" Width="400" BorderColor="#003300" Font-Italic="False" ForeColor="#003300" Font-Size="13pt" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="my-2">Enter Details</label>
                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control" required="" Height="400" Width="500" BorderColor="#003300" ForeColor="#000066" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <br />
                                <div class="input-group1">
                                    <asp:Button ID="Button1" runat="server" Text="Send to Manager" class="form-control" Height="60" Width="300" BackColor="#00CCFF" BorderColor="Black" Font-Bold="True" ForeColor="#660066" Font-Size="15" OnClick="Button1_Click"/><br />
                                    <asp:Button ID="Button2" runat="server" Text="Send to TL" class="form-control" Height="60" Width="300" BackColor="#FFFF99" BorderColor="Black" Font-Bold="True" ForeColor="#660066" Font-Size="15" OnClick="Button2_Click"/>
                                </div>
                                <br />
                                <div class="form-group">
                                    <label class="my-2">Enter Employee ID</label>
                                    <asp:TextBox ID="TextBox4" runat="server" style="text-align: center" class="form-control" placeholder="" Height="50" Width="400" BorderColor="#003300" Font-Italic="False" ForeColor="#003300" Font-Size="13pt" ></asp:TextBox>
                                </div>
                                <br />
                                <div class="input-group1">
                                    <asp:Button ID="Button3" runat="server" Text="Send to Employee" class="form-control" Height="60" Width="300" BackColor="#00CCFF" BorderColor="Black" Font-Bold="True" ForeColor="#660066" Font-Size="15" OnClick="Button3_Click"/><br />
                                </div>
                           </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section><br />
    <!-- //contact -->
<!--/newsletter-->
    
	<div class="copyright py-3">
		<div class="container">
			<div class="row">
				<div class="col-md-8">      
					<p class="copy-right mt-2">© Company Organization. All Rights Reserved 
						
					</p>
				</div>
				<div class="col-md-4">
					<ul class="social-icons scial justify-content-end">
						<li class="mr-1"><a href="#"><span class="fab fa-facebook-f"></span></a></li>
						<li class="mx-1"><a href="#"><span class="fab fa-twitter"></span></a></li>
						<li class="mx-1"><a href="#"><span class="fab fa-google-plus-g"></span></a></li>
						<li class="mx-1"><a href="#"><span class="fab fa-linkedin-in"></span></a></li>
					</ul>
				</div>
			</div>
		</div>
	</div>
    <!--//newsletter-->
<!-- js -->
    <script src="js/jquery-2.2.3.min.js"></script>
<!-- //js -->
    <!-- start-smooth-scrolling -->
    <script src="js/move-top.js"></script>
    <script src="js/easing.js"></script>
    <script>
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();

                $('html,body').animate({
                    scrollTop: $(this.hash).offset().top
                }, 1000);
            });
        });
    </script>
    <!-- //end-smooth-scrolling -->
    <!-- smooth-scrolling-of-move-up -->
    <script>
        $(document).ready(function () {
            /*
            var defaults = {
                containerID: 'toTop', // fading element id
                containerHoverID: 'toTopHover', // fading element hover id
                scrollSpeed: 1200,
                easingType: 'linear' 
            };
            */

            $().UItoTop({
                easingType: 'easeOutQuart'
            });

        });
    </script>
    <script src="js/SmoothScroll.min.js"></script>
    <!-- //smooth-scrolling-of-move-up -->
    <!-- Bootstrap core JavaScript
================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/bootstrap.js"></script>
</body>
</html>
