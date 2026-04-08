import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Httpcall {
  constructor(public httpClient: HttpClient) {  }
  apiUrl: string = "http://localhost:62430";
  logged:boolean=false;

  postCall(endPoint:string, params:{}) : Observable<any> {
    console.log(this.apiUrl+endPoint);
    return this.httpClient.post<any[]>(this.apiUrl+endPoint,params,{ withCredentials: true });
  }

  getCall(endPoint:string,token:string | null){
    console.log(`In get call: ${token}`);
    return this.httpClient.get<any[]>(this.apiUrl+endPoint, {headers: { Authorization: `Bearer ${token}` }});
  }
}
