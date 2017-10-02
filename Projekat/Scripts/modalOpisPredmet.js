$(document).ready(function () {
    console.log('Skripta radi');

    $('.getMaterijali').click(function (e) {
        $predmetMat = $(this);

        var predmetId = $predmetMat.parent().parent().attr('id');

        sessionStorage.setItem('predmetId', predmetId);
    });

    var data = sessionStorage.getItem('edited');
    if (data) {
        $('#snackbar').css('display', 'block');
        sessionStorage.clear();
    }
    else
        $('#snackbar').css('display', 'none');


    $('.opis').click(function () {
        $opis = $(this);
        var predmetNaziv = $opis.parent().parent().find('a:first').text();

        var predmetOpis = $opis.parent().parent().find("div.opisPredmeta p").text();

        console.log(predmetNaziv);
        console.log(predmetOpis);

        $('.modal-header span').text(predmetNaziv);
        $('.modal-body pre').text(predmetOpis);
    });

    $('.edit').click(function () {
        $edit = $(this);
        var predmetId = $edit.parent().parent().attr('id');
        var predmetNaziv = $edit.parent().parent().find("a[class='naziv-predmeta-na-kartici']").text();
        var predmetOpis = $edit.parent().parent().find("div.opisPredmeta p").text();

        console.log(predmetId);
        console.log(predmetNaziv);
        console.log(predmetOpis);

        $('.modal-edit .modal-header span').text(predmetNaziv);
        $(".modal-edit .modal-body input[name='smerId']").val(predmetId);
        $(".modal-edit .modal-body input[name='smerNaziv']").val(predmetNaziv);
        $(".modal-edit .modal-body textarea[name='smerOpis']").val(predmetOpis);
    });

    $('#submitEdit').click(function () {
        $.ajax({
            method: 'POST', //razmotriti metod jer je u pitanju edit predmeta
            url: '/Predmet/EditPredmet',
            data: {
                predmetId: predmetId,
                predmetNaziv: predmetNaziv,
                predmetOpis: predmetOpis
            },
            contentType: 'application/json; charset=utf-8',
            datatype: 'json',
            complete: function () {
                sessionStorage.setItem('edited', true);
            }
        });
    });
});