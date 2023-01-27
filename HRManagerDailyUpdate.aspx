<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HRManagerDailyUpdate.aspx.cs" Inherits="HRManagerDailyUpdate" %>

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
									<a class="nav-link" href="HRManagerHome.aspx">Home</a>
								</li>
								<li class="nav-item dropdown ">
									<a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true"
									    aria-expanded="false">
										Team Leader
									</a>
									<div class="dropdown-menu" aria-labelledby="navbarDropdown">
										<a class="dropdown-item" href="HRManagerTLDetails.aspx">Details</a>
										<div class="dropdown-divider"></div>
										<a class="dropdown-item" href="HRManagerTLAttendance.aspx">Attendance</a>
									</div>
								</li>
                                <li class="nav-item mx-xl-4 mx-lg-3 my-lg-0 my-3 active">
									<a class="nav-link" href="HRManagerDailyUpdate.aspx">Daily Updates</a>
								</li>
								<li class="nav-item dropdown ">
									<a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true"
									    aria-expanded="false">
										Information
									</a>
									<div class="dropdown-menu" aria-labelledby="navbarDropdown">
										<a class="dropdown-item" href="HRManagerSendInformation.aspx">Send Information</a>
										<div class="dropdown-divider"></div>
										<a class="dropdown-item" href="HRManagerNotification.aspx">Notification</a>
									</div>
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
            <a href="#">HR Manager</a>
        </li>
        <li class="breadcrumb-item active">Daily Updates</li>
    </ol>
    <!-- contact -->
    <section class="banner-bottom-w3ls pt-lg-5 pt-md-3 pt-3">
        <div class="inner-sec-wthreelayouts pt-md-5 pt-md-3 pt-3" align="center">
			<h2 class="heading-agileinfo text-center  mb-4">Daily <span> Updates</span></h2>
			
            <div class="container-fluid" align="center">
                <div class="" align="center">
                    
                    <div class="col-md-6 " align="center">
                        <div class="form" align="center">
                            
                            <form id="form1" runat="server">
                               <div class="form-group">
                                    <label class="my-2">Employee File Name</label>
                                    <asp:DropDownList ID="DropDownList1" runat="server" style="text-align: center" class="form-control" placeholder="" Height="50" Width="400" BorderColor="#003300" Font-Italic="False" ForeColor="#003300" Font-Size="13pt" Font-Bold="True" ReadOnly="True"></asp:DropDownList>
                                </div>
                                
                                <div class="input-group1">
                                    <asp:Button ID="Button1" runat="server" Text="Click" class="form-control" Height="60" Width="300" BackColor="#00CCFF" BorderColor="Black" Font-Bold="True" ForeColor="#660066" Font-Size="15" OnClick="Button1_Click"/>
                                </div>

                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <div class="form-group">
                                    <label class="my-2"></label>
                                    <asp:Image ID="Image1" runat="server" Height="250" Width="250" />
                                    </div>
                                    <div class="form-group">
                                    <label class="my-2">Scan QR and Enter Code</label>
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" style="text-align: center" placeholder="" Height="50" Width="400" BorderColor="#003300" Font-Italic="False" ForeColor="#003300" Font-Size="13pt" Font-Bold="True"></asp:TextBox>
                                    </div> 
                                    <div class="input-group1">
                                    <asp:Button ID="Button2" runat="server" Text="Submit" class="form-control" Height="60" Width="300" BackColor="#00CCFF" BorderColor="Black" Font-Bold="True" ForeColor="#660066" Font-Size="15" OnClick="Button2_Click"/>
                                    </div>
                                </asp:Panel>

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

