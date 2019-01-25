import { Component, OnInit } from '@angular/core';
import { ItemVitrine } from '../vitrine.model';
import { VitrineService } from '../vitrine.service';
import { formatCurrency } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vitrine',
  templateUrl: './vitrine.component.html',
  styleUrls: ['./vitrine.component.scss']
})
export class VitrineComponent implements OnInit {

  constructor(
    public service:VitrineService ,
    private _router:Router
    ){}

  ngOnInit() {
    this.service.get();
  }

  formata(valor:number){
    console.log( formatCurrency( valor , "pt-BR", "R$", "BLR", "1.2-2"));
  }

  onProdutos(){
    this._router.navigate(["produtos"]);
  }
}