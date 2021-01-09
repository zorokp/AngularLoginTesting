import { Component } from '@angular/core';
import { ErpMenu } from '../../_models/erpMenu';

@Component({
    selector: 'app-dynamic-erp-menu',
    templateUrl: './dynamic-erp-menu.component.html',
    styleUrls: ['./dynamic-erp-menu.component.scss']
})
/** DynamicErpMenu component*/
export class DynamicErpMenuComponent {

  erpMenuList: ErpMenu[] = [
    {
      Name: "Purchasing",
      Transaction: { AddTrans: "AddXaction", UpdateTrans: "upXaction" },
      Trans:["one","two","three"]
    },
    {
      Name: "Sales",
      Transaction: { AddTrans: "AddSalesXaction", UpdateTrans: "upSalesXaction" }
    }];
  
    /** DynamicErpMenu ctor */
    constructor() {

  }

  showMenu() {
    this.erpMenuList.push({
      Name: "Engineering",
      Transaction: { AddTrans: "AddEndXaction", UpdateTrans: "upEndXaction" }
    });
    console.log('returning: ' , this.erpMenuList);
    return this.erpMenuList;
  }
}
