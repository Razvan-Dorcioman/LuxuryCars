import { Component, OnInit } from '@angular/core';
import { DatabaseService } from '../services/database.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent {

    constructor(private data: DatabaseService, private router: Router) { }

    errorMessage: string = "";
    public creds = {
        username: "",
        password: "",
        email: "",
        confirmPassword: ""
    };

    onRegister() {
        this.errorMessage = "";
        this.data.register(this.creds)
            .subscribe(success => {
                if (success) {
                    this.router.navigate([""]);
                }
            }, err => this.errorMessage = "Invalid credentials")
    }
}
