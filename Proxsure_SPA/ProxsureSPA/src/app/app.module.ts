import { MaterialModule } from './material/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { HttpClientModule } from '@angular/common/http';
import { SuscriptionComponent } from './Admin/Suscription/suscription/suscription.component';
import { ProfilePictureComponent } from './shared/Users/profile-picture/profile-picture.component';
import { MainNavComponent } from './shared/main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { HomeLayoutComponent } from './shared/home-layout/home-layout.component';
import { ToastrModule } from 'ngx-toastr';
import { DashboardLayoutComponent } from './shared/dashboard-layout/dashboard-layout.component';
import { AuthGuardService } from './shared/Auth/auth-guard.service';
import { AuthService } from './shared/Auth/auth.service';

@NgModule({
  declarations: [
    routingComponents,
    NavBarComponent,
    SignUpComponent,
    NavBarComponent,
    AppComponent,
    SuscriptionComponent,
    ProfilePictureComponent,
    MainNavComponent,
    HomeLayoutComponent,
    DashboardLayoutComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    LayoutModule,
    ToastrModule.forRoot()
  ],
  providers: [AuthGuardService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule {}
