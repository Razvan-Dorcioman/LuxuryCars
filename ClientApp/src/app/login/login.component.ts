import { Component, OnInit } from '@angular/core';
import { DatabaseService } from '../services/database.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {

    constructor(private data: DatabaseService, private router: Router) { }

    errorMessage: string = "";
    public creds = {
        email: "",
        password: "",
        rememberMe: false
    };

    onLogin() {
        this.errorMessage = "";
        this.data.login(this.creds)
            .subscribe(success => {
                if (success) {
                    this.router.navigate([""]);
                }
            }, err => this.errorMessage = "Invalid credentials " + err);
    }

//    onLogin() {
//        this.errorMessage = "";
//       this.data.login(this.creds)
//            .subscribe(success => {
//                if (success) {
//                    this.router.navigate([""]);
//                }
//            }, err => this.errorMessage = "Invalid credentials " + err);
//    }
}
