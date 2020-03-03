import { NgModule } from "@angular/core";
import { IonicModule } from "@ionic/angular";
import { CommonModule } from "@angular/common";
import { MapboxComponent } from "./mapbox/mapbox.component";
import { RouterModule } from "@angular/router";
@NgModule({
  imports: [IonicModule, CommonModule, RouterModule],
  exports: [MapboxComponent],
  declarations: [MapboxComponent]
})
export default class ComponentModule {}
