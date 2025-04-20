import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { GameDetails } from '../../models/game.model';
import { HeroService } from '../../services/hero.service';
import { SelectItem } from '../../shared/select-with-search/select-with-search.component';
import { loadGame } from '../../store/actions/game.actions';
import { AppState } from '../../store/app.state';
import { selectGameById } from '../../store/selectors/game.selectors';

@Component({
  selector: 'app-game-edit',
  templateUrl: './game-edit.component.html',
  styleUrl: './game-edit.component.scss',
})
export class GameEditComponent implements OnInit {
  game$: Observable<GameDetails | undefined>;
  gameId: string | null = '';
  loadingDataLabel: string = 'Loading game...';
  isLoading = true;
  heroControls: Map<string | number, FormControl> = new Map();
  heroItems: SelectItem[] = [];

  constructor(
    private store: Store<AppState>,
    private router: Router,
    private route: ActivatedRoute,
    private heroService: HeroService,
  ) {
    this.gameId = this.route.snapshot.paramMap.get('id');
    this.store.dispatch(loadGame({ gameId: this.gameId || '' }));
    this.game$ = this.store.select(selectGameById(this.gameId || ''));
    this.heroService.getHeroes$().subscribe((heroes) => {
      this.heroItems = heroes.map((hero) => ({
        id: hero.id,
        label: hero.name,
      }));
    });
  }
  ngOnInit(): void {
    this.game$.subscribe((game) => {
      if (game) {
        this.isLoading = false;
        this.initializeHeroControls(game);
      }
    });
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

  updateGame(): void {}

  goBack(): void {
    this.router.navigate(['/games']);
  }
}
