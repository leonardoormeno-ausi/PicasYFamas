import { BrowserRouter, Routes, Route } from "react-router-dom";

import Login from "../paginas/Login";
import Inicio from "../paginas/Inicio";
import Juego from "../paginas/Juego";

function AppRouter() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/inicio" element={<Inicio />} />
                <Route path="/juego" element={<Juego />} />
            </Routes>
        </BrowserRouter>
    );
}

export default AppRouter;