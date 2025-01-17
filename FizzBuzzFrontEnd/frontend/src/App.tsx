import React, { useState } from "react";
import "./App.css";
import { HomePage } from "./components/HomePage";
import GamePage from "./components/GamePage";
import GameRules from "./components/GameRules";

function App() {
    const [gameStarted, setGameStarted] = useState(false);
    const [playerName, setPlayerName] = useState<string | null>(null);
    const [gameDuration, setGameDuration] = useState<number | null>(null);
    const [questionCount, setQuestionCount] = useState<number | null>(null);
    const [score, setScore] = useState<{ correct: number; incorrect: number } | null>(null);

    const handleStartGame = (name: string, duration: number, questions: number) => {
        setPlayerName(name);
        setGameDuration(duration);
        setQuestionCount(questions);
        setGameStarted(true);
    };

    const handleGameEnd = (finalScore: { correct: number; incorrect: number }) => {
        setScore(finalScore);
        setGameStarted(false);
    };

    return (
        <div className="App">
            {!gameStarted ? (
                score ? (
                    <div>
                        <h1>Game Over!</h1>
                        <p>Correct Answers: {score.correct}</p>
                        <p>Incorrect Answers: {score.incorrect}</p>
                        <button onClick={() => setScore(null)}>Play Again</button>
                    </div>
                ) : (
                    <div>
                        <HomePage onStartGame={handleStartGame} />
                        <GameRules />
                    </div>
                )
            ) : (
                <GamePage
                    playerName={playerName!}
                    gameDuration={gameDuration!}
                    questionCount={questionCount!}
                    onGameEnd={handleGameEnd}
                />
            )}
        </div>
    );
}

export default App;
