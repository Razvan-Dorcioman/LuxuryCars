import { HttpClient, HttpResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs"
import { map } from 'rxjs/operators';
import { Product } from "./product.service";

@Injectable({
    providedIn: 'root'
})
export class DatabaseService {

    constructor(private http: HttpClient) {
    }

    public products: Product[] = [];
    public product = {};



    loadProducts(): Observable<boolean> {
        return this.http.get("/api/products")
            .pipe(
                map((data: any[]) => {
                    this.products = data;
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

    //login(creds): Observable<boolean> {
    //    const hack = this.cookie;
    //    return this.http
    //        .post("/account/createtoken", creds)
    //        .map((data: any) => {
    //            if (creds.rememberMe) {
    //                hack.set('id', data.user.id);
    //                hack.set('token', data.token);
    //                hack.set('tokenExpiration', data.expiration);
    //            }
    //            else {
    //                hack.set('id', data.user.id, 1);
    //                hack.set('token', data.token, 1);
    //                hack.set('tokenExpiration', data.expiration, 1);
    //            }

    //            this.loggedInUser = data.user;
    //            return true;
    //        });
    //}

    register(creds) {
        return this.http
            .post("/account/register", creds);
    }
}
