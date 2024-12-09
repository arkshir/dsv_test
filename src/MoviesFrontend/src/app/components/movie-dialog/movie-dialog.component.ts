import { Component, Inject, Input } from '@angular/core';
import { MoviesApiUseCasesMoviesMovieDetailsDto } from '../../core/modules/openapi';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-movie-dialog',
  imports: [MatDialogModule],
  templateUrl: './movie-dialog.component.html',
  styleUrl: './movie-dialog.component.scss',
})
export class MovieDialogComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: MoviesApiUseCasesMoviesMovieDetailsDto
  ) {}

  getPlaceholderUrl(): string {
    let title = this.data.title ?? '';
    return `https://placehold.co/580x200?text=${title.replaceAll(' ', '+')}`;
  }

  getPlaceholderAlt(): string {
    return `Image of ${this.data.title}`;
  }

  getDataAsJson(): string {
    return JSON.stringify(this.data);
  }
}
