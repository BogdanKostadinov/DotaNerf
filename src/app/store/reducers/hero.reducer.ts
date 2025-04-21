import { Action, createReducer, on } from '@ngrx/store';
import * as Actions from '../actions/hero.actions';
import { HeroState } from '../app.state';

export const initialHeroState: HeroState = {
  heroes: [],
};

const _heroReducer = createReducer(
  initialHeroState,
  on(Actions.loadHeroesSuccess, (state, { heroes }) => ({
    ...state,
    heroes: heroes,
  })),
  on(Actions.loadHeroesFailure, (state, { error }) => ({
    ...state,
    error: error,
  })),
);

export function heroesReducer(
  state: HeroState | undefined,
  action: Action,
): HeroState {
  return _heroReducer(state, action);
}
