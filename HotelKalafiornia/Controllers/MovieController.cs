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
    }
}
