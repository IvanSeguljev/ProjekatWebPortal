$(document).ready(function () {

    $('.select2smerovi').select2();

    var isEdited = sessionStorage.getItem('editedPredmet');

    if (isEdited) {
        $('#snackbar').css('display', 'block');
        sessionStorage.removeItem('editedPredmet');
    }
    else
        $('#snackbar').css('display', 'none');

    $('.edit').click(function () {
        $edit = $(this);
        var predmetId = $edit.parent().parent().attr('id');
        var predmetNaziv = $edit.parent().parent().find("a[class='naziv-predmeta-na-kartici']").text();
        var predmetOpis = $edit.parent().parent().find("div.opisPredmeta p").text();

        $('.modal-edit .modal-header span').text(predmetNaziv);
        $(".modal-edit .modal-body input[name='predmetId']").val(predmetId);
        $(".modal-edit .modal-body input[name='predmetNaziv']").val(predmetNaziv);
        $(".modal-edit .modal-body textarea[name='predmetOpis']").val(predmetOpis);
    });
});