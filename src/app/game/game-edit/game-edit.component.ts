import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { filter, Observable, Subject, take, takeUntil, tap } from 'rxjs';
import { GameDetails } from '../../models/game.model';
import { SelectItem } from '../../shared/select-with-search/select-with-search.component';
import { loadGame } from '../../store/actions/game.actions';
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
          console.log('game', game);
          // If game doesn't exist in state, dispatch load action
          if (!game) {
            this.store.dispatch(loadGame({ gameId: this.gameId || '' }));
          } else {
            this.initializeHeroControls(game);
          }
        }),
      )
      .subscribe();

    this.game$ = this.store.select(selectGameById(this.gameId)).pipe(
      filter((game) => !!game),
      tap((game) => {
        if (game) {
          this.initializeHeroControls(game);
        }
      }),
    );
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
  updateGame(): void {}
  goBack(): void {
    this.router.navigate(['/games']);
  }
}
