import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../material.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProfilComponent } from './profil/profil.component';
import { ContactComponent } from './contact/contact.component';
import { FaqComponent } from './faq/faq.component';
import { ErrorComponent } from './error/error.component';
import { CompETcertifModule } from './compETcertif';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AngularEditorModule } from '@kolkov/angular-editor';




import { NgxEditorModule } from 'ngx-editor';

import { AngularFontAwesomeModule } from 'angular-font-awesome';





@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProfilComponent,
    ContactComponent,
    FaqComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    AngularEditorModule,
    NgxEditorModule,
    AngularFontAwesomeModule,
    MDBBootstrapModule.forRoot()
  ],
    providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
