import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class EnvService {
  URL = "http://localhost:71/";
  API_URL = "http://localhost:71/api/";

  constructor() {}
}
