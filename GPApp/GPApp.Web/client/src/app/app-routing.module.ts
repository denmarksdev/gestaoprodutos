import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProdutosModule } from './produtos/produtos.module'
import { ProdutosComponent } from './produtos/produtos/produtos.component';
import { ProdutoEditComponent } from './produtos/produto-edit/produto-edit.component';
import { VitrineComponent } from './vitrine/vitrine/vitrine.component';

const routes: Routes = [
  { path:'' , redirectTo:'produtos', pathMatch: 'full' },
  { path: 'produtos', component: ProdutosComponent  },
  { path: 'produto' , component:ProdutoEditComponent  },
  { path: 'produto/:id', component: ProdutoEditComponent },
  { path: 'vitrine', component: VitrineComponent }

];

@NgModule({
  imports: [
    ProdutosModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }


