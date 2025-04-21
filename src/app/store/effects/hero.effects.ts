import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of } from 'rxjs';
import { HeroService } from '../../services/hero.service';
import * as HeroActions from '../actions/hero.actions';

@Injectable()
export class HeroEffects {
  constructor(
    private actions$: Actions,
    private heroService: HeroService,
  ) {}

  getHeroes$ = createEffect(() =>
    this.actions$.pipe(
      ofType(HeroActions.loadHeroes),
      mergeMap(() =>
        this.heroService.getHeroes$().pipe(
          map((heroes) => HeroActions.loadHeroesSuccess({ heroes })),
          catchError((error) => of(HeroActions.loadHeroesFailure({ error }))),
        ),
      ),
    ),
  );
}
