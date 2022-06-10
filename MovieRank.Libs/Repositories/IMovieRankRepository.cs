using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelKalafiornia.Services
{
    public interface IMovieRankRepository
    {
        Task<IEnumerable<MovieDb>> GetAllItems();
        Task<MovieDb> GetMovie(int userId, string MovieName);
        Task<IEnumerable<MovieDb>> GetUsersRankedMoviesbyMovieTitle(int userId, string MovieName);
        Task AddMovie(MovieDb movieDb);
        Task UpdateMovie(MovieDb movieDb);
        Task<IEnumerable<MovieDb>> GetMovieRank(string MovieName);
    }
}
