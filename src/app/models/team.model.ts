import { TeamName } from './game.model';
import { PlayerGameEntry } from './player.model';

export interface Team {
  id: string;
  name: TeamName;
}

export interface TeamDetails extends Team {
  players: PlayerGameEntry[];
}
