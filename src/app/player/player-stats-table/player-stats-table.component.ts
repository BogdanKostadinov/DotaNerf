import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Player, PlayerGroup } from '../../models/player.model';
import { SelectItem } from '../../shared/select-with-search/select-with-search.component';
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
  playerGroupItems: SelectItem[] = [];

  searchText: string = '';
  selectedPlayerGroups: number[] = [];

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
        const uniqueGroups = Array.from(
          new Set(players.map((player) => player.playerDetails.playerGroup)),
        );
        this.playerGroupItems = uniqueGroups.map((group) => ({
          id: group,
          label: PlayerGroup[group],
        }));

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

  searchFilter(event: Event) {
    this.searchText = (event.target as HTMLInputElement).value
      .trim()
      .toLowerCase();
    this.applyCombinedFilter();
  }

  navigateToPlayerGames(playerId: string): void {
    this.router.navigate([`${this.router.url}/${playerId}`], {
      relativeTo: this.activatedRoute,
    });
  }

  onPlayerGroupChipsSelected(selected: SelectItem[]) {
    this.selectedPlayerGroups = selected
      .map((item) => item.id)
      .filter((id): id is number => typeof id === 'number');
    this.applyCombinedFilter();
  }

  applyCombinedFilter() {
    this.dataSource.filterPredicate = (player: Player, filter: string) => {
      // Filter by player group
      const groupMatch =
        this.selectedPlayerGroups.length === 0 ||
        this.selectedPlayerGroups.includes(player.playerDetails.playerGroup);

      // Filter by search text (name)
      const searchMatch =
        !this.searchText || player.name.toLowerCase().includes(this.searchText);

      return groupMatch && searchMatch;
    };

    // Trigger filter (value can be anything, just to re-run the predicate)
    this.dataSource.filter = Math.random().toString();
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
