import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { GameDetails } from '../../../models/game.model';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.scss',
})
export class ChartComponent implements OnChanges {
  @Input() data: GameDetails[] = [];
  @Input() playerId: string = '';

  options: any;
  processedData: any[] = [];

  constructor() {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['data'] || changes['playerId']) {
      this.processData();
      this.initializeChart();
    }
  }

  processData() {
    if (!this.data || !this.playerId) return;

    this.processedData = [];

    let cumulativeWins = 0;
    let cumulativeLosses = 0;

    this.data.forEach((game) => {
      const radiantPlayer = game.radiantTeam.players.find(
        (p) => p.id === this.playerId,
      );

      radiantPlayer ? cumulativeWins++ : cumulativeLosses++;

      this.processedData = [
        {
          category: 'Wins',
          value: cumulativeWins,
        },
        {
          category: 'Losses',
          value: cumulativeLosses,
        },
      ];
    });
  }
  initializeChart() {
    this.options = {
      title: {
        text: 'Player Statistics',
      },
      data: this.processedData,
      series: [
        {
          type: 'bar',
          xKey: 'category',
          yKey: 'value',
        },
      ],
      axes: [
        {
          type: 'category',
          position: 'bottom',
          title: {
            text: '',
          },
        },
        {
          type: 'number',
          position: 'left',
          title: {
            text: 'Number of Games',
          },
          min: 0,
        },
      ],
      legend: {
        enabled: false,
      },
    };
  }
}
