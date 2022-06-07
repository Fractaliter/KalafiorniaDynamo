using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelKalafiornia.Services
{
    public class MovieRankRepository : IMovieRankRepository
    {
        private readonly DynamoDBContext _context;
        public MovieRankRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task<IEnumerable<MovieDb>> GetAllItems()
        {
            return await _context.ScanAsync<MovieDb>(new List<ScanCondition>()).GetRemainingAsync();
        }
        public async Task<MovieDb> GetMovie(int userId, string MovieName)
        {
            return await _context.LoadAsync<MovieDb>(userId,MovieName);
        }


        public async Task<IEnumerable<MovieDb>> GetUsersRankedMoviesbyMovieTitle(int userId, string MovieName)
        {
            var config = new DynamoDBOperationConfig
            {
                QueryFilter = new List<ScanCondition>
                {
                    new ScanCondition("MovieName", ScanOperator.BeginsWith,MovieName)
                }
            };


            return await _context.QueryAsync<MovieDb>(userId, config).GetRemainingAsync();
        }
        public async Task AddMovie(MovieDb movieDb)
        {
            await _context.SaveAsync(movieDb);
        }
    }
}
