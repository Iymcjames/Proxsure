import { Injectable } from '@angular/core';
import { getAuthClientSettings } from './auth-config.model';
import { UserManager, User } from 'oidc-client';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private configManager = new UserManager(getAuthClientSettings());
  private user: User;

  constructor() {
    this.configManager.getUser().then(value => {
      this.user = value;
    });
  }

  isLoggedIn(): boolean {
    return this.user != null && !this.user.expired;
  }

  getClaims(): any {
    return this.user.profile;
  }

  getAuthorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  startAuthentication(): Promise<void> {
    return this.configManager.signinRedirect();
}

completeAuthentication(): Promise<void> {
    return this.configManager.signinRedirectCallback().then(user => {
        this.user = user;
    });
}
}

export const apiRootUrl = 'https://localhost:5001/';
