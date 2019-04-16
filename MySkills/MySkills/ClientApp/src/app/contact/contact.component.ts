import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { ContactService } from '../core/services/contact.service';
@Component({
    selector: 'contact',
    templateUrl: './contact.component.html',
    styleUrls: ['./contact.component.css']
})

export class ContactComponent {

    formdata;

    constructor(private _contactService: ContactService) { }

    ngOnInit() {
        this.formdata = new FormGroup({
            contact_name: new FormControl("", [Validators.required, this.noWhitespaceValidator,
             Validators.minLength(1)]),
            contact_object: new FormControl("", [Validators.required, this.noWhitespaceValidator,
            Validators.maxLength(400), Validators.minLength(1)]),
            contact_message: new FormControl("", [Validators.required, this.noWhitespaceValidator,
            Validators.maxLength(400), Validators.minLength(5)]),
        });

    }
   
    on_submit(contact: any) {

        this._contactService.save(contact.contact_name, contact.contact_object, contact.contact_message);
    }
    public noWhitespaceValidator(control: FormControl) {
        const isWhitespace = (control.value || '').trim().length === 0;
        const isValid = !isWhitespace;
        return isValid ? null : { 'whitespace': true };
    }

}
