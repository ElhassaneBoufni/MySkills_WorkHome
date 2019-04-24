import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { map } from 'rxjs/operators';
import { AspNetUsers, AspNetUsersAdapter } from '../models/aspNetUsers.model';

@Injectable({
    providedIn: 'root'
})
export class AspNetUsersService extends BaseService<AspNetUsers> {

    error: any = '';
    AspNetUsers: AspNetUsers[];


    constructor(protected http: HttpClient, private adapter: AspNetUsersAdapter) {
        super(http);
        this.list();
    }

    list() {
        return super.findAll('AspNetUsers/GetAll')
            .pipe(map(data => data.map((item: any) => this.adapter.adapt(item))))
            .subscribe(
                (response: AspNetUsers[]) => {
                    this.AspNetUsers = response;
                    console.log(this.AspNetUsers);
                },
                error => this.error = error);
    }
}
