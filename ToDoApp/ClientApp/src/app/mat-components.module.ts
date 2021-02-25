import { NgModule } from '@angular/core';
import { MatDialogModule, MatInputModule, MatProgressSpinnerModule } from '@angular/material';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [],
  exports: [
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatDialogModule,
  ]
})
export class MatComponentsModule { }
