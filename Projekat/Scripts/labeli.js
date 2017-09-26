$(document).ready(function () {

    $('input, textarea').each(function () {

        if ($(this).val().length !== 0) {
            $(this).prev().filter(".matDesignLabel").addClass("fokusiraniMatDesignLabel");
        }
        else { }
    });


    $('input, textarea').on("keyup focus", function () {

        if ($(this).val().length === 0) {
            $(this).prev().filter(".matDesignLabel").removeClass("fokusiraniMatDesignLabel");
        }
        else {
            $(this).prev().filter(".matDesignLabel").addClass("fokusiraniMatDesignLabel");
        }
    });

    $('input, textarea').on("blur", function () {
        if ($(this).val().length === 0) {
            $(this).prev().filter(".matDesignLabel").removeClass("fokusiraniMatDesignLabel");
        }
        else { }
    });


});