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

    newProduct: boolean = false;
    product = new Product();
    statusText;
    priceApproved = false;
    constructor(private productService : ProductService, private activatedRoute: ActivatedRoute, private router: Router) {

    }
    ngOnInit(): void {

    this.activatedRoute.params.subscribe((params: Params) => {
        let productId = params['id'];

        if(productId == undefined){
            this.newProduct = true;
        }
        else
        {
            this.productService.GetProduct(productId).subscribe((res) => {
                console.log(res);
                this.product = <Product>res;
            }, (err: Response) => {
                this.statusText = "Can not load product from server." + err.json() ||  err.statusText;
            });
        }
        });
    }

    saveProduct()
    {
        if(this.product.price > 999 && this.priceApproved == false)
        {
            this.statusText = "Price is too high. Please click Save again to approve";
            this.priceApproved = true;
            return;
        }

        if(this.newProduct = false)
        {
            this.productService.UpdateProduct(this.product.id, {code: this.product.code, name: this.product.name, photo: this.product.photo, price:this.product.price}).subscribe((res) => {
                this.statusText = "Product is updated"
            }, (err) => {
                this.statusText = "Unable to update product." + err.json() ||  err.statusText;
            })
        }
        else
        {
            this.productService.CreateProduct({code: this.product.code, name: this.product.name, photo: this.product.photo, price:this.product.price}).subscribe((res) => {
                
                this.router.navigate(['/productEdit', {id: res.id }])
            }, (err) => {
                this.statusText = "Unable to update product." + err.json() ||  err.statusText;
            })
        }
        
    }
}