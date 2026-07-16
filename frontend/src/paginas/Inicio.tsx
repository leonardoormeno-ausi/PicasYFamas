import { iniciarPartida } from "../servicios/gameService";
import { useNavigate } from "react-router-dom";

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

    return (
        <div>
            <h1>Picas y Famas</h1>

            <h2>Bienvenido</h2>

            <hr />

            <button onClick={nuevaPartida}>
                Nueva partida
            </button>

            <br /><br />

            <button>Historial</button>

            <br /><br />

            <button>Estadísticas</button>

            <br /><br />

            <button>Cerrar sesión</button>
        </div>
    );
}

export default Inicio;