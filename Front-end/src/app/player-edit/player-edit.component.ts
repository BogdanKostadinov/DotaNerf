import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { GameStats, Player } from '../models/player.model';

@Component({
  selector: 'app-player-edit',
  templateUrl: './player-edit.component.html',
  styleUrl: './player-edit.component.scss',
})
export class PlayerEditComponent implements OnInit {
  title = '';
  form!: FormGroup;
  heroSelectCtrl = new FormControl<string>('', Validators.required);

  constructor(
    public dialogRef: MatDialogRef<PlayerEditComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { action: 'addStats' | 'editStats'; player?: Player },
    public fb: FormBuilder,
  ) {}
  ngOnInit(): void {
    this.title =
      this.data.action === 'editStats'
        ? 'Edit stats for: ' + this.data.player?.name
        : 'Add stats for: ' + this.data.player?.name;

    this.initializeForm();
  }

  initializeForm(): void {
    this.form = this.fb.group({
      heroPlayed: this.heroSelectCtrl,
      xpm: [''],
      gpm: [''],
      lastHits: [''],
      kills: [''],
      deaths: [''],
      assists: [''],
      gameDuration: [''],
      gameResult: [null, Validators.required],
    });
  }

  onKeyPress(event: KeyboardEvent): void {
    const charCode = event.key;
    if (!/^\d$/.test(charCode)) {
      event.preventDefault();
    }
  }

  onSave(): void {
    const gameStats: GameStats = this.form.value;
    console.log('Game Result:', gameStats);
    this.dialogRef.close(this.data);
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
