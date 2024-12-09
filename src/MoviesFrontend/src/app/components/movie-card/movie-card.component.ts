import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MoviesApiUseCasesMoviesMovieSummaryDto } from '../../core/modules/openapi';

@Component({
  selector: 'app-movie-card',
  imports: [MatCardModule],
  templateUrl: './movie-card.component.html',
  styleUrl: './movie-card.component.scss',
})
export class MovieCardComponent {
  @Input() movie: MoviesApiUseCasesMoviesMovieSummaryDto = {};

  constructor() {}

  getPlaceholderUrl(): string {
    let title = this.movie.title ?? '';
    return `https://placehold.co/600x200?text=${title.replaceAll(' ', '+')}`;
  }

  getPlaceholderAlt(): string {
    return `Image of ${this.movie.title}`;
  }

  getSubtitle(): string {
    return [this.movie.duration, this.movie.rating].join('  |  ');
  }

  getFooter(): string {
    return `${this.movie.genres?.join(' - ')}`;
  }
}
