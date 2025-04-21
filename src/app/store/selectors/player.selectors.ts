import { createSelector } from '@ngrx/store';
import { AppState, PlayerState } from '../app.state';

export const selectPlayerState = (state: AppState) => state.players;

export const selectAllPlayers = createSelector(
  selectPlayerState,
  (state: PlayerState) => state.players,
);

export const selectPlayersLoading = createSelector(
  selectPlayerState,
  (state: PlayerState) => state.loading,
);

export const selectPlayersError = createSelector(
  selectPlayerState,
  (state: PlayerState) => state.error,
);
