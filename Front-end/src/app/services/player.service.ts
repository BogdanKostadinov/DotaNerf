import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GameStats, Player } from '../models/player.model';

@Injectable({
  providedIn: 'root',
})
export class PlayerService {
  private url = 'https://localhost:44343/players';

  constructor(private http: HttpClient) {}

  getPlayers$(): Observable<Player[]> {
    return this.http.get<Player[]>(this.url);
  }

  getPlayer$(id: number): Observable<Player> {
    return this.http.get<Player>(this.url + '/' + id);
  }

  addGameForPlayer(playerId: string, gameStats: GameStats): Observable<void> {
    return this.http.put<void>(`${this.url}/${playerId}`, gameStats);
  }
}
