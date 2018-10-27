import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { apiRootUrl } from 'src/app/shared/auth.service';

@Injectable({
  providedIn: 'root'
})
export class SuscriptionService {

  constructor(public http: HttpClient) {
  }

  getAllSuscriptions() {
    return this.http.get(apiRootUrl + 'api/suscription');
  }
}
