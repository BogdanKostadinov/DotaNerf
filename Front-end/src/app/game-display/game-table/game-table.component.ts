import { Component, Input, OnInit } from '@angular/core';
import { GameDetails } from '../../models/game.model';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-game-table',
  templateUrl: './game-table.component.html',
  styleUrl: './game-table.component.scss',
  animations: [
    trigger('detailExpand', [
      state('collapsed,void', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition(
        'expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)'),
      ),
    ]),
  ],
})
export class GameTableComponent implements OnInit {
  @Input() games: GameDetails[] = [];
  dataSource = new MatTableDataSource<GameDetails>([]);
  columnsToDisplay = ['Radiant team', 'Dire team', 'Winner'];
  columnsToDisplayWithExpand = [...this.columnsToDisplay, 'expand'];
  expandedElement!: GameDetails | null;

  ngOnInit(): void {
    this.dataSource.data = this.games;
  }

  isNaN(value: any): boolean {
    return Number.isNaN(value);
  }
}
