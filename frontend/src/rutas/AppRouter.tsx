import { BrowserRouter, Routes, Route } from "react-router-dom";

import Login from "../paginas/Login";
import Inicio from "../paginas/Inicio";
import Juego from "../paginas/Juego";
import Historial from "../paginas/Historial";
import Estadisticas from "../paginas/Estadisticas";
import Intentos from "../paginas/Intentos";
import ComoJugar from "../paginas/ComoJugar";

function AppRouter() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/inicio" element={<Inicio />} />
                <Route path="/juego" element={<Juego />} />
                <Route path="/historial" element={<Historial />} />
                <Route path="/estadisticas" element={<Estadisticas />} />
                <Route path="/intentos/:gameId" element={<Intentos />} />
                <Route path="/como-jugar" element={<ComoJugar />} />
            </Routes>
        </BrowserRouter>
    );
}

export default AppRouter;