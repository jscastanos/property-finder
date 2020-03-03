import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-app-layout",
  templateUrl: "./app-layout.component.html",
  styleUrls: ["./app-layout.component.scss"]
})
export class AppLayoutComponent implements OnInit {
  public selectedIndex = 0;
  public appPages = [
    {
      title: "Profile",
      url: "/profile",
      icon: "person"
    },
    {
      title: "Navigate Map",
      url: "/home",
      icon: "location"
    },
    {
      title: "Login",
      url: "/login",
      icon: "person"
    }
  ];

  constructor() {}

  ngOnInit() {}
}
