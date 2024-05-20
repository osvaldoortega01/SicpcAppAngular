import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  readonly apiUrl = 'https://localhost:44310/api/';

constructor(private http: HttpClient) { }
  
  // Clientes
  getClientesList(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.apiUrl + 'cliente');
  }

  addClientes(cliente: Cliente): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Cliente>(this.apiUrl + 'cliente', cliente, httpOptions);
  }

  updateClientes(cliente: Cliente): Observable<Cliente> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Cliente>(this.apiUrl + 'cliente', cliente, httpOptions);
  }

  deleteClientes(idCliente: number): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.apiUrl + 'cliente' + idCliente, httpOptions);
  }

}