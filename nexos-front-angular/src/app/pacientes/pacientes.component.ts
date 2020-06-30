import { Component, OnInit } from '@angular/core';
import { PacientesService } from '../services/pacientes.service';
import { Paciente } from '../models/Paciente';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-pacientes',
  templateUrl: './pacientes.component.html',
  styleUrls: ['./pacientes.component.css'],
})
export class PacientesComponent implements OnInit {
  Crear: Boolean = false;
  Editar: Boolean = false;
  Nombres = '';
  MensajeApertura: string = '';
  PacienteActual: Paciente;
  PacienteNuevo: Paciente = {
    id: 0,
    nombres: '',
    apellidos: '',
    seguroSocial: '',
    codigoPostal: '',
    telefono: 0,
  };

  displayedColumns: string[] = [
    'Nombres',
    'Apellidos',
    'SeguroSocial',
    'CodigoPostal',
    'Acciones',
  ];
  public ActualizacionCallBack: Function;
  public CerrarCallBack: Function;

  Pacientes: Paciente[] = [];
  constructor(
    public servicioPacientes: PacientesService,
    public _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.servicioPacientes.ObtenerPacientes().subscribe(
      (respuesta) => {
        if (respuesta.statusCode === 200) {
          this.Pacientes = respuesta.data;
          this.ActualizacionCallBack = this.ActualizarListaPacientes.bind(this);
          this.CerrarCallBack = this.CerrarComponente.bind(this);
        } else {
          this.HabilitarNotificacion(
            'Se ha generado un error al consultar, intente nuevamente',
            'Error al consultar'
          );
        }
      },
      (falla) => {
        this.HabilitarNotificacion(
          'No se ha encontrado el servicio, intente nuevamente',
          'Error al consultar'
        );
        console.log(falla);
      }
    );
  }

  CrearUsuario() {

    this.MensajeApertura = 'Crear Paciente';
    this.Crear = !this.Crear;
  }

  EditarUsuario() {
    this.Editar = !this.Editar;
    this.MensajeApertura = 'Editar Paciente';
  }

  EliminarPaciente(EliminarPaciente: Paciente) {
    let mensajeNotificacion: string = '';
    let TipoNotificacion: string = '';
    this.servicioPacientes
      .ObtenerEliminarPaciente(EliminarPaciente.id)
      .subscribe(
        (respuesta) => {
          if (respuesta.statusCode === 200) {
            const pacienteActuales = this.Pacientes.filter(
              (item) => item.id !== EliminarPaciente.id
            );
            this.Pacientes = pacienteActuales;
            mensajeNotificacion =
              'El paciente ' +
              EliminarPaciente.nombres +
              ' ' +
              EliminarPaciente.apellidos +
              ' ha sido eliminado.';
            TipoNotificacion = 'Eliminado';
          } else {
            mensajeNotificacion =
              'Se generó un error al intentar eliminar al paciente ' +
              EliminarPaciente.nombres +
              ' ' +
              EliminarPaciente.apellidos +
              ', intente nuevamente';
            TipoNotificacion = 'Error Eliminado';
          }
          this.HabilitarNotificacion(mensajeNotificacion, TipoNotificacion);
        },
        (falla) => {
          console.log(falla);
        }
      );
  }

  HabilitarNotificacion(Mensaje: string, Tipo: string) {
    this._snackBar.open(Mensaje, Tipo, {
      duration: 5000,
    });
  }

  EditarPaciente(EditarPaciente) {
    console.log(EditarPaciente);

    this.PacienteActual = EditarPaciente;
    this.Nombres = EditarPaciente.Nombres;
    this.Editar = !this.Editar;
    this.MensajeApertura = 'Editar Paciente';
  }

  ActualizarListaPacientes() {
    this.ngOnInit();
  }

  CerrarComponente() {
    this.PacienteNuevo = {
      id: 0,
      nombres: '',
      apellidos: '',
      seguroSocial: '',
      codigoPostal: '',
      telefono: 0,
    };
    this.Crear = false;
    this.Editar = false;
  }
}
