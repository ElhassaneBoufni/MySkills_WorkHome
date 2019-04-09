import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-competence-view',
  templateUrl: './competence-view.component.html',
  styleUrls: ['./competence-view.component.css']
})
export class CompetenceViewComponent implements OnInit {
  selectable = true;
  removable = true;
  displayed = true;

  CompFound: { name: string, recommended: number }[] = [
    { 'name': 'Asp.net', 'recommended': 0 },
    { 'name': 'Asp.net MVC', 'recommended': 1 },
    { 'name': 'Java EE', 'recommended': 0 },
    { 'name': 'Spring MVC', 'recommended': 0 },
    { 'name': 'Struts 2', 'recommended': 0 },
    { 'name': 'Angular 7', 'recommended': 1 },
    { 'name': 'Dynamics CRM', 'recommended': 0 },
    { 'name': 'SalesForce', 'recommended': 0 },
    { 'name': 'SQL Server Integration Services', 'recommended': 0 },
    { 'name': 'PHP', 'recommended': 0 },
    { 'name': 'Laravel', 'recommended': 0 },
    { 'name': 'Aprimo', 'recommended': 0 },
    { 'name': 'CPQ (Big machines)', 'recommended': 0 },
    { 'name': 'Computer Tele Integration-CTI', 'recommended': 0 },
    { 'name': 'OSL Marketing Cloud (Eloqua)', 'recommended': 0 },
    { 'name': 'MFG/PRO', 'recommended': 0 },
    { 'name': 'Oracle CRM On Demand', 'recommended': 0 },
    { 'name': 'Hybris', 'recommended': 0 },
    { 'name': 'CRM – Others', 'recommended': 0 }
  ];

  CompSelected: { name: string, recommended?: number }[] = [
    { 'name': 'Asp.net Core 2.2'}
  ];
  constructor() {
    if (this.CompSelected.length <= 0) {
      this.displayed = true;
    } else {
      this.displayed = false;
    }
  }

  ngOnInit() {
  }

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
      transferArrayItem(this.CompSelected, this.CompFound , this.CompSelected.indexOf(comp), this.CompFound.length);
      if (this.CompSelected.length <= 0) {
        this.displayed = true;
      } else {
        this.displayed = false;
      }
      //this.CompSelected.splice(index, 1);
      //https://xd.adobe.com/spec/0c0274ae-b6f0-45b5-6132-e74e223d39e1-7a33/screen/bae4dae5-131f-4068-8af8-ccb36566ba9c/Web-1920-3/
    }
  }

  onSubmit(form: NgForm){
    console.log(form.value);
  }

}
