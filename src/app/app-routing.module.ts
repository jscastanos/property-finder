import { NgModule } from "@angular/core";
import { PreloadAllModules, RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    loadChildren: () => import("./home/home.module").then(m => m.HomePageModule)
  },
  {
    path: 'property-profile',
    loadChildren: () => import('./pages/property-profile/property-profile.module').then( m => m.PropertyProfilePageModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./pages/login/login.module').then( m => m.LoginPageModule)
  },
  {
    path: 'post',
    loadChildren: () => import('./pages/post/post.module').then( m => m.PostPageModule)
  },
  {
    path: 'seller-profile',
    loadChildren: () => import('./pages/seller-profile/seller-profile.module').then( m => m.SellerProfilePageModule)
  },
  {
    path: 'buyer-profile',
    loadChildren: () => import('./pages/buyer-profile/buyer-profile.module').then( m => m.BuyerProfilePageModule)
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
