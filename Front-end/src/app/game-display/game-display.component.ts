import { Component } from '@angular/core';
import { GameService } from '../services/game.service';
import { Observable } from 'rxjs';
import { GameDetails } from '../models/game.model';

@Component({
  selector: 'app-game-display',
  templateUrl: './game-display.component.html',
  styleUrl: './game-display.component.scss',
})
export class GameDisplayComponent {
  games$: Observable<GameDetails[]>;
  constructor(private gameService: GameService) {
    this.games$ = this.gameService.getGames$();
  }
}
