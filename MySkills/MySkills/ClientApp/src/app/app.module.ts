import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../material.module';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CompETcertifComponent } from './compETcertif/compETcertif.component';
import { ProfilComponent } from './profil/profil.component';
import { ContactComponent } from './contact/contact.component';
import { FaqComponent } from './faq/faq.component';
import { ErrorComponent } from './error/error.component';
import { CompETcertifModule } from './compETcertif';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CompETcertifComponent,
    ProfilComponent,
    ContactComponent,
    FaqComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),     
    AppRoutingModule,
    HttpClientModule,
    FormsModule,   
    BrowserAnimationsModule,    
    MaterialModule,
    ReactiveFormsModule,
    CompETcertifModule // <== error
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
