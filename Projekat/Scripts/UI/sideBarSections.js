$(function () {

   
 
    var link = '';
    var idLinka = sessionStorage.getItem('idLinka');


    $('.ListaNav li:not(.naslov) p').on('click', function () {

        sessionStorage.setItem('aktivanLink', link);
        sessionStorage.setItem('idLinka', $(this).attr('id'));

        $(this).addClass('aktivanLink').siblings().removeClass('aktivanLink');
    });


    if (idLinka) {
        console.log($(".ListaNav li:not(.naslov) p").filter($("#" + idLinka)));

            $(".ListaNav li:not(.naslov) p").filter($("#" + idLinka)).addClass('aktivanLink').siblings().removeClass('aktivanLink');

        }
});

