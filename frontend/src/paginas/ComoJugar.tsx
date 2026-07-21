import { useNavigate } from "react-router-dom";
import "../styles/ComoJugar.css";

function ComoJugar() {
    const navigate = useNavigate();

    return (
        <div className="comojugar-container">
            <h1>Picas y Famas</h1>

            <h2>¿Cómo jugar?</h2>

            <section>
                <h3>🎯 Objetivo</h3>

                <p>
                    Adivinar un número secreto de <strong>4 cifras diferentes</strong>.
                </p>
            </section>

            <section>
                <h3>📋 Reglas</h3>

                <ul>
                    <li>El número tiene 4 dígitos.</li>
                    <li>No se repiten los dígitos.</li>
                    <li>Después de cada intento recibirás pistas.</li>
                </ul>
            </section>

            <section>
                <h3>⭐ ¿Qué es una Fama?</h3>

                <p>
                    Una <strong>Fama</strong> significa que acertaste un número
                    y además está en la posición correcta.
                </p>
            </section>

            <section>
                <h3>⭐ ¿Qué es una Pica?</h3>

                <p>
                    Una <strong>Pica</strong> significa que el número existe,
                    pero está ubicado en otra posición.
                </p>
            </section>

            <section>
                <h3>🏆 ¿Cómo ganar?</h3>

                <p>
                    Ganás cuando obtenés <strong>4 Famas</strong>.
                </p>
            </section>

            <button onClick={() => navigate("/inicio")}>
                Volver
            </button>
        </div>
    );
}

export default ComoJugar;