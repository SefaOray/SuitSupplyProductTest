import { Component, OnInit  } from '@angular/core';
import { ProductService } from '../../services/productService';
import { Product } from '../../types/product';
import { Subject } from 'rxjs';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'product-edit',
  templateUrl: './productEdit.component.html',
  styleUrls: ['./productEdit.component.css']
})
export class ProductEditComponent implements OnInit {


  constructor(private productService : ProductService, private activatedRoute: ActivatedRoute) {

  }
  ngOnInit(): void {

    this.activatedRoute.params.subscribe((params: Params) => {
        let productId = params['id'];

        this.productService.GetProduct(productId).subscribe((res) => {
            console.log(res);
        });
      });
  }
}