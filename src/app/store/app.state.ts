import { ActionReducerMap } from '@ngrx/store';
import { GameDetails } from '../models/game.model';
import { Player } from '../models/player.model';
import { gamesReducer } from './reducers/game.reducer';
import { playersReducer } from './reducers/player.reducer';

export interface AppState {
  games: GameState;
  players: PlayerState;
}
export interface GameState {
  games: GameDetails[];
}
export interface PlayerState {
  players: Player[];
}
export const reducers: ActionReducerMap<AppState> = {
  games: gamesReducer,
  players: playersReducer,
};
