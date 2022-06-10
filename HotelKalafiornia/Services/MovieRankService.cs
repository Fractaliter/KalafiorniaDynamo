using MovieRank.Contracts;
using MovieRank.Libs.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelKalafiornia.Services
{
    public class MovieRankService : IMovieRankService
    {
        private readonly IMovieRankRepository _movieRankRepository;

        private readonly IMapper _mapper;
        public MovieRankService(IMovieRankRepository movieRankRepository,IMapper mapper)
        {
            _movieRankRepository = movieRankRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var response = await _movieRankRepository.GetAllItems();
            return _mapper.ToMovieContract(response);
        }

        public async Task<MovieResponse> GetMovie(int userId , string movieName)
        {

            var response = await _movieRankRepository.GetMovie(userId,movieName);
            return _mapper.ToMovieContract(response);
        }
        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesbyMovieTitle(int userId, string movieName)
        {

            var response = await _movieRankRepository.GetUsersRankedMoviesbyMovieTitle(userId, movieName);
            return _mapper.ToMovieContract(response);
        }
        public async Task AddMovie(int userId, MovieRankRequest movieRankRequest)
        {

            var movieDB = _mapper.ToMovieDBModel(userId, movieRankRequest);
            await _movieRankRepository.AddMovie(movieDB);
        }
        public async Task UpdateMovie(int userId, MovieUpdateRequest request)
        {

            var response = await _movieRankRepository.GetMovie(userId, request.MovieName);
            var movieDB = _mapper.ToMovieDBModel(userId, response, request);
            await _movieRankRepository.UpdateMovie(movieDB);
        }
        public async Task<MovieRankResponse> GetMovieRank(string movieName)
        {

            var response = await _movieRankRepository.GetMovieRank(movieName);
            var overrallMovieRanking = Math.Round(response.Select(x => x.Ranking).Average());
            return new MovieRankResponse
            {
                MovieName = movieName,
                OverrallRanking = overrallMovieRanking
            };
        }
    }
}
