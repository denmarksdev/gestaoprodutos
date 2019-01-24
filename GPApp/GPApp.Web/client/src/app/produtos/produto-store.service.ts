import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ProdutoLookup, Produto } from './produto-model';
import { ProdutoService } from './produto.service';

@Injectable({
  providedIn: 'root'
})
export class ProdutoStoreService {

  private _produtos: BehaviorSubject<Array<ProdutoLookup>> = new BehaviorSubject([]);

  public get produtos() {
    return this._produtos.asObservable();
  }

  constructor(private _service: ProdutoService) {
    this.carregarDadosIniciais();
  }

  carregarDadosIniciais() {
    this._service.getAll()
      .subscribe(
      produtos => {
          this._produtos.next(produtos);
        },
        erro => console.log(erro)
      );
  }

  getProduto (id:string) {
    return this._service.get(id);
  }

  post(produto: Produto) {
    return this._service.post(produto);
  }

  put(produto: Produto) {
    return this._service.put(produto);
  }

}