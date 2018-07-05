$(function () {
    $('#listaKorisnika').DataTable();
});
$(document).ready(function () {
    var filter = '<button id="Filter" class="Filter" data-toggle="modal" data-target="#myModal">Napredna Pretraga</button>';
    document.getElementById("listaKorisnika_filter").insertAdjacentHTML('afterbegin', filter);
    document.getElementById("listaKorisnika_filter").getElementsByTagName("label")[0].setAttribute("id", "LabelaPretrazi");
    var labela = document.getElementById("listaKorisnika_filter").getElementsByTagName("label")[0];
    var input = document.getElementById("listaKorisnika_filter").getElementsByTagName("label")[0].getElementsByTagName("input")[0];
    var div = document.getElementById("listaKorisnika_filter");
    labela.removeChild(input);
    div.insertAdjacentElement("beforeend", input);
});
