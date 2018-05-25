$(function () {
    $('#noviKorisnik').validate({
        rules: {
            Ime: {
                required: true,

                slovaRegex: /^[A-Za-z]+$/,


                minlength: 2
            },
            Prezime: {
                required: true,

                slovaRegex: /^[a-zA-Z]+/,
                minlength: 2
            },
            file: {
                required: true,
                extension: "jpeg|png|jpg",
                maxFileSize: {
                    "unit": "KB",
                    "size": 5000
                },
                minFileSize: {
                    "unit": "KB",
                    "size": "1"
                }
            }
        },
        messages: {
            Ime: {
                required: 'Polje ime je obavezno.',
                minlength: "Ime mora imati minimum 2 karaktera!"
            },
            Prezime: {
                required: 'Polje prezime je obavezno.',
                minlength: "Prezime mora imati minimum 2 karaktera!"
            },
            file: {
                required: "Morate odabrati fajl.",
                extension: "Pogrešan format fajla.",
                maxFileSize: "Fajl ne sme biti veći od 5MB.",
                minFileSize: "Fajl ne sme biti manji od 1KB."
            }
        },
        errorPlacement: function (error, element) {
            if (element.attr("name") == "file") {
                error.insertAfter(element.next());
            }
            else {
                error.insertAfter(element);
            }
        }
    });
    $.validator.addMethod("slovaRegex", function (value, element, regexpr) {
        // allow any non-whitespace characters as the host part
        return regexpr.test(value);
    }, 'Možete uneti samo slova.');

});