import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { Store } from '@ngrx/store';
import { filter, first, Observable } from 'rxjs';
import { GameDetails } from '../../models/game.model';
import * as GameActions from '../../store/actions/game.actions';
import { AppState } from '../../store/app.state';
import { selectGameById } from '../../store/selectors/game.selectors';

export const gameResolver: ResolveFn<GameDetails | undefined> = (
  route,
): Observable<GameDetails | undefined> => {
  const store = inject(Store<AppState>);
  const gameId = route.paramMap.get('id');

  if (!gameId) {
    return new Observable((subscriber) => {
      subscriber.next(undefined);
      subscriber.complete();
    });
  }
  store.dispatch(GameActions.loadGame({ gameId }));

  return store.select(selectGameById(gameId)).pipe(
    filter((game) => !!game),
    first(),
  );
};
