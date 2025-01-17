import axios from "axios";

const API = axios.create({
    baseURL: "https://localhost:5001/api", // Replace if proxy is set up
});

export const getGameRules = () => API.get("/GameRules");
export const getPlayers = () => API.get("/Player");
export const getGameSessions = () => API.get("/GameSessions");
export const createGameSession = (data) => API.post("/GameSessions", data);

export default API;
