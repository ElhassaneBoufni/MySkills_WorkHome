import {Component, OnInit} from '@angular/core';
import { FaqService } from '../core/services/faq.service';
import { MatDialog } from '@angular/material';
import { Faq } from '../core/models/faq.model';

@Component({
    selector: 'faq',
    templateUrl: './faq.component.html',
    styleUrls: ['./faq.component.css']
})
export class FaqComponent implements OnInit{

 

    ngOnInit() {
    }

    constructor(private _faqService: FaqService, private dialog: MatDialog) {

    }

    get _Faq(): Faq[] {
        return this._faqService.Faq;
    }

    
}
