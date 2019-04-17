import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompETcertifService } from './services/comp-etcertif.service';
import { ContactService } from './services/contact.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    CompETcertifService,
    ContactService
  ]
})
export class CoreModule { }
