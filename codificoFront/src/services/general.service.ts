import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from "../environments/environment";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  private url = environment.url;
  constructor(private http: HttpClient) { }

  public get (endpoint: any){
    return this.http.get(`${this.url}${endpoint}`);
  }
  public getById (endpoint: any, id:any){
    return this.http.get(`${this.url}${endpoint}?cliente=${id}`);
  }

  public post(endpoint: any,parameters: any) {
   return this.http.post(`${this.url}${endpoint}`,parameters, );
 }


}
