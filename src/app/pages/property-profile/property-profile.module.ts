import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PropertyProfilePageRoutingModule } from './property-profile-routing.module';

import { PropertyProfilePage } from './property-profile.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PropertyProfilePageRoutingModule
  ],
  declarations: [PropertyProfilePage]
})
export class PropertyProfilePageModule {}
