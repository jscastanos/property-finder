import { Component, OnInit, Input, HostListener } from "@angular/core";
import { RatingService } from "src/app/services/rating.service";
import { get } from "../../services/storage.service";

@Component({
  selector: "app-rating",
  templateUrl: "./rating.component.html",
  styleUrls: ["./rating.component.scss"]
})
export class RatingComponent implements OnInit {
  @Input() postId;

  ratingStars;
  rateData = {
    userRating: null,
    totalRate: null,
    rateCount: null
  };

  getRating;
  hasRating = false;

  constructor(private ratingService: RatingService) {}

  ngOnInit() {
    get("user").then(e => {
      this.loadRating(e);
    });
  }

  loadRating(id) {
    this.getRating = this.ratingService
      .getRating(id, this.postId)
      .subscribe(res => {
        if (res != 0) {
          this.hasRating = true;
          this.rateData = {
            userRating: res["userRating"],
            totalRate: res["mean"],
            rateCount: res["count"]
          };
          this.ratingStars = this.computeRating(this.rateData.totalRate);
        }
      });
  }

  computeRating(rate) {
    if (rate != undefined) {
      let whole,
        half,
        none,
        array = [];

      whole = Math.trunc(rate);
      half = Math.ceil(rate - whole);
      none = Math.trunc(5 - (whole + half));

      //construct data
      for (const index of [].constructor(whole)) array.push("star");

      for (const index of [].constructor(half)) array.push("star-half");

      for (const index of [].constructor(none)) array.push("star-outline");
      return array;
    }
  }

  @HostListener("unloaded")
  ngOnDestroy() {
    this.getRating.unsubscribe();
  }
}
