import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { PlayerEditComponent } from '../player-edit/player-edit.component';
import { Player } from '../models/player.model';
import { PlayerService } from '../services/player.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss',
})
export class TableComponent implements AfterViewInit {
  displayedColumns: string[] = [
    'id',
    'name',
    'winrate',
    'totalGames',
    'score',
    'edit',
  ];
  dataSource = new MatTableDataSource<Player>([]);
  clickedRows = new Set<Player>();
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private playerService: PlayerService,
    private dialog: MatDialog,
  ) {
    this.playerService.getPlayers$().subscribe((players: Player[]) => {
      this.dataSource.data = players;
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.dataSource.filterPredicate = (data: Player, filter: string) => {
      return data.name.toLowerCase().includes(filter);
    };
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  editPlayerStats() {
    console.log('editPlayerStats');
  }
}
