import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Hero } from '../models/hero.model';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HeroService {
  private url = 'https://localhost:7174/heroes';
  constructor(private http: HttpClient) {}

  getHeroes$(): Observable<Hero[]> {
    return this.http
      .get<Hero[]>(this.url)
      .pipe(
        map((heroes) => heroes.sort((a, b) => a.name.localeCompare(b.name))),
      );
  }

  getHero$(id: number): Observable<Hero> {
    return this.http.get<Hero>(this.url + '/' + id);
  }
}
