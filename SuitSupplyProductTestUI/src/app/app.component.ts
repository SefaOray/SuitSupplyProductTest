import { Component } from '@angular/core';
import { ProductService } from './services/productService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private productService : ProductService) {
    
    productService.GetAllProducts().subscribe((res) => {
      console.log(res);
    })
  }
}