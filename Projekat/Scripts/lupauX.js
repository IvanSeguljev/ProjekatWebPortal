$(document).ready(function () {
    console.log('radi lupa u x');

    $('#lupaWrap').click(function () {
        $(this).find("#search").toggleClass('transform');
    });

});