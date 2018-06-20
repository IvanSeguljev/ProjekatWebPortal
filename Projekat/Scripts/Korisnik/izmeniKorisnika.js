$(function () {
    $('#noviKorisnik').validate({
        rules: {
            "Korisnik.Ime": {
                required: true,
                //slovaRegex: /^[A-Za-z]+$/,
                minlength: 2
            },
            "Korisnik.Prezime": {
                required: true,
                //slovaRegex: /^[a-zA-Z]+/,
                minlength: 2
            },
            "Korisnik.Email": {
                required: true,
                email: true
                //mailRegex: /^[A-z0-9]+\@[a-z](2,6)\.[a-y](2,4)$/
            },
            "Korisnik.Password": {
                required: true,
                minlength: 6
            },
            "Korisnik.GodinaUpisa": {
                required: false,
                godinaRegex: /^([0-9]{4,4})?$/,
                minlength: 4

            },
           
        },
        messages: {
            "Korisnik.Ime": {
                required: 'Polje ime je obavezno.',
                minlength: "Ime mora sadržati minimum 2 karaktera."
            },
            "Korisnik.Prezime": {
                required: 'Polje prezime je obavezno.',
                minlength: "Prezime mora sadržati minimum 2 karaktera."
            },
            "Korisnik.Email": {
                required: 'Polje email je obavezno.',
                email: "Unesite ispravan format email adrese."
            },
           
            "Korisnik.GodinaUpisa": {
                minlength: "Godina mora sadržati minimum 4 karaktera."
            },
          
        },
        errorPlacement: function (error, element) {
            if (element.attr("name") == "Fajl") {
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