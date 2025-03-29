import React from 'react';
import { useNavigate } from 'react-router-dom';
import './HomePage.css';

const HomePage: React.FC = () => {
  const navigate = useNavigate();

  return (
    <div className="container">
      <div className="home-container">
        <h1 className="home-title">Welcome to FizzBuzz Game!</h1>
        <div className="button-group">
          <button onClick={() => navigate('/game')}>Start Game</button>
          <button onClick={() => navigate('/rules')}>View Rules</button>
        </div>
      </div>
    </div>
  );
};

export default HomePage;