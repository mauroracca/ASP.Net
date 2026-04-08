import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Auth } from '../../services/auth';
import { UsersModel } from '../../models/user.model';
import {Httpcall} from '../../services/httpcall';

@Component({
  selector: 'app-home',
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit {
  currentUser: UsersModel | null = null;
  token: string | null = null;
  tokenValid: boolean | null = null;
  userEmail: string = '';
  films:any = [];

  constructor(private auth: Auth, private router: Router, private cdr: ChangeDetectorRef, private httpCall:Httpcall) {}

  ngOnInit(): void {
    this.currentUser = this.auth.getCurrentUser();
    this.token = this.auth.getToken();
    console.log(`in home.ts: ${JSON.stringify(this.currentUser)}`);
  }

  checkToken(): void {
    this.auth.validateToken().subscribe({
      next: (res) => {
        this.tokenValid = res.valid;
        this.userEmail=res.user;
        this.cdr.detectChanges();   // forza Angular ad aggiornare il DOM
        if (res.valid)
          console.log(`Token valido per utente: ${this.userEmail}`);
        },
      error: () => {
        this.tokenValid = false;
        this.cdr.detectChanges();
      }
    });
  }

  logout(): void {
    this.auth.logout();
    this.router.navigate(['/login']);
  }

  getTokenPreview(): string {
    if (!this.token) return '';
    return this.token.length > 40
      ? this.token.substring(0, 40) + '...'
      : this.token;
  }

  fetchMovies(){
    this.httpCall.getCall('/api/Film/GetAllFilms',this.auth.getToken()).subscribe({
      next: (res) => {
        this.films=res;
        console.log('Movies fetched:', this.films);
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Error fetching movies:', err);
      }
    });
  }
}
