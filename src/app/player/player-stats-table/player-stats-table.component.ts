import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Player } from '../../models/player.model';
import * as PlayerActions from '../../store/actions/player.actions';
import { AppState } from '../../store/app.state';
import {
  selectAllPlayers,
  selectPlayersLoading,
} from '../../store/selectors/player.selectors';

@Component({
  selector: 'app-player-stats-table',
  templateUrl: './player-stats-table.component.html',
  styleUrl: './player-stats-table.component.scss',
})
export class PlayersComponent implements OnInit {
  players$: Observable<Player[]>;
  loading$: Observable<boolean>;
  displayedColumns: string[] = ['id', 'name', 'winrate', 'totalGames', 'score'];
  dataSource = new MatTableDataSource<Player>([]);
  clickedRows = new Set<Player>();

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private store: Store<AppState>,
  ) {
    this.players$ = this.store.select(selectAllPlayers);
    this.loading$ = this.store.select(selectPlayersLoading);
  }

  ngOnInit(): void {
    this.store.dispatch(PlayerActions.loadPlayers());
    this.loadPlayerData();
  }

  loadPlayerData(): void {
    this.players$.subscribe({
      next: (players: Player[]) => {
        this.dataSource.data = [...players].sort(
          (a, b) => b.playerDetails.totalGames - a.playerDetails.totalGames,
        );

        // Try to set up again after data is loaded
        setTimeout(() => {
          this.setupSortAndPagination();
        });
      },
      error: (error) => {
        console.error('Error loading player data:', error);
      },
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  navigateToPlayerGames(playerId: string): void {
    this.router.navigate([`${this.router.url}/${playerId}`], {
      relativeTo: this.activatedRoute,
    });
  }

  private setupSortAndPagination(): void {
    if (this.sort && this.paginator) {
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

      // Custom sorting logic for nested properties
      this.dataSource.sortingDataAccessor = (
        item: Player,
        property: string,
      ) => {
        switch (property) {
          case 'winrate':
            return item.playerDetails.winrate;
          case 'totalGames':
            return item.playerDetails.totalGames;
          default:
            return (item as any)[property];
        }
      };
    }
  }
}
