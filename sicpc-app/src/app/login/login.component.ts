import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginService } from '../../services/login.service';
import { lastValueFrom } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule],
  providers: [LoginService]
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private loginService: LoginService,
    private router: Router
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      correo: ['', [Validators.required, Validators.email]],
      contrasena: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      // Aquí iría la lógica para enviar los datos del formulario al servidor
      this.loginRequest();
    }
  }

  loginRequest(){
    lastValueFrom(this.loginService.login(this.loginForm.value)).then((data) => {
      window.location.pathname = '/usuarios';
      localStorage.setItem('token', 'valid');
    })
    .catch((error) => {
      console.log(error);
      alert(error.error);
    });
  }
}
