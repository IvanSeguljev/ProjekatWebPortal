$(document).ready(function () {

    //kupljenje vrednosti
    var sredinaSirina = $('#sredina').width();

    var LeftBar = $('.LeftBar:first');

    //LeftBar.css("position", "fixed");

    function triTackeKontrole() {
        if ((sredinaSirina < 1130 && sredinaSirina > 958) || sredinaSirina < 555) {
            $(".delete, .uredi, .komentarisi").css('display', 'none');
            $(".triTackeKontrole").css('display', 'inline-block');
        }
            //else if (sredinaSirina > 1130) {
        else {
            $(".triTackeKontrole").css('display', 'none');
            $(".delete, .uredi, .komentarisi").css('display', 'inline-block');
        }
    }
    triTackeKontrole();

    function sakrijFormat() {
        if (sredinaSirina < 450) {
            $('.karticaFormat').css({ 'display': 'none', 'overflow': 'hidden' });
            $('.karticaTekts').css("width", "100%");
        }
        else {
            $('.karticaFormat').removeAttr("style");
            $('.karticaTekts').removeAttr("style");
        }
    };
    sakrijFormat();

    $(window).on('resize', function () {
        sakrijFormat();
        //OVO ISPOD MENE BRISI
        console.log(sredinaSirina + "(ಠ⌣ಠ)");

        sredinaSirina = $('#sredina').width();

        triTackeKontrole();
        //savrsena sirina za uslov je 1153px TAKODJE VAR UZIMA SIRINU BEZZ MARGINA I PADDINGA
        if (sredinaSirina < 958) {
            $('div.kartica').css('width', '100%').css('width', '-=55px');
            //$('div.kartica').css("width", "calc(100% - 68px)");
        } else if (sredinaSirina > 958) {
            $('div.kartica').css("width", "calc(50% - 55px)");
        }
    });

    //kartice responsive

    $('#hamburger-menu-toggle').click(function () {
        $this = $(this);
        setTimeout(function () {
            $(window).trigger('resize');
        }, 300);
    });

    //kraj kartica responsive


    //OTVARANJE ZATVARANJE NAPREDNE PRETRAGE
    $('#lupaPretragaToggle').click(function () {
        if($('#naprednaPretraga').css('transform') !== "matrix(1, 0, 0, 1, 0, -65)"){
        //$('#naprednaPretraga').toggle("blind", 200);
            $('#naprednaPretraga').css({ 'transform': 'translate(0, -65px)', 'margin-bottom': '0' });
        }
        else{
            $('#naprednaPretraga').css({ 'transform': 'translate(0, 0)', 'margin-bottom': '69px' });
        }
    });


    //trigger resiza da bi se resize funkcija za kartice runovala
    $(window).trigger('resize');
});