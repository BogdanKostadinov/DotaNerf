import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Player } from '../models/player.model';

@Injectable({
  providedIn: 'root',
})
export class PlayerService {
  private url = 'https://localhost:7174/players';

  constructor(private http: HttpClient) {}

  getPlayers$(): Observable<Player[]> {
    return this.http.get<Player[]>(this.url);
  }

  getPlayer$(id: string): Observable<Player> {
    return this.http.get<Player>(this.url + '/' + id);
  }
}
