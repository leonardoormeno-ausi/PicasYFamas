type InputNumeroProps = {
    value: string;
    onChange: (value: string) => void;
};

function InputNumero({
    value,
    onChange
}: InputNumeroProps) {
    const manejarCambio = (texto: string) => {
        // Permite únicamente números
        const soloNumeros = texto.replace(/\D/g, "");

        onChange(soloNumeros);
    };

    return (
        <input
            type="text"
            maxLength={4}
            value={value}
            onChange={(e) => manejarCambio(e.target.value)}
        />
    );
}

export default InputNumero;