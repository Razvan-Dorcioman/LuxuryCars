import { Component, OnInit } from '@angular/core';
import { DatabaseService } from '../services/database.service';
import { Product } from '../services/product.service';
import { Router } from '@angular/router';
import { ProductComponent } from '../product/product.component';

@Component({
    selector: 'app-sell-car',
    templateUrl: './sell-car.component.html',
    styleUrls: ['./sell-car.component.css']
})
export class SellCarComponent {

    public product = {
    id: 0,
    model: "",
    brand: "",
    price: 0,
    title: "",
    description: "",
    engine: "",
    fuelType: "",
    horsePower: 0,
    km: 0,
        manufactoring: null,
        username: this.data.userName
}

    errorMessage: string = ""

    constructor(private data: DatabaseService, private router: Router) {
    }

    onPostCar() {
        this.errorMessage = "";
        this.data.postProduct(this.product)
            .subscribe(success => {
                if (success) {
                    this.router.navigate([""]);
                }
            }, err => this.errorMessage = "Cannot post the product")
    }
}
