import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Gestão de produtos';
  aberto: boolean;
  
  constructor(private _router:Router) {
  }

  navegar(url:string){
    this.aberto = false;
    this._router.navigate([ "/" + url])
  }
}
