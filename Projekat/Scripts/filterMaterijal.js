$(document).ready(function () {
    $(".select2materijali, .select2formati").on("change", filterMaterijali);
    $(".customLista li").on("click", filterMaterijali);

    function filterMaterijali() {
        var url = window.location.href;
        var args = url.split('/');

        var predmetId = args[args.length - 1];
        var sort = '';
        var filterDatumSpanText = $('.datum').next('.customSelect').find('span').text();

        var novijeStarije = $(".customLista li");
        for (var i = 0; i < novijeStarije.length ; i++) {
            if (novijeStarije[i].textContent === filterDatumSpanText) {
                sort = novijeStarije[i].id;
            }
        }

        var tipovi = [];
        var formati = [];

        //OVE DVE METODE VRACAJU NAZIVE
        //$('.select2materijali').next().find('.select2-selection__choice').each(function (index, element) {
        //    var tip = $(this).attr('title');
        //    tipovi.push(tip);
        //});

        //$('.select2formati').next().find('.select2-selection__choice').each(function (index, Element) {
        //    var format = $(this).attr('title');
        //    formati.push(format);
        //});

        $(".select2materijali option:selected").each(function (index, Element) {
            tipovi.push($(".select2materijali option:selected")[index].value);
        });
        $(".select2formati option:selected").each(function (index, element) {
            formati.push($(".select2formati option:selected")[index].value);
        });

        if (sort === "opadajuce") sort = 'opadajuce';
        else if (sort === "rastuce") sort = 'rastuce';
        else sort = '';

        if (tipovi === null) {
            var tipoviOptioni = [];
            $('#tipMaterijala option').each(function () {
                tipoviOptioni.push($(this).val());
            });
            console.log(tipoviOptioni);
            tipovi = tipoviOptioni;
        } 
        if (formati === null) {
            var formatiOptioni = [];
            $('.select2formati option').each(function () {
                formatiOptioni.push($(this).val());
            });
            console.log(formatiOptioni);
            tipovi = formatiOptioni;
        }

        $.ajax({
            method: 'GET',
            url: '/Materijal/MaterijaliPrikaz',
            data: {
                id: predmetId,
                sort: sort,
                tipovi: tipovi,
                formati: formati
            },
            traditional: true,
            beforeSend: function () {
                $('#sredina').css({
                    'filter': 'blur(10px)',
                    'transition': 'all 0.3s'
                });
            },
            success: function (data) {
                tipovi = [];
                formati = [];
                sort = "";
                $('.kartica').remove();
                $('#sredina').append(data);
                $('#sredina').css('filter', 'blur(0)');
            },
            error: function () {
                console.log("ne valja");
            }
        });
    }
});