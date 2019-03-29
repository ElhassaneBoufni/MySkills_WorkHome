import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'compETcertif',
    templateUrl: './compETcertif.component.html',
    styleUrls: ['./compETcertif.component.css']
})
export class CompETcertifComponent implements OnInit {

    navLinks: any[];
    activeLinkIndex = -1;

    constructor(private router: Router) {
        this.navLinks = [
            {
                label: 'Technique',
                link: './competenceView',
                index: 0
            }, {
                label: 'Management & Support',
                link: './managAndSupp',
                index: 1
            }, {
                label: 'Soft Skills',
                link: './',
                index: 2
            },
            {
                label: 'Certification',
                link: './certifView',
                index: 3
            }
        ];
    }

    ngOnInit(): void {
        this.router.events.subscribe((res) => {
            this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));
        });
    }
}