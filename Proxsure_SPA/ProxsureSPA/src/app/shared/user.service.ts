import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user.model';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserService {
user: User;
  constructor(public httpClient: HttpClient) { }

   rootPath = 'http://localhost:4200';

   createUser(form: FormGroup) {

   }
}
