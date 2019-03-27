import { NgModule  } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CompETcertifComponent } from './compETcertif/compETcertif.component';
import { ProfilComponent } from './profil/profil.component';
import { ContactComponent } from './contact/contact.component';
import { FaqComponent } from './faq/faq.component';
import { ErrorComponent } from './error/error.component';
import { CertifViewComponent } from './compETcertif/certif-view/certif-view.component';
import { CompetenceViewComponent } from './compETcertif/competence-view/competence-view.component';
import { ManagAndSuppViewComponent } from './compETcertif/manag-and-supp-view/manag-and-supp-view.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'compETcertif', component: CompETcertifComponent },
  { path: 'profil', component: ProfilComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'faq', component: FaqComponent },
  { path: 'not-found', component: ErrorComponent},
  { path: '**', redirectTo: '/not-found'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes,
            { enableTracing: true } // <-- debugging purposes only
    )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
