import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { HomeService } from './home.service';
import { AccountService } from './services/account.service';
import { AuthorizationComponent } from './pages/authorization/authorization.component'
import { FormsModule } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { RegistrationComponent } from './pages/registration/registration.component';

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
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  providers: [
    HomeService,
    AccountService,
    CookieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
