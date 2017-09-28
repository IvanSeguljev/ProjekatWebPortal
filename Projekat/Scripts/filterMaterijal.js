$(document).ready(function () {
    console.log('skripta radi');

    $('.select2materijali').on('change', function () {
        if(true){
            $.ajax({
                method: 'POST',
                url: 'Materijal/MaterijaliPrikaz',
                data: {

                }

            });
        }
    });


});