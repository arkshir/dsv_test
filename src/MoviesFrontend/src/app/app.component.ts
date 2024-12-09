import { Component, OnInit, inject } from '@angular/core';
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
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MovieDialogComponent } from './components/movie-dialog/movie-dialog.component';

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
    MatDialogModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  readonly dialog = inject(MatDialog);

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

  fetchDetails(id: number) {
    return this.moviesService.moviesApiApiEndpointsMoviesGetGetMovieEndpoint(
      id
    );
  }

  openDetailsDialog(id: number): void {
    console.log('id: ', id);
    this.fetchDetails(id).subscribe({
      next: (res) => {
        this.dialog.open(MovieDialogComponent, {
          data: res,
          width: '560px',
          height: '560px',
        });
      },
      error: (err) => {
        console.error(err);
      },
    });
  }
}
