import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProfilComponent } from './profil/profil.component';
import { ContactComponent } from './contact/contact.component';
import { FaqComponent } from './faq/faq.component';
import { ErrorComponent } from './error/error.component';
import { CompETcertifModule } from './compETcertif';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'compETcertif', loadChildren: () => CompETcertifModule },
  { path: 'profil', component: ProfilComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'faq', component: FaqComponent },
  { path: 'not-found', component: ErrorComponent },
  { path: '**', redirectTo: '/not-found' }

];

@NgModule({
  imports: [
    RouterModule.forRoot(routes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
