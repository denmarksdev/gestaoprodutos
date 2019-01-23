import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FotoUploadComponent } from './foto-upload.component';
import { MatButtonModule } from '@angular/material';

@NgModule({
  declarations: [FotoUploadComponent],
  imports: [
    CommonModule,
    MatButtonModule
  ],
  exports: [FotoUploadComponent]
})
export class FotoUploadModule { }


