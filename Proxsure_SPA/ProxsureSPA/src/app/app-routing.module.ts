import { DashboardLayoutComponent } from './shared/dashboard-layout/dashboard-layout.component';
import { HomeLayoutComponent } from './shared/home-layout/home-layout.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SignUpComponent } from './sign-up/sign-up.component';

// const routes: Routes = [
//   {path: 'home', component: HomeComponent},
//   {path: 'dashboard', component: DashboardComponent},
//   {path: 'signup', component: SignUpComponent},
//   {path: '', redirectTo: '/home', pathMatch: 'full'}
// ];

const routes: Routes = [
  { path: '', redirectTo: 'home', data: { title: 'Home' }, pathMatch: 'full' },
  {
    path: 'home', component: HomeLayoutComponent, data: {title: 'Home'},
    children: [
      {path: '', component: HomeComponent},
      {path: 'signup', component: SignUpComponent}
    ]
  },
  { path: 'dashboard', component: DashboardLayoutComponent, data: {title: 'dashboard'},
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [HomeComponent, DashboardComponent, NavBarComponent, SignUpComponent];

