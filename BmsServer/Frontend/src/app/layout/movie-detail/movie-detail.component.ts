import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs';

import { GetHomePageService } from '../../services/get-home-page.service';


@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.scss']
})
export class MovieDetailComponent implements OnInit {

  id = 0;
  movie: any;
  isMovieLoaded = false;

  private routeSub: Subscription;
  constructor(private route: ActivatedRoute,
    private router: Router,
    private movieService: GetHomePageService) { }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.id = +params['id']
      this.getDetail();
    });
  };

  btnClick(){
    this.router.navigateByUrl('/movie');
  }
  getDetail() {
    this.movieService.getMovie(this.id).subscribe(data => {
      this.movie = data;
      this.isMovieLoaded=true;
      console.log(this.movie);
    },
      error => {
        console.log("Error fetching movies data :( ");
      })
  };
}



