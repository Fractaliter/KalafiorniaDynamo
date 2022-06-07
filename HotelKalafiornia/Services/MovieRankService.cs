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
    }
}
