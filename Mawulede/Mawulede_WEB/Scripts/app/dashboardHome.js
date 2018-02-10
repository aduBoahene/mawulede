var basrUrl = "http://localhost:55365/api/";
var outputBooking = "";
var outputCustomers = "";
var outputMovie = "";



$(function () {
    loadData();
});

var booking = {};
var Customers = {};
var House = {};
var Movie = {};

var bookingAjax = $.ajax({
    url: basrUrl + "Booking/GetAllBooking?houseId=" + HouseId,
    type: "Get"
});

var customerAjax = $.ajax({
    url: basrUrl + "Customer/GetAllCustomers?houseId=" + HouseId,
    type: "Get"
});

var houseAjax = $.ajax({
    url: basrUrl + "House/GetAllHouses?houseId=" + HouseId,
    type: "Get"
});

var movieAjax = $.ajax({
    url: basrUrl + "Movie/GetAllMovie?houseId=" + HouseId,//http://localhost:55365/api/Movie/GetAllMovie?houseId=4
    type: "Get"
});



function loadData() {
    $.when(bookingAjax, customerAjax, houseAjax, movieAjax)
        .done(function (dataBooking, dataCustomer, dataHouse,dataMovie) {
            booking = dataBooking[2].responseJSON;
            Customers = dataCustomer[2].responseJSON;
            House = dataHouse[2].responseJSON;
            Movie = dataMovie[2].responseJSON;


            
            for (var i = 0; i < Movie.length; i++) {

                outputMovie = outputMovie + "<div class='media-left'>\
                        <img src='"+ Movie[i].PosterUrl+"' class='media-object' style='width:60px'></div>\
                        <div class='media-body'>\
                            <h4 class='media-heading'>"+Movie[i].Title+"</h4>\
                            <p>"+ Movie[i].Synopsis+"</p>\
                        </div>";

                $("#movieBlock").html(outputMovie);
            }


            for (var i = 0; i < booking.length; i++) {

                outputBooking = outputBooking + "<tr>\
                    <td> <a href=''>"+ booking[i].BookingId + "</a></td>\
                    <td>"+ booking[i].Title + "</td>\
                    <td>"+ booking[i].FullName + "</td>\
                    <td>"+ booking[i].BookingDate + "</td>\
                    <td>"+ booking[i].PaymentName + "</td>\
                    <td>"+ booking[i].Day + "</td>\
                    <td>"+ booking[i].Time + "</td>\
                    <td>"+ booking[i].Amount + "</td>\
                </td>\
                </tr>";

                $("#bookingDetails").html(outputBooking);
            }


            for (var i = 0; i < Customers.length; i++) {

                //outputCustomers = outputCustomers + "<img class='img-circle img-bordered-sm' src='Content/images/profile.jpg'/>\
                outputCustomers = outputCustomers + "<img class='img-circle img-bordered-sm' src='Content/images/profile.jpg'/>\
                    <span class='username'>\
                        <a href='#'>"+ Customers[i].FullName+"</a>\
                        </span>\
                    <span class='description'>Shared publicly - 7:30 PM today</span>";

                $("#custDetails").html(outputCustomers);
            }
        });




}


