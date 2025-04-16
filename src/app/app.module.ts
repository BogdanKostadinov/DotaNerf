import { CdkAccordionModule } from '@angular/cdk/accordion';
import {
  HttpClientModule,
  provideHttpClient,
  withFetch,
} from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateGameFromTableComponent } from './create-game-from-table/create-game-from-table.component';
import { CreateGameConfirmationWindowComponent } from './create-game/create-game-confirmation-window/create-game-confirmation-window.component';
import { CreateGameComponent } from './create-game/create-game.component';
import { GameDisplayComponent } from './game-display/game-display.component';
import { GameTableComponent } from './game-display/game-table/game-table.component';
import { PlayerStatPanelComponent } from './game-display/player-stat-panel/player-stat-panel.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { PlayerEditComponent } from './player-edit/player-edit.component';
import { TableComponent } from './player-stats-table/player-stats-table.component';
import { SelectWithSearchComponent } from './shared/select-with-search/select-with-search.component';
import { SharedChipComponent } from './shared/shared-chip-component/shared-chip.component';
import { ToolbarComponent } from './toolbar/toolbar.component';

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
    ImageUploadComponent,
    CreateGameFromTableComponent,
    SharedChipComponent,
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
    ReactiveFormsModule,
    FormsModule,
    MatSortModule,
    MatRadioModule,
    MatSelectModule,
    MatMenuModule,
    MatExpansionModule,
    CdkAccordionModule,
    MatDividerModule,
    MatListModule,
    NgxMatSelectSearchModule,
    MatCardModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatCheckboxModule,
    MatChipsModule,
  ],
  providers: [provideHttpClient(withFetch()), provideAnimationsAsync()],
  bootstrap: [AppComponent],
})
export class AppModule {}
