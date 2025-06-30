import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../../models/user.model';

export interface AuthResponse {
  user: User;
  token: string;
  expiration: string;
}

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private currentUserSubject = new BehaviorSubject<User | null>(null);
  private tokenSubject = new BehaviorSubject<string | null>(null);

  public currentUser$ = this.currentUserSubject.asObservable();
  public isAuthenticated$ = this.currentUser$.pipe(map((user) => !!user));

  constructor(private router: Router) {
    this.loadStoredAuth();
  }

  private loadStoredAuth(): void {
    const storedAuth = localStorage.getItem('auth');
    if (storedAuth) {
      const { user, token, expiration } = JSON.parse(storedAuth);

      // Check if token is expired
      if (new Date(expiration) > new Date()) {
        this.currentUserSubject.next(user);
        this.tokenSubject.next(token);
      } else {
        this.logout(); // Token expired, logout
      }
    }
  }

  public setAuth(authResponse: AuthResponse): void {
    // Store in memory
    this.currentUserSubject.next(authResponse.user);
    this.tokenSubject.next(authResponse.token);

    // Store in localStorage
    localStorage.setItem('auth', JSON.stringify(authResponse));
  }

  public getToken(): string | null {
    return this.tokenSubject.value;
  }

  public getCurrentUser(): User | null {
    return this.currentUserSubject.value;
  }

  public logout(): void {
    // Clear from memory
    this.currentUserSubject.next(null);
    this.tokenSubject.next(null);

    // Clear from storage
    localStorage.removeItem('auth');

    // Redirect to login
    this.router.navigate(['/login']);
  }
}
