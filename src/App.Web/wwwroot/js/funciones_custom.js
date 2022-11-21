var estado_ajax = false;
function CargarForm(frm) { 
    try {
        CargarWaitMe();
        $(".content-custom").html("");
        estado_ajax = true;
        $(".content-custom").css({ "opacity": "1" });
        $(".content-custom").stop();
        //$(".content").html("").hide("fade");
        $(".content-custom").hide("fade");
        var form =  frm; 
        setTimeout(function () {
            xhr_p = $.ajax({
                url: form,
                type: 'post',
                beforeSend: function () {
                },
                success: function (response) {
                    $('.content-custom').html(response);
                    $('.content-custom').show("fade");
                    estado_ajax = false;
                    TerminarWaitMe();
                    //$(".content").html(response);
                    //.show("fade");
                    //$('.count-to').countTo();
                    //initRealTimeChart();
                    //initDonutChart();
                    //initSparkline();
                }, error: function (jqxhr, textStatus, errorThrown) {
                    $(".content-custom").html("");
                    estado_ajax = false;
                    TerminarWaitMe();
                }
            });
        }, 500);


    } catch (ex) {
        //alert(ex);
        estado_ajax = false;
        TerminarWaitMe();
    }
    return false;
}

function saltar(e, id) {
    // Obtenemos la tecla pulsada
    (e.keyCode) ? k = e.keyCode : k = e.which;

    // Si la tecla pulsada es enter (codigo ascii 13)
    if (k == 13) {
        // Si la variable id contiene "submit" enviamos el formulario
        if (id == "submit") {
            document.forms[0].submit();
        } else {
            // nos posicionamos en el siguiente input
            document.getElementById(id).focus();
        }
    }
}

function saltar_click(e, id) {
    // Obtenemos la tecla pulsada
    (e.keyCode) ? k = e.keyCode : k = e.which;

    // Si la tecla pulsada es enter (codigo ascii 13)
    if (k == 13) {
        // Si la variable id contiene "submit" enviamos el formulario
        if (id == "submit") {
            document.forms[0].submit();
        } else {
            // nos posicionamos en el siguiente input
            document.getElementById(id).click();
        }
    }
}

function filterFloat(evt, input) {
    // Backspace = 8, Enter = 13, ‘0′ = 48, ‘9′ = 57, ‘.’ = 46, ‘-’ = 43
    var key = window.Event ? evt.which : evt.keyCode;
    var chark = String.fromCharCode(key);
    var tempValue = input.value + chark;
    if (key >= 48 && key <= 57) {
        if (filter(tempValue) === false) {
            return false;
        } else {
            return true;
        }
    } else {
        if (key == 8 || key == 13 || key == 0) {
            return true;
        } else if (key == 46) {
            if (filter(tempValue) === false) {
                return false;
            } else {
                return true;
            }
        } else {
            return false;
        }
    }
}
function filter(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,2})$/;
    if (preg.test(__val__) === true) {
        return true;
    } else {
        return false;
    }

}

function soloNumeros(e) {
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key <= 57)
}

function formato_dinero(dato) {
    return new Intl.NumberFormat('es-PE', { style: 'currency', currency: 'PEN' }).format(dato);
}

function formMilesDec(val_monto) {
    var tmp = val_monto + ' ', val_rpta;
    var pos = tmp.indexOf('.'), val_dec;

    if (pos >= 0) {
        val_dec = tmp.substr(pos + 1, 2) + '00';
        tmp = tmp.substr(0, pos) + ' ';
    }

    val_rpta = tmp.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ",");

    if (pos >= 0) {
        val_rpta = val_rpta + '.' + val_dec.substr(0, 2);
    } else {
        val_rpta = val_rpta + '.00';
    }

    if (val_monto < 0) {
        val_rpta = '-' + val_rpta;
    }

    return val_rpta;
}

function formMiles(val_monto) {
    var tmp = val_monto + ' ', val_rpta;

    val_rpta = tmp.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ",");

    if (val_monto < 0) {
        val_rpta = '-' + val_rpta;
    }

    return val_rpta;
}
