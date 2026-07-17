type InputNumeroProps = {
    value: string;
    onChange: (value: string) => void;
};

function InputNumero({
    value,
    onChange
}: InputNumeroProps) {
    return (
        <input
            type="text"
            maxLength={4}
            value={value}
            onChange={(e) => onChange(e.target.value)}
        />
    );
}

export default InputNumero;