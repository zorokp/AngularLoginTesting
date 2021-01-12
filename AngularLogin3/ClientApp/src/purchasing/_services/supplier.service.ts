import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';


@Injectable()
export class SupplierService {

  baseUrl = environment.apiUrl + 'Supplier/';

  constructor(private http: HttpClient) {

  }


  addSupplier(model: any) {
    let formdata = model.value;

    console.log('model is: ', model);
    console.log('trying to add supplier...');

    const supplier = {
      Name: formdata.supplierName,
      SupplierAddress: {
        AddressLine1: formdata.addressStreet1,
        AddressLine2: formdata.supplierStreetAddress2,
        City: formdata.addressCity,
        StateProvinceID: formdata.selectedState,
        PostalCode: formdata.addressPostalCode,
        AddressType: "Supplier"
      }
    };


    return this.http.post(this.baseUrl + 'AddSupplier', supplier)
      .pipe(
        map((response: any) => {
          const resp = response;
          if (resp) {
            console.log('Supplier Added');
          }
        })
    );

  }
}
