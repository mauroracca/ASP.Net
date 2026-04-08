import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { LoginRequest, LoginResponse } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  private readonly apiUrl = 'http://localhost:62430/api/User';
  // chiavi per il localStorage, usate per salvare token e info utente
  private readonly TOKEN_KEY = 'jwt_token';
  private readonly USER_KEY = 'jwt_user';

  constructor(private http: HttpClient) {}

  /** POST api/User/login — autentica e salva il token in localStorage */
  login(credentials: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, credentials).pipe(
      tap(response => {
        if (response.success && response.token) {
          localStorage.setItem(this.TOKEN_KEY, response.token);
          localStorage.setItem(this.USER_KEY, JSON.stringify(response.user));
          console.log(`Dati salvati in local storage - Token: ${response.token}, User: ${JSON.stringify(response.user)}`);
          console.log(localStorage.getItem(this.USER_KEY));
        }
      })
    );
  }

  /** Rimuove il token dal localStorage */
  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.removeItem(this.USER_KEY);
  }

  /** GET api/User/validateToken — valida il token sul server */
  validateToken(): Observable<{ valid: boolean; user: string }> {
    return this.http.get<{ valid: boolean; user: string }>(`${this.apiUrl}/validateToken`, {
      headers: { Authorization: `Bearer ${this.getToken()}` },
    });
  }

  /** Restituisce il token JWT salvato */
  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  /** Controlla se l'utente è loggato (token presente) */
  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }

  /** Restituisce l'utente salvato in localStorage */
  getCurrentUser() {
    const u = localStorage.getItem(this.USER_KEY);
    console.log(`Get current user: ${u}`);
    return u ? JSON.parse(u) : null;
  }
}
