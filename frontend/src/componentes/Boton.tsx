type BotonProps = {
    texto: string;
    onClick?: () => void;
    type?: "button" | "submit";
};

function Boton({
    texto,
    onClick,
    type = "button"
}: BotonProps) {
    return (
        <button
            type={type}
            onClick={onClick}
        >
            {texto}
        </button>
    );
}

export default Boton;