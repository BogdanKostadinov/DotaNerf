import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TableComponent } from './table/table.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { PlayerEditComponent } from './player-edit/player-edit.component';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSortModule } from '@angular/material/sort';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatMenuModule } from '@angular/material/menu';
import { MatExpansionModule } from '@angular/material/expansion';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import {
  HttpClientModule,
  provideHttpClient,
  withFetch,
} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CreateGameComponent } from './create-game/create-game.component';
import { GameTableComponent } from './game-display/game-table/game-table.component';
import { PlayerStatPanelComponent } from './game-display/player-stat-panel/player-stat-panel.component';
import { GameDisplayComponent } from './game-display/game-display.component';
import { SelectWithSearchComponent } from './shared/select-with-search/select-with-search.component';
import { CreateGameConfirmationWindowComponent } from './create-game/create-game-confirmation-window/create-game-confirmation-window.component';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';

@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    ToolbarComponent,
    PlayerEditComponent,
    CreateGameComponent,
    GameTableComponent,
    GameDisplayComponent,
    PlayerStatPanelComponent,
    SelectWithSearchComponent,
    CreateGameConfirmationWindowComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    MatTableModule,
    MatToolbarModule,
    MatIconModule,
    MatPaginatorModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatSortModule,
    MatRadioModule,
    MatSelectModule,
    MatMenuModule,
    MatExpansionModule,
    CdkAccordionModule,
    MatDividerModule,
    MatListModule,
    NgxMatSelectSearchModule,
  ],
  providers: [provideHttpClient(withFetch()), provideAnimationsAsync()],
  bootstrap: [AppComponent],
})
export class AppModule {}
