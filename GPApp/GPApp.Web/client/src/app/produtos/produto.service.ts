import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProdutoLookup, Produto } from './produto-model';

const BASE_URL = "/api/v1/produto";

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  constructor(private _htpp:HttpClient ) { }

  getAll(): Observable<Array<ProdutoLookup>> {
    return this._htpp.get<Array<ProdutoLookup>>(BASE_URL);
  }

  get(id:string):Observable<Produto> {
    return this._htpp.get<Produto>(BASE_URL+ "/" + id);
  }

  post(produto:Produto){
    return this._htpp.post(BASE_URL,produto);
  }

  put(produto:Produto){
    return this._htpp.put(BASE_URL + "/" + produto.id, produto);
  }

}