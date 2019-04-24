import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Skills, SkillAdapter } from '../models/skills.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CompETcertifService extends BaseService<Skills> {

  userId = 'c278b350-d33f-4155-95fc-30f0222d7059';
  error: any = '';
  Technos: Skills[];
  Skills2: Skills[];

  constructor(protected http: HttpClient, private adapter: SkillAdapter) {
    super(http);
    this.loadTechno();
  }

  list() {
    return super.findAll('compFound')
      .pipe(map((data: any[]) => data.map((item: any) => this.adapter.adapt(item))));
    // .subscribe(
    //     (response: Skills[]) => {
    //         console.log(response) ;
    //     });
  }

  loadUserSkills() {
    return super.findAll('CompEtCertif/GetUserSkills', { appUserId: this.userId })
      .pipe(map((data: any[]) => data.map((item: any) => this.adapter.adapt(item))));
  }
  loadTechno() {
    return super.findAll('CompEtCertif/GetTechno')
      .pipe(map(data => data.map((item: any) => this.adapter.adapt(item))))
      .subscribe(
        (response: Skills[]) => {
          this.Technos = response;
          console.log(this.Technos);
        });
  }

  loadSkills(parentId) {
    return super.findAll('CompEtCertif/GetSkills', {ParentId: parentId })
      .pipe(map((data: any[]) => data.map((item: any) => this.adapter.adapt(item))));
    // .subscribe(
    //      (response: Skills[]) => {
    //          console.log(response) ;
    //     });
  }
}
