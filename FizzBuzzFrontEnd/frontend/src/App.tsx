import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './components/HomePage/HomePage';
import GamePage from './components/GamePage/GamePage';
import GameRulePage from './components/GameRulePage/GameRulePage';
import './App.css';

const App: React.FC = () => {
  const [playerName, setPlayerName] = useState<string>('');

  return (
    <Router>
      <div className="app-container">
        <Routes>
          <Route 
            path="/" 
            element={<HomePage />} 
          />
          <Route 
            path="/game" 
            element={<GamePage />} 
          />
          <Route 
            path="/rules" 
            element={<GameRulePage />} 
          />
        </Routes>
      </div>
    </Router>
  );
};

export default App;