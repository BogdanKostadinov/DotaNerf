import { PlayerGameEntry } from './player.model';
import { TeamDetails } from './team.model';

export interface Game {
  id: string;
  winningTeam: TeamName;
}

export interface GameDetails extends Game {
  radiantTeam: TeamDetails;
  direTeam: TeamDetails;
}

export interface CreateGameDTO {
  winningTeam: TeamName;
  radiantTeam: {
    name: TeamName;
    players: PlayerGameEntry[];
  };
  direTeam: {
    name: TeamName;
    players: PlayerGameEntry[];
  };
}

export enum TeamName {
  Radiant = 'Radiant',
  Dire = 'Dire',
}