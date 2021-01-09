import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Local } from 'protractor/built/driverProviders';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.apiUrl + 'Authentication/';
  JwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) {

  }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            this.decodedToken = this.JwtHelper.decodeToken(user.token);
            console.log(this.decodedToken);
          }
        })
      );    
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    const tokenExpired = this.JwtHelper.isTokenExpired(token);
    console.log('Auth Service THREE. Checking if logged in: ', !tokenExpired);
    return !tokenExpired;
  }
}
