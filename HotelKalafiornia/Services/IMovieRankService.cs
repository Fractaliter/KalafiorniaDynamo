using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelKalafiornia.Services
{
    public interface IMovieRankService
    {
        Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase();
        Task<MovieResponse> GetMovie(int userId, string movieName);
        Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesbyMovieTitle(int userId, string movieName);
        Task AddMovie(int userId, MovieRankRequest movieRankRequest);
        Task UpdateMovie(int userId, MovieUpdateRequest movieUpdateRequest);
    }
}
