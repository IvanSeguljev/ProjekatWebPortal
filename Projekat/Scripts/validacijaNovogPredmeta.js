$(document).ready(function () {
    console.log('aa');
    $('#predmetForma').validate({
        rules: {
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
            "predmet.predmetNaziv": {
                required: "Polje naziv je obavezno.",
                maxlength: "Polje naziv može sadržati najviše 255 karaktera."
            },
            "predmet.predmetOpis": {
                required: "Polje opis je obavezno.",
                minlength: "Polje opis mora sadržati najmanje 5 karaktera.",
                maxlength: "Polje opis može sadržati najviše 1000 karaktera."
            }
        }

    });
});