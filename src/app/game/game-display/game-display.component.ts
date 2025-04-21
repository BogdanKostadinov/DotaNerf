import { Component, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subject } from 'rxjs';
import { GameDetails } from '../../models/game.model';
import { loadGames } from '../../store/actions/game.actions';
import { AppState } from '../../store/app.state';
import { selectAllGames, selectGamesLoading } from '../../store/selectors/game.selectors';

@Component({
  selector: 'app-game-display',
  templateUrl: './game-display.component.html',
  styleUrl: './game-display.component.scss',
})
export class GameDisplayComponent implements OnDestroy {
  games$: Observable<GameDetails[]>;
  loading$: Observable<boolean>;
  destroy$ = new Subject<void>();

  constructor(private store: Store<AppState>) {
    this.games$ = this.store.select(selectAllGames);
    this.loading$ = this.store.select(selectGamesLoading);
    this.store.dispatch(loadGames());
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
