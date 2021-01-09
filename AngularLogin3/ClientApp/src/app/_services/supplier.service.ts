import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})

export class SupplierService {

  baseUrl = environment.apiUrl + 'Supplier/';

  constructor(private http: HttpClient) {

  }


  addSupplier(model: any) {
    console.log('model is: ', model);
    console.log('trying to add supplier...');
    const supplier = {
      Name: model.value.supplierName,
      Address: model.value.addressStreet1
    };


    return this.http.post(this.baseUrl + 'PostSupplier', supplier)
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
