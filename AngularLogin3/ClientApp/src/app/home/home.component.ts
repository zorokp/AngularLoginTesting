import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UsaState, UsState } from '../_models/State'
import { SupplierService } from '../_services/supplier.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  states: UsState[];

  constructor(private supplierService: SupplierService) {
    this.loadStates();
  }

  loadStates() {
    let usState = new UsaState('Oklahoma', 1);
    this.states = [usState];
    usState = new UsaState('Texas', 2);
    this.states.push(usState);
    usState = new UsaState('Nebraska', 3);
    this.states.push(usState);
    usState = new UsaState('Missouri', 4);
    this.states.push(usState);
  }

  addSupplier(supplierForm: NgForm): void {
    console.log('Calling Supplier Service');
    this.supplierService.addSupplier(supplierForm).subscribe(
      success => {
        console.log('supplier worked!', success);
      }, error => {
        console.log('supplier failed :-( ', error);
      })
  }

}
