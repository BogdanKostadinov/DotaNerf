import { ActionReducer, INIT, UPDATE } from '@ngrx/store';
import { AppState } from '../app.state';

export function hydrationMetaReducer(
  reducer: ActionReducer<AppState>,
): ActionReducer<AppState> {
  return (state, action) => {
    // When the app initializes or updates
    if (action.type === INIT || action.type === UPDATE) {
      // Try to load state from localStorage
      const persistedState = localStorage.getItem('appState');

      if (persistedState) {
        try {
          // If we have persisted state, parse and return it
          return JSON.parse(persistedState);
        } catch (e) {
          localStorage.removeItem('appState');
        }
      }
    }

    // Get next state from reducers
    const nextState = reducer(state, action);

    // Save state to localStorage
    localStorage.setItem('appState', JSON.stringify(nextState));

    return nextState;
  };
}
