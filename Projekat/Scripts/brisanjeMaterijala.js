// NE RADI JER JE U URL RAZOR VIEW PA MORA INLINE

//$(document).ready(function () {
//    $(".brisi").click(function () {
//        $delete = $(this);

//        var id = $delete.parent().parent().parent().parent().attr('id');
//        var ime = $delete.parent().parent().parent().find('h2').text();

//        console.log(id);
//        $('.modal-body span').text(ime);

//        $('button.btn-default:first').click(function () {
//            $.ajax({
//                //url: "/ControllerName/ActionName",
//                url: '@Url.Action("DeleteConfirmed", "Materijal")' + "/?id=" + id,
//                method: 'post',
//                //data:{id:id},
//                error: function() {
//                    alert('ne radi');
//                },
//                succes: function() {
//                    alert('radi');
//                },
//                complete: function () {
//                    $delete.parent().parent().parent().parent().remove();
//                    $('#banana').css('display', 'block').attr('src', '').attr('src', '../../Content/img/potvrdaBrisanjaGIFGOTOV.gif');
//                    setTimeout(function () { location.reload() }, 2000);

//                }
//            });

//        });
//    });

//});