import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  readonly apiUrl = 'https://localhost:44310/api/usuario';

constructor(private http: HttpClient) { }
  
  
getUsuariosList(): Observable<any[]> {
  return this.http.get<Usuario[]>(this.apiUrl);
}

getUsuario(idUsuario: number): Observable<Usuario> {
  return this.http.get<Usuario>(this.apiUrl + '/' + idUsuario);
}

addUsuarios(usuario: Usuario): Observable<any> {
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
  return this.http.post<Usuario>(this.apiUrl, usuario, httpOptions);
}

updateUsuarios(usuario: Usuario): Observable<Usuario> {
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
  return this.http.put<Usuario>(this.apiUrl, usuario, httpOptions);
}

deleteUsuarios(idusuario: number): Observable<number> {
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
  return this.http.delete<number>(`${this.apiUrl}/${idusuario}`, httpOptions);
}

}
