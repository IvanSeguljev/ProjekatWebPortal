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
        $(".modal-edit .modal-body input[name='predmetId']").val(predmetId);
        $(".modal-edit .modal-body input[name='predmet.predmetNaziv']").val(predmetNaziv);
        $(".modal-edit .modal-body textarea[name='predmet.predmetOpis']").val(predmetOpis);
    });

    $('#submitEdit').click(function () {
        $.ajax({
            method: 'POST', //razmotriti metod jer je u pitanju edit smera
            url: '/Predmet/DodajPredmet',
            data: {
                predmetId: predmetId,
                predmetNaziv: predmetNaziv,
                predmetOpis: predmetOpis
            },
            complete: function () {
                sessionStorage.setItem('edited', true);
                location.reload();
            }
        });
    });
});