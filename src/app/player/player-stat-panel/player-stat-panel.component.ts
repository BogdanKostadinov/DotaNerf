import { Component, Input } from '@angular/core';
import { PlayerGameEntry } from '../../models/player.model';

@Component({
  selector: 'app-player-stat-panel',
  templateUrl: './player-stat-panel.component.html',
  styleUrl: './player-stat-panel.component.scss',
})
export class PlayerStatPanelComponent {
  @Input() player!: PlayerGameEntry;
}
