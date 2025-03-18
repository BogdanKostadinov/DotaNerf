import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PlayerEditComponent } from '../player-edit/player-edit.component';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.scss',
})
export class ToolbarComponent {
  constructor(private dialog: MatDialog) {}

  openAddPlayerDialog(): void {
    const dialogRef = this.dialog.open(PlayerEditComponent, {
      width: '400px',
      data: { action: 'add' },
    });
    dialogRef.afterClosed().subscribe();
  }
}
