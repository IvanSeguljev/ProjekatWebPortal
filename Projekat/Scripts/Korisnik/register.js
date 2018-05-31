$(function () {
    $('#noviKorisnik').validate({
        rules: {
            Ime: {
                required: true,
                //slovaRegex: /^[A-Za-z]+$/,
                minlength: 2
            },
            Prezime: {
                required: true,
                //slovaRegex: /^[a-zA-Z]+/,
                minlength: 2
            },
            Email: {
                required: true,
                email: true
                //mailRegex: /^[A-z0-9]+\@[a-z](2,6)\.[a-y](2,4)$/
            },
            Password: {
                required: true,
                minlength: 6
            },
            GodinaUpisa: {
                required: false,
                godinaRegex: /^\d(4,4)$/,
                minlength: 4
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
                minlength: "Ime mora sadržati minimum 2 karaktera."
            },
            Prezime: {
                required: 'Polje prezime je obavezno.',
                minlength: "Prezime mora sadržati minimum 2 karaktera."
            },
            Email: {
                required: 'Polje email je obavezno.',
                email: "Unesite ispravan format email adrese."
            },
            Password: {
                required: 'Polje password je obavezno.',
                minlength: "Password mora sadržati minimum 6 karaktera."
            },
            GodinaUpisa: {
                minlength: "Godina mora sadržati minimum 4 karaktera."
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

    $.validator.addMethod("mailRegex", function (value, element, regexpr) {
        // allow any non-whitespace characters as the host part
        return regexpr.test(value);
    }, 'Mail mora biti u formatu tekst@tekst.domen');

    $.validator.addMethod("godinaRegex", function (value, element, regexpr) {
        // allow any non-whitespace characters as the host part
        return regexpr.test(value);
    }, 'Godina mora imati 4 cifre.');
});