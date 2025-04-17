import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateGameFromTableComponent } from './create-game-from-table/create-game-from-table.component';
import { GameDisplayComponent } from './game-display/game-display.component';
import { PlayerGamesComponent } from './player-games/player-games.component';
import { PlayersComponent } from './player-stats-table/player-stats-table.component';

const routes: Routes = [
  // { path: 'create-game', component: CreateGameComponent },
  // { path: 'image-upload', component: ImageUploadComponent },
  { path: 'players', component: PlayersComponent },
  { path: 'players/:id', component: PlayerGamesComponent },
  { path: 'games', component: GameDisplayComponent },
  { path: 'game', component: CreateGameFromTableComponent },
  { path: '**', redirectTo: 'players', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
