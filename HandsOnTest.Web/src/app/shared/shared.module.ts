import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './modules/material/material.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DirectivesModule } from './directives/directives.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    DirectivesModule
  ],
  exports:[
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    DirectivesModule
  ]
})
export class SharedModule { }
