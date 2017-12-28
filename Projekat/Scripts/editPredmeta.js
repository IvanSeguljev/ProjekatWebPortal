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

    var smerIds = [];

    $('.edit').click(function () {
        $edit = $(this);
        var predmetId = $edit.parent().parent().attr('id');
        var predmetNaziv = $edit.parent().parent().find("a[class='naziv-predmeta-na-kartici']").text();
        var predmetOpis = $edit.parent().parent().find("div.opisPredmeta p").text();

        $edit = $(this);

        $.ajax({
            method: 'GET',
            url: '/Predmet/VratiSmerove',
            data: {
                predmetId: predmetId
            },
            success: function (data) {
                for (var smerId in data) {
                    smerIds.push(smerId);
                }
                console.log(smerids);
            }
        });

        $('.modal-edit .modal-header span').text(predmetNaziv);
        $(".modal-edit .modal-body input[name='predmetId']").val(predmetId);
        $(".modal-edit .modal-body input[name='predmet.predmetNaziv']").val(predmetNaziv);
        $(".modal-edit .modal-body textarea[name='predmet.predmetOpis']").val(predmetOpis);
    });

    $('#submitEdit').click(function () {
        $.ajax({
            method: 'POST',
            url: '/Predmet/Edit',
            data: {
                predmetNaziv: predmetNaziv,
                predmetOpis: predmetOpis,
                smeroviId: smerids,
            },
            complete: function () {
                sessionStorage.setItem('editedPredmet', true);
                smerids = [];
                location.reload();
            }
        });
    });
    });
});