import React, { useState } from "react";

interface HomePageProps {
    onStartGame: (name: string, duration: number, questionCount: number) => void;
}

export const HomePage: React.FC<HomePageProps> = ({ onStartGame }) => {
    const [name, setName] = useState("");
    const [duration, setDuration] = useState(60);
    const [questionCount, setQuestionCount] = useState(10);

    const handleStartGame = () => {
        if (name.trim() === "") {
            alert("Please enter your name.");
            return;
        }
        onStartGame(name, duration, questionCount);
    };
  return (
      <div>
          <h1>Welcome to FizzBuzzGame</h1>

          <div>
            <h2>Game Rules:</h2>
              <div>Replace divisble number by 7 by Foo</div>
              <div>Replace divisble number by 13 by Boo</div>
              <div>Replace divisble number by 103 by Loo</div>       
          </div>

          <div>
            <label>
            Your Name:
            <input
                type='text'
                value={name}
                onChange={(e) => setName(e.target.value)}
            />
            </label>
          </div>

          <div>
                <label>
                    Game Duration (seconds):
                    <input
                        type="number"
                        value={duration}
                        onChange={(e) => setDuration(parseInt(e.target.value) || 0)}
                        min={10}
                    />
                </label>
            </div>

            <div>
                <label>
                    Number of Questions:
                    <input
                        type="number"
                        value={questionCount}
                        onChange={(e) => setQuestionCount(parseInt(e.target.value) || 0)}
                        min={1}
                    />
                </label>
            </div>

            <button onClick={handleStartGame}>Start Game</button>

      </div>
  )
}