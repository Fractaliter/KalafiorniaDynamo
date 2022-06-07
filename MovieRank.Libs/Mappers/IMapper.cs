using MovieRank.Contracts;
using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRank.Libs.Mappers
{
    public interface IMapper
    {
        IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items);
        MovieResponse ToMovieContract(MovieDb movie);
        MovieDb ToMovieDBModel(int userId, MovieRankRequest movieRankRequest);
    }
}
