import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PurchasingComponent } from './purchasing.component';
import { PurSupplierComponent } from './_components/pur-supplier/pur-supplier.component'
import { SupplierService } from './_services/supplier.service';
import { RouterModule } from '@angular/router';
import { PurSupplierAddForm } from './_components/pur-supplier/pur-supplier-add-form/pur-supplier-add-form.component';

@NgModule({
  declarations: [
    PurchasingComponent,
    PurSupplierComponent,
    PurSupplierAddForm,
  ],
  imports: [
    CommonModule,
    FormsModule,
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
