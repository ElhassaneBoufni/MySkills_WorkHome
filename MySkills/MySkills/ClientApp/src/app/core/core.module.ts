import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompETcertifService } from './services/comp-etcertif.service';
import { ContactService } from './services/contact.service';
import { AspNetUsersService } from './services/aspNetUsers.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    CompETcertifService,
      ContactService,
      AspNetUsersService

  ]
})
export class CoreModule { }
