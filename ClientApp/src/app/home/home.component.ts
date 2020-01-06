import { Component, OnInit } from '@angular/core';
import { Product } from '../services/product.service';
import { DatabaseService } from '../services/database.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

    public products: Product[];

    public loggedUser = "Guest"

    public errMessage: String = "";

    constructor(private cookie: CookieService, public data: DatabaseService) {
    }

    ngOnInit(): void {

        this.data.id = this.cookie.get('id') || null;

        // if user is remembered aka stored in cookies, refresh his personal data in cookies an so on
        if (this.data.id != null) {

            this.data.loadUserById(this.data.id)
                .subscribe(success => {
                    if (success) {
                        this.data.loggedInUser = this.data.user;
                        this.data.userName = this.data.loggedInUser.userName || 'Guest';
                    }
                });

        } else {
            this.data.userName = 'Guest';
        }
    }

}
