using FluentValidation;

namespace MoviesApi.UseCases.Movies.List;

public class ListMoviesQueryValidator : AbstractValidator<ListMoviesQuery>
{
    public ListMoviesQueryValidator()
    {
        RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(60);
    }
}