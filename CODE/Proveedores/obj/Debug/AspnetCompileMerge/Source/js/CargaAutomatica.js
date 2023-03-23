$(function () {


    $(".carga").click(function () {
        //BEGIN OF DELETE SF RSG 02.2023 V2.0
        //$("#dialog-confirm").dialog({
        //    resizable: false,
        //    height: 140,
        //    modal: true,
        //    buttons: {
        //        "Continuar": function () {
        //            $(this).dialog("close");
        //            $('body').css({ 'overflow': 'hidden'});
        //            $('#ventana-flotante').fadeIn();
        //            var ancho = $(window).width() + 10;
        //            var alto = $(window).height() + 10;
        //            var elemento = $('#ventana-flotante');
        //            var posicion = elemento.position();

        //            $('#ventana-flotante').css({
        //                'margin-top': posicion.top - posicion.top - posicion.top,
        //                'margin-left': posicion.left - posicion.left - posicion.left,
        //                'width': ancho, 'height': alto,
        //            });
        //END   OF DELETE SF RSG 02.2023 V2.0
        //BEGIN OF INSERT SF RSG 02.2023 V2.0
        swal({
            title: "¿Deseas continuar?",
            text: "Se ejecutará una carga automática",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((resultado) => {
                if (resultado) {
                    // Hicieron click en "Sí"
                    //END OF INSERT SF RSG 02.2023 V2.0
                    $.post("CargaAutomaticaProv.aspx",
                        {

                        },
                        function (data) {
                            //alert(data);
                            //var info = $(data).find("span");
                            //var info = data.getElementById('lblRetroalimentacion');
                            //alert(info);
                            //$("#contenidoPost").html(data);
                            //alert(data);
                            //alert(data);
                            ////BEGIN OF INSERT SF RSG 02.2023 V2.0
                            //swal({
                            //    title: "Se cargo exitosamente",
                            //    text: '',
                            //    icon: 'success',
                            //    timer: 5000,
                            //    showConfirmButton: false
                            //})
                            ////END OF INSERT SF RSG 02.2023 V2.0
                            document.location.href = "Proveedores.aspx";

                        }).fail(function () {

                            alert("La aplicación es actualmente inaccesible. Por favor revisa tu conexión a internet");
                        });
                    //BEGIN OF INSERT SF RSG 02.2023 V2.0
                } else {
                    // Dijeron que no
                    console.log("*NO se CARGAN PROVEEDORES*");
                }
                //END OF INSERT SF RSG 02.2023 V2.0
                //BEGIN OF DELETE SF RSG 02.2023 V2.0
                //},
                //Cancel: function () {
                //    $(this).dialog("close");
                //}
                //}
                //END   OF DELETE SF RSG 02.2023 V2.0
            });




    });
});