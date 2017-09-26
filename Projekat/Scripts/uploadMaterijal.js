$(document).ready(function () {
    var data = sessionStorage.getItem('upload');
    if (data) {
        $('#snackbar').css('display', 'block');
        sessionStorage.removeItem('kantica');
    }

    $('#postavi').click(function () {
        sessionStorage.setItem('upload', true);
        location.reload();
    });


    $('#postavkaMat').validate({
        rules: {

        },
        messages: {

        }
    });

});
