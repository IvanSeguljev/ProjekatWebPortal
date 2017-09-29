$(document).ready(function () {

    var predmetId = sessionStorage.getItem('predmetId');

    if (predmetId != undefined)
        $("#Materijal_predmetId").val(predmetId);
    else
        $("#Materijal_predmetId").val($('#Materijal_predmetId option').first().val());


    var isUploaded = sessionStorage.getItem('upload');
    var data = sessionStorage.getItem('upload');

    if (isUploaded) {
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
