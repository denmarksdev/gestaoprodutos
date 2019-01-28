import { BrowserModule } from '@angular/platform-browser';
import { 
  NgModule,
} from '@angular/core';
import {  RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProdutosModule  } from './produtos/produtos.module';
import { VitrineModule } from './vitrine/vitrine.module';
import { AngularSvgIconModule } from 'angular-svg-icon';
import {
  MatSidenavModule,
  MatButtonModule,
 } from '@angular/material'

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
   ],
  imports: [
    BrowserModule,
    RouterModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ProdutosModule,
    VitrineModule,
    MatSidenavModule,
    MatButtonModule,
    AngularSvgIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }