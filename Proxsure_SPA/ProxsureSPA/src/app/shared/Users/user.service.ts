import { apiRootUrl } from 'src/app/shared/auth.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user.model';
import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Profile } from 'selenium-webdriver/firefox';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  user: User;
  apiRootUrl = apiRootUrl;
  constructor(public httpClient: HttpClient) {}

  createUser(userValue: any) {
    this.user = {
      email: userValue.email,
      firstName: userValue.firstName,
      lastName: userValue.lastName,
      username: userValue.username,
      password: userValue.password,
      suscriptionStartDate: new Date(),
      suscriptionExpirydate: null,
      suscriptionId: userValue.suscriptionId,
      profilePicture: null
    };

    // const userProfile = new FormData();
    // userProfile.append('data', 'this.user');
    // userProfile.append('profilePicture', picToUpload);
     this.httpClient.post(apiRootUrl + 'api/signup', this.user)
    .subscribe((result) => {
console.log(result);
    });
  }

  getAllSuscriptions() {
    return this.httpClient.get(apiRootUrl + 'api/suscription');
  }
}
