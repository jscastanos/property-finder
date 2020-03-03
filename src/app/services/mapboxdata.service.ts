import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { EnvService } from "./env.service";
import { BehaviorSubject } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class MapboxdataService {
  constructor(private env: EnvService, private http: HttpClient) {}

  private latLong = new BehaviorSubject([]);
  currentMessage = this.latLong.asObservable();

  fetchMapBoxData() {
    return this.http.get(this.env.API_URL + "geocode/geojson/property");
  }

  changeDestination(longLat) {
    this.latLong.next(longLat);
  }
}
