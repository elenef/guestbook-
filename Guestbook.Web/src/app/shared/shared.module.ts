

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModule, ɵx} from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterLink } from '@angular/router';


import { CdkTableModule } from '@angular/cdk';

import { PageDetailsComponent } from './components/page-details/page-details.component';
import {MdSidenavModule} from '@angular/material';
import { AppRoutingModule } from '../app-routing.module';


@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    CdkTableModule,
    MdSidenavModule,
    AppRoutingModule
    ],
  declarations: [
    ],
  exports: [
    ],
})
export class SharedModule { }
