import { Component, OnInit } from "@angular/core";
import { remove } from "../../services/storage.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-app-layout",
  templateUrl: "./app-layout.component.html",
  styleUrls: ["./app-layout.component.scss"]
})
export class AppLayoutComponent implements OnInit {
  public selectedIndex = 0;
  public appPages = [
    {
      title: "Post",
      url: "/post",
      icon: "home"
    },
    {
      title: "Map",
      url: "/",
      icon: "location"
    }
  ];

  constructor(private router: Router) {}

  logout() {
    remove("user").then(e => {
      this.router.navigateByUrl("/login");
    });
  }

  ngOnInit() {}
}
