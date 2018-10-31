import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {  UserViewModel, UserData } from './user.model';
import { Observable } from 'rxjs';
import { apiRootUrl } from '../Auth/auth.service';
import { User } from 'oidc-client';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private user: User;
  userVM: UserViewModel;
  constructor(public httpClient: HttpClient) {}

  createUser(userValue: any): Observable<any> {
    let user: UserData;
    user = {
      email: userValue.email,
      firstName: userValue.firstName,
      lastName: userValue.lastName,
      username: userValue.username,
      suscriptionId: userValue.suscriptionId,
      profilePictureUrl: ''
    };
    this.userVM = {
      user: user,
      password: userValue.password
    };
    // const userProfile = new FormData();
    // userProfile.append('data', 'this.user');
    // userProfile.append('profilePicture', picToUpload);
    const headers = new Headers();
    headers.append(
      'Authorization',
      'Bearer' + this.user.access_token
    );
    return this.httpClient.post(apiRootUrl + 'api/user', this.userVM, {header : headers});
  }

  getAllSuscriptions() {
    return this.httpClient.get(apiRootUrl + 'api/suscription');
  }
}
