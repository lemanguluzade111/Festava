let skip = 8;
let artistsCount = $("#loadMore").next().val();
$(document).on("click", "#loadMore", function () {
    $.ajax({
        url: "/Artists/LoadMore/",
        type: "get",
        data: {
            "skipCount": skip
        },
        success: function (res) {
            $("#myArtists").append(res)
            skip += 8;

            if (artistsCount <= skip) {
                $("#loadMore").remove()
            }

        }
    });
});





