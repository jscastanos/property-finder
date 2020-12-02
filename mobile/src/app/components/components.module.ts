import { NgModule } from "@angular/core";
import { IonicModule } from "@ionic/angular";
import { CommonModule } from "@angular/common";
import { MapboxComponent } from "./mapbox/mapbox.component";
import { RouterModule } from "@angular/router";
import { RatingComponent } from "./rating/rating.component";
@NgModule({
  imports: [IonicModule, CommonModule, RouterModule],
  exports: [MapboxComponent, RatingComponent],
  declarations: [MapboxComponent, RatingComponent]
})
export default class ComponentModule {}
