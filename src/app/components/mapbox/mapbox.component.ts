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

  flyToCoords = [];

  //api
  geodata;

  constructor(
    private nav: NavController,
    private mapBoxDataService: MapboxdataService
  ) {
    mapboxgl.accessToken =
      "pk.eyJ1Ijoic2VydmljZWZpbmRlci13ZWIiLCJhIjoiY2s2dXBoaHVoMGJhczNsbzNnbTh1Mjk1YyJ9.AjVFCfErae5fBJTT0o9OIw";
  }

  longLat = [];

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

    this.map.addControl(new mapboxgl.NavigationControl());

    this.mapBoxDataService.currentMessage.subscribe(e => {
      this.longLat = e;
      if (this.longLat.length > 0) {
        this.navigateToCoords(this.longLat);
      }
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

    this.map.addControl(this.geolocate);
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
      el.style.width = "55px";
      el.style.height = "55px";

      var type = document.createElement("span");
      type.textContent = "For " + e.properties.acquisitionName;
      type.style.color = "white";
      type.style.padding = "5px";
      type.style.width = "65px";
      type.style.position = "absolute";
      type.style.top = "-15px";
      type.style.left = "0";
      type.style.borderRadius = "10px";

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

      marker.getElement().addEventListener("click", () => {
        let data = {
          id: e.properties.id,
          name: e.properties.title
        };

        let params = {
          queryParams: {
            q: JSON.stringify(data)
          }
        };

        this.map.flyTo({ cemter: this.currentCoords, zoom: 11 });

        setTimeout(() => {
          this.nav.navigateForward(["/property-profile"], params);
        }, 100);
      });
    });
  }

  navigateToCoords(longLat) {
    this.map.flyTo({
      center: longLat,
      zoom: 13
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
