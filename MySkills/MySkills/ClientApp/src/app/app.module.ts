import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatToolbarModule, MatCardModule } from '@angular/material';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { CompETcertifComponent } from './compETcertif/compETcertif.component';
import { ProfilComponent } from './profil/profil.component';
import { ContactComponent } from './contact/contact.component';
import { FaqComponent } from './faq/faq.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MDBBootstrapModule } from 'angular-bootstrap-md';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CompETcertifComponent,
    ProfilComponent,
    ContactComponent,
    FaqComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    MatToolbarModule,
    MatCardModule,
    MDBBootstrapModule.forRoot(),
    FormsModule,
    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      
      { path: 'compETcertif', component: CompETcertifComponent },
      { path: 'profil', component: ProfilComponent },
      { path: 'contact', component: ContactComponent },
      { path: 'faq', component: FaqComponent },


    ]),
    BrowserAnimationsModule
    ],
    schemas: [NO_ERRORS_SCHEMA ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
