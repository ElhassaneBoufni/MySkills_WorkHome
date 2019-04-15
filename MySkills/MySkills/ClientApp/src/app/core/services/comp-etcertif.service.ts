import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Skill, SkillAdapter } from '../models/skill.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CompETcertifService extends BaseService<Skill> {

  constructor(protected http: HttpClient, private adapter: SkillAdapter) {
    super(http);
  }

  list() {
    return super.findAll('compFound')
      .pipe(map((data: any[]) => data.map((item: any) => this.adapter.adapt(item))));
    // .subscribe(
    //     (response: Skill[]) => {
    //         console.log(response) ;
    //     });
  }

  loadUserSkills() {
    return super.findAll('compUser', { Level: '3', IdUser: '1' })
      .pipe(map((data: any[]) => data.map((item: any) => this.adapter.adapt(item))));
  }
  loadTechno() {
    return super.findAll('Skills', { Level: '1' })
      //.pipe(map((data: any[]) => data.map((item: any) => new Skill().deserialize(item))))
      .subscribe(
           (response: Skill[]) => {
               console.log(response) ;
          });
  }

  loadSkills(parentId, level) {
    return super.findAll('Skills', { Level: level, ParentId: parentId })
      .pipe(map((data: any[]) => data.map((item: any) => this.adapter.adapt(item))));
    // .subscribe(
    //      (response: Skill[]) => {
    //          console.log(response) ;
    //     });
  }
}