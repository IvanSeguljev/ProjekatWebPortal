$(document).ready(function () {

    brojKlikovaNaLupu = 0;

    $(".customDropdown").each(function () {
        var customSelect = '<div class="customSelect" id="trenutnoPravim"> <div class="izabraniUselectu"> <span>' +
            $(this).find("option:selected").text() + '</span> <div class="trougao"></div> </div> <ul class="customLista"></ul> </div>';


        $(this).after(customSelect);

        var arrayLijeva = $(this).find($('option')).toArray();

        $.each(arrayLijeva, function () {
            $('#trenutnoPravim ul.customLista').append(($('<li></li>').text($(this).text())));
        });


        var lista = $('.customLista li');


        $('#trenutnoPravim').removeAttr('id');
    });


    $(".customLista").each(function () {
        var sirinaListe = parseFloat($(this).css('width'));

        console.log(sirinaListe + " ovo je sirinaListe");

        $(this).css("width", sirinaListe + 42 + "px");
        $(this).parent().css("width", $(this).css("width"));
        $(this).parent().css("max-width", "200px");
        $(this).css("max-width", "200px");
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