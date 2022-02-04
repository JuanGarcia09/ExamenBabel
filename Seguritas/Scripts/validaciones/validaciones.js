
const expresiones = {
    soloLetras: /[^a-zA-Z ]/,
    soloNumeros: /[^0-9]/,
    email: /^[^@]+@[^@]+\.[a-zA-Z]{2,}$/,
    maxDescripcion: /^[\s\S]{0,90}$/ 
}

function validarNombre(e) {
    if (expresiones.soloLetras.test(e.value)) {
        document.getElementById('lblErrorNombre').style.display = "block";
    } else {
        document.getElementById('lblErrorNombre').style.display = "none";
    }
}

function validarApellidoPaterno(e) {
    if (expresiones.soloLetras.test(e.value)) {
        document.getElementById('lblErrorApellidoPaterno').style.display = "block";
    } else {
        document.getElementById('lblErrorApellidoPaterno').style.display = "none";
    }
}

function validarApellidoMaterno(e) {
    if (expresiones.soloLetras.test(e.value)) {
        document.getElementById('lblErrorApellidoMaterno').style.display = "block";
    } else {
        document.getElementById('lblErrorApellidoMaterno').style.display = "none";
    }
}

function validarEmail(e) {
    if (expresiones.email.test(e.value)) {
        document.getElementById('lblErrorEmail').style.display = "none";
    } else {
        document.getElementById('lblErrorEmail').style.display = "block";
    }
}

function validarTelefono(e) {
    if (expresiones.soloNumeros.test(e.value)) {
        document.getElementById('lblErrorTelefono').style.display = "block";
    } else {
        document.getElementById('lblErrorTelefono').style.display = "none";
    }

    validarSexo();
}

function validarDescripcion(e) {
    if (!expresiones.maxDescripcion.test(e.value)) {
        document.getElementById('lblErrorDescripcion').style.display = "block";
    } else {
        document.getElementById('lblErrorDescripcion').style.display = "none";
    }
}

function validarSexo() {
    if (!document.querySelector('input[name="sexo"]:checked')) {
        document.getElementById('lblErrorSexo').style.display = "block";
    } else {
        document.getElementById('lblErrorSexo').style.display = "none";
    }
}


