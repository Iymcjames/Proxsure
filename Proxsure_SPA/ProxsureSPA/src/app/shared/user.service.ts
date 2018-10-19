import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user.model';
import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
user: User;
  constructor(public httpClient: HttpClient) {
  }

   rootPath = 'http://localhost:4200';

createUser(userValue: any): Observable<any> {
this.user = {
  email: userValue.email,
   firstName: userValue.firstName,
   lastName: userValue.lastName,
   username : userValue.username,
   password: userValue.password,
   suscriptionStartDate: userValue.suscriptionStartDate,
   suscriptionExpirydate: userValue.suscriptionExpirydate,
   profileUrl: userValue.profileUrl,
  suscriptionId: userValue.suscriptionId
};
return this.httpClient.post('', this.user);
   }
}
