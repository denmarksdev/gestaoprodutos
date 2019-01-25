import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatCardModule,
  MatButtonModule
}  from '@angular/material'
import { VitrineComponent } from './vitrine/vitrine.component';
import { VitrineService } from './vitrine.service';
import { MoedaPipe } from '../shared/pipes/moeda.pipe';

@NgModule({
  declarations: [
    VitrineComponent,
    MoedaPipe
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule
  ],
  providers: [
    VitrineService
  ]
})
export class VitrineModule { }
