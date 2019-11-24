// angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {CommonModule} from '@angular/common';
// modules
import { AppRoutingModule } from './app-routing.module';
import { MaterialDesignModule } from './modules/material-design-module';
import { ImageCropperModule } from 'ngx-image-cropper';
// components
import { AppComponent } from './app.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { AuthorizationComponent } from './pages/authorization/authorization.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './directives/header/header.component';
// services
import { HomeService } from './home.service';
import { AccountService } from './services/account.service';
import { CookieService } from 'ngx-cookie-service';
import { AddBookComponent } from './pages/add-book/add-book.component';
import { CardBookComponent } from './directives/card-book/card-book.component';
import { BookListComponent } from './pages/book-list/book-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AuthorizationComponent,
    RegistrationComponent,
    HeaderComponent,
    AddBookComponent,
    CardBookComponent,
    BookListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MaterialDesignModule,
    CommonModule,
    ImageCropperModule,
    ReactiveFormsModule
  ],
  providers: [
    HomeService,
    AccountService,
    CookieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
