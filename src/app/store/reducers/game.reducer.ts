import { Action, createReducer, on } from '@ngrx/store';
import * as Actions from '../actions/game.actions';
import { GameState } from '../app.state';

export const initialGameState: GameState = {
  games: [],
};

const _gameReducer = createReducer(
  initialGameState,
  on(Actions.loadGamesSuccess, (state, { games }) => ({
    ...state,
    games: games,
  })),
  on(Actions.loadGamesFailure, (state, { error }) => ({
    ...state,
    error: error,
  })),
  on(Actions.loadGameSuccess, (state, { game }) => ({
    ...state,
    games: state.games.map((g) => (g.id === game.id ? game : g)),
  })),
  on(Actions.loadGameFailure, (state, { error }) => ({
    ...state,
    error: error,
  })),
  on(Actions.createGameSuccess, (state, { game }) => ({
    ...state,
    games: [...state.games, game],
  })),
);

export function gamesReducer(
  state: GameState | undefined,
  action: Action,
): GameState {
  return _gameReducer(state, action);
}
