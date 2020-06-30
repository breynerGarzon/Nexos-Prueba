import { Component, OnInit, Input } from '@angular/core';
import { PacientesService } from '../services/pacientes.service';
import { Paciente } from '../models/Paciente';
import { DoctorSelect } from '../models/DoctorSelect';
import { DoctorPaciente } from '../models/DoctorPaciente';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DoctorParaTabla } from '../models/DoctorParaTabla';

@Component({
  selector: 'app-paciente',
  templateUrl: './paciente.component.html',
  styleUrls: ['./paciente.component.css'],
})
export class PacienteComponent implements OnInit {
  @Input() TipoApertura;
  @Input() NombresUser;
  @Input() PacienteActual: Paciente;
  @Input() Cerrar: Function;
  @Input() Actualizar: Function;


  SeHaCreadoOEditado:boolean=true;
  MensajeVacio: string = '';
  NumeroVacio: Number = 0;
  CamposInvalidos: Boolean = true;
  NuevoDoctor: DoctorSelect;

  nuevoPacienteTemp: Paciente;
  Campos = [
    { Descripcion: 'nombres', Tipo: 'Text', Valor: this.MensajeVacio },
    { Descripcion: 'apellidos', Tipo: 'Text', Valor: this.MensajeVacio },
    { Descripcion: 'seguroSocial', Tipo: 'Text', Valor: this.MensajeVacio },
    { Descripcion: 'codigoPostal', Tipo: 'Text', Valor: this.MensajeVacio },
    { Descripcion: 'telefono', Tipo: 'number', Valor: this.NumeroVacio },
  ];

  ObtenerDoctorSeleccionadoParaRemover: Function;

  constructor(
    public servicioPacientes: PacientesService,
    public _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.Campos[0].Valor = this.PacienteActual.nombres;
    this.Campos[1].Valor = this.PacienteActual.apellidos;
    this.Campos[2].Valor = this.PacienteActual.seguroSocial;
    this.Campos[3].Valor = this.PacienteActual.codigoPostal;
    this.Campos[4].Valor = this.PacienteActual.telefono;
    this.nuevoPacienteTemp = this.PacienteActual;
    this.ValidarCampos();
  }


  Guardar() {
    if (this.TipoApertura==="Crear Paciente") {
      this.CrearPaciente();
    }else{
      this.EditarPaciente();
    }
  }


  CrearPaciente(){
    let mensajeNotificacion: string = '';
    let TipoNotificacion: string = '';
    this.servicioPacientes.AñadirPaciente(this.nuevoPacienteTemp).subscribe(
      (respuesta) => {
        if (respuesta.statusCode === 201) {
          this.nuevoPacienteTemp.id = Number(respuesta.objeto);
          this.SeHaCreadoOEditado=false;
          this.Actualizar();
          mensajeNotificacion =
            'El paciente ' +
            this.nuevoPacienteTemp.nombres +
            ' ' +
            this.nuevoPacienteTemp.apellidos +
            ' ha sido agregado.';
          TipoNotificacion = 'Registrado';
        } else {
          mensajeNotificacion =
            'Se generó un error al intentar registrar al paciente ' +
            this.nuevoPacienteTemp.nombres +
            ' ' +
            this.nuevoPacienteTemp.apellidos +
            ', intente nuevamente';
          TipoNotificacion = 'Error al registrar';
        }
        this.HabilitarNotificacion(mensajeNotificacion, TipoNotificacion);
      },
      (error) => {
        console.log('Usuario error');
        console.log(error);
      }
    );
  }

  EditarPaciente(){
    let mensajeNotificacion: string = '';
    let TipoNotificacion: string = '';
    this.servicioPacientes.EditarPaciente(this.nuevoPacienteTemp).subscribe(
      (respuesta) => {
        if (respuesta.statusCode === 200) {
          this.nuevoPacienteTemp.id = Number(respuesta.objeto);
          this.SeHaCreadoOEditado=false;
          this.Actualizar();
          mensajeNotificacion =
            'El paciente ' +
            this.nuevoPacienteTemp.nombres +
            ' ' +
            this.nuevoPacienteTemp.apellidos +
            ' ha sido editado.';
          TipoNotificacion = 'Editado';
        } else {
          mensajeNotificacion =
            'Se generó un error al intentar registrar al paciente ' +
            this.nuevoPacienteTemp.nombres +
            ' ' +
            this.nuevoPacienteTemp.apellidos +
            ', intente nuevamente';
          TipoNotificacion = 'Error al registrar';
        }
        this.HabilitarNotificacion(mensajeNotificacion, TipoNotificacion);
      },
      (error) => {
        console.log('Usuario error');
        console.log(error);
      }
    );
  }

  HabilitarNotificacion(Mensaje: string, Tipo: string) {
    this._snackBar.open(Mensaje, Tipo, {
      duration: 5000,
    });
  }

  CambioElemento(event: any) {
    this.nuevoPacienteTemp[event.target.id] = event.target.value;
    this.ValidarCampos();
  }

  ValidarCampos() {
    if (
      this.nuevoPacienteTemp.nombres === '' ||
      this.nuevoPacienteTemp.nombres === undefined
    ) {
      this.CamposInvalidos = true;
      return;
    }

    if (
      this.nuevoPacienteTemp.apellidos === '' ||
      this.nuevoPacienteTemp.apellidos === undefined
    ) {
      this.CamposInvalidos = true;
      return;
    }

    if (
      this.nuevoPacienteTemp.seguroSocial === '' ||
      this.nuevoPacienteTemp.seguroSocial === undefined
    ) {
      this.CamposInvalidos = true;
      return;
    }

    if (
      this.nuevoPacienteTemp.codigoPostal === '' ||
      this.nuevoPacienteTemp.codigoPostal === undefined
    ) {
      this.CamposInvalidos = true;
      return;
    }

    if (
      this.nuevoPacienteTemp.telefono === 0 ||
      this.nuevoPacienteTemp.telefono.toString() === '' ||
      this.nuevoPacienteTemp.telefono === undefined
    ) {
      this.CamposInvalidos = true;
      return;
    }
    this.CamposInvalidos = false;
    return;
  }

  CerrarComponente() {
    this.Cerrar();
  }
}
