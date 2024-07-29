<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HotelManagementSystem.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Home</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
    <script src="https://cdn.emailjs.com/dist/email.min.js"></script>
    <script>
        (function () {
            emailjs.init('<%= Application["EmailServicePublicKey"] %>');
        })();
    </script>
</head>



<body>
    <form id="form1" runat="server" class="container mt-5">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-light bg-light fixed-top">
            <a class="navbar-brand" href="#">Hotel</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="#about">About Us</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#location">Location</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#contact">Contact Us</a>
                    </li>
                </ul>
                <span class="navbar-text" id="weather">
                    <!-- Weather info here -->
                </span>
                <br />
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <asp:Button ID="btnEmployeeLogin" runat="server" Text="Employee Login" CssClass="btn btn-primary" OnClick="btnEmployeeLogin_Click" />
                    </li>
                </ul>
            </div>
        </nav>

        <!-- Jumbotron -->
        <div class="jumbotron mt-5 pt-5">
            <h1 class="display-4">Welcome to Our Hotel</h1>
            <p class="lead">Experience the best hospitality in Ashdod.</p>
            <hr class="my-4">
            <p>For any assistance, please contact our staff.</p>
            <a class="btn btn-primary btn-lg" href="#contact" role="button">Contact Us</a>
        </div>

        <!-- About Us Section -->
        <div id="about" class="mt-5">
            <h2>About Us</h2>
            <p>Welcome to our luxurious hotel located in the heart of Ashdod. Our hotel offers exceptional services and facilities designed to provide you with an unforgettable stay. Whether you're here for business or leisure, our dedicated staff is here to ensure that your needs are met with the highest standards of hospitality.</p>
            <p>Our hotel features elegantly designed rooms and suites, a state-of-the-art fitness center, an outdoor swimming pool, gourmet dining options, and conference facilities to cater to your every need. We are committed to providing you with a comfortable and enjoyable experience.</p>
            <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="Images/image1.png" class="d-block w-100" alt="Hotel Image 1">
                    </div>
                    <div class="carousel-item">
                        <img src="Images/image2.png" class="d-block w-100" alt="Hotel Image 2">
                    </div>
                    <div class="carousel-item">
                        <img src="Images/image3.png" class="d-block w-100" alt="Hotel Image 3">
                    </div>
                    <div class="carousel-item">
                        <img src="Images/image4.png" class="d-block w-100" alt="Hotel Image 4">
                    </div>
                    <div class="carousel-item">
                        <img src="Images/image5.png" class="d-block w-100" alt="Hotel Image 5">
                    </div>
                    <div class="carousel-item">
                        <img src="Images/image6.png" class="d-block w-100" alt="Hotel Image 6">
                    </div>
                    <div class="carousel-item">
                        <img src="Images/image7.png" class="d-block w-100" alt="Hotel Image 7">
                    </div>
                    <div class="carousel-item">
                        <img src="Images/image8.png" class="d-block w-100" alt="Hotel Image 8">
                    </div>
                    <div class="carousel-item">
                        <img src="Images/image9.png" class="d-block w-100" alt="Hotel Image 9">
                    </div>
                    <div class="carousel-item">
                        <img src="Images/image10.png" class="d-block w-100" alt="Hotel Image 10">
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleControls" data-slide-to="0" class="active">
                        <img src="Images/image1.png" class="d-block w-100" alt="Thumbnail 1">
                    </li>
                    <li data-target="#carouselExampleControls" data-slide-to="1">
                        <img src="Images/image2.png" class="d-block w-100" alt="Thumbnail 2">
                    </li>
                    <li data-target="#carouselExampleControls" data-slide-to="2">
                        <img src="Images/image3.png" class="d-block w-100" alt="Thumbnail 3">
                    </li>
                    <li data-target="#carouselExampleControls" data-slide-to="3">
                        <img src="Images/image4.png" class="d-block w-100" alt="Thumbnail 4">
                    </li>
                    <li data-target="#carouselExampleControls" data-slide-to="4">
                        <img src="Images/image5.png" class="d-block w-100" alt="Thumbnail 5">
                    </li>
                    <li data-target="#carouselExampleControls" data-slide-to="5">
                        <img src="Images/image6.png" class="d-block w-100" alt="Thumbnail 6">
                    </li>
                    <li data-target="#carouselExampleControls" data-slide-to="6">
                        <img src="Images/image7.png" class="d-block w-100" alt="Thumbnail 7">
                    </li>
                    <li data-target="#carouselExampleControls" data-slide-to="7">
                        <img src="Images/image8.png" class="d-block w-100" alt="Thumbnail 8">
                    </li>
                    <li data-target="#carouselExampleControls" data-slide-to="8">
                        <img src="Images/image9.png" class="d-block w-100" alt="Thumbnail 9">
                    </li>
                    <li data-target="#carouselExampleControls" data-slide-to="9">
                        <img src="Images/image10.png" class="d-block w-100" alt="Thumbnail 10">
                    </li>
                </ol>
            </div>
        </div>




        <!-- Location Section -->
        <div id="location" class="mt-5">
            <h2>Location</h2>
            <div class="form-group">
                <label for="userAddress">Enter your address:</label>
                <input type="text" id="userAddress" class="form-control" placeholder="Enter your address">
                <button class="btn btn-primary mt-2" onclick="calculateRoute(event)">Get Directions</button>
            </div>
            <div id="map" style="height: 400px;"></div>
        </div>


        <!-- Contact Us Section -->
        <div id="contact" class="mt-5">
            <h2>Contact Us</h2>
            <div class="form-group">
                <label for="name" class="form-label">Name</label>
                <input type="text" id="name" class="form-control">
            </div>
            <div class="form-group">
                <label for="email" class="form-label">Email</label>
                <input type="email" id="email" class="form-control">
            </div>
            <div class="form-group">
                <label for="message" class="form-label">Message</label>
                <textarea id="message" class="form-control"></textarea>
            </div>
            <button class="btn btn-primary" onclick="sendEmail(event)">Send</button>
            <div id="emailStatus" style="margin-top: 10px;"></div>
        </div>



        <!-- Footer -->
        <footer class="mt-5">
            <p>&copy; Shay Marks.<br /> Contact me on :
                <a href="https://www.facebook.com/profile.php?id=100000534363504" target="_blank"><i class="fab fa-facebook"></i> Facebook</a>,
                <a href="https://github.com/ShayMarks" target="_blank"><i class="fab fa-github"></i> GitHub</a>,
                <a href="https://www.instagram.com/shaymarks2/" target="_blank"><i class="fab fa-instagram"></i> Instagram</a>,
                <a href="https://www.linkedin.com/in/shay-marks-920546260/" target="_blank"><i class="fab fa-linkedin"></i> Linkedin</a>.

            </p>
        </footer>
      </form>

<!-- script -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
<script src="https://maps.googleapis.com/maps/api/js?key=<%= ViewState["GoogleMapsApiKey"] %>&libraries=places"></script>

<script>
    var weatherApiKey = '<%= ViewState["WeatherApiKey"] %>';
    var googleMapsApiKey = '<%= ViewState["GoogleMapsApiKey"] %>';
    var emailServicePublicKey = '<%= ViewState["EmailServicePublicKey"] %>';

    // JavaScript for weather
    document.addEventListener('DOMContentLoaded', function () {
        fetch(`https://api.openweathermap.org/data/2.5/weather?q=Ashdod&appid=${weatherApiKey}`)
            .then(response => response.json())
            .then(data => {
                const weather = document.getElementById('weather');
                const temp = Math.round(data.main.temp - 273.15); // Convert Kelvin to Celsius
                const description = data.weather[0].description;
                weather.innerHTML = `Weather in Ashdod: ${temp}&deg;C, ${description}`;
            })
            .catch(error => {
                console.error('Error fetching weather data:', error);
            });
    });

    // JavaScript for Google Maps
    const hotelLocation = { lat: 31.817083, lng: 34.656167 };
    let map, directionsRenderer, directionsService;

    function initMap() {
        map = new google.maps.Map(document.getElementById('map'), {
            zoom: 15,
            center: hotelLocation
        });
        const marker = new google.maps.Marker({
            position: hotelLocation,
            map: map
        });

        directionsService = new google.maps.DirectionsService();
        directionsRenderer = new google.maps.DirectionsRenderer();
        directionsRenderer.setMap(map);
    }
    window.onload = initMap;

    // A function to calculate a route
    function calculateRoute(event) {
        event.preventDefault(); // Prevent form submission
        const userAddress = document.getElementById('userAddress').value;
        if (userAddress.trim() === "") {
            alert("Please enter a valid address.");
            return;
        }

        console.log("User address:", userAddress); // Debug: print user address
        directionsService.route({
            origin: userAddress,
            destination: hotelLocation,
            travelMode: 'DRIVING'
        }, function (response, status) {
            if (status === 'OK') {
                console.log("Directions response:", response); // Debug: print directions response
                directionsRenderer.setDirections(response);
            } else {
                console.log("Directions request failed:", status); // Debug: print error status
                alert('Directions request failed due to ' + status);
            }
        });
    }



    // JavaScript for sending email
    function sendEmail(event) {
        event.preventDefault(); // Prevent form submission
        const name = document.getElementById('name').value;
        const email = document.getElementById('email').value;
        const message = document.getElementById('message').value;
        const emailStatus = document.getElementById('emailStatus');

        const templateParams = {
            from_name: name,
            from_email: email,
            message: message
        };

        emailjs.init(emailServicePublicKey);
        emailjs.send('service_at4rhj7', 'template_eig9h1l', templateParams)
            .then(function (response) {
                console.log('SUCCESS!', response.status, response.text);
                emailStatus.innerHTML = '<div class="alert alert-success" role="alert">Email sent successfully!</div>';
                document.getElementById('name').value = '';
                document.getElementById('email').value = '';
                document.getElementById('message').value = '';
            }, function (error) {
                console.log('FAILED...', error);
                emailStatus.innerHTML = '<div class="alert alert-danger" role="alert">Failed to send email. Please try again.</div>';
            });
    }

</script>


</body>
</html>
