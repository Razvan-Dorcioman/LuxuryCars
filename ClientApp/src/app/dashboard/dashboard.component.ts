import { Component, OnInit } from '@angular/core';
import { DatabaseService } from '../services/database.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

    public users

    constructor(private data: DatabaseService, private route: Router, private activatedRouter: ActivatedRoute) {
        //this.products = data.products;
    }

    ngOnInit() {
        //this.data.getAllUsers()
        //    .subscribe(success => {
        //        if (success) {
        //            this.users = this.data.users;
        //            console.log(this.users)
        //        }
        //    });
    }
}
