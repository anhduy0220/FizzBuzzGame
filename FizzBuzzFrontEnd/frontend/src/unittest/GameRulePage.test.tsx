import { render, screen } from '@testing-library/react';
import GameRulePage from '../components/GameRulePage/GameRulePage';
import { describe, it, expect, vi } from 'vitest';

// Mock data
const mockRules = [
  { id: 1, divisor: 3, replacement: 'Fizz', gameId: 1 }
];

vi.mock('../../Services/GameService', () => ({
  GameService: {
    getGameRules: vi.fn().mockResolvedValue(mockRules)
  }
}));

describe('GameRulePage', () => {
  it('displays game rules in a table', async () => {
    render(<GameRulePage />);
    expect(await screen.findByRole('table')).toBeInTheDocument();
    expect(screen.getByText(/Fizz/i)).toBeInTheDocument();
  });
});