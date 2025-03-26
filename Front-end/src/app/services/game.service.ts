import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Game, GameDetails } from '../models/game.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  private url = 'https://localhost:44343/games';

  constructor(private http: HttpClient) {}

  getGames$(): Observable<GameDetails[]> {
    return this.http.get<GameDetails[]>(this.url);
  }

  getGame$(id: string): Observable<Game> {
    return this.http.get<Game>(this.url + '/' + id);
  }
}
