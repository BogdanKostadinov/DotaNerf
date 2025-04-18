import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { GameDetails } from '../models/game.model';
import { GameService } from '../services/game.service';

@Component({
  selector: 'app-player-games',
  templateUrl: './player-games.component.html',
  styleUrl: './player-games.component.scss',
})
export class PlayerGamesComponent {
  games$: Observable<GameDetails[]>;
  loadingDataLabel: string = 'Loading player games...';

  constructor(
    private gameService: GameService,
    private route: ActivatedRoute,
  ) {
    const playerId = this.route.snapshot.paramMap.get('id');
    this.games$ = this.gameService.getPlayerGames$(playerId!);
  }
}
