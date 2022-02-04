
function limpiar() {
    $('#mi_modal #myModalLabel').empty();
    $('#mi_modal #myModalLabel').text("Agregar plan");
    $('#colIdPlan').hide();
    $('#formulario')[0].reset();
    $('#fechaModificacion').hide();
    $('.fechaModificacion').hide();
}


function Form() {

    var plan = {
        IdPlan: $('#idPlan').val(),
        Nombre: $('#nombre').val(),
        Descripcion: $('#descripcion').val(),
        FechaModificacion: $('#fechaModificacion').val(),
        Planes: null
    }

    if (plan.IdPlan == " ") { //agregar
        PlanAdd(plan);
    } else { //actualizar
        PlanUpdate(plan);
    }
}

function PlanAdd(plan) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:16859/api/Plan/Add',
        dataType: 'json',
        data: plan,
        success: function (result) {
            //Si la peticion es correcta 
            alert('Plan agregado correctamente!!');
        },
        error: function (result) {
            //Si ocurrio un error en la peticion 
            alert('Error al agregar plan!!');
        }
    });
}

function PlanGetById(idPlan) {
    $('#mi_modal #myModalLabel').empty();
    $('#mi_modal #myModalLabel').text("Actualizar plan");
    $('#colIdPlan').show();
    $('#fechaModificacion').show();
    $('.fechaModificacion').show();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:16859/api/Plan/GetById/' + idPlan,
        success: function (result) {
            $('#idPlan').val(result.Object.IdPlan);
            $('#nombre').val(result.Object.Nombre);
            $('#descripcion').val(result.Object.Descripcion);
            $('#fechaModificacion').val(result.Object.FechaModificacion);

        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
}

function PlanUpdate(plan) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:16859/api/Plan/Update',
        dataType: 'json',
        data: plan,
        success: function (result) {
            alert('Plan actualizado correctamente!!');
        },
        error: function (result) {
            alert('Error al actualizar plan!!');
        }
    });
}