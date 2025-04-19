import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Store } from '@ngrx/store';
import { combineLatest, startWith, Subject, switchMap, takeUntil } from 'rxjs';
import { CreateGameDTO, TeamName } from '../../models/game.model';
import { Hero } from '../../models/hero.model';
import { Player, PlayerGroup } from '../../models/player.model';
import { GameService } from '../../services/game.service';
import { HeroService } from '../../services/hero.service';
import { PlayerService } from '../../services/player.service';
import { SelectItem } from '../../shared/select-with-search/select-with-search.component';
import { createGame } from '../../store/actions/game.actions';
import { AppState } from '../../store/app.state';
import { CreateGameConfirmationWindowComponent } from '../create-game-confirmation-window/create-game-confirmation-window.component';

@Component({
  selector: 'app-create-game-from-table',
  templateUrl: './create-game-from-table.component.html',
  styleUrl: './create-game-from-table.component.scss',
})
export class CreateGameFromTableComponent implements OnInit, OnDestroy {
  basicColumns: string[] = ['name', 'played'];
  allColumns: string[] = ['name', 'played', 'playerWon', 'heroPlayed'];

  displayedColumns: string[] = this.basicColumns;
  dataSource = new MatTableDataSource<Player>([]);
  heroItems: SelectItem[] = [];
  playerItems: SelectItem[] = [];
  playerGroupItems: SelectItem[] = [];
  heroCtrl = new FormControl<number | null>(null);
  playerHasPlayedCtrls: Map<string, FormControl> = new Map();
  playerHeroSelectionCtrls: Map<string, FormControl> = new Map();
  playerWonCtrls: Map<string, FormControl> = new Map();
  playersLoaded = false;
  errorMessage: string | null = null;

  searchText: string = '';
  selectedPlayerGroups: number[] = [];
  destroy$ = new Subject<void>();

  constructor(
    private playerService: PlayerService,
    private heroService: HeroService,
    private gameService: GameService,
    private dialog: MatDialog,
    private store: Store<AppState>,
  ) {}

  ngOnInit(): void {
    this.playerService
      .getPlayers$()
      .pipe(takeUntil(this.destroy$))
      .subscribe((players: Player[]) => {
        players.forEach((player) => {
          // Check if controls already exist before creating new ones
          if (!this.playerHasPlayedCtrls.has(player.id)) {
            this.playerHasPlayedCtrls.set(
              player.id,
              new FormControl<boolean>(false),
            );
          }
          if (!this.playerHeroSelectionCtrls.has(player.id)) {
            this.playerHeroSelectionCtrls.set(
              player.id,
              new FormControl<number | null>(null),
            );
          }
          if (!this.playerWonCtrls.has(player.id)) {
            this.playerWonCtrls.set(player.id, new FormControl<boolean>(false));
          }
        });

        this.playerItems = players.map((player) => ({
          id: player.id,
          label: player.name,
        }));

        const uniqueGroups = Array.from(
          new Set(players.map((player) => player.playerDetails.playerGroup)),
        );
        this.playerGroupItems = uniqueGroups.map((group) => ({
          id: group,
          label: PlayerGroup[group],
        }));

        // Then set the data source
        this.dataSource.data = players.sort((a, b) => {
          if (a.playerDetails.playerGroup < b.playerDetails.playerGroup) {
            return -1;
          }
          if (a.playerDetails.playerGroup > b.playerDetails.playerGroup) {
            return 1;
          }
          return 0;
        });
        this.playersLoaded = true;
        this.subscribeToPlayedChanges();
      });
    this.heroService
      .getHeroes$()
      .pipe(takeUntil(this.destroy$))
      .subscribe((heroes: Hero[]) => {
        this.heroItems = heroes.map((h) => ({ id: h.id, label: h.name }));
      });
  }
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
  getPlayedControl(playerId: string): FormControl {
    const control = this.playerHasPlayedCtrls.get(playerId);
    if (!control) {
      this.playerHasPlayedCtrls.set(playerId, new FormControl(false));
      return this.playerHasPlayedCtrls.get(playerId)!;
    }
    return control;
  }

  getHeroControl(playerId: string): FormControl {
    const control = this.playerHeroSelectionCtrls.get(playerId);
    if (!control) {
      this.playerHeroSelectionCtrls.set(
        playerId,
        new FormControl<number | null>(null),
      );
      return this.playerHeroSelectionCtrls.get(playerId)!;
    }
    return control;
  }

  getPlayerWonControl(playerId: string): FormControl {
    const control = this.playerWonCtrls.get(playerId);
    if (!control) {
      this.playerWonCtrls.set(playerId, new FormControl<boolean | null>(null));
      return this.playerWonCtrls.get(playerId)!;
    }
    return control;
  }

  isPlayed(playerId: string): boolean {
    const control = this.getPlayedControl(playerId);
    return control.value === true;
  }

  canCreateGame(): boolean {
    // Reset error message
    this.errorMessage = null;

    // Check for players with missing hero selections
    const playersWithMissingHeroes = this.getPlayersWithMissingHeroes();

    if (playersWithMissingHeroes.length > 0) {
      if (playersWithMissingHeroes.length === 1) {
        this.errorMessage = `Hero selection missing for ${playersWithMissingHeroes[0].name}`;
      } else {
        this.errorMessage = `Hero selection missing for multiple players`;
      }
      return false;
    }

    // Check if at least one player in each team is played and has a hero selected
    const radiantPlayers = this.getTeamPlayers(true);
    const direPlayers = this.getTeamPlayers(false);

    // Check if any team has more than 5 players
    if (radiantPlayers.length > 5) {
      this.errorMessage = 'Too many players in winning team';
      return false;
    }

    if (direPlayers.length > 5) {
      this.errorMessage = 'Too many players in losing team';
      return false;
    }

    // Check if either team has no players
    if (radiantPlayers.length === 0) {
      this.errorMessage = 'No players in winning team';
      return false;
    }

    if (direPlayers.length === 0) {
      this.errorMessage = 'No players in losing team';
      return false;
    }

    return true;
  }

  getTeamPlayers(isWinningTeam: boolean): any[] {
    const players: any[] = [];

    this.dataSource.data.forEach((player) => {
      if (this.isPlayed(player.id)) {
        const isWinner = this.getPlayerWonControl(player.id).value;
        const heroId = this.getHeroControl(player.id).value;

        if (isWinner === isWinningTeam && heroId !== null) {
          players.push({
            id: player.id,
            playerStats: {
              heroPlayedId: Number(heroId),
              kills: 0,
              deaths: 0,
              assists: 0,
            },
          });
        }
      }
    });

    return players;
  }

  createGame(): void {
    const radiantPlayers = this.getTeamPlayers(true);
    const direPlayers = this.getTeamPlayers(false);

    const gamePayload: CreateGameDTO = {
      winningTeam: TeamName.Radiant,
      radiantTeam: {
        name: TeamName.Radiant,
        players: radiantPlayers,
      },
      direTeam: {
        name: TeamName.Dire,
        players: direPlayers,
      },
    };

    this.store.dispatch(createGame({ game: gamePayload }));
    this.resetForm();
  }

  openConfirmationDialog(): void {
    const radiantPlayers = this.getTeamPlayers(true);
    const direPlayers = this.getTeamPlayers(false);

    const radiantTeamInfo = radiantPlayers.map((rPlayer) => {
      return {
        playerName:
          this.playerItems.find((player) => player.id === rPlayer.id)?.label ||
          '',
        heroName:
          this.heroItems.find(
            (hero) => hero.id === rPlayer.playerStats.heroPlayedId,
          )?.label || '',
      };
    });

    const direTeamInfo = direPlayers.map((dPlayer) => {
      return {
        playerName:
          this.playerItems.find((player) => player.id === dPlayer.id)?.label ||
          '',
        heroName:
          this.heroItems.find(
            (hero) => hero.id === dPlayer.playerStats.heroPlayedId,
          )?.label || '',
      };
    });

    const dialogRef = this.dialog.open(CreateGameConfirmationWindowComponent, {
      width: '800px',
      data: {
        title: 'Create Game',
        message: 'Are you sure you want to create this game?',
        radiantTeam: radiantTeamInfo,
        direTeam: direTeamInfo,
        winningTeam: '0',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.createGame();
      }
    });
  }

  searchFilter(event: Event) {
    this.searchText = (event.target as HTMLInputElement).value
      .trim()
      .toLowerCase();
    this.applyCombinedFilter();
  }

  onPlayerGroupChipsSelected(selected: SelectItem[]) {
    this.selectedPlayerGroups = selected
      .map((item) => item.id)
      .filter((id): id is number => typeof id === 'number');
    this.applyCombinedFilter();
  }

  applyCombinedFilter() {
    this.dataSource.filterPredicate = (player: Player, filter: string) => {
      // Filter by player group
      const groupMatch =
        this.selectedPlayerGroups.length === 0 ||
        this.selectedPlayerGroups.includes(player.playerDetails.playerGroup);

      // Filter by search text (name)
      const searchMatch =
        !this.searchText || player.name.toLowerCase().includes(this.searchText);

      return groupMatch && searchMatch;
    };

    // Trigger filter (value can be anything, just to re-run the predicate)
    this.dataSource.filter = Math.random().toString();
  }

  private subscribeToPlayedChanges(): void {
    this.playerService
      .getPlayers$()
      .pipe(
        switchMap(() => {
          const playedObservables = Array.from(
            this.playerHasPlayedCtrls.values(),
          ).map((control) =>
            control.valueChanges.pipe(startWith(control.value)),
          );

          return combineLatest(playedObservables);
        }),
      )
      .subscribe(() => {
        this.updateDisplayedColumns();
      });
  }

  private updateDisplayedColumns(): void {
    const anyPlayerPlayed = Array.from(this.playerHasPlayedCtrls.values()).some(
      (control) => control.value === true,
    );

    this.displayedColumns = anyPlayerPlayed
      ? this.allColumns
      : this.basicColumns;
  }

  /**
   * Returns a list of players who are marked as played but don't have a hero selected
   */
  private getPlayersWithMissingHeroes(): Player[] {
    const playersWithMissingHeroes: Player[] = [];

    this.dataSource.data.forEach((player) => {
      if (this.isPlayed(player.id)) {
        const heroId = this.getHeroControl(player.id).value;
        if (heroId === null) {
          playersWithMissingHeroes.push(player);
        }
      }
    });

    return playersWithMissingHeroes;
  }

  /**
   * Resets all form controls after a game has been successfully created
   */
  private resetForm(): void {
    this.playerHasPlayedCtrls.forEach((control) => control.setValue(false));
    this.playerHeroSelectionCtrls.forEach((control) => control.setValue(null));
    this.playerWonCtrls.forEach((control) => control.setValue(false));
    this.errorMessage = null;
    this.updateDisplayedColumns();
  }
}
