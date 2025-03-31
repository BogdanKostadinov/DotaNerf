import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { CreateGameConfirmationWindowComponent } from '../create-game/create-game-confirmation-window/create-game-confirmation-window.component';
import { TeamName } from '../models/game.model';
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
  displayedColumns: string[] = [
    'id',
    'name',
    'played',
    'playerWon',
    'heroPlayed',
  ];
  dataSource = new MatTableDataSource<Player>([]);
  heroItems: SelectItem[] = [];
  playerItems: SelectItem[] = [];
  heroCtrl = new FormControl<number | null>(null);
  playerHasPlayedCtrls: FormControl[] = [];
  playerHeroSelectionCtrls: FormControl[] = [];
  playerWonCtrls: FormControl[] = [];
  playersLoaded = false;

  constructor(
    private playerService: PlayerService,
    private heroService: HeroService,
    private gameService: GameService,
    private dialog: MatDialog,
  ) {}

  ngOnInit(): void {
    this.playerService.getPlayers$().subscribe((players: Player[]) => {
      // Initialize form controls array first - IMPORTANT
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

  onHeroSelected(hero: any, element: any) {
    element.selectedHero = hero;
    // Add any additional logic you need when a hero is selected
  }

  isPlayed(index: number): boolean {
    const control = this.getPlayedControl(index);
    return control.value === true;
  }

  canCreateGame(): boolean {
    // Check if at least one player in each team is played and has a hero selected
    const radiantPlayers = this.getTeamPlayers(true);
    const direPlayers = this.getTeamPlayers(false);

    return radiantPlayers.length > 0 && direPlayers.length > 0;
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

    const gamePayload = {
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

    console.log('Game Payload:', gamePayload);
    // this.gameService.createGame$(gamePayload).subscribe();
  }

  openConfirmationDialog(): void {
    const radiantPlayers = this.getTeamPlayers(true);
    const direPlayers = this.getTeamPlayers(false);

    console.log('Radiant Players:', radiantPlayers);
    console.log('Dire Players:', direPlayers);

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
}
