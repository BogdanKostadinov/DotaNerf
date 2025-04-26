import { createAction, props } from '@ngrx/store';
import {
  CreateGameDTO,
  GameDetails,
  UpdateGameDTO,
} from '../../models/game.model';

// Create game
export const createGame = createAction(
  '[Game] Create Game',
  props<{ game: CreateGameDTO }>(),
);
export const createGameSuccess = createAction(
  '[Game] Create Game Success',
  props<{ game: GameDetails }>(),
);
export const createGameFailure = createAction(
  '[Game] Create Game Failure',
  props<{ error: string }>(),
);

// Update game
export const updateGame = createAction(
  '[Game] Update Game',
  props<{ game: UpdateGameDTO }>(),
);
export const updateGameSuccess = createAction(
  '[Game] Update Game Success',
  props<{ game: GameDetails }>(),
);
export const updateGameFailure = createAction(
  '[Game] Update Game Failure',
  props<{ error: string }>(),
);

// Load games
export const loadGames = createAction('[Game] Load Games');
export const loadGamesSuccess = createAction(
  '[Game] Load Games Success',
  props<{ games: GameDetails[] }>(),
);
export const loadGamesFailure = createAction(
  '[Game] Load Games Failure',
  props<{ error: string }>(),
);

// Load game
export const loadGame = createAction(
  '[Game] Load Game',
  props<{ gameId: string }>(),
);
export const loadGameSuccess = createAction(
  '[Game] Load Game Success',
  props<{ game: GameDetails }>(),
);
export const loadGameFailure = createAction(
  '[Game] Load Game Failure',
  props<{ error: string }>(),
);

// Load player games
export const loadPlayerGames = createAction(
  '[Game] Load Player Game',
  props<{ playerId: string }>(),
);
export const loadPlayerGamesSuccess = createAction(
  '[Game] Load Player Game Success',
  props<{ games: GameDetails[] }>(),
);
export const loadPlayerGamesFailure = createAction(
  '[Game] Load Player Game Failure',
  props<{ error: string }>(),
);

// Delete game
export const deleteGame = createAction(
  '[Game] Delete Game',
  props<{ gameId: string }>(),
);
export const deleteGameSuccess = createAction(
  '[Game] Delete Game Success',
  props<{ gameId: string }>(),
);
export const deleteGameFailure = createAction(
  '[Game] Delete Game Failure',
  props<{ error: string }>(),
);
