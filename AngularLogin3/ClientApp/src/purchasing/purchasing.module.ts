import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PurchasingComponent } from './purchasing.component';
//import { PurSupplierComponent } from './pur-supplier.component';
import { PurSupplierComponent } from './_components/pur-supplier/pur-supplier.component'
import { SupplierService } from './_services/supplier.service';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    PurchasingComponent,
    PurSupplierComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot([
      { path: 'pur-supplier', component: PurSupplierComponent },
    ])
  ],
  exports: [
    PurchasingComponent,
    PurSupplierComponent
  ],
  providers: [SupplierService]
})
export class PurchasingModule { }
