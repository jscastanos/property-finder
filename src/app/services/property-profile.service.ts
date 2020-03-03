import { Injectable } from "@angular/core";
import { EnvService } from "./env.service";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class PropertyProfileService {
  constructor(private env: EnvService, private http: HttpClient) {}

  getPropertyInfo(id) {
    return this.http.get(this.env.API_URL + "property/" + id);
  }
}
