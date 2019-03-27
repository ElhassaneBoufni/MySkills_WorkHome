import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CompETcertifComponent} from './compETcertif.component';
import { CompetenceViewComponent } from './competence-view/competence-view.component';
import { ManagAndSuppViewComponent } from './manag-and-supp-view/manag-and-supp-view.component';
import { CertifViewComponent } from './certif-view/certif-view.component';
import { CompEtCertifRoutingModule } from './compETcertif-routing.module';

@NgModule({
    imports: [
        CommonModule,
        CompEtCertifRoutingModule
    ],
    declarations: [
        CompETcertifComponent,
        CompetenceViewComponent,
        ManagAndSuppViewComponent,
        CertifViewComponent
    ],
    exports: [
        CompETcertifComponent
    ]
})
export class CompETcertifModule {}
