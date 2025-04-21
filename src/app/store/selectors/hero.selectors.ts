import { createSelector } from '@ngrx/store';
import { AppState, HeroState } from '../app.state';

export const selectHeroState = (state: AppState) => state.heroes;

export const selectAllHeroes = createSelector(
  selectHeroState,
  (state: HeroState) => state.heroes,
);
