import { Component, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { Observable, Subject } from 'rxjs';
import { GameDetails } from '../../models/game.model';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { loadGames } from '../../store/actions/game.actions';
import { AppState } from '../../store/app.state';
import {
  selectAllGames,
  selectGamesLoading,
} from '../../store/selectors/game.selectors';

@Component({
  selector: 'app-game-display',
  templateUrl: './game-display.component.html',
  styleUrl: './game-display.component.scss',
})
export class GameDisplayComponent implements OnDestroy {
  games$: Observable<GameDetails[]>;
  loading$: Observable<boolean>;
  destroy$ = new Subject<void>();

  constructor(
    private store: Store<AppState>,
    public dialog: MatDialog,
  ) {
    this.games$ = this.store.select(selectAllGames);
    this.loading$ = this.store.select(selectGamesLoading);
    this.store.dispatch(loadGames());
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  requestDeleteGame(gameId: string) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Delete Game',
        message: 'Are you sure you want to delete this game?',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        // Dispatch the delete game action here
        // this.store.dispatch(deleteGame({ gameId }));
      }
    });
  }
}
