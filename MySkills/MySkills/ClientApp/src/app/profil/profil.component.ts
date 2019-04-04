
/**
import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { ApiService } from './../api.service';
import { Observable } from 'rxjs/Observable';
import { interval} from 'rxjs';
import { startWith, switchMap} from 'rxjs/operators';
import 'rxjs/add/observable/interval';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/switchMap';
*/

import { Component } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'profil',
    templateUrl: './profil.component.html',
    styleUrls: ['./profil.component.css']
})
export class ProfilComponent {
    /*
    id: number;
    titre: string;
    descritpion: string;

    title = 'app';
    restItems: any = [];
    restItemsUrl = 'http://localhost:52468/api/notes/getall';

    constructor(private http: HttpClient) { }

    ngOnInit() {
        this.getRestItems();
    }

    // Read all REST Items
    getRestItems(): void {
        this.restItemsServiceGetRestItems()
            .subscribe(
                restItems => {
                    this.restItems = restItems;
                    console.log(this.restItems);
                }
            )
    }

    // Rest Items Service: Read all REST Items
    restItemsServiceGetRestItems() {
        return this.http
            .get<any[]>(this.restItemsUrl)
            .pipe(map(data => data));
    }

    /*
    constructor() { }

    ngOnInit() {
    }
    
    

    @Input() notes$: Observable<any>;
    constructor(private api: ApiService) { }
  
    ngOnInit() {
        this.notes$ = startWith(0).pipe(switchMap(() => this.api.getNotes()));
          
    }
*/


    /**
   
    private notes: Note[] = []; 

    private notesObservable: Observable<Note[]>; 

    constructor(private apiService: ApiService) {
        
        this.apiService.get_notes().subscribe((res: any[]) => {
            this.notes = res;
        });

    }
    */
    baseUrl: string = "http://localhost:3000";

    constructor(private httpClient: HttpClient) {    
        this.get_collabs();
        }

    get_collabs() {
        this.httpClient.get(this.baseUrl + '/collabs').subscribe((res: any[]) => {
            console.log(res);
            this.collabs = res;
        });
    }
    private collabs = []; 


}
    
