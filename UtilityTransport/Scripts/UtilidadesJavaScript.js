


function EstableceMensajesJqueryValidate() {
    $.extend($.validator.messages, {
        maxlength: $.validator.format("Favor ingrese {0} o menos caracteres"),
        minlength: $.validator.format("Favor ingrese al menos {0} caracteres"),
        required: $.validator.format("Este valor es Requerido"),
        url: "Debe ingresar una dirección web válida",
        rangelength: $.validator.format("Favor ingrese un valor entre {0} y {1} caracteres de longitud"),
        range: $.validator.format("Favor ingrese un valor entre {0} y {1}"),
        max: $.validator.format("Favor ingrese un valor menor o igual a: {0}"),
        min: $.validator.format("Favor ingrese un valor mayor o igual a: {0}"),
        number: "Favor ingrese un número válido",
        digits: "Favor ingrese solo números",
        email: "Favor ingrese una dirección de correo electrónico válida",
        accept: $.validator.format("Favor seleccione un formato válido {0}"),
        extension: $.validator.format("Favor seleccione un formato válido {0}"),
        require_from_group: $.validator.format("Ingrese al menos uno de estos valores")
    });
}

/**Funciones para validar solo numeros */
$(".clsSoloNumeros").bind('keypress', function (e) {
    //alert(e.keyCode);
    if (e.keyCode) {
        if (e.keyCode > 47 && e.keyCode < 58) {
            return true;
        }
        else {
            return false;
        }
    } else if (e.which) {
        if ((e.which == 46) || (e.which > 47 && e.which < 58)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
});



$(".clsSoloNumeros").bind("paste", function (e) {
    e.preventDefault();
});

/**Funcion para Validar Mensaje de Respuesta */
function ValidarMensajeControlador() {
    if (strResultado != null && strResultado != undefined & strResultado != '') {
        strResultado = strResultado.replace('á', '\xf3');
        strResultado = strResultado.replace('é', '\xf3');
        strResultado = strResultado.replace('í', '\xf3');
        strResultado = strResultado.replace('ó', '\xf3');
        strResultado = strResultado.replace('ú', '\xf3');
        strResultado = strResultado.replace('ñ', '\xf3');

        bootbox.alert({
            message: strResultado,
            className: 'rubberBand animated modal-top',
            callback: function () {
            }
        });
        strResultado = '';
    }
};


/**Funcion para Asignar Longitud de Control*/
function LimitarLongitud(strNomControl, nLongitud) {
    document.getElementById(strNomControl).onkeypress = function (e) {
        if ((e.keyCode == 46) || (e.keyCode == 8)) {
            return true;
        }
        else if ((document.getElementById(strNomControl).value.length + 1) > nLongitud) {
            return false;
        }
    };
};

function AsignarFormatoFecha(strNomControl) {
    $(strNomControl).datepicker({
        showAnim: 'fadeIn',
        dateFormat: 'mm/dd/yy',
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true
    }).prop('readOnly', true);
};


function MostrarCerrarSesion() {
    document.getElementById('divMensaje').style.display = 'block';
}

function OcultarCerrarSesion() {
    document.getElementById('divMensaje').style.display = 'none';
}

function LlamarAjax(Url, parametros) {
    var objResultado = '';

    $.ajax({
        url: Url,
        dataType: 'json',
        type: 'post',
        async: false,
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            if (data.Timeout) {
                bootbox.alert({
                    message: 'Sesión ha sido finalizada por inactividad.',
                    className: 'rubberBand animated',
                    callback: function () {
                        window.location.href = data.url;
                    }
                });
            } else {
                objResultado = data;
            }
        },
        error: function (jQxhr, textStatus, errorThrown) {
            bootbox.alert({
                message: 'Error ejecutando Ajax ' + textStatus,
                className: 'rubberBand animated'
            });
        }
    });

    return objResultado;
}