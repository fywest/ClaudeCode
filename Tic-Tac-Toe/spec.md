# Tic-Tac-Toe Game Spec

## Overview
A single-page, browser-based Tic-Tac-Toe (井字棋) game for two local players, implemented as one self-contained HTML file (`index.html`) with inline CSS and JavaScript — no build step or external dependencies.

## Goals
- Two players take turns marking a 3x3 grid.
- Detect wins, draws, and track a running score across rounds.
- Playable by opening `index.html` directly in a browser.

## Non-Goals
- No AI/computer opponent.
- No online multiplayer or networking.
- No persistence across browser sessions (scores reset on page reload).

## Gameplay Rules
- Board is a 3x3 grid of 9 cells, indexed 0–8:
  ```
  0 | 1 | 2
  3 | 4 | 5
  6 | 7 | 8
  ```
- Player X always moves first.
- Players alternate turns; a move fills one empty cell with the current player's mark.
- A player wins by filling any of the 8 winning lines (3 rows, 3 columns, 2 diagonals) with their own mark.
- If all 9 cells are filled with no winning line, the round ends in a draw.
- Once a round ends (win or draw), no further moves are accepted until the board is reset.

## UI Components
- **Title header**: "TIC · TAC · TOE" / "Two players, one board".
- **Scoreboard**: three counters — Player X wins, Draws, Player O wins. The active player's counter is visually highlighted (with a soft glow) while the round is in progress.
- **Status line**: shows whose turn it is ("Turn: Player X"), or the round result ("Player X wins!" / "It's a draw!").
- **Board**: 9 clickable cells. Filled cells are disabled. On win, the 3 winning cells are highlighted with a pulsing glow distinct from the rest.
- **Controls**:
  - "Play Again" — clears the board and starts a new round, keeping cumulative scores.
  - "Reset Scores" — resets all scores to 0 and starts a new round.

## Behavior Details
- Clicking an already-filled cell, or clicking any cell after the round has ended, has no effect.
- Newly placed marks animate in with a short pop/scale-in effect.
- Turn indicator and scoreboard highlighting update immediately after each move.
- Winning line cells receive a distinct highlight color separate from the normal X/O colors.

## Visual Design
- Dark, gradient-mesh background (deep indigo/violet radial glows over a diagonal gradient) with a centered glassmorphic card (`backdrop-filter: blur`, translucent panel, subtle border).
- Gradient-clipped title text (violet → blue → pink).
- Distinct glowing colors per role: cyan for X, pink for O, green for win highlights (each with a matching `text-shadow` glow), muted lavender-gray for neutral text and draws.
- Winning cells pulse with an animated glow; new marks pop in with a bouncy scale-in animation.
- Gradient-filled primary button ("Play Again") with hover lift/glow; secondary button ("Reset Scores") is a subtle outlined/ghost style.
- Responsive card layout (fixed ~400px width), rounded corners, layered shadows, hover states on interactive cells and buttons.

## Technical Notes
- Single file: `index.html` (HTML + `<style>` + `<script>`, no external assets or libraries).
- Game state kept in plain JS variables: `cells` (array of 9 nullable values), `currentPlayer`, `gameOver`, `scores`.
- Board re-rendered from state on every move (`renderBoard()`); no virtual DOM or framework.
- Win detection checks a fixed list of 8 index triples (`WIN_LINES`) after each move.
- No build tooling required; can be served by any static file server or opened directly as a local file.

## File Structure
```
Tic-Tac-Toe/
├── index.html   # game (markup, styles, logic)
└── spec.md      # this document
```
