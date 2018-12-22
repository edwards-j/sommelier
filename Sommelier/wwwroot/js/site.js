// For nav side bar
$(document).ready(function () {
    $('.sidenav').sidenav();
});

//For form inputs
$(document).ready(function () {
    $('select').formSelect();
});

//Toggles the search bar on the "My Cellar" view
$("#search_toggle_button").click(function () {
    $("#search_container").toggleClass("scale-out");
})


$(document).ready(function () {
    $('.modal').modal();
});
