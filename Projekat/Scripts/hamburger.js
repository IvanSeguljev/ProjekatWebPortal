$(document).ready(function () {

    $('.LeftBar:first').css("position", "fixed");

    var sirinaNava;

    $('#hamburger-menu-toggle').unbind('click');

    $('#hamburger-menu-toggle').bind('click', function () {
        $('.LeftBar:first').toggleClass('notActive');
        sirinaNava = $('.LeftBar:first').offset().left;
        if (sirinaNava == 0) {  //ZATVARANJE
            $(this).removeClass('hamburger-menu-toggle-otvoren');
            $('#gornjaNavigacija').css({ 'transition': '.3s', 'margin-left': "0px", 'width': "100%" });
            $('#sredina').css({ 'width': "100%" });
            $('.LeftBar:first').css({ 'width': "0" });
            $('div#gornjaNavigacija a#nazad').css({ 'margin-left': "70px" });
            sessionStorage.setItem("hamburgerState", "zatvoren");
        }
        else if (sirinaNava == -338) { //OTVARANJE
            if ($(window).width() < 1025) {
                $('#sredina').css({ 'width': "100%" });
                $('.LeftBar:first').css({ "z-index": "999" });
            }
            else {
                $('#gornjaNavigacija').removeAttr("style");
                $('#sredina').removeAttr("style");
                $('div#gornjaNavigacija a#nazad').css({ 'margin-left': "29px" });
                $('.LeftBar:first').css({ "z-index": "1" });
            }
            $('.LeftBar:first').css({ 'width': "338px" });
            $(this).addClass('hamburger-menu-toggle-otvoren');
            sessionStorage.setItem("hamburgerState", "otvoren");
        }

    });
    //ako ne radi brisi sve ispod mene osim dve poslednje zagrade

    window.onresize = function () {

        if ($('#gornjaNavigacija').width() < 680) {
            $('#gornjaNavigacija p:first').css({ 'display': "none" });

        } else if ($('#gornjaNavigacija').width() > 680) {
            $('#gornjaNavigacija p:first').show();
        }

    }

    window.onresize = function () {

        sirinaNava = $('.LeftBar:first').offset().left;

        if ($(window).width() < 1025 && sirinaNava == 0) {
            $('#sredina').css({ 'width': "100%" });
            $('.LeftBar:first').css({ "z-index": "999" });

        } else if ($(window).width() > 1025 && sirinaNava == 0) {
            $('#sredina').removeAttr("style");
            $('.LeftBar:first').css({ "z-index": "0" });
        }

    }


    $(window).trigger('resize');

});

