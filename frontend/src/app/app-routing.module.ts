import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from './@auth/auth.guard';
import { NotFoundComponent } from './pages/miscellaneous/not-found/not-found.component';

const routes: Routes = [
  {
    path: 'pages',
    canActivate: [AuthGuard],
    loadChildren: () => import('../app/pages/pages.module')
      .then(m => m.PagesModule),
  },
  {
    path: 'collectinfo',
    loadChildren: () => import('../app/@collectinfo/collectinfo.module')
      .then(m => m.CollectInfoModule),
  },
  {
    path: 'auth',
    loadChildren: () => import('../app/@auth/auth-routing.module')
      .then(m => m.AuthRoutingModule),
  },
  {
    path: '',
    component: NotFoundComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
  // { path: '', redirectTo: 'pages', pathMatch: 'full' },
  // { path: '**', redirectTo: 'pages' },
];

const config: ExtraOptions = {
    useHash: false,
    relativeLinkResolution: 'legacy',
};

@NgModule({
  imports: [RouterModule.forRoot(routes, config)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
