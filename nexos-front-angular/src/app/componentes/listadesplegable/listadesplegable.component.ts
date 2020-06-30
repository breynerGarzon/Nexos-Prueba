import { Component, OnInit,Input} from '@angular/core';
import { DoctorSelect} from '../../models/DoctorSelect';
import { PacientesService } from '../../services/pacientes.service';
import { DoctorView } from '../../models/DoctorView';

@Component({
  selector: 'app-listadesplegable',
  templateUrl: './listadesplegable.component.html',
  styleUrls: ['./listadesplegable.component.css']
})
export class ListadesplegableComponent implements OnInit {
  @Input() Nombre: string;
  Items: DoctorSelect[]=[];
  @Input() ValorSeleccionado: Function;
  Doctore:DoctorView[]=[];

  constructor(public servicioPacientes: PacientesService,) { }

  ngOnInit(): void {
    this.servicioPacientes.ObtenerDoctores()
    .subscribe(
      (datos)=>{
        if (datos.statusCode===200) {
          this.Doctore=datos.data;
          this.Doctore.forEach(element => {
            const doc : DoctorSelect={
                value:Number(element.id),
                viewValue: element.nombres+" "+ element.apellidos,
            }
            this.Items.push(doc);
          });
          
        }
      },
      (error)=>{},
    );
  }

  

  ComunicarCambio(event:any){
    console.log(event);
    const doctorSeleccionado : DoctorSelect= {
      viewValue:event.viewValue,
      value:event.value,
    }
    this.ValorSeleccionado(doctorSeleccionado);
  }
}
