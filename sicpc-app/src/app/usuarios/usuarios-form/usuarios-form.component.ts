import { Component, Input, OnInit, input } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Subject } from 'rxjs';
import { UsuarioService } from '../../../services/usuario.service';
import { HttpClientModule } from '@angular/common/http';
import { Usuario } from '../../../models/usuario';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-usuarios-form',
  templateUrl: './usuarios-form.component.html',
  styleUrls: ['./usuarios-form.component.css'],
  standalone: true,
  providers: [UsuarioService,],
  imports: [HttpClientModule, ReactiveFormsModule, FormsModule, CommonModule]
})
export class UsuariosFormComponent implements OnInit {

  usuarioForm: FormGroup;
  onClose: Subject<boolean> = new Subject<boolean>();
  submitted: boolean = false;
  @Input() action: string;
  @Input() idUsuario: number;
  constructor(private formBuilder: FormBuilder, private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.initForm();
    if(this.action === 'Editar') {
      this.usuarioService.getUsuario(this.idUsuario).subscribe((data) => {
        this.usuarioForm.patchValue({
          nombreCompleto: data.nombreCompleto,
          correo: data.correo,
          username: data.username,
          contrasena: data.contrasena,
          telefonomovil: data.telefonoMovil
        });
      });
    }
  }

  initForm(): void {
    this.usuarioForm = this.formBuilder.group({
      nombreCompleto: ['', Validators.required],
      correo: ['', [Validators.required, Validators.email]],
      username: ['', Validators.required],
      contrasena: ['', [Validators.required, Validators.minLength(6)]],
      telefonomovil: ['', Validators.required]
    });
  }

  saveUsuario(): void {
    console.log(this.usuarioForm);
    if (this.usuarioForm.valid) {
      const usuarioData: Usuario = this.usuarioForm.value;
      this.action === 'Editar' ? this.updateUsuario(usuarioData) : this.addUsuario(usuarioData);
    }
  }

  
  addUsuario(usuario: Usuario): void {
    this.usuarioService.addUsuarios(usuario).subscribe(() => {
      this,this.submitted = true;
      this.onClose.next(true);
    });
  }

  updateUsuario(usuario: Usuario): void {
    usuario.idUsuario = this.idUsuario;
    this.usuarioService.updateUsuarios(usuario).subscribe(() => {
      this,this.submitted = true;
      this.onClose.next(true);
    });
  }
}
