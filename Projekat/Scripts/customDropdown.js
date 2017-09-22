$(document).ready(function () {
    
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

        $('#trenutnoPravim').removeAttr('id');
    });











    $("#lupaPretragaToggle").click(function () {
        var sirinaListe = parseFloat($(".customSelect").css('width'));
        console.log(sirinaListe);
        $(".customSelect").css('width', sirinaListe + 2 + 'px');
        console.log($(".customSelect").css('width'));
        $('.customLista').css('width', sirinaListe + 2 + 'px');
    });


    $(".customSelect").click(function () {
        $(this).find($('.customLista')).slideToggle(200);
    });


    $(".customSelect li").click(function () {
        var kliknutiTekst = $(this).text();
        $(this).parent().siblings("div").find('span').text($(this).text());
        //$(this).parent().parent().prev().find($("option").removeAttr('selected'));
        $(this).parent().parent().prev().find($("option").filter(function () {
            return $(this).text() === kliknutiTekst;
        }).prop('selected', true));
        //$(this).parent().parent().prev().val(kliknutiTekst);
    });







});