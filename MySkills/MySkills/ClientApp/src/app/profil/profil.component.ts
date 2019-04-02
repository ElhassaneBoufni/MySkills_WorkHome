import { Component, OnInit } from '@angular/core';
import { Note } from '../_interfaces/note.model';
import { RepositoryService } from '../shared/services/repository.service';

@Component({
    selector: 'profil',
    templateUrl: './profil.component.html',
    styleUrls: ['./profil.component.css']
})

    

export class ProfilComponent implements OnInit {
    public notes: Note[];

    constructor(private repository: RepositoryService) { }

    ngOnInit() {
        this.getAllNotes();
    }

    public getAllNotes() {
        let apiAddress: string = "api/notes/getall" ;
        this.repository.getData(apiAddress)
            .subscribe(res => {
                this.notes = res as Note[];
            })
    }
}