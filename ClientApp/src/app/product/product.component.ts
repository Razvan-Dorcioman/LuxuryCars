import { Component, OnInit } from '@angular/core';
import { Product } from '../services/product.service';
import { DatabaseService } from '../services/database.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
    public id
    public product;

    constructor(private data: DatabaseService, private route: Router, private activatedRouter: ActivatedRoute) {
        //this.products = data.products;
    }

    ngOnInit() {
        this.id = this.activatedRouter.snapshot.paramMap.get('id');
        this.data.getProductById(this.id)
            .subscribe(success => {
                if (success) {
                    this.product = this.data.product;
                    console.log(this.product)
                }
            });
    }

}
