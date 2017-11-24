$(document).ready(function () {

    $('.select2predmeti').select2();

    var predmetEdited = sessionStorage.getItem('predmetEdited');

    if (predmetEdited) {
        $('#snackbar').css('display', 'block');
        sessionStorage.removeItem('predmetEdited');
    }
    else  $('#snackbar').css('display', 'none');

    var url = window.location.href;
    var args = url.split('/');

    var smerId = args[args.length - 1];

    $('#submitEdit').click(function () {
        $.ajax({
            method: 'GET',
            url: '/Predmet/VratiSmerove',
            data: { smerId: smerId },
            success: function () {
                sessionStorage.setItem('predmetEdited', true);
                location.reload();
            }
        });
    });
});