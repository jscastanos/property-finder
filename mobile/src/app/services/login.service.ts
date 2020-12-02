import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { EnvService } from "./env.service";

@Injectable({
  providedIn: "root"
})
export class LoginService {
  constructor(private http: HttpClient, private env: EnvService) {}

  goVerify(user, pass) {
    return this.http.post(this.env.API_URL + "login", {
      username: user,
      password: pass
    });
  }
}
