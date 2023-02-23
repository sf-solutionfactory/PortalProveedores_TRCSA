
function workThis(button) {
    //alert("working");
    //$("#dialog-confirm").dialog({ //DELETE SF RSG 02.2023 V2.0
    //    resizable: false,
    //    height: 140,
    //    modal: true,
    //    buttons: {
    //        "Continuar": function () {
    //            $(this).dialog("close");

    var textoBoton = $(button).find('i').attr('name');   //ADD SF RSG 02.2023 V2.0
    //var textoBoton = $.trim($(button).text());         //DELETE SF RSG 02.2023 V2.0
    //alert(textoBoton);
    var rows = $(button).parents('tr');
    var cellsOfRow = rows[0].getElementsByTagName('td');
    var val = $.trim(cellsOfRow[0].innerHTML);
    var val2 = $.trim(cellsOfRow[1].innerHTML); // solo utilizado para el de web services
    //alert(val +  " " + val2);
    var pantalla = $.trim($("#ContentPlaceHolder1_hidPantalla").val());
    var complemento = $.trim($("#ContentPlaceHolder1_hidComplementoUr").val());
    //alert(complemento);
    if (textoBoton == "Desactivar" || textoBoton == "Activar" || textoBoton ==  "Eliminar") {

        $.post("DelAndUpd.aspx",
            {
                identificador: val,
                pantalla: pantalla,
                desicion: textoBoton,
                complemento: complemento
            },
            function (data) {
                //alert(data);
                document.location.href = data;

            }
        ).fail(function () {
            alert("La aplicación es actualmente inaccesible. Por favor revisa tu conexión a internet");
        });

    }
    else if (textoBoton == "Ver más") {
        switch (pantalla) {
            default:
                break;
        }
    }
    else {
        if (textoBoton == "Modificar") {
            switch (pantalla) {
                case "usuarioPortalP":
                    document.location.href = "usuarios.aspx?toEdit=" + val;
                    break;
                default:
                    break;
            }

        }
        else {
            alert("error, intente nuevamente");
        }
    
    }

    //        },                                                //DELETE SF RSG 02.2023 V2.0
    //        Cancel: function () {
    //            $(this).dialog("close");
    //        }
    //    }
    //});

}

