import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ProfilComponent} from './profil.component';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        ProfilComponent
    ],
    exports: [
        ProfilComponent
    ]
})
export class ProfilModule {}
