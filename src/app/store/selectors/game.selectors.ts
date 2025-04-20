import { createSelector } from '@ngrx/store';
import { AppState, GameState } from '../app.state';

export const selectGameState = (state: AppState) => state.games;

export const selectAllGames = createSelector(
  selectGameState,
  (state: GameState) => state.games,
);
export const selectGameById = (gameId: string) =>
  createSelector(selectGameState, (state: GameState) =>
    state.games.find((game) => game.id === gameId),
  );
