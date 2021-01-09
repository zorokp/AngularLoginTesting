import { Component } from '@angular/core';
import { Local } from 'protractor/built/driverProviders';
import { Router, Routes } from '@angular/router';

@Component({
    selector: 'app-logout',
    templateUrl: './logout.component.html',
    styleUrls: ['./logout.component.scss']
})

export class LogoutComponent {

    constructor(private router: Router) {
      localStorage.removeItem('token');
      this.router.navigateByUrl('/login');

    }
}
