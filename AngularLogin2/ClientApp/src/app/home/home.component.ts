import { Component } from '@angular/core';
import { UserService } from '../_services/user.service'
import { User } from '../_models/user';
import { UsaState } from '../_models/state';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  users: User[];
  states: UsaState[];
  selectedState: any;
  stateList: any = ['Oklahoma', 'Texas'];

  //tempList: any = ['one','two', 'three']
  tempList: UsaState[] = [
    { id: 1, name: 'Oklahoma' },
    { id: 2, name: 'Texas' },
    { id: 3, name: 'Nebraska' }
  ];

  myTestFieldOnForm: any;

  constructor(private userService: UserService) {
    this.loadStates();
  }

  myTestFormSubmit(testForm: NgForm): void {
    console.log(testForm);
  }
  loadStates() {
    let usstate = new UsaState('Oklahoma', 1);
    this.states = [usstate];
    usstate = new UsaState('Texas', 2);
    this.states.push(usstate);
    this.selectedState = usstate;
  }

  loadUsers() {
    this.users = null;
    this.userService.getUsers().subscribe((users: User[]) => {
      console.log(users);
      this.users = users;
    }), error => {
      console.log('Error happened!', error);
    }
  }

}
