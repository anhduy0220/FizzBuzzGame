import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import HomePage from '../components/HomePage/HomePage';
import { describe, it, expect } from 'vitest';
import { BrowserRouter } from 'react-router-dom';

describe('HomePage', () => {
  it('renders welcome message', () => {
    render(
      <BrowserRouter>
        <HomePage />
      </BrowserRouter>
    );
    expect(screen.getByText(/Welcome to FizzBuzz Game!/i)).toBeInTheDocument();
  });

  it('navigates to game page when Start Game is clicked', async () => {
    const user = userEvent.setup();
    render(
      <BrowserRouter>
        <HomePage />
      </BrowserRouter>
    );
    
    await user.click(screen.getByText(/Start Game/i));
    expect(window.location.pathname).toBe('/game');
  });
});