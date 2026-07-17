import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { login } from "../servicios/authService";
import "../styles/Login.css";

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const iniciarSesion = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
        console.log("Email:", email);
        console.log("Password:", password);
        const respuesta = await login(email, password);

        console.log(respuesta);

        localStorage.setItem("token", respuesta.token);

        navigate("/inicio");
    } catch (error) {
        console.error(error);

        alert("Correo o contraseña incorrectos");
    }
};

    return (
        <div className="login-container">
            <h1>Picas y Famas</h1>

            <h2>Iniciar sesión</h2>

            <form onSubmit={iniciarSesion}>
                <div>
                    <label>Correo electrónico</label>
                    <br />
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>

                <br />

                <div>
                    <label>Contraseña</label>
                    <br />
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>

                <br />

                <button type="submit">
                    Iniciar sesión
                </button>
            </form>
        </div>
    );
}

export default Login;