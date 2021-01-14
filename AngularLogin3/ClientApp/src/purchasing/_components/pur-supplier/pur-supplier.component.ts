import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SupplierService } from '../../_services/supplier.service';

@Component({
  selector: 'app-pur-supplier',
  templateUrl: './pur-supplier.component.html',
  styleUrls: ['./pur-supplier.component.css']
})
export class PurSupplierComponent implements OnInit {

  message: string;

  constructor(private supplierService: SupplierService) { }

  ngOnInit() {
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

}
