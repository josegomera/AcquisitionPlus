import {Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({providedIn: 'root'})
export class UnitMeasureService {

    constructor(private http: HttpClient){

    }

    getUnitOfMeasures(){
        return this.http.get(`${environment.api}/UnitOfMeasurements`);
    }

    addUnitOfMeasure(payload){
        return this.http.post(`${environment.api}/UnitOfMeasurements`,payload);
    }
}