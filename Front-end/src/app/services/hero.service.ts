import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Hero } from '../models/hero.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HeroService {
  private url = 'https://localhost:44343/heroes';
  constructor(private http: HttpClient) {}

  getHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.url);
  }

  getHero(id: number): Observable<Hero> {
    return this.http.get<Hero>(this.url + '/' + id);
  }
}
