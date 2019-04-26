import { Component, OnInit, Input } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Skills } from '../../core/models/skills.model';
import { CompETcertifService } from '../../core/services/comp-etcertif.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { PropCompFormComponent } from './prop-comp-form/prop-comp-form.component';

@Component({
  selector: 'app-competence-view',
  templateUrl: './competence-view.component.html',
  styleUrls: ['./competence-view.component.css']
})
export class CompetenceViewComponent implements OnInit {
  skill2: Skills;
  selectable = true;
  removable = true;
  displayed = true;
  disabled = true;
  _CompFound: Skills[] = [];
  _CompSelected: Skills[] = [];
  // _Techno: Observable<Skills[]>;
  _Skills2: Observable<Skills[]>;
  popup: any;
  userName = 'Karim Herrati';

  constructor(private _compETcertifService: CompETcertifService, private dialog: MatDialog) {
    console.log('Le composant a fini sa construction');
    // this._Techno = this._compETcertifService.loadTechno();

    this._compETcertifService.loadUserSkills().subscribe(data => {
      this._CompSelected = data;
      console.log(this._CompSelected);
      if (this._CompSelected.length <= 0) {
        this.displayed = true;
      } else {
        this.displayed = false;
      }
    }
    );

  }

  ngOnInit() {
    console.log('Le composant a fini son initialisation');
  }

  get _Techno(): Skills[] {
    return this._compETcertifService.Technos;
  }

  // Drag And Drop methodes
  drop(event: CdkDragDrop<Skills[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(this._CompFound, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
      let sk: Skills = ((event.container.data[event.currentIndex]));
      console.log(sk);
      this._compETcertifService.postUserSkill(sk);
      if (event.container.data.length <= 0) {
        this.displayed = true;
      } else {
        this.displayed = false;
      }
    }
  }

  remove(comp): void {
    const index = this._CompSelected.indexOf(comp);
    let IdSkillToremove: number;
    if (index >= 0) {
      transferArrayItem(this._CompSelected, this._CompFound, this._CompSelected.indexOf(comp), this._CompFound.length);
      IdSkillToremove = Number.parseInt(this._CompSelected[index].skillId, 36);
      this._compETcertifService.deleteUserSkill(IdSkillToremove);
      alert(IdSkillToremove);
      if (this._CompSelected.length <= 0) {
        this.displayed = true;
      } else {
        this.displayed = false;
      }
    }
  }

  // Load Select's
  changedata($event) {
    let indexSkillsLvl2: String;

    console.log('changedata 1 !');
    if ($event.target.value === '0') {
      this._CompFound = [];
      this.disabled = true;
    } else {
      this.disabled = false;
      this._Skills2 = this._compETcertifService.loadSkills($event.target.value);

      // Pour charger les 2 select et la chips_List des skills trouvé en cascade
      this._Skills2.subscribe((response: Skills[]) => {
        indexSkillsLvl2 = (response[0].skillId);
        if (!this.disabled) {
          this._compETcertifService.loadSkills(indexSkillsLvl2, true).subscribe(data => {
            this._CompFound = data;
            console.log(this._CompFound);
          });
        }
      });
    }
    console.log(this.skill2);
  }

  changedata2($event) {
    console.log('changedata 2 !');
    console.log($event.target.value);
    this._compETcertifService.loadSkills($event.target.value, true).subscribe(data => {
      this._CompFound = data;
      console.log(this._CompFound);
    });
  }
  // Méthodes pour le PopOver d'ajout d'experiences
  onSubmit(form: NgForm) {
    console.log(form.value);
    this.popup.hide();
    console.log('Baaaa7');
  }

  openPopover(pop) {
    this.popup = pop;
  }

  // Proposer compétence DialogModal
  openPropComp() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = '50%';
    dialogConfig.data = this._Techno;
    this.dialog.open(PropCompFormComponent, dialogConfig);
  }
}

