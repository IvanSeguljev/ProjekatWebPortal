$(document).ready(function () {
    console.log('aa');
    $('#predmetForma').validate({
        rules: {
            predmetNaziv: {
                required: true,
                maxLength: 255
            },
            predmetOpis: {
                required: true,
                minLength: 5,
                maxLength: 1000
            }
        },

        messages: {
            predmetNaziv: {
                required: "Polje naziv je obavezno.",
                maxLength: "Polje naziv može sadržati najviše 255 karaktera."
            },
            predmetOpis: {
                required: "Polje opis je obavezno.",
                minLength: "Polje opis mora sadržati najmanje 5 karaktera.",
                maxLength: "Polje opis može sadržati najviše 1000 karaktera."
            }
        }

    });
});