import { Component, OnInit } from "@angular/core";
import { MapboxdataService } from "src/app/services/mapboxdata.service";
import { NavController } from "@ionic/angular";
import { EnvService } from "src/app/services/env.service";

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

  //fetch
  getGeodata;
  getBrgys;

  constructor(
    private mapboxService: MapboxdataService,
    private nav: NavController,
    private env: EnvService
  ) {
    this.url = env.URL;
  }

  ngOnInit() {
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

  // addData(){
  //   this.posts
  // }

  // filterBrgy(e) {
  //   this.posts = new Array(this.tempPosts);
  //   var selectedBrgy = e.detail.value["BrgyID"];
  //   console.log(selectedBrgy);

  //   if (e.detail.value != 0) {
  //     for (var d in this.posts) {
  //       console.log(this.tempPosts);
  //       console.log("index", d);
  //       console.log(this.posts[d]);
  //       if (this.posts[d]["properties"]["BrgyID"] != selectedBrgy) {
  //         console.log(this.posts[d]["properties"]["BrgyID"]);
  //         this.posts.splice(d, 1);
  //       }
  //     }

  //     console.log(this.posts);
  //   }
  // }
  ionViewDidLeave() {
    this.getGeodata.unsubscribe();
    this.getBrgys.unsubscribe();
  }

  goTo(id, title) {
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

    this.nav.navigateForward(["/property-profile"], params);
  }
}
