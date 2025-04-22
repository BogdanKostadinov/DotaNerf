import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { filter, Observable, Subject, take, takeUntil, tap } from 'rxjs';
import { GameDetails, UpdateGameDTO } from '../../models/game.model';
import { SelectItem } from '../../shared/select-with-search/select-with-search.component';
import { SnackbarService } from '../../shared/snackbar/snackbar.service';
import * as GameActions from '../../store/actions/game.actions';
import { loadGame, updateGame } from '../../store/actions/game.actions';
import { loadHeroes } from '../../store/actions/hero.actions';
import { AppState } from '../../store/app.state';
import {
  selectGameById,
  selectGamesLoading,
} from '../../store/selectors/game.selectors';
import { selectAllHeroes } from '../../store/selectors/hero.selectors';

@Component({
  selector: 'app-game-edit',
  templateUrl: './game-edit.component.html',
  styleUrl: './game-edit.component.scss',
})
export class GameEditComponent implements OnInit, OnDestroy {
  game$!: Observable<GameDetails | undefined>;
  loading$!: Observable<boolean>;
  gameId: string | null = '';

  heroControls: Map<string | number, FormControl> = new Map();
  heroItems: SelectItem[] = [];

  destroy$ = new Subject<void>();

  constructor(
    private store: Store<AppState>,
    private router: Router,
    private route: ActivatedRoute,
    private actions$: Actions,
    private snackbar: SnackbarService,
  ) {}

  ngOnInit(): void {
    this.loadHeroes();
    this.loadGame();
  }
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  initializeHeroControls(game: GameDetails): void {
    this.heroControls.clear();
    game.radiantTeam.players.forEach((player) => {
      const heroId = player.playerStats[0]?.heroPlayed?.id || null;
      this.heroControls.set(player.id, new FormControl(heroId));
    });
    game.direTeam.players.forEach((player) => {
      const heroId = player.playerStats[0]?.heroPlayed?.id || null;
      this.heroControls.set(player.id, new FormControl(heroId));
    });
  }
  getHeroControl(playerId: string | number): FormControl {
    if (!this.heroControls.has(playerId)) {
      this.heroControls.set(playerId, new FormControl(null));
    }
    return this.heroControls.get(playerId)!;
  }
  loadGame(): void {
    this.loading$ = this.store.select(selectGamesLoading);
    this.gameId = this.route.snapshot.paramMap.get('id') || '';

    if (!this.gameId) {
      this.router.navigate(['/games']);
      return;
    }

    this.store
      .select(selectGameById(this.gameId))
      .pipe(
        take(1),
        tap((game) => {
          // If game doesn't exist in state, dispatch load action
          if (!game) {
            this.store.dispatch(loadGame({ gameId: this.gameId || '' }));
          } else {
            this.initializeHeroControls(game);
          }
        }),
      )
      .subscribe();

    this.game$ = this.store
      .select(selectGameById(this.gameId))
      .pipe(filter((game) => !!game));
  }
  loadHeroes(): void {
    this.store.dispatch(loadHeroes());
    this.store
      .select(selectAllHeroes)
      .pipe(takeUntil(this.destroy$))
      .subscribe((heroes) => {
        this.heroItems = heroes.map((hero) => ({
          id: hero.id,
          label: hero.name,
        }));
      });
  }
  updateGame(): void {
    this.game$.pipe(take(1)).subscribe((game) => {
      if (!game) {
        return;
      }
      const updateGameDTO: UpdateGameDTO = {
        id: game.id,
        radiantTeam: {
          players: game.radiantTeam.players.map((player) => ({
            id: player.id,
            playerStats: {
              heroPlayedId: this.getHeroControl(player.id).value,
            },
          })),
        },
        direTeam: {
          players: game.direTeam.players.map((player) => ({
            id: player.id,
            playerStats: {
              heroPlayedId: this.getHeroControl(player.id).value,
            },
          })),
        },
      };
      this.store.dispatch(updateGame({ game: updateGameDTO }));
      this.actions$
        .pipe(
          ofType(GameActions.updateGameSuccess, GameActions.updateGameFailure),
          takeUntil(this.destroy$),
        )
        .subscribe((action) => {
          if (action.type === GameActions.updateGameSuccess.type) {
            this.snackbar.success('Game successfully updated!');
          } else {
            this.snackbar.error('Failed to update game. Please try again.');
          }
        });
    });
  }
  goBack(): void {
    this.router.navigate(['/games']);
  }
}
