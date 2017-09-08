console.log('YAHOO');
onload = function () {
    var predmetID;
    $("#predmet-dropdown").on("change", function () {
        //$("#SelectedvendorText").val($(this).text());
        //alert($("#predmet-dropdown option:selected").val());
        predmetID = $("#predmet-dropdown option:selected").val();
        alert(predmetID);
    });
};