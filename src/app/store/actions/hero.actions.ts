import { createAction, props } from '@ngrx/store';
import { Hero } from '../../models/hero.model';

export const loadHeroes = createAction('[Heroe] Load Heroes');
export const loadHeroesSuccess = createAction(
  '[Heroe] Load Heroes Success',
  props<{ heroes: Hero[] }>(),
);
export const loadHeroesFailure = createAction(
  '[Heroe] Load Heroes Failure',
  props<{ error: string }>(),
);
