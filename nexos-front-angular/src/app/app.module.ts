import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PacienteComponent } from './paciente/paciente.component';
import { PacientesComponent } from './pacientes/pacientes.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MaterialModules} from './material.module';
import { ListadesplegableComponent } from './componentes/listadesplegable/listadesplegable.component';
import { TablaComponent } from './componentes/tabla/tabla.component';


@NgModule({
  declarations: [
    AppComponent,
    PacienteComponent,
    PacientesComponent,
    ListadesplegableComponent,
    TablaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModules,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
