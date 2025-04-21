import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { GameDetails } from '../../models/game.model';

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
  columnsToDisplay = ['dateCreated', 'edit'];
  columnsToDisplayWithExpand = [...this.columnsToDisplay, 'expand'];
  expandedElement!: GameDetails | null;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private router: Router) {}

  ngOnInit(): void {
    setTimeout(() => {
      this.dataSource.data = this.games;
      this.dataSource.paginator = this.paginator;
    });
  }
  isNaN(value: any): boolean {
    return Number.isNaN(value);
  }
  navigateToGame(gameId: string) {
    this.router.navigate([`games/${gameId}`]);
  }
}
