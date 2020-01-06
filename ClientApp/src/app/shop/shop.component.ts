import { Component, OnInit } from '@angular/core';
import { Product } from '../services/product.service';
import { DatabaseService } from '../services/database.service';

@Component({
    selector: 'app-shop',
    templateUrl: './shop.component.html',
    styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

    public products: Product[];

    constructor(private data: DatabaseService) {
        //this.products = data.products;
    }

    ngOnInit() {
        this.data.loadProducts()
            .subscribe(success => {
                if (success) {
                    this.products = this.data.products;
                }
            });
    }

}
