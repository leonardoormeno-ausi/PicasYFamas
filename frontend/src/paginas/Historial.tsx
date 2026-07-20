import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { obtenerHistorial, obtenerIntentos } from "../servicios/gameService";
import "../styles/Historial.css";

type Partida = {
    gameId: number;
    status: string;
    createdAt: string;
    finishedAt: string | null;
    attempts: number;
};

function Historial() {
    const navigate = useNavigate();

    const [historial, setHistorial] = useState<Partida[]>([]);

    useEffect(() => {
        cargarHistorial();
    }, []);

    const cargarHistorial = async () => {
        try {
            const datos = await obtenerHistorial();

            console.log(datos);

            setHistorial(datos);
        } catch (error) {
            console.error(error);

            alert("No se pudo cargar el historial.");
        }
    };
    const verIntentos = async (gameId: number) => {
        try {
            const datos = await obtenerIntentos(gameId);

            console.log(datos);
        } catch (error) {
            console.error(error);

            alert("No se pudieron obtener los intentos.");
        }
    };

    return (
        <div className="historial-container">
            <h1>Picas y Famas</h1>

            <h2>Historial de partidas</h2>

            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Estado</th>
                        <th>Intentos</th>
                        <th>Fecha</th>
                        <th>Acción</th>
                    </tr>
                </thead>

                <tbody>
                    {historial.map((partida) => (
                        <tr key={partida.gameId}>
                            <td>{partida.gameId}</td>

                            <td>
                                {partida.status === "Active"
                                    ? "Activa"
                                    : "Finalizada"}
                            </td>

                            <td>{partida.attempts}</td>

                            <td>
                                {new Date(partida.createdAt).toLocaleString()}
                            </td>

                            <td>
                                <button
                                    onClick={() => navigate(`/intentos/${partida.gameId}`)}
                                >
                                    Ver
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <br />

            <button onClick={() => navigate("/inicio")}>
                Volver
            </button>
        </div>
    );
}

export default Historial;