import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PlayerElement } from '../table/table.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-player-edit',
  templateUrl: './player-edit.component.html',
  styleUrl: './player-edit.component.scss',
})
export class PlayerEditComponent implements OnInit {
  title = '';
  form!: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<PlayerEditComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { action: 'add' | 'edit'; player?: PlayerElement },
    public fb: FormBuilder,
  ) {}
  ngOnInit(): void {
    this.title = this.data.action === 'edit' ? 'Edit player' : 'Add player';
    this.initializeForm();
  }

  initializeForm(): void {
    this.form = this.fb.group({
      name: [
        this.data.player?.name || '',
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(50),
        ],
      ],
      winrate: [
        this.data.player?.winrate || '',
        [Validators.required, Validators.min(0), Validators.max(100)],
      ],
      games: [
        this.data.player?.totalGames || '',
        [Validators.required, Validators.min(0)],
      ],
    });
  }

  onKeyPress(event: KeyboardEvent): void {
    const charCode = event.key;
    if (!/^\d$/.test(charCode)) {
      event.preventDefault();
    }
  }

  onSave(): void {
    this.dialogRef.close(this.data);
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
