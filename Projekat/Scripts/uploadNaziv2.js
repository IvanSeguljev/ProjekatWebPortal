﻿//document.getElementById('file').onchange = uploadOnChange;
onload = function () {
    document.getElementsByClassName('inputfile')[0].onchange = uploadOnChange;
    console.log(document.getElementsByClassName('inputfile')[0].value);
    function uploadOnChange() {
        var filename = this.value;
        var lastIndex = filename.lastIndexOf("\\");
        if (lastIndex >= 0) {
            filename = filename.substring(lastIndex + 1);
        }
        document.getElementById('filename').innerHTML = filename;
    }

}