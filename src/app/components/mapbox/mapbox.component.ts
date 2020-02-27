import { Component, OnInit } from "@angular/core";
import { NavController } from "@ionic/angular";
import { set } from "../../services/storage.service";
import { MapboxdataService } from "src/app/services/mapboxdata.service";
import { interval } from "rxjs";

const mapboxgl = require("mapbox-gl");

@Component({
  selector: "app-mapbox",
  templateUrl: "./mapbox.component.html",
  styleUrls: ["./mapbox.component.scss"]
})
export class MapboxComponent implements OnInit {
  map;
  geolocate;
  currentCoords = [];
  localGeoData;

  //api
  geodata;

  constructor(
    private nav: NavController,
    private mapBoxDataService: MapboxdataService
  ) {
    mapboxgl.accessToken =
      "pk.eyJ1Ijoic2VydmljZWZpbmRlci13ZWIiLCJhIjoiY2s2dXBoaHVoMGJhczNsbzNnbTh1Mjk1YyJ9.AjVFCfErae5fBJTT0o9OIw";
  }

  ngOnInit() {
    this.buildMap();
    this.locateUser();
    this.OnMapLoad();

    let checkTimer = interval(1000).subscribe(ct => {
      if (this.currentCoords.length > 0) {
        checkTimer.unsubscribe();
        this.loadGeoData();
      }
    });
  }

  buildMap() {
    const tagumCoords = [125.8093, 7.4472];

    //build map
    this.map = new mapboxgl.Map({
      container: "map",
      style: "mapbox://styles/mapbox/streets-v11",
      center: tagumCoords,
      zoom: 15
    });
  }

  locateUser() {
    // geolocate
    this.geolocate = new mapboxgl.GeolocateControl({
      positionOptions: {
        enableHighAccuracy: true
      },
      trackUserLocation: true,
      showUserLocation: true,
      showAccuracyCircle: false,
      fitBounds: {
        minZoom: 12
      }
    });

    this.map.addControl(this.geolocate, "bottom-right");
  }

  OnMapLoad() {
    this.map.on("load", e => {
      //redraw
      document.getElementById("overlay").hidden = true;
      this.map.resize();

      //locate user
      this.geolocate.trigger();
    });

    this.geolocate.on("geolocate", g => {
      this.currentCoords[0] = g.coords.longitude;
      this.currentCoords[1] = g.coords.latitude;

      set("LngLat", this.currentCoords);
    });
  }

  drawMarkers() {
    //set marker
    this.localGeoData["features"].forEach(e => {
      var el = document.createElement("div");

      el.className = "marker";

      if (e.properties["propertyId"] == 1) {
        el.style.backgroundImage = "url(../../../assets/house.png)";
      } else if (e.properties["propertyId"] == 2) {
        el.style.backgroundImage = "url(../../../assets/lot.png)";
      } else if (e.properties["propertyId"] == 3) {
        el.style.backgroundImage = "url(../../../assets/house-lot.png)";
      }

      el.style.backgroundSize = "cover";
      el.style.width = "50px";
      el.style.height = "50px";

      var type = document.createElement("span");
      type.textContent = e.properties.acquisitionName;
      type.style.color = "white";
      type.style.padding = "5px";

      if (e.properties.acquisitionId == 1) {
        type.style.backgroundColor = "#c23a3a";
      } else if (e.properties.acquisitionId == 2) {
        type.style.backgroundColor = "#237a45";
      } else if (e.properties.acquisitionId == 3) {
        type.style.backgroundColor = "#406ec9";
      }

      el.appendChild(type);

      let marker = new mapboxgl.Marker(el)
        .setLngLat(e.geometry.coordinates)
        .addTo(this.map);

      marker.getElement().addEventListener("click", function() {
        console.log(e.properties.id);
      });
    });
  }

  async loadGeoData() {
    this.geodata = await this.mapBoxDataService
      .fetchMapBoxData()
      .subscribe(res => {
        this.localGeoData = res;

        //setup markers
        this.drawMarkers();
      });
  }
}
