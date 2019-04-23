import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompETcertifService } from './services/comp-etcertif.service';
import { FaqService } from './services/faq.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    CompETcertifService,
    FaqService
  ]
})
export class CoreModule { }
