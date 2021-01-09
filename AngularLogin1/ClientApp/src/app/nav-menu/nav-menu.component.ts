import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../_services/auth.service';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  model: any = {};
  isLooggedIn: boolean;

  isExpanded = false;
  collapse() {
    this.isExpanded = false;
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  ngOnInit(): void {

  }

  constructor(private authService: AuthService) {
    this.isLooggedIn = false;
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in worked');
      console.log(next);
      this.isLooggedIn = true;
    }, error => {
        console.log('Failed to login');
        console.log(error);
    })
  }

  logout() {
    localStorage.removeItem('token');
    this.isLooggedIn = false;
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

}
