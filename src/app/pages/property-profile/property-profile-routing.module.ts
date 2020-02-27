import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PropertyProfilePage } from './property-profile.page';

const routes: Routes = [
  {
    path: '',
    component: PropertyProfilePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PropertyProfilePageRoutingModule {}
