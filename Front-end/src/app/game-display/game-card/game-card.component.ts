import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { Game, GameDetails } from '../../models/game.model';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrl: './game-card.component.scss',
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
export class GameCardComponent implements OnInit {
  @Input() games: GameDetails[] = [];
  dataSource = new MatTableDataSource<GameDetails>([]);
  columnsToDisplay = ['colNum', 'winner'];
  columnsToDisplayWithExpand = [...this.columnsToDisplay, 'expand'];
  expandedElement!: GameDetails | null;

  // TODO display players to each game on expand
  // Display winning team on top
  ngOnInit(): void {
    this.dataSource.data = this.games;
  }
}
