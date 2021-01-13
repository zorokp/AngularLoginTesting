import { Component, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'supplier-address',
  templateUrl: './supplier-address.component.html',
  styleUrls: ['./supplier-address.component.scss']
})

export class SupplierAddressComponent {
  @Input() inputFromParent: string;
  @Output() emittSomething: EventEmitter<string> = new EventEmitter();
  constructor() {

  }

  triggerMessage() {
    this.emittSomething.emit("hello");
  }
}
