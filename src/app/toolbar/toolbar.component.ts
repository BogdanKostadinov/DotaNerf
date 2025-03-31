import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.scss',
})
export class ToolbarComponent {
  constructor(private router: Router) {}

  navigateToCreateGame(): void {
    this.router.navigate(['/create-game']);
  }
  navigateToPlayerStats(): void {
    this.router.navigate(['/table']);
  }
  navigateToRecentGames(): void {
    this.router.navigate(['/games']);
  }
  navigateToImageUpload(): void {
    this.router.navigate(['/image-upload']);
  }
  navigateToCreateGameFromTable(): void {
    this.router.navigate(['/game']);
  }
}
