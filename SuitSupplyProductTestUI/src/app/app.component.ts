import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductService } from './services/productService';
import { Product } from './types/product';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  title = 'app';

  dtOptions: DataTables.Settings = {
    searching: true
  };

  products: Product[] = [];
  dtTrigger: Subject<any> = new Subject();

  constructor(private productService : ProductService) {

  }
  ngOnInit(): void {
    this.productService.GetAllProducts().subscribe((res) => {
      this.products = <Product[]>res;
      this.dtTrigger.next();
    });
  }
}