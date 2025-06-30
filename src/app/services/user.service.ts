import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { CreateUserDTO, User } from '../models/user.model';
import {
  AuthenticationService,
  AuthResponse,
} from './authentication/authentication.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private url = 'https://localhost:7174/users';

  constructor(
    private http: HttpClient,
    private authService: AuthenticationService,
  ) {}

  login(email: string, password: string): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${this.url}/login`, { email, password })
      .pipe(tap((response) => this.authService.setAuth(response)));
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
