import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Auth } from '../../services/auth';
import { LoginRequest } from '../../models/user.model';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  credentials: LoginRequest = { email: 'mario.rossi@email.com', pwd: '1' };
  errorMessage = '';
  loading = false;

  constructor(private auth: Auth, private router: Router) {
    // Se già loggato vai alla home
    if (this.auth.isLoggedIn()) {
      this.router.navigate(['/home']);
    }
  }

  onSubmit(): void {
    this.errorMessage = '';
    this.loading = true;

    this.auth.login(this.credentials).subscribe({
      next: (response) => {
        this.loading = false;
        if (response.success) {
          this.router.navigate(['/home']);
        } else {
          this.errorMessage = response.message || 'Credenziali non valide';
        }
      },
      error: () => {
        this.loading = false;
        this.errorMessage = 'Errore di connessione al server';
      }
    });
  }
}
