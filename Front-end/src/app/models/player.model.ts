export interface Player {
  id: number;
  name: string;
  winrate: number;
  totalGames: number;
  gamesWon: number;
  gamesLost: number;
  games: GameStats[];
}

export interface GameStats {
  id: number;
  heroPlayed: string;
  xpm?: number;
  gpm?: number;
  lastHits?: number;
  kills?: number;
  deaths?: number;
  assists?: number;
  gameDuration?: number;
  gameResult: GameResult;
}

export enum GameResult {
  Won = 'Won',
  Lost = 'Lost',
}
