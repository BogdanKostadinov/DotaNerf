import { Hero } from './hero.model';

export interface Player {
  id: string;
  name: string;
  winrate: number;
  totalGames: number;
  gamesWon: number;
  gamesLost: number;
  games: GameStats[];
}

export interface GameStats {
  heroPlayed: Hero;
  xpm?: number;
  gpm?: number;
  lastHits?: number;
  kills?: number;
  deaths?: number;
  assists?: number;
  gameDuration?: number;
  gameResult: number;
  playerId: string;
}

// to be uesd in the game stats component
export enum GameResult {
  Won = 'Won',
  Lost = 'Lost',
}
