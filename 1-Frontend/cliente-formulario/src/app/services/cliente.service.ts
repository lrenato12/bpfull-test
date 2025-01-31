import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private apiUrl = 'https://localhost:7114/Cliente/Create';

  constructor(private http: HttpClient) {}

  cadastrarCliente(cliente: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, cliente);
  }
}