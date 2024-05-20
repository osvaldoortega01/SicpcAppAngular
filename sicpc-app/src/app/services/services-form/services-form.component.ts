import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Subject } from 'rxjs';
import { ServicioService } from '../../../services/servicio.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { Servicio } from '../../../models/servicio';

@Component({
  selector: 'app-services-form',
  templateUrl: './services-form.component.html',
  styleUrls: ['./services-form.component.css'],
  standalone: true,
  providers: [ServicioService],
  imports: [CommonModule, HttpClientModule, ReactiveFormsModule]
})
export class ServicesFormComponent implements OnInit {
  // To handle onClose 
  public onClose: Subject<boolean> = new Subject();
  @Input() action: string;
  @Input() idService: number;
  serviceForm: FormGroup;


  constructor(private servicioService: ServicioService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.initForm();
    if (this.action === 'Editar') {
      this.servicioService.getServicio(this.idService).subscribe((data) => {
        this.serviceForm.patchValue({
          descripcionCorta: data.descripcionCorta,
          descripcionLarga: data.descripcionLarga,
          icon: data.icon // Asumiendo que 'icono' es la propiedad que contiene el ícono
          });
        });
      }
  }

  initForm() {
    this.serviceForm = this.formBuilder.group({
      descripcionCorta: ['', Validators.required],
      descripcionLarga: ['', Validators.required],
      icon: ['', Validators.required] // Agrega un control para el ícono
    });
  }

  saveService() {
    if (this.serviceForm.valid) {
      const serviceData: Servicio = this.serviceForm.value;
      // Aquí puedes enviar los datos del formulario al servidor o manejarlos como desees

      this.action === 'Editar' ? this.updateService(serviceData) : this.addService(serviceData);
      // Emitir evento para cerrar el modal
    }
  }

  addService(service: Servicio) {
    this.servicioService.addServicios(service).subscribe((data) => {
      this.onClose.next(true);

    });
  }

  updateService(service: Servicio) {
    this.servicioService.updateServicios(service).subscribe((data) => {
      this.onClose.next(true);

    });
  }

}
