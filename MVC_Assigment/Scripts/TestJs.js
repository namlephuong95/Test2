$(document).ready(function () {
    $("#cateList").change(function () {
        $.ajax({
            url: "FilterAjax",
            type: 'get',
            data: {
                id: $("#cateList").val()
            }
        }).done(function (response) {
            $("#prod_list").html(response);
        });
    });
});