import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { obtenerIntentos } from "../servicios/gameService";
import "../styles/Historial.css";

type Intento = {
    attemptedNumber: string;
    picas: number;
    famas: number;
    attemptDate: string;
};

function Intentos() {
    const navigate = useNavigate();

    const { gameId } = useParams();

    const [intentos, setIntentos] = useState<Intento[]>([]);

    useEffect(() => {
        cargarIntentos();
    }, []);

    const cargarIntentos = async () => {
        try {
            const datos = await obtenerIntentos(Number(gameId));

            console.log(datos);

            setIntentos(datos);
        } catch (error) {
            console.error(error);

            alert("No se pudieron cargar los intentos.");
        }
    };

    return (
        <div className="historial-container">
            <h1>Picas y Famas</h1>

            <h2>Partida N.º {gameId}</h2>

            <table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Número</th>
                        <th>Picas</th>
                        <th>Famas</th>
                        <th>Fecha</th>
                    </tr>
                </thead>

                <tbody>
                    {intentos.map((intento, index) => (
                        <tr key={index}>
                            <td>{index + 1}</td>

                            <td>{intento.attemptedNumber}</td>

                            <td>{intento.picas}</td>

                            <td>{intento.famas}</td>

                            <td>
                                {new Date(intento.attemptDate).toLocaleString()}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <br />

            <button onClick={() => navigate("/historial")}>
                Volver
            </button>
        </div>
    );
}

export default Intentos;