import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizationComponent} from '../app/pages/authorization/authorization.component';
import { RegistrationComponent } from '../app/pages/registration/registration.component';
import { AddBookComponent } from './pages/add-book/add-book.component';
import {BookListComponent} from '../app/pages/book-list/book-list.component';


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'authorization', component: AuthorizationComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'add-book', component: AddBookComponent },
  { path: 'home', component: BookListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
