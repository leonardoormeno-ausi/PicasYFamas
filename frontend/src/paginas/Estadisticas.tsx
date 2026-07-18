import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { obtenerEstadisticas } from "../servicios/gameService";
import "../styles/Estadisticas.css";

type Estadisticas = {
    gamesPlayed: number;
    gamesWon: number;
    activeGames: number;
    averageAttempts: number;
    bestGameAttempts: number;
};

function Estadisticas() {
    const navigate = useNavigate();

    const [estadisticas, setEstadisticas] = useState<Estadisticas | null>(null);

    useEffect(() => {
        cargarEstadisticas();
    }, []);

    const cargarEstadisticas = async () => {
        try {
            const datos = await obtenerEstadisticas();

            console.log(datos);

            setEstadisticas(datos);
        } catch (error) {
            console.error(error);

            alert("No se pudieron cargar las estadísticas.");
        }
    };

    return (
        <div className="estadisticas-container">
            <h1>Picas y Famas</h1>

            <h2>Estadísticas</h2>

            {estadisticas && (
                <div className="estadisticas-card">

                    <p>
                        <strong>Partidas jugadas:</strong> {estadisticas.gamesPlayed}
                    </p>

                    <p>
                        <strong>Partidas ganadas:</strong> {estadisticas.gamesWon}
                    </p>

                    <p>
                        <strong>Partidas activas:</strong> {estadisticas.activeGames}
                    </p>

                    <p>
                        <strong>Promedio de intentos:</strong> {estadisticas.averageAttempts}
                    </p>

                    <p>
                        <strong>Mejor partida:</strong>{" "}
                        {estadisticas.bestGameAttempts !== null
                            ? `${estadisticas.bestGameAttempts} intentos`
                            : "Sin partidas ganadas todavía"}
                    </p>
                </div>
            )}

            <button onClick={() => navigate("/inicio")}>
                Volver
            </button>
        </div>
    );
}

export default Estadisticas;