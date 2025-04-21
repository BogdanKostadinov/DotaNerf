import { Action, createReducer, on } from '@ngrx/store';
import * as Actions from '../actions/player.actions';
import { PlayerState } from '../app.state';

export const initialPlayerState: PlayerState = {
  players: [],
  loading: false,
  error: null,
};

const _playerReducer = createReducer(
  initialPlayerState,
  on(Actions.loadPlayers, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(Actions.loadPlayersSuccess, (state, { players }) => ({
    ...state,
    players: players,
    loading: false,
    error: null,
  })),
  on(Actions.loadPlayersFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error: error,
  })),
);

export function playersReducer(
  state: PlayerState | undefined,
  action: Action,
): PlayerState {
  return _playerReducer(state, action);
}
