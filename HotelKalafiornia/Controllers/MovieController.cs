using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelKalafiornia.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
namespace HotelKalafiornia.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRankService _movieRankService;
        public MovieController(IMovieRankService movieRankService)
        {
            _movieRankService = movieRankService;
        }
        [HttpGet]
        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var results = await _movieRankService.GetAllItemsFromDatabase();
            return results;
        }
        [HttpGet]
        [Route("{userId}/{movieName}")]
        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var results = await _movieRankService.GetMovie(userId,movieName);
            return results;
        }

        [HttpGet]
        [Route("user/{userId}/rankedMovies/{movieName}")]
        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesbyMovieTitle(int userId, string movieName)
        {
            var results = await _movieRankService.GetUsersRankedMoviesbyMovieTitle(userId, movieName);
            return results;
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> AddMovie(int userId, [FromBody] MovieRankRequest movieRankRequest)
        {
            await _movieRankService.AddMovie(userId, movieRankRequest);
            return Ok();
        }
        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateMovie(int userId, [FromBody] MovieUpdateRequest request)
        {
            await _movieRankService.UpdateMovie(userId, request);
            return Ok();
        }
        [HttpGet]
        [Route("{movieName}/ranking")]
        public async Task<MovieRankResponse> GetMoviesRanking(string movieName)
        {
            var results = await _movieRankService.GetMovieRank(movieName);
            return results;
        }
    }
}
