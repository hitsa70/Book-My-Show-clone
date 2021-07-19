import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { GetHomePageService} from '../../services/get-home-page.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  movies: any;

  constructor(private movieService: GetHomePageService, private router: Router) { }


  ngOnInit(): void {
    this.movieService.getMovies().subscribe(data => {
      this.movies = data;
    },
      error => {
        console.log("Error fetching movies data :( ");
      })
  };

}
