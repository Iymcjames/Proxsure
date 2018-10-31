import { AuthService } from './../Auth/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
  constructor(public authService: AuthService) {}

  canActivate(): boolean {
    if (this.authService.isLoggedIn()) {
      return true;
    }

    this.authService.startAuthentication();
    return false;
  }
}
