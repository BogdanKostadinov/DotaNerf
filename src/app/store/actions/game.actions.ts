import { createAction, props } from '@ngrx/store';
import { CreateGameDTO, Game, GameDetails } from '../../models/game.model';

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

export const loadGames = createAction('[Game] Load Games');

export const loadGamesSuccess = createAction(
  '[Game] Load Games Success',
  props<{ games: GameDetails[] }>(),
);

export const loadGamesFailure = createAction(
  '[Game] Load Games Failure',
  props<{ error: string }>(),
);
