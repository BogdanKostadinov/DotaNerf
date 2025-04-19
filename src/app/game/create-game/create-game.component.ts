import { Component } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { CreateGameDTO } from '../../models/game.model';
import { GameService } from '../../services/game.service';
import { HeroService } from '../../services/hero.service';
import { PlayerService } from '../../services/player.service';
import { SelectItem } from '../../shared/select-with-search/select-with-search.component';
import { CreateGameConfirmationWindowComponent } from '../create-game-confirmation-window/create-game-confirmation-window.component';

@Component({
  selector: 'app-create-game',
  templateUrl: './create-game.component.html',
  styleUrl: './create-game.component.scss',
})
export class CreateGameComponent {
  gameForm!: FormGroup;
  maxPlayers = 5;
  playerItems: SelectItem[] = [];
  heroItems: SelectItem[] = [];
  winningTeamCtrl = new FormControl(null, Validators.required);
  formSubmitted = false;

  constructor(
    private fb: FormBuilder,
    private playerService: PlayerService,
    private heroService: HeroService,
    private gameService: GameService,
    private dialog: MatDialog,
  ) {
    // this.playerService.getPlayers$().subscribe((players) => {
    //   this.playerItems = players.map((player) => ({
    //     id: player.id,
    //     label: player.name,
    //   }));
    // });
    this.heroService.getHeroes$().subscribe((heroes) => {
      this.heroItems = heroes.map((hero) => ({
        id: hero.id,
        label: hero.name,
      }));
    });
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.gameForm = this.fb.group({
      winningTeam: this.winningTeamCtrl,
      radiantTeam: this.fb.group({
        name: [0, Validators.required],
        players: this.fb.array([]),
      }),
      direTeam: this.fb.group({
        name: [1, Validators.required],
        players: this.fb.array([]),
      }),
    });
  }

  // Get players FormArray
  get radiantPlayers(): FormArray {
    return this.gameForm.get('radiantTeam.players') as FormArray;
  }

  get direPlayers(): FormArray {
    return this.gameForm.get('direTeam.players') as FormArray;
  }

  // Create player form group
  createPlayerFormGroup(): FormGroup {
    return this.fb.group({
      id: [null, Validators.required],
      playerStats: this.fb.group({
        heroPlayedId: [null, Validators.required],
        kills: [0, [Validators.required, Validators.min(0)]],
        deaths: [0, [Validators.required, Validators.min(0)]],
        assists: [0, [Validators.required, Validators.min(0)]],
      }),
    });
  }

  // Add player to team
  addPlayer(team: 'radiant' | 'dire'): void {
    const players = team === 'radiant' ? this.radiantPlayers : this.direPlayers;

    if (players.length < this.maxPlayers) {
      players.push(this.createPlayerFormGroup());
    }
  }

  // Remove player from team
  removePlayer(team: 'radiant' | 'dire', index: number): void {
    const players = team === 'radiant' ? this.radiantPlayers : this.direPlayers;
    players.removeAt(index);
  }

  // Check if team has reached max players
  isTeamFull(team: 'radiant' | 'dire'): boolean {
    const players = team === 'radiant' ? this.radiantPlayers : this.direPlayers;
    return players.length >= this.maxPlayers;
  }

  onSubmit(): void {
    this.formSubmitted = true;
    if (this.gameForm.valid) {
      this.openConfirmationDialog();
    } else {
      this.markFormGroupTouched(this.gameForm);
    }
  }

  // Helper to get player ID control
  getPlayerControl(team: 'radiant' | 'dire', index: number): FormControl {
    const players = team === 'radiant' ? this.radiantPlayers : this.direPlayers;
    return players.at(index).get('id') as FormControl;
  }

  // Helper to get hero ID control
  getHeroControl(team: 'radiant' | 'dire', index: number): FormControl {
    const players = team === 'radiant' ? this.radiantPlayers : this.direPlayers;
    return players.at(index).get('playerStats.heroPlayedId') as FormControl;
  }

  // Helper method to mark all controls as touched
  markFormGroupTouched(formGroup: FormGroup): void {
    Object.values(formGroup.controls).forEach((control) => {
      control.markAsTouched();

      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      } else if (control instanceof FormArray) {
        control.controls.forEach((c) => {
          if (c instanceof FormGroup) {
            this.markFormGroupTouched(c);
          }
        });
      }
    });
  }

  openConfirmationDialog(): void {
    const radiantTeamInfo = this.radiantPlayers.controls.map((control) => {
      const playerId = control.get('id')?.value;
      const heroId = control.get('playerStats.heroPlayedId')?.value;
      return {
        playerName:
          this.playerItems.find((player) => player.id === playerId)?.label ||
          '',
        heroName:
          this.heroItems.find((hero) => hero.id === heroId)?.label || '',
      };
    });

    const direTeamInfo = this.direPlayers.controls.map((control) => {
      const playerId = control.get('id')?.value;
      const heroId = control.get('playerStats.heroPlayedId')?.value;
      return {
        playerName:
          this.playerItems.find((player) => player.id === playerId)?.label ||
          '',
        heroName:
          this.heroItems.find((hero) => hero.id === heroId)?.label || '',
      };
    });

    const dialogRef = this.dialog.open(CreateGameConfirmationWindowComponent, {
      width: '800px',
      data: {
        title: 'Create Game',
        message: 'Are you sure you want to create this game?',
        radiantTeam: radiantTeamInfo,
        direTeam: direTeamInfo,
        winningTeam: this.winningTeamCtrl.value,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        const gameDTO: CreateGameDTO = {
          ...this.gameForm.value,
          winningTeam: Number(this.winningTeamCtrl.value),
        };
        this.gameService.createGame$(gameDTO).subscribe({
          next: () => {
            this.formSubmitted = false;
            this.winningTeamCtrl.reset();
            this.radiantPlayers.clear();
            this.direPlayers.clear();
            this.gameForm.reset();
            this.initForm();
          },
          error: (error) => {
            console.error(error);
          },
        });
      }
    });
  }
}
