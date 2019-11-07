import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MantenimientosListComponent } from './list/mantenimientos-list.component';



const routes: Routes = [
  {path: '', component: MantenimientosListComponent},
  {path: 'empleados', loadChildren: () => import('./empleados/empleados.module').then(p => p.EmpleadosModule)},
  {path: 'departamentos', loadChildren: () => import('./departamentos/departamentos.module').then(p => p.DepartamentosModule)},
  {path: 'productos', loadChildren: () => import('./produtos/produtos.module').then(p => p.ProdutosModule)}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(
     routes
    )
  ],
  exports: [RouterModule]
})
export class MantenimientoRoutingModule { }
