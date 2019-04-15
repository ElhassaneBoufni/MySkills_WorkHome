import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Skill } from '../../../core/models/skill.model';
import { CompETcertifService } from '../../../core/services/comp-etcertif.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-prop-comp-form',
  templateUrl: './prop-comp-form.component.html',
  styleUrls: ['./prop-comp-form.component.css']
})
export class PropCompFormComponent implements OnInit {
  formDataPropComp: Skill;
  disabled: boolean;
  _Skills2: Observable<Skill[]>;

  constructor(
    @Inject(MAT_DIALOG_DATA) private data: Skill[],
    private _compETcertifService: CompETcertifService,
    private dialogRef: MatDialogRef<PropCompFormComponent>
  ) { }

  changedata($event) {
    console.log('chandata & !');
    console.log($event.value);
    if ($event.value === '0') {
      this.disabled = true;
    } else {
      this.disabled = false;
      this._Skills2 = this._compETcertifService.loadSkills($event.value, '2');
    }
  }

  ngOnInit() {
    console.log(this.data);
  }
  onSubmit() {
    console.log(this.formDataPropComp);
    this.dialogRef.close();
  }
  onClose() {
    this.dialogRef.close();
  }
}
