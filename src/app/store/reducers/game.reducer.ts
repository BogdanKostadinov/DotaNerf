import { Action, createReducer, on } from '@ngrx/store';
import * as Actions from '../actions/game.actions';
import { GameState } from '../app.state';

export const initialGameState: GameState = {
  games: [],
  loading: false,
  error: null,
};

const _gameReducer = createReducer(
  initialGameState,
  on(Actions.loadGames, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(Actions.loadGamesSuccess, (state, { games }) => ({
    ...state,
    games: games,
    loading: false,
    error: null,
  })),
  on(Actions.loadGamesFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error: error,
  })),
  on(Actions.loadPlayerGames, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(Actions.loadPlayerGamesSuccess, (state, { games }) => ({
    ...state,
    games: games,
    loading: false,
    error: null,
  })),
  on(Actions.loadPlayerGamesFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error: error,
  })),
  on(Actions.loadGame, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(Actions.loadGameSuccess, (state, { game }) => ({
    ...state,
    games: state.games.map((g) => (g.id === game.id ? game : g)),
    loading: false,
    error: null,
  })),
  on(Actions.loadGameFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error: error,
  })),
  on(Actions.createGame, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(Actions.createGameSuccess, (state, { game }) => ({
    ...state,
    games: [...state.games, game],
    loading: false,
    error: null,
  })),
  on(Actions.createGameFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error: error,
  })),
);

export function gamesReducer(
  state: GameState | undefined,
  action: Action,
): GameState {
  return _gameReducer(state, action);
}
