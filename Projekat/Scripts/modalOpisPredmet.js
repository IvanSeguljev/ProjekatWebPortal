$(document).ready(function () {
    console.log('Skripta radi');
        
    $('.opis').click(function () {
        $opis = $(this);
        var predmetNaziv = $opis.parent().parent().find('a:first').text();

        var predmetOpis = $opis.parent().parent().find("div.opisPredmeta p").text();

        console.log(predmetNaziv);
        console.log(predmetOpis);

        $('.modal-header span').text(predmetNaziv);
        $('.modal-body p').text(predmetOpis);
    });
});
