import { Component, OnInit, EventEmitter, Output, Input  } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UsState } from '../../../../app/_models/State';

@Component({
  selector: 'app-pur-supplier-add-form',
  templateUrl: './pur-supplier-add-form.component.html',
  styleUrls: ['./pur-supplier-add-form.component.css']
})
export class PurSupplierAddForm implements OnInit {

  @Input() states: UsState[];
  @Input() inputFromParent: string;
  @Output() emittSomething: EventEmitter<string> = new EventEmitter();
  @Output() emittAddSupplier: EventEmitter<NgForm> = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  triggerMessage() {
    this.emittSomething.emit("hello");
  }

  addSupplier(supplierForm: NgForm): void {
    this.emittAddSupplier.emit(supplierForm);
  }

}
