import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { GameDetails } from '../../models/game.model';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
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
    public dialog: MatDialog,
  ) {
    this.playerId = this.route.snapshot.paramMap.get('id') || '';
    this.games$ = this.store.select(selectAllGames);
    this.loading$ = this.store.select(selectPlayerGamesLoading);
  }

  ngOnInit(): void {
    this.store.dispatch(loadPlayerGames({ playerId: this.playerId }));
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
