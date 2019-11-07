import { Component, OnInit } from "@angular/core";

export interface Section {
  name: string;
}

@Component({
  selector: "app-mantenimientos-list",
  templateUrl: "./mantenimientos-list.component.html",
  styleUrls: ["./mantenimientos-list.component.css"]
})
export class MantenimientosListComponent implements OnInit {
  mantenimientos: Section[] = [
    {
      name: "Empleados"
    },
    {
      name: "Departamentos"
    },
    {
      name: "Suplidores"
    },
    {
      name: "Productos"
    },
    {
      name: 'Unidades de Medidas'
    }
  ];

  constructor() {}

  ngOnInit() {console.log('jeje');}
}
