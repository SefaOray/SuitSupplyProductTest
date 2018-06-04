import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ProductService } from './services/productService';
import { ServiceBase } from './shared/serviceBase';
import { HttpModule } from '@angular/http';
import { DataTablesModule } from 'angular-datatables';
import { ProductManagerComponent } from './components/productManager/productManager.component';

const appRoutes: Routes = [
  { path: 'product', component: ProductManagerComponent },
  
];


@NgModule({
  declarations: [
    AppComponent,
    ProductManagerComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    DataTablesModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
    
  ],
  providers: [ProductService, ServiceBase, RouterModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
