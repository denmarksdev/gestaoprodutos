import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'
import {
  MatCardModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatInputModule,
  MatButtonModule,
  MatSnackBarModule,
  MatProgressBarModule
} from '@angular/material';
import { FotoUploadModule } from '../shared/componentes/foto-upload/foto-upload.module';
import { TextMaskModule } from 'angular2-text-mask'

import { ProdutoService  } from './produto.service'

import { ProdutoEditComponent } from './produto-edit/produto-edit.component';
import { ProdutosComponent } from '../produtos/produtos/produtos.component';
import { ImagemService } from '../shared/helpers/imagem.service';

@NgModule({
  declarations: [ 
    ProdutosComponent, 
    ProdutoEditComponent
  ],
  exports:[
    ProdutosComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MatCardModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    FotoUploadModule,
    MatSnackBarModule,
    MatProgressBarModule,
    TextMaskModule
  ],
  providers: [
    ProdutoService,
    ImagemService
  ]
})
export class ProdutosModule { }