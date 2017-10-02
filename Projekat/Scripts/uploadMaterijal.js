$(document).ready(function () {

    var predmetId = sessionStorage.getItem('predmetId');

    if (predmetId != undefined)
        $("#Materijal_predmetId").val(predmetId);
    else
        $("#Materijal_predmetId").val($('#Materijal_predmetId option').first().val());


    var isUploaded = sessionStorage.getItem('upload');
    var data = sessionStorage.getItem('upload');

    if (isUploaded) {
        $('#snackbar').css('display', 'block');
        sessionStorage.removeItem('upload');
    }
    else
        $('#snackbar').css('display', 'none');


    var forma = $('#postavkaMat');

    console.log(sessionStorage);
    $('#postavkaMat').validate({
        rules: {
            materijalNaslov: {
                required: true
            },
            "Materijal.materijalOpis": {
                required: true
            },
            file: {
                required: true,
                fileType: {
                    types: ["pdf", "rar", "jpg", "gif", "png", "zip", "rtf", "mp4", "text"]
                },
                maxFileSize: {
                    "unit": "KB",
                    "size": 5000
                },
                minFileSize: {
                    "unit": "KB",
                    "size": "1"
                }
            }
        },
        messages: {
            materijalNaslov: {
                required: "Polje naslov je obavezno."
            },
            "Materijal.materijalOpis": {
                required: "Polje opis je obavezno."
            },
            file: {
                required: "Morate odabrati fajl.",
                fileType: "Pogrešan format fajla.",
                maxFileSize: "Fajl ne sme biti veći od 5MB",
                minFileSize: "Fajl ne sme biti manji od 1KB"
            }
        },
        submitHandler: function (forma) {
            sessionStorage.setItem('upload', true);
            forma.submit();
        }
    });
        
    //$.validator.addMethod('filesize', function (value, element, param) {
    //    return this.optional(element) || (element.files[0].size <= param)
    //}, 'File size must be less than {0}');



});
