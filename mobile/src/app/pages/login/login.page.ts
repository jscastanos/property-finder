import { Component, OnInit } from "@angular/core";
import { NavController } from "@ionic/angular";
import { set } from "../../services/storage.service";
import { NgForm } from "@angular/forms";
import { LoginService } from "src/app/services/login.service";
import { getPromise } from "@ionic-native/core";
import { EnvService } from "src/app/services/env.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.page.html",
  styleUrls: ["./login.page.scss"]
})
export class LoginPage implements OnInit {
  btnDisabled = false;
  url;
  constructor(
    private nav: NavController,
    private loginService: LoginService,
    private env: EnvService
  ) {
    this.url = env.URL;
  }

  trylogin: any;
  ngOnInit() {}

  login(form: NgForm) {
    this.btnDisabled = true;

    this.trylogin = this.loginService
      .goVerify(form.value.username, form.value.password)
      .subscribe(
        data => {
          if (data != "null") {
            set("user", data).then(e => {
              form.resetForm();
              this.btnDisabled = false;

              this.nav.navigateForward("/post");
            });
          } else {
            this.btnDisabled = false;
            alert("Please check your username or password");
          }
        },

        error => {
          this.btnDisabled = false;
          alert("Error: " + JSON.stringify(error));
        }
      );
  }

  registerOnWeb() {
    window.open(this.url + "account/signup");
  }

  ionViewDidLeave() {
    this.trylogin.unsubscribe();
  }
}
