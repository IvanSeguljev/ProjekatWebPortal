$(document).ready(function () {

    $('.select2predmeti').select2();

    var isEdited = sessionStorage.getItem('editedPredmet');

    if (isEdited) {
        $('#snackbar').css('display', 'block');
        sessionStorage.removeItem('editedPredmet');
    }
    else
        $('#snackbar').css('display', 'none');

    var url = window.location.href;
    var args = url.split('/');

    var smerId = args[args.length - 1];

    $('.edit').click(function () {
        $edit = $(this);
        var predmetId = $edit.parent().parent().attr('id');
        var predmetNaziv = $edit.parent().parent().find("a[class='naziv-predmeta-na-kartici']").text();
        var predmetOpis = $edit.parent().parent().find("div.opisPredmeta p").text();

        $('.modal-edit .modal-header span').text(predmetNaziv);
        $(".modal-edit .modal-body input[name='predmetId']").val(predmetId);
        $(".modal-edit .modal-body input[name='predmet.predmetNaziv']").val(predmetNaziv);
        $(".modal-edit .modal-body textarea[name='predmet.predmetOpis']").val(predmetOpis);
    });

    $('#submitEdit').click(function () {
        $.ajax({
            method: 'POST',
            url: '/Predmet/DodajPredmet',
            data: {
                predmetId: predmetId,
                predmetNaziv: predmetNaziv,
                predmetOpis: predmetOpis
            },
            complete: function () {
                sessionStorage.setItem('editedPredmet', true);
                location.reload();
            }
        });
    });
});