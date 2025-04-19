import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of } from 'rxjs';
import { PlayerService } from '../../services/player.service';
import * as PlayerActions from '../actions/player.actions';

@Injectable()
export class PlayerEffects {
  constructor(
    private actions$: Actions,
    private playerService: PlayerService,
  ) {}

  getPlayers$ = createEffect(() =>
    this.actions$.pipe(
      ofType(PlayerActions.loadPlayers),
      mergeMap(() =>
        this.playerService.getPlayers$().pipe(
          map((players) => PlayerActions.loadPlayersSuccess({ players })),
          catchError((error) =>
            of(PlayerActions.loadPlayersFailure({ error })),
          ),
        ),
      ),
    ),
  );
}
