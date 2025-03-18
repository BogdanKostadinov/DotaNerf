import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { PlayerEditComponent } from '../player-edit/player-edit.component';

export interface PlayerElement {
  id: number;
  name: string;
  winrate: number;
  totalGames: number;
  gamesWon: number;
  gamesLost: number;
}
const ELEMENT_DATA: PlayerElement[] = [
  {
    id: 0,
    name: 'dummy',
    winrate: 67,
    totalGames: 9,
    gamesWon: 6,
    gamesLost: 3,
  },
  {
    id: 1,
    name: 'Stoqn (kolega)',
    winrate: 67,
    totalGames: 9,
    gamesWon: 6,
    gamesLost: 3,
  },
  {
    id: 2,
    name: 'Veni',
    winrate: 63,
    totalGames: 19,
    gamesWon: 12,
    gamesLost: 7,
  },
  {
    id: 3,
    name: 'Kriskata',
    winrate: 60,
    totalGames: 15,
    gamesWon: 9,
    gamesLost: 6,
  },
  {
    id: 4,
    name: 'Marto',
    winrate: 59,
    totalGames: 17,
    gamesWon: 10,
    gamesLost: 7,
  },
  {
    id: 5,
    name: 'Steli',
    winrate: 50,
    totalGames: 14,
    gamesWon: 7,
    gamesLost: 7,
  },
  {
    id: 6,
    name: 'Rumen',
    winrate: 52,
    totalGames: 19,
    gamesWon: 10,
    gamesLost: 9,
  },
  {
    id: 7,
    name: 'Bobur Kurva',
    winrate: 40,
    totalGames: 15,
    gamesWon: 6,
    gamesLost: 9,
  },
  {
    id: 8,
    name: 'Dj Misho',
    winrate: 38,
    totalGames: 16,
    gamesWon: 6,
    gamesLost: 10,
  },
  {
    id: 9,
    name: 'Kuncho',
    winrate: 37,
    totalGames: 19,
    gamesWon: 7,
    gamesLost: 12,
  },
  {
    id: 10,
    name: 'Sofiqnece',
    winrate: 20,
    totalGames: 5,
    gamesWon: 1,
    gamesLost: 4,
  },
  {
    id: 11,
    name: 'Vaneto',
    winrate: 25,
    totalGames: 8,
    gamesWon: 2,
    gamesLost: 6,
  },
  {
    id: 12,
    name: 'Mario',
    winrate: 0,
    totalGames: 6,
    gamesWon: 0,
    gamesLost: 6,
  },
];

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss',
})
export class TableComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'id',
    'name',
    'winrate',
    'totalGames',
    'score',
    'edit',
  ];
  dataSource = new MatTableDataSource(ELEMENT_DATA);
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private dialog: MatDialog) {}
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.dataSource.filterPredicate = (data: PlayerElement, filter: string) => {
      return data.name.toLowerCase().includes(filter);
    };
  }

  ngOnInit(): void {}

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  onEdit(player: PlayerElement): void {
    const dialogRef = this.dialog.open(PlayerEditComponent, {
      width: '400px',
      data: { action: 'edit', player },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        console.log('Dialog result:', result);
      }
    });
  }
}
