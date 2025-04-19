import { createSelector } from '@ngrx/store';
import { AppState, PlayerState } from '../app.state';

export const selectPlayerState = (state: AppState) => state.players;

export const selectAllPlayers = createSelector(
  selectPlayerState,
  (state: PlayerState) => state.players,
);
