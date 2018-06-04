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
}