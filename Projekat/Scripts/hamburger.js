//$(document).ready(function () {
//    $('.hamburger-menu-toggle').click(function () {
//        console.log('YAHHOOOOOOO');
//        $('#LeftBar').toggle('slide',{direction:'left'}, 400);
//    });

//});

//$(document).ready(function () {
//    $(".hamburger-menu-toggle").click(function (event) {
//        event.preventDefault();
//        if ($("#LeftBar").attr('width') === "0") {
//            ("#LeftBar").width(338);
//        } else {
//            ("#LeftBar").width(0);
//        }


//    });
//});


$(document).ready(function () {

    $('.LeftBar:first').css("position", "fixed");

    var sirinaNava;
    $('#hamburger-menu-toggle').click(function () {
        $('.LeftBar:first').toggleClass('notActive');
        sirinaNava = $('.LeftBar:first').offset().left;
        if (sirinaNava == 0) {
            $('#gornjaNavigacija').css({ 'transition': '.3s', 'margin-left': "0px", 'width': "100%" });
            $('#sredina').css({ 'width': "100%" });
            $('.LeftBar:first').css({ 'width': "0" });
            $('div#gornjaNavigacija a#nazad').css({ 'margin-left': "70px" });
        }
        else if (sirinaNava == -338) {
            //$('#gornjaNavigacija').css({ 'transition': '1s', 'margin-left': "338px", });
            //$('#gornjaNavigacija').css({ 'width':'-='+"338px"});
            $('#gornjaNavigacija').removeAttr("style");
            //stara metoda
            //$('#sredina').css({ 'width': '-=' + "338px" });
            $('#sredina').removeAttr("style");
            $('.LeftBar:first').css({ 'width': "338px" });
            $('div#gornjaNavigacija a#nazad').css({ 'margin-left': "29px" });
        }

    });
    //ako ne radi brisi sve ispod mene osim dve poslednje zagrade


    //var gornjaNavigacijaSirina = $('#gornjaNavigacija').width();

    window.onresize = function () {

        //gornjaNavigacijaSirina = $('#gornjaNavigacija').width();

        if ($('#gornjaNavigacija').width() < 680) {
            console.log('nav je manji od 680px');
            $('#gornjaNavigacija p:first').css({ 'display': "none" });

        } else if ($('#gornjaNavigacija').width() > 680) {
            $('#gornjaNavigacija p:first').show();
        }

    }
    $(window).trigger('resize');

});

