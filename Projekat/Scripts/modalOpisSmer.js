$(document).ready(function () {
    console.log('Skripta radi');

    var data = sessionStorage.getItem('edited');

    if(data) {
        $('#snackbar').css('display', 'block');
        sessionStorage.clear();
    }
    else
        $('#snackbar').css('display', 'none');

    $('.opis').click(function () {
        $opis = $(this);
        var smerNaziv = $opis.parent().parent().find("a[class='naziv-smera-na-kartici']").text();
        var smerOpis = $opis.parent().parent().find("div.opisSmera p").text();

        console.log(smerNaziv);
        console.log(smerOpis);
        $('.modal-opis .modal-header span').text(smerNaziv);
        $('.modal-opis .modal-body pre').text(smerOpis);
    });

    $('.edit').click(function () {
        $edit = $(this);
        var smerId = $edit.parent().parent().attr('id');
        var smerNaziv = $edit.parent().parent().find("a[class='naziv-smera-na-kartici']").text();
        var smerOpis = $edit.parent().parent().find("div.opisSmera p").text();

        console.log(smerId);
        console.log(smerNaziv);
        console.log(smerOpis);

        $('.modal-edit .modal-header span').text(smerNaziv);
        $(".modal-edit .modal-body input[name='smerId']").val(smerId);
        $(".modal-edit .modal-body input[name='smerNaziv']").val(smerNaziv);
        $(".modal-edit .modal-body textarea[name='smerOpis']").val(smerOpis);
    });

    $('#submitEdit').click(function () {
        $.ajax({
            method: 'POST', //razmotriti metod jer je u pitanju edit smera
            url: '/Smer/EditSmer',
            data: {
                smerId: smerId,
                smerNaziv: smerNaziv,
                smerOpis: smerOpis
            },
            contentType: 'application/json; charset=utf-8',
            datatype: 'json',
            complete: function() {
                sessionStorage.setItem('edited', true);
            }
        });
    });
});

