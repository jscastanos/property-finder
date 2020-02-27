import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { EnvService } from "./env.service";

@Injectable({
  providedIn: "root"
})
export class MapboxdataService {
  constructor(private env: EnvService, private http: HttpClient) {}

  fetchMapBoxData() {
    return this.http.get(this.env.API_URL + "geocode/geojson/post");
  }
}
