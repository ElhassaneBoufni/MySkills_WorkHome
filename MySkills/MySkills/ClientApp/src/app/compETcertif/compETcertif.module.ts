import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CompETcertifComponent} from './compETcertif.component';
import { CompetenceViewComponent } from './competence-view/competence-view.component';
import { ManagAndSuppViewComponent } from './manag-and-supp-view/manag-and-supp-view.component';
import { CertifViewComponent } from './certif-view/certif-view.component';
import { CompEtCertifRoutingModule } from './compETcertif-routing.module';
import { MaterialModule } from '../../material.module';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SoftSkillsViewComponent } from './soft-skills-view/soft-skills-view.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        MaterialModule,
        ReactiveFormsModule,
        CompEtCertifRoutingModule,
        MDBBootstrapModule.forRoot(),
        DragDropModule
    ],
    declarations: [
        CompETcertifComponent,
        CompetenceViewComponent,
        ManagAndSuppViewComponent,
        CertifViewComponent,
        SoftSkillsViewComponent
    ],
    providers: []
})
export class CompETcertifModule {}
