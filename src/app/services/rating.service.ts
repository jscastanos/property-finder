import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { EnvService } from "./env.service";

@Injectable({
  providedIn: "root"
})
export class RatingService {
  constructor(private http: HttpClient, private env: EnvService) {}

  getRating(userId, postId) {
    return this.http.get(this.env.API_URL + "rating/" + postId + "/" + userId);
  }

  postRating(userId, postId, rating) {
    return this.http.post(this.env.API_URL + "rating/add", {
      postId: postId,
      userId: userId,
      rating: rating
    });
  }
}
