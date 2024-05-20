import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Servicio } from '../../models/servicio';
import { ServicioService } from './../../services/servicio.service';
import { CommonModule } from '@angular/common';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { BsModalService, BsModalRef, ModalOptions } from 'ngx-bootstrap/modal';
import { ServicesFormComponent } from './services-form/services-form.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css'],
  standalone: true,
  providers: [ServicioService, BsModalService],
  imports: [CommonModule]
})
export class ServicesComponent implements OnInit {
  hoveredIndex: number | null = null;
  public bsModalRef?: BsModalRef;
  isAuthenticated: boolean = false;
  @ViewChild('editServiceModal') editServiceModal: NgbModalRef; // Referencia al modal de edición

  services: Servicio[] = [];

  constructor(private servicioService: ServicioService,
    private modalService: BsModalService
  ) { }

  ngOnInit() {
    this.servicioService.getServiciosList().subscribe((data) => {
      this.services = data;
      localStorage.getItem('token') === 'valid' ? this.isAuthenticated = true : this.isAuthenticated = false;
    });
  }

  onMouseEnter(index: number): void {
    this.hoveredIndex = index;
  }

  onMouseLeave(): void {
    this.hoveredIndex = null;
  }

  editService(service: Servicio): void {
    // Implementa la lógica para editar el servicio aquí
    this.openFormModal('Editar', service.idServicio);
  }

  addService(): void {
    this.openFormModal('Agregar');
  }

  deleteService(service: Servicio): void {
    // Implementa la lógica para eliminar el servicio aquí
    const confirmDelete = window.confirm('¿Estás seguro de que deseas eliminar este servicio?');
    // Si el usuario confirma la eliminación, procede a eliminar el servicio
    if (confirmDelete) {
      // Aquí puedes implementar la lógica para eliminar el servicio
      console.log('Eliminar servicio:', service);
      this.servicioService.deleteServicios(service.idServicio).subscribe((data) => {
        this.servicioService.getServiciosList().subscribe((data) => {
          this.services = data;
        });
      });
    }
  }

  openFormModal(action?: string, idService?: number) {
    const initialState: ModalOptions = {
      initialState: {
        action: action,
        idService: idService,
      },
      class: 'modal-position-center'
    };
    this.bsModalRef = this.modalService.show(ServicesFormComponent,  initialState);

    this.bsModalRef.content.onClose.subscribe((close: boolean) => {
      if (close) {
        this.servicioService.getServiciosList().subscribe((data) => {
          this.services = data;
        });
      }
      this.bsModalRef!.hide();
    });
  }
}
