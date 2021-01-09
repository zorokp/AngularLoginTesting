import { Component } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { SupplierService } from './_services/supplier.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor(private authService: AuthService, private supplierService: SupplierService) {

  }

  isLoggedIn() {
    return this.authService.loggedIn();
  }
}
