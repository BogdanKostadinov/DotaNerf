import {
  HttpClientModule,
  provideHttpClient,
  withFetch,
} from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateGameConfirmationWindowComponent } from './game/create-game-confirmation-window/create-game-confirmation-window.component';
import { CreateGameFromTableComponent } from './game/create-game-from-table/create-game-from-table.component';
import { CreateGameComponent } from './game/create-game/create-game.component';
import { GameDisplayComponent } from './game/game-display/game-display.component';
import { GameEditComponent } from './game/game-edit/game-edit.component';
import { GameTableComponent } from './game/game-table/game-table.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { PlayerEditComponent } from './player/player-edit/player-edit.component';
import { PlayerGamesComponent } from './player/player-games/player-games.component';
import { PlayerStatPanelComponent } from './player/player-stat-panel/player-stat-panel.component';
import { PlayersComponent } from './player/player-stats-table/player-stats-table.component';
import { LoadingSpinnerComponent } from './shared/loading-spinner/loading-spinner.component';
import { MaterialModule } from './shared/modules/material.module';
import { NoDataComponent } from './shared/no-data/no-data.component';
import { SelectWithSearchComponent } from './shared/select-with-search/select-with-search.component';
import { SharedChipComponent } from './shared/shared-chip-component/shared-chip.component';
import { ToolbarComponent } from './shared/toolbar/toolbar.component';
import { reducers } from './store/app.state';
import { GameEffects } from './store/effects/game.effects';
import { HeroEffects } from './store/effects/hero.effects';
import { PlayerEffects } from './store/effects/player.effects';
import { hydrationMetaReducer } from './store/meta-reducers/hydration.meta-reducer';

@NgModule({
  declarations: [
    AppComponent,
    PlayersComponent,
    ToolbarComponent,
    PlayerEditComponent,
    CreateGameComponent,
    GameTableComponent,
    GameDisplayComponent,
    PlayerStatPanelComponent,
    SelectWithSearchComponent,
    CreateGameConfirmationWindowComponent,
    ImageUploadComponent,
    CreateGameFromTableComponent,
    SharedChipComponent,
    PlayerGamesComponent,
    LoadingSpinnerComponent,
    NoDataComponent,
    GameEditComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    StoreModule.forRoot(reducers, {
      metaReducers: [hydrationMetaReducer],
      runtimeChecks: {
        strictStateImmutability: true,
        strictActionImmutability: true,
      },
    }),
    EffectsModule.forRoot([]),
    EffectsModule.forFeature([GameEffects, PlayerEffects, HeroEffects]),
  ],
  providers: [provideHttpClient(withFetch()), provideAnimationsAsync()],
  bootstrap: [AppComponent],
})
export class AppModule {}
