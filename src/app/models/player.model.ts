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
  name?: string;
  playerStats: PlayerStats[];
}

export interface PlayerDetails {
  winrate: number;
  totalGames: number;
  gamesWon: number;
  gamesLost: number;
  playerGroup: PlayerGroup;
}

export interface PlayerStats {
  heroPlayed: Hero;
  kills?: number;
  deaths?: number;
  assists?: number;
}

export interface UpdatePlayerGameEntryDTO {
  id: string;
  playerStats: UpdatePlayerStatsDTO;
}

export interface UpdatePlayerStatsDTO {
  heroPlayedId: number;
}

export enum PlayerGroup {
  Kulalii = 0,
  Poznati = 1,
  Randoms = 2,
}
