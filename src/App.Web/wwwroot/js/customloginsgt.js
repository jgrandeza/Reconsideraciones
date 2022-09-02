
FormValidation.formValidation(document.getElementById('formLogin'), {
        fields: {
            email: {
                validators: {
                    notEmpty: {
                        message: "Ingrese su Usuario"
                    }
                }
            },
            password: {
                validators: {
                    notEmpty: {
                        message: "Ingrese su Clave"
                    }
                }
            }
        },
        plugins: {
            trigger: new FormValidation.plugins.Trigger,
            bootstrap: new FormValidation.plugins.Bootstrap5({
                rowSelector: ".fv-row"
            })
        },
    });

$(".btnAjaxFormLogin").on('click', function (e) {
    e.preventDefault();
    var botonActual = $(this);
    $(botonActual).attr('disabled', true);
    Cargar();
    var idFormulario = $(botonActual).data("formulario");
    var formAjaxAdd = $(idFormulario);

    var validAjaxAdd = formAjaxAdd.validate({
        //== Validate only visible fields
        rules: {
            email: "required",
            password: "required",
        },
        messages: {
            email: "Ingrese su Usuario",
            password: "Ingrese su Clave"
        },

        //== Display error  
        invalidHandler: function (event, validAjax) {            
            $(botonActual).attr('disabled', false);
            Swal.fire({
                text: "Lo sentimos, parece que se han detectado algunos errores, intentalo de nuevo.",
                icon: "error",
                buttonsStyling: !1,
                confirmButtonText: "Ok!",
                customClass: {
                    confirmButton: "btn btn-danger"
                }
            })
            Terminar();
        },
        //== Submit valid form
        submitHandler: function (form) {
        }
    });
    if (validAjaxAdd.form() == false) {
        return;
    }
    formAjaxAdd.ajaxSubmit({
        success: function (response) {
            if (response.isSuccess == true) {
                if (response.url != "" && response.url != null) {
                    window.location.href = response.url;
                } else {                   
                    Swal.fire({
                        text: response.message,
                        icon: "success",
                        buttonsStyling: !1,
                        confirmButtonText: "Ok!",
                        customClass: {
                            confirmButton: "btn btn-danger"
                        }
                    })
                }
            } else {
                Swal.fire({
                    text: response.message,
                    icon: "error",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-danger"
                    }
                })
                Terminar();
            }           
            $(botonActual).attr('disabled', false);
        },
        error: function (request, status, error) {

            $(botonActual).attr('disabled', false);
            Swal.fire({
                text: "Lo sentimos, parece que se han detectado algunos errores, intentalo de nuevo.",
                icon: "error",
                buttonsStyling: !1,
                confirmButtonText: "Ok!",
                customClass: {
                    confirmButton: "btn btn-danger"
                }
            })
            Terminar();
        }
    });

});

function Cargar() {
    $("#lblacceder").hide();
    $("#lblcargar").show();
    $("#icocargar").show();
}
function Terminar() {
    $("#lblacceder").show();
    $("#lblcargar").hide();
    $("#icocargar").hide();

}