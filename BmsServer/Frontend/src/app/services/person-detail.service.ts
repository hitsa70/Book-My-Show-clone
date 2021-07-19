import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PersonDetailService {


  baseUrl = 'https://localhost:44350/api/';
  httpHeaders: any;

  constructor(public http: HttpClient) {
    this.httpHeaders = this.buildHttpHeaders();
  }


  ngOnInit() {

  }

  getCasts() {
    return this.http.get<any[]>(`${this.baseUrl}MovieCasts`)
  }
  getCast(id: any) {
    return this.http.get<any>(`${this.baseUrl}MovieCasts/${id}`);
  }

  getCrews() {
    return this.http.get<any[]>(`${this.baseUrl}MovieCrews`)
  }
  getCrew(id: any) {
    return this.http.get<any>(`${this.baseUrl}MovieCrews/${id}`);
  }



  private buildHttpHeaders() {
    const headers: { [name: string]: string } = {};
    headers['Content-Type'] = 'application/json; charset=utf-8';
    headers['X-Requested-With'] = 'XMLHttpRequest';
    return new HttpHeaders(headers);
  }

}
