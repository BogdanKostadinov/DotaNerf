import { Action, createReducer, on } from '@ngrx/store';
import * as Actions from '../actions/player.actions';
import { PlayerState } from '../app.state';

export const gameFeatureKey = 'game';
export const initialPlayerState: PlayerState = {
  players: [],
};

const _playerReducer = createReducer(
  initialPlayerState,
  on(Actions.loadPlayersSuccess, (state, { players }) => ({
    ...state,
    players: players,
  })),
  on(Actions.loadPlayersFailure, (state, { error }) => ({
    ...state,
    error: error,
  })),
);

export function playersReducer(
  state: PlayerState | undefined,
  action: Action,
): PlayerState {
  return _playerReducer(state, action);
}
