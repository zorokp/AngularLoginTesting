import { Component } from '@angular/core';
import { UserService } from '../_services/user.service';
import { User } from '../_models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent  {

  users: User[];

  constructor(private userService: UserService) {

  }

  loadUsers() {
    this.users = null;
    this.userService.getUsers().subscribe((users: User[]) => {
      console.log(users);
      this.users = users;
    }), error => {
      console.log(error);
    }
  }
}
