import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { combineLatest, startWith, switchMap } from 'rxjs';
import { CreateGameConfirmationWindowComponent } from '../create-game/create-game-confirmation-window/create-game-confirmation-window.component';
import { CreateGameDTO, TeamName } from '../models/game.model';
import { Hero } from '../models/hero.model';
import { Player } from '../models/player.model';
import { GameService } from '../services/game.service';
import { HeroService } from '../services/hero.service';
import { PlayerService } from '../services/player.service';
import { SelectItem } from '../shared/select-with-search/select-with-search.component';

@Component({
  selector: 'app-create-game-from-table',
  templateUrl: './create-game-from-table.component.html',
  styleUrl: './create-game-from-table.component.scss',
})
export class CreateGameFromTableComponent implements OnInit {
  basicColumns: string[] = ['id', 'name', 'played'];
  allColumns: string[] = ['id', 'name', 'played', 'playerWon', 'heroPlayed'];

  displayedColumns: string[] = this.basicColumns;
  dataSource = new MatTableDataSource<Player>([]);
  heroItems: SelectItem[] = [];
  playerItems: SelectItem[] = [];
  heroCtrl = new FormControl<number | null>(null);
  playerHasPlayedCtrls: FormControl[] = [];
  playerHeroSelectionCtrls: FormControl[] = [];
  playerWonCtrls: FormControl[] = [];
  playersLoaded = false;
  errorMessage: string | null = null;

  constructor(
    private playerService: PlayerService,
    private heroService: HeroService,
    private gameService: GameService,
    private dialog: MatDialog,
  ) {}

  ngOnInit(): void {
    this.playerService.getPlayers$().subscribe((players: Player[]) => {
      this.playerHasPlayedCtrls = players.map(
        () => new FormControl<boolean>(false),
      );
      this.playerHeroSelectionCtrls = players.map(
        () => new FormControl<number | null>(null),
      );
      this.playerWonCtrls = players.map(() => new FormControl<boolean>(false));

      this.playerItems = players.map((player) => ({
        id: player.id,
        label: player.name,
      }));

      // Then set the data source
      this.dataSource.data = players;
      this.playersLoaded = true;
    });
    this.heroService.getHeroes$().subscribe((heroes: Hero[]) => {
      this.heroItems = heroes.map((h) => ({ id: h.id, label: h.name }));
    });
    this.subscribeToPlayedChanges();
  }

  getPlayedControl(index: number): FormControl {
    // Add a safety check
    if (index >= 0 && index < this.playerHasPlayedCtrls.length) {
      return this.playerHasPlayedCtrls[index];
    }
    // Return a default control if index is out of bounds
    return new FormControl(false);
  }

  getHeroControl(index: number): FormControl {
    // Add a safety check
    if (index >= 0 && index < this.playerHeroSelectionCtrls.length) {
      return this.playerHeroSelectionCtrls[index];
    }
    // Return a default control if index is out of bounds
    return new FormControl<number | null>(null);
  }

  getPlayerWonControl(index: number): FormControl {
    // Add a safety check
    if (index >= 0 && index < this.playerWonCtrls.length) {
      return this.playerWonCtrls[index];
    }
    // Return a default control if index is out of bounds
    return new FormControl<number | null>(null);
  }

  isPlayed(index: number): boolean {
    const control = this.getPlayedControl(index);
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

    this.dataSource.data.forEach((player, index) => {
      if (this.isPlayed(index)) {
        const isWinner = this.getPlayerWonControl(index).value;
        const heroId = this.getHeroControl(index).value;

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

    this.gameService.createGame$(gamePayload).subscribe();
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

  private subscribeToPlayedChanges(): void {
    this.playerService
      .getPlayers$()
      .pipe(
        switchMap(() => {
          const playedObservables = this.playerHasPlayedCtrls.map((control) =>
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
    const anyPlayerPlayed = this.playerHasPlayedCtrls.some(
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

    this.dataSource.data.forEach((player, index) => {
      if (this.isPlayed(index)) {
        const heroId = this.getHeroControl(index).value;
        if (heroId === null) {
          playersWithMissingHeroes.push(player);
        }
      }
    });

    return playersWithMissingHeroes;
  }
}
