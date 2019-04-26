import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Skills, SkillAdapter } from '../models/skills.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CompETcertifService extends BaseService<Skills> {

  userId = 'c278b350-d33f-4155-95fc-30f0222d7059';
  error: any = '';
  Technos: Skills[];
  Skills2: Skills[];

  constructor(protected http: HttpClient, private adapter: SkillAdapter, private toastr: ToastrService) {
    super(http);
    this.loadTechno();
  }

  list() {
    return super.findAll('compFound')
      .pipe(map((data: any[]) => data.map((item: any) => this.adapter.adapt(item))));
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

  loadSkills(parentId, Islvl3?: boolean) {
    let res: Observable<Skills[]>;
    if (Islvl3) {
      res = super.findAll('CompEtCertif/GetSkills', { ParentId: parentId, appUserId: this.userId, islvl3: Islvl3 });
    } else {
      res = super.findAll('CompEtCertif/GetSkills', { ParentId: parentId, appUserId: this.userId });
    }
    return res.pipe(map((data: any[]) => data.map((item: any) => this.adapter.adapt(item))));
  }

  postUserSkill(skill: Skills) {
    skill.applicationUserId = this.userId;
    return super.insert(skill, 'CompEtCertif/PostSkills')
      .subscribe(
        (data: Skills) => {
          console.log(data);
          this.toastr.success('Compétence ajoutée !');
        }
      );
  }

  deleteUserSkill(id) {
    return super.delete(id, 'CompEtCertif/DeleteUserSkill').subscribe();
  }
}
