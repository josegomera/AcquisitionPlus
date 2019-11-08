import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class ProductService {

    constructor(private http: HttpClient) {

    }

    getProducts() {
        return this.http.get(`${environment.api}/Products`);
    }

    getListProducts() {
        return this.http.get(`${environment.api}/Products/GetProducts`);
    }
}