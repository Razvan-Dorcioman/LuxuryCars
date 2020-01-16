import { HttpClient, HttpResponse, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs"
import { Product } from "./product.service";
//import 'rxjs/add/operator/map';
//import 'rxjs/Rx';
import { CookieService } from "ngx-cookie-service";
import { map, retry } from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class DatabaseService {

    public id: string = '';
    public userName: string = '';

    public loggedInUser = null;
    
    public user = {};
    public basic = '';

    constructor(private http: HttpClient, private cookie: CookieService) {
    }

    public products: Product[] = [];
    public product = {};
    public users = [];



    loadProducts(): Observable<boolean> {
        return this.http.get("/api/products")
            .pipe(
                map((data: any[]) => {
                    this.products = data;
                    return true;
                }));
    }

    public get loginRequired(): boolean {
        let tokenExpiration = new Date(this.cookie.get('tokenExpiration'));
        let token = this.cookie.get('token');
        return token.length == 0 || tokenExpiration < new Date();
    }

    login(creds): Observable<boolean> {
        const hack = this.cookie;
        return this.http
            .post("/account/createtoken", creds).pipe(
            map((data: any) => {
                if (creds.rememberMe) {
                    hack.set('id', data.user.id);
                    hack.set('token', data.token);
                    hack.set('tokenExpiration', data.expiration);
                }
                else {
                    hack.set('id', data.user.id, 1);
                    hack.set('token', data.token, 1);
                    hack.set('tokenExpiration', data.expiration, 1);
                }

                this.loggedInUser = data.user;
                return true;
            }));
    }

    register(creds) {
        return this.http
            .post("/account/register", creds);
    }

    loadUserById(id) {
        let params = new HttpParams();
        params.append('id', id);
        return this.http.get("/api/users/getUserById/" + id)
            .pipe(
                map((data: any[]) => {
                    this.user = data;
                    return true;
                }));
    }

    getProductById(id): Observable<boolean> {
        return this.http.get("/api/products/getProductById/"+ id)
            .pipe(
                map((data: any[]) => {
                    this.product = data;
                    return true;
                }));
    }

    postProduct(product) {
        return this.http
            .post("/api/products/postProduct", product);
    }

    signout() {
        return this.http
            .get("/account/logout");
    }
        
}
