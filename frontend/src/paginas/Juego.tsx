import { useState } from "react";
import { enviarIntento } from "../servicios/gameService";
import "../styles/Juego.css";
import Boton from "../componentes/Boton";
import InputNumero from "../componentes/InputNumero";
import TablaIntentos from "../componentes/TablaIntentos";

function Juego() {
    const [numero, setNumero] = useState("");
    const [resultado, setResultado] = useState<any>(null);
    const [historial, setHistorial] = useState<any[]>([]);

    const enviarIntentoHandler = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const respuesta = await enviarIntento(numero);

            console.log(respuesta);

            setResultado(respuesta);

setHistorial((anterior) => [
    ...anterior,
    {
        numero,
        picas: respuesta.picas,
        famas: respuesta.famas
    }
]);

setNumero("");
        } catch (error) {
            console.error(error);

            alert("Error al enviar el intento");
        }
    };

    return (
        <div className="juego-container">
            <h1>Picas y Famas</h1>

            <h2>Juego</h2>
            <form onSubmit={enviarIntentoHandler} className="formulario">
            <label>Ingrese un número de 4 cifras</label>

            <InputNumero
                value={numero}
                onChange={setNumero}
            />

                <Boton
                    texto="Adivinar"
                    type="submit"
                />
        </form>
           <TablaIntentos historial={historial} />
            

            {resultado && (
                <div className="resultado">
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