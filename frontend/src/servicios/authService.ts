import axios from "axios";

const API_URL = "http://localhost:5065/api/game/v1";

export async function login(email: string, password: string) {
    const response = await axios.post(`${API_URL}/login`, {
        email,
        password
    });

    return response.data;
}