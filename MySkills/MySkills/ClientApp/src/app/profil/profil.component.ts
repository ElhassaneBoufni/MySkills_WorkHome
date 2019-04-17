
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

import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Chart } from 'chart.js';

import * as jspdf from 'jspdf';

import html2canvas from 'html2canvas'; 

@Component({
    selector: 'profil',
    templateUrl: './profil.component.html',
    styleUrls: ['./profil.component.css']
})
export class ProfilComponent implements OnInit{

    @ViewChild('content') content: ElementRef;
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
    collabs = [];

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

    DoughnutChart = [];

    ngOnInit() {
        this.DoughnutChart = new Chart('doughnutChart', {
            type: 'doughnut',
            data: {
                labels: ["JAVA", ".NET", "ASP.NET", "C#", "PHP", "DRUPAL"],
                datasets: [{
                    label: '# of Votes',
                    data: [9, 7, 3, 5, 2, 10],
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                
                segmentShowStroke: true,
                segmentStrokeColor: "#fff",
                segmentStrokeWidth: 2,
                percentageInnerCutout: 50,
                animationSteps: 100,
                animationEasing: "easeOutBounce",
                animateRotate: true,
                animateScale: false,
                responsive: true,
                maintainAspectRatio: true,
                showScale: true
                
            }
        });

    }

    public captureScreen() {
        var data = document.getElementById('convert');
        html2canvas(data).then(canvas => {
            var imgWidth = 208;
            var pageHeight = 295;
            var imgHeight = canvas.height * imgWidth / canvas.width;
            var heightLeft = imgHeight;
            const contentDataURL = canvas.toDataURL('image/png')
            let pdf = new jspdf('p', 'mm', 'a4');
            var position = 0;
            pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight)
            pdf.save('MYPdf.pdf')
        });
    }


}

