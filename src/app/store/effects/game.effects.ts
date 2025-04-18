import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { catchError, map, mergeMap, of } from 'rxjs';
import { GameService } from '../../services/game.service';
import * as GameActions from '../actions/game.actions';

@Injectable()
export class GameEffects {
  constructor(
    private actions$: Actions,
    private store: Store,
    private gameService: GameService,
  ) {}

  getGames$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GameActions.loadGames),
      mergeMap(() =>
        this.gameService.getGames$().pipe(
          map((games) => GameActions.loadGamesSuccess({ games })),
          catchError((error) => of(GameActions.loadGamesFailure({ error }))),
        ),
      ),
    ),
  );

  addGame$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GameActions.createGame),
      mergeMap((action) =>
        this.gameService.createGame$(action.game).pipe(
          map((game) => GameActions.createGameSuccess({ game })),
          catchError((error) => of(GameActions.createGameFailure({ error }))),
        ),
      ),
    ),
  );

  addGameSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GameActions.createGameSuccess),
      map(() => GameActions.loadGames()),
    ),
  );
}
