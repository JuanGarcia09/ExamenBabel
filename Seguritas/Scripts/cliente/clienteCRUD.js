
function limpiar() {
    $('#mi_modal #myModalLabel').empty();
    $('#mi_modal #myModalLabel').text("Agregar cliente");
    $('#colIdCliente').hide();
    $('#formulario')[0].reset();
    $('#fechaModificacion').hide();
    $('.fechaModificacion').hide();
}


function Form(e) {

   

        var cliente = {
            IdCliente: $('#idCliente').val(),
            Nombre: $('#nombre').val(),
            ApellidoPaterno: $('#apellidoPaterno').val(),
            ApellidoMaterno: $('#apellidoMaterno').val(),
            Sexo: $('input[name=sexo]:checked').val(),
            Email: $('#email').val(),
            Telefono: $('#telefono').val(),
            FechaModificacion: $('#fechaModificacion').val(),
            Clientes: null
        }



        if (cliente.IdCliente == " ") { //agregar
            ClienteAdd(cliente);
        } else { //actualizar
            ClienteUpdate(cliente);
        }
    
}

function ClienteAdd(cliente) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:16859/api/Cliente/Add',
        dataType: 'json',
        data: cliente,        
        success: function (result) {
            //Si la peticion es correcta 
            alert('Cliente agregado correctamente!!');            
        },
        error: function (result) {
            //Si ocurrio un error en la peticion 
            alert('Error al agregar cliente!!');
        }
    });
}

function ClienteGetById(idCliente) {
    $('#mi_modal #myModalLabel').empty();
    $('#mi_modal #myModalLabel').text("Actualizar cliente");
    $('#colIdCliente').show();
    $('#fechaModificacion').show();
    $('.fechaModificacion').show();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:16859/api/Cliente/GetById/' + idCliente,
        success: function (result) {
            $('#idCliente').val(result.Object.IdCliente);
            $('#nombre').val(result.Object.Nombre);            
            $('#apellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#apellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#sexo').val(result.Object.Sexo);
            $('#email').val(result.Object.Email);
            $('#telefono').val(result.Object.Telefono);            
            $('#fechaModificacion').val(result.Object.FechaModificacion);

        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
}

function ClienteUpdate(cliente) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:16859/api/Cliente/Update',
        dataType: 'json',
        data: cliente,        
        success: function (result) {
            alert('Cliente actualizado correctamente!!');
        },
        error: function (result) {
            alert('Error al actualizar cliente!!');
        }
    });
}

