import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

type SnackbarType = 'success' | 'error' | 'warning' | 'info';

@Injectable({
  providedIn: 'root',
})
export class SnackbarService {
  constructor(private snackBar: MatSnackBar) {}

  show(
    message: string,
    type: SnackbarType = 'info',
    duration: number = 3000,
  ): void {
    const panelClass = this.getPanelClassByType(type);

    this.snackBar.open(message, 'Close', {
      duration: duration,
      panelClass: panelClass,
      horizontalPosition: 'center',
      verticalPosition: 'bottom',
    });
  }

  success(message: string, duration: number = 3000): void {
    this.show(message, 'success', duration);
  }
  error(message: string, duration: number = 3000): void {
    this.show(message, 'error', duration);
  }
  warning(message: string, duration: number = 3000): void {
    this.show(message, 'warning', duration);
  }
  info(message: string, duration: number = 3000): void {
    this.show(message, 'info', duration);
  }

  private getPanelClassByType(type: SnackbarType): string[] {
    switch (type) {
      case 'success':
        return ['snackbar-success'];
      case 'error':
        return ['snackbar-error'];
      case 'warning':
        return ['snackbar-warning'];
      case 'info':
      default:
        return ['snackbar-info'];
    }
  }
}
