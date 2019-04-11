import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class ContactService {

    public data: any = [];

    constructor(private http: HttpClient) { }

    save(name, subject, message) {
        this.data['name'] = name;
        this.data['subject'] = subject;
        this.data['message'] = message;
        console.log(this.data);
        //add request to send email or into mysql
        //this.http.put<any>('http://localhost/api/v1/update/', this.data).subscribe(
        //    res => {
        //        console.log(res);
        //    },
        //    (err: HttpErrorResponse) => {
        //        if (err.error instanceof Error) {
        //            console.log("Client-side error occured.");
        //        } else {
        //            console.log("Server-side error occurred.");
        //        }
        //    });
    }
}
