import { render, screen, waitFor } from '@testing-library/react';
import GamePage from '../components/GamePage/GamePage';
import { describe, it, expect, vi } from 'vitest';

// Mock the GameService
vi.mock('../../Services/GameService', () => ({
  GameService: {
    startSession: vi.fn().mockResolvedValue({
      gameSessionId: 1,
      number: 15
    }),
    submitAnswer: vi.fn().mockResolvedValue({
      isCorrect: true,
      nextNumber: 20
    })
  }
}));

describe('GamePage', () => {
  it('displays current number after loading', async () => {
    render(<GamePage />);
    await waitFor(() => {
      expect(screen.getByText(/Current Number:/i)).toBeInTheDocument();
    });
  });

  it('updates score when answer is submitted', async () => {
    const { getByText } = render(<GamePage />);
    await userEvent.click(getByText('Fizz'));
    expect(await screen.findByText(/Correct: 1/i)).toBeInTheDocument();
  });
});