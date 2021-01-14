import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UsaState, UsState } from '../../../app/_models/State';
import { SupplierService } from '../../_services/supplier.service';

@Component({
  selector: 'app-pur-supplier',
  templateUrl: './pur-supplier.component.html',
  styleUrls: ['./pur-supplier.component.css']
})
export class PurSupplierComponent implements OnInit {

  message: string;
  states: UsState[];

  constructor(private supplierService: SupplierService) {
    
  }

  ngOnInit() {
    this.loadStates();
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

  showEmitted(whatToCatch: string) {
    console.log('showEmitted?? ' + whatToCatch);
    this.message += ' ' + whatToCatch;
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

}
