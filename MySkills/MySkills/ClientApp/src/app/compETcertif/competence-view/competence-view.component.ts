import { Component, OnInit } from '@angular/core';
import {CdkDragDrop, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-competence-view',
  templateUrl: './competence-view.component.html',
  styleUrls: ['./competence-view.component.css']
})
export class CompetenceViewComponent implements OnInit {
  selectable = true;
  removable = true;

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
    'Laravel'
  ];

  CompSelected = [
    'Asp.net Core 2.2'
  ];

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
                        event.container.data,
                        event.previousIndex,
                        event.currentIndex);
    }
  }

  remove(comp): void {
    const index = this.CompSelected.indexOf(comp);

    if (index >= 0) {
      transferArrayItem(this.CompSelected,this.CompFound, this.CompSelected.indexOf(comp), this.CompFound.length);
      //this.CompSelected.splice(index, 1);
      //https://xd.adobe.com/spec/0c0274ae-b6f0-45b5-6132-e74e223d39e1-7a33/screen/bae4dae5-131f-4068-8af8-ccb36566ba9c/Web-1920-3/
    }
  }
  constructor() { }

  ngOnInit() {
  }

}
