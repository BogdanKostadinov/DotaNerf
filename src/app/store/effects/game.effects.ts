import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of } from 'rxjs';
import { GameService } from '../../services/game.service';
import * as GameActions from '../actions/game.actions';

@Injectable()
export class GameEffects {
  constructor(
    private actions$: Actions,
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
  getGame$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GameActions.loadGame),
      mergeMap((action) =>
        this.gameService.getGame$(action.gameId).pipe(
          map((game) => GameActions.loadGameSuccess({ game })),
          catchError((error) => of(GameActions.loadGameFailure({ error }))),
        ),
      ),
    ),
  );
  getPlayerGames$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GameActions.loadPlayerGames),
      mergeMap((action) =>
        this.gameService.getPlayerGames$(action.playerId).pipe(
          map((games) => GameActions.loadPlayerGamesSuccess({ games })),
          catchError((error) =>
            of(GameActions.loadPlayerGamesFailure({ error })),
          ),
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
