import { AuthService } from './../shared/Auth/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(public authService: AuthService ) { }

  ngOnInit() {
    this.authService.completeAuthentication();
  }

}
