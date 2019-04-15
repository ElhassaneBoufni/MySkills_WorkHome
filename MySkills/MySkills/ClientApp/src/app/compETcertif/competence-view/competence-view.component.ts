import { Component, OnInit, Input } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Skill } from '../../core/models/skill.model';
import { CompETcertifService } from '../../core/services/comp-etcertif.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { PropCompFormComponent } from './prop-comp-form/prop-comp-form.component';

@Component({
  selector: 'app-competence-view',
  templateUrl: './competence-view.component.html',
  styleUrls: ['./competence-view.component.css']
})
export class CompetenceViewComponent implements OnInit {
  selectable = true;
  removable = true;
  displayed = false;
  disabled = true;
  _CompFound: Skill[] = [];
  _CompSelected: Skill[] = [];
  _Techno: Observable<Skill[]>;
  _Skills2: Observable<Skill[]>;
  popup: any;
  userName = 'Karim Herrati';

  constructor(private _compETcertifService: CompETcertifService, private dialog: MatDialog) {
    console.log('Le composant a fini sa construction');
    this._compETcertifService.loadTechno();

    // this._compETcertifService.loadUserSkills().subscribe(data => {
    //   this._CompSelected = data;
    //   console.log(this._CompSelected);
    // });

    if (this._CompSelected.length <= 0) {
      this.displayed = false;
    } else {
      this.displayed = true;
    }
  }

  ngOnInit() {
    console.log('Le composant a fini son initialisation');

  }

  // Drag And Drop methodes
  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(this._CompFound, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
      console.log(event.container.data);
      if (event.container.data.length <= 0) {
        this.displayed = true;
      } else {
        this.displayed = false;
      }
    }
  }

  remove(comp): void {
    const index = this._CompSelected.indexOf(comp);

    if (index >= 0) {
      transferArrayItem(this._CompSelected, this._CompFound, this._CompSelected.indexOf(comp), this._CompFound.length);
      if (this._CompSelected.length <= 0) {
        this.displayed = true;
      } else {
        this.displayed = false;
      }
    }
  }

  // Load Select's
  changedata($event) {
    console.log('chandata & !');
    console.log($event.target.value);
    if ($event.target.value === '0') {
      this.disabled = true;
    } else {
      this.disabled = false;
      this._Skills2 = this._compETcertifService.loadSkills($event.target.value, '2');
    }
  }
  changedata2($event) {
    console.log('chandata 2 !');
    console.log($event.target.value);
    if ($event.target.value === '0') {
    } else {
      this._compETcertifService.loadSkills($event.target.value, '3').subscribe(data => {
        this._CompFound = data;
        console.log(this._CompFound);
      });
    }
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
