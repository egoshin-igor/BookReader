// angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
// modules
import { AppRoutingModule } from './app-routing.module';
import { MaterialDesignModule } from './modules/material-design-module';
// components
import { AppComponent } from './app.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { AuthorizationComponent } from './pages/authorization/authorization.component';
import { HomeComponent } from './home/home.component';
// services
import { HomeService } from './home.service';
import { AccountService } from './services/account.service';
import { CookieService } from 'ngx-cookie-service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AuthorizationComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MaterialDesignModule
  ],
  providers: [
    HomeService,
    AccountService,
    CookieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
