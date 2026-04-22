
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import {
  NgxCollectInfoComponent,
} from './components';
import { CollectionInfoComponent } from './collectioninfo.component';

const routes: Routes = [{
  path: '',
  component: CollectionInfoComponent,
  children: [
    {
      path: '',
      component: NgxCollectInfoComponent,
    },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CollectInfoRoutingModule {
}
