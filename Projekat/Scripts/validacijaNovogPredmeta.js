$(document).ready(function () {

    $('.select2smerovi').select2({
        width: "auto",
        placeholder: "Odaberite smerove",
    });

    var isUploaded = sessionStorage.getItem('uploadPredmet');
    if (isUploaded) {
        $('#snackbar').css('display', 'block');
        sessionStorage.removeItem('uploadPredmet');
    }
    else
        $('#snackbar').css('display', 'none');

    $('#predmetForma').validate({
        rules: {
            smeroviId: {
                required: true
            },
            "predmet.predmetNaziv": {
                required: true,
                maxlength: 255
            },
            "predmet.predmetOpis": {
                required: true,
                minlength: 5,
                maxlength: 1000
            }
        },

        messages: {
            smeroviId: {
                required: "Odaberite barem jedan smer."
            },
            "predmet.predmetNaziv": {
                required: "Polje naziv je obavezno.",
                maxlength: "Polje naziv može sadržati najviše 255 karaktera."
            },
            "predmet.predmetOpis": {
                required: "Polje opis je obavezno.",
                minlength: "Polje opis mora sadržati najmanje 5 karaktera.",
                maxlength: "Polje opis može sadržati najviše 1000 karaktera."
            }
        },
        submitHandler: function (forma) {
            sessionStorage.setItem('uploadPredmet', true);
            forma.submit();
        }
    });
});