import { Component, OnInit } from '@angular/core';
import { DatabaseService } from '../services/database.service';

@Component({
    selector: 'app-sell-car',
    templateUrl: './sell-car.component.html',
    styleUrls: ['./sell-car.component.css']
})
export class SellCarComponent {



    constructor(private data: DatabaseService) {
    }

    ngOnInit() {

    }
}
