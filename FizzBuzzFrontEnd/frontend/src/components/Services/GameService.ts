import axios from 'axios';

const API_URL = 'https://localhost:7107/api';

export const GameService = {
  // Games
  getGames: async () => {
    return await axios.get(`${API_URL}/game`);
  },

  // Game Rules
  getGameRules: async (gameId: number) => {
    return await axios.get(`${API_URL}/gamerule/game/${gameId}`);
  },

  // Game Sessions
  startSession: async (gameId: number, playerId: number, duration: number) => {
    return await axios.post(`${API_URL}/gamesession/start`, {
      gameId,
      playerId,
      durationInSeconds: duration
    });
  },

  submitAnswer: async (sessionId: number, number: number, answer: string) => {
    return await axios.post(`${API_URL}/gamesession/answer`, {
      gameSessionId: sessionId,
      number,
      playerAnswer: answer
    });
  }
};