using MovieRank.Contracts;
using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRank.Libs.Mappers
{
    public class Mapper : IMapper
    {
        public IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items)
        {
            return items.Select(ToMovieContract);
        }

        public MovieResponse ToMovieContract(MovieDb movie)
        {
            return new MovieResponse
            {
                MovieName = movie.MovieName,
                Description = movie.Description,
                Actors = movie.Actors,
                Ranking = movie.Ranking,
                TimeRanked = movie.RankedDateTime

            };
        }
        public MovieDb ToMovieDBModel(int userId,MovieRankRequest movieRankRequest)
        {
            return new MovieDb
            {
                UserId = userId,
                MovieName = movieRankRequest.MovieName,
                Description = movieRankRequest.Description,
                Actors = movieRankRequest.Actors,
                Ranking = movieRankRequest.Ranking,
                RankedDateTime = DateTime.UtcNow.ToString()

            };
        }
        public MovieDb ToMovieDBModel(int userId, MovieDb movieDbRequest, MovieUpdateRequest request)
        {
            return new MovieDb
            {
                UserId = movieDbRequest.UserId,
                MovieName = movieDbRequest.MovieName,
                Description = movieDbRequest.Description,
                Actors = movieDbRequest.Actors,
                Ranking = request.Ranking,
                RankedDateTime = DateTime.UtcNow.ToString()

            };
        }
    }
}
