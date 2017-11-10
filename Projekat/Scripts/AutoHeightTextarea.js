$(document).ready(function () {
    
    function textAreaAdjust(o) {
        o.style.height = "1px";
        o.style.height = (25 + o.scrollHeight) + "px";
    }
    //$('#editModal #predmetOpis').on("load keyup", function () {
    $('#predmetOpis').keyup(function () {
        textAreaAdjust(this);

    });


    $('#editModal').on('shown.bs.modal', function (e) {
        var VisinaScrollaTexta = document.getElementById("predmetOpis").scrollHeight;
        //$('#predmetOpis').style.height = "1px";
        $('#predmetOpis').css("height", "1px");
        $('#predmetOpis').css("height", 25 + VisinaScrollaTexta + "px");
        //$('#predmetOpis').style.height = (25 + o.scrollHeight) + "px";
        console.log(VisinaScrollaTexta);

    })

});

