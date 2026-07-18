import axios from "axios";

const API_URL = "http://localhost:5065/api/game/v1";

export async function iniciarPartida() {
    const token = localStorage.getItem("token");

    const response = await axios.post(
        `${API_URL}/new-game`,
        {},
        {
            headers: {
                Authorization: `Bearer ${token}`
            }
        }
    );

    return response.data;
}

export async function enviarIntento(numero: string) {
    const token = localStorage.getItem("token");
    const gameId = Number(localStorage.getItem("gameId"));

    const response = await axios.post(
        `${API_URL}/guess`,
        {
            gameId,
            number: numero
        },
        {
            headers: {
                Authorization: `Bearer ${token}`
            }
        }
    );

    return response.data;
}

export async function obtenerHistorial() {
    const token = localStorage.getItem("token");

    const response = await axios.get(
        `${API_URL}/history`,
        {
            headers: {
                Authorization: `Bearer ${token}`
            }
        }
    );

    return response.data;
}
export async function obtenerEstadisticas() {
    const token = localStorage.getItem("token");

    const response = await axios.get(
        `${API_URL}/stats`,
        {
            headers: {
                Authorization: `Bearer ${token}`
            }
        }
    );

    return response.data;
}