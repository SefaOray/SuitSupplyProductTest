import { Injectable} from '@angular/core';
import { ServiceBase } from '../shared/serviceBase';
import { Observable }     from 'rxjs/Observable';

@Injectable()
export class ProductService{
    
    constructor(private serviceBase: ServiceBase) {
        
    }

    GetAllProducts() : Observable<any>
    {
        return this.serviceBase.get('/api/Product');
    }

    GetProduct(productId) : Observable<any>
    {
        return this.serviceBase.get("/api/Product/" + productId);
    }

    UpdateProduct(id, product){
        return this.serviceBase.put("/api/Product/" + id,product);
    }

    DeleteProduct(id)
    {
        return this.serviceBase.delete("/api/Product/" + id);
    }

    CreateProduct(product)
    {
        return this.serviceBase.post("/api/Product", product);
    }
}