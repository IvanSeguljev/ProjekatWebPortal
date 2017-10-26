$(document).ready(function () {
    console.log('skripta radi');

    //u skripti custom dropdown su vec definisani on change eventovi za filtere, razmotriti da se tamo nadograde
    $('.select2materijali').on('change', function () {
        if (true) {
            $.ajax({
                method: 'POST',
                url: ''/*'Materijal/MaterijaliPrikaz'*/,
                data: {

                }

            });
        }
    });

});