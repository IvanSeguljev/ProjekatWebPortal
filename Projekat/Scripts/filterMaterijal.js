$(document).ready(function () { 
    $("select").on("change", function () {
        
        var url = window.location.href;
        var args = url.split('/');

        query = args[args.length - 1];
        var sort = '';
        var filterDatumSpanText = $('.datum').next('.customSelect').find('span').text();

        var novijeStarije = $(".customLista li");
        for (var i = 0; i < novijeStarije.length ; i++) {
            if (novijeStarije[i].textContent === filterDatumSpanText ) {
                sort = novijeStarije[i].id;
            }
        }
        var tipovi = [];
        var formati = [];

        $('.select2materijali').next().find('.select2-selection__choice').each(function (index, element) {
            var tip = $(this).attr('title');
            tipovi.push(tip);
        });
        //console.log(tipovi);
        
        $('.select2formati').next().find('.select2-selection__choice').each(function (index, element) {
            var format = $(this).attr('title');
            console.log(format);
            formati.push(format);
        });
        //console.log(formati);

        if (sort === "opadajuce") sort = 'opadajuce';
        else if (sort === "rastuce") sort = 'rastuce';
        else sort = '';

        if (1) {
            $.ajax({
                method: 'GET',
                url: '/Materijal/MaterijaliPrikaz',
                data: {
                    id: query,
                    sort: sort,
                    tipovi: tipovi,
                    formati: formati
                },
                beforeSend: function () {
                    $('#sredina').css({
                        'filter': 'blur(0px)', //stavio sam ti na 0 jer je jos scuffed
                        'transition': 'all 0.3s'
                    });
                },
                success: function (data) {
                    $('#sredina').css('filter', 'blur(0)');
                    $('.kartica').each(function (index, element) {
                        var kartica = $(this);

                        var materijalId = data[index].materijalId;
                        var materijalNaslov = data[index].materijalNaslov;
                        var materijalOpis = data[index].materijalOpis;
                        var ImgPath = data[index].ImgPath;
                        var path = ImgPath.substring(1);

                        kartica.attr('id', materijalId);
                        kartica.find('h2').text(materijalNaslov);
                        kartica.find($('.opis')).text(materijalOpis);
                        kartica.find($('.imgPath')).attr('src', path);
                        kartica.find($('.preuzmi')).attr('href', '/Materijal/DownloadMaterijal/' + materijalId);
                    });
                }
            });
        }
    });
});