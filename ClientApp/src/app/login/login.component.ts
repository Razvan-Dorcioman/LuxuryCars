import { Component, OnInit } from '@angular/core';
import { DatabaseService } from '../services/database.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {

    constructor(private data: DatabaseService) {
    }

    errorMessage: string = "";
    public creds = {
        username: "",
        password: ""
    };

    ngOnInit() {
        
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
