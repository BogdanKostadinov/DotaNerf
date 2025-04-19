import { ActionReducerMap } from '@ngrx/store';
import { GameDetails } from '../models/game.model';
import { gamesReducer } from './reducers/game.reducer';

export interface AppState {
  games: GameState;
}
export interface GameState {
  games: GameDetails[];
}
export const reducers: ActionReducerMap<AppState> = {
  games: gamesReducer,
};
