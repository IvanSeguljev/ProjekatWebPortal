$(function () {

    $('#novaVest').validate({
        rules: {
            Naslov: {
                required: true,
                naslovReg: /^[A-za-z0-9\.\,\:\;\!\@\s\'\"\#\$\%\^\&\*\(\)\_\-\+\=\{\}\[\]\|\<\>\?\/]{0,60}$/
            },
            KratakOpis: {
                required: true,
                opisReg: /^[A-za-z0-9\.\,\:\;\!\@\s\'\"\#\$\%\^\&\*\(\)\_\-\+\=\{\}\[\]\|\<\>\?\/]{0,150}$/
            }
        },
        messages: {
            Vest: {
                required: 'Ovo polje je obavezno'
            },
            KratakOpis: {
                required: 'Ovo polje je obavezno'
            }

        }
    });
    $.validator.addMethod("naslovReg", function (value, element, regexpr) {
        // allow any non-whitespace characters as the host part
        return regexpr.test(value);
    }, 'Polje moze sadrzati maksimum 60 karaktera');


$.validator.addMethod("opisReg", function (value, element, regexpr) {
    // allow any non-whitespace characters as the host part
    return regexpr.test(value);
    }, 'Polje moze sadrzati maksimum 150 karaktera');
});

