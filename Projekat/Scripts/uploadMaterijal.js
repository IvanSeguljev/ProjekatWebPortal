$(document).ready(function () {

    var data = sessionStorage.getItem('upload');
    if (data) {
        $('#snackbar').css('display', 'block');
        sessionStorage.removeItem('upload');
    }
    else
        $('#snackbar').css('display', 'none');


    var forma = $('#postavkaMat');

    console.log(sessionStorage);
    $('#postavkaMat').validate({
        rules: {
            materijalNaslov: {
                required: true
            },
            "Materijal.materijalOpis": {
                required: true
            }
        },
        messages: {
            materijalNaslov: {
                required: "Polje naslov je obavezno."
            },
            "Materijal.materijalOpis": {
                required: "Polje opis je obavezno."
            }
        },
        submitHandler: function (forma) {
            sessionStorage.setItem('upload', true);
            forma.submit();
        }

    });

});
