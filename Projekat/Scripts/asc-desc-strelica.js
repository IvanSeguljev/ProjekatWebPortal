$(document).ready(function () {

    $('#opadajuce, #rastuce').click(function () {

        if ($(this).closest(".customSelect").prev().filter(".datum").val() === 'Od novijeg ka starijem') {
            //console.log("od novijeg, strelica gore")
            $(this).closest(".customSelect").next().filter("#asc-desc").css("transform", "translate(11px,0) rotate(90deg)");

        } else {
            //console.log("od starijeg, strelica dole")
            $(this).closest(".customSelect").next().filter("#asc-desc").css("transform", "translate(11px,0) rotate(-90deg)");
        }

    });
});