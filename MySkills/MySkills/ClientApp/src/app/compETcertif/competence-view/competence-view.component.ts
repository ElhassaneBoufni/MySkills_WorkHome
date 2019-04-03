import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-competence-view',
  templateUrl: './competence-view.component.html',
  styleUrls: ['./competence-view.component.css']
})
export class CompetenceViewComponent implements OnInit {
  selectable = true;
  removable = true;
  displayed = true;

  CompFound = [
    'Asp.net',
    'Asp.net MVC',
    'Java EE',
    'Spring MVC',
    'Struts 2',
    'Angular 7',
    'Dynamics CRM',
    'SalesForce',
    'SQL Server Integration Services',
    'PHP',
    'Laravel',
    'Aprimo',
    'CPQ (Big machines)',
    'Computer Tele Integration-CTI',
    'OSL Marketing Cloud (Eloqua)',
    'MFG/PRO',
    'Oracle CRM On Demand',
    'Hybris',
    'CRM – Others',
  ];

  CompSelected = [
    'Asp.net Core 2.2'
  ];

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(this.CompFound, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
      if (event.container.data.length <= 0) {
        this.displayed = true;
      } else {
        this.displayed = false;
      }
    }
  }

  remove(comp): void {
    const index = this.CompSelected.indexOf(comp);

    if (index >= 0) {
      transferArrayItem(this.CompSelected, this.CompFound, this.CompSelected.indexOf(comp), this.CompFound.length);
      if (this.CompSelected.length <= 0) {
        this.displayed = true;
      } else {
        this.displayed = false;
      }
      //this.CompSelected.splice(index, 1);
      //https://xd.adobe.com/spec/0c0274ae-b6f0-45b5-6132-e74e223d39e1-7a33/screen/bae4dae5-131f-4068-8af8-ccb36566ba9c/Web-1920-3/
    }
  }
  constructor() {
    if (this.CompSelected.length <= 0) {
      this.displayed = true;
    } else {
      this.displayed = false;
    }
  }

  ngOnInit() {
  }

}
