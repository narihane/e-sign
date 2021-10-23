import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { UserMainComponent } from './user-main/user-main.component';
import { UserAddDetailsComponent } from './user-add-details/user-add-details.component';
import { AdminMainComponent } from './admin-main/admin-main.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { APP_BASE_HREF } from '@angular/common';
import {
  MatFormFieldModule
} from '@angular/material/form-field';
import {
  MatInputModule
} from '@angular/material/input';
import { TileComponent } from './shared/tile/tile.component';
import { InvoiceDetailsComponent } from './invoice-details/invoice-details.component';
import { AuthGuard } from './shared/_guards/authGuard';
import { AuthenticationService } from './shared/_services/authentication.service';
import { UserService } from './shared/_services/user.service';
import { JwtInterceptor } from './shared/_helpers/jwt.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    UserMainComponent,
    UserAddDetailsComponent,
    AdminMainComponent,
    TileComponent,
    InvoiceDetailsComponent
  ],
  imports: [
    MatFormFieldModule,
    MatInputModule,
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule,
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [{ provide: APP_BASE_HREF, useValue: '/' },
  AuthGuard,
  AuthenticationService,
  UserService,
  {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
  }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
