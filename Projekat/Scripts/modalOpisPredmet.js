$(document).ready(function () {
    console.log('Skripta radi');

    var data = sessionStorage.getItem('edited');

    if (data) {
        alert('ok');
        sessionStorage.clear();
    }

    $('.opis').click(function () {
        $opis = $(this);
        var predmetNaziv = $opis.parent().parent().find('a:first').text();

        var predmetOpis = $opis.parent().parent().find("div.opisPredmeta p").text();

        console.log(predmetNaziv);
        console.log(predmetOpis);

        $('.modal-header span').text(predmetNaziv);
        $('.modal-body p').text(predmetOpis);
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
            method: 'POST', //razmotriti metod jer je u pitanju edit smera
            complete: function () {
                sessionStorage.setItem('edited', true);
            }
        });
    });
});
