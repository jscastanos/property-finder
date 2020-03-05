import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class EnvService {
  //  URL = "http://localhost:71/";
  //  API_URL = "http://localhost:71/api/";

  URL = "http://propertyfinder-001-site1.itempurl.com/";
  API_URL = "http://propertyfinder-001-site1.itempurl.com/api/";

  constructor() {}
}
