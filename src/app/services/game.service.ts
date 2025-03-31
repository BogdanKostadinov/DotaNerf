import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateGameDTO, Game, GameDetails } from '../models/game.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  private url = 'https://localhost:7174/games';

  constructor(private http: HttpClient) {}

  getGames$(): Observable<GameDetails[]> {
    return this.http.get<GameDetails[]>(this.url);
  }

  getGame$(id: string): Observable<Game> {
    return this.http.get<Game>(this.url + '/' + id);
  }

  createGame$(game: CreateGameDTO): Observable<Game> {
    return this.http.post<Game>(this.url, game);
  }
}
