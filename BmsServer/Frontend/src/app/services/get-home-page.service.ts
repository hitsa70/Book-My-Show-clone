import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GetHomePageService {

  baseUrl = 'https://localhost:44350/dapper/';
  httpHeaders: any;


  constructor(public http: HttpClient) {
    this.httpHeaders = this.buildHttpHeaders();
  }

  ngOnInit() {

  }

  getMovies() {
    return this.http.get<any[]>(`${this.baseUrl}movie`);
    console.log(`${this.baseUrl}dapper/movie`);
  }
  getMovie(id: any) {
    return this.http.get<any>(`${this.baseUrl}movie/${id}`);
  }

  private buildHttpHeaders() {
    const headers: { [name: string]: string } = {};
    headers['Content-Type'] = 'application/json; charset=utf-8';
    headers['X-Requested-With'] = 'XMLHttpRequest';
    return new HttpHeaders(headers);
  }
}
