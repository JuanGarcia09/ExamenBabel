
function limpiar() {
    $('#mi_modal #myModalLabel').empty();
    $('#mi_modal #myModalLabel').text("Agregar cobertura");
    $('#colIdCobertura').hide();
    $('#formulario')[0].reset();
    $('#fechaModificacion').hide();
    $('.fechaModificacion').hide();
}


function Form() {

    var cobertura = {
        IdCobertura: $('#idCobertura').val(),
        Nombre: $('#nombre').val(),
        Descripcion: $('#descripcion').val(),        
        FechaModificacion: $('#fechaModificacion').val(),
        Coberturas: null
    }



    if (cobertura.IdCobertura == " ") { //agregar
        CoberturaAdd(cobertura);
    } else { //actualizar
        CoberturaUpdate(cobertura);
    }
}

function CoberturaAdd(cobertura) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:16859/api/Cobertura/Add',
        dataType: 'json',
        data: cobertura,
        success: function (result) {
            //Si la peticion es correcta 
            alert('Cobertura agregada correctamente!!');
        },
        error: function (result) {
            //Si ocurrio un error en la peticion 
            alert('Error al agregar cobertura!!');
        }
    });
}

function CoberturaGetById(idCobertura) {
    $('#mi_modal #myModalLabel').empty();
    $('#mi_modal #myModalLabel').text("Actualizar cobertura");
    $('#colIdCobertura').show();
    $('#fechaModificacion').show();
    $('.fechaModificacion').show();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:16859/api/Cobertura/GetById/' + idCobertura,
        success: function (result) {
            $('#idCobertura').val(result.Object.IdCobertura);
            $('#nombre').val(result.Object.Nombre);
            $('#descripcion').val(result.Object.Descripcion);
            $('#fechaModificacion').val(result.Object.FechaModificacion);

        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
}

function CoberturaUpdate(cobertura) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:16859/api/Cobertura/Update',
        dataType: 'json',
        data: cobertura,
        success: function (result) {
            alert('Cobertura actualizada correctamente!!');
        },
        error: function (result) {
            alert('Error al actualizar cobertura!!');
        }
    });
}

