export interface Game {
    id: number;
    name: string;
    author: string;
  }
  
  export interface GameRule {
    id: number;
    divisor: number;
    replacement: string;
    gameId: number;
  }
  
  export interface GameSession {
    id: number;
    gameId: number;
    playerId: number;
    startTime: string;
    endTime?: string;
    correctAnswers: number;
    incorrectAnswers: number;
  }