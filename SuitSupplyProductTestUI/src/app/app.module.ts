import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ProductService } from './services/productService';
import { ServiceBase } from './shared/serviceBase';
import { HttpModule } from '@angular/http';
import { DataTablesModule } from 'angular-datatables';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    DataTablesModule
  ],
  providers: [ProductService, ServiceBase],
  bootstrap: [AppComponent]
})
export class AppModule { }
