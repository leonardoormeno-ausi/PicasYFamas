type ResultadoValidacion = {
    valido: boolean;
    mensaje: string;
};

export function validarNumero(numero: string): ResultadoValidacion {

    if (numero.length !== 4) {
        return {
            valido: false,
            mensaje: "El número debe tener exactamente 4 cifras."
        };
    }

    if (!/^\d+$/.test(numero)) {
        return {
            valido: false,
            mensaje: "Solo se permiten números."
        };
    }

    const digitos = new Set(numero);

    if (digitos.size !== 4) {
        return {
            valido: false,
            mensaje: "No se permiten números repetidos."
        };
    }

    return {
        valido: true,
        mensaje: ""
    };
}