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
- **Title header**: "井字棋" / "Tic-Tac-Toe · 双人对战".
- **Scoreboard**: three counters — Player X wins, Draws, Player O wins. The active player's counter is visually highlighted while the round is in progress.
- **Status line**: shows whose turn it is, or the round result ("玩家 X 获胜！" / "平局！").
- **Board**: 9 clickable cells. Filled cells are disabled. On win, the 3 winning cells are highlighted distinctly from the rest.
- **Controls**:
  - "再来一局" (Play Again) — clears the board and starts a new round, keeping cumulative scores.
  - "清空比分" (Reset Scores) — resets all scores to 0 and starts a new round.

## Behavior Details
- Clicking an already-filled cell, or clicking any cell after the round has ended, has no effect.
- Newly placed marks animate in with a short pop/scale-in effect.
- Turn indicator and scoreboard highlighting update immediately after each move.
- Winning line cells receive a distinct highlight color separate from the normal X/O colors.

## Visual Design
- Dark theme (`#1a1b26` background) with a centered card-style panel.
- Distinct colors per role: cyan for X, orange for O, green for win highlights, muted purple/gray for neutral text and draws.
- Responsive card layout (fixed ~380px width), rounded corners, subtle shadows, hover states on interactive cells and buttons.

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
