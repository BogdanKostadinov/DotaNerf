import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateGameFromTableComponent } from './game/create-game-from-table/create-game-from-table.component';
import { GameDisplayComponent } from './game/game-display/game-display.component';
import { GameEditComponent } from './game/game-edit/game-edit.component';
import { PlayerGamesComponent } from './player/player-games/player-games.component';
import { PlayersComponent } from './player/player-stats-table/player-stats-table.component';
import { LoginPageComponent } from './shared/login-page/login-page.component';

const routes: Routes = [
  // { path: 'create-game', component: CreateGameComponent },
  // { path: 'image-upload', component: ImageUploadComponent },
  { path: 'players', component: PlayersComponent },
  { path: 'players/:id', component: PlayerGamesComponent },
  { path: 'games', component: GameDisplayComponent },
  {
    path: 'games/:id',
    component: GameEditComponent,
  },
  { path: 'game', component: CreateGameFromTableComponent },
  { path: 'login', component: LoginPageComponent },
  { path: '**', redirectTo: 'players', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
