import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CertifViewComponent } from './certif-view/certif-view.component';
import { CompetenceViewComponent } from './competence-view/competence-view.component';
import { ManagAndSuppViewComponent } from './manag-and-supp-view/manag-and-supp-view.component';
import { CompETcertifComponent } from './compETcertif.component';
import { SoftSkillsViewComponent } from './soft-skills-view/soft-skills-view.component';

const routesCompEtCertif: Routes = [
     { path: '', component: CompETcertifComponent,
        children: [ { path: 'certifView', component: CertifViewComponent },
                    { path: 'competenceView', component: CompetenceViewComponent },
                    { path: 'managAndSupp', component: ManagAndSuppViewComponent },
                    { path: 'softSkillsview', component: SoftSkillsViewComponent }
        ]
      }
];

@NgModule({
  imports: [
    RouterModule.forChild(routesCompEtCertif)
  ],
  exports: [RouterModule]
})
export class CompEtCertifRoutingModule { }
