
/**
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ApiService {

    constructor(private http: HttpClient) { }

    getNotes() {
        return this.http.get('http://localhost:52468/api/notes/getall');
    }

}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, take } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    baseUrl: string = "http://localhost:52468";

    constructor(private httpClient: HttpClient) { }

    get_notes() {
        let body = this.httpClient.get(this.baseUrl + '/api/notes/getall').pipe(map((data: any) => data.result), catchError(error => { return throwError('Its a Trap!') }));
           
        return body;
    }
}
*/