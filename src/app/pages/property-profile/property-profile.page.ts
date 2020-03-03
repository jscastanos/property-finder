import { Component, OnInit, OnDestroy } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { PropertyProfileService } from "src/app/services/property-profile.service";
import { MapboxdataService } from "src/app/services/mapboxdata.service";
import { NavController } from "@ionic/angular";

@Component({
  selector: "app-property-profile",
  templateUrl: "./property-profile.page.html",
  styleUrls: ["./property-profile.page.scss"]
})
export class PropertyProfilePage implements OnInit, OnDestroy {
  propertyName;
  properyId;
  details;

  //api
  getInfo;

  constructor(
    private route: ActivatedRoute,
    private nav: NavController,
    private propertyService: PropertyProfileService,
    private mapboxService: MapboxdataService
  ) {
    this.route.queryParams.subscribe(params => {
      let data = JSON.parse(params.q);
      this.propertyName = data["name"];
      this.properyId = data["id"];
    });
  }

  latLng = [];

  ngOnInit() {
    this.getInfo = this.propertyService
      .getPropertyInfo(this.properyId)
      .subscribe(e => {
        this.details = e;
      });

    this.mapboxService.currentMessage.subscribe(
      latLng => (this.latLng = latLng)
    );
  }

  newMessage() {}

  navigateMap(long, lat) {
    let longLat = [long, lat];
    this.mapboxService.changeDestination(longLat);
    this.nav.navigateForward("/");
  }

  sendNotif() {}

  navigateHome() {
    this.mapboxService.changeDestination([125.8093, 7.4472]);
    this.nav.navigateBack("/");
  }

  ngOnDestroy() {}
}
