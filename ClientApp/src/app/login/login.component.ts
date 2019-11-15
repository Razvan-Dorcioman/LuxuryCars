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

    ngOnInit() {
        
    }
}
