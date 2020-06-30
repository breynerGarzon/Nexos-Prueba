import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ModeloRespuesta } from '../models/ModeloRespuesta';
import { Paciente } from '../models/Paciente';
import { DoctorPaciente } from '../models/DoctorPaciente';

@Injectable({
  providedIn: 'root',
})
export class PacientesService {
  constructor(private http: HttpClient) {}

  ObtenerPacientes() {
    return this.http.get<ModeloRespuesta>(
      'http://localhost:5000/paciente/obtenerpacientes'
    );
  }

  ObtenerEliminarPaciente(IdPaciente) {
    return this.http.delete<ModeloRespuesta>(
      'http://localhost:5000/paciente/EliminarPaciente/' + IdPaciente
    );
  }

  AñadirPaciente(nuevoPaciente: Paciente) {
    const usuario =  {
      "Nombres":nuevoPaciente.nombres,
      "Apellidos":nuevoPaciente.apellidos,
      "CodigoPostal":nuevoPaciente.codigoPostal,
      "SeguroSocial":nuevoPaciente.seguroSocial,
      "Telefono":Number(nuevoPaciente.telefono),
    }
    console.log(usuario)
    return this.http.post<ModeloRespuesta>('http://localhost:5000/paciente/AgregarPaciente/',usuario);
    // return this.http.post<ModeloRespuesta>('http://localhost:5000/paciente/AgregarPaciente/',nuevoPaciente);
  }

  EditarPaciente(editarPaciente: Paciente) {
    const usuario =  {
      "Id":Number(editarPaciente.id),
      "Nombres":editarPaciente.nombres,
      "Apellidos":editarPaciente.apellidos,
      "CodigoPostal":editarPaciente.codigoPostal,
      "SeguroSocial":editarPaciente.seguroSocial,
      "Telefono":Number(editarPaciente.telefono),
    }
    console.log(usuario)
    return this.http.put<ModeloRespuesta>('http://localhost:5000/paciente/EditarPaciente/',usuario);
    // return this.http.post<ModeloRespuesta>('http://localhost:5000/paciente/AgregarPaciente/',nuevoPaciente);
  }


  AsignarDoctorPaciente(nuevoAsignacion: DoctorPaciente) {
    return this.http.post<ModeloRespuesta>('http://localhost:5000/paciente/ActualizarDoctor/',nuevoAsignacion);
    // return this.http.post<ModeloRespuesta>('http://localhost:5000/paciente/AgregarPaciente/',nuevoPaciente);
  }


  ObtenerDoctores() {
    return this.http.get<ModeloRespuesta>('http://localhost:5000/Doctor/ObtenerDoctores');
  }

  ObtenerDoctoresAsignados(IdPaciente:Number) {
    return this.http.get<ModeloRespuesta>('http://localhost:5000/paciente/ObtenerDoctorAsignados/'+IdPaciente);
  }
}
