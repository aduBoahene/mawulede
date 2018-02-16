var basrUrl = "http://localhost:55365/api/";
var Movie = {};

var outputMovie = "";



$(function () {
    loadData(HouseId);
});



function loadData(id){
    $.ajax({
        type: "GET",
        url: basrUrl + "Movie/GetAllMovie?houseId=" + id,
        success: function (result) {
            Movie = result;
            console.log("Movies ", Movie);

            for (var i = 0; i < Movie.length; i++) {
                outputMovie = outputMovie + "<div class='col-md-2'>\
                    <div class='thumbnail'>\
                        <img src='"+Movie[i].PosterUrl+"' style='width:320px;height:200px'>\
                            <div class='caption'>\
                                <h4>"+Movie[i].Title+"</h4>\
                                <a href= '#' class='btn btn-default btn-xs pull-right' role='button'>\
                        <i class='glyphicon glyphicon-edit'></i></a > <a href='#' class='btn btn-default btn-xs pat' role='button' id='"+Movie[i].MovieId+"'>Edit</a>\</div></div>\
                </div>";

                $("#cardMovie").html(outputMovie);
            }

            $(".pat").click(function () {

                var hymn = $(this).attr("id");
                //console.log("tris", hymn);
                //alert('you clicked me!' + hymn);

                window.location = "/Movie/EditMovie/" + hymn;
            });

        }
    });
}
