import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './_components/login/login.component';
import { LogoutComponent } from './_components/logout/logout.component';
import { PurchasingSupplierComponent } from '../purchasing/supplier/supplier.component';
import { PurchasingComponent } from '../purchasing/purchasing.component';
import { SupplierAddressComponent } from '../purchasing/supplier-address/supplier-address.component';
import { SupplierService } from '../purchasing/_services/supplier.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    LogoutComponent,
    PurchasingComponent,
    PurchasingSupplierComponent,
    SupplierAddressComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'logout', component: LogoutComponent },
      { path: 'purchasing', component: PurchasingComponent }
    ])
  ],
  providers: [SupplierService],  
  bootstrap: [AppComponent]
})
export class AppModule { }
