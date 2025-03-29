import React, { useState, useEffect } from 'react';
import { GameService } from '../Services/GameService';
import './GamePage.css';

const GamePage: React.FC = () => {
  const [currentNumber, setCurrentNumber] = useState<number | null>(null);
  const [sessionId, setSessionId] = useState<number | null>(null);
  const [score, setScore] = useState({ correct: 0, incorrect: 0 });

  const startGame = async () => {
    const response = await GameService.startSession(1, 1, 60); // Example IDs
    setSessionId(response.data.gameSessionId);
    setCurrentNumber(response.data.number);
  };

  const handleAnswer = async (answer: string) => {
    if (!sessionId || currentNumber === null) return;
    
    const response = await GameService.submitAnswer(
      sessionId, 
      currentNumber, 
      answer
    );
    
    setScore(prev => ({
      correct: response.data.isCorrect ? prev.correct + 1 : prev.correct,
      incorrect: !response.data.isCorrect ? prev.incorrect + 1 : prev.incorrect
    }));
    
    setCurrentNumber(response.data.nextNumber);
  };

  useEffect(() => {
    startGame();
  }, []);

  return (
    <div className="game-container">
      <h2>Current Number: {currentNumber}</h2>
      <div className="button-group">
        <button onClick={() => handleAnswer('Foo')}>Foo</button>
        <button onClick={() => handleAnswer('Boo')}>Boo</button>
        <button onClick={() => handleAnswer('Loo')}>Loo</button>
      </div>
      <div className="score">
        Correct: {score.correct} | Incorrect: {score.incorrect}
      </div>
    </div>
  );
};

export default GamePage;