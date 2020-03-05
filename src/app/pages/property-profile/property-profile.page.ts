import { Component, OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { PropertyProfileService } from "src/app/services/property-profile.service";
import { MapboxdataService } from "src/app/services/mapboxdata.service";
import { NavController, AlertController } from "@ionic/angular";
import { EnvService } from "src/app/services/env.service";
import { get } from "../../services/storage.service";
import { RatingService } from "src/app/services/rating.service";
import { RatingComponent } from "src/app/components/rating/rating.component";

@Component({
  selector: "app-property-profile",
  templateUrl: "./property-profile.page.html",
  styleUrls: ["./property-profile.page.scss"]
})
export class PropertyProfilePage implements OnInit {
  @ViewChild(RatingComponent, { static: false })
  _ratingComponent: RatingComponent;

  propertyName;
  properytId;
  refer;
  details;
  url;
  userId;
  hasRated = false;
  userRating = 0;

  //api
  getInfo;
  getRating;
  postRate;

  constructor(
    private route: ActivatedRoute,
    private nav: NavController,
    private propertyService: PropertyProfileService,
    private mapboxService: MapboxdataService,
    private env: EnvService,
    private ratingService: RatingService
  ) {
    this.url = env.URL;
    get("user").then(e => {
      this.userId = e;
      this.loadRating(e);
    });

    this.route.queryParams.subscribe(params => {
      let data = JSON.parse(params.q);
      this.propertyName = data["name"];
      this.properytId = data["id"];
      this.refer = data["refer"];
    });
  }

  latLng = [];

  goRate(score) {
    this.postRate = this.ratingService
      .postRating(this.userId, this.properytId, score)
      .subscribe(e => {
        if (e) {
          this.hasRated = true;
          this._ratingComponent.loadRating(this.userId);
        }
      });
  }

  ngOnInit() {
    this.getInfo = this.propertyService
      .getPropertyInfo(this.properytId)
      .subscribe(e => {
        this.details = e;
      });

    this.mapboxService.currentMessage.subscribe(
      latLng => (this.latLng = latLng)
    );
  }

  loadRating(userId) {
    this.getRating = this.ratingService
      .getRating(userId, this.properytId)
      .subscribe(e => {
        if (e["userRating"] != undefined) {
          this.hasRated = true;
          this.userRating = e["userRating"];
        }
      });
  }

  newMessage() {
    this.propertyService
      .sendNotification(this.userId, this.details.UserId)
      .subscribe(e => {
        if (e == 1) {
          alert("Notification Sent!");
        }
      });
  }

  navigateMap(long, lat) {
    let longLat = [long, lat];
    this.mapboxService.changeDestination(longLat);
    this.nav.navigateForward("/");
  }

  navigateHome() {
    if (this.refer == 1) {
      this.nav.navigateBack("/post");
    } else {
      this.mapboxService.changeDestination([125.8093, 7.4472]);
      this.nav.navigateBack("/");
    }
  }

  ionViewDidLeave() {
    this.getInfo.unsubscribe();
    this.getRating.unsubscribe();
  }
}
