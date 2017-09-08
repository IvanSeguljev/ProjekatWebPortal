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
    //window.onresize = function () {

    //    if (sredinaSirina < 450) {
    //        $('.karticaFormat').css({ 'display': 'none', 'overflow': 'hidden' });
    //        $('.karticaTekts').css("width", "100%");
    //    } else if (sredinaSirina > 450) {
    //        $('.karticaFormat').removeAttr("style");
    //        $('.karticaTekts').removeAttr("style");
    //    }

    //}

    //kraj kartica responsive


    //trigger resiza da bi se resize funkcija za kartice runovala
    $(window).trigger('resize');
});