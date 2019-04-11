import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Skill, SkillAdapter } from '../models/skill.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CompETcertifService extends BaseService<Skill> {
  CompSelected: Skill[] = [];

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

  loadTechno() {
    let params = new HttpParams();
    params.append('Level', '1');
    return super.findAll('Skills', { Level: '1' })
    .pipe(map((data: any[]) => data.map((item: any) => this.adapter.adapt(item))));
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