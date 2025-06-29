import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateUserDTO, User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private url = 'https://localhost:7174/users';

  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<User> {
    return this.http.post<User>(`${this.url}/login`, { email, password });
  }

  createUser(user: CreateUserDTO): Observable<User> {
    return this.http.post<User>(`${this.url}/create`, user);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.url);
  }
  getUser(id: string): Observable<User> {
    return this.http.get<User>(`${this.url}/${id}`);
  }
}
