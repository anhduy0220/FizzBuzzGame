import React, { useEffect, useState } from 'react';
import { GameService } from '../Services/GameService';
import { Game, GameRule } from '../../types/types';
import './GameRulePage.css';

const GameRulePage: React.FC = () => {
  const [games, setGames] = useState<Game[]>([]);
  const [selectedGameId, setSelectedGameId] = useState<number | null>(null);
  const [rules, setRules] = useState<GameRule[]>([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const gamesResponse = await GameService.getGames();
        setGames(gamesResponse.data);
        setIsLoading(false);
      } catch (error) {
        console.error("Error fetching games:", error);
        setIsLoading(false);
      }
    };

    fetchData();
  }, []);

  useEffect(() => {
    if (selectedGameId) {
      const fetchRules = async () => {
        try {
          const rulesResponse = await GameService.getGameRules(selectedGameId);
          setRules(rulesResponse.data);
        } catch (error) {
          console.error("Error fetching rules:", error);
        }
      };

      fetchRules();
    }
  }, [selectedGameId]);

  if (isLoading) {
    return <div className="loading">Loading games...</div>;
  }

  return (
    <div className="game-rule-container">
      <h1>Game Rules</h1>
      
      <div className="game-selector">
        <label htmlFor="game-select">Select a Game: </label>
        <select
          id="game-select"
          value={selectedGameId || ''}
          onChange={(e) => setSelectedGameId(Number(e.target.value))}
        >
          <option value="">-- Choose a game --</option>
          {games.map((game) => (
            <option key={game.id} value={game.id}>
              {game.name} (by {game.author})
            </option>
          ))}
        </select>
      </div>

      {selectedGameId && (
        <div className="rules-list">
          <h2>Rules for {games.find(g => g.id === selectedGameId)?.name}</h2>
          {rules.length > 0 ? (
            <table>
              <thead>
                <tr>
                  <th>Divisor</th>
                  <th>Replacement Word</th>
                </tr>
              </thead>
              <tbody>
                {rules.map((rule) => (
                  <tr key={rule.id}>
                    <td>{rule.divisor}</td>
                    <td>{rule.replacement}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          ) : (
            <p>No rules defined for this game.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default GameRulePage;