import React, { useState, useEffect } from "react";

interface GamePageProps {
    playerName: string;
    gameDuration: number;
    questionCount: number;
    onGameEnd: (score: { correct: number; incorrect: number }) => void;
}

const GamePage: React.FC<GamePageProps> = ({ playerName, gameDuration, questionCount, onGameEnd }) => {
    const [currentQuestion, setCurrentQuestion] = useState<number | null>(null);
    const [answer, setAnswer] = useState("");
    const [score, setScore] = useState({ correct: 0, incorrect: 0 });
    const [timeLeft, setTimeLeft] = useState(gameDuration);
    const [questionsAsked, setQuestionsAsked] = useState(0);

    useEffect(() => {
        if (timeLeft <= 0 || questionsAsked >= questionCount) {
            onGameEnd(score);
        }
        const timer = setInterval(() => setTimeLeft((prev) => prev - 1), 1000);
        return () => clearInterval(timer);
    }, [timeLeft, questionsAsked]);

    useEffect(() => {
        generateNewQuestion();
    }, []);

    const generateNewQuestion = () => {
        const randomNum = Math.floor(Math.random() * 1000) + 1;
        setCurrentQuestion(randomNum);
        setQuestionsAsked((prev) => prev + 1);
    };

    const handleSubmit = () => {
        if (!currentQuestion) return;

        const isCorrect = checkAnswer(currentQuestion, answer);
        setScore((prev) => ({
            correct: prev.correct + (isCorrect ? 1 : 0),
            incorrect: prev.incorrect + (isCorrect ? 0 : 1),
        }));
        setAnswer("");
        generateNewQuestion();
    };

    const checkAnswer = (number: number, userAnswer: string) => {
        let expectedAnswer = "";
        if (number % 7 === 0) expectedAnswer += "Foo";
        if (number % 13 === 0) expectedAnswer += "Boo";
        if (number % 103 === 0) expectedAnswer += "Loo";
        return expectedAnswer || number.toString() === userAnswer;
    };

    return (
        <div>
            <h1>Welcome, {playerName}!</h1>
            <p>Time Left: {timeLeft}s</p>
            <p>Score: {score.correct} Correct, {score.incorrect} Incorrect</p>

            {currentQuestion && (
                <div>
                    <p>Question: {currentQuestion}</p>
                    <label htmlFor="answer-input">Your Answer:</label>
                    <input
                        id="answer-input"
                        type="text"
                        value={answer}
                        onChange={(e) => setAnswer(e.target.value)}
                    />
                    <button onClick={handleSubmit}>Submit</button>
                </div>
            )}
        </div>
    );
};

export default GamePage;