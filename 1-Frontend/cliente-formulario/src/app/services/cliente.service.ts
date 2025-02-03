import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponseModel } from '../models/cliente.model';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private apiUrlCreate = 'https://localhost:7114/Cliente/Create';
  private apiUrlGetAll  = 'https://localhost:7114/Cliente/Get';
  private apiUrlDelete  = 'https://localhost:7114/Cliente/Delete';

  constructor(private http: HttpClient) {}

  cadastrarCliente(cliente: any): Observable<any> {
    return this.http.post<any>(this.apiUrlCreate, cliente);
  }

  listarClientes(): Observable<ApiResponseModel> {
    return this.http.get<ApiResponseModel>(this.apiUrlGetAll);
  }

  excluirCliente(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrlDelete}/${id}`);
  }
}