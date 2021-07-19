import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './layout/home/home.component'
import { MovieDetailComponent } from './layout/movie-detail/movie-detail.component'




const routes: Routes = [
  {
    path: 'movie', component: HomeComponent,

  },
  {
    path: 'movie/:id', component: MovieDetailComponent,

  }, {
    path: '', component: HomeComponent,

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
