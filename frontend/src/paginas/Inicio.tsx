import { iniciarPartida } from "../servicios/gameService";
import { useNavigate } from "react-router-dom";
import "../styles/Inicio.css";

function Inicio() {
    const navigate = useNavigate();

    const nuevaPartida = async () => {
        try {
            const respuesta = await iniciarPartida();

            console.log(respuesta);

            localStorage.setItem("gameId", respuesta.gameId);

            navigate("/juego");
        } catch (error) {
            console.error(error);

            alert("No se pudo iniciar la partida");
        }
    };
    const irAHistorial = () => {
        navigate("/historial");
    };
    const irAEstadisticas = () => {
        navigate("/estadisticas");
    };

    const cerrarSesion = () => {
        const confirmar = window.confirm(
            "¿Está seguro que desea cerrar sesión?"
        );

        if (!confirmar) {
            return;
        }

        localStorage.removeItem("token");
        localStorage.removeItem("gameId");

        navigate("/");
    };

    return (
        <div className="inicio-container">
            <h1>Picas y Famas</h1>

            <h2>Bienvenido</h2>

            <hr />

            <div className="botones">
                <button onClick={nuevaPartida}>
                    Nueva partida
                </button>
                
                <button onClick={() => navigate("/como-jugar")}>
                    📖 ¿Cómo jugar?
                </button>

               
                <button onClick={irAHistorial}>
                    Historial
                </button>

                <button onClick={irAEstadisticas}>
                    Estadísticas
                </button>


                <button onClick={cerrarSesion}>
                    Cerrar sesión
                </button>
            </div>
        </div>
    );
}

export default Inicio;