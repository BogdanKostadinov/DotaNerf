import { Component, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

interface DialogData {
  title: string;
  message: string;
  radiantTeam: any[];
  direTeam: any[];
  winningTeam: string;
}

@Component({
  selector: 'app-create-game-confirmation-window',
  templateUrl: './create-game-confirmation-window.component.html',
  styleUrl: './create-game-confirmation-window.component.scss',
})
export class CreateGameConfirmationWindowComponent {
  timeControl = new FormControl('', [
    Validators.required,
    Validators.pattern('^([01]?[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$'),
  ]);

  timePattern = '^([01]?[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$';

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private dialogRef: MatDialogRef<CreateGameConfirmationWindowComponent>,
  ) {}

  onSaveClick(): void {
    this.dialogRef.close({ gameDuration: this.timeControl.value });
  }

  onCancelClick(): void {
    this.dialogRef.close(false);
  }
}
