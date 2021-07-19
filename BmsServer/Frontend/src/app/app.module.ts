import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './layout/home/home.component';
import { HeaderComponent } from './layout/shared/header/header.component';
import { FooterComponent } from './layout/shared/footer/footer.component';
import { MovieCardComponent } from './layout/shared/movie-card/movie-card.component';
import { SliderComponent } from './layout/shared/slider/slider.component';

import { HttpClientModule } from '@angular/common/http';
import { MovieDetailComponent } from './layout/movie-detail/movie-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    MovieCardComponent,
    SliderComponent,
    MovieDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
