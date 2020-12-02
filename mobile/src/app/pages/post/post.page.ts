import { Component, OnInit } from "@angular/core";
import { MapboxdataService } from "src/app/services/mapboxdata.service";
import { NavController } from "@ionic/angular";
import { EnvService } from "src/app/services/env.service";
import { PropertyProfileService } from "src/app/services/property-profile.service";
import { get } from "../../services/storage.service";

@Component({
  selector: "app-post",
  templateUrl: "./post.page.html",
  styleUrls: ["./post.page.scss"]
})
export class PostPage implements OnInit {
  posts;
  url;
  brgys;
  tempPosts = [];
  userId;

  //fetch
  getGeodata;
  getBrgys;

  constructor(
    private mapboxService: MapboxdataService,
    private profileService: PropertyProfileService,
    private nav: NavController,
    private env: EnvService
  ) {
    this.url = env.URL;
    get("user").then(e => {
      this.userId = e;
    });
  }

  ngOnInit() {
    console.log("hey");

    this.getBrgys = this.mapboxService.fetchBarangays().subscribe(b => {
      this.brgys = b;
    });

    this.getGeodata = this.mapboxService.fetchMapBoxData().subscribe(data => {
      this.posts = data["features"];

      for (var p in this.posts) {
        switch (this.posts[p]["properties"]["propertyId"]) {
          case "1":
            this.posts[p]["properties"]["propertyName"] = "House";
            break;
          case "2":
            this.posts[p]["properties"]["propertyName"] = "Lot";
            break;
          case "3":
            this.posts[p]["properties"]["propertyName"] = "House and Lot";
            break;
        }
      }
    });
  }

  ionViewDidLeave() {
    this.getGeodata.unsubscribe();
    this.getBrgys.unsubscribe();
  }

  goTo(id, title, index) {
    let data = {
      id: id,
      name: title,
      refer: 1
    };

    let params = {
      queryParams: {
        q: JSON.stringify(data)
      }
    };

    this.profileService.postVisit(this.userId, id).subscribe(e => {
      this.posts[index]["properties"]["CountViews"] += 1;
    });

    this.nav.navigateForward(["/property-profile"], params);
  }
}
