import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router' 
import { ProdutoStoreService } from '../produto-store.service';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.scss']
})
export class ProdutosComponent implements OnInit {

  constructor(
    private _router:Router,
    public store:ProdutoStoreService
    ){}

  ngOnInit() {
    this.store.carregarDadosIniciais();
  }

  editarProduto(id:string){
    this._router.navigate(['/produto/' + id]);
  }

  incluirProduto(){
    this._router.navigate(['/produto']);
  }

  onVitrine(){
    this._router.navigate(['/vitrine']);
  }

}