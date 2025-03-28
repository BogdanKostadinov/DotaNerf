import { Component, Inject } from '@angular/core';
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
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private dialogRef: MatDialogRef<CreateGameConfirmationWindowComponent>,
  ) {}

  onSaveClick(): void {
    this.dialogRef.close(true);
  }

  onCancelClick(): void {
    this.dialogRef.close(false);
  }
}
