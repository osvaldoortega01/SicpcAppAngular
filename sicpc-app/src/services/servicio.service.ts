import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Servicio } from '../models/servicio';

@Injectable({
  providedIn: 'root'
})
export class ServicioService {
  readonly apiUrl = 'https://localhost:44310/api/';

constructor(private http: HttpClient) { }
  
  // Servicios
  getServiciosList(): Observable<Servicio[]> {
    return this.http.get<Servicio[]>(this.apiUrl + 'servicio');
  }
  
  getServicio(idService: number): Observable<Servicio> {
    return this.http.get<Servicio>(this.apiUrl + 'servicio/' + idService);
  }

  addServicios(cliente: Servicio): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Servicio>(this.apiUrl + 'servicio', cliente, httpOptions);
  }

  updateServicios(cliente: Servicio): Observable<Servicio> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Servicio>(this.apiUrl + 'servicio', cliente, httpOptions);
  }

  deleteServicios(idServicio: number): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.apiUrl + 'servicio/' + idServicio, httpOptions);
  }

}