import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../models/usuario';
import { UsuarioService } from '../../services/usuario.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { UsuariosFormComponent } from './usuarios-form/usuarios-form.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css'],
  standalone: true,
  providers: [UsuarioService, BsModalService],
  imports: [CommonModule, HttpClientModule, FormsModule]
})
export class UsuariosComponent implements OnInit {
  users: Usuario[] = [];

  public bsModalRef?: BsModalRef;

  isAuthenticated: boolean = false;

  constructor(private userService: UsuarioService,
    private modalService: BsModalService,
    private route: Router
  ) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') === 'valid') {
      this.isAuthenticated = true;
    }
    else{
      this.route.navigate(['/login']);
    }
    this.loadUsuarios();
  }

  loadUsuarios(): void {
    this.userService.getUsuariosList().subscribe(users => {
      this.users = users;
    });
  }

  editUsuario(usuario: Usuario): void {
    // Implementa la lógica para editar el servicio aquí
    this.openFormModal('Editar', usuario.idUsuario);
  }

  addUsuario(): void {
    this.openFormModal('Agregar');
  }

  deleteUsuario(user: Usuario): void {
    const confirmDelete = window.confirm('¿Estás seguro de que deseas eliminar este usuario?');
    if (!confirmDelete) {
      return;
    }
    this.userService.deleteUsuarios(user.idUsuario).subscribe(() => {
      this.loadUsuarios();
    });
  }


  openFormModal(action?: string, idUsuario?: number) {
    const initialState: ModalOptions = {
      initialState: {
        action: action,
        idUsuario: idUsuario,
      },
      class: 'modal-xl modal-position-center'
    };
    this.bsModalRef = this.modalService.show(UsuariosFormComponent,  initialState);

    this.bsModalRef.content.onClose.subscribe((close: boolean) => {
      if (close) {
        this.loadUsuarios();
      }
      this.bsModalRef!.hide();
    });
  }
}
