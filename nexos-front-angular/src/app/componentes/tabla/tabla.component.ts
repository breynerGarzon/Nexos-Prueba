import {
  Component,
  OnInit,
  Input,
  SimpleChanges,
  ChangeDetectionStrategy,
} from '@angular/core';
import { DoctorParaTabla } from '../../models/DoctorParaTabla';
import { DoctorSelect } from '../../models/DoctorSelect';
import { DoctorPaciente } from '../../models/DoctorPaciente';
import { PacientesService } from '../../services/pacientes.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-tabla',
  templateUrl: './tabla.component.html',
  styleUrls: ['./tabla.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TablaComponent implements OnInit {
  @Input() PacienteActual: Number;

  NombreColumnas: string[] = ['NombreDoctor'];

  DatosMedico: DoctorParaTabla[] = [];
  NombreDeplegable = 'Doctores';
  ObtenerDoctorSeleccionado: Function;
  NuevoDoctor: DoctorSelect;
  SeHaCreadoOEditado: boolean = true;
  DoctoresAsignados: DoctorPaciente[] = [];
  constructor(
    public servicioPacientes: PacientesService,
    public _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.servicioPacientes
      .ObtenerDoctoresAsignados(this.PacienteActual)
      .subscribe(
        (data) => {
          if (data.statusCode === 200) {
            console.log(data);
            this.DatosMedico = [];
            this.DoctoresAsignados = data.data;
            this.DoctoresAsignados.forEach((item) => {
              const doc: DoctorParaTabla = {
                id: item.doctorId,
                NombreDoctor: 'Id doctor ' + item.doctorId,
              };
              this.DatosMedico.push(doc);
            });
          }
        },

        (error) => {
          console.log(error);
        }
      );
    this.ObtenerDoctorSeleccionado = this.ObtenerDoctorActual.bind(this);
  }

  ObtenerDoctorActual(doctorSeleccionado: DoctorSelect) {
    this.NuevoDoctor = doctorSeleccionado;
    console.log(this.NuevoDoctor);
  }

  ngOnChanges(changes: SimpleChanges) {
    if (
      changes['PacienteActual'] &&
      changes['PacienteActual'].currentValue !== 0
    ) {
      this.PacienteActual = changes['PacienteActual'].currentValue;
      this.SeHaCreadoOEditado = false;
    }

    if (changes['DatosMedico']) {
      debugger
      this.DatosMedico = changes['DatosMedico'].currentValue;
    }
  }

  Crear() {
    const nu: DoctorParaTabla = {
      id: Number(4),
      NombreDoctor: 'sdsd',
    };
    this.DatosMedico.push(nu);
    this.DatosMedico = this.DatosMedico;
    console.log(this.DatosMedico);
  }

  AsociarDoctor() {
    let asignacion: DoctorPaciente = {
      doctorId: this.NuevoDoctor.value,
      pacienteId: this.PacienteActual,
      agregar: true,
    };
    this.servicioPacientes.AsignarDoctorPaciente(asignacion).subscribe(
      (data) => {
        this.SeHaCreadoOEditado = false;
        if (data.statusCode === 201) {
          this.HabilitarNotificacion('El medico a sido asignado', 'Asginación');
          this.ngOnInit();
        } else {
          this.HabilitarNotificacion(data.message, 'º Asginando');
        }
        console.log(data);
      },
      (error) => {
        this.HabilitarNotificacion(error, 'Falla Asginando');
      }
    );
  }

  RemoverAsociacion(IdDocto:number){
    let asignacion: DoctorPaciente = {
      doctorId: Number(IdDocto),
      pacienteId: this.PacienteActual,
      agregar: false,
    };

    this.servicioPacientes.AsignarDoctorPaciente(asignacion).subscribe(
      (data) => {
        if (data.statusCode === 201) {
          this.HabilitarNotificacion('El medico ha sido removido', 'Asginación');
          const nueva = this.DatosMedico.filter(item=>item.id!==IdDocto);
          this.DatosMedico=nueva;
          this.SeHaCreadoOEditado=false;
        } else {
          this.HabilitarNotificacion(data.message, 'Falla Asginando');
        }
        console.log(data);
      },
      (error) => {
        this.HabilitarNotificacion(error, 'Falla Asginando');
      }
    );
  }

  HabilitarNotificacion(Mensaje: string, Tipo: string) {
    this._snackBar.open(Mensaje, Tipo, {
      duration: 5000,
    });
  }
}
