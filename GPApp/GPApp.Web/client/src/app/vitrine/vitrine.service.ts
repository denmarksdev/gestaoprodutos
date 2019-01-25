import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ItemVitrine } from './vitrine.model';
import { BehaviorSubject } from 'rxjs';

const BASE_URL = "/api/v1/vitrine";

@Injectable({
  providedIn: 'root'
})
export class VitrineService {

   vitrine = new BehaviorSubject<Array<ItemVitrine>>([]);
   vitrine$ = this.vitrine.asObservable(); 

  constructor(private _htpp:HttpClient) {
   }

   get(){
    this._htpp.get<Array<ItemVitrine>>(BASE_URL)
       .subscribe( items => {
         this.vitrine.next(items)
       });

   }
}
