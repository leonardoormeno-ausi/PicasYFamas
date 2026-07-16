import { useState } from "react";
import { enviarIntento } from "../servicios/gameService";

function Juego() {
    const [numero, setNumero] = useState("");
    const [resultado, setResultado] = useState<any>(null);

    const enviarIntentoHandler = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const respuesta = await enviarIntento(numero);

            console.log(respuesta);

            setResultado(respuesta);

            // Limpia el input después de enviar el intento
            setNumero("");
        } catch (error) {
            console.error(error);

            alert("Error al enviar el intento");
        }
    };

    return (
        <div>
            <h1>Picas y Famas</h1>

            <h2>Juego</h2>

            <form onSubmit={enviarIntentoHandler}>
                <label>Ingrese un número de 4 cifras</label>

                <br />
                <br />

                <input
                    type="text"
                    maxLength={4}
                    value={numero}
                    onChange={(e) => setNumero(e.target.value)}
                />

                <br />
                <br />

                <button type="submit">
                    Adivinar
                </button>
            </form>

            {resultado && (
                <div>
                    <hr />

                    <h3>Resultado</h3>

                    <p>
                        <strong>Picas:</strong> {resultado.picas}
                    </p>

                    <p>
                        <strong>Famas:</strong> {resultado.famas}
                    </p>

                    <p>{resultado.message}</p>

                    {resultado.isWinner && (
                        <h2>🎉 ¡Ganaste la partida! 🎉</h2>
                    )}
                </div>
            )}
        </div>
    );
}

export default Juego;