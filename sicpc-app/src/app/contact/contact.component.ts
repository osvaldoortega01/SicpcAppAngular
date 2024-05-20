import { ClienteService } from './../../services/cliente.service';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, HttpClientModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss',
  providers: [ClienteService]
})
export class ContactComponent implements OnInit{
  contactForm: FormGroup;
  submitted: boolean = false;

  constructor(private fb: FormBuilder,
    private clienteService: ClienteService,
  ) {
    this.contactForm = this.fb.group({
      nombreCompleto: ['', Validators.required],
      empresa: ['', Validators.required],
      correo: ['', [Validators.required, Validators.email]],
      telefono: ['', Validators.required],
      mensaje: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  onSubmit() {
    if (this.contactForm.valid) {
      this.sendForm();
      console.log('Formulario enviado', this.contactForm.value);
    } else {
      // Mostrar errores
      this.contactForm.markAllAsTouched();
    }
  }

  private sendForm() {
    this.clienteService.addClientes(this.contactForm.value).subscribe((data) => {
      this.contactForm.reset();
      this.submitted = true;
      console.log(data);
    });
  }
}
