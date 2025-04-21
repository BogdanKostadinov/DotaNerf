import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { GameDetails } from '../../models/game.model';
import { loadPlayerGames } from '../../store/actions/game.actions';
import { AppState } from '../../store/app.state';
import {
  selectAllGames,
  selectPlayerGamesLoading,
} from '../../store/selectors/game.selectors';

@Component({
  selector: 'app-player-games',
  templateUrl: './player-games.component.html',
  styleUrl: './player-games.component.scss',
})
export class PlayerGamesComponent implements OnInit {
  games$: Observable<GameDetails[]>;
  loading$: Observable<boolean>;
  playerId = '';

  constructor(
    private route: ActivatedRoute,
    private store: Store<AppState>,
  ) {
    this.playerId = this.route.snapshot.paramMap.get('id') || '';
    this.games$ = this.store.select(selectAllGames);
    this.loading$ = this.store.select(selectPlayerGamesLoading);
  }

  ngOnInit(): void {
    this.store.dispatch(loadPlayerGames({ playerId: this.playerId }));
  }
}
