import React, { useEffect, useState } from "react";
import { getGameRules } from "../api";

interface GameRule {
    id: number;
    divisor: number;
    word: string;
    game: {
        id: number;
        gameName: string;
    };
}

const GameRules: React.FC = () => {
    const [rules, setRules] = useState<GameRule[]>([]);

    useEffect(() => {
        const fetchRules = async () => {
            try {
                const { data } = await getGameRules();
                setRules(data);
            } catch (error) {
                console.error("Error fetching game rules:", error);
            }
        };

        fetchRules();
    }, []);

    return (
        <div>
            <h1>Game Rules</h1>
            <ul>
                {rules.map((rule) => (
                    <li key={rule.id}>
                        {rule.divisor}: {rule.word} (Game: {rule.game.gameName})
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default GameRules;
