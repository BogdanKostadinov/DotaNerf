import { GameDetails } from './game.model';
import { Hero } from './hero.model';

export interface Player {
  id: string;
  name: string;
  playerDetails: PlayerDetails;
  games: GameDetails[];
}

export interface PlayerGameEntry {
  id: string;
  name: string;
  playerStats: PlayerStats[];
}

export interface PlayerStats {
  heroPlayed: Hero;
  kills: number;
  deaths: number;
  assists: number;
}

export interface PlayerDetails {
  winrate: number;
  totalGames: number;
  gamesWon: number;
  gamesLost: number;
}
