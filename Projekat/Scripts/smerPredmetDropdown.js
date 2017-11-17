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
        $(this).toggleClass("customSelectHighlightovan");
        $(this).find($(".izabraniUselectu")).toggleClass("izabraniUselectuHighlightovan");
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

    //pokusaj zatvaranja customdropdowna na klik negde drugde
   /* $('body').click(function () {
        if ($(".customLista").css('display', 'block')) { 
            var otvoreniCustomDropdownovi = $('.customLista').filter(function(){
                return $(this).css("display") === 'block'
            });

            console.log(otvoreniCustomDropdownovi);

            otvoreniCustomDropdownovi.slideToggle(200);

        }
    });*/


    $(document).click(function (e) {
        if ($(e.target).closest('.customSelect').length === 0) {
            console.log(e.target);
            console.log($(e.target).closest('.customSelect').length);

            var otvoreniCustomDropdownovi = $('.customLista').filter(function () {
                return $(this).css("display") === 'block'
            });

            var trougloviOtvorenihDorpdownova = otvoreniCustomDropdownovi.siblings('.izabraniUselectu').find(".trougao");


            otvoreniCustomDropdownovi.slideUp();
            trougloviOtvorenihDorpdownova.toggleClass("rotate");
            otvoreniCustomDropdownovi.siblings('.izabraniUselectuHighlightovan').removeClass("izabraniUselectuHighlightovan");
            otvoreniCustomDropdownovi.parent(".customSelectHighlightovan").removeClass("customSelectHighlightovan");
        }
        
    });


});