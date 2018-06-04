import { Http, Response, Headers } from '@angular/http';
import { Observable }     from 'rxjs/Observable';
import { Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import 'rxjs/add/operator/map'

@Injectable()
export class ServiceBase{
    constructor(private httpBase: Http){}
    private baseUrl : string = environment.apiUrl;
    
    get(endpoint: string){
        return this.httpBase.get(this.baseUrl + endpoint)
        .map((res) => {
                return this.extractData(res)
        });;
    }

    post(endpoint: string, params: any){
        return this.httpBase.post(this.baseUrl + endpoint, params)
        .map((res) => {
                return this.extractData(res)
        });
    }
    
    put(endpoint: string, params: any)
    {
        return this.httpBase.put(this.baseUrl + endpoint, params)
        .map((res) => {
                return this.extractData(res)
        });
    }

    delete(endpoint: string)
    {
        return this.httpBase.delete(this.baseUrl + endpoint)
        .map((res) => {
                return this.extractData(res)
        });
    }

    private extractData(res: Response) {

        try{
            let body = res.json();
            return body || { };
        }
        catch{
            return {};
        }
    }

    private handleError (error: any) {
        let errMsg = (error.message) ? error.message :
        error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

}