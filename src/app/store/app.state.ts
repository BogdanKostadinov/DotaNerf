import { ActionReducerMap } from '@ngrx/store';
import { GameDetails } from '../models/game.model';
import { Hero } from '../models/hero.model';
import { Player } from '../models/player.model';
import { gamesReducer } from './reducers/game.reducer';
import { heroesReducer } from './reducers/hero.reducer';
import { playersReducer } from './reducers/player.reducer';

export interface AppState {
  games: GameState;
  players: PlayerState;
  heroes: HeroState;
}
export interface GameState {
  games: GameDetails[];
  loading: boolean;
  error: string | null;
}
export interface PlayerState {
  players: Player[];
  loading: boolean;
  error: string | null;
}
export interface HeroState {
  heroes: Hero[];
}
export const reducers: ActionReducerMap<AppState> = {
  games: gamesReducer,
  players: playersReducer,
  heroes: heroesReducer,
};
