$(document).ready(function () {
    
    brojKlikovaNaLupu = 0;

    $(".customDropdown").each(function () {
        var customSelect = '<div class="customSelect" id="trenutnoPravim"> <div class="izabraniUselectu"> <span>' +
            $(this).find("option:selected").text() + '</span> <div class="trougao"></div> </div> <ul class="customLista"></ul> </div>';


        $(this).after(customSelect);

        var arrayLijeva = $(this).find($('option')).toArray();

        $.each(arrayLijeva, function () {
            $('#trenutnoPravim ul.customLista').append(($('<li></li>').text($(this).text())));
            //console.log($(this).next().find($('li')));
        });

        //$(this).find($('option')).toArray().each(function () {
        //    $(this).next().find($('ul.customLista')).append(($('<li></li>').text($(this).text())));
        //});
        
        var lista = $('.customLista li');

        

       /* $.each(lista, function (index) {
            if ($('.customLista li')[index].css('width') > $('.customLista').css('width')) {
                $('.customLista').css('width') = lista[index].css('width');
            }
        });*/

        $('#trenutnoPravim').removeAttr('id');
    });



    var formati;
    $('.select2formati').select2({
        width: "auto",
        placeholder: "Filter pretrage",        
    });

    var materijali;
    $('.select2materijali').select2({
        width: "auto",
        placeholder: "Filter pretrage",
    });

    var datum;
    $('.select2_datum').select2({
        width: "auto",
        minimumResultsForSearch: Infinity
    });

    $('.select2formati').on("change", function () {
        formati = $(this).val();
        console.log(formati);
    })
    $('.select2materijali').on("change", function () {
        materijali = $(this).val();
        console.log(materijali);
    })
    $('.select2_datum').on("change", function () {
        datum = $(this).val();
        console.log(datum);
    })





    $("#lupaPretragaToggle").click(function () {
        if (brojKlikovaNaLupu < 1){
        //console.log(sirinaListe);
        //$(".customSelect").css('width', sirinaListe + 2 + 'px');
        //console.log($(".customSelect").css('width'));
        //$('.customLista').css('width', sirinaListe + 'px');


        $(".customLista").each(function () {
            var sirinaListe = parseFloat($(this).css('width'));

            console.log(sirinaListe + " ovo je sirinaListe");

            $(this).css("width", sirinaListe + 32 + "px");
            $(this).parent().css("width", $(this).css("width"));
        }

        );
        }
        brojKlikovaNaLupu = 2;
    });


    $(".customSelect").click(function () {
        $(this).find($('.customLista')).slideToggle(200);
        $(this).find($(".izabraniUselectu .trougao")).toggleClass("rotate");
    });


    

    $(".customSelect li").click(function () {
        var kliknutiTekst = $(this).text();
        $(this).parent().siblings("div").find('span').text($(this).text());
        //$(this).parent().parent().prev().find($("option").removeAttr('selected'));
        $(this).parent().parent().prev().find($("option").filter(function () {
            return $(this).text() === kliknutiTekst;
        }).prop('selected', true));
        //$(this).parent().parent().prev().val(kliknutiTekst);
        //var sirinaListe = parseFloat($(".customSelect").css('width'));
        //$('.customLista').css('width', sirinaListe + 'px');
        

    });







});