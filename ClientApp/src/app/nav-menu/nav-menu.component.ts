import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { DatabaseService } from '../services/database.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
    isExpanded = false;

    constructor(private cookie: CookieService, private router: Router, public data: DatabaseService) {
    }

    ngOnInit(): void {
    }

    onSignOut() {
        this.data.signout()
            .subscribe(success => {
                if (success) {
                    this.cookie.delete('id');
                    this.cookie.delete('token');
                    this.cookie.delete('tokenExpiration');
                    this.data.loggedInUser = null;
                    this.router.navigate(["/login"]);
                }
            }, err => console.log("Error on signed out: " + err));
    }

    adminDashboard() {
        if (!this.data.loginRequired) {
            this.router.navigate(["/admin"]);
        }
        else {
            this.router.navigate(["/login"]);
        }
    }

    sellCar() {
        if (!this.data.loginRequired) {
            this.router.navigate(["/sell-car"]);
        }
        else {
            this.router.navigate(["/login"]);
        }
    }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
