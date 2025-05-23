import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import {
  CreateGameDTO,
  GameDetails,
  UpdateGameDTO,
} from '../models/game.model';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  private url = 'https://localhost:7174/games';

  constructor(private http: HttpClient) {}

  getGames$(): Observable<GameDetails[]> {
    return this.http
      .get<GameDetails[]>(this.url)
      .pipe(
        map((games) =>
          games.sort(
            (a, b) =>
              new Date(b.dateCreated).getTime() -
              new Date(a.dateCreated).getTime(),
          ),
        ),
      );
  }
  getPlayerGames$(playerId: string): Observable<GameDetails[]> {
    return this.http
      .get<GameDetails[]>(this.url + '/player/' + playerId)
      .pipe(
        map((games) =>
          games.sort(
            (a, b) =>
              new Date(b.dateCreated).getTime() -
              new Date(a.dateCreated).getTime(),
          ),
        ),
      );
  }
  getGame$(id: string): Observable<GameDetails> {
    return this.http.get<GameDetails>(this.url + '/' + id);
  }
  createGame$(game: CreateGameDTO): Observable<GameDetails> {
    return this.http.post<GameDetails>(this.url, game);
  }
  updateGame$(updateGameDTO: UpdateGameDTO): Observable<GameDetails> {
    return this.http.put<GameDetails>(this.url, updateGameDTO);
  }
  deleteGame$(gameId: string): Observable<void> {
    return this.http.delete<void>(this.url + '/' + gameId);
  }
}
