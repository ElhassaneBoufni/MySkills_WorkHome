import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Faq, FaqAdapter } from '../models/faq.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FaqService extends BaseService<Faq> {

    error: any = '';
    Faq: Faq[];
  

  constructor(protected http: HttpClient, private adapter: FaqAdapter) {
    super(http);
      this.list();
  }

  list() {
      return super.findAll('Faq/GetAll')
          .pipe(map(data => data.map((item: any) => this.adapter.adapt(item))))
        .subscribe(
        (response: Faq[]) => {
            this.Faq = response;
            console.log(this.Faq);
              },
              error => this.error = error);
  }
}
