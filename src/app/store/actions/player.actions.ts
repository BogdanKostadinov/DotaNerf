import { createAction, props } from '@ngrx/store';
import { Player } from '../../models/player.model';

export const loadPlayers = createAction('[Player] Load Players');
export const loadPlayersSuccess = createAction(
  '[Player] Load Players Success',
  props<{ players: Player[] }>(),
);
export const loadPlayersFailure = createAction(
  '[Player] Load Players Failure',
  props<{ error: string }>(),
);
