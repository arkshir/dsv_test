import { Component, OnInit, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import {
  ApiModule,
  MoviesApiUseCasesMoviesMovieSummaryDto,
  MoviesService,
} from './core/modules/openapi';
import { MatGridListModule } from '@angular/material/grid-list';
import { MovieCardComponent } from './components/movie-card/movie-card.component';
import { CommonModule } from '@angular/common';
import {
  MatPaginator,
  MatPaginatorModule,
  PageEvent,
} from '@angular/material/paginator';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    CommonModule,
    MatCardModule,
    ApiModule,
    MatGridListModule,
    MovieCardComponent,
    MatPaginatorModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'Movies Frontend';
  page: number = 1;
  pageSize: number = 12;
  totalPages: number = 0;
  totalItems: number = 0;
  movies: MoviesApiUseCasesMoviesMovieSummaryDto[] = [];

  constructor(private moviesService: MoviesService) {}

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData(): void {
    this.moviesService
      .moviesApiApiEndpointsMoviesListListMoviesEndpoint(
        this.page,
        this.pageSize,
        'id asc'
      )
      .subscribe({
        next: (res) => {
          this.movies = res.items ?? [];
          this.page = res.page ?? 1;
          this.pageSize = res.pageSize ?? 20;
          this.totalPages = res.totalPages ?? 1;
          this.totalItems = res.totalItems ?? 0;
        },
        error: (err) => {
          console.error(err);
        },
      });
  }

  onPageChange(event: PageEvent) {
    this.page = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.fetchData();
  }
}
