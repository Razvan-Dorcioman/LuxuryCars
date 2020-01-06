import { Component, OnInit } from '@angular/core';
import { Product } from '../services/product.service';
import { DatabaseService } from '../services/database.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    public products: Product[];

    constructor(private data: DatabaseService) {
        //this.products = data.products;
    }

    ngOnInit() {
        
    }

}
