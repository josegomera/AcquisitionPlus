import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ProdutosListComponent } from './list/produtos-list.component';
import { ProductResolver } from 'src/app/core/resolvers/product.resolver';


const routes: Routes = [
  {path: '', component: ProdutosListComponent, resolve: {product: ProductResolver }}
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

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ProdutosRoutigModule { }
