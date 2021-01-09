import { Component } from '@angular/core';
import { AuthService } from '../../_services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})

export class LoginComponent {

  loginModel: any = {};
  loggedIn: boolean;
  constructor(private authService: AuthService) {

  }

  login() {
    this.authService.login(this.loginModel).subscribe(
      next => {
        console.log('Login worked!');
        console.log(next);
        this.loggedIn = true;
      }, error => {
        console.log('Login Error:', error);
      })
  }

  logout() {
    localStorage.removeItem('token');
    this.loggedIn = false;
  }

  isLoggedIn() {
    return this.authService.loggedIn();
  }
}
