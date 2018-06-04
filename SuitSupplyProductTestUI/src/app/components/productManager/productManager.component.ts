import { Component, OnInit, ViewChild, AfterViewInit,Renderer  } from '@angular/core';
import { ProductService } from '../../services/productService';
import { Product } from '../../types/product';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';
import { Router } from '@angular/router';

@Component({
  selector: 'product-manager',
  templateUrl: './productManager.component.html',
  styleUrls: ['./productManager.component.css']
})
export class ProductManagerComponent implements OnInit {
  
  dtOptions: any = {
    searching: true,
    rowCallback: (row: Node, data: any[] | Object, index: number) => {
      const self = this;
      // Unbind first in order to avoid any duplicate handler
      // (see https://github.com/l-lin/angular-datatables/issues/87)
      $('td', row).unbind('click');
      $('td', row).bind('click', () => {
        self.rowClickHandler(data);
      });
      return row;
    },
    select: true,
    dom: 'Bfrtip',
    buttons:[
      'excel',
      {
        text: 'Details',
        action:(function(e,dt,node,config){
          console.log(e);
          console.log(dt);
          console.log(node);
          console.log(config);
        })
      }
    ]
  };

  selectedId;

  rowClickHandler(info: any): void {
    //unclick event
    if(info[0] == this.selectedId)
    {
      this.selectedId = undefined;
    }
    else{
      this.selectedId = info[0];
    }
    
    
    console.log(this.selectedId);
  }

  products: Product[] = [];
  dtTrigger: Subject<any> = new Subject();

  constructor(private renderer: Renderer, private router: Router, private productService : ProductService) {

  }
  ngOnInit(): void {
    this.productService.GetAllProducts().subscribe((res) => {
      this.products = <Product[]>res;
      this.dtTrigger.next();
    });
  }
}