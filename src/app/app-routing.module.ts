import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TableComponent } from './table/table.component';
import { CreateGameComponent } from './create-game/create-game.component';
import { GameDisplayComponent } from './game-display/game-display.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';

const routes: Routes = [
  { path: 'table', component: TableComponent },
  { path: 'create-game', component: CreateGameComponent },
  { path: 'games', component: GameDisplayComponent },
  { path: 'image-upload', component: ImageUploadComponent },
  { path: '**', redirectTo: 'table', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
