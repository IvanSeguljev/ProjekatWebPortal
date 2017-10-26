$(document).ready(function () {
    console.log('skripta radi');

    $('.select2materijali').on('change', function () {
        if(true){
            $.ajax({
                method: 'POST',
                url: ''/*'Materijal/MaterijaliPrikaz'*/,
                data: {

                }

            });
        }
    });

    $('.select2_datum').change(function () {
        alert($("select[name='filterStarijeNovije']").val());
   
        $.ajax({
            method: 'POST',
            url: '',
            data: {

            }
        });
    });


});